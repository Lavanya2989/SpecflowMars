Feature: Login 
	Navigate to URL
	Login with valid credentials
	Seller can add the details in it
		
@smoke
Scenario: Login with valid credential
	Given Login to the website
	When I enter valid username and password
    Then I should be at the homepage

