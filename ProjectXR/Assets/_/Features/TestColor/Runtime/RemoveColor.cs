using System;
using UnityEngine;
using System.Diagnostics;

namespace RemoveColor
{
    public class RemoveColor : MonoBehaviour
    {
        #region Publics
        
        public RenderTexture m_source;
        public Texture2D m_result;
        public double m_timeToExecute;
        
        #endregion
        
        #region Api Unity

        private void Update()
        {
            var timer = new Stopwatch();
            timer.Start();
            
            RenderTexture.active = m_source;
            m_result.ReadPixels(new Rect(0, 0, m_source.width, m_source.height), 0, 0);
            Color32[] pixels = m_result.GetPixels32();
            for (int i = 0; i < pixels.Length; i++)
                pixels[i].r = 0;
            m_result.SetPixels32(pixels);
            m_result.Apply();
            
            timer.Stop();
            
            TimeSpan timeTaken = timer.Elapsed;
            m_timeToExecute = timeTaken.TotalMilliseconds;
        }

        #endregion
        
        
        #region Utils
        
        public void SetRenderTexture(RenderTexture rt)
        {
            m_source = rt;
            
            if (m_result == null)
            {
                m_result = new Texture2D(rt.width, rt.height, TextureFormat.RGBA32, false);
            }
        }
        
        #endregion
        
        
        #region Private And Protected
        
        
        
        #endregion
    }
}
