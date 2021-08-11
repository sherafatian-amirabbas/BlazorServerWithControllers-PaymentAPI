# BlazorServerWithControllers-PaymentAPI
The project is architecturally designed to be testable. In the front-end, Blazor Server and Bootstrap; in the backend, C# and .Net Core 3 are employed. Also For the Test project, NUnit and Moq frameworks are used. 


# Description:
In order to make a payment with the credit card, user has to provide credit card information and it has to be validated. The API validates credit card data and recognize the credit card type. 

Input parameters: Card owner, Credit Card number, issue date and CVC.

Logic verifies that all fields are provided, credit card is not expired, credit card type is resplved based on the card number and checks if it is valid, CVC is valid for specified credit card type.

API returns credit card type in case of success for Master Card, Visa or American Express and returns all validation errors in case of failure.
