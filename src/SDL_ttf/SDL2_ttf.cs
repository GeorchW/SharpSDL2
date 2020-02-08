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

namespace SDL2.TTF
{
    public static class TTF
    {
        #region SDL2# Variables

        /* Used by DllImport to load the native library. */
        private const string nativeLibName = "SDL2_ttf";

        #endregion

        #region ttf.h

        /* Similar to the headers, this is the version we're expecting to be
		 * running with. You will likely want to check this somewhere in your
		 * program!
		 */
        public const int TTF_MAJOR_VERSION = 2;
        public const int TTF_MINOR_VERSION = 0;
        public const int TTF_PATCHLEVEL = 12;

        public const int UNICODE_BOM_NATIVE = 0xFEFF;
        public const int UNICODE_BOM_SWAPPED = 0xFFFE;


        public static void TTF_VERSION(out Version X)
        {
            X.Major = TTF_MAJOR_VERSION;
            X.Minor = TTF_MINOR_VERSION;
            X.Patch = TTF_PATCHLEVEL;
        }

        [DllImport(nativeLibName, EntryPoint = "TTF_LinkedVersion", CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe Version* INTERNAL_TTF_LinkedVersion();
        public static unsafe Version TTF_LinkedVersion()
        {
            return *INTERNAL_TTF_LinkedVersion();
        }

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void TTF_ByteSwappedUNICODE(int swapped);

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int TTF_Init();

        [DllImport(nativeLibName, EntryPoint = "TTF_OpenFont", CallingConvention = CallingConvention.Cdecl)]
        private static extern Font INTERNAL_TTF_OpenFont(
            byte[] file,
            int ptsize
        );
        public static Font TTF_OpenFont(string file, int ptsize)
        {
            return INTERNAL_TTF_OpenFont(
                SDL.UTF8_ToNative(file),
                ptsize
            );
        }

        /* src refers to an RWops* */
        /* THIS IS A PUBLIC RWops FUNCTION! */
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern Font TTF_OpenFontRW(
            IntPtr src,
            int freesrc,
            int ptsize
        );

        [DllImport(nativeLibName, EntryPoint = "TTF_OpenFontIndex", CallingConvention = CallingConvention.Cdecl)]
        private static extern Font INTERNAL_TTF_OpenFontIndex(
            byte[] file,
            int ptsize,
            long index
        );
        public static Font TTF_OpenFontIndex(
            string file,
            int ptsize,
            long index
        )
        {
            return INTERNAL_TTF_OpenFontIndex(
                SDL.UTF8_ToNative(file),
                ptsize,
                index
            );
        }

        /* src refers to an RWops* */
        /* THIS IS A PUBLIC RWops FUNCTION! */
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern Font TTF_OpenFontIndexRW(
            IntPtr src,
            int freesrc,
            int ptsize,
            long index
        );

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern FontStyle TTF_GetFontStyle(Font font);

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void TTF_SetFontStyle(Font font, FontStyle style);


        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int TTF_GetFontOutline(Font font);


        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void TTF_SetFontOutline(Font font, int outline);


        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern FontHinting TTF_GetFontHinting(Font font);


        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void TTF_SetFontHinting(Font font, FontHinting hinting);


        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int TTF_FontHeight(Font font);


        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int TTF_FontAscent(Font font);


        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int TTF_FontDescent(Font font);


        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int TTF_FontLineSkip(Font font);


        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool TTF_GetFontKerning(Font font);


        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void TTF_SetFontKerning(Font font, bool allowed);


        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern long TTF_FontFaces(Font font);


        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool TTF_FontFaceIsFixedWidth(Font font);


        [DllImport(nativeLibName, EntryPoint = "TTF_FontFaceFamilyName", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr INTERNAL_TTF_FontFaceFamilyName(
            Font font
        );
        public static string TTF_FontFaceFamilyName(Font font)
        {
            return SDL.UTF8_ToManaged(
                INTERNAL_TTF_FontFaceFamilyName(font)
            );
        }


        [DllImport(nativeLibName, EntryPoint = "TTF_FontFaceStyleName", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr INTERNAL_TTF_FontFaceStyleName(
            Font font
        );
        public static string TTF_FontFaceStyleName(Font font)
        {
            return SDL.UTF8_ToManaged(
                INTERNAL_TTF_FontFaceStyleName(font)
            );
        }


        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool TTF_GlyphIsProvided(Font font, char ch);


        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int TTF_GlyphMetrics(
            Font font,
            char ch,
            out int minx,
            out int maxx,
            out int miny,
            out int maxy,
            out int advance
        );


        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int TTF_SizeText(
            Font font,
            [In()] [MarshalAs(UnmanagedType.LPStr)]
                string text,
            out int w,
            out int h
        );


        [DllImport(nativeLibName, EntryPoint = "TTF_SizeUTF8", CallingConvention = CallingConvention.Cdecl)]
        public static extern int INTERNAL_TTF_SizeUTF8(
            Font font,
            byte[] text,
            out int w,
            out int h
        );
        public static int TTF_SizeUTF8(
            Font font,
            string text,
            out int w,
            out int h
        )
        {
            return INTERNAL_TTF_SizeUTF8(
                font,
                SDL.UTF8_ToNative(text),
                out w,
                out h
            );
        }


        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int TTF_SizeUNICODE(
            Font font,
            [In()] [MarshalAs(UnmanagedType.LPWStr)]
                string text,
            out int w,
            out int h
        );

        /* IntPtr refers to an Surface* */
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr TTF_RenderText_Solid(
            Font font,
            [In()] [MarshalAs(UnmanagedType.LPStr)]
                string text,
            SDL.Color fg
        );

        /* IntPtr refers to an Surface* */
        [DllImport(nativeLibName, EntryPoint = "TTF_RenderUTF8_Solid", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr INTERNAL_TTF_RenderUTF8_Solid(
            Font font,
            byte[] text,
            SDL.Color fg
        );
        public static IntPtr TTF_RenderUTF8_Solid(
            Font font,
            string text,
            SDL.Color fg
        )
        {
            return INTERNAL_TTF_RenderUTF8_Solid(
                font,
                SDL.UTF8_ToNative(text),
                fg
            );
        }

        /* IntPtr refers to an Surface* */
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr TTF_RenderUNICODE_Solid(
            Font font,
            [In()] [MarshalAs(UnmanagedType.LPWStr)]
                string text,
            SDL.Color fg
        );

        /* IntPtr refers to an Surface* */
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr TTF_RenderGlyph_Solid(
            Font font,
            char c,
            SDL.Color fg
        );

        /* IntPtr refers to an Surface* */
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr TTF_RenderText_Shaded(
            Font font,
            [In()] [MarshalAs(UnmanagedType.LPStr)]
                string text,
            SDL.Color fg,
            SDL.Color bg
        );

        /* IntPtr refers to an Surface* */
        [DllImport(nativeLibName, EntryPoint = "TTF_RenderUTF8_Shaded", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr INTERNAL_TTF_RenderUTF8_Shaded(
            Font font,
            byte[] text,
            SDL.Color fg,
            SDL.Color bg
        );
        public static IntPtr TTF_RenderUTF8_Shaded(
            Font font,
            string text,
            SDL.Color fg,
            SDL.Color bg
        )
        {
            return INTERNAL_TTF_RenderUTF8_Shaded(
                font,
                SDL.UTF8_ToNative(text),
                fg,
                bg
            );
        }

        /* IntPtr refers to an Surface* */
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr TTF_RenderUNICODE_Shaded(
            Font font,
            [In()] [MarshalAs(UnmanagedType.LPWStr)]
                string text,
            SDL.Color fg,
            SDL.Color bg
        );

        /* IntPtr refers to an Surface* */
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr TTF_RenderGlyph_Shaded(
            Font font,
            char c,
            SDL.Color fg,
            SDL.Color bg
        );

        /* IntPtr refers to an Surface* */
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr TTF_RenderText_Blended(
            Font font,
            [In()] [MarshalAs(UnmanagedType.LPStr)]
                string text,
            SDL.Color fg
        );

        /* IntPtr refers to an Surface* */
        [DllImport(nativeLibName, EntryPoint = "TTF_RenderUTF8_Blended", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr INTERNAL_TTF_RenderUTF8_Blended(
            Font font,
            byte[] text,
            SDL.Color fg
        );
        public static IntPtr TTF_RenderUTF8_Blended(
            Font font,
            string text,
            SDL.Color fg
        )
        {
            return INTERNAL_TTF_RenderUTF8_Blended(
                font,
                SDL.UTF8_ToNative(text),
                fg
            );
        }

        /* IntPtr refers to an Surface* */
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr TTF_RenderUNICODE_Blended(
            Font font,
            [In()] [MarshalAs(UnmanagedType.LPWStr)]
                string text,
            SDL.Color fg
        );

        /* IntPtr refers to an Surface* */
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr TTF_RenderText_Blended_Wrapped(
            Font font,
            [In()] [MarshalAs(UnmanagedType.LPStr)]
                string text,
            SDL.Color fg,
            uint wrapped
        );

        /* IntPtr refers to an Surface* */
        [DllImport(nativeLibName, EntryPoint = "TTF_RenderUTF8_Blended_Wrapped", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr INTERNAL_TTF_RenderUTF8_Blended_Wrapped(
            Font font,
            byte[] text,
            SDL.Color fg,
            uint wrapped
        );
        public static IntPtr TTF_RenderUTF8_Blended_Wrapped(
            Font font,
            string text,
            SDL.Color fg,
            uint wrapped
        )
        {
            return INTERNAL_TTF_RenderUTF8_Blended_Wrapped(
                font,
                SDL.UTF8_ToNative(text),
                fg,
                wrapped
            );
        }

        /* IntPtr refers to an Surface* */
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr TTF_RenderUNICODE_Blended_Wrapped(
            Font font,
            [In()] [MarshalAs(UnmanagedType.LPWStr)]
                string text,
            SDL.Color fg,
            uint wrapped
        );

        /* IntPtr refers to an Surface* */
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr TTF_RenderGlyph_Blended(
            Font font,
            char c,
            SDL.Color fg
        );


        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void TTF_CloseFont(Font font);

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void TTF_Quit();

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int TTF_WasInit();


        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetFontKerningSize")]
        public static extern int GetFontKerningSize(
            Font font,
            int prev_index,
            int index
        );

        #endregion
    }
}
