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


		#region render.h

		[Flags]
		public enum RendererFlags : uint
		{
			Software =		0x00000001,
			Accelerated =	0x00000002,
			PresentVSync =	0x00000004,
			TargetTexture =	0x00000008
		}

		[Flags]
		public enum RendererFlip
		{
			None =		0x00000000,
			Horizontal =	0x00000001,
			Vertical =	0x00000002
		}

		public enum TextureAccess
		{
			Static,
			Streaming,
			Target
		}

		[Flags]
		public enum TextureModulate
		{
			None =		0x00000000,
			Horizontal =	0x00000001,
			Vertical =		0x00000002
		}

		[StructLayout(LayoutKind.Sequential)]
		public unsafe struct RendererInfo
		{
			public IntPtr name; // const char*
			public uint flags;
			public uint num_texture_formats;
			public fixed uint texture_formats[16];
			public int max_texture_width;
			public int max_texture_height;
		}

		/* IntPtr refers to an Renderer*, window to an Window* */
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint="SDL_CreateRenderer")]
		public static extern IntPtr CreateRenderer(
			IntPtr window,
			int index,
			RendererFlags flags
		);

		/* IntPtr refers to an Renderer*, surface to an Surface* */
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint="SDL_CreateSoftwareRenderer")]
		public static extern IntPtr CreateSoftwareRenderer(IntPtr surface);

		/* IntPtr refers to an Texture*, renderer to an Renderer* */
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint="SDL_CreateTexture")]
		public static extern IntPtr CreateTexture(
			IntPtr renderer,
			uint format,
			int access,
			int w,
			int h
		);

		/* IntPtr refers to an Texture*
		 * renderer refers to an Renderer*
		 * surface refers to an Surface*
		 */
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint="SDL_CreateTextureFromSurface")]
		public static extern IntPtr CreateTextureFromSurface(
			IntPtr renderer,
			IntPtr surface
		);

		/* renderer refers to an Renderer* */
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint="SDL_DestroyRenderer")]
		public static extern void DestroyRenderer(IntPtr renderer);

		/* texture refers to an Texture* */
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint="SDL_DestroyTexture")]
		public static extern void DestroyTexture(IntPtr texture);

		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint="SDL_GetNumRenderDrivers")]
		public static extern int GetNumRenderDrivers();

		/* renderer refers to an Renderer* */
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint="SDL_GetRenderDrawBlendMode")]
		public static extern int GetRenderDrawBlendMode(
			IntPtr renderer,
			out BlendMode blendMode
		);

		/* renderer refers to an Renderer* */
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint="SDL_GetRenderDrawColor")]
		public static extern int GetRenderDrawColor(
			IntPtr renderer,
			out byte r,
			out byte g,
			out byte b,
			out byte a
		);

		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint="SDL_GetRenderDriverInfo")]
		public static extern int GetRenderDriverInfo(
			int index,
			out RendererInfo info
		);

		/* IntPtr refers to an Renderer*, window to an Window* */
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint="SDL_GetRenderer")]
		public static extern IntPtr GetRenderer(IntPtr window);

		/* renderer refers to an Renderer* */
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint="SDL_GetRendererInfo")]
		public static extern int GetRendererInfo(
			IntPtr renderer,
			out RendererInfo info
		);

		/* renderer refers to an Renderer* */
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint="SDL_GetRendererOutputSize")]
		public static extern int GetRendererOutputSize(
			IntPtr renderer,
			out int w,
			out int h
		);

		/* texture refers to an Texture* */
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint="SDL_GetTextureAlphaMod")]
		public static extern int GetTextureAlphaMod(
			IntPtr texture,
			out byte alpha
		);

		/* texture refers to an Texture* */
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint="SDL_GetTextureBlendMode")]
		public static extern int GetTextureBlendMode(
			IntPtr texture,
			out BlendMode blendMode
		);

		/* texture refers to an Texture* */
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint="SDL_GetTextureColorMod")]
		public static extern int GetTextureColorMod(
			IntPtr texture,
			out byte r,
			out byte g,
			out byte b
		);

		/* texture refers to an Texture*, pixels to a void* */
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint="SDL_LockTexture")]
		public static extern int LockTexture(
			IntPtr texture,
			ref Rect rect,
			out IntPtr pixels,
			out int pitch
		);

		/* texture refers to an Texture*, pixels to a void*.
		 * Internally, this function contains logic to use default values when
		 * the rectangle is passed as NULL.
		 * This overload allows for IntPtr.Zero to be passed for rect.
		 */
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint="SDL_LockTexture")]
		public static extern int LockTexture(
			IntPtr texture,
			IntPtr rect,
			out IntPtr pixels,
			out int pitch
		);

		/* texture refers to an Texture* */
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint="SDL_QueryTexture")]
		public static extern int QueryTexture(
			IntPtr texture,
			out uint format,
			out int access,
			out int w,
			out int h
		);

		/* renderer refers to an Renderer* */
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint="SDL_RenderClear")]
		public static extern int RenderClear(IntPtr renderer);

		/* renderer refers to an Renderer*, texture to an Texture* */
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint="SDL_RenderCopy")]
		public static extern int RenderCopy(
			IntPtr renderer,
			IntPtr texture,
			ref Rect srcrect,
			ref Rect dstrect
		);

		/* renderer refers to an Renderer*, texture to an Texture*.
		 * Internally, this function contains logic to use default values when
		 * source and destination rectangles are passed as NULL.
		 * This overload allows for IntPtr.Zero (null) to be passed for srcrect.
		 */
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint="SDL_RenderCopy")]
		public static extern int RenderCopy(
			IntPtr renderer,
			IntPtr texture,
			IntPtr srcrect,
			ref Rect dstrect
		);

		/* renderer refers to an Renderer*, texture to an Texture*.
		 * Internally, this function contains logic to use default values when
		 * source and destination rectangles are passed as NULL.
		 * This overload allows for IntPtr.Zero (null) to be passed for dstrect.
		 */
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint="SDL_RenderCopy")]
		public static extern int RenderCopy(
			IntPtr renderer,
			IntPtr texture,
			ref Rect srcrect,
			IntPtr dstrect
		);

		/* renderer refers to an Renderer*, texture to an Texture*.
		 * Internally, this function contains logic to use default values when
		 * source and destination rectangles are passed as NULL.
		 * This overload allows for IntPtr.Zero (null) to be passed for both Rects.
		 */
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint="SDL_RenderCopy")]
		public static extern int RenderCopy(
			IntPtr renderer,
			IntPtr texture,
			IntPtr srcrect,
			IntPtr dstrect
		);

		/* renderer refers to an Renderer*, texture to an Texture* */
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint="SDL_RenderCopyEx")]
		public static extern int RenderCopyEx(
			IntPtr renderer,
			IntPtr texture,
			ref Rect srcrect,
			ref Rect dstrect,
			double angle,
			ref Point center,
			RendererFlip flip
		);

		/* renderer refers to an Renderer*, texture to an Texture*.
		 * Internally, this function contains logic to use default values when
		 * source, destination, and/or center are passed as NULL.
		 * This overload allows for IntPtr.Zero (null) to be passed for srcrect.
		 */
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint="SDL_RenderCopyEx")]
		public static extern int RenderCopyEx(
			IntPtr renderer,
			IntPtr texture,
			IntPtr srcrect,
			ref Rect dstrect,
			double angle,
			ref Point center,
			RendererFlip flip
		);

		/* renderer refers to an Renderer*, texture to an Texture*.
		 * Internally, this function contains logic to use default values when
		 * source, destination, and/or center are passed as NULL.
		 * This overload allows for IntPtr.Zero (null) to be passed for dstrect.
		 */
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint="SDL_RenderCopyEx")]
		public static extern int RenderCopyEx(
			IntPtr renderer,
			IntPtr texture,
			ref Rect srcrect,
			IntPtr dstrect,
			double angle,
			ref Point center,
			RendererFlip flip
		);

		/* renderer refers to an Renderer*, texture to an Texture*.
		 * Internally, this function contains logic to use default values when
		 * source, destination, and/or center are passed as NULL.
		 * This overload allows for IntPtr.Zero (null) to be passed for center.
		 */
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint="SDL_RenderCopyEx")]
		public static extern int RenderCopyEx(
			IntPtr renderer,
			IntPtr texture,
			ref Rect srcrect,
			ref Rect dstrect,
			double angle,
			IntPtr center,
			RendererFlip flip
		);

		/* renderer refers to an Renderer*, texture to an Texture*.
		 * Internally, this function contains logic to use default values when
		 * source, destination, and/or center are passed as NULL.
		 * This overload allows for IntPtr.Zero (null) to be passed for both
		 * srcrect and dstrect.
		 */
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint="SDL_RenderCopyEx")]
		public static extern int RenderCopyEx(
			IntPtr renderer,
			IntPtr texture,
			IntPtr srcrect,
			IntPtr dstrect,
			double angle,
			ref Point center,
			RendererFlip flip
		);

		/* renderer refers to an Renderer*, texture to an Texture*.
		 * Internally, this function contains logic to use default values when
		 * source, destination, and/or center are passed as NULL.
		 * This overload allows for IntPtr.Zero (null) to be passed for both
		 * srcrect and center.
		 */
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint="SDL_RenderCopyEx")]
		public static extern int RenderCopyEx(
			IntPtr renderer,
			IntPtr texture,
			IntPtr srcrect,
			ref Rect dstrect,
			double angle,
			IntPtr center,
			RendererFlip flip
		);

		/* renderer refers to an Renderer*, texture to an Texture*.
		 * Internally, this function contains logic to use default values when
		 * source, destination, and/or center are passed as NULL.
		 * This overload allows for IntPtr.Zero (null) to be passed for both
		 * dstrect and center.
		 */
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint="SDL_RenderCopyEx")]
		public static extern int RenderCopyEx(
			IntPtr renderer,
			IntPtr texture,
			ref Rect srcrect,
			IntPtr dstrect,
			double angle,
			IntPtr center,
			RendererFlip flip
		);

		/* renderer refers to an Renderer*, texture to an Texture*.
		 * Internally, this function contains logic to use default values when
		 * source, destination, and/or center are passed as NULL.
		 * This overload allows for IntPtr.Zero (null) to be passed for all
		 * three parameters.
		 */
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint="SDL_RenderCopyEx")]
		public static extern int RenderCopyEx(
			IntPtr renderer,
			IntPtr texture,
			IntPtr srcrect,
			IntPtr dstrect,
			double angle,
			IntPtr center,
			RendererFlip flip
		);

		/* renderer refers to an Renderer* */
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint="SDL_RenderDrawLine")]
		public static extern int RenderDrawLine(
			IntPtr renderer,
			int x1,
			int y1,
			int x2,
			int y2
		);

		/* renderer refers to an Renderer* */
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint="SDL_RenderDrawLines")]
		public static extern int RenderDrawLines(
			IntPtr renderer,
			[In] Point[] points,
			int count
		);

		/* renderer refers to an Renderer* */
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint="SDL_RenderDrawPoint")]
		public static extern int RenderDrawPoint(
			IntPtr renderer,
			int x,
			int y
		);

		/* renderer refers to an Renderer* */
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint="SDL_RenderDrawPoints")]
		public static extern int RenderDrawPoints(
			IntPtr renderer,
			[In] Point[] points,
			int count
		);

		/* renderer refers to an Renderer* */
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint="SDL_RenderDrawRect")]
		public static extern int RenderDrawRect(
			IntPtr renderer,
			ref Rect rect
		);

		/* renderer refers to an Renderer*, rect to an Rect*.
		 * This overload allows for IntPtr.Zero (null) to be passed for rect.
		 */
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint="SDL_RenderDrawRect")]
		public static extern int RenderDrawRect(
			IntPtr renderer,
			IntPtr rect
		);

		/* renderer refers to an Renderer* */
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint="SDL_RenderDrawRects")]
		public static extern int RenderDrawRects(
			IntPtr renderer,
			[In] Rect[] rects,
			int count
		);

		/* renderer refers to an Renderer* */
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint="SDL_RenderFillRect")]
		public static extern int RenderFillRect(
			IntPtr renderer,
			ref Rect rect
		);

		/* renderer refers to an Renderer*, rect to an Rect*.
		 * This overload allows for IntPtr.Zero (null) to be passed for rect.
		 */
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint="SDL_RenderFillRect")]
		public static extern int RenderFillRect(
			IntPtr renderer,
			IntPtr rect
		);

		/* renderer refers to an Renderer* */
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint="SDL_RenderFillRects")]
		public static extern int RenderFillRects(
			IntPtr renderer,
			[In] Rect[] rects,
			int count
		);

		/* This region only available in SDL 2.0.10 or higher. */

		/* renderer refers to an Renderer*, texture to an Texture* */
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint="SDL_RenderCopyF")]
		public static extern int RenderCopyF(
			IntPtr renderer,
			IntPtr texture,
			ref Rect srcrect,
			ref FRect dstrect
		);

		/* renderer refers to an Renderer*, texture to an Texture*.
		 * Internally, this function contains logic to use default values when
		 * source and destination rectangles are passed as NULL.
		 * This overload allows for IntPtr.Zero (null) to be passed for srcrect.
		 */
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint="SDL_RenderCopyF")]
		public static extern int RenderCopyF(
			IntPtr renderer,
			IntPtr texture,
			IntPtr srcrect,
			ref FRect dstrect
		);

		/* renderer refers to an Renderer*, texture to an Texture*.
		 * Internally, this function contains logic to use default values when
		 * source and destination rectangles are passed as NULL.
		 * This overload allows for IntPtr.Zero (null) to be passed for dstrect.
		 */
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint="SDL_RenderCopyF")]
		public static extern int RenderCopyF(
			IntPtr renderer,
			IntPtr texture,
			ref Rect srcrect,
			IntPtr dstrect
		);

		/* renderer refers to an Renderer*, texture to an Texture*.
		 * Internally, this function contains logic to use default values when
		 * source and destination rectangles are passed as NULL.
		 * This overload allows for IntPtr.Zero (null) to be passed for both Rects.
		 */
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint="SDL_RenderCopyF")]
		public static extern int RenderCopyF(
			IntPtr renderer,
			IntPtr texture,
			IntPtr srcrect,
			IntPtr dstrect
		);

		/* renderer refers to an Renderer*, texture to an Texture* */
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint="SDL_RenderCopyEx")]
		public static extern int RenderCopyEx(
			IntPtr renderer,
			IntPtr texture,
			ref Rect srcrect,
			ref FRect dstrect,
			double angle,
			ref FPoint center,
			RendererFlip flip
		);

		/* renderer refers to an Renderer*, texture to an Texture*.
		 * Internally, this function contains logic to use default values when
		 * source, destination, and/or center are passed as NULL.
		 * This overload allows for IntPtr.Zero (null) to be passed for srcrect.
		 */
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint="SDL_RenderCopyEx")]
		public static extern int RenderCopyEx(
			IntPtr renderer,
			IntPtr texture,
			IntPtr srcrect,
			ref FRect dstrect,
			double angle,
			ref FPoint center,
			RendererFlip flip
		);

		/* renderer refers to an Renderer*, texture to an Texture*.
		 * Internally, this function contains logic to use default values when
		 * source, destination, and/or center are passed as NULL.
		 * This overload allows for IntPtr.Zero (null) to be passed for dstrect.
		 */
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint="SDL_RenderCopyExF")]
		public static extern int RenderCopyExF(
			IntPtr renderer,
			IntPtr texture,
			ref Rect srcrect,
			IntPtr dstrect,
			double angle,
			ref FPoint center,
			RendererFlip flip
		);

		/* renderer refers to an Renderer*, texture to an Texture*.
		 * Internally, this function contains logic to use default values when
		 * source, destination, and/or center are passed as NULL.
		 * This overload allows for IntPtr.Zero (null) to be passed for center.
		 */
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint="SDL_RenderCopyExF")]
		public static extern int RenderCopyExF(
			IntPtr renderer,
			IntPtr texture,
			ref Rect srcrect,
			ref FRect dstrect,
			double angle,
			IntPtr center,
			RendererFlip flip
		);

		/* renderer refers to an Renderer*, texture to an Texture*.
		 * Internally, this function contains logic to use default values when
		 * source, destination, and/or center are passed as NULL.
		 * This overload allows for IntPtr.Zero (null) to be passed for both
		 * srcrect and dstrect.
		 */
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint="SDL_RenderCopyExF")]
		public static extern int RenderCopyExF(
			IntPtr renderer,
			IntPtr texture,
			IntPtr srcrect,
			IntPtr dstrect,
			double angle,
			ref FPoint center,
			RendererFlip flip
		);

		/* renderer refers to an Renderer*, texture to an Texture*.
		 * Internally, this function contains logic to use default values when
		 * source, destination, and/or center are passed as NULL.
		 * This overload allows for IntPtr.Zero (null) to be passed for both
		 * srcrect and center.
		 */
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint="SDL_RenderCopyExF")]
		public static extern int RenderCopyExF(
			IntPtr renderer,
			IntPtr texture,
			IntPtr srcrect,
			ref FRect dstrect,
			double angle,
			IntPtr center,
			RendererFlip flip
		);

		/* renderer refers to an Renderer*, texture to an Texture*.
		 * Internally, this function contains logic to use default values when
		 * source, destination, and/or center are passed as NULL.
		 * This overload allows for IntPtr.Zero (null) to be passed for both
		 * dstrect and center.
		 */
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint="SDL_RenderCopyExF")]
		public static extern int RenderCopyExF(
			IntPtr renderer,
			IntPtr texture,
			ref Rect srcrect,
			IntPtr dstrect,
			double angle,
			IntPtr center,
			RendererFlip flip
		);

		/* renderer refers to an Renderer*, texture to an Texture*.
		 * Internally, this function contains logic to use default values when
		 * source, destination, and/or center are passed as NULL.
		 * This overload allows for IntPtr.Zero (null) to be passed for all
		 * three parameters.
		 */
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint="SDL_RenderCopyExF")]
		public static extern int RenderCopyExF(
			IntPtr renderer,
			IntPtr texture,
			IntPtr srcrect,
			IntPtr dstrect,
			double angle,
			IntPtr center,
			RendererFlip flip
		);

		/* renderer refers to an Renderer* */
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint="SDL_RenderDrawPointF")]
		public static extern int RenderDrawPointF(
			IntPtr renderer,
			float x,
			float y
		);

		/* renderer refers to an Renderer* */
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint="SDL_RenderDrawPointsF")]
		public static extern int RenderDrawPointsF(
			IntPtr renderer,
			[In] FPoint[] points,
			int count
		);

		/* renderer refers to an Renderer* */
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint="SDL_RenderDrawLineF")]
		public static extern int RenderDrawLineF(
			IntPtr renderer,
			float x1,
			float y1,
			float x2,
			float y2
		);

		/* renderer refers to an Renderer* */
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint="SDL_RenderDrawLinesF")]
		public static extern int RenderDrawLinesF(
			IntPtr renderer,
			[In] FPoint[] points,
			int count
		);

		/* renderer refers to an Renderer* */
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint="SDL_RenderDrawRectF")]
		public static extern int RenderDrawRectF(
			IntPtr renderer,
			ref FRect rect
		);

		/* renderer refers to an Renderer*, rect to an Rect*.
		 * This overload allows for IntPtr.Zero (null) to be passed for rect.
		 */
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint="SDL_RenderDrawRectF")]
		public static extern int RenderDrawRectF(
			IntPtr renderer,
			IntPtr rect
		);

		/* renderer refers to an Renderer* */
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint="SDL_RenderDrawRectsF")]
		public static extern int RenderDrawRectsF(
			IntPtr renderer,
			[In] FRect[] rects,
			int count
		);

		/* renderer refers to an Renderer* */
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint="SDL_RenderFillRectF")]
		public static extern int RenderFillRectF(
			IntPtr renderer,
			ref FRect rect
		);

		/* renderer refers to an Renderer*, rect to an Rect*.
		 * This overload allows for IntPtr.Zero (null) to be passed for rect.
		 */
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint="SDL_RenderFillRectF")]
		public static extern int RenderFillRectF(
			IntPtr renderer,
			IntPtr rect
		);

		/* renderer refers to an Renderer* */
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint="SDL_RenderFillRectsF")]
		public static extern int RenderFillRectsF(
			IntPtr renderer,
			[In] FRect[] rects,
			int count
		);

		

		/* renderer refers to an Renderer* */
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint="SDL_RenderGetClipRect")]
		public static extern void RenderGetClipRect(
			IntPtr renderer,
			out Rect rect
		);

		/* renderer refers to an Renderer* */
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint="SDL_RenderGetLogicalSize")]
		public static extern void RenderGetLogicalSize(
			IntPtr renderer,
			out int w,
			out int h
		);

		/* renderer refers to an Renderer* */
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint="SDL_RenderGetScale")]
		public static extern void RenderGetScale(
			IntPtr renderer,
			out float scaleX,
			out float scaleY
		);

		/* renderer refers to an Renderer* */
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint="SDL_RenderGetViewport")]
		public static extern int RenderGetViewport(
			IntPtr renderer,
			out Rect rect
		);

		/* renderer refers to an Renderer* */
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint="SDL_RenderPresent")]
		public static extern void RenderPresent(IntPtr renderer);

		/* renderer refers to an Renderer* */
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint="SDL_RenderReadPixels")]
		public static extern int RenderReadPixels(
			IntPtr renderer,
			ref Rect rect,
			uint format,
			IntPtr pixels,
			int pitch
		);

		/* renderer refers to an Renderer* */
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint="SDL_RenderSetClipRect")]
		public static extern int RenderSetClipRect(
			IntPtr renderer,
			ref Rect rect
		);

		/* renderer refers to an Renderer*
		 * This overload allows for IntPtr.Zero (null) to be passed for rect.
		 */
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint="SDL_RenderSetClipRect")]
		public static extern int RenderSetClipRect(
			IntPtr renderer,
			IntPtr rect
		);

		/* renderer refers to an Renderer* */
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint="SDL_RenderSetLogicalSize")]
		public static extern int RenderSetLogicalSize(
			IntPtr renderer,
			int w,
			int h
		);

		/* renderer refers to an Renderer* */
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint="SDL_RenderSetScale")]
		public static extern int RenderSetScale(
			IntPtr renderer,
			float scaleX,
			float scaleY
		);

		/* renderer refers to an Renderer* */
		/* Available in 2.0.5 or higher */
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint="SDL_RenderSetIntegerScale")]
		public static extern int RenderSetIntegerScale(
			IntPtr renderer,
			bool enable
		);

		/* renderer refers to an Renderer* */
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint="SDL_RenderSetViewport")]
		public static extern int RenderSetViewport(
			IntPtr renderer,
			ref Rect rect
		);

		/* renderer refers to an Renderer* */
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint="SDL_SetRenderDrawBlendMode")]
		public static extern int SetRenderDrawBlendMode(
			IntPtr renderer,
			BlendMode blendMode
		);

		/* renderer refers to an Renderer* */
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint="SDL_SetRenderDrawColor")]
		public static extern int SetRenderDrawColor(
			IntPtr renderer,
			byte r,
			byte g,
			byte b,
			byte a
		);

		/* renderer refers to an Renderer*, texture to an Texture* */
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint="SDL_SetRenderTarget")]
		public static extern int SetRenderTarget(
			IntPtr renderer,
			IntPtr texture
		);

		/* texture refers to an Texture* */
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint="SDL_SetTextureAlphaMod")]
		public static extern int SetTextureAlphaMod(
			IntPtr texture,
			byte alpha
		);

		/* texture refers to an Texture* */
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint="SDL_SetTextureBlendMode")]
		public static extern int SetTextureBlendMode(
			IntPtr texture,
			BlendMode blendMode
		);

		/* texture refers to an Texture* */
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint="SDL_SetTextureColorMod")]
		public static extern int SetTextureColorMod(
			IntPtr texture,
			byte r,
			byte g,
			byte b
		);

		/* texture refers to an Texture* */
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint="SDL_UnlockTexture")]
		public static extern void UnlockTexture(IntPtr texture);

		/* texture refers to an Texture* */
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint="SDL_UpdateTexture")]
		public static extern int UpdateTexture(
			IntPtr texture,
			ref Rect rect,
			IntPtr pixels,
			int pitch
		);

		/* texture refers to an Texture* */
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint="SDL_UpdateTexture")]
		public static extern int UpdateTexture(
			IntPtr texture,
			IntPtr rect,
			IntPtr pixels,
			int pitch
		);

		/* texture refers to an Texture* */
		/* Available in 2.0.1 or higher */
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint="SDL_UpdateYUVTexture")]
		public static extern int UpdateYUVTexture(
			IntPtr texture,
			ref Rect rect,
			IntPtr yPlane,
			int yPitch,
			IntPtr uPlane,
			int uPitch,
			IntPtr vPlane,
			int vPitch
		);

		/* renderer refers to an Renderer* */
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint="SDL_RenderTargetSupported")]
		public static extern bool RenderTargetSupported(
			IntPtr renderer
		);

		/* IntPtr refers to an Texture*, renderer to an Renderer* */
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint="SDL_GetRenderTarget")]
		public static extern IntPtr GetRenderTarget(IntPtr renderer);

		/* renderer refers to an Renderer* */
		/* Available in 2.0.8 or higher */
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint="SDL_RenderGetMetalLayer")]
		public static extern IntPtr RenderGetMetalLayer(
			IntPtr renderer
		);

		/* renderer refers to an Renderer* */
		/* Available in 2.0.8 or higher */
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint="SDL_RenderGetMetalCommandEncoder")]
		public static extern IntPtr RenderGetMetalCommandEncoder(
			IntPtr renderer
		);

		/* renderer refers to an Renderer* */
		/* Only available in 2.0.4 */
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint="SDL_RenderIsClipEnabled")]
		public static extern bool RenderIsClipEnabled(IntPtr renderer);

		/* renderer refers to an Renderer* */
		/* Available in 2.0.10 or higher. */
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint="SDL_RenderFlush")]
		public static extern int RenderFlush(IntPtr renderer);

		#endregion
    }
}
