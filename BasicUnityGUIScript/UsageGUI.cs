﻿using System;
using UnityEngine;
namespace BasicUnityGUIScript
{
    public class UsageGUI : MonoBehaviour
    {
        public static bool buttonFeature, toggleFeature;
        public static string StrInput = " ";
        public static float SliderInput = 0f;
        public static float ToatlNeededHeight = 0f;
        public static float BtnHeight = 35f;
        public static float BtnSpace = 5f;
        public static Rect GroupRect()
        {
            return new Rect()
            {
                x = (Screen.width / 2) - 100f,
                y = (Screen.height / 2) - 150f,
                width = 200f,
                height = 300f
            };
        }
        public void Start()
        {
          
        }

        public void OnGUI()
        {
            float y = GroupRect().y;
            float btn = 0f;
           
            /* Assign our button style */
            GUIDrawHelper.InitButonStyle();

            /* Draw Label */
            GUIDrawHelper.DrawLabel(Screen.width / 2, GroupRect().y - 40f, 23, Color.red, true, "Welcome User");

            /* Draw Background */
            GUIDrawHelper.DrawBackground(18, Color.white, GroupRect().x,y , GroupRect().width, ToatlNeededHeight, "Menu Title", true, Color.red);
            y += 25f;
            /* Draw Button */
            if(GUIDrawHelper.DrawButton(GroupRect().x + 5f, y, GroupRect().width - 10f, 35f, "button Feature"))
            {
                // place a code here
            }
            y += 40f;
            btn++;
            /* Draw String Input */
            GUIDrawHelper.DrawStringInput(StrInput, GroupRect().x + 5f, y, GroupRect().width - 10f, 35f, 255);
            y += 40f;
            btn++;
            /* Horizontal Slider */
            GUIDrawHelper.DrawSliderInput(false, SliderInput, GroupRect().x + 5f, GroupRect().y + 145f, GroupRect().width - 10f, 35f, 0f, GroupRect().width - 10f);
            y += 40f;
            btn++;
            float th = (btn * BtnHeight) + (btn * BtnSpace) + 5f;
            if (ToatlNeededHeight != th) ToatlNeededHeight = th;
        }
        public void Update()
        {

        }
    }
}