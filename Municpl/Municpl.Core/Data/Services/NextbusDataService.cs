using Municpl.Core.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Windows.Data.Xml.Dom;

namespace Municpl.Core.Data.Services
{
    public class NextbusDataService : BaseDataService, INextbusDataService
    {
        private const string _webservicesUrl = "http://webservices.nextbus.com/service/publicXMLFeed";

        /// <summary>
        /// Gets a list of agencies which Nextbus supports
        /// </summary>
        /// <returns></returns>
        public async Task<List<NextbusAgency>> AgencyListAsync()
        {
            List<NextbusAgency> response = new List<NextbusAgency>();

            try
            {
                XmlDocument doc = await ExecuteNextbusCommandAsync("agencyList");

                var agencies = doc.SelectNodes("body/agency");

                foreach (var agencyNode in agencies)
                {
                    NextbusAgency agency = new NextbusAgency();
                    agency.Title = GetAttributeValue("title", agencyNode.Attributes);
                    agency.RegionTitle = GetAttributeValue("regionTitle", agencyNode.Attributes);
                    agency.ShortTitle = GetAttributeValue("shortTitle", agencyNode.Attributes);
                    agency.Tag = GetAttributeValue("tag", agencyNode.Attributes);

                    response.Add(agency);
                }
            }
            catch (Exception ex)
            {
                RaiseError(DataEngineType.Nextbus, ex.Message);

                throw ex;
            }

            return response;
        }

        /// <summary>
        /// Gets a list of routes for a given agency
        /// </summary>
        /// <param name="agencyTag">Agency tag identifier, e.g. sf-muni</param>
        /// <returns>A list of <see cref="NextbusRoute"/></returns>
        public async Task<List<NextbusRoute>> RouteListAsync(string agencyTag)
        {
            List<NextbusRoute> response = new List<NextbusRoute>();

            try
            {
                XmlDocument doc = await ExecuteNextbusCommandAsync("routeList", new List<KeyValuePair<string, string>>()
                {
                    new KeyValuePair<string, string>("a", agencyTag)
                });

                var routes = doc.SelectNodes("body/route");

                foreach (var routeNode in routes)
                {
                    NextbusRoute route = new NextbusRoute();
                    route.Tag = GetAttributeValue("tag", routeNode.Attributes);
                    route.Title = GetAttributeValue("title", routeNode.Attributes);

                    response.Add(route);
                }
            }
            catch (Exception ex)
            {
                RaiseError(DataEngineType.Nextbus, ex.Message);

                throw ex;
            }

            return response;
        }

        /// <summary>
        /// Gets detailed information about a route.
        /// </summary>
        /// <param name="agencyTag">Agency tag identifier, e.g. sf-muni</param>
        /// <param name="routeTag">Route tag identifier, e.g. N</param>
        /// <returns>Detailed route information including stops, their location and the path information.</returns>
        public async Task<NextbusRoute> RouteConfigAsync(string agencyTag, string routeTag)
        {
            try
            {
                XmlDocument doc = await ExecuteNextbusCommandAsync("routeConfig", new List<KeyValuePair<string, string>>()
                {
                    new KeyValuePair<string, string>("a", agencyTag),
                    new KeyValuePair<string, string>("r", routeTag)
                });

                var routeNodes = doc.SelectNodes("body/route");

                NextbusRoute route = new NextbusRoute();

                if (routeNodes.Count > 0)
                {
                    var routeNode = routeNodes.First();

                    /// Parse base route info
                                        
                    route.Tag = GetAttributeValue("tag", routeNode.Attributes);
                    route.Title = GetAttributeValue("title", routeNode.Attributes);
                    route.Color = GetAttributeValue("color", routeNode.Attributes);
                    route.OppositeColor = GetAttributeValue("oppositeColor", routeNode.Attributes);
                    route.MinimumCoordinates = new GeoCoordinate()
                    {
                        Latitude = Double.Parse(GetAttributeValue("latMin", routeNode.Attributes)),
                        Longitude = Double.Parse(GetAttributeValue("lonMin", routeNode.Attributes))
                    };
                    route.MaximumCoordinates = new GeoCoordinate()
                    {
                        Latitude = Double.Parse(GetAttributeValue("latMax", routeNode.Attributes)),
                        Longitude = Double.Parse(GetAttributeValue("lonMax", routeNode.Attributes))
                    };

                    /// Parse stops

                    List<NextbusStop> detailedStops = new List<NextbusStop>();
                    var stopNodes = routeNode.SelectNodes("stop");
                    foreach (var stopNode in stopNodes)
                    {
                        detailedStops.Add(new NextbusStop()
                        {
                            Tag = GetAttributeValue("tag", stopNode.Attributes),
                            Title = GetAttributeValue("tag", stopNode.Attributes),
                            Coordinates = new GeoCoordinate()
                            {
                                Latitude = Double.Parse(GetAttributeValue("lat", stopNode.Attributes)),
                                Longitude = Double.Parse(GetAttributeValue("lon", stopNode.Attributes))
                            },
                            StopId = Int32.Parse(GetAttributeValue("stopId", stopNode.Attributes))
                        });
                    }
                    route.Stops = detailedStops;

                    /// Parse directions

                    List<NextbusDirection> directions = new List<NextbusDirection>();
                    var directionNodes = routeNode.SelectNodes("direction");
                    foreach (var directionNode in directionNodes)
                    {
                        NextbusDirection direction = new NextbusDirection()
                        {
                            Tag = GetAttributeValue("tag", directionNode.Attributes),
                            Title = GetAttributeValue("title", directionNode.Attributes),
                            Name = GetAttributeValue("name", directionNode.Attributes),
                            UseForUI = Boolean.Parse(GetAttributeValue("useForUI", directionNode.Attributes)),
                            Stops = new List<NextbusStop>()
                            {

                            }
                        };
                        List<NextbusStop> inlineStops = new List<NextbusStop>();
                        foreach (var inlineStopNode in directionNode.SelectNodes("stop"))
                        {
                            inlineStops.Add(new NextbusStop()
                            {
                                Tag = GetAttributeValue("tag", inlineStopNode.Attributes)
                            });
                        }
                        direction.Stops = inlineStops;

                        directions.Add(direction);
                    }
                    route.Directions = directions;

                    /// Parse Paths

                    List<List<GeoCoordinate>> paths = new List<List<GeoCoordinate>>();
                    foreach (var pathGroupNode in routeNode.SelectNodes("path"))
                    {
                        List<GeoCoordinate> path = new List<GeoCoordinate>();

                        foreach (var pointNode in pathGroupNode.SelectNodes("point"))
                        {
                            path.Add(new GeoCoordinate()
                            {
                                Latitude = Double.Parse(GetAttributeValue("lat", pointNode.Attributes)),
                                Longitude = Double.Parse(GetAttributeValue("lon", pointNode.Attributes))
                            });
                        }

                        paths.Add(path);
                    }
                    route.Paths = paths;
                }

                return route;
            }
            catch (Exception ex)
            {
                RaiseError(DataEngineType.Nextbus, ex.Message);

                throw ex;
            }
        }
        
