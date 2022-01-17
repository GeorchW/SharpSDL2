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
    #region joystick.h
    enum JoystickHat : byte
    {
        Centered = 0x00,
        Up = 0x01,
        Right = 0x02,
        Down = 0x04,
        Left = 0x08,
        RightUp = Right | Up,
        RightDown = Right | Down,
        LeftUp = Left | Up,
        LeftDown = Left | Down,
    }

    public enum JoystickPowerLevel
    {
        Unknown = -1,
        Empty,
        Low,
        Medium,
        Full,
        Wired,
        Max
    }

    public enum JoystickType
    {
        Unknown,
        Gamecontroller,
        Wheel,
        ArcadeStick,
        FlightStick,
        DancePad,
        Guitar,
        DrumKit,
        ArcadePad
    }
    public static partial class SDL
    {

        /* joystick refers to an Joystick*.
		 * This function is only available in 2.0.9 or higher.
		 */
        /// <summary>
        /// Trigger a rumble effect Each call to this function cancels any previous rumble effect, and calling it with 0 intensity stops any rumbling.
        /// 
        /// Binding info:
        /// joystick refers to an Joystick*.
        /// This function is only available in 2.0.9 or higher.
        /// </summary>
        /// <param name="joystick">The joystick to vibrate</param>
        /// <param name="low_frequency_rumble">The intensity of the low frequency (left) rumble motor, from 0 to 0xFFFF</param>
        /// <param name="high_frequency_rumble">The intensity of the high frequency (right) rumble motor, from 0 to 0xFFFF</param>
        /// <param name="duration_ms">The duration of the rumble effect, in milliseconds</param>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_JoystickRumble")]
        public static extern int JoystickRumble(
            IntPtr joystick,
            ushort low_frequency_rumble,
            ushort high_frequency_rumble,
            uint duration_ms
        );

        /* joystick refers to an Joystick* */
        /// <summary>
        /// Close a joystick previously opened with .
        /// 
        /// Binding info:
        /// joystick refers to an Joystick*
        /// </summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_JoystickClose")]
        public static extern void JoystickClose(IntPtr joystick);

        /// <summary>Enable/disable joystick event polling.If joystick events are disabled, you must call  yourself and check the state of the joystick when you want joystick information.The state can be one of ,  or .</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_JoystickEventState")]
        public static extern int JoystickEventState(int state);

        /* joystick refers to an Joystick* */
        /// <summary>
        /// Get the current state of an axis control on a joystick.The state is a value ranging from -32768 to 32767.The axis indices start at index 0.
        /// 
        /// Binding info:
        /// joystick refers to an Joystick*
        /// </summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_JoystickGetAxis")]
        public static extern short JoystickGetAxis(
            IntPtr joystick,
            int axis
        );

        /* joystick refers to an Joystick*.
		 * This function is only available in 2.0.6 or higher.
		 */
        /// <summary>
        /// Get the initial state of an axis control on a joystick.The state is a value ranging from -32768 to 32767.The axis indices start at index 0.
        /// 
        /// Binding info:
        /// joystick refers to an Joystick*.
        /// This function is only available in 2.0.6 or higher.
        /// </summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_JoystickGetAxisInitialState")]
        public static extern bool JoystickGetAxisInitialState(
            IntPtr joystick,
            int axis,
            out ushort state
        );

        /* joystick refers to an Joystick* */
        /// <summary>
        /// Get the ball axis change since the last poll.
        /// The ball indices start at index 0.
        /// 
        /// Binding info:
        /// joystick refers to an Joystick*
        /// </summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_JoystickGetBall")]
        public static extern int JoystickGetBall(
            IntPtr joystick,
            int ball,
            out int dx,
            out int dy
        );

        /* joystick refers to an Joystick* */
        /// <summary>
        /// Get the current state of a button on a joystick.The button indices start at index 0.
        /// 
        /// Binding info:
        /// joystick refers to an Joystick*
        /// </summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_JoystickGetButton")]
        public static extern byte JoystickGetButton(
            IntPtr joystick,
            int button
        );

        /* joystick refers to an Joystick* */
        /// <summary>
        /// Get the current state of a POV hat on a joystick.The hat indices start at index 0.
        /// 
        /// Binding info:
        /// joystick refers to an Joystick*
        /// </summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_JoystickGetHat")]
        public static extern byte JoystickGetHat(
            IntPtr joystick,
            int hat
        );

        /* joystick refers to an Joystick* */
        /// <summary>
        /// Return the name for this currently opened joystick. If no name can be found, this function returns NULL.
        /// 
        /// Binding info:
        /// joystick refers to an Joystick*
        /// </summary>
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

        /// <summary>Get the implementation dependent name of a joystick. This can be called before any joysticks are opened. If no name can be found, this function returns NULL.</summary>
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
        /// <summary>
        /// Get the number of general axis controls on a joystick.
        /// 
        /// Binding info:
        /// joystick refers to an Joystick*
        /// </summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_JoystickNumAxes")]
        public static extern int JoystickNumAxes(IntPtr joystick);

        /* joystick refers to an Joystick* */
        /// <summary>
        /// Get the number of trackballs on a joystick.Joystick trackballs have only relative motion events associated with them and their state cannot be polled.
        /// 
        /// Binding info:
        /// joystick refers to an Joystick*
        /// </summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_JoystickNumBalls")]
        public static extern int JoystickNumBalls(IntPtr joystick);

        /* joystick refers to an Joystick* */
        /// <summary>
        /// Get the number of buttons on a joystick.
        /// 
        /// Binding info:
        /// joystick refers to an Joystick*
        /// </summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_JoystickNumButtons")]
        public static extern int JoystickNumButtons(IntPtr joystick);

        /* joystick refers to an Joystick* */
        /// <summary>
        /// Get the number of POV hats on a joystick.
        /// 
        /// Binding info:
        /// joystick refers to an Joystick*
        /// </summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_JoystickNumHats")]
        public static extern int JoystickNumHats(IntPtr joystick);

        /* IntPtr refers to an Joystick* */
        /// <summary>
        /// Open a joystick for use. The index passed as an argument refers to the N'th joystick on the system. This index is not the value which will identify this joystick in future joystick events. The joystick's instance id () will be used there instead.
        /// 
        /// Binding info:
        /// IntPtr refers to an Joystick*
        /// </summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_JoystickOpen")]
        public static extern IntPtr JoystickOpen(int device_index);

        /* joystick refers to an Joystick* */
        /// <summary>
        /// Update the current state of the open joysticks.This is called automatically by the event loop if any joystick events are enabled.
        /// 
        /// Binding info:
        /// joystick refers to an Joystick*
        /// </summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_JoystickUpdate")]
        public static extern void JoystickUpdate();

        /* joystick refers to an Joystick* */
        /// <summary>
        /// Count the number of joysticks attached to the system right now
        /// 
        /// Binding info:
        /// joystick refers to an Joystick*
        /// </summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_NumJoysticks")]
        public static extern int NumJoysticks();

        /// <summary>Return the GUID for the joystick at this index This can be called before any joysticks are opened.</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_JoystickGetDeviceGUID")]
        public static extern Guid JoystickGetDeviceGUID(
            int device_index
        );

        /* joystick refers to an Joystick* */
        /// <summary>
        /// Return the GUID for this opened joystick
        /// 
        /// Binding info:
        /// joystick refers to an Joystick*
        /// </summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_JoystickGetGUID")]
        public static extern Guid JoystickGetGUID(
            IntPtr joystick
        );

        /// <summary>Return a string representation for this guid. pszGUID must point to at least 33 bytes (32 for the string plus a NULL terminator).</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_JoystickGetGUIDString")]
        public static extern void JoystickGetGUIDString(
            Guid guid,
            byte[] pszGUID,
            int cbGUID
        );

        /// <summary>Convert a string into a joystick guid</summary>
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
        /// <summary>
        /// Get the USB vendor ID of a joystick, if available. This can be called before any joysticks are opened. If the vendor ID isn't available this function returns 0.
        /// 
        /// Binding info:
        /// This function is only available in 2.0.6 or higher.
        /// </summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_JoystickGetDeviceVendor")]
        public static extern ushort JoystickGetDeviceVendor(int device_index);

        /* This function is only available in 2.0.6 or higher. */
        /// <summary>
        /// Get the USB product ID of a joystick, if available. This can be called before any joysticks are opened. If the product ID isn't available this function returns 0.
        /// 
        /// Binding info:
        /// This function is only available in 2.0.6 or higher.
        /// </summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_JoystickGetDeviceProduct")]
        public static extern ushort JoystickGetDeviceProduct(int device_index);

        /* This function is only available in 2.0.6 or higher. */
        /// <summary>
        /// Get the product version of a joystick, if available. This can be called before any joysticks are opened. If the product version isn't available this function returns 0.
        /// 
        /// Binding info:
        /// This function is only available in 2.0.6 or higher.
        /// </summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_JoystickGetDeviceProductVersion")]
        public static extern ushort JoystickGetDeviceProductVersion(int device_index);

        /* This function is only available in 2.0.6 or higher. */
        /// <summary>
        /// Get the type of a joystick, if available. This can be called before any joysticks are opened.
        /// 
        /// Binding info:
        /// This function is only available in 2.0.6 or higher.
        /// </summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_JoystickGetDeviceType")]
        public static extern JoystickType JoystickGetDeviceType(int device_index);

        /* int refers to an JoystickID.
		 * This function is only available in 2.0.6 or higher.
		 */
        /// <summary>
        /// Get the instance ID of a joystick. This can be called before any joysticks are opened. If the index is out of range, this function will return -1.
        /// 
        /// Binding info:
        /// int refers to an JoystickID.
        /// This function is only available in 2.0.6 or higher.
        /// </summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_JoystickGetDeviceInstanceID")]
        public static extern int JoystickGetDeviceInstanceID(int device_index);

        /* joystick refers to an Joystick*.
		 * This function is only available in 2.0.6 or higher.
		 */
        /// <summary>
        /// Get the USB vendor ID of an opened joystick, if available. If the vendor ID isn't available this function returns 0.
        /// 
        /// Binding info:
        /// joystick refers to an Joystick*.
        /// This function is only available in 2.0.6 or higher.
        /// </summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_JoystickGetVendor")]
        public static extern ushort JoystickGetVendor(IntPtr joystick);

        /* joystick refers to an Joystick*.
		 * This function is only available in 2.0.6 or higher.
		 */
        /// <summary>
        /// Get the USB product ID of an opened joystick, if available. If the product ID isn't available this function returns 0.
        /// 
        /// Binding info:
        /// joystick refers to an Joystick*.
        /// This function is only available in 2.0.6 or higher.
        /// </summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_JoystickGetProduct")]
        public static extern ushort JoystickGetProduct(IntPtr joystick);

        /* joystick refers to an Joystick*.
		 * This function is only available in 2.0.6 or higher.
		 */
        /// <summary>
        /// Get the product version of an opened joystick, if available. If the product version isn't available this function returns 0.
        /// 
        /// Binding info:
        /// joystick refers to an Joystick*.
        /// This function is only available in 2.0.6 or higher.
        /// </summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_JoystickGetProductVersion")]
        public static extern ushort JoystickGetProductVersion(IntPtr joystick);

        /* joystick refers to an Joystick*.
		 * This function is only available in 2.0.6 or higher.
		 */
        /// <summary>
        /// Get the type of an opened joystick.
        /// 
        /// Binding info:
        /// joystick refers to an Joystick*.
        /// This function is only available in 2.0.6 or higher.
        /// </summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_JoystickGetType")]
        public static extern JoystickType JoystickGetType(IntPtr joystick);

        /* joystick refers to an Joystick* */
        /// <summary>
        /// Returns SDL_TRUE if the joystick has been opened and currently connected, or SDL_FALSE if it has not.
        /// 
        /// Binding info:
        /// joystick refers to an Joystick*
        /// </summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_JoystickGetAttached")]
        public static extern bool JoystickGetAttached(IntPtr joystick);

        /* int refers to an JoystickID, joystick to an Joystick* */
        /// <summary>
        /// Get the instance ID of an opened joystick or -1 if the joystick is invalid.
        /// 
        /// Binding info:
        /// int refers to an JoystickID, joystick to an Joystick*
        /// </summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_JoystickInstanceID")]
        public static extern int JoystickInstanceID(IntPtr joystick);

        /* joystick refers to an Joystick*.
		 * This function is only available in 2.0.4 or higher.
		 */
        /// <summary>
        /// Return the battery level of this joystick
        /// 
        /// Binding info:
        /// joystick refers to an Joystick*.
        /// This function is only available in 2.0.4 or higher.
        /// </summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_JoystickCurrentPowerLevel")]
        public static extern JoystickPowerLevel JoystickCurrentPowerLevel(
            IntPtr joystick
        );

        /* int refers to an JoystickID, IntPtr to an Joystick*.
		 * This function is only available in 2.0.4 or higher.
		 */
        /// <summary>
        /// Return the SDL_Joystick associated with an instance id.
        /// 
        /// Binding info:
        /// int refers to an JoystickID, IntPtr to an Joystick*.
        /// This function is only available in 2.0.4 or higher.
        /// </summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_JoystickFromInstanceID")]
        public static extern IntPtr JoystickFromInstanceID(int joyid);

        /* Only available in 2.0.7 */
        /// <summary>
        /// Locking for multi-threaded access to the joystick APIIf you are using the joystick API or handling events from multiple threads you should use these locking functions to protect access to the joysticks.In particular, you are guaranteed that the joystick list won't change, so the API functions that take a joystick index will be valid, and joystick and game controller events will not be delivered.
        /// 
        /// Binding info:
        /// Only available in 2.0.7
        /// </summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_LockJoysticks")]
        public static extern void LockJoysticks();

        /* Only available in 2.0.7 */
        /// <summary>
        /// 
        /// 
        /// Binding info:
        /// Only available in 2.0.7
        /// </summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_UnlockJoysticks")]
        public static extern void UnlockJoysticks();
    }
    #endregion
}
