// HLSL port of shipped GLES300 code. Not recovered original authoring text.
// Source sharedassets1.assets path_id=873; 84609903fad822e0121dd21b36d98d9fc2ea7221957a53137f1da73e86782c67
Shader "Custom/SpriteOutline_Builtin_Improved"
{
Properties {

_Color ("Tint", Color) = (1,1,1,1)

_OutlineColor ("Outline Color", Color) = (1,0,0,1)

_OutlineWidth ("Outline Width", Range(0, 10)) = 1.5

_MainTex ("Main Texture", 2D) = "white" { }

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
            sampler2D _MainTex; float4 _Color; float4 _OutlineColor; float _OutlineWidth;

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
                float4 center = tex2D(_MainTex, input.uv) * _Color;
                float effectiveAlpha = center.a * input.color.a;
                float2 stepUV = _OutlineWidth / _ScreenParams.xy;
                float neighborAlpha = 0.0;
                [unroll] for (int x = -1; x <= 1; x++)
                    [unroll] for (int y = -1; y <= 1; y++)
                        neighborAlpha = max(neighborAlpha, tex2D(_MainTex, input.uv + float2(x, y) * stepUV).a);
                float3 rgb = effectiveAlpha * (center.rgb * input.color.rgb - _OutlineColor.rgb) + _OutlineColor.rgb;
                return float4(rgb, max(effectiveAlpha, neighborAlpha));
            }
            ENDCG
        }
    }
    Fallback Off
}
