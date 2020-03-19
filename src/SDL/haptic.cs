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
    #region haptic.h
    public enum HapticEffectType : ushort
    {
        Constant = (1 << 0),
        Sine = (1 << 1),
        Leftright = (1 << 2),
        Triangle = (1 << 3),
        Sawtoothup = (1 << 4),
        Sawtoothdown = (1 << 5),
        Spring = (1 << 7),
        Damper = (1 << 8),
        Inertia = (1 << 9),
        Friction = (1 << 10),
        Custom = (1 << 11),
        Gain = (1 << 12),
        Autocenter = (1 << 13),
        Status = (1 << 14),
        Pause = (1 << 15),
    }

    /* HapticDirection type */
    public enum HapticDirectionType : byte
    {
        Polar = 0,
        Cartesian = 1,
        Spherical = 2,
    }

    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct HapticDirection
    {
        public HapticDirectionType Type;
        public fixed int dir[3];
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct HapticConstant
    {
        // Header
        public HapticEffectType Type;
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
        public HapticEffectType Type;
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
        public HapticEffectType Type;
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
        public HapticEffectType Type;
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
        public HapticEffectType Type;
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
        public HapticEffectType Type;
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
        public HapticEffectType Type;
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
    public static partial class SDL
    {
        /* HapticRunEffect */
        public const uint HAPTIC_INFINITY = 4294967295U;

        /* haptic refers to an Haptic* */
        /// <summary>
        /// Closes a haptic device previously opened with SDL_HapticOpen().
        /// 
        /// Binding info:
        /// haptic refers to an Haptic*
        /// </summary>
        /// <param name="haptic">Haptic device to close.</param>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_HapticClose")]
        public static extern void HapticClose(IntPtr haptic);

        /* haptic refers to an Haptic* */
        /// <summary>
        /// Destroys a haptic effect on the device. 
        /// This will stop the effect if it's running. Effects are automatically destroyed when the device is closed.
        /// 
        /// Binding info:
        /// haptic refers to an Haptic*
        /// </summary>
        /// <param name="haptic">Device to destroy the effect on.</param>
        /// <param name="effect">Identifier of the effect to destroy.</param>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_HapticDestroyEffect")]
        public static extern void HapticDestroyEffect(
            IntPtr haptic,
            int effect
        );

        /* haptic refers to an Haptic* */
        /// <summary>
        /// Checks to see if effect is supported by haptic.
        /// 
        /// Binding info:
        /// haptic refers to an Haptic*
        /// </summary>
        /// <param name="haptic">Haptic device to check on.</param>
        /// <param name="effect">Effect to check to see if it is supported.</param>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_HapticEffectSupported")]
        public static extern int HapticEffectSupported(
            IntPtr haptic,
            ref HapticEffect effect
        );

        /* haptic refers to an Haptic* */
        /// <summary>
        /// Gets the status of the current effect on the haptic device. 
        /// Device must support the  feature.
        /// 
        /// Binding info:
        /// haptic refers to an Haptic*
        /// </summary>
        /// <param name="haptic">Haptic device to query the effect status on.</param>
        /// <param name="effect">Identifier of the effect to query its status.</param>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_HapticGetEffectStatus")]
        public static extern int HapticGetEffectStatus(
            IntPtr haptic,
            int effect
        );

        /* haptic refers to an Haptic* */
        /// <summary>
        /// Gets the index of a haptic device.
        /// 
        /// Binding info:
        /// haptic refers to an Haptic*
        /// </summary>
        /// <param name="haptic">Haptic device to get the index of.</param>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_HapticIndex")]
        public static extern int HapticIndex(IntPtr haptic);

        /* haptic refers to an Haptic* */
        /// <summary>
        /// Get the implementation dependent name of a haptic device. 
        /// This can be called before any joysticks are opened. If no name can be found, this function returns NULL.
        /// 
        /// Binding info:
        /// haptic refers to an Haptic*
        /// </summary>
        /// <param name="device_index">Index of the device to get its name.</param>
        [DllImport(nativeLibName, EntryPoint = "SDL_HapticName", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr INTERNAL_HapticName(int device_index);
        public static string HapticName(int device_index)
        {
            return UTF8_ToManaged(INTERNAL_HapticName(device_index));
        }

        /* haptic refers to an Haptic* */
        /// <summary>
        /// Creates a new haptic effect on the device.
        /// 
        /// Binding info:
        /// haptic refers to an Haptic*
        /// </summary>
        /// <param name="haptic">Haptic device to create the effect on.</param>
        /// <param name="effect">Properties of the effect to create.</param>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_HapticNewEffect")]
        public static extern int HapticNewEffect(
            IntPtr haptic,
            ref HapticEffect effect
        );

        /* haptic refers to an Haptic* */
        /// <summary>
        /// Gets the number of haptic axes the device has.
        /// 
        /// Binding info:
        /// haptic refers to an Haptic*
        /// </summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_HapticNumAxes")]
        public static extern int HapticNumAxes(IntPtr haptic);

        /* haptic refers to an Haptic* */
        /// <summary>
        /// Returns the number of effects a haptic device can store. 
        /// On some platforms this isn't fully supported, and therefore is an approximation. Always check to see if your created effect was actually created and do not rely solely on .
        /// 
        /// Binding info:
        /// haptic refers to an Haptic*
        /// </summary>
        /// <param name="haptic">The haptic device to query effect max.</param>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_HapticNumEffects")]
        public static extern int HapticNumEffects(IntPtr haptic);

        /* haptic refers to an Haptic* */
        /// <summary>
        /// Returns the number of effects a haptic device can play at the same time. 
        /// This is not supported on all platforms, but will always return a value. Added here for the sake of completeness.
        /// 
        /// Binding info:
        /// haptic refers to an Haptic*
        /// </summary>
        /// <param name="haptic">The haptic device to query maximum playing effects.</param>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_HapticNumEffectsPlaying")]
        public static extern int HapticNumEffectsPlaying(IntPtr haptic);

        /* IntPtr refers to an Haptic* */
        /// <summary>
        /// Opens a haptic device for use. 
        /// The index passed as an argument refers to the N'th haptic device on this system.When opening a haptic device, its gain will be set to maximum and autocenter will be disabled. To modify these values use  and .
        /// 
        /// Binding info:
        /// IntPtr refers to an Haptic*
        /// </summary>
        /// <param name="device_index">Index of the device to open.</param>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_HapticOpen")]
        public static extern IntPtr HapticOpen(int device_index);

        /// <summary>Checks if the haptic device at index has been opened.</summary>
        /// <param name="device_index">Index to check to see if it has been opened.</param>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_HapticOpened")]
        public static extern int HapticOpened(int device_index);

        /* IntPtr refers to an Haptic*, joystick to an Joystick* */
        /// <summary>
        /// Opens a haptic device for use from a joystick device. 
        /// You must still close the haptic device separately. It will not be closed with the joystick.When opening from a joystick you should first close the haptic device before closing the joystick device. If not, on some implementations the haptic device will also get unallocated and you'll be unable to use force feedback on that device.
        /// 
        /// Binding info:
        /// IntPtr refers to an Haptic*, joystick to an Joystick*
        /// </summary>
        /// <param name="joystick">Joystick to create a haptic device from.</param>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_HapticOpenFromJoystick")]
        public static extern IntPtr HapticOpenFromJoystick(
            IntPtr joystick
        );

        /* IntPtr refers to an Haptic* */
        /// <summary>
        /// Tries to open a haptic device from the current mouse.
        /// 
        /// Binding info:
        /// IntPtr refers to an Haptic*
        /// </summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_HapticOpenFromMouse")]
        public static extern IntPtr HapticOpenFromMouse();

        /* haptic refers to an Haptic* */
        /// <summary>
        /// Pauses a haptic device. 
        /// Device must support the  feature. Call  to resume playback.Do not modify the effects nor add new ones while the device is paused. That can cause all sorts of weird errors.
        /// 
        /// Binding info:
        /// haptic refers to an Haptic*
        /// </summary>
        /// <param name="haptic">Haptic device to pause.</param>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_HapticPause")]
        public static extern int HapticPause(IntPtr haptic);

        /* haptic refers to an Haptic* */
        /// <summary>
        /// Gets the haptic device's supported features in bitwise manner. 
        /// Example:
        /// 
        /// Binding info:
        /// haptic refers to an Haptic*
        /// </summary>
        /// <param name="haptic">The haptic device to query.</param>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_HapticQuery")]
        public static extern uint HapticQuery(IntPtr haptic);

        /* haptic refers to an Haptic* */
        /// <summary>
        /// Initializes the haptic device for simple rumble playback.
        /// 
        /// Binding info:
        /// haptic refers to an Haptic*
        /// </summary>
        /// <param name="haptic">Haptic device to initialize for simple rumble playback.</param>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_HapticRumbleInit")]
        public static extern int HapticRumbleInit(IntPtr haptic);

        /* haptic refers to an Haptic* */
        /// <summary>
        /// Runs simple rumble on a haptic device.
        /// 
        /// Binding info:
        /// haptic refers to an Haptic*
        /// </summary>
        /// <param name="haptic">Haptic device to play rumble effect on.</param>
        /// <param name="strength">Strength of the rumble to play as a 0-1 float value.</param>
        /// <param name="length">Length of the rumble to play in milliseconds.</param>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_HapticRumblePlay")]
        public static extern int HapticRumblePlay(
            IntPtr haptic,
            float strength,
            uint length
        );

        /* haptic refers to an Haptic* */
        /// <summary>
        /// Stops the simple rumble on a haptic device.
        /// 
        /// Binding info:
        /// haptic refers to an Haptic*
        /// </summary>
        /// <param name="haptic">Haptic to stop the rumble on.</param>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_HapticRumbleStop")]
        public static extern int HapticRumbleStop(IntPtr haptic);

        /* haptic refers to an Haptic* */
        /// <summary>
        /// Checks to see if rumble is supported on a haptic device.
        /// 
        /// Binding info:
        /// haptic refers to an Haptic*
        /// </summary>
        /// <param name="haptic">Haptic device to check to see if it supports rumble.</param>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_HapticRumbleSupported")]
        public static extern int HapticRumbleSupported(IntPtr haptic);

        /* haptic refers to an Haptic* */
        /// <summary>
        /// Runs the haptic effect on its associated haptic device. 
        /// If iterations are , it'll run the effect over and over repeating the envelope (attack and fade) every time. If you only want the effect to last forever, set  in the effect's length parameter.
        /// 
        /// Binding info:
        /// haptic refers to an Haptic*
        /// </summary>
        /// <param name="haptic">Haptic device to run the effect on.</param>
        /// <param name="effect">Identifier of the haptic effect to run.</param>
        /// <param name="iterations">Number of iterations to run the effect. Use SDL_HAPTIC_INFINITY for infinity.</param>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_HapticRunEffect")]
        public static extern int HapticRunEffect(
            IntPtr haptic,
            int effect,
            uint iterations
        );

        /* haptic refers to an Haptic* */
        /// <summary>
        /// Sets the global autocenter of the device. 
        /// Autocenter should be between 0 and 100. Setting it to 0 will disable autocentering.Device must support the  feature.
        /// 
        /// Binding info:
        /// haptic refers to an Haptic*
        /// </summary>
        /// <param name="haptic">Haptic device to set autocentering on.</param>
        /// <param name="autocenter">Value to set autocenter to, 0 disables autocentering.</param>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_HapticSetAutocenter")]
        public static extern int HapticSetAutocenter(
            IntPtr haptic,
            int autocenter
        );

        /* haptic refers to an Haptic* */
        /// <summary>
        /// Sets the global gain of the device. 
        /// Device must support the  feature.The user may specify the maximum gain by setting the environment variable SDL_HAPTIC_GAIN_MAX which should be between 0 and 100. All calls to  will scale linearly using SDL_HAPTIC_GAIN_MAX as the maximum.
        /// 
        /// Binding info:
        /// haptic refers to an Haptic*
        /// </summary>
        /// <param name="haptic">Haptic device to set the gain on.</param>
        /// <param name="gain">Value to set the gain to, should be between 0 and 100.</param>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_HapticSetGain")]
        public static extern int HapticSetGain(
            IntPtr haptic,
            int gain
        );

        /* haptic refers to an Haptic* */
        /// <summary>
        /// Stops all the currently playing effects on a haptic device.
        /// 
        /// Binding info:
        /// haptic refers to an Haptic*
        /// </summary>
        /// <param name="haptic">Haptic device to stop.</param>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_HapticStopAll")]
        public static extern int HapticStopAll(IntPtr haptic);

        /* haptic refers to an Haptic* */
        /// <summary>
        /// Stops the haptic effect on its associated haptic device.
        /// 
        /// Binding info:
        /// haptic refers to an Haptic*
        /// </summary>
        /// <param name="haptic">Haptic device to stop the effect on.</param>
        /// <param name="effect">Identifier of the effect to stop.</param>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_HapticStopEffect")]
        public static extern int HapticStopEffect(
            IntPtr haptic,
            int effect
        );

        /* haptic refers to an Haptic* */
        /// <summary>
        /// Unpauses a haptic device. 
        /// Call to unpause after .
        /// 
        /// Binding info:
        /// haptic refers to an Haptic*
        /// </summary>
        /// <param name="haptic">Haptic device to unpause.</param>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_HapticUnpause")]
        public static extern int HapticUnpause(IntPtr haptic);

        /* haptic refers to an Haptic* */
        /// <summary>
        /// Updates the properties of an effect. 
        /// Can be used dynamically, although behavior when dynamically changing direction may be strange. Specifically the effect may reupload itself and start playing from the start. You cannot change the type either when running .
        /// 
        /// Binding info:
        /// haptic refers to an Haptic*
        /// </summary>
        /// <param name="haptic">Haptic device that has the effect.</param>
        /// <param name="effect">Identifier of the effect to update.</param>
        /// <param name="data">New effect properties to use.</param>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_HapticUpdateEffect")]
        public static extern int HapticUpdateEffect(
            IntPtr haptic,
            int effect,
            ref HapticEffect data
        );

        /* joystick refers to an Joystick* */
        /// <summary>
        /// Checks to see if a joystick has haptic features.
        /// 
        /// Binding info:
        /// joystick refers to an Joystick*
        /// </summary>
        /// <param name="joystick">Joystick to test for haptic capabilities.</param>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_JoystickIsHaptic")]
        public static extern int JoystickIsHaptic(IntPtr joystick);

        /// <summary>Gets whether or not the current mouse has haptic capabilities.</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_MouseIsHaptic")]
        public static extern int MouseIsHaptic();

        /// <summary>Count the number of haptic devices attached to the system.</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_NumHaptics")]
        public static extern int NumHaptics();
    }
    #endregion
}
