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
			ContextResetNotification,	/* Only available in 2.0.6 */
			ContextNoError,		/* Only available in 2.0.6 */
		}

		[Flags]
		public enum GlProfile
		{
			Core				= 0x0001,
			Compatibility	= 0x0002,
			Es				= 0x0004
		}

		[Flags]
		public enum GLcontext
		{
			DebugFlag				= 0x0001,
			ForwardCompatibleFlag	= 0x0002,
			RobustAccessFlag		= 0x0004,
			ResetIsolationFlag		= 0x0008
		}

		public enum WindowEventID : byte
		{
			None,
			Shown,
			Hidden,
			Exposed,
			Moved,
			Resized,
			SizeChanged,
			Minimized,
			Maximized,
			Restored,
			Enter,
			Leave,
			FocusGained,
			FocusLost,
			Close,
			/* Available in 2.0.5 or higher */
			TakeFocus,
			HitTest
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
			Fullscreen =		0x00000001,
			OpenGL =		0x00000002,
			Shown =		0x00000004,
			Hidden =		0x00000008,
			Borderless =		0x00000010,
			Resizable =		0x00000020,
			Minimized =		0x00000040,
			Maximized =		0x00000080,
			InputGrabbed =	0x00000100,
			InputFocus =	0x00000200,
			MouseFocus =	0x00000400,
			FullscreenDesktop =
				(Fullscreen | 0x00001000),
			Foreign =		0x00000800,
			AllowHighdpi =	0x00002000,	/* Only available in 2.0.1 */
			MouseCapture =	0x00004000,	/* Only available in 2.0.4 */
			AlwaysOnTop =	0x00008000,	/* Only available in 2.0.5 */
			SkipTaskbar =	0x00010000,	/* Only available in 2.0.5 */
			Utility =		0x00020000,	/* Only available in 2.0.5 */
			Tooltip =		0x00040000,	/* Only available in 2.0.5 */
			PopupMenu =		0x00080000,	/* Only available in 2.0.5 */
			Vulkan =		0x10000000,	/* Only available in 2.0.6 */
		}

		/* Only available in 2.0.4 */
		public enum HitTestResult
		{
			Normal,		/* Region is normal. No special properties. */
			Draggable,		/* Region can drag entire window. */
			ResizeTopleft,
			ResizeTop,
			ResizeTopright,
			ResizeRight,
			ResizeBottomright,
			ResizeBottom,
			ResizeBottomleft,
			ResizeLeft
		}

		public const int WINDOWPOS_UNDEFINED_MASK =	0x1FFF0000;
		public const int WINDOWPOS_CENTERED_MASK =	0x2FFF0000;
		public const int WINDOWPOS_UNDEFINED =	0x1FFF0000;
		public const int WINDOWPOS_CENTERED =	0x2FFF0000;

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

		[StructLayout(LayoutKind.Sequential)]
		public struct DisplayMode
		{
			public uint format;
			public int w;
			public int h;
			public int refresh_rate;
			public IntPtr driverdata; // void*
		}

		/* win refers to an Window*, area to a cosnt Point*, data to a void* */
		/* Only available in 2.0.4 */
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate HitTestResult HitTest(IntPtr win, IntPtr area, IntPtr data);

		/* IntPtr refers to an Window* */
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
		) {
			return INTERNAL_CreateWindow(
				UTF8_ToNative(title),
				x, y, w, h,
				flags
			);
		}

		/* window refers to an Window*, renderer to an Renderer* */
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint="SDL_CreateWindowAndRenderer")]
		public static extern int CreateWindowAndRenderer(
			int width,
			int height,
			WindowFlags window_flags,
			out IntPtr window,
			out IntPtr renderer
		);

		/* data refers to some native window type, IntPtr to an Window* */
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint="SDL_CreateWindowFrom")]
		public static extern IntPtr CreateWindowFrom(IntPtr data);

		/* window refers to an Window* */
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint="SDL_DestroyWindow")]
		public static extern void DestroyWindow(IntPtr window);

		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint="SDL_DisableScreenSaver")]
		public static extern void DisableScreenSaver();

		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint="SDL_EnableScreenSaver")]
		public static extern void EnableScreenSaver();

		/* IntPtr refers to an DisplayMode. Just use closest. */
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint="SDL_GetClosestDisplayMode")]
		public static extern IntPtr GetClosestDisplayMode(
			int displayIndex,
			ref DisplayMode mode,
			out DisplayMode closest
		);

		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint="SDL_GetCurrentDisplayMode")]
		public static extern int GetCurrentDisplayMode(
			int displayIndex,
			out DisplayMode mode
		);

		[DllImport(nativeLibName, EntryPoint = "SDL_GetCurrentVideoDriver", CallingConvention = CallingConvention.Cdecl)]
		private static extern IntPtr INTERNAL_GetCurrentVideoDriver();
		public static string GetCurrentVideoDriver()
		{
			return UTF8_ToManaged(INTERNAL_GetCurrentVideoDriver());
		}

		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint="SDL_GetDesktopDisplayMode")]
		public static extern int GetDesktopDisplayMode(
			int displayIndex,
			out DisplayMode mode
		);

		[DllImport(nativeLibName, EntryPoint = "SDL_GetDisplayName", CallingConvention = CallingConvention.Cdecl)]
		private static extern IntPtr INTERNAL_GetDisplayName(int index);
		public static string GetDisplayName(int index)
		{
			return UTF8_ToManaged(INTERNAL_GetDisplayName(index));
		}

		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint="SDL_GetDisplayBounds")]
		public static extern int GetDisplayBounds(
			int displayIndex,
			out Rect rect
		);

		/* This function is only available in 2.0.4 or higher */
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint="SDL_GetDisplayDPI")]
		public static extern int GetDisplayDPI(
			int displayIndex,
			out float ddpi,
			out float hdpi,
			out float vdpi
		);

		/* This function is only available in 2.0.9 or higher */
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint="SDL_GetDisplayOrientation")]
		public static extern DisplayOrientation GetDisplayOrientation(
			int displayIndex
		);

		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint="SDL_GetDisplayMode")]
		public static extern int GetDisplayMode(
			int displayIndex,
			int modeIndex,
			out DisplayMode mode
		);

		/* Available in 2.0.5 or higher */
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint="SDL_GetDisplayUsableBounds")]
		public static extern int GetDisplayUsableBounds(
			int displayIndex,
			out Rect rect
		);

		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint="SDL_GetNumDisplayModes")]
		public static extern int GetNumDisplayModes(
			int displayIndex
		);

		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint="SDL_GetNumVideoDisplays")]
		public static extern int GetNumVideoDisplays();

		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint="SDL_GetNumVideoDrivers")]
		public static extern int GetNumVideoDrivers();

		[DllImport(nativeLibName, EntryPoint = "SDL_GetVideoDriver", CallingConvention = CallingConvention.Cdecl)]
		private static extern IntPtr INTERNAL_GetVideoDriver(
			int index
		);
		public static string GetVideoDriver(int index)
		{
			return UTF8_ToManaged(INTERNAL_GetVideoDriver(index));
		}

		/* window refers to an Window* */
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint="SDL_GetWindowBrightness")]
		public static extern float GetWindowBrightness(
			IntPtr window
		);

		/* window refers to an Window* */
		/* Available in 2.0.5 or higher */
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint="SDL_SetWindowOpacity")]
		public static extern int SetWindowOpacity(
			IntPtr window,
			float opacity
		);

		/* window refers to an Window* */
		/* Available in 2.0.5 or higher */
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint="SDL_GetWindowOpacity")]
		public static extern int GetWindowOpacity(
			IntPtr window,
			out float out_opacity
		);

		/* modal_window and parent_window refer to an Window*s */
		/* Available in 2.0.5 or higher */
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint="SDL_SetWindowModalFor")]
		public static extern int SetWindowModalFor(
			IntPtr modal_window,
			IntPtr parent_window
		);

		/* window refers to an Window* */
		/* Available in 2.0.5 or higher */
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint="SDL_SetWindowInputFocus")]
		public static extern int SetWindowInputFocus(IntPtr window);

		/* window refers to an Window*, IntPtr to a void* */
		[DllImport(nativeLibName, EntryPoint = "SDL_GetWindowData", CallingConvention = CallingConvention.Cdecl)]
		private static extern IntPtr INTERNAL_GetWindowData(
			IntPtr window,
			byte[] name
		);
		public static IntPtr GetWindowData(
			IntPtr window,
			string name
		) {
			return INTERNAL_GetWindowData(
				window,
				UTF8_ToNative(name)
			);
		}

		/* window refers to an Window* */
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint="SDL_GetWindowDisplayIndex")]
		public static extern int GetWindowDisplayIndex(
			IntPtr window
		);

		/* window refers to an Window* */
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint="SDL_GetWindowDisplayMode")]
		public static extern int GetWindowDisplayMode(
			IntPtr window,
			out DisplayMode mode
		);

		/* window refers to an Window* */
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint="SDL_GetWindowFlags")]
		public static extern uint GetWindowFlags(IntPtr window);

		/* IntPtr refers to an Window* */
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint="SDL_GetWindowFromID")]
		public static extern IntPtr GetWindowFromID(uint id);

		/* window refers to an Window* */
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint="SDL_GetWindowGammaRamp")]
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
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint="SDL_GetWindowGrab")]
		public static extern bool GetWindowGrab(IntPtr window);

		/* window refers to an Window* */
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint="SDL_GetWindowID")]
		public static extern uint GetWindowID(IntPtr window);

		/* window refers to an Window* */
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint="SDL_GetWindowPixelFormat")]
		public static extern uint GetWindowPixelFormat(
			IntPtr window
		);

		/* window refers to an Window* */
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint="SDL_GetWindowMaximumSize")]
		public static extern void GetWindowMaximumSize(
			IntPtr window,
			out int max_w,
			out int max_h
		);

		/* window refers to an Window* */
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint="SDL_GetWindowMinimumSize")]
		public static extern void GetWindowMinimumSize(
			IntPtr window,
			out int min_w,
			out int min_h
		);

		/* window refers to an Window* */
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint="SDL_GetWindowPosition")]
		public static extern void GetWindowPosition(
			IntPtr window,
			out int x,
			out int y
		);

		/* window refers to an Window* */
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint="SDL_GetWindowSize")]
		public static extern void GetWindowSize(
			IntPtr window,
			out int w,
			out int h
		);

		/* IntPtr refers to an Surface*, window to an Window* */
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint="SDL_GetWindowSurface")]
		public static extern IntPtr GetWindowSurface(IntPtr window);

		/* window refers to an Window* */
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
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint="SDL_GL_BindTexture")]
		public static extern int GL_BindTexture(
			IntPtr texture,
			out float texw,
			out float texh
		);

		/* IntPtr and window refer to an GLContext and Window* */
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint="SDL_GL_CreateContext")]
		public static extern IntPtr GL_CreateContext(IntPtr window);

		/* context refers to an GLContext */
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint="SDL_GL_DeleteContext")]
		public static extern void GL_DeleteContext(IntPtr context);

		/* IntPtr refers to a function pointer */
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

		[DllImport(nativeLibName, EntryPoint = "SDL_GL_LoadLibrary", CallingConvention = CallingConvention.Cdecl)]
		private static extern int INTERNAL_GL_LoadLibrary(byte[] path);
		public static int GL_LoadLibrary(string path)
		{
			return INTERNAL_GL_LoadLibrary(
				UTF8_ToNative(path)
			);
		}

		/* IntPtr refers to a function pointer, proc to a const char* */
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint="SDL_GL_GetProcAddress")]
		public static extern IntPtr GL_GetProcAddress(IntPtr proc);

		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint="SDL_GL_UnloadLibrary")]
		public static extern void GL_UnloadLibrary();

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
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint="SDL_GL_ResetAttributes")]
		public static extern void GL_ResetAttributes();

		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint="SDL_GL_GetAttribute")]
		public static extern int GL_GetAttribute(
			GlAttr attr,
			out int value
		);

		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint="SDL_GL_GetSwapInterval")]
		public static extern int GL_GetSwapInterval();

		/* window and context refer to an Window* and GLContext */
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint="SDL_GL_MakeCurrent")]
		public static extern int GL_MakeCurrent(
			IntPtr window,
			IntPtr context
		);

		/* IntPtr refers to an Window* */
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint="SDL_GL_GetCurrentWindow")]
		public static extern IntPtr GL_GetCurrentWindow();

		/* IntPtr refers to an Context */
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint="SDL_GL_GetCurrentContext")]
		public static extern IntPtr GL_GetCurrentContext();

		/* window refers to an Window*, This function is only available in SDL 2.0.1 */
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint="SDL_GL_GetDrawableSize")]
		public static extern void GL_GetDrawableSize(
			IntPtr window,
			out int w,
			out int h
		);

		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint="SDL_GL_SetAttribute")]
		public static extern int GL_SetAttribute(
			GlAttr attr,
			int value
		);

		public static int GL_SetAttribute(
			GlAttr attr,
			GlProfile profile
		) {
			return GL_SetAttribute(attr, (int)profile);
		}

		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint="SDL_GL_SetSwapInterval")]
		public static extern int GL_SetSwapInterval(int interval);

		/* window refers to an Window* */
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint="SDL_GL_SwapWindow")]
		public static extern void GL_SwapWindow(IntPtr window);

		/* texture refers to an Texture* */
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint="SDL_GL_UnbindTexture")]
		public static extern int GL_UnbindTexture(IntPtr texture);

		/* window refers to an Window* */
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint="SDL_HideWindow")]
		public static extern void HideWindow(IntPtr window);

		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint="SDL_IsScreenSaverEnabled")]
		public static extern bool IsScreenSaverEnabled();

		/* window refers to an Window* */
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint="SDL_MaximizeWindow")]
		public static extern void MaximizeWindow(IntPtr window);

		/* window refers to an Window* */
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint="SDL_MinimizeWindow")]
		public static extern void MinimizeWindow(IntPtr window);

		/* window refers to an Window* */
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint="SDL_RaiseWindow")]
		public static extern void RaiseWindow(IntPtr window);

		/* window refers to an Window* */
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint="SDL_RestoreWindow")]
		public static extern void RestoreWindow(IntPtr window);

		/* window refers to an Window* */
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint="SDL_SetWindowBrightness")]
		public static extern int SetWindowBrightness(
			IntPtr window,
			float brightness
		);

		/* IntPtr and userdata are void*, window is an Window* */
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
		) {
			return INTERNAL_SetWindowData(
				window,
				UTF8_ToNative(name),
				userdata
			);
		}

		/* window refers to an Window* */
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint="SDL_SetWindowDisplayMode")]
		public static extern int SetWindowDisplayMode(
			IntPtr window,
			ref DisplayMode mode
		);

		/* window refers to an Window* */
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint="SDL_SetWindowFullscreen")]
		public static extern int SetWindowFullscreen(
			IntPtr window,
			uint flags
		);

		/* window refers to an Window* */
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint="SDL_SetWindowGammaRamp")]
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
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint="SDL_SetWindowGrab")]
		public static extern void SetWindowGrab(
			IntPtr window,
			bool grabbed
		);

		/* window refers to an Window*, icon to an Surface* */
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint="SDL_SetWindowIcon")]
		public static extern void SetWindowIcon(
			IntPtr window,
			IntPtr icon
		);

		/* window refers to an Window* */
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint="SDL_SetWindowMaximumSize")]
		public static extern void SetWindowMaximumSize(
			IntPtr window,
			int max_w,
			int max_h
		);

		/* window refers to an Window* */
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint="SDL_SetWindowMinimumSize")]
		public static extern void SetWindowMinimumSize(
			IntPtr window,
			int min_w,
			int min_h
		);

		/* window refers to an Window* */
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint="SDL_SetWindowPosition")]
		public static extern void SetWindowPosition(
			IntPtr window,
			int x,
			int y
		);

		/* window refers to an Window* */
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint="SDL_SetWindowSize")]
		public static extern void SetWindowSize(
			IntPtr window,
			int w,
			int h
		);

		/* window refers to an Window* */
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint="SDL_SetWindowBordered")]
		public static extern void SetWindowBordered(
			IntPtr window,
			bool bordered
		);

		/* window refers to an Window* */
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint="SDL_GetWindowBordersSize")]
		public static extern int GetWindowBordersSize(
			IntPtr window,
			out int top,
			out int left,
			out int bottom,
			out int right
		);

		/* window refers to an Window* */
		/* Available in 2.0.5 or higher */
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint="SDL_SetWindowResizable")]
		public static extern void SetWindowResizable(
			IntPtr window,
			bool resizable
		);

		/* window refers to an Window* */
		[DllImport(nativeLibName, EntryPoint = "SDL_SetWindowTitle", CallingConvention = CallingConvention.Cdecl)]
		private static extern void INTERNAL_SetWindowTitle(
			IntPtr window,
			byte[] title
		);
		public static void SetWindowTitle(
			IntPtr window,
			string title
		) {
			INTERNAL_SetWindowTitle(
				window,
				UTF8_ToNative(title)
			);
		}

		/* window refers to an Window* */
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint="SDL_ShowWindow")]
		public static extern void ShowWindow(IntPtr window);

		/* window refers to an Window* */
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint="SDL_UpdateWindowSurface")]
		public static extern int UpdateWindowSurface(IntPtr window);

		/* window refers to an Window* */
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint="SDL_UpdateWindowSurfaceRects")]
		public static extern int UpdateWindowSurfaceRects(
			IntPtr window,
			[In] Rect[] rects,
			int numrects
		);

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

		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint="SDL_VideoQuit")]
		public static extern void VideoQuit();

		/* window refers to an Window*, callback_data to a void* */
		/* Only available in 2.0.4 */
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint="SDL_SetWindowHitTest")]
		public static extern int SetWindowHitTest(
			IntPtr window,
			HitTest callback,
			IntPtr callback_data
		);

		/* IntPtr refers to an Window* */
		/* Only available in 2.0.4 */
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint="SDL_GetGrabbedWindow")]
		public static extern IntPtr GetGrabbedWindow();

		#endregion
    }
}
