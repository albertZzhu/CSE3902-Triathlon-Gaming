# CSE3902-Triathlon-Gaming
### This is the Sprint3 stage for the CSE 3902 project.

#### Description
Our project emulates the first dungeon from the original Legend of Zelda game. At this point, the player (who is reskinned to a custom sprite) can explore each room of the dungeon, attack enemies, and be damaged by them. There is no way for the player character to switch rooms, but the user can switch rooms from the keyboard.

#### Motivation
This sprint, we knew we had to implement collision and create the rooms of the first level. This, we were able to do. We also added a game object manager. Our other goal was to refactor our previous code to a higher quality. We made some progress on some more complex refactoring for execute and state machines, but not to the point where they were able to be added to the project. Many small things such as comments and object declaration locations were cleaned up. As time allows, we plan to add more custom sprites to make the project our own. 

##### Player Control:
* user can use <code>w</code> or <code>↑</code> to move character move upwards
* user can use <code>a</code> or <code>←</code> to move character move leftwards
* user can use <code>s</code> or <code>↓</code> to move character move downwards
* user can use <code>d</code> or <code>→</code> to move character move rightwards
* user can use <code>z</code> or <code>n</code> to attack
* user can use <code>e</code> to make the character damaged
* user can use <code>1</code>, <code>2</code>, or <code>3</code> to switch different projectiles
* user can use <code>space</code> to fire projectiles

##### Added NPC:
* NPC can fire projectiles
* NPC can move automatically
* dragon can fire three fireballs at the same time

##### Added Room Switching:
* user can use <code>0</code> to switch to the next room
* user can use <code>9</code> to switch to the previous room

##### Added Collision:
* player can detect interaction with NPC's projectiles, blocks and items

##### KNOWN ISSUES:
* the player may be stuck on blocks and walls slightly by its toes / head
* no damage caused via player doing melee attacks
* The player's damage sprite is larger than is correct.
* When facing left, the player's projectiles collide with the player's hitbox, causing damage.
* The player's melee attack animations do not play properly.

