using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Gmage.Config;
namespace Gmage
{
    public class Register
    {
        /// <summary>
        /// 功能组装代码由脚本生成至剪切板
        /// </summary>
        public static void Pack() { Packaging(); }
        public static void Void()
        {
            var ss = "";
            foreach (int v in Enum.GetValues(typeof(FunctionType)))
            {
                var str = Enum.GetName(typeof(FunctionType), v);
                var s = str.ToString().Trim();
                ss += $"GraphCommand.{s} {s.ToLower()}= new GraphCommand.{s}();\r\n" +
                    $"graphCommand.AddCommand(FunctionType.{s}, {s.ToLower()});\r\n";
            }
            System.Windows.Forms.Clipboard.Clear();
            System.Windows.Forms.Clipboard.SetText(ss);
        }

        public static void Packaging()
        {
            GraphCommand.Gray gray = new GraphCommand.Gray();
            graphCommand.AddCommand(FunctionType.Gray, gray);
            GraphCommand.Binarization binarization = new GraphCommand.Binarization();
            graphCommand.AddCommand(FunctionType.Binarization, binarization);
            GraphCommand.Complementary complementary = new GraphCommand.Complementary();
            graphCommand.AddCommand(FunctionType.Complementary, complementary);
            GraphCommand.Sharpen sharpen = new GraphCommand.Sharpen();
            graphCommand.AddCommand(FunctionType.Sharpen, sharpen);
            GraphCommand.Lighten lighten = new GraphCommand.Lighten();
            graphCommand.AddCommand(FunctionType.Lighten, lighten);
            GraphCommand.Contrast contrast = new GraphCommand.Contrast();
            graphCommand.AddCommand(FunctionType.Contrast, contrast);
            GraphCommand.Robert robert = new GraphCommand.Robert();
            graphCommand.AddCommand(FunctionType.Robert, robert);
            GraphCommand.Smoothed smoothed = new GraphCommand.Smoothed();
            graphCommand.AddCommand(FunctionType.Smoothed, smoothed);
            GraphCommand.SaltNoise saltnoise = new GraphCommand.SaltNoise();
            graphCommand.AddCommand(FunctionType.SaltNoise, saltnoise);
            GraphCommand.GaussNoise gaussnoise = new GraphCommand.GaussNoise();
            graphCommand.AddCommand(FunctionType.GaussNoise, gaussnoise);
            GraphCommand.MedianFilter medianfilter = new GraphCommand.MedianFilter();
            graphCommand.AddCommand(FunctionType.MedianFilter, medianfilter);
            GraphCommand.GaussBlur gaussblur = new GraphCommand.GaussBlur();
            graphCommand.AddCommand(FunctionType.GaussBlur, gaussblur);
            GraphCommand.Polar polar = new GraphCommand.Polar();
            graphCommand.AddCommand(FunctionType.Polar, polar);
            GraphCommand.FFT fft = new GraphCommand.FFT();
            graphCommand.AddCommand(FunctionType.FFT, fft);
            GraphCommand.Recognition recognition = new GraphCommand.Recognition();
            graphCommand.AddCommand(FunctionType.Recognition, recognition);
            GraphCommand.Clockwise180 clockwise180 = new GraphCommand.Clockwise180();
            graphCommand.AddCommand(FunctionType.Clockwise180, clockwise180);
            GraphCommand.Clockwise90 clockwise90 = new GraphCommand.Clockwise90();
            graphCommand.AddCommand(FunctionType.Clockwise90, clockwise90);
            GraphCommand.Clockwise270 clockwise270 = new GraphCommand.Clockwise270();
            graphCommand.AddCommand(FunctionType.Clockwise270, clockwise270);
            GraphCommand.RotateNoneFlipX rotatenoneflipx = new GraphCommand.RotateNoneFlipX();
            graphCommand.AddCommand(FunctionType.RotateNoneFlipX, rotatenoneflipx);
            GraphCommand.RotateNoneFlipY rotatenoneflipy = new GraphCommand.RotateNoneFlipY();
            graphCommand.AddCommand(FunctionType.RotateNoneFlipY, rotatenoneflipy);
            GraphCommand.Erosion erosion = new GraphCommand.Erosion();
            graphCommand.AddCommand(FunctionType.Erosion, erosion);
            GraphCommand.Swell swell = new GraphCommand.Swell();
            graphCommand.AddCommand(FunctionType.Swell, swell);
            GraphCommand.Tophap tophap = new GraphCommand.Tophap();
            graphCommand.AddCommand(FunctionType.Tophap, tophap);
            GraphCommand.Skeleton skeleton = new GraphCommand.Skeleton();
            graphCommand.AddCommand(FunctionType.Skeleton, skeleton);
            GraphCommand.Boundary boundary = new GraphCommand.Boundary();
            graphCommand.AddCommand(FunctionType.Boundary, boundary);
            GraphCommand.Cut cut = new GraphCommand.Cut();
            graphCommand.AddCommand(FunctionType.Cut, cut);
            GraphCommand.PenDraw pendraw = new GraphCommand.PenDraw();
            graphCommand.AddCommand(FunctionType.PenDraw, pendraw);
            GraphCommand.Mosaic mosaic = new GraphCommand.Mosaic();
            graphCommand.AddCommand(FunctionType.Mosaic, mosaic);
            GraphCommand.Soften soften = new GraphCommand.Soften();
            graphCommand.AddCommand(FunctionType.Soften, soften);
            GraphCommand.Atomization atomization = new GraphCommand.Atomization();
            graphCommand.AddCommand(FunctionType.Atomization, atomization);
            GraphCommand.Embossment embossment = new GraphCommand.Embossment();
            graphCommand.AddCommand(FunctionType.Embossment, embossment);
            GraphCommand.Cartoonify cartoonify = new GraphCommand.Cartoonify();
            graphCommand.AddCommand(FunctionType.Cartoonify, cartoonify);
            GraphCommand.RGBChannel rgbchannel = new GraphCommand.RGBChannel();
            graphCommand.AddCommand(FunctionType.RGBChannel, rgbchannel);
            GraphCommand.Skin skin = new GraphCommand.Skin();
            graphCommand.AddCommand(FunctionType.Skin, skin);
            GraphCommand.NoiseEffect noiseeffect = new GraphCommand.NoiseEffect();
            graphCommand.AddCommand(FunctionType.NoiseEffect, noiseeffect);
            GraphCommand.DisplacementFilter displacementfilter = new GraphCommand.DisplacementFilter();
            graphCommand.AddCommand(FunctionType.DisplacementFilter, displacementfilter);
            GraphCommand.LUTFilter lutfilter = new GraphCommand.LUTFilter();
            graphCommand.AddCommand(FunctionType.LUTFilter, lutfilter);
            GraphCommand.HighlightShadowPreciseAdjustProcess highlightshadowpreciseadjustprocess = new GraphCommand.HighlightShadowPreciseAdjustProcess();
            graphCommand.AddCommand(FunctionType.HighlightShadowPreciseAdjustProcess, highlightshadowpreciseadjustprocess);
            GraphCommand.ImageWarpWaveProcess imagewarpwaveprocess = new GraphCommand.ImageWarpWaveProcess();
            graphCommand.AddCommand(FunctionType.ImageWarpWaveProcess, imagewarpwaveprocess);
            GraphCommand.GlowingEdgesProcess glowingedgesprocess = new GraphCommand.GlowingEdgesProcess();
            graphCommand.AddCommand(FunctionType.GlowingEdgesProcess, glowingedgesprocess);
            GraphCommand.MedianFilterProcess medianfilterprocess = new GraphCommand.MedianFilterProcess();
            graphCommand.AddCommand(FunctionType.MedianFilterProcess, medianfilterprocess);
            GraphCommand.MaxFilterProcess maxfilterprocess = new GraphCommand.MaxFilterProcess();
            graphCommand.AddCommand(FunctionType.MaxFilterProcess, maxfilterprocess);
            GraphCommand.MinFilterProcess minfilterprocess = new GraphCommand.MinFilterProcess();
            graphCommand.AddCommand(FunctionType.MinFilterProcess, minfilterprocess);
            GraphCommand.GammaCorrectProcess gammacorrectprocess = new GraphCommand.GammaCorrectProcess();
            graphCommand.AddCommand(FunctionType.GammaCorrectProcess, gammacorrectprocess);
            GraphCommand.ChannelMixProcess channelmixprocess = new GraphCommand.ChannelMixProcess();
            graphCommand.AddCommand(FunctionType.ChannelMixProcess, channelmixprocess);
            GraphCommand.MeanProcess meanprocess = new GraphCommand.MeanProcess();
            graphCommand.AddCommand(FunctionType.MeanProcess, meanprocess);
            GraphCommand.AutoColorGradationAdjust autocolorgradationadjust = new GraphCommand.AutoColorGradationAdjust();
            graphCommand.AddCommand(FunctionType.AutoColorGradationAdjust, autocolorgradationadjust);
            GraphCommand.AutoContrastAdjust autocontrastadjust = new GraphCommand.AutoContrastAdjust();
            graphCommand.AddCommand(FunctionType.AutoContrastAdjust, autocontrastadjust);
            GraphCommand.HistagramEqualize histagramequalize = new GraphCommand.HistagramEqualize();
            graphCommand.AddCommand(FunctionType.HistagramEqualize, histagramequalize);
            GraphCommand.MotionBlur motionblur = new GraphCommand.MotionBlur();
            graphCommand.AddCommand(FunctionType.MotionBlur, motionblur);
            GraphCommand.TransformRotation transformrotation = new GraphCommand.TransformRotation();
            graphCommand.AddCommand(FunctionType.TransformRotation, transformrotation);
            GraphCommand.TransformScale transformscale = new GraphCommand.TransformScale();
            graphCommand.AddCommand(FunctionType.TransformScale, transformscale);
            GraphCommand.TransformRotationScale transformrotationscale = new GraphCommand.TransformRotationScale();
            graphCommand.AddCommand(FunctionType.TransformRotationScale, transformrotationscale);
            GraphCommand.TransformAffine transformaffine = new GraphCommand.TransformAffine();
            graphCommand.AddCommand(FunctionType.TransformAffine, transformaffine);
            GraphCommand.Threshold threshold = new GraphCommand.Threshold();
            graphCommand.AddCommand(FunctionType.Threshold, threshold);
            GraphCommand.TransformMirror transformmirror = new GraphCommand.TransformMirror();
            graphCommand.AddCommand(FunctionType.TransformMirror, transformmirror);
            GraphCommand.Fragment fragment = new GraphCommand.Fragment();
            graphCommand.AddCommand(FunctionType.Fragment, fragment);
            GraphCommand.HueSaturationAdjust huesaturationadjust = new GraphCommand.HueSaturationAdjust();
            graphCommand.AddCommand(FunctionType.HueSaturationAdjust, huesaturationadjust);
            GraphCommand.ColorTemperatureProcess colortemperatureprocess = new GraphCommand.ColorTemperatureProcess();
            graphCommand.AddCommand(FunctionType.ColorTemperatureProcess, colortemperatureprocess);
            GraphCommand.Posterize posterize = new GraphCommand.Posterize();
            graphCommand.AddCommand(FunctionType.Posterize, posterize);
            GraphCommand.Desaturate desaturate = new GraphCommand.Desaturate();
            graphCommand.AddCommand(FunctionType.Desaturate, desaturate);
            GraphCommand.OverExposure overexposure = new GraphCommand.OverExposure();
            graphCommand.AddCommand(FunctionType.OverExposure, overexposure);
            GraphCommand.ExposureAdjust exposureadjust = new GraphCommand.ExposureAdjust();
            graphCommand.AddCommand(FunctionType.ExposureAdjust, exposureadjust);
            GraphCommand.LightnessAdjustProcess lightnessadjustprocess = new GraphCommand.LightnessAdjustProcess();
            graphCommand.AddCommand(FunctionType.LightnessAdjustProcess, lightnessadjustprocess);
            GraphCommand.ShadowAdjust shadowadjust = new GraphCommand.ShadowAdjust();
            graphCommand.AddCommand(FunctionType.ShadowAdjust, shadowadjust);
            GraphCommand.HighlightAdjust highlightadjust = new GraphCommand.HighlightAdjust();
            graphCommand.AddCommand(FunctionType.HighlightAdjust, highlightadjust);
            GraphCommand.Invert invert = new GraphCommand.Invert();
            graphCommand.AddCommand(FunctionType.Invert, invert);
            GraphCommand.SurfaceBlur surfaceblur = new GraphCommand.SurfaceBlur();
            graphCommand.AddCommand(FunctionType.SurfaceBlur, surfaceblur);
            GraphCommand.NLinearBrightContrastAdjust nlinearbrightcontrastadjust = new GraphCommand.NLinearBrightContrastAdjust();
            graphCommand.AddCommand(FunctionType.NLinearBrightContrastAdjust, nlinearbrightcontrastadjust);
            GraphCommand.LinearBrightContrastAdjust linearbrightcontrastadjust = new GraphCommand.LinearBrightContrastAdjust();
            graphCommand.AddCommand(FunctionType.LinearBrightContrastAdjust, linearbrightcontrastadjust);
            GraphCommand.FindEdgesProcess findedgesprocess = new GraphCommand.FindEdgesProcess();
            graphCommand.AddCommand(FunctionType.FindEdgesProcess, findedgesprocess);
            GraphCommand.GaussFilterProcess gaussfilterprocess = new GraphCommand.GaussFilterProcess();
            graphCommand.AddCommand(FunctionType.GaussFilterProcess, gaussfilterprocess);
            GraphCommand.MeanFilterProcess meanfilterprocess = new GraphCommand.MeanFilterProcess();
            graphCommand.AddCommand(FunctionType.MeanFilterProcess, meanfilterprocess);
            GraphCommand.HighPassProcess highpassprocess = new GraphCommand.HighPassProcess();
            graphCommand.AddCommand(FunctionType.HighPassProcess, highpassprocess);
            GraphCommand.USMProcess usmprocess = new GraphCommand.USMProcess();
            graphCommand.AddCommand(FunctionType.USMProcess, usmprocess);
            GraphCommand.SaturationProcess saturationprocess = new GraphCommand.SaturationProcess();
            graphCommand.AddCommand(FunctionType.SaturationProcess, saturationprocess);
            GraphCommand.NaturalSaturationProcess naturalsaturationprocess = new GraphCommand.NaturalSaturationProcess();
            graphCommand.AddCommand(FunctionType.NaturalSaturationProcess, naturalsaturationprocess);
            GraphCommand.ColorBalanceProcess colorbalanceprocess = new GraphCommand.ColorBalanceProcess();
            graphCommand.AddCommand(FunctionType.ColorBalanceProcess, colorbalanceprocess);
            GraphCommand.Relief relief = new GraphCommand.Relief();
            graphCommand.AddCommand(FunctionType.Relief, relief);
            GraphCommand.DiffusionProcess diffusionprocess = new GraphCommand.DiffusionProcess();
            graphCommand.AddCommand(FunctionType.DiffusionProcess, diffusionprocess);
            GraphCommand.MosaicProcess mosaicprocess = new GraphCommand.MosaicProcess();
            graphCommand.AddCommand(FunctionType.MosaicProcess, mosaicprocess);
            GraphCommand.RadialBlurProcess radialblurprocess = new GraphCommand.RadialBlurProcess();
            graphCommand.AddCommand(FunctionType.RadialBlurProcess, radialblurprocess);
            GraphCommand.ZoomBlurProcess zoomblurprocess = new GraphCommand.ZoomBlurProcess();
            graphCommand.AddCommand(FunctionType.ZoomBlurProcess, zoomblurprocess);
            GraphCommand.ColorLevelProcess colorlevelprocess = new GraphCommand.ColorLevelProcess();
            graphCommand.AddCommand(FunctionType.ColorLevelProcess, colorlevelprocess);
            GraphCommand.BlackwhiteProcess blackwhiteprocess = new GraphCommand.BlackwhiteProcess();
            graphCommand.AddCommand(FunctionType.BlackwhiteProcess, blackwhiteprocess);
            GraphCommand.LUTFilterProcess lutfilterprocess = new GraphCommand.LUTFilterProcess();
            graphCommand.AddCommand(FunctionType.LUTFilterProcess, lutfilterprocess);
            GraphCommand.SmartBlurProcess smartblurprocess = new GraphCommand.SmartBlurProcess();
            graphCommand.AddCommand(FunctionType.SmartBlurProcess, smartblurprocess);
            GraphCommand.AnisotropicFilter anisotropicfilter = new GraphCommand.AnisotropicFilter();
            graphCommand.AddCommand(FunctionType.AnisotropicFilter, anisotropicfilter);
        }
    }
}
