using System.Net;

namespace FloodMonitoringServices.StepDefinitions
{
    [Binding]
    public sealed class FloodMonitoringStepDefinitions
    {
        private ScenarioContext _scenarioContext;
        public FloodMonitoringStepDefinitions(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
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



        }

        [Then(@"the response status should have status '([^']*)'")]
        public void ThenTheResponseStatusShouldHaveStatus(HttpStatusCode StatusCode)
        {

        }

        [Then(@"the Items array count should be '([^']*)'")]
        public void ThenTheItemsArrayCountShouldBe(int limitCount)
        {

        }

        [When(@"I make an API request to the station endpoint without specifying the limit parameter")]
        public async Task WhenIMakeAnAPIRequestToTheStationEndpointWithoutSpecifyingTheLimitParameter()
        {

        }

        [Then(@"the response should contain imposed length limit")]
        public void ThenTheResponseShouldContainImposedLengthLimit()
        {

        }

        [When(@"I make an API request to the station endpoint with a specific date '([^']*)'")]
        public async Task WhenIMakeAnAPIRequestToTheStationEndpointWithASpecificDate(string date)
        {

        }

        [Then(@"the response should contain rainfall data for that specific date '([^']*)'")]
        public void ThenTheResponseShouldContainRainfallDataForThatSpecificDate(string date)
        {


        }

    }
}