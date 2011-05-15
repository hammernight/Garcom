Feature: Register New Place
	As a hungry person
	I want to have a list of places available 
	So that I can have lunch

Scenario: Registering a new place
	Given I am at the register new place page
	When I fill in the name with Pallatus
	And I click submit
	Then I should see place created successfully 

