Feature: Add new menu items	
	In order pick pasteis for my order
	As hungry person
	I want to be able to add items to a place

Scenario: Add menu item to list of items
	Given "georges" is an existent place
	And I am at the all places page
	When I click on the name of "georges"
	Then I should be at "georges" page
	
Scenario: See what items are on the menu
	Given I am on the Places page
	And The place I want to order from is an existing place
	When I click on the name of the place
	Then I should see that place's menu items

