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

            PipeNull pipe3 = new PipeNull();
            PipeSerial pipe2 = new PipeSerial(filterNegative,pipe3);
            PipeSerial pipe1 = new PipeSerial(filterGreyscale,pipe2);
            
            finalpicture = pipe1.Send(picture);
            provider.SavePicture(finalpicture, @$"{Environment.CurrentDirectory}\newluke.jpg");

        }
    }
}
