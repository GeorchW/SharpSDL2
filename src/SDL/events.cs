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
			FirstEvent =		0,

			/* Application events */
			Quit = 			0x100,

			/* iOs/Android/WinRt app events */
			AppTerminating,
			AppLowMemory,
			AppWillEnterBackground,
			AppDidEnterBackground,
			AppWillEnterForeground,
			AppDidEnterForeground,

			/* Display events */
			/* Only available in Sdl 2.0.9 or higher */
			DisplayEvent =		0x150,

			/* Window events */
			WindowEvent = 		0x200,
			SyswmEvent,

			/* Keyboard events */
			KeyDown = 			0x300,
			KeyUp,
			TextEditing,
			TextInput,
			KeymapChanged,

			/* Mouse events */
			MouseMotion = 		0x400,
			MouseButtonDown,
			MouseButtonUp,
			MouseWheel,

			/* Joystick events */
			JoyAxisMotion =		0x600,
			JoyBallMotion,
			JoyHatMotion,
			JoyButtonDown,
			JoyButtonUp,
			JoyDeviceAdded,
			JoyDeviceRemoved,

			/* Game controller events */
			ControllerAxisMotion = 	0x650,
			ControllerButtonDown,
			ControllerButtonUp,
			ControllerDeviceAdded,
			ControllerDeviceRemoved,
			ControllerDeviceRemapped,

			/* Touch events */
			FingerDown = 		0x700,
			FingerUp,
			FingerMotion,

			/* Gesture events */
			DollarGesture =		0x800,
			DollarRecord,
			MultiGesture,

			/* Clipboard events */
			ClipboardUpdate =		0x900,

			/* Drag and drop events */
			DropFile =			0x1000,
			/* Only available in 2.0.4 or higher */
			DropText,
			DropBegin,
			DropComplete,

			/* Audio hotplug events */
			/* Only available in Sdl 2.0.4 or higher */
			AudioDeviceAdded =		0x1100,
			AudioDeviceRemoved,

			/* Sensor events */
			/* Only available in Sdl 2.0.9 or higher */
			SensorUpdate =		0x1200,

			/* Render events */
			/* Only available in Sdl 2.0.2 or higher */
			RenderTargetsReset =	0x2000,
			/* Only available in Sdl 2.0.4 or higher */
			RenderDeviceReset,

			/* Events Userevent through Lastevent are for
			 * your use, and should be allocated with
			 * RegisterEvents()
			 */
			UserEvent =			0x8000,

			/* The last event, used for bouding arrays. */
			LastEvent =			0xFfff
		}

		/* Only available in 2.0.4 or higher */
		public enum MouseWheelDirection : uint
		{
			Normal,
			Flipped
		}

		/* Fields shared by every event */
		[StructLayout(LayoutKind.Sequential)]
		public struct GenericEvent
		{
			public EventType Type;
			public UInt32 Timestamp;
		}

// Ignore private members used for padding in this struct
#pragma warning disable 0169
		[StructLayout(LayoutKind.Sequential)]
		public struct DisplayEvent
		{
			public EventType Type;
			public UInt32 Timestamp;
			public UInt32 Display;
			public DisplayEventID Event;
			private byte padding1;
			private byte padding2;
			private byte padding3;
			public Int32 Data1;
		}
#pragma warning restore 0169

// Ignore private members used for padding in this struct
#pragma warning disable 0169
		/* Window state change event data (event.window.*) */
		[StructLayout(LayoutKind.Sequential)]
		public struct WindowEvent
		{
			public EventType Type;
			public UInt32 Timestamp;
			public UInt32 WindowID;
			public WindowEventID Event;
			private byte padding1;
			private byte padding2;
			private byte padding3;
			public Int32 Data1;
			public Int32 Data2;
		}
#pragma warning restore 0169

