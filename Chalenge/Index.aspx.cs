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

        protected void Page_Load(object sender, EventArgs e)
        {
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

            BindData();
        }
    }
}