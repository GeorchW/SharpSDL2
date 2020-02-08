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


		#region touch.h

		public const uint TOUCH_MOUSEID = uint.MaxValue;

		public struct Finger
		{
			public long id; // FingerID
			public float x;
			public float y;
			public float pressure;
		}

		/* Only available in SDL 2.0.10 or higher. */
		public enum TouchDeviceType
		{
			Invalid = -1,
			Direct,            /* touch screen with window-relative coordinates */
			IndirectAbsolute, /* trackpad with absolute device coordinates */
			IndirectRelative  /* trackpad with screen cursor-relative coordinates */
		}

		/**
		 *  \brief Get the number of registered touch devices.
 		 */
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint="SDL_GetNumTouchDevices")]
		public static extern int GetNumTouchDevices();

		/**
		 *  \brief Get the touch ID with the given index, or 0 if the index is invalid.
		 */
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint="SDL_GetTouchDevice")]
		public static extern long GetTouchDevice(int index);

		/**
		 *  \brief Get the number of active fingers for a given touch device.
		 */
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint="SDL_GetNumTouchFingers")]
		public static extern int GetNumTouchFingers(long touchID);

		/**
		 *  \brief Get the finger object of the given touch, with the given index.
		 *  Returns pointer to Finger.
		 */
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint="SDL_GetTouchFinger")]
		public static extern IntPtr GetTouchFinger(long touchID, int index);

		/* Only available in SDL 2.0.10 or higher. */
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint="SDL_GetTouchDeviceType")]
		public static extern TouchDeviceType GetTouchDeviceType(Int64 touchID);

		#endregion
    }
}
