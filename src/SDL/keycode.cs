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
    #region keycode.h
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

        CapsLock = (int)Scancode.CapsLock | SDL.SDLK_SCANCODE_MASK,

        F1 = (int)Scancode.F1 | SDL.SDLK_SCANCODE_MASK,
        F2 = (int)Scancode.F2 | SDL.SDLK_SCANCODE_MASK,
        F3 = (int)Scancode.F3 | SDL.SDLK_SCANCODE_MASK,
        F4 = (int)Scancode.F4 | SDL.SDLK_SCANCODE_MASK,
        F5 = (int)Scancode.F5 | SDL.SDLK_SCANCODE_MASK,
        F6 = (int)Scancode.F6 | SDL.SDLK_SCANCODE_MASK,
        F7 = (int)Scancode.F7 | SDL.SDLK_SCANCODE_MASK,
        F8 = (int)Scancode.F8 | SDL.SDLK_SCANCODE_MASK,
        F9 = (int)Scancode.F9 | SDL.SDLK_SCANCODE_MASK,
        F10 = (int)Scancode.F10 | SDL.SDLK_SCANCODE_MASK,
        F11 = (int)Scancode.F11 | SDL.SDLK_SCANCODE_MASK,
        F12 = (int)Scancode.F12 | SDL.SDLK_SCANCODE_MASK,

        PrintScreen = (int)Scancode.PrintScreen | SDL.SDLK_SCANCODE_MASK,
        ScrollLock = (int)Scancode.ScrollLock | SDL.SDLK_SCANCODE_MASK,
        Pause = (int)Scancode.Pause | SDL.SDLK_SCANCODE_MASK,
        Insert = (int)Scancode.Insert | SDL.SDLK_SCANCODE_MASK,
        Home = (int)Scancode.Home | SDL.SDLK_SCANCODE_MASK,
        PageUp = (int)Scancode.PageUp | SDL.SDLK_SCANCODE_MASK,
        Delete = 127,
        End = (int)Scancode.End | SDL.SDLK_SCANCODE_MASK,
        PageDown = (int)Scancode.PageDown | SDL.SDLK_SCANCODE_MASK,
        Right = (int)Scancode.Right | SDL.SDLK_SCANCODE_MASK,
        Left = (int)Scancode.Left | SDL.SDLK_SCANCODE_MASK,
        Down = (int)Scancode.Down | SDL.SDLK_SCANCODE_MASK,
        Up = (int)Scancode.Up | SDL.SDLK_SCANCODE_MASK,

        NumlockClear = (int)Scancode.NumlockClear | SDL.SDLK_SCANCODE_MASK,
        KeypadDivide = (int)Scancode.KeypadDivide | SDL.SDLK_SCANCODE_MASK,
        KeypadMultiply = (int)Scancode.KeypadMultiply | SDL.SDLK_SCANCODE_MASK,
        KeypadMinus = (int)Scancode.KeypadMinus | SDL.SDLK_SCANCODE_MASK,
        KeypadPlus = (int)Scancode.KeypadPlus | SDL.SDLK_SCANCODE_MASK,
        KeypadEnter = (int)Scancode.KeypadEnter | SDL.SDLK_SCANCODE_MASK,
        Keypad1 = (int)Scancode.Keypad1 | SDL.SDLK_SCANCODE_MASK,
        Keypad2 = (int)Scancode.Keypad2 | SDL.SDLK_SCANCODE_MASK,
        Keypad3 = (int)Scancode.Keypad3 | SDL.SDLK_SCANCODE_MASK,
        Keypad4 = (int)Scancode.Keypad4 | SDL.SDLK_SCANCODE_MASK,
        Keypad5 = (int)Scancode.Keypad5 | SDL.SDLK_SCANCODE_MASK,
        Keypad6 = (int)Scancode.Keypad6 | SDL.SDLK_SCANCODE_MASK,
        Keypad7 = (int)Scancode.Keypad7 | SDL.SDLK_SCANCODE_MASK,
        Keypad8 = (int)Scancode.Keypad8 | SDL.SDLK_SCANCODE_MASK,
        Keypad9 = (int)Scancode.Keypad9 | SDL.SDLK_SCANCODE_MASK,
        Keypad0 = (int)Scancode.Keypad0 | SDL.SDLK_SCANCODE_MASK,
        KeypadPeriod = (int)Scancode.KeypadPeriod | SDL.SDLK_SCANCODE_MASK,

        Application = (int)Scancode.Application | SDL.SDLK_SCANCODE_MASK,
        Power = (int)Scancode.Power | SDL.SDLK_SCANCODE_MASK,
        KeypadEquals = (int)Scancode.KeypadEquals | SDL.SDLK_SCANCODE_MASK,
        F13 = (int)Scancode.F13 | SDL.SDLK_SCANCODE_MASK,
        F14 = (int)Scancode.F14 | SDL.SDLK_SCANCODE_MASK,
        F15 = (int)Scancode.F15 | SDL.SDLK_SCANCODE_MASK,
        F16 = (int)Scancode.F16 | SDL.SDLK_SCANCODE_MASK,
        F17 = (int)Scancode.F17 | SDL.SDLK_SCANCODE_MASK,
        F18 = (int)Scancode.F18 | SDL.SDLK_SCANCODE_MASK,
        F19 = (int)Scancode.F19 | SDL.SDLK_SCANCODE_MASK,
        F20 = (int)Scancode.F20 | SDL.SDLK_SCANCODE_MASK,
        F21 = (int)Scancode.F21 | SDL.SDLK_SCANCODE_MASK,
        F22 = (int)Scancode.F22 | SDL.SDLK_SCANCODE_MASK,
        F23 = (int)Scancode.F23 | SDL.SDLK_SCANCODE_MASK,
        F24 = (int)Scancode.F24 | SDL.SDLK_SCANCODE_MASK,
        Execute = (int)Scancode.Execute | SDL.SDLK_SCANCODE_MASK,
        Help = (int)Scancode.Help | SDL.SDLK_SCANCODE_MASK,
        Menu = (int)Scancode.Menu | SDL.SDLK_SCANCODE_MASK,
        Select = (int)Scancode.Select | SDL.SDLK_SCANCODE_MASK,
        Stop = (int)Scancode.Stop | SDL.SDLK_SCANCODE_MASK,
        Again = (int)Scancode.Again | SDL.SDLK_SCANCODE_MASK,
        Undo = (int)Scancode.Undo | SDL.SDLK_SCANCODE_MASK,
        Cut = (int)Scancode.Cut | SDL.SDLK_SCANCODE_MASK,
        Copy = (int)Scancode.Copy | SDL.SDLK_SCANCODE_MASK,
        Paste = (int)Scancode.Paste | SDL.SDLK_SCANCODE_MASK,
        Find = (int)Scancode.Find | SDL.SDLK_SCANCODE_MASK,
        Mute = (int)Scancode.Mute | SDL.SDLK_SCANCODE_MASK,
        VolumeUp = (int)Scancode.VolumeUp | SDL.SDLK_SCANCODE_MASK,
        VolumeDown = (int)Scancode.VolumeDown | SDL.SDLK_SCANCODE_MASK,
        KeypadComma = (int)Scancode.KeypadComma | SDL.SDLK_SCANCODE_MASK,
        KeypadEqualsas400 =
        (int)Scancode.KeypadEqualsas400 | SDL.SDLK_SCANCODE_MASK,

        Alterase = (int)Scancode.Alterase | SDL.SDLK_SCANCODE_MASK,
        Sysreq = (int)Scancode.Sysreq | SDL.SDLK_SCANCODE_MASK,
        Cancel = (int)Scancode.Cancel | SDL.SDLK_SCANCODE_MASK,
        Clear = (int)Scancode.Clear | SDL.SDLK_SCANCODE_MASK,
        Prior = (int)Scancode.Prior | SDL.SDLK_SCANCODE_MASK,
        Return2 = (int)Scancode.Return2 | SDL.SDLK_SCANCODE_MASK,
        Separator = (int)Scancode.Separator | SDL.SDLK_SCANCODE_MASK,
        Out = (int)Scancode.Out | SDL.SDLK_SCANCODE_MASK,
        Oper = (int)Scancode.Oper | SDL.SDLK_SCANCODE_MASK,
        Clearagain = (int)Scancode.ClearAgain | SDL.SDLK_SCANCODE_MASK,
        Crsel = (int)Scancode.Crsel | SDL.SDLK_SCANCODE_MASK,
        Exsel = (int)Scancode.Exsel | SDL.SDLK_SCANCODE_MASK,

        Keypad00 = (int)Scancode.Keypad00 | SDL.SDLK_SCANCODE_MASK,
        Keypad000 = (int)Scancode.Keypad000 | SDL.SDLK_SCANCODE_MASK,
        ThousandsSeparator =
        (int)Scancode.ThousandsSeparator | SDL.SDLK_SCANCODE_MASK,
        DecimalSeparator =
        (int)Scancode.DecimalSeparator | SDL.SDLK_SCANCODE_MASK,
        CurrencyUnit = (int)Scancode.CurrencyUnit | SDL.SDLK_SCANCODE_MASK,
        CurrencySubUnit =
        (int)Scancode.CurrencySubUnit | SDL.SDLK_SCANCODE_MASK,
        KeypadLeftParen = (int)Scancode.KeypadLeftParen | SDL.SDLK_SCANCODE_MASK,
        KeypadRightParen = (int)Scancode.KeypadRightParen | SDL.SDLK_SCANCODE_MASK,
        KeypadLeftBrace = (int)Scancode.KeypadLeftBrace | SDL.SDLK_SCANCODE_MASK,
        KeypadRightBrace = (int)Scancode.KeypadRightBrace | SDL.SDLK_SCANCODE_MASK,
        KeypadTab = (int)Scancode.KeypadTab | SDL.SDLK_SCANCODE_MASK,
        KeypadBackspace = (int)Scancode.KeypadBackspace | SDL.SDLK_SCANCODE_MASK,
        KeypadA = (int)Scancode.KeypadA | SDL.SDLK_SCANCODE_MASK,
        KeypadB = (int)Scancode.KeypadB | SDL.SDLK_SCANCODE_MASK,
        KeypadC = (int)Scancode.KeypadC | SDL.SDLK_SCANCODE_MASK,
        KeypadD = (int)Scancode.KeypadD | SDL.SDLK_SCANCODE_MASK,
        KeypadE = (int)Scancode.KeypadE | SDL.SDLK_SCANCODE_MASK,
        KeypadF = (int)Scancode.KeypadF | SDL.SDLK_SCANCODE_MASK,
        KeypadXor = (int)Scancode.KeypadXor | SDL.SDLK_SCANCODE_MASK,
        KeypadPower = (int)Scancode.KeypadPower | SDL.SDLK_SCANCODE_MASK,
        KeypadPercent = (int)Scancode.KeypadPercent | SDL.SDLK_SCANCODE_MASK,
        KeypadLess = (int)Scancode.KeypadLess | SDL.SDLK_SCANCODE_MASK,
        KeypadGreater = (int)Scancode.KeypadGreater | SDL.SDLK_SCANCODE_MASK,
        KeypadAmpersand = (int)Scancode.KeypadAmpersand | SDL.SDLK_SCANCODE_MASK,
        KeypadDblampersand =
        (int)Scancode.KeypadDblampersand | SDL.SDLK_SCANCODE_MASK,
        KeypadVerticalbar =
        (int)Scancode.KeypadVerticalbar | SDL.SDLK_SCANCODE_MASK,
        KeypadDblverticalbar =
        (int)Scancode.KeypadDblverticalbar | SDL.SDLK_SCANCODE_MASK,
        KeypadColon = (int)Scancode.KeypadColon | SDL.SDLK_SCANCODE_MASK,
        KeypadHash = (int)Scancode.KeypadHash | SDL.SDLK_SCANCODE_MASK,
        KeypadSpace = (int)Scancode.KeypadSpace | SDL.SDLK_SCANCODE_MASK,
        KeypadAt = (int)Scancode.KeypadAt | SDL.SDLK_SCANCODE_MASK,
        KeypadExclam = (int)Scancode.KeypadExclam | SDL.SDLK_SCANCODE_MASK,
        KeypadMemStore = (int)Scancode.KeypadMemStore | SDL.SDLK_SCANCODE_MASK,
        KeypadMemRecall = (int)Scancode.KeypadMemRecall | SDL.SDLK_SCANCODE_MASK,
        KeypadMemClear = (int)Scancode.KeypadMemClear | SDL.SDLK_SCANCODE_MASK,
        KeypadMemAdd = (int)Scancode.KeypadMemAdd | SDL.SDLK_SCANCODE_MASK,
        KeypadMemSubtract =
        (int)Scancode.KeypadMemSubtract | SDL.SDLK_SCANCODE_MASK,
        KeypadMemMultiply =
        (int)Scancode.KeypadMemMultiply | SDL.SDLK_SCANCODE_MASK,
        KeypadMemDivide = (int)Scancode.KeypadMemDivide | SDL.SDLK_SCANCODE_MASK,
        KeypadPlusminus = (int)Scancode.KeypadPlusminus | SDL.SDLK_SCANCODE_MASK,
        KeypadClear = (int)Scancode.KeypadClear | SDL.SDLK_SCANCODE_MASK,
        KeypadClearentry = (int)Scancode.KeypadClearentry | SDL.SDLK_SCANCODE_MASK,
        KeypadBinary = (int)Scancode.KeypadBinary | SDL.SDLK_SCANCODE_MASK,
        KeypadOctal = (int)Scancode.KeypadOctal | SDL.SDLK_SCANCODE_MASK,
        KeypadDecimal = (int)Scancode.KeypadDecimal | SDL.SDLK_SCANCODE_MASK,
        KeypadHexadecimal =
        (int)Scancode.KeypadHexadecimal | SDL.SDLK_SCANCODE_MASK,

        LCtrl = (int)Scancode.LCtrl | SDL.SDLK_SCANCODE_MASK,
        LShift = (int)Scancode.LShift | SDL.SDLK_SCANCODE_MASK,
        LAlt = (int)Scancode.LAlt | SDL.SDLK_SCANCODE_MASK,
        LGui = (int)Scancode.LGui | SDL.SDLK_SCANCODE_MASK,
        RCtrl = (int)Scancode.RCtrl | SDL.SDLK_SCANCODE_MASK,
        RShift = (int)Scancode.RShift | SDL.SDLK_SCANCODE_MASK,
        RAlt = (int)Scancode.RAlt | SDL.SDLK_SCANCODE_MASK,
        RGui = (int)Scancode.RGui | SDL.SDLK_SCANCODE_MASK,

        Mode = (int)Scancode.Mode | SDL.SDLK_SCANCODE_MASK,

        AudioNext = (int)Scancode.AudioNext | SDL.SDLK_SCANCODE_MASK,
        AudioPrev = (int)Scancode.AudioPrev | SDL.SDLK_SCANCODE_MASK,
        AudioStop = (int)Scancode.AudioStop | SDL.SDLK_SCANCODE_MASK,
        AudioPlay = (int)Scancode.AudioPlay | SDL.SDLK_SCANCODE_MASK,
        AudioMute = (int)Scancode.AudioMute | SDL.SDLK_SCANCODE_MASK,
        MediaSelect = (int)Scancode.MediaSelect | SDL.SDLK_SCANCODE_MASK,
        Www = (int)Scancode.Www | SDL.SDLK_SCANCODE_MASK,
        Mail = (int)Scancode.Mail | SDL.SDLK_SCANCODE_MASK,
        Calculator = (int)Scancode.Calculator | SDL.SDLK_SCANCODE_MASK,
        Computer = (int)Scancode.Computer | SDL.SDLK_SCANCODE_MASK,
        AcSearch = (int)Scancode.AcSearch | SDL.SDLK_SCANCODE_MASK,
        AcHome = (int)Scancode.AcHome | SDL.SDLK_SCANCODE_MASK,
        AcBack = (int)Scancode.AcBack | SDL.SDLK_SCANCODE_MASK,
        AcForward = (int)Scancode.AcForward | SDL.SDLK_SCANCODE_MASK,
        AcStop = (int)Scancode.AcStop | SDL.SDLK_SCANCODE_MASK,
        AcRefresh = (int)Scancode.AcRefresh | SDL.SDLK_SCANCODE_MASK,
        AcBookmarks = (int)Scancode.AcBookmarks | SDL.SDLK_SCANCODE_MASK,

        BrightnessDown =
        (int)Scancode.BrightnessDown | SDL.SDLK_SCANCODE_MASK,
        BrightnessUp = (int)Scancode.BrightnessUp | SDL.SDLK_SCANCODE_MASK,
        DisplaySwitch = (int)Scancode.DisplaySwitch | SDL.SDLK_SCANCODE_MASK,
        KbdillumToggle =
        (int)Scancode.KbdillumToggle | SDL.SDLK_SCANCODE_MASK,
        KbdillumDown = (int)Scancode.KbdillumDown | SDL.SDLK_SCANCODE_MASK,
        KbdillumUp = (int)Scancode.KbdillumUp | SDL.SDLK_SCANCODE_MASK,
        Eject = (int)Scancode.Eject | SDL.SDLK_SCANCODE_MASK,
        Sleep = (int)Scancode.Sleep | SDL.SDLK_SCANCODE_MASK,
        App1 = (int)Scancode.App1 | SDL.SDLK_SCANCODE_MASK,
        App2 = (int)Scancode.App2 | SDL.SDLK_SCANCODE_MASK,

        AudioRewind = (int)Scancode.AudioRewind | SDL.SDLK_SCANCODE_MASK,
        AudioFastForward = (int)Scancode.AudioFastForward | SDL.SDLK_SCANCODE_MASK
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
        Gui = (LGui | RGui),
    }
    public static partial class SDL
    {
        public const int SDLK_SCANCODE_MASK = (1 << 30);
        public static Keycode SCANCODE_TO_KEYCODE(Scancode X)
        {
            return (Keycode)((int)X | SDLK_SCANCODE_MASK);
        }
    }
    #endregion
}
