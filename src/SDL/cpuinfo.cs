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
    #region cpuinfo.h
    public static partial class SDL
    {
        /// <summary>This function returns the number of CPU cores available.</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetCPUCount")]
        public static extern int GetCPUCount();

        /// <summary>This function returns the L1 cache line size of the CPUThis is useful for determining multi-threaded structure padding or SIMD prefetch sizes.</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetCPUCacheLineSize")]
        public static extern int GetCPUCacheLineSize();

        /// <summary>This function returns true if the CPU has the RDTSC instruction.</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_HasRDTSC")]
        public static extern bool HasRDTSC();

        /// <summary>This function returns true if the CPU has AltiVec features.</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_HasAltiVec")]
        public static extern bool HasAltiVec();

        /// <summary>This function returns true if the CPU has MMX features.</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_HasMMX")]
        public static extern bool HasMMX();

        /// <summary>This function returns true if the CPU has 3DNow! features.</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_Has3DNow")]
        public static extern bool Has3DNow();

        /// <summary>This function returns true if the CPU has SSE features.</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_HasSSE")]
        public static extern bool HasSSE();

        /// <summary>This function returns true if the CPU has SSE2 features.</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_HasSSE2")]
        public static extern bool HasSSE2();

        /// <summary>This function returns true if the CPU has SSE3 features.</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_HasSSE3")]
        public static extern bool HasSSE3();

        /// <summary>This function returns true if the CPU has SSE4.1 features.</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_HasSSE41")]
        public static extern bool HasSSE41();

        /// <summary>This function returns true if the CPU has SSE4.2 features.</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_HasSSE42")]
        public static extern bool HasSSE42();

        /// <summary>This function returns true if the CPU has AVX features.</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_HasAVX")]
        public static extern bool HasAVX();

        /// <summary>This function returns true if the CPU has AVX2 features.</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_HasAVX2")]
        public static extern bool HasAVX2();

        /// <summary>This function returns true if the CPU has AVX-512F (foundation) features.</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_HasAVX512F")]
        public static extern bool HasAVX512F();

        /// <summary>This function returns true if the CPU has NEON (ARM SIMD) features.</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_HasNEON")]
        public static extern bool HasNEON();

        /* Only available in 2.0.1 */
        /// <summary>
        /// This function returns the amount of RAM configured in the system, in MB.
        /// 
        /// Binding info:
        /// Only available in 2.0.1
        /// </summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetSystemRAM")]
        public static extern int GetSystemRAM();

        /* Only available in SDL 2.0.10 or higher. */
        /// <summary>
        /// Report the alignment this system needs for SIMD allocations. 
        /// This will return the minimum number of bytes to which a pointer must be aligned to be compatible with SIMD instructions on the current machine. For example, if the machine supports SSE only, it will return 16, but if it supports AVX-512F, it'll return 64 (etc). This only reports values for instruction sets SDL knows about, so if your SDL build doesn't have , then it might return 16 for the SSE support it sees and not 64 for the AVX-512 instructions that exist but SDL doesn't know about. Plan accordingly.
        /// 
        /// Binding info:
        /// Only available in SDL 2.0.10 or higher.
        /// </summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_SIMDGetAlignment")]
        public static extern uint SIMDGetAlignment();

        /* Only available in SDL 2.0.10 or higher. */
        /// <summary>
        /// Allocate memory in a SIMD-friendly way. 
        /// This will allocate a block of memory that is suitable for use with SIMD instructions. Specifically, it will be properly aligned and padded for the system's supported vector instructions.The memory returned will be padded such that it is safe to read or write an incomplete vector at the end of the memory block. This can be useful so you don't have to drop back to a scalar fallback at the end of your SIMD processing loop to deal with the final elements without overflowing the allocated buffer.You must free this memory with SDL_FreeSIMD(), not free() or  or delete[], etc.Note that SDL will only deal with SIMD instruction sets it is aware of; for example, SDL 2.0.8 knows that SSE wants 16-byte vectors (), and AVX2 wants 32 bytes (), but doesn't know that AVX-512 wants 64. To be clear: if you can't decide to use an instruction set with an SDL_Has*() function, don't use that instruction set with memory allocated through here.SDL_AllocSIMD(0) will return a non-NULL pointer, assuming the system isn't out of memory.
        /// 
        /// Binding info:
        /// Only available in SDL 2.0.10 or higher.
        /// </summary>
        /// <param name="len">The length, in bytes, of the block to allocated. The actual allocated block might be larger due to padding, etc.</param>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_SIMDAlloc")]
        public static extern IntPtr SIMDAlloc(uint len);

        /* Only available in SDL 2.0.10 or higher. */
        /// <summary>
        /// Deallocate memory obtained from SDL_SIMDAlloc. 
        /// It is not valid to use this function on a pointer from anything but . It can't be used on pointers from malloc, realloc, SDL_malloc, memalign, new[], etc.However, SDL_SIMDFree(NULL) is a legal no-op.
        /// 
        /// Binding info:
        /// Only available in SDL 2.0.10 or higher.
        /// </summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_SIMDFree")]
        public static extern void SIMDFree(IntPtr ptr);
    }
    #endregion
}
