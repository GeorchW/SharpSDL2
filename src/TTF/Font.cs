



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
            get => GetFontStyle(this);
            set => SetFontStyle(this, value);
        }
        public int Outline
        {
            get => GetFontOutline(this);
            set => SetFontOutline(this, value);
        }
        public FontHinting Hinting
        {
            get => GetFontHinting(this);
            set => SetFontHinting(this, value);
        }
        public int Height => FontHeight(this);
        public int Ascent => FontAscent(this);
        public int Descent => FontDescent(this);
        public int LineSkip => FontLineSkip(this);
        public bool Kerning
        {
            get => GetFontKerning(this);
            set => SetFontKerning(this, value);
        }
        public long Faces => FontFaces(this);
        public bool FaceIsFixedWidth => FontFaceIsFixedWidth(this);
        public string FaceFamilyName => FontFaceFamilyName(this);
        public string FaceStyleName => FontFaceStyleName(this);

        public bool GlyphIsProvided(char c) => TTF.GlyphIsProvided(this, c);
        public int GetGlyphMetrics(
            char ch,
            out int minX,
            out int maxX,
            out int minY,
            out int maxY,
            out int advance
        ) => GlyphMetrics(this, ch, out minX, out maxX, out minY, out maxY, out advance);

        public int GetTextSize(string text, out int w, out int h) => SizeText(this, text, out w, out h);
        public IntPtr RenderTextSolid(string text, Color foregroundColor) => TTF.RenderTextSolid(this, text, foregroundColor);
        public IntPtr RenderGlyphSolid(char c, Color foregroundColor) => TTF.RenderGlyphSolid(this, c, foregroundColor);
        public IntPtr RenderTextShaded(string text, Color foregroundColor, Color bg) => TTF.RenderTextShaded(this, text, foregroundColor, bg);
        public IntPtr RenderGlyphShaded(char c, Color foregroundColor, Color bg) => TTF.RenderGlyphShaded(this, c, foregroundColor, bg);
        public IntPtr RenderTextBlended(string text, Color foregroundColor) => TTF.RenderTextBlended(this, text, foregroundColor);
        public IntPtr RenderGlyphBlended(char c, Color foregroundColor) => TTF.RenderGlyphBlended(this, c, foregroundColor);
        public IntPtr RenderTextBlendedWrapped(string text, Color foregroundColor, uint wrapped) => TTF.RenderTextBlendedWrapped(this, text, foregroundColor, wrapped);

        public int GetFontKerningSize(int previousIndex, int index) => TTF.GetFontKerningSize(this, previousIndex, index);

        public void Close() => CloseFont(this);

    }
}
