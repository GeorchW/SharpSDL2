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


		#region audio.h

		public const ushort AUDIO_MASK_BITSIZE =	0xFF;
		public const ushort AUDIO_MASK_DATATYPE =	(1 << 8);
		public const ushort AUDIO_MASK_ENDIAN =	(1 << 12);
		public const ushort AUDIO_MASK_SIGNED =	(1 << 15);

		public static ushort AUDIO_BITSIZE(ushort x)
		{
			return (ushort) (x & AUDIO_MASK_BITSIZE);
		}

		public static bool AUDIO_ISFLOAT(ushort x)
		{
			return (x & AUDIO_MASK_DATATYPE) != 0;
		}

		public static bool AUDIO_ISBIGENDIAN(ushort x)
		{
			return (x & AUDIO_MASK_ENDIAN) != 0;
		}

		public static bool AUDIO_ISSIGNED(ushort x)
		{
			return (x & AUDIO_MASK_SIGNED) != 0;
		}

		public static bool AUDIO_ISINT(ushort x)
		{
			return (x & AUDIO_MASK_DATATYPE) == 0;
		}

		public static bool AUDIO_ISLITTLEENDIAN(ushort x)
		{
			return (x & AUDIO_MASK_ENDIAN) == 0;
		}

		public static bool AUDIO_ISUNSIGNED(ushort x)
		{
			return (x & AUDIO_MASK_SIGNED) == 0;
		}

		public const ushort AUDIO_U8 =		0x0008;
		public const ushort AUDIO_S8 =		0x8008;
		public const ushort AUDIO_U16LSB =	0x0010;
		public const ushort AUDIO_S16LSB =	0x8010;
		public const ushort AUDIO_U16MSB =	0x1010;
		public const ushort AUDIO_S16MSB =	0x9010;
		public const ushort AUDIO_U16 =		AUDIO_U16LSB;
		public const ushort AUDIO_S16 =		AUDIO_S16LSB;
		public const ushort AUDIO_S32LSB =	0x8020;
		public const ushort AUDIO_S32MSB =	0x9020;
		public const ushort AUDIO_S32 =		AUDIO_S32LSB;
		public const ushort AUDIO_F32LSB =	0x8120;
		public const ushort AUDIO_F32MSB =	0x9120;
		public const ushort AUDIO_F32 =		AUDIO_F32LSB;

		public static readonly ushort AUDIO_U16SYS =
			BitConverter.IsLittleEndian ? AUDIO_U16LSB : AUDIO_U16MSB;
		public static readonly ushort AUDIO_S16SYS =
			BitConverter.IsLittleEndian ? AUDIO_S16LSB : AUDIO_S16MSB;
		public static readonly ushort AUDIO_S32SYS =
			BitConverter.IsLittleEndian ? AUDIO_S32LSB : AUDIO_S32MSB;
		public static readonly ushort AUDIO_F32SYS =
			BitConverter.IsLittleEndian ? AUDIO_F32LSB : AUDIO_F32MSB;

		public const uint AUDIO_ALLOW_FREQUENCY_CHANGE =	0x00000001;
		public const uint AUDIO_ALLOW_FORMAT_CHANGE =	0x00000002;
		public const uint AUDIO_ALLOW_CHANNELS_CHANGE =	0x00000004;
		public const uint AUDIO_ALLOW_SAMPLES_CHANGE =	0x00000008;
		public const uint AUDIO_ALLOW_ANY_CHANGE = (
			AUDIO_ALLOW_FREQUENCY_CHANGE |
			AUDIO_ALLOW_FORMAT_CHANGE |
			AUDIO_ALLOW_CHANNELS_CHANGE |
			AUDIO_ALLOW_SAMPLES_CHANGE
		);

		public const int MIX_MAXVOLUME = 128;

		public enum AudioStatus
		{
			AUDIO_STOPPED,
			AUDIO_PLAYING,
			AUDIO_PAUSED
		}

		[StructLayout(LayoutKind.Sequential)]
		public struct AudioSpec
		{
			public int freq;
			public ushort format; // AudioFormat
			public byte channels;
			public byte silence;
			public ushort samples;
			public uint size;
			public AudioCallback callback;
			public IntPtr userdata; // void*
		}

		/* userdata refers to a void*, stream to a Uint8 */
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void AudioCallback(
			IntPtr userdata,
			IntPtr stream,
			int len
		);

		[DllImport(nativeLibName, EntryPoint = "SDL_AudioInit", CallingConvention = CallingConvention.Cdecl)]
		private static extern int INTERNAL_AudioInit(
			byte[] driver_name
		);
		public static int AudioInit(string driver_name)
		{
			return INTERNAL_AudioInit(
				UTF8_ToNative(driver_name)
			);
		}

		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint="SDL_AudioQuit")]
		public static extern void AudioQuit();

		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint="SDL_CloseAudio")]
		public static extern void CloseAudio();

		/* dev refers to an AudioDeviceID */
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint="SDL_CloseAudioDevice")]
		public static extern void CloseAudioDevice(uint dev);

		/* audio_buf refers to a malloc()'d buffer from LoadWAV */
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint="SDL_FreeWAV")]
		public static extern void FreeWAV(IntPtr audio_buf);

		[DllImport(nativeLibName, EntryPoint = "SDL_GetAudioDeviceName", CallingConvention = CallingConvention.Cdecl)]
		private static extern IntPtr INTERNAL_GetAudioDeviceName(
			int index,
			int iscapture
		);
		public static string GetAudioDeviceName(
			int index,
			int iscapture
		) {
			return UTF8_ToManaged(
				INTERNAL_GetAudioDeviceName(index, iscapture)
			);
		}

		/* dev refers to an AudioDeviceID */
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint="SDL_GetAudioDeviceStatus")]
		public static extern AudioStatus GetAudioDeviceStatus(
			uint dev
		);

		[DllImport(nativeLibName, EntryPoint = "SDL_GetAudioDriver", CallingConvention = CallingConvention.Cdecl)]
		private static extern IntPtr INTERNAL_GetAudioDriver(int index);
		public static string GetAudioDriver(int index)
		{
			return UTF8_ToManaged(
				INTERNAL_GetAudioDriver(index)
			);
		}

		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint="SDL_GetAudioStatus")]
		public static extern AudioStatus GetAudioStatus();

		[DllImport(nativeLibName, EntryPoint = "SDL_GetCurrentAudioDriver", CallingConvention = CallingConvention.Cdecl)]
		private static extern IntPtr INTERNAL_GetCurrentAudioDriver();
		public static string GetCurrentAudioDriver()
		{
			return UTF8_ToManaged(INTERNAL_GetCurrentAudioDriver());
		}

		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint="SDL_GetNumAudioDevices")]
		public static extern int GetNumAudioDevices(int iscapture);

		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint="SDL_GetNumAudioDrivers")]
		public static extern int GetNumAudioDrivers();

		/* audio_buf will refer to a malloc()'d byte buffer */
		/* THIS IS AN RWops FUNCTION! */
		[DllImport(nativeLibName, EntryPoint = "SDL_LoadWAV_RW", CallingConvention = CallingConvention.Cdecl)]
		private static extern IntPtr INTERNAL_LoadWAV_RW(
			IntPtr src,
			int freesrc,
			ref AudioSpec spec,
			out IntPtr audio_buf,
			out uint audio_len
		);
		public static AudioSpec LoadWAV(
			string file,
			ref AudioSpec spec,
			out IntPtr audio_buf,
			out uint audio_len
		) {
			AudioSpec result;
			IntPtr rwops = RWFromFile(file, "rb");
			IntPtr result_ptr = INTERNAL_LoadWAV_RW(
				rwops,
				1,
				ref spec,
				out audio_buf,
				out audio_len
			);
			result = (AudioSpec) Marshal.PtrToStructure(
				result_ptr,
				typeof(AudioSpec)
			);
			return result;
		}

		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint="SDL_LockAudio")]
		public static extern void LockAudio();

		/* dev refers to an AudioDeviceID */
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint="SDL_LockAudioDevice")]
		public static extern void LockAudioDevice(uint dev);

		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint="SDL_MixAudio")]
		public static extern void MixAudio(
			[Out()] [MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U1, SizeParamIndex = 2)]
				byte[] dst,
			[In()] [MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U1, SizeParamIndex = 2)]
				byte[] src,
			uint len,
			int volume
		);

		/* format refers to an AudioFormat */
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint="SDL_MixAudioFormat")]
		public static extern void MixAudioFormat(
			[Out()] [MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U1, SizeParamIndex = 3)]
				byte[] dst,
			[In()] [MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U1, SizeParamIndex = 3)]
				byte[] src,
			ushort format,
			uint len,
			int volume
		);

		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint="SDL_OpenAudio")]
		public static extern int OpenAudio(
			ref AudioSpec desired,
			out AudioSpec obtained
		);

		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint="SDL_OpenAudio")]
		public static extern int OpenAudio(
			ref AudioSpec desired,
			IntPtr obtained
		);

		/* uint refers to an AudioDeviceID */
		[DllImport(nativeLibName, EntryPoint = "SDL_OpenAudioDevice", CallingConvention = CallingConvention.Cdecl)]
		private static extern uint INTERNAL_OpenAudioDevice(
			byte[] device,
			int iscapture,
			ref AudioSpec desired,
			out AudioSpec obtained,
			int allowed_changes
		);
		public static uint OpenAudioDevice(
			string device,
			int iscapture,
			ref AudioSpec desired,
			out AudioSpec obtained,
			int allowed_changes
		) {
			return INTERNAL_OpenAudioDevice(
				UTF8_ToNative(device),
				iscapture,
				ref desired,
				out obtained,
				allowed_changes
			);
		}

		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint="SDL_PauseAudio")]
		public static extern void PauseAudio(int pause_on);

		/* dev refers to an AudioDeviceID */
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint="SDL_PauseAudioDevice")]
		public static extern void PauseAudioDevice(
			uint dev,
			int pause_on
		);

		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint="SDL_UnlockAudio")]
		public static extern void UnlockAudio();

		/* dev refers to an AudioDeviceID */
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint="SDL_UnlockAudioDevice")]
		public static extern void UnlockAudioDevice(uint dev);

		/* dev refers to an AudioDeviceID, data to a void* */
		/* Only available in 2.0.4 */
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint="SDL_QueueAudio")]
		public static extern int QueueAudio(
			uint dev,
			IntPtr data,
			UInt32 len
		);

		/* dev refers to an AudioDeviceID, data to a void* */
		/* Only available in 2.0.5 */
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint="SDL_DequeueAudio")]
		public static extern uint DequeueAudio(
			uint dev,
			IntPtr data,
			uint len
		);

		/* dev refers to an AudioDeviceID */
		/* Only available in 2.0.4 */
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint="SDL_GetQueuedAudioSize")]
		public static extern UInt32 GetQueuedAudioSize(uint dev);

		/* dev refers to an AudioDeviceID */
		/* Only available in 2.0.4 */
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint="SDL_ClearQueuedAudio")]
		public static extern void ClearQueuedAudio(uint dev);

		/* src_format and dst_format refer to AudioFormats.
		 * IntPtr refers to an AudioStream*.
		 * Only available in 2.0.7
		 */
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint="SDL_NewAudioStream")]
		public static extern IntPtr NewAudioStream(
			ushort src_format,
			byte src_channels,
			int src_rate,
			ushort dst_format,
			byte dst_channels,
			int dst_rate
		);

		/* stream refers to an AudioStream*, buf to a void*.
		 * Only available in 2.0.7
		 */
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint="SDL_AudioStreamPut")]
		public static extern int AudioStreamPut(
			IntPtr stream,
			IntPtr buf,
			int len
		);

		/* stream refers to an AudioStream*, buf to a void*.
		 * Only available in 2.0.7
		 */
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint="SDL_AudioStreamGet")]
		public static extern int AudioStreamGet(
			IntPtr stream,
			IntPtr buf,
			int len
		);

		/* stream refers to an AudioStream*.
		 * Only available in 2.0.7
		 */
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint="SDL_AudioStreamAvailable")]
		public static extern int AudioStreamAvailable(IntPtr stream);

		/* stream refers to an AudioStream*.
		 * Only available in 2.0.7
		 */
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint="SDL_AudioStreamClear")]
		public static extern void AudioStreamClear(IntPtr stream);

		/* stream refers to an AudioStream*.
		 * Only available in 2.0.7
		 */
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint="SDL_FreeAudioStream")]
		public static extern void FreeAudioStream(IntPtr stream);

		#endregion
    }
}
