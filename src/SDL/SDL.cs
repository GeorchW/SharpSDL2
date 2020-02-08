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


		#region SDL.h

		public const uint INIT_TIMER =		0x00000001;
		public const uint INIT_AUDIO =		0x00000010;
		public const uint INIT_VIDEO =		0x00000020;
		public const uint INIT_JOYSTICK =		0x00000200;
		public const uint INIT_HAPTIC =		0x00001000;
		public const uint INIT_GAMECONTROLLER =	0x00002000;
		public const uint INIT_EVENTS =		0x00004000;
		public const uint INIT_SENSOR =		0x00008000;
		public const uint INIT_NOPARACHUTE =	0x00100000;
		public const uint INIT_EVERYTHING = (
			INIT_TIMER | INIT_AUDIO | INIT_VIDEO |
			INIT_EVENTS | INIT_JOYSTICK | INIT_HAPTIC |
			INIT_GAMECONTROLLER | INIT_SENSOR
		);

		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint="SDL_Init")]
		public static extern int Init(uint flags);

		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint="SDL_InitSubSystem")]
		public static extern int InitSubSystem(uint flags);

		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint="SDL_Quit")]
		public static extern void Quit();

		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint="SDL_QuitSubSystem")]
		public static extern void QuitSubSystem(uint flags);

		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint="SDL_WasInit")]
		public static extern uint WasInit(uint flags);

		#endregion
    }
}
