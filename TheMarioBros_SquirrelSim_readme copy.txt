# Squirrel Sim by TheMarioBros
**Team Members**: Sahej Panag, Tyler Schott, Maxim Vancompernolle, Shirling Xu, Helena Zhang

## Objective

You play as a squirrel trying to climb / conquor 3 trees. At the top of each tree, there is a boss. Defeat all bosses and conquor all 3 trees to win and reign over the squirrel kingdom. But watch out... there are bird enimies trying to damage you on your quest for greatness!

## How to Play

Control the squirrel with standard movement controls (using the arrow keys of a keyboard for example) to go forwards/backwards and rotate. Can also jump using the space bar.

Your character can also transition on and off trees by approaching and running into them. Once on a tree, forwards/backwards becomes up/down the tree and rotations become side-to-side motion along the tree.

As you go, you can collect randomly appearing acorns on the ground and surface of the trees. Once collected, acorns can be thrown by pressing the "t" key on the keyboard. This will inflict damage to enimies.

To reach the top of a tree, simply climb up to the leaves at the top of the tree. Once you reach them, you will launch through the leaves to a boss fight at the top. Make sure to collect plenty of acorns so you can throw them and damage the boss! If you touch the boss, or their projectile hits you, you will lose health and eventually die!

If you fall off a platform, you can maneuver through the air to cling back to a tree. Otherwise you will hit the ground and be able to climb up again. Feel free to jump down off of a platform after killing the boss or just look out over the world for a bit!

Once you kill all 3 bosses, you win!

## Build Instructions
Main Scene: MainScene

## Incomplete or Buggy Features
1. The floating text is not super visible.
2. The squirrel has the ability to latch onto and climb trees. There is a bug where if the squirrel first touches a tree on one half, it will sometimes jump to the other half instantaniously, causing a quick character teleportation and camera whip.
3. If a button was previously pressed must press open space on the screen again before pressing space to jump or it will open the button again.
3. Apart from that no known bugs!!
** This is not a bug but an important to know -- the game is intended to be played in 1080x720 aspect ratio.

## External Assets
- Squirrel Body: Mesh provided by 3rd party, animations done by us
- Birds (including bosses): Mesh provided by 3rd party, animations done by us
- Tree Texture: Material provided by 3rd party asset
- Leaf Texture: Material provided by 3rd party asset

## Contribution Manifest
### Sahej Panag

** Final Bosses on Top of Trees **
'/Assets/BossAssets/Additions' <- worked on everything within this (animations visible)
'/Assets/BossAssets/Additions/EnemyFollow.cs'
'/Assets/BossAssets/Additions/BossScript.cs'

- Implemented and created all of the bosses on the trees and everything associated with them

- Implemented EnemyFollow Script
  - Follows the player within a certain distance
  - Based on boss's tag attacks player in method of attack
  - Updates health bar and health status
  - Triggers animations for the animator
  - Triggers appropriate audios
  
- Implemented BossScript
  - Reference for the health bar and to track health of boss
  
- Implemented individual animations for each boss
  - Created multiple animations for each boss
  - Created the animtor and respective triggers
  - Created different states
    - Idle state
    - State when shot
    - State when dead
    - Based on boss state when running
    - Based on boss state when attacking
    
** Bullet Projectiles and Firing **
'/Assets/BossAssets/Additions/AcornProjectile.cs'
'/Assets/BossAssets/Additions/Projectile.cs'
`/Assets/Scripts/PlayerController.cs`
  
- Projectile
  - Implemented projectile script for enemy
  - Moves in relation to delta time with a fire rate (this was actally implemented in EnemyFollow)
  - Makes the bullet move towards the player
  - Created material and prefab for bullet
  
- Acorn Projectile
  - Created projectile for the player
  - Makes the bullet move at certain velocity in relation to launchForce
  
- Acorn Shooting
  - Instantiated bullet
  - Updated count as Necessary
  
** Damage Taken and Screen Logic **
`/Assets/Scripts/PlayerController.cs`
`/Assets/BossAssets/Additions/EnemyFollow.cs`
`/Assets/BossAssets/Additions/BossScript.cs`

- Implemented collisions for both squirrel and final bosses
  - If final boss is shot checks for whether to change health bar or to destroy
  - Same with the squirrel
  - Updates screens accordingly based on deaths
  
- Createed and Implemented Health Bars
  - All visible when looking at what was passed in PlayerController and BossScript
  - For bosses added them to world space so they sit above boss
  - For squirrel added them to screen space so visible for player
  
** Game Audio **
`/Assets/Scripts/PlayerController.cs`
`/Assets/BossAssets/Additions/EnemyFollow.cs`

- Implemented Audio throughout game
  - Audio occurs when collision of player with acorn
  - Audio occurs when player attemps to shoot but has no acorns
  - Audio acorns on click events for shop menu and pause buttons
  - Audio occurs when player collides with the crates
  - Audio occurs when the enemies get shot
  - Audio occurs when the enemies die
  - Audio occurs when starting deer disappears
  
** Game Intro **
`/Assets/BossAssets/Additions/Dialogue.cs`

- Added game intro
  - Spawn character in certain space
  - Have interaction with deer
  - Animate the deer
  - Add dialogue that updates and changes
  - Dialogue is also able to show up completely when clicked and allows to skip forward
  
