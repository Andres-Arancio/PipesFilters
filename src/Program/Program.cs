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

            FilterNegative filterNegative = new FilterNegative();
            FilterGreyscale filterGreyscale = new FilterGreyscale();
            HistoryGreyscale historyGreyscale = new HistoryGreyscale();
            HistoryNegative historyNegative = new HistoryNegative();
            TwitterSendGrey twittergrey = new TwitterSendGrey();
            TwitterSendNegative twitternegative = new TwitterSendNegative();
            FilterConditional conditionalfilter = new FilterConditional();

            PipeNull pipeEND = new PipeNull();
            PipeSerial pipe6 = new PipeSerial(historyNegative, pipeEND);
            PipeSerial pipe5 = new PipeSerial(filterNegative, pipe6);
            PipeSerial pipe4 = new PipeSerial(twittergrey, pipeEND);
            PipeCondFork pipe3 = new PipeCondFork(conditionalfilter, pipe4, pipe5);
            PipeSerial pipe2 = new PipeSerial(historyGreyscale, pipe3);
            PipeSerial pipe1 = new PipeSerial(filterGreyscale, pipe2);

            pipe1.Send(picture);
        }
    }
}
