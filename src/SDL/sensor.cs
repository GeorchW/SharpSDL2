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
    #region sensor.h

    /* This region is only available in 2.0.9 or higher. */

    public enum SensorType
    {
        Invalid = -1,
        Unknown,
        Accel,
        Gyro
    }

    public static partial class SDL
    {
        public const float StandardGravity = 9.80665f;

        /// <summary>
        /// Count the number of sensors attached to the system right now. 
        /// Gyroscope sensorThe gyroscope returns the current rate of rotation in radians per second. The rotation is positive in the counter-clockwise direction. That is, an observer looking from a positive location on one of the axes would see positive rotation on that axis when it appeared to be rotating counter-clockwise.values[0]: Angular speed around the x axis values[1]: Angular speed around the y axis values[2]: Angular speed around the z axisFor phones held in portrait mode, the axes are defined as follows: -X ... +X : left ... right -Y ... +Y : bottom ... top -Z ... +Z : farther ... closerThe axis data is not changed when the phone is rotated.
        /// </summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_NumSensors")]
        public static extern int NumSensors();

        /// <summary>
        /// Get the implementation dependent name of a sensor. 
        /// This can be called before any sensors are opened.
        /// </summary>
        [DllImport(nativeLibName, EntryPoint = "SDL_SensorGetDeviceName", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr INTERNAL_SensorGetDeviceName(int device_index);
        public static string SensorGetDeviceName(int device_index)
        {
            return UTF8_ToManaged(INTERNAL_SensorGetDeviceName(device_index));
        }

        /// <summary>
        /// Get the type of a sensor. 
        /// This can be called before any sensors are opened.
        /// </summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_SensorGetDeviceType")]
        public static extern SensorType SensorGetDeviceType(int device_index);

        /// <summary>
        /// Get the platform dependent type of a sensor. 
        /// This can be called before any sensors are opened.
        /// </summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_SensorGetDeviceNonPortableType")]
        public static extern int SensorGetDeviceNonPortableType(int device_index);

        /// <summary>
        /// Get the instance ID of a sensor. 
        /// This can be called before any sensors are opened.
        /// </summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_SensorGetDeviceInstanceID")]
        public static extern Int32 SensorGetDeviceInstanceID(int device_index);

        /* IntPtr refers to an Sensor* */
        /// <summary>
        /// Open a sensor for use. 
        /// The index passed as an argument refers to the N'th sensor on the system.
        /// 
        /// Binding info:
        /// IntPtr refers to an Sensor*
        /// </summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_SensorOpen")]
        public static extern IntPtr SensorOpen(int device_index);

        /* IntPtr refers to an Sensor* */
        /// <summary>
        /// Return the SDL_Sensor associated with an instance id.
        /// 
        /// Binding info:
        /// IntPtr refers to an Sensor*
        /// </summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_SensorFromInstanceID")]
        public static extern IntPtr SensorFromInstanceID(
            Int32 instance_id
        );

        /* sensor refers to an Sensor* */
        /// <summary>
        /// Get the implementation dependent name of a sensor.
        /// 
        /// Binding info:
        /// sensor refers to an Sensor*
        /// </summary>
        [DllImport(nativeLibName, EntryPoint = "SDL_SensorGetName", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr INTERNAL_SensorGetName(IntPtr sensor);
        public static string SensorGetName(IntPtr sensor)
        {
            return UTF8_ToManaged(INTERNAL_SensorGetName(sensor));
        }

        /* sensor refers to an Sensor* */
        /// <summary>
        /// Get the type of a sensor. 
        /// This can be called before any sensors are opened.
        /// 
        /// Binding info:
        /// sensor refers to an Sensor*
        /// </summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_SensorGetType")]
        public static extern SensorType SensorGetType(IntPtr sensor);

        /* sensor refers to an Sensor* */
        /// <summary>
        /// Get the platform dependent type of a sensor. 
        /// This can be called before any sensors are opened.
        /// 
        /// Binding info:
        /// sensor refers to an Sensor*
        /// </summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_SensorGetNonPortableType")]
        public static extern int SensorGetNonPortableType(IntPtr sensor);

        /* sensor refers to an Sensor* */
        /// <summary>
        /// Get the instance ID of a sensor. 
        /// This can be called before any sensors are opened.
        /// 
        /// Binding info:
        /// sensor refers to an Sensor*
        /// </summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_SensorGetInstanceID")]
        public static extern Int32 SensorGetInstanceID(IntPtr sensor);

        /* sensor refers to an Sensor* */
        /// <summary>
        /// Get the current state of an opened sensor.The number of values and interpretation of the data is sensor dependent.
        /// 
        /// Binding info:
        /// sensor refers to an Sensor*
        /// </summary>
        /// <param name="sensor">The sensor to query</param>
        /// <param name="data">A pointer filled with the current sensor state</param>
        /// <param name="num_values">The number of values to write to data</param>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_SensorGetData")]
        public static extern int SensorGetData(
            IntPtr sensor,
            float[] data,
            int num_values
        );

        /* sensor refers to an Sensor* */
        /// <summary>
        /// Close a sensor previously opened with
        /// 
        /// Binding info:
        /// sensor refers to an Sensor*
        /// </summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_SensorClose")]
        public static extern void SensorClose(IntPtr sensor);

        /// <summary>Update the current state of the open sensors.This is called automatically by the event loop if sensor events are enabled.This needs to be called from the thread that initialized the sensor subsystem.</summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_SensorUpdate")]
        public static extern void SensorUpdate();
    }
    #endregion
}
