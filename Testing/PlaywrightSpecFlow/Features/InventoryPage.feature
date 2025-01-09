Feature: Inventory page feature

Scenario: Login to inventory page as a normal user
	Given User opens products page as a normal user
	Then User should be on products page
	
Scenario: Login to inventory page as a locked out user
	Given User opens products page as a locked out user
	Then User should not be on products page