// Ignore private members used for padding in this struct
#pragma warning disable 0169
		/* Keyboard button event structure (event.key.*) */
		[StructLayout(LayoutKind.Sequential)]
		public struct KeyboardEvent
		{
			public EventType Type;
			public UInt32 Timestamp;
			public UInt32 WindowID;
			public byte State;
			///<summary> non-zero if this is a repeat </summary>

			public byte Repeat;
			private byte padding2;
			private byte padding3;
			public Keysym Keysym;
		}
#pragma warning restore 0169

		[StructLayout(LayoutKind.Sequential)]
		public unsafe struct TextEditingEvent
		{
			public EventType Type;
			public UInt32 Timestamp;
			public UInt32 WindowID;
			public fixed byte text[TEXTEDITINGEVENT_TEXT_SIZE];
			public Int32 Start;
			public Int32 Length;
		}

		[StructLayout(LayoutKind.Sequential)]
		public unsafe struct TextInputEvent
		{
			public EventType Type;
			public UInt32 Timestamp;
			public UInt32 WindowID;
			public fixed byte text[TEXTINPUTEVENT_TEXT_SIZE];
		}

// Ignore private members used for padding in this struct
#pragma warning disable 0169
		/* Mouse motion event structure (event.motion.*) */
		[StructLayout(LayoutKind.Sequential)]
		public struct MouseMotionEvent
		{
			public EventType Type;
			public UInt32 Timestamp;
			public UInt32 WindowID;
			public UInt32 Which;
			///<summary> bitmask of buttons </summary>
			public byte State;
			private byte padding1;
			private byte padding2;
			private byte padding3;
			public Int32 X;
			public Int32 Y;
			public Int32 Xrel;
			public Int32 Yrel;
		}
#pragma warning restore 0169

// Ignore private members used for padding in this struct
#pragma warning disable 0169
		/* Mouse button event structure (event.button.*) */
		[StructLayout(LayoutKind.Sequential)]
		public struct MouseButtonEvent
		{
			public EventType Type;
			public UInt32 Timestamp;
			public UInt32 WindowID;
			public UInt32 Which;
			///<summary> button id </summary>
			public byte Button;
			///<summary> PRESSED or RELEASED </summary>
			public byte State;
			///<summary> 1 for single-click, 2 for double-click, etc. </summary>
			public byte Clicks;
			private byte padding1;
			public Int32 X;
			public Int32 Y;
		}
#pragma warning restore 0169

		/* Mouse wheel event structure (event.wheel.*) */
		[StructLayout(LayoutKind.Sequential)]
		public struct MouseWheelEvent
		{
			public EventType Type;
			public UInt32 Timestamp;
			public UInt32 WindowID;
			public UInt32 Which;
			///<summary> amount scrolled horizontally </summary>
			public Int32 X;
			///<summary> amount scrolled vertically </summary>
			public Int32 Y;
			///<summary> Set to one of the MOUSEWHEEL_* defines </summary>
			public UInt32 Direction;
		}

// Ignore private members used for padding in this struct
#pragma warning disable 0169
		/* Joystick axis motion event structure (event.jaxis.*) */
		[StructLayout(LayoutKind.Sequential)]
		public struct JoyAxisEvent
		{
			public EventType Type;
			public UInt32 Timestamp;
			///<summary> JoystickID </summary>
			public Int32 Which;
			public byte Axis;
			private byte padding1;
			private byte padding2;
			private byte padding3;
			public Int16 Value;
			public UInt16 Padding4;
		}
#pragma warning restore 0169

// Ignore private members used for padding in this struct
#pragma warning disable 0169
		/* Joystick trackball motion event structure (event.jball.*) */
		[StructLayout(LayoutKind.Sequential)]
		public struct JoyBallEvent
		{
			public EventType Type;
			public UInt32 Timestamp;
			///<summary> JoystickID </summary>
			public Int32 Which;
			public byte Ball;
			private byte padding1;
			private byte padding2;
			private byte padding3;
			public Int16 Xrel;
			public Int16 Yrel;
		}
#pragma warning restore 0169

