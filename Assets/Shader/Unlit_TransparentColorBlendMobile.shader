// Restored from original serialized render states and GLES3 program(s), not DummyShaderTextExporter.
Shader "Unlit/TransparentColorBlendMobile"{
Properties {

_Color ("Color", Color) = (1,1,1,1)

_MainTex ("Main Tex (optional)", 2D) = "white" { }

_UseMainTex ("Use MainTex (0 = off, 1 = on)", Float) = 1.0

}

SubShader{Tags{"IGNOREPROJECTOR"="true" "QUEUE"="Transparent" "RenderType"="Transparent"}
Cull Off
ZWrite Off
ZTest LEqual
Blend SrcAlpha OneMinusSrcAlpha, SrcAlpha OneMinusSrcAlpha
Pass{
CGPROGRAM
#pragma target 3.0
#pragma vertex vert
#pragma fragment frag
#include "UnityCG.cginc"
struct A{float4 vertex:POSITION;float2 uv:TEXCOORD0;float4 color:COLOR;};
struct V{float4 pos:SV_POSITION;float2 uv:TEXCOORD0;float4 color:TEXCOORD1;};
sampler2D _MainTex;float4 _MainTex_ST;
float4 _Color;float _UseMainTex;
V vert(A v){V o;o.pos=UnityObjectToClipPos(float4(v.vertex.xyz,1));o.uv=v.uv;o.color=v.color*_Color;return o;}
float4 frag(V i):SV_Target{return lerp(float4(1,1,1,1),tex2D(_MainTex,i.uv),saturate(_UseMainTex))*i.color;}

ENDCG
}
}
}
