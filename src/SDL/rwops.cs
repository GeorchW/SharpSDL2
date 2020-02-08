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
    #region rwops.h

    [StructLayout(LayoutKind.Sequential)]
    public struct RWops
    {
        public IntPtr Size;
        public IntPtr Seek;
        public IntPtr Read;
        public IntPtr Write;
        public IntPtr Close;

        public UInt32 Type;

        /* NOTE: This isn't the full structure since
         * the native RWops contains a hidden union full of
         * internal information and platform-specific stuff depending
         * on what conditions the native library was built with
         */
    }
    public static partial class SDL
    {
        public const int RW_SEEK_SET = 0;
        public const int RW_SEEK_CUR = 1;
        public const int RW_SEEK_END = 2;

        public const UInt32 RWOPS_UNKNOWN = 0; /* Unknown stream type */
        public const UInt32 RWOPS_WINFILE = 1; /* Win32 file */
        public const UInt32 RWOPS_STDFILE = 2; /* Stdio file */
        public const UInt32 RWOPS_JNIFILE = 3; /* Android asset */
        public const UInt32 RWOPS_MEMORY = 4; /* Memory stream */
        public const UInt32 RWOPS_MEMORY_RO = 5; /* Read-Only memory stream */

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate long SDLRWopsSizeCallback(IntPtr context);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate long SDLRWopsSeekCallback(
            IntPtr context,
            long offset,
            int whence
        );

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate IntPtr SDLRWopsReadCallback(
            IntPtr context,
            IntPtr ptr,
            IntPtr size,
            IntPtr maxnum
        );

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate IntPtr SDLRWopsWriteCallback(
            IntPtr context,
            IntPtr ptr,
            IntPtr size,
            IntPtr num
        );

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate int SDLRWopsCloseCallback(
            IntPtr context
        );

        /* IntPtr refers to an RWops* */
        [DllImport(nativeLibName, EntryPoint = "SDL_RWFromFile", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr INTERNAL_RWFromFile(
            byte[] file,
            byte[] mode
        );
        public static IntPtr RWFromFile(
            string file,
            string mode
        )
        {
            return INTERNAL_RWFromFile(
                UTF8_ToNative(file),
                UTF8_ToNative(mode)
            );
        }

        /* IntPtr refers to an RWops* */
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_AllocRW")]
        public static extern IntPtr AllocRW();

        /* area refers to an RWops* */
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_FreeRW")]
        public static extern void FreeRW(IntPtr area);

        /* fp refers to a void* */
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_RWFromFP")]
        public static extern IntPtr RWFromFP(IntPtr fp, bool autoclose);

        /* mem refers to a void*, IntPtr to an RWops* */
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_RWFromMem")]
        public static extern IntPtr RWFromMem(IntPtr mem, int size);

        /* mem refers to a const void*, IntPtr to an RWops* */
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_RWFromConstMem")]
        public static extern IntPtr RWFromConstMem(IntPtr mem, int size);

        /* Only available in SDL 2.0.10 or higher. */
        /* context refers to an RWops* */
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_RWsize")]
        public static extern long RWsize(IntPtr context);

        /* Only available in SDL 2.0.10 or higher. */
        /* context refers to an RWops* */
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_RWseek")]
        public static extern long RWseek(
            IntPtr context,
            long offset,
            int whence
        );

        /* Only available in SDL 2.0.10 or higher. */
        /* context refers to an RWops* */
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_RWtell")]
        public static extern long RWtell(IntPtr context);

        /* Only available in SDL 2.0.10 or higher. */
        /* context refers to an RWops*, ptr refers to a void* */
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_RWread")]
        public static extern long RWread(
            IntPtr context,
            IntPtr ptr,
            IntPtr size,
            IntPtr maxnum
        );

        /* Only available in SDL 2.0.10 or higher. */
        /* context refers to an RWops*, ptr refers to a const void* */
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_RWwrite")]
        public static extern long RWwrite(
            IntPtr context,
            IntPtr ptr,
            IntPtr size,
            IntPtr maxnum
        );

        /* Read endian functions */

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_ReadU8")]
        public static extern byte ReadU8(IntPtr src);

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_ReadLE16")]
        public static extern UInt16 ReadLE16(IntPtr src);

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_ReadBE16")]
        public static extern UInt16 ReadBE16(IntPtr src);

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_ReadLE32")]
        public static extern UInt32 ReadLE32(IntPtr src);

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_ReadBE32")]
        public static extern UInt32 ReadBE32(IntPtr src);

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_ReadLE64")]
        public static extern UInt64 ReadLE64(IntPtr src);

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_ReadBE64")]
        public static extern UInt64 ReadBE64(IntPtr src);

        /* Write endian functions */

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_WriteU8")]
        public static extern uint WriteU8(IntPtr dst, byte value);

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_WriteLE16")]
        public static extern uint WriteLE16(IntPtr dst, UInt16 value);

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_WriteBE16")]
        public static extern uint WriteBE16(IntPtr dst, UInt16 value);

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_WriteLE32")]
        public static extern uint WriteLE32(IntPtr dst, UInt32 value);

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_WriteBE32")]
        public static extern uint WriteBE32(IntPtr dst, UInt32 value);

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_WriteLE64")]
        public static extern uint WriteLE64(IntPtr dst, UInt64 value);

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_WriteBE64")]
        public static extern uint WriteBE64(IntPtr dst, UInt64 value);

        /* Only available in SDL 2.0.10 or higher. */
        /* context refers to an RWops* */
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_RWclose")]
        public static extern long RWclose(IntPtr context);

        /* Only available in SDL 2.0.10 or higher. */
        /* file refers to a const char*
		 * datasize refers to a size_t*
		 * IntPtr refers to a void*
		*/
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_LoadFile")]
        public static extern IntPtr LoadFile(IntPtr file, IntPtr datasize);
    }
    #endregion
}
