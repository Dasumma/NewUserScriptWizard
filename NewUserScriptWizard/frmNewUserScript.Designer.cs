namespace NewUserScriptWizard
{
    partial class FrmNewUserScript
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            LstFacilities = new ListBox();
            LstDrives = new ListBox();
            LstPrinters = new ListBox();
            TxtUserName = new TextBox();
            LblUserName = new Label();
            LblFacilities = new Label();
            LblDrives = new Label();
            LblPrinters = new Label();
            BtnCreateScript = new Button();
            SuspendLayout();
            // 
            // LstFacilities
            // 
            LstFacilities.FormattingEnabled = true;
            LstFacilities.Location = new Point(31, 93);
            LstFacilities.Name = "LstFacilities";
            LstFacilities.Size = new Size(150, 304);
            LstFacilities.TabIndex = 1;
            LstFacilities.SelectedIndexChanged += LstFacilities_SelectedIndexChanged;
            // 
            // LstDrives
            // 
            LstDrives.FormattingEnabled = true;
            LstDrives.Location = new Point(292, 93);
            LstDrives.Name = "LstDrives";
            LstDrives.SelectionMode = SelectionMode.MultiExtended;
            LstDrives.Size = new Size(150, 304);
            LstDrives.TabIndex = 2;
            // 
            // LstPrinters
            // 
            LstPrinters.FormattingEnabled = true;
            LstPrinters.Location = new Point(561, 93);
            LstPrinters.Name = "LstPrinters";
            LstPrinters.SelectionMode = SelectionMode.MultiExtended;
            LstPrinters.Size = new Size(150, 304);
            LstPrinters.TabIndex = 3;
            // 
            // TxtUserName
            // 
            TxtUserName.Location = new Point(31, 31);
            TxtUserName.Name = "TxtUserName";
            TxtUserName.Size = new Size(150, 27);
            TxtUserName.TabIndex = 0;
            // 
            // LblUserName
            // 
            LblUserName.AutoSize = true;
            LblUserName.Location = new Point(31, 9);
            LblUserName.Name = "LblUserName";
            LblUserName.Size = new Size(85, 20);
            LblUserName.TabIndex = 2;
            LblUserName.Text = "User Name:";
            // 
            // LblFacilities
            // 
            LblFacilities.AutoSize = true;
            LblFacilities.Location = new Point(31, 70);
            LblFacilities.Name = "LblFacilities";
            LblFacilities.Size = new Size(65, 20);
            LblFacilities.TabIndex = 2;
            LblFacilities.Text = "Facilities";
            // 
            // LblDrives
            // 
            LblDrives.AutoSize = true;
            LblDrives.Location = new Point(292, 70);
            LblDrives.Name = "LblDrives";
            LblDrives.Size = new Size(50, 20);
            LblDrives.TabIndex = 2;
            LblDrives.Text = "Drives";
            // 
            // LblPrinters
            // 
            LblPrinters.AutoSize = true;
            LblPrinters.Location = new Point(561, 70);
            LblPrinters.Name = "LblPrinters";
            LblPrinters.Size = new Size(58, 20);
            LblPrinters.TabIndex = 2;
            LblPrinters.Text = "Printers";
            // 
            // BtnCreateScript
            // 
            BtnCreateScript.Location = new Point(561, 409);
            BtnCreateScript.Name = "BtnCreateScript";
            BtnCreateScript.Size = new Size(150, 29);
            BtnCreateScript.TabIndex = 4;
            BtnCreateScript.Text = "Create Script";
            BtnCreateScript.UseVisualStyleBackColor = true;
            BtnCreateScript.Click += BtnCreateScript_Click;
            // 
            // FrmNewUserScript
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(746, 450);
            Controls.Add(BtnCreateScript);
            Controls.Add(LblPrinters);
            Controls.Add(LblDrives);
            Controls.Add(LblFacilities);
            Controls.Add(LblUserName);
            Controls.Add(TxtUserName);
            Controls.Add(LstPrinters);
            Controls.Add(LstDrives);
            Controls.Add(LstFacilities);
            Name = "FrmNewUserScript";
            Text = "New User Script Wizard";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListBox LstFacilities;
        private ListBox LstDrives;
        private ListBox LstPrinters;
        private TextBox TxtUserName;
        private Label LblUserName;
        private Label LblFacilities;
        private Label LblDrives;
        private Label LblPrinters;
        private Button BtnCreateScript;
    }
}
