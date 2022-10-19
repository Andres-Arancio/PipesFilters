using System;
using System.Drawing;

namespace CompAndDel.Filters
{
    public class TwitterSendNegative : IFilter
    {
        public string pathFinalVersion = @$"{Environment.CurrentDirectory}\negativeluke.jpg";
        public IPicture Filter(IPicture image)
        {
            var twitter = new TwitterImage();
            twitter.PublishToTwitter("Final version of the image:", pathFinalVersion);
            return image;
        }
    }
}