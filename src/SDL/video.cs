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


    #region video.h

    public enum GlAttr
    {
        RedSize,
        GreenSize,
        BlueSize,
        AlphaSize,
        BufferSize,
        Doublebuffer,
        DepthSize,
        StencilSize,
        AccumRedSize,
        AccumGreenSize,
        AccumBlueSize,
        AccumAlphaSize,
        Stereo,
        Multisamplebuffers,
        Multisamplesamples,
        AcceleratedVisual,
        RetainedBacking,
        ContextMajorVersion,
        ContextMinorVersion,
        ContextEgl,
        ContextFlags,
        ContextProfileMask,
        ShareWithCurrentContext,
        FramebufferSrgbCapable,
        ContextReleaseBehavior,
        ContextResetNotification,   /* Only available in 2.0.6 */
        ContextNoError,     /* Only available in 2.0.6 */
    }

    [Flags]
    public enum GlProfile
    {
        Core = 0x0001,
        Compatibility = 0x0002,
        Es = 0x0004
    }

    [Flags]
    public enum GlContext
    {
        DebugFlag = 0x0001,
        ForwardCompatibleFlag = 0x0002,
        RobustAccessFlag = 0x0004,
        ResetIsolationFlag = 0x0008
    }

    public enum WindowEventID : byte
    {
        /// <summary>
        /// Never used
        /// </summary>
        None,
        /// <summary>
        /// Window has been shown
        /// </summary>
        Shown,
        /// <summary>
        /// Window has been hidden
        /// </summary>
        Hidden,
        /// <summary>
        /// Window has been exposed and should be redrawn
        /// </summary>
        Exposed,
        /// <summary>
        /// Window has been moved to data1, data2
        /// </summary>
        Moved,
        /// <summary>
        /// Window has been resized to data1xdata2.
        /// This event is always preceded by WindowEventSizeChanged
        /// </summary>
        Resized,
        /// <summary>
        /// The window size has changed, either as a result of an API call or through the system or user changing the window size.
        /// This event is followed by WindowEventResized if the size was changed by an external event, i.e. the user or the window manager.
        /// </summary>
        SizeChanged,
        /// <summary>
        /// Window has been minimized
        /// </summary>
        Minimized,
        /// <summary>
        /// Window has been maximized
        /// </summary>
        Maximized,
        /// <summary>
        /// Window has been restored to normal size and position
        /// </summary>
        Restored,
        /// <summary>
        /// Window has gained mouse focus
        /// </summary>
        Enter,
        /// <summary>
        /// Window has lost mouse focus
        /// </summary>
        Leave,
        /// <summary>
        /// Window has gained keyboard focus
        /// </summary>
        FocusGained,
        /// <summary>
        /// Window has lost keyboard focus
        /// </summary>
        FocusLost,
        /// <summary>
        /// The window manager requests that the window be closed
        /// </summary>
        Close,
        /* Available in 2.0.5 or higher */
        /// <summary>
        /// Window is being offered a focus (should SetWindowInputFocus() on itself or a subwindow, or ignore
        /// </summary>
        /// <remarks>Available in 2.0.5 or higher</remarks>
        TakeFocus,
        /// <summary>
        /// Window had a hit test that wasn't HitTestNormal
        /// </summary>
        /// <remarks>Available in 2.0.5 or higher</remarks>
        HitTest,
        /* Available in 2.1.8 or higher */
        /// <summary>
        /// The ICC profile of the window's display has changed
        /// </summary>
        /// <remarks>Available in 2.1.8 or higher</remarks>
        ICCProfileChanged,
        /// <summary>
        /// The window has been moved to display data1
        /// </summary>
        /// <remarks>Available in 2.1.8 or higher</remarks>
        DisplayChanged,
    }

    public enum DisplayEventID : byte
    {
        None,
        Orientation
    }

    public enum DisplayOrientation
    {
        Unknown,
        Landscape,
        LandscapeFlipped,
        Portrait,
        PortraitFlipped
    }

    [Flags]
    public enum WindowFlags : uint
    {
        Fullscreen = 0x00000001,
        OpenGL = 0x00000002,
        Shown = 0x00000004,
        Hidden = 0x00000008,
        Borderless = 0x00000010,
        Resizable = 0x00000020,
        Minimized = 0x00000040,
        Maximized = 0x00000080,
        InputGrabbed = 0x00000100,
        InputFocus = 0x00000200,
        MouseFocus = 0x00000400,
        FullscreenDesktop =
            (Fullscreen | 0x00001000),
        Foreign = 0x00000800,
        AllowHighdpi = 0x00002000,  /* Only available in 2.0.1 */
        MouseCapture = 0x00004000,  /* Only available in 2.0.4 */
        AlwaysOnTop = 0x00008000,   /* Only available in 2.0.5 */
        SkipTaskbar = 0x00010000,   /* Only available in 2.0.5 */
        Utility = 0x00020000,   /* Only available in 2.0.5 */
        Tooltip = 0x00040000,   /* Only available in 2.0.5 */
        PopupMenu = 0x00080000, /* Only available in 2.0.5 */
        Vulkan = 0x10000000,    /* Only available in 2.0.6 */
    }

    /* Only available in 2.0.4 */
    public enum HitTestResult
    {
        Normal,     /* Region is normal. No special properties. */
        Draggable,      /* Region can drag entire window. */
        ResizeTopleft,
        ResizeTop,
        ResizeTopright,
        ResizeRight,
        ResizeBottomright,
        ResizeBottom,
        ResizeBottomleft,
        ResizeLeft
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct DisplayMode
    {
        public uint Format;
        public int W;
        public int H;
        public int RefreshRate;
        public IntPtr DriverData; // void*
    }

    /* win refers to an Window*, area to a cosnt Point*, data to a void* */
    /* Only available in 2.0.4 */
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate HitTestResult HitTest(IntPtr win, IntPtr area, IntPtr data);

    public static partial class SDL
    {
        public const int WINDOWPOS_UNDEFINED_MASK = 0x1FFF0000;
        public const int WINDOWPOS_CENTERED_MASK = 0x2FFF0000;
        public const int WINDOWPOS_UNDEFINED = 0x1FFF0000;
        public const int WINDOWPOS_CENTERED = 0x2FFF0000;

        public static int WINDOWPOS_UNDEFINED_DISPLAY(int X)
        {
            return (WINDOWPOS_UNDEFINED_MASK | X);
        }

        public static bool WINDOWPOS_ISUNDEFINED(int X)
        {
            return (X & 0xFFFF0000) == WINDOWPOS_UNDEFINED_MASK;
        }

        public static int WINDOWPOS_CENTERED_DISPLAY(int X)
        {
            return (WINDOWPOS_CENTERED_MASK | X);
        }

        public static bool WINDOWPOS_ISCENTERED(int X)
        {
            return (X & 0xFFFF0000) == WINDOWPOS_CENTERED_MASK;
        }

        /* IntPtr refers to an Window* */
        /// <summary>
        /// Create a window with the specified position, dimensions, and flags. 
        /// If the window is created with the SDL_WINDOW_ALLOW_HIGHDPI flag, its size in pixels may differ from its size in screen coordinates on platforms with high-DPI support (e.g. iOS and Mac OS X). Use  to query the client area's size in screen coordinates, and , , or  to query the drawable size in pixels.If the window is created with any of the SDL_WINDOW_OPENGL or SDL_WINDOW_VULKAN flags, then the corresponding LoadLibrary function (SDL_GL_LoadLibrary or SDL_Vulkan_LoadLibrary) is called and the corresponding UnloadLibrary function is called by .If SDL_WINDOW_VULKAN is specified and there isn't a working Vulkan driver,  will fail because  will fail.
        /// 
        /// Binding info:
        /// IntPtr refers to an Window*
        /// </summary>
        /// <param name="title">The title of the window, in UTF-8 encoding.</param>
        /// <param name="x">The x position of the window, SDL_WINDOWPOS_CENTERED, or SDL_WINDOWPOS_UNDEFINED.</param>
        /// <param name="y">The y position of the window, SDL_WINDOWPOS_CENTERED, or SDL_WINDOWPOS_UNDEFINED.</param>
        /// <param name="w">The width of the window, in screen coordinates.</param>
        /// <param name="h">The height of the window, in screen coordinates.</param>
        /// <param name="flags">The flags for the window, a mask of any of the following: SDL_WINDOW_FULLSCREEN, SDL_WINDOW_OPENGL, SDL_WINDOW_HIDDEN, SDL_WINDOW_BORDERLESS, SDL_WINDOW_RESIZABLE, SDL_WINDOW_MAXIMIZED, SDL_WINDOW_MINIMIZED, SDL_WINDOW_INPUT_GRABBED, SDL_WINDOW_ALLOW_HIGHDPI, SDL_WINDOW_VULKAN.</param>
        [DllImport(nativeLibName, EntryPoint = "SDL_CreateWindow", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr INTERNAL_CreateWindow(
            byte[] title,
            int x,
            int y,
            int w,
            int h,
            WindowFlags flags
        );
        public static IntPtr CreateWindow(
            string title,
            int x,
            int y,
            int w,
            int h,
            WindowFlags flags
        )
        {
            return INTERNAL_CreateWindow(
                UTF8_ToNative(title),
                x, y, w, h,
                flags
            );
        }

        /* window refers to an Window*, renderer to an Renderer* */
        /// <summary>
        /// Create a window and default renderer.
        /// 
        /// Binding info:
        /// window refers to an Window*, renderer to an Renderer*
        /// </summary>
        /// <param name="width">The width of the window</param>
        /// <param name="height">The height of the window</param>
        /// <param name="window_flags">The flags used to create the window</param>
        /// <param name="window">A pointer filled with the window, or NULL on error</param>
        /// <param name="renderer">A pointer filled with the renderer, or NULL on error</param>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_CreateWindowAndRenderer")]
        public static extern int CreateWindowAndRenderer(
            int width,
            int height,
            WindowFlags window_flags,
            out IntPtr window,
            out IntPtr renderer
        );

        /* data refers to some native window type, IntPtr to an Window* */
        /// <summary>
        /// Create an SDL window from an existing native window.
        /// 
        /// Binding info:
        /// data refers to some native window type, IntPtr to an Window*
        /// </summary>
        /// <param name="data">A pointer to driver-dependent window creation data</param>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_CreateWindowFrom")]
        public static extern IntPtr CreateWindowFrom(IntPtr data);

        /* window refers to an Window* */
        /// <summary>
        /// Destroy a window.
        /// 
        /// Binding info:
        /// window refers to an Window*
        /// </summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_DestroyWindow")]
        public static extern void DestroyWindow(IntPtr window);

        /// <summary>Prevent the screen from being blanked by a screensaver.</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_DisableScreenSaver")]
        public static extern void DisableScreenSaver();

        /// <summary>Allow the screen to be blanked by a screensaver.</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_EnableScreenSaver")]
        public static extern void EnableScreenSaver();

        /* IntPtr refers to an DisplayMode. Just use closest. */
        /// <summary>
        /// Get the closest match to the requested display mode. 
        /// The available display modes are scanned, and  is filled in with the closest mode matching the requested mode and returned. The mode format and refresh_rate default to the desktop mode if they are 0. The modes are scanned with size being first priority, format being second priority, and finally checking the refresh_rate. If all the available modes are too small, then NULL is returned.
        /// 
        /// Binding info:
        /// IntPtr refers to an DisplayMode. Just use closest.
        /// </summary>
        /// <param name="displayIndex">The index of display from which mode should be queried.</param>
        /// <param name="mode">The desired display mode</param>
        /// <param name="closest">A pointer to a display mode to be filled in with the closest match of the available display modes.</param>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetClosestDisplayMode")]
        public static extern IntPtr GetClosestDisplayMode(
            int displayIndex,
            ref DisplayMode mode,
            out DisplayMode closest
        );

        /// <summary>Fill in information about the current display mode.</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetCurrentDisplayMode")]
        public static extern int GetCurrentDisplayMode(
            int displayIndex,
            out DisplayMode mode
        );

        /// <summary>Returns the name of the currently initialized video driver.</summary>
        [DllImport(nativeLibName, EntryPoint = "SDL_GetCurrentVideoDriver", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr INTERNAL_GetCurrentVideoDriver();
        public static string GetCurrentVideoDriver()
        {
            return UTF8_ToManaged(INTERNAL_GetCurrentVideoDriver());
        }

        /// <summary>Fill in information about the desktop display mode.</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetDesktopDisplayMode")]
        public static extern int GetDesktopDisplayMode(
            int displayIndex,
            out DisplayMode mode
        );

        /// <summary>Get the name of a display in UTF-8 encoding.</summary>
        [DllImport(nativeLibName, EntryPoint = "SDL_GetDisplayName", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr INTERNAL_GetDisplayName(int index);
        public static string GetDisplayName(int index)
        {
            return UTF8_ToManaged(INTERNAL_GetDisplayName(index));
        }

        /// <summary>Get the desktop area represented by a display, with the primary display located at 0,0.</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetDisplayBounds")]
        public static extern int GetDisplayBounds(
            int displayIndex,
            out Rect rect
        );

        /* This function is only available in 2.0.4 or higher */
        /// <summary>
        /// Get the dots/pixels-per-inch for a display.
        /// 
        /// Binding info:
        /// This function is only available in 2.0.4 or higher
        /// </summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetDisplayDPI")]
        public static extern int GetDisplayDPI(
            int displayIndex,
            out float ddpi,
            out float hdpi,
            out float vdpi
        );

        /* This function is only available in 2.0.9 or higher */
        /// <summary>
        /// Get the orientation of a display.
        /// 
        /// Binding info:
        /// This function is only available in 2.0.9 or higher
        /// </summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetDisplayOrientation")]
        public static extern DisplayOrientation GetDisplayOrientation(
            int displayIndex
        );

        /// <summary>Fill in information about a specific display mode.</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetDisplayMode")]
        public static extern int GetDisplayMode(
            int displayIndex,
            int modeIndex,
            out DisplayMode mode
        );

        /* Available in 2.0.5 or higher */
        /// <summary>
        /// Get the usable desktop area represented by a display, with the primary display located at 0,0. 
        /// This is the same area as  reports, but with portions reserved by the system removed. For example, on Mac OS X, this subtracts the area occupied by the menu bar and dock.Setting a window to be fullscreen generally bypasses these unusable areas, so these are good guidelines for the maximum space available to a non-fullscreen window.
        /// 
        /// Binding info:
        /// Available in 2.0.5 or higher
        /// </summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetDisplayUsableBounds")]
        public static extern int GetDisplayUsableBounds(
            int displayIndex,
            out Rect rect
        );

        /// <summary>Returns the number of available display modes.</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetNumDisplayModes")]
        public static extern int GetNumDisplayModes(
            int displayIndex
        );

        /// <summary>Returns the number of available video displays.</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetNumVideoDisplays")]
        public static extern int GetNumVideoDisplays();

        /// <summary>Get the number of video drivers compiled into SDL.</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetNumVideoDrivers")]
        public static extern int GetNumVideoDrivers();

        /// <summary>Get the name of a built in video driver.</summary>
        [DllImport(nativeLibName, EntryPoint = "SDL_GetVideoDriver", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr INTERNAL_GetVideoDriver(
            int index
        );
        public static string GetVideoDriver(int index)
        {
            return UTF8_ToManaged(INTERNAL_GetVideoDriver(index));
        }

        /* window refers to an Window* */
        /// <summary>
        /// Get the brightness (gamma correction) for a window.
        /// 
        /// Binding info:
        /// window refers to an Window*
        /// </summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetWindowBrightness")]
        public static extern float GetWindowBrightness(
            IntPtr window
        );

        /* window refers to an Window* */
        /* Available in 2.0.5 or higher */
        /// <summary>
        /// Set the opacity for a window.
        /// 
        /// Binding info:
        /// Available in 2.0.5 or higher
        /// </summary>
        /// <param name="window">The window which will be made transparent or opaque</param>
        /// <param name="opacity">Opacity (0.0f - transparent, 1.0f - opaque) This will be clamped internally between 0.0f and 1.0f.</param>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_SetWindowOpacity")]
        public static extern int SetWindowOpacity(
            IntPtr window,
            float opacity
        );

        /* window refers to an Window* */
        /* Available in 2.0.5 or higher */
        /// <summary>
        /// Get the opacity of a window. 
        /// If transparency isn't supported on this platform, opacity will be reported as 1.0f without error.
        /// 
        /// Binding info:
        /// Available in 2.0.5 or higher
        /// </summary>
        /// <param name="window">The window in question.</param>
        /// <param name="out_opacity">Opacity (0.0f - transparent, 1.0f - opaque)</param>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetWindowOpacity")]
        public static extern int GetWindowOpacity(
            IntPtr window,
            out float out_opacity
        );

        /* modal_window and parent_window refer to an Window*s */
        /* Available in 2.0.5 or higher */
        /// <summary>
        /// Sets the window as a modal for another window (TODO: reconsider this function and/or its name)
        /// 
        /// Binding info:
        /// Available in 2.0.5 or higher
        /// </summary>
        /// <param name="modal_window">The window that should be modal</param>
        /// <param name="parent_window">The parent window</param>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_SetWindowModalFor")]
        public static extern int SetWindowModalFor(
            IntPtr modal_window,
            IntPtr parent_window
        );

        /* window refers to an Window* */
        /* Available in 2.0.5 or higher */
        /// <summary>
        /// Explicitly sets input focus to the window. 
        /// You almost certainly want  instead of this function. Use this with caution, as you might give focus to a window that's completely obscured by other windows.
        /// 
        /// Binding info:
        /// Available in 2.0.5 or higher
        /// </summary>
        /// <param name="window">The window that should get the input focus</param>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_SetWindowInputFocus")]
        public static extern int SetWindowInputFocus(IntPtr window);

        /* window refers to an Window*, IntPtr to a void* */
        /// <summary>
        /// Retrieve the data pointer associated with a window.
        /// 
        /// Binding info:
        /// window refers to an Window*, IntPtr to a void*
        /// </summary>
        /// <param name="window">The window to query.</param>
        /// <param name="name">The name of the pointer.</param>
        [DllImport(nativeLibName, EntryPoint = "SDL_GetWindowData", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr INTERNAL_GetWindowData(
            IntPtr window,
            byte[] name
        );
        public static IntPtr GetWindowData(
            IntPtr window,
            string name
        )
        {
            return INTERNAL_GetWindowData(
                window,
                UTF8_ToNative(name)
            );
        }

        /* window refers to an Window* */
        /// <summary>
        /// Get the display index associated with a window.
        /// 
        /// Binding info:
        /// window refers to an Window*
        /// </summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetWindowDisplayIndex")]
        public static extern int GetWindowDisplayIndex(
            IntPtr window
        );

        /* window refers to an Window* */
        /// <summary>
        /// Fill in information about the display mode used when a fullscreen window is visible.
        /// 
        /// Binding info:
        /// window refers to an Window*
        /// </summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetWindowDisplayMode")]
        public static extern int GetWindowDisplayMode(
            IntPtr window,
            out DisplayMode mode
        );

        /* window refers to an Window* */
        /// <summary>
        /// Get the window flags.
        /// 
        /// Binding info:
        /// window refers to an Window*
        /// </summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetWindowFlags")]
        public static extern uint GetWindowFlags(IntPtr window);

        /* IntPtr refers to an Window* */
        /// <summary>
        /// Get a window from a stored ID, or NULL if it doesn't exist.
        /// 
        /// Binding info:
        /// IntPtr refers to an Window*
        /// </summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetWindowFromID")]
        public static extern IntPtr GetWindowFromID(uint id);

        /* window refers to an Window* */
        /// <summary>
        /// Get the gamma ramp for a window.
        /// 
        /// Binding info:
        /// window refers to an Window*
        /// </summary>
        /// <param name="window">The window from which the gamma ramp should be queried.</param>
        /// <param name="red">A pointer to a 256 element array of 16-bit quantities to hold the translation table for the red channel, or NULL.</param>
        /// <param name="green">A pointer to a 256 element array of 16-bit quantities to hold the translation table for the green channel, or NULL.</param>
        /// <param name="blue">A pointer to a 256 element array of 16-bit quantities to hold the translation table for the blue channel, or NULL.</param>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetWindowGammaRamp")]
        public static extern int GetWindowGammaRamp(
            IntPtr window,
            [Out()] [MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U2, SizeConst = 256)]
                ushort[] red,
            [Out()] [MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U2, SizeConst = 256)]
                ushort[] green,
            [Out()] [MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U2, SizeConst = 256)]
                ushort[] blue
        );

        /* window refers to an Window* */
        /// <summary>
        /// Get a window's input grab mode.
        /// 
        /// Binding info:
        /// window refers to an Window*
        /// </summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetWindowGrab")]
        public static extern bool GetWindowGrab(IntPtr window);

        /* window refers to an Window* */
        /// <summary>
        /// Get the numeric ID of a window, for logging purposes.
        /// 
        /// Binding info:
        /// window refers to an Window*
        /// </summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetWindowID")]
        public static extern uint GetWindowID(IntPtr window);

        /* window refers to an Window* */
        /// <summary>
        /// Get the pixel format associated with the window.
        /// 
        /// Binding info:
        /// window refers to an Window*
        /// </summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetWindowPixelFormat")]
        public static extern uint GetWindowPixelFormat(
            IntPtr window
        );

        /* window refers to an Window* */
        /// <summary>
        /// Get the maximum size of a window's client area.
        /// 
        /// Binding info:
        /// window refers to an Window*
        /// </summary>
        /// <param name="window">The window to query.</param>
        /// <param name="w">Pointer to variable for storing the maximum width, may be NULL</param>
        /// <param name="h">Pointer to variable for storing the maximum height, may be NULL</param>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetWindowMaximumSize")]
        public static extern void GetWindowMaximumSize(
            IntPtr window,
            out int max_w,
            out int max_h
        );

        /* window refers to an Window* */
        /// <summary>
        /// Get the minimum size of a window's client area.
        /// 
        /// Binding info:
        /// window refers to an Window*
        /// </summary>
        /// <param name="window">The window to query.</param>
        /// <param name="w">Pointer to variable for storing the minimum width, may be NULL</param>
        /// <param name="h">Pointer to variable for storing the minimum height, may be NULL</param>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetWindowMinimumSize")]
        public static extern void GetWindowMinimumSize(
            IntPtr window,
            out int min_w,
            out int min_h
        );

        /* window refers to an Window* */
        /// <summary>
        /// Get the position of a window.
        /// 
        /// Binding info:
        /// window refers to an Window*
        /// </summary>
        /// <param name="window">The window to query.</param>
        /// <param name="x">Pointer to variable for storing the x position, in screen coordinates. May be NULL.</param>
        /// <param name="y">Pointer to variable for storing the y position, in screen coordinates. May be NULL.</param>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetWindowPosition")]
        public static extern void GetWindowPosition(
            IntPtr window,
            out int x,
            out int y
        );

        /* window refers to an Window* */
        /// <summary>
        /// Get the size of a window's client area. 
        /// The window size in screen coordinates may differ from the size in pixels, if the window was created with SDL_WINDOW_ALLOW_HIGHDPI on a platform with high-dpi support (e.g. iOS or OS X). Use  or  to get the real client area size in pixels.
        /// 
        /// Binding info:
        /// window refers to an Window*
        /// </summary>
        /// <param name="window">The window to query.</param>
        /// <param name="w">Pointer to variable for storing the width, in screen coordinates. May be NULL.</param>
        /// <param name="h">Pointer to variable for storing the height, in screen coordinates. May be NULL.</param>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetWindowSize")]
        public static extern void GetWindowSize(
            IntPtr window,
            out int w,
            out int h
        );

        /* IntPtr refers to an Surface*, window to an Window* */
        /// <summary>
        /// Get the SDL surface associated with the window. 
        /// A new surface will be created with the optimal format for the window, if necessary. This surface will be freed when the window is destroyed.
        /// 
        /// Binding info:
        /// IntPtr refers to an Surface*, window to an Window*
        /// </summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetWindowSurface")]
        public static extern IntPtr GetWindowSurface(IntPtr window);

        /* window refers to an Window* */
        /// <summary>
        /// Get the title of a window, in UTF-8 format.
        /// 
        /// Binding info:
        /// window refers to an Window*
        /// </summary>
        [DllImport(nativeLibName, EntryPoint = "SDL_GetWindowTitle", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr INTERNAL_GetWindowTitle(
            IntPtr window
        );
        public static string GetWindowTitle(IntPtr window)
        {
            return UTF8_ToManaged(
                INTERNAL_GetWindowTitle(window)
            );
        }

        /* texture refers to an Texture* */
        /// <summary>
        /// Bind the texture to the current OpenGL/ES/ES2 context for use with OpenGL instructions.
        /// 
        /// Binding info:
        /// texture refers to an Texture*
        /// </summary>
        /// <param name="texture">The SDL texture to bind</param>
        /// <param name="texw">A pointer to a float that will be filled with the texture width</param>
        /// <param name="texh">A pointer to a float that will be filled with the texture height</param>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GL_BindTexture")]
        public static extern int GL_BindTexture(
            IntPtr texture,
            out float texw,
            out float texh
        );

        /* IntPtr and window refer to an GLContext and Window* */
        /// <summary>
        /// Create an OpenGL context for use with an OpenGL window, and make it current.
        /// 
        /// Binding info:
        /// IntPtr and window refer to an GLContext and Window*
        /// </summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GL_CreateContext")]
        public static extern IntPtr GL_CreateContext(IntPtr window);

        /* context refers to an GLContext */
        /// <summary>
        /// Delete an OpenGL context.
        /// 
        /// Binding info:
        /// context refers to an GLContext
        /// </summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GL_DeleteContext")]
        public static extern void GL_DeleteContext(IntPtr context);

        /* IntPtr refers to a function pointer */
        /// <summary>
        /// Get the address of an OpenGL function.
        /// 
        /// Binding info:
        /// IntPtr refers to a function pointer
        /// </summary>
        [DllImport(nativeLibName, EntryPoint = "SDL_GL_GetProcAddress", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr INTERNAL_GL_GetProcAddress(
            byte[] proc
        );
        public static IntPtr GL_GetProcAddress(string proc)
        {
            return INTERNAL_GL_GetProcAddress(
                UTF8_ToNative(proc)
            );
        }

        /// <summary>
        /// Dynamically load an OpenGL library. 
        /// This should be done after initializing the video driver, but before creating any OpenGL windows. If no OpenGL library is loaded, the default library will be loaded upon creation of the first OpenGL window.
        /// </summary>
        /// <param name="path">The platform dependent OpenGL library name, or NULL to open the default OpenGL library.</param>
        [DllImport(nativeLibName, EntryPoint = "SDL_GL_LoadLibrary", CallingConvention = CallingConvention.Cdecl)]
        private static extern int INTERNAL_GL_LoadLibrary(byte[] path);
        public static int GL_LoadLibrary(string path)
        {
            return INTERNAL_GL_LoadLibrary(
                UTF8_ToNative(path)
            );
        }

        /* IntPtr refers to a function pointer, proc to a const char* */
        /// <summary>
        /// Get the address of an OpenGL function.
        /// 
        /// Binding info:
        /// IntPtr refers to a function pointer, proc to a const char*
        /// </summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GL_GetProcAddress")]
        public static extern IntPtr GL_GetProcAddress(IntPtr proc);

        /// <summary>Unload the OpenGL library previously loaded by SDL_GL_LoadLibrary().</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GL_UnloadLibrary")]
        public static extern void GL_UnloadLibrary();

        /// <summary>Return true if an OpenGL extension is supported for the current context.</summary>
        [DllImport(nativeLibName, EntryPoint = "SDL_GL_ExtensionSupported", CallingConvention = CallingConvention.Cdecl)]
        private static extern bool INTERNAL_GL_ExtensionSupported(
            byte[] extension
        );
        public static bool GL_ExtensionSupported(string extension)
        {
            return INTERNAL_GL_ExtensionSupported(
                UTF8_ToNative(extension)
            );
        }

        /* Only available in SDL 2.0.2 or higher */
        /// <summary>
        /// Reset all previously set OpenGL context attributes to their default values.
        /// 
        /// Binding info:
        /// Only available in SDL 2.0.2 or higher
        /// </summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GL_ResetAttributes")]
        public static extern void GL_ResetAttributes();

        /// <summary>Get the actual value for an attribute from the current context.</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GL_GetAttribute")]
        public static extern int GL_GetAttribute(
            GlAttr attr,
            out int value
        );

        /// <summary>Get the swap interval for the current OpenGL context.</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GL_GetSwapInterval")]
        public static extern int GL_GetSwapInterval();

        /* window and context refer to an Window* and GLContext */
        /// <summary>
        /// Set up an OpenGL context for rendering into an OpenGL window.
        /// 
        /// Binding info:
        /// window and context refer to an Window* and GLContext
        /// </summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GL_MakeCurrent")]
        public static extern int GL_MakeCurrent(
            IntPtr window,
            IntPtr context
        );

        /* IntPtr refers to an Window* */
        /// <summary>
        /// Get the currently active OpenGL window.
        /// 
        /// Binding info:
        /// IntPtr refers to an Window*
        /// </summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GL_GetCurrentWindow")]
        public static extern IntPtr GL_GetCurrentWindow();

        /* IntPtr refers to an Context */
        /// <summary>
        /// Get the currently active OpenGL context.
        /// 
        /// Binding info:
        /// IntPtr refers to an Context
        /// </summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GL_GetCurrentContext")]
        public static extern IntPtr GL_GetCurrentContext();

        /* window refers to an Window*, This function is only available in SDL 2.0.1 */
        /// <summary>
        /// Get the size of a window's underlying drawable in pixels (for use with glViewport). 
        /// This may differ from  if we're rendering to a high-DPI drawable, i.e. the window was created with SDL_WINDOW_ALLOW_HIGHDPI on a platform with high-DPI support (Apple calls this "Retina"), and not disabled by the SDL_HINT_VIDEO_HIGHDPI_DISABLED hint.
        /// 
        /// Binding info:
        /// window refers to an Window*, This function is only available in SDL 2.0.1
        /// </summary>
        /// <param name="window">Window from which the drawable size should be queried</param>
        /// <param name="w">Pointer to variable for storing the width in pixels, may be NULL</param>
        /// <param name="h">Pointer to variable for storing the height in pixels, may be NULL</param>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GL_GetDrawableSize")]
        public static extern void GL_GetDrawableSize(
            IntPtr window,
            out int w,
            out int h
        );

        /// <summary>Set an OpenGL window attribute before window creation.</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GL_SetAttribute")]
        public static extern int GL_SetAttribute(
            GlAttr attr,
            int value
        );

        public static int GL_SetAttribute(
            GlAttr attr,
            GlProfile profile
        )
        {
            return GL_SetAttribute(attr, (int)profile);
        }

        /// <summary>Set the swap interval for the current OpenGL context.</summary>
        /// <param name="interval">0 for immediate updates, 1 for updates synchronized with the vertical retrace. If the system supports it, you may specify -1 to allow late swaps to happen immediately instead of waiting for the next retrace.</param>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GL_SetSwapInterval")]
        public static extern int GL_SetSwapInterval(int interval);

        /* window refers to an Window* */
        /// <summary>
        /// Swap the OpenGL buffers for a window, if double-buffering is supported.
        /// 
        /// Binding info:
        /// window refers to an Window*
        /// </summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GL_SwapWindow")]
        public static extern void GL_SwapWindow(IntPtr window);

        /* texture refers to an Texture* */
        /// <summary>
        /// Unbind a texture from the current OpenGL/ES/ES2 context.
        /// 
        /// Binding info:
        /// texture refers to an Texture*
        /// </summary>
        /// <param name="texture">The SDL texture to unbind</param>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GL_UnbindTexture")]
        public static extern int GL_UnbindTexture(IntPtr texture);

        /* window refers to an Window* */
        /// <summary>
        /// Hide a window.
        /// 
        /// Binding info:
        /// window refers to an Window*
        /// </summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_HideWindow")]
        public static extern void HideWindow(IntPtr window);

        /// <summary>Returns whether the screensaver is currently enabled (default off).</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_IsScreenSaverEnabled")]
        public static extern bool IsScreenSaverEnabled();

        /* window refers to an Window* */
        /// <summary>
        /// Make a window as large as possible.
        /// 
        /// Binding info:
        /// window refers to an Window*
        /// </summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_MaximizeWindow")]
        public static extern void MaximizeWindow(IntPtr window);

        /* window refers to an Window* */
        /// <summary>
        /// Minimize a window to an iconic representation.
        /// 
        /// Binding info:
        /// window refers to an Window*
        /// </summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_MinimizeWindow")]
        public static extern void MinimizeWindow(IntPtr window);

        /* window refers to an Window* */
        /// <summary>
        /// Raise a window above other windows and set the input focus.
        /// 
        /// Binding info:
        /// window refers to an Window*
        /// </summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_RaiseWindow")]
        public static extern void RaiseWindow(IntPtr window);

        /* window refers to an Window* */
        /// <summary>
        /// Restore the size and position of a minimized or maximized window.
        /// 
        /// Binding info:
        /// window refers to an Window*
        /// </summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_RestoreWindow")]
        public static extern void RestoreWindow(IntPtr window);

        /* window refers to an Window* */
        /// <summary>
        /// Set the brightness (gamma correction) for a window.
        /// 
        /// Binding info:
        /// window refers to an Window*
        /// </summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_SetWindowBrightness")]
        public static extern int SetWindowBrightness(
            IntPtr window,
            float brightness
        );

        /* IntPtr and userdata are void*, window is an Window* */
        /// <summary>
        /// Associate an arbitrary named pointer with a window.
        /// 
        /// Binding info:
        /// IntPtr and userdata are void*, window is an Window*
        /// </summary>
        /// <param name="window">The window to associate with the pointer.</param>
        /// <param name="name">The name of the pointer.</param>
        /// <param name="userdata">The associated pointer.</param>
        [DllImport(nativeLibName, EntryPoint = "SDL_SetWindowData", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr INTERNAL_SetWindowData(
            IntPtr window,
            byte[] name,
            IntPtr userdata
        );
        public static IntPtr SetWindowData(
            IntPtr window,
            string name,
            IntPtr userdata
        )
        {
            return INTERNAL_SetWindowData(
                window,
                UTF8_ToNative(name),
                userdata
            );
        }

        /* window refers to an Window* */
        /// <summary>
        /// Set the display mode used when a fullscreen window is visible. 
        /// By default the window's dimensions and the desktop format and refresh rate are used.
        /// 
        /// Binding info:
        /// window refers to an Window*
        /// </summary>
        /// <param name="window">The window for which the display mode should be set.</param>
        /// <param name="mode">The mode to use, or NULL for the default mode.</param>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_SetWindowDisplayMode")]
        public static extern int SetWindowDisplayMode(
            IntPtr window,
            ref DisplayMode mode
        );

        /* window refers to an Window* */
        /// <summary>
        /// Set a window's fullscreen state.
        /// 
        /// Binding info:
        /// window refers to an Window*
        /// </summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_SetWindowFullscreen")]
        public static extern int SetWindowFullscreen(
            IntPtr window,
            uint flags
        );

        /* window refers to an Window* */
        /// <summary>
        /// Set the gamma ramp for a window. 
        /// Set the gamma translation table for the red, green, and blue channels of the video hardware. Each table is an array of 256 16-bit quantities, representing a mapping between the input and output for that channel. The input is the index into the array, and the output is the 16-bit gamma value at that index, scaled to the output color precision.
        /// 
        /// Binding info:
        /// window refers to an Window*
        /// </summary>
        /// <param name="window">The window for which the gamma ramp should be set.</param>
        /// <param name="red">The translation table for the red channel, or NULL.</param>
        /// <param name="green">The translation table for the green channel, or NULL.</param>
        /// <param name="blue">The translation table for the blue channel, or NULL.</param>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_SetWindowGammaRamp")]
        public static extern int SetWindowGammaRamp(
            IntPtr window,
            [In()] [MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U2, SizeConst = 256)]
                ushort[] red,
            [In()] [MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U2, SizeConst = 256)]
                ushort[] green,
            [In()] [MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U2, SizeConst = 256)]
                ushort[] blue
        );

        /* window refers to an Window* */
        /// <summary>
        /// Set a window's input grab mode. 
        /// If the caller enables a grab while another window is currently grabbed, the other window loses its grab in favor of the caller's window.
        /// 
        /// Binding info:
        /// window refers to an Window*
        /// </summary>
        /// <param name="window">The window for which the input grab mode should be set.</param>
        /// <param name="grabbed">This is SDL_TRUE to grab input, and SDL_FALSE to release input.</param>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_SetWindowGrab")]
        public static extern void SetWindowGrab(
            IntPtr window,
            bool grabbed
        );

        /* window refers to an Window*, icon to an Surface* */
        /// <summary>
        /// Set the icon for a window.
        /// 
        /// Binding info:
        /// window refers to an Window*, icon to an Surface*
        /// </summary>
        /// <param name="window">The window for which the icon should be set.</param>
        /// <param name="icon">The icon for the window.</param>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_SetWindowIcon")]
        public static extern void SetWindowIcon(
            IntPtr window,
            IntPtr icon
        );

        /* window refers to an Window* */
        /// <summary>
        /// Set the maximum size of a window's client area.
        /// 
        /// Binding info:
        /// window refers to an Window*
        /// </summary>
        /// <param name="window">The window to set a new maximum size.</param>
        /// <param name="max_w">The maximum width of the window, must be >0</param>
        /// <param name="max_h">The maximum height of the window, must be >0</param>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_SetWindowMaximumSize")]
        public static extern void SetWindowMaximumSize(
            IntPtr window,
            int max_w,
            int max_h
        );

        /* window refers to an Window* */
        /// <summary>
        /// Set the minimum size of a window's client area.
        /// 
        /// Binding info:
        /// window refers to an Window*
        /// </summary>
        /// <param name="window">The window to set a new minimum size.</param>
        /// <param name="min_w">The minimum width of the window, must be >0</param>
        /// <param name="min_h">The minimum height of the window, must be >0</param>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_SetWindowMinimumSize")]
        public static extern void SetWindowMinimumSize(
            IntPtr window,
            int min_w,
            int min_h
        );

        /* window refers to an Window* */
        /// <summary>
        /// Set the position of a window.
        /// 
        /// Binding info:
        /// window refers to an Window*
        /// </summary>
        /// <param name="window">The window to reposition.</param>
        /// <param name="x">The x coordinate of the window in screen coordinates, or SDL_WINDOWPOS_CENTERED or SDL_WINDOWPOS_UNDEFINED.</param>
        /// <param name="y">The y coordinate of the window in screen coordinates, or SDL_WINDOWPOS_CENTERED or SDL_WINDOWPOS_UNDEFINED.</param>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_SetWindowPosition")]
        public static extern void SetWindowPosition(
            IntPtr window,
            int x,
            int y
        );

        /* window refers to an Window* */
        /// <summary>
        /// Set the size of a window's client area. 
        /// The window size in screen coordinates may differ from the size in pixels, if the window was created with SDL_WINDOW_ALLOW_HIGHDPI on a platform with high-dpi support (e.g. iOS or OS X). Use  or  to get the real client area size in pixels.
        /// 
        /// Binding info:
        /// window refers to an Window*
        /// </summary>
        /// <param name="window">The window to resize.</param>
        /// <param name="w">The width of the window, in screen coordinates. Must be >0.</param>
        /// <param name="h">The height of the window, in screen coordinates. Must be >0.</param>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_SetWindowSize")]
        public static extern void SetWindowSize(
            IntPtr window,
            int w,
            int h
        );

        /* window refers to an Window* */
        /// <summary>
        /// Set the border state of a window. 
        /// This will add or remove the window's SDL_WINDOW_BORDERLESS flag and add or remove the border from the actual window. This is a no-op if the window's border already matches the requested state.
        /// 
        /// Binding info:
        /// window refers to an Window*
        /// </summary>
        /// <param name="window">The window of which to change the border state.</param>
        /// <param name="bordered">SDL_FALSE to remove border, SDL_TRUE to add border.</param>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_SetWindowBordered")]
        public static extern void SetWindowBordered(
            IntPtr window,
            bool bordered
        );

        /* window refers to an Window* */
        /// <summary>
        /// Get the size of a window's borders (decorations) around the client area.
        /// 
        /// Binding info:
        /// window refers to an Window*
        /// </summary>
        /// <param name="window">The window to query.</param>
        /// <param name="top">Pointer to variable for storing the size of the top border. NULL is permitted.</param>
        /// <param name="left">Pointer to variable for storing the size of the left border. NULL is permitted.</param>
        /// <param name="bottom">Pointer to variable for storing the size of the bottom border. NULL is permitted.</param>
        /// <param name="right">Pointer to variable for storing the size of the right border. NULL is permitted.</param>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetWindowBordersSize")]
        public static extern int GetWindowBordersSize(
            IntPtr window,
            out int top,
            out int left,
            out int bottom,
            out int right
        );

        /* window refers to an Window* */
        /* Available in 2.0.5 or higher */
        /// <summary>
        /// Set the user-resizable state of a window. 
        /// This will add or remove the window's SDL_WINDOW_RESIZABLE flag and allow/disallow user resizing of the window. This is a no-op if the window's resizable state already matches the requested state.
        /// 
        /// Binding info:
        /// Available in 2.0.5 or higher
        /// </summary>
        /// <param name="window">The window of which to change the resizable state.</param>
        /// <param name="resizable">SDL_TRUE to allow resizing, SDL_FALSE to disallow.</param>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_SetWindowResizable")]
        public static extern void SetWindowResizable(
            IntPtr window,
            bool resizable
        );

        /* window refers to an Window* */
        /// <summary>
        /// Set the title of a window, in UTF-8 format.
        /// 
        /// Binding info:
        /// window refers to an Window*
        /// </summary>
        [DllImport(nativeLibName, EntryPoint = "SDL_SetWindowTitle", CallingConvention = CallingConvention.Cdecl)]
        private static extern void INTERNAL_SetWindowTitle(
            IntPtr window,
            byte[] title
        );
        public static void SetWindowTitle(
            IntPtr window,
            string title
        )
        {
            INTERNAL_SetWindowTitle(
                window,
                UTF8_ToNative(title)
            );
        }

        /* window refers to an Window* */
        /// <summary>
        /// Show a window.
        /// 
        /// Binding info:
        /// window refers to an Window*
        /// </summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_ShowWindow")]
        public static extern void ShowWindow(IntPtr window);

        /* window refers to an Window* */
        /// <summary>
        /// Copy the window surface to the screen.
        /// 
        /// Binding info:
        /// window refers to an Window*
        /// </summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_UpdateWindowSurface")]
        public static extern int UpdateWindowSurface(IntPtr window);

        /* window refers to an Window* */
        /// <summary>
        /// Copy a number of rectangles on the window surface to the screen.
        /// 
        /// Binding info:
        /// window refers to an Window*
        /// </summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_UpdateWindowSurfaceRects")]
        public static extern int UpdateWindowSurfaceRects(
            IntPtr window,
            [In] Rect[] rects,
            int numrects
        );

        /// <summary>
        /// Initialize the video subsystem, optionally specifying a video driver. 
        /// This function initializes the video subsystem; setting up a connection to the window manager, etc, and determines the available display modes and pixel formats, but does not initialize a window or graphics mode.
        /// </summary>
        /// <param name="driver_name">Initialize a specific driver by name, or NULL for the default video driver.</param>
        [DllImport(nativeLibName, EntryPoint = "SDL_VideoInit", CallingConvention = CallingConvention.Cdecl)]
        private static extern int INTERNAL_VideoInit(
            byte[] driver_name
        );
        public static int VideoInit(string driver_name)
        {
            return INTERNAL_VideoInit(
                UTF8_ToNative(driver_name)
            );
        }

        /// <summary>
        /// Shuts down the video subsystem. 
        /// This function closes all windows, and restores the original video mode.
        /// </summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_VideoQuit")]
        public static extern void VideoQuit();

        /* window refers to an Window*, callback_data to a void* */
        /* Only available in 2.0.4 */
        /// <summary>
        /// Provide a callback that decides if a window region has special properties. 
        /// Normally windows are dragged and resized by decorations provided by the system window manager (a title bar, borders, etc), but for some apps, it makes sense to drag them from somewhere else inside the window itself; for example, one might have a borderless window that wants to be draggable from any part, or simulate its own title bar, etc.This function lets the app provide a callback that designates pieces of a given window as special. This callback is run during event processing if we need to tell the OS to treat a region of the window specially; the use of this callback is known as "hit testing."Mouse input may not be delivered to your application if it is within a special area; the OS will often apply that input to moving the window or resizing the window and not deliver it to the application.Specifying NULL for a callback disables hit-testing. Hit-testing is disabled by default.Platforms that don't support this functionality will return -1 unconditionally, even if you're attempting to disable hit-testing.Your callback may fire at any time, and its firing does not indicate any specific behavior (for example, on Windows, this certainly might fire when the OS is deciding whether to drag your window, but it fires for lots of other reasons, too, some unrelated to anything you probably care about ). Since this can fire at any time, you should try to keep your callback efficient, devoid of allocations, etc.
        /// 
        /// Binding info:
        /// Only available in 2.0.4
        /// </summary>
        /// <param name="window">The window to set hit-testing on.</param>
        /// <param name="callback">The callback to call when doing a hit-test.</param>
        /// <param name="callback_data">An app-defined void pointer passed to the callback.</param>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_SetWindowHitTest")]
        public static extern int SetWindowHitTest(
            IntPtr window,
            HitTest callback,
            IntPtr callback_data
        );

        /* IntPtr refers to an Window* */
        /* Only available in 2.0.4 */
        /// <summary>
        /// Get the window that currently has an input grab enabled.
        /// 
        /// Binding info:
        /// Only available in 2.0.4
        /// </summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetGrabbedWindow")]
        public static extern IntPtr GetGrabbedWindow();

        #endregion
    }
}
