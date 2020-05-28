using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageAnalyze
{
    public class Config
    {
        public static FunctionType Model;
    }

    public enum FunctionType
    {
        /// <summary>
        /// 灰度化
        /// </summary>
        Empty,
        /// <summary>
        /// 灰度化
        /// </summary>
        Gray,
        /// <summary>
        /// 二值化
        /// </summary>
        Binarization,
        /// <summary>
        /// 反色
        /// </summary>
        Complementary,
        /// <summary>
        /// 锐化
        /// </summary>
        Sharpen,
        /// <summary>
        /// 亮度
        /// </summary>
        Lighten,
        /// <summary>
        /// 对比度
        /// </summary>
        Contrast,
        /// <summary>
        /// Robert边缘检测
        /// </summary>
        Robert,
        /// <summary>
        /// Smoothed边缘检测
        /// </summary>
        Smoothed,
        /// <summary>
        /// 椒盐噪声
        /// </summary>
        Salt,
        /// <summary>
        /// 高斯噪声
        /// </summary>
        GaussNoise,
        /// <summary>
        /// 中值滤波
        /// </summary>
        MedianFilter,
        /// <summary>
        /// 高斯平滑
        /// </summary>
        GaussBlur,
        /// <summary>
        /// 极坐标变换
        /// </summary>
        Polar,
        /// <summary>
        /// 傅里叶变换（频率谱）
        /// </summary>
        Frequency,
        /// <summary>
        /// 傅里叶逆变换
        /// </summary>
        BFT,
        /// <summary>
        /// 面部识别
        /// </summary>
        FaceRecognition,
    }
}
