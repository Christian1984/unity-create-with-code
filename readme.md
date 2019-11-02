This repository is a collection of tutorials from https://learn.unity.com/course/create-with-code

# Unit 1 - Player Control

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


# Unit 2 - Basic Gameplay

## Lesson 2.1 - Player Positioning

Nice little excercise. Gets one comfy with setting up a new project, importing assets etc.

If Visual Studio Code Autocomplete does not work:
- make sure you have dotnet sdk installed
- make sure you have the C#-vscode-extension installed
- make sure you have the correct project select (bottom right in status bar)
- restart vscode

### New Functionality
- The player can move left and right based on the user’s left and right key presses
- The player will not be able to leave the play area on either side

### New Concepts & Skills
- Adjust object scale
- If-statements
- Greater/Less than operators

## Lesson 2.2 - Food Flight

- Overrides: If you update an instance of a prefab and want to see the diff between the two, and/or update the prefab/revert the instance to the prefab's state, click override on the top right of the inspector!
- Make sure to use the right reference space (Space.Local vs. Space.World when moving and rotating objects at the same time!)

### New Functionality
- The player can press the Spacebar to launch a projectile prefab,
- Projectile and Animals are removed from the scene if they leave the screen

### New Concepts & Skills
- Create Prefabs
- Override Prefabs
- Test for Key presses
- Instantiate objects
- Destroy objects 
- Else-if statements

## Lesson 2.3 - Random Animal Stampede

Random.Range has overloaded methodes:
- int Random.Range(int min, int max) for min (inclusive) and max (EXclusive) and
- float Random.Range(float min, float max) for min (inclusive) and max (INclusive)

### New Functionality
- The player can press the S to spawn an animal
- Animal selection and spawn location are randomized
- Camera projection (perspective/orthographic) selected

### New Concepts & Skills
- Spawn Manager
- Arrays
- Keycodes
- Random generation
- Local vs Global variables
- Perspective vs Isometric projections