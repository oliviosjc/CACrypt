using System;
using System.IO;
using System.Windows.Forms;
using System.Threading.Tasks;

namespace TwoFishCrypto
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 1;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string selectedFile = openFileDialog.FileName;
                    string extension = Path.GetExtension(selectedFile).ToLower();
                    
                    if (extension != ".txt")
                    {
                        MessageBox.Show("Por favor, selecione apenas arquivos com extensão .txt", 
                            "Tipo de arquivo inválido", 
                            MessageBoxButtons.OK, 
                            MessageBoxIcon.Warning);
                        Log($"Arquivo rejeitado: {selectedFile} (extensão inválida: {extension})");
                        return;
                    }
                    
                    txtFilePath.Text = selectedFile;
                    Log($"Arquivo selecionado: {selectedFile}");
                }
            }
        }

        private void btnEncrypt_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidateInputs())
                    return;

                string inputFile = txtFilePath.Text;
                string outputFile = Path.Combine(
                    Path.GetDirectoryName(inputFile) ?? "",
                    Path.GetFileNameWithoutExtension(inputFile) + "_encrypted.txt"
                );

                CryptoHelper.EncryptFile(inputFile, outputFile, txtKey.Text.Trim(), txtIV.Text.Trim());
                
                Log($"Arquivo encriptado com sucesso!");
                Log($"Arquivo de saída: {outputFile}");
                MessageBox.Show("Arquivo encriptado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                Log($"Erro ao encriptar: {ex.Message}");
                MessageBox.Show($"Erro ao encriptar: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnDecrypt_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidateInputs())
                    return;

                string inputFile = txtFilePath.Text;
                
                // Disable buttons and show progress bar
                btnEncrypt.Enabled = false;
                btnDecrypt.Enabled = false;
                btnBrowse.Enabled = false;
                progressBar.Visible = true;
                progressBar.Value = 0;
                progressBar.Maximum = 100;
                
                Log($"Iniciando descriptografia...");
                
                // Simulate progress with async task
                string decryptedContent = "";
                await Task.Run(async () =>
                {
                    // Simulate reading file (0-20%)
                    for (int i = 0; i <= 20; i += 5)
                    {
                        await Task.Delay(50);
                        this.Invoke((Action)(() => progressBar.Value = i));
                    }
                    
                    // Simulate decryption process (20-80%)
                    decryptedContent = CryptoHelper.DecryptFileToString(inputFile, txtKey.Text.Trim(), txtIV.Text.Trim());
                    
                    for (int i = 20; i <= 80; i += 10)
                    {
                        await Task.Delay(100);
                        this.Invoke((Action)(() => progressBar.Value = i));
                    }
                    
                    // Simulate final processing (80-100%)
                    for (int i = 80; i <= 100; i += 5)
                    {
                        await Task.Delay(50);
                        this.Invoke((Action)(() => progressBar.Value = i));
                    }
                });
                
                txtDecryptedContent.Text = decryptedContent;
                btnSaveDecrypted.Enabled = true;
                
                Log($"Arquivo decriptado com sucesso!");
                Log($"Conteúdo exibido na área de texto abaixo.");
                MessageBox.Show("Arquivo decriptado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                Log($"Erro ao decriptar: {ex.Message}");
                txtDecryptedContent.Text = "";
                btnSaveDecrypted.Enabled = false;
                MessageBox.Show($"Erro ao decriptar: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // Re-enable buttons and hide progress bar
                btnEncrypt.Enabled = true;
                btnDecrypt.Enabled = true;
                btnBrowse.Enabled = true;
                progressBar.Visible = false;
                progressBar.Value = 0;
            }
        }

        private bool ValidateInputs()
        {
            if (string.IsNullOrWhiteSpace(txtFilePath.Text))
            {
                MessageBox.Show("Por favor, selecione um arquivo TXT.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (!File.Exists(txtFilePath.Text))
            {
                MessageBox.Show("O arquivo selecionado não existe.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            
            // Validate file extension
            string extension = Path.GetExtension(txtFilePath.Text).ToLower();
            if (extension != ".txt")
            {
                MessageBox.Show("Por favor, selecione apenas arquivos com extensão .txt", 
                    "Tipo de arquivo inválido", 
                    MessageBoxButtons.OK, 
                    MessageBoxIcon.Warning);
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtKey.Text))
            {
                MessageBox.Show("Por favor, insira a chave (Key).", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            string cleanKey = txtKey.Text.Replace(" ", "");
            if (cleanKey.Length != 64)
            {
                MessageBox.Show("A chave deve ter exatamente 64 caracteres hexadecimais (32 bytes).", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (!string.IsNullOrWhiteSpace(txtIV.Text))
            {
                string cleanIV = txtIV.Text.Replace(" ", "");
                if (cleanIV.Length != 32)
                {
                    MessageBox.Show("O IV deve ter exatamente 32 caracteres hexadecimais (16 bytes).", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            else
            {
                MessageBox.Show("IV não foi fornecido. Usando IV padrão de zeros.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtIV.Text = new string('0', 32);
            }

            return true;
        }

        private void Log(string message)
        {
            txtLog.AppendText($"[{DateTime.Now:HH:mm:ss}] {message}{Environment.NewLine}");
            txtLog.SelectionStart = txtLog.Text.Length;
            txtLog.ScrollToCaret();
        }

        private void btnSaveDecrypted_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtDecryptedContent.Text))
                {
                    MessageBox.Show("Não há conteúdo decriptado para salvar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                {
                    saveFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
                    saveFileDialog.FilterIndex = 1;
                    saveFileDialog.RestoreDirectory = true;
                    saveFileDialog.FileName = "decrypted_content.txt";

                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        File.WriteAllText(saveFileDialog.FileName, txtDecryptedContent.Text);
                        Log($"Conteúdo salvo em: {saveFileDialog.FileName}");
                        MessageBox.Show("Conteúdo salvo com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                Log($"Erro ao salvar: {ex.Message}");
                MessageBox.Show($"Erro ao salvar o arquivo: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        private void btnBatchDecrypt_Click(object sender, EventArgs e)
        {
            // Validar se as chaves foram fornecidas
            if (string.IsNullOrWhiteSpace(txtKey.Text))
            {
                MessageBox.Show("Por favor, insira a chave (Key) antes de usar a descriptografia em lote.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string cleanKey = txtKey.Text.Replace(" ", "");
            if (cleanKey.Length != 64)
            {
                MessageBox.Show("A chave deve ter exatamente 64 caracteres hexadecimais (32 bytes).", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string iv = txtIV.Text.Trim();
            if (string.IsNullOrWhiteSpace(iv))
            {
                iv = new string('0', 32);
            }
            else
            {
                string cleanIV = iv.Replace(" ", "");
                if (cleanIV.Length != 32)
                {
                    MessageBox.Show("O IV deve ter exatamente 32 caracteres hexadecimais (16 bytes).", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            // Abrir o formulário de descriptografia em lote
            using (BatchDecryptForm batchForm = new BatchDecryptForm(txtKey.Text.Trim(), iv))
            {
                batchForm.ShowDialog(this);
            }

            Log("Formulário de descriptografia em lote fechado.");
        }
    }
}