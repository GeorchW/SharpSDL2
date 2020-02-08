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
using static SDL2.TTF.TTF;
#endregion

namespace SDL2.TTF
{
    [StructLayout(LayoutKind.Sequential)]
    public struct Font
    {
        public readonly IntPtr Pointer;
        public FontStyle Style
        {
            get => TTF_GetFontStyle(this);
            set => TTF_SetFontStyle(this, value);
        }
        public int Outline
        {
            get => TTF_GetFontOutline(this);
            set => TTF_SetFontOutline(this, value);
        }
        public FontHinting Hinting
        {
            get => TTF_GetFontHinting(this);
            set => TTF_SetFontHinting(this, value);
        }
        public int Height => TTF_FontHeight(this);
        public int Ascent => TTF_FontAscent(this);
        public int Descent => TTF_FontDescent(this);
        public int LineSkip => TTF_FontLineSkip(this);
        public bool Kerning
        {
            get => TTF_GetFontKerning(this);
            set => TTF_SetFontKerning(this, value);
        }
        public long Faces => TTF_FontFaces(this);
        public bool FaceIsFixedWidth => TTF_FontFaceIsFixedWidth(this);
        public string FaceFamilyName => TTF_FontFaceFamilyName(this);
        public string FaceStyleName => TTF_FontFaceStyleName(this);

        public bool GlyphIsProvided(char c) => TTF_GlyphIsProvided(this, c);
        public int GetGlyphMetrics(
            char ch,
            out int minx,
            out int maxx,
            out int miny,
            out int maxy,
            out int advance
        ) => TTF_GlyphMetrics(this, ch, out minx, out maxx, out miny, out maxy, out advance);

        public int GetTextSize(string text, out int w, out int h) => TTF_SizeText(this, text, out w, out h);
        public IntPtr RenderTextSolid(string text, SDL.Color fg) => TTF_RenderText_Solid(this, text, fg);
        public IntPtr RenderGlyphSolid(char c, SDL.Color fg) => TTF_RenderGlyph_Solid(this, c, fg);
        public IntPtr RenderTextShaded(string text, SDL.Color fg, SDL.Color bg) => TTF_RenderText_Shaded(this, text, fg, bg);
        public IntPtr RenderGlyphShaded(char c, SDL.Color fg, SDL.Color bg) => TTF_RenderGlyph_Shaded(this, c, fg, bg);
        public IntPtr RenderTextBlended(string text, SDL.Color fg) => TTF_RenderText_Blended(this, text, fg);
        public IntPtr RenderGlyphBlended(char c, SDL.Color fg) => TTF_RenderGlyph_Blended(this, c, fg);
        public IntPtr RenderTextBlendedWrapped(string text, SDL.Color fg, uint wrapped) => TTF_RenderText_Blended_Wrapped(this, text, fg, wrapped);

        public int GetFontKerningSize(int prev_index, int index) => TTF.GetFontKerningSize(this, prev_index, index);

        public void Close() => TTF_CloseFont(this);

    }
}
