
### Game Design Document

# OVERTONE

## High Level Concept

**Game title:** OVERTONE  
**Concept statement:** Colored enemies are wreaking havoc in the city, and you’ve got a spray can loaded with only red, green, and blue. Turn them to dust.
**Genres:** Shooter, puzzle
**Target Audience:** Anyone who likes killing in games & color theory :)
**Unique Selling Points:** This game aims to make the most out of the input options given by the Arcade Machine at VIA. The buttons with RGB colors are the selling point – the player will be able to mix & match Red, Green and Blue to kill enemies that come in different colors. The objective will be to turn the enemies black – for example, if an enemy is Cyan (G+B), the player should shoot Red to kill them. The fun part will be the increasing difficulty – as enemies come in different colors, the player should quickly change to the right color in order to match & kill all of them.

## Product Design

**Game POV:** The game will likely be 2D with the camera looking down at the player. He will be able to move up & down (X and Z axis).
**Player Experience:** The game will have a set number of levels for the player to complete. As the levels go up, the difficulty increases (e.g., more enemies, different types of enemies, different colors). It’s possible that there will also be puzzles that the player will have to solve with color theory. The player might acquire new weapon types & power-ups as the game progresses.
**Visual & Audio Style:** Likely, everything pixelated. 8-bit sounds.
**Game World Fiction:** The player is a graffiti artist with a special spray can that works with additive colors (so when he sprays fx R and G together, it makes yellow). The mayors of the cities don’t like his work and often get it painted over, but that doesn’t stop him. One day, he is graffitiing, and a girl comes to him saying that her village was plagued by colorful monsters and only he can help exterminate them. The girl is pretty, and the player is bored, so he says yes. Exterminating the monsters in the village is the tutorial. After the tutorial, the player sees a monster coming out of the sewer and finds out that they are coming from the sewer. There are then many levels inside the sewers, kind of going deeper & deeper, and the monsters become more intricate & crazier. Every now and then, there is a staircase out of the sewer where the player must go into different cities/villages to kill monsters that got out of the sewer there as well. At the end of the game, there is a super crazy boss that’s been spawning the creatures. After killing the boss, all of the mayors in all the affected cities are grateful for the player and he is no longer seen as an outcast but as a hero, and his graffiti artwork is praised :). The girl is also really grateful and makes a small drawing for him to show her gratitude. Happy ending!!
**Monetization:** If this game was on Steam, I would charge like 10 EUR for it.
**Platform(s):** Designed especially for the VIA Arcade Machine :) But could also work on PC with an XBOX controller since the XYAB buttons have the needed colors ;)

## Detailed & Game Systems Design
**Core Loops:** At the beginning of each level or level phase, enemies are spawned. A level is completed when all enemies are killed.
**Objectives & Progression:** The objective is to save all locations that have been plagued with monsters. Each location saved rewards the player with a new weapon or power-up. Another “intrinsic” goal is to clear the player’s reputation – his heroic work will make his graffiti art become valued & treasured by the population :).
Game Systems: Enemy spawning, shooting with color mix & match (e.g. shooting R and B together outputs Magenta, which should be used to eliminate Green enemies), health, reload & ammo, power-ups, levels.
**Interactivity:** The player’s main interaction with the game will be to move with the joystick and shoot with the colored buttons. Dialogue options with certain NPCs will also likely be a part of it for lore progression & reward acquisition.

