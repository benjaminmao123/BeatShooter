# BeatShooter
 
BeatShooter is a 3D osu-inspired game developed in Unity. It is a rhythm game that where the player needs to hit with the correct timing to the music. It supports VR but the player can also opt to use the keyboard and mouse.

## Abstract

For our project we have created a rhythm shooter game. In the game, the player is placed into a room where he/she has to shoot colored tiles while keeping up with the rhythm of the song. If the player misses, he has to dodge an incoming projectile. This is a unique experience because it allows the player to use hearing, hand-eye coordination and movement in order to pass a beat map. A laser pointer is tied to the user’s hand which triggers a hitsound when the user clicks on a colored tile. 

## Introduction
 
Beat shooter is a rhythm shooter game where a player is placed into a room where he/she has to shoot colored tiles to the rhythm of the song. There will be a green outline on the current tile the player must shoot. Shooting a tile will result in 2 points if the tile is blue and 1 point if the tile is red. If the player does not hit the tile after a certain time, it will count as a miss and a projectile will come from that tile which the player must dodge in order to not lose health. The player loses the level if his/her health is reduced to 0. 

This project is interesting because it challenges the player’s senses and mind in many ways. Firstly the player must pay attention to the rhythm of the song in order to hit the tiles in the correct timing. Secondly, the player must have good hand eye coordination in order to aim at the tile he/she needs to hit. Lastly, the player must be aware to move away from the projectile when he/she misses while still keeping up both the aim and the rhythm aspect of the game. 

VR makes this game more interesting because it allows the user to interact with the different components of the game in a more realistic manner. Instead of using a mouse and keyboard for aim and movement, a player uses his/her body creating a more immersive experience. This game has the potential to become very challenging just like other rhythm games.  Having players play using their hands and body as opposed to mouse and keyboard can also prove to be challenging for many players who are used to playing games with the latter. 

## Related Works

Our game is a VR rhythm game. The popular games of this type are: Beat Saber, by Beat Games, Synth Riders, by Kluge Interactive, Audioshield, by Dylan Fitterer, et cetera. Though these games and ours are fall into the same category, our game is different from them. 

In Beat Saber, players only need to pay attention to the direction marks on the cubes, and when the cube comes close, the player uses the virtual sword to cut the cubes. Our game, by contrast, needs more ear-eye-hand coordination. Players need to listen to the music carefully to follow the rhythm while looking at the color of cubes, only shoot during a certain interval will be recognized as valid. We have cubes on three walls, which are in three different directions: left, front and right. Cube can appear on any one, players need to focus and respond quickly by turning and aiming at the correct one. However, there are some disadvantages when compared to that famous game. The Beat Saber has higher quality of special effects and the music is more compatible to the video. Also the Beat Saber uses both hands while our game only uses only one, which causes an imbalance of force using. 

## Design

For our design, we created a main menu, a game scene, and a post game scene. In our main menu scene, we have a play button and a quit button. The play button brings the user into the next menu which allows them to select a song. The quit button just quits the game.
In the select song menu, the player can preview a song or select a song which will then move them into the next scene, the game scene. 

The game scene consists of a room with 6 planes. There are 3 planes to the left, middle, and right of the player which has tiles on it that the player can shoot to get points. 
The roof has a main menu option which allows the player to go back to the main menu in case they selected the wrong song.
The floor has the score of the player and the player’s current health. 
The post game scene just contains the player’s results, indicating their score out of a possible score and a main menu option which allows them to return back to the main menu.

For our controls, we used the oculus controller as the main method of input for our game. We mapped the right index trigger to be able to shoot at the tiles that appear. We chose this interface because it felt more natural than using a mouse. The game was actually easier to play using the oculus controller instead of a mouse. 

Our game conforms to the Oculus Best Practices Guide in that we had a stable UI. It did not follow the player around which would induce motion sickness. Our UI was plastered onto a world canvas, and onto a plane where the player would have to turn to look at. In addition, we abided to the head tracking practices as our camera movement was not erratic and followed the player’s head correctly. We provided a good view of range for our player so they did not have to move their head too much to see the tiles. Our game also ran at 60+ FPS which reduces the amount of latency experienced by the player. One practice in which our game struggled with was providing a good resting position for the player as they would have to keep their arm up all game to aim at the tiles. Another would be the jitteriness of the oculus controller movement.

Our game would perform the best for songs that are about a minute to a minute and a half long. These songs are short and concise so they don’t force the player to keep aiming at the tiles. Our game would perform the worst if the song went on for too long. This is because it requires the player to concentrate and keep their arm up to aim at the tiles. This may in turn cause “gorilla arm” which will make the player’s arm very tired as they can’t rest their arm or else they risk losing points. In addition, another issue we did not get around to fixing was the jitteriness of the oculus controller. We did not smooth the input due to time constraints which made it feel slightly awkward when aiming at the tiles.

## Implementation

There are several important parts of this project. 

Note and Timing: For the timing if the songs, we export the existing timing file in music game editors and assign corresponding cubes to each timestamp. The assigning process follows two rules: no cube will light up within five timestamps, no two consecutive notes jumps between more than one wall. We use class Notemanager to control this part, which repeatedly reads the pre-set index of cube and light up the cube in its update function.

Hand and Ray: We use the Physics.Raycast in Unity to create a ray line casting from the virtual hand (controller), and pointing the direction of front of the controller. When the ray hits the correct cube, class PrimaryFireInputAction checks the color of it, if blue value is larger than red, it triggers a custom c# event called GameEvent.HitGood and increase score by 2, otherwise GameEvent.HitBad is triggered.

Styling: When the cube is good for shooting, green outline lights up around the cube, we use Outline API for this.  When timeout, the cube becomes a red light spot coming at the player. When hitting a cube correctly, sparks emit from the position of  cube, class ParticleSystem is used. The cube color changes by sine function from red to blue, there is a Color.Lerp interface.

Audio and Sound: Unity has its audio manager in UnityEngine.Audio, we use it to handle the song previewing and audio playing. The sound effect of hit, missing are different and are triggered with GameEvent.

## Lessons Learned

In this project we learned many different things. We learned that the oculus controllers need to be turned on when you start the game otherwise the game will not receive its inputs. We learned that getting timings for a rhythm game is very challenging and to speed up the process of finishing the game, we had to use the time stamps of when to hit the tile from a different game (osu). 

For the most part our users reacted positively towards our project. They liked the idea and found the game very fun to play. The game was challenging yet playable making the users want to try the game again so they can beat the levels. One issue the users had was the shakiness of the cursor in the game. This made it difficult to hit tiles as the cursor would shake and sometimes make the user aim slightly off from where they intended to aim. Two ways we can improve this is either to fix the cursor shakiness itself by writing code to optimize the cursor or to make the tiles bigger and easier to aim, therefore users have more room for error. 

For the most part all work was done together in lab and office hours. A lot of discussion was made on how to implement certain parts of the project such as the color changer and rhythm timings. As for more individual tasks, Benjamin Mao added better design and effects, score calculation and a menu to make the game more visually appealing and engaging. As determining the rhythm of the song was pretty difficult, Qicheng and Garret were in charge of figuring out the rhythm timings as well as making the beatmap itself.  The rest of the project such as controller inputs, environment design and assets were done together. 

## Video
https://www.youtube.com/watch?v=2K2GBEHeObs&feature=youtu.be
