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
    #region render.h
    [Flags]
    public enum RendererFlags : uint
    {
        Software = 0x00000001,
        Accelerated = 0x00000002,
        PresentVSync = 0x00000004,
        TargetTexture = 0x00000008
    }

    [Flags]
    public enum RendererFlip
    {
        None = 0x00000000,
        Horizontal = 0x00000001,
        Vertical = 0x00000002
    }

    public enum TextureAccess
    {
        Static,
        Streaming,
        Target
    }

    [Flags]
    public enum TextureModulate
    {
        None = 0x00000000,
        Horizontal = 0x00000001,
        Vertical = 0x00000002
    }

    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct RendererInfo
    {
        public IntPtr Name; // const char*
        public uint Flags;
        public uint NumTextureFormats;
        public fixed uint TextureFormats[16];
        public int MaxTextureWidth;
        public int MaxTextureHeight;
    }

    public static partial class SDL
    {
        /* IntPtr refers to an Renderer*, window to an Window* */
        /// <summary>
        /// Create a 2D rendering context for a window.
        /// 
        /// Binding info:
        /// IntPtr refers to an Renderer*, window to an Window*
        /// </summary>
        /// <param name="window">The window where rendering is displayed.</param>
        /// <param name="index">The index of the rendering driver to initialize, or -1 to initialize the first one supporting the requested flags.</param>
        /// <param name="flags">SDL_RendererFlags.</param>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_CreateRenderer")]
        public static extern IntPtr CreateRenderer(
            IntPtr window,
            int index,
            RendererFlags flags
        );

        /* IntPtr refers to an Renderer*, surface to an Surface* */
        /// <summary>
        /// Create a 2D software rendering context for a surface.
        /// 
        /// Binding info:
        /// IntPtr refers to an Renderer*, surface to an Surface*
        /// </summary>
        /// <param name="surface">The surface where rendering is done.</param>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_CreateSoftwareRenderer")]
        public static extern IntPtr CreateSoftwareRenderer(IntPtr surface);

        /* IntPtr refers to an Texture*, renderer to an Renderer* */
        /// <summary>
        /// Create a texture for a rendering context.
        /// 
        /// Binding info:
        /// IntPtr refers to an Texture*, renderer to an Renderer*
        /// </summary>
        /// <param name="renderer">The renderer.</param>
        /// <param name="format">The format of the texture.</param>
        /// <param name="access">One of the enumerated values in SDL_TextureAccess.</param>
        /// <param name="w">The width of the texture in pixels.</param>
        /// <param name="h">The height of the texture in pixels.</param>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_CreateTexture")]
        public static extern IntPtr CreateTexture(
            IntPtr renderer,
            uint format,
            int access,
            int w,
            int h
        );

        /* IntPtr refers to an Texture*
		 * renderer refers to an Renderer*
		 * surface refers to an Surface*
		 */
        /// <summary>
        /// Create a texture from an existing surface.
        /// 
        /// Binding info:
        /// IntPtr refers to an Texture*
        /// renderer refers to an Renderer*
        /// surface refers to an Surface*
        /// </summary>
        /// <param name="renderer">The renderer.</param>
        /// <param name="surface">The surface containing pixel data used to fill the texture.</param>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_CreateTextureFromSurface")]
        public static extern IntPtr CreateTextureFromSurface(
            IntPtr renderer,
            IntPtr surface
        );

        /* renderer refers to an Renderer* */
        /// <summary>
        /// Destroy the rendering context for a window and free associated textures.
        /// 
        /// Binding info:
        /// renderer refers to an Renderer*
        /// </summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_DestroyRenderer")]
        public static extern void DestroyRenderer(IntPtr renderer);

        /* texture refers to an Texture* */
        /// <summary>
        /// Destroy the specified texture.
        /// 
        /// Binding info:
        /// texture refers to an Texture*
        /// </summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_DestroyTexture")]
        public static extern void DestroyTexture(IntPtr texture);

        /// <summary>
        /// Get the number of 2D rendering drivers available for the current display. 
        /// A render driver is a set of code that handles rendering and texture management on a particular display. Normally there is only one, but some drivers may have several available with different capabilities.
        /// </summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetNumRenderDrivers")]
        public static extern int GetNumRenderDrivers();

        /* renderer refers to an Renderer* */
        /// <summary>
        /// Get the blend mode used for drawing operations.
        /// 
        /// Binding info:
        /// renderer refers to an Renderer*
        /// </summary>
        /// <param name="renderer">The renderer from which blend mode should be queried.</param>
        /// <param name="blendMode">A pointer filled in with the current blend mode.</param>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetRenderDrawBlendMode")]
        public static extern int GetRenderDrawBlendMode(
            IntPtr renderer,
            out BlendMode blendMode
        );

        /* renderer refers to an Renderer* */
        /// <summary>
        /// Get the color used for drawing operations (Rect, Line and Clear).
        /// 
        /// Binding info:
        /// renderer refers to an Renderer*
        /// </summary>
        /// <param name="renderer">The renderer from which drawing color should be queried.</param>
        /// <param name="r">A pointer to the red value used to draw on the rendering target.</param>
        /// <param name="g">A pointer to the green value used to draw on the rendering target.</param>
        /// <param name="b">A pointer to the blue value used to draw on the rendering target.</param>
        /// <param name="a">A pointer to the alpha value used to draw on the rendering target, usually SDL_ALPHA_OPAQUE (255).</param>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetRenderDrawColor")]
        public static extern int GetRenderDrawColor(
            IntPtr renderer,
            out byte r,
            out byte g,
            out byte b,
            out byte a
        );

        /// <summary>Get information about a specific 2D rendering driver for the current display.</summary>
        /// <param name="index">The index of the driver to query information about.</param>
        /// <param name="info">A pointer to an SDL_RendererInfo struct to be filled with information on the rendering driver.</param>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetRenderDriverInfo")]
        public static extern int GetRenderDriverInfo(
            int index,
            out RendererInfo info
        );

        /* IntPtr refers to an Renderer*, window to an Window* */
        /// <summary>
        /// Get the renderer associated with a window.
        /// 
        /// Binding info:
        /// IntPtr refers to an Renderer*, window to an Window*
        /// </summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetRenderer")]
        public static extern IntPtr GetRenderer(IntPtr window);

        /* renderer refers to an Renderer* */
        /// <summary>
        /// Get information about a rendering context.
        /// 
        /// Binding info:
        /// renderer refers to an Renderer*
        /// </summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetRendererInfo")]
        public static extern int GetRendererInfo(
            IntPtr renderer,
            out RendererInfo info
        );

        /* renderer refers to an Renderer* */
        /// <summary>
        /// Get the output size in pixels of a rendering context.
        /// 
        /// Binding info:
        /// renderer refers to an Renderer*
        /// </summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetRendererOutputSize")]
        public static extern int GetRendererOutputSize(
            IntPtr renderer,
            out int w,
            out int h
        );

        /* texture refers to an Texture* */
        /// <summary>
        /// Get the additional alpha value used in render copy operations.
        /// 
        /// Binding info:
        /// texture refers to an Texture*
        /// </summary>
        /// <param name="texture">The texture to query.</param>
        /// <param name="alpha">A pointer filled in with the current alpha value.</param>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetTextureAlphaMod")]
        public static extern int GetTextureAlphaMod(
            IntPtr texture,
            out byte alpha
        );

        /* texture refers to an Texture* */
        /// <summary>
        /// Get the blend mode used for texture copy operations.
        /// 
        /// Binding info:
        /// texture refers to an Texture*
        /// </summary>
        /// <param name="texture">The texture to query.</param>
        /// <param name="blendMode">A pointer filled in with the current blend mode.</param>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetTextureBlendMode")]
        public static extern int GetTextureBlendMode(
            IntPtr texture,
            out BlendMode blendMode
        );

        /* texture refers to an Texture* */
        /// <summary>
        /// Get the additional color value used in render copy operations.
        /// 
        /// Binding info:
        /// texture refers to an Texture*
        /// </summary>
        /// <param name="texture">The texture to query.</param>
        /// <param name="r">A pointer filled in with the current red color value.</param>
        /// <param name="g">A pointer filled in with the current green color value.</param>
        /// <param name="b">A pointer filled in with the current blue color value.</param>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetTextureColorMod")]
        public static extern int GetTextureColorMod(
            IntPtr texture,
            out byte r,
            out byte g,
            out byte b
        );

        /* texture refers to an Texture*, pixels to a void* */
        /// <summary>
        /// Lock a portion of the texture for write-only pixel access.
        /// 
        /// Binding info:
        /// texture refers to an Texture*, pixels to a void*
        /// </summary>
        /// <param name="texture">The texture to lock for access, which was created with SDL_TEXTUREACCESS_STREAMING.</param>
        /// <param name="rect">A pointer to the rectangle to lock for access. If the rect is NULL, the entire texture will be locked.</param>
        /// <param name="pixels">This is filled in with a pointer to the locked pixels, appropriately offset by the locked area.</param>
        /// <param name="pitch">This is filled in with the pitch of the locked pixels.</param>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_LockTexture")]
        public static extern int LockTexture(
            IntPtr texture,
            ref Rect rect,
            out IntPtr pixels,
            out int pitch
        );

        /* texture refers to an Texture*, pixels to a void*.
		 * Internally, this function contains logic to use default values when
		 * the rectangle is passed as NULL.
		 * This overload allows for IntPtr.Zero to be passed for rect.
		 */
        /// <summary>
        /// Lock a portion of the texture for write-only pixel access.
        /// 
        /// Binding info:
        /// texture refers to an Texture*, pixels to a void*.
        /// Internally, this function contains logic to use default values when
        /// the rectangle is passed as NULL.
        /// This overload allows for IntPtr.Zero to be passed for rect.
        /// </summary>
        /// <param name="texture">The texture to lock for access, which was created with SDL_TEXTUREACCESS_STREAMING.</param>
        /// <param name="rect">A pointer to the rectangle to lock for access. If the rect is NULL, the entire texture will be locked.</param>
        /// <param name="pixels">This is filled in with a pointer to the locked pixels, appropriately offset by the locked area.</param>
        /// <param name="pitch">This is filled in with the pitch of the locked pixels.</param>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_LockTexture")]
        public static extern int LockTexture(
            IntPtr texture,
            IntPtr rect,
            out IntPtr pixels,
            out int pitch
        );

        /* texture refers to an Texture* */
        /// <summary>
        /// Query the attributes of a texture.
        /// 
        /// Binding info:
        /// texture refers to an Texture*
        /// </summary>
        /// <param name="texture">A texture to be queried.</param>
        /// <param name="format">A pointer filled in with the raw format of the texture. The actual format may differ, but pixel transfers will use this format.</param>
        /// <param name="access">A pointer filled in with the actual access to the texture.</param>
        /// <param name="w">A pointer filled in with the width of the texture in pixels.</param>
        /// <param name="h">A pointer filled in with the height of the texture in pixels.</param>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_QueryTexture")]
        public static extern int QueryTexture(
            IntPtr texture,
            out uint format,
            out int access,
            out int w,
            out int h
        );

        /* renderer refers to an Renderer* */
        /// <summary>
        /// Clear the current rendering target with the drawing color. 
        /// This function clears the entire rendering target, ignoring the viewport and the clip rectangle.
        /// 
        /// Binding info:
        /// renderer refers to an Renderer*
        /// </summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_RenderClear")]
        public static extern int RenderClear(IntPtr renderer);

        /* renderer refers to an Renderer*, texture to an Texture* */
        /// <summary>
        /// Copy a portion of the texture to the current rendering target.
        /// 
        /// Binding info:
        /// renderer refers to an Renderer*, texture to an Texture*
        /// </summary>
        /// <param name="renderer">The renderer which should copy parts of a texture.</param>
        /// <param name="texture">The source texture.</param>
        /// <param name="srcrect">A pointer to the source rectangle, or NULL for the entire texture.</param>
        /// <param name="dstrect">A pointer to the destination rectangle, or NULL for the entire rendering target.</param>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_RenderCopy")]
        public static extern int RenderCopy(
            IntPtr renderer,
            IntPtr texture,
            ref Rect srcrect,
            ref Rect dstrect
        );

        /* renderer refers to an Renderer*, texture to an Texture*.
		 * Internally, this function contains logic to use default values when
		 * source and destination rectangles are passed as NULL.
		 * This overload allows for IntPtr.Zero (null) to be passed for srcrect.
		 */
        /// <summary>
        /// Copy a portion of the texture to the current rendering target.
        /// 
        /// Binding info:
        /// renderer refers to an Renderer*, texture to an Texture*.
        /// Internally, this function contains logic to use default values when
        /// source and destination rectangles are passed as NULL.
        /// This overload allows for IntPtr.Zero (null) to be passed for srcrect.
        /// </summary>
        /// <param name="renderer">The renderer which should copy parts of a texture.</param>
        /// <param name="texture">The source texture.</param>
        /// <param name="srcrect">A pointer to the source rectangle, or NULL for the entire texture.</param>
        /// <param name="dstrect">A pointer to the destination rectangle, or NULL for the entire rendering target.</param>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_RenderCopy")]
        public static extern int RenderCopy(
            IntPtr renderer,
            IntPtr texture,
            IntPtr srcrect,
            ref Rect dstrect
        );

        /* renderer refers to an Renderer*, texture to an Texture*.
		 * Internally, this function contains logic to use default values when
		 * source and destination rectangles are passed as NULL.
		 * This overload allows for IntPtr.Zero (null) to be passed for dstrect.
		 */
        /// <summary>
        /// Copy a portion of the texture to the current rendering target.
        /// 
        /// Binding info:
        /// renderer refers to an Renderer*, texture to an Texture*.
        /// Internally, this function contains logic to use default values when
        /// source and destination rectangles are passed as NULL.
        /// This overload allows for IntPtr.Zero (null) to be passed for dstrect.
        /// </summary>
        /// <param name="renderer">The renderer which should copy parts of a texture.</param>
        /// <param name="texture">The source texture.</param>
        /// <param name="srcrect">A pointer to the source rectangle, or NULL for the entire texture.</param>
        /// <param name="dstrect">A pointer to the destination rectangle, or NULL for the entire rendering target.</param>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_RenderCopy")]
        public static extern int RenderCopy(
            IntPtr renderer,
            IntPtr texture,
            ref Rect srcrect,
            IntPtr dstrect
        );

        /* renderer refers to an Renderer*, texture to an Texture*.
		 * Internally, this function contains logic to use default values when
		 * source and destination rectangles are passed as NULL.
		 * This overload allows for IntPtr.Zero (null) to be passed for both Rects.
		 */
        /// <summary>
        /// Copy a portion of the texture to the current rendering target.
        /// 
        /// Binding info:
        /// renderer refers to an Renderer*, texture to an Texture*.
        /// Internally, this function contains logic to use default values when
        /// source and destination rectangles are passed as NULL.
        /// This overload allows for IntPtr.Zero (null) to be passed for both Rects.
        /// </summary>
        /// <param name="renderer">The renderer which should copy parts of a texture.</param>
        /// <param name="texture">The source texture.</param>
        /// <param name="srcrect">A pointer to the source rectangle, or NULL for the entire texture.</param>
        /// <param name="dstrect">A pointer to the destination rectangle, or NULL for the entire rendering target.</param>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_RenderCopy")]
        public static extern int RenderCopy(
            IntPtr renderer,
            IntPtr texture,
            IntPtr srcrect,
            IntPtr dstrect
        );

        /* renderer refers to an Renderer*, texture to an Texture* */
        /// <summary>
        /// Copy a portion of the source texture to the current rendering target, rotating it by angle around the given center.
        /// 
        /// Binding info:
        /// renderer refers to an Renderer*, texture to an Texture*
        /// </summary>
        /// <param name="renderer">The renderer which should copy parts of a texture.</param>
        /// <param name="texture">The source texture.</param>
        /// <param name="srcrect">A pointer to the source rectangle, or NULL for the entire texture.</param>
        /// <param name="dstrect">A pointer to the destination rectangle, or NULL for the entire rendering target.</param>
        /// <param name="angle">An angle in degrees that indicates the rotation that will be applied to dstrect, rotating it in a clockwise direction</param>
        /// <param name="center">A pointer to a point indicating the point around which dstrect will be rotated (if NULL, rotation will be done around dstrect.w/2, dstrect.h/2).</param>
        /// <param name="flip">An SDL_RendererFlip value stating which flipping actions should be performed on the texture</param>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_RenderCopyEx")]
        public static extern int RenderCopyEx(
            IntPtr renderer,
            IntPtr texture,
            ref Rect srcrect,
            ref Rect dstrect,
            double angle,
            ref Point center,
            RendererFlip flip
        );

        /* renderer refers to an Renderer*, texture to an Texture*.
		 * Internally, this function contains logic to use default values when
		 * source, destination, and/or center are passed as NULL.
		 * This overload allows for IntPtr.Zero (null) to be passed for srcrect.
		 */
        /// <summary>
        /// Copy a portion of the source texture to the current rendering target, rotating it by angle around the given center.
        /// 
        /// Binding info:
        /// renderer refers to an Renderer*, texture to an Texture*.
        /// Internally, this function contains logic to use default values when
        /// source, destination, and/or center are passed as NULL.
        /// This overload allows for IntPtr.Zero (null) to be passed for srcrect.
        /// </summary>
        /// <param name="renderer">The renderer which should copy parts of a texture.</param>
        /// <param name="texture">The source texture.</param>
        /// <param name="srcrect">A pointer to the source rectangle, or NULL for the entire texture.</param>
        /// <param name="dstrect">A pointer to the destination rectangle, or NULL for the entire rendering target.</param>
        /// <param name="angle">An angle in degrees that indicates the rotation that will be applied to dstrect, rotating it in a clockwise direction</param>
        /// <param name="center">A pointer to a point indicating the point around which dstrect will be rotated (if NULL, rotation will be done around dstrect.w/2, dstrect.h/2).</param>
        /// <param name="flip">An SDL_RendererFlip value stating which flipping actions should be performed on the texture</param>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_RenderCopyEx")]
        public static extern int RenderCopyEx(
            IntPtr renderer,
            IntPtr texture,
            IntPtr srcrect,
            ref Rect dstrect,
            double angle,
            ref Point center,
            RendererFlip flip
        );

        /* renderer refers to an Renderer*, texture to an Texture*.
		 * Internally, this function contains logic to use default values when
		 * source, destination, and/or center are passed as NULL.
		 * This overload allows for IntPtr.Zero (null) to be passed for dstrect.
		 */
        /// <summary>
        /// Copy a portion of the source texture to the current rendering target, rotating it by angle around the given center.
        /// 
        /// Binding info:
        /// renderer refers to an Renderer*, texture to an Texture*.
        /// Internally, this function contains logic to use default values when
        /// source, destination, and/or center are passed as NULL.
        /// This overload allows for IntPtr.Zero (null) to be passed for dstrect.
        /// </summary>
        /// <param name="renderer">The renderer which should copy parts of a texture.</param>
        /// <param name="texture">The source texture.</param>
        /// <param name="srcrect">A pointer to the source rectangle, or NULL for the entire texture.</param>
        /// <param name="dstrect">A pointer to the destination rectangle, or NULL for the entire rendering target.</param>
        /// <param name="angle">An angle in degrees that indicates the rotation that will be applied to dstrect, rotating it in a clockwise direction</param>
        /// <param name="center">A pointer to a point indicating the point around which dstrect will be rotated (if NULL, rotation will be done around dstrect.w/2, dstrect.h/2).</param>
        /// <param name="flip">An SDL_RendererFlip value stating which flipping actions should be performed on the texture</param>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_RenderCopyEx")]
        public static extern int RenderCopyEx(
            IntPtr renderer,
            IntPtr texture,
            ref Rect srcrect,
            IntPtr dstrect,
            double angle,
            ref Point center,
            RendererFlip flip
        );

        /* renderer refers to an Renderer*, texture to an Texture*.
		 * Internally, this function contains logic to use default values when
		 * source, destination, and/or center are passed as NULL.
		 * This overload allows for IntPtr.Zero (null) to be passed for center.
		 */
        /// <summary>
        /// Copy a portion of the source texture to the current rendering target, rotating it by angle around the given center.
        /// 
        /// Binding info:
        /// renderer refers to an Renderer*, texture to an Texture*.
        /// Internally, this function contains logic to use default values when
        /// source, destination, and/or center are passed as NULL.
        /// This overload allows for IntPtr.Zero (null) to be passed for center.
        /// </summary>
        /// <param name="renderer">The renderer which should copy parts of a texture.</param>
        /// <param name="texture">The source texture.</param>
        /// <param name="srcrect">A pointer to the source rectangle, or NULL for the entire texture.</param>
        /// <param name="dstrect">A pointer to the destination rectangle, or NULL for the entire rendering target.</param>
        /// <param name="angle">An angle in degrees that indicates the rotation that will be applied to dstrect, rotating it in a clockwise direction</param>
        /// <param name="center">A pointer to a point indicating the point around which dstrect will be rotated (if NULL, rotation will be done around dstrect.w/2, dstrect.h/2).</param>
        /// <param name="flip">An SDL_RendererFlip value stating which flipping actions should be performed on the texture</param>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_RenderCopyEx")]
        public static extern int RenderCopyEx(
            IntPtr renderer,
            IntPtr texture,
            ref Rect srcrect,
            ref Rect dstrect,
            double angle,
            IntPtr center,
            RendererFlip flip
        );

        /* renderer refers to an Renderer*, texture to an Texture*.
		 * Internally, this function contains logic to use default values when
		 * source, destination, and/or center are passed as NULL.
		 * This overload allows for IntPtr.Zero (null) to be passed for both
		 * srcrect and dstrect.
		 */
        /// <summary>
        /// Copy a portion of the source texture to the current rendering target, rotating it by angle around the given center.
        /// 
        /// Binding info:
        /// renderer refers to an Renderer*, texture to an Texture*.
        /// Internally, this function contains logic to use default values when
        /// source, destination, and/or center are passed as NULL.
        /// This overload allows for IntPtr.Zero (null) to be passed for both
        /// srcrect and dstrect.
        /// </summary>
        /// <param name="renderer">The renderer which should copy parts of a texture.</param>
        /// <param name="texture">The source texture.</param>
        /// <param name="srcrect">A pointer to the source rectangle, or NULL for the entire texture.</param>
        /// <param name="dstrect">A pointer to the destination rectangle, or NULL for the entire rendering target.</param>
        /// <param name="angle">An angle in degrees that indicates the rotation that will be applied to dstrect, rotating it in a clockwise direction</param>
        /// <param name="center">A pointer to a point indicating the point around which dstrect will be rotated (if NULL, rotation will be done around dstrect.w/2, dstrect.h/2).</param>
        /// <param name="flip">An SDL_RendererFlip value stating which flipping actions should be performed on the texture</param>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_RenderCopyEx")]
        public static extern int RenderCopyEx(
            IntPtr renderer,
            IntPtr texture,
            IntPtr srcrect,
            IntPtr dstrect,
            double angle,
            ref Point center,
            RendererFlip flip
        );

        /* renderer refers to an Renderer*, texture to an Texture*.
		 * Internally, this function contains logic to use default values when
		 * source, destination, and/or center are passed as NULL.
		 * This overload allows for IntPtr.Zero (null) to be passed for both
		 * srcrect and center.
		 */
        /// <summary>
        /// Copy a portion of the source texture to the current rendering target, rotating it by angle around the given center.
        /// 
        /// Binding info:
        /// renderer refers to an Renderer*, texture to an Texture*.
        /// Internally, this function contains logic to use default values when
        /// source, destination, and/or center are passed as NULL.
        /// This overload allows for IntPtr.Zero (null) to be passed for both
        /// srcrect and center.
        /// </summary>
        /// <param name="renderer">The renderer which should copy parts of a texture.</param>
        /// <param name="texture">The source texture.</param>
        /// <param name="srcrect">A pointer to the source rectangle, or NULL for the entire texture.</param>
        /// <param name="dstrect">A pointer to the destination rectangle, or NULL for the entire rendering target.</param>
        /// <param name="angle">An angle in degrees that indicates the rotation that will be applied to dstrect, rotating it in a clockwise direction</param>
        /// <param name="center">A pointer to a point indicating the point around which dstrect will be rotated (if NULL, rotation will be done around dstrect.w/2, dstrect.h/2).</param>
        /// <param name="flip">An SDL_RendererFlip value stating which flipping actions should be performed on the texture</param>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_RenderCopyEx")]
        public static extern int RenderCopyEx(
            IntPtr renderer,
            IntPtr texture,
            IntPtr srcrect,
            ref Rect dstrect,
            double angle,
            IntPtr center,
            RendererFlip flip
        );

        /* renderer refers to an Renderer*, texture to an Texture*.
		 * Internally, this function contains logic to use default values when
		 * source, destination, and/or center are passed as NULL.
		 * This overload allows for IntPtr.Zero (null) to be passed for both
		 * dstrect and center.
		 */
        /// <summary>
        /// Copy a portion of the source texture to the current rendering target, rotating it by angle around the given center.
        /// 
        /// Binding info:
        /// renderer refers to an Renderer*, texture to an Texture*.
        /// Internally, this function contains logic to use default values when
        /// source, destination, and/or center are passed as NULL.
        /// This overload allows for IntPtr.Zero (null) to be passed for both
        /// dstrect and center.
        /// </summary>
        /// <param name="renderer">The renderer which should copy parts of a texture.</param>
        /// <param name="texture">The source texture.</param>
        /// <param name="srcrect">A pointer to the source rectangle, or NULL for the entire texture.</param>
        /// <param name="dstrect">A pointer to the destination rectangle, or NULL for the entire rendering target.</param>
        /// <param name="angle">An angle in degrees that indicates the rotation that will be applied to dstrect, rotating it in a clockwise direction</param>
        /// <param name="center">A pointer to a point indicating the point around which dstrect will be rotated (if NULL, rotation will be done around dstrect.w/2, dstrect.h/2).</param>
        /// <param name="flip">An SDL_RendererFlip value stating which flipping actions should be performed on the texture</param>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_RenderCopyEx")]
        public static extern int RenderCopyEx(
            IntPtr renderer,
            IntPtr texture,
            ref Rect srcrect,
            IntPtr dstrect,
            double angle,
            IntPtr center,
            RendererFlip flip
        );

        /* renderer refers to an Renderer*, texture to an Texture*.
		 * Internally, this function contains logic to use default values when
		 * source, destination, and/or center are passed as NULL.
		 * This overload allows for IntPtr.Zero (null) to be passed for all
		 * three parameters.
		 */
        /// <summary>
        /// Copy a portion of the source texture to the current rendering target, rotating it by angle around the given center.
        /// 
        /// Binding info:
        /// renderer refers to an Renderer*, texture to an Texture*.
        /// Internally, this function contains logic to use default values when
        /// source, destination, and/or center are passed as NULL.
        /// This overload allows for IntPtr.Zero (null) to be passed for all
        /// three parameters.
        /// </summary>
        /// <param name="renderer">The renderer which should copy parts of a texture.</param>
        /// <param name="texture">The source texture.</param>
        /// <param name="srcrect">A pointer to the source rectangle, or NULL for the entire texture.</param>
        /// <param name="dstrect">A pointer to the destination rectangle, or NULL for the entire rendering target.</param>
        /// <param name="angle">An angle in degrees that indicates the rotation that will be applied to dstrect, rotating it in a clockwise direction</param>
        /// <param name="center">A pointer to a point indicating the point around which dstrect will be rotated (if NULL, rotation will be done around dstrect.w/2, dstrect.h/2).</param>
        /// <param name="flip">An SDL_RendererFlip value stating which flipping actions should be performed on the texture</param>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_RenderCopyEx")]
        public static extern int RenderCopyEx(
            IntPtr renderer,
            IntPtr texture,
            IntPtr srcrect,
            IntPtr dstrect,
            double angle,
            IntPtr center,
            RendererFlip flip
        );

        /* renderer refers to an Renderer* */
        /// <summary>
        /// Draw a line on the current rendering target.
        /// 
        /// Binding info:
        /// renderer refers to an Renderer*
        /// </summary>
        /// <param name="renderer">The renderer which should draw a line.</param>
        /// <param name="x1">The x coordinate of the start point.</param>
        /// <param name="y1">The y coordinate of the start point.</param>
        /// <param name="x2">The x coordinate of the end point.</param>
        /// <param name="y2">The y coordinate of the end point.</param>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_RenderDrawLine")]
        public static extern int RenderDrawLine(
            IntPtr renderer,
            int x1,
            int y1,
            int x2,
            int y2
        );

        /* renderer refers to an Renderer* */
        /// <summary>
        /// Draw a series of connected lines on the current rendering target.
        /// 
        /// Binding info:
        /// renderer refers to an Renderer*
        /// </summary>
        /// <param name="renderer">The renderer which should draw multiple lines.</param>
        /// <param name="points">The points along the lines</param>
        /// <param name="count">The number of points, drawing count-1 lines</param>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_RenderDrawLines")]
        public static extern int RenderDrawLines(
            IntPtr renderer,
            [In] Point[] points,
            int count
        );

        /* renderer refers to an Renderer* */
        /// <summary>
        /// Draw a point on the current rendering target.
        /// 
        /// Binding info:
        /// renderer refers to an Renderer*
        /// </summary>
        /// <param name="renderer">The renderer which should draw a point.</param>
        /// <param name="x">The x coordinate of the point.</param>
        /// <param name="y">The y coordinate of the point.</param>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_RenderDrawPoint")]
        public static extern int RenderDrawPoint(
            IntPtr renderer,
            int x,
            int y
        );

        /* renderer refers to an Renderer* */
        /// <summary>
        /// Draw multiple points on the current rendering target.
        /// 
        /// Binding info:
        /// renderer refers to an Renderer*
        /// </summary>
        /// <param name="renderer">The renderer which should draw multiple points.</param>
        /// <param name="points">The points to draw</param>
        /// <param name="count">The number of points to draw</param>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_RenderDrawPoints")]
        public static extern int RenderDrawPoints(
            IntPtr renderer,
            [In] Point[] points,
            int count
        );

        /* renderer refers to an Renderer* */
        /// <summary>
        /// Draw a rectangle on the current rendering target.
        /// 
        /// Binding info:
        /// renderer refers to an Renderer*
        /// </summary>
        /// <param name="renderer">The renderer which should draw a rectangle.</param>
        /// <param name="rect">A pointer to the destination rectangle, or NULL to outline the entire rendering target.</param>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_RenderDrawRect")]
        public static extern int RenderDrawRect(
            IntPtr renderer,
            ref Rect rect
        );

        /* renderer refers to an Renderer*, rect to an Rect*.
		 * This overload allows for IntPtr.Zero (null) to be passed for rect.
		 */
        /// <summary>
        /// Draw a rectangle on the current rendering target.
        /// 
        /// Binding info:
        /// renderer refers to an Renderer*, rect to an Rect*.
        /// This overload allows for IntPtr.Zero (null) to be passed for rect.
        /// </summary>
        /// <param name="renderer">The renderer which should draw a rectangle.</param>
        /// <param name="rect">A pointer to the destination rectangle, or NULL to outline the entire rendering target.</param>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_RenderDrawRect")]
        public static extern int RenderDrawRect(
            IntPtr renderer,
            IntPtr rect
        );

        /* renderer refers to an Renderer* */
        /// <summary>
        /// Draw some number of rectangles on the current rendering target.
        /// 
        /// Binding info:
        /// renderer refers to an Renderer*
        /// </summary>
        /// <param name="renderer">The renderer which should draw multiple rectangles.</param>
        /// <param name="rects">A pointer to an array of destination rectangles.</param>
        /// <param name="count">The number of rectangles.</param>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_RenderDrawRects")]
        public static extern int RenderDrawRects(
            IntPtr renderer,
            [In] Rect[] rects,
            int count
        );

        /* renderer refers to an Renderer* */
        /// <summary>
        /// Fill a rectangle on the current rendering target with the drawing color.
        /// 
        /// Binding info:
        /// renderer refers to an Renderer*
        /// </summary>
        /// <param name="renderer">The renderer which should fill a rectangle.</param>
        /// <param name="rect">A pointer to the destination rectangle, or NULL for the entire rendering target.</param>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_RenderFillRect")]
        public static extern int RenderFillRect(
            IntPtr renderer,
            ref Rect rect
        );

        /* renderer refers to an Renderer*, rect to an Rect*.
		 * This overload allows for IntPtr.Zero (null) to be passed for rect.
		 */
        /// <summary>
        /// Fill a rectangle on the current rendering target with the drawing color.
        /// 
        /// Binding info:
        /// renderer refers to an Renderer*, rect to an Rect*.
        /// This overload allows for IntPtr.Zero (null) to be passed for rect.
        /// </summary>
        /// <param name="renderer">The renderer which should fill a rectangle.</param>
        /// <param name="rect">A pointer to the destination rectangle, or NULL for the entire rendering target.</param>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_RenderFillRect")]
        public static extern int RenderFillRect(
            IntPtr renderer,
            IntPtr rect
        );

        /* renderer refers to an Renderer* */
        /// <summary>
        /// Fill some number of rectangles on the current rendering target with the drawing color.
        /// 
        /// Binding info:
        /// renderer refers to an Renderer*
        /// </summary>
        /// <param name="renderer">The renderer which should fill multiple rectangles.</param>
        /// <param name="rects">A pointer to an array of destination rectangles.</param>
        /// <param name="count">The number of rectangles.</param>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_RenderFillRects")]
        public static extern int RenderFillRects(
            IntPtr renderer,
            [In] Rect[] rects,
            int count
        );

        /* This region only available in SDL 2.0.10 or higher. */

        /* renderer refers to an Renderer*, texture to an Texture* */
        /// <summary>
        /// Copy a portion of the texture to the current rendering target.
        /// 
        /// Binding info:
        /// renderer refers to an Renderer*, texture to an Texture*
        /// </summary>
        /// <param name="renderer">The renderer which should copy parts of a texture.</param>
        /// <param name="texture">The source texture.</param>
        /// <param name="srcrect">A pointer to the source rectangle, or NULL for the entire texture.</param>
        /// <param name="dstrect">A pointer to the destination rectangle, or NULL for the entire rendering target.</param>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_RenderCopyF")]
        public static extern int RenderCopyF(
            IntPtr renderer,
            IntPtr texture,
            ref Rect srcrect,
            ref FRect dstrect
        );

        /* renderer refers to an Renderer*, texture to an Texture*.
		 * Internally, this function contains logic to use default values when
		 * source and destination rectangles are passed as NULL.
		 * This overload allows for IntPtr.Zero (null) to be passed for srcrect.
		 */
        /// <summary>
        /// Copy a portion of the texture to the current rendering target.
        /// 
        /// Binding info:
        /// renderer refers to an Renderer*, texture to an Texture*.
        /// Internally, this function contains logic to use default values when
        /// source and destination rectangles are passed as NULL.
        /// This overload allows for IntPtr.Zero (null) to be passed for srcrect.
        /// </summary>
        /// <param name="renderer">The renderer which should copy parts of a texture.</param>
        /// <param name="texture">The source texture.</param>
        /// <param name="srcrect">A pointer to the source rectangle, or NULL for the entire texture.</param>
        /// <param name="dstrect">A pointer to the destination rectangle, or NULL for the entire rendering target.</param>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_RenderCopyF")]
        public static extern int RenderCopyF(
            IntPtr renderer,
            IntPtr texture,
            IntPtr srcrect,
            ref FRect dstrect
        );

        /* renderer refers to an Renderer*, texture to an Texture*.
		 * Internally, this function contains logic to use default values when
		 * source and destination rectangles are passed as NULL.
		 * This overload allows for IntPtr.Zero (null) to be passed for dstrect.
		 */
        /// <summary>
        /// Copy a portion of the texture to the current rendering target.
        /// 
        /// Binding info:
        /// renderer refers to an Renderer*, texture to an Texture*.
        /// Internally, this function contains logic to use default values when
        /// source and destination rectangles are passed as NULL.
        /// This overload allows for IntPtr.Zero (null) to be passed for dstrect.
        /// </summary>
        /// <param name="renderer">The renderer which should copy parts of a texture.</param>
        /// <param name="texture">The source texture.</param>
        /// <param name="srcrect">A pointer to the source rectangle, or NULL for the entire texture.</param>
        /// <param name="dstrect">A pointer to the destination rectangle, or NULL for the entire rendering target.</param>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_RenderCopyF")]
        public static extern int RenderCopyF(
            IntPtr renderer,
            IntPtr texture,
            ref Rect srcrect,
            IntPtr dstrect
        );

        /* renderer refers to an Renderer*, texture to an Texture*.
		 * Internally, this function contains logic to use default values when
		 * source and destination rectangles are passed as NULL.
		 * This overload allows for IntPtr.Zero (null) to be passed for both Rects.
		 */
        /// <summary>
        /// Copy a portion of the texture to the current rendering target.
        /// 
        /// Binding info:
        /// renderer refers to an Renderer*, texture to an Texture*.
        /// Internally, this function contains logic to use default values when
        /// source and destination rectangles are passed as NULL.
        /// This overload allows for IntPtr.Zero (null) to be passed for both Rects.
        /// </summary>
        /// <param name="renderer">The renderer which should copy parts of a texture.</param>
        /// <param name="texture">The source texture.</param>
        /// <param name="srcrect">A pointer to the source rectangle, or NULL for the entire texture.</param>
        /// <param name="dstrect">A pointer to the destination rectangle, or NULL for the entire rendering target.</param>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_RenderCopyF")]
        public static extern int RenderCopyF(
            IntPtr renderer,
            IntPtr texture,
            IntPtr srcrect,
            IntPtr dstrect
        );

        /* renderer refers to an Renderer*, texture to an Texture* */
        /// <summary>
        /// Copy a portion of the source texture to the current rendering target, rotating it by angle around the given center.
        /// 
        /// Binding info:
        /// renderer refers to an Renderer*, texture to an Texture*
        /// </summary>
        /// <param name="renderer">The renderer which should copy parts of a texture.</param>
        /// <param name="texture">The source texture.</param>
        /// <param name="srcrect">A pointer to the source rectangle, or NULL for the entire texture.</param>
        /// <param name="dstrect">A pointer to the destination rectangle, or NULL for the entire rendering target.</param>
        /// <param name="angle">An angle in degrees that indicates the rotation that will be applied to dstrect, rotating it in a clockwise direction</param>
        /// <param name="center">A pointer to a point indicating the point around which dstrect will be rotated (if NULL, rotation will be done around dstrect.w/2, dstrect.h/2).</param>
        /// <param name="flip">An SDL_RendererFlip value stating which flipping actions should be performed on the texture</param>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_RenderCopyEx")]
        public static extern int RenderCopyEx(
            IntPtr renderer,
            IntPtr texture,
            ref Rect srcrect,
            ref FRect dstrect,
            double angle,
            ref FPoint center,
            RendererFlip flip
        );

        /* renderer refers to an Renderer*, texture to an Texture*.
		 * Internally, this function contains logic to use default values when
		 * source, destination, and/or center are passed as NULL.
		 * This overload allows for IntPtr.Zero (null) to be passed for srcrect.
		 */
        /// <summary>
        /// Copy a portion of the source texture to the current rendering target, rotating it by angle around the given center.
        /// 
        /// Binding info:
        /// renderer refers to an Renderer*, texture to an Texture*.
        /// Internally, this function contains logic to use default values when
        /// source, destination, and/or center are passed as NULL.
        /// This overload allows for IntPtr.Zero (null) to be passed for srcrect.
        /// </summary>
        /// <param name="renderer">The renderer which should copy parts of a texture.</param>
        /// <param name="texture">The source texture.</param>
        /// <param name="srcrect">A pointer to the source rectangle, or NULL for the entire texture.</param>
        /// <param name="dstrect">A pointer to the destination rectangle, or NULL for the entire rendering target.</param>
        /// <param name="angle">An angle in degrees that indicates the rotation that will be applied to dstrect, rotating it in a clockwise direction</param>
        /// <param name="center">A pointer to a point indicating the point around which dstrect will be rotated (if NULL, rotation will be done around dstrect.w/2, dstrect.h/2).</param>
        /// <param name="flip">An SDL_RendererFlip value stating which flipping actions should be performed on the texture</param>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_RenderCopyEx")]
        public static extern int RenderCopyEx(
            IntPtr renderer,
            IntPtr texture,
            IntPtr srcrect,
            ref FRect dstrect,
            double angle,
            ref FPoint center,
            RendererFlip flip
        );

        /* renderer refers to an Renderer*, texture to an Texture*.
		 * Internally, this function contains logic to use default values when
		 * source, destination, and/or center are passed as NULL.
		 * This overload allows for IntPtr.Zero (null) to be passed for dstrect.
		 */
        /// <summary>
        /// Copy a portion of the source texture to the current rendering target, rotating it by angle around the given center.
        /// 
        /// Binding info:
        /// renderer refers to an Renderer*, texture to an Texture*.
        /// Internally, this function contains logic to use default values when
        /// source, destination, and/or center are passed as NULL.
        /// This overload allows for IntPtr.Zero (null) to be passed for dstrect.
        /// </summary>
        /// <param name="renderer">The renderer which should copy parts of a texture.</param>
        /// <param name="texture">The source texture.</param>
        /// <param name="srcrect">A pointer to the source rectangle, or NULL for the entire texture.</param>
        /// <param name="dstrect">A pointer to the destination rectangle, or NULL for the entire rendering target.</param>
        /// <param name="angle">An angle in degrees that indicates the rotation that will be applied to dstrect, rotating it in a clockwise direction</param>
        /// <param name="center">A pointer to a point indicating the point around which dstrect will be rotated (if NULL, rotation will be done around dstrect.w/2, dstrect.h/2).</param>
        /// <param name="flip">An SDL_RendererFlip value stating which flipping actions should be performed on the texture</param>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_RenderCopyExF")]
        public static extern int RenderCopyExF(
            IntPtr renderer,
            IntPtr texture,
            ref Rect srcrect,
            IntPtr dstrect,
            double angle,
            ref FPoint center,
            RendererFlip flip
        );

        /* renderer refers to an Renderer*, texture to an Texture*.
		 * Internally, this function contains logic to use default values when
		 * source, destination, and/or center are passed as NULL.
		 * This overload allows for IntPtr.Zero (null) to be passed for center.
		 */
        /// <summary>
        /// Copy a portion of the source texture to the current rendering target, rotating it by angle around the given center.
        /// 
        /// Binding info:
        /// renderer refers to an Renderer*, texture to an Texture*.
        /// Internally, this function contains logic to use default values when
        /// source, destination, and/or center are passed as NULL.
        /// This overload allows for IntPtr.Zero (null) to be passed for center.
        /// </summary>
        /// <param name="renderer">The renderer which should copy parts of a texture.</param>
        /// <param name="texture">The source texture.</param>
        /// <param name="srcrect">A pointer to the source rectangle, or NULL for the entire texture.</param>
        /// <param name="dstrect">A pointer to the destination rectangle, or NULL for the entire rendering target.</param>
        /// <param name="angle">An angle in degrees that indicates the rotation that will be applied to dstrect, rotating it in a clockwise direction</param>
        /// <param name="center">A pointer to a point indicating the point around which dstrect will be rotated (if NULL, rotation will be done around dstrect.w/2, dstrect.h/2).</param>
        /// <param name="flip">An SDL_RendererFlip value stating which flipping actions should be performed on the texture</param>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_RenderCopyExF")]
        public static extern int RenderCopyExF(
            IntPtr renderer,
            IntPtr texture,
            ref Rect srcrect,
            ref FRect dstrect,
            double angle,
            IntPtr center,
            RendererFlip flip
        );

        /* renderer refers to an Renderer*, texture to an Texture*.
		 * Internally, this function contains logic to use default values when
		 * source, destination, and/or center are passed as NULL.
		 * This overload allows for IntPtr.Zero (null) to be passed for both
		 * srcrect and dstrect.
		 */
        /// <summary>
        /// Copy a portion of the source texture to the current rendering target, rotating it by angle around the given center.
        /// 
        /// Binding info:
        /// renderer refers to an Renderer*, texture to an Texture*.
        /// Internally, this function contains logic to use default values when
        /// source, destination, and/or center are passed as NULL.
        /// This overload allows for IntPtr.Zero (null) to be passed for both
        /// srcrect and dstrect.
        /// </summary>
        /// <param name="renderer">The renderer which should copy parts of a texture.</param>
        /// <param name="texture">The source texture.</param>
        /// <param name="srcrect">A pointer to the source rectangle, or NULL for the entire texture.</param>
        /// <param name="dstrect">A pointer to the destination rectangle, or NULL for the entire rendering target.</param>
        /// <param name="angle">An angle in degrees that indicates the rotation that will be applied to dstrect, rotating it in a clockwise direction</param>
        /// <param name="center">A pointer to a point indicating the point around which dstrect will be rotated (if NULL, rotation will be done around dstrect.w/2, dstrect.h/2).</param>
        /// <param name="flip">An SDL_RendererFlip value stating which flipping actions should be performed on the texture</param>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_RenderCopyExF")]
        public static extern int RenderCopyExF(
            IntPtr renderer,
            IntPtr texture,
            IntPtr srcrect,
            IntPtr dstrect,
            double angle,
            ref FPoint center,
            RendererFlip flip
        );

        /* renderer refers to an Renderer*, texture to an Texture*.
		 * Internally, this function contains logic to use default values when
		 * source, destination, and/or center are passed as NULL.
		 * This overload allows for IntPtr.Zero (null) to be passed for both
		 * srcrect and center.
		 */
        /// <summary>
        /// Copy a portion of the source texture to the current rendering target, rotating it by angle around the given center.
        /// 
        /// Binding info:
        /// renderer refers to an Renderer*, texture to an Texture*.
        /// Internally, this function contains logic to use default values when
        /// source, destination, and/or center are passed as NULL.
        /// This overload allows for IntPtr.Zero (null) to be passed for both
        /// srcrect and center.
        /// </summary>
        /// <param name="renderer">The renderer which should copy parts of a texture.</param>
        /// <param name="texture">The source texture.</param>
        /// <param name="srcrect">A pointer to the source rectangle, or NULL for the entire texture.</param>
        /// <param name="dstrect">A pointer to the destination rectangle, or NULL for the entire rendering target.</param>
        /// <param name="angle">An angle in degrees that indicates the rotation that will be applied to dstrect, rotating it in a clockwise direction</param>
        /// <param name="center">A pointer to a point indicating the point around which dstrect will be rotated (if NULL, rotation will be done around dstrect.w/2, dstrect.h/2).</param>
        /// <param name="flip">An SDL_RendererFlip value stating which flipping actions should be performed on the texture</param>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_RenderCopyExF")]
        public static extern int RenderCopyExF(
            IntPtr renderer,
            IntPtr texture,
            IntPtr srcrect,
            ref FRect dstrect,
            double angle,
            IntPtr center,
            RendererFlip flip
        );

        /* renderer refers to an Renderer*, texture to an Texture*.
		 * Internally, this function contains logic to use default values when
		 * source, destination, and/or center are passed as NULL.
		 * This overload allows for IntPtr.Zero (null) to be passed for both
		 * dstrect and center.
		 */
        /// <summary>
        /// Copy a portion of the source texture to the current rendering target, rotating it by angle around the given center.
        /// 
        /// Binding info:
        /// renderer refers to an Renderer*, texture to an Texture*.
        /// Internally, this function contains logic to use default values when
        /// source, destination, and/or center are passed as NULL.
        /// This overload allows for IntPtr.Zero (null) to be passed for both
        /// dstrect and center.
        /// </summary>
        /// <param name="renderer">The renderer which should copy parts of a texture.</param>
        /// <param name="texture">The source texture.</param>
        /// <param name="srcrect">A pointer to the source rectangle, or NULL for the entire texture.</param>
        /// <param name="dstrect">A pointer to the destination rectangle, or NULL for the entire rendering target.</param>
        /// <param name="angle">An angle in degrees that indicates the rotation that will be applied to dstrect, rotating it in a clockwise direction</param>
        /// <param name="center">A pointer to a point indicating the point around which dstrect will be rotated (if NULL, rotation will be done around dstrect.w/2, dstrect.h/2).</param>
        /// <param name="flip">An SDL_RendererFlip value stating which flipping actions should be performed on the texture</param>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_RenderCopyExF")]
        public static extern int RenderCopyExF(
            IntPtr renderer,
            IntPtr texture,
            ref Rect srcrect,
            IntPtr dstrect,
            double angle,
            IntPtr center,
            RendererFlip flip
        );

        /* renderer refers to an Renderer*, texture to an Texture*.
		 * Internally, this function contains logic to use default values when
		 * source, destination, and/or center are passed as NULL.
		 * This overload allows for IntPtr.Zero (null) to be passed for all
		 * three parameters.
		 */
        /// <summary>
        /// Copy a portion of the source texture to the current rendering target, rotating it by angle around the given center.
        /// 
        /// Binding info:
        /// renderer refers to an Renderer*, texture to an Texture*.
        /// Internally, this function contains logic to use default values when
        /// source, destination, and/or center are passed as NULL.
        /// This overload allows for IntPtr.Zero (null) to be passed for all
        /// three parameters.
        /// </summary>
        /// <param name="renderer">The renderer which should copy parts of a texture.</param>
        /// <param name="texture">The source texture.</param>
        /// <param name="srcrect">A pointer to the source rectangle, or NULL for the entire texture.</param>
        /// <param name="dstrect">A pointer to the destination rectangle, or NULL for the entire rendering target.</param>
        /// <param name="angle">An angle in degrees that indicates the rotation that will be applied to dstrect, rotating it in a clockwise direction</param>
        /// <param name="center">A pointer to a point indicating the point around which dstrect will be rotated (if NULL, rotation will be done around dstrect.w/2, dstrect.h/2).</param>
        /// <param name="flip">An SDL_RendererFlip value stating which flipping actions should be performed on the texture</param>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_RenderCopyExF")]
        public static extern int RenderCopyExF(
            IntPtr renderer,
            IntPtr texture,
            IntPtr srcrect,
            IntPtr dstrect,
            double angle,
            IntPtr center,
            RendererFlip flip
        );

        /* renderer refers to an Renderer* */
        /// <summary>
        /// Draw a point on the current rendering target.
        /// 
        /// Binding info:
        /// renderer refers to an Renderer*
        /// </summary>
        /// <param name="renderer">The renderer which should draw a point.</param>
        /// <param name="x">The x coordinate of the point.</param>
        /// <param name="y">The y coordinate of the point.</param>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_RenderDrawPointF")]
        public static extern int RenderDrawPointF(
            IntPtr renderer,
            float x,
            float y
        );

        /* renderer refers to an Renderer* */
        /// <summary>
        /// Draw multiple points on the current rendering target.
        /// 
        /// Binding info:
        /// renderer refers to an Renderer*
        /// </summary>
        /// <param name="renderer">The renderer which should draw multiple points.</param>
        /// <param name="points">The points to draw</param>
        /// <param name="count">The number of points to draw</param>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_RenderDrawPointsF")]
        public static extern int RenderDrawPointsF(
            IntPtr renderer,
            [In] FPoint[] points,
            int count
        );

        /* renderer refers to an Renderer* */
        /// <summary>
        /// Draw a line on the current rendering target.
        /// 
        /// Binding info:
        /// renderer refers to an Renderer*
        /// </summary>
        /// <param name="renderer">The renderer which should draw a line.</param>
        /// <param name="x1">The x coordinate of the start point.</param>
        /// <param name="y1">The y coordinate of the start point.</param>
        /// <param name="x2">The x coordinate of the end point.</param>
        /// <param name="y2">The y coordinate of the end point.</param>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_RenderDrawLineF")]
        public static extern int RenderDrawLineF(
            IntPtr renderer,
            float x1,
            float y1,
            float x2,
            float y2
        );

        /* renderer refers to an Renderer* */
        /// <summary>
        /// Draw a series of connected lines on the current rendering target.
        /// 
        /// Binding info:
        /// renderer refers to an Renderer*
        /// </summary>
        /// <param name="renderer">The renderer which should draw multiple lines.</param>
        /// <param name="points">The points along the lines</param>
        /// <param name="count">The number of points, drawing count-1 lines</param>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_RenderDrawLinesF")]
        public static extern int RenderDrawLinesF(
            IntPtr renderer,
            [In] FPoint[] points,
            int count
        );

        /* renderer refers to an Renderer* */
        /// <summary>
        /// Draw a rectangle on the current rendering target.
        /// 
        /// Binding info:
        /// renderer refers to an Renderer*
        /// </summary>
        /// <param name="renderer">The renderer which should draw a rectangle.</param>
        /// <param name="rect">A pointer to the destination rectangle, or NULL to outline the entire rendering target.</param>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_RenderDrawRectF")]
        public static extern int RenderDrawRectF(
            IntPtr renderer,
            ref FRect rect
        );

        /* renderer refers to an Renderer*, rect to an Rect*.
		 * This overload allows for IntPtr.Zero (null) to be passed for rect.
		 */
        /// <summary>
        /// Draw a rectangle on the current rendering target.
        /// 
        /// Binding info:
        /// renderer refers to an Renderer*, rect to an Rect*.
        /// This overload allows for IntPtr.Zero (null) to be passed for rect.
        /// </summary>
        /// <param name="renderer">The renderer which should draw a rectangle.</param>
        /// <param name="rect">A pointer to the destination rectangle, or NULL to outline the entire rendering target.</param>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_RenderDrawRectF")]
        public static extern int RenderDrawRectF(
            IntPtr renderer,
            IntPtr rect
        );

        /* renderer refers to an Renderer* */
        /// <summary>
        /// Draw some number of rectangles on the current rendering target.
        /// 
        /// Binding info:
        /// renderer refers to an Renderer*
        /// </summary>
        /// <param name="renderer">The renderer which should draw multiple rectangles.</param>
        /// <param name="rects">A pointer to an array of destination rectangles.</param>
        /// <param name="count">The number of rectangles.</param>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_RenderDrawRectsF")]
        public static extern int RenderDrawRectsF(
            IntPtr renderer,
            [In] FRect[] rects,
            int count
        );

        /* renderer refers to an Renderer* */
        /// <summary>
        /// Fill a rectangle on the current rendering target with the drawing color.
        /// 
        /// Binding info:
        /// renderer refers to an Renderer*
        /// </summary>
        /// <param name="renderer">The renderer which should fill a rectangle.</param>
        /// <param name="rect">A pointer to the destination rectangle, or NULL for the entire rendering target.</param>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_RenderFillRectF")]
        public static extern int RenderFillRectF(
            IntPtr renderer,
            ref FRect rect
        );

        /* renderer refers to an Renderer*, rect to an Rect*.
		 * This overload allows for IntPtr.Zero (null) to be passed for rect.
		 */
        /// <summary>
        /// Fill a rectangle on the current rendering target with the drawing color.
        /// 
        /// Binding info:
        /// renderer refers to an Renderer*, rect to an Rect*.
        /// This overload allows for IntPtr.Zero (null) to be passed for rect.
        /// </summary>
        /// <param name="renderer">The renderer which should fill a rectangle.</param>
        /// <param name="rect">A pointer to the destination rectangle, or NULL for the entire rendering target.</param>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_RenderFillRectF")]
        public static extern int RenderFillRectF(
            IntPtr renderer,
            IntPtr rect
        );

        /* renderer refers to an Renderer* */
        /// <summary>
        /// Fill some number of rectangles on the current rendering target with the drawing color.
        /// 
        /// Binding info:
        /// renderer refers to an Renderer*
        /// </summary>
        /// <param name="renderer">The renderer which should fill multiple rectangles.</param>
        /// <param name="rects">A pointer to an array of destination rectangles.</param>
        /// <param name="count">The number of rectangles.</param>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_RenderFillRectsF")]
        public static extern int RenderFillRectsF(
            IntPtr renderer,
            [In] FRect[] rects,
            int count
        );



        /* renderer refers to an Renderer* */
        /// <summary>
        /// Get the clip rectangle for the current target.
        /// 
        /// Binding info:
        /// renderer refers to an Renderer*
        /// </summary>
        /// <param name="renderer">The renderer from which clip rectangle should be queried.</param>
        /// <param name="rect">A pointer filled in with the current clip rectangle, or an empty rectangle if clipping is disabled.</param>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_RenderGetClipRect")]
        public static extern void RenderGetClipRect(
            IntPtr renderer,
            out Rect rect
        );

        /* renderer refers to an Renderer* */
        /// <summary>
        /// Get device independent resolution for rendering.
        /// 
        /// Binding info:
        /// renderer refers to an Renderer*
        /// </summary>
        /// <param name="renderer">The renderer from which resolution should be queried.</param>
        /// <param name="w">A pointer filled with the width of the logical resolution</param>
        /// <param name="h">A pointer filled with the height of the logical resolution</param>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_RenderGetLogicalSize")]
        public static extern void RenderGetLogicalSize(
            IntPtr renderer,
            out int w,
            out int h
        );

        /* renderer refers to an Renderer* */
        /// <summary>
        /// Get the drawing scale for the current target.
        /// 
        /// Binding info:
        /// renderer refers to an Renderer*
        /// </summary>
        /// <param name="renderer">The renderer from which drawing scale should be queried.</param>
        /// <param name="scaleX">A pointer filled in with the horizontal scaling factor</param>
        /// <param name="scaleY">A pointer filled in with the vertical scaling factor</param>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_RenderGetScale")]
        public static extern void RenderGetScale(
            IntPtr renderer,
            out float scaleX,
            out float scaleY
        );

        /* renderer refers to an Renderer* */
        /// <summary>
        /// Get the drawing area for the current target.
        /// 
        /// Binding info:
        /// renderer refers to an Renderer*
        /// </summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_RenderGetViewport")]
        public static extern int RenderGetViewport(
            IntPtr renderer,
            out Rect rect
        );

        /* renderer refers to an Renderer* */
        /// <summary>
        /// Update the screen with rendering performed.
        /// 
        /// Binding info:
        /// renderer refers to an Renderer*
        /// </summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_RenderPresent")]
        public static extern void RenderPresent(IntPtr renderer);

        /* renderer refers to an Renderer* */
        /// <summary>
        /// Read pixels from the current rendering target.
        /// 
        /// Binding info:
        /// renderer refers to an Renderer*
        /// </summary>
        /// <param name="renderer">The renderer from which pixels should be read.</param>
        /// <param name="rect">A pointer to the rectangle to read, or NULL for the entire render target.</param>
        /// <param name="format">The desired format of the pixel data, or 0 to use the format of the rendering target</param>
        /// <param name="pixels">A pointer to be filled in with the pixel data</param>
        /// <param name="pitch">The pitch of the pixels parameter.</param>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_RenderReadPixels")]
        public static extern int RenderReadPixels(
            IntPtr renderer,
            ref Rect rect,
            uint format,
            IntPtr pixels,
            int pitch
        );

        /* renderer refers to an Renderer* */
        /// <summary>
        /// Set the clip rectangle for the current target.
        /// 
        /// Binding info:
        /// renderer refers to an Renderer*
        /// </summary>
        /// <param name="renderer">The renderer for which clip rectangle should be set.</param>
        /// <param name="rect">A pointer to the rectangle to set as the clip rectangle, relative to the viewport, or NULL to disable clipping.</param>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_RenderSetClipRect")]
        public static extern int RenderSetClipRect(
            IntPtr renderer,
            ref Rect rect
        );

        /* renderer refers to an Renderer*
		 * This overload allows for IntPtr.Zero (null) to be passed for rect.
		 */
        /// <summary>
        /// Set the clip rectangle for the current target.
        /// 
        /// Binding info:
        /// renderer refers to an Renderer*
        /// This overload allows for IntPtr.Zero (null) to be passed for rect.
        /// </summary>
        /// <param name="renderer">The renderer for which clip rectangle should be set.</param>
        /// <param name="rect">A pointer to the rectangle to set as the clip rectangle, relative to the viewport, or NULL to disable clipping.</param>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_RenderSetClipRect")]
        public static extern int RenderSetClipRect(
            IntPtr renderer,
            IntPtr rect
        );

        /* renderer refers to an Renderer* */
        /// <summary>
        /// Set device independent resolution for rendering. 
        /// This function uses the viewport and scaling functionality to allow a fixed logical resolution for rendering, regardless of the actual output resolution. If the actual output resolution doesn't have the same aspect ratio the output rendering will be centered within the output display.If the output display is a window, mouse events in the window will be filtered and scaled so they seem to arrive within the logical resolution.
        /// 
        /// Binding info:
        /// renderer refers to an Renderer*
        /// </summary>
        /// <param name="renderer">The renderer for which resolution should be set.</param>
        /// <param name="w">The width of the logical resolution</param>
        /// <param name="h">The height of the logical resolution</param>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_RenderSetLogicalSize")]
        public static extern int RenderSetLogicalSize(
            IntPtr renderer,
            int w,
            int h
        );

        /* renderer refers to an Renderer* */
        /// <summary>
        /// Set the drawing scale for rendering on the current target. 
        /// The drawing coordinates are scaled by the x/y scaling factors before they are used by the renderer. This allows resolution independent drawing with a single coordinate system.
        /// 
        /// Binding info:
        /// renderer refers to an Renderer*
        /// </summary>
        /// <param name="renderer">The renderer for which the drawing scale should be set.</param>
        /// <param name="scaleX">The horizontal scaling factor</param>
        /// <param name="scaleY">The vertical scaling factor</param>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_RenderSetScale")]
        public static extern int RenderSetScale(
            IntPtr renderer,
            float scaleX,
            float scaleY
        );

        /* renderer refers to an Renderer* */
        /* Available in 2.0.5 or higher */
        /// <summary>
        /// Set whether to force integer scales for resolution-independent rendering. 
        /// This function restricts the logical viewport to integer values - that is, when a resolution is between two multiples of a logical size, the viewport size is rounded down to the lower multiple.
        /// 
        /// Binding info:
        /// Available in 2.0.5 or higher
        /// </summary>
        /// <param name="renderer">The renderer for which integer scaling should be set.</param>
        /// <param name="enable">Enable or disable integer scaling</param>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_RenderSetIntegerScale")]
        public static extern int RenderSetIntegerScale(
            IntPtr renderer,
            bool enable
        );

        /* renderer refers to an Renderer* */
        /// <summary>
        /// Set the drawing area for rendering on the current target. 
        /// The x,y of the viewport rect represents the origin for rendering.
        /// 
        /// Binding info:
        /// renderer refers to an Renderer*
        /// </summary>
        /// <param name="renderer">The renderer for which the drawing area should be set.</param>
        /// <param name="rect">The rectangle representing the drawing area, or NULL to set the viewport to the entire target.</param>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_RenderSetViewport")]
        public static extern int RenderSetViewport(
            IntPtr renderer,
            ref Rect rect
        );

        /* renderer refers to an Renderer* */
        /// <summary>
        /// Set the blend mode used for drawing operations (Fill and Line).
        /// 
        /// Binding info:
        /// renderer refers to an Renderer*
        /// </summary>
        /// <param name="renderer">The renderer for which blend mode should be set.</param>
        /// <param name="blendMode">SDL_BlendMode to use for blending.</param>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_SetRenderDrawBlendMode")]
        public static extern int SetRenderDrawBlendMode(
            IntPtr renderer,
            BlendMode blendMode
        );

        /* renderer refers to an Renderer* */
        /// <summary>
        /// Set the color used for drawing operations (Rect, Line and Clear).
        /// 
        /// Binding info:
        /// renderer refers to an Renderer*
        /// </summary>
        /// <param name="renderer">The renderer for which drawing color should be set.</param>
        /// <param name="r">The red value used to draw on the rendering target.</param>
        /// <param name="g">The green value used to draw on the rendering target.</param>
        /// <param name="b">The blue value used to draw on the rendering target.</param>
        /// <param name="a">The alpha value used to draw on the rendering target, usually SDL_ALPHA_OPAQUE (255).</param>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_SetRenderDrawColor")]
        public static extern int SetRenderDrawColor(
            IntPtr renderer,
            byte r,
            byte g,
            byte b,
            byte a
        );

        /* renderer refers to an Renderer*, texture to an Texture* */
        /// <summary>
        /// Set a texture as the current rendering target.
        /// 
        /// Binding info:
        /// renderer refers to an Renderer*, texture to an Texture*
        /// </summary>
        /// <param name="renderer">The renderer.</param>
        /// <param name="texture">The targeted texture, which must be created with the SDL_TEXTUREACCESS_TARGET flag, or NULL for the default render target</param>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_SetRenderTarget")]
        public static extern int SetRenderTarget(
            IntPtr renderer,
            IntPtr texture
        );

        /* texture refers to an Texture* */
        /// <summary>
        /// Set an additional alpha value used in render copy operations.
        /// 
        /// Binding info:
        /// texture refers to an Texture*
        /// </summary>
        /// <param name="texture">The texture to update.</param>
        /// <param name="alpha">The alpha value multiplied into copy operations.</param>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_SetTextureAlphaMod")]
        public static extern int SetTextureAlphaMod(
            IntPtr texture,
            byte alpha
        );

        /* texture refers to an Texture* */
        /// <summary>
        /// Set the blend mode used for texture copy operations.
        /// 
        /// Binding info:
        /// texture refers to an Texture*
        /// </summary>
        /// <param name="texture">The texture to update.</param>
        /// <param name="blendMode">SDL_BlendMode to use for texture blending.</param>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_SetTextureBlendMode")]
        public static extern int SetTextureBlendMode(
            IntPtr texture,
            BlendMode blendMode
        );

        /* texture refers to an Texture* */
        /// <summary>
        /// Set an additional color value used in render copy operations.
        /// 
        /// Binding info:
        /// texture refers to an Texture*
        /// </summary>
        /// <param name="texture">The texture to update.</param>
        /// <param name="r">The red color value multiplied into copy operations.</param>
        /// <param name="g">The green color value multiplied into copy operations.</param>
        /// <param name="b">The blue color value multiplied into copy operations.</param>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_SetTextureColorMod")]
        public static extern int SetTextureColorMod(
            IntPtr texture,
            byte r,
            byte g,
            byte b
        );

        /* texture refers to an Texture* */
        /// <summary>
        /// Unlock a texture, uploading the changes to video memory, if needed. If SDL_LockTextureToSurface() was called for locking, the SDL surface is freed.
        /// 
        /// Binding info:
        /// texture refers to an Texture*
        /// </summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_UnlockTexture")]
        public static extern void UnlockTexture(IntPtr texture);

        /* texture refers to an Texture* */
        /// <summary>
        /// Update the given texture rectangle with new pixel data. 
        /// The pixel data must be in the format of the texture. The pixel format can be queried with SDL_QueryTexture.
        /// 
        /// Binding info:
        /// texture refers to an Texture*
        /// </summary>
        /// <param name="texture">The texture to update</param>
        /// <param name="rect">A pointer to the rectangle of pixels to update, or NULL to update the entire texture.</param>
        /// <param name="pixels">The raw pixel data in the format of the texture.</param>
        /// <param name="pitch">The number of bytes in a row of pixel data, including padding between lines.</param>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_UpdateTexture")]
        public static extern int UpdateTexture(
            IntPtr texture,
            ref Rect rect,
            IntPtr pixels,
            int pitch
        );

        /* texture refers to an Texture* */
        /// <summary>
        /// Update the given texture rectangle with new pixel data. 
        /// The pixel data must be in the format of the texture. The pixel format can be queried with SDL_QueryTexture.
        /// 
        /// Binding info:
        /// texture refers to an Texture*
        /// </summary>
        /// <param name="texture">The texture to update</param>
        /// <param name="rect">A pointer to the rectangle of pixels to update, or NULL to update the entire texture.</param>
        /// <param name="pixels">The raw pixel data in the format of the texture.</param>
        /// <param name="pitch">The number of bytes in a row of pixel data, including padding between lines.</param>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_UpdateTexture")]
        public static extern int UpdateTexture(
            IntPtr texture,
            IntPtr rect,
            IntPtr pixels,
            int pitch
        );

        /* texture refers to an Texture* */
        /* Available in 2.0.1 or higher */
        /// <summary>
        /// Update a rectangle within a planar YV12 or IYUV texture with new pixel data.
        /// 
        /// Binding info:
        /// Available in 2.0.1 or higher
        /// </summary>
        /// <param name="texture">The texture to update</param>
        /// <param name="rect">A pointer to the rectangle of pixels to update, or NULL to update the entire texture.</param>
        /// <param name="Yplane">The raw pixel data for the Y plane.</param>
        /// <param name="Ypitch">The number of bytes between rows of pixel data for the Y plane.</param>
        /// <param name="Uplane">The raw pixel data for the U plane.</param>
        /// <param name="Upitch">The number of bytes between rows of pixel data for the U plane.</param>
        /// <param name="Vplane">The raw pixel data for the V plane.</param>
        /// <param name="Vpitch">The number of bytes between rows of pixel data for the V plane.</param>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_UpdateYUVTexture")]
        public static extern int UpdateYUVTexture(
            IntPtr texture,
            ref Rect rect,
            IntPtr yPlane,
            int yPitch,
            IntPtr uPlane,
            int uPitch,
            IntPtr vPlane,
            int vPitch
        );

        /* renderer refers to an Renderer* */
        /// <summary>
        /// Determines whether a window supports the use of render targets.
        /// 
        /// Binding info:
        /// renderer refers to an Renderer*
        /// </summary>
        /// <param name="renderer">The renderer that will be checked</param>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_RenderTargetSupported")]
        public static extern bool RenderTargetSupported(
            IntPtr renderer
        );

        /* IntPtr refers to an Texture*, renderer to an Renderer* */
        /// <summary>
        /// Get the current render target or NULL for the default render target.
        /// 
        /// Binding info:
        /// IntPtr refers to an Texture*, renderer to an Renderer*
        /// </summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetRenderTarget")]
        public static extern IntPtr GetRenderTarget(IntPtr renderer);

        /* renderer refers to an Renderer* */
        /* Available in 2.0.8 or higher */
        /// <summary>
        /// Get the CAMetalLayer associated with the given Metal renderer.
        /// 
        /// Binding info:
        /// Available in 2.0.8 or higher
        /// </summary>
        /// <param name="renderer">The renderer to query</param>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_RenderGetMetalLayer")]
        public static extern IntPtr RenderGetMetalLayer(
            IntPtr renderer
        );

        /* renderer refers to an Renderer* */
        /* Available in 2.0.8 or higher */
        /// <summary>
        /// Get the Metal command encoder for the current frame.
        /// 
        /// Binding info:
        /// Available in 2.0.8 or higher
        /// </summary>
        /// <param name="renderer">The renderer to query</param>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_RenderGetMetalCommandEncoder")]
        public static extern IntPtr RenderGetMetalCommandEncoder(
            IntPtr renderer
        );

        /* renderer refers to an Renderer* */
        /* Only available in 2.0.4 */
        /// <summary>
        /// Get whether clipping is enabled on the given renderer.
        /// 
        /// Binding info:
        /// Only available in 2.0.4
        /// </summary>
        /// <param name="renderer">The renderer from which clip state should be queried.</param>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_RenderIsClipEnabled")]
        public static extern bool RenderIsClipEnabled(IntPtr renderer);

        /* renderer refers to an Renderer* */
        /* Available in 2.0.10 or higher. */
        /// <summary>
        /// Force the rendering context to flush any pending commands to the underlying rendering API. 
        /// You do not need to (and in fact, shouldn't) call this function unless you are planning to call into OpenGL/Direct3D/Metal/whatever directly in addition to using an SDL_Renderer.This is for a very-specific case: if you are using SDL's render API, you asked for a specific renderer backend (OpenGL, Direct3D, etc), you set SDL_HINT_RENDER_BATCHING to "1", and you plan to make OpenGL/D3D/whatever calls in addition to SDL render API calls. If all of this applies, you should call  between calls to SDL's render API and the low-level API you're using in cooperation.In all other cases, you can ignore this function. This is only here to get maximum performance out of a specific situation. In all other cases, SDL will do the right thing, perhaps at a performance loss.This function is first available in SDL 2.0.10, and is not needed in 2.0.9 and earlier, as earlier versions did not queue rendering commands at all, instead flushing them to the OS immediately.
        /// 
        /// Binding info:
        /// Available in 2.0.10 or higher.
        /// </summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_RenderFlush")]
        public static extern int RenderFlush(IntPtr renderer);
    }
    #endregion
}
