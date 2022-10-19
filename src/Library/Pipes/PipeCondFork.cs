using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CompAndDel;


namespace CompAndDel.Pipes
{
    public class PipeCondFork : IPipe
    {
        IPipe truePipe;
        IPipe falsePipe;
        IFilterConditional condfilter;
        
        public PipeCondFork(IFilterConditional condfilter, IPipe truePipe, IPipe falsePipe) 
        {
            this.truePipe = truePipe;
            this.falsePipe = falsePipe;
            this.condfilter = condfilter;           
        }
        public IPicture Send(IPicture picture)
        {
            picture = this.condfilter.Filter(picture);
            if(condfilter.FilterResult == true)
            {
                return truePipe.Send(picture);
            }
            else
            {
                return falsePipe.Send(picture);
            }
        }
    }
}