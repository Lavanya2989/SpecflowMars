Feature: SearchSkill
	User can select the skills from list

@SkillByCategory
Scenario: Select Skill from categories
	Given I clicked searchskill button
    When Select the skill by clicking Category and subcategory
	Then I should see the Skill details page

@SkillSelectionByFilter
Scenario: Select Skill by filter
  Given I clicked searchskill button
  When Select the skill by using Filter
  Then I should see the skill list
