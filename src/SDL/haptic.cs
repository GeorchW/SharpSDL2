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


		#region haptic.h

		/* HapticEffect type */
		public const ushort HAPTIC_CONSTANT =	(1 << 0);
		public const ushort HAPTIC_SINE =		(1 << 1);
		public const ushort HAPTIC_LEFTRIGHT =	(1 << 2);
		public const ushort HAPTIC_TRIANGLE =	(1 << 3);
		public const ushort HAPTIC_SAWTOOTHUP =	(1 << 4);
		public const ushort HAPTIC_SAWTOOTHDOWN =	(1 << 5);
		public const ushort HAPTIC_SPRING =		(1 << 7);
		public const ushort HAPTIC_DAMPER =		(1 << 8);
		public const ushort HAPTIC_INERTIA =	(1 << 9);
		public const ushort HAPTIC_FRICTION =	(1 << 10);
		public const ushort HAPTIC_CUSTOM =		(1 << 11);
		public const ushort HAPTIC_GAIN =		(1 << 12);
		public const ushort HAPTIC_AUTOCENTER =	(1 << 13);
		public const ushort HAPTIC_STATUS =		(1 << 14);
		public const ushort HAPTIC_PAUSE =		(1 << 15);

		/* HapticDirection type */
		public const byte HAPTIC_POLAR =		0;
		public const byte HAPTIC_CARTESIAN =	1;
		public const byte HAPTIC_SPHERICAL =	2;

		/* HapticRunEffect */
		public const uint HAPTIC_INFINITY = 4294967295U;

		[StructLayout(LayoutKind.Sequential)]
		public unsafe struct HapticDirection
		{
			public byte Type;
			public fixed int dir[3];
		}

		[StructLayout(LayoutKind.Sequential)]
		public struct HapticConstant
		{
			// Header
			public ushort Type;
			public HapticDirection Direction;
			// Replay
			public uint Length;
			public ushort Delay;
			// Trigger
			public ushort Button;
			public ushort Interval;
			// Constant
			public short Level;
			// Envelope
			public ushort AttackLength;
			public ushort AttackLevel;
			public ushort FadeLength;
			public ushort FadeLevel;
		}

		[StructLayout(LayoutKind.Sequential)]
		public struct HapticPeriodic
		{
			// Header
			public ushort Type;
			public HapticDirection Direction;
			// Replay
			public uint Length;
			public ushort Delay;
			// Trigger
			public ushort Button;
			public ushort Interval;
			// Periodic
			public ushort Period;
			public short Magnitude;
			public short Offset;
			public ushort Phase;
			// Envelope
			public ushort AttackLength;
			public ushort AttackLevel;
			public ushort FadeLength;
			public ushort FadeLevel;
		}

		[StructLayout(LayoutKind.Sequential)]
		public unsafe struct HapticCondition
		{
			// Header
			public ushort Type;
			public HapticDirection Direction;
			// Replay
			public uint Length;
			public ushort Delay;
			// Trigger
			public ushort Button;
			public ushort Interval;
			// Condition
			public fixed ushort RightSat[3];
			public fixed ushort LeftSat[3];
			public fixed short RightCoeff[3];
			public fixed short LeftCoeff[3];
			public fixed ushort Deadband[3];
			public fixed short Center[3];
		}

		[StructLayout(LayoutKind.Sequential)]
		public struct HapticRamp
		{
			// Header
			public ushort Type;
			public HapticDirection Direction;
			// Replay
			public uint Length;
			public ushort Delay;
			// Trigger
			public ushort Button;
			public ushort Interval;
			// Ramp
			public short Start;
			public short End;
			// Envelope
			public ushort AttackLength;
			public ushort AttackLevel;
			public ushort FadeLength;
			public ushort FadeLevel;
		}

		[StructLayout(LayoutKind.Sequential)]
		public struct HapticLeftRight
		{
			// Header
			public ushort Type;
			// Replay
			public uint Length;
			// Rumble
			public ushort LargeMagnitude;
			public ushort SmallMagnitude;
		}

		[StructLayout(LayoutKind.Sequential)]
		public struct HapticCustom
		{
			// Header
			public ushort Type;
			public HapticDirection Direction;
			// Replay
			public uint Length;
			public ushort Delay;
			// Trigger
			public ushort Button;
			public ushort Interval;
			// Custom
			public byte Channels;
			public ushort Period;
			public ushort Samples;
			public IntPtr Data; // Uint16*
			// Envelope
			public ushort AttackLength;
			public ushort AttackLevel;
			public ushort FadeLength;
			public ushort FadeLevel;
		}

		[StructLayout(LayoutKind.Explicit)]
		public struct HapticEffect
		{
			[FieldOffset(0)]
			public ushort Type;
			[FieldOffset(0)]
			public HapticConstant Constant;
			[FieldOffset(0)]
			public HapticPeriodic Periodic;
			[FieldOffset(0)]
			public HapticCondition Condition;
			[FieldOffset(0)]
			public HapticRamp Ramp;
			[FieldOffset(0)]
			public HapticLeftRight LeftRight;
			[FieldOffset(0)]
			public HapticCustom Custom;
		}

		/* haptic refers to an Haptic* */
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint="SDL_HapticClose")]
		public static extern void HapticClose(IntPtr haptic);

		/* haptic refers to an Haptic* */
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint="SDL_HapticDestroyEffect")]
		public static extern void HapticDestroyEffect(
			IntPtr haptic,
			int effect
		);

		/* haptic refers to an Haptic* */
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint="SDL_HapticEffectSupported")]
		public static extern int HapticEffectSupported(
			IntPtr haptic,
			ref HapticEffect effect
		);

		/* haptic refers to an Haptic* */
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint="SDL_HapticGetEffectStatus")]
		public static extern int HapticGetEffectStatus(
			IntPtr haptic,
			int effect
		);

		/* haptic refers to an Haptic* */
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint="SDL_HapticIndex")]
		public static extern int HapticIndex(IntPtr haptic);

		/* haptic refers to an Haptic* */
		[DllImport(nativeLibName, EntryPoint = "SDL_HapticName", CallingConvention = CallingConvention.Cdecl)]
		private static extern IntPtr INTERNAL_HapticName(int device_index);
		public static string HapticName(int device_index)
		{
			return UTF8_ToManaged(INTERNAL_HapticName(device_index));
		}

		/* haptic refers to an Haptic* */
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint="SDL_HapticNewEffect")]
		public static extern int HapticNewEffect(
			IntPtr haptic,
			ref HapticEffect effect
		);

		/* haptic refers to an Haptic* */
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint="SDL_HapticNumAxes")]
		public static extern int HapticNumAxes(IntPtr haptic);

		/* haptic refers to an Haptic* */
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint="SDL_HapticNumEffects")]
		public static extern int HapticNumEffects(IntPtr haptic);

		/* haptic refers to an Haptic* */
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint="SDL_HapticNumEffectsPlaying")]
		public static extern int HapticNumEffectsPlaying(IntPtr haptic);

		/* IntPtr refers to an Haptic* */
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint="SDL_HapticOpen")]
		public static extern IntPtr HapticOpen(int device_index);

		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint="SDL_HapticOpened")]
		public static extern int HapticOpened(int device_index);

		/* IntPtr refers to an Haptic*, joystick to an Joystick* */
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint="SDL_HapticOpenFromJoystick")]
		public static extern IntPtr HapticOpenFromJoystick(
			IntPtr joystick
		);

		/* IntPtr refers to an Haptic* */
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint="SDL_HapticOpenFromMouse")]
		public static extern IntPtr HapticOpenFromMouse();

		/* haptic refers to an Haptic* */
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint="SDL_HapticPause")]
		public static extern int HapticPause(IntPtr haptic);

		/* haptic refers to an Haptic* */
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint="SDL_HapticQuery")]
		public static extern uint HapticQuery(IntPtr haptic);

		/* haptic refers to an Haptic* */
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint="SDL_HapticRumbleInit")]
		public static extern int HapticRumbleInit(IntPtr haptic);

		/* haptic refers to an Haptic* */
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint="SDL_HapticRumblePlay")]
		public static extern int HapticRumblePlay(
			IntPtr haptic,
			float strength,
			uint length
		);

		/* haptic refers to an Haptic* */
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint="SDL_HapticRumbleStop")]
		public static extern int HapticRumbleStop(IntPtr haptic);

		/* haptic refers to an Haptic* */
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint="SDL_HapticRumbleSupported")]
		public static extern int HapticRumbleSupported(IntPtr haptic);

		/* haptic refers to an Haptic* */
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint="SDL_HapticRunEffect")]
		public static extern int HapticRunEffect(
			IntPtr haptic,
			int effect,
			uint iterations
		);

		/* haptic refers to an Haptic* */
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint="SDL_HapticSetAutocenter")]
		public static extern int HapticSetAutocenter(
			IntPtr haptic,
			int autocenter
		);

		/* haptic refers to an Haptic* */
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint="SDL_HapticSetGain")]
		public static extern int HapticSetGain(
			IntPtr haptic,
			int gain
		);

		/* haptic refers to an Haptic* */
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint="SDL_HapticStopAll")]
		public static extern int HapticStopAll(IntPtr haptic);

		/* haptic refers to an Haptic* */
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint="SDL_HapticStopEffect")]
		public static extern int HapticStopEffect(
			IntPtr haptic,
			int effect
		);

		/* haptic refers to an Haptic* */
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint="SDL_HapticUnpause")]
		public static extern int HapticUnpause(IntPtr haptic);

		/* haptic refers to an Haptic* */
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint="SDL_HapticUpdateEffect")]
		public static extern int HapticUpdateEffect(
			IntPtr haptic,
			int effect,
			ref HapticEffect data
		);

		/* joystick refers to an Joystick* */
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint="SDL_JoystickIsHaptic")]
		public static extern int JoystickIsHaptic(IntPtr joystick);

		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint="SDL_MouseIsHaptic")]
		public static extern int MouseIsHaptic();

		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint="SDL_NumHaptics")]
		public static extern int NumHaptics();

		#endregion
    }
}
