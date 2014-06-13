#YouOwnTest 

**YOT** is a home made test framework, created step by step to learn how to create one 
and understand the problems and techniques used in this kind of framework

##Context

Tests frameworks have 2 parts:

* The test framework to reference in your test projects
* The runner to execute the tests

**NOTE:** This is supposed to be a simple test framework to _learn_ not a complete
testing framework


##Requirements

###1.Test Framework

These are the simple requirements for the test framework. You can choose a completely other way, once you explain your choices!

In terms of functionality, whatever the way you implement it, the test framework should contains mainly:

1. Something that Identify the test cases. Exemple: it can be attributes:
  1. The attributes to identify tests classes and tests cases
	  *	Decorate tests classes with `TestClass`
	  *	Decorate tests methods with `Test`
2. It must have Assertion helpers:
	*	Exemple : You can use a static `Verify` class as main assertion class
	*	That class should verify at least: 
		* IsTrue(sut,message="")*
		* IsFalse(sut,message="")
		* IsNull(sut,message="")
		* IsNotNull(sut,message="")
		* AreEqual(sut,expected, message="")

(*) each verify method can take an optional expected message  

###2.The Runner

The runner is a console executable. It should take a dll as argument and set the
working path to the parent folder of the library in order to load
dependencies correctly.

It will search the library for TestClasses, find each test method 
and then instantiates the class and executes the method for each test.

you should ensure that:

* test signatures are of type void delegate().
* each test is _**really**_ isolated from the others
* and of course that runner doesn't crash when a test fails

The runner when executed should print a header with it's name, it's version in clean form and a starting and ending time

Then it should print in a nice way:

	X tests found, Y success, Z failed.

It should be printed in green if `all`tests pass, in red if at least
`one`test fails.

If tests failed then you should be able to print for each one:

* The full name of the tested method (ex : `MyApp.Web.Tests.HomeControllerTests.ShouldGetOkWhenCallRoot()`)
* The type of the verification(s) (ex: `IsTrue verification failed`)
* The error message that comes with each verification (ex: `expected True instead of False`)

##End word

Don't forget that _This is mainly a learning game!_

You can try to test other groups frameworks ;-)



## some Rules 
The work should be done in  pair programming, you should try to work in TDD mode and test at least the things that you feel have more value!

One target is to do modern C# programming, so, try to apply as possible clean and modern C# (solid,lambdas,anonymous,etc...). 

You must have a building script:

* it should build your sources from command line
* run your tests
* if everything is ok, then copy executable and libraries to an artifacts folder

You must have a documentation:

* not a **_school_** documentation !
* but something that makes sense 
* something that explain what your tool do
* something that explain how to use your tool and write tests


