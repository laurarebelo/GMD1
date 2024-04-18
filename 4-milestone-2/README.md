Welcome to the second blog post about OverChrome!!!!

(I am just gonna push this markdown file now without gifs because I need to get to bed, but I will add some visual examples tomorrow.)

I have done a lot since the last milestone.
The game actually looks unique now!!
And it's playable to a pretty decent degree!

What follows is a list of the new systems that have been implemented:

# Achievements Summary
### PLAYER HEALTH:  
- Player Health System

### ENEMY BEHAVIOUR
- Slimes now move from side to side on their own
- Slimes now damage Player on Contact

### PLAYER PAINT LEVELS:  
(in other words, the "color ammo")
- Player has limited paint for R, G and B.

### UI
- Main Menu
    - Buttons: Play, Options (empty), Quit
    - Infinitely moving background image
    - Easter Egg included... :)
- Player Health UI
- Player Paint Levels UI

### PICK-UPS
- Health Pick-Up
- Paint Pick-Up
- Pick-Up Off-Screen Respawn Functionality

### SPRITES:  
- Player Sprites
    - MADE FROM SCRATCH!
    - Includes animations for:
        - Jumping
        - Shooting
        - Walking
        - Jumping + Shooting
        - Walking + Shooting

- Slime Sprites
    - MADE FROM SCRATCH:
        - Includes animation for:
            - Moving

- Pickup Sprites
    - MADE FROM SCRATCH:
        - Health Sprite (Heart)
        - Paint Sprite (Spray Can)

- Tilemap for Background & Levels
    - CREDITS: Alb_pixel Store
    - LINK: https://alb-pixel-store.itch.io/robotype-sewer

I will now write a few words about each.

# Achievements Description

## PLAYER HEALTH SYSTEM

What you'd expect!

Uses new "Health" Component.

Has a max value and a current value.  

Can take damage or heal. (These functions are public, can be triggered externally.)

When taking damage, the player flashes in the same color as the enemy that hit him.

The Player will be tinted in the damage color for as long as he is temporarily immune to damage (currently 1 second).

## ENEMY BEHAVIOUR
### Slimes Idle Movement

The slimes are now more lively - they move from side to side!

Uses new "Wandering" component.

You can give it a Max Range and a Movement Speed.

They flip their sprite depending on the direction they're moving.

They also wait a couple of seconds before starting to move again after they've "flipped". This was my first experience with **coroutines** so that was interesting - they're not as complicated as I thought!

Below, you can see what their behaviour looks like ingame currently.

