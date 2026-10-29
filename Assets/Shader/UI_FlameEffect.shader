// HLSL port of shipped GLES300 code. Not recovered original authoring text.
// Source sharedassets1.assets path_id=869; d61ac6e4bd80b259997dea41c0f4aead2bd55e7a4b5310ea88b99d0dfdcfae8f
Shader "UI/FlameEffect"
{
Properties {

_MainTex ("Sprite Texture", 2D) = "white" { }

_FlameColor ("Flame Color", Color) = (1,0.5,0,1)

_FlameIntensity ("Flame Intensity", Range(0, 1)) = 0.5

_WaveSpeed ("Wave Speed", Range(0.1, 5)) = 2.0

_WaveStrength ("Wave Strength", Range(0, 0.1)) = 0.019999999552965164

}

    SubShader
    {
        Tags { "QUEUE"="Transparent" "RenderType"="Transparent" }
        Cull Off
        ZWrite Off
        ZTest LEqual
        Blend SrcAlpha OneMinusSrcAlpha, SrcAlpha OneMinusSrcAlpha
        BlendOp Add, Add
        ColorMask RGBA
        ZClip On
        AlphaToMask Off
        Stencil { Ref 0 ReadMask 255 WriteMask 255 Comp Always Pass Keep Fail Keep ZFail Keep }
        Pass
        {
            CGPROGRAM

            #pragma target 3.0
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"
            struct Attributes { float4 vertex : POSITION; float2 uv : TEXCOORD0; float4 color : COLOR; };
            struct Varyings { float4 pos : SV_POSITION; float2 uv : TEXCOORD0; float4 color : TEXCOORD1; };
            sampler2D _MainTex; float4 _FlameColor; float _FlameIntensity; float _WaveSpeed; float _WaveStrength;

            Varyings vert(Attributes input)
            {
                Varyings o;
                o.pos = UnityObjectToClipPos(float4(input.vertex.xyz, 1.0));
                o.uv.x = sin(input.uv.y * 20.0 + _Time.y * _WaveSpeed) * _WaveStrength + input.uv.x;
                o.uv.y = input.uv.y;
                o.color = input.color; // Unused in the source fragment program.
                return o;
            }
            float4 frag(Varyings input) : SV_Target
            {
                float4 sampled = tex2D(_MainTex, input.uv);
                bool outside = input.uv.x > 1.0 || input.uv.x < 0.0;
                float flame = sin(input.uv.y * 10.0 + _Time.y * 5.0) * _FlameIntensity;
                float4 expanded = float4(sampled.rgb + _FlameColor.rgb * flame, max(flame, sampled.a));
                return outside ? expanded : sampled;
            }
            ENDCG
        }
    }
    Fallback Off
}
