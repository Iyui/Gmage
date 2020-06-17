using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
namespace Gmage.GraphCommand
{
    class ZPhotoGraphCommand
    {
    }


    /// <summary>
    /// 
    /// </summary>
    public class NoiseEffect : IGraphCommand
    {
        public string _Name { get; } = "NoiseEffect";
        //
        public Bitmap bitmap
        {
            set; get;
        }
        public Parameter Parameter
        {
            set; get;
        }

        public Bitmap Draw()
        {
            var _bitmap = bitmap.Clone() as Bitmap;
            return Config.zPhoto.NoiseEffect(_bitmap, Parameter.iParameter[0], Parameter.fParameter[0], Parameter.fParameter[1]);
        }

        public void Undo()
        {

        }
    }
    /// <summary>
    /// 
    /// </summary>
    public class DisplacementFilter : IGraphCommand
    {
        public string _Name { get; } = "DisplacementFilter";
        //
        public Bitmap bitmap
        {
            set; get;
        }
        public Parameter Parameter
        {
            set; get;
        }

        public Bitmap Draw()
        {
            var _bitmap = bitmap.Clone() as Bitmap;
            return Config.zPhoto.DisplacementFilter(_bitmap, Parameter.mask, Parameter.iParameter[0], Parameter.iParameter[1]);
        }

        public void Undo()
        {

        }
    }
    /// <summary>
    /// 
    /// </summary>
    public class LUTFilter : IGraphCommand
    {
        public string _Name { get; } = "LUTFilter";
        //
        public Bitmap bitmap
        {
            set; get;
        }
        public Parameter Parameter
        {
            set; get;
        }

        public Bitmap Draw()
        {
            var _bitmap = bitmap.Clone() as Bitmap;
            return Config.zPhoto.LUTFilter(_bitmap, Parameter.mask, Parameter.iParameter[0]);
        }

        public void Undo()
        {

        }
    }
    /// <summary>
    /// 
    /// </summary>
    public class HighlightShadowPreciseAdjustProcess : IGraphCommand
    {
        public string _Name { get; } = "HighlightShadowPreciseAdjustProcess";
        //
        public Bitmap bitmap
        {
            set; get;
        }
        public Parameter Parameter
        {
            set; get;
        }

        public Bitmap Draw()
        {
            var _bitmap = bitmap.Clone() as Bitmap;
            return Config.zPhoto.HighlightShadowPreciseAdjustProcess(_bitmap, Parameter.fParameter[0], Parameter.fParameter[1]);
        }

        public void Undo()
        {

        }
    }
    /// <summary>
    /// 
    /// </summary>
    public class ImageWarpWaveProcess : IGraphCommand
    {
        public string _Name { get; } = "ImageWarpWaveProcess";
        //
        public Bitmap bitmap
        {
            set; get;
        }
        public Parameter Parameter
        {
            set; get;
        }

        public Bitmap Draw()
        {
            var _bitmap = bitmap.Clone() as Bitmap;
            return Config.zPhoto.ImageWarpWaveProcess(_bitmap, Parameter.iParameter[0]);
        }

        public void Undo()
        {

        }
    }
    /// <summary>
    /// 
    /// </summary>
    public class GlowingEdgesProcess : IGraphCommand
    {
        public string _Name { get; } = "GlowingEdgesProcess";
        //
        public Bitmap bitmap
        {
            set; get;
        }
        public Parameter Parameter
        {
            set; get;
        }

        public Bitmap Draw()
        {
            var _bitmap = bitmap.Clone() as Bitmap;
            return Config.zPhoto.GlowingEdgesProcess(_bitmap, Parameter.iParameter[0], Parameter.iParameter[1], Parameter.iParameter[2]);
        }

        public void Undo()
        {

        }
    }
    /// <summary>
    /// 
    /// </summary>
    public class MedianFilterProcess : IGraphCommand
    {
        public string _Name { get; } = "MedianFilterProcess";
        //
        public Bitmap bitmap
        {
            set; get;
        }
        public Parameter Parameter
        {
            set; get;
        }

        public Bitmap Draw()
        {
            var _bitmap = bitmap.Clone() as Bitmap;
            return Config.zPhoto.MedianFilterProcess(_bitmap,Parameter.iParameter[0]);
        }

