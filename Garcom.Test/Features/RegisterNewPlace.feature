Feature: Register New Place
	As a hungry person
	I want to have a list of places available 
	So that I can have lunch

Scenario: Registering a new place using the add new place page
	Given I am at the register new place page
	When I fill in "name" with "Usina dos Pasteis"
	And I click on "submit"
	Then I should see "Usina dos Pasteis"
	
Scenario: Registering a new place through the all places page
	Given I am at the all places page
	When I fill in "name" with "Usina dos Pasteis"
	And I click on "create_place_with_ajax"
	Then I should see "Usina dos Pasteis"
	