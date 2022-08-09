
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
            loadCsv("listfileonlyadts.csv");
        }
        public void loadCsv(string csv)
        {
            //  var values = File.ReadAllLines("listfile.csv");

            foreach (var line in File.ReadAllLines(csv))

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
                            
                          // Regex regex = new Regex("");
                          

                            // goal is 12104 
                           
                            
                          

                        }
                    adtname = fileListBox.SelectedItem.ToString();
                    string[] test = adtname.Split(new char[] { '_', '.' });
                    var x = test[1];
                    var y = test[2];
                    MessageBox.Show(x + " " + y);
                    int xint = Int32.Parse(x);
                    int yint = Int32.Parse(y);

                    var offsetMain = xint * 8 + 64 * 8 * yint;
                    wdtStream.Position = 60 + offsetMain;
                    MessageBox.Show(xint + yint + Environment.NewLine + "Byte 0x01 written at !" + wdtStream.Position + Environment.NewLine + "Offset main is" + offsetMain); ;
                    wdtStream.WriteByte(01);
                       
                    
                    }
                  
                   if (token == 1296124228)
                    {
                        while (wdtReader.BaseStream.Position < pos + size)
                        {
                            maid_seen = true;
                            var rootADT = wdtReader.ReadUInt32();
                            var obj0ADT = wdtReader.ReadUInt32();
                            var obj1ADT = wdtReader.ReadUInt32();
                            var tex0ADT = wdtReader.ReadUInt32();
                            var lodADT = wdtReader.ReadUInt32();
                            var mapTexBLP = wdtReader.ReadUInt32();
                            var mapTex_N_BLP = wdtReader.ReadUInt32();
                            var minimapTex_BLP = wdtReader.ReadUInt32();


                        }
                        //first rootADT begins at 32836
                        adtname = fileListBox.SelectedItem.ToString();
                        string[] test = adtname.Split(new char[] { '_', '.' });
                        string[] test2 = adtname.Split(new char[] { '|' });

                        var x = test[1];
                        var y = test[2];
                        MessageBox.Show(x + " " + y);
                        int xint = Int32.Parse(x);
                        int yint = Int32.Parse(y);

                        var offsetMaid = xint * 32 + 64 * 32 * yint;
                        MessageBox.Show("found MAID");
                        wdtStream.Position = 32836 + offsetMaid;
                        MessageBox.Show(xint + yint + Environment.NewLine + "Byte 0x01 written at !" + wdtStream.Position + Environment.NewLine + "Offset main is" + offsetMaid); ;
                        int fdid = Int32.Parse(test2[0]);
                        MessageBox.Show(fdid.ToString());
                        uint fdid1 = Convert.ToUInt32(fdid);
                      
                        wdtWriter.Write(fdid1);
                        
                        wdtWriter.Write(fdid1);
                        
                        wdtWriter.Write(fdid1);
                        
                        wdtWriter.Write(fdid1);
                        
                        wdtWriter.Write(fdid1);
                        
                        wdtWriter.Write(fdid1);
                        
                        wdtWriter.Write(fdid1);
                        
                        wdtWriter.Write(fdid1);

                    }
                    wdtReader.BaseStream.Position = pos + size;
                }
                adtLabel.Text = "Added ADT: " + adtname;
            }

          
        }

        private void fileListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            adtname = fileListBox.SelectedItem.ToString();
            var test = adtname.Split("_");
            adtLabel.Visible = true;
            adtLabel.Text = "x is " + test[1].ToString() + "y is " +  test[2];
           
        }
    }
}