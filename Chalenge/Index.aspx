<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="Chalenge.Index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8" />
    <link rel="stylesheet" type="text/css" href="http://cdn.leafletjs.com/leaflet/v0.7.7/leaflet.css" />
    <link rel="stylesheet" type="text/css" href="http://cdnjs.cloudflare.com/ajax/libs/leaflet.markercluster/0.4.0/MarkerCluster.css" />
    <link rel="stylesheet" type="text/css" href="http://cdnjs.cloudflare.com/ajax/libs/leaflet.markercluster/0.4.0/MarkerCluster.Default.css" />

    <script type='text/javascript' src='http://ajax.googleapis.com/ajax/libs/jquery/2.1.4/jquery.min.js'></script>
    <script type='text/javascript' src='http://cdn.leafletjs.com/leaflet/v0.7.7/leaflet.js'></script>
    <script type='text/javascript' src='http://cdnjs.cloudflare.com/ajax/libs/leaflet.markercluster/0.4.0/leaflet.markercluster.js'></script>
</head>
<body>
    <form id="form1" runat="server">
        <div id="map" style="width: 1024px; height: 768px"></div>

        <fieldset title="Gender">
            <asp:CheckBox ID="chbxGenderAll" runat="server" Text="Sellect / Unsellect All" />
            <asp:CheckBox ID="chbxMale" runat="server" Text="Male" />
            <asp:CheckBox ID="chbxFemale" runat="server" Text="Female" />
            <asp:CheckBox ID="chbxUnknown" runat="server" Text="Unknown" />
        </fieldset>
        <fieldset title="Ages">
            <asp:CheckBoxList
                ID="chbxListAges"
                runat="server"
                DataSourceID="odsYearsRange"
                OnSelectedIndexChanged="ChbxListAges_SelectedIndexChanged"
                AutoPostBack="true"
                DataTextField="RangeText"
                DataValueField="YearRange">
            </asp:CheckBoxList>
            <asp:ObjectDataSource runat="Server" ID="odsYearsRange"
                SelectMethod="GetYearsRangeItems" TypeName="BusinessObjects.Filters.YearsRangeFilter"></asp:ObjectDataSource>
        </fieldset>

         <script src="Scripts/leafletMap.js"></script>
    </form>
</body>
</html>
