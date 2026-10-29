// Restored from original serialized render states and GLES3 program(s), not DummyShaderTextExporter.
Shader "UI/Particles/AdditiveMasked"{
Properties {

_MainTex ("Particle Texture", 2D) = "white" { }

_Color ("Tint", Color) = (1,1,1,1)

_StencilComp ("Stencil Comparison", Float) = 8.0

_Stencil ("Stencil ID", Float) = 0.0

_StencilOp ("Stencil Operation", Float) = 0.0

_StencilWriteMask ("Stencil Write Mask", Float) = 255.0

_StencilReadMask ("Stencil Read Mask", Float) = 255.0

_ColorMask ("Color Mask", Float) = 15.0

}

SubShader{Tags{"IGNOREPROJECTOR"="true" "PreviewType"="Plane" "QUEUE"="Transparent" "RenderType"="Transparent"}
Cull Off
ZWrite Off
ZTest LEqual
Blend SrcAlpha One, SrcAlpha One
Stencil { Ref [_Stencil] Comp [_StencilComp] Pass [_StencilOp] ReadMask [_StencilReadMask] WriteMask [_StencilWriteMask] }
Pass{
CGPROGRAM
#pragma target 3.0
#pragma vertex vert
#pragma fragment frag
#include "UnityCG.cginc"
struct A{float4 vertex:POSITION;float2 uv:TEXCOORD0;float4 color:COLOR;};
struct V{float4 pos:SV_POSITION;float2 uv:TEXCOORD0;float4 color:TEXCOORD1;};
sampler2D _MainTex;float4 _MainTex_ST;
float4 _Color;
V vert(A v){V o;o.pos=UnityObjectToClipPos(float4(v.vertex.xyz,1));o.uv=v.uv*_MainTex_ST.xy+_MainTex_ST.zw;o.color=v.color*_Color;return o;}
float4 frag(V i):SV_Target{return tex2D(_MainTex,i.uv)*i.color;}

ENDCG
}
}
}
