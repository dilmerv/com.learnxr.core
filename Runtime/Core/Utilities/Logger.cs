using System.Linq;
using TMPro;
using UnityEngine;
using System;

namespace LearnXR.Core.Utilities
{
    public class Logger : Singleton<Logger>
    {
        [SerializeField]
        private TextMeshProUGUI debugAreaText;

        [SerializeField]
        private bool enableDebug;

        [SerializeField]
        private int maxLines = 15;
        
        void Awake()
        {
            if (debugAreaText == null)
            {
                debugAreaText = GetComponent<TextMeshProUGUI>();
            }
            debugAreaText.text = string.Empty;
        }

        void OnEnable()
        {
            debugAreaText.enabled = enableDebug;
            enabled = enableDebug;

            if (enabled)
            {
                debugAreaText.text += $"<color=\"white\">{DateTime.Now:HH:mm:ss.fff} {GetType().Name} enabled</color>\n";
            }
        }

        public void Clear() => debugAreaText.text = string.Empty;

        public void LogInfo(string message)
        {
            ClearLines();
            debugAreaText.text += $"<color=\"green\">{DateTime.Now:HH:mm:ss.fff} {message}</color>\n";
        }

        public void LogError(string message)
        {
            ClearLines();
            debugAreaText.text += $"<color=\"red\">{DateTime.Now:HH:mm:ss.fff} {message}</color>\n";
        }

        public void LogWarning(string message)
        {
            ClearLines();
            debugAreaText.text += $"<color=\"yellow\">{DateTime.Now:HH:mm:ss.fff} {message}</color>\n";
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