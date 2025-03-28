Use Cases (Vertical slices or Workflows)
User Stories with Acceptance Criteria

https://www.youtube.com/watch?v=MECG5MPy_cc

# Use Cases

The use cases layer contains the ‘application-specific business rules’ for the software. This is where every system use case is enclosed and implemented. Use cases help coordinate the way data flows to and from entities. It then instructs the entities that, to achieve the use case goals, they should make use of the Critical Business Rules.

Again, changes in the use case layer should have no effect on the entities. Neither do we expect any external changes, such as changes to the UI, the database, or any common framework, to affect the use case layer. In simple terms, the use layer has been isolated, so it isn’t affected by any of these concerns.

What we do expect is that any changes in the application operation will have an effect on the use cases and, as such, the layer contains the software. If any of the use case details change, some of the code in the use case layer will
need to change too.

The application layer contains application-specific information only. It operates through ‘use cases.’
The Use Cases function as “interactors” and make sure that there is a smooth flow of data to and from the domain layer to the application layer. They direct the data from the application layer into the domain layer, and vice versa too, and also make sure that the domain layer is utilizing this entity into achieving the specified goals of the application.
However, any change in this part of the layer affects the use cases, and ultimately the part of the software contained in this layer.


In simple words, we shall describe this as the “motive” or “intention” of the system under consideration, or the system that is our business. The entire coding, programming, and designing of the said software will be based on it.

Even if we forget all about architecture systems, and software engineering at this time, and think of the literal meaning of “intention,” it means the “pure feelings, or thoughts of someone, without any fakeness, or hidden meaning,” which implies that our conduct is based off our intentions. The same goes for a clean architecture system in this case. The actual outcome or the final product would be based on the “intention” that is fed into the system from the very starting. So, it is always better and always recommended that the “use cases” which are fed into the system are crystal-clear, and defining enough to elaborate on the meaning of the application in demand.

The importance of “use cases” in clean architecture can be judged from the fact that it is given the first priority, and is fed into the inner-most, or the most concentric, and important of all layers. And in accordance with that, it should be defined enough to convey the entire purpose of the program to the other outer, interfering layers.

Just like the decoupling of layers is very important to avoid confusion, the decoupling of use cases is very important too. In the literal sense, use cases are instructing the entire system how, when, and where to carry out the specific set of instructions that has been fed into it, without creating any further messes.

But sometimes, these use cases can cause confusion to arise within the system, especially in such a situation where the instructions they have been given are two contradicting statements. For example, at one point, it is instructing the system to delete a particular function, but on the other point, it is instructing it to add that particular function back again. This is neither an intentional error nor a created one, as the use case is simply doing what it has
been told to do. Under such circumstances, it becomes really necessary for the use cases to assure their decoupling, too, for failure to do so can result in extremely disastrous results, along with the crashing of the entire system.
Since use cases descend vertically down the layers, we must focus on keeping the use cases separate down that entire level of layers to achieve their decoupling.

A much better, and a smarter technique to achieve this decoupling of the use cases could be done by adding the User Interface (UI) and the database related to one particular use case in a single group. Then both of them could function as one, along with the use case that they were initially instructed to work for.
This way, separate use cases can contain all the interfaces and databases that were initially meant for them. This could help in achieving, not only the decoupling, but also would allow the use cases to proceed peacefully, without any effect, or influence whatsoever from the contradicting use case.


Use Case is a single operation within the project that leads to changing the state of the system, assuming everything goes right. Using auctioning example, we could have a Use Case for placing a bid and another one for withdrawing a bid. If we were building an e-commerce solution, we could have one Use Case for adding an item to a cart and another for removing an item from the cart. Use Case represents a single action of a user (or another actor) that is significant from the business point of view. If you are familiar with Scrum, these can be more or less translated into user stories.

The second kind of building blocks which will always reside in this layer is an Interface (also known as Port). These are abstractions over anything that sits in the layer above - Infrastructure and is required by at least one Use Case.

What is important - a Use Case MUST NOT be aware whether we are using LocalhostEmailSender or any other class inheriting from EmailSender.

The first bullet -— use cases — means that the architecture of the system must support the intent of the system. If the system is a shopping cart application, then the architecture must support shopping cart use cases. Indeed, this is the first concern of the architect, and the first priority of the architecture. The architecture must support the use cases.

However, as we discussed previously, architecture does not wield much influence over the behavior of the system. There are very few behavioral options that the architecture can leave open. But influence isn’t everything. The most important thing a good architecture can do to support behavior is to clarify and expose that behavior so that the intent of the system is visible at the architectural level.

A shopping cart application with a good architecture will look like a shopping cart application. The use cases of that system will be plainly visible within the structure of that system. Developers will not have to hunt for behaviors, because those behaviors will be first-class elements visible at the top level of the system. Those elements will be classes or functions or modules that have prominent positions within the architecture, and they will have names that clearly describe their function.

The problem is that most of the time we don’t know what all the use cases are. But all is not lost: Some principles of architecture are relatively inexpensive to implement and can help balance those concerns, even when you don’t have a clear picture of the targets you have to hit. Those principles help us partition our systems into well-isolated components that allow us to leave as many options open as possible, for as long as possible. A good architecture makes the system easy to change, in all the ways that it must change, by leaving options open.

Consider the use cases. The architect wants the structure of the system to support all the necessary use cases, but does not know what all those use cases are. However, the architect does know the basic intent of the system. It’s a shopping cart system, or it’s a bill of materials system, or it’s an order processing system. So the architect can employ the Single Responsibility Principle and the Common Closure Principle to separate those things that change for different reasons, and to collect those things that change for the same reasons — given the context of the intent of the system.

What changes for different reasons? There are some obvious things. User interfaces change for reasons that have nothing to do with business rules. Use cases have elements of both. Clearly, then, a good architect will want to separate the UI portions of a use case from the business rule portions in such a way that they can be changed independently of each other, while keeping those use cases visible and clear.

Business rules themselves may be closely tied to the application, or they may be more general. For example, the validation of input fields is a business rule that is closely tied to the application itself. In contrast, the calculation of interest on an account and the counting of inventory are business rules that are more closely associated with the domain. These two different kinds of rules will change at different rates, and for different reasons—so they should be separated so that they can be independently changed.

The database, the query language, and even the schema are technical details that have nothing to do with the business rules or the UI. They will change at rates, and for reasons, that are independent of other aspects of the system. Consequently, the architecture should separate them from the rest of the system so that they can be independently changed.

Thus we find the system divided into decoupled horizontal layers—the UI, application-specific business rules, application-independent business rules, and the database, just to mention a few.

What else changes for different reasons? The use cases themselves! The use case for adding an order to an order entry system almost certainly will change at a different rate, and for different reasons, than the use case that deletes an order from the system. Use cases are a very natural way to divide the system.

At the same time, use cases are narrow vertical slices that cut through the horizontal layers of the system. Each use case uses some UI, some application-specific business rules, some application-independent business rules, and some database functionality. Thus, as we are dividing the system in to horizontal layers, we are also dividing the system into thin vertical use
cases that cut through those layers.

To achieve this decoupling, we separate the UI of the add-order use case from the UI of the delete-order use case. We do the same with the business rules, and with the database. We keep the use cases separate down the vertical height of the system.

You can see the pattern here. If you decouple the elements of the system that change for different reasons, then you can continue to add new use cases without interfering with old ones. If you also group the UI and database in support of those use cases, so that each use case uses a different aspect of the UI and database, then adding new use cases will be unlikely to affect older ones.
