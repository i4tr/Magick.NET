﻿// Copyright 2013-2020 Dirk Lemstra <https://github.com/dlemstra/Magick.NET/>
//
// Licensed under the ImageMagick License (the "License"); you may not use this file except in
// compliance with the License. You may obtain a copy of the License at
//
//   https://www.imagemagick.org/script/license.php
//
// Unless required by applicable law or agreed to in writing, software distributed under the
// License is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND,
// either express or implied. See the License for the specific language governing permissions
// and limitations under the License.

using System.Collections;
using System.Collections.Generic;
using System.Linq;
using ImageMagick;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Magick.NET.Tests
{
    public partial class SafePixelCollectionTests
    {
        [TestClass]
        public class TheGetEnumeratorMethod
        {
            [TestMethod]
            public void ShouldReturnEnumerator()
            {
                using (var image = new MagickImage(Files.CirclePNG))
                {
                    using (var pixels = image.GetPixels())
                    {
                        var enumerator = pixels.GetEnumerator();
                        Assert.IsNotNull(enumerator);
                    }
                }
            }

            [TestMethod]
            public void ShouldReturnEnumeratorForInterfaceImplementation()
            {
                using (var image = new MagickImage(Files.CirclePNG))
                {
                    using (var pixels = image.GetPixels())
                    {
                        IEnumerable enumerable = pixels;
                        Assert.IsNotNull(enumerable.GetEnumerator());
                    }
                }
            }

            [TestMethod]
            public void ShouldReturnEnumeratorForFirst()
            {
                using (var image = new MagickImage(Files.ConnectedComponentsPNG, 10, 10))
                {
                    var pixel = image.GetPixels().First(p => p.ToColor().Equals(MagickColors.Black));
                    Assert.IsNotNull(pixel);

                    Assert.AreEqual(350, pixel.X);
                    Assert.AreEqual(196, pixel.Y);
                    Assert.AreEqual(2, pixel.Channels);
                }
            }

            [TestMethod]
            public void ShouldReturnEnumeratorForCount()
            {
                using (var image = new MagickImage(MagickColors.Red, 5, 10))
                {
                    using (var pixels = image.GetPixels())
                    {
                        Assert.AreEqual(50, pixels.Count());
                    }
                }
            }
        }
    }
}
