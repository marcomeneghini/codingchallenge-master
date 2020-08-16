using System.Collections.Generic;

namespace ConstructionLine.CodingChallenge
{
    public class SearchEngine
    {
        private readonly List<Shirt> _shirts;
        private readonly List<IObjectIndex<Shirt>> _indexes;
        private readonly IObjectIndexScanner<Shirt> _indexScanner;
        private readonly ISummaryBuilder _summaryBuilder;

        public SearchEngine(List<Shirt> shirts) :
             this(shirts,
                 new ShirtIndexBuilder(),
                 new ShirtIndexScanner(),
                 new SummaryBuilder())
        {
            _shirts = shirts;

            // TODO: data preparation and initialisation of additional data structures to improve performance goes here.

        }

        public SearchEngine(
            List<Shirt> shirts,
            IObjectIndexBuilder<Shirt> indexBuilder,
            IObjectIndexScanner<Shirt> indexScanner,
            ISummaryBuilder summaryBuilder)
        {
            _indexes = indexBuilder.BuildIndexes(shirts);
            _indexScanner = indexScanner;
            _summaryBuilder = summaryBuilder;
        }


        public SearchResults Search(SearchOptions options)
        {
            var filteredShirts = _indexScanner.GetObjects(_indexes, options);

            return _summaryBuilder.GetShirtResult(filteredShirts);
        }
    }
}