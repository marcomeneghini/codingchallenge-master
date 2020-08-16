using System;
using System.Collections.Generic;
using System.Text;

namespace ConstructionLine.CodingChallenge
{
    public interface ISummaryBuilder
    {
        SearchResults GetShirtResult(List<Shirt> shirts);
    }
}
