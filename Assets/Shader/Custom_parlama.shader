// Restored from original serialized render states and GLES3 program(s), not DummyShaderTextExporter.
Shader "Custom/parlama"{
Properties {

_MainTex ("Sprite Texture", 2D) = "white" { }

_ShineColor ("Shine Color", Color) = (1,1,1,1)

_ShineSpeed ("Shine Speed", Float) = 1.0

_ShineWidth ("Shine Width", Float) = 0.20000000298023224

}

SubShader{Tags{"QUEUE"="Overlay" "RenderType"="Transparent"}
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
float4 _ShineColor;float _ShineSpeed,_ShineWidth;
V vert(A v){V o;o.pos=UnityObjectToClipPos(float4(v.vertex.xyz,1));o.uv=v.uv*_MainTex_ST.xy+_MainTex_ST.zw;o.color=v.color;return o;}
float4 frag(V i):SV_Target{float4 c=tex2D(_MainTex,i.uv);float band=abs(i.uv.x+sin(-_Time.y*_ShineSpeed));if(band<_ShineWidth)c.rgb+=_ShineColor.rgb*(1-band/_ShineWidth);return c;}

ENDCG
}
}
}
