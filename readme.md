This repository is a collection of tutorials from https://learn.unity.com/course/create-with-code

# Lesson 1

## Lession 1.1 - Start your 3D Engines

- Not a whole lot of new stuff here, if you're already somewhat familiar with the Unity editor and its controls etc.

### New Functionality Covererd in this Lesson:
- Project set up with assets imported
- Vehicle positioned at the start of the road
- Obstacle positioned in front of the vehicle
- Camera positioned behind vehicle

### New Concepts & Skills Covererd in this Lesson:
- Create a new project
- Import assets
- Add objects to the scene
- Game vs Scene view
- Project, Hierarchy, Inspector windows
- Navigate 3D space
- Move and Rotate tools
- Customize the layout

## Lession 1.2 - Pedal to the Metal

- Fun, but again, nothing new... Good refresher for a lazy afternoon, though :-)

### New Functionality
- Vehicle moves down the road at a constant speed
- When the vehicle collides with obstacles, they fly into the air

# New Concepts & Skills
- C# Scripts
- Start vs Update
- Comments
- Methods
- Pass parameters
- Time.deltaTime
- Multiply (*) operator
- Components
- Collider and RigidBody

## Lession 1.3 - High Speed Chase

- Not sure if this tutorial is right for me; going very slow, looking forward to the more unity-specific stuff...
- Helpful trick is to set the Playmode Tint Color (under Edit > Preferences) to a more distinct color (like #9DC2EF with alpha = 150) to get right away whether you are in edit or play mode.

### New Functionality
- Camera follows the vehicle down the road at a set offset distance

### New Concepts & Skills
- Variables 
- Data types 
- Access Modifiers
- Declare and initialize variables

## Lesson 1.4 - Step into the Driver's Seat

Modified some of the stuff that was tought here, e.g. 
- use local variables instead of members for the inputs, as that makes more sense
- multiply roration by vInput to allow the car to only turn when it's moving. (that also fixes the behaviour when backing up!)
- left some stuff public/Serialized so that it can be changed from inside the editor...

### New Functionality
- When the player presses the up/down arrows, the vehicle will move forward and backward
- When the player presses the left/right arrows, the vehicle turns 

### New Concepts & Skills
- Empty objects 
- Get user input
- Translate vs Rotate

## Lesson 1 Challenge - Plane Programming

Fun challenge, quite simple... Well, aimed at beginners. But still a nice refresher :-)