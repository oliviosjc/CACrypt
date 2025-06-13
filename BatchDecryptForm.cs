using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TwoFishCrypto
{
    public partial class BatchDecryptForm : Form
    {
        private string _sourceFolder = "";
        private string _destinationFolder = "";
        private string _key = "";
        private string _iv = "";
        private List<string> _txtFiles = new List<string>();

        public BatchDecryptForm(string key, string iv)
        {
            InitializeComponent();
            _key = key;
            _iv = iv;
        }

        private void btnSelectSource_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog folderDialog = new FolderBrowserDialog())
            {
                folderDialog.Description = "Selecione a pasta com os arquivos .txt encriptados";
                folderDialog.ShowNewFolderButton = false;

                if (folderDialog.ShowDialog() == DialogResult.OK)
                {
                    _sourceFolder = folderDialog.SelectedPath;
                    txtSourceFolder.Text = _sourceFolder;
                    ScanForTxtFiles();
                }
            }
        }

        private void btnSelectDestination_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog folderDialog = new FolderBrowserDialog())
            {
                folderDialog.Description = "Selecione a pasta de destino para os arquivos decriptados";
                folderDialog.ShowNewFolderButton = true;

                if (folderDialog.ShowDialog() == DialogResult.OK)
                {
                    _destinationFolder = folderDialog.SelectedPath;
                    txtDestinationFolder.Text = _destinationFolder;
                    UpdateStartButtonState();
                }
            }
        }

        private void ScanForTxtFiles()
        {
            try
            {
                _txtFiles.Clear();
                listBoxFiles.Items.Clear();

                if (string.IsNullOrEmpty(_sourceFolder) || !Directory.Exists(_sourceFolder))
                    return;

                // Buscar recursivamente todos os arquivos .txt
                var txtFiles = Directory.GetFiles(_sourceFolder, "*.txt", SearchOption.AllDirectories);
                _txtFiles = txtFiles.ToList();

                // Mostrar na lista
                foreach (var file in _txtFiles)
                {
                    var relativePath = GetRelativePath(_sourceFolder, file);
                    listBoxFiles.Items.Add(relativePath);
                }

                lblFileCount.Text = $"Arquivos encontrados: {_txtFiles.Count}";
                UpdateStartButtonState();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao buscar arquivos: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string GetRelativePath(string baseDir, string fullPath)
        {
            Uri baseUri = new Uri(baseDir.EndsWith(Path.DirectorySeparatorChar.ToString()) ? baseDir : baseDir + Path.DirectorySeparatorChar);
            Uri fullUri = new Uri(fullPath);
            return Uri.UnescapeDataString(baseUri.MakeRelativeUri(fullUri).ToString().Replace('/', Path.DirectorySeparatorChar));
        }

        private void UpdateStartButtonState()
        {
            btnStartDecryption.Enabled = !string.IsNullOrEmpty(_sourceFolder) &&
                                        !string.IsNullOrEmpty(_destinationFolder) &&
                                        _txtFiles.Count > 0;
        }

        private async void btnStartDecryption_Click(object sender, EventArgs e)
        {
            if (_txtFiles.Count == 0)
            {
                MessageBox.Show("Nenhum arquivo .txt encontrado para decriptar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Desabilitar controles
            SetControlsEnabled(false);
            
            progressBar.Maximum = _txtFiles.Count;
            progressBar.Value = 0;
            progressBar.Visible = true;

            int successCount = 0;
            int errorCount = 0;
            var errors = new List<string>();

            txtLog.Clear();
            LogMessage("Iniciando descriptografia em lote...");
            LogMessage($"Total de arquivos: {_txtFiles.Count}");
            LogMessage("");

            await Task.Run(async () =>
            {
                for (int i = 0; i < _txtFiles.Count; i++)
                {
                    var sourceFile = _txtFiles[i];
                    var relativePath = GetRelativePath(_sourceFolder, sourceFile);
                    
                    try
                    {
                        // Criar estrutura de diretórios no destino
                        var destFile = Path.Combine(_destinationFolder, relativePath);
                        var destDir = Path.GetDirectoryName(destFile);
                        
                        if (!Directory.Exists(destDir))
                            Directory.CreateDirectory(destDir);

                        // Decriptar arquivo
                        await Task.Run(() => CryptoHelper.DecryptFile(sourceFile, destFile, _key, _iv));
                        
                        successCount++;
                        this.Invoke((Action)(() =>
                        {
                            LogMessage($"✓ Decriptado: {relativePath}");
                            progressBar.Value = i + 1;
                        }));
                    }
                    catch (Exception ex)
                    {
                        errorCount++;
                        errors.Add($"{relativePath}: {ex.Message}");
                        this.Invoke((Action)(() =>
                        {
                            LogMessage($"✗ Erro: {relativePath} - {ex.Message}");
                            progressBar.Value = i + 1;
                        }));
                    }

                    // Pequena pausa para não sobrecarregar
                    await Task.Delay(10);
                }
            });

            // Relatório final
            LogMessage("");
            LogMessage("=== RELATÓRIO FINAL ===");
            LogMessage($"Arquivos processados: {_txtFiles.Count}");
            LogMessage($"Sucesso: {successCount}");
            LogMessage($"Erros: {errorCount}");
            
            if (errors.Count > 0)
            {
                LogMessage("");
                LogMessage("Arquivos com erro:");
                foreach (var error in errors)
                {
                    LogMessage($"  - {error}");
                }
            }

            // Reabilitar controles
            SetControlsEnabled(true);
            progressBar.Visible = false;

            // Mensagem final
            var message = $"Descriptografia concluída!\n\nSucesso: {successCount}\nErros: {errorCount}";
            var icon = errorCount > 0 ? MessageBoxIcon.Warning : MessageBoxIcon.Information;
            MessageBox.Show(message, "Processo Concluído", MessageBoxButtons.OK, icon);

            // Abrir pasta de destino se tudo deu certo
            if (successCount > 0 && MessageBox.Show("Deseja abrir a pasta de destino?", "Abrir Pasta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                System.Diagnostics.Process.Start("explorer.exe", _destinationFolder);
            }
        }

        private void SetControlsEnabled(bool enabled)
        {
            btnSelectSource.Enabled = enabled;
            btnSelectDestination.Enabled = enabled;
            btnStartDecryption.Enabled = enabled && !string.IsNullOrEmpty(_sourceFolder) && !string.IsNullOrEmpty(_destinationFolder) && _txtFiles.Count > 0;
            btnClose.Enabled = enabled;
        }

        private void LogMessage(string message)
        {
            txtLog.AppendText($"{message}{Environment.NewLine}");
            txtLog.SelectionStart = txtLog.Text.Length;
            txtLog.ScrollToCaret();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}