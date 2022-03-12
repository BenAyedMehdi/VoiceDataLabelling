namespace SoundLabelling
{
    partial class mainForm
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.BrowseButton = new System.Windows.Forms.Button();
            this.PathTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.CommandTypesListBox = new System.Windows.Forms.ListBox();
            this.RenameFolderButton = new System.Windows.Forms.Button();
            this.SampleFilesListBox = new System.Windows.Forms.ListBox();
            this.LabelsListBox = new System.Windows.Forms.ListBox();
            this.PlayButton = new System.Windows.Forms.Button();
            this.NextButton = new System.Windows.Forms.Button();
            this.UnacceptableButton = new System.Windows.Forms.Button();
            this.RenameFileButton = new System.Windows.Forms.Button();
            this.moveAndRenameFileButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Root folder:";
            // 
            // BrowseButton
            // 
            this.BrowseButton.Location = new System.Drawing.Point(871, 10);
            this.BrowseButton.Name = "BrowseButton";
            this.BrowseButton.Size = new System.Drawing.Size(26, 23);
            this.BrowseButton.TabIndex = 1;
            this.BrowseButton.Text = "...";
            this.BrowseButton.UseVisualStyleBackColor = true;
            this.BrowseButton.Click += new System.EventHandler(this.BrowseButton_Click);
            // 
            // PathTextBox
            // 
            this.PathTextBox.Location = new System.Drawing.Point(82, 11);
            this.PathTextBox.Name = "PathTextBox";
            this.PathTextBox.Size = new System.Drawing.Size(788, 20);
            this.PathTextBox.TabIndex = 2;
            this.PathTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.PathTextBox_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Folder structure:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(196, 41);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Command type:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(340, 41);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Sample files:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(690, 41);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "Labels:";
            // 
            // treeView1
            // 
            this.treeView1.Location = new System.Drawing.Point(16, 67);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(177, 316);
            this.treeView1.TabIndex = 7;
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            // 
            // CommandTypesListBox
            // 
            this.CommandTypesListBox.FormattingEnabled = true;
            this.CommandTypesListBox.Location = new System.Drawing.Point(199, 67);
            this.CommandTypesListBox.Name = "CommandTypesListBox";
            this.CommandTypesListBox.Size = new System.Drawing.Size(139, 264);
            this.CommandTypesListBox.TabIndex = 8;
            this.CommandTypesListBox.SelectedIndexChanged += new System.EventHandler(this.lbxCommandType_SelectedIndexChanged);
            // 
            // RenameFolderButton
            // 
            this.RenameFolderButton.Enabled = false;
            this.RenameFolderButton.Location = new System.Drawing.Point(199, 344);
            this.RenameFolderButton.Name = "RenameFolderButton";
            this.RenameFolderButton.Size = new System.Drawing.Size(138, 39);
            this.RenameFolderButton.TabIndex = 9;
            this.RenameFolderButton.Text = "Rename folder";
            this.RenameFolderButton.UseVisualStyleBackColor = true;
            this.RenameFolderButton.Click += new System.EventHandler(this.RenameFolderButton_Click);
            // 
            // SampleFilesListBox
            // 
            this.SampleFilesListBox.FormattingEnabled = true;
            this.SampleFilesListBox.Location = new System.Drawing.Point(344, 67);
            this.SampleFilesListBox.Name = "SampleFilesListBox";
            this.SampleFilesListBox.Size = new System.Drawing.Size(344, 316);
            this.SampleFilesListBox.TabIndex = 10;
            // 
            // LabelsListBox
            // 
            this.LabelsListBox.FormattingEnabled = true;
            this.LabelsListBox.Location = new System.Drawing.Point(692, 67);
            this.LabelsListBox.Name = "LabelsListBox";
            this.LabelsListBox.Size = new System.Drawing.Size(177, 316);
            this.LabelsListBox.TabIndex = 11;
            // 
            // PlayButton
            // 
            this.PlayButton.Enabled = false;
            this.PlayButton.Location = new System.Drawing.Point(874, 67);
            this.PlayButton.Name = "PlayButton";
            this.PlayButton.Size = new System.Drawing.Size(118, 37);
            this.PlayButton.TabIndex = 12;
            this.PlayButton.Text = "Play";
            this.PlayButton.UseVisualStyleBackColor = true;
            this.PlayButton.Click += new System.EventHandler(this.PlayButton_Click);
            // 
            // NextButton
            // 
            this.NextButton.Enabled = false;
            this.NextButton.Location = new System.Drawing.Point(874, 137);
            this.NextButton.Name = "NextButton";
            this.NextButton.Size = new System.Drawing.Size(118, 35);
            this.NextButton.TabIndex = 13;
            this.NextButton.Text = "Next";
            this.NextButton.UseVisualStyleBackColor = true;
            this.NextButton.Click += new System.EventHandler(this.NextButton_Click);
            // 
            // UnacceptableButton
            // 
            this.UnacceptableButton.Enabled = false;
            this.UnacceptableButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UnacceptableButton.ForeColor = System.Drawing.Color.Red;
            this.UnacceptableButton.Location = new System.Drawing.Point(874, 203);
            this.UnacceptableButton.Name = "UnacceptableButton";
            this.UnacceptableButton.Size = new System.Drawing.Size(118, 40);
            this.UnacceptableButton.TabIndex = 14;
            this.UnacceptableButton.Text = "Sample unacceptable";
            this.UnacceptableButton.UseVisualStyleBackColor = true;
            this.UnacceptableButton.Click += new System.EventHandler(this.UnacceptableButton_Click);
            // 
            // RenameFileButton
            // 
            this.RenameFileButton.Enabled = false;
            this.RenameFileButton.Location = new System.Drawing.Point(874, 344);
            this.RenameFileButton.Name = "RenameFileButton";
            this.RenameFileButton.Size = new System.Drawing.Size(118, 39);
            this.RenameFileButton.TabIndex = 16;
            this.RenameFileButton.Text = "Rename file";
            this.RenameFileButton.UseVisualStyleBackColor = true;
            this.RenameFileButton.Click += new System.EventHandler(this.RenameFileButton_Click);
            // 
            // moveAndRenameFileButton
            // 
            this.moveAndRenameFileButton.Enabled = false;
            this.moveAndRenameFileButton.Location = new System.Drawing.Point(874, 274);
            this.moveAndRenameFileButton.Margin = new System.Windows.Forms.Padding(2);
            this.moveAndRenameFileButton.Name = "moveAndRenameFileButton";
            this.moveAndRenameFileButton.Size = new System.Drawing.Size(118, 39);
            this.moveAndRenameFileButton.TabIndex = 17;
            this.moveAndRenameFileButton.Text = "Move and rename file";
            this.moveAndRenameFileButton.UseVisualStyleBackColor = true;
            this.moveAndRenameFileButton.Click += new System.EventHandler(this.moveAndRenameFileButton_Click);
            // 
            // mainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1002, 401);
            this.Controls.Add(this.moveAndRenameFileButton);
            this.Controls.Add(this.RenameFileButton);
            this.Controls.Add(this.UnacceptableButton);
            this.Controls.Add(this.NextButton);
            this.Controls.Add(this.PlayButton);
            this.Controls.Add(this.LabelsListBox);
            this.Controls.Add(this.SampleFilesListBox);
            this.Controls.Add(this.RenameFolderButton);
            this.Controls.Add(this.CommandTypesListBox);
            this.Controls.Add(this.treeView1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.PathTextBox);
            this.Controls.Add(this.BrowseButton);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "mainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sound labelling";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Button BrowseButton;
        private System.Windows.Forms.TextBox PathTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.ListBox CommandTypesListBox;
        private System.Windows.Forms.Button RenameFolderButton;
        private System.Windows.Forms.ListBox SampleFilesListBox;
        private System.Windows.Forms.ListBox LabelsListBox;
        private System.Windows.Forms.Button PlayButton;
        private System.Windows.Forms.Button NextButton;
        private System.Windows.Forms.Button UnacceptableButton;
        private System.Windows.Forms.Button RenameFileButton;
        private System.Windows.Forms.Button moveAndRenameFileButton;
    }
}

