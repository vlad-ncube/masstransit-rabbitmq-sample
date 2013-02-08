Feature: SignUpSteps
	As a developer
	I want to check we are able to test signup steps within one page which uses KO templates and history

Scenario: Test walk though three signup steps back and forth
	Given I have signup page opened

	When I press Next button
	Then the result should contain header with text "This is step 2"

	When I press Next button second time
	Then the result should contain header with text "This is step 3"

	When I press browser back button
	Then the result should contain header with text "This is step 2"

	When I press browser Back button again
	Then the result should contain header with text "This is step 1"

	When I press browser Forward button
	Then the result should contain header with text "This is step 2"