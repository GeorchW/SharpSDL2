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


		#region joystick.h

		public const byte HAT_CENTERED =	0x00;
		public const byte HAT_UP =		0x01;
		public const byte HAT_RIGHT =	0x02;
		public const byte HAT_DOWN =	0x04;
		public const byte HAT_LEFT =	0x08;
		public const byte HAT_RIGHTUP =	HAT_RIGHT | HAT_UP;
		public const byte HAT_RIGHTDOWN =	HAT_RIGHT | HAT_DOWN;
		public const byte HAT_LEFTUP =	HAT_LEFT | HAT_UP;
		public const byte HAT_LEFTDOWN =	HAT_LEFT | HAT_DOWN;

		public enum JoystickPowerLevel
		{
			JOYSTICK_POWER_UNKNOWN = -1,
			JOYSTICK_POWER_EMPTY,
			JOYSTICK_POWER_LOW,
			JOYSTICK_POWER_MEDIUM,
			JOYSTICK_POWER_FULL,
			JOYSTICK_POWER_WIRED,
			JOYSTICK_POWER_MAX
		}

		public enum JoystickType
		{
			JOYSTICK_TYPE_UNKNOWN,
			JOYSTICK_TYPE_GAMECONTROLLER,
			JOYSTICK_TYPE_WHEEL,
			JOYSTICK_TYPE_ARCADE_STICK,
			JOYSTICK_TYPE_FLIGHT_STICK,
			JOYSTICK_TYPE_DANCE_PAD,
			JOYSTICK_TYPE_GUITAR,
			JOYSTICK_TYPE_DRUM_KIT,
			JOYSTICK_TYPE_ARCADE_PAD
		}

		/* joystick refers to an Joystick*.
		 * This function is only available in 2.0.9 or higher.
		 */
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint="SDL_JoystickRumble")]
		public static extern int JoystickRumble(
			IntPtr joystick,
			UInt16 low_frequency_rumble,
			UInt16 high_frequency_rumble,
			UInt32 duration_ms
		);

		/* joystick refers to an Joystick* */
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint="SDL_JoystickClose")]
		public static extern void JoystickClose(IntPtr joystick);

		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint="SDL_JoystickEventState")]
		public static extern int JoystickEventState(int state);

		/* joystick refers to an Joystick* */
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint="SDL_JoystickGetAxis")]
		public static extern short JoystickGetAxis(
			IntPtr joystick,
			int axis
		);

		/* joystick refers to an Joystick*.
		 * This function is only available in 2.0.6 or higher.
		 */
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint="SDL_JoystickGetAxisInitialState")]
		public static extern bool JoystickGetAxisInitialState(
			IntPtr joystick,
			int axis,
			out ushort state
		);

		/* joystick refers to an Joystick* */
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint="SDL_JoystickGetBall")]
		public static extern int JoystickGetBall(
			IntPtr joystick,
			int ball,
			out int dx,
			out int dy
		);

		/* joystick refers to an Joystick* */
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint="SDL_JoystickGetButton")]
		public static extern byte JoystickGetButton(
			IntPtr joystick,
			int button
		);

		/* joystick refers to an Joystick* */
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint="SDL_JoystickGetHat")]
		public static extern byte JoystickGetHat(
			IntPtr joystick,
			int hat
		);

		/* joystick refers to an Joystick* */
		[DllImport(nativeLibName, EntryPoint = "SDL_JoystickName", CallingConvention = CallingConvention.Cdecl)]
		private static extern IntPtr INTERNAL_JoystickName(
			IntPtr joystick
		);
		public static string JoystickName(IntPtr joystick)
		{
			return UTF8_ToManaged(
				INTERNAL_JoystickName(joystick)
			);
		}

		[DllImport(nativeLibName, EntryPoint = "SDL_JoystickNameForIndex", CallingConvention = CallingConvention.Cdecl)]
		private static extern IntPtr INTERNAL_JoystickNameForIndex(
			int device_index
		);
		public static string JoystickNameForIndex(int device_index)
		{
			return UTF8_ToManaged(
				INTERNAL_JoystickNameForIndex(device_index)
			);
		}

		/* joystick refers to an Joystick* */
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint="SDL_JoystickNumAxes")]
		public static extern int JoystickNumAxes(IntPtr joystick);

		/* joystick refers to an Joystick* */
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint="SDL_JoystickNumBalls")]
		public static extern int JoystickNumBalls(IntPtr joystick);

		/* joystick refers to an Joystick* */
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint="SDL_JoystickNumButtons")]
		public static extern int JoystickNumButtons(IntPtr joystick);

		/* joystick refers to an Joystick* */
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint="SDL_JoystickNumHats")]
		public static extern int JoystickNumHats(IntPtr joystick);

		/* IntPtr refers to an Joystick* */
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint="SDL_JoystickOpen")]
		public static extern IntPtr JoystickOpen(int device_index);

		/* joystick refers to an Joystick* */
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint="SDL_JoystickUpdate")]
		public static extern void JoystickUpdate();

		/* joystick refers to an Joystick* */
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint="SDL_NumJoysticks")]
		public static extern int NumJoysticks();

		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint="SDL_JoystickGetDeviceGUID")]
		public static extern Guid JoystickGetDeviceGUID(
			int device_index
		);

		/* joystick refers to an Joystick* */
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint="SDL_JoystickGetGUID")]
		public static extern Guid JoystickGetGUID(
			IntPtr joystick
		);

		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint="SDL_JoystickGetGUIDString")]
		public static extern void JoystickGetGUIDString(
			Guid guid,
			byte[] pszGUID,
			int cbGUID
		);

		[DllImport(nativeLibName, EntryPoint = "SDL_JoystickGetGUIDFromString", CallingConvention = CallingConvention.Cdecl)]
		private static extern Guid INTERNAL_JoystickGetGUIDFromString(
			byte[] pchGUID
		);
		public static Guid JoystickGetGUIDFromString(string pchGuid)
		{
			return INTERNAL_JoystickGetGUIDFromString(
				UTF8_ToNative(pchGuid)
			);
		}

		/* This function is only available in 2.0.6 or higher. */
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint="SDL_JoystickGetDeviceVendor")]
		public static extern ushort JoystickGetDeviceVendor(int device_index);

		/* This function is only available in 2.0.6 or higher. */
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint="SDL_JoystickGetDeviceProduct")]
		public static extern ushort JoystickGetDeviceProduct(int device_index);

		/* This function is only available in 2.0.6 or higher. */
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint="SDL_JoystickGetDeviceProductVersion")]
		public static extern ushort JoystickGetDeviceProductVersion(int device_index);

		/* This function is only available in 2.0.6 or higher. */
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint="SDL_JoystickGetDeviceType")]
		public static extern JoystickType JoystickGetDeviceType(int device_index);

		/* int refers to an JoystickID.
		 * This function is only available in 2.0.6 or higher.
		 */
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint="SDL_JoystickGetDeviceInstanceID")]
		public static extern int JoystickGetDeviceInstanceID(int device_index);

		/* joystick refers to an Joystick*.
		 * This function is only available in 2.0.6 or higher.
		 */
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint="SDL_JoystickGetVendor")]
		public static extern ushort JoystickGetVendor(IntPtr joystick);

		/* joystick refers to an Joystick*.
		 * This function is only available in 2.0.6 or higher.
		 */
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint="SDL_JoystickGetProduct")]
		public static extern ushort JoystickGetProduct(IntPtr joystick);

		/* joystick refers to an Joystick*.
		 * This function is only available in 2.0.6 or higher.
		 */
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint="SDL_JoystickGetProductVersion")]
		public static extern ushort JoystickGetProductVersion(IntPtr joystick);

		/* joystick refers to an Joystick*.
		 * This function is only available in 2.0.6 or higher.
		 */
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint="SDL_JoystickGetType")]
		public static extern JoystickType JoystickGetType(IntPtr joystick);

		/* joystick refers to an Joystick* */
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint="SDL_JoystickGetAttached")]
		public static extern bool JoystickGetAttached(IntPtr joystick);

		/* int refers to an JoystickID, joystick to an Joystick* */
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint="SDL_JoystickInstanceID")]
		public static extern int JoystickInstanceID(IntPtr joystick);

		/* joystick refers to an Joystick*.
		 * This function is only available in 2.0.4 or higher.
		 */
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint="SDL_JoystickCurrentPowerLevel")]
		public static extern JoystickPowerLevel JoystickCurrentPowerLevel(
			IntPtr joystick
		);

		/* int refers to an JoystickID, IntPtr to an Joystick*.
		 * This function is only available in 2.0.4 or higher.
		 */
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint="SDL_JoystickFromInstanceID")]
		public static extern IntPtr JoystickFromInstanceID(int joyid);

		/* Only available in 2.0.7 */
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint="SDL_LockJoysticks")]
		public static extern void LockJoysticks();

		/* Only available in 2.0.7 */
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint="SDL_UnlockJoysticks")]
		public static extern void UnlockJoysticks();

		#endregion
    }
}
