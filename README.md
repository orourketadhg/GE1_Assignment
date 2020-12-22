# Philips Infinite Adventure

Name: Tadhg O'Rourke

Student Number: C17403574

Class Group: DT228

# Description of the project

This project shows a procedurally animated creature (Philip) walking, via Inverse Kinematics, along a path created by a Bezier Curve Editor. This project will also showcase the use of Unity's (New) Input System to track user input. 

[![Philips Infinite Adventure](http://i3.ytimg.com/vi/S32D5DwIEcc/hqdefault.jpg)](https://youtu.be/S32D5DwIEcc)]

# Instructions for use

### Play Mode
  [spacebar] - Cycle to next camera position <br/>
  [W/S] - Increase/Decrease Walking speed <br/>
  [Up Arrow/Down Arrow] - Increase/Decrease Walking speed <br/>
  
### Editor Mode
  Path GameObject:  <br/>
  [Right Click] - Move/Adjust Anchor/Control point <br/>
  [Shift + Right Click] - Split Segment <br/>

# How it works

### Procedural Animation for creature (Walking)

The procedural creature (Philip) operates by having the legs walk under Inverse Kinematic motion. By having the Root joint act as a foot, and the leaf joint act as a sholder, each leg would act as would expect. Each leg also has a pole, this pole will pull all free moving joints towards it, allowing the legs to be always upright. For a leg to take a step, the foot (Root Joint) must exceed a certain threshold value, the foot will then calculate the position the foot will move to after the step is finished, and begin stepping. The foot follows a bezier curve to move from its previous position to its next step position. Each foot target uses physics raycasts to detect the ground, and follow it so that each foot will always rest on the ground. 

### Path

The path

# References

[![Unity PROCEDURAL ANIMATION tutorial (10 steps)](http://i3.ytimg.com/vi/e6Gjhr1IP6w/hqdefault.jpg)](https://www.youtube.com/watch?v=e6Gjhr1IP6w&ab_channel=Codeer)

[![Curve Editor](http://i3.ytimg.com/vi/RF04Fi9OCPc/hqdefault.jpg)](https://www.youtube.com/playlist?list=PLFt_AvWsXl0d8aDaovNztYf6iTChHzrHP)

[![C# Inverse Kinematics in Unity](http://i3.ytimg.com/vi/qqOAzn05fvk/hqdefault.jpg)](https://www.youtube.com/watch?v=qqOAzn05fvk&t=559s&ab_channel=DitzelGames)

# What I am most proud of in the assignment

I am most proud of the fact that I used a advanced tutorial, with help from a Inverse Kinematics tutorial, to create a completely prodedual walking animation. I am also proud of the use of Unitys (New) input system to handle any user input recieved by the player gives. 

# Proposal submitted earlier can go here:

The following project outlines a procedurally animated creature walking over a infinite winding path. The path will generate using a Bizier curve to construct the ground the creature will follow. I plan to use Unity3D's new Input System to control the camera, the colors, and the creatures speed. 
