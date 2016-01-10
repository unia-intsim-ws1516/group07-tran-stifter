using UnityEngine;
using System.Collections;

namespace UnityStandardAssets.ImageEffects
{
    public class MakeWhiteTransparent : PostEffectsBase
    {
        //private GameObject tagCameraWithoutBreath;

        public Shader transparentShader = null;
        private Material transparentMaterial = null;

        private Texture2D originalTex = null;

        new void Start()
        {
            //tagCameraWithoutBreath = GameObject.FindWithTag("Breath");
        }

        // Update is called once per frame
        void Update()
        {

        }

        public override bool CheckResources()
        {
            CheckSupport(false);

            transparentMaterial = CheckShaderAndCreateMaterial(transparentShader, transparentMaterial);

            if (!isSupported)
                ReportAutoDisable();
            return isSupported;
        }

        public void OnRenderImage(RenderTexture source, RenderTexture destination)
        {
            CheckResources();
            originalTex = new Texture2D(source.width, source.height);

            // change texture. every white pixel should be transparent after this
            int y = 0;
            while (y < originalTex.height)
            {
                int x = 0;
                while (x < originalTex.width)
                {
                    Color colorAtPixel = new Color();
                    colorAtPixel = originalTex.GetPixel(x, y);
                    if (colorAtPixel[0] == 1 && colorAtPixel[1] == 1 && colorAtPixel[2] == 1 && colorAtPixel[3] == 1)
                    {
                        originalTex.SetPixel(x, y, Color.clear);
                    }
                    else
                    {
                        originalTex.SetPixel(x, y, new Color(colorAtPixel[0], colorAtPixel[1], colorAtPixel[2], colorAtPixel[3] ));
                    }
                    ++x;
                }
                ++y;
            }
            originalTex.Apply();

            transparentMaterial.SetTexture("_MainTex", originalTex);

            Graphics.Blit(source, destination, transparentMaterial, 0);
        }
    }
}
