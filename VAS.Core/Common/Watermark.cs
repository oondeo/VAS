﻿//
//  Copyright (C) 2017 Fluendo S.A.
//
//  This program is free software; you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation; either version 2 of the License, or
//  (at your option) any later version.
//
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY; without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the
//  GNU General Public License for more details.
//
//  You should have received a copy of the GNU General Public License
//  along with this program; if not, write to the Free Software
//  Foundation, Inc., 51 Franklin St, Fifth Floor, Boston, MA 02110-1301, USA.
//
using System;
using VAS.Core.Resources.Styles;

namespace VAS.Core.Common
{
	/// <summary>
	/// Watermark object to configure the watermark in renderings
	/// </summary>
	[Serializable]
	public class Watermark
	{
		public Watermark (Image image, double height, double offsetX, double offsetY)
		{
			Image = image;
			Height = height;
			OffsetX = offsetX;
			OffsetY = offsetY;
		}

		/// <summary>
		/// The image.
		/// </summary>
		public Image Image { get; set; }

		/// <summary>
		/// The relative height, normalized from 0 to 1 based on output video height
		/// </summary>
		public double Height { get; set; }

		/// <summary>
		/// The offset x, normalized from 0 to 1 based on output video height
		/// </summary>
		public double OffsetX { get; set; }

		/// <summary>
		/// The offset y, normalized from 0 to 1 based on output video height
		/// </summary>
		public double OffsetY { get; set; }

		/// <summary>
		/// Configures a new watermark, by calculating its offset and size depending on
		/// position and VideoStandard (Size of the video)
		/// </summary>
		/// <returns>The new configured watermark.</returns>
		/// <param name="position">Position.</param>
		/// <param name="videoStandard">Video standard.</param>
		public static Watermark ConfigureNewWatermark (WatermarkPosition position, VideoStandard videoStandard, Image image = null)
		{
			double videoWidth = videoStandard.Width;
			double videoHeight = videoStandard.Height;
			Image originalImage = image ?? App.Current.ResourcesLocator.LoadEmbeddedImage (Constants.WATERMARK_RESOURCE_ID);

			double sizeChanged = (videoHeight * Sizes.WatermarkHeightNormalization) / originalImage.Height;
			int newWidth = (int)(originalImage.Width * sizeChanged);
			int newHeight = (int)(originalImage.Height * sizeChanged);

			Image newImage;
			if (image == null) {
				newImage = App.Current.ResourcesLocator.LoadEmbeddedImage (Constants.WATERMARK_RESOURCE_ID, newWidth, newHeight);
			} else {
				newImage = image.Scale (newWidth, newHeight);
			}
			double offsetX = 0;
			double offsetY = 0;

			switch (position) {
			case WatermarkPosition.TOP_LEFT:
				offsetX = Sizes.WatermarkPadding / videoWidth;
				offsetY = Sizes.WatermarkPadding / videoHeight;
				break;
			case WatermarkPosition.TOP_RIGHT:
				offsetX = (videoWidth - newImage.Width - Sizes.WatermarkPadding) / videoWidth;
				offsetY = Sizes.WatermarkPadding / videoHeight;
				break;
			case WatermarkPosition.BOTTOM_LEFT:
				offsetX = Sizes.WatermarkPadding / videoWidth;
				offsetY = (videoHeight - newImage.Height - Sizes.WatermarkPadding) / videoHeight;
				break;
			case WatermarkPosition.BOTTOM_RIGHT:
				offsetX = (videoWidth - newImage.Width - Sizes.WatermarkPadding) / videoWidth;
				offsetY = (videoHeight - newImage.Height - Sizes.WatermarkPadding) / videoStandard.Height;
				break;
			default:
				return null;
			}
			return new Watermark (newImage, Sizes.WatermarkHeightNormalization, offsetX, offsetY);
		}
	}
}
