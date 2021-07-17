@Testplan4
Feature: Account
	As a user I want to create a new account 
	so that I can start buying items using my personal account

Background:
	Given I navigate to the Sign in page

@Testplan4a
Scenario: Account Form can only accept valid information
	And I enter 'abcd12@yandeTesting.com' email address on registeration
	When I select create account
	Then I get a valid green response

@Testplan4b
Scenario: Invalid information message will produce
	And I enter 'sdsdsgdfd43434352422343' email address on registeration
	When I select create account
	Then I get an invalid data response

@Testplan4c
Scenario: Invalid data not accepted
	And I enter 'abcd@yandeTesting.com' email address on registeration
	And I select create account
	When I click register on the Create An Account Page without populating required fields
	Then an invalid data banner will appear

@Testplan4d
Scenario: Account registeration form can only accept valid information
	And I enter 'abcdhh132@yandeTesting.com' email address on registeration
	And I select create account
	When I populate all required fields and click register
		| Field        | Value             |
		| FirstName    | TestFirstName     |
		| LastName     | TestLastName      |
		| Password     | passwordmycompany |
		| Company      | Argos             |
		| Address      | 10 James street   |
		| City         | London            |
		| PostCode     | 10000             |
		| HomePhone    | 012345678987      |
		| Mobilephone  | 072345678987      |
		| AddressAlias | jamesby           |
	Then an account will be created successfully