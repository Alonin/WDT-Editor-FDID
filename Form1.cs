
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

            foreach (var line in File.ReadAllLines(csv))

            {
                Regex.Escape(".");
                Regex regex = new Regex("[.]|/|;|_");

                {

                };

                string[] items = regex.Split(line);
                //todo: account for map names with _ in them.
                fileListBox.Items.Add(items[0] + " ||" + items[4] + "_" + items[5] + "_" + items[6] + "." + items[7]);

            }

        }
        public string adtname = "";
        public string wdtname = "";
        public void openfiledialog()
        {
            openFileDialog1.Multiselect = false;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                wdtLabel.Visible = true;
                wdtLabel.Text = "WDT Loaded: " + Path.GetFileName(openFileDialog1.FileName);
            }
            else
            {
                wdtLabel.Visible = true;
                wdtLabel.Text = "Error! Please select a WDT File.";
            }
            wdtname = openFileDialog1.FileName;
            //DEBUG  MessageBox.Show(wdtname);

        }
        private void loadWDTButton_Click(object sender, EventArgs e)
        {
            openfiledialog();
        }
        public void loadCsvForRoot(string csv2)
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
         //   adtLabel.Text = "Please Wait..";
            using (Stream wdtStream = File.Open(openFileDialog1.FileName, FileMode.Open, FileAccess.ReadWrite))
            using (BinaryReader wdtReader = new BinaryReader(wdtStream))
            using (BinaryWriter wdtWriter = new BinaryWriter(wdtStream))
            {
                bool maid_seen = false;
                bool main_seen = false;
                while (wdtReader.BaseStream.Position != wdtReader.BaseStream.Length)
                {
                    var token = wdtReader.ReadUInt32();
                    var size = wdtReader.ReadUInt32();
                    var pos = wdtReader.BaseStream.Position;
                    if (token == 1296124238)     //MAIN 
                    {
                        while (wdtReader.BaseStream.Position < pos + size)
                        {
                            main_seen = true;
                            var flags = wdtReader.ReadUInt32();

                        }
                        adtname = fileListBox.SelectedItem.ToString();
                        string[] adtArray = adtname.Split(new char[] { '_', '.' });
                        var x = adtArray[1];
                        var y = adtArray[2];
                        
                        int xint = Int32.Parse(x);
                        int yint = Int32.Parse(y);

                        var offsetMain = xint * 8 + 64 * 8 * yint;
                        wdtStream.Position = 60 + offsetMain;
                       
                        wdtStream.WriteByte(01);


                    }

                    if (token == 1296124228) //MAID
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
                        
                        adtname = fileListBox.SelectedItem.ToString();
                        string[] adtArray = adtname.Split(new char[] { '_', '.' });
                        string[] fdidArray = adtname.Split(new char[] { '|' });

                        var x = adtArray[1];
                        var y = adtArray[2];
                       
                        int xint = Int32.Parse(x);
                        int yint = Int32.Parse(y);

                        var offsetMaid = xint * 32 + 64 * 32 * yint;
                        //first rootADT entry begins at 32836
                        wdtStream.Position = 32836 + offsetMaid;
                        int fdid = Int32.Parse(fdidArray[0]);
                        uint rootadt = Convert.ToUInt32(fdid);
                        wdtWriter.Write(rootadt);
                        
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
                           
                            string[] mapname = adtname2.Split(new char[] { '|', '.' });
                        
                          
                          

                            if (splitFilesArray[4] == mapname[2] + "_obj0")
                            {
                               
                                obj0_seen = true;
                                uint obj0Adt = Convert.ToUInt32(fdid_split);
                                wdtWriter.Write(obj0Adt);
                                //obj 0 edit applied
                            }
                            if (splitFilesArray[4] == mapname[2] + "_obj1")
                            {
                                obj1_seen = true;
                                uint obj1Adt = Convert.ToUInt32(fdid_split);
                                wdtWriter.Write(obj1Adt);
                                //obj 1 edit applied
                            }
                            if (splitFilesArray[4] == mapname[2] + "_tex0")
                            {
                                tex0_seen = true;             
                                uint tex0Adt = Convert.ToUInt32(fdid_split);
                                wdtWriter.Write(tex0Adt);    
                                //tex0 edit applied
                                break;
                            }
                            if (splitFilesArray[4] == mapname[2] + "_lod")
                            {
                                lod_seen = true;
                                uint lodAdt = Convert.ToUInt32(fdid_split);
                                wdtWriter.Write(lodAdt);
                                //  MessageBox.Show("edits written lod");
                                // break;
                            }



                        }
                       
                        adtLabel.Visible = true;
                        adtLabel.Text = "Applied edits for: " + adtname;
                    }
                    wdtReader.BaseStream.Position = pos + size;
                }
              
            }


        }

        private void fileListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            adtname = fileListBox.SelectedItem.ToString();
            var test = adtname.Split("_");
         

        }

        private void searchBox1_TextChanged(object sender, EventArgs e)
        {
            string SearchString = searchBox1.Text;
            for (int i = 0; i <= fileListBox.Items.Count - 1; i++)
            {
                if (fileListBox.Items[i].ToString().Contains(SearchString))
                {
                    fileListBox.SetSelected(i, true);
                    break;
                }
            }
        }
    }
}