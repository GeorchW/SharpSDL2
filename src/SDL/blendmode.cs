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
    public static partial class SDL
    {


		#region blendmode.h

		[Flags]
		public enum BlendMode
		{
			BLENDMODE_NONE =	0x00000000,
			BLENDMODE_BLEND =	0x00000001,
			BLENDMODE_ADD =	0x00000002,
			BLENDMODE_MOD =	0x00000004,
			BLENDMODE_INVALID =	0x7FFFFFFF
		}

		public enum BlendOperation
		{
			BLENDOPERATION_ADD		= 0x1,
			BLENDOPERATION_SUBTRACT	= 0x2,
			BLENDOPERATION_REV_SUBTRACT	= 0x3,
			BLENDOPERATION_MINIMUM	= 0x4,
			BLENDOPERATION_MAXIMUM	= 0x5
		}

		public enum BlendFactor
		{
			BLENDFACTOR_ZERO			= 0x1,
			BLENDFACTOR_ONE			= 0x2,
			BLENDFACTOR_SRC_COLOR		= 0x3,
			BLENDFACTOR_ONE_MINUS_SRC_COLOR	= 0x4,
			BLENDFACTOR_SRC_ALPHA		= 0x5,
			BLENDFACTOR_ONE_MINUS_SRC_ALPHA	= 0x6,
			BLENDFACTOR_DST_COLOR		= 0x7,
			BLENDFACTOR_ONE_MINUS_DST_COLOR	= 0x8,
			BLENDFACTOR_DST_ALPHA		= 0x9,
			BLENDFACTOR_ONE_MINUS_DST_ALPHA	= 0xA
		}

		/* Only available in 2.0.6 */
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint="SDL_ComposeCustomBlendMode")]
		public static extern BlendMode ComposeCustomBlendMode(
			BlendFactor srcColorFactor,
			BlendFactor dstColorFactor,
			BlendOperation colorOperation,
			BlendFactor srcAlphaFactor,
			BlendFactor dstAlphaFactor,
			BlendOperation alphaOperation
		);

		#endregion
    }
}
