// HLSL port of shipped GLES300 code. Not recovered original authoring text.
// Source sharedassets1.assets path_id=866; 57886c5c4e1e71ec3c1969cba43819ce733153c4728290714d9861ae04dec5dc
Shader "Custom/PixelWobbleTransparent"
{
Properties {

_MainTex ("Texture", 2D) = "white" { }

_Color ("Main Color", Color) = (1,1,1,1)

_WobbleAmount ("Wobble Amount", Float) = 0.05000000074505806

_Speed ("Speed", Float) = 1.0

_Transparency ("Transparency", Range(0, 1)) = 1.0

}

    SubShader
    {
        Tags { "QUEUE"="Transparent" "RenderType"="Transparent" }
        LOD 100
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
            sampler2D _MainTex; float4 _Color; float _WobbleAmount; float _Speed; float _Transparency;

            Varyings vert(Attributes input)
            {
                Varyings o;
                o.pos = UnityObjectToClipPos(float4(input.vertex.xyz, 1.0));
                float phase = _Time.y * _Speed;
                o.uv = input.uv + float2(sin(input.vertex.y * 5.0 + phase), cos(input.vertex.x * 5.0 + phase)) * _WobbleAmount;
                o.color = input.color; // Unused in the source fragment program.
                return o;
            }
            float4 frag(Varyings input) : SV_Target
            {
                float4 color = tex2D(_MainTex, input.uv) * _Color;
                color.a *= _Transparency;
                return color;
            }
            ENDCG
        }
    }
    Fallback Off
}
