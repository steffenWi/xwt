using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Interop;

namespace Xwt.WPFBackend
{
	class WpfCairoContextBackendHandler: CairoBackend.CairoContextBackendHandler
	{
		protected override Size GetImageSize (object img)
		{
			Bitmap bmp = DataConverter.AsBitmap (img);
			return new Size (bmp.Width, bmp.Height);
		}

		protected override void SetSourceImage (Cairo.Context ctx, object img, double x, double y)
		{
			Bitmap bmp = DataConverter.AsBitmap (img);
			var bmap = bmp.LockBits (new System.Drawing.Rectangle (0, 0, bmp.Width, bmp.Height), System.Drawing.Imaging.ImageLockMode.WriteOnly, bmp.PixelFormat);
			Cairo.ImageSurface surface = new Cairo.ImageSurface (bmap.Scan0, Cairo.Format.Argb32, bmp.Width, bmp.Height, bmp.Width * 4);
			bmp.UnlockBits (bmap);
			ctx.SetSource (surface, x, y);
		}
	}
}
