CloudQA Automation Practice Form Tests
This project contains automated tests for the CloudQA Automation Practice Form using C# and Selenium WebDriver with NUnit. The tests validate the functionality of key fields on the form to ensure they work correctly even if the HTML structure changes.

Prerequisites
.NET SDK (version 6.0 or later)
Visual Studio or any C# IDE
NuGet packages:
Selenium.WebDriver
Selenium.Support
NUnit
NUnit3TestAdapter
Getting Started
Clone the Repository:

bash
Run
Copy code
git clone <repository-url>
cd <repository-directory>
Install Dependencies: Open the project in your IDE and restore the NuGet packages.

Run the Tests:

Open the Test Explorer in your IDE.
Run the tests to validate the functionality of the form.
Test Cases
The following test cases are implemented:

Test First Name Field: Verifies that the first name input field accepts and displays the entered value.
Test Gender Selection: Checks that the male and female gender radio buttons can be selected correctly.
Test Form Submission: Ensures that submitting the form navigates away from the form page.
Code Structure
PracticeFormPage.cs: Contains the page object model for interacting with the Automation Practice Form.
PracticeFormTests.cs: Contains the NUnit test cases for validating the form functionality.
Contributing
Feel free to submit issues or pull requests for improvements or additional test cases.

License
This project is licensed under the MIT License.
