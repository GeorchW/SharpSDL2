SharpSDL2
=========

This is SharpSDL2, a C# wrapper for SDL2. Originally, this stems from [flibitijibibo's work](https://github.com/flibitijibibo/SDL2-CS), but since he dislikes adapting the APIs to a more C#-like style (dropping `SDL_` prefixes etc.), here's a fork that does adapt the style.

License
-------
SharpSDL2 and SDL2 are released under the zlib license. See LICENSE for details.

About SDL2
----------
For more information about SDL2, visit the SDL wiki:

http://wiki.libsdl.org/moin.fcg/FrontPage

About this project
------------------

This project used various python script and a bunch of manual intervention to port the original SDL2-CS library. You can find the scripts in `/src`. 

Current status of the refactored wrappers:

| Library    | Status    |
| ---------- | --------- |
| SDL2       | ok        |
| SDL2_ttf   | started   |
| SDL2_image | unstarted |
| SDL2_ttf   | unstarted |

About the Visual Studio Debugger
--------------------------------

When running C# applications under the Visual Studio debugger, native code that
names threads with the 0x406D1388 exception will silently exit. To prevent this
exception from being thrown by SDL, add this line before your SDL_Init call:

SDL.SDL_SetHint(SDL.SDL_HINT_WINDOWS_DISABLE_THREAD_NAMING, "1");
