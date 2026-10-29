// HLSL port of shipped GLES300 code. Not recovered original authoring text.
// Source sharedassets1.assets path_id=864; 570f3d007e06c4ada9c7b34792371a0112f39df8ffc8bc362f24f06c07c8de0e
Shader "Custom/FlashEffectWithSpriteRendererColor_Sorted"
{
Properties {

_MainTex ("Texture", 2D) = "white" { }

_FlashColor ("Flash Color", Color) = (1,1,1,1)

_FlashAmount ("Flash Amount", Range(0, 1)) = 0.0

_ClipThreshold ("Alpha Clip Threshold", Range(0, 1)) = 0.10000000149011612

}

    SubShader
    {
        Tags { "QUEUE"="Transparent" "RenderType"="Transparent" }
        LOD 200
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
            sampler2D _MainTex; float4 _FlashColor; float _FlashAmount; float _ClipThreshold;

            Varyings vert(Attributes input)
            {
                Varyings o;
                // The GLES column-vector sequence adds the translation column with w=1.
                o.pos = UnityObjectToClipPos(float4(input.vertex.xyz, 1.0));
                o.uv = input.uv;
                o.color = input.color;
                return o;
            }

            float4 frag(Varyings input) : SV_Target
            {
                float4 sampled = tex2D(_MainTex, input.uv);
                clip(sampled.a * input.color.a - _ClipThreshold);
                float4 color = sampled * input.color;
                color.rgb += _FlashAmount * (_FlashColor.rgb - sampled.rgb * input.color.rgb);
                return color;
            }
            ENDCG
        }
    }
    Fallback Off
}
