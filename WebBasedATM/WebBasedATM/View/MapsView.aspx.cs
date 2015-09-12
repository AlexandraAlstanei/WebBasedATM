using Subgurim.Controles;
using Subgurim.Controles.GoogleChartIconMaker;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebBasedATM
{
    public partial class MapsView : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            GLatLng centerCoordinates = new GLatLng(55.2, 9.5);
            GMap1.setCenter(centerCoordinates);
            GMap1.GZoom = 7;
            GMap1.enableHookMouseWheelToZoom = true;
            GMap1.enableDoubleClickZoom = true;

            GLatLng latlng = new GLatLng(50.86, 9.83);
            GLatLng latlng2 = new GLatLng(45.7, 27.17);
            GIcon icon = new GIcon();
            icon.image = "https://dl.dropboxusercontent.com/u/1936953/airplane105%20%283%29.png";
            icon.iconSize = new GSize(55, 55);
            icon.iconAnchor = new GPoint(16, 32);

            GMarkerOptions mOpts = new GMarkerOptions();
            mOpts.icon = icon;
            GMarkerOptions mOpts2 = new GMarkerOptions();
            mOpts2.icon = icon;

            GMarker marker = new GMarker(latlng, mOpts);
            GMarker marker2 = new GMarker(latlng2, mOpts2);
            GMap1.Add(marker);
            GMap1.Add(marker2);
        }
    }
}