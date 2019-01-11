using ActionService;
using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json;
using BusinessObjects.Filters;

namespace Chalenge
{
    public partial class Index : System.Web.UI.Page
    {
        List<YearsRangeFilterItem> _ageFilters;
        List<GenderFilterItem> _genderFilters;
        const string AGE_FILTER_CACHE_KEY = "AGE_FILTER_CACHE_KEY";
        const string GENDER_FILTER_CACHE_KEY = "GENDER_FILTER_CACHE_KEY";

        protected void Page_Load(object sender, EventArgs e)
        {
            if(Cache[AGE_FILTER_CACHE_KEY] == null)
                _ageFilters = new List<YearsRangeFilterItem>();
            else
                _ageFilters = Cache[AGE_FILTER_CACHE_KEY] as List<YearsRangeFilterItem>;
            if (Cache[GENDER_FILTER_CACHE_KEY] == null)
                _genderFilters = new List<GenderFilterItem>();
            else
                _genderFilters = Cache[GENDER_FILTER_CACHE_KEY] as List<GenderFilterItem>;

            if (!IsPostBack)
            {
                BindData();
            }

        }

          protected void ChbxListAges_SelectedIndexChanged(object sender, EventArgs e)
        {
            CheckBoxList list = (CheckBoxList)sender;
            YearsRangeFilter filter = new YearsRangeFilter();
            _ageFilters = new List<YearsRangeFilterItem>();

            list.Items.Cast<ListItem>()
            .Where(li => li.Selected)
            .ToList()
            .ForEach(x =>
                _ageFilters.Add((YearsRangeFilterItem)filter.GetFilterItem(x.Value.ToString())));

            Cache[AGE_FILTER_CACHE_KEY] = _ageFilters;


            BindData();
        }

        private void BindData()
        {
            IPointService service = ServicesFactory.CreatePointService();

            string data = Newtonsoft.Json.JsonConvert.SerializeObject(service.GetListOfPoints(_ageFilters,_genderFilters));

            string myScriptValue = "markers=" + data;
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "myScriptName", myScriptValue, true);
        }

        protected void chbxListGenders_SelectedIndexChanged(object sender, EventArgs e)
        {
            CheckBoxList list = (CheckBoxList)sender;
            GenderFilter filter = new GenderFilter();
            _genderFilters = new List<GenderFilterItem>();

            list.Items.Cast<ListItem>()
            .Where(li => li.Selected)
            .ToList()
            .ForEach(x =>
                _genderFilters.Add((GenderFilterItem)filter.GetFilterItem(x.Value.ToString())));

            Cache[GENDER_FILTER_CACHE_KEY] = _genderFilters;

            BindData();
        }
    }
}