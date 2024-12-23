﻿Feature: TextBox

Scenario: Fill form with valid data
	Given Open Text Box page

	When Fill Full Name 'John Doe'
    And Fill Email 'john.doe@example.com'
    And Fill Current Address '123 Main St, Anytown, USA'
    And Fill Permanent Address '456 Another St, Othertown, USA'
    And Submit Form
	Then Output Name should be 'Name:John Doe'

    @myTag
Scenario: Fill form with valid data 1_2
	Given Opening Text Box page

	When Fill Full Name 'John Doe'
    And Fill Email 'john.doe@example.com'
    And Fill Current Address '123 Main St, Anytown, USA'
    And Fill Permanent Address '456 Another St, Othertown, USA'
    And Submit Form
	Then Output Name should be 'Name:John Doe'

