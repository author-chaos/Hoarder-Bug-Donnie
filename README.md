# Hoarder-Bug-Donnie
## *Preface*
This is the first mod I ever made! It took a lot of trial and error, requiring me to learn about new concepts like AssetBundles and using DLL's to look under the hood of the game to see how we can modify it. 

My goal with this mod is to build a workflow that will make modding in the future easier.

## Mod Concept
Patch the passive sound of the Hoarder Bug with Donnie from the Wild Thornberries tv show. 

## Learning
- There are a handful of DLL's that make our life so much easier, they are (but not limited to):
	- **0Harmony.dll**
		- (Contains many patching tools for .NET)*
	- **BepInEx.dll**
		- *(Unity / XNA game patcher and plugin framework)*
	- **Assembly-CSharp.dll** 
		- *(Contains all of Lethal Company's source code)*
	- **UnityEngine.dll** 
		- *(This and below should be self evident)*
		- **UnityEngine.AssetBundleModule.dll**
		- **UnityEngine.AudioModule.dll**
		- **UnityEngine.CoreModule.dll**

- There was major confusion with how to get assets into the game. Apparently you can't just give it raw files like an mp3 or wav. It expects an **AssetBundle** to be loaded into the game. This requires having Unity (potentially the same version the game uses) and building this by hand. 

## Release
The mod can be acquired from the Thunderstore:
https://thunderstore.io/c/lethal-company/p/AuthorChaos/HoarderBugDonnie/

At this time, HoarderBugDonnie is at version 1.0.1 and will continue to be developed with improvements/bugfixes.