Shader "UI/IconOutline"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _OutlineColor ("Outline Color", Color) = (0,0,0,1)
        _OutlineWidth ("Outline Width", Range(0.001, 0.5)) = 0.005
    }
    SubShader
    {
        Tags {"Queue"="Overlay" "IgnoreProjector"="True" "RenderType"="Transparent"}
        Cull Off
        Lighting Off
        ZWrite Off
        Blend SrcAlpha OneMinusSrcAlpha

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"

            struct appdata_t
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };

            sampler2D _MainTex;
            float4 _MainTex_ST;
            float4 _OutlineColor;
            float _OutlineWidth;

            v2f vert (appdata_t v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                return o;
            }

            float4 frag (v2f i) : SV_Target
            {
                float2 offsets[8] = {
                    float2(-_OutlineWidth, -_OutlineWidth), float2(0, -_OutlineWidth), float2(_OutlineWidth, -_OutlineWidth),
                    float2(-_OutlineWidth, 0),                               float2(_OutlineWidth, 0),
                    float2(-_OutlineWidth, _OutlineWidth), float2(0, _OutlineWidth), float2(_OutlineWidth, _OutlineWidth)
                };

                float4 texColor = tex2D(_MainTex, i.uv);
                float outlineFactor = 0;

                for (int j = 0; j < 8; j++)
                {
                    float4 sampleColor = tex2D(_MainTex, i.uv + offsets[j]);
                    outlineFactor += sampleColor.a; // Check alpha to detect the sprite shape
                }

                outlineFactor = outlineFactor / 8; // Normalize

                // If the current pixel is transparent but neighboring pixels are not, draw the outline
                if (texColor.a < 0.1 && outlineFactor > 0.1)
                {
                    return _OutlineColor;
                }

                return texColor;
            }
            ENDCG
        }
    }
}
