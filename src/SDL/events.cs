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


		#region events.h

		/* General keyboard/mouse state definitions. */
		public const byte PRESSED =		1;
		public const byte RELEASED =	0;

		/* Default size is according to SDL2 default. */
		public const int TEXTEDITINGEVENT_TEXT_SIZE = 32;
		public const int TEXTINPUTEVENT_TEXT_SIZE = 32;

		/* The types of events that can be delivered. */
		public enum EventType : uint
		{
			FIRSTEVENT =		0,

			/* Application events */
			QUIT = 			0x100,

			/* iOS/Android/WinRT app events */
			APP_TERMINATING,
			APP_LOWMEMORY,
			APP_WILLENTERBACKGROUND,
			APP_DIDENTERBACKGROUND,
			APP_WILLENTERFOREGROUND,
			APP_DIDENTERFOREGROUND,

			/* Display events */
			/* Only available in SDL 2.0.9 or higher */
			DISPLAYEVENT =		0x150,

			/* Window events */
			WINDOWEVENT = 		0x200,
			SYSWMEVENT,

			/* Keyboard events */
			KEYDOWN = 			0x300,
			KEYUP,
			TEXTEDITING,
			TEXTINPUT,
			KEYMAPCHANGED,

			/* Mouse events */
			MOUSEMOTION = 		0x400,
			MOUSEBUTTONDOWN,
			MOUSEBUTTONUP,
			MOUSEWHEEL,

			/* Joystick events */
			JOYAXISMOTION =		0x600,
			JOYBALLMOTION,
			JOYHATMOTION,
			JOYBUTTONDOWN,
			JOYBUTTONUP,
			JOYDEVICEADDED,
			JOYDEVICEREMOVED,

			/* Game controller events */
			CONTROLLERAXISMOTION = 	0x650,
			CONTROLLERBUTTONDOWN,
			CONTROLLERBUTTONUP,
			CONTROLLERDEVICEADDED,
			CONTROLLERDEVICEREMOVED,
			CONTROLLERDEVICEREMAPPED,

			/* Touch events */
			FINGERDOWN = 		0x700,
			FINGERUP,
			FINGERMOTION,

			/* Gesture events */
			DOLLARGESTURE =		0x800,
			DOLLARRECORD,
			MULTIGESTURE,

			/* Clipboard events */
			CLIPBOARDUPDATE =		0x900,

			/* Drag and drop events */
			DROPFILE =			0x1000,
			/* Only available in 2.0.4 or higher */
			DROPTEXT,
			DROPBEGIN,
			DROPCOMPLETE,

			/* Audio hotplug events */
			/* Only available in SDL 2.0.4 or higher */
			AUDIODEVICEADDED =		0x1100,
			AUDIODEVICEREMOVED,

			/* Sensor events */
			/* Only available in SDL 2.0.9 or higher */
			SENSORUPDATE =		0x1200,

			/* Render events */
			/* Only available in SDL 2.0.2 or higher */
			RENDER_TARGETS_RESET =	0x2000,
			/* Only available in SDL 2.0.4 or higher */
			RENDER_DEVICE_RESET,

			/* Events USEREVENT through LASTEVENT are for
			 * your use, and should be allocated with
			 * RegisterEvents()
			 */
			USEREVENT =			0x8000,

			/* The last event, used for bouding arrays. */
			LASTEVENT =			0xFFFF
		}

		/* Only available in 2.0.4 or higher */
		public enum MouseWheelDirection : uint
		{
			MOUSEWHEEL_NORMAL,
			MOUSEWHEEL_FLIPPED
		}

		/* Fields shared by every event */
		[StructLayout(LayoutKind.Sequential)]
		public struct GenericEvent
		{
			public EventType type;
			public UInt32 timestamp;
		}

