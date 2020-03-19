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
    #region timer.h
    public static partial class SDL
    {
        /* System timers rely on different OS mechanisms depending on
		 * which operating system SDL2 is compiled against.
		 */

        /* Compare tick values, return true if A has passed B. Introduced in SDL 2.0.1,
		 * but does not require it (it was a macro).
		 */
        public static bool TICKS_PASSED(UInt32 A, UInt32 B)
        {
            return ((Int32)(B - A) <= 0);
        }

        /* Delays the thread's processing based on the milliseconds parameter */
        /// <summary>
        /// Wait a specified number of milliseconds before returning.
        /// 
        /// Binding info:
        /// Delays the thread's processing based on the milliseconds parameter
        /// </summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_Delay")]
        public static extern void Delay(UInt32 ms);

        /* Returns the milliseconds that have passed since SDL was initialized */
        /// <summary>
        /// Get the number of milliseconds since the SDL library initialization.
        /// 
        /// Binding info:
        /// Returns the milliseconds that have passed since SDL was initialized
        /// </summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetTicks")]
        public static extern UInt32 GetTicks();

        /* Get the current value of the high resolution counter */
        /// <summary>
        /// Get the current value of the high resolution counter.
        /// 
        /// Binding info:
        /// Get the current value of the high resolution counter
        /// </summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetPerformanceCounter")]
        public static extern UInt64 GetPerformanceCounter();

        /* Get the count per second of the high resolution counter */
        /// <summary>
        /// Get the count per second of the high resolution counter.
        /// 
        /// Binding info:
        /// Get the count per second of the high resolution counter
        /// </summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetPerformanceFrequency")]
        public static extern UInt64 GetPerformanceFrequency();

        /* param refers to a void* */
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate UInt32 TimerCallback(UInt32 interval, IntPtr param);

        /* int refers to an TimerID, param to a void* */
        /// <summary>
        /// Add a new timer to the pool of timers already running.
        /// 
        /// Binding info:
        /// int refers to an TimerID, param to a void*
        /// </summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_AddTimer")]
        public static extern int AddTimer(
            UInt32 interval,
            TimerCallback callback,
            IntPtr param
        );

        /* id refers to an TimerID */
        /// <summary>
        /// Remove a timer knowing its ID.
        /// 
        /// Binding info:
        /// id refers to an TimerID
        /// </summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_RemoveTimer")]
        public static extern bool RemoveTimer(int id);
    }
    #endregion
}
