using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace BasicUnityGUIScript
{
    public static class PlainTextures
    {
        static Texture2D redtexture,
         yellowtexture,
         greentexture,
         cyantexture,
         bluetexture,
         purpletexture,
         whitetexture,
         blacktexture,
         customtexture;

        public static Texture2D NewTexture2D { get { return new Texture2D(1, 1); } }
        public static Texture2D GetTextureByColor(Color clr)
        {
            if (clr == Color.red) return RedTexture;
            if (clr == Color.yellow) return YellowTexture;
            if (clr == Color.green) return GreenTexture;
            if (clr == Color.cyan) return CyanTexture;
            if (clr == Color.blue) return BlueTexture;
            if (clr == Color.magenta) return PurpleTexture;
            if (clr == Color.white) return WhiteTexture;
            if (clr == Color.black) return BlackTexture;
            return CustomTexture(clr);
        }
        public static Texture2D RedTexture
        {
            get
            {
                if (redtexture == null)
                {
                    redtexture = NewTexture2D;
                    redtexture.SetPixel(0, 0, Color.red);
                    redtexture.Apply();
                }
                return redtexture;
            }
        }

        public static Texture2D YellowTexture
        {
            get
            {
                if (yellowtexture == null)
                {
                    yellowtexture = NewTexture2D;
                    yellowtexture.SetPixel(0, 0, Color.yellow);
                    yellowtexture.Apply();
                }
                return yellowtexture;
            }
        }

        public static Texture2D GreenTexture
        {
            get
            {
                if (greentexture == null)
                {
                    greentexture = NewTexture2D;
                    greentexture.SetPixel(0, 0, Color.green);
                    greentexture.Apply();
                }
                return greentexture;
            }
        }

        public static Texture2D CyanTexture
        {
            get
            {
                if (cyantexture == null)
                {
                    cyantexture = NewTexture2D;
                    cyantexture.SetPixel(0, 0, Color.cyan);
                    cyantexture.Apply();
                }
                return cyantexture;
            }
        }

        public static Texture2D BlueTexture
        {
            get
            {
                if (bluetexture == null)
                {
                    bluetexture = NewTexture2D;
                    bluetexture.SetPixel(0, 0, Color.blue);
                    bluetexture.Apply();
                }
                return bluetexture;
            }
        }

        public static Texture2D PurpleTexture
        {
            get
            {
                if (purpletexture == null)
                {
                    purpletexture = NewTexture2D;
                    purpletexture.SetPixel(0, 0, Color.magenta);
                    purpletexture.Apply();
                }
                return purpletexture;
            }
        }

        public static Texture2D WhiteTexture
        {
            get
            {
                if (whitetexture == null)
                {
                    whitetexture = NewTexture2D;
                    whitetexture.SetPixel(0, 0, Color.white);
                    whitetexture.Apply();
                }
                return whitetexture;
            }
        }

        public static Texture2D BlackTexture
        {
            get
            {
                if (blacktexture == null)
                {
                    blacktexture = NewTexture2D;
                    blacktexture.SetPixel(0, 0, Color.black);
                    blacktexture.Apply();
                }
                return blacktexture;
            }
        }

        public static Texture2D CustomTexture(Color clr)
        {
            if (customtexture == null)
            {
                customtexture = NewTexture2D;
            }
            if (customtexture.GetPixel(0, 0) != clr)
            {
                customtexture.SetPixel(0, 0, new Color(clr.r, clr.g, clr.b, clr.a));
                customtexture.Apply();
            }
            return customtexture;
        }
        public static Color GetColorFromTexture(Texture2D tex)
        {
            return tex.GetPixel(0, 0);
        }
    }
}
