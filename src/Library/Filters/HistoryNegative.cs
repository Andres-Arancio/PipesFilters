using System;
using System.Drawing;

namespace CompAndDel.Filters
{
    public class HistoryNegative : IFilter
    {
        public PictureProvider provider = new PictureProvider();
        public string pathNegative = @$"{Environment.CurrentDirectory}\negativeluke.jpg";
        public IPicture Filter(IPicture image)
        {
            provider.SavePicture(image,pathNegative);
            image.Path = pathNegative;
            return image;
        }
    }
}