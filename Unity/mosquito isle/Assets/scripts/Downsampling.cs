using System;
using UnityEngine;

namespace UnityStandardAssets.ImageEffects
{
    [ExecuteInEditMode]
    [RequireComponent(typeof(Camera))]
    [AddComponentMenu("Downsampling")]
    public class Downsampling : PostEffectsBase
    {

        //[Range(0, 10)]
        private float downsampleX = 1;
        //[Range(0, 10)]
        private float downsampleY = 1;

        // low resolution at 594 ommatidia, high resolution at 858 (paper said: 600 to 900)
        private const int targetWidthLow = 33;
        private const int targetHeightLow = 18;
        private const int targetWidthHigh = 39;
        private const int targetHeightHigh = 22;
        public Boolean lowResolution = false;

        public Shader blurShader = null;
        private Material blurMaterial = null;

 

        new void Start()
        {
            
        }

        public override bool CheckResources()
        {
            CheckSupport(false);

            blurMaterial = CheckShaderAndCreateMaterial(blurShader, blurMaterial);

            if (!isSupported)
                ReportAutoDisable();
            return isSupported;
        }

        public void OnDisable()
        {
            if (blurMaterial)
                DestroyImmediate(blurMaterial);
        }

        public void OnRenderImage(RenderTexture source, RenderTexture destination)
        {
            if (CheckResources() == false)
            {
                Graphics.Blit(source, destination);
                return;
            }

            //float widthMod = 1.0f / (1.0f * (1 << downsample));

            //blurMaterial.SetVector("_Parameter", new Vector4(blurSize * widthMod, -blurSize * widthMod, 0.0f, 0.0f));
            //source.filterMode = FilterMode.Bilinear;

            // calculate how often we have to downsample. Calculate the new height and width.
            int rtW=0, rtH=0;
            if (lowResolution == false )
            {
                downsampleX = Mathf.Log( source.width / targetWidthHigh, 2 );
                downsampleY = Mathf.Log( source.height / targetHeightHigh, 2 );

                rtW = (int)(source.width / Mathf.Pow(2, downsampleX));
                rtH = (int)(source.height / Mathf.Pow(2, downsampleY));
            }
            else
            {
                downsampleX = Mathf.Log(source.width / targetWidthLow, 2);
                downsampleY = Mathf.Log(source.height / targetHeightLow, 2);

                rtW = (int)(source.width / Mathf.Pow(2, downsampleX));
                rtH = (int)(source.height / Mathf.Pow(2, downsampleY));
            }

             


            // downsample
            RenderTexture rt = RenderTexture.GetTemporary(rtW, rtH, 0, source.format);

            rt.filterMode = FilterMode.Point;
            Graphics.Blit(source, rt, blurMaterial, 0);

            //var passOffs = blurType == BlurType.StandardGauss ? 0 : 2;

            //for (int i = 0; i < blurIterations; i++)
            //{
                //float iterationOffs = (i * 1.0f);
                //blurMaterial.SetVector("_Parameter", new Vector4(blurSize * widthMod + iterationOffs, -blurSize * widthMod - iterationOffs, 0.0f, 0.0f));

                //// vertical blur
                //RenderTexture rt2 = RenderTexture.GetTemporary(rtW, rtH, 0, source.format);
                //rt2.filterMode = FilterMode.Bilinear;
                //Graphics.Blit(rt, rt2, blurMaterial, 1 + passOffs);
                //RenderTexture.ReleaseTemporary(rt);
                //rt = rt2;

                //// horizontal blur
                //rt2 = RenderTexture.GetTemporary(rtW, rtH, 0, source.format);
                //rt2.filterMode = FilterMode.Bilinear;
                //Graphics.Blit(rt, rt2, blurMaterial, 2 + passOffs);
                //RenderTexture.ReleaseTemporary(rt);
                //rt = rt2;
            //}

            Graphics.Blit(rt, destination);

            RenderTexture.ReleaseTemporary(rt);
        }
    }
}
