using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace WebBasedATM.Model
{
    public class XMLReader
    {
        public void readFromFile()
        {
            List<Flight> flightList;
            flightList = (from e in XDocument.Load("C:\\Users\\Alexandra\\Documents\\Visual Studio 2015\\Projects\\ReadFromXML\\src\\ReadFromXML\\Flights.xml").
                              Root.Elements("flight")
                          select new Flight
                          {
                              ID = (string)e.Element("id"),
                              callSign = (string)e.Element("callsign"),
                              ADEP = (string)e.Element("adep"),
                              ADES = (string)e.Element("ades"),
                              ACType = (string)e.Element("actype"),
                              WTC = (string)e.Element("wtc"),
                              Plots = (
                                  from o in e.Elements("plots").Elements("plot")
                                  select new Plot
                                  {
                                      latitude = (double)o.Element("latitude"),
                                      longitude = (double)o.Element("longitude"),
                                      altitude = (double)o.Element("altitude"),
                                      speed = (double)o.Element("speed"),
                                      ModeS = (String)o.Element("modescode"),
                                  })
                                  .ToArray()
                          }).ToList();
        }
    }
}