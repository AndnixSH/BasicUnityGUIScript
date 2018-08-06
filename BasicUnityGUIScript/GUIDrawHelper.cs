﻿using System;
using UnityEngine;

namespace BasicUnityGUIScript
{
    public static class GUIDrawHelper
    {

        //fields
        static GUIStyle buttonStyle = null;
        static string _themeKey = "ThemeKey";
        static Vector2 _Scroller = Vector2.zero;
        public static Material renderMat;
        static float _BtnWidth = 260f,
            _BtnHeight = 35f,
            _BtnSpace = 5f,
            _Totalheight,
            _ScaleWidth = 1280f,
            _ScaleHeight = 720f,
            groupWidth = 260f,
            groupHeight = 300f;

        //properties
        public static float Totalheight { get { return _Totalheight; } set { _Totalheight = value; } }
        public static float BtnSpace { get { return _BtnSpace; } set { _BtnSpace = value; } }
        public static float BtnHeight { get { return _BtnHeight; } set { _BtnHeight = value; } }
        public static float BtnWidth { get { return _BtnWidth; } set { _BtnWidth = value; } }
        public static Vector2 Scroller { get { return _Scroller; } set { _Scroller = value; } }
        public static float ScaleWidth { get { return _ScaleWidth / (float)Screen.width; } }
        public static float ScaleHeight { get { return _ScaleHeight / (float)Screen.height; } }
        public static Vector3 GUIScale { get { return new Vector3(ScaleWidth, ScaleHeight, 1f); } }
        public static Matrix4x4 GUIMatrix { get { return Matrix4x4.TRS(Vector3.zero, Quaternion.identity, GUIScale); } }
        public static float GroupWidth { get { return groupWidth; } set { groupWidth = value; } }
        public static float GroupHeight { get { return groupHeight; } set { groupHeight = value; } }
        public static GUIStyle ButtonStyle { get { return buttonStyle; } set { buttonStyle = value; } }



    
        public static void onClickButtonThemeColor(Color clr)
        {
            ButtonStyle.onNormal.background = onHoverButton_Background(PlainTextures.GetTextureByColor(clr));
            ButtonStyle.active.background = onHoverButton_Background(PlainTextures.GetTextureByColor(clr));
            ButtonStyle.onActive.background = onHoverButton_Background(PlainTextures.GetTextureByColor(clr));
            ButtonStyle.hover.background = onHoverButton_Background(PlainTextures.GetTextureByColor(clr));
            ButtonStyle.onHover.background = onHoverButton_Background(PlainTextures.GetTextureByColor(clr));
            ButtonStyle.focused.background = onHoverButton_Background(PlainTextures.GetTextureByColor(clr));
            ButtonStyle.onFocused.background = onHoverButton_Background(PlainTextures.GetTextureByColor(clr));
            ButtonStyle.normal.textColor = clr;
        }
        public static void SetLastonClickColorTheme(string theme)
        {
            switch (theme)
            {
                case "Red":
                    onClickButtonThemeColor(Color.red);
                    PlayerPrefs.SetString(_themeKey, "Red");
                    break;
                case "Yellow":
                    onClickButtonThemeColor(Color.yellow);
                    PlayerPrefs.SetString(_themeKey, "Yellow");
                    break;
                case "Green":
                    onClickButtonThemeColor(Color.green);
                    PlayerPrefs.SetString(_themeKey, "Green");
                    break;
                case "Cyan":
                    onClickButtonThemeColor(Color.cyan);
                    PlayerPrefs.SetString(_themeKey, "Cyan");
                    break;
                case "Blue":
                    onClickButtonThemeColor(Color.blue);
                    PlayerPrefs.SetString(_themeKey, "Blue");
                    break;
                case "Purple":
                    onClickButtonThemeColor(Color.magenta);
                    PlayerPrefs.SetString(_themeKey, "Purple");
                    break;
                case "Default":
                    onClickButtonThemeColor(Color.white);
                    PlayerPrefs.SetString(_themeKey, "Default");
                    break;
            }
        }
        public static void LoadLastTheme()
        {
            if (PlayerPrefs.HasKey(_themeKey))
            {
                SetLastonClickColorTheme(PlayerPrefs.GetString(_themeKey));
            }
            else
            {
                SetLastonClickColorTheme("Default");
            }
        }
        public static void InitButonStyle()
        {
            if (ButtonStyle == null)
            {
                ButtonStyle = new GUIStyle(GUI.skin.button);
                ButtonStyle.normal.background = onNormalButton_Background();
                ButtonStyle.fontSize = 18;
                ButtonStyle.fontStyle = FontStyle.Normal;
                ButtonStyle.alignment = TextAnchor.MiddleCenter;
                onClickButtonThemeColor(Color.yellow);
            }
        }
        public static Texture2D onNormalButton_Background()
        {
            return PlainTextures.BlackTexture;
        }
        public static Texture2D onHoverButton_Background(Texture2D tex)
        {
            return tex;
        }

        public static bool DrawButton(float x, float y, float width, float height, string str)
        {
            return GUI.Button(new Rect(x, y, width, height), str, ButtonStyle);
        }

        public static string StringInput(out string inStr, string outStr, float x, float y, float width, float height, int strLen)
        {
            return inStr = GUI.TextField(new Rect(x, y, width, height), outStr, strLen);
        }
        public static string DrawStringInput(string str, float x, float y, float width, float height, int strLen)
        {
            return StringInput(out str, str, x, y, width, height, strLen);
        }
        public static float SliderInput(bool Vertical, out float inNum, float outNum, float x, float y, float width, float height, float numMin, float numMax)
        {
            return inNum = Vertical ? GUI.VerticalSlider(new Rect(x, y, width, height), outNum, numMin, numMax) : GUI.HorizontalSlider(new Rect(x, y, width, height), outNum, numMin, numMax);
        }
        public static float DrawSliderInput(bool Vertical, float outNum, float x, float y, float width, float height, float numMin, float numMax)
        {
            return SliderInput(Vertical, out outNum, outNum, x, y, width, height, numMin, numMax);
        }
        public static void DrawLabel(float x, float y, int fontsize, Color clr, bool center, string info)
        {
            var style = new GUIStyle(GUI.skin.label);
            style.fontSize = fontsize;
            style.fontStyle = FontStyle.Normal;
            style.normal.textColor = clr;
            var size = style.CalcSize(new GUIContent(info));
            var rect = new Rect(center ? x - (size.x / 2) : x, y, size.x, size.y);
            GUI.Label(rect, info, style);
        }
        public static void DrawBackground(int fontsize, Color clr, float x, float y, float width, float height, string title, bool border, Color borderClr)
        {
            var style = new GUIStyle(GUI.skin.box);
            style.fontSize = fontsize;
            style.normal.background = PlainTextures.GetTextureByColor(clr);
            if (border)
            {
                var bstyle = new GUIStyle(GUI.skin.box);
                style.normal.background = PlainTextures.GetTextureByColor(borderClr);
                GUI.Box(new Rect(x - 3f, y - 3, width + 6f, height + 6f), "");
            }
            GUI.Box(new Rect(x, y, width, height), title);
        }
        public static void DrawCrosshair()
        {
            GUI.DrawTexture(new Rect(Screen.width / 2 - 7f, Screen.height / 2 - 2f, 14f, 4f), PlainTextures.RedTexture);
            GUI.DrawTexture(new Rect(Screen.width / 2 - 2f, Screen.height / 2 - 7f, 4f, 14f), PlainTextures.RedTexture);
        }
    } 
}