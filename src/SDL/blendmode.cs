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
    #region blendmode.h

    [Flags]
    public enum BlendMode
    {
        None = 0x00000000,
        Blend = 0x00000001,
        Add = 0x00000002,
        Mod = 0x00000004,
        Invalid = 0x7Fffffff
    }

    public enum BlendOperation
    {
        Add = 0x1,
        Subtract = 0x2,
        RevSubtract = 0x3,
        Minimum = 0x4,
        Maximum = 0x5
    }

    public enum BlendFactor
    {
        Zero = 0x1,
        One = 0x2,
        SrcColor = 0x3,
        OneMinusSrcColor = 0x4,
        SrcAlpha = 0x5,
        OneMinusSrcAlpha = 0x6,
        DstColor = 0x7,
        OneMinusDstColor = 0x8,
        DstAlpha = 0x9,
        OneMinusDstAlpha = 0xA
    }

    public static partial class SDL
    {
        /* Only available in 2.0.6 */
        /// <summary>
        /// Create a custom blend mode, which may or may not be supported by a given renderer. 
        /// The result of the blend mode operation will be: dstRGB = dstRGB * dstColorFactor colorOperation srcRGB * srcColorFactor and dstA = dstA * dstAlphaFactor alphaOperation srcA * srcAlphaFactor
        /// 
        /// Binding info:
        /// Only available in 2.0.6
        /// </summary>
        /// <param name="srcColorFactor">source color factor</param>
        /// <param name="dstColorFactor">destination color factor</param>
        /// <param name="colorOperation">color operation</param>
        /// <param name="srcAlphaFactor">source alpha factor</param>
        /// <param name="dstAlphaFactor">destination alpha factor</param>
        /// <param name="alphaOperation">alpha operation</param>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_ComposeCustomBlendMode")]
        public static extern BlendMode ComposeCustomBlendMode(
            BlendFactor srcColorFactor,
            BlendFactor dstColorFactor,
            BlendOperation colorOperation,
            BlendFactor srcAlphaFactor,
            BlendFactor dstAlphaFactor,
            BlendOperation alphaOperation
        );
    }
    #endregion
}
