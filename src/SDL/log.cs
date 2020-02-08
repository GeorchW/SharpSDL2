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


		#region log.h

		/* Begin nameless enum LOG_CATEGORY */
		public const int LOG_CATEGORY_APPLICATION = 0;
		public const int LOG_CATEGORY_ERROR = 1;
		public const int LOG_CATEGORY_ASSERT = 2;
		public const int LOG_CATEGORY_SYSTEM = 3;
		public const int LOG_CATEGORY_AUDIO = 4;
		public const int LOG_CATEGORY_VIDEO = 5;
		public const int LOG_CATEGORY_RENDER = 6;
		public const int LOG_CATEGORY_INPUT = 7;
		public const int LOG_CATEGORY_TEST = 8;

		/* Reserved for future SDL library use */
		public const int LOG_CATEGORY_RESERVED1 = 9;
		public const int LOG_CATEGORY_RESERVED2 = 10;
		public const int LOG_CATEGORY_RESERVED3 = 11;
		public const int LOG_CATEGORY_RESERVED4 = 12;
		public const int LOG_CATEGORY_RESERVED5 = 13;
		public const int LOG_CATEGORY_RESERVED6 = 14;
		public const int LOG_CATEGORY_RESERVED7 = 15;
		public const int LOG_CATEGORY_RESERVED8 = 16;
		public const int LOG_CATEGORY_RESERVED9 = 17;
		public const int LOG_CATEGORY_RESERVED10 = 18;

		/* Beyond this point is reserved for application use, e.g.
			enum {
				LogCategoryAwesome1 = LogCategoryCustom,
				LogCategoryAwesome2,
				LogCategoryAwesome3,
				...
			};
		*/
		public const int LOG_CATEGORY_CUSTOM = 19;
		/* End nameless enum LOG_CATEGORY */

		public enum LogPriority
		{
			Verbose = 1,
			Debug,
			Info,
			Warn,
			Error,
			Critical,
			NumLogPriorities
		}

		/* userdata refers to a void*, message to a const char* */
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void LogOutputFunction(
			IntPtr userdata,
			int category,
			LogPriority priority,
			IntPtr message
		);

		/* Use string.Format for arglists */
		[DllImport(nativeLibName, EntryPoint = "SDL_Log", CallingConvention = CallingConvention.Cdecl)]
		private static extern void INTERNAL_Log(byte[] fmtAndArglist);
		public static void Log(string fmtAndArglist)
		{
			INTERNAL_Log(
				UTF8_ToNative(fmtAndArglist)
			);
		}

		/* Use string.Format for arglists */
		[DllImport(nativeLibName, EntryPoint = "SDL_LogVerbose", CallingConvention = CallingConvention.Cdecl)]
		private static extern void INTERNAL_LogVerbose(
			int category,
			byte[] fmtAndArglist
		);
		public static void LogVerbose(
			int category,
			string fmtAndArglist
		) {
			INTERNAL_LogVerbose(
				category,
				UTF8_ToNative(fmtAndArglist)
			);
		}

		/* Use string.Format for arglists */
		[DllImport(nativeLibName, EntryPoint = "SDL_LogDebug", CallingConvention = CallingConvention.Cdecl)]
		private static extern void INTERNAL_LogDebug(
			int category,
			byte[] fmtAndArglist
		);
		public static void LogDebug(
			int category,
			string fmtAndArglist
		) {
			INTERNAL_LogDebug(
				category,
				UTF8_ToNative(fmtAndArglist)
			);
		}

		/* Use string.Format for arglists */
		[DllImport(nativeLibName, EntryPoint = "SDL_LogInfo", CallingConvention = CallingConvention.Cdecl)]
		private static extern void INTERNAL_LogInfo(
			int category,
			byte[] fmtAndArglist
		);
		public static void LogInfo(
			int category,
			string fmtAndArglist
		) {
			INTERNAL_LogInfo(
				category,
				UTF8_ToNative(fmtAndArglist)
			);
		}

		/* Use string.Format for arglists */
		[DllImport(nativeLibName, EntryPoint = "SDL_LogWarn", CallingConvention = CallingConvention.Cdecl)]
		private static extern void INTERNAL_LogWarn(
			int category,
			byte[] fmtAndArglist
		);
		public static void LogWarn(
			int category,
			string fmtAndArglist
		) {
			INTERNAL_LogWarn(
				category,
				UTF8_ToNative(fmtAndArglist)
			);
		}

		/* Use string.Format for arglists */
		[DllImport(nativeLibName, EntryPoint = "SDL_LogError", CallingConvention = CallingConvention.Cdecl)]
		private static extern void INTERNAL_LogError(
			int category,
			byte[] fmtAndArglist
		);
		public static void LogError(
			int category,
			string fmtAndArglist
		) {
			INTERNAL_LogError(
				category,
				UTF8_ToNative(fmtAndArglist)
			);
		}

		/* Use string.Format for arglists */
		[DllImport(nativeLibName, EntryPoint = "SDL_LogCritical", CallingConvention = CallingConvention.Cdecl)]
		private static extern void INTERNAL_LogCritical(
			int category,
			byte[] fmtAndArglist
		);
		public static void LogCritical(
			int category,
			string fmtAndArglist
		) {
			INTERNAL_LogCritical(
				category,
				UTF8_ToNative(fmtAndArglist)
			);
		}

		/* Use string.Format for arglists */
		[DllImport(nativeLibName, EntryPoint = "SDL_LogMessage", CallingConvention = CallingConvention.Cdecl)]
		private static extern void INTERNAL_LogMessage(
			int category,
			LogPriority priority,
			byte[] fmtAndArglist
		);
		public static void LogMessage(
			int category,
			LogPriority priority,
			string fmtAndArglist
		) {
			INTERNAL_LogMessage(
				category,
				priority,
				UTF8_ToNative(fmtAndArglist)
			);
		}

		/* Use string.Format for arglists */
		[DllImport(nativeLibName, EntryPoint = "SDL_LogMessageV", CallingConvention = CallingConvention.Cdecl)]
		private static extern void INTERNAL_LogMessageV(
			int category,
			LogPriority priority,
			byte[] fmtAndArglist
		);
		public static void LogMessageV(
			int category,
			LogPriority priority,
			string fmtAndArglist
		) {
			INTERNAL_LogMessageV(
				category,
				priority,
				UTF8_ToNative(fmtAndArglist)
			);
		}

		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint="SDL_LogGetPriority")]
		public static extern LogPriority LogGetPriority(
			int category
		);

		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint="SDL_LogSetPriority")]
		public static extern void LogSetPriority(
			int category,
			LogPriority priority
		);

		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint="SDL_LogSetAllPriority")]
		public static extern void LogSetAllPriority(
			LogPriority priority
		);

		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint="SDL_LogResetPriorities")]
		public static extern void LogResetPriorities();

		/* userdata refers to a void* */
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		private static extern void LogGetOutputFunction(
			out IntPtr callback,
			out IntPtr userdata
		);
		public static void LogGetOutputFunction(
			out LogOutputFunction callback,
			out IntPtr userdata
		) {
			IntPtr result = IntPtr.Zero;
			LogGetOutputFunction(
				out result,
				out userdata
			);
			if (result != IntPtr.Zero)
			{
				callback = (LogOutputFunction) Marshal.GetDelegateForFunctionPointer(
					result,
					typeof(LogOutputFunction)
				);
			}
			else
			{
				callback = null;
			}
		}

		/* userdata refers to a void* */
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint="SDL_LogSetOutputFunction")]
		public static extern void LogSetOutputFunction(
			LogOutputFunction callback,
			IntPtr userdata
		);

		#endregion
    }
}