        public void Undo()
        {

        }
    }
    /// <summary>
    /// 
    /// </summary>
    public class MaxFilterProcess : IGraphCommand
    {
        public string _Name { get; } = "MaxFilterProcess";
        //
        public Bitmap bitmap
        {
            set; get;
        }
        public Parameter Parameter
        {
            set; get;
        }

        public Bitmap Draw()
        {
            var _bitmap = bitmap.Clone() as Bitmap;
            return Config.zPhoto.MaxFilterProcess(_bitmap,Parameter.iParameter[0]);
        }

        public void Undo()
        {

        }
    }
    /// <summary>
    /// 
    /// </summary>
    public class MinFilterProcess : IGraphCommand
    {
        public string _Name { get; } = "MinFilterProcess";
        //
        public Bitmap bitmap
        {
            set; get;
        }
        public Parameter Parameter
        {
            set; get;
        }

        public Bitmap Draw()
        {
            var _bitmap = bitmap.Clone() as Bitmap;
            return Config.zPhoto.MinFilterProcess(_bitmap,Parameter.iParameter[0]);
        }

        public void Undo()
        {

        }
    }
    /// <summary>
    /// 
    /// </summary>
    public class GammaCorrectProcess : IGraphCommand
    {
        public string _Name { get; } = "GammaCorrectProcess";
        //
        public Bitmap bitmap
        {
            set; get;
        }
        public Parameter Parameter
        {
            set; get;
        }

        public Bitmap Draw()
        {
            var _bitmap = bitmap.Clone() as Bitmap;
            return Config.zPhoto.GammaCorrectProcess(_bitmap, Parameter.iParameter[0]);
        }

        public void Undo()
        {

        }
    }
    /// <summary>
    /// 
    /// </summary>
    public class ChannelMixProcess : IGraphCommand
    {
        public string _Name { get; } = "ChannelMixProcess";
        //
        public Bitmap bitmap
        {
            set; get;
        }
        public Parameter Parameter
        {
            set; get;
        }

        public Bitmap Draw()
        {
            var _bitmap = bitmap.Clone() as Bitmap;
            return Config.zPhoto.ChannelMixProcess(_bitmap, Parameter.iParameter[0], Parameter.iParameter[1], Parameter.iParameter[2], Parameter.iParameter[3], Parameter.iParameter[4], Parameter.bParameter[0], Parameter.bParameter[1]);
        }

        public void Undo()
        {

        }
    }
    /// <summary>
    /// 
    /// </summary>
    public class MeanProcess : IGraphCommand
    {
        public string _Name { get; } = "MeanProcess";
        //
        public Bitmap bitmap
        {
            set; get;
        }
        public Parameter Parameter
        {
            set; get;
        }

        public Bitmap Draw()
        {
            var _bitmap = bitmap.Clone() as Bitmap;
            return Config.zPhoto.MeanProcess(_bitmap);
        }

        public void Undo()
        {

        }
    }
    /// <summary>
    /// 
    /// </summary>
    public class AutoColorGradationAdjust : IGraphCommand
    {
        public string _Name { get; } = "AutoColorGradationAdjust";
        //
        public Bitmap bitmap
        {
            set; get;
        }
        public Parameter Parameter
        {
            set; get;
        }

        public Bitmap Draw()
        {
            var _bitmap = bitmap.Clone() as Bitmap;
            return Config.zPhoto.AutoColorGradationAdjust(_bitmap);
        }

        public void Undo()
        {

        }
    }
    /// <summary>
    /// 
    /// </summary>
    public class AutoContrastAdjust : IGraphCommand
    {
        public string _Name { get; } = "AutoContrastAdjust";
        //
        public Bitmap bitmap
        {
            set; get;
        }
        public Parameter Parameter
        {
            set; get;
        }

        public Bitmap Draw()
        {
            var _bitmap = bitmap.Clone() as Bitmap;
            return Config.zPhoto.AutoContrastAdjust(_bitmap);
        }

        public void Undo()
        {

        }
    }
    /// <summary>
    /// 
    /// </summary>
    public class HistagramEqualize : IGraphCommand
    {
        public string _Name { get; } = "HistagramEqualize";
        //
        public Bitmap bitmap
        {
            set; get;
        }
        public Parameter Parameter
        {
            set; get;
        }

        public Bitmap Draw()
        {
            var _bitmap = bitmap.Clone() as Bitmap;
            return Config.zPhoto.HistagramEqualize(_bitmap);
        }

