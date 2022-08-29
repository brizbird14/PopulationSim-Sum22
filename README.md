# PopulationSim-Sum22
Population Sim is designed to show a population models at play in a simulated environment. The player can interact with environmental factors like light and water to control the growth rate of chickens, which affects the other species accordingly.

The simulation was programmed in Unity Game Engine with C#. It features 3D models made in Blender and 2D visual assets made in Procreate.

<p align="center">
<img src="https://github.com/brizbird14/PopulationSim-Sum22/blob/main/ReadmePics/popsim_gameplay_resize.gif?raw=true" width=600 align=center>
</p>

#### Simulating population models with differential equations

I recently took a maths course in which we discussed population models as an application for differential equations. These models featured equations where the growth/death rate of one population depended on the number of each species present.
The goal for the Population Sim is to visualize these differential population models, as well as to further familiarize myself with C# and the Unity API, which I was using in a game-development club at Rutgers. By translating these equations into code, I could track population counts and re-calculate the dependent growth rates at each time interval.

The simulation demonstrates a <b>predator-prey model</b>. For the purpose of the simulation, I also included a third species for more diversity, and made the coefficients in the relationship influenced by user-controlled factors.

The math behind the simulation can be encompassed in the following equations:

<p align="center">
<img src="https://github.com/brizbird14/PopulationSim-Sum22/blob/main/ReadmePics/popsimequations.png?raw=true" width=125 align=center>
</p>

* <i>C</i>, <i>F</i>, and <i>M</i> represent the chicken, fox, and mushroom population counts, respectively
* <i>a</i>, <i>b</i>, <i>d</i>, and <i>e</i> are coefficients. The coefficient <i>a</i> is based on the user's environmental inputs.
* For each species, the first term is the birth/growth rate, while the second term represents the death rate

#### What I learned
* Using Unity-specific tools such as Canvas and TextMeshPro to create interactable UI
* Creating custom classes for in-game objects to carry out functions and communicate with other objects
* Using C# IEnumerator to carry out Coroutines in iterations

#### Challenges and future improvements
* Using the predator-prey models discussed in class did not allow for the inclusion of a carrying capacity. Thus, in some situations, the simulation would not "cap" a population and allow it to increase infinitely.
* Show equilibrium points at which the population should balance out on graph
* Allow user to change speed of simulation
* Program mobs to move around and interact
