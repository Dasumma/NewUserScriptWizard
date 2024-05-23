using Newtonsoft.Json;
using System.IO;
using System.Windows.Forms;

namespace NewUserInfo
{
    partial class NewUserScript
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
            this.lstFacilities = new System.Windows.Forms.ListBox();
            this.lstDrives = new System.Windows.Forms.ListBox();
            this.lstPrinters = new System.Windows.Forms.ListBox();
            this.btnCreateScript = new System.Windows.Forms.Button();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.lblFacilities = new System.Windows.Forms.Label();
            this.lblDrives = new System.Windows.Forms.Label();
            this.lblPrinters = new System.Windows.Forms.Label();
            this.lblUserName = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lstFacilities
            // 
            this.lstFacilities.FormattingEnabled = true;
            this.lstFacilities.ItemHeight = 16;
            this.lstFacilities.Location = new System.Drawing.Point(43, 67);
            this.lstFacilities.Name = "lstFacilities";
            this.lstFacilities.Size = new System.Drawing.Size(186, 356);
            this.lstFacilities.TabIndex = 1;
            this.lstFacilities.SelectedIndexChanged += new System.EventHandler(this.facilities_SelectedIndexChanged);
            // 
            // lstDrives
            // 
            this.lstDrives.FormattingEnabled = true;
            this.lstDrives.ItemHeight = 16;
            this.lstDrives.Location = new System.Drawing.Point(307, 67);
            this.lstDrives.Name = "lstDrives";
            this.lstDrives.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lstDrives.Size = new System.Drawing.Size(186, 356);
            this.lstDrives.TabIndex = 2;
            // 
            // lstPrinters
            // 
            this.lstPrinters.FormattingEnabled = true;
            this.lstPrinters.ItemHeight = 16;
            this.lstPrinters.Location = new System.Drawing.Point(578, 67);
            this.lstPrinters.Name = "lstPrinters";
            this.lstPrinters.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lstPrinters.Size = new System.Drawing.Size(186, 356);
            this.lstPrinters.TabIndex = 3;
            // 
            // btnCreateScript
            // 
            this.btnCreateScript.Location = new System.Drawing.Point(607, 434);
            this.btnCreateScript.Name = "btnCreateScript";
            this.btnCreateScript.Size = new System.Drawing.Size(133, 23);
            this.btnCreateScript.TabIndex = 4;
            this.btnCreateScript.Text = "Create Script";
            this.btnCreateScript.UseVisualStyleBackColor = true;
            this.btnCreateScript.Click += new System.EventHandler(this.createScript_Click);
            // 
            // txtUserName
            // 
            this.txtUserName.Location = new System.Drawing.Point(43, 23);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(186, 22);
            this.txtUserName.TabIndex = 0;
            // 
            // lblFacilities
            // 
            this.lblFacilities.AutoSize = true;
            this.lblFacilities.Location = new System.Drawing.Point(40, 48);
            this.lblFacilities.Name = "lblFacilities";
            this.lblFacilities.Size = new System.Drawing.Size(72, 16);
            this.lblFacilities.TabIndex = 5;
            this.lblFacilities.Text = "Facility List";
            // 
            // lblDrives
            // 
            this.lblDrives.AutoSize = true;
            this.lblDrives.Location = new System.Drawing.Point(304, 48);
            this.lblDrives.Name = "lblDrives";
            this.lblDrives.Size = new System.Drawing.Size(114, 16);
            this.lblDrives.TabIndex = 6;
            this.lblDrives.Text = "Network Drive List";
            // 
            // lblPrinters
            // 
            this.lblPrinters.AutoSize = true;
            this.lblPrinters.Location = new System.Drawing.Point(575, 48);
            this.lblPrinters.Name = "lblPrinters";
            this.lblPrinters.Size = new System.Drawing.Size(120, 16);
            this.lblPrinters.TabIndex = 6;
            this.lblPrinters.Text = "Network Printer List";
            // 
            // lblUserName
            // 
            this.lblUserName.AutoSize = true;
            this.lblUserName.Location = new System.Drawing.Point(40, 4);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(79, 16);
            this.lblUserName.TabIndex = 7;
            this.lblUserName.Text = "User Name:";
            // 
            // NewUserScript
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(809, 474);
            this.Controls.Add(this.lblUserName);
            this.Controls.Add(this.lblPrinters);
            this.Controls.Add(this.lblDrives);
            this.Controls.Add(this.lblFacilities);
            this.Controls.Add(this.txtUserName);
            this.Controls.Add(this.btnCreateScript);
            this.Controls.Add(this.lstPrinters);
            this.Controls.Add(this.lstDrives);
            this.Controls.Add(this.lstFacilities);
            this.Name = "NewUserScript";
            this.Text = "New User Script Wizard";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lstFacilities;
        private System.Windows.Forms.ListBox lstDrives;
        private System.Windows.Forms.ListBox lstPrinters;
        private System.Windows.Forms.Button btnCreateScript;
        private TextBox txtUserName;
        private Label lblFacilities;
        private Label lblDrives;
        private Label lblPrinters;
        private Label lblUserName;
    }
}