        public void Undo()
        {

        }
    }
    /// <summary>
    /// 
    /// </summary>
    public class MotionBlur : IGraphCommand
    {
        public string _Name { get; } = "MotionBlur";
        //
        public Bitmap bitmap
        {
            set; get;
        }
        public Parameter Parameter
        {
            set; get;
        }

        public Bitmap Draw()
        {
            var _bitmap = bitmap.Clone() as Bitmap;
            return Config.zPhoto.MotionBlur(_bitmap, Parameter.iParameter[0], Parameter.iParameter[1]);
        }

        public void Undo()
        {

        }
    }
    /// <summary>
    /// 
    /// </summary>
    public class TransformRotation : IGraphCommand
    {
        public string _Name { get; } = "TransformRotation";
        //
        public Bitmap bitmap
        {
            set; get;
        }
        public Parameter Parameter
        {
            set; get;
        }

        public Bitmap Draw()
        {
            var _bitmap = bitmap.Clone() as Bitmap;
            return Config.zPhoto.TransformRotation(_bitmap, Parameter.fParameter[0], Parameter.iParameter[0], Parameter.iParameter[1]);
        }

        public void Undo()
        {

        }
    }
    /// <summary>
    /// 
    /// </summary>
    public class TransformScale : IGraphCommand
    {
        public string _Name { get; } = "TransformScale";
        //
        public Bitmap bitmap
        {
            set; get;
        }
        public Parameter Parameter
        {
            set; get;
        }

        public Bitmap Draw()
        {
            var _bitmap = bitmap.Clone() as Bitmap;
            return Config.zPhoto.TransformScale(_bitmap, Parameter.fParameter[0], Parameter.iParameter[0], Parameter.iParameter[1]);
        }

        public void Undo()
        {

        }
    }
    /// <summary>
    /// 
    /// </summary>
    public class TransformRotationScale : IGraphCommand
    {
        public string _Name { get; } = "TransformRotationScale";
        //
        public Bitmap bitmap
        {
            set; get;
        }
        public Parameter Parameter
        {
            set; get;
        }

        public Bitmap Draw()
        {
            var _bitmap = bitmap.Clone() as Bitmap;
            return Config.zPhoto.TransformRotationScale(_bitmap, Parameter.fParameter[0], Parameter.fParameter[1], Parameter.iParameter[0], Parameter.iParameter[1]);
        }

        public void Undo()
        {

        }
    }
    /// <summary>
    /// 
    /// </summary>
    public class TransformAffine : IGraphCommand
    {
        public string _Name { get; } = "TransformAffine";
        //
        public Bitmap bitmap
        {
            set; get;
        }
        public Parameter Parameter
        {
            set; get;
        }

        public Bitmap Draw()
        {
            var _bitmap = bitmap.Clone() as Bitmap;
            return Config.zPhoto.TransformAffine(_bitmap, Parameter.fParameter, Parameter.iParameter[0], Parameter.iParameter[1]);
        }

        public void Undo()
        {

        }
    }
    /// <summary>
    /// 
    /// </summary>
    public class Threshold : IGraphCommand
    {
        public string _Name { get; } = "Threshold";
        //
        public Bitmap bitmap
        {
            set; get;
        }
        public Parameter Parameter
        {
            set; get;
        }

        public Bitmap Draw()
        {
            var _bitmap = bitmap.Clone() as Bitmap;
            return Config.zPhoto.Threshold(_bitmap, Parameter.iParameter[0]);
        }

        public void Undo()
        {

        }
    }
    /// <summary>
    /// 
    /// </summary>
    public class TransformMirror : IGraphCommand
    {
        public string _Name { get; } = "TransformMirror";
        //
        public Bitmap bitmap
        {
            set; get;
        }
        public Parameter Parameter
        {
            set; get;
        }

        public Bitmap Draw()
        {
            var _bitmap = bitmap.Clone() as Bitmap;
            return Config.zPhoto.TransformMirror(_bitmap, Parameter.iParameter[0]);
        }

        public void Undo()
        {

        }
    }
    /// <summary>
    /// 
    /// </summary>
    public class Fragment : IGraphCommand
    {
        public string _Name { get; } = "Fragment";
        //
        public Bitmap bitmap
        {
            set; get;
        }
        public Parameter Parameter
        {
            set; get;
        }

        public Bitmap Draw()
        {
            var _bitmap = bitmap.Clone() as Bitmap;
            return Config.zPhoto.Fragment(_bitmap);
        }

