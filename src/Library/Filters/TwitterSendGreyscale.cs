using System;
using System.Drawing;

namespace CompAndDel.Filters
{
    public class TwitterSendGrey : IFilter
    {
        public string pathFinalVersion = @$"{Environment.CurrentDirectory}\greyscaleluke.jpg";
        public IPicture Filter(IPicture image)
        {
            var twitter = new TwitterImage();
            twitter.PublishToTwitter("Greyscaled version of the image:", pathFinalVersion);
            return image;
        }
    }
}