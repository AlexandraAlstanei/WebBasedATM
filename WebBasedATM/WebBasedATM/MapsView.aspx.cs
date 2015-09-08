using Subgurim.Controles;
using System;
using System.Collections.Generic;
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
        }
    }
}