        public void Undo()
        {

        }
    }
    /// <summary>
    /// 
    /// </summary>
    public class HueSaturationAdjust : IGraphCommand
    {
        public string _Name { get; } = "HueSaturationAdjust";
        //
        public Bitmap bitmap
        {
            set; get;
        }
        public Parameter Parameter
        {
            set; get;
        }

        public Bitmap Draw()
        {
            var _bitmap = bitmap.Clone() as Bitmap;
            return Config.zPhoto.HueSaturationAdjust(_bitmap, Parameter.iParameter[0], Parameter.iParameter[1]);
        }

        public void Undo()
        {

        }
    }
    /// <summary>
    /// 
    /// </summary>
    public class ColorTemperatureProcess : IGraphCommand
    {
        public string _Name { get; } = "ColorTemperatureProcess";
        //
        public Bitmap bitmap
        {
            set; get;
        }
        public Parameter Parameter
        {
            set; get;
        }

        public Bitmap Draw()
        {
            var _bitmap = bitmap.Clone() as Bitmap;
            return Config.zPhoto.ColorTemperatureProcess(_bitmap, Parameter.iParameter[0]);
        }

        public void Undo()
        {

        }
    }
    /// <summary>
    /// 
    /// </summary>
    public class Posterize : IGraphCommand
    {
        public string _Name { get; } = "Posterize";
        //
        public Bitmap bitmap
        {
            set; get;
        }
        public Parameter Parameter
        {
            set; get;
        }

        public Bitmap Draw()
        {
            var _bitmap = bitmap.Clone() as Bitmap;
            return Config.zPhoto.Posterize(_bitmap, Parameter.iParameter[0]);
        }

        public void Undo()
        {

        }
    }
    /// <summary>
    /// 
    /// </summary>
    public class Desaturate : IGraphCommand
    {
        public string _Name { get; } = "Desaturate";
        //
        public Bitmap bitmap
        {
            set; get;
        }
        public Parameter Parameter
        {
            set; get;
        }

        public Bitmap Draw()
        {
            var _bitmap = bitmap.Clone() as Bitmap;
            return Config.zPhoto.Desaturate(_bitmap);
        }

        public void Undo()
        {

        }
    }
    /// <summary>
    /// 
    /// </summary>
    public class OverExposure : IGraphCommand
    {
        public string _Name { get; } = "OverExposure";
        //
        public Bitmap bitmap
        {
            set; get;
        }
        public Parameter Parameter
        {
            set; get;
        }

        public Bitmap Draw()
        {
            var _bitmap = bitmap.Clone() as Bitmap;
            return Config.zPhoto.OverExposure(_bitmap);
        }

        public void Undo()
        {

        }
    }
    /// <summary>
    /// 
    /// </summary>
    public class ExposureAdjust : IGraphCommand
    {
        public string _Name { get; } = "ExposureAdjust";
        //
        public Bitmap bitmap
        {
            set; get;
        }
        public Parameter Parameter
        {
            set; get;
        }

        public Bitmap Draw()
        {
            var _bitmap = bitmap.Clone() as Bitmap;
            return Config.zPhoto.ExposureAdjust(_bitmap, Parameter.iParameter[0]);
        }

        public void Undo()
        {

        }
    }
    /// <summary>
    /// 
    /// </summary>
    public class LightnessAdjustProcess : IGraphCommand
    {
        public string _Name { get; } = "LightnessAdjustProcess";
        //
        public Bitmap bitmap
        {
            set; get;
        }
        public Parameter Parameter
        {
            set; get;
        }

        public Bitmap Draw()
        {
            var _bitmap = bitmap.Clone() as Bitmap;
            return Config.zPhoto.LightnessAdjustProcess(_bitmap, Parameter.iParameter[0]);
        }

        public void Undo()
        {

        }
    }
    /// <summary>
    /// 
    /// </summary>
    public class ShadowAdjust : IGraphCommand
    {
        public string _Name { get; } = "ShadowAdjust";
        //
        public Bitmap bitmap
        {
            set; get;
        }
        public Parameter Parameter
        {
            set; get;
        }

        public Bitmap Draw()
        {
            var _bitmap = bitmap.Clone() as Bitmap;
            return Config.zPhoto.ShadowAdjust(_bitmap, Parameter.iParameter[0], Parameter.iParameter[1]);
        }

