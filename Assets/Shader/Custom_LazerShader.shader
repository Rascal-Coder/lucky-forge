// HLSL port of shipped GLES300 code. Not recovered original authoring text.
// Source sharedassets1.assets path_id=871; 558810e8f14910163d741d8f76a048b1dc2dd1f1e697c5a401c1af676f557c7e
Shader "Custom/LazerShader"
{
Properties {

_Color ("Lazer Rengi", Color) = (1,0,0,1)

_Speed ("INVALID_UTF8_STRING", Float) = 2.0

_Width ("INVALID_UTF8_STRING", Float) = 0.30000001192092896

}

    SubShader
    {
        Tags { "QUEUE"="Transparent" "RenderType"="Transparent" }
        Cull Off
        ZWrite Off
        ZTest LEqual
        Blend SrcAlpha One, SrcAlpha One
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
            float4 _Color; float _Speed; float _Width;

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
                float t = saturate((abs(input.uv.y - 0.5) - _Width) / (-_Width));
                float edge = t * t * (3.0 - 2.0 * t);
                float wave = sin(input.uv.x * 10.0 + _Time.y * _Speed) * 0.5 + 0.5;
                float alpha = wave * edge;
                // _Color.a is not consumed by the compiled fragment program.
                return float4(alpha * _Color.rgb, alpha);
            }
            ENDCG
        }
    }
    Fallback Off
}
