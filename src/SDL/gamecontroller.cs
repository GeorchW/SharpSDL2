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
    #region gamecontroller.h
    public enum GameControllerBindType
    {
        None,
        Button,
        Axis,
        Hat
    }

    public enum GameControllerAxis
    {
        Invalid = -1,
        LeftX,
        LeftY,
        RightX,
        RightY,
        TriggerLeft,
        TriggerRight,
        Max
    }

    public enum GameControllerButton
    {
        Invalid = -1,
        A,
        B,
        X,
        Y,
        Back,
        Guide,
        Start,
        LeftStick,
        RightStick,
        LeftShoulder,
        RightShoulder,
        DpadUp,
        DpadDown,
        DpadLeft,
        DpadRight,
        Max,
    }

    // FIXME: I'd rather this somehow be private...
    [StructLayout(LayoutKind.Sequential)]
    public struct INTERNAL_GameControllerButtonBind_hat
    {
        public int Hat;
        public int HatMask;
    }

    // FIXME: I'd rather this somehow be private...
    [StructLayout(LayoutKind.Explicit)]
    public struct INTERNAL_GameControllerButtonBind_union
    {
        [FieldOffset(0)]
        public int Button;
        [FieldOffset(0)]
        public int Axis;
        [FieldOffset(0)]
        public INTERNAL_GameControllerButtonBind_hat Hat;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct GameControllerButtonBind
    {
        public GameControllerBindType BindType;
        public INTERNAL_GameControllerButtonBind_union Value;
    }
    public static partial class SDL
    {
        /* This exists to deal with C# being stupid about blittable types. */
        [StructLayout(LayoutKind.Sequential)]
        private struct INTERNAL_GameControllerButtonBind
        {
            public int BindType;
            /* Largest data type in the union is two ints in size */
            public int UnionVal0;
            public int UnionVal1;
        }

        /// <summary>Add or update an existing mapping configuration</summary>
        [DllImport(nativeLibName, EntryPoint = "SDL_GameControllerAddMapping", CallingConvention = CallingConvention.Cdecl)]
        private static extern int INTERNAL_GameControllerAddMapping(
            byte[] mappingString
        );
        public static int GameControllerAddMapping(
            string mappingString
        )
        {
            return INTERNAL_GameControllerAddMapping(
                UTF8_ToNative(mappingString)
            );
        }

        /* This function is only available in 2.0.6 or higher. */
        /// <summary>
        /// Get the number of mappings installed
        /// 
        /// Binding info:
        /// This function is only available in 2.0.6 or higher.
        /// </summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GameControllerNumMappings")]
        public static extern int GameControllerNumMappings();

        /* This function is only available in 2.0.6 or higher. */
        /// <summary>
        /// Get the mapping at a particular index.
        /// 
        /// Binding info:
        /// This function is only available in 2.0.6 or higher.
        /// </summary>
        [DllImport(nativeLibName, EntryPoint = "SDL_GameControllerMappingForIndex", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr INTERNAL_GameControllerMappingForIndex(int mapping_index);
        public static string GameControllerMappingForIndex(int mapping_index)
        {
            return UTF8_ToManaged(
                INTERNAL_GameControllerMappingForIndex(
                    mapping_index
                )
            );
        }

        /* THIS IS AN RWops FUNCTION! */
        /// <summary>
        /// To count the number of game controllers in the system for the following: int nJoysticks = ; int nGameControllers = 0; for (int i = 0; i < nJoysticks; i++) { if (SDL_IsGameController(i)) { nGameControllers++; } }Using the SDL_HINT_GAMECONTROLLERCONFIG hint or the  you can add support for controllers SDL is unaware of or cause an existing controller to have a different binding. The format is: guid,name,mappingsWhere GUID is the string value from , name is the human readable string for the device and mappings are controller mappings to joystick ones. Under Windows there is a reserved GUID of "xinput" that covers any XInput devices. The mapping format for joystick is: bX - a joystick button, index X hX.Y - hat X with value Y aX - axis X of the joystick Buttons can be used as a controller axis and vice versa.This string shows an example of a valid mapping for a controller "03000000341a00003608000000000000,PS3 Controller,a:b1,b:b2,y:b3,x:b0,start:b9,guide:b12,back:b8,dpup:h0.1,dpleft:h0.8,dpdown:h0.4,dpright:h0.2,leftshoulder:b4,rightshoulder:b5,leftstick:b10,rightstick:b11,leftx:a0,lefty:a1,rightx:a2,righty:a3,lefttrigger:b6,righttrigger:b7", Load a set of mappings from a seekable SDL data stream (memory or file), filtered by the current  A community sourced database of controllers is available at If  is non-zero, the stream will be closed after being read.
        /// 
        /// Binding info:
        /// THIS IS AN RWops FUNCTION!
        /// </summary>
        [DllImport(nativeLibName, EntryPoint = "SDL_GameControllerAddMappingsFromRW", CallingConvention = CallingConvention.Cdecl)]
        private static extern int INTERNAL_GameControllerAddMappingsFromRW(
            IntPtr rw,
            int freerw
        );
        public static int GameControllerAddMappingsFromFile(string file)
        {
            IntPtr rwops = RWFromFile(file, "rb");
            return INTERNAL_GameControllerAddMappingsFromRW(rwops, 1);
        }

        /// <summary>Get a mapping string for a GUID</summary>
        [DllImport(nativeLibName, EntryPoint = "SDL_GameControllerMappingForGUID", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr INTERNAL_GameControllerMappingForGUID(
            Guid guid
        );
        public static string GameControllerMappingForGUID(Guid guid)
        {
            return UTF8_ToManaged(
                INTERNAL_GameControllerMappingForGUID(guid)
            );
        }

        /* gamecontroller refers to an GameController* */
        /// <summary>
        /// Get a mapping string for an open GameController
        /// 
        /// Binding info:
        /// gamecontroller refers to an GameController*
        /// </summary>
        [DllImport(nativeLibName, EntryPoint = "SDL_GameControllerMapping", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr INTERNAL_GameControllerMapping(
            IntPtr gamecontroller
        );
        public static string GameControllerMapping(
            IntPtr gamecontroller
        )
        {
            return UTF8_ToManaged(
                INTERNAL_GameControllerMapping(
                    gamecontroller
                )
            );
        }

        /// <summary>Is the joystick on this index supported by the game controller interface?</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_IsGameController")]
        public static extern bool IsGameController(int joystick_index);

        /// <summary>Get the implementation dependent name of a game controller. This can be called before any controllers are opened. If no name can be found, this function returns NULL.</summary>
        [DllImport(nativeLibName, EntryPoint = "SDL_GameControllerNameForIndex", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr INTERNAL_GameControllerNameForIndex(
            int joystick_index
        );
        public static string GameControllerNameForIndex(
            int joystick_index
        )
        {
            return UTF8_ToManaged(
                INTERNAL_GameControllerNameForIndex(joystick_index)
            );
        }

        /* Only available in 2.0.9 or higher */
        /// <summary>
        /// Get the mapping of a game controller. This can be called before any controllers are opened.
        /// 
        /// Binding info:
        /// Only available in 2.0.9 or higher
        /// </summary>
        [DllImport(nativeLibName, EntryPoint = "SDL_GameControllerMappingForDeviceIndex", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr INTERNAL_GameControllerMappingForDeviceIndex(
            int joystick_index
        );
        public static string GameControllerMappingForDeviceIndex(
            int joystick_index
        )
        {
            return UTF8_ToManaged(
                INTERNAL_GameControllerMappingForDeviceIndex(joystick_index)
            );
        }

        /* IntPtr refers to an GameController* */
        /// <summary>
        /// Open a game controller for use. The index passed as an argument refers to the N'th game controller on the system. This index is not the value which will identify this controller in future controller events. The joystick's instance id () will be used there instead.
        /// 
        /// Binding info:
        /// IntPtr refers to an GameController*
        /// </summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GameControllerOpen")]
        public static extern IntPtr GameControllerOpen(int joystick_index);

        /* gamecontroller refers to an GameController* */
        /// <summary>
        /// Return the name for this currently opened controller
        /// 
        /// Binding info:
        /// gamecontroller refers to an GameController*
        /// </summary>
        [DllImport(nativeLibName, EntryPoint = "SDL_GameControllerName", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr INTERNAL_GameControllerName(
            IntPtr gamecontroller
        );
        public static string GameControllerName(
            IntPtr gamecontroller
        )
        {
            return UTF8_ToManaged(
                INTERNAL_GameControllerName(gamecontroller)
            );
        }

        /* gamecontroller refers to an GameController*.
		 * This function is only available in 2.0.6 or higher.
		 */
        /// <summary>
        /// Get the USB vendor ID of an opened controller, if available. If the vendor ID isn't available this function returns 0.
        /// 
        /// Binding info:
        /// gamecontroller refers to an GameController*.
        /// This function is only available in 2.0.6 or higher.
        /// </summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GameControllerGetVendor")]
        public static extern ushort GameControllerGetVendor(
            IntPtr gamecontroller
        );

        /* gamecontroller refers to an GameController*.
		 * This function is only available in 2.0.6 or higher.
		 */
        /// <summary>
        /// Get the USB product ID of an opened controller, if available. If the product ID isn't available this function returns 0.
        /// 
        /// Binding info:
        /// gamecontroller refers to an GameController*.
        /// This function is only available in 2.0.6 or higher.
        /// </summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GameControllerGetProduct")]
        public static extern ushort GameControllerGetProduct(
            IntPtr gamecontroller
        );

        /* gamecontroller refers to an GameController*.
		 * This function is only available in 2.0.6 or higher.
		 */
        /// <summary>
        /// Get the product version of an opened controller, if available. If the product version isn't available this function returns 0.
        /// 
        /// Binding info:
        /// gamecontroller refers to an GameController*.
        /// This function is only available in 2.0.6 or higher.
        /// </summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GameControllerGetProductVersion")]
        public static extern ushort GameControllerGetProductVersion(
            IntPtr gamecontroller
        );

        /* gamecontroller refers to an GameController* */
        /// <summary>
        /// Returns SDL_TRUE if the controller has been opened and currently connected, or SDL_FALSE if it has not.
        /// 
        /// Binding info:
        /// gamecontroller refers to an GameController*
        /// </summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GameControllerGetAttached")]
        public static extern bool GameControllerGetAttached(
            IntPtr gamecontroller
        );

        /* IntPtr refers to an Joystick*
		 * gamecontroller refers to an GameController*
		 */
        /// <summary>
        /// Get the underlying joystick object used by a controller
        /// 
        /// Binding info:
        /// IntPtr refers to an Joystick*
        /// gamecontroller refers to an GameController*
        /// </summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GameControllerGetJoystick")]
        public static extern IntPtr GameControllerGetJoystick(
            IntPtr gamecontroller
        );

        /// <summary>Enable/disable controller event polling.If controller events are disabled, you must call  yourself and check the state of the controller when you want controller information.The state can be one of ,  or .</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GameControllerEventState")]
        public static extern int GameControllerEventState(int state);

        /// <summary>Update the current state of the open game controllers.This is called automatically by the event loop if any game controller events are enabled.</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GameControllerUpdate")]
        public static extern void GameControllerUpdate();

        /// <summary>turn this string into a axis mapping</summary>
        [DllImport(nativeLibName, EntryPoint = "SDL_GameControllerGetAxisFromString", CallingConvention = CallingConvention.Cdecl)]
        private static extern GameControllerAxis INTERNAL_GameControllerGetAxisFromString(
            byte[] pchString
        );
        public static GameControllerAxis GameControllerGetAxisFromString(
            string pchString
        )
        {
            return INTERNAL_GameControllerGetAxisFromString(
                UTF8_ToNative(pchString)
            );
        }

        /// <summary>turn this axis enum into a string mapping</summary>
        [DllImport(nativeLibName, EntryPoint = "SDL_GameControllerGetStringForAxis", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr INTERNAL_GameControllerGetStringForAxis(
            GameControllerAxis axis
        );
        public static string GameControllerGetStringForAxis(
            GameControllerAxis axis
        )
        {
            return UTF8_ToManaged(
                INTERNAL_GameControllerGetStringForAxis(
                    axis
                )
            );
        }

        /* gamecontroller refers to an GameController* */
        /// <summary>
        /// Get the SDL joystick layer binding for this controller button mapping
        /// 
        /// Binding info:
        /// gamecontroller refers to an GameController*
        /// </summary>
        [DllImport(nativeLibName, EntryPoint = "SDL_GameControllerGetBindForAxis", CallingConvention = CallingConvention.Cdecl)]
        private static extern INTERNAL_GameControllerButtonBind INTERNAL_GameControllerGetBindForAxis(
            IntPtr gamecontroller,
            GameControllerAxis axis
        );
        public static GameControllerButtonBind GameControllerGetBindForAxis(
            IntPtr gamecontroller,
            GameControllerAxis axis
        )
        {
            // This is guaranteed to never be null
            INTERNAL_GameControllerButtonBind dumb = INTERNAL_GameControllerGetBindForAxis(
                gamecontroller,
                axis
            );
            GameControllerButtonBind result = new GameControllerButtonBind();
            result.BindType = (GameControllerBindType)dumb.BindType;
            result.Value.Hat.Hat = dumb.UnionVal0;
            result.Value.Hat.HatMask = dumb.UnionVal1;
            return result;
        }

        /* gamecontroller refers to an GameController* */
        /// <summary>
        /// Get the current state of an axis control on a game controller.The state is a value ranging from -32768 to 32767 (except for the triggers, which range from 0 to 32767).The axis indices start at index 0.
        /// 
        /// Binding info:
        /// gamecontroller refers to an GameController*
        /// </summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GameControllerGetAxis")]
        public static extern short GameControllerGetAxis(
            IntPtr gamecontroller,
            GameControllerAxis axis
        );

        /// <summary>turn this string into a button mapping</summary>
        [DllImport(nativeLibName, EntryPoint = "SDL_GameControllerGetButtonFromString", CallingConvention = CallingConvention.Cdecl)]
        private static extern GameControllerButton INTERNAL_GameControllerGetButtonFromString(
            byte[] pchString
        );
        public static GameControllerButton GameControllerGetButtonFromString(
            string pchString
        )
        {
            return INTERNAL_GameControllerGetButtonFromString(
                UTF8_ToNative(pchString)
            );
        }

        /// <summary>turn this button enum into a string mapping</summary>
        [DllImport(nativeLibName, EntryPoint = "SDL_GameControllerGetStringForButton", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr INTERNAL_GameControllerGetStringForButton(
            GameControllerButton button
        );
        public static string GameControllerGetStringForButton(
            GameControllerButton button
        )
        {
            return UTF8_ToManaged(
                INTERNAL_GameControllerGetStringForButton(button)
            );
        }

        /* gamecontroller refers to an GameController* */
        /// <summary>
        /// Get the SDL joystick layer binding for this controller button mapping
        /// 
        /// Binding info:
        /// gamecontroller refers to an GameController*
        /// </summary>
        [DllImport(nativeLibName, EntryPoint = "SDL_GameControllerGetBindForButton", CallingConvention = CallingConvention.Cdecl)]
        private static extern INTERNAL_GameControllerButtonBind INTERNAL_GameControllerGetBindForButton(
            IntPtr gamecontroller,
            GameControllerButton button
        );
        public static GameControllerButtonBind GameControllerGetBindForButton(
            IntPtr gamecontroller,
            GameControllerButton button
        )
        {
            // This is guaranteed to never be null
            INTERNAL_GameControllerButtonBind dumb = INTERNAL_GameControllerGetBindForButton(
                gamecontroller,
                button
            );
            GameControllerButtonBind result = new GameControllerButtonBind();
            result.BindType = (GameControllerBindType)dumb.BindType;
            result.Value.Hat.Hat = dumb.UnionVal0;
            result.Value.Hat.HatMask = dumb.UnionVal1;
            return result;
        }

        /* gamecontroller refers to an GameController* */
        /// <summary>
        /// Get the current state of a button on a game controller.The button indices start at index 0.
        /// 
        /// Binding info:
        /// gamecontroller refers to an GameController*
        /// </summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GameControllerGetButton")]
        public static extern byte GameControllerGetButton(
            IntPtr gamecontroller,
            GameControllerButton button
        );

        /* gamecontroller refers to an GameController*.
		 * This function is only available in 2.0.9 or higher.
		 */
        /// <summary>
        /// Trigger a rumble effect Each call to this function cancels any previous rumble effect, and calling it with 0 intensity stops any rumbling.
        /// 
        /// Binding info:
        /// gamecontroller refers to an GameController*.
        /// This function is only available in 2.0.9 or higher.
        /// </summary>
        /// <param name="gamecontroller">The controller to vibrate</param>
        /// <param name="low_frequency_rumble">The intensity of the low frequency (left) rumble motor, from 0 to 0xFFFF</param>
        /// <param name="high_frequency_rumble">The intensity of the high frequency (right) rumble motor, from 0 to 0xFFFF</param>
        /// <param name="duration_ms">The duration of the rumble effect, in milliseconds</param>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GameControllerRumble")]
        public static extern int GameControllerRumble(
            IntPtr gamecontroller,
            UInt16 low_frequency_rumble,
            UInt16 high_frequency_rumble,
            UInt32 duration_ms
        );

        /* gamecontroller refers to an GameController* */
        /// <summary>
        /// Close a controller previously opened with .
        /// 
        /// Binding info:
        /// gamecontroller refers to an GameController*
        /// </summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GameControllerClose")]
        public static extern void GameControllerClose(
            IntPtr gamecontroller
        );

        /* int refers to an JoystickID, IntPtr to an GameController*.
		 * This function is only available in 2.0.4 or higher.
		 */
        /// <summary>
        /// Return the SDL_GameController associated with an instance id.
        /// 
        /// Binding info:
        /// int refers to an JoystickID, IntPtr to an GameController*.
        /// This function is only available in 2.0.4 or higher.
        /// </summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GameControllerFromInstanceID")]
        public static extern IntPtr GameControllerFromInstanceID(int joyid);

        #endregion
    }
}
