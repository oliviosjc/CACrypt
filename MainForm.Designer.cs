namespace TwoFishCrypto
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TextBox txtFilePath;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.TextBox txtKey;
        private System.Windows.Forms.TextBox txtIV;
        private System.Windows.Forms.Button btnEncrypt;
        private System.Windows.Forms.Button btnDecrypt;
        private System.Windows.Forms.Label lblFile;
        private System.Windows.Forms.Label lblKey;
        private System.Windows.Forms.Label lblIV;
        private System.Windows.Forms.TextBox txtLog;
        private System.Windows.Forms.Label lblLog;
        private System.Windows.Forms.TextBox txtDecryptedContent;
        private System.Windows.Forms.Label lblDecryptedContent;
        private System.Windows.Forms.Button btnSaveDecrypted;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Label lblFooter;
        private System.Windows.Forms.Button btnBatchDecrypt;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.txtFilePath = new System.Windows.Forms.TextBox();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.txtKey = new System.Windows.Forms.TextBox();
            this.txtIV = new System.Windows.Forms.TextBox();
            this.btnEncrypt = new System.Windows.Forms.Button();
            this.btnDecrypt = new System.Windows.Forms.Button();
            this.lblFile = new System.Windows.Forms.Label();
            this.lblKey = new System.Windows.Forms.Label();
            this.lblIV = new System.Windows.Forms.Label();
            this.txtLog = new System.Windows.Forms.TextBox();
            this.lblLog = new System.Windows.Forms.Label();
            this.txtDecryptedContent = new System.Windows.Forms.TextBox();
            this.lblDecryptedContent = new System.Windows.Forms.Label();
            this.btnSaveDecrypted = new System.Windows.Forms.Button();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.lblFooter = new System.Windows.Forms.Label();
            this.btnBatchDecrypt = new System.Windows.Forms.Button();
            this.SuspendLayout();
            
            // lblFile
            this.lblFile.AutoSize = true;
            this.lblFile.Location = new System.Drawing.Point(12, 15);
            this.lblFile.Name = "lblFile";
            this.lblFile.Size = new System.Drawing.Size(74, 15);
            this.lblFile.TabIndex = 0;
            this.lblFile.Text = "Arquivo TXT:";
            
            // txtFilePath
            this.txtFilePath.Location = new System.Drawing.Point(12, 33);
            this.txtFilePath.Name = "txtFilePath";
            this.txtFilePath.ReadOnly = true;
            this.txtFilePath.Size = new System.Drawing.Size(620, 23);
            this.txtFilePath.TabIndex = 1;
            
            // btnBrowse
            this.btnBrowse.Location = new System.Drawing.Point(638, 32);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(150, 25);
            this.btnBrowse.TabIndex = 2;
            this.btnBrowse.Text = "Procurar";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            
            // lblKey
            this.lblKey.AutoSize = true;
            this.lblKey.Location = new System.Drawing.Point(12, 70);
            this.lblKey.Name = "lblKey";
            this.lblKey.Size = new System.Drawing.Size(58, 15);
            this.lblKey.TabIndex = 3;
            this.lblKey.Text = "Key (hex):";
            
            // txtKey
            this.txtKey.Location = new System.Drawing.Point(12, 88);
            this.txtKey.Name = "txtKey";
            this.txtKey.Size = new System.Drawing.Size(776, 23);
            this.txtKey.TabIndex = 4;
            this.txtKey.Text = "620C724A2FF22C975B5A2B9C21430820227B3D2800193AAA4CF3128803AC3ABD";
            
            // lblIV
            this.lblIV.AutoSize = true;
            this.lblIV.Location = new System.Drawing.Point(12, 125);
            this.lblIV.Name = "lblIV";
            this.lblIV.Size = new System.Drawing.Size(76, 15);
            this.lblIV.TabIndex = 5;
            this.lblIV.Text = "IV (optional):";
            
            // txtIV
            this.txtIV.Location = new System.Drawing.Point(12, 143);
            this.txtIV.Name = "txtIV";
            this.txtIV.Size = new System.Drawing.Size(776, 23);
            this.txtIV.TabIndex = 6;
            this.txtIV.Text = "56B83E3F68B60F0F29357BED335E5642";
            
            // btnEncrypt
            this.btnEncrypt.Location = new System.Drawing.Point(12, 180);
            this.btnEncrypt.Name = "btnEncrypt";
            this.btnEncrypt.Size = new System.Drawing.Size(380, 35);
            this.btnEncrypt.TabIndex = 7;
            this.btnEncrypt.Text = "Encriptar";
            this.btnEncrypt.UseVisualStyleBackColor = true;
            this.btnEncrypt.Click += new System.EventHandler(this.btnEncrypt_Click);
            
            // btnDecrypt
            this.btnDecrypt.Location = new System.Drawing.Point(408, 180);
            this.btnDecrypt.Name = "btnDecrypt";
            this.btnDecrypt.Size = new System.Drawing.Size(380, 35);
            this.btnDecrypt.TabIndex = 8;
            this.btnDecrypt.Text = "Decriptar";
            this.btnDecrypt.UseVisualStyleBackColor = true;
            this.btnDecrypt.Click += new System.EventHandler(this.btnDecrypt_Click);
            
            // lblLog
            this.lblLog.AutoSize = true;
            this.lblLog.Location = new System.Drawing.Point(12, 230);
            this.lblLog.Name = "lblLog";
            this.lblLog.Size = new System.Drawing.Size(30, 15);
            this.lblLog.TabIndex = 9;
            this.lblLog.Text = "Log:";
            
            // txtLog
            this.txtLog.Location = new System.Drawing.Point(12, 270);
            this.txtLog.Multiline = true;
            this.txtLog.Name = "txtLog";
            this.txtLog.ReadOnly = true;
            this.txtLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtLog.Size = new System.Drawing.Size(776, 80);
            this.txtLog.TabIndex = 10;
            
            // lblDecryptedContent
            this.lblDecryptedContent.AutoSize = true;
            this.lblDecryptedContent.Location = new System.Drawing.Point(12, 365);
            this.lblDecryptedContent.Name = "lblDecryptedContent";
            this.lblDecryptedContent.Size = new System.Drawing.Size(124, 15);
            this.lblDecryptedContent.TabIndex = 11;
            this.lblDecryptedContent.Text = "Conteúdo Decriptado:";
            
            // btnSaveDecrypted
            this.btnSaveDecrypted.Location = new System.Drawing.Point(638, 358);
            this.btnSaveDecrypted.Name = "btnSaveDecrypted";
            this.btnSaveDecrypted.Size = new System.Drawing.Size(150, 25);
            this.btnSaveDecrypted.TabIndex = 13;
            this.btnSaveDecrypted.Text = "Salvar Conteúdo";
            this.btnSaveDecrypted.UseVisualStyleBackColor = true;
            this.btnSaveDecrypted.Enabled = false;
            this.btnSaveDecrypted.Click += new System.EventHandler(this.btnSaveDecrypted_Click);
            
            // txtDecryptedContent
            this.txtDecryptedContent.Location = new System.Drawing.Point(12, 385);
            this.txtDecryptedContent.Multiline = true;
            this.txtDecryptedContent.Name = "txtDecryptedContent";
            this.txtDecryptedContent.ReadOnly = true;
            this.txtDecryptedContent.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtDecryptedContent.Size = new System.Drawing.Size(776, 180);
            this.txtDecryptedContent.TabIndex = 12;
            
            // progressBar
            this.progressBar.Location = new System.Drawing.Point(12, 230);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(776, 23);
            this.progressBar.TabIndex = 14;
            this.progressBar.Visible = false;
            
            // lblFooter
            this.lblFooter.AutoSize = true;
            this.lblFooter.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblFooter.Location = new System.Drawing.Point(12, 575);
            this.lblFooter.Name = "lblFooter";
            this.lblFooter.Size = new System.Drawing.Size(215, 15);
            this.lblFooter.TabIndex = 15;
            this.lblFooter.Text = "Desenvolvido por Olívio Rodrigues";
            
            // btnBatchDecrypt
            this.btnBatchDecrypt.Location = new System.Drawing.Point(638, 565);
            this.btnBatchDecrypt.Name = "btnBatchDecrypt";
            this.btnBatchDecrypt.Size = new System.Drawing.Size(150, 30);
            this.btnBatchDecrypt.TabIndex = 16;
            this.btnBatchDecrypt.Text = "Decriptar em Lote";
            this.btnBatchDecrypt.UseVisualStyleBackColor = true;
            this.btnBatchDecrypt.Click += new System.EventHandler(this.btnBatchDecrypt_Click);
            
            // MainForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Controls.Add(this.btnBatchDecrypt);
            this.Controls.Add(this.lblFooter);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.btnSaveDecrypted);
            this.Controls.Add(this.txtDecryptedContent);
            this.Controls.Add(this.lblDecryptedContent);
            this.Controls.Add(this.txtLog);
            this.Controls.Add(this.lblLog);
            this.Controls.Add(this.btnDecrypt);
            this.Controls.Add(this.btnEncrypt);
            this.Controls.Add(this.txtIV);
            this.Controls.Add(this.lblIV);
            this.Controls.Add(this.txtKey);
            this.Controls.Add(this.lblKey);
            this.Controls.Add(this.btnBrowse);
            this.Controls.Add(this.txtFilePath);
            this.Controls.Add(this.lblFile);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Combat Arms Decrypt and Encrypt TXT Files - by Olívio Rodrigues";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}