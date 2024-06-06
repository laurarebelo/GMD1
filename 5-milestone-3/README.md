For my third milestone, I have implemented the following systems:

- New Character - Maggie
- Dialogue System (incl. new sprites)
- Cutscenes
- Tutorial (Dynamic Slime Spawning)
- Levels
- Sound
- Pause Menu
- Compile for Windows
- Arcade Machine Input Mapping...

Let's go through them one by one.

## NEW CHARACTER - MAGGIE

I mentioned, I believe, in the Game Design Document, that the lore of OverChrome would consist of a guy (the player) who was doing grafitti and is interrupted by a girl who asks him for help to slay the monsters that are plaguing her city.

I was really committed to bringing this to life so I designed and drew the sprites for her - her name is Maggie, which is short for Magenta! And her outfit is entirely magenta colored... Isn't that adorable!

<img width="516" alt="maggie-show" src="https://github.com/laurarebelo/GMD1/assets/91252082/02bd600a-c873-412b-8628-792fc1e8daf6">

## DIALOGUE SYSTEM

I was really excited about making a dialogue system for the longest time since I wanted to have a storytelling component to the game.

I had to make my dialogue dynamic so that I could quickly put new dialogue information in a file and have the game read it "dynamically" - which would greatly speed up the development of new dialogue scenes. For this, I have a class called DialogueTrigger that can read a .json file in a certain format and trigger a dialogue, and a main class called DialogueManager that can handle said dialogue.

The dialogue progresses as the player presses any button in the input system. For each line, the UI is updated with a "headshot sprite" of who is speaking, their name, and what they are saying.

An ongoing dialogue blocks the player from moving and also impedes any input that could trigger a pause menu - it is just dialogue happening, nothing more.

As for animations, the dialogue pans in and out of the screen when starting and finishing. Moreover, each line of dialogue is "typed out", as opposed to appearing in one frame, which makes for a nice effect and user experience.

![dialogue-maggie](https://github.com/laurarebelo/GMD1/assets/91252082/4d0016a9-1713-478b-acef-e2d61b8d5b92)

Below is an example of just how simple it is to define a Dialogue in a file!
<img width="600" alt="Screenshot 2024-06-06 at 18 56 30" src="https://github.com/laurarebelo/GMD1/assets/91252082/0568b817-bd41-4a45-823c-03334978b90f">

It is also possible to add an "ending scene" to the end of a dialogue. The type of object is a Timeline! If a timeline was provided to the DialogueManager, then after the very last line of the dialogue, this timeline will play. For my case in particular, this was good for cutscenes and for finishing a level (I would put a black fade out between levels and make their transition more seamless :)).

Speaking of cutscenes and timelines, let's get into them.

## CUTSCENES

Given my determination to have a cutscene, I had to learn how to work with the Timeline feature of Unity. I had heard that it was hard to work with, but in the end, I did not think it was that bad. It was easy for me to make sense of them. So I basically keyframed the position, sprites & opacity of everything I wanted in order to achieve the effect I envisioned!

I have one cutscene at the beginning of the game, where the Player meets Maggie and is prompted to go kill some monsters, and I have one at the end of the game where Maggie thanks the Player for him having killed all the monsters (duh), and they kind of go on a date - which we don't see. The absolute last screen of the game is a thanks for playing it.

