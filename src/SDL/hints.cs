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
    #region hints.h
    public static class Hints
    {
        public const string FRAMEBUFFER_ACCELERATION =
            "SDL_FRAMEBUFFER_ACCELERATION";
        public const string RENDER_DRIVER =
            "SDL_RENDER_DRIVER";
        public const string RENDER_OPENGL_SHADERS =
            "SDL_RENDER_OPENGL_SHADERS";
        public const string RENDER_DIRECT3D_THREADSAFE =
            "SDL_RENDER_DIRECT3D_THREADSAFE";
        public const string RENDER_VSYNC =
            "SDL_RENDER_VSYNC";
        public const string VIDEO_X11_XVIDMODE =
            "SDL_VIDEO_X11_XVIDMODE";
        public const string VIDEO_X11_XINERAMA =
            "SDL_VIDEO_X11_XINERAMA";
        public const string VIDEO_X11_XRANDR =
            "SDL_VIDEO_X11_XRANDR";
        public const string GRAB_KEYBOARD =
            "SDL_GRAB_KEYBOARD";
        public const string VIDEO_MINIMIZE_ON_FOCUS_LOSS =
            "SDL_VIDEO_MINIMIZE_ON_FOCUS_LOSS";
        public const string IDLE_TIMER_DISABLED =
            "SDL_IOS_IDLE_TIMER_DISABLED";
        public const string ORIENTATIONS =
            "SDL_IOS_ORIENTATIONS";
        public const string XINPUT_ENABLED =
            "SDL_XINPUT_ENABLED";
        public const string GAMECONTROLLERCONFIG =
            "SDL_GAMECONTROLLERCONFIG";
        public const string JOYSTICK_ALLOW_BACKGROUND_EVENTS =
            "SDL_JOYSTICK_ALLOW_BACKGROUND_EVENTS";
        public const string ALLOW_TOPMOST =
            "SDL_ALLOW_TOPMOST";
        public const string TIMER_RESOLUTION =
            "SDL_TIMER_RESOLUTION";
        public const string RENDER_SCALE_QUALITY =
            "SDL_RENDER_SCALE_QUALITY";

        /* Only available in SDL 2.0.1 or higher */
        public const string VIDEO_HIGHDPI_DISABLED =
            "SDL_VIDEO_HIGHDPI_DISABLED";

        /* Only available in SDL 2.0.2 or higher */
        public const string CTRL_CLICK_EMULATE_RIGHT_CLICK =
            "SDL_CTRL_CLICK_EMULATE_RIGHT_CLICK";
        public const string VIDEO_WIN_D3DCOMPILER =
            "SDL_VIDEO_WIN_D3DCOMPILER";
        public const string MOUSE_RELATIVE_MODE_WARP =
            "SDL_MOUSE_RELATIVE_MODE_WARP";
        public const string VIDEO_WINDOW_SHARE_PIXEL_FORMAT =
            "SDL_VIDEO_WINDOW_SHARE_PIXEL_FORMAT";
        public const string VIDEO_ALLOW_SCREENSAVER =
            "SDL_VIDEO_ALLOW_SCREENSAVER";
        public const string ACCELEROMETER_AS_JOYSTICK =
            "SDL_ACCELEROMETER_AS_JOYSTICK";
        public const string VIDEO_MAC_FULLSCREEN_SPACES =
            "SDL_VIDEO_MAC_FULLSCREEN_SPACES";

        /* Only available in SDL 2.0.3 or higher */
        public const string WINRT_PRIVACY_POLICY_URL =
            "SDL_WINRT_PRIVACY_POLICY_URL";
        public const string WINRT_PRIVACY_POLICY_LABEL =
            "SDL_WINRT_PRIVACY_POLICY_LABEL";
        public const string WINRT_HANDLE_BACK_BUTTON =
            "SDL_WINRT_HANDLE_BACK_BUTTON";

        /* Only available in SDL 2.0.4 or higher */
        public const string NO_SIGNAL_HANDLERS =
            "SDL_NO_SIGNAL_HANDLERS";
        public const string IME_INTERNAL_EDITING =
            "SDL_IME_INTERNAL_EDITING";
        public const string ANDROID_SEPARATE_MOUSE_AND_TOUCH =
            "SDL_ANDROID_SEPARATE_MOUSE_AND_TOUCH";
        public const string EMSCRIPTEN_KEYBOARD_ELEMENT =
            "SDL_EMSCRIPTEN_KEYBOARD_ELEMENT";
        public const string THREAD_STACK_SIZE =
            "SDL_THREAD_STACK_SIZE";
        public const string WINDOW_FRAME_USABLE_WHILE_CURSOR_HIDDEN =
            "SDL_WINDOW_FRAME_USABLE_WHILE_CURSOR_HIDDEN";
        public const string WINDOWS_ENABLE_MESSAGELOOP =
            "SDL_WINDOWS_ENABLE_MESSAGELOOP";
        public const string WINDOWS_NO_CLOSE_ON_ALT_F4 =
            "SDL_WINDOWS_NO_CLOSE_ON_ALT_F4";
        public const string XINPUT_USE_OLD_JOYSTICK_MAPPING =
            "SDL_XINPUT_USE_OLD_JOYSTICK_MAPPING";
        public const string MAC_BACKGROUND_APP =
            "SDL_MAC_BACKGROUND_APP";
        public const string VIDEO_X11_NET_WM_PING =
            "SDL_VIDEO_X11_NET_WM_PING";
        public const string ANDROID_APK_EXPANSION_MAIN_FILE_VERSION =
            "SDL_ANDROID_APK_EXPANSION_MAIN_FILE_VERSION";
        public const string ANDROID_APK_EXPANSION_PATCH_FILE_VERSION =
            "SDL_ANDROID_APK_EXPANSION_PATCH_FILE_VERSION";

        /* Only available in 2.0.5 or higher */
        public const string MOUSE_FOCUS_CLICKTHROUGH =
            "SDL_MOUSE_FOCUS_CLICKTHROUGH";
        public const string BMP_SAVE_LEGACY_FORMAT =
            "SDL_BMP_SAVE_LEGACY_FORMAT";
        public const string WINDOWS_DISABLE_THREAD_NAMING =
            "SDL_WINDOWS_DISABLE_THREAD_NAMING";
        public const string APPLE_TV_REMOTE_ALLOW_ROTATION =
            "SDL_APPLE_TV_REMOTE_ALLOW_ROTATION";

        /* Only available in 2.0.6 or higher */
        public const string AUDIO_RESAMPLING_MODE =
            "SDL_AUDIO_RESAMPLING_MODE";
        public const string RENDER_LOGICAL_SIZE_MODE =
            "SDL_RENDER_LOGICAL_SIZE_MODE";
        public const string MOUSE_NORMAL_SPEED_SCALE =
            "SDL_MOUSE_NORMAL_SPEED_SCALE";
        public const string MOUSE_RELATIVE_SPEED_SCALE =
            "SDL_MOUSE_RELATIVE_SPEED_SCALE";
        public const string TOUCH_MOUSE_EVENTS =
            "SDL_TOUCH_MOUSE_EVENTS";
        public const string WINDOWS_INTRESOURCE_ICON =
            "SDL_WINDOWS_INTRESOURCE_ICON";
        public const string WINDOWS_INTRESOURCE_ICON_SMALL =
            "SDL_WINDOWS_INTRESOURCE_ICON_SMALL";

        /* Only available in 2.0.8 or higher */
        public const string IOS_HIDE_HOME_INDICATOR =
            "SDL_IOS_HIDE_HOME_INDICATOR";
        public const string TV_REMOTE_AS_JOYSTICK =
            "SDL_TV_REMOTE_AS_JOYSTICK";

        /* Only available in 2.0.9 or higher */
        public const string MOUSE_DOUBLE_CLICK_TIME =
            "SDL_MOUSE_DOUBLE_CLICK_TIME";
        public const string MOUSE_DOUBLE_CLICK_RADIUS =
            "SDL_MOUSE_DOUBLE_CLICK_RADIUS";
        public const string JOYSTICK_HIDAPI =
            "SDL_JOYSTICK_HIDAPI";
        public const string JOYSTICK_HIDAPI_PS4 =
            "SDL_JOYSTICK_HIDAPI_PS4";
        public const string JOYSTICK_HIDAPI_PS4_RUMBLE =
            "SDL_JOYSTICK_HIDAPI_PS4_RUMBLE";
        public const string JOYSTICK_HIDAPI_STEAM =
            "SDL_JOYSTICK_HIDAPI_STEAM";
        public const string JOYSTICK_HIDAPI_SWITCH =
            "SDL_JOYSTICK_HIDAPI_SWITCH";
        public const string JOYSTICK_HIDAPI_XBOX =
            "SDL_JOYSTICK_HIDAPI_XBOX";
        public const string ENABLE_STEAM_CONTROLLERS =
            "SDL_ENABLE_STEAM_CONTROLLERS";
        public const string ANDROID_TRAP_BACK_BUTTON =
            "SDL_ANDROID_TRAP_BACK_BUTTON";

        /* Only available in 2.0.10 or higher */
        public const string MOUSE_TOUCH_EVENTS =
            "SDL_MOUSE_TOUCH_EVENTS";
        public const string GAMECONTROLLERCONFIG_FILE =
            "SDL_GAMECONTROLLERCONFIG_FILE";
        public const string ANDROID_BLOCK_ON_PAUSE =
            "SDL_ANDROID_BLOCK_ON_PAUSE";
        public const string RENDER_BATCHING =
            "SDL_RENDER_BATCHING";
        public const string EVENT_LOGGING =
            "SDL_EVENT_LOGGING";
        public const string WAVE_RIFF_CHUNK_SIZE =
            "SDL_WAVE_RIFF_CHUNK_SIZE";
        public const string WAVE_TRUNCATION =
            "SDL_WAVE_TRUNCATION";
        public const string WAVE_FACT_CHUNK =
            "SDL_WAVE_FACT_CHUNK";
    }

    public enum HintPriority
    {
        Default,
        Normal,
        Override
    }
    public static partial class SDL
    {

        /// <summary>
        /// Clear all hints. 
        /// This function is called during  to free stored hints.
        /// </summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_ClearHints")]
        public static extern void ClearHints();

        /// <summary>Get a hint.</summary>
        [DllImport(nativeLibName, EntryPoint = "SDL_GetHint", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr INTERNAL_GetHint(byte[] name);
        public static string GetHint(string name)
        {
            return UTF8_ToManaged(
                INTERNAL_GetHint(
                    UTF8_ToNative(name)
                )
            );
        }

        /// <summary>Set a hint with normal priority.</summary>
        [DllImport(nativeLibName, EntryPoint = "SDL_SetHint", CallingConvention = CallingConvention.Cdecl)]
        private static extern bool INTERNAL_SetHint(
            byte[] name,
            byte[] value
        );
        public static bool SetHint(string name, string value)
        {
            return INTERNAL_SetHint(
                UTF8_ToNative(name),
                UTF8_ToNative(value)
            );
        }

        /// <summary>
        /// Set a hint with a specific priority. 
        /// The priority controls the behavior when setting a hint that already has a value. Hints will replace existing hints of their priority and lower. Environment variables are considered to have override priority.
        /// </summary>
        [DllImport(nativeLibName, EntryPoint = "SDL_SetHintWithPriority", CallingConvention = CallingConvention.Cdecl)]
        private static extern bool INTERNAL_SetHintWithPriority(
            byte[] name,
            byte[] value,
            HintPriority priority
        );
        public static bool SetHintWithPriority(
            string name,
            string value,
            HintPriority priority
        )
        {
            return INTERNAL_SetHintWithPriority(
                UTF8_ToNative(name),
                UTF8_ToNative(value),
                priority
            );
        }

        /* Available in 2.0.5 or higher */
        /// <summary>
        /// Get a hint.
        /// 
        /// Binding info:
        /// Available in 2.0.5 or higher
        /// </summary>
        [DllImport(nativeLibName, EntryPoint = "SDL_GetHintBoolean", CallingConvention = CallingConvention.Cdecl)]
        private static extern bool INTERNAL_GetHintBoolean(
            byte[] name,
            bool default_value
        );
        public static bool GetHintBoolean(
            string name,
            bool default_value
        )
        {
            return INTERNAL_GetHintBoolean(
                UTF8_ToNative(name),
                default_value
            );
        }

        #endregion
    }
}
