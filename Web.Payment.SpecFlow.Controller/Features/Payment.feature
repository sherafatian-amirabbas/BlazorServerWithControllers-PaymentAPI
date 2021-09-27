Feature: Payment

# ======================================================================================== invalid Card Owner
Scenario Outline: The provided Card Owner is not provided
	Given the payment data as
		| CardOwner    | CardNumber       | ExpirationDate | CVC |
		| <Card owner> | 5555555555554444 | <next_month>   | 432 |
	When the data is posted
	Then the result must NOT be successful
	And The response must contain the error code <Error Code>

	Examples:
		| description                            | Card owner | Error Code |
		| when card owner is null                | <null>     | 100        |
		| when card owner is empty or whitespace |            | 100        |

# ======================================================================================== invalid Card Number
Scenario Outline: The provided Card Number is not valid
	Given the payment data as
		| CardOwner    | CardNumber    | ExpirationDate | CVC |
		| Owner's Name | <Card Number> | <next_month>   | 432 |
	When the data is posted
	Then the result must NOT be successful
	And The response must contain the error code <Error Code>

	Examples:
		| description                             | Card Number | Error Code |
		| when card number is null                | <null>      | 105        |
		| when card number is empty or whitespace |             | 105        |
		| when card number has invalid format     | 4646hg37    | 120        |

# ======================================================================================== invalid CVC
Scenario Outline: The provided CVC is not valid
	Given the payment data as
		| CardOwner    | CardNumber       | ExpirationDate | CVC   |
		| Owner's Name | 5555555555554444 | <next_month>   | <CVC> |
	When the data is posted
	Then the result must NOT be successful
	And The response must contain the error code <Error Code>

	Examples:
		| description                     | CVC    | Error Code |
		| when CVC is null                | <null> | 110        |
		| when CVC is empty or whitespace |        | 110        |
		| when CVC is not a number        | abc    | 115        |
		| when CVC has invalid format     | 464637 | 130        |

# ======================================================================================== card is expired
Scenario: The Card is expired
	Given the payment data as
		| CardOwner    | CardNumber       | ExpirationDate | CVC |
		| Owner's Name | 5555555555554444 | <last_month>   | 437 |
	When the data is posted
	Then the result must NOT be successful
	And The response must contain the error code 125

# ======================================================================================== provided valid data
Scenario: The provided data is valid
	Given the payment data as
		| CardOwner    | CardNumber      | ExpirationDate | CVC  |
		| Owner's Name | 378282246310005 | <next_month>   | 4325 |
	When the data is posted
	Then the result must be successful
	And The response must contain the type of the Credit Card as American Express Card