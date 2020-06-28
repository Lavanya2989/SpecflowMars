Feature: ShareSkill and ManageListing
	Adding,updating, deleting user skill

@AddShareSkill
Scenario: Add Shareskill details
	Given I clicked shareskill button on profile page
	When I add user details
	Then I should see the listing on managelisting page

@EditShareSkill
Scenario: Update SahreSkill
 Given I clicked Edit button on shareskill
 When I update user details
 Then i should see the updated details on managelisting

@DeleteShareSkill
Scenario:Delete ShareSkill
 Given I clicked delete button on managelisting
 When I delete ShareSkill
 Then Shareskill i deleted should not seen in listings

