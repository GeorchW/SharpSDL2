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
using System.Text;

#endregion

namespace SDL2
{
	public static class Mixer
	{
		#region SDL2# Variables

		/* Used by DllImport to load the native library. */
		private const string nativeLibName = "SDL2_mixer";

		#endregion

		#region SDL_mixer.h

		/* Similar to the headers, this is the version we're expecting to be
		 * running with. You will likely want to check this somewhere in your
		 * program!
		 */
		public const int MajorVersion =	2;
		public const int MinorVersion =	0;
        public const int PatchLevel   = 2;

		/* In C, you can redefine this value before including SDL_mixer.h.
		 * We're not going to allow this in SDL2#, since the value of this
		 * variable is persistent and not dependent on preprocessor ordering.
		 */
		public const int Channels = 8;

		public static readonly int DefaultFrequency = 22050;
		public static readonly ushort DefaultFormat =
			BitConverter.IsLittleEndian ? SDL.AUDIO_S16LSB : SDL.AUDIO_S16MSB;
		public static readonly int DefaultChannels = 2;
		public static readonly byte MaxVolume = 128;

		[Flags]
		public enum InitFlags
		{
			Flac =		0x00000001,
			Mod =		0x00000002,
			Mp3 =		0x00000008,
			Ogg =		0x00000010,
			Mid =		0x00000020,
		}

		public enum Fading
		{
			None,
			Out,
			In
		}

		public enum MusicType
		{
			None,
			Cmd,
			Wav,
			Mod,
			Mid,
			Ogg,
			Mp3,
			Mp3Mad,
			Flac,
			ModPlug
		}

		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void FuncDelegate(
			IntPtr udata, // void*
			IntPtr stream, // Uint8*
			int len
		);

		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void EffectFunction(
			int chan,
			IntPtr stream, // void*
			int len,
			IntPtr udata // void*
		);

		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void EffectDone(
			int chan,
			IntPtr udata // void*
		);

		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void MusicFinishedDelegate();

		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void ChannelFinishedDelegate(int channel);

		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate int SoundFontDelegate(
			IntPtr a, // const char*
			IntPtr b // void*
		);

		public static void MixerVersion(out Version version)
		{
			version.Major = MajorVersion;
			version.Minor = MinorVersion;
			version.Patch = PatchLevel;
		}

