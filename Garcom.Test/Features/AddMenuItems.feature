Feature: Add new menu items	
	In order pick pasteis for my order
	As hungry person
	I want to be able to add items to a place

Scenario: Go to places page
	Given "georges" is an existent place
	And I am at the all places page
	When I click on the name of "georges"
	Then I should be at "georges" page

Scenario: Add menu items
	Given "georges" sells awesome pasteis
	And I am at "georges" page
	When I fill in "name" with "Banana" 
	And I click on "add_item_with_ajax"
	Then I should see "Banana"

