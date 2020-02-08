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

		#region SDL2# Variables

		private const string nativeLibName = "SDL2";

		#endregion


		#region UTF8 Marshaling

		internal static byte[] UTF8_ToNative(string s)
		{
			if (s == null)
			{
				return null;
			}

			// Add a null terminator. That's kind of it... :/
			return System.Text.Encoding.UTF8.GetBytes(s + '\0');
		}

		/* This is public because DropEvent needs it! */
		public static unsafe string UTF8_ToManaged(IntPtr s, bool freePtr = false)
		{
			if (s == IntPtr.Zero)
			{
				return null;
			}

			/* We get to do strlen ourselves! */
			byte* ptr = (byte*) s;
			while (*ptr != 0)
			{
				ptr++;
			}

			/* TODO: This #ifdef is only here because the equivalent
			 * .NET 2.0 constructor appears to be less efficient?
			 * Here's the pretty version, maybe steal this instead:
			 *
			string result = new string(
				(sbyte*) s, // Also, why sbyte???
				0,
				(int) (ptr - (byte*) s),
				System.Text.Encoding.UTF8
			);
			 * See the CoreCLR source for more info.
			 * -flibit
			 */
#if NETSTANDARD2_0
			/* Modern C# lets you just send the byte*, nice! */
			string result = System.Text.Encoding.UTF8.GetString(
				(byte*) s,
				(int) (ptr - (byte*) s)
			);
#else
			/* Old C# requires an extra memcpy, bleh! */
			int len = (int) (ptr - (byte*) s);
			if (len == 0)
			{
				return string.Empty;
			}
			char* chars = stackalloc char[len];
			int strLen = System.Text.Encoding.UTF8.GetChars((byte*) s, len, chars, len);
			string result = new string(chars, 0, strLen);
#endif

			/* Some SDL functions will malloc, we have to free! */
			if (freePtr)
			{
				free(s);
			}
			return result;
		}

		#endregion
    }
}
