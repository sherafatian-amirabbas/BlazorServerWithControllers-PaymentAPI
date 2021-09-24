Feature: Payment

@formulated
Scenario: The provided data is valid
	Given the payment data as
		| CardOwner    | CardNumber      | ExpirationDate  | CVC  |
		| Owner's Name | 378282246310005 | TODAY + 1 month | 4325 |
	When the data is posted
	Then the result must be successful
	And The response must contain the type of the Credit Card as "American Express Card"

@formulated
Scenario: The provided Card Number is not valid
	Given the payment data as
		| CardOwner    | CardNumber | ExpirationDate  | CVC |
		| Owner's Name | 4646hg37   | TODAY + 1 month | 432 |
	When the data is posted
	Then the result must NOT be successful
	And The response must contain the error Code

@formulated
Scenario: The provided CVC is not valid
	Given the payment data as
		| CardOwner    | CardNumber       | ExpirationDate  | CVC   |
		| Owner's Name | 5555555555554444 | TODAY + 1 month | 432s7 |
	When the data is posted
	Then the result must NOT be successful
	And The response must contain the error Code

@formulated
Scenario: The Card is expired
	Given the payment data as
		| CardOwner    | CardNumber       | ExpirationDate  | CVC |
		| Owner's Name | 5555555555554444 | TODAY - 1 month | 437 |
	When the data is posted
	Then the result must NOT be successful
	And The response must contain the error Code