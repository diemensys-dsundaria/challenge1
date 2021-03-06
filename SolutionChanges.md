# As per instructions, changes are done as below:


# Code Refactoring

## The Challenge
* Incorporate IOC using a DI container of your choice.
    Used **Unity** container for DI.
* Appropriate unit testing coverage.
    Added two more test classes:
    1. Option2ControllerTests
    2. Option2VoucherDirectBusinessTests

    For doing direct tests on controller methods and business methods.

* Refactoring the code base as appropriate to:
>1. Improve the overall usability.
    Nuget packages added
>2. Maintainability of the codebase.
    a) Adjusted substitute method to point to datalayer. Removed direct access through controller
    b) Cleaned up controller and business logic moved out
    c) Data retrieval done in data layer
>3. Performance.
    a) Caching implemented with policy on change file

Refactored code as much can be done in short time frame, still there is some places where code can be refactored. For time being, left like some places loops can be changed into LINQ statements.
