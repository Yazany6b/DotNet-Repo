using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Smart_Regions_Sketcher
{
    public static class SketchersFactory
    {
        public static ISketcher CreateSketcher(string type,System.Drawing.Graphics g)
        {
            if (type.Equals("Polygons", StringComparison.OrdinalIgnoreCase))
                return new PolygonSketcher(g);
            else
                if (type.Equals("Lines", StringComparison.OrdinalIgnoreCase))
                    return new LinesSketcher(g);

            return null;
        }
    }
}
