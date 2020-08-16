using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConstructionLine.CodingChallenge
{
    public class ShirtSizeIndex : IObjectIndex<Shirt>
    {
        private readonly ILookup<Size, Shirt> _shirtSizes;
        public ShirtSizeIndex(List<Shirt> shirts)
        {
            _shirtSizes = shirts.ToLookup(x => x.Size, x => x);
        }

        public IEnumerable<Shirt> Find(SearchOptions searchOptions)
        {
            if (!searchOptions.Sizes.Any())
                return _shirtSizes.SelectMany(shirt => shirt);
            return _shirtSizes
                .Where(x => searchOptions.Sizes.Contains(x.Key))
                .SelectMany(shirt => shirt);
        }
    }
}
