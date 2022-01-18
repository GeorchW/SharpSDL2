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
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
#endregion
namespace SDL2
{
		#region vulkan.h

    public static partial class SDL
    {
		/* Only available in 2.0.6 */
		/// <summary>
		/// Dynamically load a Vulkan loader library. 
		/// If  is NULL SDL will use the value of the environment variable , if set, otherwise it loads the default Vulkan loader library.This should be called after initializing the video driver, but before creating any Vulkan windows. If no Vulkan loader library is loaded, the default library will be loaded upon creation of the first Vulkan window.
		/// 
		/// Binding info:
		/// Only available in 2.0.6
		/// </summary>
		/// <param name="path">The platform dependent Vulkan loader library name, or NULL.</param>
		[DllImport(nativeLibName, EntryPoint = "SDL_Vulkan_LoadLibrary", CallingConvention = CallingConvention.Cdecl)]
        private static extern int INTERNAL_Vulkan_LoadLibrary(
			byte[] path
		);

        [SdlAvailable("2.0.6")]
		public static int Vulkan_LoadLibrary(string path) {
			
            // This is a thought. Perhaps there is another way to handle this?
			// I'm not really great with Attribute handling.
			// @Blizzardo1

            var sdl = (SdlAvailableAttribute)MethodBase.GetCurrentMethod()
                .GetCustomAttributes(typeof(SdlAvailableAttribute), false).FirstOrDefault();
            if (sdl != null && !sdl.Equals()) return -1;

            return INTERNAL_Vulkan_LoadLibrary(
				UTF8_ToNative(path)
			);
		}

		/* Only available in 2.0.6 */
		/// <summary>
		/// Get the address of the vkGetInstanceProcAddr function.
		/// 
		/// Binding info:
		/// Only available in 2.0.6
		/// </summary>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint="SDL_Vulkan_GetVkGetInstanceProcAddr")]
        
		public static extern IntPtr Vulkan_GetVkGetInstanceProcAddress();

		/* Only available in 2.0.6 */
		/// <summary>
		/// Unload the Vulkan loader library previously loaded by SDL_Vulkan_LoadLibrary().
		/// 
		/// Binding info:
		/// Only available in 2.0.6
		/// </summary>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint="SDL_Vulkan_UnloadLibrary")]
		public static extern void Vulkan_UnloadLibrary();

		/* window refers to an Window*, pNames to a const char**.
		 * Only available in 2.0.6.
		 */
		/// <summary>
		/// Get the names of the Vulkan instance extensions needed to create a surface with SDL_Vulkan_CreateSurface().
		/// 
		/// Binding info:
		/// window refers to an Window*, pNames to a const char**.
		/// Only available in 2.0.6.
		/// </summary>
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
		/// <summary>
		/// Create a Vulkan rendering surface for a window.
		/// 
		/// Binding info:
		/// window refers to an Window.
		/// instance refers to a VkInstance.
		/// surface refers to a VkSurfaceKHR.
		/// Only available in 2.0.6.
		/// </summary>
		/// <param name="window">SDL_Window to which to attach the rendering surface.</param>
		/// <param name="instance">handle to the Vulkan instance to use.</param>
		/// <param name="surface">pointer to a VkSurfaceKHR handle to receive the handle of the newly created surface.</param>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint="SDL_Vulkan_CreateSurface")]
		public static extern bool Vulkan_CreateSurface(
			IntPtr window,
			IntPtr instance,
			out ulong surface
		);

		/* window refers to an Window*.
		 * Only available in 2.0.6.
		 */
		/// <summary>
		/// Get the size of a window's underlying drawable in pixels (for use with setting viewport, scissor & etc). 
		/// This may differ from  if we're rendering to a high-DPI drawable, i.e. the window was created with SDL_WINDOW_ALLOW_HIGHDPI on a platform with high-DPI support (Apple calls this "Retina"), and not disabled by the  hint.
		/// 
		/// Binding info:
		/// window refers to an Window*.
		/// Only available in 2.0.6.
		/// </summary>
		/// <param name="window">SDL_Window from which the drawable size should be queried</param>
		/// <param name="w">Pointer to variable for storing the width in pixels, may be NULL</param>
		/// <param name="h">Pointer to variable for storing the height in pixels, may be NULL</param>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint="SDL_Vulkan_GetDrawableSize")]
		public static extern void Vulkan_GetDrawableSize(
			IntPtr window,
			out int w,
			out int h
		);

		#endregion
    }
}
