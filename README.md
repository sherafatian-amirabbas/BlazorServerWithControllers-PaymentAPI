## BlazorServerWithControllers-PaymentAPI
In the front-end, Blazor Server and Bootstrap; in the backend, C# and .NET Core are employed. Also, for the Tests, NUnit and Moq frameworks are used; automate tests via SpecFlow.

<br/>

#### Description:
In order to make a payment with the credit card, user has to provide credit card information and it has to be validated. The API validates credit card data and recognize the Credit Card type out of Master Card, Visa and American Express. 

Input parameters: Card Owner, Credit Card Number, Expiration Date and CVC.

<br/>

##### User Story:
As an API consumer,  
I want to have the provided Credit Card info validated,
So that I am aware of either potential errors or the the type of the Credit Card.   

_Acceptance Citeria:_   
The Card Owner has to be provided and it is required.   
The Card Number is required and needs to follow the respective format of that kind.   
The CVC is required and needs to follow the respective format of that kind.   
The Issue Date is required and the Credit Card must not be expired.   
The API must recognize and specify the type of the Credit Card in the response.


_Examples:_   
The Card Number 464637 is not valid for the Visa type, since they starts with a 4 and are 13 to 16 digits.   
<br/> 
The CVC 3245 is not a valid CVC for MasterCard type, since it must contain 3 digits.   
<br/>
The Expiration Date is one month before today, so the Card is expired.   
<br/>
The Card Number 378282246310005 is a valid American Express card and in the response we must receive the respective type recognized by the API (assuming there are not any other validation errors).   
<br/>