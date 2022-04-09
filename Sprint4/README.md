# CSE3902-Triathlon-Gaming
### This is the Sprint3 stage for the CSE 3902 project.

#### Description
Our project emulates the first dungeon from the original Legend of Zelda game. At this point, the player (who is reskinned to a custom sprite) can explore each room of the dungeon, attack enemies, and be damaged by them. Switch rooms by walking through doors. The player can die after 6 hits and they have to choose to restart or continue. If the player is able to find the triforce, the game is won and an ending screen is shown, also with quit and restart options. 

#### Motivation
This sprint, things came together into a more cohesive product. We added sound, moving from room to room, menus and pausing. We also changed a couple things internally, such as moving code to databases and further implementing the Game Object Manager.

##### Player Control:
* user can use <code>w</code> or <code>↑</code> to move character move upwards
* user can use <code>a</code> or <code>←</code> to move character move leftwards
* user can use <code>s</code> or <code>↓</code> to move character move downwards
* user can use <code>d</code> or <code>→</code> to move character move rightwards
* user can use <code>z</code> or <code>n</code> to attack
* user can use <code>1</code>, <code>2</code>, or <code>3</code> to switch different projectiles
* user can use <code>space</code> to fire projectiles
* user can use the quit and pause buttons in the top right with a left click. 

##### Added Room Switching:
* user can walk through doors to change rooms, which are properly laid out on a map, including an accurate map showing the player's location when unlocked.

##### Polished Collision:
* player no longer gets stuck near walls and can shoot projectiles over water but not walk across it. 

##### KNOWN ISSUES:
* When facing up or down and near a wall on the right or left, the large projectile sprite hits the wall before anything else and will not properly fire.
* The player's animations do not play properly.
* when player win the game and press r to restart the game, the player status like HealthPoints won’t be updated if player get hurt in the previous game play. Only the initial location in which room will be updated.
* Items that should only have 1 copy respawn when the player reenters a room

