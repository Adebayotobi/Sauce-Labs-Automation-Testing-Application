# Sauce-Labs Automation Test Suite

### Summary
This repository contains an automated test script written in C# using the Playwright framework to test the Sauce-Labs' E-commerce platform. The script navigates through the website, performs various actions like logging in, adding items to the cart, and checking out, while asserting the expected behavior at each step.

### Test Objective
The objective of this test script is to automate the process of purchasing a T-shirt from the e-commerce website Sauce Demo. The script aims to validate the functionality of the website's shopping cart and checkout process.

### Prerequisites
- .NET Core SDK installed on your machine
- NUnit framework installed in your project
- Microsoft.Playwright package added to your project

### Getting Started
*Clone the Repository*: Clone this repository to your local machine using the following command:

```
git clone https://github.com/Adebayotobi/Sauce-Labs-Automation-Testing-Application.git
```

*Install Dependencies*: Navigate to the project directory and restore the NuGet packages using the following command:

```
cd Sauce-Labs-Automation-Testing-Application
dotnet restore
```

*Run the Test*: Execute the test script by running the following command:
```
dotnet test
```

### Test Steps
- *Login*: The script logs in to the Sauce Demo website using predefined credentials.
- *Navigate to Product Page*: After successful login, the script navigates to the inventory page.
- *Add Item to Cart*: An item (T-shirt) is added to the shopping cart.
- *Proceed to Checkout*: The script proceeds to the checkout page.
- *Enter Checkout Information*: Necessary checkout information like name and postal code are filled in.
- *Complete Order*: The order is completed, and the confirmation page is verified.
- *Logout*: Finally, the script logs out of the website.

### Test Assertions
- *Login*: Verify successful login and redirection to the inventory page.
- *Shopping Cart*: Ensure that the item is successfully added to the shopping cart.
- *Checkout Process*: Validate each step of the checkout process.
- *Order Confirmation*: Confirm the display of the order confirmation page.
- *Logout*: Ensure successful logout and redirection to the login page.

### Conclusion
This test script demonstrates the automated testing of an e-commerce website using Playwright, ensuring the reliability and accuracy of the purchasing process. It can be further extended and customized to cover additional scenarios and edge cases.