        public void Undo()
        {

        }
    }
    /// <summary>
    /// 
    /// </summary>
    public class HighlightAdjust : IGraphCommand
    {
        public string _Name { get; } = "HighlightAdjust";
        //
        public Bitmap bitmap
        {
            set; get;
        }
        public Parameter Parameter
        {
            set; get;
        }

        public Bitmap Draw()
        {
            var _bitmap = bitmap.Clone() as Bitmap;
            return Config.zPhoto.HighlightAdjust(_bitmap, Parameter.iParameter[0], Parameter.iParameter[1]);
        }

        public void Undo()
        {

        }
    }
    /// <summary>
    /// 
    /// </summary>
    public class Invert : IGraphCommand
    {
        public string _Name { get; } = "Invert";
        //
        public Bitmap bitmap
        {
            set; get;
        }
        public Parameter Parameter
        {
            set; get;
        }

        public Bitmap Draw()
        {
            var _bitmap = bitmap.Clone() as Bitmap;
            return Config.zPhoto.Invert(_bitmap);
        }

        public void Undo()
        {

        }
    }
    /// <summary>
    /// 
    /// </summary>
    public class SurfaceBlur : IGraphCommand
    {
        public string _Name { get; } = "SurfaceBlur";
        //
        public Bitmap bitmap
        {
            set; get;
        }
        public Parameter Parameter
        {
            set; get;
        }

        public Bitmap Draw()
        {
            var _bitmap = bitmap.Clone() as Bitmap;
            return Config.zPhoto.SurfaceBlur(_bitmap, Parameter.iParameter[0], Parameter.iParameter[1]);
        }

        public void Undo()
        {

        }
    }
    /// <summary>
    /// 
    /// </summary>
    public class NLinearBrightContrastAdjust : IGraphCommand
    {
        public string _Name { get; } = "NLinearBrightContrastAdjust";
        //
        public Bitmap bitmap
        {
            set; get;
        }
        public Parameter Parameter
        {
            set; get;
        }

        public Bitmap Draw()
        {
            var _bitmap = bitmap.Clone() as Bitmap;
            return Config.zPhoto.NLinearBrightContrastAdjust(_bitmap, Parameter.iParameter[0], Parameter.iParameter[1], Parameter.iParameter[2]);
        }

        public void Undo()
        {

        }
    }
    /// <summary>
    /// 
    /// </summary>
    public class LinearBrightContrastAdjust : IGraphCommand
    {
        public string _Name { get; } = "LinearBrightContrastAdjust";
        //
        public Bitmap bitmap
        {
            set; get;
        }
        public Parameter Parameter
        {
            set; get;
        }

        public Bitmap Draw()
        {
            var _bitmap = bitmap.Clone() as Bitmap;
            return Config.zPhoto.LinearBrightContrastAdjust(_bitmap, Parameter.iParameter[0], Parameter.iParameter[1], Parameter.iParameter[2]);
        }

        public void Undo()
        {

        }
    }
    /// <summary>
    /// 
    /// </summary>
    public class FindEdgesProcess : IGraphCommand
    {
        public string _Name { get; } = "FindEdgesProcess";
        //
        public Bitmap bitmap
        {
            set; get;
        }
        public Parameter Parameter
        {
            set; get;
        }

        public Bitmap Draw()
        {
            var _bitmap = bitmap.Clone() as Bitmap;
            return Config.zPhoto.FindEdgesProcess(_bitmap);
        }

        public void Undo()
        {

        }
    }
    /// <summary>
    /// 
    /// </summary>
    public class GaussFilterProcess : IGraphCommand
    {
        public string _Name { get; } = "GaussFilterProcess";
        //
        public Bitmap bitmap
        {
            set; get;
        }
        public Parameter Parameter
        {
            set; get;
        }

        public Bitmap Draw()
        {
            var _bitmap = bitmap.Clone() as Bitmap;
            return Config.zPhoto.GaussFilterProcess(_bitmap, Parameter.fParameter[0]);
        }

        public void Undo()
        {

        }
    }
    /// <summary>
    /// 
    /// </summary>
    public class MeanFilterProcess : IGraphCommand
    {
        public string _Name { get; } = "MeanFilterProcess";
        //
        public Bitmap bitmap
        {
            set; get;
        }
        public Parameter Parameter
        {
            set; get;
        }

        public Bitmap Draw()
        {
            var _bitmap = bitmap.Clone() as Bitmap;
            return Config.zPhoto.MeanFilterProcess(_bitmap, Parameter.iParameter[0]);
        }

