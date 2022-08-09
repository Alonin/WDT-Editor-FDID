
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Runtime;
namespace WDT_Editor_FDID
{
    public partial class wdtEditor : Form
    {
        public wdtEditor()
        {
            InitializeComponent();
            loadCsv();
        }
        public void loadCsv()
        {
          //  var values = File.ReadAllLines("listfile.csv");
                
            foreach (var line in File.ReadAllLines("listfileonlyadts.csv"))

            {
                Regex.Escape(".");
                Regex regex = new Regex("[.]|/|;|_");
                
                {

                };

                string[] items = regex.Split(line);
               // File.AppendAllText("test.txt", line + items);
                fileListBox.Items.Add(items[0] + " || " + items[4] + "_" + items[5] + "_" + items[6] + "." + items[7]);

            }
            
        }
        public string adtname = "asdaf";
       
        public string wdtname = "";
        public void openfiledialog()
        {
            openFileDialog1.Multiselect = false;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                wdtLabel.Visible = true;
                wdtLabel.Text = "WDT Loaded: " + openFileDialog1.FileName;

            }
            else
            {
                wdtLabel.Visible = true;
                wdtLabel.Text = "Error! Please select a WDT File.";
            }
            wdtname = openFileDialog1.FileName;
           
        }
private void loadWDTButton_Click(object sender, EventArgs e)
        {
            openfiledialog();
        }

        private void addADTButton_Click(object sender, EventArgs e)
        {
           
          
        }

        private void fileListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            adtname = fileListBox.SelectedItem.ToString();
            adtLabel.Visible = true;
            adtLabel.Text = adtname;
           
        }
    }
}