		[DllImport(nativeLibName, EntryPoint = "MIX_Linked_Version", CallingConvention = CallingConvention.Cdecl)]
		private static extern IntPtr INTERNAL_MIX_Linked_Version();
		public static Version MIX_Linked_Version()
		{
            IntPtr resultPointer = INTERNAL_MIX_Linked_Version();
			var result = (Version) Marshal.PtrToStructure(
                resultPointer,
                typeof(Version)
            );
			return result;
		}

		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "Mix_Init")]
		public static extern int Init(InitFlags flags);

		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "Mix_Quit")]
		public static extern void Quit();

		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "Mix_OpenAudio")]
		public static extern int OpenAudio(
			int frequency,
			ushort format,
			int channels,
			int chunkSize
		);

		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "Mix_AllocateChannels")]
		public static extern int AllocateChannels(int numberOfChannels);

		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "Mix_QuerySpec")]
		public static extern int QuerySpec(
			out int frequency,
			out ushort format,
			out int channels
		);

		/* src refers to an SDL_RWops*, IntPtr to a Mix_Chunk* */
		/* THIS IS A PUBLIC RWops FUNCTION! */
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "Mix_LoadWAV_RW")]
		public static extern IntPtr LoadWavRw(
			IntPtr src,
			int freeSrc
		);
		
		/* IntPtr refers to a Mix_Chunk* */
		/* This is an RWops macro in the C header. */
		public static IntPtr LoadWav(string file)
		{
			IntPtr rwops = SDL.RWFromFile(file, "rb");
			return LoadWavRw(rwops, 1);
		}

		/* IntPtr refers to a Mix_Music* */
		[DllImport(nativeLibName, EntryPoint = "Mix_LoadMUS", CallingConvention = CallingConvention.Cdecl)]
		private static extern IntPtr INTERNAL_Mix_LoadMUS(
			byte[] file
		);
		public static IntPtr LoadMusic(string file)
		{
			return INTERNAL_Mix_LoadMUS(SDL.UTF8_ToNative(file));
		}

		/* IntPtr refers to a Mix_Chunk* */
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "Mix_QuickLoad_WAV")]
		public static extern IntPtr QuickLoadWav(
			[In] [MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U1)]
				byte[] mem
		);

		/* IntPtr refers to a Mix_Chunk* */
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "Mix_QuickLoad_RAW")]
		public static extern IntPtr QuickLoadRaw(
			[In] [MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U1, SizeParamIndex = 1)]
				byte[] mem,
			uint len
		);

		/* chunk refers to a Mix_Chunk* */
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "Mix_FreeChunk")]
		public static extern void FreeChunk(IntPtr chunk);

		/* music refers to a Mix_Music* */
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "Mix_FreeMusic")]
		public static extern void FreeMusic(IntPtr music);

		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "Mix_GetNumChunkDecoders")]
		public static extern int GetNumChunkDecoders();

		[DllImport(nativeLibName, EntryPoint = "Mix_GetChunkDecoder", CallingConvention = CallingConvention.Cdecl)]
		private static extern IntPtr INTERNAL_Mix_GetChunkDecoder(int index);
		public static string GetChunkDecoder(int index)
		{
			return SDL.UTF8_ToManaged(
				INTERNAL_Mix_GetChunkDecoder(index)
			);
		}

		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "Mix_GetNumMusicDecoders")]
		public static extern int Mix_GetNumMusicDecoders();

		[DllImport(nativeLibName, EntryPoint = "Mix_GetMusicDecoder", CallingConvention = CallingConvention.Cdecl)]
		private static extern IntPtr INTERNAL_Mix_GetMusicDecoder(int index);
		public static string GetMusicDecoder(int index)
		{
			return SDL.UTF8_ToManaged(
				INTERNAL_Mix_GetMusicDecoder(index)
			);
		}

		/* music refers to a Mix_Music* */
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "Mix_GetMusicType")]
		public static extern MusicType GetMusicType(IntPtr music);

		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "Mix_SetPostMix")]
		public static extern void SetPostMix(
			FuncDelegate function,
			IntPtr arg // void*
		);

		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "Mix_HookMusic")]
		public static extern void HookMusic(
			FuncDelegate function,
			IntPtr arg // void*
		);

		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "Mix_HookMusicFinished")]
		public static extern void HookMusicFinished(
			MusicFinishedDelegate musicFinished
		);

		/* IntPtr refers to a void* */
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "Mix_GetMusicHookData")]
		public static extern IntPtr GetMusicHookData();

		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "Mix_ChannelFinished")]
		public static extern void ChannelFinished(
			ChannelFinishedDelegate channelFinished
		);

		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "Mix_RegisterEffect")]
		public static extern int RegisterEffect(
			int chan,
			EffectFunction f,
			EffectDone d,
			IntPtr arg // void*
		);

		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "Mix_UnregisterEffect")]
		public static extern int UnregisterEffect(
			int channel,
			EffectFunction f
		);

		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "Mix_UnregisterAllEffects")]
		public static extern int UnregisterAllEffects(int channel);

		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "Mix_SetPanning")]
		public static extern int SetPanning(
			int channel,
			byte left,
			byte right
		);

		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "Mix_SetPosition")]
		public static extern int SetPosition(
			int channel,
			short angle,
			byte distance
		);

		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "Mix_SetDistance")]
		public static extern int SetDistance(int channel, byte distance);

		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "Mix_SetReverseStereo")]
		public static extern int SetReverseStereo(int channel, int flip);

		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "Mix_ReserveChannels")]
		public static extern int ReserveChannels(int num);

		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "Mix_GroupChannel")]
		public static extern int GroupChannel(int which, int tag);

		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "Mix_GroupChannels")]
		public static extern int GroupChannels(int from, int to, int tag);

		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "Mix_GroupAvailable")]
		public static extern int GroupAvailable(int tag);

		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "Mix_GroupCount")]
		public static extern int GroupCount(int tag);

		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "Mix_GroupOldest")]
		public static extern int GroupOldest(int tag);

		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "Mix_GroupNewer")]
		public static extern int GroupNewer(int tag);

		/* chunk refers to a Mix_Chunk* */
		public static int PlayChannel(
			int channel,
			IntPtr chunk,
			int loops
		) {
			return PlayChannelTimed(channel, chunk, loops, -1);
		}

		/* chunk refers to a Mix_Chunk* */
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "Mix_PlayChannelTimed")]
		public static extern int PlayChannelTimed(
			int channel,
			IntPtr chunk,
			int loops,
			int ticks
		);

		/* music refers to a Mix_Music* */
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "Mix_PlayMusic")]
		public static extern int PlayMusic(IntPtr music, int loops);

		/* music refers to a Mix_Music* */
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "Mix_FadeInMusic")]
		public static extern int FadeInMusic(
			IntPtr music,
			int loops,
			int ms
		);

		/* music refers to a Mix_Music* */
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "Mix_FadeInMusicPos")]
		public static extern int FadeInMusicPos(
			IntPtr music,
			int loops,
			int ms,
			double position
		);

		/* chunk refers to a Mix_Chunk* */
		public static int FadeInChannel(
			int channel,
			IntPtr chunk,
			int loops,
			int ms
		) {
			return FadeInChannelTimed(channel, chunk, loops, ms, -1);
		}

		/* chunk refers to a Mix_Chunk* */
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "Mix_FadeInChannelTimed")]
		public static extern int FadeInChannelTimed(
			int channel,
			IntPtr chunk,
			int loops,
			int ms,
			int ticks
		);

		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "Mix_Volume")]
		public static extern int Volume(int channel, int volume);

		/* chunk refers to a Mix_Chunk* */
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "Mix_VolumeChunk")]
		public static extern int VolumeChunk(
			IntPtr chunk,
			int volume
		);

		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "Mix_VolumeMusic")]
		public static extern int VolumeMusic(int volume);

		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "Mix_HaltChannel")]
		public static extern int HaltChannel(int channel);

		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "Mix_HaltGroup")]
		public static extern int HaltGroup(int tag);

		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "Mix_HaltMusic")]
		public static extern int HaltMusic();

		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "Mix_ExpireChannel")]
		public static extern int ExpireChannel(int channel, int ticks);

		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "Mix_FadeOutChannel")]
		public static extern int FadeOutChannel(int which, int ms);

		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "Mix_FadeOutGroup")]
		public static extern int FadeOutGroup(int tag, int ms);

		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "Mix_FadeOutMusic")]
		public static extern int FadeOutMusic(int ms);

		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "Mix_FadingMusic")]
		public static extern Fading FadingMusic();

		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "Mix_FadingChannel")]
		public static extern Fading FadingChannel(int which);

		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "Mix_Pause")]
		public static extern void Pause(int channel);

		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "Mix_Resume")]
		public static extern void Resume(int channel);

		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "Mix_Paused")]
		public static extern int Paused(int channel);

		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "Mix_PauseMusic")]
		public static extern void PauseMusic();

		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "Mix_ResumeMusic")]
		public static extern void ResumeMusic();

		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "Mix_RewindMusic")]
		public static extern void RewindMusic();

		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "Mix_PausedMusic")]
		public static extern int PausedMusic();

		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "Mix_SetMusicPosition")]
		public static extern int SetMusicPosition(double position);

		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "Mix_Playing")]
		public static extern int Playing(int channel);

		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "Mix_PlayingMusic")]
		public static extern int PlayingMusic();

		[DllImport(nativeLibName, EntryPoint = "Mix_SetMusicCMD", CallingConvention = CallingConvention.Cdecl)]
		private static extern int INTERNAL_Mix_SetMusicCMD(
			byte[] command
		);
		public static int SetMusicCommand(string command)
		{
			return INTERNAL_Mix_SetMusicCMD(
				SDL.UTF8_ToNative(command)
			);
		}

		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "Mix_SetSynchroValue")]
		public static extern int SetSynchroValue(int value);

		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "Mix_GetSynchroValue")]
		public static extern int GetSynchroValue();

		[DllImport(nativeLibName, EntryPoint = "Mix_SetSoundFonts", CallingConvention = CallingConvention.Cdecl)]
		private static extern int INTERNAL_Mix_SetSoundFonts(
			byte[] paths
		);
		public static int SetSoundFonts(string paths)
		{
			return INTERNAL_Mix_SetSoundFonts(
				SDL.UTF8_ToNative(paths)
			);
		}

		[DllImport(nativeLibName, EntryPoint = "Mix_GetSoundFonts", CallingConvention = CallingConvention.Cdecl)]
		private static extern IntPtr INTERNAL_Mix_GetSoundFonts();
		public static string GetSoundFonts()
		{
			return SDL.UTF8_ToManaged(INTERNAL_Mix_GetSoundFonts());
		}

		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "Mix_EachSoundFont")]
		public static extern int EachSoundFont(
			SoundFontDelegate function,
			IntPtr data // void*
		);

		/* IntPtr refers to a Mix_Chunk* */
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "Mix_GetChunk")]
		public static extern IntPtr GetChunk(int channel);

		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "Mix_CloseAudio")]
		public static extern void CloseAudio();

		#endregion
	}
}