        public void Undo()
        {

        }
    }
    /// <summary>
    /// 
    /// </summary>
    public class HighPassProcess : IGraphCommand
    {
        public string _Name { get; } = "HighPassProcess";
        //
        public Bitmap bitmap
        {
            set; get;
        }
        public Parameter Parameter
        {
            set; get;
        }

        public Bitmap Draw()
        {
            var _bitmap = bitmap.Clone() as Bitmap;
            return Config.zPhoto.HighPassProcess(_bitmap, Parameter.fParameter[0]);
        }

        public void Undo()
        {

        }
    }
    /// <summary>
    /// 
    /// </summary>
    public class USMProcess : IGraphCommand
    {
        public string _Name { get; } = "USMProcess";
        //
        public Bitmap bitmap
        {
            set; get;
        }
        public Parameter Parameter
        {
            set; get;
        }

        public Bitmap Draw()
        {
            var _bitmap = bitmap.Clone() as Bitmap;
            return Config.zPhoto.USMProcess(_bitmap, Parameter.fParameter[0], Parameter.iParameter[0], Parameter.iParameter[1]);
        }

        public void Undo()
        {

        }
    }
    /// <summary>
    /// 
    /// </summary>
    public class SaturationProcess : IGraphCommand
    {
        public string _Name { get; } = "SaturationProcess";
        //
        public Bitmap bitmap
        {
            set; get;
        }
        public Parameter Parameter
        {
            set; get;
        }

        public Bitmap Draw()
        {
            var _bitmap = bitmap.Clone() as Bitmap;
            return Config.zPhoto.SaturationProcess(_bitmap, Parameter.iParameter[0]);
        }

        public void Undo()
        {

        }
    }
    /// <summary>
    /// 
    /// </summary>
    public class NaturalSaturationProcess : IGraphCommand
    {
        public string _Name { get; } = "NaturalSaturationProcess";
        //
        public Bitmap bitmap
        {
            set; get;
        }
        public Parameter Parameter
        {
            set; get;
        }

        public Bitmap Draw()
        {
            var _bitmap = bitmap.Clone() as Bitmap;
            return Config.zPhoto.NaturalSaturationProcess(_bitmap, Parameter.iParameter[0]);
        }

        public void Undo()
        {

        }
    }
    /// <summary>
    /// 
    /// </summary>
    public class ColorBalanceProcess : IGraphCommand
    {
        public string _Name { get; } = "ColorBalanceProcess";
        //
        public Bitmap bitmap
        {
            set; get;
        }
        public Parameter Parameter
        {
            set; get;
        }

        public Bitmap Draw()
        {
            var _bitmap = bitmap.Clone() as Bitmap;
            return Config.zPhoto.ColorBalanceProcess(_bitmap, Parameter.iParameter[0], Parameter.iParameter[1], Parameter.iParameter[2], Parameter.iParameter[3], Parameter.bParameter[0]);
        }

        public void Undo()
        {

        }
    }
    /// <summary>
    /// 
    /// </summary>
    public class Relief : IGraphCommand
    {
        public string _Name { get; } = "Relief";
        //
        public Bitmap bitmap
        {
            set; get;
        }
        public Parameter Parameter
        {
            set; get;
        }

        public Bitmap Draw()
        {
            var _bitmap = bitmap.Clone() as Bitmap;
            return Config.zPhoto.Relief(_bitmap, Parameter.iParameter[0], Parameter.iParameter[1]);
        }

        public void Undo()
        {

        }
    }
    /// <summary>
    /// 
    /// </summary>
    public class DiffusionProcess : IGraphCommand
    {
        public string _Name { get; } = "DiffusionProcess";
        //
        public Bitmap bitmap
        {
            set; get;
        }
        public Parameter Parameter
        {
            set; get;
        }

        public Bitmap Draw()
        {
            var _bitmap = bitmap.Clone() as Bitmap;
            return Config.zPhoto.DiffusionProcess(_bitmap, Parameter.iParameter[0]);
        }

        public void Undo()
        {

        }
    }
    /// <summary>
    /// 
    /// </summary>
    public class MosaicProcess : IGraphCommand
    {
        public string _Name { get; } = "MosaicProcess";
        //
        public Bitmap bitmap
        {
            set; get;
        }
        public Parameter Parameter
        {
            set; get;
        }

        public Bitmap Draw()
        {
            var _bitmap = bitmap.Clone() as Bitmap;
            return Config.zPhoto.MosaicProcess(_bitmap, Parameter.iParameter[0]);
        }

