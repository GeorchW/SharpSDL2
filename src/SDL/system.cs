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
    #region system.h
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr WindowsMessageHook(
        IntPtr userdata,
        IntPtr hWnd,
        uint message,
        ulong wParam,
        long lParam
    );
    public enum WinRT_DeviceFamily
    {
        Unknown,
        Desktop,
        Mobile,
        Xbox
    }
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void iPhoneAnimationCallback(IntPtr p);
    public static partial class SDL
    {
        /* Windows */

        /// <summary>
        /// 
        /// 
        /// Binding info:
        /// Windows
        /// </summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_SetWindowsMessageHook")]
        public static extern void SetWindowsMessageHook(
            WindowsMessageHook callback,
            IntPtr userdata
        );

        /* iOS */
        /// <summary>
        /// Binding info:
        /// iOS
        /// </summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_iPhoneSetAnimationCallback")]
        public static extern int iPhoneSetAnimationCallback(
            IntPtr window, /* Window* */
            int interval,
            iPhoneAnimationCallback callback,
            IntPtr callbackParam
        );

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_iPhoneSetEventPump")]
        public static extern void iPhoneSetEventPump(bool enabled);

        /* Android */
        public const int ANDROID_EXTERNAL_STORAGE_READ = 0x01;
        public const int ANDROID_EXTERNAL_STORAGE_WRITE = 0x02;

        /* IntPtr refers to a JNIEnv* */
        /// <summary>
        /// Binding info:
        /// IntPtr refers to a JNIEnv*
        /// </summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_AndroidGetJNIEnv")]
        public static extern IntPtr AndroidGetJNIEnv();

        /* IntPtr refers to a jobject */
        /// <summary>
        /// Binding info:
        /// IntPtr refers to a jobject
        /// </summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_AndroidGetActivity")]
        public static extern IntPtr AndroidGetActivity();

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_IsAndroidTV")]
        public static extern bool IsAndroidTV();

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_IsChromebook")]
        public static extern bool IsChromebook();

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_IsDeXMode")]
        public static extern bool IsDeXMode();

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_AndroidBackButton")]
        public static extern void AndroidBackButton();

        [DllImport(nativeLibName, EntryPoint = "SDL_AndroidGetInternalStoragePath", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr INTERNAL_AndroidGetInternalStoragePath();

        public static string AndroidGetInternalStoragePath()
        {
            return UTF8_ToManaged(
                INTERNAL_AndroidGetInternalStoragePath()
            );
        }

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_AndroidGetExternalStorageState")]
        public static extern int AndroidGetExternalStorageState();

        [DllImport(nativeLibName, EntryPoint = "SDL_AndroidGetExternalStorageState", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr INTERNAL_AndroidGetExternalStoragePath();

        public static string AndroidGetExternalStoragePath()
        {
            return UTF8_ToManaged(
                INTERNAL_AndroidGetExternalStoragePath()
            );
        }

        /* WinRT */


        /// <summary>
        /// Binding info:
        /// WinRT
        /// </summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_WinRTGetDeviceFamily")]
        public static extern WinRT_DeviceFamily WinRTGetDeviceFamily();

        /// <summary>Return true if the current device is a tablet.</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_IsTablet")]
        public static extern bool IsTablet();
    }
    #endregion
}
