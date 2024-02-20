# Antymology Project

This Unity project is for the CPSC 565: Emergent Computing course, Winter 2024, led by Christian Jacob at the Department of Computer Science, University of Calgary. The assignment, titled "Antymology," challenges students to simulate ant behavior and nest building using principles of emergent computing.

## Project Objective

The primary goal is to create a species of ant capable of generating the largest nest possible through evolutionary algorithms and interaction with a simulated environment. Ants must exhibit complex emergent behaviors derived from simple individual rules, focusing on activities such as foraging, nest building, and environmental interaction.

## Current Implementation

### Components

#### 1. Agents
- **AntLogic** and **AntHouse** (contained within `AntLogic.cs`): Define the basic movement, decision-making logic, and health management for ants.
- **Implementation**: Simple random movement and health depletion over time.
- **TO DOs**:
  - Develop complex behaviors based on environmental stimuli and objectives.
  - Implement ant-to-ant interactions, such as health donation and nest building.

#### 2. Configuration
- **SimulationSettings** (`SimulationSettings.cs`): Stores configuration settings for the simulation, such as ant count and simulation tick interval.
- **AntSettings** (`AntSettings.cs`): Defines ant-specific parameters like initial health and health modification rates.
- **TO DOs**:
  - Expand settings to include genetic traits and mutation rates for the evolutionary algorithm.

#### 3. Terrain
- **WorldManager** (`WorldManager.cs`): Manages terrain generation and initializes ant entities.
- **Implementation**: Terrain generation based on simplex noise, random ant spawning.
- **TO DOs**:
  - Integrate resources and obstacles into the terrain.
  - Optimize terrain generation for realistic environmental challenges.

#### 4. UI
- **Current Implementation**: Basic camera control and a placeholder for UI elements.
- **TO DOs**:
  - Develop a UI system to display real-time simulation data, such as nest size and ant population.
  - Implement controls for simulation parameters and observation tools.

### Goals and Remaining Tasks

- **Evolutionary Algorithm**: Implement an evolutionary algorithm to evolve ant behavior over generations.
  - **TO DOs**:
    - Define a fitness function based on nest size and survival.
    - Implement a breeding system that uses the fitness scores to select traits for offspring.
- **Environmental Interaction**: Enhance ant interactions with the environment to include foraging for resources, avoiding predators, and responding to environmental changes.
- **Nest Building**: Develop mechanisms for ants to collectively build nests, requiring coordination and resource management.
- **Simulation Analysis**: Create tools for analyzing and visualizing the simulation's progress, including tracking the evolutionary success of ant behaviors.

## Getting Started

To contribute to this project:
1. Clone the repository and open it in Unity version 2022.3.18f1.
2. Ensure all prefabs and ScriptableObjects are correctly assigned in the Unity Editor.
3. Review the TO DOs listed in each component for areas that require development.

## Contribution Guidelines

Contributors are encouraged to document their changes comprehensively and adhere to established coding conventions. Major changes should be discussed in issues before implementation.

## License

This project is licensed under the MIT License - see the LICENSE file for details.
