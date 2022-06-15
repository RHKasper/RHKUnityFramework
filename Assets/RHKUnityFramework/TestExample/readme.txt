Unity has two types of automated testing: Editor tests and PlayMode tests. 

Editor tests are great for Unit Testing, but they are somewhat limited as they don't support time delays, meaning they can't be used to test most gameplay features. To do that, we use PlayMode tests! In this folder, you'll find examples of each type.

To run these tests, navigate to Window => General => Test Runner.
Important pieces of this window:
	1. "Run All" button in the top left
	2. PlayMode vs. EditMode toggle in the center at the top
	3. While PlayMode is selected, the "Run All Tests" button near the top right. This is used to create a build that will run all your tests to make sure they work in a build.