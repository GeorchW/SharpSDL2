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
    #region surface.h

    [StructLayout(LayoutKind.Sequential)]
    public struct Surface
    {
        public uint Flags;
        public IntPtr Format; // PixelFormat*
        public int W;
        public int H;
        public int Pitch;
        public IntPtr Pixels; // void*
        public IntPtr Userdata; // void*
        public int Locked;
        public IntPtr LockData; // void*
        public Rect ClipRect;
        public IntPtr Map; // BlitMap*
        public int Refcount;
    }
    public static partial class SDL
    {
        public const uint SWSURFACE = 0x00000000;
        public const uint PREALLOC = 0x00000001;
        public const uint RLEACCEL = 0x00000002;
        public const uint DONTFREE = 0x00000004;

        /* surface refers to an Surface* */
        public static bool MUSTLOCK(IntPtr surface)
        {
            Surface sur;
            sur = (Surface)Marshal.PtrToStructure(
                surface,
                typeof(Surface)
            );
            return (sur.Flags & RLEACCEL) != 0;
        }

        /* src and dst refer to an Surface* */
        /// <summary>
        /// This is the public blit function, , and it performs rectangle validation and clipping before passing it to
        /// 
        /// Binding info:
        /// src and dst refer to an Surface*
        /// </summary>
        [DllImport(nativeLibName, EntryPoint = "SDL_UpperBlit", CallingConvention = CallingConvention.Cdecl)]
        public static extern int BlitSurface(
            IntPtr src,
            ref Rect srcrect,
            IntPtr dst,
            ref Rect dstrect
        );

        /* src and dst refer to an Surface*
		 * Internally, this function contains logic to use default values when
		 * source and destination rectangles are passed as NULL.
		 * This overload allows for IntPtr.Zero (null) to be passed for srcrect.
		 */
        /// <summary>
        /// This is the public blit function, , and it performs rectangle validation and clipping before passing it to
        /// 
        /// Binding info:
        /// src and dst refer to an Surface*
        /// Internally, this function contains logic to use default values when
        /// source and destination rectangles are passed as NULL.
        /// This overload allows for IntPtr.Zero (null) to be passed for srcrect.
        /// </summary>
        [DllImport(nativeLibName, EntryPoint = "SDL_UpperBlit", CallingConvention = CallingConvention.Cdecl)]
        public static extern int BlitSurface(
            IntPtr src,
            IntPtr srcrect,
            IntPtr dst,
            ref Rect dstrect
        );

        /* src and dst refer to an Surface*
		 * Internally, this function contains logic to use default values when
		 * source and destination rectangles are passed as NULL.
		 * This overload allows for IntPtr.Zero (null) to be passed for dstrect.
		 */
        /// <summary>
        /// This is the public blit function, , and it performs rectangle validation and clipping before passing it to
        /// 
        /// Binding info:
        /// src and dst refer to an Surface*
        /// Internally, this function contains logic to use default values when
        /// source and destination rectangles are passed as NULL.
        /// This overload allows for IntPtr.Zero (null) to be passed for dstrect.
        /// </summary>
        [DllImport(nativeLibName, EntryPoint = "SDL_UpperBlit", CallingConvention = CallingConvention.Cdecl)]
        public static extern int BlitSurface(
            IntPtr src,
            ref Rect srcrect,
            IntPtr dst,
            IntPtr dstrect
        );

        /* src and dst refer to an Surface*
		 * Internally, this function contains logic to use default values when
		 * source and destination rectangles are passed as NULL.
		 * This overload allows for IntPtr.Zero (null) to be passed for both Rects.
		 */
        /// <summary>
        /// This is the public blit function, , and it performs rectangle validation and clipping before passing it to
        /// 
        /// Binding info:
        /// src and dst refer to an Surface*
        /// Internally, this function contains logic to use default values when
        /// source and destination rectangles are passed as NULL.
        /// This overload allows for IntPtr.Zero (null) to be passed for both Rects.
        /// </summary>
        [DllImport(nativeLibName, EntryPoint = "SDL_UpperBlit", CallingConvention = CallingConvention.Cdecl)]
        public static extern int BlitSurface(
            IntPtr src,
            IntPtr srcrect,
            IntPtr dst,
            IntPtr dstrect
        );

        /* src and dst refer to an Surface* */
        /// <summary>
        /// This is the public scaled blit function, , and it performs rectangle validation and clipping before passing it to
        /// 
        /// Binding info:
        /// src and dst refer to an Surface*
        /// </summary>
        [DllImport(nativeLibName, EntryPoint = "SDL_UpperBlitScaled", CallingConvention = CallingConvention.Cdecl)]
        public static extern int BlitScaled(
            IntPtr src,
            ref Rect srcrect,
            IntPtr dst,
            ref Rect dstrect
        );

        /* src and dst refer to an Surface*
		 * Internally, this function contains logic to use default values when
		 * source and destination rectangles are passed as NULL.
		 * This overload allows for IntPtr.Zero (null) to be passed for srcrect.
		 */
        /// <summary>
        /// This is the public scaled blit function, , and it performs rectangle validation and clipping before passing it to
        /// 
        /// Binding info:
        /// src and dst refer to an Surface*
        /// Internally, this function contains logic to use default values when
        /// source and destination rectangles are passed as NULL.
        /// This overload allows for IntPtr.Zero (null) to be passed for srcrect.
        /// </summary>
        [DllImport(nativeLibName, EntryPoint = "SDL_UpperBlitScaled", CallingConvention = CallingConvention.Cdecl)]
        public static extern int BlitScaled(
            IntPtr src,
            IntPtr srcrect,
            IntPtr dst,
            ref Rect dstrect
        );

        /* src and dst refer to an Surface*
		 * Internally, this function contains logic to use default values when
		 * source and destination rectangles are passed as NULL.
		 * This overload allows for IntPtr.Zero (null) to be passed for dstrect.
		 */
        /// <summary>
        /// This is the public scaled blit function, , and it performs rectangle validation and clipping before passing it to
        /// 
        /// Binding info:
        /// src and dst refer to an Surface*
        /// Internally, this function contains logic to use default values when
        /// source and destination rectangles are passed as NULL.
        /// This overload allows for IntPtr.Zero (null) to be passed for dstrect.
        /// </summary>
        [DllImport(nativeLibName, EntryPoint = "SDL_UpperBlitScaled", CallingConvention = CallingConvention.Cdecl)]
        public static extern int BlitScaled(
            IntPtr src,
            ref Rect srcrect,
            IntPtr dst,
            IntPtr dstrect
        );

        /* src and dst refer to an Surface*
		 * Internally, this function contains logic to use default values when
		 * source and destination rectangles are passed as NULL.
		 * This overload allows for IntPtr.Zero (null) to be passed for both Rects.
		 */
        /// <summary>
        /// This is the public scaled blit function, , and it performs rectangle validation and clipping before passing it to
        /// 
        /// Binding info:
        /// src and dst refer to an Surface*
        /// Internally, this function contains logic to use default values when
        /// source and destination rectangles are passed as NULL.
        /// This overload allows for IntPtr.Zero (null) to be passed for both Rects.
        /// </summary>
        [DllImport(nativeLibName, EntryPoint = "SDL_UpperBlitScaled", CallingConvention = CallingConvention.Cdecl)]
        public static extern int BlitScaled(
            IntPtr src,
            IntPtr srcrect,
            IntPtr dst,
            IntPtr dstrect
        );

        /* src and dst are void* pointers */
        /// <summary>
        /// Copy a block of pixels of one format to another format.
        /// 
        /// Binding info:
        /// src and dst are void* pointers
        /// </summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_ConvertPixels")]
        public static extern int ConvertPixels(
            int width,
            int height,
            uint src_format,
            IntPtr src,
            int src_pitch,
            uint dst_format,
            IntPtr dst,
            int dst_pitch
        );

        /* IntPtr refers to an Surface*
		 * src refers to an Surface*
		 * fmt refers to an PixelFormat*
		 */
        /// <summary>
        /// Creates a new surface of the specified format, and then copies and maps the given surface to it so the blit of the converted surface will be as fast as possible. If this function fails, it returns NULL.The  parameter is passed to  and has those semantics. You can also pass  in the flags parameter and SDL will try to RLE accelerate colorkey and alpha blits in the resulting surface.
        /// 
        /// Binding info:
        /// IntPtr refers to an Surface*
        /// src refers to an Surface*
        /// fmt refers to an PixelFormat*
        /// </summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_ConvertSurface")]
        public static extern IntPtr ConvertSurface(
            IntPtr src,
            IntPtr fmt,
            uint flags
        );

        /* IntPtr refers to an Surface*, src to an Surface* */
        /// <summary>
        /// 
        /// 
        /// Binding info:
        /// IntPtr refers to an Surface*, src to an Surface*
        /// </summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_ConvertSurfaceFormat")]
        public static extern IntPtr ConvertSurfaceFormat(
            IntPtr src,
            uint pixel_format,
            uint flags
        );

        /* IntPtr refers to an Surface* */
        /// <summary>
        /// Allocate and free an RGB surface.If the depth is 4 or 8 bits, an empty palette is allocated for the surface. If the depth is greater than 8 bits, the pixel format is set using the flags '[RGB]mask'.If the function runs out of memory, it will return NULL.
        /// 
        /// Binding info:
        /// IntPtr refers to an Surface*
        /// </summary>
        /// <param name="flags">The flags are obsolete and should be set to 0.</param>
        /// <param name="width">The width in pixels of the surface to create.</param>
        /// <param name="height">The height in pixels of the surface to create.</param>
        /// <param name="depth">The depth in bits of the surface to create.</param>
        /// <param name="Rmask">The red mask of the surface to create.</param>
        /// <param name="Gmask">The green mask of the surface to create.</param>
        /// <param name="Bmask">The blue mask of the surface to create.</param>
        /// <param name="Amask">The alpha mask of the surface to create.</param>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_CreateRGBSurface")]
        public static extern IntPtr CreateRGBSurface(
            uint flags,
            int width,
            int height,
            int depth,
            uint Rmask,
            uint Gmask,
            uint Bmask,
            uint Amask
        );

        /* IntPtr refers to an Surface*, pixels to a void* */
        /// <summary>
        /// 
        /// 
        /// Binding info:
        /// IntPtr refers to an Surface*, pixels to a void*
        /// </summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_CreateRGBSurfaceFrom")]
        public static extern IntPtr CreateRGBSurfaceFrom(
            IntPtr pixels,
            int width,
            int height,
            int depth,
            int pitch,
            uint Rmask,
            uint Gmask,
            uint Bmask,
            uint Amask
        );

        /* IntPtr refers to an Surface* */
        /* Available in 2.0.5 or higher */
        /// <summary>
        /// 
        /// 
        /// Binding info:
        /// Available in 2.0.5 or higher
        /// </summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_CreateRGBSurfaceWithFormat")]
        public static extern IntPtr CreateRGBSurfaceWithFormat(
            uint flags,
            int width,
            int height,
            int depth,
            uint format
        );

        /* IntPtr refers to an Surface*, pixels to a void* */
        /* Available in 2.0.5 or higher */
        /// <summary>
        /// 
        /// 
        /// Binding info:
        /// Available in 2.0.5 or higher
        /// </summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_CreateRGBSurfaceWithFormatFrom")]
        public static extern IntPtr CreateRGBSurfaceWithFormatFrom(
            IntPtr pixels,
            int width,
            int height,
            int depth,
            int pitch,
            uint format
        );

        /* dst refers to an Surface* */
        /// <summary>
        /// Performs a fast fill of the given rectangle with .If  is NULL, the whole surface will be filled with .The color should be a pixel of the format used by the surface, and can be generated by the  function.
        /// 
        /// Binding info:
        /// dst refers to an Surface*
        /// </summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_FillRect")]
        public static extern int FillRect(
            IntPtr dst,
            ref Rect rect,
            uint color
        );

        /* dst refers to an Surface*.
		 * This overload allows passing NULL to rect.
		 */
        /// <summary>
        /// Performs a fast fill of the given rectangle with .If  is NULL, the whole surface will be filled with .The color should be a pixel of the format used by the surface, and can be generated by the  function.
        /// 
        /// Binding info:
        /// dst refers to an Surface*.
        /// This overload allows passing NULL to rect.
        /// </summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_FillRect")]
        public static extern int FillRect(
            IntPtr dst,
            IntPtr rect,
            uint color
        );

        /* dst refers to an Surface* */
        /// <summary>
        /// 
        /// 
        /// Binding info:
        /// dst refers to an Surface*
        /// </summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_FillRects")]
        public static extern int FillRects(
            IntPtr dst,
            [In] Rect[] rects,
            int count,
            uint color
        );

        /* surface refers to an Surface* */
        /// <summary>
        /// 
        /// 
        /// Binding info:
        /// surface refers to an Surface*
        /// </summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_FreeSurface")]
        public static extern void FreeSurface(IntPtr surface);

        /* surface refers to an Surface* */
        /// <summary>
        /// Gets the clipping rectangle for the destination surface in a blit. must be a pointer to a valid rectangle which will be filled with the correct values.
        /// 
        /// Binding info:
        /// surface refers to an Surface*
        /// </summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetClipRect")]
        public static extern void GetClipRect(
            IntPtr surface,
            out Rect rect
        );

        /* surface refers to an Surface*.
		 * This function is only available in 2.0.9 or higher.
		 */
        /// <summary>
        /// Returns whether the surface has a color key.
        /// 
        /// Binding info:
        /// surface refers to an Surface*.
        /// This function is only available in 2.0.9 or higher.
        /// </summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_HasColorKey")]
        public static extern bool HasColorKey(IntPtr surface);

        /* surface refers to an Surface* */
        /// <summary>
        /// Gets the color key (transparent pixel) in a blittable surface.
        /// 
        /// Binding info:
        /// surface refers to an Surface*
        /// </summary>
        /// <param name="surface">The surface to update</param>
        /// <param name="key">A pointer filled in with the transparent pixel in the native surface format</param>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetColorKey")]
        public static extern int GetColorKey(
            IntPtr surface,
            out uint key
        );

        /* surface refers to an Surface* */
        /// <summary>
        /// Get the additional alpha value used in blit operations.
        /// 
        /// Binding info:
        /// surface refers to an Surface*
        /// </summary>
        /// <param name="surface">The surface to query.</param>
        /// <param name="alpha">A pointer filled in with the current alpha value.</param>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetSurfaceAlphaMod")]
        public static extern int GetSurfaceAlphaMod(
            IntPtr surface,
            out byte alpha
        );

        /* surface refers to an Surface* */
        /// <summary>
        /// Get the blend mode used for blit operations.
        /// 
        /// Binding info:
        /// surface refers to an Surface*
        /// </summary>
        /// <param name="surface">The surface to query.</param>
        /// <param name="blendMode">A pointer filled in with the current blend mode.</param>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetSurfaceBlendMode")]
        public static extern int GetSurfaceBlendMode(
            IntPtr surface,
            out BlendMode blendMode
        );

        /* surface refers to an Surface* */
        /// <summary>
        /// Get the additional color value used in blit operations.
        /// 
        /// Binding info:
        /// surface refers to an Surface*
        /// </summary>
        /// <param name="surface">The surface to query.</param>
        /// <param name="r">A pointer filled in with the current red color value.</param>
        /// <param name="g">A pointer filled in with the current green color value.</param>
        /// <param name="b">A pointer filled in with the current blue color value.</param>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetSurfaceColorMod")]
        public static extern int GetSurfaceColorMod(
            IntPtr surface,
            out byte r,
            out byte g,
            out byte b
        );

        /* These are for LoadBMP, which is a macro in the SDL headers. */
        /* IntPtr refers to an Surface* */
        /* THIS IS AN RWops FUNCTION! */
        /// <summary>
        /// Load a surface from a seekable SDL data stream (memory or file).If  is non-zero, the stream will be closed after being read.The new surface should be freed with .
        /// 
        /// Binding info:
        /// THIS IS AN RWops FUNCTION!
        /// </summary>
        [DllImport(nativeLibName, EntryPoint = "SDL_LoadBMP_RW", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr INTERNAL_LoadBMP_RW(
            IntPtr src,
            int freesrc
        );
        public static IntPtr LoadBMP(string file)
        {
            IntPtr rwops = RWFromFile(file, "rb");
            return INTERNAL_LoadBMP_RW(rwops, 1);
        }

        /* surface refers to an Surface* */
        /// <summary>
        /// Sets up a surface for directly accessing the pixels. 
        /// Between calls to  / , you can write to and read from , using the pixel format stored in . Once you are done accessing the surface, you should use  to release it.Not all surfaces require locking. If  evaluates to 0, then you can read and write to the surface at any time, and the pixel format of the surface will not change.No operating system or library calls should be made between lock/unlock pairs, as critical system locks may be held during this time. returns 0, or -1 if the surface couldn't be locked.
        /// 
        /// Binding info:
        /// surface refers to an Surface*
        /// </summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_LockSurface")]
        public static extern int LockSurface(IntPtr surface);

        /* src and dst refer to an Surface* */
        /// <summary>
        /// This is a semi-private blit function and it performs low-level surface blitting only.
        /// 
        /// Binding info:
        /// src and dst refer to an Surface*
        /// </summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_LowerBlit")]
        public static extern int LowerBlit(
            IntPtr src,
            ref Rect srcrect,
            IntPtr dst,
            ref Rect dstrect
        );

        /* src and dst refer to an Surface* */
        /// <summary>
        /// This is a semi-private blit function and it performs low-level surface scaled blitting only.
        /// 
        /// Binding info:
        /// src and dst refer to an Surface*
        /// </summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_LowerBlitScaled")]
        public static extern int LowerBlitScaled(
            IntPtr src,
            ref Rect srcrect,
            IntPtr dst,
            ref Rect dstrect
        );

        /* These are for SaveBMP, which is a macro in the SDL headers. */
        /* IntPtr refers to an Surface* */
        /* THIS IS AN RWops FUNCTION! */
        /// <summary>
        /// Save a surface to a seekable SDL data stream (memory or file).Surfaces with a 24-bit, 32-bit and paletted 8-bit format get saved in the BMP directly. Other RGB formats with 8-bit or higher get converted to a 24-bit surface or, if they have an alpha mask or a colorkey, to a 32-bit surface before they are saved. YUV and paletted 1-bit and 4-bit formats are not supported.If  is non-zero, the stream will be closed after being written.
        /// 
        /// Binding info:
        /// THIS IS AN RWops FUNCTION!
        /// </summary>
        [DllImport(nativeLibName, EntryPoint = "SDL_SaveBMP_RW", CallingConvention = CallingConvention.Cdecl)]
        private static extern int INTERNAL_SaveBMP_RW(
            IntPtr surface,
            IntPtr src,
            int freesrc
        );
        public static int SaveBMP(IntPtr surface, string file)
        {
            IntPtr rwops = RWFromFile(file, "wb");
            return INTERNAL_SaveBMP_RW(surface, rwops, 1);
        }

        /* surface refers to an Surface* */
        /// <summary>
        /// Sets the clipping rectangle for the destination surface in a blit.If the clip rectangle is NULL, clipping will be disabled.If the clip rectangle doesn't intersect the surface, the function will return SDL_FALSE and blits will be completely clipped. Otherwise the function returns SDL_TRUE and blits to the surface will be clipped to the intersection of the surface area and the clipping rectangle.Note that blits are automatically clipped to the edges of the source and destination surfaces.
        /// 
        /// Binding info:
        /// surface refers to an Surface*
        /// </summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_SetClipRect")]
        public static extern bool SetClipRect(
            IntPtr surface,
            ref Rect rect
        );

        /* surface refers to an Surface* */
        /// <summary>
        /// Sets the color key (transparent pixel) in a blittable surface. 
        /// You can pass SDL_RLEACCEL to enable RLE accelerated blits.
        /// 
        /// Binding info:
        /// surface refers to an Surface*
        /// </summary>
        /// <param name="surface">The surface to update</param>
        /// <param name="flag">Non-zero to enable colorkey and 0 to disable colorkey</param>
        /// <param name="key">The transparent pixel in the native surface format</param>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_SetColorKey")]
        public static extern int SetColorKey(
            IntPtr surface,
            int flag,
            uint key
        );

        /* surface refers to an Surface* */
        /// <summary>
        /// Set an additional alpha value used in blit operations.
        /// 
        /// Binding info:
        /// surface refers to an Surface*
        /// </summary>
        /// <param name="surface">The surface to update.</param>
        /// <param name="alpha">The alpha value multiplied into blit operations.</param>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_SetSurfaceAlphaMod")]
        public static extern int SetSurfaceAlphaMod(
            IntPtr surface,
            byte alpha
        );

        /* surface refers to an Surface* */
        /// <summary>
        /// Set the blend mode used for blit operations.
        /// 
        /// Binding info:
        /// surface refers to an Surface*
        /// </summary>
        /// <param name="surface">The surface to update.</param>
        /// <param name="blendMode">SDL_BlendMode to use for blit blending.</param>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_SetSurfaceBlendMode")]
        public static extern int SetSurfaceBlendMode(
            IntPtr surface,
            BlendMode blendMode
        );

        /* surface refers to an Surface* */
        /// <summary>
        /// Set an additional color value used in blit operations.
        /// 
        /// Binding info:
        /// surface refers to an Surface*
        /// </summary>
        /// <param name="surface">The surface to update.</param>
        /// <param name="r">The red color value multiplied into blit operations.</param>
        /// <param name="g">The green color value multiplied into blit operations.</param>
        /// <param name="b">The blue color value multiplied into blit operations.</param>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_SetSurfaceColorMod")]
        public static extern int SetSurfaceColorMod(
            IntPtr surface,
            byte r,
            byte g,
            byte b
        );

        /* surface refers to an Surface*, palette to an Palette* */
        /// <summary>
        /// Set the palette used by a surface.
        /// 
        /// Binding info:
        /// surface refers to an Surface*, palette to an Palette*
        /// </summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_SetSurfacePalette")]
        public static extern int SetSurfacePalette(
            IntPtr surface,
            IntPtr palette
        );

        /* surface refers to an Surface* */
        /// <summary>
        /// Sets the RLE acceleration hint for a surface.
        /// 
        /// Binding info:
        /// surface refers to an Surface*
        /// </summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_SetSurfaceRLE")]
        public static extern int SetSurfaceRLE(
            IntPtr surface,
            int flag
        );

        /* src and dst refer to an Surface* */
        /// <summary>
        /// Perform a fast, low quality, stretch blit between two surfaces of the same pixel format.
        /// 
        /// Binding info:
        /// src and dst refer to an Surface*
        /// </summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_SoftStretch")]
        public static extern int SoftStretch(
            IntPtr src,
            ref Rect srcrect,
            IntPtr dst,
            ref Rect dstrect
        );

        /* surface refers to an Surface* */
        /// <summary>
        /// 
        /// 
        /// Binding info:
        /// surface refers to an Surface*
        /// </summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_UnlockSurface")]
        public static extern void UnlockSurface(IntPtr surface);

        /* src and dst refer to an Surface* */
        /// <summary>
        /// This is the public blit function, , and it performs rectangle validation and clipping before passing it to
        /// 
        /// Binding info:
        /// src and dst refer to an Surface*
        /// </summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_UpperBlit")]
        public static extern int UpperBlit(
            IntPtr src,
            ref Rect srcrect,
            IntPtr dst,
            ref Rect dstrect
        );

        /* src and dst refer to an Surface* */
        /// <summary>
        /// This is the public scaled blit function, , and it performs rectangle validation and clipping before passing it to
        /// 
        /// Binding info:
        /// src and dst refer to an Surface*
        /// </summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_UpperBlitScaled")]
        public static extern int UpperBlitScaled(
            IntPtr src,
            ref Rect srcrect,
            IntPtr dst,
            ref Rect dstrect
        );

        /* surface and IntPtr refer to an Surface* */
        /// <summary>
        /// 
        /// 
        /// Binding info:
        /// surface and IntPtr refer to an Surface*
        /// </summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_DuplicateSurface")]
        public static extern IntPtr DuplicateSurface(IntPtr surface);
    }
    #endregion
}
