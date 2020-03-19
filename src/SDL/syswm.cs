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
    #region syswm.h



    public enum SysWmType
    {
        Unknown,
        Windows,
        X11,
        Directfb,
        Cocoa,
        Uikit,
        Wayland,
        Mir,
        Winrt,
        Android,
        Vivante,
        Os2
    }

    // FIXME: I wish these weren't public...
    [StructLayout(LayoutKind.Sequential)]
    public struct INTERNAL_windows_wminfo
    {
        public IntPtr Window; // Refers to an HWND
        public IntPtr Hdc; // Refers to an HDC
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct INTERNAL_winrt_wminfo
    {
        public IntPtr Window; // Refers to an IInspectable*
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct INTERNAL_x11_wminfo
    {
        public IntPtr Display; // Refers to a Display*
        public IntPtr Window; // Refers to a Window (XID, use ToInt64!)
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct INTERNAL_directfb_wminfo
    {
        public IntPtr Dfb; // Refers to an IDirectFB*
        public IntPtr Window; // Refers to an IDirectFBWindow*
        public IntPtr Surface; // Refers to an IDirectFBSurface*
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct INTERNAL_cocoa_wminfo
    {
        public IntPtr Window; // Refers to an NSWindow*
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct INTERNAL_uikit_wminfo
    {
        public IntPtr Window; // Refers to a UIWindow*
        public uint Framebuffer;
        public uint Colorbuffer;
        public uint ResolveFramebuffer;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct INTERNAL_wayland_wminfo
    {
        public IntPtr Display; // Refers to a wl_display*
        public IntPtr Surface; // Refers to a wl_surface*
        public IntPtr ShellSurface; // Refers to a wl_shell_surface*
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct INTERNAL_mir_wminfo
    {
        public IntPtr Connection; // Refers to a MirConnection*
        public IntPtr Surface; // Refers to a MirSurface*
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct INTERNAL_android_wminfo
    {
        public IntPtr Window; // Refers to an ANativeWindow
        public IntPtr Surface; // Refers to an EGLSurface
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct INTERNAL_vivante_wminfo
    {
        public IntPtr Display; // Refers to an EGLNativeDisplayType
        public IntPtr Window; // Refers to an EGLNativeWindowType
    }

    [StructLayout(LayoutKind.Explicit)]
    public struct INTERNAL_SysWMDriverUnion
    {
        [FieldOffset(0)]
        public INTERNAL_windows_wminfo Win;
        [FieldOffset(0)]
        public INTERNAL_winrt_wminfo Winrt;
        [FieldOffset(0)]
        public INTERNAL_x11_wminfo X11;
        [FieldOffset(0)]
        public INTERNAL_directfb_wminfo Dfb;
        [FieldOffset(0)]
        public INTERNAL_cocoa_wminfo Cocoa;
        [FieldOffset(0)]
        public INTERNAL_uikit_wminfo Uikit;
        [FieldOffset(0)]
        public INTERNAL_wayland_wminfo Wl;
        [FieldOffset(0)]
        public INTERNAL_mir_wminfo Mir;
        [FieldOffset(0)]
        public INTERNAL_android_wminfo Android;
        [FieldOffset(0)]
        public INTERNAL_vivante_wminfo Vivante;
        // private int dummy;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct SysWMinfo
    {
        public Version Version;
        public SysWmType Subsystem;
        public INTERNAL_SysWMDriverUnion Info;
    }

    public static partial class SDL
    {
        /* window refers to an Window* */
        /// <summary>
        /// This function allows access to driver-dependent window information. 
        /// You typically use this function like this:
        /// 
        /// Binding info:
        /// window refers to an Window*
        /// </summary>
        /// <param name="window">The window about which information is being requested</param>
        /// <param name="info">This structure must be initialized with the SDL version, and is then filled in with information about the given window.</param>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetWindowWMInfo")]
        public static extern bool GetWindowWMInfo(
            IntPtr window,
            ref SysWMinfo info
        );
    }
    #endregion
}
