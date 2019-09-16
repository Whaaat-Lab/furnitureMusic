# Process Documentation

## 08.14.19
This whole thing begins with us thinking about exploratory alternative input devices (Bearwarp's [geobio](https://vimeo.com/259809620), for example). But how can we translate the methodology behind physical exploration into pure game-control? Additionally, can this control be used to influence the overall sonic landscape of a game experience, hopefully leveraging the music to create slow and/or contemplative experiences.

Secondly, this stems from an interest in Eric Satie's notion of [Furniture Music](https://en.wikipedia.org/wiki/Furniture_music), or music composed for a given architectural environment. Obviously the project naming and execution makes light of this, but especially in Eno's [Ambient 1: Music for Airports](https://open.spotify.com/album/063f8Ej8rLVTz9KkjQKEMa), we feel that there was a potential for real symbiosis between architectural and sonic decisions. 

This initial commit uses the [Low Poly Modular Living Room](https://assetstore.unity.com/packages/3d/environments/urban/low-poly-modular-living-room-128552) asset from Cenk Sanusoglu on the Unity Asset store. We have implemented clicking and dragging the furniture. The next stage will be to compose a soundscape for the environment.

## Initial Music Setup and Colorization Prototype - 08.17.19
We spent a few days exploring which middleware we could use for the soundtrack. Earlier versions of this project had used Wwise, but this seems a little cumbersome for what we want to achieve here, namely musical tracks separated out and the ability to manipulate effects parameters. [Elias](https://www.eliassoftware.com) seemed like a good solution, but its free version is fairly limiting, and doesn't seem to offer enough granular access to effects. In the end, Unity's Audio package will work for our goals. 

![alt text](colorExploration "Color Exploration")

We also began exploring the possibility of manipulating the visuals alongside the audio. This build of the project has the user increasing the tiling as they drag any piece of furniture. The results are interesting, but maybe too haphazard.

## Music Implementation 1 - 09.16.19
In this first implementation of music manipulation, we add six ambient synth tracks. Moving some furniture affects the pitch, and moving some changes the Cutoff Frequency of a High-Pass Filter. Using the built-in Unity Audio Engine proves to be interesting. We tried adding an overall distortion to the track using the Audio Distortion Filter, but it works more like an overdrive, maxing out all of the volume to an undesirable degree. There is also some ambient street noise that plays when the door opens. 

With all of this, it has been great to experiment with the sounds with the room already in place. Every decision is pushed against this idea of "does it make sense for [Furniture X] to affect the sound this way?" which is a fun way to work. In the end, this feels more like a playground where we can explore ideas of how sound and movement could work. Because of this, in the future we plan on uploading playable versions of each iteration of the project for others to play with. Perhaps we will organize those here outside of the timeline?