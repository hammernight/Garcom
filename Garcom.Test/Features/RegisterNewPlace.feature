Feature: Register New Place
	As a hungry person
	I want to have a list of places available 
	So that I can have lunch

Scenario: Registering a new place using the add new place page
	Given I am at the register new place page
	When I fill in the name with Pallatus
	And I click submit
	Then I should be at the all places page
	And I should see place created successfully
	And I should see Pallatus

Scenario Outline: Registering a new place through the all places page
	Given I am at the all places page
	When I fill in the name with <name>
	And I click submit
	Then I should see place created successfully
	And I should see <name>

	Examples:
		| name      |
		| silva     |
		| forty two |
