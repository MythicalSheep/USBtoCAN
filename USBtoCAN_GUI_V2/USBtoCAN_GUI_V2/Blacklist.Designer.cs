namespace USBtoCAN_GUI_V2
{
    partial class Blacklist
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            blacklistEntries = new ListView();
            filter = new ColumnHeader();
            blacklistAdd = new Button();
            blacklistDelete = new Button();
            blacklistTextbox = new TextBox();
            blackWriteButton = new Button();
            blackReadButton = new Button();
            blackBurnButton = new Button();
            SuspendLayout();
            // 
            // blacklistEntries
            // 
            blacklistEntries.Columns.AddRange(new ColumnHeader[] { filter });
            blacklistEntries.Location = new Point(12, 12);
            blacklistEntries.MultiSelect = false;
            blacklistEntries.Name = "blacklistEntries";
            blacklistEntries.Size = new Size(382, 168);
            blacklistEntries.TabIndex = 0;
            blacklistEntries.UseCompatibleStateImageBehavior = false;
            blacklistEntries.View = View.Details;
            // 
            // filter
            // 
            filter.Text = "Filters";
            // 
            // blacklistAdd
            // 
            blacklistAdd.Location = new Point(400, 41);
            blacklistAdd.Name = "blacklistAdd";
            blacklistAdd.Size = new Size(84, 23);
            blacklistAdd.TabIndex = 1;
            blacklistAdd.Text = "Add Entry";
            blacklistAdd.UseVisualStyleBackColor = true;
            blacklistAdd.Click += blacklistAdd_Click;
            // 
            // blacklistDelete
            // 
            blacklistDelete.Location = new Point(400, 70);
            blacklistDelete.Name = "blacklistDelete";
            blacklistDelete.Size = new Size(84, 23);
            blacklistDelete.TabIndex = 2;
            blacklistDelete.Text = "Delete Entry";
            blacklistDelete.UseVisualStyleBackColor = true;
            blacklistDelete.Click += blacklistDelete_Click;
            // 
            // blacklistTextbox
            // 
            blacklistTextbox.Location = new Point(400, 12);
            blacklistTextbox.Name = "blacklistTextbox";
            blacklistTextbox.Size = new Size(84, 23);
            blacklistTextbox.TabIndex = 3;
            // 
            // blackWriteButton
            // 
            blackWriteButton.Location = new Point(400, 99);
            blackWriteButton.Name = "blackWriteButton";
            blackWriteButton.Size = new Size(84, 23);
            blackWriteButton.TabIndex = 4;
            blackWriteButton.Text = "Write";
            blackWriteButton.UseVisualStyleBackColor = true;
            blackWriteButton.Click += blackWriteButton_Click;
            // 
            // blackReadButton
            // 
            blackReadButton.Location = new Point(400, 128);
            blackReadButton.Name = "blackReadButton";
            blackReadButton.Size = new Size(84, 23);
            blackReadButton.TabIndex = 5;
            blackReadButton.Text = "Read";
            blackReadButton.UseVisualStyleBackColor = true;
            blackReadButton.Click += blackReadButton_Click;
            // 
            // blackBurnButton
            // 
            blackBurnButton.Location = new Point(400, 157);
            blackBurnButton.Name = "blackBurnButton";
            blackBurnButton.Size = new Size(84, 23);
            blackBurnButton.TabIndex = 6;
            blackBurnButton.Text = "Burn";
            blackBurnButton.UseVisualStyleBackColor = true;
            blackBurnButton.Click += blackBurnButton_Click;
            // 
            // Blacklist
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(493, 192);
            Controls.Add(blackBurnButton);
            Controls.Add(blackReadButton);
            Controls.Add(blackWriteButton);
            Controls.Add(blacklistTextbox);
            Controls.Add(blacklistDelete);
            Controls.Add(blacklistAdd);
            Controls.Add(blacklistEntries);
            Name = "Blacklist";
            Text = "Blacklist";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListView blacklistEntries;
        private Button blacklistAdd;
        private Button blacklistDelete;
        private ColumnHeader filter;
        private TextBox blacklistTextbox;
        private Button blackWriteButton;
        private Button blackReadButton;
        private Button blackBurnButton;
    }
}