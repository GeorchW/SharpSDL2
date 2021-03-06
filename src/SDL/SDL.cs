#region License
/* SDL2# - C# Wrapper for SDL2
 *
 * Copyright (c) 2013-2020 Ethan Lee.
 *
 * This software is provided 'as-is', without any express or implied warranty.
 * In no event will the authors be held liable for any damages arising from
 * the use of this software.
 *
 * Permission is granted to anyone to use this software for any purpose,
 * including commercial applications, and to alter it and redistribute it
 * freely, subject to the following restrictions:
 *
 * 1. The origin of this software must not be misrepresented; you must not
 * claim that you wrote the original software. If you use this software in a
 * product, an acknowledgment in the product documentation would be
 * appreciated but is not required.
 *
 * 2. Altered source versions must be plainly marked as such, and must not be
 * misrepresented as being the original software.
 *
 * 3. This notice may not be removed or altered from any source distribution.
 *
 * Ethan "flibitijibibo" Lee <flibitijibibo@flibitijibibo.com>
 *
 */
#endregion


#region Using Statements
using System;
using System.Runtime.InteropServices;
#endregion
namespace SDL2
{
    #region SDL.h
    [Flags]
    public enum InitFlags
    {
        Timer = 0x00000001,
        Audio = 0x00000010,
        Video = 0x00000020,
        Joystick = 0x00000200,
        Haptic = 0x00001000,
        GameController = 0x00002000,
        Events = 0x00004000,
        Sensor = 0x00008000,
        Noparachute = 0x00100000,
        Everything = (
            Timer | Audio | Video |
            Events | Joystick | Haptic |
            GameController | Sensor
        ),
    }

    public static partial class SDL
    {
        /// <summary>This function initializes the subsystems specified by</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_Init")]
        public static extern int Init(InitFlags flags);

        /// <summary>This function initializes specific SDL subsystemsSubsystem initialization is ref-counted, you must call  for each  to correctly shutdown a subsystem manually (or call  to force shutdown). If a subsystem is already loaded then this call will increase the ref-count and return.</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_InitSubSystem")]
        public static extern int InitSubSystem(InitFlags flags);

        /// <summary>This function cleans up all initialized subsystems. You should call it upon all exit conditions.</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_Quit")]
        public static extern void Quit();

        /// <summary>This function cleans up specific SDL subsystems</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_QuitSubSystem")]
        public static extern void QuitSubSystem(InitFlags flags);

        /// <summary>This function returns a mask of the specified subsystems which have previously been initialized.If  is 0, it returns a mask of all initialized subsystems.</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_WasInit")]
        public static extern InitFlags WasInit(InitFlags flags);
    }
    #endregion
}