![ezgif-4-757127d807](https://github.com/laurarebelo/GMD1/assets/91252082/ad82d1e0-11cf-42aa-9764-4d7f9eb09ae4)


### Slimes Damage Player

The slimes can now deal damage to the Player.

This happens on collision, of course.

Uses new "DamageDealer" component.

This component is responsible for checking for collisions and, if it collides with a Game Object with the "Health" component, it will use that and call its "TakeDamage" function.

The fun part is that, to that function, it not only passes the value of damage, but also the **color of damage**.

This is used to make the Player flash in the same color as the enemy that damaged him.

You can see a Slime dealing damage to the Player.

![gif-damage](https://github.com/laurarebelo/GMD1/assets/91252082/a0a4f2fa-1d0c-4cc6-808a-74824acd7fde)

In retrospective, maybe there is not enough feedback to sinalize when the Player takes Damage. This could be refined by adding a recoil, audio and better sprite design. Soon!


## PLAYER PAINT LEVELS

The Player used to be able to indiscriminately shoot.

I figured the game would be more interesting and challenging if there was a limit to how much you can shoot. Otherwise, one could just spam all the time and be unphased by all enemies.

By having "paint levels", the player is forced to take a step back and "ration" his paint depending on the enemies he finds.

The Paint Levels were integrated into the "PlayerShooter" component. This component has grown quite large so I am thinking of splitting it soon (fx. separating the Input Management from the Paint Level State Management).

The component keeps track of the level of Red, Green and Blue the player has left. The initial value is 100. If a player is shooting, the value goes down at a certain rate that can be assigned in the inspector.

If the player is shooting a color he does not have, he is unable to shoot.
(fx: if you're out of Red and you try to fire Magenta (R+B), you will only fire Blue.)

Below is a gif of the Player spending all of his Blue paint.

![gif-paint-lvls](https://github.com/laurarebelo/GMD1/assets/91252082/fdc6ccf4-39ac-4013-bac5-0fb900e8da80)


## UI
### Main Menu
I am very happy with the UI I have integrated into the game so far, particularly the Main Menu. The three buttons have different sprites for when they're normal, selected or pressed.

I must say, though, that the customization options for Text in Unity seemed very limited, so much that I found them to be unusable. In the end, I had to do the Sprites in an image editor and import them into Unity.

The sprites for the title of the game, OverChrome, are split into the Outline and the Fill. Can you guess why? There is an Easter Egg in the Main Menu that makes use of this split.

It was also interesting to find out how to make an infinitely moving background image.

I learned a lot about the UI elements while making this menu.

Below is a GIF showing the current state of the Main Menu :).

![gif-main-menu](https://github.com/laurarebelo/GMD1/assets/91252082/94c2c9d6-78c8-44ac-9d60-1f0968da5abc)


### Player Health UI
- Type: Horizontal Bar with Fill
- Location: Top Left Corner
- Referenced Component: Player's "Health"
    - Used parameters:
        - Max Health
        - Current Health
    - What for?
        - To determine how filled the bar is

I also made myself a little heart icon to put next to it.

![gif-health-bar](https://github.com/laurarebelo/GMD1/assets/91252082/6042fae5-9538-480e-94f0-191b351be65f)


### Player Paint Levels UI
- Type: 3 Horizontal Bars with Fill
- Location: Top Right Corner
- Referenced Component: Player's "PlayerShooter"
    - Used parameters:
        - Rfuel
        - Gfuel
        - Bfuel
    - What for?
        - To determine how filled each bar is

I also made "labels" saying R, G, and B to put next to each bar.

![gif-paint-lvls](https://github.com/laurarebelo/GMD1/assets/91252082/a6ce02f8-5052-4dfc-b946-114aad356dbf)


## PICK-UPS
### Health, Paint
I made, at the same time, pick-ups for the Health and for the Paint Levels.
They were extremely similar.

The Health Pick-Up checks for collisions with a GameObject with a "Health" Component and, if it finds it, calls its "Heal" function with the specified value (default: 1HP). If the Health is filled, does nothing.

The Paint Pick-Up checks for collisions with a GameObject with a "PlayerShooter" component, which is keeping track of the Player's Paint Levels. A Paint Pick-Up can be of any combination of colors except for Black (which contains no colors). Whatever colors are included will be totally filled for the Player, if he is lacking any of those included in the Pick-Up. (This means that a White Paint Pickup would restore all of the Player's Paint Levels.)

Initially, both Pick-Ups were destroyed forever when they were first consumed. However, this seemed unsustainable, given the possibility of the Player running out of Paint and potentially being unable to finish a level.

For this, I implemented a functionality to respawn a Pick-Up if it goes off screen. I copied a lot of code from the Bullet Script, which Destroyed the Bullet object if it went off screen.

For the Pick-Ups to be able to Respawn off screen, they could not be Destroyed nor Deactivated. That only left hiding them while keeping them Active - but how?

The answer was disabling the Sprite Renderer components. However, this was trickier than I expected because the Paint Pick-Up had more than one Sprite (due to the necessity of dynamically setting its inner color but not its outline). I felt blocked... how could I reference all its SpriteRenderers in an extendable way? But I soon learned that you can also have Lists as Serializable Fields for a Script, and that solved my issue, because then I could easily pass both of them - even more, if I had any, or just one.

Below is a gif of a Player that jumps into the middle of two slimes, takes 2 damage, spends all his Blue Paint, **picks up a Blue Paint Pick-Up**, and then **picks up a Health Pick-Up**, healing 1 damage.

![gif-pickups](https://github.com/laurarebelo/GMD1/assets/91252082/906d2fab-56f8-4257-acfc-90e84a28a505)


## SPRITES

### Drawing them myself!  
As I mentioned before, I handmade sprites for my Player, my Slimes and my Pick-Ups.
Making my own sprites was super satisfying. I've always had a fascination for pixel art so this was a great reintroduction to it. To make my own sprites, I bought Aseprite on Steam. This program is really nice and is packed with useful features - for example, the possibility of exporting an animation as a spritesheet directly.

### Animating them in Unity  
In order to get my sprites moving in-game, I had to face the Unity Animator. It was not as bad as I thought, although it took me a second to get the hang of importing my images and slicing them correctly. I like the Animation State Machine.

Switching between Animator states crowded my scripts a little bit though, so I would like to research a way to do it more cleanly in the future, if it's possible.
