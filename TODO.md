https://www.youtube.com/watch?v=WAoqGzVDHc0

Hexagonal architecture allow you to run your application without UI or data storage. The application can be equally driven by users, programs or automated tests. The application can be development in isolation from UI or data storage.

The ports to access the hexegon application are driven by UI, Web API or automated tests (the primary actors).
The way the hexegon accesses outside resources such as databases is through adaptors. The application is coupled to an interface contract rather than an adaptor implementation in order to call a database.

* [ ] Create a unit test targeting a single use case (couple tests to behaviour not implementation or structure of the code, if the behaviour stays the same after refactoring then the tests won't break)
