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
    #region filesystem.h
    public static partial class SDL
    {
        /* Only available in 2.0.1 */
        /// <summary>
        /// Get the path where the application resides. 
        /// Get the "base path". This is the directory where the application was run from, which is probably the installation directory, and may or may not be the process's current working directory.This returns an absolute path in UTF-8 encoding, and is guaranteed to end with a path separator ('\' on Windows, '/' most other places).The pointer returned by this function is owned by you. Please call  on the pointer when you are done with it, or it will be a memory leak. This is not necessarily a fast call, though, so you should call this once near startup and save the string if you need it.Some platforms can't determine the application's path, and on other platforms, this might be meaningless. In such cases, this function will return NULL.
        /// 
        /// Binding info:
        /// Only available in 2.0.1
        /// </summary>
        [DllImport(nativeLibName, EntryPoint = "SDL_GetBasePath", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr INTERNAL_GetBasePath();
        public static string GetBasePath()
        {
            return UTF8_ToManaged(INTERNAL_GetBasePath(), true);
        }

        /* Only available in 2.0.1 */
        /// <summary>
        /// Get the user-and-app-specific path where files can be written. 
        /// Get the "pref dir". This is meant to be where users can write personal files (preferences and save games, etc) that are specific to your application. This directory is unique per user, per application.This function will decide the appropriate location in the native filesystem, create the directory if necessary, and return a string of the absolute path to the directory in UTF-8 encoding.On Windows, the string might look like: "C:\\Users\\bob\\AppData\\Roaming\\My Company\\My Program Name\\"On Linux, the string might look like: "/home/bob/.local/share/My Program Name/"On Mac OS X, the string might look like: "/Users/bob/Library/Application Support/My Program Name/"(etc.)You specify the name of your organization (if it's not a real organization, your name or an Internet domain you own might do) and the name of your application. These should be untranslated proper names.Both the org and app strings may become part of a directory name, so please follow these rules:
        /// This returns an absolute path in UTF-8 encoding, and is guaranteed to end with a path separator ('\' on Windows, '/' most other places).The pointer returned by this function is owned by you. Please call  on the pointer when you are done with it, or it will be a memory leak. This is not necessarily a fast call, though, so you should call this once near startup and save the string if you need it.You should assume the path returned by this function is the only safe place to write files (and that , while it might be writable, or even the parent of the returned path, aren't where you should be writing things).Some platforms can't determine the pref path, and on other platforms, this might be meaningless. In such cases, this function will return NULL.
        /// 
        /// Binding info:
        /// Only available in 2.0.1
        /// </summary>
        /// <param name="org">The name of your organization.</param>
        /// <param name="app">The name of your application.</param>
        [DllImport(nativeLibName, EntryPoint = "SDL_GetPrefPath", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr INTERNAL_GetPrefPath(
            byte[] org,
            byte[] app
        );
        public static string GetPrefPath(string org, string app)
        {
            return UTF8_ToManaged(
                INTERNAL_GetPrefPath(
                    UTF8_ToNative(org),
                    UTF8_ToNative(app)
                ),
                true
            );
        }
    }
    #endregion
}
