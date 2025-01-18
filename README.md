# BuckyEditor

Fork of https://github.com/spiiin/BuckyEditor (obviously). Shout out to spiiin and all other original contributors!

## Objectives

### Main

To create a level editor that is tailored specifically to NES game Bucky O'Hare for my own hacking purposes.

### Detailed

- Source all data directly from the ROM. The way it works now is using premade bin files based on the original ROM, so if you make any changes that you actually want to see in the editor, you have to recreate the bins.
- Some levels do not load correctly; fix these if possible
- Strip down the code to essentials to make it easier for my personal understanding
- Make it function with newer .NET framework, Visual Studio version, etc.
- Stretch goal - modernize and clarify some aspects of the user experience

## Usage

### Building and Running

Currently I am not publishing any releases and building it myself. I build the BuckyEditor.sln solution to get all dependent binaries built. Then it should run from the .exe, or directly in VS debug mode.

### Using the Editor

Currently functions the same as the original editor, minus the configurations for other games. I will update this section if I change how it functions.

- Divided by section when the screen needs to load
- Sometimes grouped if
    - Palettes are the same
    - Pattern tables are the same
    - Screens are adjacent in memory

## Limitations

- Editor loads level details how they are stored in memory, which isn't always exactly how they are displayed in game
    - Mostly gets confusing with vertical or right-to-left sections
    - Sometimes even if it's a normal left to right act, the screens are still swapped
    - Nonetheless, for any _given_ screen (as in 8x6 metatile area), each screen itself should be correct with a few exceptions for odd ones
- Some tile details don't show - such as Cell elevator platform, robo snake paths
- No sprites (i.e player charcter, enemy, certain scenery effects) at all
- No editing of metatile "physics" properties (i.e. solid, air, dropdown, deadly)
- No editing of metatile palette selection - some leftover functionality here from original program, but it doesn't work right