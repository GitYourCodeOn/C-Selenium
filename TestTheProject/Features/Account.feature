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
Scenario Outline: Account registeration form can only accept valid information <Description>
	And I enter '<Email>' email address on registeration
	And I select create account
	When I populate all required fields and click register
		| Field        | Value          |
		| FirstName    | <FirstName>    |
		| LastName     | <LastName>     |
		| Password     | <Password>     |
		| Company      | <Company>      |
		| Address      | <Address>      |
		| City         | <City>         |
		| PostCode     | <PostCode>     |
		| HomePhone    | <HomePhone>    |
		| Mobilephone  | <Mobilephone>  |
		| AddressAlias | <AddressAlias> |
	Then an account will be created successfully

	Examples:
		| Description      | Email            | FirstName | LastName | Password | Company  | Address  | City | PostCode | HomePhone | Mobilephone | AddressAlias |
		| correct data 1st | fdffddf@zzxzx.   | ghghg     | ghg      | GGG3434!     | ghghg    | 32323232 | sdsd | 00000    | 0232323   | 0343434     | xcxc         |
		| correct data 2nd | fdffddf@dfdfdfd. | dfdfdfd   | sdsdsds  | sdsdsF23!  | sdsdsdsd | 32323232 | sdsd | 00000    | 0232323   | 0343434     | xcxc         |