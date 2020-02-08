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
        [DllImport(nativeLibName, EntryPoint = "SDL_UpperBlit", CallingConvention = CallingConvention.Cdecl)]
        public static extern int BlitSurface(
            IntPtr src,
            IntPtr srcrect,
            IntPtr dst,
            IntPtr dstrect
        );

        /* src and dst refer to an Surface* */
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
        [DllImport(nativeLibName, EntryPoint = "SDL_UpperBlitScaled", CallingConvention = CallingConvention.Cdecl)]
        public static extern int BlitScaled(
            IntPtr src,
            IntPtr srcrect,
            IntPtr dst,
            IntPtr dstrect
        );

        /* src and dst are void* pointers */
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
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_ConvertSurface")]
        public static extern IntPtr ConvertSurface(
            IntPtr src,
            IntPtr fmt,
            uint flags
        );

        /* IntPtr refers to an Surface*, src to an Surface* */
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_ConvertSurfaceFormat")]
        public static extern IntPtr ConvertSurfaceFormat(
            IntPtr src,
            uint pixel_format,
            uint flags
        );

        /* IntPtr refers to an Surface* */
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
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_FillRect")]
        public static extern int FillRect(
            IntPtr dst,
            ref Rect rect,
            uint color
        );

        /* dst refers to an Surface*.
		 * This overload allows passing NULL to rect.
		 */
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_FillRect")]
        public static extern int FillRect(
            IntPtr dst,
            IntPtr rect,
            uint color
        );

        /* dst refers to an Surface* */
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_FillRects")]
        public static extern int FillRects(
            IntPtr dst,
            [In] Rect[] rects,
            int count,
            uint color
        );

        /* surface refers to an Surface* */
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_FreeSurface")]
        public static extern void FreeSurface(IntPtr surface);

        /* surface refers to an Surface* */
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetClipRect")]
        public static extern void GetClipRect(
            IntPtr surface,
            out Rect rect
        );

        /* surface refers to an Surface*.
		 * This function is only available in 2.0.9 or higher.
		 */
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_HasColorKey")]
        public static extern bool HasColorKey(IntPtr surface);

        /* surface refers to an Surface* */
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetColorKey")]
        public static extern int GetColorKey(
            IntPtr surface,
            out uint key
        );

        /* surface refers to an Surface* */
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetSurfaceAlphaMod")]
        public static extern int GetSurfaceAlphaMod(
            IntPtr surface,
            out byte alpha
        );

        /* surface refers to an Surface* */
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetSurfaceBlendMode")]
        public static extern int GetSurfaceBlendMode(
            IntPtr surface,
            out BlendMode blendMode
        );

        /* surface refers to an Surface* */
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
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_LockSurface")]
        public static extern int LockSurface(IntPtr surface);

        /* src and dst refer to an Surface* */
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_LowerBlit")]
        public static extern int LowerBlit(
            IntPtr src,
            ref Rect srcrect,
            IntPtr dst,
            ref Rect dstrect
        );

        /* src and dst refer to an Surface* */
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
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_SetClipRect")]
        public static extern bool SetClipRect(
            IntPtr surface,
            ref Rect rect
        );

        /* surface refers to an Surface* */
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_SetColorKey")]
        public static extern int SetColorKey(
            IntPtr surface,
            int flag,
            uint key
        );

        /* surface refers to an Surface* */
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_SetSurfaceAlphaMod")]
        public static extern int SetSurfaceAlphaMod(
            IntPtr surface,
            byte alpha
        );

        /* surface refers to an Surface* */
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_SetSurfaceBlendMode")]
        public static extern int SetSurfaceBlendMode(
            IntPtr surface,
            BlendMode blendMode
        );

        /* surface refers to an Surface* */
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_SetSurfaceColorMod")]
        public static extern int SetSurfaceColorMod(
            IntPtr surface,
            byte r,
            byte g,
            byte b
        );

        /* surface refers to an Surface*, palette to an Palette* */
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_SetSurfacePalette")]
        public static extern int SetSurfacePalette(
            IntPtr surface,
            IntPtr palette
        );

        /* surface refers to an Surface* */
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_SetSurfaceRLE")]
        public static extern int SetSurfaceRLE(
            IntPtr surface,
            int flag
        );

        /* src and dst refer to an Surface* */
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_SoftStretch")]
        public static extern int SoftStretch(
            IntPtr src,
            ref Rect srcrect,
            IntPtr dst,
            ref Rect dstrect
        );

        /* surface refers to an Surface* */
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_UnlockSurface")]
        public static extern void UnlockSurface(IntPtr surface);

        /* src and dst refer to an Surface* */
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_UpperBlit")]
        public static extern int UpperBlit(
            IntPtr src,
            ref Rect srcrect,
            IntPtr dst,
            ref Rect dstrect
        );

        /* src and dst refer to an Surface* */
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_UpperBlitScaled")]
        public static extern int UpperBlitScaled(
            IntPtr src,
            ref Rect srcrect,
            IntPtr dst,
            ref Rect dstrect
        );

        /* surface and IntPtr refer to an Surface* */
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_DuplicateSurface")]
        public static extern IntPtr DuplicateSurface(IntPtr surface);
    }
    #endregion
}
