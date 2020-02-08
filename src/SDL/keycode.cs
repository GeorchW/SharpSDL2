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


		#region keycode.h

		public const int SDLK_SCANCODE_MASK = (1 << 30);
		public static Keycode SCANCODE_TO_KEYCODE(Scancode X)
		{
			return (Keycode)((int)X | SDLK_SCANCODE_MASK);
		}

		/* So, in the C headers, Keycode is a typedef of Sint32
		 * and all of the names are in an anonymous enum. Yeah...
		 * that's not going to cut it for C#. We'll just put them in an
		 * enum for now? */
		public enum Keycode
		{
			Unknown = 0,

			Return = '\r',
			Escape = 27, // '\033'
			Backspace = '\b',
			Tab = '\t',
			Space = ' ',
			Exclaim = '!',
			Quotedbl = '"',
			Hash = '#',
			Percent = '%',
			Dollar = '$',
			Ampersand = '&',
			Quote = '\'',
			LeftParen = '(',
			RightParen = ')',
			Asterisk = '*',
			Plus = '+',
			Comma = ',',
			Minus = '-',
			Period = '.',
			Slash = '/',
			D0 = '0',
			D1 = '1',
			D2 = '2',
			D3 = '3',
			D4 = '4',
			D5 = '5',
			D6 = '6',
			D7 = '7',
			D8 = '8',
			D9 = '9',
			Colon = ':',
			Semicolon = ';',
			Less = '<',
			Equals = '=',
			Greater = '>',
			Question = '?',
			At = '@',
			/*
			Skip uppercase letters
			*/
			LeftBracket = '[',
			Backslash = '\\',
			RightBracket = ']',
			Caret = '^',
			Underscore = '_',
			Backquote = '`',
			a = 'a',
			b = 'b',
			c = 'c',
			d = 'd',
			e = 'e',
			f = 'f',
			g = 'g',
			h = 'h',
			i = 'i',
			j = 'j',
			k = 'k',
			l = 'l',
			m = 'm',
			n = 'n',
			o = 'o',
			p = 'p',
			q = 'q',
			r = 'r',
			s = 's',
			t = 't',
			u = 'u',
			v = 'v',
			w = 'w',
			x = 'x',
			y = 'y',
			z = 'z',

			CapsLock = (int)Scancode.CapsLock | SDLK_SCANCODE_MASK,

			F1 = (int)Scancode.F1 | SDLK_SCANCODE_MASK,
			F2 = (int)Scancode.F2 | SDLK_SCANCODE_MASK,
			F3 = (int)Scancode.F3 | SDLK_SCANCODE_MASK,
			F4 = (int)Scancode.F4 | SDLK_SCANCODE_MASK,
			F5 = (int)Scancode.F5 | SDLK_SCANCODE_MASK,
			F6 = (int)Scancode.F6 | SDLK_SCANCODE_MASK,
			F7 = (int)Scancode.F7 | SDLK_SCANCODE_MASK,
			F8 = (int)Scancode.F8 | SDLK_SCANCODE_MASK,
			F9 = (int)Scancode.F9 | SDLK_SCANCODE_MASK,
			F10 = (int)Scancode.F10 | SDLK_SCANCODE_MASK,
			F11 = (int)Scancode.F11 | SDLK_SCANCODE_MASK,
			F12 = (int)Scancode.F12 | SDLK_SCANCODE_MASK,

			PrintScreen = (int)Scancode.PrintScreen | SDLK_SCANCODE_MASK,
			ScrollLock = (int)Scancode.ScrollLock | SDLK_SCANCODE_MASK,
			Pause = (int)Scancode.Pause | SDLK_SCANCODE_MASK,
			Insert = (int)Scancode.Insert | SDLK_SCANCODE_MASK,
			Home = (int)Scancode.Home | SDLK_SCANCODE_MASK,
			PageUp = (int)Scancode.PageUp | SDLK_SCANCODE_MASK,
			Delete = 127,
			End = (int)Scancode.End | SDLK_SCANCODE_MASK,
			PageDown = (int)Scancode.PageDown | SDLK_SCANCODE_MASK,
			Right = (int)Scancode.Right | SDLK_SCANCODE_MASK,
			Left = (int)Scancode.Left | SDLK_SCANCODE_MASK,
			Down = (int)Scancode.Down | SDLK_SCANCODE_MASK,
			Up = (int)Scancode.Up | SDLK_SCANCODE_MASK,

			NumlockClear = (int)Scancode.NumlockClear | SDLK_SCANCODE_MASK,
			KeypadDivide = (int)Scancode.KeypadDivide | SDLK_SCANCODE_MASK,
			KeypadMultiply = (int)Scancode.KeypadMultiply | SDLK_SCANCODE_MASK,
			KeypadMinus = (int)Scancode.KeypadMinus | SDLK_SCANCODE_MASK,
			KeypadPlus = (int)Scancode.KeypadPlus | SDLK_SCANCODE_MASK,
			KeypadEnter = (int)Scancode.KeypadEnter | SDLK_SCANCODE_MASK,
			Keypad1 = (int)Scancode.Keypad1 | SDLK_SCANCODE_MASK,
			Keypad2 = (int)Scancode.Keypad2 | SDLK_SCANCODE_MASK,
			Keypad3 = (int)Scancode.Keypad3 | SDLK_SCANCODE_MASK,
			Keypad4 = (int)Scancode.Keypad4 | SDLK_SCANCODE_MASK,
			Keypad5 = (int)Scancode.Keypad5 | SDLK_SCANCODE_MASK,
			Keypad6 = (int)Scancode.Keypad6 | SDLK_SCANCODE_MASK,
			Keypad7 = (int)Scancode.Keypad7 | SDLK_SCANCODE_MASK,
			Keypad8 = (int)Scancode.Keypad8 | SDLK_SCANCODE_MASK,
			Keypad9 = (int)Scancode.Keypad9 | SDLK_SCANCODE_MASK,
			Keypad0 = (int)Scancode.Keypad0 | SDLK_SCANCODE_MASK,
			KeypadPeriod = (int)Scancode.KeypadPeriod | SDLK_SCANCODE_MASK,

			Application = (int)Scancode.Application | SDLK_SCANCODE_MASK,
			Power = (int)Scancode.Power | SDLK_SCANCODE_MASK,
			KeypadEquals = (int)Scancode.KeypadEquals | SDLK_SCANCODE_MASK,
			F13 = (int)Scancode.F13 | SDLK_SCANCODE_MASK,
			F14 = (int)Scancode.F14 | SDLK_SCANCODE_MASK,
			F15 = (int)Scancode.F15 | SDLK_SCANCODE_MASK,
			F16 = (int)Scancode.F16 | SDLK_SCANCODE_MASK,
			F17 = (int)Scancode.F17 | SDLK_SCANCODE_MASK,
			F18 = (int)Scancode.F18 | SDLK_SCANCODE_MASK,
			F19 = (int)Scancode.F19 | SDLK_SCANCODE_MASK,
			F20 = (int)Scancode.F20 | SDLK_SCANCODE_MASK,
			F21 = (int)Scancode.F21 | SDLK_SCANCODE_MASK,
			F22 = (int)Scancode.F22 | SDLK_SCANCODE_MASK,
			F23 = (int)Scancode.F23 | SDLK_SCANCODE_MASK,
			F24 = (int)Scancode.F24 | SDLK_SCANCODE_MASK,
			Execute = (int)Scancode.Execute | SDLK_SCANCODE_MASK,
			Help = (int)Scancode.Help | SDLK_SCANCODE_MASK,
			Menu = (int)Scancode.Menu | SDLK_SCANCODE_MASK,
			Select = (int)Scancode.Select | SDLK_SCANCODE_MASK,
			Stop = (int)Scancode.Stop | SDLK_SCANCODE_MASK,
			Again = (int)Scancode.Again | SDLK_SCANCODE_MASK,
			Undo = (int)Scancode.Undo | SDLK_SCANCODE_MASK,
			Cut = (int)Scancode.Cut | SDLK_SCANCODE_MASK,
			Copy = (int)Scancode.Copy | SDLK_SCANCODE_MASK,
			Paste = (int)Scancode.Paste | SDLK_SCANCODE_MASK,
			Find = (int)Scancode.Find | SDLK_SCANCODE_MASK,
			Mute = (int)Scancode.Mute | SDLK_SCANCODE_MASK,
			VolumeUp = (int)Scancode.VolumeUp | SDLK_SCANCODE_MASK,
			VolumeDown = (int)Scancode.VolumeDown | SDLK_SCANCODE_MASK,
			KeypadComma = (int)Scancode.KeypadComma | SDLK_SCANCODE_MASK,
			KeypadEqualsas400 =
			(int)Scancode.KeypadEqualsas400 | SDLK_SCANCODE_MASK,

			Alterase = (int)Scancode.Alterase | SDLK_SCANCODE_MASK,
			Sysreq = (int)Scancode.Sysreq | SDLK_SCANCODE_MASK,
			Cancel = (int)Scancode.Cancel | SDLK_SCANCODE_MASK,
			Clear = (int)Scancode.Clear | SDLK_SCANCODE_MASK,
			Prior = (int)Scancode.Prior | SDLK_SCANCODE_MASK,
			Return2 = (int)Scancode.Return2 | SDLK_SCANCODE_MASK,
			Separator = (int)Scancode.Separator | SDLK_SCANCODE_MASK,
			Out = (int)Scancode.Out | SDLK_SCANCODE_MASK,
			Oper = (int)Scancode.Oper | SDLK_SCANCODE_MASK,
			Clearagain = (int)Scancode.ClearAgain | SDLK_SCANCODE_MASK,
			Crsel = (int)Scancode.Crsel | SDLK_SCANCODE_MASK,
			Exsel = (int)Scancode.Exsel | SDLK_SCANCODE_MASK,

			Keypad00 = (int)Scancode.Keypad00 | SDLK_SCANCODE_MASK,
			Keypad000 = (int)Scancode.Keypad000 | SDLK_SCANCODE_MASK,
			ThousandsSeparator =
			(int)Scancode.ThousandsSeparator | SDLK_SCANCODE_MASK,
			DecimalSeparator =
			(int)Scancode.DecimalSeparator | SDLK_SCANCODE_MASK,
			CurrencyUnit = (int)Scancode.CurrencyUnit | SDLK_SCANCODE_MASK,
			CurrencySubUnit =
			(int)Scancode.CurrencySubUnit | SDLK_SCANCODE_MASK,
			KeypadLeftParen = (int)Scancode.KeypadLeftParen | SDLK_SCANCODE_MASK,
			KeypadRightParen = (int)Scancode.KeypadRightParen | SDLK_SCANCODE_MASK,
			KeypadLeftBrace = (int)Scancode.KeypadLeftBrace | SDLK_SCANCODE_MASK,
			KeypadRightBrace = (int)Scancode.KeypadRightBrace | SDLK_SCANCODE_MASK,
			KeypadTab = (int)Scancode.KeypadTab | SDLK_SCANCODE_MASK,
			KeypadBackspace = (int)Scancode.KeypadBackspace | SDLK_SCANCODE_MASK,
			KeypadA = (int)Scancode.KeypadA | SDLK_SCANCODE_MASK,
			KeypadB = (int)Scancode.KeypadB | SDLK_SCANCODE_MASK,
			KeypadC = (int)Scancode.KeypadC | SDLK_SCANCODE_MASK,
			KeypadD = (int)Scancode.KeypadD | SDLK_SCANCODE_MASK,
			KeypadE = (int)Scancode.KeypadE | SDLK_SCANCODE_MASK,
			KeypadF = (int)Scancode.KeypadF | SDLK_SCANCODE_MASK,
			KeypadXor = (int)Scancode.KeypadXor | SDLK_SCANCODE_MASK,
			KeypadPower = (int)Scancode.KeypadPower | SDLK_SCANCODE_MASK,
			KeypadPercent = (int)Scancode.KeypadPercent | SDLK_SCANCODE_MASK,
			KeypadLess = (int)Scancode.KeypadLess | SDLK_SCANCODE_MASK,
			KeypadGreater = (int)Scancode.KeypadGreater | SDLK_SCANCODE_MASK,
			KeypadAmpersand = (int)Scancode.KeypadAmpersand | SDLK_SCANCODE_MASK,
			KeypadDblampersand =
			(int)Scancode.KeypadDblampersand | SDLK_SCANCODE_MASK,
			KeypadVerticalbar =
			(int)Scancode.KeypadVerticalbar | SDLK_SCANCODE_MASK,
			KeypadDblverticalbar =
			(int)Scancode.KeypadDblverticalbar | SDLK_SCANCODE_MASK,
			KeypadColon = (int)Scancode.KeypadColon | SDLK_SCANCODE_MASK,
			KeypadHash = (int)Scancode.KeypadHash | SDLK_SCANCODE_MASK,
			KeypadSpace = (int)Scancode.KeypadSpace | SDLK_SCANCODE_MASK,
			KeypadAt = (int)Scancode.KeypadAt | SDLK_SCANCODE_MASK,
			KeypadExclam = (int)Scancode.KeypadExclam | SDLK_SCANCODE_MASK,
			KeypadMemStore = (int)Scancode.KeypadMemStore | SDLK_SCANCODE_MASK,
			KeypadMemRecall = (int)Scancode.KeypadMemRecall | SDLK_SCANCODE_MASK,
			KeypadMemClear = (int)Scancode.KeypadMemClear | SDLK_SCANCODE_MASK,
			KeypadMemAdd = (int)Scancode.KeypadMemAdd | SDLK_SCANCODE_MASK,
			KeypadMemSubtract =
			(int)Scancode.KeypadMemSubtract | SDLK_SCANCODE_MASK,
			KeypadMemMultiply =
			(int)Scancode.KeypadMemMultiply | SDLK_SCANCODE_MASK,
			KeypadMemDivide = (int)Scancode.KeypadMemDivide | SDLK_SCANCODE_MASK,
			KeypadPlusminus = (int)Scancode.KeypadPlusminus | SDLK_SCANCODE_MASK,
			KeypadClear = (int)Scancode.KeypadClear | SDLK_SCANCODE_MASK,
			KeypadClearentry = (int)Scancode.KeypadClearentry | SDLK_SCANCODE_MASK,
			KeypadBinary = (int)Scancode.KeypadBinary | SDLK_SCANCODE_MASK,
			KeypadOctal = (int)Scancode.KeypadOctal | SDLK_SCANCODE_MASK,
			KeypadDecimal = (int)Scancode.KeypadDecimal | SDLK_SCANCODE_MASK,
			KeypadHexadecimal =
			(int)Scancode.KeypadHexadecimal | SDLK_SCANCODE_MASK,

			LCtrl = (int)Scancode.LCtrl | SDLK_SCANCODE_MASK,
			LShift = (int)Scancode.LShift | SDLK_SCANCODE_MASK,
			LAlt = (int)Scancode.LAlt | SDLK_SCANCODE_MASK,
			LGui = (int)Scancode.LGui | SDLK_SCANCODE_MASK,
			RCtrl = (int)Scancode.RCtrl | SDLK_SCANCODE_MASK,
			RShift = (int)Scancode.RShift | SDLK_SCANCODE_MASK,
			RAlt = (int)Scancode.RAlt | SDLK_SCANCODE_MASK,
			RGui = (int)Scancode.RGui | SDLK_SCANCODE_MASK,

			Mode = (int)Scancode.Mode | SDLK_SCANCODE_MASK,

			AudioNext = (int)Scancode.AudioNext | SDLK_SCANCODE_MASK,
			AudioPrev = (int)Scancode.AudioPrev | SDLK_SCANCODE_MASK,
			AudioStop = (int)Scancode.AudioStop | SDLK_SCANCODE_MASK,
			AudioPlay = (int)Scancode.AudioPlay | SDLK_SCANCODE_MASK,
			AudioMute = (int)Scancode.AudioMute | SDLK_SCANCODE_MASK,
			MediaSelect = (int)Scancode.MediaSelect | SDLK_SCANCODE_MASK,
			Www = (int)Scancode.Www | SDLK_SCANCODE_MASK,
			Mail = (int)Scancode.Mail | SDLK_SCANCODE_MASK,
			Calculator = (int)Scancode.Calculator | SDLK_SCANCODE_MASK,
			Computer = (int)Scancode.Computer | SDLK_SCANCODE_MASK,
			AcSearch = (int)Scancode.AcSearch | SDLK_SCANCODE_MASK,
			AcHome = (int)Scancode.AcHome | SDLK_SCANCODE_MASK,
			AcBack = (int)Scancode.AcBack | SDLK_SCANCODE_MASK,
			AcForward = (int)Scancode.AcForward | SDLK_SCANCODE_MASK,
			AcStop = (int)Scancode.AcStop | SDLK_SCANCODE_MASK,
			AcRefresh = (int)Scancode.AcRefresh | SDLK_SCANCODE_MASK,
			AcBookmarks = (int)Scancode.AcBookmarks | SDLK_SCANCODE_MASK,

			BrightnessDown =
			(int)Scancode.BrightnessDown | SDLK_SCANCODE_MASK,
			BrightnessUp = (int)Scancode.BrightnessUp | SDLK_SCANCODE_MASK,
			DisplaySwitch = (int)Scancode.DisplaySwitch | SDLK_SCANCODE_MASK,
			KbdillumToggle =
			(int)Scancode.KbdillumToggle | SDLK_SCANCODE_MASK,
			KbdillumDown = (int)Scancode.KbdillumDown | SDLK_SCANCODE_MASK,
			KbdillumUp = (int)Scancode.KbdillumUp | SDLK_SCANCODE_MASK,
			Eject = (int)Scancode.Eject | SDLK_SCANCODE_MASK,
			Sleep = (int)Scancode.Sleep | SDLK_SCANCODE_MASK,
			App1 = (int)Scancode.App1 | SDLK_SCANCODE_MASK,
			App2 = (int)Scancode.App2 | SDLK_SCANCODE_MASK,

			AudioRewind = (int)Scancode.AudioRewind | SDLK_SCANCODE_MASK,
			AudioFastForward = (int)Scancode.AudioFastForward | SDLK_SCANCODE_MASK
		}

		/* Key modifiers (bitfield) */
		[Flags]
		public enum Keymod : ushort
		{
			None = 0x0000,
			LShift = 0x0001,
			RShift = 0x0002,
			LCtrl = 0x0040,
			RCtrl = 0x0080,
			LAlt = 0x0100,
			RAlt = 0x0200,
			LGui = 0x0400,
			RGui = 0x0800,
			Num = 0x1000,
			Caps = 0x2000,
			Mode = 0x4000,
			Reserved = 0x8000,

			/* These are defines in the Sdl headers */
			Ctrl = (LCtrl | RCtrl),
			Shift = (LShift | RShift),
			Alt = (LAlt | RAlt),
			Gui = (LGui | RGui)
		}

		#endregion
    }
}
