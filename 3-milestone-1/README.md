Hello, and welcome to my first blog post of OverChrome!! The game actually got renamed (Overtone -> Overchrome) since writing the Game Design Document because I thought it alluded to the concept more (Chrome = Color).

The main systems implemented in this “sprint” were:
    1. Player Control
    2. Color Mechanics
    3. Enemy Health
    4. Shooting Mechanics

I will take the description System by System.

## 1. Player Control
This one was a bit tricky. I first thought I would do my game as a **Top-Down Shooter**, so I went with that and fully implemented it. One of the cool parts was that the player would have a crosshair that pointed in the direction that he last moved towards, and this way he knew exactly where his bullets would shoot when he did. This was challenging to implement, but cool.

![ezgif-4-cdc19d69d6](https://github.com/laurarebelo/GMD1/assets/91252082/e6f3b16e-3101-4c86-8dc7-cce4e3e92eb3)

However, I was still concerned about the input constraints. Moving in two directions, dodging enemies, and killing them, all at the same time with only one joystick, did not seem like a good user experience. To tackle this, I considered doing an aim assist system, or even auto-aim (since it was pretty hard to aim at enemies with the keyboard inputs), but left that for the next day.

In the said next day, I started thinking to myself... and I realized that the game would be a lot better as a platformer. Not only would it be easier to design levels, but also to navigate them, and the input/aim issue would be resolved since we wouldn't need to worry about shooting enemies "above" or "below" us - only in front or behind.

So, I implemented a platformer-type control. I dreaded this big change, but when I got to it, it was incredibly easy thanks to the way I had approached Components. The Player's Shooting Mechanics resided in another Component, so all I had to do was swap out the "PlayerTopDownController", archive it (because you never know when old scripts will come in handy, even if they're unused), and replace it with my new "PlayerPlatformerController".

For the platformer, I also had to implement the Camera following the Player and the Bounds of the Level so that the Player couldn't fall off. This is illustrated in the gif below - I cannot fall to the left at the beginning of the level. This was pretty simple and also handled mindfully of extendability (for different levels, it will be easy to set new boundary values and pass them to the Player Controller.)

![ezgif-4-32e1a1efd8](https://github.com/laurarebelo/GMD1/assets/91252082/0dba3e7c-38c4-4d59-b04c-05835649fb4a)


## 2. Color Mechanics

The color mechanics are a central part of OverChrome, so it made sense for it to be one of the first things to be implemented. I actually implemented them before the Player Controls because I was so excited about the concept. Everything went as planned and it was a lot of fun.

I made it so that the functions related to Colors would reside in a separate script, not belonging to any Game Object - the script is called Colorz not to clash with any previously-existing classes. This script has static functions that can be used by any script in the project.

Since OverChrome works mostly with saturated colors, a lot of my support functions play with this.

For example, there is a function GetColor that, instead of taking float values for R, G and B, takes booleans. So if I provide it with G and B, it will give me a Unity Color equal to Cyan (#00FFFF). The hex values are always 00 or FF, that's the idea. This is extremely useful when generating enemies, because they can only be of a saturated color.

Another useful function is to get the opposite color when given the same RGB booleans. This is good for determining what will be the right color to shoot an enemy with. (For example, a R enemy can only be damaged GB (cyan), so this GetOppositeColor() function, when provided with R, will return GB.)

## 3. Enemy Health

Enemy health was a very interesting concept to implement. Our goal is to make the enemy entirely white, since the game works with additive colors. So, in a way, we must shoot him with the colors that they're "short of".

When spawning an enemy, there are two things that we need to provide:
- What are his initial colors? It is possible to choose any combination of R, G and B, except for all of these colors together at the same time.
- What is his total health?

Provided with these initial parameters, here's what happens in the Enemy Health script:

- The script calculates what color corresponds to the combination of RGB provided, and assigns that color to the material of the Sprite Renderer.
- The script calculates what is the "opposite" color of this enemy. (fx a GB enemy will have the opposite color R). This opposite color will be the only color that can deal damage to this enemy.
- The script has a "GetHit()" function, taking a damage value and a color value.
  - The GetHit() function will be called by the bullets when colliding with the enemy.
  - If the color of the hit is the same as the enemy opposite color, the hit takes effect.
  - If the hit takes effect, the damage value will be subtracted from the enemy's health.
  - When an enemy takes damage:
    - The color of his sprite will become brighter (closer to white). The closer the health is to zero, the brighter the color.
    - His health bar becomes shorter, representing the damage taken.
    - The script checks for a death. If health is smaller or equal to zero, the enemy is dead and the Game Object is destroyed.
   
The enemies currently have no sprite, they are a mere circle. They also have a health bar over their head, displaying their remaining health. The health bar is the same color as their initial color, no matter how much damage they have taken. This way, no matter how bright the enemy is at the moment, the player can always know what was his initial color.

## 4. Shooting Mechanics

The shooting mechanic was a lot of fun to implement due to the "colorful" nature of my game. I had to set up three new Buttons in the Input Manager - "FireR", "FireG", and "FireB". (To fire Red, Green, and Blue). Since we are supposed to be able to combine these colors, the Player Shooter script has three boolean variables to keep track of what colors are being shot at the moment. These variables are updated in the Update() function. Then, if the Player is pressing any of them, the Shooting script attempts to fire - but not so fast! I also implemented a "max fire rate" system, with a variable in the editor, that utilizes a timer to limit how many bullets a player can fire per second. If I get to implement Weapons, it will be interesting to mess with these values.

The Bullet Prefab is also extremely important for the Shooting Mechanics.

The control of the instantiated Bullets occurs mostly in the Player Shooter script - it is this script that defines how much damage each bullet will deal, what color they will be, and what direction they will take. This makes sense because all these variables depend on the player (what weapon he is wielding, what colors he is shooting, and what direction he is facing).

However, the Bullet itself manages a couple of things:
- Maintains/persists all of these values provided by the Shooter Script
- Destroys itself when going outside of the screen bounds
- Triggers a Damage (*GetHit()*) function when colliding with a Game Object with a ColorHealth component (a.k.a. an Enemy), including providing it with the color of the hit and the damage dealt (as explained in the 3. Enemy Health section.)

