using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Windows.Forms;
using System.IO;

namespace NewUserInfo
{
    public partial class NewUserScript : Form
    {
        public class Facility
        {
            public string facilityName { get; set; }
            public string[] printer { get; set; }
            public string[] drive { get; set; }
            public Facility()
            {
                printer = new string[0];
                drive = new string[0];
            }
            public Facility(string[] print, string[] dri)
            {
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
            public Facility getFacility(int i)
            {
                return facility[i];
            }
        }
        public NewUserScript()
        {
            InitializeComponent();
            string facilityData = File.ReadAllText("FacilityData.json");
            FacilityData deSerFacData = JsonConvert.DeserializeObject<FacilityData>(facilityData);
            foreach (Facility fac in deSerFacData.facility)
            {
                this.lstFacilities.Items.Add(fac.facilityName);
            }
        }

        private void facilities_SelectedIndexChanged(object sender, EventArgs e)
        {
            string facilityData = File.ReadAllText("FacilityData.json");
            FacilityData deSerFacData = JsonConvert.DeserializeObject<FacilityData>(facilityData);
            lstDrives.Enabled = true;
            lstPrinters.Enabled = true;
            lstDrives.Items.Clear();
            lstPrinters.Items.Clear();
            int index = lstFacilities.SelectedIndex;
            if (lstFacilities.SelectedIndex > 0 | lstDrives.SelectedIndex < 10)
            {
                lstPrinters.Items.AddRange(deSerFacData.facility[index].printer);
                lstDrives.Items.AddRange(deSerFacData.facility[index].drive);
            } else
            {
                lstPrinters.Enabled = false;
                lstDrives.Enabled = false;
            }
        }

        private void createScript_Click(object sender, EventArgs e)
        {

            string fileName = lstFacilities.SelectedItem + "\\" + txtUserName.Text.Replace(" ", "") + ".bat";
            string createText = "@echo off" + Environment.NewLine;

            createText += ":: New User Script " + Environment.NewLine;
            createText += ":: User = " + txtUserName.Text + Environment.NewLine;
            createText += ":: Facility = " + lstFacilities.SelectedItem + Environment.NewLine + Environment.NewLine;

            createText += "pushd \\\\enjet.local\\netlogon\\" + lstFacilities.SelectedItem + "\\" + Environment.NewLine;
            createText += "call Variables.bat" + Environment.NewLine;
            createText += "popd" + Environment.NewLine + Environment.NewLine;

            foreach (string drive in lstDrives.SelectedItems)
            {
                createText += "%" + drive + "%" + Environment.NewLine;
            }
            createText += Environment.NewLine;
            foreach (string printer in lstPrinters.SelectedItems)
            {
                createText += "%" + printer + "%" + Environment.NewLine;
            }
            
            try
            {
                if (!Directory.Exists(lstFacilities.SelectedItem.ToString())) Directory.CreateDirectory(lstFacilities.SelectedItem.ToString());
                if (File.Exists(fileName))
                {
                    DialogResult result = MessageBox.Show("Script already exists, are you sure you want to write over it?", "File Exists!", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                    if (result == DialogResult.Yes) 
                    { 
                        File.Delete(fileName);
                        File.WriteAllText(fileName, createText);
                    }
                    else
                    {
                        MessageBox.Show("Script Not Saved", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }
            }
            catch(Exception ex)
            {
                DialogResult result = MessageBox.Show(ex.Message, "Error", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error);
                if (result == DialogResult.Abort) { Application.Exit(); }
                if (result == DialogResult.Retry) { createScript_Click(null, null); }
                if (result == DialogResult.Ignore) { return; }
            }

            MessageBox.Show("Script Saved To: " + fileName + Environment.NewLine + "Put this link into the user's Profile tab in AD.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            txtUserName.Text = "";
            lstFacilities.SelectedIndex = 0;

        }
    }
}
