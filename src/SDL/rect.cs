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
    #region rect.h

    [StructLayout(LayoutKind.Sequential)]
    public struct Point
    {
        public int X;
        public int Y;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct Rect
    {
        public int X;
        public int Y;
        public int W;
        public int H;
    }

    /* Only available in 2.0.10 or higher. */
    [StructLayout(LayoutKind.Sequential)]
    public struct FPoint
    {
        public float X;
        public float Y;
    }

    /* Only available in 2.0.10 or higher. */
    [StructLayout(LayoutKind.Sequential)]
    public struct FRect
    {
        public float X;
        public float Y;
        public float W;
        public float H;
    }

    public static partial class SDL
    {
        /* Only available in 2.0.4 */
        public static bool PointInRect(in Point p, in Rect r)
        {
            return ((p.X >= r.X) &&
                    (p.X < (r.X + r.W)) &&
                    (p.Y >= r.Y) &&
                    (p.Y < (r.Y + r.H)));
        }

        /// <summary>Calculate a minimal rectangle enclosing a set of points.</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_EnclosePoints")]
        public static extern bool EnclosePoints(
            [In] Point[] points,
            int count,
            in Rect clip,
            out Rect result
        );

        /// <summary>Determine whether two rectangles intersect.</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_HasIntersection")]
        public static extern bool HasIntersection(
            in Rect A,
            in Rect B
        );

        /// <summary>Calculate the intersection of two rectangles.</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_IntersectRect")]
        public static extern bool IntersectRect(
            in Rect A,
            in Rect B,
            out Rect result
        );

        /// <summary>Calculate the intersection of a rectangle and line segment.</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_IntersectRectAndLine")]
        public static extern bool IntersectRectAndLine(
            in Rect rect,
            in int X1,
            in int Y1,
            in int X2,
            in int Y2
        );

        public static bool RectEmpty(ref Rect r)
        {
            return ((r.W <= 0) || (r.H <= 0));
        }

        public static bool RectEquals(
            in Rect a,
            in Rect b
        )
        {
            return ((a.X == b.X) &&
                    (a.Y == b.Y) &&
                    (a.W == b.W) &&
                    (a.H == b.H));
        }

        /// <summary>Calculate the union of two rectangles.</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_UnionRect")]
        public static extern void UnionRect(
            in Rect A,
            in Rect B,
            out Rect result
        );
    }
    #endregion
}
