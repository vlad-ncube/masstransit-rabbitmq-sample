Feature: ElevateContractorSignUpSteps
	In order to start using the system
	As a new contractor
	I want to fill my profile

Scenario: Go through the steps to fill the profile
	Given I have sign in page opened

	When I enter my Email = 'mickdelaney@gmail.com' and Password = '$Password123'
	Then my dashboard is opened and its title is 'Elevate'

	When I manually go to signup step 0
	Then profile step0 page is opened with header 'Hello mick delaney'

	When I press Continue
	Then profile step1 page is opened with header 'Technical skills'

	When I enter skills:
	| Skill   | Experience | LastUsedMonth | LastUsedYear |
	| MongoDB | 0.5        | August        | 2012         |
	And Press Save and Continue button
	Then profile step2 page is opened with header 'Work experience'