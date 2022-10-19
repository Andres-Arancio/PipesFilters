using System;
using System.Drawing;

namespace CompAndDel.Filters
{
    public class HistoryGreyscale : IFilter
    {
        public PictureProvider provider = new PictureProvider();
        public string pathGreyscale = @$"{Environment.CurrentDirectory}\greyscaleluke.jpg";
        public IPicture Filter(IPicture image)
        {
            provider.SavePicture(image,pathGreyscale);
            return image;
        }
    }
}