// Ignore private members used for padding in this struct
#pragma warning disable 0169
		/* Joystick hat position change event struct (event.jhat.*) */
		[StructLayout(LayoutKind.Sequential)]
		public struct JoyHatEvent
		{
			public EventType Type;
			public UInt32 Timestamp;
			///<summary> JoystickID </summary>
			public Int32 Which;
			///<summary> index of the hat </summary>
			public byte Hat;
			public byte Value;
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
			public EventType Type;
			public UInt32 Timestamp;
			///<summary> JoystickID </summary>
			public Int32 Which;
			public byte Button;
			///<summary> PRESSED or RELEASED </summary>
			public byte State;
			private byte padding1;
			private byte padding2;
		}
#pragma warning restore 0169

		/* Joystick device event structure (event.jdevice.*) */
		[StructLayout(LayoutKind.Sequential)]
		public struct JoyDeviceEvent
		{
			public EventType Type;
			public UInt32 Timestamp;
			///<summary> JoystickID </summary>
			public Int32 Which;
		}

// Ignore private members used for padding in this struct
#pragma warning disable 0169
		/* Game controller axis motion event (event.caxis.*) */
		[StructLayout(LayoutKind.Sequential)]
		public struct ControllerAxisEvent
		{
			public EventType Type;
			public UInt32 Timestamp;
			///<summary> JoystickID </summary>
			public Int32 Which;
			public byte Axis;
			private byte padding1;
			private byte padding2;
			private byte padding3;
			public Int16 Value;
			private UInt16 padding4;
		}
#pragma warning restore 0169

// Ignore private members used for padding in this struct
#pragma warning disable 0169
		/* Game controller button event (event.cbutton.*) */
		[StructLayout(LayoutKind.Sequential)]
		public struct ControllerButtonEvent
		{
			public EventType Type;
			public UInt32 Timestamp;
			///<summary> JoystickID </summary>
			public Int32 Which;
			public byte Button;
			public byte State;
			private byte padding1;
			private byte padding2;
		}
#pragma warning restore 0169

		/* Game controller device event (event.cdevice.*) */
		[StructLayout(LayoutKind.Sequential)]
		public struct ControllerDeviceEvent
		{
			public EventType Type;
			public UInt32 Timestamp;
			/// <summary>joystick id for ADDED, else instance id</summary>
			public Int32 Which;
		}

// Ignore private members used for padding in this struct
#pragma warning disable 0169
		/* Audio device event (event.adevice.*) */
		[StructLayout(LayoutKind.Sequential)]
		public struct AudioDeviceEvent
		{
			public UInt32 Type;
			public UInt32 Timestamp;
			public UInt32 Which;
			public byte IsCapture;
			private byte padding1;
			private byte padding2;
			private byte padding3;
		}