![cutscene-1](https://github.com/laurarebelo/GMD1/assets/91252082/53d18c1b-d931-43a2-b52e-c18effe7e086)
![cutscene-2](https://github.com/laurarebelo/GMD1/assets/91252082/aee06f01-1519-4041-8783-ac5e1e691cf0)
![cutscene-3](https://github.com/laurarebelo/GMD1/assets/91252082/4a81ff5b-ca1b-433c-9fed-e969eeafbe02)
![cutscene-4](https://github.com/laurarebelo/GMD1/assets/91252082/f99bd447-a2cb-43e0-9128-d5067f858bfc)

Actually, making the cutscenes, particularly the first one, also included designing the background/scenario for it with a tilemap! I used two tilemaps in my game - one for City and one for Sewer. They were both 16-bit and luckily for me they looked pretty nice together!

Speaking of 16-bit - for some reason, when I worked with the Main Menu, I remember struggling so much to import a font into Unity, but this time, when doing it for the dialogue system, it was far easier and the text looked really nice and sharp! So I am glad I learned a new way.

I also want to mention that, while working with Timelines, I learned about Signals which I found very interesting. I needed them to, for example, block the player at some point in the timeline or trigger a dialogue from the timeline. I learned loads of new things when making cutscenes!

## TUTORIAL (DYNAMICALLY SLIME SPAWNING)

It is nearly seamless to transition from the first cutscene to the tutorial of the game. Making the tutorial was very challenging for me because it had a lot of "pre-programmed" things, such as a lot of explanatory dialogue and dynamic spawning of monsters. I had to keep track of how many monsters had been killed at any given moment so that I knew when to trigger the next dialogue! This included making a new class (KillCount) and calling methods between components to make sure that the game kept flowing.

![slime-spawn](https://github.com/laurarebelo/GMD1/assets/91252082/18528b00-06f7-46fd-988b-a28890b4a4e5)
<img width="805" alt="Screenshot 2024-06-06 at 18 42 53" src="https://github.com/laurarebelo/GMD1/assets/91252082/a94bfbd5-91a6-461e-a44b-a09aabf85a88">


## LEVELS

Speaking of KillCount, only now on the third milestone did I implement actual levels for the game! The thing about a level is that it starts and it ends. In Overchrome, a level ends when you have killed all the slimes, so - you guessed it - I had to keep track of the kill count once more.

KillCount is actually multi-purpose because it can both be used for spawning more monsters when you have reached a certain kill count, or simply to finish the level once you have killed all the monsters that existed in that level. The latter happens dynamically so I did not need to change any parameters if I added more slimes - the KillCount component immediatelly picked up on them :). I thought that was pretty cool.

Making levels was extremely smooth with all of these systems I had in place - the tilemap designing, the enemy Prefabs, the dynamic kill counter, the extendable dialogue system... Chef's kiss. It went very very smoothly. I thought three levels was enough for the game to be playable and have progression, but of course, if I had more time I would have done some more, with different enemy types and such. But I am satisfied with what I have put out :).

Below is an example of one of the quickest level - notice how the dialogue is triggered immediately after the last monster is killed, and it transitions out into another scene.

![level](https://github.com/laurarebelo/GMD1/assets/91252082/0d1404d2-4acf-488e-bd0e-9c18e3d0c5b2)


## SOUND

Oh man... How silly of me to leave sound for the last day of development lol!!! I am fortunate that it also wasn't too much trouble! I got a bunch of audio assets online and put them wherever I saw fit (so, in the cutscenes, when we walk, when we catch a pickup, when we jump, when we get hit, and background music!) Deep down, all it took was a bunch of AudioSource components and knowing where to place Play() and Stop() in the scripts ahahah. And I also added audio to the dialogue which introduced such a cool effect!!! :)))

![audiosc](https://github.com/laurarebelo/GMD1/assets/91252082/5f9df517-f932-43a4-ab86-6ef9bb287bb5)

## PAUSE MENU

Implementing the pause menu was very satisfying! I learned how to stop time in my scene. I mostly followed a tutorial for it but it was still a learning experience for me. I had a challenge with the navigation of the buttons but in the end I figured it out and pulled it off - I had to set the default-selected button and manually map the navigation between them since the automatic setup Unity had done was totally broken. I also made a Controls section that shows you everything you can do with the colored buttons of the arcade machine, which I thought was super cool! From the pause menu, you can resume your game, see the controls or quit the game. I made a prefab out of the Pause menu and added it to all the relevant scenes. This made it a lot quicker to implement across all levels.

<img width="709" alt="Pause Menu" src="https://github.com/laurarebelo/GMD1/assets/91252082/2d2b7a37-b993-4738-8fe5-a59b457f719b">
<img width="704" alt="Options Menu" src="https://github.com/laurarebelo/GMD1/assets/91252082/89e77ddc-a411-4c3d-8df4-7d43722ade1a">

## COMPILE FOR WINDOWS

I was dreading compiling my game for Windows because I have a Mac machine and the windows build didn't appear in my default configurations!!! But guess what... All it took was to install a new module in my Unity version, and the option appeared. And it worked just fine! :)

## ARCADE MACHINE INPUT MAPPING...

Mapping my inputs to the arcade machine was both easy and hard! The simple buttons, I had mapped them correctly from the beginning (so, the joystick and the colored buttons were all okay). But the black and white ones... I just couldn't get them to work. For some reason, I stuck with the old input system from the beginning of the development of my game (I guess just because it's what I was used to!) and I just couldn't make it so that the 9th and 10th axis (white and black buttons) would behave how I wanted them to on the arcade machine.

So in the end, I had to make do with what I had - a joystick and four buttons. I pulled it off, though! The Red, Green and Blue are all used for shooting in different combinations and the yellow button is used for menu interactions. The final user experience is pretty nice and I am happy with how the input turned out on the arcade machine despite the limitations! :)