// Ignore private members used for padding in this struct
#pragma warning disable 0169
		[StructLayout(LayoutKind.Sequential)]
		public struct DisplayEvent
		{
			public EventType type;
			public UInt32 timestamp;
			public UInt32 display;
			public DisplayEventID displayEvent; // event, lolC#
			private byte padding1;
			private byte padding2;
			private byte padding3;
			public Int32 data1;
		}
#pragma warning restore 0169

// Ignore private members used for padding in this struct
#pragma warning disable 0169
		/* Window state change event data (event.window.*) */
		[StructLayout(LayoutKind.Sequential)]
		public struct WindowEvent
		{
			public EventType type;
			public UInt32 timestamp;
			public UInt32 windowID;
			public WindowEventID windowEvent; // event, lolC#
			private byte padding1;
			private byte padding2;
			private byte padding3;
			public Int32 data1;
			public Int32 data2;
		}
#pragma warning restore 0169

// Ignore private members used for padding in this struct
#pragma warning disable 0169
		/* Keyboard button event structure (event.key.*) */
		[StructLayout(LayoutKind.Sequential)]
		public struct KeyboardEvent
		{
			public EventType type;
			public UInt32 timestamp;
			public UInt32 windowID;
			public byte state;
			public byte repeat; /* non-zero if this is a repeat */
			private byte padding2;
			private byte padding3;
			public Keysym keysym;
		}
#pragma warning restore 0169

		[StructLayout(LayoutKind.Sequential)]
		public unsafe struct TextEditingEvent
		{
			public EventType type;
			public UInt32 timestamp;
			public UInt32 windowID;
			public fixed byte text[TEXTEDITINGEVENT_TEXT_SIZE];
			public Int32 start;
			public Int32 length;
		}

		[StructLayout(LayoutKind.Sequential)]
		public unsafe struct TextInputEvent
		{
			public EventType type;
			public UInt32 timestamp;
			public UInt32 windowID;
			public fixed byte text[TEXTINPUTEVENT_TEXT_SIZE];
		}

// Ignore private members used for padding in this struct
#pragma warning disable 0169
		/* Mouse motion event structure (event.motion.*) */
		[StructLayout(LayoutKind.Sequential)]
		public struct MouseMotionEvent
		{
			public EventType type;
			public UInt32 timestamp;
			public UInt32 windowID;
			public UInt32 which;
			public byte state; /* bitmask of buttons */
			private byte padding1;
			private byte padding2;
			private byte padding3;
			public Int32 x;
			public Int32 y;
			public Int32 xrel;
			public Int32 yrel;
		}
#pragma warning restore 0169

// Ignore private members used for padding in this struct
#pragma warning disable 0169
		/* Mouse button event structure (event.button.*) */
		[StructLayout(LayoutKind.Sequential)]
		public struct MouseButtonEvent
		{
			public EventType type;
			public UInt32 timestamp;
			public UInt32 windowID;
			public UInt32 which;
			public byte button; /* button id */
			public byte state; /* PRESSED or RELEASED */
			public byte clicks; /* 1 for single-click, 2 for double-click, etc. */
			private byte padding1;
			public Int32 x;
			public Int32 y;
		}
#pragma warning restore 0169

		/* Mouse wheel event structure (event.wheel.*) */
		[StructLayout(LayoutKind.Sequential)]
		public struct MouseWheelEvent
		{
			public EventType type;
			public UInt32 timestamp;
			public UInt32 windowID;
			public UInt32 which;
			public Int32 x; /* amount scrolled horizontally */
			public Int32 y; /* amount scrolled vertically */
			public UInt32 direction; /* Set to one of the MOUSEWHEEL_* defines */
		}

// Ignore private members used for padding in this struct
#pragma warning disable 0169
		/* Joystick axis motion event structure (event.jaxis.*) */
		[StructLayout(LayoutKind.Sequential)]
		public struct JoyAxisEvent
		{
			public EventType type;
			public UInt32 timestamp;
			public Int32 which; /* JoystickID */
			public byte axis;
			private byte padding1;
			private byte padding2;
			private byte padding3;
			public Int16 axisValue; /* value, lolC# */
			public UInt16 padding4;
		}
