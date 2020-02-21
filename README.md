# Magic Leap Unity Project 

## Versions

### Unity

2019.2.x

### MLSDK

v0.23.0

### LuminOS

0.98.x

## Instructions After Downloading
### Intructions From Template For Magic Leap Environment Setup
1) Using Unity Hub, download Unity 2019.2.x and make sure Lumin support is checked during installation
2) `ADD` the project using Unity Hub
3) Open the project using Unity Hub
4) Under File > Build Settings, make sure the build target is Lumin
5) Under Unity preferences, set the MLSDK path
6) Under project settings > player settings > Lumin tab (Magic Leap logo icon) > publishing settings, set your cert path (and make sure the privkey file is in the same directory. If this is confusing, refer to and read our docs. There’s also a `README` in the privkey folder after unzipping)
7) Make sure USB debugging is enabled between your device and computer (which requires MLDB access) and you’re allowing untrusted sources
8) // Skip this - See Scene Instruction Below Open the `EmptyScene` Scene from `Assets`>`Scenes`>`EmptyScene`
9) Navigate to https://creator.magicleap.com/learn/guides/gsg-create-your-first-unity-app

### Git Notes
Create your own branch before commiting changes to minimize conflicts

## Game Notes
1) Open game scene from `Assets`>`Scenes`>`gamePrototype`. This is the current game prototype. Feel free to create more scences and store under this directory.

2) The purchased package is under `Assets`>`SolarSystem`. `Scenes` contains the orbiting planets. `Prefabs`contains the individual planets. 

## Device Instructions

### Zero Iteration
Currently, we can only iterate using Zero Iteration. Build is not currently working.

1) Connect to controller and put on the headset to unlock device
2) Connect device to computer. Device Bridge in the Lab should show the connected device.
3) In the Lab, open Unity Hub and Zero Iteration
4) In Zero Iteration. Open the Target selector. Select your device from the Target selector. Click Restart ZI.
5) Once Zero Iteration restarts, make sure to switch State to running
6) In your Unity project, click Play on the top.

## Solar System Package
Link to Unity store: https://assetstore.unity.com/packages/templates/packs/solar-system-16139

Download original purchased version: https://drive.google.com/file/d/1gYxC0krZh7F3sSEdGXgfHOV3WSiGo4Fs/view
