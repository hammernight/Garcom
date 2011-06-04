Feature: Add new menu items	
	In order pick pasteis for my order
	As hungry person
	I want to be able to add items to a place

@mytag
Scenario: See what items are on the menu
	Given I am on the Places page
	And The place I want to order from existing place
	When I click on the name of the place
	Then I should see that places menu items

Scenario: Add menu item to list of items
		Given I am on a place page
		When I fill in "menu item" with "item name"
		And I click on "ajax_button name"
		Then I should see my "item name" in the menu list

