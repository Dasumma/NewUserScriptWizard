using Microsoft.VisualBasic.Devices;
using Newtonsoft.Json;
using System.Diagnostics;
using static NewUserScriptWizard.FrmNewUserScript;

namespace NewUserScriptWizard
{
    public partial class FrmNewUserScript : Form
    {

        FacilityData? deSerFacData;
        public class Facility
        {
            public string facilityName { get; set; }
            public string[] printer { get; set; }
            public string[] drive { get; set; }
            public Facility()
            {
                facilityName = "";
                printer = new string[0];
                drive = new string[0];
            }
            public Facility(string[] print, string[] dri, string facility)
            {
                facilityName = facility;
                printer = print;
                drive = dri;
            }
        }
        public class FacilityData
        {
            public Facility[] facility { get; set; }
            public FacilityData(Facility[] fac)
            {
                facility = fac;
            }
            public FacilityData()
            {
                facility = new Facility[0];
            }
        }
        public FrmNewUserScript()
        {
            InitializeComponent();
            GetFacilityInfo();
        }

        private void GetFacilityInfo()
        {
            try
            {
                if (!File.Exists("FacilityData.json")) CreateJson();
                string facilityData = File.ReadAllText("FacilityData.json");
                deSerFacData = JsonConvert.DeserializeObject<FacilityData>(facilityData);
                if (deSerFacData == null) return;
                foreach (Facility fac in deSerFacData.facility)
                {
                    this.LstFacilities.Items.Add(fac.facilityName);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK);
                Application.Exit();
            }
        }
        private void CreateJson()
        {
            FacilityData facilityData = new FacilityData()
            {
                facility = new Facility[]
                {
                    new Facility()
                    {
                        facilityName = "FacilityName",
                        drive = new string[]{"NetDrive1", "NetDrive2"},
                        printer = new string[]{"Printer1", "Printer2"}
                    }
                }
            };
            string SerializeData = JsonConvert.SerializeObject(facilityData);
            CreateFile("FacilityData.json", SerializeData);
        }

        private void BtnCreateScript_Click(object sender, EventArgs e)
        {
            CreateScript();
        }

        private string NewLine(string toAppend, string append)
        {
            toAppend += append + Environment.NewLine;
            return toAppend;
        }
        private string NewLine(string toAppend, string append, int numSpaces)
        {
            toAppend += append;
            for (int i = 0; i < numSpaces; i++) toAppend += Environment.NewLine;
            return toAppend;
        }

        private void CreateScript()
        {
            if (LstFacilities.SelectedItem == null) return;
            string? facility = LstFacilities.SelectedItem.ToString();
            if (facility == null) return;
            string fileName = facility + "\\" + TxtUserName.Text.Replace(" ", "") + ".bat";

            //Creates Script
            string createText = "";
            createText = NewLine(createText, "@echo off");
            createText = NewLine(createText, ":: New User Script ");
            createText = NewLine(createText, ":: User = " + TxtUserName.Text);
            createText = NewLine(createText, ":: Facility = " + facility, 2);
            createText = NewLine(createText, "pushd \\\\enjet.local\\netlogon\\" + LstFacilities.SelectedItem + "\\");
            createText = NewLine(createText, "call _Variables.bat");
            createText = NewLine(createText, "popd", 2);
            createText = NewLine(createText, ":: Version control (If script version changes then it will rerun the script)");
            createText = NewLine(createText, "FOR /F \"tokens=2* skip=2\" %%a in ('reg query \"HKCU\\Enjet\" /v \"Script_Version\"') do set CUR_VER=%%b");
            createText = NewLine(createText, "if /i \"%CUR_VER%\"==\"%SCRIPT_VERSION%\" GOTO END", 2);
            createText = NewLine(createText, ":START");
            createText = NewLine(createText, "reg add \"HKCU\\Enjet\" /f /v \"Script_Version\" /t REG_SZ /d \"%SCRIPT_VERSION%\"");
            foreach (string drive in LstDrives.SelectedItems) createText = NewLine(createText, "%" + drive + "%");
            createText = NewLine(createText, "");
            foreach (string printer in LstPrinters.SelectedItems) createText = NewLine(createText, "%" + printer + "%");
            createText = NewLine(createText, ":END");
            //End Script


            try { if (!Directory.Exists(facility)) Directory.CreateDirectory(facility); }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Error"); }

            CreateFile(fileName, createText);
            MessageBox.Show("Script Saved To: " + fileName + Environment.NewLine + "Put this link into the user's Profile tab in AD.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            PowerShellHelper(TxtUserName.Text, fileName);
        }

        /// <summary>
        /// PowerShellHelper allows the user to 
        /// </summary>
        /// <param name="username"></param>
        /// <param name="filename"></param>
        private void PowerShellHelper(string username, string filename)
        {
            if (File.Exists("helperScript.ps1"))
            {
                string ps1File = "helperScript.ps1";
                var startInfo = new ProcessStartInfo()
                {
                    FileName = "powershell.exe",
                    Arguments = $"{ps1File} {username} {filename}",
                    UseShellExecute = false
                };
                Process.Start(startInfo);
            }
        }

        /// <summary>
        /// Creates file with the filename "fileName" and text "createText"
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="createText"></param>
        private void CreateFile(string fileName, string createText)
        {
            try
            {
                if (File.Exists(fileName))
                {
                    DialogResult result = MessageBox.Show("Script already exists, are you sure you want to write over it?", "File Exists!", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                    if (result == DialogResult.No)
                    {
                        MessageBox.Show("Script Not Saved", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    File.Delete(fileName);
                }
                File.WriteAllText(fileName, createText);
            }
            catch (Exception ex)
            {
                DialogResult result = MessageBox.Show(ex.Message, "Error", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error);
                if (result == DialogResult.Abort) { Application.Exit(); }
                if (result == DialogResult.Retry) { CreateScript(); }
                if (result == DialogResult.Ignore) { return; }
            }

        }

        /// <summary>
        /// When user changes index on the faciltiy list reads all facility data to get corresponding drives and printers
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LstFacilities_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (deSerFacData == null) return;
            LstDrives.Enabled = true;
            LstPrinters.Enabled = true;
            LstDrives.Items.Clear();
            LstPrinters.Items.Clear();
            int index = LstFacilities.SelectedIndex;
            if (LstFacilities.SelectedIndex > 0 | LstDrives.SelectedIndex < 10)
            {
                LstPrinters.Items.AddRange(deSerFacData.facility[index].printer);
                LstDrives.Items.AddRange(deSerFacData.facility[index].drive);
            }
            else
            {
                LstPrinters.Enabled = false;
                LstDrives.Enabled = false;
            }
        }

        private void KeyDownEvent(object sender, KeyEventArgs e)
        {
            if (e.Modifiers == Keys.Control && e.KeyCode == Keys.Enter) CreateScript();
        }
    }
}
