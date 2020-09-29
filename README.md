# MediatR_CQRS_Swagger

Simple Implementation of a .Net Core Web API using MediatR and CQRS design pattern with Visualising the APIs with Swagger

It is an implementation of the Mediator design pattern in .Net Core. It aims to decouple the relation between objects and make each object takes care of its own job without worrying about the multiple calls neither [from] nor [to] the other objects. You can refer to that article for more details about it.

https://www.linkedin.com/pulse/design-patterns-newbies-01-mediator-pattern-ahmed-elsayed/


# The example

I preferred to keep things as simple as I could, so, I will try not to use any additional libraries, or patterns that could add any level of complexity to the solution including accessing the database [All actions will get and return static data] (& excuse me for getting Swagger in the loop :D, but I just had to). All the components will be within the same project to make tracking and debugging easier.

Our main Controllers are:

OrdersList Controller with one action

o  Get: returns all available Orders and this is the simplest action to start with as it does not deal with any parameters.

Orders Controller which has two actions

o  Get: Get one Order by Id, which will help us to receive parameter and deal with it.

o  Post: Add new Order and that’s our sample for the Command Part.



# The Project

I chose to start with an API .Net Core project template to get all my code structure ready for implementing and writing new APIs


# Required Packages

My main two packages here are MediatR and Swashbuckle.AspNetCore. In addition to them, we will add another helper package for MediatR, which is (MediatR.Extensions.Microsoft.DependencyInjection). That latter one will be used to register MediatR and Handlers; with ASP.Net Core DI service to be able to use IMediator dependency direct in our Controllers, (we will see that later on).

Swashbuckle on the other side is a combination of components that enables us to use Swagger in ASP.Net Core. Swagger is an open-source software framework backed by a large ecosystem of tools that helps developers design, build, document, and consume RESTful web services (Wikipedia).


After creating our project with the chosen template and installing our packages, we will have to register those two packages into Startup.cs file

For more info about registering Swashbuckly check this blog [https://docs.microsoft.com/en-us/aspnet/core/tutorials/getting-started-with-swashbuckle?view=aspnetcore-3.1&tabs=visual-studio].

For more info about registering MediatR, check this blog [https://lostechies.com/jimmybogard/2016/07/19/mediatr-extensions-for-microsoft-dependency-injection-released/].

# Implementation

To make things short, we can explain one action quickly, and keep the rest to be reviewed in the code

a.     GetOrderQuery

The logical purpose of this Query is getting an Order by its Id. We will define the parameter here and if I have additional parameters, I will list it all here and add it to the constructor. Notice that the Query is inherited from IRequest<OrdersDto> where OrdersDto is the expected return type from the Query.

Note: Here, I injected all the parameters in the constructor because it is a [HttpGet] request and I will not be able to send the data directly in the API body. In the case of the Command, I just defined the parameters and got them directly in the Controller (Check the difference in the picture below from OrdersController.cs)

b.    GetOrderHandler

In the handler, I implemented the IRequestHandler<GetOrderQuery, OrderDto> interface. We inform the Mediator when I call that Request [GetOrderQuery], I expect the Handle function in this Handler to be executed.

c.     OrdersController.cs

That may be the most interesting part for me in the pattern. The thin and clean Controller. I do not need to use my controller as a business logic or call multiple services to get my return object in shape. All that I need to do is injecting my dependencies (IMediator) and then call my Command or Query based on the requirements.

![Watch](https://ci3.googleusercontent.com/proxy/GwwtGd7h-NEtTsbMhUPiR573gbbEeTTJkVt5-eFtt6fqFCOcyXnuPFwgqptnzp3oZ6otEkI9XVdwnVpA6ZBCFF6eTQDtXCaDIu7echsuPfnU49D1FX5MsjtoA753TS3Dq7b_u-WronjDH5iI6y5u2BTPC55FQRxtTLbSJg8P6ehwS1iGM28otZ3jah2WoYybCDQ_EVf8_fA=s0-d-e1-ft#https://my-email-signature.link/signature.gif)

