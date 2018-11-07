using System;
using System.Collections.Generic;
using UnityEngine.Rendering;

namespace UnityEngine.Experimental.Rendering
{
    public class TexturePadding
    {
        static readonly int _RectOffset = Shader.PropertyToID("_RectOffset");
        static readonly int _InOutTexture = Shader.PropertyToID("_InOutTexture");

        ComputeShader m_CS;
        int m_KMainTopRight;
        int m_KMainTop;
        int m_KMainRight;

        // Avoid garbage generated by .SetComputeIntParams methods (using params int[] will generate an array on the fly)
        int[] m_IntParams = new int[2];

        public TexturePadding(ComputeShader cs)
        {
            m_CS = cs;
            m_KMainTopRight     = m_CS.FindKernel("KMainTopRight");
            m_KMainTop          = m_CS.FindKernel("KMainTop");
            m_KMainRight        = m_CS.FindKernel("KMainRight");
        }

        public void Pad(CommandBuffer cmd, RenderTexture inOutTexture, RectInt from, RectInt to)
        {
            if (from.width < to.width)
            {
                m_IntParams[0] = from.width;
                m_IntParams[1] = 0;
                cmd.SetComputeIntParams(m_CS, _RectOffset, m_IntParams);
                cmd.SetComputeTextureParam(m_CS, m_KMainRight, _InOutTexture, inOutTexture);
                cmd.DispatchCompute(m_CS, m_KMainRight, to.width - from.width, from.height, 1);
            }
            if (from.height < to.height)
            {
                m_IntParams[0] = 0;
                m_IntParams[1] = from.height;
                cmd.SetComputeIntParams(m_CS, _RectOffset, m_IntParams);
                cmd.SetComputeTextureParam(m_CS, m_KMainTop, _InOutTexture, inOutTexture);
                cmd.DispatchCompute(m_CS, m_KMainTop, from.width, to.height - from.height, 1);
            }
            if (from.width < to.width && from.height < to.height)
            {
                m_IntParams[0] = from.width;
                m_IntParams[1] = from.height;
                cmd.SetComputeIntParams(m_CS, _RectOffset, m_IntParams);
                cmd.SetComputeTextureParam(m_CS, m_KMainTopRight, _InOutTexture, inOutTexture);
                cmd.DispatchCompute(m_CS, m_KMainTopRight, to.width - from.width, to.height - from.height, 1);
            }
        }
    }
}
