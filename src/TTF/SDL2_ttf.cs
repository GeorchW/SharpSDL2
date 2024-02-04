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
using System.Runtime.CompilerServices;
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
        public const int MinorVersion = 20;
        public const int PatchLevel = 0;

        public const int UnicodeBomNative = 0xFEFF;
        public const int UnicodeBomSwapped = 0xFFFE;


        public static void GetVersion(out Version X)
        {
            X.Major = MajorVersion;
            X.Minor = MinorVersion;
            X.Patch = PatchLevel;
        }

        [DllImport(nativeLibName, EntryPoint = "TTF_Linked_Version", CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe Version* INTERNAL_TTF_LinkedVersion();

        /// <summary>
        /// Query the version of SDL_ttf that the program is linked against.
        /// </summary>
        /// <returns>
        /// Returns a pointer to the version information.
        /// </returns>
        /// <remarks>
        /// This function gets the version of the dynamically linked SDL_ttf library.
        /// This is separate from the SDL_TTF_VERSION() macro, which tells you what
        /// version of the SDL_ttf headers you compiled against.
        /// 
        /// This returns static internal data; do not free or modify it!
        /// This function is available since SDL_ttf 2.0.12.
        /// </remarks>
        public static unsafe Version LinkedVersion()
        {
            return *INTERNAL_TTF_LinkedVersion();
        }

        /// <summary>
        /// Tell SDL_ttf whether UNICODE text is generally byteswapped.
        /// </summary>
        /// <param name="swapped">boolean to indicate whether text is byteswapped</param>
        /// <remarks>
        /// A UNICODE BOM character in a string will override this setting for the
        /// remainder of that string.
        /// This function is available since SDL_ttf 2.0.12.
        /// </remarks>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "TTF_ByteSwappedUNICODE")]
        public static extern void ByteSwappedUnicode(int swapped);

        [Obsolete("Naming convention change. Will be removed in the next major commit. Please change to ByteSwappedUnicode.")]
        public static void ByteSwappedUNICODE(int swapped) => ByteSwappedUnicode(swapped);

        /// <summary>
        /// Initialize SDL_ttf.
        /// </summary>
        /// <returns>
        /// Returns 0 on success, -1 on error.
        /// </returns>
        /// <remarks>
        /// You must successfully call this function before it is safe to call any
        /// other function in this library, with one exception: a human-readable error
        /// message can be retrieved from TTF_GetError() if this
        /// function fails.
        /// 
        /// SDL must be initialized before calls to functions in this library, because
        /// this library uses utility functions from the SDL library.
        /// 
        /// It is safe to call this more than once; the library keeps a counter of init
        /// calls, and decrements it on each call to TTF_Quit, so you must
        /// pair your init and quit calls.
        /// This function is available since SDL_ttf 2.0.12.
        /// </remarks>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "TTF_Init")]
        public static extern int Init();

        [DllImport(nativeLibName, EntryPoint = "TTF_OpenFont", CallingConvention = CallingConvention.Cdecl)]
        private static extern Font INTERNAL_TTF_OpenFont(
            byte[] file,
            int ptSize
        );

        /// <summary>
        /// Create a font from a file, using a specified point size.
        /// </summary>
        /// <param name="file">path to font file.</param>
        /// <param name="ptsize">point size to use for the newlyopened font.</param>
        /// <returns>
        /// Returns a valid TTF_Font, or NULL on error.
        /// </returns>
        /// <remarks>
        /// Some .fon fonts will have several sizes embedded in the file, so the point
        /// size becomes the index of choosing which size. If the value is too high,
        /// the last indexed size will be the default.
        /// 
        /// When done with the returned TTF_Font, use
        /// TTF_CloseFont() to dispose of it.
        /// This function is available since SDL_ttf 2.0.12.
        /// </remarks>
        public static Font OpenFont(string file, int ptSize)
        {
            return INTERNAL_TTF_OpenFont(
                SDL.UTF8_ToNative(file),
                ptSize
            );
        }

        /// <summary>
        /// Create a font from a file, using target resolutions (in DPI).
        /// </summary>
        /// <param name="file">path to font file.</param>
        /// <param name="pointSize">point size to use for the newlyopened font.</param>
        /// <param name="horizontalDpi">the target horizontal DPI.</param>
        /// <param name="verticalDpi">the target vertical DPI.</param>
        /// <returns>
        /// Returns a valid TTF_Font, or NULL on error.
        /// </returns>
        /// <remarks>
        /// DPI scaling only applies to scalable fonts (e.g. TrueType).
        /// 
        /// Some .fon fonts will have several sizes embedded in the file, so the point
        /// size becomes the index of choosing which size. If the value is too high,
        /// the last indexed size will be the default.
        /// 
        /// When done with the returned TTF_Font, use
        /// TTF_CloseFont() to dispose of it.
        /// This function is available since SDL_ttf 2.0.18.
        /// </remarks>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "TTF_OpenFontDPI")]
        public static extern Font OpenFontDPI(string file, int pointSize, uint horizontalDpi, uint verticalDpi);

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "TTF_OpenFontDPIRW")]
        private static extern Font INTERNAL_TTF_OpenFontDpiRw(nint src, int freeSource, int pointSize, uint horizontalDpi, uint verticalDpi);

        /// <summary>
        /// Opens a font from an SDL_RWops with target resolutions (in DPI).
        /// </summary>
        /// <param name="src">an SDL_RWops to provide a font file's data.</param>
        /// <param name="freeSource">true to close the RWops before returning, false to leave it open.</param>
        /// <param name="pointSize">point size to use for the newlyopened font.</param>
        /// <param name="horizontalDpi">the target horizontal DPI.</param>
        /// <param name="verticalDpi">the target vertical DPI.</param>
        /// <returns>
        /// Returns a valid TTF_Font, or NULL on error.
        /// </returns>
        /// <remarks>
        /// DPI scaling only applies to scalable fonts (e.g. TrueType).
        /// 
        /// Some .fon fonts will have several sizes embedded in the file, so the point
        /// size becomes the index of choosing which size. If the value is too high,
        /// the last indexed size will be the default.
        /// 
        /// If `freeSource` is non-zero, the RWops will be closed before returning,
        /// whether this function succeeds or not. SDL_ttf reads everything it needs
        /// from the RWops during this call in any case.
        /// 
        /// When done with the returned TTF_Font, use
        /// TTF_CloseFont() to dispose of it.
        /// This function is available since SDL_ttf 2.0.18.
        /// </remarks>

        public static Font OpenFontDpiRw(nint src, bool freeSource, int pointSize, uint horizontalDpi, uint verticalDpi)
        {
            return INTERNAL_TTF_OpenFontDpiRw(src, freeSource ? 1 : 0, pointSize, horizontalDpi, verticalDpi);
        }

        /* src refers to an RWops* */
        /* THIS IS A PUBLIC RWops FUNCTION! */
        /// <summary>
        /// Create a font from an SDL_RWops, using a specified point size.
        /// </summary>
        /// <param name="src">an SDL_RWops to provide a font file's data.</param>
        /// <param name="freeSrc">nonzero to close the RWops before returning, zero to leave it open.</param>
        /// <param name="ptSize">point size to use for the newlyopened font.</param>
        /// <returns>
        /// Returns a valid TTF_Font, or NULL on error.
        /// </returns>
        /// <remarks>
        /// Some .fon fonts will have several sizes embedded in the file, so the point
        /// size becomes the index of choosing which size. If the value is too high,
        /// the last indexed size will be the default.
        /// 
        /// If `freesrc` is non-zero, the RWops will be closed before returning,
        /// whether this function succeeds or not. SDL_ttf reads everything it needs
        /// from the RWops during this call in any case.
        /// 
        /// When done with the returned TTF_Font, use
        /// TTF_CloseFont() to dispose of it.
        /// This function is available since SDL_ttf 2.0.12.
        /// </remarks>
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

        /// <summary>
        /// Create a font from a file, using a specified face index.
        /// </summary>
        /// <param name="file">path to font file.</param>
        /// <param name="ptSize">point size to use for the newlyopened font.</param>
        /// <param name="index">index of the face in the font file.</param>
        /// <returns>
        /// Returns a valid TTF_Font, or NULL on error.
        /// </returns>
        /// <remarks>
        /// Some .fon fonts will have several sizes embedded in the file, so the point
        /// size becomes the index of choosing which size. If the value is too high,
        /// the last indexed size will be the default.
        /// 
        /// Some fonts have multiple "faces" included. The index specifies which face
        /// to use from the font file. Font files with only one face should specify
        /// zero for the index.
        /// 
        /// When done with the returned TTF_Font, use
        /// TTF_CloseFont() to dispose of it.
        /// This function is available since SDL_ttf 2.0.12.
        /// </remarks>
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

        
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "TTF_OpenFontIndexDPI")]
        private static extern Font INTERNAL_TTF_OpenFontIndexDPI(byte[] file, int ptSize, long index, uint horizontalDpi, uint verticalDpi);
        
        /// <summary>
        /// Create a font from a file, using target resolutions (in DPI).
        /// </summary>
        /// <param name="file">path to font file.</param>
        /// <param name="ptSize">point size to use for the newlyopened font.</param>
        /// <param name="index">index of the face in the font file.</param>
        /// <param name="horizontalDpi">the target horizontal DPI.</param>
        /// <param name="verticalDpi">the target vertical DPI.</param>
        /// <returns>
        /// Returns a valid TTF_Font, or NULL on error.
        /// </returns>
        /// <remarks>
        /// DPI scaling only applies to scalable fonts (e.g. TrueType).
        /// 
        /// Some .fon fonts will have several sizes embedded in the file, so the point
        /// size becomes the index of choosing which size. If the value is too high,
        /// the last indexed size will be the default.
        /// 
        /// Some fonts have multiple "faces" included. The index specifies which face
        /// to use from the font file. Font files with only one face should specify
        /// zero for the index.
        /// 
        /// When done with the returned TTF_Font, use
        /// TTF_CloseFont() to dispose of it.
        /// This function is available since SDL_ttf 2.0.18.
        /// </remarks>
        public static Font OpenFontIndexDpi(string file, int ptSize, long index, uint horizontalDpi, uint verticalDpi)
        {
            return INTERNAL_TTF_OpenFontIndexDPI(
                SDL.UTF8_ToNative(file),
                ptSize,
                index,
                horizontalDpi,
                verticalDpi
            );
        }

        
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "TTF_OpenFontIndexDPIRW")]
        private  static extern Font INTERNAL_TTF_OpenFontIndexDpiRw(nint src, int freeSource, int ptSize, long index, uint horizontalDpi, uint verticalDpi);


        /// <summary>
        /// Opens a font from an SDL_RWops with target resolutions (in DPI).
        /// </summary>
        /// <param name="src">an SDL_RWops to provide a font file's data.</param>
        /// <param name="freeSource">true to close the RWops before returning, false to leave it open.</param>
        /// <param name="ptSize">point size to use for the newlyopened font.</param>
        /// <param name="index">index of the face in the font file.</param>
        /// <param name="horizontalDpi">the target horizontal DPI.</param>
        /// <param name="verticalDpi">the target vertical DPI.</param>
        /// <returns>
        /// Returns a valid TTF_Font, or NULL on error.
        /// </returns>
        /// <remarks>
        /// DPI scaling only applies to scalable fonts (e.g. TrueType).
        /// 
        /// Some .fon fonts will have several sizes embedded in the file, so the point
        /// size becomes the index of choosing which size. If the value is too high,
        /// the last indexed size will be the default.
        /// 
        /// If `freeSource` is true, the RWops will be closed before returning,
        /// whether this function succeeds or not. SDL_ttf reads everything it needs
        /// from the RWops during this call in any case.
        /// 
        /// Some fonts have multiple "faces" included. The index specifies which face
        /// to use from the font file. Font files with only one face should specify
        /// zero for the index.
        /// 
        /// When done with the returned TTF_Font, use
        /// TTF_CloseFont() to dispose of it.
        /// This function is available since SDL_ttf 2.0.18.
        /// </remarks>
        public static Font OpenFontIndexDpiRw(nint src, bool freeSource, int ptSize, long index, uint horizontalDpi, uint verticalDpi)
        {
            return INTERNAL_TTF_OpenFontIndexDpiRw(src, freeSource ? 1 : 0, ptSize, index, horizontalDpi, verticalDpi);
        }

        /* src refers to an RWops* */
        /* THIS IS A PUBLIC RWops FUNCTION! */
        /// <summary>
        /// Create a font from an SDL_RWops, using a specified face index.
        /// </summary>
        /// <param name="src">an SDL_RWops to provide a font file's data.</param>
        /// <param name="freesrc">nonzero to close the RWops before returning, zero to leave it open.</param>
        /// <param name="ptsize">point size to use for the newlyopened font.</param>
        /// <param name="index">index of the face in the font file.</param>
        /// <returns>
        /// Returns a valid TTF_Font, or NULL on error.
        /// </returns>
        /// <remarks>
        /// Some .fon fonts will have several sizes embedded in the file, so the point
        /// size becomes the index of choosing which size. If the value is too high,
        /// the last indexed size will be the default.
        /// 
        /// If `freesrc` is non-zero, the RWops will be closed before returning,
        /// whether this function succeeds or not. SDL_ttf reads everything it needs
        /// from the RWops during this call in any case.
        /// 
        /// Some fonts have multiple "faces" included. The index specifies which face
        /// to use from the font file. Font files with only one face should specify
        /// zero for the index.
        /// 
        /// When done with the returned TTF_Font, use
        /// TTF_CloseFont() to dispose of it.
        /// This function is available since SDL_ttf 2.0.12.
        /// </remarks>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "TTF_OpenFontIndexRW")]
        public static extern Font OpenFontIndexRW(
            IntPtr src,
            int freeSrc,
            int ptSize,
            long index
        );

        /// <summary>
        /// Query a font's current style.
        /// </summary>
        /// <param name="font">the font to query.</param>
        /// <returns>
        /// Returns the current font style, as a set of bit flags.
        /// </returns>
        /// <remarks>
        /// The font styles are a set of bit flags, OR'd together:
        /// 
        /// ['[`TTF_STYLE_NORMAL`](TTF_STYLE_NORMAL) (is zero)', '[`TTF_STYLE_BOLD`](TTF_STYLE_BOLD)', '[`TTF_STYLE_ITALIC`](TTF_STYLE_ITALIC)', '[`TTF_STYLE_UNDERLINE`](TTF_STYLE_UNDERLINE)', '[`TTF_STYLE_STRIKETHROUGH`](TTF_STYLE_STRIKETHROUGH)']
        /// This function is available since SDL_ttf 2.0.12.
        /// </remarks>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "TTF_GetFontStyle")]
        public static extern FontStyle GetFontStyle(Font font);


        /// <summary>
        /// Set a font's current style.
        /// </summary>
        /// <param name="font">the font to set a new style on.</param>
        /// <param name="style">the new style values to set, OR'd together.</param>
        /// <remarks>
        /// Setting the style clears already-generated glyphs, if any, from the cache.
        /// 
        /// The font styles are a set of bit flags, OR'd together:
        /// 
        /// ['[`TTF_STYLE_NORMAL`](TTF_STYLE_NORMAL) (is zero)', '[`TTF_STYLE_BOLD`](TTF_STYLE_BOLD)', '[`TTF_STYLE_ITALIC`](TTF_STYLE_ITALIC)', '[`TTF_STYLE_UNDERLINE`](TTF_STYLE_UNDERLINE)', '[`TTF_STYLE_STRIKETHROUGH`](TTF_STYLE_STRIKETHROUGH)']
        /// This function is available since SDL_ttf 2.0.12.
        /// </remarks>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "TTF_SetFontStyle")]
        public static extern void SetFontStyle(Font font, FontStyle style);


        /// <summary>
        /// Query a font's current outline.
        /// </summary>
        /// <param name="font">the font to query.</param>
        /// <returns>
        /// Returns the font's current outline value.
        /// </returns>
        /// <remarks>
        /// 
        /// This function is available since SDL_ttf 2.0.12.
        /// </remarks>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "TTF_GetFontOutline")]
        public static extern int GetFontOutline(Font font);


        /// <summary>
        /// Set a font's current outline.
        /// </summary>
        /// <param name="font">the font to set a new outline on.</param>
        /// <param name="outline">positive outline value, 0 to default.</param>
        /// <remarks>
        /// 
        /// This function is available since SDL_ttf 2.0.12.
        /// </remarks>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "TTF_SetFontOutline")]
        public static extern void SetFontOutline(Font font, int outline);

        /// <summary>
        /// Query a font's current wrap alignment option.
        /// </summary>
        /// <param name="font">the font to query.</param>
        /// <returns>
        /// Returns the font's current wrap alignment option.
        /// </returns>
        /// <remarks>
        /// The wrap alignment option can be one of the following:
        /// 
        /// ['[`TTF_WRAPPED_ALIGN_LEFT`](TTF_WRAPPED_ALIGN_LEFT)', '[`TTF_WRAPPED_ALIGN_CENTER`](TTF_WRAPPED_ALIGN_CENTER)', '[`TTF_WRAPPED_ALIGN_RIGHT`](TTF_WRAPPED_ALIGN_RIGHT)']
        /// This function is available since SDL_ttf 2.20.0.
        /// </remarks>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "TTF_GetFontWrappedAlign")]
        public static extern int GetFontWrappedAlign(Font font);

        /// <summary>
        /// Query a font's current FreeType hinter setting.
        /// </summary>
        /// <param name="font">the font to query.</param>
        /// <returns>
        /// Returns the font's current hinter value.
        /// </returns>
        /// <remarks>
        /// The hinter setting is a single value:
        /// 
        /// ['[`TTF_HINTING_NORMAL`](TTF_HINTING_NORMAL)', '[`TTF_HINTING_LIGHT`](TTF_HINTING_LIGHT)', '[`TTF_HINTING_MONO`](TTF_HINTING_MONO)', '[`TTF_HINTING_NONE`](TTF_HINTING_NONE)', '[`TTF_HINTING_LIGHT_SUBPIXEL`](TTF_HINTING_LIGHT_SUBPIXEL) (available in\nSDL_ttf 2.0.18 and later)']
        /// This function is available since SDL_ttf 2.0.12.
        /// </remarks>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "TTF_GetFontHinting")]
        public static extern FontHinting GetFontHinting(Font font);


        /// <summary>
        /// Set a font's current hinter setting.
        /// </summary>
        /// <param name="font">the font to set a new hinter setting on.</param>
        /// <param name="hinting">the new hinter setting.</param>
        /// <remarks>
        /// Setting it clears already-generated glyphs, if any, from the cache.
        /// 
        /// The hinter setting is a single value:
        /// 
        /// ['[`TTF_HINTING_NORMAL`](TTF_HINTING_NORMAL)', '[`TTF_HINTING_LIGHT`](TTF_HINTING_LIGHT)', '[`TTF_HINTING_MONO`](TTF_HINTING_MONO)', '[`TTF_HINTING_NONE`](TTF_HINTING_NONE)', '[`TTF_HINTING_LIGHT_SUBPIXEL`](TTF_HINTING_LIGHT_SUBPIXEL) (available in\nSDL_ttf 2.0.18 and later)']
        /// This function is available since SDL_ttf 2.0.12.
        /// </remarks>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "TTF_SetFontHinting")]
        public static extern void SetFontHinting(Font font, FontHinting hinting);


        /// <summary>
        /// Query the total height of a font.
        /// </summary>
        /// <param name="font">the font to query.</param>
        /// <returns>
        /// Returns the font's height.
        /// </returns>
        /// <remarks>
        /// This is usually equal to point size.
        /// This function is available since SDL_ttf 2.0.12.
        /// </remarks>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "TTF_FontHeight")]
        public static extern int FontHeight(Font font);

        /// <summary>
        /// Query the offset from the baseline to the top of a font.
        /// </summary>
        /// <param name="font">the font to query.</param>
        /// <returns>
        /// Returns the font's ascent.
        /// </returns>
        /// <remarks>
        /// This is a positive value, relative to the baseline.
        /// This function is available since SDL_ttf 2.0.12.
        /// </remarks>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "TTF_FontAscent")]
        public static extern int FontAscent(Font font);

        /// <summary>
        /// Query the offset from the baseline to the bottom of a font.
        /// </summary>
        /// <param name="font">the font to query.</param>
        /// <returns>
        /// Returns the font's descent.
        /// </returns>
        /// <remarks>
        /// This is a negative value, relative to the baseline.
        /// This function is available since SDL_ttf 2.0.12.
        /// </remarks>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "TTF_FontDescent")]
        public static extern int FontDescent(Font font);


        /// <summary>
        /// Query the recommended spacing between lines of text for a font.
        /// </summary>
        /// <param name="font">the font to query.</param>
        /// <returns>
        /// Returns the font's recommended spacing.
        /// </returns>
        /// <remarks>
        /// 
        /// This function is available since SDL_ttf 2.0.12.
        /// </remarks>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "TTF_FontLineSkip")]
        public static extern int FontLineSkip(Font font);


        /// <summary>
        /// Query whether or not kerning is allowed for a font.
        /// </summary>
        /// <param name="font">the font to query.</param>
        /// <returns>
        /// Returns non-zero if kerning is enabled, zero otherwise.
        /// </returns>
        /// <remarks>
        /// 
        /// This function is available since SDL_ttf 2.0.12.
        /// </remarks>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "TTF_GetFontKerning")]
        public static extern bool GetFontKerning(Font font);


        /// <summary>
        /// Set if kerning is allowed for a font.
        /// </summary>
        /// <param name="font">the font to set kerning on.</param>
        /// <param name="allowed">nonzero to allow kerning, zero to disallow.</param>
        /// <remarks>
        /// Newly-opened fonts default to allowing kerning. This is generally a good
        /// policy unless you have a strong reason to disable it, as it tends to
        /// produce better rendering (with kerning disabled, some fonts might render
        /// the word `kerning` as something that looks like `keming` for example).
        /// This function is available since SDL_ttf 2.0.12.
        /// </remarks>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "TTF_SetFontKerning")]
        public static extern void SetFontKerning(Font font, bool allowed);


        /// <summary>
        /// Query the number of faces of a font.
        /// </summary>
        /// <param name="font">the font to query.</param>
        /// <returns>
        /// Returns the number of FreeType font faces.
        /// </returns>
        /// <remarks>
        /// 
        /// This function is available since SDL_ttf 2.0.12.
        /// </remarks>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "TTF_FontFaces")]
        public static extern long FontFaces(Font font);



        /// <summary>
        /// Query whether a font is fixed-width.
        /// </summary>
        /// <param name="font">the font to query.</param>
        /// <returns>
        /// Returns non-zero if fixed-width, zero if not.
        /// </returns>
        /// <remarks>
        /// A "fixed-width" font means all glyphs are the same width across; a
        /// lowercase 'i' will be the same size across as a capital 'W', for example.
        /// This is common for terminals and text editors, and other apps that treat
        /// text as a grid. Most other things (WYSIWYG word processors, web pages, etc)
        /// are more likely to not be fixed-width in most cases.
        /// This function is available since SDL_ttf 2.0.12.
        /// </remarks>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "TTF_FontFaceIsFixedWidth")]
        public static extern bool FontFaceIsFixedWidth(Font font);


        [DllImport(nativeLibName, EntryPoint = "TTF_FontFaceFamilyName", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr INTERNAL_TTF_FontFaceFamilyName(
            Font font
        );

        /// <summary>
        /// Query a font's family name.
        /// </summary>
        /// <param name="font">the font to query.</param>
        /// <returns>
        /// Returns the font's family name.
        /// </returns>
        /// <remarks>
        /// This string is dictated by the contents of the font file.
        /// 
        /// Note that the returned string is to internal storage, and should not be
        /// modifed or free'd by the caller. The string becomes invalid, with the rest
        /// of the font, when `font` is handed to TTF_CloseFont().
        /// This function is available since SDL_ttf 2.0.12.
        /// </remarks>
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

        /// <summary>
        /// Query a font's style name.
        /// </summary>
        /// <param name="font">the font to query.</param>
        /// <returns>
        /// Returns the font's style name.
        /// </returns>
        /// <remarks>
        /// This string is dictated by the contents of the font file.
        /// 
        /// Note that the returned string is to internal storage, and should not be
        /// modifed or free'd by the caller. The string becomes invalid, with the rest
        /// of the font, when `font` is handed to TTF_CloseFont().
        /// This function is available since SDL_ttf 2.0.12.
        /// </remarks>
        public static string FontFaceStyleName(Font font)
        {
            return SDL.UTF8_ToManaged(
                INTERNAL_TTF_FontFaceStyleName(font)
            );
        }


        /// <summary>
        /// Check whether a glyph is provided by the font for a 16-bit codepoint.
        /// </summary>
        /// <param name="font">the font to query.</param>
        /// <param name="ch">the character code to check.</param>
        /// <returns>
        /// Returns non-zero if font provides a glyph for this character, zero if not.
        /// </returns>
        /// <remarks>
        /// Note that this version of the function takes a 16-bit character code, which
        /// covers the Basic Multilingual Plane, but is insufficient to cover the
        /// entire set of possible Unicode values, including emoji glyphs. You should
        /// use TTF_GlyphIsProvided32() instead, which offers
        /// the same functionality but takes a 32-bit codepoint instead.
        /// 
        /// The only reason to use this function is that it was available since the
        /// beginning of time, more or less.
        /// This function is available since SDL_ttf 2.0.12.
        /// </remarks>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "TTF_GlyphIsProvided")]
        public static extern bool GlyphIsProvided(Font font, char ch);

        /// <summary>
        /// Check whether a glyph is provided by the font for a 32-bit codepoint.
        /// </summary>
        /// <param name="font">the font to query.</param>
        /// <param name="ch">the character code to check.</param>
        /// <returns>
        /// Returns non-zero if font provides a glyph for this character, zero if not.
        /// </returns>
        /// <remarks>
        /// This is the same as TTF_GlyphIsProvided(), but takes
        /// a 32-bit character instead of 16-bit, and thus can query a larger range. If
        /// you are sure you'll have an SDL_ttf that's version 2.0.18 or newer, there's
        /// no reason not to use this function exclusively.
        /// This function is available since SDL_ttf 2.0.18.
        /// </remarks>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "TTF_GlyphIsProvided32")]
        public static extern bool GlyphIsProvided32(Font font, uint ch);

        /// <summary>
        /// Query the metrics (dimensions) of a font's 16-bit glyph.
        /// </summary>
        /// <param name="font">the font to query.</param>
        /// <param name="ch">the character code to check.</param>
        /// <param name="minX">Minimum X</param>
        /// <param name="maxX">Maximum X</param>
        /// <param name="minY">Minimum Y</param>
        /// <param name="maxY">Maximum Y</param>
        /// <param name="advance"></param>
        /// <returns>
        /// 
        /// </returns>
        /// <remarks>
        /// To understand what these metrics mean, here is a useful link:
        /// 
        /// https://freetype.sourceforge.net/freetype2/docs/tutorial/step2.html
        /// 
        /// Note that this version of the function takes a 16-bit character code, which
        /// covers the Basic Multilingual Plane, but is insufficient to cover the
        /// entire set of possible Unicode values, including emoji glyphs. You should
        /// use TTF_GlyphMetrics32() instead, which offers the
        /// same functionality but takes a 32-bit codepoint instead.
        /// 
        /// The only reason to use this function is that it was available since the
        /// beginning of time, more or less.
        /// This function is available since SDL_ttf 2.0.12.
        /// </remarks>
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

        /// <summary>
        /// Query the metrics (dimensions) of a font's 32-bit glyph.
        /// </summary>
        /// <param name="font">the font to query.</param>
        /// <param name="ch">the character code to check.</param>
        /// <param name="minX">Minimum X</param>
        /// <param name="maxX">Maximum X</param>
        /// <param name="minY">Minimum Y</param>
        /// <param name="maxY">Maximum Y</param>
        /// <param name="advance"></param>
        /// <returns>
        /// 
        /// </returns>
        /// <remarks>
        /// To understand what these metrics mean, here is a useful link:
        /// 
        /// https://freetype.sourceforge.net/freetype2/docs/tutorial/step2.html
        /// 
        /// This is the same as TTF_GlyphMetrics(), but takes a
        /// 32-bit character instead of 16-bit, and thus can query a larger range. If
        /// you are sure you'll have an SDL_ttf that's version 2.0.18 or newer, there's
        /// no reason not to use this function exclusively.
        /// This function is available since SDL_ttf 2.0.18.
        /// </remarks>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "TTF_GlyphMetrics32")]
        public static extern int GlyphMetrics32(
            Font font,
            char ch,
            out int minX,
            out int maxX,
            out int minY,
            out int maxY,
            out int advance
        );

        /// <summary>
        /// Calculate the dimensions of a rendered string of Latin1 text.
        /// </summary>
        /// <param name="font">the font to query.</param>
        /// <param name="text">text to calculate, in Latin1 encoding.</param>
        /// <param name="w">will be filled with width, in pixels, on return.</param>
        /// <param name="h">will be filled with height, in pixels, on return.</param>
        /// <returns>
        /// Returns 0 if successful, -1 on error.
        /// </returns>
        /// <remarks>
        /// This will report the width and height, in pixels, of the space that the
        /// specified string will take to fully render.
        /// 
        /// This does not need to render the string to do this calculation.
        /// 
        /// You almost certainly want TTF_SizeUTF8() unless you're sure
        /// you have a 1-byte Latin1 encoding. US ASCII characters will work with
        /// either function, but most other Unicode characters packed into a `const
        /// char *` will need UTF-8.
        /// This function is available since SDL_ttf 2.0.12.
        /// </remarks>
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


        /// <summary>
        /// Calculate the dimensions of a rendered string of UTF-8 text.
        /// </summary>
        /// <param name="font">the font to query.</param>
        /// <param name="text">text to calculate, in UTF8 encoding.</param>
        /// <param name="w">will be filled with width, in pixels, on return.</param>
        /// <param name="h">will be filled with height, in pixels, on return.</param>
        /// <returns>
        /// Returns 0 if successful, -1 on error.
        /// </returns>
        /// <remarks>
        /// This will report the width and height, in pixels, of the space that the
        /// specified string will take to fully render.
        /// 
        /// This does not need to render the string to do this calculation.
        /// This function is available since SDL_ttf 2.0.12.
        /// </remarks>
        public static int SizeUtf8(
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


        /// <summary>
        /// Calculate the dimensions of a rendered string of UCS-2 text.
        /// </summary>
        /// <param name="font">the font to query.</param>
        /// <param name="text">text to calculate, in UCS2 encoding.</param>
        /// <param name="w">will be filled with width, in pixels, on return.</param>
        /// <param name="h">will be filled with height, in pixels, on return.</param>
        /// <returns>
        /// Returns 0 if successful, -1 on error.
        /// </returns>
        /// <remarks>
        /// This will report the width and height, in pixels, of the space that the
        /// specified string will take to fully render.
        /// 
        /// This does not need to render the string to do this calculation.
        /// 
        /// Please note that this function is named "Unicode" but currently expects
        /// UCS-2 encoding (16 bits per codepoint). This does not give you access to
        /// large Unicode values, such as emoji glyphs. These codepoints are accessible
        /// through the UTF-8 version of this function.
        /// This function is available since SDL_ttf 2.0.12.
        /// </remarks>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "TTF_SizeUNICODE")]
        public static extern int SizeUnicode(
            Font font,
            [In] [MarshalAs(UnmanagedType.LPWStr)]
                string text,
            out int w,
            out int h
        );

        /* IntPtr refers to an Surface* */

        /// <summary>
        /// Render Latin1 text at fast quality to a new 8-bit surface.
        /// </summary>
        /// <param name="font">the font to render with.</param>
        /// <param name="text">text to render, in Latin1 encoding.</param>
        /// <param name="fg">the foreground color for the text.</param>
        /// <returns>
        /// Returns a new 8-bit, palettized surface, or NULL if there was an error.
        /// </returns>
        /// <remarks>
        /// This function will allocate a new 8-bit, palettized surface. The surface's
        /// 0 pixel will be the colorkey, giving a transparent background. The 1 pixel
        /// will be set to the text color.
        /// 
        /// This will not word-wrap the string; you'll get a surface with a single line
        /// of text, as long as the string requires. You can use
        /// TTF_RenderText_Solid_Wrapped() instead if
        /// you need to wrap the output to multiple lines.
        /// 
        /// This will not wrap on newline characters.
        /// 
        /// You almost certainly want TTF_RenderUTF8_Solid()
        /// unless you're sure you have a 1-byte Latin1 encoding. US ASCII characters
        /// will work with either function, but most other Unicode characters packed
        /// into a `const char *` will need UTF-8.
        /// 
        /// You can render at other quality levels with
        /// TTF_RenderText_Shaded,
        /// TTF_RenderText_Blended, and
        /// TTF_RenderText_LCD.
        /// This function is available since SDL_ttf 2.0.12.
        /// </remarks>
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
        /// <summary>
        /// Render UCS-2 text at fast quality to a new 8-bit surface.
        /// </summary>
        /// <param name="font">the font to render with.</param>
        /// <param name="text">text to render, in UCS2 encoding.</param>
        /// <param name="fg">the foreground color for the text.</param>
        /// <returns>
        /// Returns a new 8-bit, palettized surface, or NULL if there was an error.
        /// </returns>
        /// <remarks>
        /// This function will allocate a new 8-bit, palettized surface. The surface's
        /// 0 pixel will be the colorkey, giving a transparent background. The 1 pixel
        /// will be set to the text color.
        /// 
        /// This will not word-wrap the string; you'll get a surface with a single line
        /// of text, as long as the string requires. You can use
        /// TTF_RenderUNICODE_Solid_Wrapped()
        /// instead if you need to wrap the output to multiple lines.
        /// 
        /// This will not wrap on newline characters.
        /// 
        /// Please note that this function is named "Unicode" but currently expects
        /// UCS-2 encoding (16 bits per codepoint). This does not give you access to
        /// large Unicode values, such as emoji glyphs. These codepoints are accessible
        /// through the UTF-8 version of this function.
        /// 
        /// You can render at other quality levels with
        /// TTF_RenderUNICODE_Shaded,
        /// TTF_RenderUNICODE_Blended, and
        /// TTF_RenderUNICODE_LCD.
        /// This function is available since SDL_ttf 2.0.12.
        /// </remarks>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "TF_RenderUNICODE_Solid")]
        public static extern IntPtr RenderUnicodeSolid(
            Font font,
            [In] [MarshalAs(UnmanagedType.LPWStr)]
                string text,
            Color foregroundColor
        );

        /* IntPtr refers to an Surface* */
        /// <summary>
        /// Render a single 16-bit glyph at fast quality to a new 8-bit surface.
        /// </summary>
        /// <param name="font">the font to render with.</param>
        /// <param name="c">the character to render.</param>
        /// <param name="foregroundColor">the foreground color for the text.</param>
        /// <returns>
        /// Returns a new 8-bit, palettized surface, or NULL if there was an error.
        /// </returns>
        /// <remarks>
        /// This function will allocate a new 8-bit, palettized surface. The surface's
        /// 0 pixel will be the colorkey, giving a transparent background. The 1 pixel
        /// will be set to the text color.
        /// 
        /// The glyph is rendered without any padding or centering in the X direction,
        /// and aligned normally in the Y direction.
        /// 
        /// Note that this version of the function takes a 16-bit character code, which
        /// covers the Basic Multilingual Plane, but is insufficient to cover the
        /// entire set of possible Unicode values, including emoji glyphs. You should
        /// use TTF_RenderGlyph32_Solid() instead, which
        /// offers the same functionality but takes a 32-bit codepoint instead.
        /// 
        /// The only reason to use this function is that it was available since the
        /// beginning of time, more or less.
        /// 
        /// You can render at other quality levels with
        /// TTF_RenderGlyph_Shaded,
        /// TTF_RenderGlyph_Blended, and
        /// TTF_RenderGlyph_LCD.
        /// This function is available since SDL_ttf 2.0.12.
        /// </remarks>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "TTF_RenderGlyph_Solid")]
        public static extern IntPtr RenderGlyphSolid(
            Font font,
            char c,
            Color foregroundColor
        );

        /* IntPtr refers to an Surface* */
        /// <summary>
        /// Render Latin1 text at high quality to a new 8-bit surface.
        /// </summary>
        /// <param name="font">the font to render with.</param>
        /// <param name="text">text to render, in Latin1 encoding.</param>
        /// <param name="fg">the foreground color for the text.</param>
        /// <param name="bg">the background color for the text.</param>
        /// <returns>
        /// Returns a new 8-bit, palettized surface, or NULL if there was an error.
        /// </returns>
        /// <remarks>
        /// This function will allocate a new 8-bit, palettized surface. The surface's
        /// 0 pixel will be the specified background color, while other pixels have
        /// varying degrees of the foreground color. This function returns the new
        /// surface, or NULL if there was an error.
        /// 
        /// This will not word-wrap the string; you'll get a surface with a single line
        /// of text, as long as the string requires. You can use
        /// TTF_RenderText_Shaded_Wrapped() instead if
        /// you need to wrap the output to multiple lines.
        /// 
        /// This will not wrap on newline characters.
        /// 
        /// You almost certainly want TTF_RenderUTF8_Shaded()
        /// unless you're sure you have a 1-byte Latin1 encoding. US ASCII characters
        /// will work with either function, but most other Unicode characters packed
        /// into a `const char *` will need UTF-8.
        /// 
        /// You can render at other quality levels with
        /// TTF_RenderText_Solid,
        /// TTF_RenderText_Blended, and
        /// TTF_RenderText_LCD.
        /// This function is available since SDL_ttf 2.0.12.
        /// </remarks>
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

        /// <summary>
        /// Render UTF-8 text at high quality to a new 8-bit surface.
        /// </summary>
        /// <param name="font">the font to render with.</param>
        /// <param name="text">text to render, in UTF8 encoding.</param>
        /// <param name="fg">the foreground color for the text.</param>
        /// <param name="bg">the background color for the text.</param>
        /// <returns>
        /// Returns a new 8-bit, palettized surface, or NULL if there was an error.
        /// </returns>
        /// <remarks>
        /// This function will allocate a new 8-bit, palettized surface. The surface's
        /// 0 pixel will be the specified background color, while other pixels have
        /// varying degrees of the foreground color. This function returns the new
        /// surface, or NULL if there was an error.
        /// 
        /// This will not word-wrap the string; you'll get a surface with a single line
        /// of text, as long as the string requires. You can use
        /// TTF_RenderUTF8_Shaded_Wrapped() instead if
        /// you need to wrap the output to multiple lines.
        /// 
        /// This will not wrap on newline characters.
        /// 
        /// You can render at other quality levels with
        /// TTF_RenderUTF8_Solid,
        /// TTF_RenderUTF8_Blended, and
        /// TTF_RenderUTF8_LCD.
        /// This function is available since SDL_ttf 2.0.12.
        /// </remarks>
        public static IntPtr RenderUtf8Shaded(
            Font font,
            string text,
            Color fg,
            Color bg
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
        /// <summary>
        /// Render UCS-2 text at high quality to a new 8-bit surface.
        /// </summary>
        /// <param name="font">the font to render with.</param>
        /// <param name="text">text to render, in UCS2 encoding.</param>
        /// <param name="foregroundColor">the foreground color for the text.</param>
        /// <param name="bg">the background color for the text.</param>
        /// <returns>
        /// Returns a new 8-bit, palettized surface, or NULL if there was an error.
        /// </returns>
        /// <remarks>
        /// This function will allocate a new 8-bit, palettized surface. The surface's
        /// 0 pixel will be the specified background color, while other pixels have
        /// varying degrees of the foreground color. This function returns the new
        /// surface, or NULL if there was an error.
        /// 
        /// This will not word-wrap the string; you'll get a surface with a single line
        /// of text, as long as the string requires. You can use
        /// TTF_RenderUNICODE_Shaded_Wrapped()
        /// instead if you need to wrap the output to multiple lines.
        /// 
        /// This will not wrap on newline characters.
        /// 
        /// Please note that this function is named "Unicode" but currently expects
        /// UCS-2 encoding (16 bits per codepoint). This does not give you access to
        /// large Unicode values, such as emoji glyphs. These codepoints are accessible
        /// through the UTF-8 version of this function.
        /// 
        /// You can render at other quality levels with
        /// TTF_RenderUNICODE_Solid,
        /// TTF_RenderUNICODE_Blended, and
        /// TTF_RenderUNICODE_LCD.
        /// This function is available since SDL_ttf 2.0.12.
        /// </remarks>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "TTF_RenderUNICODE_Shaded")]
        public static extern IntPtr RenderUnicodeShaded(
            Font font,
            [In] [MarshalAs(UnmanagedType.LPWStr)]
                string text,
            Color foregroundColor,
            Color bg
        );

        /* IntPtr refers to an Surface* */
        /// <summary>
        /// Render a single 16-bit glyph at high quality to a new 8-bit surface.
        /// </summary>
        /// <param name="font">the font to render with.</param>
        /// <param name="ch">the character to render.</param>
        /// <param name="fg">the foreground color for the text.</param>
        /// <param name="bg">the background color for the text.</param>
        /// <returns>
        /// Returns a new 8-bit, palettized surface, or NULL if there was an error.
        /// </returns>
        /// <remarks>
        /// This function will allocate a new 8-bit, palettized surface. The surface's
        /// 0 pixel will be the specified background color, while other pixels have
        /// varying degrees of the foreground color. This function returns the new
        /// surface, or NULL if there was an error.
        /// 
        /// The glyph is rendered without any padding or centering in the X direction,
        /// and aligned normally in the Y direction.
        /// 
        /// Note that this version of the function takes a 16-bit character code, which
        /// covers the Basic Multilingual Plane, but is insufficient to cover the
        /// entire set of possible Unicode values, including emoji glyphs. You should
        /// use TTF_RenderGlyph32_Shaded() instead, which
        /// offers the same functionality but takes a 32-bit codepoint instead.
        /// 
        /// The only reason to use this function is that it was available since the
        /// beginning of time, more or less.
        /// 
        /// You can render at other quality levels with
        /// TTF_RenderGlyph_Solid,
        /// TTF_RenderGlyph_Blended, and
        /// TTF_RenderGlyph_LCD.
        /// This function is available since SDL_ttf 2.0.12.
        /// </remarks>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "TTF_RenderGlyph_Shaded")]
        public static extern IntPtr RenderGlyphShaded(
            Font font,
            char c,
            Color foregroundColor,
            Color bg
        );

        /* IntPtr refers to an Surface* */
        /// <summary>
        /// Render Latin1 text at high quality to a new ARGB surface.
        /// </summary>
        /// <param name="font">the font to render with.</param>
        /// <param name="text">text to render, in Latin1 encoding.</param>
        /// <param name="foregroundColor">the foreground color for the text.</param>
        /// <returns>
        /// Returns a new 32-bit, ARGB surface, or NULL if there was an error.
        /// </returns>
        /// <remarks>
        /// This function will allocate a new 32-bit, ARGB surface, using alpha
        /// blending to dither the font with the given color. This function returns the
        /// new surface, or NULL if there was an error.
        /// 
        /// This will not word-wrap the string; you'll get a surface with a single line
        /// of text, as long as the string requires. You can use
        /// TTF_RenderText_Blended_Wrapped() instead
        /// if you need to wrap the output to multiple lines.
        /// 
        /// This will not wrap on newline characters.
        /// 
        /// You almost certainly want
        /// TTF_RenderUTF8_Blended() unless you're sure you
        /// have a 1-byte Latin1 encoding. US ASCII characters will work with either
        /// function, but most other Unicode characters packed into a `const char *`
        /// will need UTF-8.
        /// 
        /// You can render at other quality levels with
        /// TTF_RenderText_Solid,
        /// TTF_RenderText_Blended, and
        /// TTF_RenderText_LCD.
        /// This function is available since SDL_ttf 2.0.12.
        /// </remarks>
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

        /// <summary>
        /// Render UTF-8 text at high quality to a new ARGB surface.
        /// </summary>
        /// <param name="font">the font to render with.</param>
        /// <param name="text">text to render, in UTF8 encoding.</param>
        /// <param name="foregroundColor">the foreground color for the text.</param>
        /// <returns>
        /// Returns a new 32-bit, ARGB surface, or NULL if there was an error.
        /// </returns>
        /// <remarks>
        /// This function will allocate a new 32-bit, ARGB surface, using alpha
        /// blending to dither the font with the given color. This function returns the
        /// new surface, or NULL if there was an error.
        /// 
        /// This will not word-wrap the string; you'll get a surface with a single line
        /// of text, as long as the string requires. You can use
        /// TTF_RenderUTF8_Blended_Wrapped() instead
        /// if you need to wrap the output to multiple lines.
        /// 
        /// This will not wrap on newline characters.
        /// 
        /// You can render at other quality levels with
        /// TTF_RenderUTF8_Solid,
        /// TTF_RenderUTF8_Shaded, and
        /// TTF_RenderUTF8_LCD.
        /// This function is available since SDL_ttf 2.0.12.
        /// </remarks>
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

        /// <summary>
        /// Render UCS-2 text at high quality to a new ARGB surface.
        /// </summary>
        /// <param name="font">the font to render with.</param>
        /// <param name="text">text to render, in UCS2 encoding.</param>
        /// <param name="foregroundColor">the foreground color for the text.</param>
        /// <returns>
        /// Returns a new 32-bit, ARGB surface, or NULL if there was an error.
        /// </returns>
        /// <remarks>
        /// This function will allocate a new 32-bit, ARGB surface, using alpha
        /// blending to dither the font with the given color. This function returns the
        /// new surface, or NULL if there was an error.
        /// 
        /// This will not word-wrap the string; you'll get a surface with a single line
        /// of text, as long as the string requires. You can use
        /// TTF_RenderUNICODE_Blended_Wrapped()
        /// instead if you need to wrap the output to multiple lines.
        /// 
        /// This will not wrap on newline characters.
        /// 
        /// Please note that this function is named "Unicode" but currently expects
        /// UCS-2 encoding (16 bits per codepoint). This does not give you access to
        /// large Unicode values, such as emoji glyphs. These codepoints are accessible
        /// through the UTF-8 version of this function.
        /// 
        /// You can render at other quality levels with
        /// TTF_RenderUNICODE_Solid,
        /// TTF_RenderUNICODE_Shaded, and
        /// TTF_RenderUNICODE_LCD.
        /// This function is available since SDL_ttf 2.0.12.
        /// </remarks>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "TTF_RenderUNICODE_Blended")]
        public static extern nint RenderUnicodeBlended(
            Font font,
            [In] [MarshalAs(UnmanagedType.LPWStr)]
                string text,
            Color foregroundColor
        );

        /* IntPtr refers to an Surface* */
        /// <summary>
        /// Render word-wrapLength Latin1 text at high quality to a new ARGB surface.
        /// </summary>
        /// <param name="font">the font to render with.</param>
        /// <param name="text">text to render, in Latin1 encoding.</param>
        /// <param name="foregroundColor">the foreground color for the text.</param>
        /// <param name="wrapLength"></param>
        /// <returns>
        /// Returns a new 32-bit, ARGB surface, or NULL if there was an error.
        /// </returns>
        /// <remarks>
        /// This function will allocate a new 32-bit, ARGB surface, using alpha
        /// blending to dither the font with the given color. This function returns the
        /// new surface, or NULL if there was an error.
        /// 
        /// Text is wrapLength to multiple lines on line endings and on word boundaries if
        /// it extends beyond `wrapLength` in pixels.
        /// 
        /// If wrapLength is 0, this function will only wrap on newline characters.
        /// 
        /// You almost certainly want
        /// TTF_RenderUTF8_Blended_Wrapped() unless
        /// you're sure you have a 1-byte Latin1 encoding. US ASCII characters will
        /// work with either function, but most other Unicode characters packed into a
        /// `const char *` will need UTF-8.
        /// 
        /// You can render at other quality levels with
        /// TTF_RenderText_Solid_Wrapped,
        /// TTF_RenderText_Shaded_Wrapped, and
        /// TTF_RenderText_LCD_Wrapped.
        /// This function is available since SDL_ttf 2.0.18.
        /// </remarks>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "TTF_RenderText_Blended_Wrapped")]
        public static extern IntPtr RenderTextBlendedWrapped(
            Font font,
            [In] [MarshalAs(UnmanagedType.LPStr)]
                string text,
            Color foregroundColor,
            uint wrapLength
        );

        /* IntPtr refers to an Surface* */
        [DllImport(nativeLibName, EntryPoint = "TTF_RenderUTF8_Blended_Wrapped", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr INTERNAL_TTF_RenderUTF8_Blended_Wrapped(
            Font font,
            byte[] text,
            Color foregroundColor,
            uint wrapped
        );

        /// <summary>
        /// Render word-wrapped UTF-8 text at high quality to a new ARGB surface.
        /// </summary>
        /// <param name="font">the font to render with.</param>
        /// <param name="text">text to render, in UTF8 encoding.</param>
        /// <param name="foregroundColor">the foreground color for the text.</param>
        /// <param name="wrapped"></param>
        /// <returns>
        /// Returns a new 32-bit, ARGB surface, or NULL if there was an error.
        /// </returns>
        /// <remarks>
        /// This function will allocate a new 32-bit, ARGB surface, using alpha
        /// blending to dither the font with the given color. This function returns the
        /// new surface, or NULL if there was an error.
        /// 
        /// Text is wrapped to multiple lines on line endings and on word boundaries if
        /// it extends beyond `wrapLength` in pixels.
        /// 
        /// If wrapLength is 0, this function will only wrap on newline characters.
        /// 
        /// You can render at other quality levels with
        /// INTERNAL_TTF_RenderUTF8_Solid_Wrapped,
        /// TTF_RenderUTF8_Shaded_Wrapped, and
        /// TTF_RenderUTF8_LCD_Wrapped.
        /// This function is available since SDL_ttf 2.0.18.
        /// </remarks>
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
        /// <summary>
        /// Render word-wrapped UCS-2 text at high quality to a new ARGB surface.
        /// </summary>
        /// <param name="font">the font to render with.</param>
        /// <param name="text">text to render, in UCS2 encoding.</param>
        /// <param name="foregroundColor">the foreground color for the text.</param>
        /// <param name="wrapped"></param>
        /// <returns>
        /// Returns a new 32-bit, ARGB surface, or NULL if there was an error.
        /// </returns>
        /// <remarks>
        /// This function will allocate a new 32-bit, ARGB surface, using alpha
        /// blending to dither the font with the given color. This function returns the
        /// new surface, or NULL if there was an error.
        /// 
        /// Text is wrapped to multiple lines on line endings and on word boundaries if
        /// it extends beyond `wrapLength` in pixels.
        /// 
        /// If wrapLength is 0, this function will only wrap on newline characters.
        /// 
        /// Please note that this function is named "Unicode" but currently expects
        /// UCS-2 encoding (16 bits per codepoint). This does not give you access to
        /// large Unicode values, such as emoji glyphs. These codepoints are accessible
        /// through the UTF-8 version of this function.
        /// 
        /// You can render at other quality levels with
        /// TTF_RenderUNICODE_Solid_Wrapped,
        /// TTF_RenderUNICODE_Shaded_Wrapped, and
        /// TTF_RenderUNICODE_LCD_Wrapped.
        /// This function is available since SDL_ttf 2.0.18.
        /// </remarks>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "TTF_RenderUNICODE_Blended_Wrapped")]
        public static extern IntPtr RenderUnicodeBlendedWrapped(
            Font font,
            [In] [MarshalAs(UnmanagedType.LPWStr)]
                string text,
            Color foregroundColor,
            uint wrapped
        );

        /* IntPtr refers to an Surface* */
        /// <summary>
        /// Render a single 16-bit glyph at high quality to a new ARGB surface.
        /// </summary>
        /// <param name="font">the font to render with.</param>
        /// <param name="character">the character to render.</param>
        /// <param name="foregroundColor">the foreground color for the text.</param>
        /// <returns>
        /// Returns a new 32-bit, ARGB surface, or NULL if there was an error.
        /// </returns>
        /// <remarks>
        /// This function will allocate a new 32-bit, ARGB surface, using alpha
        /// blending to dither the font with the given color. This function returns the
        /// new surface, or NULL if there was an error.
        /// 
        /// The glyph is rendered without any padding or centering in the X direction,
        /// and aligned normally in the Y direction.
        /// 
        /// Note that this version of the function takes a 16-bit character code, which
        /// covers the Basic Multilingual Plane, but is insufficient to cover the
        /// entire set of possible Unicode values, including emoji glyphs. You should
        /// use TTF_RenderGlyph32_Blended() instead, which
        /// offers the same functionality but takes a 32-bit codepoint instead.
        /// 
        /// The only reason to use this function is that it was available since the
        /// beginning of time, more or less.
        /// 
        /// You can render at other quality levels with
        /// TTF_RenderGlyph_Solid,
        /// TTF_RenderGlyph_Shaded, and
        /// TTF_RenderGlyph_LCD.
        /// This function is available since SDL_ttf 2.0.12.
        /// </remarks>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "TTF_RenderGlyph_Blended")]
        public static extern IntPtr RenderGlyphBlended(
            Font font,
            char character,
            Color foregroundColor
        );

        /// <summary>
        /// Dispose of a previously-created font.
        /// </summary>
        /// <param name="font">the font to dispose of.</param>
        /// <remarks>
        /// Call this when done with a font. This function will free any resources
        /// associated with it. It is safe to call this function on NULL, for example
        /// on the result of a failed call to TTF_OpenFont().
        /// 
        /// The font is not valid after being passed to this function. String pointers
        /// from functions that return information on this font, such as
        /// TTF_FontFaceFamilyName() and
        /// TTF_FontFaceStyleName(), are no longer valid after
        /// this call, as well.
        /// This function is available since SDL_ttf 2.0.12.
        /// </remarks>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "TTF_CloseFont")]
        public static extern void CloseFont(Font font);


        /// <summary>
        /// Create a font from an SDL_RWops, using a specified point size.
        /// </summary>
        /// <param name="src">an SDL_RWops to provide a font file's data.</param>
        /// <param name="freesrc">nonzero to close the RWops before returning, zero to leave it open.</param>
        /// <param name="ptsize">point size to use for the newlyopened font.</param>
        /// <returns>
        /// Returns a valid TTF_Font, or NULL on error.
        /// </returns>
        /// <remarks>
        /// Some .fon fonts will have several sizes embedded in the file, so the point
        /// size becomes the index of choosing which size. If the value is too high,
        /// the last indexed size will be the default.
        /// 
        /// If `freesrc` is non-zero, the RWops will be closed before returning,
        /// whether this function succeeds or not. SDL_ttf reads everything it needs
        /// from the RWops during this call in any case.
        /// 
        /// When done with the returned TTF_Font, use
        /// TTF_CloseFont() to dispose of it.
        /// This function is available since SDL_ttf 2.0.12.
        /// </remarks>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "TTF_Quit")]
        public static extern void Quit();

        /// <summary>
        /// Check if SDL_ttf is initialized.
        /// </summary>
        /// <returns>
        /// Returns the current number of initialization calls, that need to eventually
        /// be paired with this many calls to TTF_Quit().
        /// </returns>
        /// <remarks>
        /// This reports the number of times the library has been initialized by a call
        /// to TTF_Init(), without a paired deinitialization request from
        /// TTF_Quit().
        /// 
        /// In short: if it's greater than zero, the library is currently initialized
        /// and ready to work. If zero, it is not initialized.
        /// 
        /// Despite the return value being a signed integer, this function should not
        /// return a negative number.
        /// This function is available since SDL_ttf 2.0.12.
        /// </remarks>

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "TTF_WasInit")]
        public static extern int WasInitialized();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="font"></param>
        /// <param name="previousIndex"></param>
        /// <param name="index"></param>
        /// <remarks>
        /// This is undocumented in the SDL Documentation. Please provide Summary and Parameter descriptions.
        /// </remarks>
        /// <returns></returns>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetFontKerningSize")]
        public static extern int GetFontKerningSize(
            Font font,
            int previousIndex,
            int index
        );

        /// <summary>
        /// Calculate how much of a Latin1 string will fit in a given width.
        /// </summary>
        /// <param name="font">the font to query.</param>
        /// <param name="text">text to calculate, in Latin1 encoding.</param>
        /// <param name="measureWidth">maximum width, in pixels, available for the string.</param>
        /// <param name="count">on return, filled with number of characters that can be rendered.</param>
        /// <param name="extent">on return, filled with latest calculated width.</param>
        /// <returns>
        /// Returns 0 if successful, -1 on error.
        /// </returns>
        /// <remarks>
        /// This reports the number of characters that can be rendered before reaching
        /// `measure_width`.
        /// 
        /// This does not need to render the string to do this calculation.
        /// 
        /// You almost certainly want TTF_MeasureUTF8() unless
        /// you're sure you have a 1-byte Latin1 encoding. US ASCII characters will
        /// work with either function, but most other Unicode characters packed into a
        /// `const char *` will need UTF-8.
        /// This function is available since SDL_ttf 2.0.18.
        /// </remarks>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "TTF_MeasureText")]
        public static extern int MeasureText(Font font, string text, int measureWidth, out int extent, out int count);

        /// <summary>
        /// Calculate how much of a UCS-2 string will fit in a given width.
        /// </summary>
        /// <param name="font">the font to query.</param>
        /// <param name="text">text to calculate, in UCS2 encoding.</param>
        /// <param name="measureWidth">maximum width, in pixels, available for the string.</param>
        /// <param name="count">on return, filled with number of characters that can be rendered.</param>
        /// <param name="extent">on return, filled with latest calculated width.</param>
        /// <returns>
        /// Returns 0 if successful, -1 on error.
        /// </returns>
        /// <remarks>
        /// This reports the number of characters that can be rendered before reaching
        /// `measure_width`.
        /// 
        /// This does not need to render the string to do this calculation.
        /// 
        /// Please note that this function is named "Unicode" but currently expects
        /// UCS-2 encoding (16 bits per codepoint). This does not give you access to
        /// large Unicode values, such as emoji glyphs. These codepoints are accessible
        /// through the UTF-8 version of this function.
        /// This function is available since SDL_ttf 2.0.18.
        /// </remarks>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "TTF_MeasureUNICODE")]
        public static extern int MeasureUnicode(Font font, string text, int measureWidth, out int extent,
            out int count);

        /// <summary>
        /// Calculate how much of a UTF-8 string will fit in a given width.
        /// </summary>
        /// <param name="font">the font to query.</param>
        /// <param name="text">text to calculate, in UTF8 encoding.</param>
        /// <param name="measureWidth">maximum width, in pixels, available for the string.</param>
        /// <param name="count">on return, filled with number of characters that can be rendered.</param>
        /// <param name="extent">on return, filled with latest calculated width.</param>
        /// <returns>
        /// Returns 0 if successful, -1 on error.
        /// </returns>
        /// <remarks>
        /// This reports the number of characters that can be rendered before reaching
        /// `measure_width`.
        /// 
        /// This does not need to render the string to do this calculation.
        /// This function is available since SDL_ttf 2.0.18.
        /// </remarks>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "TTF_MeasureUTF8")]
        public static extern int MeasureUTF8(Font font, string text, int measureWidth, out int extent, out int count);

        /// <summary>
        /// Query the version of the FreeType library in use.
        /// </summary>
        /// <param name="major">to be filled in with the major version number. Can be NULL.</param>
        /// <param name="minor">to be filled in with the minor version number. Can be NULL.</param>
        /// <param name="patch">to be filled in with the param version number. Can be NULL.</param>
        /// <remarks>
        /// TTF_Init() should be called before calling this function.
        /// This function is available since SDL_ttf 2.0.18.
        /// </remarks>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "TTF_GetFreeTypeVersion")]
        public static extern void GetFreeTypeVersion(out int major, out int minor, out int patch);

        /// <summary>
        /// Query the version of the HarfBuzz library in use.
        /// </summary>
        /// <param name="major">to be filled in with the major version number. Can be NULL.</param>
        /// <param name="minor">to be filled in with the minor version number. Can be NULL.</param>
        /// <param name="patch">to be filled in with the param version number. Can be NULL.</param>
        /// <remarks>
        /// If HarfBuzz is not available, the version reported is 0.0.0.
        /// This function is available since SDL_ttf 2.0.18.
        /// </remarks>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "TTF_GetHarfBuzzVersion")]
        public static extern void GetHarfBuzzVersion(out int major, out int minor, out int patch);


        /// <summary>
        /// Render a single 32-bit glyph at high quality to a new ARGB surface.
        /// </summary>
        /// <param name="font">the font to render with.</param>
        /// <param name="ch">the character to render.</param>
        /// <param name="fg">the foreground color for the text.</param>
        /// <returns>
        /// Returns a new 32-bit, ARGB surface, or NULL if there was an error.
        /// </returns>
        /// <remarks>
        /// This function will allocate a new 32-bit, ARGB surface, using alpha
        /// blending to dither the font with the given color. This function returns the
        /// new surface, or NULL if there was an error.
        /// 
        /// The glyph is rendered without any padding or centering in the X direction,
        /// and aligned normally in the Y direction.
        /// 
        /// This is the same as TTF_RenderGlyph_Blended(),
        /// but takes a 32-bit character instead of 16-bit, and thus can render a
        /// larger range. If you are sure you'll have an SDL_ttf that's version 2.0.18
        /// or newer, there's no reason not to use this function exclusively.
        /// 
        /// You can render at other quality levels with
        /// TTF_RenderGlyph32_Solid,
        /// TTF_RenderGlyph32_Shaded, and
        /// TTF_RenderGlyph32_LCD.
        /// This function is available since SDL_ttf 2.0.18.
        /// </remarks>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "TTF_RenderGlyph32_Blended")]
        public static extern nint RenderGlyph32Blended(Font font, uint ch, Color fg);


        /// <summary>
        /// Render a single 32-bit glyph at LCD subpixel quality to a new ARGB surface.
        /// </summary>
        /// <param name="font">the font to render with.</param>
        /// <param name="ch">the character to render.</param>
        /// <param name="fg">the foreground color for the text.</param>
        /// <param name="bg">the background color for the text.</param>
        /// <returns>
        /// Returns a new 32-bit, ARGB surface, or NULL if there was an error.
        /// </returns>
        /// <remarks>
        /// This function will allocate a new 32-bit, ARGB surface, and render
        /// alpha-blended text using FreeType's LCD subpixel rendering. This function
        /// returns the new surface, or NULL if there was an error.
        /// 
        /// The glyph is rendered without any padding or centering in the X direction,
        /// and aligned normally in the Y direction.
        /// 
        /// This is the same as TTF_RenderGlyph_LCD(), but takes
        /// a 32-bit character instead of 16-bit, and thus can render a larger range.
        /// Between the two, you should always use this function.
        /// 
        /// You can render at other quality levels with
        /// TTF_RenderGlyph32_Solid,
        /// TTF_RenderGlyph32_Shaded, and
        /// TTF_RenderGlyph32_Blended.
        /// This function is available since SDL_ttf 2.20.0.
        /// </remarks>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "TTF_RenderGlyph32_LCD")]
        public static extern nint RenderGlyph32LCD(Font font, uint ch, Color fg, Color bg);

        /// <summary>
        /// Render a single 32-bit glyph at high quality to a new 8-bit surface.
        /// </summary>
        /// <param name="font">the font to render with.</param>
        /// <param name="ch">the character to render.</param>
        /// <param name="fg">the foreground color for the text.</param>
        /// <returns>
        /// Returns a new 8-bit, palettized surface, or NULL if there was an error.
        /// </returns>
        /// <remarks>
        /// This function will allocate a new 8-bit, palettized surface. The surface's
        /// 0 pixel will be the specified background color, while other pixels have
        /// varying degrees of the foreground color. This function returns the new
        /// surface, or NULL if there was an error.
        /// 
        /// The glyph is rendered without any padding or centering in the X direction,
        /// and aligned normally in the Y direction.
        /// 
        /// This is the same as TTF_RenderGlyph_Shaded(), but
        /// takes a 32-bit character instead of 16-bit, and thus can render a larger
        /// range. If you are sure you'll have an SDL_ttf that's version 2.0.18 or
        /// newer, there's no reason not to use this function exclusively.
        /// 
        /// You can render at other quality levels with
        /// TTF_RenderGlyph32_Solid,
        /// TTF_RenderGlyph32_Blended, and
        /// TTF_RenderGlyph32_LCD.
        /// This function is available since SDL_ttf 2.0.18.
        /// </remarks>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "TTF_RenderGlyph32_Shaded")]
        public static extern nint RenderGlyph32Shaded(Font font, uint ch, Color fg, Color bg);


        /// <summary>
        /// Render a single 32-bit glyph at fast quality to a new 8-bit surface.
        /// </summary>
        /// <param name="font">the font to render with.</param>
        /// <param name="ch">the character to render.</param>
        /// <param name="fg">the foreground color for the text.</param>
        /// <returns>
        /// Returns a new 8-bit, palettized surface, or NULL if there was an error.
        /// </returns>
        /// <remarks>
        /// This function will allocate a new 8-bit, palettized surface. The surface's
        /// 0 pixel will be the colorkey, giving a transparent background. The 1 pixel
        /// will be set to the text color.
        /// 
        /// The glyph is rendered without any padding or centering in the X direction,
        /// and aligned normally in the Y direction.
        /// 
        /// This is the same as TTF_RenderGlyph_Solid(), but
        /// takes a 32-bit character instead of 16-bit, and thus can render a larger
        /// range. If you are sure you'll have an SDL_ttf that's version 2.0.18 or
        /// newer, there's no reason not to use this function exclusively.
        /// 
        /// You can render at other quality levels with
        /// TTF_RenderGlyph32_Shaded,
        /// TTF_RenderGlyph32_Blended, and
        /// TTF_RenderGlyph32_LCD.
        /// This function is available since SDL_ttf 2.0.18.
        /// </remarks>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "TTF_RenderGlyph32_Solid")]
        public static extern nint RenderGlyph32Solid(Font font, uint ch, Color fg);



        /* File \SDL2_ttf\TTF_RenderGlyph_LCD.md */
        /// <summary>
        /// Render a single 16-bit glyph at LCD subpixel quality to a new ARGB surface.
        /// </summary>
        /// <param name="font">the font to render with.</param>
        /// <param name="ch">the character to render.</param>
        /// <param name="fg">the foreground color for the text.</param>
        /// <param name="bg">the background color for the text.</param>
        /// <returns>
        /// Returns a new 32-bit, ARGB surface, or NULL if there was an error.
        /// </returns>
        /// <remarks>
        /// This function will allocate a new 32-bit, ARGB surface, and render
        /// alpha-blended text using FreeType's LCD subpixel rendering. This function
        /// returns the new surface, or NULL if there was an error.
        /// 
        /// The glyph is rendered without any padding or centering in the X direction,
        /// and aligned normally in the Y direction.
        /// 
        /// Note that this version of the function takes a 16-bit character code, which
        /// covers the Basic Multilingual Plane, but is insufficient to cover the
        /// entire set of possible Unicode values, including emoji glyphs. You should
        /// use TTF_RenderGlyph32_LCD() instead, which offers
        /// the same functionality but takes a 32-bit codepoint instead.
        /// 
        /// This function only exists for consistency with the existing API at the time
        /// of its addition.
        /// 
        /// You can render at other quality levels with
        /// TTF_RenderGlyph_Solid,
        /// TTF_RenderGlyph_Shaded, and
        /// TTF_RenderGlyph_Blended.
        /// This function is available since SDL_ttf 2.20.0.
        /// </remarks>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "TTF_RenderGlyph_LCD")]
        public static extern nint RenderGlyphLCD(Font font, ushort ch, Color fg, Color bg);

        /// <summary>
        /// Render Latin1 text at LCD subpixel quality to a new ARGB surface.
        /// </summary>
        /// <param name="font">the font to render with.</param>
        /// <param name="text">text to render, in Latin1 encoding.</param>
        /// <param name="fg">the foreground color for the text.</param>
        /// <param name="bg">the background color for the text.</param>
        /// <returns>
        /// Returns a new 32-bit, ARGB surface, or NULL if there was an error.
        /// </returns>
        /// <remarks>
        /// This function will allocate a new 32-bit, ARGB surface, and render
        /// alpha-blended text using FreeType's LCD subpixel rendering. This function
        /// returns the new surface, or NULL if there was an error.
        /// 
        /// This will not word-wrap the string; you'll get a surface with a single line
        /// of text, as long as the string requires. You can use
        /// TTF_RenderText_LCD_Wrapped() instead if you
        /// need to wrap the output to multiple lines.
        /// 
        /// This will not wrap on newline characters.
        /// 
        /// You almost certainly want TTF_RenderUTF8_LCD() unless
        /// you're sure you have a 1-byte Latin1 encoding. US ASCII characters will
        /// work with either function, but most other Unicode characters packed into a
        /// `const char *` will need UTF-8.
        /// 
        /// You can render at other quality levels with
        /// TTF_RenderText_Solid,
        /// TTF_RenderText_Shaded, and
        /// TTF_RenderText_Blended.
        /// This function is available since SDL_ttf 2.20.0.
        /// </remarks>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "TTF_RenderText_LCD")]
        public static extern nint RenderTextLcd(Font font, string  text, Color fg, Color bg);



        /* File \SDL2_ttf\TTF_RenderText_LCD_Wrapped.md */
        /// <summary>
        /// Render word-wrapped Latin1 text at LCD subpixel quality to a new ARGB surface.
        /// </summary>
        /// <param name="font">the font to render with.</param>
        /// <param name="text">text to render, in Latin1 encoding.</param>
        /// <param name="fg">the foreground color for the text.</param>
        /// <param name="bg">the background color for the text.</param>
        /// <param name="wrapLength"></param>
        /// <returns>
        /// Returns a new 32-bit, ARGB surface, or NULL if there was an error.
        /// </returns>
        /// <remarks>
        /// This function will allocate a new 32-bit, ARGB surface, and render
        /// alpha-blended text using FreeType's LCD subpixel rendering. This function
        /// returns the new surface, or NULL if there was an error.
        /// 
        /// Text is wrapped to multiple lines on line endings and on word boundaries if
        /// it extends beyond `wrapLength` in pixels.
        /// 
        /// If wrapLength is 0, this function will only wrap on newline characters.
        /// 
        /// You almost certainly want
        /// TTF_RenderUTF8_LCD_Wrapped() unless you're
        /// sure you have a 1-byte Latin1 encoding. US ASCII characters will work with
        /// either function, but most other Unicode characters packed into a `const
        /// char *` will need UTF-8.
        /// 
        /// You can render at other quality levels with
        /// TTF_RenderText_Solid_Wrapped,
        /// TTF_RenderText_Shaded_Wrapped, and
        /// TTF_RenderText_Blended_Wrapped.
        /// This function is available since SDL_ttf 2.20.0.
        /// </remarks>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "TTF_RenderText_LCD_Wrapped")]
        public static extern nint RenderTextLcdWrapped(Font font, string text, Color fg, Color bg, uint wrapLength);

        /// <summary>
        /// Render word-wrapped Latin1 text at high quality to a new 8-bit surface.
        /// </summary>
        /// <param name="font">the font to render with.</param>
        /// <param name="text">text to render, in Latin1 encoding.</param>
        /// <param name="fg">the foreground color for the text.</param>
        /// <param name="bg">the background color for the text.</param>
        /// <param name="wrapLength"></param>
        /// <returns>
        /// Returns a new 8-bit, palettized surface, or NULL if there was an error.
        /// </returns>
        /// <remarks>
        /// This function will allocate a new 8-bit, palettized surface. The surface's
        /// 0 pixel will be the specified background color, while other pixels have
        /// varying degrees of the foreground color. This function returns the new
        /// surface, or NULL if there was an error.
        /// 
        /// Text is wrapped to multiple lines on line endings and on word boundaries if
        /// it extends beyond `wrapLength` in pixels.
        /// 
        /// If wrapLength is 0, this function will only wrap on newline characters.
        /// 
        /// You almost certainly want
        /// TTF_RenderUTF8_Shaded_Wrapped() unless
        /// you're sure you have a 1-byte Latin1 encoding. US ASCII characters will
        /// work with either function, but most other Unicode characters packed into a
        /// `const char *` will need UTF-8.
        /// 
        /// You can render at other quality levels with
        /// TTF_RenderText_Solid_Wrapped,
        /// TTF_RenderText_Blended_Wrapped, and
        /// TTF_RenderText_LCD_Wrapped.
        /// This function is available since SDL_ttf 2.0.18.
        /// </remarks>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "TTF_RenderText_Shaded_Wrapped")]
        public static extern nint RenderTextShadedWrapped(Font font,
            [In][MarshalAs(UnmanagedType.LPStr)] string text,
            Color fg,
            Color bg,
            uint wrapLength);

        /// <summary>
        /// Render word-wrapped Latin1 text at fast quality to a new 8-bit surface.
        /// </summary>
        /// <param name="font">the font to render with.</param>
        /// <param name="text">text to render, in Latin1 encoding.</param>
        /// <param name="fg">the foreground color for the text.</param>
        /// <param name="wrapLength"></param>
        /// <returns>
        /// Returns a new 8-bit, palettized surface, or NULL if there was an error.
        /// </returns>
        /// <remarks>
        /// This function will allocate a new 8-bit, palettized surface. The surface's
        /// 0 pixel will be the colorkey, giving a transparent background. The 1 pixel
        /// will be set to the text color.
        /// 
        /// Text is wrapped to multiple lines on line endings and on word boundaries if
        /// it extends beyond `wrapLength` in pixels.
        /// 
        /// If wrapLength is 0, this function will only wrap on newline characters.
        /// 
        /// You almost certainly want
        /// INTERNAL_TTF_RenderUTF8_Solid_Wrapped() unless
        /// you're sure you have a 1-byte Latin1 encoding. US ASCII characters will
        /// work with either function, but most other Unicode characters packed into a
        /// `const char *` will need UTF-8.
        /// 
        /// You can render at other quality levels with
        /// TTF_RenderText_Shaded_Wrapped,
        /// TTF_RenderText_Blended_Wrapped, and
        /// TTF_RenderText_LCD_Wrapped.
        /// This function is available since SDL_ttf 2.0.18.
        /// </remarks>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "TTF_RenderText_Solid_Wrapped")]
        public static extern nint RenderTextSolidWrapped(Font font,
            [In][MarshalAs(UnmanagedType.LPStr)] string text,
            Color fg,
            uint wrapLength);



        /// <summary>
        /// Render UCS-2 text at LCD subpixel quality to a new ARGB surface.
        /// </summary>
        /// <param name="font">the font to render with.</param>
        /// <param name="text">text to render, in UCS2 encoding.</param>
        /// <param name="fg">the foreground color for the text.</param>
        /// <param name="bg">the background color for the text.</param>
        /// <returns>
        /// Returns a new 32-bit, ARGB surface, or NULL if there was an error.
        /// </returns>
        /// <remarks>
        /// This function will allocate a new 32-bit, ARGB surface, and render
        /// alpha-blended text using FreeType's LCD subpixel rendering. This function
        /// returns the new surface, or NULL if there was an error.
        /// 
        /// This will not word-wrap the string; you'll get a surface with a single line
        /// of text, as long as the string requires. You can use
        /// TTF_RenderUNICODE_LCD_Wrapped() instead if
        /// you need to wrap the output to multiple lines.
        /// 
        /// This will not wrap on newline characters.
        /// 
        /// Please note that this function is named "Unicode" but currently expects
        /// UCS-2 encoding (16 bits per codepoint). This does not give you access to
        /// large Unicode values, such as emoji glyphs. These codepoints are accessible
        /// through the UTF-8 version of this function.
        /// 
        /// You can render at other quality levels with
        /// TTF_RenderUNICODE_Solid,
        /// TTF_RenderUNICODE_Shaded, and
        /// TTF_RenderUNICODE_Blended.
        /// This function is available since SDL_ttf 2.20.0.
        /// </remarks>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "TTF_RenderUNICODE_LCD")]
        public static extern nint RenderUnicodeLcd(Font font,
            [In][MarshalAs(UnmanagedType.LPWStr)] string text,
            Color fg,
            Color bg);



        /* File \SDL2_ttf\TTF_RenderUNICODE_LCD_Wrapped.md */
        /// <summary>
        /// Render word-wrapped UCS-2 text at LCD subpixel quality to a new ARGB surface.
        /// </summary>
        /// <param name="font">the font to render with.</param>
        /// <param name="text">text to render, in UCS2 encoding.</param>
        /// <param name="fg">the foreground color for the text.</param>
        /// <param name="bg">the background color for the text.</param>
        /// <param name="wrapLength"></param>
        /// <returns>
        /// Returns a new 32-bit, ARGB surface, or NULL if there was an error.
        /// </returns>
        /// <remarks>
        /// This function will allocate a new 32-bit, ARGB surface, and render
        /// alpha-blended text using FreeType's LCD subpixel rendering. This function
        /// returns the new surface, or NULL if there was an error.
        /// 
        /// Text is wrapped to multiple lines on line endings and on word boundaries if
        /// it extends beyond `wrapLength` in pixels.
        /// 
        /// If wrapLength is 0, this function will only wrap on newline characters.
        /// 
        /// Please note that this function is named "Unicode" but currently expects
        /// UCS-2 encoding (16 bits per codepoint). This does not give you access to
        /// large Unicode values, such as emoji glyphs. These codepoints are accessible
        /// through the UTF-8 version of this function.
        /// 
        /// You can render at other quality levels with
        /// TTF_RenderUNICODE_Solid_Wrapped,
        /// TTF_RenderUNICODE_Shaded_Wrapped, and
        /// TTF_RenderUNICODE_Blended_Wrapped.
        /// This function is available since SDL_ttf 2.20.0.
        /// </remarks>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "TTF_RenderUNICODE_LCD_Wrapped")]
        public static extern nint RenderUnicodeLcdWrapped(Font font,
            [In][MarshalAs(UnmanagedType.LPWStr)] string text,
            Color fg,
            Color bg,
            uint wrapLength);

        /// <summary>
        /// Render word-wrapped UCS-2 text at high quality to a new 8-bit surface.
        /// </summary>
        /// <param name="font">the font to render with.</param>
        /// <param name="text">text to render, in UCS2 encoding.</param>
        /// <param name="fg">the foreground color for the text.</param>
        /// <param name="bg">the background color for the text.</param>
        /// <param name="wrapLength"></param>
        /// <returns>
        /// Returns a new 8-bit, palettized surface, or NULL if there was an error.
        /// </returns>
        /// <remarks>
        /// This function will allocate a new 8-bit, palettized surface. The surface's
        /// 0 pixel will be the specified background color, while other pixels have
        /// varying degrees of the foreground color. This function returns the new
        /// surface, or NULL if there was an error.
        /// 
        /// Text is wrapped to multiple lines on line endings and on word boundaries if
        /// it extends beyond `wrapLength` in pixels.
        /// 
        /// If wrapLength is 0, this function will only wrap on newline characters.
        /// 
        /// Please note that this function is named "Unicode" but currently expects
        /// UCS-2 encoding (16 bits per codepoint). This does not give you access to
        /// large Unicode values, such as emoji glyphs. These codepoints are accessible
        /// through the UTF-8 version of this function.
        /// 
        /// You can render at other quality levels with
        /// TTF_RenderUNICODE_Solid_Wrapped,
        /// TTF_RenderUNICODE_Blended_Wrapped, and
        /// TTF_RenderUNICODE_LCD_Wrapped.
        /// This function is available since SDL_ttf 2.0.18.
        /// </remarks>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "TTF_RenderUNICODE_Shaded_Wrapped")]
        public static extern nint RenderUnicodeShadedWrapped(Font font,
        
        [In][MarshalAs(UnmanagedType.LPWStr)] string text,
            Color fg, 
            Color bg,
            uint wrapLength);

        /// <summary>
        /// Render word-wrapped UCS-2 text at fast quality to a new 8-bit surface.
        /// </summary>
        /// <param name="font">the font to render with.</param>
        /// <param name="text">text to render, in UCS2 encoding.</param>
        /// <param name="fg">the foreground color for the text.</param>
        /// <param name="wrapLength"></param>
        /// <returns>
        /// Returns a new 8-bit, palettized surface, or NULL if there was an error.
        /// </returns>
        /// <remarks>
        /// This function will allocate a new 8-bit, palettized surface. The surface's
        /// 0 pixel will be the colorkey, giving a transparent background. The 1 pixel
        /// will be set to the text color.
        /// 
        /// Text is wrapped to multiple lines on line endings and on word boundaries if
        /// it extends beyond `wrapLength` in pixels.
        /// 
        /// If wrapLength is 0, this function will only wrap on newline characters.
        /// 
        /// Please note that this function is named "Unicode" but currently expects
        /// UCS-2 encoding (16 bits per codepoint). This does not give you access to
        /// large Unicode values, such as emoji glyphs. These codepoints are accessible
        /// through the UTF-8 version of this function.
        /// 
        /// You can render at other quality levels with
        /// TTF_RenderUNICODE_Shaded_Wrapped,
        /// TTF_RenderUNICODE_Blended_Wrapped, and
        /// TTF_RenderUNICODE_LCD_Wrapped.
        /// This function is available since SDL_ttf 2.0.18.
        /// </remarks>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "TTF_RenderUNICODE_Solid_Wrapped")]
        public static extern nint RenderUnicodeSolidWrapped(Font font,
        [In][MarshalAs(UnmanagedType.LPWStr)] string text,
            Color fg,
            uint wrapLength);

        
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "TTF_RenderUTF8_LCD")]
        private static extern nint INTERNAL_TTF_RenderUTF8_LCD(Font font, byte[] text, Color fg, Color bg);

        /// <summary>
        /// Render UTF-8 text at LCD subpixel quality to a new ARGB surface.
        /// </summary>
        /// <param name="font">the font to render with.</param>
        /// <param name="text">text to render, in UTF8 encoding.</param>
        /// <param name="fg">the foreground color for the text.</param>
        /// <param name="bg">the background color for the text.</param>
        /// <returns>
        /// Returns a new 32-bit, ARGB surface, or NULL if there was an error.
        /// </returns>
        /// <remarks>
        /// This function will allocate a new 32-bit, ARGB surface, and render
        /// alpha-blended text using FreeType's LCD subpixel rendering. This function
        /// returns the new surface, or NULL if there was an error.
        /// 
        /// This will not word-wrap the string; you'll get a surface with a single line
        /// of text, as long as the string requires. You can use
        /// TTF_RenderUTF8_LCD_Wrapped() instead if you
        /// need to wrap the output to multiple lines.
        /// 
        /// This will not wrap on newline characters.
        /// 
        /// You can render at other quality levels with
        /// TTF_RenderUTF8_Solid,
        /// TTF_RenderUTF8_Shaded, and
        /// TTF_RenderUTF8_Blended.
        /// This function is available since SDL_ttf 2.20.0.
        /// </remarks>
        public static nint RenderUtf8Lcd(Font font, string text, Color fg, Color bg) {
            return INTERNAL_TTF_RenderUTF8_LCD(font, SDL.UTF8_ToNative(text), fg, bg);
        }

        
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "TTF_RenderUTF8_LCD_Wrapped")]
        private static extern nint INTERNAL_TTF_RenderUTF8_LCD_Wrapped(Font font,
        byte[] text,
        Color fg, Color bg, uint wrapLength);


        /// <summary>
        /// Render word-wrapped UTF-8 text at LCD subpixel quality to a new ARGB surface.
        /// </summary>
        /// <param name="font">the font to render with.</param>
        /// <param name="text">text to render, in UTF8 encoding.</param>
        /// <param name="fg">the foreground color for the text.</param>
        /// <param name="bg">the background color for the text.</param>
        /// <param name="wrapLength"></param>
        /// <returns>
        /// Returns a new 32-bit, ARGB surface, or NULL if there was an error.
        /// </returns>
        /// <remarks>
        /// This function will allocate a new 32-bit, ARGB surface, and render
        /// alpha-blended text using FreeType's LCD subpixel rendering. This function
        /// returns the new surface, or NULL if there was an error.
        /// 
        /// Text is wrapped to multiple lines on line endings and on word boundaries if
        /// it extends beyond `wrapLength` in pixels.
        /// 
        /// If wrapLength is 0, this function will only wrap on newline characters.
        /// 
        /// You can render at other quality levels with
        /// INTERNAL_TTF_RenderUTF8_Solid_Wrapped,
        /// TTF_RenderUTF8_Shaded_Wrapped, and
        /// TTF_RenderUTF8_Blended_Wrapped.
        /// This function is available since SDL_ttf 2.20.0.
        /// </remarks>
        public static nint RenderUtf8LcdWrapped(Font font, string text, Color fg, Color bg, uint wrapLength) {
            return INTERNAL_TTF_RenderUTF8_LCD_Wrapped(font, SDL.UTF8_ToNative(text), fg, bg, wrapLength);
        }


        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "TTF_RenderUTF8_Shaded_Wrapped")]
        private static extern nint INTERNAL_TTF_RenderUTF8_Shaded_Wrapped(Font font,
        byte[] text, Color fg, Color bg, uint wrapLength);

        /// <summary>
        /// Render word-wrapped UTF-8 text at high quality to a new 8-bit surface.
        /// </summary>
        /// <param name="font">the font to render with.</param>
        /// <param name="text">text to render, in UTF8 encoding.</param>
        /// <param name="fg">the foreground color for the text.</param>
        /// <param name="bg">the background color for the text.</param>
        /// <param name="wrapLength"></param>
        /// <returns>
        /// Returns a new 8-bit, palettized surface, or NULL if there was an error.
        /// </returns>
        /// <remarks>
        /// This function will allocate a new 8-bit, palettized surface. The surface's
        /// 0 pixel will be the specified background color, while other pixels have
        /// varying degrees of the foreground color. This function returns the new
        /// surface, or NULL if there was an error.
        /// 
        /// Text is wrapped to multiple lines on line endings and on word boundaries if
        /// it extends beyond `wrapLength` in pixels.
        /// 
        /// If wrapLength is 0, this function will only wrap on newline characters.
        /// 
        /// You can render at other quality levels with
        /// INTERNAL_TTF_RenderUTF8_Solid_Wrapped,
        /// TTF_RenderUTF8_Blended_Wrapped, and
        /// TTF_RenderUTF8_LCD_Wrapped.
        /// This function is available since SDL_ttf 2.0.18.
        /// </remarks>
        public static nint RenderUtf8ShadedWrapped(Font font,
            string text, Color fg, Color bg, uint wrapLength) {
            return INTERNAL_TTF_RenderUTF8_Shaded_Wrapped(font, SDL.UTF8_ToNative(text), fg, bg, wrapLength);
        }


        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "INTERNAL_TTF_RenderUTF8_Solid_Wrapped")]
        private static extern nint INTERNAL_TTF_RenderUTF8_Solid_Wrapped(Font font,
        byte[] text, Color fg, uint wrapLength);


        /// <summary>
        /// Render word-wrapped UTF-8 text at fast quality to a new 8-bit surface.
        /// </summary>
        /// <param name="font">the font to render with.</param>
        /// <param name="text">text to render, in UTF8 encoding.</param>
        /// <param name="fg">the foreground color for the text.</param>
        /// <param name="wrapLength"></param>
        /// <returns>
        /// Returns a new 8-bit, palettized surface, or NULL if there was an error.
        /// </returns>
        /// <remarks>
        /// This function will allocate a new 8-bit, palettized surface. The surface's
        /// 0 pixel will be the colorkey, giving a transparent background. The 1 pixel
        /// will be set to the text color.
        /// 
        /// Text is wrapped to multiple lines on line endings and on word boundaries if
        /// it extends beyond `wrapLength` in pixels.
        /// 
        /// If wrapLength is 0, this function will only wrap on newline characters.
        /// 
        /// You can render at other quality levels with
        /// TTF_RenderUTF8_Shaded_Wrapped,
        /// TTF_RenderUTF8_Blended_Wrapped, and
        /// TTF_RenderUTF8_LCD_Wrapped.
        /// This function is available since SDL_ttf 2.0.18.
        /// </remarks>
        public static nint RenderUtf8SolidWrapped(Font font, string text, Color fg, uint wrapLength) {
            return INTERNAL_TTF_RenderUTF8_Solid_Wrapped(font, SDL.UTF8_ToNative(text), fg, wrapLength);
        }


        /// <summary>
        /// Set a global direction to be used for text shaping.
        /// </summary>
        /// <param name="direction">an hb_direction_t value.</param>
        /// <returns>
        /// Returns 0, or -1 if SDL_ttf is not compiled with HarfBuzz support.
        /// </returns>
        /// <remarks>
        /// 
        /// This function is available since SDL_ttf 2.0.18.
        /// </remarks>
        [Obsolete("This function is now deprecated as of SDL 2.20.0. Please use SetFontDirection(Font, FontDirection);")]
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "TTF_SetDirection")]
        public static extern int SetDirection(int direction); /* hb_direction_t */



        /* File \SDL2_ttf\TTF_SetFontDirection.md */
        /// <summary>
        /// Set direction to be used for text shaping by a font.
        /// </summary>
        /// <param name="font">the font to specify a direction for.</param>
        /// <param name="direction">the new direction for text to flow.</param>
        /// <returns>
        /// Returns 0 on success, or -1 on error.
        /// </returns>
        /// <remarks>
        /// Any value supplied here will override the global direction set with the
        /// deprecated TTF_SetDirection().
        /// 
        /// Possible direction values are:
        /// 
        /// ['[`TTF_DIRECTION_LTR`](TTF_DIRECTION_LTR) (Left to Right)', '[`TTF_DIRECTION_RTL`](TTF_DIRECTION_RTL) (Right to Left)', '[`TTF_DIRECTION_TTB`](TTF_DIRECTION_TTB) (Top to Bottom)', '[`TTF_DIRECTION_BTT`](TTF_DIRECTION_BTT) (Bottom to Top)']
        /// 
        /// If SDL_ttf was not built with HarfBuzz support, this function returns -1.
        /// This function is available since SDL_ttf 2.20.0.
        /// </remarks>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "TTF_SetFontDirection")]
        public static extern int SetFontDirection(Font font, FontDirection direction);

        /// <summary>
        /// Set script to be used for text shaping by a font.
        /// </summary>
        /// <param name="font">the font to specify a direction for.</param>
        /// <param name="script">nullterminated string of exactly 4 characters.</param>
        /// <returns>
        /// Returns 0 on success, or -1 on error.
        /// </returns>
        /// <remarks>
        /// Any value supplied here will override the global script set with the
        /// deprecated TTF_SetScript().
        /// 
        /// The supplied script value must be a null-terminated string of exactly four
        /// characters.
        /// 
        /// If SDL_ttf was not built with HarfBuzz support, this function returns -1.
        /// This function is available since SDL_ttf 2.20.0.
        /// </remarks>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "TTF_SetFontScriptName")]
        private static extern int INTERNAL_TTF_SetFontScriptName(Font font, byte[] script);

        public static int SetFontScriptName(Font font, string script) {
            return INTERNAL_TTF_SetFontScriptName(font, SDL.UTF8_ToNative(script));
        }

        /// <summary>
        /// Set a font's size dynamically.
        /// </summary>
        /// <param name="font">the font to resize.</param>
        /// <param name="ptSize">the new point size.</param>
        /// <returns>
        /// Returns 0 if successful, -1 on error
        /// </returns>
        /// <remarks>
        /// This clears already-generated glyphs, if any, from the cache.
        /// This function is available since SDL_ttf 2.0.18.
        /// </remarks>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "TTF_SetFontSize")]
        public static extern int SetFontSize(Font font, int ptSize);



        /* File \SDL2_ttf\TTF_SetFontSizeDPI.md */
        /// <summary>
        /// Set font size dynamically with target resolutions (in DPI).
        /// </summary>
        /// <param name="font">the font to resize.</param>
        /// <param name="ptSize">the new point size.</param>
        /// <param name="horizontalDpi">the target horizontal DPI.</param>
        /// <param name="verticalDpi">the target vertical DPI.</param>
        /// <returns>
        /// Returns 0 if successful, -1 on error.
        /// </returns>
        /// <remarks>
        /// This clears already-generated glyphs, if any, from the cache.
        /// This function is available since SDL_ttf 2.0.18.
        /// </remarks>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "TTF_SetFontSizeDPI")]
        public static extern int SetFontSizeDpi(Font font, int ptSize, uint horizontalDpi, uint verticalDpi);

        /// <summary>
        /// Set a font's current wrap alignment option.
        /// </summary>
        /// <param name="font">the font to set a new wrap alignment option on.</param>
        /// <param name="align">the new wrap alignment option.</param>
        /// <remarks>
        /// The wrap alignment option can be one of the following:
        /// 
        /// ['[`TTF_WRAPPED_ALIGN_LEFT`](TTF_WRAPPED_ALIGN_LEFT)', '[`TTF_WRAPPED_ALIGN_CENTER`](TTF_WRAPPED_ALIGN_CENTER)', '[`TTF_WRAPPED_ALIGN_RIGHT`](TTF_WRAPPED_ALIGN_RIGHT)']
        /// This function is available since SDL_ttf 2.20.0.
        /// </remarks>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "TTF_SetFontWrappedAlign")]
        public static extern void SetFontWrappedAlign(Font font, FontWrappedAlign align);

        /// <summary>
        /// Set a global script to be used for text shaping.
        /// </summary>
        /// <returns>
        /// Returns 0, or -1 if SDL_ttf is not compiled with HarfBuzz support.
        /// </returns>
        /// <remarks>
        /// 
        /// This function is available since SDL_ttf 2.0.18.
        /// </remarks>
        [Obsolete("This function is now deprecated as of SDL 2.20.0. Please use SetFontScriptName(Font, string);")]
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "TTF_SetScript")]
        public static extern int SetScript(int script); /* hb_script_t */

        #endregion
    }
}
