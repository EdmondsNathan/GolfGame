Shader "UI/IconUnderlay"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _Color ("Main Color", Color) = (1,1,1,1)
        _UnderlayColor ("Underlay Color", Color) = (0,0,0,1)
        _UnderlayOffset ("Underlay Offset", Vector) = (2,-2,0,0)
        _UnderlayScale ("Scale", Float) = 1.05
        _Center ("Center", Float) = 0.5
    }
    SubShader
    {
        Tags {"Queue"="Transparent" "IgnoreProjector"="True" "RenderType"="Transparent"}
        Blend SrcAlpha OneMinusSrcAlpha
        Cull Off
        ZWrite Off

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
                float4 pos : SV_POSITION;
                float2 uv : TEXCOORD0;
            };

            sampler2D _MainTex;
            float4 _Color;
            float4 _UnderlayColor;
            float4 _UnderlayOffset;
            float _UnderlayScale;
            float _Center;

            v2f vert (appdata_t v)
            {
                v2f o;
                o.pos = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                // Compute scaled UVs for underlay
                float2 center = float2(_Center, _Center);
                float2 scaledUV = (i.uv - center) * _UnderlayScale + center;

                // Apply offset
                float2 offsetUV = scaledUV + _UnderlayOffset.xy * 0.01;

                // Sample the underlay (scaled and offset)
                fixed4 underlayCol = tex2D(_MainTex, offsetUV) * _UnderlayColor;

                //Sample main texture
                fixed4 col = tex2D(_MainTex, i.uv) * _Color;

                // Combine underlay and main image
                return lerp(underlayCol, col, col.a);
            }
            ENDCG
        }
    }
}
