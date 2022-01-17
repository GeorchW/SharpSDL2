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
	public static class Image
	{
		#region SDL2# Variables

		/* Used by DllImport to load the native library. */
		private const string nativeLibName = "SDL2_image";

		#endregion

		#region SDL_image.h

		/* Similar to the headers, this is the version we're expecting to be
		 * running with. You will likely want to check this somewhere in your
		 * program!
		 */
		public const int ImageMajorVersion =	2;
		public const int ImageMinorVersion =	0;
		public const int PatchLevel =		2;

		[Flags]
		public enum InitFlags
		{
			Jpg =	0x00000001,
			Png =	0x00000002,
			Tif =	0x00000004,
			Webp =	0x00000008
		}

		public static void ImageVersion(out Version X)
		{
			X.Major = ImageMajorVersion;
			X.Minor = ImageMinorVersion;
			X.Patch = PatchLevel;
		}

		[DllImport(nativeLibName, EntryPoint = "IMG_Linked_Version", CallingConvention = CallingConvention.Cdecl)]
		private static extern IntPtr INTERNAL_IMG_Linked_Version();
		public static Version LinkedVersion()
		{
			Version result;
			IntPtr result_ptr = INTERNAL_IMG_Linked_Version();
			result = (Version) Marshal.PtrToStructure(
				result_ptr,
				typeof(Version)
			);
			return result;
		}

		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "IMG_Init")]
		public static extern int Init(InitFlags flags);

		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "IMG_Quit")]
        public static extern void Quit();

		/* IntPtr refers to an SDL_Surface* */
		[DllImport(nativeLibName, EntryPoint = "IMG_Load", CallingConvention = CallingConvention.Cdecl)]
		private static extern IntPtr INTERNAL_IMG_Load(
			byte[] file
		);
		public static IntPtr Load(string file)
		{
			return INTERNAL_IMG_Load(SDL.UTF8_ToNative(file));
		}

		/* src refers to an SDL_RWops*, IntPtr to an SDL_Surface* */
		/* THIS IS A PUBLIC RWops FUNCTION! */
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "IMG_Load_RW")]
		public static extern IntPtr LoadRw (
			IntPtr src,
			int freeSrc
		);

		/* src refers to an SDL_RWops*, IntPtr to an SDL_Surface* */
		/* THIS IS A PUBLIC RWops FUNCTION! */
		[DllImport(nativeLibName, EntryPoint = "IMG_LoadTyped_RW", CallingConvention = CallingConvention.Cdecl)]
		private static extern IntPtr INTERNAL_IMG_LoadTyped_RW(
			IntPtr src,
			int freeSrc,
			byte[] type
		);
		public static IntPtr LoadTypedRw(
			IntPtr src,
			int freeSrc,
			string type
		) {
			return INTERNAL_IMG_LoadTyped_RW(
				src,
				freeSrc,
				SDL.UTF8_ToNative(type)
			);
		}

		/* IntPtr refers to an SDL_Texture*, renderer to an SDL_Renderer* */
		[DllImport(nativeLibName, EntryPoint = "IMG_LoadTexture", CallingConvention = CallingConvention.Cdecl)]
		private static extern IntPtr INTERNAL_IMG_LoadTexture(
			IntPtr renderer,
			byte[] file
		);
		public static IntPtr LoadTexture(
			IntPtr renderer,
			string file
		) {
			return INTERNAL_IMG_LoadTexture(
				renderer,
				SDL.UTF8_ToNative(file)
			);
		}

		/* renderer refers to an SDL_Renderer*.
		 * src refers to an SDL_RWops*.
		 * IntPtr to an SDL_Texture*.
		 */
		/* THIS IS A PUBLIC RWops FUNCTION! */
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "IMG_LoadTexture_RW")]
		public static extern IntPtr LoadTextureRw(
			IntPtr renderer,
			IntPtr src,
			int freeSrc
		);

		/* renderer refers to an SDL_Renderer*.
		 * src refers to an SDL_RWops*.
		 * IntPtr to an SDL_Texture*.
		 */
		/* THIS IS A PUBLIC RWops FUNCTION! */
		[DllImport(nativeLibName, EntryPoint = "IMG_LoadTextureTyped_RW", CallingConvention = CallingConvention.Cdecl)]
		private static extern IntPtr INTERNAL_IMG_LoadTextureTyped_RW(
			IntPtr renderer,
			IntPtr src,
			int freeSrc,
			byte[] type
		);
		public static IntPtr LoadTextureTypedRw(
			IntPtr renderer,
			IntPtr src,
			int freeSrc,
			string type
		) {
			return INTERNAL_IMG_LoadTextureTyped_RW(
				renderer,
				src,
				freeSrc,
				SDL.UTF8_ToNative(type)
			);
		}

		/* IntPtr refers to an SDL_Surface* */
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "IMG_ReadXPMFromArray")]
		public static extern IntPtr ReadXPMFromArray(
			[In()] [MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.LPStr)]
				string[] xpm
		);

		/* surface refers to an SDL_Surface* */
		[DllImport(nativeLibName, EntryPoint = "IMG_SavePNG", CallingConvention = CallingConvention.Cdecl)]
		private static extern int INTERNAL_IMG_SavePNG(
			IntPtr surface,
			byte[] file
		);
		public static int SavePng(IntPtr surface, string file)
		{
			return INTERNAL_IMG_SavePNG(
				surface,
				SDL.UTF8_ToNative(file)
			);
		}

		/* surface refers to an SDL_Surface*, dst to an SDL_RWops* */
		/* THIS IS A PUBLIC RWops FUNCTION! */
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "IMG_SavePNG_RW")]
		public static extern int SavePngRw(
			IntPtr surface,
			IntPtr dst,
			int freeDst
		);

		/* surface refers to an SDL_Surface* */
		[DllImport(nativeLibName, EntryPoint = "IMG_SaveJPG", CallingConvention = CallingConvention.Cdecl)]
		private static extern int INTERNAL_IMG_SaveJPG(
			IntPtr surface,
			byte[] file,
			int quality
		);
		public static int SaveJpg(IntPtr surface, string file, int quality)
		{
			return INTERNAL_IMG_SaveJPG(
				surface,
				SDL.UTF8_ToNative(file),
				quality
			);
		}

		/* surface refers to an SDL_Surface*, dst to an SDL_RWops* */
		/* THIS IS A PUBLIC RWops FUNCTION! */
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "IMG_SaveJPG_RW")]
		public static extern int SaveJpgRw(
			IntPtr surface,
			IntPtr dst,
			int freeDst,
			int quality
		);

		#endregion
	}
}
