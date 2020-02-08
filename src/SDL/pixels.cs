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


		#region pixels.h

		public static uint DEFINE_PIXELFOURCC(byte A, byte B, byte C, byte D)
		{
			return FOURCC(A, B, C, D);
		}

		public static uint DEFINE_PIXELFORMAT(
			PixelType type,
			PixelOrder order,
			PackedLayout layout,
			byte bits,
			byte bytes
		) {
			return (uint) (
				(1 << 28) |
				(((byte) type) << 24) |
				(((byte) order) << 20) |
				(((byte) layout) << 16) |
				(bits << 8) |
				(bytes)
			);
		}

		public static byte PIXELFLAG(uint X)
		{
			return (byte) ((X >> 28) & 0x0F);
		}

		public static byte PIXELTYPE(uint X)
		{
			return (byte) ((X >> 24) & 0x0F);
		}

		public static byte PIXELORDER(uint X)
		{
			return (byte) ((X >> 20) & 0x0F);
		}

		public static byte PIXELLAYOUT(uint X)
		{
			return (byte) ((X >> 16) & 0x0F);
		}

		public static byte BITSPERPIXEL(uint X)
		{
			return (byte) ((X >> 8) & 0xFF);
		}

		public static byte BYTESPERPIXEL(uint X)
		{
			if (ISPIXELFORMAT_FOURCC(X))
			{
				if (	(X == PIXELFORMAT_YUY2) ||
						(X == PIXELFORMAT_UYVY) ||
						(X == PIXELFORMAT_YVYU)	)
				{
					return 2;
				}
				return 1;
			}
			return (byte) (X & 0xFF);
		}

		public static bool ISPIXELFORMAT_INDEXED(uint format)
		{
			if (ISPIXELFORMAT_FOURCC(format))
			{
				return false;
			}
			PixelType pType =
					(PixelType) PIXELTYPE(format);
			return (
				pType == PixelType.Index1 ||
				pType == PixelType.Index4 ||
				pType == PixelType.Index8
			);
		}

		public static bool ISPIXELFORMAT_ALPHA(uint format)
		{
			if (ISPIXELFORMAT_FOURCC(format))
			{
				return false;
			}
			PixelOrder pOrder =
					(PixelOrder) PIXELORDER(format);
			return (
				pOrder == PixelOrder.PackedOrderARGB ||
				pOrder == PixelOrder.PackedOrderRGBA ||
				pOrder == PixelOrder.PackedOrderABGR ||
				pOrder == PixelOrder.PackedOrderBGRA
			);
		}

		public static bool ISPIXELFORMAT_FOURCC(uint format)
		{
			return (format == 0) && (PIXELFLAG(format) != 1);
		}

		public enum PixelType
		{
			Unknown,
			Index1,
			Index4,
			Index8,
			Packed8,
			Packed16,
			Packed32,
			Arrayu8,
			Arrayu16,
			Arrayu32,
			Arrayf16,
			Arrayf32
		}

		public enum PixelOrder
		{
			/* BitmapOrder */
			BitmapOrderNone,
			BitmapOrder4321,
			BitmapOrder1234,
			/* PackedOrder */
			PackedOrderNone = 0,
			PackedOrderXRGB,
			PackedOrderRGBX,
			PackedOrderARGB,
			PackedOrderRGBA,
			PackedOrderXBGR,
			PackedOrderBGRX,
			PackedOrderABGR,
			PackedOrderBGRA,
			/* ArrayOrder */
			ArrayOrderNone = 0,
			ArrayOrderRGB,
			ArrayOrderRGBA,
			ArrayOrderARGB,
			ArrayOrderBGR,
			ArrayOrderBGRA,
			ArrayOrderABGR
		}

		public enum PackedLayout
		{
			PackedLayoutNone,
			PackedLayout332,
			PackedLayout4444,
			PackedLayout1555,
			PackedLayout5551,
			PackedLayout565,
			PackedLayout8888,
			PackedLayout2101010,
			PackedLayout1010102
		}

		public static readonly uint PIXELFORMAT_UNKNOWN = 0;
		public static readonly uint PIXELFORMAT_INDEX1LSB =
			DEFINE_PIXELFORMAT(
				PixelType.Index1,
				PixelOrder.BitmapOrder4321,
				0,
				1, 0
			);
		public static readonly uint PIXELFORMAT_INDEX1MSB =
			DEFINE_PIXELFORMAT(
				PixelType.Index1,
				PixelOrder.BitmapOrder1234,
				0,
				1, 0
			);
		public static readonly uint PIXELFORMAT_INDEX4LSB =
			DEFINE_PIXELFORMAT(
				PixelType.Index4,
				PixelOrder.BitmapOrder4321,
				0,
				4, 0
			);
		public static readonly uint PIXELFORMAT_INDEX4MSB =
			DEFINE_PIXELFORMAT(
				PixelType.Index4,
				PixelOrder.BitmapOrder1234,
				0,
				4, 0
			);
		public static readonly uint PIXELFORMAT_INDEX8 =
			DEFINE_PIXELFORMAT(
				PixelType.Index8,
				0,
				0,
				8, 1
			);
		public static readonly uint PIXELFORMAT_RGB332 =
			DEFINE_PIXELFORMAT(
				PixelType.Packed8,
				PixelOrder.PackedOrderXRGB,
				PackedLayout.PackedLayout332,
				8, 1
			);
		public static readonly uint PIXELFORMAT_RGB444 =
			DEFINE_PIXELFORMAT(
				PixelType.Packed16,
				PixelOrder.PackedOrderXRGB,
				PackedLayout.PackedLayout4444,
				12, 2
			);
		public static readonly uint PIXELFORMAT_RGB555 =
			DEFINE_PIXELFORMAT(
				PixelType.Packed16,
				PixelOrder.PackedOrderXRGB,
				PackedLayout.PackedLayout1555,
				15, 2
			);
		public static readonly uint PIXELFORMAT_BGR555 =
			DEFINE_PIXELFORMAT(
				PixelType.Index1,
				PixelOrder.BitmapOrder4321,
				PackedLayout.PackedLayout1555,
				15, 2
			);
		public static readonly uint PIXELFORMAT_ARGB4444 =
			DEFINE_PIXELFORMAT(
				PixelType.Packed16,
				PixelOrder.PackedOrderARGB,
				PackedLayout.PackedLayout4444,
				16, 2
			);
		public static readonly uint PIXELFORMAT_RGBA4444 =
			DEFINE_PIXELFORMAT(
				PixelType.Packed16,
				PixelOrder.PackedOrderRGBA,
				PackedLayout.PackedLayout4444,
				16, 2
			);
		public static readonly uint PIXELFORMAT_ABGR4444 =
			DEFINE_PIXELFORMAT(
				PixelType.Packed16,
				PixelOrder.PackedOrderABGR,
				PackedLayout.PackedLayout4444,
				16, 2
			);
		public static readonly uint PIXELFORMAT_BGRA4444 =
			DEFINE_PIXELFORMAT(
				PixelType.Packed16,
				PixelOrder.PackedOrderBGRA,
				PackedLayout.PackedLayout4444,
				16, 2
			);
		public static readonly uint PIXELFORMAT_ARGB1555 =
			DEFINE_PIXELFORMAT(
				PixelType.Packed16,
				PixelOrder.PackedOrderARGB,
				PackedLayout.PackedLayout1555,
				16, 2
			);
		public static readonly uint PIXELFORMAT_RGBA5551 =
			DEFINE_PIXELFORMAT(
				PixelType.Packed16,
				PixelOrder.PackedOrderRGBA,
				PackedLayout.PackedLayout5551,
				16, 2
			);
		public static readonly uint PIXELFORMAT_ABGR1555 =
			DEFINE_PIXELFORMAT(
				PixelType.Packed16,
				PixelOrder.PackedOrderABGR,
				PackedLayout.PackedLayout1555,
				16, 2
			);
		public static readonly uint PIXELFORMAT_BGRA5551 =
			DEFINE_PIXELFORMAT(
				PixelType.Packed16,
				PixelOrder.PackedOrderBGRA,
				PackedLayout.PackedLayout5551,
				16, 2
			);
		public static readonly uint PIXELFORMAT_RGB565 =
			DEFINE_PIXELFORMAT(
				PixelType.Packed16,
				PixelOrder.PackedOrderXRGB,
				PackedLayout.PackedLayout565,
				16, 2
			);
		public static readonly uint PIXELFORMAT_BGR565 =
			DEFINE_PIXELFORMAT(
				PixelType.Packed16,
				PixelOrder.PackedOrderXBGR,
				PackedLayout.PackedLayout565,
				16, 2
			);
		public static readonly uint PIXELFORMAT_RGB24 =
			DEFINE_PIXELFORMAT(
				PixelType.Arrayu8,
				PixelOrder.ArrayOrderRGB,
				0,
				24, 3
			);
		public static readonly uint PIXELFORMAT_BGR24 =
			DEFINE_PIXELFORMAT(
				PixelType.Arrayu8,
				PixelOrder.ArrayOrderBGR,
				0,
				24, 3
			);
		public static readonly uint PIXELFORMAT_RGB888 =
			DEFINE_PIXELFORMAT(
				PixelType.Packed32,
				PixelOrder.PackedOrderXRGB,
				PackedLayout.PackedLayout8888,
				24, 4
			);
		public static readonly uint PIXELFORMAT_RGBX8888 =
			DEFINE_PIXELFORMAT(
				PixelType.Packed32,
				PixelOrder.PackedOrderRGBX,
				PackedLayout.PackedLayout8888,
				24, 4
			);
		public static readonly uint PIXELFORMAT_BGR888 =
			DEFINE_PIXELFORMAT(
				PixelType.Packed32,
				PixelOrder.PackedOrderXBGR,
				PackedLayout.PackedLayout8888,
				24, 4
			);
		public static readonly uint PIXELFORMAT_BGRX8888 =
			DEFINE_PIXELFORMAT(
				PixelType.Packed32,
				PixelOrder.PackedOrderBGRX,
				PackedLayout.PackedLayout8888,
				24, 4
			);
		public static readonly uint PIXELFORMAT_ARGB8888 =
			DEFINE_PIXELFORMAT(
				PixelType.Packed32,
				PixelOrder.PackedOrderARGB,
				PackedLayout.PackedLayout8888,
				32, 4
			);
		public static readonly uint PIXELFORMAT_RGBA8888 =
			DEFINE_PIXELFORMAT(
				PixelType.Packed32,
				PixelOrder.PackedOrderRGBA,
				PackedLayout.PackedLayout8888,
				32, 4
			);
		public static readonly uint PIXELFORMAT_ABGR8888 =
			DEFINE_PIXELFORMAT(
				PixelType.Packed32,
				PixelOrder.PackedOrderABGR,
				PackedLayout.PackedLayout8888,
				32, 4
			);
		public static readonly uint PIXELFORMAT_BGRA8888 =
			DEFINE_PIXELFORMAT(
				PixelType.Packed32,
				PixelOrder.PackedOrderBGRA,
				PackedLayout.PackedLayout8888,
				32, 4
			);
		public static readonly uint PIXELFORMAT_ARGB2101010 =
			DEFINE_PIXELFORMAT(
				PixelType.Packed32,
				PixelOrder.PackedOrderARGB,
				PackedLayout.PackedLayout2101010,
				32, 4
			);
		public static readonly uint PIXELFORMAT_YV12 =
			DEFINE_PIXELFOURCC(
				(byte) 'Y', (byte) 'V', (byte) '1', (byte) '2'
			);
		public static readonly uint PIXELFORMAT_IYUV =
			DEFINE_PIXELFOURCC(
				(byte) 'I', (byte) 'Y', (byte) 'U', (byte) 'V'
			);
		public static readonly uint PIXELFORMAT_YUY2 =
			DEFINE_PIXELFOURCC(
				(byte) 'Y', (byte) 'U', (byte) 'Y', (byte) '2'
			);
		public static readonly uint PIXELFORMAT_UYVY =
			DEFINE_PIXELFOURCC(
				(byte) 'U', (byte) 'Y', (byte) 'V', (byte) 'Y'
			);
		public static readonly uint PIXELFORMAT_YVYU =
			DEFINE_PIXELFOURCC(
				(byte) 'Y', (byte) 'V', (byte) 'Y', (byte) 'U'
			);

		[StructLayout(LayoutKind.Sequential)]
		public struct Color
		{
			public byte r;
			public byte g;
			public byte b;
			public byte a;
		}

		[StructLayout(LayoutKind.Sequential)]
		public struct Palette
		{
			public int ncolors;
			public IntPtr colors;
			public int version;
			public int refcount;
		}

		[StructLayout(LayoutKind.Sequential)]
		public struct PixelFormat
		{
			public uint format;
			public IntPtr palette; // Palette*
			public byte BitsPerPixel;
			public byte BytesPerPixel;
			public uint Rmask;
			public uint Gmask;
			public uint Bmask;
			public uint Amask;
			public byte Rloss;
			public byte Gloss;
			public byte Bloss;
			public byte Aloss;
			public byte Rshift;
			public byte Gshift;
			public byte Bshift;
			public byte Ashift;
			public int refcount;
			public IntPtr next; // PixelFormat*
		}

		/* IntPtr refers to an PixelFormat* */
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint="SDL_AllocFormat")]
		public static extern IntPtr AllocFormat(uint pixel_format);

		/* IntPtr refers to an Palette* */
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint="SDL_AllocPalette")]
		public static extern IntPtr AllocPalette(int ncolors);

		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint="SDL_CalculateGammaRamp")]
		public static extern void CalculateGammaRamp(
			float gamma,
			[Out()] [MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U2, SizeConst = 256)]
				ushort[] ramp
		);

		/* format refers to an PixelFormat* */
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint="SDL_FreeFormat")]
		public static extern void FreeFormat(IntPtr format);

		/* palette refers to an Palette* */
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint="SDL_FreePalette")]
		public static extern void FreePalette(IntPtr palette);

		[DllImport(nativeLibName, EntryPoint = "SDL_GetPixelFormatName", CallingConvention = CallingConvention.Cdecl)]
		private static extern IntPtr INTERNAL_GetPixelFormatName(
			uint format
		);
		public static string GetPixelFormatName(uint format)
		{
			return UTF8_ToManaged(
				INTERNAL_GetPixelFormatName(format)
			);
		}

		/* format refers to an PixelFormat* */
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint="SDL_GetRGB")]
		public static extern void GetRGB(
			uint pixel,
			IntPtr format,
			out byte r,
			out byte g,
			out byte b
		);

		/* format refers to an PixelFormat* */
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint="SDL_GetRGBA")]
		public static extern void GetRGBA(
			uint pixel,
			IntPtr format,
			out byte r,
			out byte g,
			out byte b,
			out byte a
		);

		/* format refers to an PixelFormat* */
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint="SDL_MapRGB")]
		public static extern uint MapRGB(
			IntPtr format,
			byte r,
			byte g,
			byte b
		);

		/* format refers to an PixelFormat* */
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint="SDL_MapRGBA")]
		public static extern uint MapRGBA(
			IntPtr format,
			byte r,
			byte g,
			byte b,
			byte a
		);

		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint="SDL_MasksToPixelFormatEnum")]
		public static extern uint MasksToPixelFormatEnum(
			int bpp,
			uint Rmask,
			uint Gmask,
			uint Bmask,
			uint Amask
		);

		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint="SDL_PixelFormatEnumToMasks")]
		public static extern bool PixelFormatEnumToMasks(
			uint format,
			out int bpp,
			out uint Rmask,
			out uint Gmask,
			out uint Bmask,
			out uint Amask
		);

		/* palette refers to an Palette* */
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint="SDL_SetPaletteColors")]
		public static extern int SetPaletteColors(
			IntPtr palette,
			[In] Color[] colors,
			int firstcolor,
			int ncolors
		);

		/* format and palette refer to an PixelFormat* and Palette* */
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint="SDL_SetPixelFormatPalette")]
		public static extern int SetPixelFormatPalette(
			IntPtr format,
			IntPtr palette
		);

		#endregion
    }
}
