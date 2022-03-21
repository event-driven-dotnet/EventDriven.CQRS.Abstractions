# EventDriven.CQRS.Abstractions

Abstractions for implementing Command Query Responsibility Segregation in .NET.

## Prerequisites
- [.NET Core SDK](https://dotnet.microsoft.com/download) (6.0 or greater)

## Packages
- [EventDriven.CQRS.Abstractions](https://www.nuget.org/packages/EventDriven.CQRS.Abstractions)
- [EventDriven.CQRS.Extensions](https://www.nuget.org/packages/EventDriven.CQRS.Extensions)

## Introduction

[Command Query Responsibility Segregation](https://martinfowler.com/bliki/CQRS.html) (CQRS) is a software a pattern that separates read and update operations for a data store.

> **Note**: EventDriven.CQRS.Abstractions version 2.0 or later uses [MediatR](https://github.com/jbogard/MediatR) to enable a handler per command pattern with behaviors for cross-cutting concerns.

The **EventDriven.CQRS.Abstractions** library contains interfaces and abstract base classes to support these concepts:
- **Command**: An object that is sent to the domain for a state change which is handled by a command handler.
- **Queries**: An object that is sent to the domain to retrieve data which is handled by a query handler.

### Reference Architecture and Development Guide

Please refer to the [EventDriven.ReferenceArchitecture](https://github.com/event-driven-dotnet/EventDriven.ReferenceArchitecture) repository for a reference architecture and development guide based on the principles of Domain Driven Design (DDD), Command Query Responsibility Segregation (CQRS) and Event Driven Architecture (EDA).