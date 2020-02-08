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


		#region messagebox.h

		[Flags]
		public enum MessageBoxFlags : uint
		{
			Error =		0x00000010,
			Warning =	0x00000020,
			Information =	0x00000040
		}

		[Flags]
		public enum MessageBoxButtonFlags : uint
		{
			ReturnKeyDefault = 0x00000001,
			EscapeKeyDefault = 0x00000002
		}

		[StructLayout(LayoutKind.Sequential)]
		private struct INTERNAL_MessageBoxButtonData
		{
			public MessageBoxButtonFlags Flags;
			public int ButtonId;
			///<summary> The UTF-8 button text </summary>
			public IntPtr Text;
		}

		[StructLayout(LayoutKind.Sequential)]
		public struct MessageBoxButtonData
		{
			public MessageBoxButtonFlags Flags;
			public int ButtonId;
			///<summary> The UTF-8 button text </summary>
			public string Text;
		}

		[StructLayout(LayoutKind.Sequential)]
		public struct MessageBoxColor
		{
			public byte R, G, B;
		}

		public enum MessageBoxColorType
		{
			Background,
			Text,
			ButtonBorder,
			ButtonBackground,
			ButtonSelected,
			Max
		}

		[StructLayout(LayoutKind.Sequential)]
		public struct MessageBoxColorScheme
		{
			[MarshalAs(UnmanagedType.ByValArray, ArraySubType = UnmanagedType.Struct, SizeConst = (int)MessageBoxColorType.Max)]
				public MessageBoxColor[] colors;
		}

		[StructLayout(LayoutKind.Sequential)]
		private struct INTERNAL_MessageBoxData
		{
			public MessageBoxFlags Flags;
			public IntPtr Window;				/* Parent window, can be NULL */
			public IntPtr Title;				/* UTF-8 title */
			public IntPtr Message;				/* UTF-8 message text */
			public int Numbuttons;
			public IntPtr Buttons;
			public IntPtr ColorScheme;			/* Can be NULL to use system settings */
		}

		[StructLayout(LayoutKind.Sequential)]
		public struct MessageBoxData
		{
			public MessageBoxFlags Flags;
			public IntPtr Window;				/* Parent window, can be NULL */
			public string Title;				/* UTF-8 title */
			public string Message;				/* UTF-8 message text */
			public int Numbuttons;
			public MessageBoxButtonData[] Buttons;
			public MessageBoxColorScheme? ColorScheme;	/* Can be NULL to use system settings */
		}

		[DllImport(nativeLibName, EntryPoint = "SDL_ShowMessageBox", CallingConvention = CallingConvention.Cdecl)]
		private static extern int INTERNAL_ShowMessageBox(in INTERNAL_MessageBoxData messageboxdata, out int buttonid);

		/* Ripped from Jameson's LpUtf8StrMarshaler */
		private static IntPtr INTERNAL_AllocUTF8(string str)
		{
			if (string.IsNullOrEmpty(str))
			{
				return IntPtr.Zero;
			}
			byte[] bytes = System.Text.Encoding.UTF8.GetBytes(str + '\0');
			IntPtr mem = SDL.malloc((IntPtr) bytes.Length);
			Marshal.Copy(bytes, 0, mem, bytes.Length);
			return mem;
		}

		public static unsafe int ShowMessageBox(in MessageBoxData messageboxdata, out int buttonid)
		{
			var data = new INTERNAL_MessageBoxData()
			{
				Flags = messageboxdata.Flags,
				Window = messageboxdata.Window,
				Title = INTERNAL_AllocUTF8(messageboxdata.Title),
				Message = INTERNAL_AllocUTF8(messageboxdata.Message),
				Numbuttons = messageboxdata.Numbuttons,
			};

			var buttons = new INTERNAL_MessageBoxButtonData[messageboxdata.Numbuttons];
			for (int i = 0; i < messageboxdata.Numbuttons; i++)
			{
				buttons[i] = new INTERNAL_MessageBoxButtonData()
				{
					Flags = messageboxdata.Buttons[i].Flags,
					ButtonId = messageboxdata.Buttons[i].ButtonId,
					Text = INTERNAL_AllocUTF8(messageboxdata.Buttons[i].Text),
				};
			}

			if (messageboxdata.ColorScheme != null)
			{
				data.ColorScheme = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(MessageBoxColorScheme)));
				Marshal.StructureToPtr(messageboxdata.ColorScheme.Value, data.ColorScheme, false);
			}

			int result;
			fixed (INTERNAL_MessageBoxButtonData* buttonsPtr = &buttons[0])
			{
				data.Buttons = (IntPtr)buttonsPtr;
				result = INTERNAL_ShowMessageBox(in data, out buttonid);
			}

			Marshal.FreeHGlobal(data.ColorScheme);
			for (int i = 0; i < messageboxdata.Numbuttons; i++)
			{
				free(buttons[i].Text);
			}
			free(data.Message);
			free(data.Title);

			return result;
		}

		/* window refers to an Window* */
		[DllImport(nativeLibName, EntryPoint = "SDL_ShowSimpleMessageBox", CallingConvention = CallingConvention.Cdecl)]
		private static extern int INTERNAL_ShowSimpleMessageBox(
			MessageBoxFlags flags,
			byte[] title,
			byte[] message,
			IntPtr window
		);
		public static int ShowSimpleMessageBox(
			MessageBoxFlags flags,
			string title,
			string message,
			IntPtr window
		) {
			return INTERNAL_ShowSimpleMessageBox(
				flags,
				UTF8_ToNative(title),
				UTF8_ToNative(message),
				window
			);
		}

		#endregion
    }
}
