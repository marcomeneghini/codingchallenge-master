using System;
using System.Collections.Generic;
using System.Text;

namespace ConstructionLine.CodingChallenge
{
    public class ShirtIndexBuilder : IObjectIndexBuilder<Shirt>
    {
        public List<IObjectIndex<Shirt>> BuildIndexes(List<Shirt> shirts)
        {
            // build the index for Size
            var sizeIndex = new ShirtSizeIndex(shirts);

            // build the index for Colour
            var colorIndex = new ShirtColorIndex(shirts);

            // TODO: think how to build them in parallel
            // TODO: Initialize in the constructor the index required, from a dynamic index collection/index factory

            return new List<IObjectIndex<Shirt>> { sizeIndex, colorIndex };

        }
    }
}
