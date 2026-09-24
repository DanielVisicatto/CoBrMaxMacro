# CoBrMaxMacro

Desktop automation project built with **C# / .NET 10** and **WPF**, currently focused on **CABAL Online**.

The project is being developed as a modular desktop application, with an emphasis on maintainability, separation of responsibilities, and gradual evolution of automation features.

> This is an independent project and is not affiliated with or endorsed by CABAL Online or its publishers.

## Overview

CoBrMaxMacro is designed to provide a structured interface for configuring and controlling in-game automation routines.

The current development direction includes:

- Character class selection
- Map and spot selection
- Skill configuration
- Combat routine configuration
- HP and MP potion handling
- Battle Mode support
- Action bar switching
- Runtime state detection
- Visual game-state recognition
- Progression-oriented automation
- Future support for local AI-assisted features

The application is still under active development, and features are being added incrementally.

## Current Status

The project already includes:

- WPF desktop application structure
- Light, Dark, and System theme support
- Custom application controls and styling
- Character class selection
- Initial map data infrastructure
- Dependency Injection
- Query and command abstractions
- Repository-based data access
- Modular resource dictionaries
- Versioned application contracts

Screenshots and usage examples will be added as the UI and main workflows evolve.

## Tech Stack

- **C#**
- **.NET 10**
- **WPF**
- **Microsoft.Extensions.DependencyInjection**
- **System.Text.Json**

### Architecture and Practices

The project follows principles and patterns such as:

- Clean Architecture
- Domain-Driven Design concepts
- CQRS / CQS
- Vertical Slice organization
- SOLID
- DRY
- KISS
- Dependency Injection
- Repository Pattern
- Separation of presentation, application, domain, and infrastructure concerns

## Solution Structure

```text
src/
├─ CoBrMaxMacro.Presentation
├─ CoBrMaxMacro.Application
├─ CoBrMaxMacro.Domain
└─ CoBrMaxMacro.Infrastructure
```

### Presentation

Responsible for the WPF user interface, themes, controls, application startup, and dependency composition.

### Application

Contains use cases, commands, queries, handlers, models, and application-level contracts.

### Domain

Contains core domain concepts such as character classes, character progression, and related value objects.

### Infrastructure

Contains external and technical implementations such as repositories and local game data sources.

## UI

The application uses a custom WPF interface with:

- Custom title bar
- Light / Dark / System themes
- Custom ComboBox controls
- Modular ResourceDictionary files
- Reusable visual components

The UI is being built feature by feature to avoid large monolithic XAML files and keep visual resources easy to maintain.

## Data

Static game information is currently stored locally and accessed through repository abstractions.

JSON is used for externalized game data, while runtime collections can be optimized for efficient in-memory lookup.

As the project grows, additional persistence mechanisms may be introduced where they provide a clear benefit.

## Planned Features

Some of the planned areas include:

- Map selection
- Spot selection
- Character profiles
- Skill and action-bar configuration
- Combat state handling
- Target detection
- Combo support
- Potion automation
- Navigation
- Quest and dungeon workflows
- Character progression tracking
- Screen capture and visual state recognition
- Local AI-assisted classification and decision support

The roadmap may change as the project evolves.

## Development Approach

The project is intentionally being developed incrementally.

New abstractions are introduced only when there is a concrete need, keeping the codebase simple while still allowing the architecture to evolve as the application becomes more capable.

Visual resources, controls, and features are kept granular to make maintenance and future expansion easier.

## Requirements

- Windows
- .NET 10 SDK
- Visual Studio with WPF support

## Build

Clone the repository and build the solution:

```bash
git clone https://github.com/DanielVisicatto/CoBrMaxMacro.git
cd CoBrMaxMacro/src
dotnet restore
dotnet build
```

Then run the `CoBrMaxMacro.Presentation` project.

## Project Status

**Early development / work in progress**

The core architecture and initial UI foundation are in place, while automation features are being implemented progressively.

## Disclaimer

This project is intended for software development, experimentation, and learning purposes.

Users are responsible for ensuring that any use of automation complies with the rules and terms of service of the software or game being automated.