#pragma warning restore 0169

// Ignore private members used for padding in this struct
#pragma warning disable 0169
		/* Joystick trackball motion event structure (event.jball.*) */
		[StructLayout(LayoutKind.Sequential)]
		public struct JoyBallEvent
		{
			public EventType type;
			public UInt32 timestamp;
			public Int32 which; /* JoystickID */
			public byte ball;
			private byte padding1;
			private byte padding2;
			private byte padding3;
			public Int16 xrel;
			public Int16 yrel;
		}
#pragma warning restore 0169

// Ignore private members used for padding in this struct
#pragma warning disable 0169
		/* Joystick hat position change event struct (event.jhat.*) */
		[StructLayout(LayoutKind.Sequential)]
		public struct JoyHatEvent
		{
			public EventType type;
			public UInt32 timestamp;
			public Int32 which; /* JoystickID */
			public byte hat; /* index of the hat */
			public byte hatValue; /* value, lolC# */
			private byte padding1;
			private byte padding2;
		}
#pragma warning restore 0169

// Ignore private members used for padding in this struct
#pragma warning disable 0169
		/* Joystick button event structure (event.jbutton.*) */
		[StructLayout(LayoutKind.Sequential)]
		public struct JoyButtonEvent
		{
			public EventType type;
			public UInt32 timestamp;
			public Int32 which; /* JoystickID */
			public byte button;
			public byte state; /* PRESSED or RELEASED */
			private byte padding1;
			private byte padding2;
		}
#pragma warning restore 0169

		/* Joystick device event structure (event.jdevice.*) */
		[StructLayout(LayoutKind.Sequential)]
		public struct JoyDeviceEvent
		{
			public EventType type;
			public UInt32 timestamp;
			public Int32 which; /* JoystickID */
		}

// Ignore private members used for padding in this struct
#pragma warning disable 0169
		/* Game controller axis motion event (event.caxis.*) */
		[StructLayout(LayoutKind.Sequential)]
		public struct ControllerAxisEvent
		{
			public EventType type;
			public UInt32 timestamp;
			public Int32 which; /* JoystickID */
			public byte axis;
			private byte padding1;
			private byte padding2;
			private byte padding3;
			public Int16 axisValue; /* value, lolC# */
			private UInt16 padding4;
		}
#pragma warning restore 0169

// Ignore private members used for padding in this struct
#pragma warning disable 0169
		/* Game controller button event (event.cbutton.*) */
		[StructLayout(LayoutKind.Sequential)]
		public struct ControllerButtonEvent
		{
			public EventType type;
			public UInt32 timestamp;
			public Int32 which; /* JoystickID */
			public byte button;
			public byte state;
			private byte padding1;
			private byte padding2;
		}
#pragma warning restore 0169

		/* Game controller device event (event.cdevice.*) */
		[StructLayout(LayoutKind.Sequential)]
		public struct ControllerDeviceEvent
		{
			public EventType type;
			public UInt32 timestamp;
			public Int32 which;	/* joystick id for ADDED,
						 * else instance id
						 */
		}

// Ignore private members used for padding in this struct
#pragma warning disable 0169
		/* Audio device event (event.adevice.*) */
		[StructLayout(LayoutKind.Sequential)]
		public struct AudioDeviceEvent
		{
			public UInt32 type;
			public UInt32 timestamp;
			public UInt32 which;
			public byte iscapture;
			private byte padding1;
			private byte padding2;
			private byte padding3;
		}
