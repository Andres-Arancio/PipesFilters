using System;
using System.Drawing;

namespace CompAndDel.Filters
{
    public class FilterConditional : IFilter, IFilterConditional
    {   
        public bool FilterResult {get ; set ;}
        public IPicture Filter(IPicture image)
        {
            CognitiveFace cog = new CognitiveFace(true, Color.GreenYellow);
            Console.WriteLine($"Path: {image.Path}");
            cog.Recognize(image.Path);
            FilterResult = cog.FaceFound;
            Console.WriteLine($"Result: {FilterResult}");
            return image;
        }
    }
}