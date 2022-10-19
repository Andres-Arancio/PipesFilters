using System;
using CompAndDel.Pipes;
using CompAndDel.Filters;

namespace CompAndDel
{
    class Program
    {
        static void Main(string[] args)
        {
            string pathtopicture = @$"{Environment.CurrentDirectory}\luke.jpg";

            PictureProvider provider = new PictureProvider();
            IPicture picture = provider.GetPicture(pathtopicture);
            IPicture finalpicture;
            
            FilterNegative filterNegative = new FilterNegative();
            FilterGreyscale filterGreyscale = new FilterGreyscale();
            HistoryGreyscale historyGreyscale = new HistoryGreyscale();
            HistoryNegative historyNegative = new HistoryNegative();
            TwitterSendGrey twittergrey = new TwitterSendGrey();
            TwitterSendNegative twitternegative = new TwitterSendNegative();

            PipeNull pipeEND = new PipeNull();
            PipeSerial pipe6 = new PipeSerial(twitternegative, pipeEND);
            PipeSerial pipe5 = new PipeSerial(historyNegative, pipe6);
            PipeSerial pipe4 = new PipeSerial(filterNegative, pipe5);
            PipeSerial pipe3 = new PipeSerial(twittergrey, pipe4);
            PipeSerial pipe2 = new PipeSerial(historyGreyscale, pipe3);
            PipeSerial pipe1 = new PipeSerial(filterGreyscale, pipe2);
            
            finalpicture = pipe1.Send(picture);
        }
    }
}
