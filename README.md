# PM.Assessments.ShopModel
A simple shop model using the OOP approach.
This model is just an abstraction, and there are no implementations.
It has different domains, and each part is separated using a folder for simplicity.
Each domain is responsible for its operations. some domains are dependent on each other which is not the best practice and could be replaced with messaging patterns.
I have used some design patterns like `Strategy` (to calculate prices and costs) and `Observer` (to notify price changes or other events). It was possible to use other design patterns like `Decorator`
to represent different product types and also `Factory` to create desired product types.
