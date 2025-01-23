# BuckyEditor

Fork of https://github.com/spiiin/CadEditor (obviously). Shout out to spiiin and all other original contributors!

## Objectives

### Main

To create a level editor that is tailored specifically to NES game Bucky O'Hare for my own hacking purposes.

### Detailed

- Source all data directly from the ROM. The way it worked previously is using premade bin files based on the original ROM, so if you made any changes that you actually want to see in the editor, you have to recreate the bins.
- Change how levels with multiple palette sets and/or pattern tables load. Previously there was too much being loaded at once and finding the right one to select was confusing.
- Display additional useful information inside of the editor
- Strip down the code to essentials to make it easier for my personal understanding
- Make it function with newer .NET framework, Visual Studio version, etc.

## Usage

### Building and Running

Currently I am not publishing any releases and building it myself. I build the BuckyEditor.sln solution to get all dependent binaries built using Visual Studio. It produces a BuckyEditor.exe executable for a Release build and the same-named exe within an obj folder for a Debug build.

### Using the Editor

Currently functions similarly to the original editor, minus the configurations for other games. Load a ROM and config file, then you can scroll through the screens. I based the config files not on acts but how levels are stored. Basically, if the screens are stored contiguously in the ROM and have the same screen size, pattern tables and palettes, they can go into the same config file. There are exceptions where a screen can have multiple pattern tables and/or palettes, but those are only cases where it's the same one within screens (which is generally when the game animates scenery elements). In the previous implemenation, there was no consistency to how levels were divided up, and sometimes a single config had multiple pattern tables but they were for totally different acts of the level.

In the main editor you pick out existing metatiles and place them into the selected screen. There is also a subeditor you can load to edit the metatiles by placing new tiles in. There is no functionality to edit tiles themselves, I use a different program for that.

## Limitations

- Editor loads level details how they are stored in memory, which isn't always exactly how they are displayed in game
    - Mostly gets confusing with vertical or right-to-left sections
    - Sometimes even if it's a normal left to right act, the screens are still out of order
    - Nonetheless, for any _given_ screen (as in 8x6 metatile area), each screen itself should be correct with a few exceptions for odd ones
- Some tile details don't show - such as Cell elevator platform, robo snake paths
- Valid metatiles can vary act to act for a given level, but they're all grouped together per level. There isn't an indication of which ones are valid, but invalid ones usually look pretty obviously garbled
- No sprites (i.e player charcter, enemy, certain scenery effects) at all
- No editing of metatile "physics" properties (i.e. solid, air, dropdown, deadly)
- No editing of metatile palette selection - some leftover functionality here from original program, but it doesn't work right