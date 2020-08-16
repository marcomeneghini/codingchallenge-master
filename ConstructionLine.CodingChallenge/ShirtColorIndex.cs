using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConstructionLine.CodingChallenge
{
    public class ShirtColorIndex : IObjectIndex<Shirt>
    {
        private readonly ILookup<Color, Shirt> _shirtColors;
        public ShirtColorIndex(List<Shirt> shirts)
        {
            _shirtColors = shirts.ToLookup(x => x.Color, x => x);
        }

        public IEnumerable<Shirt> Find(SearchOptions searchOptions)
        {
            if (!searchOptions.Colors.Any())
                return _shirtColors.SelectMany(shirt => shirt); ;
            return _shirtColors
                .Where(x => searchOptions.Colors.Contains(x.Key))
                .SelectMany(shirt => shirt);
        }

    }
}
