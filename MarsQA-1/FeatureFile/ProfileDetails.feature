Feature: Add,Update,Delete Profile details
	  As a Skill Trader
      I want to be able to Add,update,Delete Languages,Skill,Education,Certification
      In order to update my profile details

@addlanguage
Scenario: Add language
	Given I clicked on the Language tab under Profile page
	When I add a new language
	Then that language should be displayed on my listings
@updatelanguage
Scenario: Update language 
	Given I clicked on the Language tab under Profile page
	When I  update Language 
	Then that updated language should be displayed on my listings
@deletelanguage     
Scenario: Delete language 
	Given I clicked on the Language tab under Profile page
	When I delete language 
	Then that language should not be displayed on my listings

	@addskill
Scenario: Add Skill
	Given I clicked on the Skill tab under Profile page
	When I add a new Skill
	Then that skill should be displayed on my listings
@updateskill
Scenario: Update Skill 
	Given I clicked on the Skill tab under Profile page
	When I  update Skill 
	Then that updated Skill should be displayed on my listings

@deleteskill    
Scenario: Delete Skill
	Given I clicked on the Skill tab under Profile page
	When I delete Skill 
	Then that Skill should not be displayed on my listings

	@addeducation
Scenario: Add Education
	Given I clicked on the Education tab under Profile page
	When I add a new Education
	Then that Education should be displayed on my listings
@editeducation
Scenario: Update Education 
	Given I clicked on the Education tab under Profile page
	When I  update Education
	Then that updated Education should be displayed on my listings
@deleteeducation    
Scenario: Delete Education 
	Given I clicked on the Education tab under Profile page
	When I delete Education
	Then that Education should not be displayed on my listings

	@addcertification
Scenario: Add Certification
	Given I clicked on the Certification tab under Profile page
	When I add a new Certification
	Then that Certification should be displayed on my listings
@editcertification
Scenario: Update Certification 
	Given I clicked on the Certification tab under Profile page
	When I  update Certification
	Then that updated Certification should be displayed on my listings
@deletecertification     
Scenario: Delete Certification 
	Given I clicked on the Certification tab under Profile page
	When I delete Certification
	Then that Certification should not be displayed on my listings

@Availability
Scenario: Available time of user
 Given I clicked Availability button
 When I select the Available time
 Then the available time should be displayed

 @Hours
 Scenario: Hours selection
  Given I clicked Hours button
  When I select hours can work
  Then the hours should be displayed

@EarnTarget
Scenario:EarnTarget
 Given I clicked Earntarget button
 When I select the earn target
 Then the earn target should be displayed

 @Description
 Scenario:Adding Description
 Given I clicked Description button
 When I add the description in textarea
 Then i should see the description in my profile

 @Profilename
 Scenario:Adding username
 Given I clicked profile name button
 When I add the username
 Then i should see the username in my profile