#pragma warning restore 0169

		[StructLayout(LayoutKind.Sequential)]
		public struct TouchFingerEvent
		{
			public UInt32 Type;
			public UInt32 Timestamp;
			public Int64 TouchId; // TouchID
			public Int64 FingerId; // GestureID
			public float X;
			public float Y;
			public float Dx;
			public float Dy;
			public float Pressure;
		}

		[StructLayout(LayoutKind.Sequential)]
		public struct MultiGestureEvent
		{
			public UInt32 Type;
			public UInt32 Timestamp;
			public Int64 TouchId; // TouchID
			public float DTheta;
			public float DDist;
			public float X;
			public float Y;
			public UInt16 NumFingers;
			public UInt16 Padding;
		}

		[StructLayout(LayoutKind.Sequential)]
		public struct DollarGestureEvent
		{
			public UInt32 Type;
			public UInt32 Timestamp;
			public Int64 TouchId; // TouchID
			public Int64 GestureId; // GestureID
			public UInt32 NumFingers;
			public float Error;
			public float X;
			public float Y;
		}

		/* File open request by system (event.drop.*), enabled by
		 * default
		 */
		[StructLayout(LayoutKind.Sequential)]
		public struct DropEvent
		{
			public EventType Type;
			public UInt32 Timestamp;

			/* char* filename, to be freed.
			 * Access the variable EXACTLY ONCE like this:
			 * string s = SDL.UTF8_ToManaged(evt.drop.file, true);
			 */
			public IntPtr File;
			public UInt32 WindowID;
		}

		[StructLayout(LayoutKind.Sequential)]
		public unsafe struct SensorEvent
		{
			public EventType Type;
			public UInt32 Timestamp;
			public Int32 Which;
			public fixed float data[6];
		}

		/* The "quit requested" event */
		[StructLayout(LayoutKind.Sequential)]
		public struct QuitEvent
		{
			public EventType Type;
			public UInt32 Timestamp;
		}

		/* A user defined event (event.user.*) */
		[StructLayout(LayoutKind.Sequential)]
		public struct UserEvent
		{
			public UInt32 Type;
			public UInt32 Timestamp;
			public UInt32 WindowID;
			public Int32 Code;
			///<summary> user-defined </summary>
			public IntPtr Data1;
			///<summary> user-defined </summary>
			public IntPtr Data2;
		}

		/* A video driver dependent event (event.syswm.*), disabled */
		[StructLayout(LayoutKind.Sequential)]
		public struct SysWMEvent
		{
			public EventType Type;
			public UInt32 Timestamp;
			///<summary> SysWMmsg*, system-dependent</summary>
			public IntPtr Msg;
		}

		/* General event structure */
		// C# doesn't do unions, so we do this ugly thing. */
		[StructLayout(LayoutKind.Explicit)]
		public struct Event
		{
			[FieldOffset(0)]
			public EventType Type;
			[FieldOffset(0)]
			public DisplayEvent Display;
			[FieldOffset(0)]
			public WindowEvent Window;
			[FieldOffset(0)]
			public KeyboardEvent Key;
			[FieldOffset(0)]
			public TextEditingEvent Edit;
			[FieldOffset(0)]
			public TextInputEvent Text;
			[FieldOffset(0)]
			public MouseMotionEvent Motion;
			[FieldOffset(0)]
			public MouseButtonEvent Button;
			[FieldOffset(0)]
			public MouseWheelEvent Wheel;
			[FieldOffset(0)]
			public JoyAxisEvent JAxis;
			[FieldOffset(0)]
			public JoyBallEvent JBall;
			[FieldOffset(0)]
			public JoyHatEvent JHat;
			[FieldOffset(0)]
			public JoyButtonEvent JButton;
			[FieldOffset(0)]
			public JoyDeviceEvent JDevice;
			[FieldOffset(0)]
			public ControllerAxisEvent CAxis;
			[FieldOffset(0)]
			public ControllerButtonEvent CButton;
			[FieldOffset(0)]
			public ControllerDeviceEvent CDevice;
			[FieldOffset(0)]
			public AudioDeviceEvent ADevice;
			[FieldOffset(0)]
			public SensorEvent Sensor;
			[FieldOffset(0)]
			public QuitEvent Quit;
			[FieldOffset(0)]
			public UserEvent User;
			[FieldOffset(0)]
			public SysWMEvent Syswm;
			[FieldOffset(0)]
			public TouchFingerEvent TFinger;
			[FieldOffset(0)]
			public MultiGestureEvent MGesture;
			[FieldOffset(0)]
			public DollarGestureEvent DGesture;
			[FieldOffset(0)]
			public DropEvent Drop;
		}

		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate int EventFilter(
			IntPtr userdata, // void*
			IntPtr sdlevent // Event* event, lolC#
		);

		/* Pump the event loop, getting events from the input devices*/
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint="SDL_PumpEvents")]
		public static extern void PumpEvents();

		public enum EventAction
		{
			Add,
			Peek,
			Get
		}

		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint="SDL_PeepEvents")]
		public static extern int PeepEvents(
			[Out] Event[] events,
			int numevents,
			EventAction action,
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