        public void Undo()
        {

        }
    }
    /// <summary>
    /// 
    /// </summary>
    public class RadialBlurProcess : IGraphCommand
    {
        public string _Name { get; } = "RadialBlurProcess";
        //
        public Bitmap bitmap
        {
            set; get;
        }
        public Parameter Parameter
        {
            set; get;
        }

        public Bitmap Draw()
        {
            var _bitmap = bitmap.Clone() as Bitmap;
            return Config.zPhoto.RadialBlurProcess(_bitmap, Parameter.iParameter[0]);
        }

        public void Undo()
        {

        }
    }
    /// <summary>
    /// 
    /// </summary>
    public class ZoomBlurProcess : IGraphCommand
    {
        public string _Name { get; } = "ZoomBlurProcess";
        //
        public Bitmap bitmap
        {
            set; get;
        }
        public Parameter Parameter
        {
            set; get;
        }

        public Bitmap Draw()
        {
            var _bitmap = bitmap.Clone() as Bitmap;
            return Config.zPhoto.ZoomBlurProcess(_bitmap, Parameter.iParameter[0], Parameter.iParameter[1]);
        }

        public void Undo()
        {

        }
    }
    /// <summary>
    /// 
    /// </summary>
    public class ColorLevelProcess : IGraphCommand
    {
        public string _Name { get; } = "ColorLevelProcess";
        //
        public Bitmap bitmap
        {
            set; get;
        }
        public Parameter Parameter
        {
            set; get;
        }

        public Bitmap Draw()
        {
            var _bitmap = bitmap.Clone() as Bitmap;
            return Config.zPhoto.ColorLevelProcess(_bitmap, Parameter.iParameter[0], Parameter.iParameter[1], Parameter.fParameter[0], Parameter.iParameter[2],Parameter.iParameter[3], Parameter.iParameter[4]);
        }

        public void Undo()
        {

        }
    }
    /// <summary>
    /// 
    /// </summary>
    public class BlackwhiteProcess : IGraphCommand
    {
        public string _Name { get; } = "BlackwhiteProcess";
        //
        public Bitmap bitmap
        {
            set; get;
        }
        public Parameter Parameter
        {
            set; get;
        }

        public Bitmap Draw()
        {
            var _bitmap = bitmap.Clone() as Bitmap;
            return Config.zPhoto.BlackwhiteProcess(_bitmap,Parameter.iParameter[0], Parameter.iParameter[1],  Parameter.iParameter[2], Parameter.iParameter[3], Parameter.iParameter[4], Parameter.iParameter[5]);
        }

        public void Undo()
        {

        }
    }
    /// <summary>
    /// 
    /// </summary>
    public class LUTFilterProcess : IGraphCommand
    {
        public string _Name { get; } = "LUTFilterProcess";
        //
        public Bitmap bitmap
        {
            set; get;
        }
        public Parameter Parameter
        {
            set; get;
        }

        public Bitmap Draw()
        {
            var _bitmap = bitmap.Clone() as Bitmap;
            return Config.zPhoto.LUTFilterProcess(_bitmap, Parameter.mask, Parameter.iParameter[0]);
        }

        public void Undo()
        {

        }
    }
    /// <summary>
    /// 
    /// </summary>
    public class SmartBlurProcess : IGraphCommand
    {
        public string _Name { get; } = "SmartBlurProcess";
        //
        public Bitmap bitmap
        {
            set; get;
        }
        public Parameter Parameter
        {
            set; get;
        }

        public Bitmap Draw()
        {
            var _bitmap = bitmap.Clone() as Bitmap;
            return Config.zPhoto.SmartBlurProcess(_bitmap, Parameter.iParameter[0], Parameter.iParameter[1]);
        }

        public void Undo()
        {

        }
    }
    /// <summary>
    /// 
    /// </summary>
    public class AnisotropicFilter : IGraphCommand
    {
        public string _Name { get; } = "AnisotropicFilter";
        //
        public Bitmap bitmap
        {
            set; get;
        }
        public Parameter Parameter
        {
            set; get;
        }

        public Bitmap Draw()
        {
            var _bitmap = bitmap.Clone() as Bitmap;
            return Config.zPhoto.AnisotropicFilter(_bitmap, Parameter.iParameter[0], Parameter.fParameter[0]);
        }

        public void Undo()
        {

        }
    }
}
