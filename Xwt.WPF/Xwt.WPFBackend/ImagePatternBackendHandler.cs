//
// ImagePatternBackendHandler.cs
//
// Author:
//       Eric Maupin <ermau@xamarin.com>
//
// Copyright (c) 2012 Xamarin, Inc.
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.

using System;
using System.Drawing;
using Xwt.Backends;

namespace Xwt.WPFBackend
{
	public class ImagePatternBackendHandler
		: IImagePatternBackendHandler
	{
		public object Create (object img)
		{
			Bitmap bmp = DataConverter.AsBitmap (img);
			var bmap = bmp.LockBits (new System.Drawing.Rectangle (0, 0, bmp.Width, bmp.Height), System.Drawing.Imaging.ImageLockMode.WriteOnly, bmp.PixelFormat);
			Cairo.ImageSurface surface = new Cairo.ImageSurface (bmap.Scan0, Cairo.Format.Argb32, bmp.Width, bmp.Height, bmap.Stride);
			var p = new Cairo.SurfacePattern (surface);
			p.Extend = Cairo.Extend.Repeat;
			bmp.UnlockBits (bmap);
			return p;
		}
	}
}
