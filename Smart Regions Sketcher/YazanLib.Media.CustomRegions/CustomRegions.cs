
using System.Collections.Generic;
namespace YazanLib.Media
{
    public static class CustomRegions
    {
        public static void ApplyRegion(System.Windows.Forms.Form form, System.Drawing.Region region)
        {
            form.Region = region;
        }

        public static void ApplyRegion(System.Windows.Forms.Control control, System.Drawing.Region region)
        {
            control.Region = region;
        }

        public static void PlayOn(System.Windows.Forms.Form form, List<RegionData> data)
        {
            if (data == null || data.Count == 0)
                return;

            int current = 0;
            int ticks = 0;

            RegionData region = null;

            while (current < data.Count)
            {
                region = data[current];
                ApplyRegion(form, region.CreateRegion());

                ticks = System.Environment.TickCount + region.WaitMs;
                while (System.Environment.TickCount < ticks) ;

                current++;
            }
        }

        public static void PlayOn(System.Windows.Forms.Control control, List<RegionData> data)
        {
            if (data == null || data.Count == 0)
                return;

            int current = 0;
            int ticks = 0;

            RegionData region = null;

            while (current < data.Count)
            {
                region = data[current];
                ApplyRegion(control, region.CreateRegion());

                ticks = System.Environment.TickCount + region.WaitMs;
                while (System.Environment.TickCount < ticks) ;
            }
        }

        /*
        public static System.Drawing.Region CreateRegion(RegionData data)
        {

            System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath();

            path.AddPolygon(data.Points.ToArray());

            return new System.Drawing.Region(path);
        }
        */

        public static RegionData ImportRegion(string filename)
        {
            System.IO.Stream stream = null;
            RegionData data = null;
            try
            {
                System.Runtime.Serialization.Formatters.Binary.BinaryFormatter binaryFormatter =
                    new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();

                stream = System.IO.File.Open(filename, System.IO.FileMode.OpenOrCreate);

                data = (RegionData)binaryFormatter.Deserialize(stream);

                stream.Close();
            }
            finally
            {
                stream.Close();
            }


            return data;
        }

        public static List<RegionData> ImportRegions(string filename)
        {
            System.IO.Stream stream = null;
            List<RegionData> data = null;
            try
            {
                System.Runtime.Serialization.Formatters.Binary.BinaryFormatter binaryFormatter =
                    new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();

                stream = System.IO.File.Open(filename, System.IO.FileMode.OpenOrCreate);

                data = (List<RegionData>)binaryFormatter.Deserialize(stream);

                stream.Close();
            }
            finally
            {
                stream.Close();
            }


            return data;
        }

        public static void ExportRegion(RegionData data,string filename)
        {
            System.Runtime.Serialization.Formatters.Binary.BinaryFormatter binaryFormatter =
                new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();

            System.IO.Stream stream = System.IO.File.Open(filename, System.IO.FileMode.OpenOrCreate);

            binaryFormatter.Serialize(stream, data);

            stream.Close();
        }

        public static void ExportRegions(List<RegionData> data, string filename)
        {
            System.Runtime.Serialization.Formatters.Binary.BinaryFormatter binaryFormatter =
                new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();

            System.IO.Stream stream = System.IO.File.Open(filename, System.IO.FileMode.OpenOrCreate);

            binaryFormatter.Serialize(stream, data);

            stream.Close();
        }
    }
}
