using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConstructionLine.CodingChallenge
{
    public class ShirtIndexScanner : IObjectIndexScanner<Shirt>
    {
        public List<Shirt> GetObjects(IEnumerable<IObjectIndex<Shirt>> indexes, SearchOptions searchOptions)
        {
            List<Shirt> shirts = new List<Shirt>();
            foreach (var index in indexes)
            {
                var shirtsPerIndex = index.Find(searchOptions);
                if (!shirtsPerIndex.Any())                
                    continue;
                
                if (shirts.Any())
                {
                    shirts = shirts.Intersect(shirtsPerIndex).ToList();
                }
                else
                {
                    shirts = shirtsPerIndex.ToList();
                }
            }

            return shirts;
        }
    }
}
