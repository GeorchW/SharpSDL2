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


		#region syswm.h

		public enum SYSWM_TYPE
		{
			SYSWM_UNKNOWN,
			SYSWM_WINDOWS,
			SYSWM_X11,
			SYSWM_DIRECTFB,
			SYSWM_COCOA,
			SYSWM_UIKIT,
			SYSWM_WAYLAND,
			SYSWM_MIR,
			SYSWM_WINRT,
			SYSWM_ANDROID,
			SYSWM_VIVANTE,
			SYSWM_OS2
		}

		// FIXME: I wish these weren't public...
		[StructLayout(LayoutKind.Sequential)]
		public struct INTERNAL_windows_wminfo
		{
			public IntPtr window; // Refers to an HWND
			public IntPtr hdc; // Refers to an HDC
		}

		[StructLayout(LayoutKind.Sequential)]
		public struct INTERNAL_winrt_wminfo
		{
			public IntPtr window; // Refers to an IInspectable*
		}

		[StructLayout(LayoutKind.Sequential)]
		public struct INTERNAL_x11_wminfo
		{
			public IntPtr display; // Refers to a Display*
			public IntPtr window; // Refers to a Window (XID, use ToInt64!)
		}

		[StructLayout(LayoutKind.Sequential)]
		public struct INTERNAL_directfb_wminfo
		{
			public IntPtr dfb; // Refers to an IDirectFB*
			public IntPtr window; // Refers to an IDirectFBWindow*
			public IntPtr surface; // Refers to an IDirectFBSurface*
		}

		[StructLayout(LayoutKind.Sequential)]
		public struct INTERNAL_cocoa_wminfo
		{
			public IntPtr window; // Refers to an NSWindow*
		}

		[StructLayout(LayoutKind.Sequential)]
		public struct INTERNAL_uikit_wminfo
		{
			public IntPtr window; // Refers to a UIWindow*
			public uint framebuffer;
			public uint colorbuffer;
			public uint resolveFramebuffer;
		}

		[StructLayout(LayoutKind.Sequential)]
		public struct INTERNAL_wayland_wminfo
		{
			public IntPtr display; // Refers to a wl_display*
			public IntPtr surface; // Refers to a wl_surface*
			public IntPtr shell_surface; // Refers to a wl_shell_surface*
		}

		[StructLayout(LayoutKind.Sequential)]
		public struct INTERNAL_mir_wminfo
		{
			public IntPtr connection; // Refers to a MirConnection*
			public IntPtr surface; // Refers to a MirSurface*
		}

		[StructLayout(LayoutKind.Sequential)]
		public struct INTERNAL_android_wminfo
		{
			public IntPtr window; // Refers to an ANativeWindow
			public IntPtr surface; // Refers to an EGLSurface
		}

		[StructLayout(LayoutKind.Sequential)]
		public struct INTERNAL_vivante_wminfo
		{
			public IntPtr display; // Refers to an EGLNativeDisplayType
			public IntPtr window; // Refers to an EGLNativeWindowType
		}

		[StructLayout(LayoutKind.Explicit)]
		public struct INTERNAL_SysWMDriverUnion
		{
			[FieldOffset(0)]
			public INTERNAL_windows_wminfo win;
			[FieldOffset(0)]
			public INTERNAL_winrt_wminfo winrt;
			[FieldOffset(0)]
			public INTERNAL_x11_wminfo x11;
			[FieldOffset(0)]
			public INTERNAL_directfb_wminfo dfb;
			[FieldOffset(0)]
			public INTERNAL_cocoa_wminfo cocoa;
			[FieldOffset(0)]
			public INTERNAL_uikit_wminfo uikit;
			[FieldOffset(0)]
			public INTERNAL_wayland_wminfo wl;
			[FieldOffset(0)]
			public INTERNAL_mir_wminfo mir;
			[FieldOffset(0)]
			public INTERNAL_android_wminfo android;
			[FieldOffset(0)]
			public INTERNAL_vivante_wminfo vivante;
			// private int dummy;
		}

		[StructLayout(LayoutKind.Sequential)]
		public struct SysWMinfo
		{
			public Version version;
			public SYSWM_TYPE subsystem;
			public INTERNAL_SysWMDriverUnion info;
		}

		/* window refers to an Window* */
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint="SDL_GetWindowWMInfo")]
		public static extern bool GetWindowWMInfo(
			IntPtr window,
			ref SysWMinfo info
		);

		#endregion
    }
}
