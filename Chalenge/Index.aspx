<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="Chalenge.Index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8" />
    <link rel="stylesheet" type="text/css" href="http://cdn.leafletjs.com/leaflet/v0.7.7/leaflet.css" />
    <link rel="stylesheet" type="text/css" href="http://cdnjs.cloudflare.com/ajax/libs/leaflet.markercluster/0.4.0/MarkerCluster.css" />
    <link rel="stylesheet" type="text/css" href="http://cdnjs.cloudflare.com/ajax/libs/leaflet.markercluster/0.4.0/MarkerCluster.Default.css" />
    <link href="CSS/bootstrap.css" rel="stylesheet" />
    <link href="CSS/Index.css" rel="stylesheet" />
    <script type='text/javascript' src='http://ajax.googleapis.com/ajax/libs/jquery/2.1.4/jquery.min.js'></script>
    <script type='text/javascript' src='http://cdn.leafletjs.com/leaflet/v0.7.7/leaflet.js'></script>
    <script type='text/javascript' src='http://cdnjs.cloudflare.com/ajax/libs/leaflet.markercluster/0.4.0/leaflet.markercluster.js'></script>
</head>
<body>
    <form id="form1" runat="server">

        <div class="container">
            <div class="row">
                <div class="col ">
                    <h2 class="h2 text-center">It is my simple locator</h2>
                </div>
            </div>
            <div class="row">
                <div class="col-lg-2 text-center">
                    <h6 class="h5" style="color: white; background-color: #330033;">These are filter options</h6>
                </div>
            </div>
            <div class="row">
                <div class="col-md-2">
                    <fieldset title="Gender" style="margin: 20px 0">
                        <p>You can filter by gender:</p>
                        <asp:CheckBoxList
                            ID="chbxListGenders"
                            runat="server"
                            DataSourceID="odsGender"
                            OnSelectedIndexChanged="chbxListGenders_SelectedIndexChanged"
                            DataTextField="FilterText"
                            DataValueField="FilterName"
                            AutoPostBack="true">
                        </asp:CheckBoxList>
                        <asp:ObjectDataSource runat="Server" ID="odsGender"
                            SelectMethod="GetFilterItems" TypeName="BusinessObjects.Filters.GenderFilter"></asp:ObjectDataSource>
                    </fieldset>
                    <fieldset title="Ages">
                        <p>You can filter by age:</p>
                        <asp:CheckBoxList
                            ID="chbxListAges"
                            runat="server"
                            DataSourceID="odsYearsRange"
                            OnSelectedIndexChanged="ChbxListAges_SelectedIndexChanged"
                            DataTextField="FilterText"
                            DataValueField="FilterName"
                            AutoPostBack="true">
                        </asp:CheckBoxList>
                        <asp:ObjectDataSource runat="Server" ID="odsYearsRange"
                            SelectMethod="GetFilterItems" TypeName="BusinessObjects.Filters.YearsRangeFilter"></asp:ObjectDataSource>
                    </fieldset>
                </div>

                <div class="col-md-10">
                    <div id="map" style="width: 1024px; height: 768px"></div>
                </div>
            </div>
        </div>

        <script src="Scripts/leafletMap.js"></script>
    </form>
</body>
</html>
