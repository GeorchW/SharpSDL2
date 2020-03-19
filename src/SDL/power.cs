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
    #region power.h
    public enum PowerState
    {
        Unknown = 0,
        OnBattery,
        NoBattery,
        Charging,
        Charged
    }

    public static partial class SDL
    {
        /// <summary>Get the current power supply details.</summary>
        /// <param name="secs">Seconds of battery life left. You can pass a NULL here if you don't care. Will return -1 if we can't determine a value, or we're not running on a battery.</param>
        /// <param name="pct">Percentage of battery life left, between 0 and 100. You can pass a NULL here if you don't care. Will return -1 if we can't determine a value, or we're not running on a battery.</param>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetPowerInfo")]
        public static extern PowerState GetPowerInfo(
            out int secs,
            out int pct
        );
    }
    #endregion
}
