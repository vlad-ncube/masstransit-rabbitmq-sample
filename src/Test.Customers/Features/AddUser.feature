Feature: AddUser

Scenario: Add new user
	Given I opened Add New User Page
	When I entered new user data
	| FirstName       | LastName       | EmailAddress       | Age | Location      |
	| Test First Name | Test Last Name | Test Email Address | 99  | Test Location |
	And submited the page
	Then the result says the user "Test First Name" has been added
	And new record about the user has been added to db with UserFirstName = "Test First Name"