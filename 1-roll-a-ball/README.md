# 1st Assignment: Roll-a-ball

Going through the Unity Roll-a-Ball tutorial was a lot of fun. It taught me a lot of the basics of the Unity Editor & Scripting, and made me realize just how endless the possibilities are when developing games with Unity. The tutorial felt a little bit slow and made me want to skip the videos and just focus on the text instructions, but seeing as I am a beginner and the videos had more detailed comments, I decided to stick to following them, which I felt was a good idea.

I was impressed with how you can create a public variable in the Script and then "Drag and drop" the GameObject you wanted to reference in your script. I was also impressed by the built-in physics system, and how easy it was to make a simple rolling game. It made me realize how insanely simple are the shitty phone games that are advertised on Instagram... Some of them might have been programmed in a day or two, right?! We just made Roll-a-Ball in two hours...

Anyway, here's the technical description of how I implemented Roll-a-Ball, although all I did was follow the tutorial:

- I set up the playing area with a simple primitive plane
- I set up the Player GameObject with a simple sphere
- I added a Rigidbody to the Player so that it would have Physics
- I learned about Materials and added a shiny material to the Player
- I added PlayerInput with the help of a built-in input system in Unity, and scripted the Player movement according to the Tutorial instructions
- I made the Camera follow the Player through a script that keeps a fixed distance between the Player and the Camera, disregarding the Player's rotation
- I learned about Prefabs and made my Collectibles Prefabs so that I could "bulk edit" them. I made them rotate and be yellow to be more eye-catching.
- I removed the physics and gravity from my Collectibles so that they would consume less resources.
- I scripted the collision between the Player and the Collectibles so that it wouldn't affect the Player's movement and the collectibles would disappear upon colliding with the player.
- I learned a little bit about UI and added a Counter to display how many Collectibles were picked up.
- I scripted the increment of the counter with each collected Collectible.
- I added a Winning Screen (a simple text overlay) when the Player has collected all Collectibles.

This learning experience was satisfying and exciting. I look forward to developing my own game ideas instead of just following a tutorial, facing new challenges, and yeah, overall just learning by getting my hands dirty :D

Below is a screenshot of what my Roll-a-Ball's first version looks like. It's pretty dull, but cooler stuff will follow.
<img width="513" alt="Screenshot 2024-02-11 at 14 58 42" src="https://github.com/laurarebelo/GMD1/assets/91252082/9db17a05-573f-4684-81be-5192ed5b7bdb">
