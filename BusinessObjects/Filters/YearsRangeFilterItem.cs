using static BusinessObjects.Filters.Enumerators;

namespace BusinessObjects.Filters
{
    public class YearsRangeFilterItem : IFilterItem
    {
        public string FilterName { get; set; }
        public FilterObject ToFilter { get; set; }
        public string FilterText { get; set; }

        /// <summary>
        /// Years ranges filter items
        /// </summary>
        /// <param name="type"></param>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <param name="filterText"></param>
        public YearsRangeFilterItem(string filterName, FilterObject filterObject, string filterText)
        {
            FilterName = filterName;
            ToFilter = filterObject;
            FilterText = filterText;
        }
    }
}
