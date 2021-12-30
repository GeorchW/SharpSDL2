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
    #region main.h
    /* This is used as a function pointer to a C main() function */
    public delegate int MainFunction(int argc, IntPtr argv);

    public static partial class SDL
    {
        /// <summary>
        /// This is called by the real SDL main function to let the rest of the library know that initialization was done properly.
        /// Calling this yourself without knowing what you're doing can cause crashes and hard to diagnose problems with your application.
        /// </summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_SetMainReady")]
        public static extern void SetMainReady();

        /* Use this function with UWP to call your C# Main() function! */
        /// <summary>
        /// Binding info:
        /// Use this function with UWP to call your C# Main() function!
        /// </summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_WinRTRunApp")]
        public static extern int WinRTRunApp(
            MainFunction mainFunction,
            IntPtr reserved
        );

        /* Use this function with iOS to call your C# Main() function!
		 * Only available in SDL 2.0.10 or higher.
		 */
        /// <summary>
        /// Binding info:
        /// Use this function with iOS to call your C# Main() function!
        /// Only available in SDL 2.0.10 or higher.
        /// </summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_UIKitRunApp")]
        public static extern int UIKitRunApp(
            int argc,
            IntPtr argv,
            MainFunction mainFunction
        );
    }
    #endregion
}
