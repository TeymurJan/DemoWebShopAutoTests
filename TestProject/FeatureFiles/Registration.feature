@HW22
Feature: Registration
	As a product owner,
	I want my product users being able to sign up,
	So that make valid registration

@p1 @smoke
Scenario: Submit with valid data
	Given Registration page is opened
	When I submit new account
		| First Name | Second Name | Password  |
		| First name | Second name | qwerty123 |
	Then Check the confirmation of registration

@p2
Scenario: Submit with an existing email
	Given Registration page is opened
	When I submit with existing account
		| First Name | Second Name | Password  |
		| First name | Second name | qwerty123 |
	Then Check that the specified email already exists

@p2
Scenario: Submit with invalid mail
	Given Registration page is opened
	When I submit with invalid mail
		| First Name | Second Name | Email       | Password |
		| First name | Second name | randommmail | qwerty123 |
	Then Check that the entered mail is invalid

@p2
Scenario: Submit with empty mail field
	Given Registration page is opened
	When I submit with empty mail
		| First Name | Second Name | Email | Password |
		| First name | Second name |       | qwerty123 |
	Then Check that email is required

@p2
Scenario: Submit with empty first name
	Given Registration page is opened
	When I submit with empty first name
		| First Name | Second Name | Password |
		|            | Second name | qwerty123 |
	Then Check that first name is required

@p2
Scenario: Submit with empty second name
	Given Registration page is opened
	When I submit with empty second name
		| First Name | Second Name | Password  |
		| First name |             | qwerty123 |
	Then Check that second name is required

@p2
Scenario: Submit with empty passsword
	Given Registration page is opened
	When I submit with empty password
		| First Name | Second Name | Password  |
		| First name | Second name | qwerty123 |
	Then Check that password and confirmation password do not match

@p2
Scenario: Submit with empty confirm passsword
	Given Registration page is opened
	When I submit with empty confirm password
		| First Name | Second Name | Password  |
		| First name | Second name | qwerty123 |
	Then Check that password is required

@p2
Scenario: Submit with 5-character password
	Given Registration page is opened
	When I submit with 5-character password
		| First Name | Second Name | Password |
		| First name | Second name | qwert    |
	Then Check that password should have at least 6 characters

@p2
Scenario: Submit with different confirm password
	Given Registration page is opened
	When I submit with different confirm password
		| First Name | Second Name | Password  | Confirm Password |
		| First name | Second name | qwerty123 | qwerty1234       |
	Then Check that password and confirmation password do not match

@p2
Scenario: All freakin fields is empty
	Given Registration page is opened
	When I submit with empty fields
	Then Check that first name is required
	And Check that second name is required
	And Check that email is required
	And Check that password is required


