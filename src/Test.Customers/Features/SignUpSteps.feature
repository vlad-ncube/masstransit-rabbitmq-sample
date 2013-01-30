Feature: SignUpSteps
	As a developer
	I want to check we are able to test signup steps within one page which uses KO templates

Scenario: Test walk though three signup steps
	Given I have page opened
	When I press Next button two times
	Then the result should contain header with text "This is step 3"