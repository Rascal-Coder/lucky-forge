// HLSL port of shipped GLES300 code. Not recovered original authoring text.
// Source sharedassets1.assets path_id=868; c583c8d08e74a1f3bdeca3a7bb0163259e2548f53d5ea194c083d65ef35735b4,948d00f28ca02b2cc2faad734593fd709241105118f6a741330dbbf8bdd46138
Shader "Sprites-GrayScaleWithAutomaticMask"
{
Properties {

[PerRendererData] _MainTex ("Sprite Texture", 2D) = "white" { }

_Color ("Tint", Color) = (1,1,1,1)

[MaterialToggle] PixelSnap ("Pixel snap", Float) = 0.0

_GrayscaleAmount ("Grayscale Amount", Range(0, 1)) = 1.0

_StencilComp ("Stencil Comparison", Float) = 8.0

_Stencil ("Stencil ID", Float) = 0.0

_StencilOp ("Stencil Operation", Float) = 0.0

_StencilWriteMask ("Stencil Write Mask", Float) = 255.0

_StencilReadMask ("Stencil Read Mask", Float) = 255.0

_ColorMask ("Color Mask", Float) = 15.0

}

    SubShader
    {
        Tags { "CanUseSpriteAtlas"="true" "IGNOREPROJECTOR"="true" "PreviewType"="Plane" "QUEUE"="Transparent" "RenderType"="Transparent" }
        Cull Off
        ZWrite Off
        ZTest LEqual
        Blend SrcAlpha OneMinusSrcAlpha, SrcAlpha OneMinusSrcAlpha
        BlendOp Add, Add
        ColorMask [_ColorMask]
        ZClip On
        AlphaToMask Off
        Stencil { Ref [_Stencil] ReadMask [_StencilReadMask] WriteMask [_StencilWriteMask] Comp [_StencilComp] Pass [_StencilOp] Fail Keep ZFail Keep }
        Pass
        {
            CGPROGRAM

            #pragma target 3.0
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"
            struct Attributes { float4 vertex : POSITION; float2 uv : TEXCOORD0; float4 color : COLOR; };
            struct Varyings { float4 pos : SV_POSITION; float2 uv : TEXCOORD0; float4 color : TEXCOORD1; };
            sampler2D _MainTex; float4 _Color; float _GrayscaleAmount;

            #pragma multi_compile __ PIXELSNAP_ON
            float RoundEvenOriginal(float value)
            {
                float lower = floor(value);
                float part = value - lower;
                if (part > 0.5) return lower + 1.0;
                if (part < 0.5) return lower;
                return fmod(abs(lower), 2.0) == 1.0 ? lower + 1.0 : lower;
            }
            Varyings vert(Attributes input)
            {
                Varyings o;
                o.pos = UnityObjectToClipPos(float4(input.vertex.xyz, 1.0));
                #ifdef PIXELSNAP_ON
                float2 halfScreen = _ScreenParams.xy * 0.5;
                float2 pixel = o.pos.xy / o.pos.w * halfScreen;
                pixel = float2(RoundEvenOriginal(pixel.x), RoundEvenOriginal(pixel.y));
                o.pos.xy = pixel / halfScreen * o.pos.w;
                #endif
                o.uv = input.uv;
                o.color = input.color * _Color;
                return o;
            }
            float4 frag(Varyings input) : SV_Target
            {
                float4 sampled = tex2D(_MainTex, input.uv);
                float gray = dot(sampled.rgb, float3(0.300000012, 0.589999974, 0.109999999));
                sampled.rgb += _GrayscaleAmount * (gray.xxx - sampled.rgb);
                return sampled * input.color;
            }
            ENDCG
        }
    }
    Fallback Off
}