** Floating Text **
`/Assets/BossAssets/Additions/FloatingText.cs`

- Add floating text to game to show "-10" when boss has been shot

### Tyler Schott
**Squirrel Transitions Between Tree and Ground:**

`/Assets/Scripts/PlayerController.cs`
- Transitioning between being on the floor and on the tree
- Transitioning between being on the tree and the platforms on top of the tree
- Attaching to the tree when flying in the air

**Squirrel Movement on Flat Ground and on Tree:**

`/Assets/Scripts/PlayerController.cs`
- Motion forward, backwards, rotation on ground (not animation)
- Motion up and down the tree, circularly around the tree
- Interaction to go above the leaves

**Camera Control**

`/Assets/Scripts/CameraController.cs`
- Camera follows the squirrel's motion and rotation

**Environment**

- Created trees and leaf platforms
- Found and added textures
- Made initial scene including trees, ground, character, etc
- Added tree barrier around the world, mountains, grasses/bushes, path, shop/starting buildings

**Misc**

- Added countdown timer for game end
- Created Readme, trailer, builds, submission

### Maxim Vancompernolle

**Boss interactions**
`/Assets/Scripts/PlayerController.cs`
- Add boss introduction text with a title, an explanation of their moves, and how to defeat them
- Pausing the game indefinitely to allow the user to read at their own pace

`/Assets/Scripts/ScrollTextScripts.cs`
- Add textScroll() to remove the boss introduction text upon mouse click
- Unpauses the game and puts you right into the heat of battle

**Pause Menu**
`/Assets/Scripts/ControlsMenuScript.cs`
- Add controls text for the player in case they forget
- WASD to move
- T to shoot
- Space to jump
- Allow controls to be accessed from the pause menu and resume play from the controls menu

`/Assets/Scripts/CreditsMenuScript.cs`
- Add credits text with our team member names
- Allow credits to be accessed from the pause menu and resume play from the credits menu

**Enemy Control**

`/Assets/Scripts/BirdController.cs`
- Applies rotation and translation to bird enemies on trees to make them circle around
- Temporary Script while testing more advanced enemy AI

`/Assets/Scripts/SweeperController.cs`
- Controls sweeper enemy class with xDelta constraint
- "Sweep" horizontally across the tree by a specified xDelta amount

`/Assets/Scripts/SwooperController.cs`
- Controls swooper enemy class with yDelta constraint
- "Swoop" vertically across the tree by a specified yDelta amount

`/Assets/Scripts/ChaserController.cs`
- Controls chaser enemy class
- Interpolate squirrel position and paths to it (not yet implemented)

### Shirling Xu
**Win and lose screens**
- Created win and lose screens

**Collect acorns and acorn count**
`/Assets/Scripts/PlayerController.cs`
- Acorn count increases upon squirrel collision with acorn
- Count is displayed on top left corner

**Acorn prefabs and assets**
`/Assets/Prefabs`
- Created collectable acorn asset
- Created acorn bullet asset

**Randomly spawned acorns**
`/Assets/RandomSpawner.cs`
- Randomly spawns acorns across ground and around the trees

**Created acorn animations**
`/Assets/Animations`
- Acorn bounce animation

**Created squirrel animations**
`/Assets/Animations`
`/Assets/Scripts/PlayerController.cs`
- Created Squirrel idle, crawling, and jumping animations with transitions (uses foot IK)
- Squirrel returns to idle position when in rest
- Squirrel moves when WASD or arrow keys are pressed
- Squirrel jumps when space is pressed

**Tree labels**
- Added easy, difficult, and medium signs to trees

**Nav surface for bosses**
- Expanded baked navigation surface for AI bosses

### Helena Zhang
**Shop Instructions Menu, Pause Menu**
`/Assets/ShopInstructionsToggle.cs`
- Added a screen for the shop instructions menu that tells player to navigate to the store
- Shop button opens the screen
- Exit closes the screen

**Shop & Shop Menu**
`/Assets/Scripts/ShopMenuController.cs`
`/Assets/Scripts/StoreTableShopMenuController.cs`
- Added wall of rigidbody crates in front of shop entrances that player must knock down in order to enter
- When player triggers the sphere collider inside (gets far enough inside the shop), shop menu appears
- Sprite images represent menu items
- Buying items from shop reduces player's acorn count and affects player / enemies 
  - Health, speed, and damage to enemies all increase
  - Success text pops up when item is successfully purchased
  - Error message appears if player does not have enough acorns
- User can exit the menu by clicking exit button
- Game time freezes during this

`/Assets/Scripts/PlayerController.cs`
- Added functions to fetch and update attributes of the squirrel for buying shop menu items

`/Assets/Scripts/EnemyFollow.cs`
- Buying damage boost from the shop successfully updates the amount of damage each enemy bullet causes
- Bullet gets destroyed immediately after collision with enemy (so that one acorn bullet was not causing multiple collisions' worth of damage)

**Bird Enemies**
`/Assets/Scripts/BirdController.cs`
`/Assets/living birds/animations/blueJayAnimationController.controller`
- Created new Animator controller for bird hops (imported living birds folder of assets)
- Bird Controller for enemy birds motion 

**Background Audio**
`/Assets/Scripts/Nature/`
- Added background audio game object to the game
