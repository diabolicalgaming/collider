# Blog: Collider

**Ore Ibikunle**

## Blog 1 | Introduction (October)

Collider is a 2D space shooter where a player will have to manoeuvre a spaceship through space and
aim to avoid obstacles. These obstacles will be asteroids. There will be two types of asteroids, a 
larger one and a smaller one. When the large asteroid collides with the smaller asteroid, the trajectory of
the small asteroid changes, which makes it harder for the player to avoid obstacles. The player can shoot down
the smaller asteroids but not the larger ones. The game will become more difficult as the player progresses, with the
speed of the asteroids increasing.

This blog will be used to show the the progress of my project, highlight the changes that I made
and the ideas that I added to the game.

## Blog 2 | Break to Focus on Continuous Assessment

It is important to balance the amount of time spent on my final year projrect and other modules. I decided to take a break
to focus on the other modules.

## Blog 3 | Functional Specification (November)

My project has now been approved by the approval panel, so I can begin to work on my Functional Specification

![beginning](https://gitlab.computing.dcu.ie/ibikuno2/2019-ca400-XXXX/raw/master/docs/blog/images/functional-spec-start.jpg)

To begin I worked on the Introduction and General Descriptions of the document. For the glossary I had to research some
common terms used in game development and physics and their definitions. I also had to research some of the terms that I
would use when writing the document.

Here is my System Architecture. This is how I plan to design the system.

![system-architecture](https://gitlab.computing.dcu.ie/ibikuno2/2019-ca400-XXXX/raw/master/docs/blog/images/component-diagram.png)

## Blog 4 | Beginning (December)

Change in plans - rather than implement my project in Eclipse with Java, I opted to go with Unity and C#, for 2 reasons:

1. I wanted the GUI for the game to be well designed and it is better to do that in Unity.
2. I wanted the game to have animations and sprites. Doing this in Unity saves a lot of time so that I can focus on the more important things in the project.

![system-architecture](https://gitlab.computing.dcu.ie/ibikuno2/2019-ca400-XXXX/raw/master/docs/blog/images/beginning.png)

When you start a new project in Unity, you are given a sample scene with just a Camera.

## Blog 5 | Monobehaviour Explained

* Monobehaviour is the base class from which every other class derives. When you use C#, you must explicitly derive from Monobehaviour.
When you create a class in Unity, this is what it will always look like:

![system-architecture](https://gitlab.computing.dcu.ie/ibikuno2/2019-ca400-XXXX/raw/master/docs/blog/images/awake-start-update.png)

There is a third function called _Awake_, which is used to act as a constructor.

* _Awake_ is called when an instance of the code is being loaded and is only called once during the lifetime of the class instance.In Object-Oriented Programming design we usually use Constructors to 
initialize fields of our class. But, in Unity whenever I implement the MonoBehaviour class I will use Awake to initialize the fields of the class because the serialized state of the component is 
undefined at construction time.

* _Start_ is called on the frame when a class is enabled just before any of the Update function are called the first time. This function is usually used to initialise variables and is only ever called once.

* _Update_ is called every frame if the MonoBehaviour is enabled. Update is the most commonly used function to implement any kind of game code. Not every MonoBehaviour class to have _Update_.

To begin I have created a Menu class, which will have two functions:

1. _ClickPlay()_ - this function is attached to the "Play" button. When the player clicks this button, the game begins
2. _ClickExit()_ - this function is attached to the "Exit" button. When the player clicks this button, the application closed.

At this point this is what the Menu looks like:

![first-menu](https://gitlab.computing.dcu.ie/ibikuno2/2019-ca400-XXXX/raw/master/docs/blog/images/first-menu-photo.png)

## Blog 6 | Implementing Player Movement and Player Missiles (January):

Before deciding what the controls for the game would be, I researched what the most common keyboard/mouse inputs for PC games were.
The design of my controls will be based on Fitts's Law.

![finger-groups](https://gitlab.computing.dcu.ie/ibikuno2/2019-ca400-XXXX/raw/master/docs/blog/images/finger-groups.png)

![common-inputs](https://gitlab.computing.dcu.ie/ibikuno2/2019-ca400-XXXX/raw/master/docs/blog/images/common-keyboard-mouse-inputs.png)

* Fitt's law - is a predictive model of human movement primarly used in human-computer interaction and ergonomics.
To keep it short and simple, the fewer the distance to the button and the bigger the button, the more accessible the button is.

These will be the controls:

* WASD or Arrow Keys to move the player.
* Space to fire missiles.
* Escape to pause (most commonly used in games as the pause button, the images above only represent what buttons players use to play the game).

I added the option of allowing the arrow keys to move the player to give players that are primarily right-handed an option and because people who don't commonly play games and are right-handed
may not be used to using their left hand for the WASD keys.

At this moment I have created a class called _Playership_. This class is responsible for allowing the player to move around the screen. It also enforces boundaries, so that the player cannot move the spaceship out
of the screen as shown below:

![playership-out-of-camera-view](https://gitlab.computing.dcu.ie/ibikuno2/2019-ca400-XXXX/raw/master/docs/blog/images/playership-out-of-camera-view.png)

### GameObjects and Prefabs Explained:

GameObjects are the fundamental objects in Unity that represent characters, props and scenery. They do not accomplish anything themselves 
but they act as containers for Components, which implement the real functionality.

* Components - are the classes that **you create** and are attached to game objects in Unity to add functionality.

To create the missiles I used Prefabs.

* Prefab - is a game object that you create in the scene and store in the project. Prefabs can be instantiated or cloned to create an instance of them during the game. They are a key part of development in Unity.

Instantiated - this means that they can be created at any parituclar point in the game using:

```csharp
	Instantiate(prefab);
```

I created a class called _PlayershipMissile_ which will be responsible for moving missiles up the screen. It will be attached to the players missile prefab.

What happens in games is that unused objects tend to cause memeny leaks. When the missile leaves the screen of the game, it will still be used
by memory. This obviously isn't efficient since this game is an "endless runner".

![memory-leaks](https://gitlab.computing.dcu.ie/ibikuno2/2019-ca400-XXXX/raw/master/docs/blog/images/memory-leaks.png)

I created a function in _PlayershipMissile_ that destroys the missiles when they leave the screen.

## Blog 7 | Adding a Moving Background, Planets, and Stars:

For this game, I feel like it would be important that the background moves, so that the player feels as if they are really travelling through space when they are playing the game.
This adds to the user experience. This functionality is added in my _BackgroundScroller_ class. I will also be adding Planets and Stars to make the GUI look nicer.

Before I explain how I added the planets and stars, here is a view of the camera. The x and y axis are normalized,
meaning that both x and y have a maximum length of 1 as shown below.

![camera-points-explained](https://gitlab.computing.dcu.ie/ibikuno2/2019-ca400-XXXX/raw/master/docs/blog/images/camera-coordinates.png)

I will be adding stars and planets to the background of the game using prefabs as discussed earlier.

To begin, I have created a class call _SpawnPoints_ , which will be attached to each planet and the star prefab.
This component will be used to to control the points at which they spawn.

![spawn-points](https://gitlab.computing.dcu.ie/ibikuno2/2019-ca400-XXXX/raw/master/docs/blog/images/spawn-points.png)

These values are not hard coded. When the stars and planets move out of the screen, they will be placed back at a random point between the screen, with x1 and y1
representing the bottom left corner of the screen at position (0,0) and x2 and y2 representing the top right corner at position (1,1). Meaning that the point at which they
are placed after moving out of the screen will always be at a point that is between the screen coordinates.

This script is very important because it allows me to take the size of the sprites into account. It is attached to each game object, and obviously the some objects
have large sprites than others. Scaling the sprites smaller ruins their quality (As I said I want the GUI to be physically appealing to the eye).
For example, sprites that are very large, will need to have higher **x1** and **x2** values, meaning that they will be spawned closer to the centre of the screen.

For the stars, I have created a class called _Stars_, which will be responsible for moving the stars down the screen. 
This also will be added to the Star prefab.  In space there are over 100 billion stars, so in order to make the player feel 
as if they are travelling through space, so I will need to create multiple instances of the star prefab. This is done by my
_CreateStar_ function in my _StarCreator_ class. This function will create multiple instances of the star prefab at random positions
on the screen between the values set by their _SpawnPoints_ component. Each created instance of the star prefab will move at random speed, so that the stars don't
clump up together.

![creatstar-function](https://gitlab.computing.dcu.ie/ibikuno2/2019-ca400-XXXX/raw/master/docs/blog/images/createstar-function.png)

For Adding background objects. I created a component (class) called _BackgroundObject_ that will move the object on the screen.
As well as the _SpawnPoints_ component, each planet will have the _BackgroundObject_ component attached to it.

For the planets in the background I will be implementing a pooling system (_BackgroundObjectPooler_ class).

* Object Pooling - is when you reuse objects that have already been instantiated before gameplay, rather than allocating and destroying them on demand.

As you can see in the GIF below, then the large planet moves out of the screen, it is added back to queue so that it can be used again and then the next planet in the queue will start to move. 
You can add as many planets to the queue as you want. Just to speed things up, for now I have added 4. 

![planets-moving](https://gitlab.computing.dcu.ie/ibikuno2/2019-ca400-XXXX/raw/master/docs/blog/images/moving-planets.gif)

## Blog 8 | Implementing Asteroid and Meteoroid Spawner:

I will be using the names Asteroid and Meteroid to denote larger and smaller asteroids respectively.
Just like the players missiles, both asteroids and meteroids will need to be created  in multiple instances, so I will be creating them as prefabs.
I have added an _Asteroid_ component (class) that will be attached to the Asteroid prefab, and a _Meteroid_ class that will be attached to the Meteoroid prefab.
Since both classes serve different purposes (i.e meteroids can be destroyed and asteroids can't) I will keep them seperatly for now.
Note: that this is obviously not very efficient, I plan to change this later, but it will do for now.
At this point, I have created a class called _MeteoroidSpawner_ which will spawn the asteroid and meteroids at random positions. 
I will be improving this later also, this is just to get things set up.

Current state of the game:

![first-look](https://gitlab.computing.dcu.ie/ibikuno2/2019-ca400-XXXX/raw/master/docs/blog/images/background-objects-added-to-game.gif)

## Blog 9 | Meeting with Charlie:

I had a brief meeting with Charles Daly about possible ways to implement collision to detection and we spoke about possibly adding more enemies to the game.
I tried to think of ways that I could implement my original idea into the game and still make it playable. After some thought I concluded that it wouldn't work
for two reasons:

1. As a person who plays games myself, I want the game to be fun. I felt like the idea of the player moving around trying to avoid asteroids that where colliding with each
other was a bit too basic and that I needed to add more functionality to the game. (i.e. more enemies).
2. Since I am using Unity, I also feel like I can add a lot more complexity to my game.

Charlie and I both came to a consenus that adding more functionality to the game and improving my original idea would make the project more interesting.
While I think of ideas for enemies that I could add to the game, I think the best thing to do is to continue on with other parts of the project.

## Blog 10 | Adding the Game Menu:

At this point I have now added an in-game menu to the game. I want this menu to be simple. When the player pauses the game, there will be two options:

* Resume - to resume the game.
* Menu - to return the the main menu.

Usually in games where the controls are not that simple, there would be an option in the menu (i.e something like a controls option) to remind them of the controls for the game.
Since, I am using keyboard/mouse inputs that are common in PC games, I feel like there is no need for a "controls" option in the in-game menu. There will be an option in the main menu
where the user can view the controls for the game.

Current state of game:

![menu](https://gitlab.computing.dcu.ie/ibikuno2/2019-ca400-XXXX/raw/master/docs/blog/images/game-menu.png)

At the moment the game has no sound, so this is what I plan on adding next.

## Blog 11 | Adding Sound to Game:

To add sound to games, Unity has a component that it already made called an Audio Source.
This component is reponsible for playing an audio clip. It has propoerties such as the:

* Volume - the volume of the audio source.
* Pitch - the pitch of the audio source.
* Spatial Blend - to control whether or not you want the sound to be played in 2D or 3D space.

This Audio Source can be added to each game object and you can make a call to the audio source component that is attached
to that game object. An example of this is below:

![menu](https://gitlab.computing.dcu.ie/ibikuno2/2019-ca400-XXXX/raw/master/docs/blog/images/audio-source.gif)

When it comes to adding sound to my game this would mean that I would have to repeat this process (as shown above) for every game object. 
There could be hundreds of objects in my game, therefore doing it this way would be too time consuming.

There are also sounds that are not tied to game objects, i.e the "game over" voice you hear when you lose the game. This would mean that I would need
to create empty game objects and add the audio source component to each of them and then access the sound through code on that game object, and call AudioSource.Play() when I need to play that sound. 
This method is of course not very efficient. So, I decided to make my own Sound Manager. This is an object within my game that will be responsible for playing sounds.
Any time I want to play a sound at a patricular moment, I will make a reference to that game object. This will save me a lot of time.

To do this, I have created a class called Sound:

![sound-class](https://gitlab.computing.dcu.ie/ibikuno2/2019-ca400-XXXX/raw/master/docs/blog/images/sound.png)

As shown in the class above each Sound object has:

* loop - bool to determine if the sound should be repeated.
* audio - the actual audio clip/sound that it plays.
* audioName - the name of the sound you want to play.
* audioPitch -  the pitch of the sound.
* audioVolume - the volume of the sound.
* blend - the spatial blend of the audio source. Do you want the audio to be in 2D or 3D space? **0** means the audio is in 2D space and **1** means it is in 3D space. 

When you create a custom class, and you want the class to appear in the inspector, it has to be marked by the **[System.Serializable]** attribute.
This will be used in my other class called SoundManager.

The idea of my Sound Manager is to hold a list of _Sounds_ (my Sound class) that I can easily add and remove.
When I want to add a sound, I will just add it to the list of sounds in my SoundManager class which is attached to my SoundManager object in the UI as show below:

![sound-class](https://gitlab.computing.dcu.ie/ibikuno2/2019-ca400-XXXX/raw/master/docs/blog/images/sound-manager.gif)

Here is a close up of how it is being used:

![sound-manager-in-use](https://gitlab.computing.dcu.ie/ibikuno2/2019-ca400-XXXX/raw/master/docs/blog/images/sound-manager-being-used.png)

In my _SoundManager_ class, there will be a set of public functions that I can call outside this class to play or pause specific sounds.
These functions will iterate through all of the sounds in the list and find the sound with the appropriate name.

The functions in this SoundManager are:

* Play - to play the sound.
* PauseBGM - to pause the music in the background when the menu is paused.
* StopBGM - to stop the background music when the player dies.
* PlayOnce - which will be used to play sounds for clicking on buttons or hovering over buttons, etc.

For example, let's say I am in my Playership class, and the player has been hit by an asteroid. Just some sudo code of example:

```csharp
if(player is hit by asteroid)
{
	//Make a reference to my _Play_ function in my SoundManager class and play the sound.
	FindObjectOfType<SoundManager>().Play("PlayerDies");
}
```

I will make make a call to my SoundManager object (this is the class) using _FindObjectOfType<ClassName>()_ and call its _Play_ method.

* _FindObjectOfType_ - returns the object (in this case the class and not the game object) that matches the specified type.

Here you can see that although Unity has its own way to play audio, I have implemented it my own way, which is a lot more efficient.

## Blog 12 | Working on the User Interface: (February)

At this point I have been working on the UI in my Game scene. Since this game is designed for computers with a 1920x1080 resolution (Full HD),
I have chosen a default of 1152 x 864 as the screen size for the game. This screen size works perfectly because since the width of the screen is
narrow it won't take a long time for the player to get from one side of the screen to the other. It also seems to work well for the quality of
the sprites that I have used.

I have also added sound to all the buttons in both the main menu and in game menu. I've added a score counter and health bar which will be used to display
the players health points (no functionality implemented yet at this point).

Current state of the game:

![sound-class](https://gitlab.computing.dcu.ie/ibikuno2/2019-ca400-XXXX/raw/master/docs/blog/images/scores-and-lives.png)

## Blog 13 | Implementing Collision Detection:

I have decided that since I will be adding more enemies to my game, I will be implementing collision detection with the Unity Engine.
I have decided to use the Unity Engine for for two reasons:

1. Performance - the performance of the physics engine in Unity is very effecient.
2. I want to focus more on adding more types of intelligence to my game for my enemies and my enemy spawner. Which may take a lot of time.
So speeding up the process of implementing collision detection would be beneficial to the progress of my project.

In order to implement collision detection, I will need to add a _Tag_ to both the enemy and player objects.

* Tag - is a way of identifying game objects in Unity.

Then to each of the enemies and the player objects I will be adding two components provided by Unity; the BoxCollider2D and the RigidBody2D components.
In order to detect collision I will be using Unity's OnTriggerEnter2D function. An example of this is provided below:

```csharp
private void OnTriggerEnter2D(Collider2D collider)
{
    // Detect collision of player and an enemy.
    if(collider.tag == "EnemyTag")
    {
		//Do something
    }
}
```

## Blog 14 | Getting Started With the Enemies:

Here are some of the current ideas that I have decided to add to my game:

* The player will have 3 lives in total and 100 HP **per life**.
* I will be removing the asteroid and meteroid enemies and adding enemy ships instead.
* I plan to have 4 enemy ships and 1 mother ship. They will fire missiles at the player.
* The enemy ships will display some level of intelligence (haven't thought of it at this point). 
* Direct collision between an enemy ship and player or an enemy missile and a player cause the player to lose health points.
* Collision with an enemy ship cause the player to lose more health points than collision with enemy missiles.
* The mother ship will also display some level of intelligence (not decided at this point also).
* Collision with the mother ship causes more damage to the player than collision with a normal enemy ship. This mother ship will also move faster than normal enemy ships and have faster missiles.
* Enemy ships and the mother ship will also have health points that will decrease when they are attacked by the players missiles.
* Like my original idea, there will still be an online leader board where players can post their scores and view the scores of other players.
* The player will be able to pick up lives while playing to ensure that they don't die so quickly.

Terminology:

* Health - is an attribute assigned to entities such as characters and objects in games that indicate their continued ability to function.
It is usually mesaured in Health Points(HP), which lowers by set amounts when the entity is attacked or injured.

* Mother Ship - a large spacecraft or ship.

Since I will be adding more enemies, I will start to make changes to the Asteroid and Meteoroid enemies. I have removed the Asteroid and Meteoroid class that were previously added.
I will however be using their game objects just to get things set up before I remove them and implement my new enemies. As shown below, the components with the suffix "(Script)" are components
that I have added myself and are not provided by the Unity API. They are classes that I have created. The components marked between the green line will be the core components and will be attached
to all enemies. Some components will be reusable for other objects (i.e. _ObjectGravity_ as explained below).

![enemy-components](https://gitlab.computing.dcu.ie/ibikuno2/2019-ca400-XXXX/raw/master/docs/blog/images/setting-up-enemies.png)

1. _ObjectGravity_ - responsible for moving the game objects down the y-axis. This component will be used for **some** of the enemies. As aformentioned, I plan to 
implement a health points system for the player so that they can have lives. This _ObjectGravity_ component will also be attached to collectable items that the
player can pick up to gain an advantage (i.e. **Hearts** to regain health points).

2. _EnemyCollider_ - this component will be attached to each enemy game object and will be reposible for detecting collision. It consists of the following fields:

![enemy-collider](https://gitlab.computing.dcu.ie/ibikuno2/2019-ca400-XXXX/raw/master/docs/blog/images/enemy-collider-fields.png)

* killScore - this is the number of points that the player gets for killing an enemy ship. Its default is 100, but I will be changed on a per enemy basis (e.g. the Mother ship will have a higher kill score).
* enemyMaxHP - this is the number of health points that the enemy has, default is 10 HP (this will also be changed on a per enemy basis).
* damage - the amount of damage that the enemy takes to their health points when they are hit by an enemy missile.
* collisionDetected - since the player fires two missiles, if two missiles hit the enemy then it loses double its HP and also causes the players score to double.
The purpose of the boolean condition is to check that once one of the player missiles collides with the enemy, you don't have to check if the other one has collided.
* scoreText - the text in the UI that shows the players score.
* explosionAnimationObject - an object with an explosion animation attached to it that is played when an enemy ship is destroyed.
* isBlinkable - this is a boolean condition that if set to true will allow the enemy to blink red if it is hit by the players missiles.

3. _BlinkObject_ - if the isBlinkable variable is set to true for the object then this component allows a game object to blink when they have taken damage. 
This will be used by the player (attached to the player game object) and enemy (they blink red when they take damage). It will also be used when the player collects a heart (will blink green).
This is to alert the player that they have either taken damage, hit an enemy ship with a missile or regained health.

4. _SpawnPoints_ - to keep it short, this component sets the points of the screen that objects will spawn between (explained in greater detail in blog entry 7).

5. _OutOfBounds_ - this component is responsible for detstroying game objects when they leave the screen (to stop memory leaks like I did with the player missiles).

6. _DamagePoints_ - this component has one field called damagePoints. This is the amount of damage that they take to the players HP.

Why it is a seperate script:

It is seperate because I want it to be resuable with other game objects, i.e. enemies and collectable(e.g. the **Heart**, for which it has "positive damage" to give the player more health points).

Attributes:

* SerializeField - this attribute allows for private variables to be viewed in the inspector as shown below by the Enemy Collider component:

![enemy-collider](https://gitlab.computing.dcu.ie/ibikuno2/2019-ca400-XXXX/raw/master/docs/blog/images/inspector-explained.png)

As mentioned earlier, these will be the core components for my enemies. I want to design the game in such a way that if I need to add more enemies I can easily do so because these components I have created 
will be reusable for all of the enemies that I add to the game. I have also done it this way to show how well I understand the Unity Engine and how I will be using it to my advantage to improve my design.

## Blog 15 | Adding Game Over State, Scores, and Health Points:

Since collision detection was implemented, I have now added a **GameManager** class that will handle the Game Over state and a _PlayerScore_ class which will be responsible for incrementing the players score
and posting the scores to the database when the player submits their name. I have not added the database yet.

I have also implemented a health point system. This is done in my **HealthPoints** class. Just a quick recap on what I said in my previous blog.
The player will have a maximum of 3 lives and 100 HP **per life**. Each time the player loses 100HP, they will lose one life. When they have 0 lives, they lose and the game is over.
They will be able to collect hearts to regain lives which will allow the player to regain 50 Health Points.

This class consists of 3 functions:

* IncreaseHP - this function will be called in the **Playership** class to increase the players health points when they collect hearts.
* DecreaseHP - this function is called in the **Playership** class to decrease the players health points when they are attacked.
* UpdateHP - this function increases or decreases the health bar in the user interface. It is also responsible for scaling the health bar in the UI so that what is shown below does not happen:

![scaling](https://gitlab.computing.dcu.ie/ibikuno2/2019-ca400-XXXX/raw/master/docs/blog/images/scaling.png)

Notice that as explained in blog 11, I will be using _FindObjectOfType<ClassName>().Function()_ (which is how you call a function from a MonoBehaviour in Unity) to reference my components as shown below.
You can now see how I am using my _SoundManager_ class that I implemented to play different sounds. You can also see that I am reusing my **BlinkObject** component for the player.

![player-collision](https://gitlab.computing.dcu.ie/ibikuno2/2019-ca400-XXXX/raw/master/docs/blog/images/player-collision.png)

Here are the components that I have added to the Player at this point:

![player-collision](https://gitlab.computing.dcu.ie/ibikuno2/2019-ca400-XXXX/raw/master/docs/blog/images/player-components.png)

### Current state of the game:

As you can see below in the GIF (the quality is a bit poor because this is a GIF), when the player takes damage they blink and when I destroy a meteroid the player score incremenets.

![blinking-and-scores](https://gitlab.computing.dcu.ie/ibikuno2/2019-ca400-XXXX/raw/master/docs/blog/images/player-blinks.gif)

When the game is over, the player can now type in their name.

![game-over](https://gitlab.computing.dcu.ie/ibikuno2/2019-ca400-XXXX/raw/master/docs/blog/images/game-over.gif)

## Blog 16 | Putting the Game Online (March)

When players get a high score they will always try to beat the score that they usually have, they may fail a few times but each failure will drive
them to work harder and play smarter until they beat that score or the scores of other players. The element of competition
makes the player want to play the game. That is why I was very adamant on implementing an online leaderbard in both my original
and new idea for the game.

To put the game online I will be using a No SQL and No PHP server called DreamLo. To post and pull the scores from the database I will be using
HTTP GET Requests in **C#** that will fetch and put the scores and the player names on the DreamLo Server.

At this point I have added 4 new components to the game.

* _Ranking_ - this is just a class that will hold the players score and their name.
* _RankingManager_ - this class is where I implement the HTTP GET requests to post and pull the scores from the server.
* _DisplayRankings_ - this is used to display the top 10 rankings in the User Interface.
* _Template_ - this component will be attached to each of the template game objects as shown below and will hold the text components that will display the name of the player and their score.

![entry-templates](https://gitlab.computing.dcu.ie/ibikuno2/2019-ca400-XXXX/raw/master/docs/blog/images/leaderboard.png)

![template-component](https://gitlab.computing.dcu.ie/ibikuno2/2019-ca400-XXXX/raw/master/docs/blog/images/template-component.png)

When the player clicks the submit button after losing the game, their score will be posted to the server and they will be instantly taken back to the main menu to view where they ranked against the score
of other players or to see if they made the top 10. Rather than having one player with multiple scores displayed, **when the player beats their high score, then that score will be overwritten**. This is done
purposly to avoid putting too much data on the server.


## Blog 17 | Making the Enemies and Player Collectable (April)

People usually prefer to play games that have an intermediate level of difficulty. 
When making the enemies, I want them to be hard to beat, and I want the game itself to be challenging. 
But I want it to be fair, so that the player doesn't get fustrated up to the point where they get bored
and no longer want to play the game.

Since I am learning how to use the Unity Engine, I want to also use some of the new features that Unity provides. Since all the enemies have the same
core components, to create the other prefabs for the new enemies I will be using Prefab Varients.

* Prefab Varients - allow you to create new prefab assets that are derived from other prefab assets. The prefab that a prefab varient is based on
is refered to as the **base**. The prefab varient can contain overrides to the base prefab, but still receieve update to properties that are not overwitten.

Notice the way that I'm utilising the engine to allow me to design the game to a high standard. Now when I want to add a new enemy, it is very simple, I won't have to even create a **brand new** game object,
I can make a varient of the one that I already have and add components to it if I want to modify its behaviour.

### Chaser

The first new enemy that I will be making is the Chaser, the name of the component for this enemy is called **Chaser**.
I will be naming the components after the name of the enemy just to make it easy to follow. You can see that since I created a varient of the **Asteroid** prefab, 
all I had to do was change its sprite and remove its **ObjectGravity** component that was attached to it and replace this component 
with the **Chaser** component that I created in order to change its behaviour.

![chaser-core](https://gitlab.computing.dcu.ie/ibikuno2/2019-ca400-XXXX/raw/master/docs/blog/images/chaser-components.png)

The chaser enemy ship will move towards the players last position and stop at a certain distance from that position. To make it fair to the player, the chaser won't move
to the exact last position in (x,y) coordinates, rather it will at a certain distance away from that position, this is to give the player enough time to move away 
when they see the chaser heading towards thier direction. It will then rotate and fire missiles towards the player. As you can see below:

![chaser-enemy](https://gitlab.computing.dcu.ie/ibikuno2/2019-ca400-XXXX/raw/master/docs/blog/images/chaser-enemy.gif)

Unity has a method to make an object always look at another object called transform.LookAt(), but I will be implemeting this myself 
which is done by my _LookAtPlayer_ function in my **Chaser** class. 

To do this, I will be using a _Quaternion_ and Vector Calculations.

* Quaternion - these are a 4 dimensional extension of complex numbers. A quaternion is used to describe 
rotation in 3D. This is used to compute 3D rotations.

* Vector - a quantity having direction as well as magnitude, especially as determining the position of one 
point in space relative to another.

![quaternion-explained](https://gitlab.computing.dcu.ie/ibikuno2/2019-ca400-XXXX/raw/master/docs/blog/images/quaternion-rotation.gif)

In order to get the chaser to rotate and always look at the player:

You have to calculate the direction between the position of the chaser and the players current position and then store it as a vector.
From this direction (as a vector) you then get the angle between the x-axis of the chaser and a 2D vector that starts at zero and terminates at the current (x,y) position of the player.
You then create a rotation which rotates angle degrees around the axis.

![chaser-angle](https://gitlab.computing.dcu.ie/ibikuno2/2019-ca400-XXXX/raw/master/docs/blog/images/chaser-angle.png)

### Gunner

I played against the chaser myself, and each battle I had against each instance of the chaser enemy ship usually caused me to lose a fair amount of HP (to me this is good). 
When playing I usually lost about 10-20 HP per chaser enemy ship. This is good because when the player hits an enemy ship they lose 20 HP (mother ship does more damage) or 10HP if
they are hit by an enemy missile. With that being said, I made the **Gunner** enemy ship to balance the level of difficulty. It has less HP, but its still hard to beat, 
but not as hard as the chaser enemy. This enemy  moves from one side of the screen to the other while firing at the player. This behaviour is done by my **Gunner** component.

![gunner](https://gitlab.computing.dcu.ie/ibikuno2/2019-ca400-XXXX/raw/master/docs/blog/images/gunner-components.png)

### Ring and RingParent

The **RingParent** enemy is composed of 8 enemy ships called **Rings**. These enemy ships will move in a circular formation 
and each will fire missiles at the player. They will not all fire at the same time as it would be to hard for the player to avoid so many missiles at once.

How this enemy was made:

I started by creating another prefab varient, let's call it the **base ring**. As with the other enemy prefabs, this prefab will inherit all core components except for
**SpawnPoints** component (remember that prefab varients allow you to make overrides to the base prefab, which in this case is the **chaser** enemy).

![ring-components](https://gitlab.computing.dcu.ie/ibikuno2/2019-ca400-XXXX/raw/master/docs/blog/images/ring-components.png)

I then created 7 other prefab variants from the **base ring**. One ring enemy ship on its own can move in a circular path around a fixed point, which I will call a **pivot**.
In order to get the ring to move in a circular path around this **pivot**, I will be using a Quaternion like I did before. This time not to rotate but to form
points around the **pivot** in the shape of a circle, which is done by my __CircularMotion_ function in my **Ring** class.

![ring-moving](https://gitlab.computing.dcu.ie/ibikuno2/2019-ca400-XXXX/raw/master/docs/blog/images/ring-by-itself.gif)

As you can see above, this only allows it to move in a circle around that one position, it cannot move anywhere else. To get it to move, I will create a **RingParent**
object. This object will act as the pivot and will hold all the 8 ring enemy ships, the enemy ships will then move around this parent object in a circle, this is done in my **Ring** class.

The **RingParent** object will have my **ObjectGravity** (which is what will make it move), **SpawnPoints**, and **OutOfBounds** components attached. 
It will also have a new component that I created called **DestroyParent** which will destroy the pivot if all the 8 ring enemy ships have been destroyed.

![ringparent-components](https://gitlab.computing.dcu.ie/ibikuno2/2019-ca400-XXXX/raw/master/docs/blog/images/ring-parent.png)

* _DestroyParent_ - will destroy the ring parent object if all of its children have been destroyed. This is done to avoid keeping the parent object alive in the game even though it is not being used.
This is very important, otherwise the game can begin to lag.

![ring-parent-moving](https://gitlab.computing.dcu.ie/ibikuno2/2019-ca400-XXXX/raw/master/docs/blog/images/ring-parent.gif)

As you can see above, because I am using varients, when you destroy one of the ring enemy ships, the others are not going to be destroyed. Also notice that they don't fire at the same time. Since the pivot is moving 
downwards and will eventually move out of the screen, I have made it so that they will fire a few microseconds after each other, that way they all have a purpose. The player will get 175 points added to their score
for each ring enemy ship that they destroy. If all ring enemy ships are destroyed then they get 1400 points.

### Patrol

At this point we have one tough enemy to beat, which is the **chaser**, and two other enemies that will allow the player to collect a lot of points, the **gunner** and the **RingParent** (because of its 8 enemy ships).
Now, I want to increase the level of difficulty again by adding a more intelligent enemy ship than the **chaser** enemy ship.

The patrol enemy will search around for the player and try to locate its current position. When it finds the players position, 
it will head towards the players direction, lock itself a few units away from the players current position, it will then follow 
the player around always remaining in front of them. When implementing up this enemy, I had to take into account that when the **patrol** enemy ship 
locks onto the players current position, it cannot just stay in front of the player and display no kind of movement, this would allow the player to kill it too easily.
So to make it more difficult I decided to make it move left and right while firing at the players current position, but still always remaining in front of the player at all times.

How this enemy was made:

This enemy consists of two objects, the **Patrol** object which acts as a parent object and the **Slicer** which will be attached to the **Patrol** object.
Firstly, I started by attaching the **slicer** object to its core components as show below:

![slicer](https://gitlab.computing.dcu.ie/ibikuno2/2019-ca400-XXXX/raw/master/docs/blog/images/slicer-components.png)

Next I go it to move left and right at a fixed point, which I will call the **pivot**. To get it to move left and right, I will be using a **RayCasting** and **Euler Angles**.

* Raycasting - is the process of shooting an invisible ray from a point in a specified direction to detect whether any
any colliders lay in the path of that ray. A raycast consists of 3 parts:

1. Origin - is a point in world space.
2. Direction - this is the direction that the ray is "fired".
3. Distance - this is the length of the ray.

Terminology:

* _World Space_ - is the coordinate system of our 3D universe.

As you can see in the above image, there is a small diamond beside the **slicer** enemy ship sprite. I will call this diamond a **barrier**. This **barrier** will shoot
a ray downwards. This **barrier** stops the ship from contiuosly moving towards an infinite point in space. Whenever the **slicer** enemy ship hits this barrier, it will begin to move in
the oppsite direction as shown below. To get it to move in the opposite direction I will be using **Euler Angles**. This is done by my **Slicer** component.

* Euler Angles - are three angles used to describe the orientation of a rigid body with respect to a fixed coordinate system.

![euler-angles](https://gitlab.computing.dcu.ie/ibikuno2/2019-ca400-XXXX/raw/master/docs/blog/images/euler-pitch-yaw-roll.png)

As you can see, in the above image, getting the **slicer** enemy ship to move side to side means that you must rotate the y value in world space by **-180** degrees any time it reaches the barrier on its right side
and when it reaches the barrier on the left side, you must set the y value to **0** so that it can go back in the opposite direction to **180**.

Next I added the **Patrol** abject and its components:

![patrol](https://gitlab.computing.dcu.ie/ibikuno2/2019-ca400-XXXX/raw/master/docs/blog/images/patrol-components.png)

To get the **patrol** object to allow the slicer to always stay in front of the player, the player will have a new object called a **stop**, this object is in front of the player at all times. The **patrol** will
search for that stopping position, which is always based on the current position of the player. 

![player-stop](https://gitlab.computing.dcu.ie/ibikuno2/2019-ca400-XXXX/raw/master/docs/blog/images/player-stop.png)
![player-stop-position](https://gitlab.computing.dcu.ie/ibikuno2/2019-ca400-XXXX/raw/master/docs/blog/images/player-stop-position.png)

When it finds it, it will then move the **slicer** side to side and fire missiles towards the player. The **patrols** behaviour is done by my **Follow** class.
Here is the behaviour of the **Patrol** enemy in action:

![player-stop-position](https://gitlab.computing.dcu.ie/ibikuno2/2019-ca400-XXXX/raw/master/docs/blog/images/patrol-follow.gif)

### Mother Ship

The **Mother Ship** is the strongest enemy ship that the player will battle against. This enemy moves faster, fires missiles faster, and has a lot more health points than the other enemies.
This enemy will also make use of the core components that are used by the other enemies.

![player-stop-position](https://gitlab.computing.dcu.ie/ibikuno2/2019-ca400-XXXX/raw/master/docs/blog/images/mothership-components.png)

The weight of the **Mother Ship** is adjusted based on the players perfomrnace. There is a higher chance of the **Mother Ship** being spawned if the player has a score that is higher than the average scores on the leader board.
It will have a list of moving positions. It will chose a random position to move towards, stay at that position for a few seconds while firing missiles at the player, before it decides where to move next.
It performs these actions while always looking at the players current position. This behaviour is shown below.

![player-stop-position](https://gitlab.computing.dcu.ie/ibikuno2/2019-ca400-XXXX/raw/master/docs/blog/images/mothership.gif)

### Enemy Missile:

I will also be using prefab varients when it comes to adding the enemy missiles. The chasers missile will server as the **base** prefab for the other enemy missiles
since this is the first new nemey that I am implementing. Each enemy will have a shooter object attached to them. As you can see below, each enemy shooter object will have my
**EnemyShooter** component attached to them. This component is responsible for firing the enemys missiles in the direction of the player.

![enemy-shooter](https://gitlab.computing.dcu.ie/ibikuno2/2019-ca400-XXXX/raw/master/docs/blog/images/enemy-shooter.png)

Each missile prefab will have the follow core components:

![enemy-missile](https://gitlab.computing.dcu.ie/ibikuno2/2019-ca400-XXXX/raw/master/docs/blog/images/enemy-missile.png)

* _EnemyMissile_ - this component is for moving the enemy missile across the screen and destroying it if it moves out of the screen.
* _MissileCollider_ - is attached to each missile prefab to detect collision with the player.
* _DamagePoints_ - this component has one field called damagePoints. This is the amount of damage that they take to the players HP.

### Player Collectable

After adding all the enemies, I then went on to add a collectable object, which I call the **HeartPickUp**. When the player collides with this object, 50HP will be added
to their current HP.

![heart](https://gitlab.computing.dcu.ie/ibikuno2/2019-ca400-XXXX/raw/master/docs/blog/images/hearpickup-components.png)

The only new component that I have added for the Heart is the **HeartCollider**, which will detect collision between the player and the heart.
Notice again how well I have designed the game. Whenever I needed to make a new enemy or event a collectable I reused the components that I already have
and added new ones when needed.

As you can see below, the player can regain HP by colliding with the **HeartPickUp**:

![heart](https://gitlab.computing.dcu.ie/ibikuno2/2019-ca400-XXXX/raw/master/docs/blog/images/heart-pick-up.gif) 

## Blog 18 | Adding Intelligence to the Spawning of Objects

At this point, I have renamed the **EnemySpawner** component (class) to **SpawnManager**. This component will be responsible for spawning both the enemies and the heart collectable.
Now that I have added the enemies and the heart collectable, I want to add intelligence to the way objects are spawned. Rather than making objects spawn from random positions,
I will now be making them spawn based on the players current position.

I did this for 3 reasons:

1. It makes the game more interesting.
2. To give the player an advantage, so that the heart collectables spawn based on their position, making it easier for them to regain some HP.
3. To also add more difficulty because now enemies will also spawn based on the players position.

When spawning the objects, I don't want them to spawn directly in front of the player. Instead objects will still spawn based on
the position of the player, but a bit closer to the centre of the screen. An example of this is shown below. The green line indicates
the position that the objects will be spawned.

![spawn-based-on-player-position](https://gitlab.computing.dcu.ie/ibikuno2/2019-ca400-XXXX/raw/master/docs/blog/images/how-objects-are-spawned.png)

My **SpawnObjectOnScreen** method in the **SpawnManager** class is responsible for doing this.
To do this I will need to keep track of the Cameras current position at all times and calculate 
the difference between the cameras position on the z axis and the players position on the z-axis. To
actually spawn the object in front of the player, I will need to also keep track of the top border of
the camera. I then spawn the objects based on the players position on the x-axis.

![spawn-object-on-screen](https://gitlab.computing.dcu.ie/ibikuno2/2019-ca400-XXXX/raw/master/docs/blog/images/spawnmanager-spawnobject-on-screen-function.png)

As you can see in the code above, notice that I am still using my **SpawnPoints** component that is attached to each object.
This is because I have to take the size of objects into account so that they don't render outside of the screen.
This is discussed in **Blog 7**.

The code below is what actually allows me to spawn the object a bit closer to the center of the screen (but still based on the players position).

```csharp
camToWorld.x = instanceOfObject.GetComponent<SpawnPoints>().x1 * this.playership.transform.position.x;
```

Notice that I am reusing my **SpawnPoints** component that is attached to each object, meaning that the size of each object will be taken into account.

As you can see below the heart is being spawned based on the players position, but as explained, not directly in front of the player but a bit closer to the 
center of the screen:

![spawn-based-on-player-position](https://gitlab.computing.dcu.ie/ibikuno2/2019-ca400-XXXX/raw/master/docs/blog/images/spawn-based-on-players-position.gif)

### Cumulative Distribution Function

To Add more intelligence to my **SpawnMnager**, I will be spawning objects based on weights. 
To implement this I will be using the **Cumulative Distribution Function**.

Why I will use weights:

1. For exmaple, since the **SpawnManager** has a list of all the enemy objects, if the player has just started the game
and I was to select an enemy from this list at random without using weights, there is a chance that the **MotherShip** will be the first
enemy spawned. I obviously don't want something like this to happen, because this **MotherShip** enemy is the boss. In games, the player
should only have to fight against the boss if they performing really well.
2. Having weights will allow me to add an element of dynamic difficulty adjustment, because now I can give the player even more of a chance to perform well. For example
increasing the probility of a heart being spawned if they have very low HP.
3. Another element of dynmaic difficulty adjustment weights allow me to add is increasing the chance of the **MotherShip** being spawned if the player is
performing really well.

To implement this I created a new class called **CustomObject**. This class consists of two fields:

1. _customObject_ - this is the gameobject.
2. _weight_ - this is the factor that will determine how frequently the object is spawned.

![custom-object](https://gitlab.computing.dcu.ie/ibikuno2/2019-ca400-XXXX/raw/master/docs/blog/images/custom-object.png)

The **SpawnManager** will have a list of **CustomObject**'s. In order to chose a random object based on their weights,
a random value will be picked between zero and the total number of the weights of all of the objects. The object with 
the highest weight that is greater the value generated, will be the object that is selected to spawn.

![cumulative-distribution](https://gitlab.computing.dcu.ie/ibikuno2/2019-ca400-XXXX/raw/master/docs/blog/images/cumulative-distribution.png)

The weight of the **HeartPickUp** will be adjusted based on the number of lives and HP that the player has left.
For example, if a player has a very low number of lives and HP remaining then there is a higher chance that a heart
will be spawned.

Whereas, the weight assigned to the **MotherShip** enemy (which is the boss) will be adjusted based on the score of the current
player and the average of the current high scores online.

For example, if the players score is greater than the average of the high scores, then there is more chance
that the **MotherShip** will be spawned.

## Blog 19 | Unit, Integration, UI, and User Acceptance Testing

### Testing Method:

In game development the most common type of testing is **Data Driven Development**. This type of testing involves testing the behaviour of game objects
in the game when they are attached to their components. I used this method as well as the **Humble Object Pattern** to carry out my integration and unit tests. 
Both are explained thoroughly in my **Technical Guide** document.

An example of a data driven test is shown below, as you can see in this test, I am checking to see that the chaser enemy ship fires missiles
(Please wait until after "No Cameras Rendering").

![chaser-test-code](https://gitlab.computing.dcu.ie/ibikuno2/2019-ca400-XXXX/raw/master/docs/blog/images/chaser-shoots-test.png)

![chaser-test-in-action](https://gitlab.computing.dcu.ie/ibikuno2/2019-ca400-XXXX/raw/master/docs/blog/images/integration-chaser-test.gif)

I used the open-source libraries **Nunit** and **NSubstitute** to write my tests and to add assertions to them.
I combined these two open-source tools with a closed-source dependency injector called **IUnityService**, which is not part of the Unity API. 
**IUnityService** is a component that can be found in my Gitlab repo. **IUnityService** allows me to write integration tests to validate player movement in my game.
It is used in my **PlayershipController** component to seperate Unity's static **Input** and **Time** classes. This allows me to write tests to actually check if input
was provided by the user. This is also explained in detail in my **Technical Guide**.

The **IUnityService** dependency injector is only used to write tests for player movement because this test specifically requires user input and you cannot
simulate the clicking of keyboard buttons for tests in Unity. The other integration tests don't require input, so I won't need this dependency injector to test them.

Here is what the test actually looks like when it is being run (Please wait until after "No Cameras Rendering"). 

![player-movement-test-code](https://gitlab.computing.dcu.ie/ibikuno2/2019-ca400-XXXX/raw/master/docs/blog/images/player-controller-test.png)

![player-movement-test-code-in-action](https://gitlab.computing.dcu.ie/ibikuno2/2019-ca400-XXXX/raw/master/docs/blog/images/integration-player-test.gif)

Since the y-axis is normalized, meaning it has a maximum length of 1 (from -1 to 1). If
the player moves up, they should be at position 1 on the y axis (with -1 and 0 being
down and middle respectively) meaning that the test should pass.

To perform UI tests I used Unity's Automation Testing tool that is provided on the Asset store and an open-source library called **Puppetry**.

Citation: https://github.com/TestUnitLab/Puppetry

For User Acceptance Testing, I carried out a survey and allowed people to play my game. I got a lot of positive feedback from the users.
The results from my survey show that all users to enjoy the game. I also implemented some of the changes that the users asked me to make. 
The changes made and results will be shown in the testing section of my **Technical Guide** document.

At this point I have implemented Unit Testing, Integration Testing, UI Testing, and User Testing.

Tools:

* Unity Test Runner - To run my Integrationa, UI, and Unit Tests.
* Unity UI Automation Testing Tool - UI Tests 
* Puppetry - UI Tests

## Blog 20 | Optimisation

After carrying out user testing I will be making some changes based on the the feedback that I got from the users (results will be available in my Technical Manual).
A very tiny portion of the users said that they experienced a bit of lag, so I will be taking some steps to reduce lag even further.

Terminology:

* _Lag_ – is a time delay between a player’s action and the game’s reaction to that input.

So far I have one way that reduces lag in the game already, which is **Object Pooling**. This is discussed in **Blog 7**. To reduce lag even more, I will be using a technique
known as **Static Batching**, which is done in the Unity UI:

* _Static Batching_ - allows the engine to reduce draw calls for geometry of any size provided it shares the same material
and does not move. When static batching is applied to objects that do not move (i.e. my in-game menu, which has a fixed position), 
lag can be removed by reducing draw calls made to the CPU.

Finally to reduce lag even more, I implemented player reloading. This will reduce the amount of lag by a lot because when the player fires missiles, the missile objects are instantiated.
Instantiations can be very expensive (depending on how they are used). So rather than allowing the player to fire missiles whenever they like, the player will be given five missiles.
When the player runs out of missiles, the missiles will then be reloaded and the player will have to wait for a few microseconds before they can start to fire again.

![reload-function](https://gitlab.computing.dcu.ie/ibikuno2/2019-ca400-XXXX/raw/master/docs/blog/images/player-reloading.png)

To demonstrate the effects of this, below you can see that the number of draw calls made by the **PlayerShipMissile** component has been reduced. To look at the performance of my game
I used the **Unity Profiler**.

* _Unity Profiler_ - gives detailed information about how your game is performing.

### Draw calls of player missile before optimization:

![player-missile-before-optimization](https://gitlab.computing.dcu.ie/ibikuno2/2019-ca400-XXXX/raw/master/docs/blog/images/profiler-playermissile-spike.png)

### Draw calls of player missile after optimization:

![player-missile-after-optimization](https://gitlab.computing.dcu.ie/ibikuno2/2019-ca400-XXXX/raw/master/docs/blog/images/profiler-playermissile-spike-optimized.png)

As you can see above in the second image, I have droppped the number of draw calls made by the CPU to **4** per frame, it used to be **12**. This will reduce the amount of lag significantly.
As you can see below, after firing 5 missiles, it pauses for a few microseconds before it allows me to fire again.

![player-missiles-optimized](https://gitlab.computing.dcu.ie/ibikuno2/2019-ca400-XXXX/raw/master/docs/blog/images/player-missile-optimised.gif)