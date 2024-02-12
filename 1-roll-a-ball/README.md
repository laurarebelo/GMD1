# 1st Assignment: Roll-a-ball

Going through the Unity Roll-a-Ball tutorial was a lot of fun. It taught me a lot of the basics of the Unity Editor & Scripting, and made me realize just how endless the possibilities are when developing games with Unity. The tutorial felt a little bit slow and made me want to skip the videos and just focus on the text instructions, but seeing as I am a beginner and the videos had more detailed comments, I decided to stick to following them, which I felt was a good idea.

I was impressed with how you can create a public variable in the Script and then "Drag and drop" the GameObject you wanted to reference in your script. I was also impressed by the built-in physics system, and how easy it was to make a simple rolling game. It made me realize how insanely simple are the shitty phone games that are advertised on Instagram... Some of them might have been programmed in a day or two, right?! We just made Roll-a-Ball in two hours...

I will not detail the steps I took during the tutorial - I just followed it from start to finish.

After following the tutorial, since we were prompted to elaborate on the game, I developed another level. Instead of it being just a square like the first one, I made it L shaped with the Pickups displayed in a way that would require the player to move "up and down" in the board. It's not super exciting, but it's a new level! To make different levels, I had to do some scripting. Below is a list of what I had to do:

- Duplicate and edit GameObjects so as to make the new level layout in a new Scene. This was challenging because the Editor navigation isn't super intuitive for me, coming from Blender which has great navigation rip :')
- Defining, with a switch statement in the PlayerController, how many pickups exist per level.
- Manage what level the Player is currently on, so as to show the Winning screen at the right number of Pickups. I did this by adding a new public variable in the PlayerController called "currentLevel", which I could then edit in each scene so as to duplicate as little code as possible.
- Manage whether the current level was completed or not, so as to prompt the player for a Key Press to move on to the next level.
- Listen for a Keyboard Input after the current level was completed, so as to load the next Scene.
- In order to load the next Scene, keep a switch statement that defines, on Start, what is the "corresponding string" for the name of the next Scene, so it can be passed to the LoadScene method.

This learning experience was satisfying and exciting. I look forward to developing my own game ideas instead of just following a tutorial, facing new challenges, and yeah, overall just learning by getting my hands dirty :D

Below are a couple screenshots from the playable environment and of the new level layout. It's pretty dull, but cooler stuff will follow.

<img width="513" alt="Screenshot 2024-02-11 at 14 58 42" src="https://github.com/laurarebelo/GMD1/assets/91252082/9db17a05-573f-4684-81be-5192ed5b7bdb">
<img width="824" alt="Screenshot 2024-02-12 at 12 03 56" src="https://github.com/laurarebelo/GMD1/assets/91252082/a2a75872-e77f-4630-8e70-dbd9b7742cc6">
<img width="713" alt="Screenshot 2024-02-12 at 12 04 20" src="https://github.com/laurarebelo/GMD1/assets/91252082/c5f087ea-a323-4dc3-a7e0-e59ba17e6dab">


