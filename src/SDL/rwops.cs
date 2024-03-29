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

        public uint Type;

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

        public const uint RWOPS_UNKNOWN = 0; /* Unknown stream type */
        public const uint RWOPS_WINFILE = 1; /* Win32 file */
        public const uint RWOPS_STDFILE = 2; /* Stdio file */
        public const uint RWOPS_JNIFILE = 3; /* Android asset */
        public const uint RWOPS_MEMORY = 4; /* Memory stream */
        public const uint RWOPS_MEMORY_RO = 5; /* Read-Only memory stream */

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
        /// <summary>
        /// 
        /// 
        /// Binding info:
        /// IntPtr refers to an RWops*
        /// </summary>
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
        /// <summary>
        /// 
        /// 
        /// Binding info:
        /// IntPtr refers to an RWops*
        /// </summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_AllocRW")]
        public static extern IntPtr AllocRW();

        /* area refers to an RWops* */
        /// <summary>
        /// 
        /// 
        /// Binding info:
        /// area refers to an RWops*
        /// </summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_FreeRW")]
        public static extern void FreeRW(IntPtr area);

        /* fp refers to a void* */
        /// <summary>
        /// 
        /// 
        /// Binding info:
        /// fp refers to a void*
        /// </summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_RWFromFP")]
        public static extern IntPtr RWFromFP(IntPtr fp, bool autoclose);

        /* mem refers to a void*, IntPtr to an RWops* */
        /// <summary>
        /// 
        /// 
        /// Binding info:
        /// mem refers to a void*, IntPtr to an RWops*
        /// </summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_RWFromMem")]
        public static extern IntPtr RWFromMem(IntPtr mem, int size);

        /* mem refers to a const void*, IntPtr to an RWops* */
        /// <summary>
        /// 
        /// 
        /// Binding info:
        /// mem refers to a const void*, IntPtr to an RWops*
        /// </summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_RWFromConstMem")]
        public static extern IntPtr RWFromConstMem(IntPtr mem, int size);

        /* Only available in SDL 2.0.10 or higher. */
        /* context refers to an RWops* */
        /// <summary>
        /// Return the size of the file in this rwops, or -1 if unknown
        /// 
        /// Binding info:
        /// context refers to an RWops*
        /// </summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_RWsize")]
        public static extern long RWsize(IntPtr context);

        /* Only available in SDL 2.0.10 or higher. */
        /* context refers to an RWops* */
        /// <summary>
        /// Seek to  relative to , one of stdio's whence values: RW_SEEK_SET, RW_SEEK_CUR, RW_SEEK_END
        /// 
        /// Binding info:
        /// context refers to an RWops*
        /// </summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_RWseek")]
        public static extern long RWseek(
            IntPtr context,
            long offset,
            int whence
        );

        /* Only available in SDL 2.0.10 or higher. */
        /* context refers to an RWops* */
        /// <summary>
        /// Return the current offset in the data stream, or -1 on error.
        /// 
        /// Binding info:
        /// context refers to an RWops*
        /// </summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_RWtell")]
        public static extern long RWtell(IntPtr context);

        /* Only available in SDL 2.0.10 or higher. */
        /* context refers to an RWops*, ptr refers to a void* */
        /// <summary>
        /// Read up to  objects each of size  from the data stream to the area pointed at by .
        /// 
        /// Binding info:
        /// context refers to an RWops*, ptr refers to a void*
        /// </summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_RWread")]
        public static extern long RWread(
            IntPtr context,
            IntPtr ptr,
            IntPtr size,
            IntPtr maxnum
        );

        /* Only available in SDL 2.0.10 or higher. */
        /* context refers to an RWops*, ptr refers to a const void* */
        /// <summary>
        /// Write exactly  objects each of size  from the area pointed at by  to data stream.
        /// 
        /// Binding info:
        /// context refers to an RWops*, ptr refers to a const void*
        /// </summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_RWwrite")]
        public static extern long RWwrite(
            IntPtr context,
            IntPtr ptr,
            IntPtr size,
            IntPtr maxnum
        );

        /* Read endian functions */

        /// <summary>
        /// 
        /// 
        /// Binding info:
        /// Read endian functions
        /// </summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_ReadU8")]
        public static extern byte ReadU8(IntPtr src);

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_ReadLE16")]
        public static extern ushort ReadLE16(IntPtr src);

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_ReadBE16")]
        public static extern ushort ReadBE16(IntPtr src);

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_ReadLE32")]
        public static extern uint ReadLE32(IntPtr src);

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_ReadBE32")]
        public static extern uint ReadBE32(IntPtr src);

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_ReadLE64")]
        public static extern ulong ReadLE64(IntPtr src);

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_ReadBE64")]
        public static extern ulong ReadBE64(IntPtr src);

        /* Write endian functions */

        /// <summary>
        /// 
        /// 
        /// Binding info:
        /// Write endian functions
        /// </summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_WriteU8")]
        public static extern uint WriteU8(IntPtr dst, byte value);

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_WriteLE16")]
        public static extern uint WriteLE16(IntPtr dst, ushort value);

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_WriteBE16")]
        public static extern uint WriteBE16(IntPtr dst, ushort value);

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_WriteLE32")]
        public static extern uint WriteLE32(IntPtr dst, uint value);

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_WriteBE32")]
        public static extern uint WriteBE32(IntPtr dst, uint value);

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_WriteLE64")]
        public static extern uint WriteLE64(IntPtr dst, ulong value);

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_WriteBE64")]
        public static extern uint WriteBE64(IntPtr dst, ulong value);

        /* Only available in SDL 2.0.10 or higher. */
        /* context refers to an RWops* */
        /// <summary>
        /// Close and free an allocated  structure.
        /// 
        /// Binding info:
        /// context refers to an RWops*
        /// </summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_RWclose")]
        public static extern long RWclose(IntPtr context);

        /* Only available in SDL 2.0.10 or higher. */
        /* file refers to a const char*
		 * datasize refers to a size_t*
		 * IntPtr refers to a void*
		*/
        /// <summary>
        /// Load an entire file.The data is allocated with a zero byte at the end (null terminated)If  is not NULL, it is filled with the size of the data read.If  is non-zero, the stream will be closed after being read.The data should be freed with .
        /// 
        /// Binding info:
        /// file refers to a const char*
        /// datasize refers to a size_t*
        /// IntPtr refers to a void*
        /// </summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_LoadFile")]
        public static extern IntPtr LoadFile(IntPtr file, IntPtr datasize);
    }
    #endregion
}