        public async Task<NextbusPredictions> PredictionsAsync(string agencyTag, string routeTag, string stopTag, bool useShortTitles = true)
        {
            try
            {
                XmlDocument doc = await ExecuteNextbusCommandAsync("predictions", new List<KeyValuePair<string, string>>()
                {
                    new KeyValuePair<string, string>("a", agencyTag),
                    new KeyValuePair<string, string>("r", routeTag),
                    new KeyValuePair<string, string>("s", stopTag),
                    new KeyValuePair<string, string>("useShortTitles", useShortTitles.ToString())
                });

                var predictionsNodes = doc.SelectNodes("body/predictions");

                if (predictionsNodes.Count > 0)
                    return ParsePredictionsXml(predictionsNodes.First());
            }
            catch (Exception ex)
            {
                RaiseError(DataEngineType.Nextbus, ex.Message);

                throw ex;
            }

            return null;
        }

        public async Task<List<NextbusPredictions>> PredictionsForMultiStopsAsync(string agencyTag, List<KeyValuePair<string, string>> routeTagStopTagPairs, bool useShortTitles = true)
        {
            List<NextbusPredictions> response = new List<NextbusPredictions>();

            try
            {
                List<KeyValuePair<string, string>> requestParameters = new List<KeyValuePair<string, string>>()
                {
                    new KeyValuePair<string, string>("a", agencyTag),
                    new KeyValuePair<string, string>("useShortTitles", useShortTitles.ToString())
                };

                foreach (var routeTagStopPair in routeTagStopTagPairs)
                {
                    requestParameters.Add(new KeyValuePair<string, string>("stop", String.Format("{0}|{1}", routeTagStopPair.Key, routeTagStopPair.Value)));
                }

                XmlDocument doc = await ExecuteNextbusCommandAsync("predictionsForMultiStops", requestParameters);

                var predictionsNodes = doc.SelectNodes("body/predictions");

                foreach (var predictionsNode in predictionsNodes)
                {
                    var predictions = ParsePredictionsXml(predictionsNode);

                    response.Add(predictions);
                }
            }
            catch (Exception ex)
            {
                RaiseError(DataEngineType.Nextbus, ex.Message);
                
                throw ex;
            }

            return response;
        }

        protected NextbusPredictions ParsePredictionsXml(IXmlNode predictionsNode)
        {
            NextbusPredictions predictions = new NextbusPredictions();

            predictions.AgencyTitle = GetAttributeValue("agencyTitle", predictionsNode.Attributes);
            predictions.RouteTag = GetAttributeValue("routeTag", predictionsNode.Attributes);
            predictions.RouteTitle = GetAttributeValue("routeTitle", predictionsNode.Attributes);
            predictions.StopTag = GetAttributeValue("stopTag", predictionsNode.Attributes);
            predictions.StopTitle = GetAttributeValue("stopTitle", predictionsNode.Attributes);
            predictions.Directions = new List<NextbusPredictionsDirection>();
            // TODO

            predictions.Messages = new List<NextbusMessage>();
            foreach (var messageNode in predictionsNode.SelectNodes("message"))
            {
                predictions.Messages.Add(new NextbusMessage()
                {
                    Text = GetAttributeValue("text", messageNode.Attributes),
                    Priority = GetAttributeValue("priority", messageNode.Attributes)
                });
            }

            return predictions;
        }

        protected async Task<XmlDocument> ExecuteNextbusCommandAsync(string command, List<KeyValuePair<string, string>> parameters = null)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(_webservicesUrl);
            sb.Append("?command=");
            sb.Append(command);

            if (parameters != null)
            {
                sb.Append("&");
                string parameterString = String.Join("&", parameters.Select(c => c.Key + "=" + c.Value));
                sb.Append(parameterString);
            }

            //Uri url = new Uri(_useFixtures ? String.Format("ms-appx:///Data/Fixtures/Nextbus/{0}.xml", command) : sb.ToString(), UriKind.Absolute);

            Uri url = new Uri(sb.ToString(), UriKind.Absolute);

            string xml = await _httpClient.GetStringAsync(url);

            XmlDocument doc = new XmlDocument();

            doc.LoadXml(xml);

            return doc;
        }

        protected string GetAttributeValue(string attributeName, XmlNamedNodeMap attributes)
        {
            return attributes.GetNamedItem(attributeName)?.InnerText;
        }
    }
}
