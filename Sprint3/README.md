# CSE3902-Triathlon-Gaming
### This is the Sprint3 stage for the CSE 3902 project.

#### Description
Our project emulates the first dungeon from the original Legend of Zelda game. At this point, the player (who is reskinned to a custom sprite) can explore each room of the dungeon, attack enemies, and be damaged by them. There is no way for the player character to switch rooms, but the user can switch rooms from the keyboard.

#### Motivation
This sprint, we knew we had to implement collision and create the rooms of the first level. This, we were able to do. We also added a game object manager. Our other goal was to refactor our previous code to a higher quality. We made some progress on some more complex refactoring for execute and state machines, but not to the point where they were able to be added to the project. Many small things such as comments and object declaration locations were cleaned up. As time allows, we plan to add more custom sprites to make the project our own. 

##### player control:
* user can use <code>w</code> or <code>↑</code> to move character move upwards
* user can use <code>a</code> or <code>←</code> to move character move leftwards
* user can use <code>s</code> or <code>↓</code> to move character move downwards
* user can use <code>d</code> or <code>→</code> to move character move rightwards
* user can use <code>z</code> or <code>n</code> to attack
* user can use <code>1</code>, <code>2</code>, or <code>3</code> to fire different projectiles

##### KNOWN ISSUES:
* The room flickers when the room changes from one to another.
* The player's damage sprite is larger than is correct.
* When facing left, the player's projectiles collide with the player's hitbox, causing damage.
* The player's melee attack animations do not play properly.
* Sometimes, the player will get stuck inside blocks. 
