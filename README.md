About this project

Simple framework that runs a series of tests on the site AutomationPractice.com

The framework outlines some of the latest tools such as .Net Core, Specflow, Extent Reports that can be used to run extensive end-to-end tests.
Accounting for deprecated features such as PageFactory, Using the latest tools such as .Net Core 3.1, Nunit, Specflow, I've created a useful frameowork that is both robust and efficient.

1. Clone the "automation_practice"project from the repo to get started.
2. Ensure you have the latest VS(Visual Studio), latest version of Chrome installed on your machine.
3. Restore all required nuget packages then build the solution
4. Tests should appear in Test explorer.
5. Select a test and click run

NOTE: Tests are executed in parallel by default, may overwhelm your machine. If you intend on running the framework on low spec machine :
- Navigate to Solution directory , then AssemblyInfo.cs. 
- Comment out lines 6 and 7

TROUBLESHOOT

1 Issue : Browser briefly opens then closes before test is conducted
 Possible solution(s): -Ensure your chrome broowser version is the latest version. 
						if you are unable to install the latest version of chrome navigate
						to file /Hooks/BrowserHooks.cs Line 64 and excplicity declare 
						your chrome browser version (Example listed below)
					

						Your chrome browser version can be found by opening Chrome, n
						avigate to top right ellpsis (three vertical dots),
						selecting Help,
						Then Selecting 'About Google Chrome' option
						Chrome version should be listed, you could copy and paste the version /Hooks/BrowserHooks.cs Line 64
						Example :
						new DriverManager().SetUpDriver(new ChromeConfig(),version: "88.0.4324.96");





						