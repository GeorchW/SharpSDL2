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
    #region audio.h
    public enum AudioStatus
    {
        Stopped,
        Playing,
        Paused
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct AudioSpec
    {
        public int Frequency;
        public ushort Format; // AudioFormat
        public byte Channels;
        public byte Silence;
        public ushort Samples;
        public uint Size;
        public AudioCallback Callback;
        public IntPtr Userdata; // void*
    }

    /* userdata refers to a void*, stream to a Uint8 */
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void AudioCallback(
        IntPtr userdata,
        IntPtr stream,
        int len
    );
    public static partial class SDL
    {
        public const ushort AUDIO_MASK_BITSIZE = 0xFF;
        public const ushort AUDIO_MASK_DATATYPE = (1 << 8);
        public const ushort AUDIO_MASK_ENDIAN = (1 << 12);
        public const ushort AUDIO_MASK_SIGNED = (1 << 15);

        public static ushort AUDIO_BITSIZE(ushort x)
        {
            return (ushort)(x & AUDIO_MASK_BITSIZE);
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

        public const ushort AUDIO_U8 = 0x0008;
        public const ushort AUDIO_S8 = 0x8008;
        public const ushort AUDIO_U16LSB = 0x0010;
        public const ushort AUDIO_S16LSB = 0x8010;
        public const ushort AUDIO_U16MSB = 0x1010;
        public const ushort AUDIO_S16MSB = 0x9010;
        public const ushort AUDIO_U16 = AUDIO_U16LSB;
        public const ushort AUDIO_S16 = AUDIO_S16LSB;
        public const ushort AUDIO_S32LSB = 0x8020;
        public const ushort AUDIO_S32MSB = 0x9020;
        public const ushort AUDIO_S32 = AUDIO_S32LSB;
        public const ushort AUDIO_F32LSB = 0x8120;
        public const ushort AUDIO_F32MSB = 0x9120;
        public const ushort AUDIO_F32 = AUDIO_F32LSB;

        public static readonly ushort AUDIO_U16SYS =
            BitConverter.IsLittleEndian ? AUDIO_U16LSB : AUDIO_U16MSB;
        public static readonly ushort AUDIO_S16SYS =
            BitConverter.IsLittleEndian ? AUDIO_S16LSB : AUDIO_S16MSB;
        public static readonly ushort AUDIO_S32SYS =
            BitConverter.IsLittleEndian ? AUDIO_S32LSB : AUDIO_S32MSB;
        public static readonly ushort AUDIO_F32SYS =
            BitConverter.IsLittleEndian ? AUDIO_F32LSB : AUDIO_F32MSB;

        public const uint AUDIO_ALLOW_FREQUENCY_CHANGE = 0x00000001;
        public const uint AUDIO_ALLOW_FORMAT_CHANGE = 0x00000002;
        public const uint AUDIO_ALLOW_CHANNELS_CHANGE = 0x00000004;
        public const uint AUDIO_ALLOW_SAMPLES_CHANGE = 0x00000008;
        public const uint AUDIO_ALLOW_ANY_CHANGE = (
            AUDIO_ALLOW_FREQUENCY_CHANGE |
            AUDIO_ALLOW_FORMAT_CHANGE |
            AUDIO_ALLOW_CHANNELS_CHANGE |
            AUDIO_ALLOW_SAMPLES_CHANGE
        );

        public const int MIX_MAXVOLUME = 128;

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

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_AudioQuit")]
        public static extern void AudioQuit();

        /// <summary>This function shuts down audio processing and closes the audio device.</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_CloseAudio")]
        public static extern void CloseAudio();

        /* dev refers to an AudioDeviceID */
        /// <summary>
        /// 
        /// 
        /// Binding info:
        /// dev refers to an AudioDeviceID
        /// </summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_CloseAudioDevice")]
        public static extern void CloseAudioDevice(uint dev);

        /* audio_buf refers to a malloc()'d buffer from LoadWAV */
        /// <summary>
        /// This function frees data previously allocated with
        /// 
        /// Binding info:
        /// audio_buf refers to a malloc()'d buffer from LoadWAV
        /// </summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_FreeWAV")]
        public static extern void FreeWAV(IntPtr audio_buf);

        /// <summary>Get the human-readable name of a specific audio device. Must be a value between 0 and (number of audio devices-1). Only valid after a successfully initializing the audio subsystem. The values returned by this function reflect the latest call to ; recall that function to redetect available hardware.The string returned by this function is UTF-8 encoded, read-only, and managed internally. You are not to free it. If you need to keep the string for any length of time, you should make your own copy of it, as it will be invalid next time any of several other SDL functions is called.</summary>
        [DllImport(nativeLibName, EntryPoint = "SDL_GetAudioDeviceName", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr INTERNAL_GetAudioDeviceName(
            int index,
            int iscapture
        );
        public static string GetAudioDeviceName(
            int index,
            int iscapture
        )
        {
            return UTF8_ToManaged(
                INTERNAL_GetAudioDeviceName(index, iscapture)
            );
        }

        /* dev refers to an AudioDeviceID */
        /// <summary>
        /// 
        /// 
        /// Binding info:
        /// dev refers to an AudioDeviceID
        /// </summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetAudioDeviceStatus")]
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

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetAudioStatus")]
        public static extern AudioStatus GetAudioStatus();

        /// <summary>This function returns the name of the current audio driver, or NULL if no driver has been initialized.</summary>
        [DllImport(nativeLibName, EntryPoint = "SDL_GetCurrentAudioDriver", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr INTERNAL_GetCurrentAudioDriver();
        public static string GetCurrentAudioDriver()
        {
            return UTF8_ToManaged(INTERNAL_GetCurrentAudioDriver());
        }

        /// <summary>Get the number of available devices exposed by the current driver. Only valid after a successfully initializing the audio subsystem. Returns -1 if an explicit list of devices can't be determined; this is not an error. For example, if SDL is set up to talk to a remote audio server, it can't list every one available on the Internet, but it will still allow a specific host to be specified to .In many common cases, when this function returns a value <= 0, it can still successfully open the default device (NULL for first argument of ).</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetNumAudioDevices")]
        public static extern int GetNumAudioDevices(int iscapture);

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetNumAudioDrivers")]
        public static extern int GetNumAudioDrivers();

        /* audio_buf will refer to a malloc()'d byte buffer */
        /* THIS IS AN RWops FUNCTION! */
        /// <summary>
        /// Load the audio data of a WAVE file into memory. 
        /// Loading a WAVE file requires , ,  and  to be valid pointers. The entire data portion of the file is then loaded into memory and decoded if necessary.If  is non-zero, the data source gets automatically closed and freed before the function returns.Supported are RIFF WAVE files with the formats PCM (8, 16, 24, and 32 bits), IEEE Float (32 bits), Microsoft ADPCM and IMA ADPCM (4 bits), and A-law and µ-law (8 bits). Other formats are currently unsupported and cause an error.If this function succeeds, the pointer returned by it is equal to  and the pointer to the audio data allocated by the function is written to  and its length in bytes to . The  members , , and  are set to the values of the audio data in the buffer. The  member is set to a sane default and all others are set to zero.It's necessary to use  to free the audio data returned in  when it is no longer used.Because of the underspecification of the Waveform format, there are many problematic files in the wild that cause issues with strict decoders. To provide compatibility with these files, this decoder is lenient in regards to the truncation of the file, the fact chunk, and the size of the RIFF chunk. The hints SDL_HINT_WAVE_RIFF_CHUNK_SIZE, SDL_HINT_WAVE_TRUNCATION, and SDL_HINT_WAVE_FACT_CHUNK can be used to tune the behavior of the loading process.Any file that is invalid (due to truncation, corruption, or wrong values in the headers), too big, or unsupported causes an error. Additionally, any critical I/O error from the data source will terminate the loading process with an error. The function returns NULL on error and in all cases (with the exception of  being NULL), an appropriate error message will be set.It is required that the data source supports seeking.Example:
        /// 
        /// Binding info:
        /// THIS IS AN RWops FUNCTION!
        /// </summary>
        /// <param name="src">The data source with the WAVE data</param>
        /// <param name="freesrc">A integer value that makes the function close the data source if non-zero</param>
        /// <param name="spec">A pointer filled with the audio format of the audio data</param>
        /// <param name="audio_buf">A pointer filled with the audio data allocated by the function</param>
        /// <param name="audio_len">A pointer filled with the length of the audio data buffer in bytes</param>
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
        )
        {
            AudioSpec result;
            IntPtr rwops = RWFromFile(file, "rb");
            IntPtr result_ptr = INTERNAL_LoadWAV_RW(
                rwops,
                1,
                ref spec,
                out audio_buf,
                out audio_len
            );
            result = (AudioSpec)Marshal.PtrToStructure(
                result_ptr,
                typeof(AudioSpec)
            );
            return result;
        }

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_LockAudio")]
        public static extern void LockAudio();

        /* dev refers to an AudioDeviceID */
        /// <summary>
        /// 
        /// 
        /// Binding info:
        /// dev refers to an AudioDeviceID
        /// </summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_LockAudioDevice")]
        public static extern void LockAudioDevice(uint dev);

        /// <summary>This takes two audio buffers of the playing audio format and mixes them, performing addition, volume adjustment, and overflow clipping. The volume ranges from 0 - 128, and should be set to  for full audio volume. Note this does not change hardware volume. This is provided for convenience  you can mix your own audio data.</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_MixAudio")]
        public static extern void MixAudio(
            [Out()] [MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U1, SizeParamIndex = 2)]
                byte[] dst,
            [In()] [MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U1, SizeParamIndex = 2)]
                byte[] src,
            uint len,
            int volume
        );

        /* format refers to an AudioFormat */
        /// <summary>
        /// This works like , but you specify the audio format instead of using the format of audio device 1. Thus it can be used when no audio device is open at all.
        /// 
        /// Binding info:
        /// format refers to an AudioFormat
        /// </summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_MixAudioFormat")]
        public static extern void MixAudioFormat(
            [Out()] [MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U1, SizeParamIndex = 3)]
                byte[] dst,
            [In()] [MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U1, SizeParamIndex = 3)]
                byte[] src,
            ushort format,
            uint len,
            int volume
        );

        /// <summary>
        /// This function opens the audio device with the desired parameters, and returns 0 if successful, placing the actual hardware parameters in the structure pointed to by . If  is NULL, the audio data passed to the callback function will be guaranteed to be in the requested format, and will be automatically converted to the hardware audio format if necessary. This function returns -1 if it failed to open the audio device, or couldn't set up the audio thread.When filling in the desired audio spec structure,
        /// The audio device starts out playing silence when it's opened, and should be enabled for playing by calling  when you are ready for your audio callback function to be called. Since the audio driver may modify the requested size of the audio buffer, you should allocate any local mixing buffers after you open the audio device.
        /// </summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_OpenAudio")]
        public static extern int OpenAudio(
            ref AudioSpec desired,
            out AudioSpec obtained
        );

        /// <summary>
        /// This function opens the audio device with the desired parameters, and returns 0 if successful, placing the actual hardware parameters in the structure pointed to by . If  is NULL, the audio data passed to the callback function will be guaranteed to be in the requested format, and will be automatically converted to the hardware audio format if necessary. This function returns -1 if it failed to open the audio device, or couldn't set up the audio thread.When filling in the desired audio spec structure,
        /// The audio device starts out playing silence when it's opened, and should be enabled for playing by calling  when you are ready for your audio callback function to be called. Since the audio driver may modify the requested size of the audio buffer, you should allocate any local mixing buffers after you open the audio device.
        /// </summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_OpenAudio")]
        public static extern int OpenAudio(
            ref AudioSpec desired,
            IntPtr obtained
        );

        /* uint refers to an AudioDeviceID */
        /// <summary>
        /// Open a specific audio device. Passing in a device name of NULL requests the most reasonable default (and is equivalent to calling ).The device name is a UTF-8 string reported by , but some drivers allow arbitrary and driver-specific strings, such as a hostname/IP address for a remote audio server, or a filename in the diskaudio driver.
        /// , unlike this function, always acts on device ID 1.
        /// 
        /// Binding info:
        /// uint refers to an AudioDeviceID
        /// </summary>
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
        )
        {
            return INTERNAL_OpenAudioDevice(
                UTF8_ToNative(device),
                iscapture,
                ref desired,
                out obtained,
                allowed_changes
            );
        }

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_PauseAudio")]
        public static extern void PauseAudio(int pause_on);

        /* dev refers to an AudioDeviceID */
        /// <summary>
        /// 
        /// 
        /// Binding info:
        /// dev refers to an AudioDeviceID
        /// </summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_PauseAudioDevice")]
        public static extern void PauseAudioDevice(
            uint dev,
            int pause_on
        );

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_UnlockAudio")]
        public static extern void UnlockAudio();

        /* dev refers to an AudioDeviceID */
        /// <summary>
        /// 
        /// 
        /// Binding info:
        /// dev refers to an AudioDeviceID
        /// </summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_UnlockAudioDevice")]
        public static extern void UnlockAudioDevice(uint dev);

        /* dev refers to an AudioDeviceID, data to a void* */
        /* Only available in 2.0.4 */
        /// <summary>
        /// Queue more audio on non-callback devices.(If you are looking to retrieve queued audio from a non-callback capture device, you want  instead. This will return -1 to signify an error if you use it with capture devices.)SDL offers two ways to feed audio to the device: you can either supply a callback that SDL triggers with some frequency to obtain more audio (pull method), or you can supply no callback, and then SDL will expect you to supply data at regular intervals (push method) with this function.There are no limits on the amount of data you can queue, short of exhaustion of address space. Queued data will drain to the device as necessary without further intervention from you. If the device needs audio but there is not enough queued, it will play silence to make up the difference. This means you will have skips in your audio playback if you aren't routinely queueing sufficient data.This function copies the supplied data, so you are safe to free it when the function returns. This function is thread-safe, but queueing to the same device from two threads at once does not promise which buffer will be queued first.You may not queue audio on a device that is using an application-supplied callback; doing so returns an error. You have to use the audio callback or queue audio with this function, but not both.You should not call  on the device before queueing; SDL handles locking internally for this function.
        /// 
        /// Binding info:
        /// Only available in 2.0.4
        /// </summary>
        /// <param name="dev">The device ID to which we will queue audio.</param>
        /// <param name="data">The data to queue to the device for later playback.</param>
        /// <param name="len">The number of bytes (not samples!) to which (data) points.</param>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_QueueAudio")]
        public static extern int QueueAudio(
            uint dev,
            IntPtr data,
            uint len
        );

        /* dev refers to an AudioDeviceID, data to a void* */
        /* Only available in 2.0.5 */
        /// <summary>
        /// Dequeue more audio on non-callback devices.(If you are looking to queue audio for output on a non-callback playback device, you want  instead. This will always return 0 if you use it with playback devices.)SDL offers two ways to retrieve audio from a capture device: you can either supply a callback that SDL triggers with some frequency as the device records more audio data, (push method), or you can supply no callback, and then SDL will expect you to retrieve data at regular intervals (pull method) with this function.There are no limits on the amount of data you can queue, short of exhaustion of address space. Data from the device will keep queuing as necessary without further intervention from you. This means you will eventually run out of memory if you aren't routinely dequeueing data.Capture devices will not queue data when paused; if you are expecting to not need captured audio for some length of time, use  to stop the capture device from queueing more data. This can be useful during, say, level loading times. When unpaused, capture devices will start queueing data from that point, having flushed any capturable data available while paused.This function is thread-safe, but dequeueing from the same device from two threads at once does not promise which thread will dequeued data first.You may not dequeue audio from a device that is using an application-supplied callback; doing so returns an error. You have to use the audio callback, or dequeue audio with this function, but not both.You should not call  on the device before queueing; SDL handles locking internally for this function.
        /// 
        /// Binding info:
        /// Only available in 2.0.5
        /// </summary>
        /// <param name="dev">The device ID from which we will dequeue audio.</param>
        /// <param name="data">A pointer into where audio data should be copied.</param>
        /// <param name="len">The number of bytes (not samples!) to which (data) points.</param>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_DequeueAudio")]
        public static extern uint DequeueAudio(
            uint dev,
            IntPtr data,
            uint len
        );

        /* dev refers to an AudioDeviceID */
        /* Only available in 2.0.4 */
        /// <summary>
        /// Get the number of bytes of still-queued audio.For playback device:This is the number of bytes that have been queued for playback with , but have not yet been sent to the hardware. This number may shrink at any time, so this only informs of pending data.Once we've sent it to the hardware, this function can not decide the exact byte boundary of what has been played. It's possible that we just gave the hardware several kilobytes right before you called this function, but it hasn't played any of it yet, or maybe half of it, etc.For capture devices:This is the number of bytes that have been captured by the device and are waiting for you to dequeue. This number may grow at any time, so this only informs of the lower-bound of available data.You may not queue audio on a device that is using an application-supplied callback; calling this function on such a device always returns 0. You have to queue audio with /SDL_DequeueAudio(), or use the audio callback, but not both.You should not call  on the device before querying; SDL handles locking internally for this function.
        /// 
        /// Binding info:
        /// Only available in 2.0.4
        /// </summary>
        /// <param name="dev">The device ID of which we will query queued audio size.</param>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetQueuedAudioSize")]
        public static extern uint GetQueuedAudioSize(uint dev);

        /* dev refers to an AudioDeviceID */
        /* Only available in 2.0.4 */
        /// <summary>
        /// Drop any queued audio data. For playback devices, this is any queued data still waiting to be submitted to the hardware. For capture devices, this is any data that was queued by the device that hasn't yet been dequeued by the application.Immediately after this call,  will return 0. For playback devices, the hardware will start playing silence if more audio isn't queued. Unpaused capture devices will start filling the queue again as soon as they have more data available (which, depending on the state of the hardware and the thread, could be before this function call returns!).This will not prevent playback of queued audio that's already been sent to the hardware, as we can not undo that, so expect there to be some fraction of a second of audio that might still be heard. This can be useful if you want to, say, drop any pending music during a level change in your game.You may not queue audio on a device that is using an application-supplied callback; calling this function on such a device is always a no-op. You have to queue audio with /SDL_DequeueAudio(), or use the audio callback, but not both.You should not call  on the device before clearing the queue; SDL handles locking internally for this function.This function always succeeds and thus returns void.
        /// 
        /// Binding info:
        /// Only available in 2.0.4
        /// </summary>
        /// <param name="dev">The device ID of which to clear the audio queue.</param>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_ClearQueuedAudio")]
        public static extern void ClearQueuedAudio(uint dev);

        /* src_format and dst_format refer to AudioFormats.
		 * IntPtr refers to an AudioStream*.
		 * Only available in 2.0.7
		 */
        /// <summary>
        /// Create a new audio stream
        /// 
        /// Binding info:
        /// src_format and dst_format refer to AudioFormats.
        /// IntPtr refers to an AudioStream*.
        /// Only available in 2.0.7
        /// </summary>
        /// <param name="src_format">The format of the source audio</param>
        /// <param name="src_channels">The number of channels of the source audio</param>
        /// <param name="src_rate">The sampling rate of the source audio</param>
        /// <param name="dst_format">The format of the desired audio output</param>
        /// <param name="dst_channels">The number of channels of the desired audio output</param>
        /// <param name="dst_rate">The sampling rate of the desired audio output</param>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_NewAudioStream")]
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
        /// <summary>
        /// Add data to be converted/resampled to the stream
        /// 
        /// Binding info:
        /// stream refers to an AudioStream*, buf to a void*.
        /// Only available in 2.0.7
        /// </summary>
        /// <param name="stream">The stream the audio data is being added to</param>
        /// <param name="buf">A pointer to the audio data to add</param>
        /// <param name="len">The number of bytes to write to the stream</param>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_AudioStreamPut")]
        public static extern int AudioStreamPut(
            IntPtr stream,
            IntPtr buf,
            int len
        );

        /* stream refers to an AudioStream*, buf to a void*.
		 * Only available in 2.0.7
		 */
        /// <summary>
        /// Get converted/resampled data from the stream
        /// 
        /// Binding info:
        /// stream refers to an AudioStream*, buf to a void*.
        /// Only available in 2.0.7
        /// </summary>
        /// <param name="stream">The stream the audio is being requested from</param>
        /// <param name="buf">A buffer to fill with audio data</param>
        /// <param name="len">The maximum number of bytes to fill</param>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_AudioStreamGet")]
        public static extern int AudioStreamGet(
            IntPtr stream,
            IntPtr buf,
            int len
        );

        /* stream refers to an AudioStream*.
		 * Only available in 2.0.7
		 */
        /// <summary>
        /// Get the number of converted/resampled bytes available. The stream may be buffering data behind the scenes until it has enough to resample correctly, so this number might be lower than what you expect, or even be zero. Add more data or flush the stream if you need the data now.
        /// 
        /// Binding info:
        /// stream refers to an AudioStream*.
        /// Only available in 2.0.7
        /// </summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_AudioStreamAvailable")]
        public static extern int AudioStreamAvailable(IntPtr stream);

        /* stream refers to an AudioStream*.
		 * Only available in 2.0.7
		 */
        /// <summary>
        /// Clear any pending data in the stream without converting it
        /// 
        /// Binding info:
        /// stream refers to an AudioStream*.
        /// Only available in 2.0.7
        /// </summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_AudioStreamClear")]
        public static extern void AudioStreamClear(IntPtr stream);

        /* stream refers to an AudioStream*.
		 * Only available in 2.0.7
		 */
        /// <summary>
        /// Free an audio stream
        /// 
        /// Binding info:
        /// stream refers to an AudioStream*.
        /// Only available in 2.0.7
        /// </summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_FreeAudioStream")]
        public static extern void FreeAudioStream(IntPtr stream);
    }
    #endregion
}
