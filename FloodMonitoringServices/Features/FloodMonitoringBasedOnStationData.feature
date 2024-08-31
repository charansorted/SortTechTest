@FloodMonitoringBasedOnStationData
Feature: FloodMonitoringBasedOnStationData

As a user i am able to access current and previous rainfall data using Flood monitoring API



Scenario: Retrieve a limited number of readings for a specific station
	Given I have an individual station with an ID of '3680'
	When I make an API request to the station endpoint with a limit of '10'
	Then the response status should have status 'OK'
		And the Items array count should be '10'

Scenario: Validate default limit is applied when limit parameter is not specified
	Given I have an individual station with an ID of '3680'
	When I make an API request to the station endpoint without specifying the limit parameter
	Then the response status should have status 'OK'
	And the response should contain imposed length limit



@Secondtestfeature
Scenario: Validate Rainfall measurement of a station for a particular date
Given I have an individual station with an ID of '3680'
When I make an API request to the station endpoint with a specific date '2019-02-05'
Then the response status should have status 'OK'
And the response should contain rainfall data for that specific date '2019-02-05'

