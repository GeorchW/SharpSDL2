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


		#region main.h

		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint="SDL_SetMainReady")]
		public static extern void SetMainReady();

		/* This is used as a function pointer to a C main() function */
		public delegate int main_func(int argc, IntPtr argv);

		/* Use this function with UWP to call your C# Main() function! */
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint="SDL_WinRTRunApp")]
		public static extern int WinRTRunApp(
			main_func mainFunction,
			IntPtr reserved
		);

		/* Use this function with iOS to call your C# Main() function!
		 * Only available in SDL 2.0.10 or higher.
		 */
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint="SDL_UIKitRunApp")]
		public static extern int UIKitRunApp(
			int argc,
			IntPtr argv,
			main_func mainFunction
		);

		#endregion
    }
}
