## Critical
- Bug fix: Too many controls fully reload the level. Showing address, changing palette, changing pattern table

## High Priority

- Show addresses of metatiles, palette bytes, etc. within editors
- Can change palette and pattern table on main screen but not metatile editor
    - Option A: Duplicate main editor flow (buttons, etc.)
    - Option B: Find way to pass through from main form
    - Option C: Leave it because it shouldn't affect metatile composition

## Nice to Have

- Better management of variables
- Keyboard navigation
- Display issues with the currently loaded level in editor instead of file comments
- Fix confusing references
    - "Tiles" for 8x8 pixel units
    - "Metatiles" for 4x4 clusters of tiles
    - "Pattern table" for the ROM data that makes up tiles
    - Remove anything about "blocks", "video", "chunk", etc.
- Remove anything to do with layers