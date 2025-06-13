namespace TwoFishCrypto
{
    partial class BatchDecryptForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TextBox txtSourceFolder;
        private System.Windows.Forms.TextBox txtDestinationFolder;
        private System.Windows.Forms.Button btnSelectSource;
        private System.Windows.Forms.Button btnSelectDestination;
        private System.Windows.Forms.Label lblSourceFolder;
        private System.Windows.Forms.Label lblDestinationFolder;
        private System.Windows.Forms.ListBox listBoxFiles;
        private System.Windows.Forms.Label lblFiles;
        private System.Windows.Forms.Label lblFileCount;
        private System.Windows.Forms.Button btnStartDecryption;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.TextBox txtLog;
        private System.Windows.Forms.Label lblLog;

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
            this.txtSourceFolder = new System.Windows.Forms.TextBox();
            this.txtDestinationFolder = new System.Windows.Forms.TextBox();
            this.btnSelectSource = new System.Windows.Forms.Button();
            this.btnSelectDestination = new System.Windows.Forms.Button();
            this.lblSourceFolder = new System.Windows.Forms.Label();
            this.lblDestinationFolder = new System.Windows.Forms.Label();
            this.listBoxFiles = new System.Windows.Forms.ListBox();
            this.lblFiles = new System.Windows.Forms.Label();
            this.lblFileCount = new System.Windows.Forms.Label();
            this.btnStartDecryption = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.txtLog = new System.Windows.Forms.TextBox();
            this.lblLog = new System.Windows.Forms.Label();
            this.SuspendLayout();
            
            // lblSourceFolder
            this.lblSourceFolder.AutoSize = true;
            this.lblSourceFolder.Location = new System.Drawing.Point(12, 15);
            this.lblSourceFolder.Name = "lblSourceFolder";
            this.lblSourceFolder.Size = new System.Drawing.Size(90, 15);
            this.lblSourceFolder.TabIndex = 0;
            this.lblSourceFolder.Text = "Pasta de origem:";
            
            // txtSourceFolder
            this.txtSourceFolder.Location = new System.Drawing.Point(12, 33);
            this.txtSourceFolder.Name = "txtSourceFolder";
            this.txtSourceFolder.ReadOnly = true;
            this.txtSourceFolder.Size = new System.Drawing.Size(500, 23);
            this.txtSourceFolder.TabIndex = 1;
            
            // btnSelectSource
            this.btnSelectSource.Location = new System.Drawing.Point(518, 32);
            this.btnSelectSource.Name = "btnSelectSource";
            this.btnSelectSource.Size = new System.Drawing.Size(120, 25);
            this.btnSelectSource.TabIndex = 2;
            this.btnSelectSource.Text = "Selecionar";
            this.btnSelectSource.UseVisualStyleBackColor = true;
            this.btnSelectSource.Click += new System.EventHandler(this.btnSelectSource_Click);
            
            // lblDestinationFolder
            this.lblDestinationFolder.AutoSize = true;
            this.lblDestinationFolder.Location = new System.Drawing.Point(12, 70);
            this.lblDestinationFolder.Name = "lblDestinationFolder";
            this.lblDestinationFolder.Size = new System.Drawing.Size(95, 15);
            this.lblDestinationFolder.TabIndex = 3;
            this.lblDestinationFolder.Text = "Pasta de destino:";
            
            // txtDestinationFolder
            this.txtDestinationFolder.Location = new System.Drawing.Point(12, 88);
            this.txtDestinationFolder.Name = "txtDestinationFolder";
            this.txtDestinationFolder.ReadOnly = true;
            this.txtDestinationFolder.Size = new System.Drawing.Size(500, 23);
            this.txtDestinationFolder.TabIndex = 4;
            
            // btnSelectDestination
            this.btnSelectDestination.Location = new System.Drawing.Point(518, 87);
            this.btnSelectDestination.Name = "btnSelectDestination";
            this.btnSelectDestination.Size = new System.Drawing.Size(120, 25);
            this.btnSelectDestination.TabIndex = 5;
            this.btnSelectDestination.Text = "Selecionar";
            this.btnSelectDestination.UseVisualStyleBackColor = true;
            this.btnSelectDestination.Click += new System.EventHandler(this.btnSelectDestination_Click);
            
            // lblFiles
            this.lblFiles.AutoSize = true;
            this.lblFiles.Location = new System.Drawing.Point(12, 125);
            this.lblFiles.Name = "lblFiles";
            this.lblFiles.Size = new System.Drawing.Size(125, 15);
            this.lblFiles.TabIndex = 6;
            this.lblFiles.Text = "Arquivos encontrados:";
            
            // lblFileCount
            this.lblFileCount.AutoSize = true;
            this.lblFileCount.Location = new System.Drawing.Point(450, 125);
            this.lblFileCount.Name = "lblFileCount";
            this.lblFileCount.Size = new System.Drawing.Size(132, 15);
            this.lblFileCount.TabIndex = 7;
            this.lblFileCount.Text = "Arquivos encontrados: 0";
            
            // listBoxFiles
            this.listBoxFiles.FormattingEnabled = true;
            this.listBoxFiles.ItemHeight = 15;
            this.listBoxFiles.Location = new System.Drawing.Point(12, 143);
            this.listBoxFiles.Name = "listBoxFiles";
            this.listBoxFiles.ScrollAlwaysVisible = true;
            this.listBoxFiles.Size = new System.Drawing.Size(626, 154);
            this.listBoxFiles.TabIndex = 8;
            
            // lblLog
            this.lblLog.AutoSize = true;
            this.lblLog.Location = new System.Drawing.Point(12, 310);
            this.lblLog.Name = "lblLog";
            this.lblLog.Size = new System.Drawing.Size(30, 15);
            this.lblLog.TabIndex = 9;
            this.lblLog.Text = "Log:";
            
            // txtLog
            this.txtLog.Location = new System.Drawing.Point(12, 328);
            this.txtLog.Multiline = true;
            this.txtLog.Name = "txtLog";
            this.txtLog.ReadOnly = true;
            this.txtLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtLog.Size = new System.Drawing.Size(626, 150);
            this.txtLog.TabIndex = 10;
            
            // progressBar
            this.progressBar.Location = new System.Drawing.Point(12, 490);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(626, 23);
            this.progressBar.TabIndex = 11;
            this.progressBar.Visible = false;
            
            // btnStartDecryption
            this.btnStartDecryption.Enabled = false;
            this.btnStartDecryption.Location = new System.Drawing.Point(12, 525);
            this.btnStartDecryption.Name = "btnStartDecryption";
            this.btnStartDecryption.Size = new System.Drawing.Size(200, 35);
            this.btnStartDecryption.TabIndex = 12;
            this.btnStartDecryption.Text = "Iniciar Descriptografia";
            this.btnStartDecryption.UseVisualStyleBackColor = true;
            this.btnStartDecryption.Click += new System.EventHandler(this.btnStartDecryption_Click);
            
            // btnClose
            this.btnClose.Location = new System.Drawing.Point(538, 525);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(100, 35);
            this.btnClose.TabIndex = 13;
            this.btnClose.Text = "Fechar";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            
            // BatchDecryptForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(650, 572);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnStartDecryption);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.txtLog);
            this.Controls.Add(this.lblLog);
            this.Controls.Add(this.listBoxFiles);
            this.Controls.Add(this.lblFileCount);
            this.Controls.Add(this.lblFiles);
            this.Controls.Add(this.btnSelectDestination);
            this.Controls.Add(this.txtDestinationFolder);
            this.Controls.Add(this.lblDestinationFolder);
            this.Controls.Add(this.btnSelectSource);
            this.Controls.Add(this.txtSourceFolder);
            this.Controls.Add(this.lblSourceFolder);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "BatchDecryptForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Combat Arms Decrypt and Encrypt TXT Files - by Olívio Rodrigues";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}