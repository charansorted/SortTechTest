using RestSharp;
using System.Runtime.InteropServices;

namespace FloodMonitoringServices.ServiceHelper
{
    public class FloodMonitoringReadingLogic
    {
        private readonly string _baseURL = "https://environment.data.gov.uk";

        public FloodMonitoringReadingLogic() { }

        public async Task<dynamic> GetFloodMonitoringReadings(string stationId, [Optional] string? parameter, [Optional] string? value)
        {
            var options = new RestClientOptions(_baseURL)
            {
                MaxTimeout = -1,
            };
            var client = new RestClient(options);
            var url = string.Empty;
            switch (parameter)
            {
                case null:
                    url = $"/flood-monitoring/id/stations/{stationId}/readings";
                    break;
                case "limit":
                    url = $"/flood-monitoring/id/stations/{stationId}/readings?_limit={value}";
                    break;
                case "date":
                    url = $"/flood-monitoring/id/stations/{stationId}/readings?date={value}";
                    break;
            }
            var request = new RestRequest(url, Method.Get);

            var response = await client.ExecuteAsync(request);

            return response;

        }
    }
}
