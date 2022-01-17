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
        public const int MajorVersion = 2;
        public const int MinorVersion = 0;
        public const int PatchLevel = 12;

        public const int UnicodeBomNative = 0xFEFF;
        public const int UnicodeBomSwapped = 0xFFFE;


        public static void GetVersion(out Version X)
        {
            X.Major = MajorVersion;
            X.Minor = MinorVersion;
            X.Patch = PatchLevel;
        }

        [DllImport(nativeLibName, EntryPoint = "TTF_LinkedVersion", CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe Version* INTERNAL_TTF_LinkedVersion();
        public static unsafe Version LinkedVersion()
        {
            return *INTERNAL_TTF_LinkedVersion();
        }

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "TTF_ByteSwappedUNICODE")]
        public static extern void ByteSwappedUNICODE(int swapped);

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "TTF_Init")]
        public static extern int Init();

        [DllImport(nativeLibName, EntryPoint = "TTF_OpenFont", CallingConvention = CallingConvention.Cdecl)]
        private static extern Font INTERNAL_TTF_OpenFont(
            byte[] file,
            int ptSize
        );
        public static Font OpenFont(string file, int ptSize)
        {
            return INTERNAL_TTF_OpenFont(
                SDL.UTF8_ToNative(file),
                ptSize
            );
        }

        /* src refers to an RWops* */
        /* THIS IS A PUBLIC RWops FUNCTION! */
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "TTF_OpenFontRW")]
        public static extern Font OpenFontRW(
            IntPtr src,
            int freeSrc,
            int ptSize
        );

        [DllImport(nativeLibName, EntryPoint = "TTF_OpenFontIndex", CallingConvention = CallingConvention.Cdecl)]
        private static extern Font INTERNAL_TTF_OpenFontIndex(
            byte[] file,
            int ptSize,
            long index
        );
        public static Font OpenFontIndex(
            string file,
            int ptSize,
            long index
        )
        {
            return INTERNAL_TTF_OpenFontIndex(
                SDL.UTF8_ToNative(file),
                ptSize,
                index
            );
        }

        /* src refers to an RWops* */
        /* THIS IS A PUBLIC RWops FUNCTION! */
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "TTF_OpenFontIndexRW")]
        public static extern Font OpenFontIndexRW(
            IntPtr src,
            int freeSrc,
            int ptSize,
            long index
        );

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "TTF_GetFontStyle")]
        public static extern FontStyle GetFontStyle(Font font);

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "TTF_SetFontStyle")]
        public static extern void SetFontStyle(Font font, FontStyle style);


        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "TTF_GetFontOutline")]
        public static extern int GetFontOutline(Font font);


        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "TTF_SetFontOutline")]
        public static extern void SetFontOutline(Font font, int outline);


        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "TTF_GetFontHinting")]
        public static extern FontHinting GetFontHinting(Font font);


        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "TTF_SetFontHinting")]
        public static extern void SetFontHinting(Font font, FontHinting hinting);


        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "TTF_FontHeight")]
        public static extern int FontHeight(Font font);


        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "TTF_FontAscent")]
        public static extern int FontAscent(Font font);


        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "TTF_FontDescent")]
        public static extern int FontDescent(Font font);


        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "TTF_FontLineSkip")]
        public static extern int FontLineSkip(Font font);


        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "TTF_GetFontKerning")]
        public static extern bool GetFontKerning(Font font);


        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "TTF_SetFontKerning")]
        public static extern void SetFontKerning(Font font, bool allowed);


        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "TTF_FontFaces")]
        public static extern long FontFaces(Font font);


        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "TTF_FontFaceIsFixedWidth")]
        public static extern bool FontFaceIsFixedWidth(Font font);


        [DllImport(nativeLibName, EntryPoint = "TTF_FontFaceFamilyName", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr INTERNAL_TTF_FontFaceFamilyName(
            Font font
        );
        public static string FontFaceFamilyName(Font font)
        {
            return SDL.UTF8_ToManaged(
                INTERNAL_TTF_FontFaceFamilyName(font)
            );
        }


        [DllImport(nativeLibName, EntryPoint = "TTF_FontFaceStyleName", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr INTERNAL_TTF_FontFaceStyleName(
            Font font
        );
        public static string FontFaceStyleName(Font font)
        {
            return SDL.UTF8_ToManaged(
                INTERNAL_TTF_FontFaceStyleName(font)
            );
        }


        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "TTF_GlyphIsProvided")]
        public static extern bool GlyphIsProvided(Font font, char ch);


        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "TTF_GlyphMetrics")]
        public static extern int GlyphMetrics(
            Font font,
            char ch,
            out int minX,
            out int maxX,
            out int minY,
            out int maxY,
            out int advance
        );


        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "TTF_SizeText")]
        public static extern int SizeText(
            Font font,
            [In] [MarshalAs(UnmanagedType.LPStr)]
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
        public static int SizeUTF8(
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


        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "TTF_SizeUNICODE")]
        public static extern int SizeUNICODE(
            Font font,
            [In] [MarshalAs(UnmanagedType.LPWStr)]
                string text,
            out int w,
            out int h
        );

        /* IntPtr refers to an Surface* */
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "TTF_RenderText_Solid")]
        public static extern IntPtr RenderTextSolid(
            Font font,
            [In] [MarshalAs(UnmanagedType.LPStr)]
                string text,
            Color foregroundColor
        );

        /* IntPtr refers to an Surface* */
        [DllImport(nativeLibName, EntryPoint = "TTF_RenderUTF8_Solid", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr INTERNAL_TTF_RenderUTF8_Solid(
            Font font,
            byte[] text,
            Color foregroundColor
        );
        public static IntPtr RenderUtf8Solid(
            Font font,
            string text,
            Color foregroundColor
        )
        {
            return INTERNAL_TTF_RenderUTF8_Solid(
                font,
                SDL.UTF8_ToNative(text),
                foregroundColor
            );
        }

        /* IntPtr refers to an Surface* */
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "TF_RenderUNICODE_Solid")]
        public static extern IntPtr RenderUnicodeSolid(
            Font font,
            [In] [MarshalAs(UnmanagedType.LPWStr)]
                string text,
            Color foregroundColor
        );

        /* IntPtr refers to an Surface* */
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "TTF_RenderGlyph_Solid")]
        public static extern IntPtr RenderGlyphSolid(
            Font font,
            char c,
            Color foregroundColor
        );

        /* IntPtr refers to an Surface* */
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "TTF_RenderText_Shaded")]
        public static extern IntPtr RenderTextShaded(
            Font font,
            [In] [MarshalAs(UnmanagedType.LPStr)]
                string text,
            Color foregroundColor,
            Color bg
        );

        /* IntPtr refers to an Surface* */
        [DllImport(nativeLibName, EntryPoint = "TTF_RenderUTF8_Shaded", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr INTERNAL_TTF_RenderUTF8_Shaded(
            Font font,
            byte[] text,
            Color foregroundColor,
            Color bg
        );
        public static IntPtr RenderUtf8Shaded(
            Font font,
            string text,
            Color foregroundColor,
            Color bg
        )
        {
            return INTERNAL_TTF_RenderUTF8_Shaded(
                font,
                SDL.UTF8_ToNative(text),
                foregroundColor,
                bg
            );
        }

        /* IntPtr refers to an Surface* */
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "TTF_RenderUNICODE_Shaded")]
        public static extern IntPtr RenderUnicodeShaded(
            Font font,
            [In] [MarshalAs(UnmanagedType.LPWStr)]
                string text,
            Color foregroundColor,
            Color bg
        );

        /* IntPtr refers to an Surface* */
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "TTF_RenderGlyph_Shaded")]
        public static extern IntPtr RenderGlyphShaded(
            Font font,
            char c,
            Color foregroundColor,
            Color bg
        );

        /* IntPtr refers to an Surface* */
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "TTF_RenderText_Blended")]
        public static extern IntPtr RenderTextBlended(
            Font font,
            [In] [MarshalAs(UnmanagedType.LPStr)]
                string text,
            Color foregroundColor
        );

        /* IntPtr refers to an Surface* */
        [DllImport(nativeLibName, EntryPoint = "TTF_RenderUTF8_Blended", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr INTERNAL_TTF_RenderUTF8_Blended(
            Font font,
            byte[] text,
            Color foregroundColor
        );
        public static IntPtr RenderUtf8Blended(
            Font font,
            string text,
            Color foregroundColor
        )
        {
            return INTERNAL_TTF_RenderUTF8_Blended(
                font,
                SDL.UTF8_ToNative(text),
                foregroundColor
            );
        }

        /* IntPtr refers to an Surface* */
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "TTF_RenderUNICODE_Blended")]
        public static extern IntPtr RenderUnicodeBlended(
            Font font,
            [In] [MarshalAs(UnmanagedType.LPWStr)]
                string text,
            Color foregroundColor
        );

        /* IntPtr refers to an Surface* */
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "TTF_RenderText_Blended_Wrapped")]
        public static extern IntPtr RenderTextBlendedWrapped(
            Font font,
            [In] [MarshalAs(UnmanagedType.LPStr)]
                string text,
            Color foregroundColor,
            uint wrapped
        );

        /* IntPtr refers to an Surface* */
        [DllImport(nativeLibName, EntryPoint = "TTF_RenderUTF8_Blended_Wrapped", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr INTERNAL_TTF_RenderUTF8_Blended_Wrapped(
            Font font,
            byte[] text,
            Color foregroundColor,
            uint wrapped
        );
        public static IntPtr RenderUtf8BlendedWrapped(
            Font font,
            string text,
            Color foregroundColor,
            uint wrapped
        )
        {
            return INTERNAL_TTF_RenderUTF8_Blended_Wrapped(
                font,
                SDL.UTF8_ToNative(text),
                foregroundColor,
                wrapped
            );
        }

        /* IntPtr refers to an Surface* */
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "TTF_RenderUNICODE_Blended_Wrapped")]
        public static extern IntPtr RenderUnicodeBlendedWrapped(
            Font font,
            [In] [MarshalAs(UnmanagedType.LPWStr)]
                string text,
            Color foregroundColor,
            uint wrapped
        );

        /* IntPtr refers to an Surface* */
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "TTF_RenderGlyph_Blended")]
        public static extern IntPtr RenderGlyphBlended(
            Font font,
            char character,
            Color foregroundColor
        );


        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "TTF_CloseFont")]
        public static extern void CloseFont(Font font);

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "TTF_Quit")]
        public static extern void Quit();

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "TTF_WasInit")]
        public static extern int WasInitialized();


        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetFontKerningSize")]
        public static extern int GetFontKerningSize(
            Font font,
            int previousIndex,
            int index
        );

        #endregion
    }
}