#pragma warning restore 0169

		[StructLayout(LayoutKind.Sequential)]
		public struct TouchFingerEvent
		{
			public UInt32 type;
			public UInt32 timestamp;
			public Int64 touchId; // TouchID
			public Int64 fingerId; // GestureID
			public float x;
			public float y;
			public float dx;
			public float dy;
			public float pressure;
		}

		[StructLayout(LayoutKind.Sequential)]
		public struct MultiGestureEvent
		{
			public UInt32 type;
			public UInt32 timestamp;
			public Int64 touchId; // TouchID
			public float dTheta;
			public float dDist;
			public float x;
			public float y;
			public UInt16 numFingers;
			public UInt16 padding;
		}

		[StructLayout(LayoutKind.Sequential)]
		public struct DollarGestureEvent
		{
			public UInt32 type;
			public UInt32 timestamp;
			public Int64 touchId; // TouchID
			public Int64 gestureId; // GestureID
			public UInt32 numFingers;
			public float error;
			public float x;
			public float y;
		}

		/* File open request by system (event.drop.*), enabled by
		 * default
		 */
		[StructLayout(LayoutKind.Sequential)]
		public struct DropEvent
		{
			public EventType type;
			public UInt32 timestamp;

			/* char* filename, to be freed.
			 * Access the variable EXACTLY ONCE like this:
			 * string s = SDL.UTF8_ToManaged(evt.drop.file, true);
			 */
			public IntPtr file;
			public UInt32 windowID;
		}

		[StructLayout(LayoutKind.Sequential)]
		public unsafe struct SensorEvent
		{
			public EventType type;
			public UInt32 timestamp;
			public Int32 which;
			public fixed float data[6];
		}

		/* The "quit requested" event */
		[StructLayout(LayoutKind.Sequential)]
		public struct QuitEvent
		{
			public EventType type;
			public UInt32 timestamp;
		}

		/* A user defined event (event.user.*) */
		[StructLayout(LayoutKind.Sequential)]
		public struct UserEvent
		{
			public UInt32 type;
			public UInt32 timestamp;
			public UInt32 windowID;
			public Int32 code;
			public IntPtr data1; /* user-defined */
			public IntPtr data2; /* user-defined */
		}

		/* A video driver dependent event (event.syswm.*), disabled */
		[StructLayout(LayoutKind.Sequential)]
		public struct SysWMEvent
		{
			public EventType type;
			public UInt32 timestamp;
			public IntPtr msg; /* SysWMmsg*, system-dependent*/
		}

		/* General event structure */
		// C# doesn't do unions, so we do this ugly thing. */
		[StructLayout(LayoutKind.Explicit)]
		public struct Event
		{
			[FieldOffset(0)]
			public EventType type;
			[FieldOffset(0)]
			public DisplayEvent display;
			[FieldOffset(0)]
			public WindowEvent window;
			[FieldOffset(0)]
			public KeyboardEvent key;
			[FieldOffset(0)]
			public TextEditingEvent edit;
			[FieldOffset(0)]
			public TextInputEvent text;
			[FieldOffset(0)]
			public MouseMotionEvent motion;
			[FieldOffset(0)]
			public MouseButtonEvent button;
			[FieldOffset(0)]
			public MouseWheelEvent wheel;
			[FieldOffset(0)]
			public JoyAxisEvent jaxis;
			[FieldOffset(0)]
			public JoyBallEvent jball;
			[FieldOffset(0)]
			public JoyHatEvent jhat;
			[FieldOffset(0)]
			public JoyButtonEvent jbutton;
			[FieldOffset(0)]
			public JoyDeviceEvent jdevice;
			[FieldOffset(0)]
			public ControllerAxisEvent caxis;
			[FieldOffset(0)]
			public ControllerButtonEvent cbutton;
			[FieldOffset(0)]
			public ControllerDeviceEvent cdevice;
			[FieldOffset(0)]
			public AudioDeviceEvent adevice;
			[FieldOffset(0)]
			public SensorEvent sensor;
			[FieldOffset(0)]
			public QuitEvent quit;
			[FieldOffset(0)]
			public UserEvent user;
			[FieldOffset(0)]
			public SysWMEvent syswm;
			[FieldOffset(0)]
			public TouchFingerEvent tfinger;
			[FieldOffset(0)]
			public MultiGestureEvent mgesture;
			[FieldOffset(0)]
			public DollarGestureEvent dgesture;
			[FieldOffset(0)]
			public DropEvent drop;
		}

		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate int EventFilter(
			IntPtr userdata, // void*
			IntPtr sdlevent // Event* event, lolC#
		);

		/* Pump the event loop, getting events from the input devices*/
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint="SDL_PumpEvents")]
		public static extern void PumpEvents();

		public enum eventaction
		{
			ADDEVENT,
			PEEKEVENT,
			GETEVENT
		}

		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint="SDL_PeepEvents")]
		public static extern int PeepEvents(
			[Out] Event[] events,
			int numevents,
			eventaction action,
			EventType minType,
			EventType maxType
		);

		/* Checks to see if certain events are in the event queue */
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint="SDL_HasEvent")]
		public static extern bool HasEvent(EventType type);

		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint="SDL_HasEvents")]
		public static extern bool HasEvents(
			EventType minType,
			EventType maxType
		);

		/* Clears events from the event queue */
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint="SDL_FlushEvent")]
		public static extern void FlushEvent(EventType type);

		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint="SDL_FlushEvents")]
		public static extern void FlushEvents(
			EventType min,
			EventType max
		);

		/* Polls for currently pending events */
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint="SDL_PollEvent")]
		public static extern int PollEvent(out Event _event);

		/* Waits indefinitely for the next event */
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint="SDL_WaitEvent")]
		public static extern int WaitEvent(out Event _event);

		/* Waits until the specified timeout (in ms) for the next event
		 */
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint="SDL_WaitEventTimeout")]
		public static extern int WaitEventTimeout(out Event _event, int timeout);

		/* Add an event to the event queue */
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint="SDL_PushEvent")]
		public static extern int PushEvent(ref Event _event);

		/* userdata refers to a void* */
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint="SDL_SetEventFilter")]
		public static extern void SetEventFilter(
			EventFilter filter,
			IntPtr userdata
		);

		/* userdata refers to a void* */
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		private static extern bool GetEventFilter(
			out IntPtr filter,
			out IntPtr userdata
		);
		public static bool GetEventFilter(
			out EventFilter filter,
			out IntPtr userdata
		) {
			IntPtr result = IntPtr.Zero;
			bool retval = GetEventFilter(out result, out userdata);
			if (result != IntPtr.Zero)
			{
				filter = (EventFilter) Marshal.GetDelegateForFunctionPointer(
					result,
					typeof(EventFilter)
				);
			}
			else
			{
				filter = null;
			}
			return retval;
		}

		/* userdata refers to a void* */
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint="SDL_AddEventWatch")]
		public static extern void AddEventWatch(
			EventFilter filter,
			IntPtr userdata
		);

		/* userdata refers to a void* */
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint="SDL_DelEventWatch")]
		public static extern void DelEventWatch(
			EventFilter filter,
			IntPtr userdata
		);

		/* userdata refers to a void* */
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint="SDL_FilterEvents")]
		public static extern void FilterEvents(
			EventFilter filter,
			IntPtr userdata
		);

		/* These are for EventState() */
		public const int QUERY = 		-1;
		public const int IGNORE = 		0;
		public const int DISABLE =		0;
		public const int ENABLE = 		1;

		/* This function allows you to enable/disable certain events */
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint="SDL_EventState")]
		public static extern byte EventState(EventType type, int state);

		/* Get the state of an event */
		public static byte GetEventState(EventType type)
		{
			return EventState(type, QUERY);
		}

		/* Allocate a set of user-defined events */
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint="SDL_RegisterEvents")]
		public static extern UInt32 RegisterEvents(int numevents);
		#endregion
    }
}
