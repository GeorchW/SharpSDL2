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
    public static partial class SDL
    {


		#region rect.h

		[StructLayout(LayoutKind.Sequential)]
		public struct Point
		{
			public int x;
			public int y;
		}

		[StructLayout(LayoutKind.Sequential)]
		public struct Rect
		{
			public int x;
			public int y;
			public int w;
			public int h;
		}

		/* Only available in 2.0.10 or higher. */
		[StructLayout(LayoutKind.Sequential)]
		public struct FPoint
		{
			public float x;
			public float y;
		}

		/* Only available in 2.0.10 or higher. */
		[StructLayout(LayoutKind.Sequential)]
		public struct FRect
		{
			public float x;
			public float y;
			public float w;
			public float h;
		}

		/* Only available in 2.0.4 */
		public static bool PointInRect(ref Point p, ref Rect r)
		{
			return (	(p.x >= r.x) &&
					(p.x < (r.x + r.w)) &&
					(p.y >= r.y) &&
					(p.y < (r.y + r.h))	) ;
		}

		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint="SDL_EnclosePoints")]
		public static extern bool EnclosePoints(
			[In] Point[] points,
			int count,
			ref Rect clip,
			out Rect result
		);

		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint="SDL_HasIntersection")]
		public static extern bool HasIntersection(
			ref Rect A,
			ref Rect B
		);

		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint="SDL_IntersectRect")]
		public static extern bool IntersectRect(
			ref Rect A,
			ref Rect B,
			out Rect result
		);

		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint="SDL_IntersectRectAndLine")]
		public static extern bool IntersectRectAndLine(
			ref Rect rect,
			ref int X1,
			ref int Y1,
			ref int X2,
			ref int Y2
		);

		public static bool RectEmpty(ref Rect r)
		{
			return ((r.w <= 0) || (r.h <= 0)) ;
		}

		public static bool RectEquals(
			ref Rect a,
			ref Rect b
		) {
			return (	(a.x == b.x) &&
					(a.y == b.y) &&
					(a.w == b.w) &&
					(a.h == b.h)	) ;
		}

		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint="SDL_UnionRect")]
		public static extern void UnionRect(
			ref Rect A,
			ref Rect B,
			out Rect result
		);

		#endregion
    }
}
