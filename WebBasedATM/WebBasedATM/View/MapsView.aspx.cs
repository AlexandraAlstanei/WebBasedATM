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

            GLatLng latlng = new GLatLng(55.86, 9.83);
            PinLetter pinLetter = new PinLetter("A", Color.Yellow, Color.Black);
            GMap1.Add(new GMarker(latlng, new GMarkerOptions(new GIcon(pinLetter.ToString(), pinLetter.Shadow()))));

            GIcon icon = new GIcon();
            icon.image = "http://www.flaticon.com/free-icon/airplane-shape_59919";
            icon.iconSize = new GSize(32, 32);
            icon.iconAnchor = new GPoint(16, 32);

            GMarkerOptions mOpts = new GMarkerOptions();
            mOpts.icon = icon;

            GMarker marker = new GMarker(latlng, mOpts);
            GMap1.Add(marker);
        }
    }
}