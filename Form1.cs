
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Runtime;
using Microsoft.VisualBasic;
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
                fileListBox.Items.Add(items[0] + " ||" + items[4] + "_" + items[5] + "_" + items[6] + "." + items[7]);

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
        //    MessageBox.Show(wdtname);
           
        }
        private void loadWDTButton_Click(object sender, EventArgs e)
        {
            openfiledialog();
        }
              public void loadCsvForRoot (string csv2)
        {
           

            foreach (var line in File.ReadAllLines(csv2))

            {
                string[] splitFilesArray = line.Split(";");
                string fdid_split = splitFilesArray[0];
                string filename = splitFilesArray[1];

            }
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
                     //   MessageBox.Show(x + " " + y);
                        int xint = Int32.Parse(x);
                        int yint = Int32.Parse(y);

                        var offsetMaid = xint * 32 + 64 * 32 * yint;
                     //   MessageBox.Show("found MAID");
                        wdtStream.Position = 32836 + offsetMaid;
                        int fdid = Int32.Parse(test2[0]);
                        uint rootadt = Convert.ToUInt32(fdid);
                        wdtWriter.Write(rootadt);
                        // MessageBox.Show(xint + yint + Environment.NewLine + "Byte 0x01 written at !" + wdtStream.Position + Environment.NewLine + "Offset main is" + offsetMaid); ;
                        foreach (var line1 in File.ReadAllLines("splitfiles01.csv"))

                        {
                            bool obj0_seen = false;
                            bool obj1_seen = false;
                            bool tex0_seen = false;
                            bool lod_seen = false;
                            string adtname2 = "";
                            adtname2 = fileListBox.SelectedItem.ToString();
                            string[] splitFilesArray = line1.Split(';', '.', '/');
                            string fdid_split = splitFilesArray[0];
                         //   string filename = splitFilesArray[4];
                            string[] mapname = adtname2.Split(new char[] { '|', '.' });
                            string mapname2 = mapname[2] + "_obj0";
                           // MessageBox.Show(filename + " | | " + mapname[2] + "_obj0");
                            StringComparison comp = StringComparison.OrdinalIgnoreCase;

                            if (string.Equals(splitFilesArray[4], mapname2) == true)
                            {
                                MessageBox.Show(splitFilesArray[4] + " " + fdid_split);
                                //   string obj0 = Interaction.InputBox("Input obj0 FDID", "", "");
                                 obj0_seen = true;
                                uint obj0Adt = Convert.ToUInt32(fdid_split);
                                wdtWriter.Write(obj0Adt);
                                MessageBox.Show("edits written obj0");
                            }
                            if(splitFilesArray[4] == mapname[2] + "_obj1")
                            {
                                obj1_seen = true;
                               // string obj1 = Interaction.InputBox("Input obj1 FDID", "", "");
                                uint obj1Adt = Convert.ToUInt32(fdid_split);
                                wdtWriter.Write(obj1Adt);
                                MessageBox.Show("edits written obj1");
                            }
                            if (splitFilesArray[4] == mapname[2] + "_tex0")
                            {
                                 tex0_seen = true;
                                // string obj1 = Interaction.InputBox("Input obj1 FDID", "", "");
                                uint tex0Adt = Convert.ToUInt32(fdid_split);
                                wdtWriter.Write(tex0Adt);
                                MessageBox.Show("edits written tex0");
                                break;
                            }
                            if (splitFilesArray[4] == mapname[2] + "_lod")
                            {
                                lod_seen = true;
                                // string obj1 = Interaction.InputBox("Input obj1 FDID", "", "");
                                uint lodAdt = Convert.ToUInt32(fdid_split);
                                wdtWriter.Write(lodAdt);
                                MessageBox.Show("edits written lod");
                               // break;
                            }
                           
                           

                        }
                        MessageBox.Show("all edits applied");




                        //string tex0 = Interaction.InputBox("Input tex0 FDID", "", "");
                        //uint tex0Adt = Convert.ToUInt32(tex0);
                        //wdtWriter.Write(tex0Adt);
                        //string lod = Interaction.InputBox("Input lod FDID", "", "");
                        //uint lodAdt = Convert.ToUInt32(lod);
                        //wdtWriter.Write(lodAdt);


                        //wdtWriter.Write(fdid1);

                        //wdtWriter.Write(fdid1);

                        //wdtWriter.Write(fdid1);

                        //wdtWriter.Write(fdid1);

                        //wdtWriter.Write(fdid1);

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

        private void button1_Click(object sender, EventArgs e)
        {
            string[] test = adtname.Split(new char[] { '_', '|', '.' });
            MessageBox.Show(test[2]);
        }
    }
}