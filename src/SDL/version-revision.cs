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

    [StructLayout(LayoutKind.Sequential)]
    public struct Version
    {
        public byte major;
        public byte minor;
        public byte patch;
    }
    public static partial class SDL
    {


        #region version.h, revision.h

        /* Similar to the headers, this is the version we're expecting to be
		 * running with. You will likely want to check this somewhere in your
		 * program!
		 */
        public const int MAJOR_VERSION = 2;
        public const int MINOR_VERSION = 0;
        public const int PATCHLEVEL = 10;

        public static readonly int COMPILEDVERSION = VERSIONNUM(
            MAJOR_VERSION,
            MINOR_VERSION,
            PATCHLEVEL
        );

        public static void VERSION(out Version x)
        {
            x.major = MAJOR_VERSION;
            x.minor = MINOR_VERSION;
            x.patch = PATCHLEVEL;
        }

        public static int VERSIONNUM(int X, int Y, int Z)
        {
            return (X * 1000) + (Y * 100) + Z;
        }

        public static bool VERSION_ATLEAST(int X, int Y, int Z)
        {
            return (COMPILEDVERSION >= VERSIONNUM(X, Y, Z));
        }

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetVersion")]
        public static extern void GetVersion(out Version ver);

        [DllImport(nativeLibName, EntryPoint = "SDL_GetRevision", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr INTERNAL_GetRevision();
        public static string GetRevision()
        {
            return UTF8_ToManaged(INTERNAL_GetRevision());
        }

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetRevisionNumber")]
        public static extern int GetRevisionNumber();

        #endregion
    }
}
