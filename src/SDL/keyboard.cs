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
    #region keyboard.h
    [StructLayout(LayoutKind.Sequential)]
    public struct Keysym
    {
        public Scancode Scancode;
        public Keycode Sym;
        public Keymod Mod;
        [Obsolete]
        public uint Unicode;
    }
    public static partial class SDL
    {

        /* Get the window which has kbd focus */
        /* Return type is an Window pointer */
        /// <summary>
        /// Get the window which currently has keyboard focus.
        /// 
        /// Binding info:
        /// Return type is an Window pointer
        /// </summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetKeyboardFocus")]
        public static extern IntPtr GetKeyboardFocus();

        /* Get a snapshot of the keyboard state. */
        /* Return value is a pointer to a UInt8 array */
        /* Numkeys returns the size of the array if non-null */
        /// <summary>
        /// Get a snapshot of the current state of the keyboard.
        /// 
        /// Binding info:
        /// Numkeys returns the size of the array if non-null
        /// </summary>
        /// <param name="numkeys">if non-NULL, receives the length of the returned array.</param>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetKeyboardState")]
        public static extern IntPtr GetKeyboardState(out int numkeys);

        /* Get the current key modifier state for the keyboard. */
        /// <summary>
        /// Get the current key modifier state for the keyboard.
        /// 
        /// Binding info:
        /// Get the current key modifier state for the keyboard.
        /// </summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetModState")]
        public static extern Keymod GetModState();

        /* Set the current key modifier state */
        /// <summary>
        /// Set the current key modifier state for the keyboard.
        /// 
        /// Binding info:
        /// Set the current key modifier state
        /// </summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_SetModState")]
        public static extern void SetModState(Keymod modstate);

        /* Get the key code corresponding to the given scancode
		 * with the current keyboard layout.
		 */
        /// <summary>
        /// Get the key code corresponding to the given scancode according to the current keyboard layout. 
        /// See  for details.
        /// 
        /// Binding info:
        /// Get the key code corresponding to the given scancode
        /// with the current keyboard layout.
        /// </summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetKeyFromScancode")]
        public static extern Keycode GetKeyFromScancode(Scancode scancode);

        /* Get the scancode for the given keycode */
        /// <summary>
        /// Get the scancode corresponding to the given key code according to the current keyboard layout. 
        /// See  for details.
        /// 
        /// Binding info:
        /// Get the scancode for the given keycode
        /// </summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetScancodeFromKey")]
        public static extern Scancode GetScancodeFromKey(Keycode key);

        /* Wrapper for GetScancodeName */
        /// <summary>
        /// Get a human-readable name for a scancode.
        /// 
        /// Binding info:
        /// Wrapper for GetScancodeName
        /// </summary>
        [DllImport(nativeLibName, EntryPoint = "SDL_GetScancodeName", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr INTERNAL_GetScancodeName(Scancode scancode);
        public static string GetScancodeName(Scancode scancode)
        {
            return UTF8_ToManaged(
                INTERNAL_GetScancodeName(scancode)
            );
        }

        /* Get a scancode from a human-readable name */
        /// <summary>
        /// Get a scancode from a human-readable name.
        /// 
        /// Binding info:
        /// Get a scancode from a human-readable name
        /// </summary>
        [DllImport(nativeLibName, EntryPoint = "SDL_GetScancodeFromName", CallingConvention = CallingConvention.Cdecl)]
        private static extern Scancode INTERNAL_GetScancodeFromName(
            byte[] name
        );
        public static Scancode GetScancodeFromName(string name)
        {
            return INTERNAL_GetScancodeFromName(
                UTF8_ToNative(name)
            );
        }

        /* Wrapper for GetKeyName */
        /// <summary>
        /// Get a human-readable name for a key.
        /// 
        /// Binding info:
        /// Wrapper for GetKeyName
        /// </summary>
        [DllImport(nativeLibName, EntryPoint = "SDL_GetKeyName", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr INTERNAL_GetKeyName(Keycode key);
        public static string GetKeyName(Keycode key)
        {
            return UTF8_ToManaged(INTERNAL_GetKeyName(key));
        }

        /* Get a key code from a human-readable name */
        /// <summary>
        /// Get a key code from a human-readable name.
        /// 
        /// Binding info:
        /// Get a key code from a human-readable name
        /// </summary>
        [DllImport(nativeLibName, EntryPoint = "SDL_GetKeyFromName", CallingConvention = CallingConvention.Cdecl)]
        private static extern Keycode INTERNAL_GetKeyFromName(
            byte[] name
        );
        public static Keycode GetKeyFromName(string name)
        {
            return INTERNAL_GetKeyFromName(UTF8_ToNative(name));
        }

        /* Start accepting Unicode text input events, show keyboard */
        /// <summary>
        /// Start accepting Unicode text input events. This function will show the on-screen keyboard if supported.
        /// 
        /// Binding info:
        /// Start accepting Unicode text input events, show keyboard
        /// </summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_StartTextInput")]
        public static extern void StartTextInput();

        /* Check if unicode input events are enabled */
        /// <summary>
        /// Return whether or not Unicode text input events are enabled.
        /// 
        /// Binding info:
        /// Check if unicode input events are enabled
        /// </summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_IsTextInputActive")]
        public static extern bool IsTextInputActive();

        /* Stop receiving any text input events, hide onscreen kbd */
        /// <summary>
        /// Stop receiving any text input events. This function will hide the on-screen keyboard if supported.
        /// 
        /// Binding info:
        /// Stop receiving any text input events, hide onscreen kbd
        /// </summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_StopTextInput")]
        public static extern void StopTextInput();

        /* Set the rectangle used for text input, hint for IME */
        /// <summary>
        /// Set the rectangle used to type Unicode text inputs. This is used as a hint for IME and on-screen keyboard placement.
        /// 
        /// Binding info:
        /// Set the rectangle used for text input, hint for IME
        /// </summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_SetTextInputRect")]
        public static extern void SetTextInputRect(ref Rect rect);

        /* Does the platform support an on-screen keyboard? */
        /// <summary>
        /// Returns whether the platform has some screen keyboard support.
        /// 
        /// Binding info:
        /// Does the platform support an on-screen keyboard?
        /// </summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_HasScreenKeyboardSupport")]
        public static extern bool HasScreenKeyboardSupport();

        /* Is the on-screen keyboard shown for a given window? */
        /* window is an Window pointer */
        /// <summary>
        /// Returns whether the screen keyboard is shown for given window.
        /// 
        /// Binding info:
        /// window is an Window pointer
        /// </summary>
        /// <param name="window">The window for which screen keyboard should be queried.</param>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_IsScreenKeyboardShown")]
        public static extern bool IsScreenKeyboardShown(IntPtr window);
    }
    #endregion
}
