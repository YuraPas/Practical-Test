# RefactorMircoExcercise

## Timing
You can count about 90 minutes per exercise: you can organize a 90 minutes implementation with just one exercise, a 90+90 minutes implementation with 2 exercises.

## Developers’ Instructions
Complete any of the exercise of you choice. You must complete at least 1 exercies or do whichever amount you please. Please advise once delivering your result on which exercises were completed and duration taken to complete them.

This could be code you just inherited from a legacy code-base. Now you want to write unit tests for it, and that is harder than it needs to be.

For each exercise, there is only one class you are interested in writing tests for right now. As a first step, try to get some kind of test in place before you change the class at all. Identify why the class is hard to write tests for, and which SOLID principles are not being followed.

When you have some kind of test to lean on, refactor the code and make it testable. Take care when refactoring not to alter the functionality, or change interfaces which other client code may rely on. Add more tests to cover the functionality of the particular class you've been asked to get under test.

Apply the unit testing style and framework you are most comfortable with. You can choose to use stubs or mocks or none at all. If you do, you are free to use the mocking tool that you prefer.

#### 1. **TirePressureMonitoringSystem exercise**:
Write the unit tests for the Alarm class, refactor the code as much as you need to make the class testable.

The Alarm class is designed to monitor tire pressure and set an alarm if the pressure falls outside of the expected range. The Sensor class provided for the exercise simulates the behaviour of a real tire sensor, providing random but realistic values.

#### 2. **UnicodeFileToHtmlTextConverter exercise**:
Write the unit tests for the UnicodeFileToHtmlTextConverter class, refactor the code as much as you need to make the class testable.

The UnicodeFileToHtmlTextConverter class is designed to reformat a plain text file for display in a browser.


#### 3. **TicketDispenser exercise**:
Write the unit tests for the TicketDispenser, refactor the code as much as you need to make the class testable.

The TicketDispenser class is designed to be used to manage a queuing system in a shop. There may be more than one ticket dispenser but the same ticket should not be issued to two different customers.


#### 4. **TelemetrySystem exercise**:
Write the unit tests for the TelemetryDiagnosticControls class, refactor the code as much as you need to make the class testable.

The responsibility of the TelemetryDiagnosticControls class is to establish a connection to the telemetry server (through the TelemetryClient), send a diagnostic request and successfully receive the response that contains the diagnostic info. The TelemetryClient class provided for the exercise simulates the behavior of the real TelemetryClient class, and can respond with either the diagnostic information or a random sequence. The real TelemetryClient class would connect and communicate with the telemetry server via tcp/ip.

#### 5. **Refactor the entire solution architecture**:
Follow the SOLID principles and refactor the entire code base and change the architecture as you see fit without losing functionality.

## Original Exercise and possible solution

All credits to the original creators.
The original source can be found here: https://github.com/lucaminudel/TDDwithMockObjectsAndDesignPrinciples/tree/master/TDDMicroExercises#readme

## Share your solutions

Share your solutions via zip and or any other means of sharing.

## Some hints
Please ensure that you are familiar with our values in the instructions project.  They are important to us.

* simple, elegant code that reads like a narrative
* thinking about the code more than the writing of the code (we spend a lot of time thinking/debating about what we are writing)
* transparency and feedback to support continuous learning
* excellent testing that acts as documentation for the code
* challenging boundaries where necessary
