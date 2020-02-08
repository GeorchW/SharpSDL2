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


		#region error.h

		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint="SDL_ClearError")]
		public static extern void ClearError();

		[DllImport(nativeLibName, EntryPoint = "SDL_GetError", CallingConvention = CallingConvention.Cdecl)]
		private static extern IntPtr INTERNAL_GetError();
		public static string GetError()
		{
			return UTF8_ToManaged(INTERNAL_GetError());
		}

		/* Use string.Format for arglists */
		[DllImport(nativeLibName, EntryPoint = "SDL_SetError", CallingConvention = CallingConvention.Cdecl)]
		private static extern void INTERNAL_SetError(byte[] fmtAndArglist);
		public static void SetError(string fmtAndArglist)
		{
			INTERNAL_SetError(
				UTF8_ToNative(fmtAndArglist)
			);
		}

		#endregion
    }
}
