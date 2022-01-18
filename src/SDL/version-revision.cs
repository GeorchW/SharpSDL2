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
using System.ComponentModel;
using System.Data.Common;
using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
#endregion
namespace SDL2
{

    #region version.h, revision.h
    [StructLayout(LayoutKind.Sequential)]
    public struct Version
    {
        public byte Major;
        public byte Minor;
        public byte Patch;

        public Version(byte major, byte minor, byte patch) {
            Major = major;
            Minor = minor;
            Patch = patch;
        }

        public Version(string version) {
            string[] verStr = version.Split('.');
            if (verStr.Length < 3)
                throw new ArgumentException("Version length is inappropriate. The format is major.minor.patch (2.0.18).");
            byte.TryParse(verStr[ 0 ], out byte major);
            byte.TryParse(verStr[ 1 ], out byte minor);
            byte.TryParse(verStr[ 2 ], out byte patch);
            Major = major;
            Minor = minor;
            Patch = patch;
        }

        public static bool operator ==(Version a, Version b) =>
            a.Major == b.Major && a.Minor == b.Minor && a.Patch == b.Patch;

        public static bool operator !=(Version a, Version b) => !( a == b );

        public static bool operator >=(Version a, Version b) =>
            a.Major >= b.Major && a.Major >= b.Minor && a.Patch >= b.Patch;

        public static bool operator <=(Version a, Version b) => 
            a.Major <= b.Major && a.Major <= b.Minor && a.Patch <= b.Patch;

        #region Overrides of ValueType

        /// <inheritdoc />
        public override string ToString() {
            return $"{Major}.{Minor}.{Patch}";
        }

        #endregion
    }
    public static partial class SDL
    {
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
            x.Major = MAJOR_VERSION;
            x.Minor = MINOR_VERSION;
            x.Patch = PATCHLEVEL;
        }

        public static int VERSIONNUM(int X, int Y, int Z)
        {
            return (X * 1000) + (Y * 100) + Z;
        }

        public static bool VERSION_ATLEAST(int X, int Y, int Z)
        {
            return (COMPILEDVERSION >= VERSIONNUM(X, Y, Z));
        }

        /// <summary>
        /// Get the version of SDL that is linked against your program. 
        /// If you are linking to SDL dynamically, then it is possible that the current version will be different than the version you compiled against. This function returns the current version, while  is a macro that tells you what version you compiled with.This function may be called safely at any time, even before .
        /// </summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetVersion")]
        public static extern void GetVersion(out Version ver);

        /// <summary>
        /// Get the code revision of SDL that is linked against your program. 
        /// Returns an arbitrary string (a hash value) uniquely identifying the exact revision of the SDL library in use, and is only useful in comparing against other revisions. It is NOT an incrementing number.
        /// </summary>
        [DllImport(nativeLibName, EntryPoint = "SDL_GetRevision", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr INTERNAL_GetRevision();
        public static string GetRevision()
        {
            return UTF8_ToManaged(INTERNAL_GetRevision());
        }

        /// <summary>
        /// Get the revision number of SDL that is linked against your program. 
        /// Returns a number uniquely identifying the exact revision of the SDL library in use. It is an incrementing number based on commits to hg.libsdl.org.
        /// </summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetRevisionNumber")]
        public static extern int GetRevisionNumber();
    }
    #endregion
}
