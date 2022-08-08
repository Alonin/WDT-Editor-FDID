using System;
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
        private void loadCsv()
        {
          //  var values = File.ReadAllLines("listfile.csv");
                
            foreach (var line in File.ReadAllLines("listfileonlyadts.csv"))

            {
                Regex regex = new Regex("/|;");

                string[] items = regex.Split(line);
               // File.AppendAllText("test.txt", line + items);
                fileListBox.Items.Add(items[0] + " || " + items[4]);

            }



        }
        private void fileListBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}