Feature: TextBox2

Scenario: Fill form with valid data 2
	Given Open Text Box page

	When Fill Full Name 'John Doe'
    And Fill Email 'john.doe@example.com'
    And Fill Current Address '123 Main St, Anytown, USA'
    And Fill Permanent Address '456 Another St, Othertown, USA'
    And Submit Form
	Then Output Name should be 'Name:John Doe'

    
Scenario: Fill form with valid data 2_2
	Given Open Text Box page

	When Fill Full Name 'John Doe'
    And Fill Email 'john.doe@example.com'
    And Fill Current Address '123 Main St, Anytown, USA'
    And Fill Permanent Address '456 Another St, Othertown, USA'
    And Submit Form
	Then Output Name should be 'Name:John Doe'

