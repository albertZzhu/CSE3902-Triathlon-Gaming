# CSE3902-Triathlon-Gaming
### This is the Sprint5 stage for the CSE 3902 project.

#### Description
Our project emulates the first dungeon from the original Legend of Zelda game. At this point, the player (who is reskinned to a custom sprite) can explore each room of the dungeon, attack enemies, and be damaged by them. Switch rooms by walking through doors. The player can die after 6 hits and they have to choose to restart or quit. If the player is able to find the triforce, the game is won and an ending screen is shown, also with quit and restart options. 

#### Motivation
In this sprint, in addition to polishing some existing features, we are adding our unique features, including a brand new level we call "horde mode", implementing A* pathfinding AI, and more. 

##### Player Control:
* user can use <code>w</code> or <code>↑</code> to move character move upwards
* user can use <code>a</code> or <code>←</code> to move character move leftwards
* user can use <code>s</code> or <code>↓</code> to move character move downwards
* user can use <code>d</code> or <code>→</code> to move character move rightwards
* user can use <code>z</code> or <code>n</code> to attack
* user can use <code>1</code>, <code>2</code>, or <code>3</code> to switch different projectiles
* user can use <code>space</code> to fire projectiles
* user can use <code>q</code> to quit at any time
* user can use the quit and pause buttons in the top right with a left click. 

##### The door to the triforce is LOCKED:
* The player needs to use a certain amount of keys to unlock it!

##### Enemies can drop items:
* Enemies can drop items when they are eliminated, including keys and health.

##### A* pathfinding AIs:
*  Implementing A* pathfinding AI in applicable rooms and the new level.

##### A brand new level:
* Big size level, horde mode. This is another way to win the game. 

##### Portal system:
* A portal system that teleports the player between different levels. 


##### KNOWN ISSUES:
* After the player is teleported from level2 to level1, this disables many game interactions. The only thing that the player can do is pick up the triforce and win the game. However, the issue will not disappear when the player immediately resets the game after picking up the triforce. 
* If the player is hit while using the boomerang, it will suddenly become unavailable to use until the player goes to another room.
* After a player death, the player can spawn outside of the bounds of the spawn room.

