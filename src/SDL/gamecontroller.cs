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


		#region gamecontroller.h

		public enum GameControllerBindType
		{
			CONTROLLER_BINDTYPE_NONE,
			CONTROLLER_BINDTYPE_BUTTON,
			CONTROLLER_BINDTYPE_AXIS,
			CONTROLLER_BINDTYPE_HAT
		}

		public enum GameControllerAxis
		{
			CONTROLLER_AXIS_INVALID = -1,
			CONTROLLER_AXIS_LEFTX,
			CONTROLLER_AXIS_LEFTY,
			CONTROLLER_AXIS_RIGHTX,
			CONTROLLER_AXIS_RIGHTY,
			CONTROLLER_AXIS_TRIGGERLEFT,
			CONTROLLER_AXIS_TRIGGERRIGHT,
			CONTROLLER_AXIS_MAX
		}

		public enum GameControllerButton
		{
			CONTROLLER_BUTTON_INVALID = -1,
			CONTROLLER_BUTTON_A,
			CONTROLLER_BUTTON_B,
			CONTROLLER_BUTTON_X,
			CONTROLLER_BUTTON_Y,
			CONTROLLER_BUTTON_BACK,
			CONTROLLER_BUTTON_GUIDE,
			CONTROLLER_BUTTON_START,
			CONTROLLER_BUTTON_LEFTSTICK,
			CONTROLLER_BUTTON_RIGHTSTICK,
			CONTROLLER_BUTTON_LEFTSHOULDER,
			CONTROLLER_BUTTON_RIGHTSHOULDER,
			CONTROLLER_BUTTON_DPAD_UP,
			CONTROLLER_BUTTON_DPAD_DOWN,
			CONTROLLER_BUTTON_DPAD_LEFT,
			CONTROLLER_BUTTON_DPAD_RIGHT,
			CONTROLLER_BUTTON_MAX,
		}

		// FIXME: I'd rather this somehow be private...
		[StructLayout(LayoutKind.Sequential)]
		public struct INTERNAL_GameControllerButtonBind_hat
		{
			public int hat;
			public int hat_mask;
		}

		// FIXME: I'd rather this somehow be private...
		[StructLayout(LayoutKind.Explicit)]
		public struct INTERNAL_GameControllerButtonBind_union
		{
			[FieldOffset(0)]
			public int button;
			[FieldOffset(0)]
			public int axis;
			[FieldOffset(0)]
			public INTERNAL_GameControllerButtonBind_hat hat;
		}

		[StructLayout(LayoutKind.Sequential)]
		public struct GameControllerButtonBind
		{
			public GameControllerBindType bindType;
			public INTERNAL_GameControllerButtonBind_union value;
		}

		/* This exists to deal with C# being stupid about blittable types. */
		[StructLayout(LayoutKind.Sequential)]
		private struct INTERNAL_GameControllerButtonBind
		{
			public int bindType;
			/* Largest data type in the union is two ints in size */
			public int unionVal0;
			public int unionVal1;
		}

		[DllImport(nativeLibName, EntryPoint = "SDL_GameControllerAddMapping", CallingConvention = CallingConvention.Cdecl)]
		private static extern int INTERNAL_GameControllerAddMapping(
			byte[] mappingString
		);
		public static int GameControllerAddMapping(
			string mappingString
		) {
			return INTERNAL_GameControllerAddMapping(
				UTF8_ToNative(mappingString)
			);
		}

		/* This function is only available in 2.0.6 or higher. */
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint="SDL_GameControllerNumMappings")]
		public static extern int GameControllerNumMappings();

		/* This function is only available in 2.0.6 or higher. */
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
		[DllImport(nativeLibName, EntryPoint = "SDL_GameControllerMapping", CallingConvention = CallingConvention.Cdecl)]
		private static extern IntPtr INTERNAL_GameControllerMapping(
			IntPtr gamecontroller
		);
		public static string GameControllerMapping(
			IntPtr gamecontroller
		) {
			return UTF8_ToManaged(
				INTERNAL_GameControllerMapping(
					gamecontroller
				)
			);
		}

		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint="SDL_IsGameController")]
		public static extern bool IsGameController(int joystick_index);

		[DllImport(nativeLibName, EntryPoint = "SDL_GameControllerNameForIndex", CallingConvention = CallingConvention.Cdecl)]
		private static extern IntPtr INTERNAL_GameControllerNameForIndex(
			int joystick_index
		);
		public static string GameControllerNameForIndex(
			int joystick_index
		) {
			return UTF8_ToManaged(
				INTERNAL_GameControllerNameForIndex(joystick_index)
			);
		}

		/* Only available in 2.0.9 or higher */
		[DllImport(nativeLibName, EntryPoint = "SDL_GameControllerMappingForDeviceIndex", CallingConvention = CallingConvention.Cdecl)]
		private static extern IntPtr INTERNAL_GameControllerMappingForDeviceIndex(
			int joystick_index
		);
		public static string GameControllerMappingForDeviceIndex(
			int joystick_index
		) {
			return UTF8_ToManaged(
				INTERNAL_GameControllerMappingForDeviceIndex(joystick_index)
			);
		}

		/* IntPtr refers to an GameController* */
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint="SDL_GameControllerOpen")]
		public static extern IntPtr GameControllerOpen(int joystick_index);

		/* gamecontroller refers to an GameController* */
		[DllImport(nativeLibName, EntryPoint = "SDL_GameControllerName", CallingConvention = CallingConvention.Cdecl)]
		private static extern IntPtr INTERNAL_GameControllerName(
			IntPtr gamecontroller
		);
		public static string GameControllerName(
			IntPtr gamecontroller
		) {
			return UTF8_ToManaged(
				INTERNAL_GameControllerName(gamecontroller)
			);
		}

		/* gamecontroller refers to an GameController*.
		 * This function is only available in 2.0.6 or higher.
		 */
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint="SDL_GameControllerGetVendor")]
		public static extern ushort GameControllerGetVendor(
			IntPtr gamecontroller
		);

		/* gamecontroller refers to an GameController*.
		 * This function is only available in 2.0.6 or higher.
		 */
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint="SDL_GameControllerGetProduct")]
		public static extern ushort GameControllerGetProduct(
			IntPtr gamecontroller
		);

		/* gamecontroller refers to an GameController*.
		 * This function is only available in 2.0.6 or higher.
		 */
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint="SDL_GameControllerGetProductVersion")]
		public static extern ushort GameControllerGetProductVersion(
			IntPtr gamecontroller
		);

		/* gamecontroller refers to an GameController* */
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint="SDL_GameControllerGetAttached")]
		public static extern bool GameControllerGetAttached(
			IntPtr gamecontroller
		);

		/* IntPtr refers to an Joystick*
		 * gamecontroller refers to an GameController*
		 */
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint="SDL_GameControllerGetJoystick")]
		public static extern IntPtr GameControllerGetJoystick(
			IntPtr gamecontroller
		);

		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint="SDL_GameControllerEventState")]
		public static extern int GameControllerEventState(int state);

		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint="SDL_GameControllerUpdate")]
		public static extern void GameControllerUpdate();

		[DllImport(nativeLibName, EntryPoint = "SDL_GameControllerGetAxisFromString", CallingConvention = CallingConvention.Cdecl)]
		private static extern GameControllerAxis INTERNAL_GameControllerGetAxisFromString(
			byte[] pchString
		);
		public static GameControllerAxis GameControllerGetAxisFromString(
			string pchString
		) {
			return INTERNAL_GameControllerGetAxisFromString(
				UTF8_ToNative(pchString)
			);
		}

		[DllImport(nativeLibName, EntryPoint = "SDL_GameControllerGetStringForAxis", CallingConvention = CallingConvention.Cdecl)]
		private static extern IntPtr INTERNAL_GameControllerGetStringForAxis(
			GameControllerAxis axis
		);
		public static string GameControllerGetStringForAxis(
			GameControllerAxis axis
		) {
			return UTF8_ToManaged(
				INTERNAL_GameControllerGetStringForAxis(
					axis
				)
			);
		}

		/* gamecontroller refers to an GameController* */
		[DllImport(nativeLibName, EntryPoint = "SDL_GameControllerGetBindForAxis", CallingConvention = CallingConvention.Cdecl)]
		private static extern INTERNAL_GameControllerButtonBind INTERNAL_GameControllerGetBindForAxis(
			IntPtr gamecontroller,
			GameControllerAxis axis
		);
		public static GameControllerButtonBind GameControllerGetBindForAxis(
			IntPtr gamecontroller,
			GameControllerAxis axis
		) {
			// This is guaranteed to never be null
			INTERNAL_GameControllerButtonBind dumb = INTERNAL_GameControllerGetBindForAxis(
				gamecontroller,
				axis
			);
			GameControllerButtonBind result = new GameControllerButtonBind();
			result.bindType = (GameControllerBindType) dumb.bindType;
			result.value.hat.hat = dumb.unionVal0;
			result.value.hat.hat_mask = dumb.unionVal1;
			return result;
		}

		/* gamecontroller refers to an GameController* */
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint="SDL_GameControllerGetAxis")]
		public static extern short GameControllerGetAxis(
			IntPtr gamecontroller,
			GameControllerAxis axis
		);

		[DllImport(nativeLibName, EntryPoint = "SDL_GameControllerGetButtonFromString", CallingConvention = CallingConvention.Cdecl)]
		private static extern GameControllerButton INTERNAL_GameControllerGetButtonFromString(
			byte[] pchString
		);
		public static GameControllerButton GameControllerGetButtonFromString(
			string pchString
		) {
			return INTERNAL_GameControllerGetButtonFromString(
				UTF8_ToNative(pchString)
			);
		}

		[DllImport(nativeLibName, EntryPoint = "SDL_GameControllerGetStringForButton", CallingConvention = CallingConvention.Cdecl)]
		private static extern IntPtr INTERNAL_GameControllerGetStringForButton(
			GameControllerButton button
		);
		public static string GameControllerGetStringForButton(
			GameControllerButton button
		) {
			return UTF8_ToManaged(
				INTERNAL_GameControllerGetStringForButton(button)
			);
		}

		/* gamecontroller refers to an GameController* */
		[DllImport(nativeLibName, EntryPoint = "SDL_GameControllerGetBindForButton", CallingConvention = CallingConvention.Cdecl)]
		private static extern INTERNAL_GameControllerButtonBind INTERNAL_GameControllerGetBindForButton(
			IntPtr gamecontroller,
			GameControllerButton button
		);
		public static GameControllerButtonBind GameControllerGetBindForButton(
			IntPtr gamecontroller,
			GameControllerButton button
		) {
			// This is guaranteed to never be null
			INTERNAL_GameControllerButtonBind dumb = INTERNAL_GameControllerGetBindForButton(
				gamecontroller,
				button
			);
			GameControllerButtonBind result = new GameControllerButtonBind();
			result.bindType = (GameControllerBindType) dumb.bindType;
			result.value.hat.hat = dumb.unionVal0;
			result.value.hat.hat_mask = dumb.unionVal1;
			return result;
		}

		/* gamecontroller refers to an GameController* */
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint="SDL_GameControllerGetButton")]
		public static extern byte GameControllerGetButton(
			IntPtr gamecontroller,
			GameControllerButton button
		);

		/* gamecontroller refers to an GameController*.
		 * This function is only available in 2.0.9 or higher.
		 */
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint="SDL_GameControllerRumble")]
		public static extern int GameControllerRumble(
			IntPtr gamecontroller,
			UInt16 low_frequency_rumble,
			UInt16 high_frequency_rumble,
			UInt32 duration_ms
		);

		/* gamecontroller refers to an GameController* */
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint="SDL_GameControllerClose")]
		public static extern void GameControllerClose(
			IntPtr gamecontroller
		);

		/* int refers to an JoystickID, IntPtr to an GameController*.
		 * This function is only available in 2.0.4 or higher.
		 */
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint="SDL_GameControllerFromInstanceID")]
		public static extern IntPtr GameControllerFromInstanceID(int joyid);

		#endregion
    }
}
