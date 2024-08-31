using FloodMonitoringServices.ServiceHelper;
using Newtonsoft.Json;
using NUnit.Framework;
using RestSharp;
using System.Net;

namespace FloodMonitoringServices.StepDefinitions
{
    [Binding]
    public sealed class FloodMonitoringStepDefinitions
    {
        private ScenarioContext _scenarioContext;
        private FloodMonitoringReadingLogic _floodMonitoringlReadingLogic;
        public FloodMonitoringStepDefinitions(ScenarioContext scenarioContext, FloodMonitoringReadingLogic floodMonitoringReadingLogic)
        {
            _scenarioContext = scenarioContext;
            _floodMonitoringlReadingLogic = floodMonitoringReadingLogic;
        }



        [Given(@"I have an individual station with an ID of '([^']*)'")]
        public void GivenIHaveAnIndividualStationWithAnIDOf(string stationId)
        {
            _scenarioContext.Set(stationId, "StationId");
        }

        [When(@"I make an API request to the station endpoint with a limit of '([^']*)'")]
        public async Task WhenIMakeAnAPIRequestToTheStationEndpointWithALimitOf(string limitCount)
        {
            var stationId = _scenarioContext.Get<string>("StationId");

            var floodMonitoringRestResponse = await _floodMonitoringlReadingLogic.GetFloodMonitoringReadings(stationId, "limit", limitCount);
            _scenarioContext.Set(floodMonitoringRestResponse, "FloodMonitoringRestResponse");

        }

        [Then(@"the response status should have status '([^']*)'")]
        public void ThenTheResponseStatusShouldHaveStatus(string StatusCode)
        {
            var floodMonitoringRestResponse = _scenarioContext.Get<RestResponse>("FloodMonitoringRestResponse");
            Assert.AreEqual(StatusCode, floodMonitoringRestResponse.StatusCode.ToString("D"));
        }

        [Then(@"the Items array count should be '([^']*)'")]
        public void ThenTheItemsArrayCountShouldBe(int limitCount)
        {
            var floodMonitoringRestResponse = _scenarioContext.Get<RestResponse>("FloodMonitoringRestResponse");

            var floodMonitoringResponse = JsonConvert.DeserializeObject<FloodMonitoringResponse>(floodMonitoringRestResponse.Content);
            Assert.AreEqual(limitCount, floodMonitoringResponse.Items.Count);
        }

        [When(@"I make an API request to the station endpoint without specifying the limit parameter")]
        public async Task WhenIMakeAnAPIRequestToTheStationEndpointWithoutSpecifyingTheLimitParameter()
        {
            var stationId = _scenarioContext.Get<string>("StationId");

            var floodMonitoringRestResponse = await _floodMonitoringlReadingLogic.GetFloodMonitoringReadings(stationId);
            _scenarioContext.Set(floodMonitoringRestResponse, "FloodMonitoringRestResponse");
        }

        [Then(@"the response should contain imposed length limit")]
        public void ThenTheResponseShouldContainImposedLengthLimit()
        {
            var floodMonitoringRestResponse = _scenarioContext.Get<RestResponse>("FloodMonitoringRestResponse");

            var floodMonitoringResponse = JsonConvert.DeserializeObject<FloodMonitoringResponse>(floodMonitoringRestResponse.Content);
            Assert.AreEqual(floodMonitoringResponse.Meta.Limit, floodMonitoringResponse.Items.Count);
        }

        [When(@"I make an API request to the station endpoint with a specific date '([^']*)'")]
        public async Task WhenIMakeAnAPIRequestToTheStationEndpointWithASpecificDate(string date)
        {
            var stationId = _scenarioContext.Get<string>("StationId");

            var floodMonitoringRestResponse = await _floodMonitoringlReadingLogic.GetFloodMonitoringReadings(stationId, "date", date);
            _scenarioContext.Set(floodMonitoringRestResponse, "FloodMonitoringRestResponse");
        }

        [Then(@"the response should contain rainfall data for that specific date '([^']*)'")]
        public void ThenTheResponseShouldContainRainfallDataForThatSpecificDate(string date)
        {
            var floodMonitoringRestResponse = _scenarioContext.Get<RestResponse>("FloodMonitoringRestResponse");

            var floodMonitoringResponse = JsonConvert.DeserializeObject<FloodMonitoringResponse>(floodMonitoringRestResponse.Content);
            Assert.AreEqual(floodMonitoringResponse.Meta.Limit, 500);
            Assert.AreEqual(floodMonitoringResponse.Items.Count, 0);
            Assert.True(floodMonitoringResponse.Meta.HasFormat.TrueForAll(x => x.Contains(date)));

        }

    }
}