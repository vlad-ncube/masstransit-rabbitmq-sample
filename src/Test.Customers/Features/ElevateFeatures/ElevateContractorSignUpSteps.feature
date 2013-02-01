Feature: ElevateContractorSignUpSteps
	In order to start using the system
	As a new contractor
	I want to fill my profile

Scenario: Go through the steps to fill the profile
	Given I have sign in page opened

	When I enter my Email = 'mickdelaney@gmail.com' and Password = '$Password123'
	Then my dashboard is opened and its title is 'Elevate'

	When I manually enter signup steps url = 'http://localhost/Contractors/signup/steps?step=0'
	Then profile's Choose password page is opened
	And it says 'Password saved. You can change this later, once you've completed signing up.'

	When I press Continue
	Then profile's Technical skills page is opened

	When I enter skills:
	| Skill   | Experience | LastUsedMonth | LastUsedYear |
	| MongoDB | 0.5        | August        | 2012         |
	And Press Save and Continue button
	Then profile's Work experience page is opened