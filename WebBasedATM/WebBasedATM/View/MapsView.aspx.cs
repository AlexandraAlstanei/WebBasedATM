using Subgurim.Controles;
using Subgurim.Controles.GoogleChartIconMaker;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebBasedATM.Model;

namespace WebBasedATM
{
    public partial class MapsView : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            #region Maps
            GLatLng centerCoordinates = new GLatLng(55.2, 9.5);
            GMap1.setCenter(centerCoordinates);
            GMap1.GZoom = 7;
            GMap1.enableHookMouseWheelToZoom = true;
            GMap1.enableDoubleClickZoom = true; 
            #endregion

            XMLReader xmlReader = new XMLReader();
            List<Flight> listOfFlights = xmlReader.readFromFile();
            foreach (Flight flight in listOfFlights)
            {
                GLatLng coordinates = new GLatLng(flight.Plots[0].latitude, flight.Plots[0].longitude);
                GIcon icon = createIcon(chooseIcon(calculateDirection(flight.Plots[0].latitude, flight.Plots[0].longitude, flight.Plots[1].latitude, flight.Plots[1].longitude)));
                GMarkerOptions mOpts = new GMarkerOptions();
                mOpts.icon = icon;
                GMarker marker = new GMarker(coordinates, mOpts);
                GMap1.Add(marker);
           }   
        }

        public GIcon createIcon(string iconURL)
        { 
            GIcon icon = new GIcon();
            icon.image = iconURL;
            icon.iconSize = new GSize(55, 55);
            icon.iconAnchor = new GPoint(16, 32);
            return icon;
        }

        public string chooseIcon(string direction)
        {
            switch (direction)
            {
                case "N":
                    return "https://dl.dropboxusercontent.com/u/1936953/N.png";
                case "N - E":
                    return "https://dl.dropboxusercontent.com/u/1936953/NE.png";
                case "S - E":
                    return "https://dl.dropboxusercontent.com/u/1936953/SE.png";
                case "S":
                    return "https://dl.dropboxusercontent.com/u/1936953/S.png";
                case "S - W":
                    return "https://dl.dropboxusercontent.com/u/1936953/SW.png";
                case "E":
                    return "https://dl.dropboxusercontent.com/u/1936953/E.png";
                case "W":
                    return "https://dl.dropboxusercontent.com/u/1936953/W.png";
                case "N - W":
                    return "https://dl.dropboxusercontent.com/u/1936953/NW.png";
                default: 
                    return "https://dl.dropboxusercontent.com/u/1936953/N.png";
            }
        }

        public string calculateDirection(double latitudeA, double longitudeA, double latitudeB, double longitudeB)
        {
            double x, y, direction;
            x = Math.Cos(latitudeB) * Math.Sin(longitudeA - longitudeB);
            y = Math.Cos(latitudeA) * Math.Sin(latitudeB) - Math.Sin(latitudeA) * Math.Cos(latitudeB) * Math.Cos(longitudeA - longitudeB);
            direction = Math.Atan2(x, y);
            double directionAngle = 0;
            if (direction > 0)
            {
                 directionAngle = direction * (180 / Math.PI);
            }
            else
            {
                 directionAngle = 360 + (direction * (180 / Math.PI));
            }
            if ((directionAngle > 0) && (directionAngle < 90))
            {
                return "N - E";
            }
            else if ((directionAngle > 90) && (directionAngle < 180))
            {
                return "S - E";
            }
            else if ((directionAngle > 180) && (directionAngle < 270))
            {
                return "S - W";
            }
            else if ((directionAngle > 270) && (directionAngle < 360))
            {
                return "N - W";
            }
            else if ((directionAngle == 0) || (directionAngle == 360))
            {
                return "N";
            }
            else if (directionAngle == 90)
            {
                return "E";
            }
            else if (directionAngle == 180)
            {
                return "S";
            }
            else if (directionAngle == 270)
            {
                return "W";
            }
            return "N";
        }
    }
}