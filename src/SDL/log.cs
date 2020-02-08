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
    #region log.h

    public enum LogCategory
    {
        Application = 0,
        Error = 1,
        Assert = 2,
        System = 3,
        Audio = 4,
        Video = 5,
        Render = 6,
        Input = 7,
        Test = 8,

        /* Reserved for future SDL library use */
        Reserved1 = 9,
        Reserved2 = 10,
        Reserved3 = 11,
        Reserved4 = 12,
        Reserved5 = 13,
        Reserved6 = 14,
        Reserved7 = 15,
        Reserved8 = 16,
        Reserved9 = 17,
        Reserved10 = 18,

        /* Beyond this point is reserved for application use, e.g.
            enum {
                LogCategoryAwesome1 = LogCategoryCustom,
                LogCategoryAwesome2,
                LogCategoryAwesome3,
                ...
            };
        */
        Custom = 19
    }

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
        LogCategory category,
        LogPriority priority,
        IntPtr message
    );

    public static partial class SDL
    {
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
            LogCategory category,
            byte[] fmtAndArglist
        );
        public static void LogVerbose(
            LogCategory category,
            string fmtAndArglist
        )
        {
            INTERNAL_LogVerbose(
                category,
                UTF8_ToNative(fmtAndArglist)
            );
        }

        /* Use string.Format for arglists */
        [DllImport(nativeLibName, EntryPoint = "SDL_LogDebug", CallingConvention = CallingConvention.Cdecl)]
        private static extern void INTERNAL_LogDebug(
            LogCategory category,
            byte[] fmtAndArglist
        );
        public static void LogDebug(
            LogCategory category,
            string fmtAndArglist
        )
        {
            INTERNAL_LogDebug(
                category,
                UTF8_ToNative(fmtAndArglist)
            );
        }

        /* Use string.Format for arglists */
        [DllImport(nativeLibName, EntryPoint = "SDL_LogInfo", CallingConvention = CallingConvention.Cdecl)]
        private static extern void INTERNAL_LogInfo(
            LogCategory category,
            byte[] fmtAndArglist
        );
        public static void LogInfo(
            LogCategory category,
            string fmtAndArglist
        )
        {
            INTERNAL_LogInfo(
                category,
                UTF8_ToNative(fmtAndArglist)
            );
        }

        /* Use string.Format for arglists */
        [DllImport(nativeLibName, EntryPoint = "SDL_LogWarn", CallingConvention = CallingConvention.Cdecl)]
        private static extern void INTERNAL_LogWarn(
            LogCategory category,
            byte[] fmtAndArglist
        );
        public static void LogWarn(
            LogCategory category,
            string fmtAndArglist
        )
        {
            INTERNAL_LogWarn(
                category,
                UTF8_ToNative(fmtAndArglist)
            );
        }

        /* Use string.Format for arglists */
        [DllImport(nativeLibName, EntryPoint = "SDL_LogError", CallingConvention = CallingConvention.Cdecl)]
        private static extern void INTERNAL_LogError(
            LogCategory category,
            byte[] fmtAndArglist
        );
        public static void LogError(
            LogCategory category,
            string fmtAndArglist
        )
        {
            INTERNAL_LogError(
                category,
                UTF8_ToNative(fmtAndArglist)
            );
        }

        /* Use string.Format for arglists */
        [DllImport(nativeLibName, EntryPoint = "SDL_LogCritical", CallingConvention = CallingConvention.Cdecl)]
        private static extern void INTERNAL_LogCritical(
            LogCategory category,
            byte[] fmtAndArglist
        );
        public static void LogCritical(
            LogCategory category,
            string fmtAndArglist
        )
        {
            INTERNAL_LogCritical(
                category,
                UTF8_ToNative(fmtAndArglist)
            );
        }

        /* Use string.Format for arglists */
        [DllImport(nativeLibName, EntryPoint = "SDL_LogMessage", CallingConvention = CallingConvention.Cdecl)]
        private static extern void INTERNAL_LogMessage(
            LogCategory category,
            LogPriority priority,
            byte[] fmtAndArglist
        );
        public static void LogMessage(
            LogCategory category,
            LogPriority priority,
            string fmtAndArglist
        )
        {
            INTERNAL_LogMessage(
                category,
                priority,
                UTF8_ToNative(fmtAndArglist)
            );
        }

        /* Use string.Format for arglists */
        [DllImport(nativeLibName, EntryPoint = "SDL_LogMessageV", CallingConvention = CallingConvention.Cdecl)]
        private static extern void INTERNAL_LogMessageV(
            LogCategory category,
            LogPriority priority,
            byte[] fmtAndArglist
        );
        public static void LogMessageV(
            LogCategory category,
            LogPriority priority,
            string fmtAndArglist
        )
        {
            INTERNAL_LogMessageV(
                category,
                priority,
                UTF8_ToNative(fmtAndArglist)
            );
        }

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_LogGetPriority")]
        public static extern LogPriority LogGetPriority(
            LogCategory category
        );

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_LogSetPriority")]
        public static extern void LogSetPriority(
            LogCategory category,
            LogPriority priority
        );

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_LogSetAllPriority")]
        public static extern void LogSetAllPriority(
            LogPriority priority
        );

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_LogResetPriorities")]
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
        )
        {
            IntPtr result = IntPtr.Zero;
            LogGetOutputFunction(
                out result,
                out userdata
            );
            if (result != IntPtr.Zero)
            {
                callback = (LogOutputFunction)Marshal.GetDelegateForFunctionPointer(
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
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_LogSetOutputFunction")]
        public static extern void LogSetOutputFunction(
            LogOutputFunction callback,
            IntPtr userdata
        );
    }
    #endregion
}
