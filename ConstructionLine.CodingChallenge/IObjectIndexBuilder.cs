using System;
using System.Collections.Generic;
using System.Text;

namespace ConstructionLine.CodingChallenge
{
    public interface IObjectIndexBuilder<T>
    {
        List<IObjectIndex<T>> BuildIndexes(List<T> objects);
    }
}
