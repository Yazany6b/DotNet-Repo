using Smart_Regions_Sketcher.Dialogs;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using YazanLib.Media;

namespace Smart_Regions_Sketcher
{
    public class ImportExportHandler
    {
        private List<FreamsList> AllFreamsLists { get; set; }

        public ImportExportHandler(List<FreamsList> allFreamsList)
        {
            this.AllFreamsLists = allFreamsList;
        }

        public void ImportYCL(string filename,Graphics g ,Color sketchColor, Color unSketchColor )
        {
            List<List<RegionData>> data = YazanLib.Media.CustomRegions.ImportEmbbededRegions(filename);

            if (data == null)
            {
                MessageBox.Show("Unable to import data unkown format", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            System.Windows.Forms.DialogResult res = MargeOptionsDialog.Show();
            if (AllFreamsLists.Count > 0 && res == System.Windows.Forms.DialogResult.OK)
            {
                if (MargeOptionsDialog.Dialog.MargeAsNew)
                {
                    AllFreamsLists.Clear();
                    System.GC.Collect();
                }
            }
            else
            {

                if (res == System.Windows.Forms.DialogResult.Cancel)
                    return;
            }

            foreach (var item in data)
            {
                FreamsList list = new FreamsList();
                foreach (var subItem in item)
                {
                    ISketcher sk = SketchersFactory.CreateSketcher(subItem.Type, g);
                    sk.SketchPoints = subItem.Points;

                    sk.SketchColor = sketchColor;
                    sk.UnSketchColor = unSketchColor;

                    if (list.ActiveSketcher == null)
                        list.ActiveSketcher = sk;

                    list.Add(new AnimationFream(sk, subItem.WaitMs));
                }

                AllFreamsLists.Add(list);
            }
        }

        public void ImportYCA(string filename, Graphics g, Color sketchColor, Color unSketchColor)
        {
        }

        public void ImportYCR(string filename, Graphics g, Color sketchColor, Color unSketchColor)
        {
        }

        public void ExportYCL(string filename)
        {
        }

        public void ExportYCA(string filename)
        {
        }

        public void ExportYCR(string filename)
        {
        }
    }
}
