using System;

namespace CompAndDel
{
    public interface IFilterConditional : IFilter
    {
        public bool FilterResult {get ; set ;}
        IPicture Filter(IPicture image);
    }
}