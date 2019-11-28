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

### New Concepts & Skills
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

## Lesson 2.3 - Collision Decision

Working with colliders was a nice refresher!

### New Functionality
- Animals spawn on a timed interval and walk down the screen 
- When animals get past the player, it triggers a “Game Over” message
- If a projectile collides with an animal, both objects are removed

### New Concepts & Skills
- Create custom methods/functions
- InvokeRepeating() to repeat code
- Colliders and Triggers 
- Override functions
- Log Debug messages to console


### Unit 3 - Run and Jump

## Lesson 3.1 - Jump Force

One thing I didn't know was that Unity has several ForceModes (e.g. for use with Rigidbody.AddForce()) for different use cases (https://docs.unity3d.com/ScriptReference/ForceMode.html)!

I really don't like changing global properties from non-static GameObjects... This feels ugly and in my opinion can lead to unexpected side effects (imagine multiple instances of player with different settings for this property!)

Therefore I decided to move this piece of code to a GameManager-GameObject and make it a singleton as described here -> https://answers.unity.com/questions/576969/create-a-persistent-gameobject-using-singleton.html

I think I'll also change how the velocity system works in a similar way...

### New Functionality
- Player jumps on spacebar press
- Player cannot double-jump
- Obstacles and Background move left
- Obstacles spawn on intervals

### Key Concepts and Skills
- GetComponent
- ForceMode.Impulse
- Physics.Gravity
- Rigidbody constraints
- Rigidbody variables
- Booleans
- Multiply/Assign (“*) Operator
- And (&&) Operator
- OnCollisionEnter()

## Lesson 3.2 - Make the World Whiz By

Instead of adding an additional box collider to the background, one can use `repeatWidth = GetComponent<SpriteRenderer>().bounds.size.x / 2;` to achieve the same result!

- Refresher on tags which was helpful!
- Cross-Script-Communication was really helpful; though I'm not sure if I wouldn't want to use references instead of tags and GameObject.Find(string)!? Guess both have their place!
- I decided to do some things slightly different, e.g. how and when Obstacles are destroyed: I decided to use a separate script here and use the y coordinate (i.e. as soon as the obstacle starts falling it gets destroyed).

### New Functionality
- Background repeats seamlessly
- Background stops when player collides with obstacle
- Obstacle spawning stops when player collides with obstacle
- Obstacles are destroyed off-screen

### New Concepts and Skills:
- Repeat background
- Get Collider width
- Script communication
- Equal to (==) operator
- Tags
- CompareTag()

## Lesson 3.3 - Don't Just Stand There

Playing around with the Animator and the Animator's State Machine was helpful!

### New Functionality:
- The player starts the scene with a fast-paced running animation
- When the player jumps, there is a jumping animation
- When the player crashes, the player falls over
### New Concepts and Skills:
- Animation Controllers
- Animation States, Layers, and Transitions
- Animation parameters
- Animation programming
- SetTrigger(), SetBool(), SetInt()
- Not (!) operator

## Lesson 3.4 - Particles and Sound Effects

Working with AudioClips and AudioSource, especially AudioSource.PlayOneShot() was helpful!

### New Functionality:
- Music plays during the game
- Particle effects at the player’s feet when they run
- Sound effects and explosion when the player hits an obstacle

### New Concepts and Skills:
- Particle systems 
- Child object positioning
- Audio clips and Audio sources 
- Play and stop sound effects


# Unit 4 - Gameplay Mechanics

## Lession 4.1 Watch Where You're Going

Added a mouse controller! :-) Works like a charm!

### New Functionality:
- Camera rotates around the island based on horizontal input
- Player rolls in direction of camera based on vertical input

### New Concepts and Skills:
- Texture Wraps
- Camera as child object
- Global vs Local coordinates
- Get direction of other object

## Lesson 4.2 - Follow the Player

- Moved Rigidbody.AddForce()-calls to FixedUpdate for proper physics handling.
- Implemented the SpawnManager using a circular spawn area and a minimum distance to player.

### New Functionality:
- Enemy spawns at random location on the island
- Enemy follows the player around 
- Spheres bounce off of each other 

### New Concepts and Skills:
- Physics Materials
- Defining vectors in 3D space
- Normalizing values
- Methods with return values

## Lesson 4.3 - PowerUp and CountDown

- Coroutines are pretty cool, as they "are excellent when modeling behavior over several frames." (https://docs.unity3d.com/ScriptReference/MonoBehaviour.StartCoroutine.html)

### New Functionality:
- When the player collects a powerup, a visual indicator appears
- When the player collides with an enemy while they have the powerup, the enemy goes flying
- After a certain amount of time, the powerup ability and indicator disappear

### New Concepts and Skills:
- Debug concatenation
- Local component variables 
- IEnumerators and WaitForSeconds()
- Coroutines
- SetActive(true/false)

## Lesson 4.4 - For-Loops For Waves

- Use `GameObject.FindGameObjectsWithTag("Enemy").Length` or `GameObject.FindObjectsOfType<EnemyController>().Length` to determine the number of enemies alive

### New Functionality:
- Enemies spawn in waves
- The number of enemies spawned increases after every wave is defeated
- A new power up spawns with every wave
### New Concepts and Skills:
- For-loops
- Increment (++) operator
- Custom methods with parameters
- FindObjectsOfType


# Unit 5 - User Interface

## Lesson 5.1 - Clicky Mouse

While the teacher uses Coroutines, I decided to go with InvokeRepeating. A discussion about the approaches can be found here: https://forum.unity.com/threads/invoke-vs-coroutine.40928/

Despite my decision here, I totally agree with that: "I find that Invokes are error-prone (string calling) and limiting (no parameters)."

### New Functionality:
- Random objects are tossed into the air on intervals
- Objects are given random speed, position, and torque
- If you click on an object, it is destroyed

### New Concepts and Skills: 
- 2D View
- AddTorque 
- Game Manager
- Lists
- While Loops
- Mouse Events

## Lesson 5.2 - Keeping Score

Impressive how much bang the simple particle effect adds to the game! Cool stuff, and pretty simple to implement!

### New Functionality:
- There is a UI element for score on the screen
- The player’s score is tracked and displayed by the score text when hit a target
- There are particle explosions when the player gets an object

### New Concepts and Skills:
- TextMeshPro 
- Canvas
- Anchor Points
- Import Libraries
- Custom methods with parameters
- Calling methods from other scripts

## Lesson 5.3 - Game Over

Note that UI-Buttons offer OnClick-Listeners right from the Editor that do not require any additional code. Just make sure that you drag in the actual GameObject into the Inspector, rather than using the circle and selecting the script-asset that you want to use!

### New Functionality:
- A functional Game Over screen with a Restart button
- When the Restart button is clicked, the game resets

### New Concepts and Skills: 
- Game states 
- Buttons
- On Click events
- Scene management Library
- UI Library
- Booleans to control game states

## Lesson 5.4 - What's the Difficulty

### New Functionality
- Title screen that lets the user start the game
- Difficulty selection that affects spawn rate

### New Concepts and Skills:
- AddListener() 
- Passing parameters between scripts
- Divide/Assign (/=) operator
- Grouping child objects

