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
		#region mouse.c

		/* Note: Cursor is a typedef normally. We'll treat it as
		 * an IntPtr, because C# doesn't do typedefs. Yay!
		 */

		/* System cursor types */
		public enum SystemCursor
        {
            ///<summary>Arrow.</summary>
            Arrow,
            ///<summary>I-beam.</summary>
            IBeam,
            ///<summary>Wait.</summary>
            Wait,
            ///<summary>Crosshair.</summary>
            CrossHair,
            ///<summary>Small wait cursor (or Wait if not available).</summary>
            WaitArrow,
            ///<summary>Double arrow pointing northwest and southeast.</summary>
            SizeNwse,
            ///<summary>Double arrow pointing northeast and southwest.</summary>
            SizeNesw,
            ///<summary>Double arrow pointing west and east.</summary>
            SizeWe,
            ///<summary>Double arrow pointing north and south.</summary>
            SizeNs,
            ///<summary>Four pointed arrow pointing north, south, east, and west.</summary>
            SizeAll,
            ///<summary>Slashed circle or crossbones.</summary>
            No,
            ///<summary>Hand.</summary>
            Hand,
            NumSystemCursors
        }

		/* Get the window which currently has mouse focus */
		/* Return value is an Window pointer */
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint="SDL_GetMouseFocus")]
		public static extern IntPtr GetMouseFocus();

		/* Get the current state of the mouse */
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint="SDL_GetMouseState")]
		public static extern UInt32 GetMouseState(out int x, out int y);

		/* Get the current state of the mouse */
		/* This overload allows for passing NULL to x */
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint="SDL_GetMouseState")]
		public static extern UInt32 GetMouseState(IntPtr x, out int y);

		/* Get the current state of the mouse */
		/* This overload allows for passing NULL to y */
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint="SDL_GetMouseState")]
		public static extern UInt32 GetMouseState(out int x, IntPtr y);

		/* Get the current state of the mouse */
		/* This overload allows for passing NULL to both x and y */
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint="SDL_GetMouseState")]
		public static extern UInt32 GetMouseState(IntPtr x, IntPtr y);

		/* Get the current state of the mouse, in relation to the desktop */
		/* Only available in 2.0.4 */
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint="SDL_GetGlobalMouseState")]
		public static extern UInt32 GetGlobalMouseState(out int x, out int y);

		/* Get the current state of the mouse, in relation to the desktop */
		/* Only available in 2.0.4 */
		/* This overload allows for passing NULL to x */
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint="SDL_GetGlobalMouseState")]
		public static extern UInt32 GetGlobalMouseState(IntPtr x, out int y);

		/* Get the current state of the mouse, in relation to the desktop */
		/* Only available in 2.0.4 */
		/* This overload allows for passing NULL to y */
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint="SDL_GetGlobalMouseState")]
		public static extern UInt32 GetGlobalMouseState(out int x, IntPtr y);

		/* Get the current state of the mouse, in relation to the desktop */
		/* Only available in 2.0.4 */
		/* This overload allows for passing NULL to both x and y */
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint="SDL_GetGlobalMouseState")]
		public static extern UInt32 GetGlobalMouseState(IntPtr x, IntPtr y);

		/* Get the mouse state with relative coords*/
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint="SDL_GetRelativeMouseState")]
		public static extern UInt32 GetRelativeMouseState(out int x, out int y);

		/* Set the mouse cursor's position (within a window) */
		/* window is an Window pointer */
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint="SDL_WarpMouseInWindow")]
		public static extern void WarpMouseInWindow(IntPtr window, int x, int y);

		/* Set the mouse cursor's position in global screen space */
		/* Only available in 2.0.4 */
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint="SDL_WarpMouseGlobal")]
		public static extern int WarpMouseGlobal(int x, int y);

		/* Enable/Disable relative mouse mode (grabs mouse, rel coords) */
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint="SDL_SetRelativeMouseMode")]
		public static extern int SetRelativeMouseMode(bool enabled);

		/* Capture the mouse, to track input outside an SDL window */
		/* Only available in 2.0.4 */
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint="SDL_CaptureMouse")]
		public static extern int CaptureMouse(bool enabled);

		/* Query if the relative mouse mode is enabled */
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint="SDL_GetRelativeMouseMode")]
		public static extern bool GetRelativeMouseMode();

		/* Create a cursor from bitmap data (amd mask) in MSB format */
		/* data and mask are byte arrays, and w must be a multiple of 8 */
		/* return value is an Cursor pointer */
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint="SDL_CreateCursor")]
		public static extern IntPtr CreateCursor(
			IntPtr data,
			IntPtr mask,
			int w,
			int h,
			int hot_x,
			int hot_y
		);

		/* Create a cursor from an Surface */
		/* IntPtr refers to an Cursor*, surface to an Surface* */
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint="SDL_CreateColorCursor")]
		public static extern IntPtr CreateColorCursor(
			IntPtr surface,
			int hot_x,
			int hot_y
		);

		/* Create a cursor from a system cursor id */
		/* return value is an Cursor pointer */
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint="SDL_CreateSystemCursor")]
		public static extern IntPtr CreateSystemCursor(SystemCursor id);

		/* Set the active cursor */
		/* cursor is an Cursor pointer */
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint="SDL_SetCursor")]
		public static extern void SetCursor(IntPtr cursor);

		/* Return the active cursor */
		/* return value is an Cursor pointer */
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint="SDL_GetCursor")]
		public static extern IntPtr GetCursor();

		/* Frees a cursor created with one of the CreateCursor functions */
		/* cursor in an Cursor pointer */
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint="SDL_FreeCursor")]
		public static extern void FreeCursor(IntPtr cursor);

		/* Toggle whether or not the cursor is shown */
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint="SDL_ShowCursor")]
		public static extern int ShowCursor(int toggle);

		public static uint BUTTON(uint X)
		{
			// If only there were a better way of doing this in C#
			return (uint) (1 << ((int) X - 1));
		}

		public const uint BUTTON_LEFT =	1;
		public const uint BUTTON_MIDDLE =	2;
		public const uint BUTTON_RIGHT =	3;
		public const uint BUTTON_X1 =	4;
		public const uint BUTTON_X2 =	5;
		public static readonly UInt32 BUTTON_LMASK =	BUTTON(BUTTON_LEFT);
		public static readonly UInt32 BUTTON_MMASK =	BUTTON(BUTTON_MIDDLE);
		public static readonly UInt32 BUTTON_RMASK =	BUTTON(BUTTON_RIGHT);
		public static readonly UInt32 BUTTON_X1MASK =	BUTTON(BUTTON_X1);
		public static readonly UInt32 BUTTON_X2MASK =	BUTTON(BUTTON_X2);

		#endregion
    }
}
