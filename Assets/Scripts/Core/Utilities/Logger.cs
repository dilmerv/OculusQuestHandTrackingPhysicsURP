using System;
using System.Linq;
using DilmerGames.Core.Singletons;
using TMPro;
using UnityEngine;

namespace DilmerGames.Core.Utilities
{
    public class Logger : Singleton<Logger>
    {
        [SerializeField]
        private TextMeshProUGUI debugAreaText;

        [SerializeField]
        private bool enableDebug = false;

        [SerializeField]
        private int maxLines = 15;

        void OnEnable()
        {
            debugAreaText.enabled = enableDebug;
            enabled = enableDebug;
        }

        public void LogInfo(string message)
        {
            ClearLines();
            debugAreaText.text += $"{DateTime.Now.ToString("yyyy-dd-M--HH-mm-ss")} <color=\"white\">{message}</color>\n";
        }

        public void LogError(string message)
        {
            ClearLines();
            debugAreaText.text += $"{DateTime.Now.ToString("yyyy-dd-M--HH-mm-ss")} <color=\"red\">{message}</color>\n";
        }

        public void LogWarning(string message)
        {
            ClearLines();
            debugAreaText.text += $"{DateTime.Now.ToString("yyyy-dd-M--HH-mm-ss")} <color=\"yellow\">{message}</color>\n";
        }

        private void ClearLines()
        {
            if (debugAreaText.text.Split('\n').Count() >= maxLines)
            {
                debugAreaText.text = string.Empty;
            }
        }
    }
}