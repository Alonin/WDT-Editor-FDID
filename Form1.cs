
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
            MessageBox.Show(wdtname);
           
        }
private void loadWDTButton_Click(object sender, EventArgs e)
        {
            openfiledialog();
        }

        private void addADTButton_Click(object sender, EventArgs e)
        {
            using (Stream wdtStream = File.Open(openFileDialog1.FileName, FileMode.Open, FileAccess.ReadWrite))
            using (BinaryReader wdtReader = new BinaryReader(wdtStream))
            using (BinaryWriter wdtWriter = new BinaryWriter(wdtStream))
            {
                bool maid_seen = false;
                bool main_seen = false;
                while(wdtReader.BaseStream.Position != wdtReader.BaseStream.Length)
                {
                    var token = wdtReader.ReadUInt32();
                    var size = wdtReader.ReadUInt32();
                    var pos = wdtReader.BaseStream.Position;
                    if(token == 1296124238)     //MAIN 
                    {
                        while(wdtReader.BaseStream.Position < pos + size)
                        {
                            main_seen = true;
                            var flags = wdtReader.ReadUInt32();
                            adtname.Split("_");
                            var x = adtname[1];
                            var y = adtname[2];
                            var test = 64 * y;
                            var test2 = test + x;

                            var offsetMain = 8 * test2;
                            wdtStream.Position = pos + offsetMain;
                            wdtWriter.Write(0x01);
                        }

                    }
                   
                    
                    wdtReader.BaseStream.Position = pos + size;
                }
                adtLabel.Text = "Added ADT: " + adtname;
            }

          
        }

        private void fileListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            adtname = fileListBox.SelectedItem.ToString();
            adtLabel.Visible = true;
          
           
        }
    }
}