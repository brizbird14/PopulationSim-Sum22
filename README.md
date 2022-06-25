# PopulationSim-Sum22

[*HEADER IMAGE HERE*]

Link to online build: [*INSERT LINK WHEN BROWSER VERSION BUILT*]

#### Populations with differential equations

In a recent mathematics course that I attended at Rutgers University, we discussed population models as a potential application for systems of differential equations. The goals of this project were to simulate interacting populations based off of models studied in class, and to further familiarize myself with C# and the Unity API.

Tools used:
* Unity (version 2021.3.4f1)
* Blender for 3D visual assets
* Procreate for 2D visual assets


#### Simulation design

The simulation features 3 populations: chickens, foxes, and mushrooms. The chicken and fox are representative of a **predator-prey relationship**, where the *chicken's death rrate realtes to the fox's birth rate.* The chicken's birth rate is influenced by user-controlled environmental factors, while the fox's death rate decides the presence of decomposers (mushrooms).
The populations are related by the equations below, and the calculations to derive them may be found [*FILE LOC WHEN MATH CALCS POSTED*]

[*INSERT FINAL EQ PICS HERE, along with small caption below explaining variables*]

#### Code and Visuals

The above equations were translated into code, and is used to re-calculate populations at each interval of 0.2sec using population counts from the previous interval. The "Spawn" in the game instantiates and destroys game objects that visually represent the number of each mob present, depending on whether their population is increasing or decreasing.
The user can view information about the populations and interact with the simulation using UI elements:
* User control over environmental factors that influence chicken's birth rate (light levels, water presence)
* Pause/start button that pauses simulation
* Access to an info tab with animations and pop-up text that explain the simulation
* Graph that shows population counts of chickens (C) and foxes (F)

#### What I learned
* Using Unity-specific tools such as Canvas and TextMeshPro to create interactable UI
* Passing values between game objects by creating instances of custom classes
* 

#### Future improvements
* Adjust math to cap fox population
* Allow user to change speed of simulation

#### References

Textbook from maths course -- Charnley, M. (2021). Differential Equations An Introduction for Engineers. 
