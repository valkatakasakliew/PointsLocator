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

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindData();
            }
            //IPointService pServ = ServicesFactory.CreatePointService();

            //string data = JsonConvert.SerializeObject(pServ.GetListOfPoints(ageFilters));

            //string myScriptValue = "markers=" + data;
            //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "myScriptName", myScriptValue, true);

        }

        //private void GridViewCustomersBind()
        //{
        //    ICustomerService service = ServicesFactory.CreateCustomerService();

        //    GridViewCustomers.DataSource = service.GetListOfCustomers();
        //    GridViewCustomers.DataBind();
        //}

        //private void GridViewTrafficsBind()
        //{
        //    ITrafficService service = ServicesFactory.CreateTrafficServcie();

        //    GridViewTraffics.DataSource = service.GetListOfTraffics();
        //    GridViewTraffics.DataBind();
        //}

        private void ChbxListAgesBind()
        {
          //  chbxListAges.DataSource = 
        }

        private string GetJsonData(List<CustomerTraffic> customerTraffics)
        {
            List<object> liO = new List<object>();
            foreach (var item in customerTraffics)
            {
                var x = new
                {
                    type = "Feature",
                    geometry = new
                    {
                        type = "Point",
                        coordinates = new[] { item.CellLat, item.CellLong }
                    },
                    properties = new
                    {
                        gender = item.Gender,
                        age = item.Age,
                        number = item.Number
                    }

                };

                liO.Add(x);
            }
            JavaScriptSerializer js = new JavaScriptSerializer();
            return js.Serialize(liO);
        }

        private static string GetMarkers(List<CustomerTraffic> customerTraffics)
        {
            List<object> liO = new List<object>();
            foreach (var item in customerTraffics)
            {

                var x = new
                {
                    gender = item.Gender,
                    age = item.Age,
                    numer = item.Number,
                    lat = item.CellLat,
                    lng = item.CellLong
                };

                liO.Add(x);
            }
            JavaScriptSerializer js = new JavaScriptSerializer();
            js.MaxJsonLength = int.MaxValue;
            return js.Serialize(liO);
        }


        protected void ChbxListAges_SelectedIndexChanged(object sender, EventArgs e)
        {
            CheckBoxList list = (CheckBoxList)sender;
            _ageFilters = new List<YearsRangeFilterItem>();

            list.Items.Cast<ListItem>()
            .Where(li => li.Selected)
            .ToList()
            .ForEach(x =>
                _ageFilters.Add(YearsRangeFilter.GetFilter((YearsRangeFilterEnum)Enum.Parse(typeof(YearsRangeFilterEnum), x.Value, true))));

            BindData(_ageFilters);
        }

        private void BindData(List<YearsRangeFilterItem> ageFilters = null)
        {
            IPointService service = ServicesFactory.CreatePointService();

            string data = Newtonsoft.Json.JsonConvert.SerializeObject(service.GetListOfPoints(ageFilters));

            string myScriptValue = "markers=" + data;
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "myScriptName", myScriptValue, true);
        }

    }
}