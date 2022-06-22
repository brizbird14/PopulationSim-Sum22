# PopulationSim-Sum22

Link to online build:

#### Population models with differential equations

In a recent maths course that I took at Rutgers University, we discussed how populations can be modeled with differential equations. During this course I completed simple coding assignments in MATLAB to model healthy, infected, and deceased populations in a “disease” scenario.

To expand on the topics discussed in class, I made a population simulation that models the predator-prey relationship between two populations, chickens and foxes, and their relationship with environmental variables that the user can control.

This project was completed in Unity 2021.3.4f1 in C#. All 3D assets were modeled in Blender, and all 2D and UI assets were created in Procreate.


#### Population simulation design

The chicken and fox populations also depend on environmental factors like light level, water availability, and the presence of decomposers (mushrooms), some of which can be controlled by the user. It uses the following equation, which is a combination of the two following equations discussed in class.

[*Fill in later, planning to adjust soon*]

The first of the template equations discusses the relationship between two co-existing populations that demonstrate exponential growth, while the other relates a simple predator-prey relationship, where the shared term is positive for one population (predator) and negative for the other (prey). Because I wanted to include both a population limit/plateau and a predator-prey relationship, it was necessary to combine the two.

![Example of competing species equation](ReadMePics/rmPic_CompetingSpeciesFormulas.png)
This is an example of the rate equations for two competing species, taken from the textbook of the aforementioned math class. Here, *x* and *y* represent the competing populations, and constants *K* and *M* represent their population caps, respectively.

![Example of predator-prey species equation](ReadMePics/rmPc_PredPreyFormulas.png)
This is an example of the rate equations for species in a predator-prey relationship. Here, *x* represents the prey population, since the shared term (containing *xy*) is negative, while *y* is the predator pouplation and its rate equation contains a positive shared term.

One current issue encountered here is that, because the predator (Fox) population has a positive shared term, it can exceed the population cap *K* and can thus increase infinitely.

The user has access to a light level (slider) and a pond for water availability (on/off button), which indirectly influence the chicken population. They are also able to view an info screen, which explains the simulation, and a graph that shows the current population counts.

#### Future improvements

* Improving formulas to cap fox population
* Mob movement
* Graph dynamic movement between points and scaling
* Touching up UI and 3D assets

#### References

Textbook from maths course -- Charnley, M. (2021). Differential Equations An Introduction for Engineers. 