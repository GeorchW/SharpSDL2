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


		#region vulkan.h

		/* Only available in 2.0.6 */
		[DllImport(nativeLibName, EntryPoint = "SDL_Vulkan_LoadLibrary", CallingConvention = CallingConvention.Cdecl)]
		private static extern int INTERNAL_Vulkan_LoadLibrary(
			byte[] path
		);
		public static int Vulkan_LoadLibrary(string path)
		{
			return INTERNAL_Vulkan_LoadLibrary(
				UTF8_ToNative(path)
			);
		}

		/* Only available in 2.0.6 */
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint="SDL_Vulkan_GetVkGetInstanceProcAddr")]
		public static extern IntPtr Vulkan_GetVkGetInstanceProcAddr();

		/* Only available in 2.0.6 */
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint="SDL_Vulkan_UnloadLibrary")]
		public static extern void Vulkan_UnloadLibrary();

		/* window refers to an Window*, pNames to a const char**.
		 * Only available in 2.0.6.
		 */
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint="SDL_Vulkan_GetInstanceExtensions")]
		public static extern bool Vulkan_GetInstanceExtensions(
			IntPtr window,
			out uint pCount,
			IntPtr[] pNames
		);

		/* window refers to an Window.
		 * instance refers to a VkInstance.
		 * surface refers to a VkSurfaceKHR.
		 * Only available in 2.0.6.
		 */
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint="SDL_Vulkan_CreateSurface")]
		public static extern bool Vulkan_CreateSurface(
			IntPtr window,
			IntPtr instance,
			out ulong surface
		);

		/* window refers to an Window*.
		 * Only available in 2.0.6.
		 */
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint="SDL_Vulkan_GetDrawableSize")]
		public static extern void Vulkan_GetDrawableSize(
			IntPtr window,
			out int w,
			out int h
		);

		#endregion
    }
}
