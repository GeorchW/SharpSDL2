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
    public enum MouseButtonMask
    {
        Left = 1 << 0,
        Middle = 1 << 1,
        Right = 1 << 2,
        X1 = 1 << 3,
        X2 = 1 << 4
    }
    public static partial class SDL
    {

        /* Get the window which currently has mouse focus */
        /* Return value is an Window pointer */
        /// <summary>
        /// Get the window which currently has mouse focus.
        /// 
        /// Binding info:
        /// Return value is an Window pointer
        /// </summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetMouseFocus")]
        public static extern IntPtr GetMouseFocus();

        /* Get the current state of the mouse */
        /// <summary>
        /// Retrieve the current state of the mouse. 
        /// The current button state is returned as a button bitmask, which can be tested using the  macros, and x and y are set to the mouse cursor position relative to the focus window for the currently selected mouse. You can pass NULL for either x or y.
        /// 
        /// Binding info:
        /// Get the current state of the mouse
        /// </summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetMouseState")]
        public static extern MouseButtonMask GetMouseState(out int x, out int y);

        /* Get the current state of the mouse */
        /* This overload allows for passing NULL to x */
        /// <summary>
        /// Retrieve the current state of the mouse. 
        /// The current button state is returned as a button bitmask, which can be tested using the  macros, and x and y are set to the mouse cursor position relative to the focus window for the currently selected mouse. You can pass NULL for either x or y.
        /// 
        /// Binding info:
        /// This overload allows for passing NULL to x
        /// </summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetMouseState")]
        public static extern MouseButtonMask GetMouseState(IntPtr x, out int y);

        /* Get the current state of the mouse */
        /* This overload allows for passing NULL to y */
        /// <summary>
        /// Retrieve the current state of the mouse. 
        /// The current button state is returned as a button bitmask, which can be tested using the  macros, and x and y are set to the mouse cursor position relative to the focus window for the currently selected mouse. You can pass NULL for either x or y.
        /// 
        /// Binding info:
        /// This overload allows for passing NULL to y
        /// </summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetMouseState")]
        public static extern MouseButtonMask GetMouseState(out int x, IntPtr y);

        /* Get the current state of the mouse */
        /* This overload allows for passing NULL to both x and y */
        /// <summary>
        /// Retrieve the current state of the mouse. 
        /// The current button state is returned as a button bitmask, which can be tested using the  macros, and x and y are set to the mouse cursor position relative to the focus window for the currently selected mouse. You can pass NULL for either x or y.
        /// 
        /// Binding info:
        /// This overload allows for passing NULL to both x and y
        /// </summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetMouseState")]
        public static extern MouseButtonMask GetMouseState(IntPtr x, IntPtr y);

        /* Get the current state of the mouse, in relation to the desktop */
        /* Only available in 2.0.4 */
        /// <summary>
        /// Get the current state of the mouse, in relation to the desktop. 
        /// This works just like , but the coordinates will be reported relative to the top-left of the desktop. This can be useful if you need to track the mouse outside of a specific window and  doesn't fit your needs. For example, it could be useful if you need to track the mouse while dragging a window, where coordinates relative to a window might not be in sync at all times.
        /// 
        /// Binding info:
        /// Only available in 2.0.4
        /// </summary>
        /// <param name="x">Returns the current X coord, relative to the desktop. Can be NULL.</param>
        /// <param name="y">Returns the current Y coord, relative to the desktop. Can be NULL.</param>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetGlobalMouseState")]
        public static extern MouseButtonMask GetGlobalMouseState(out int x, out int y);

        /* Get the current state of the mouse, in relation to the desktop */
        /* Only available in 2.0.4 */
        /* This overload allows for passing NULL to x */
        /// <summary>
        /// Get the current state of the mouse, in relation to the desktop. 
        /// This works just like , but the coordinates will be reported relative to the top-left of the desktop. This can be useful if you need to track the mouse outside of a specific window and  doesn't fit your needs. For example, it could be useful if you need to track the mouse while dragging a window, where coordinates relative to a window might not be in sync at all times.
        /// 
        /// Binding info:
        /// This overload allows for passing NULL to x
        /// </summary>
        /// <param name="x">Returns the current X coord, relative to the desktop. Can be NULL.</param>
        /// <param name="y">Returns the current Y coord, relative to the desktop. Can be NULL.</param>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetGlobalMouseState")]
        public static extern MouseButtonMask GetGlobalMouseState(IntPtr x, out int y);

        /* Get the current state of the mouse, in relation to the desktop */
        /* Only available in 2.0.4 */
        /* This overload allows for passing NULL to y */
        /// <summary>
        /// Get the current state of the mouse, in relation to the desktop. 
        /// This works just like , but the coordinates will be reported relative to the top-left of the desktop. This can be useful if you need to track the mouse outside of a specific window and  doesn't fit your needs. For example, it could be useful if you need to track the mouse while dragging a window, where coordinates relative to a window might not be in sync at all times.
        /// 
        /// Binding info:
        /// This overload allows for passing NULL to y
        /// </summary>
        /// <param name="x">Returns the current X coord, relative to the desktop. Can be NULL.</param>
        /// <param name="y">Returns the current Y coord, relative to the desktop. Can be NULL.</param>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetGlobalMouseState")]
        public static extern MouseButtonMask GetGlobalMouseState(out int x, IntPtr y);

        /* Get the current state of the mouse, in relation to the desktop */
        /* Only available in 2.0.4 */
        /* This overload allows for passing NULL to both x and y */
        /// <summary>
        /// Get the current state of the mouse, in relation to the desktop. 
        /// This works just like , but the coordinates will be reported relative to the top-left of the desktop. This can be useful if you need to track the mouse outside of a specific window and  doesn't fit your needs. For example, it could be useful if you need to track the mouse while dragging a window, where coordinates relative to a window might not be in sync at all times.
        /// 
        /// Binding info:
        /// This overload allows for passing NULL to both x and y
        /// </summary>
        /// <param name="x">Returns the current X coord, relative to the desktop. Can be NULL.</param>
        /// <param name="y">Returns the current Y coord, relative to the desktop. Can be NULL.</param>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetGlobalMouseState")]
        public static extern MouseButtonMask GetGlobalMouseState(IntPtr x, IntPtr y);

        /* Get the mouse state with relative coords*/
        /// <summary>
        /// Retrieve the relative state of the mouse. 
        /// The current button state is returned as a button bitmask, which can be tested using the  macros, and x and y are set to the mouse deltas since the last call to .
        /// 
        /// Binding info:
        /// Get the mouse state with relative coords
        /// </summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetRelativeMouseState")]
        public static extern MouseButtonMask GetRelativeMouseState(out int x, out int y);

        /* Set the mouse cursor's position (within a window) */
        /* window is an Window pointer */
        /// <summary>
        /// Moves the mouse to the given position within the window.
        /// 
        /// Binding info:
        /// window is an Window pointer
        /// </summary>
        /// <param name="window">The window to move the mouse into, or NULL for the current mouse focus</param>
        /// <param name="x">The x coordinate within the window</param>
        /// <param name="y">The y coordinate within the window</param>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_WarpMouseInWindow")]
        public static extern void WarpMouseInWindow(IntPtr window, int x, int y);

        /* Set the mouse cursor's position in global screen space */
        /* Only available in 2.0.4 */
        /// <summary>
        /// Moves the mouse to the given position in global screen space.
        /// 
        /// Binding info:
        /// Only available in 2.0.4
        /// </summary>
        /// <param name="x">The x coordinate</param>
        /// <param name="y">The y coordinate</param>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_WarpMouseGlobal")]
        public static extern int WarpMouseGlobal(int x, int y);

        /* Enable/Disable relative mouse mode (grabs mouse, rel coords) */
        /// <summary>
        /// Set relative mouse mode. 
        /// While the mouse is in relative mode, the cursor is hidden, and the driver will try to report continuous motion in the current window. Only relative motion events will be delivered, the mouse position will not change.
        /// 
        /// Binding info:
        /// Enable/Disable relative mouse mode (grabs mouse, rel coords)
        /// </summary>
        /// <param name="enabled">Whether or not to enable relative mode</param>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_SetRelativeMouseMode")]
        public static extern int SetRelativeMouseMode(bool enabled);

        /* Capture the mouse, to track input outside an SDL window */
        /* Only available in 2.0.4 */
        /// <summary>
        /// Capture the mouse, to track input outside an SDL window. 
        /// Capturing enables your app to obtain mouse events globally, instead of just within your window. Not all video targets support this function. When capturing is enabled, the current window will get all mouse events, but unlike relative mode, no change is made to the cursor and it is not restrained to your window.This function may also deny mouse input to other windowsboth those in your application and others on the systemso you should use this function sparingly, and in small bursts. For example, you might want to track the mouse while the user is dragging something, until the user releases a mouse button. It is not recommended that you capture the mouse for long periods of time, such as the entire time your app is running.While captured, mouse events still report coordinates relative to the current (foreground) window, but those coordinates may be outside the bounds of the window (including negative values). Capturing is only allowed for the foreground window. If the window loses focus while capturing, the capture will be disabled automatically.While capturing is enabled, the current window will have the SDL_WINDOW_MOUSE_CAPTURE flag set.
        /// 
        /// Binding info:
        /// Only available in 2.0.4
        /// </summary>
        /// <param name="enabled">Whether or not to enable capturing</param>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_CaptureMouse")]
        public static extern int CaptureMouse(bool enabled);

        /* Query if the relative mouse mode is enabled */
        /// <summary>
        /// Query whether relative mouse mode is enabled.
        /// 
        /// Binding info:
        /// Query if the relative mouse mode is enabled
        /// </summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetRelativeMouseMode")]
        public static extern bool GetRelativeMouseMode();

        /* Create a cursor from bitmap data (amd mask) in MSB format */
        /* data and mask are byte arrays, and w must be a multiple of 8 */
        /* return value is an Cursor pointer */
        /// <summary>
        /// Create a cursor, using the specified bitmap data and mask (in MSB format). 
        /// The cursor width must be a multiple of 8 bits.The cursor is created in black and white according to the following:
        /// 
        /// Binding info:
        /// return value is an Cursor pointer
        /// </summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_CreateCursor")]
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
        /// <summary>
        /// Create a color cursor.
        /// 
        /// Binding info:
        /// IntPtr refers to an Cursor*, surface to an Surface*
        /// </summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_CreateColorCursor")]
        public static extern IntPtr CreateColorCursor(
            IntPtr surface,
            int hot_x,
            int hot_y
        );

        /* Create a cursor from a system cursor id */
        /* return value is an Cursor pointer */
        /// <summary>
        /// Create a system cursor.
        /// 
        /// Binding info:
        /// return value is an Cursor pointer
        /// </summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_CreateSystemCursor")]
        public static extern IntPtr CreateSystemCursor(SystemCursor id);

        /* Set the active cursor */
        /* cursor is an Cursor pointer */
        /// <summary>
        /// Set the active cursor.
        /// 
        /// Binding info:
        /// cursor is an Cursor pointer
        /// </summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_SetCursor")]
        public static extern void SetCursor(IntPtr cursor);

        /* Return the active cursor */
        /* return value is an Cursor pointer */
        /// <summary>
        /// Return the active cursor.
        /// 
        /// Binding info:
        /// return value is an Cursor pointer
        /// </summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetCursor")]
        public static extern IntPtr GetCursor();

        /* Frees a cursor created with one of the CreateCursor functions */
        /* cursor in an Cursor pointer */
        /// <summary>
        /// Frees a cursor created with SDL_CreateCursor() or similar functions.
        /// 
        /// Binding info:
        /// cursor in an Cursor pointer
        /// </summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_FreeCursor")]
        public static extern void FreeCursor(IntPtr cursor);

        /* Toggle whether or not the cursor is shown */
        /// <summary>
        /// Toggle whether or not the cursor is shown.
        /// 
        /// Binding info:
        /// Toggle whether or not the cursor is shown
        /// </summary>
        /// <param name="toggle">1 to show the cursor, 0 to hide it, -1 to query the current state.</param>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_ShowCursor")]
        public static extern int ShowCursor(int toggle);


    }
    #endregion
}
