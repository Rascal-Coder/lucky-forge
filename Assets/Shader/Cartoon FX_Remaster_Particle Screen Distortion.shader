// Original named GrabPass and four GLES forward variants, with D3D grab-UV convention adapter.
Shader "Cartoon FX/Remaster/Particle Screen Distortion"{
Properties {

[Toggle(_ALPHATEST_ON)] _UseAlphaClip ("Alpha Clipping (Cutout)", Float) = 0.0

_Cutoff ("Cutoff Threshold", Range(0.001, 1)) = 0.10000000149011612

[Toggle(_FADING_ON)] _UseSP ("Soft Particles", Float) = 0.0

_SoftParticlesFadeDistanceNear ("Near Fade", Float) = 0.0

_SoftParticlesFadeDistanceFar ("Far Fade", Float) = 1.0

[Toggle(_CFXR_EDGE_FADING)] _UseEF ("Edge Fade", Float) = 0.0

_EdgeFadePow ("Edge Fade Power", Float) = 1.0

_ScreenDistortionTex ("Distortion Texture", 2D) = "bump" { }

_ScreenDistortionScale ("Distortion Scale", Range(-0.5, 0.5)) = 0.10000000149011612

[Toggle(_DEBUG_VISUALIZE_DISTORTION)] _DebugVisualize ("Visualize Distortion Particles", Float) = 0.0

}

SubShader{Tags{"IGNOREPROJECTOR"="true" "PreviewType"="Plane" "QUEUE"="Transparent" "RenderType"="Transparent"}
GrabPass{"_GrabTexture"}
Pass{Name "BASE" Tags{"LightMode"="ForwardBase"}
Blend SrcAlpha OneMinusSrcAlpha, One One
ZWrite Off
ZTest LEqual
Cull Off
CGPROGRAM
#pragma target 3.0
#pragma vertex vert
#pragma fragment frag
#pragma multi_compile_particles
#pragma shader_feature_local _ _FADING_ON
#include "UnityCG.cginc"
#if defined(_FADING_ON) && defined(SOFTPARTICLES_ON)
// Original GLES 5
float _ScreenDistortionScale;
float _SoftParticlesFadeDistanceNear;
float _SoftParticlesFadeDistanceFar;
sampler2D _ScreenDistortionTex;
sampler2D _GrabTexture;
sampler2D _CameraDepthTexture;
struct A{float4 in_POSITION0:POSITION0;float4 in_COLOR0:COLOR0;float4 in_TEXCOORD0:TEXCOORD0;float4 in_TEXCOORD1:TEXCOORD1;};
struct V{float4 vertex:SV_POSITION;float4 vs_COLOR0:TEXCOORD0;float4 vs_TEXCOORD0:TEXCOORD1;float4 vs_TEXCOORD2:TEXCOORD2;float4 vs_TEXCOORD3:TEXCOORD3;};
V vert(A i){V o=(V)0;
float4 vs_TEXCOORD1;
float4 u_xlat0;
float4 u_xlat1;
float4 u_xlat2;
float u_xlat3;

    u_xlat0 = i.in_POSITION0.yyyy * transpose(unity_ObjectToWorld)[1];
    u_xlat0 = transpose(unity_ObjectToWorld)[0] * i.in_POSITION0.xxxx + u_xlat0;
    u_xlat0 = transpose(unity_ObjectToWorld)[2] * i.in_POSITION0.zzzz + u_xlat0;
    u_xlat0 = u_xlat0 + transpose(unity_ObjectToWorld)[3];
    u_xlat1 = u_xlat0.yyyy * transpose(unity_MatrixVP)[1];
    u_xlat1 = transpose(unity_MatrixVP)[0] * u_xlat0.xxxx + u_xlat1;
    u_xlat1 = transpose(unity_MatrixVP)[2] * u_xlat0.zzzz + u_xlat1;
    u_xlat1 = transpose(unity_MatrixVP)[3] * u_xlat0.wwww + u_xlat1;
    o.vertex = u_xlat1;
    o.vs_COLOR0 = i.in_COLOR0;
    o.vs_TEXCOORD0 = i.in_TEXCOORD0.xyxy;
    vs_TEXCOORD1 = i.in_TEXCOORD1;
    u_xlat2.xyz = u_xlat1.xyw * float3(0.5, 0.5, 0.5);
    o.vs_TEXCOORD2.zw = u_xlat1.zw;
    o.vs_TEXCOORD3.w = u_xlat1.w;
    o.vs_TEXCOORD2.xy = u_xlat2.zz + u_xlat2.xy;
    u_xlat3 = u_xlat0.y * transpose(unity_MatrixV)[1].z;
    u_xlat0.x = transpose(unity_MatrixV)[0].z * u_xlat0.x + u_xlat3;
    u_xlat0.x = transpose(unity_MatrixV)[2].z * u_xlat0.z + u_xlat0.x;
    u_xlat0.x = transpose(unity_MatrixV)[3].z * u_xlat0.w + u_xlat0.x;
    o.vs_TEXCOORD3.z = (-u_xlat0.x);
    u_xlat2.w = u_xlat2.y * _ProjectionParams.x;
    o.vs_TEXCOORD3.xy = u_xlat2.zz + u_xlat2.xw;
    // Platform adapter for original GLES grab UV: retain equations, account for D3D render-texture Y orientation.
    o.vs_TEXCOORD2.xy=ComputeGrabScreenPos(o.vertex).xy;
    return o;

}
float4 frag(V i):SV_Target{float4 result=0;
float2 u_xlat0;
float3 u_xlat16_0;
float u_xlat16_1;
float2 u_xlat2;
float3 u_xlat16_2;
float2 u_xlat16_3;
bool u_xlatb4;

    u_xlat0.xy = i.vs_TEXCOORD3.xy / i.vs_TEXCOORD3.ww;
    u_xlat0.x = tex2D(_CameraDepthTexture, u_xlat0.xy).x;
    u_xlat2.x = _ZBufferParams.z * u_xlat0.x + _ZBufferParams.w;
    u_xlat0.x = u_xlat0.x * _ProjectionParams.z + _ProjectionParams.y;
    u_xlat2.x = float(1.0) / u_xlat2.x;
    u_xlatb4 = unity_OrthoParams.w==1.0;
    u_xlat0.x = (u_xlatb4) ? u_xlat0.x : u_xlat2.x;
    u_xlat0.x = u_xlat0.x + (-_SoftParticlesFadeDistanceNear);
    u_xlat0.x = u_xlat0.x + (-i.vs_TEXCOORD3.z);
    u_xlat0.x = u_xlat0.x * _SoftParticlesFadeDistanceFar;
    u_xlat0.x = clamp(u_xlat0.x, 0.0, 1.0);
    u_xlat16_2.xyz = tex2D(_ScreenDistortionTex, i.vs_TEXCOORD0.xy).xyz;
    u_xlat16_1 = u_xlat16_2.z * i.vs_COLOR0.w;
    u_xlat16_3.xy = u_xlat16_2.xy * float2(2.0, 2.0) + float2(-1.0, -1.0);
    u_xlat16_3.xy = u_xlat16_3.xy * ((float2)(_ScreenDistortionScale));
    u_xlat2.xy = u_xlat16_3.xy * ((float2)(u_xlat16_1)) + i.vs_TEXCOORD2.xy;
    u_xlat0.x = u_xlat0.x * u_xlat16_1;
    result.w = min(u_xlat0.x, 1.0);
    u_xlat0.xy = u_xlat2.xy / i.vs_TEXCOORD2.ww;
    u_xlat16_0.xyz = tex2D(_GrabTexture, u_xlat0.xy).xyz;
    result.xyz = u_xlat16_0.xyz;
    return result;

}

#elif defined(_FADING_ON) && !defined(SOFTPARTICLES_ON)
// Original GLES 3
float _ScreenDistortionScale;
sampler2D _ScreenDistortionTex;
sampler2D _GrabTexture;
struct A{float4 in_POSITION0:POSITION0;float4 in_COLOR0:COLOR0;float4 in_TEXCOORD0:TEXCOORD0;float4 in_TEXCOORD1:TEXCOORD1;};
struct V{float4 vertex:SV_POSITION;float4 vs_COLOR0:TEXCOORD0;float4 vs_TEXCOORD0:TEXCOORD1;float4 vs_TEXCOORD2:TEXCOORD2;};
V vert(A i){V o=(V)0;
float4 vs_TEXCOORD1;
float4 u_xlat0;
float4 u_xlat1;

    u_xlat0 = i.in_POSITION0.yyyy * transpose(unity_ObjectToWorld)[1];
    u_xlat0 = transpose(unity_ObjectToWorld)[0] * i.in_POSITION0.xxxx + u_xlat0;
    u_xlat0 = transpose(unity_ObjectToWorld)[2] * i.in_POSITION0.zzzz + u_xlat0;
    u_xlat0 = u_xlat0 + transpose(unity_ObjectToWorld)[3];
    u_xlat1 = u_xlat0.yyyy * transpose(unity_MatrixVP)[1];
    u_xlat1 = transpose(unity_MatrixVP)[0] * u_xlat0.xxxx + u_xlat1;
    u_xlat1 = transpose(unity_MatrixVP)[2] * u_xlat0.zzzz + u_xlat1;
    u_xlat0 = transpose(unity_MatrixVP)[3] * u_xlat0.wwww + u_xlat1;
    o.vertex = u_xlat0;
    o.vs_COLOR0 = i.in_COLOR0;
    o.vs_TEXCOORD0 = i.in_TEXCOORD0.xyxy;
    vs_TEXCOORD1 = i.in_TEXCOORD1;
    u_xlat1.xyz = u_xlat0.xyw * float3(0.5, 0.5, 0.5);
    o.vs_TEXCOORD2.zw = u_xlat0.zw;
    o.vs_TEXCOORD2.xy = u_xlat1.zz + u_xlat1.xy;
    // Platform adapter for original GLES grab UV: retain equations, account for D3D render-texture Y orientation.
    o.vs_TEXCOORD2.xy=ComputeGrabScreenPos(o.vertex).xy;
    return o;

}
float4 frag(V i):SV_Target{float4 result=0;
float2 u_xlat0;
float3 u_xlat16_0;
float2 u_xlat16_1;
float u_xlat16_5;

    u_xlat16_0.xyz = tex2D(_ScreenDistortionTex, i.vs_TEXCOORD0.xy).xyz;
    u_xlat16_1.xy = u_xlat16_0.xy * float2(2.0, 2.0) + float2(-1.0, -1.0);
    u_xlat16_5 = u_xlat16_0.z * i.vs_COLOR0.w;
    u_xlat16_1.xy = u_xlat16_1.xy * ((float2)(_ScreenDistortionScale));
    u_xlat0.xy = u_xlat16_1.xy * ((float2)(u_xlat16_5)) + i.vs_TEXCOORD2.xy;
    result.w = min(u_xlat16_5, 1.0);
    u_xlat0.xy = u_xlat0.xy / i.vs_TEXCOORD2.ww;
    u_xlat16_0.xyz = tex2D(_GrabTexture, u_xlat0.xy).xyz;
    result.xyz = u_xlat16_0.xyz;
    return result;

}

#elif !defined(_FADING_ON) && defined(SOFTPARTICLES_ON)
// Original GLES 4
float _ScreenDistortionScale;
sampler2D _ScreenDistortionTex;
sampler2D _GrabTexture;
struct A{float4 in_POSITION0:POSITION0;float4 in_COLOR0:COLOR0;float4 in_TEXCOORD0:TEXCOORD0;float4 in_TEXCOORD1:TEXCOORD1;};
struct V{float4 vertex:SV_POSITION;float4 vs_COLOR0:TEXCOORD0;float4 vs_TEXCOORD0:TEXCOORD1;float4 vs_TEXCOORD2:TEXCOORD2;};
V vert(A i){V o=(V)0;
float4 vs_TEXCOORD1;
float4 u_xlat0;
float4 u_xlat1;

    u_xlat0 = i.in_POSITION0.yyyy * transpose(unity_ObjectToWorld)[1];
    u_xlat0 = transpose(unity_ObjectToWorld)[0] * i.in_POSITION0.xxxx + u_xlat0;
    u_xlat0 = transpose(unity_ObjectToWorld)[2] * i.in_POSITION0.zzzz + u_xlat0;
    u_xlat0 = u_xlat0 + transpose(unity_ObjectToWorld)[3];
    u_xlat1 = u_xlat0.yyyy * transpose(unity_MatrixVP)[1];
    u_xlat1 = transpose(unity_MatrixVP)[0] * u_xlat0.xxxx + u_xlat1;
    u_xlat1 = transpose(unity_MatrixVP)[2] * u_xlat0.zzzz + u_xlat1;
    u_xlat0 = transpose(unity_MatrixVP)[3] * u_xlat0.wwww + u_xlat1;
    o.vertex = u_xlat0;
    o.vs_COLOR0 = i.in_COLOR0;
    o.vs_TEXCOORD0 = i.in_TEXCOORD0.xyxy;
    vs_TEXCOORD1 = i.in_TEXCOORD1;
    u_xlat1.xyz = u_xlat0.xyw * float3(0.5, 0.5, 0.5);
    o.vs_TEXCOORD2.zw = u_xlat0.zw;
    o.vs_TEXCOORD2.xy = u_xlat1.zz + u_xlat1.xy;
    // Platform adapter for original GLES grab UV: retain equations, account for D3D render-texture Y orientation.
    o.vs_TEXCOORD2.xy=ComputeGrabScreenPos(o.vertex).xy;
    return o;

}
float4 frag(V i):SV_Target{float4 result=0;
float2 u_xlat0;
float3 u_xlat16_0;
float2 u_xlat16_1;
float u_xlat16_5;

    u_xlat16_0.xyz = tex2D(_ScreenDistortionTex, i.vs_TEXCOORD0.xy).xyz;
    u_xlat16_1.xy = u_xlat16_0.xy * float2(2.0, 2.0) + float2(-1.0, -1.0);
    u_xlat16_5 = u_xlat16_0.z * i.vs_COLOR0.w;
    u_xlat16_1.xy = u_xlat16_1.xy * ((float2)(_ScreenDistortionScale));
    u_xlat0.xy = u_xlat16_1.xy * ((float2)(u_xlat16_5)) + i.vs_TEXCOORD2.xy;
    result.w = min(u_xlat16_5, 1.0);
    u_xlat0.xy = u_xlat0.xy / i.vs_TEXCOORD2.ww;
    u_xlat16_0.xyz = tex2D(_GrabTexture, u_xlat0.xy).xyz;
    result.xyz = u_xlat16_0.xyz;
    return result;

}

#elif !defined(_FADING_ON) && !defined(SOFTPARTICLES_ON)
// Original GLES 2
float _ScreenDistortionScale;
sampler2D _ScreenDistortionTex;
sampler2D _GrabTexture;
struct A{float4 in_POSITION0:POSITION0;float4 in_COLOR0:COLOR0;float4 in_TEXCOORD0:TEXCOORD0;float4 in_TEXCOORD1:TEXCOORD1;};
struct V{float4 vertex:SV_POSITION;float4 vs_COLOR0:TEXCOORD0;float4 vs_TEXCOORD0:TEXCOORD1;float4 vs_TEXCOORD2:TEXCOORD2;};
V vert(A i){V o=(V)0;
float4 vs_TEXCOORD1;
float4 u_xlat0;
float4 u_xlat1;

    u_xlat0 = i.in_POSITION0.yyyy * transpose(unity_ObjectToWorld)[1];
    u_xlat0 = transpose(unity_ObjectToWorld)[0] * i.in_POSITION0.xxxx + u_xlat0;
    u_xlat0 = transpose(unity_ObjectToWorld)[2] * i.in_POSITION0.zzzz + u_xlat0;
    u_xlat0 = u_xlat0 + transpose(unity_ObjectToWorld)[3];
    u_xlat1 = u_xlat0.yyyy * transpose(unity_MatrixVP)[1];
    u_xlat1 = transpose(unity_MatrixVP)[0] * u_xlat0.xxxx + u_xlat1;
    u_xlat1 = transpose(unity_MatrixVP)[2] * u_xlat0.zzzz + u_xlat1;
    u_xlat0 = transpose(unity_MatrixVP)[3] * u_xlat0.wwww + u_xlat1;
    o.vertex = u_xlat0;
    o.vs_COLOR0 = i.in_COLOR0;
    o.vs_TEXCOORD0 = i.in_TEXCOORD0.xyxy;
    vs_TEXCOORD1 = i.in_TEXCOORD1;
    u_xlat1.xyz = u_xlat0.xyw * float3(0.5, 0.5, 0.5);
    o.vs_TEXCOORD2.zw = u_xlat0.zw;
    o.vs_TEXCOORD2.xy = u_xlat1.zz + u_xlat1.xy;
    // Platform adapter for original GLES grab UV: retain equations, account for D3D render-texture Y orientation.
    o.vs_TEXCOORD2.xy=ComputeGrabScreenPos(o.vertex).xy;
    return o;

}
float4 frag(V i):SV_Target{float4 result=0;
float2 u_xlat0;
float3 u_xlat16_0;
float2 u_xlat16_1;
float u_xlat16_5;

    u_xlat16_0.xyz = tex2D(_ScreenDistortionTex, i.vs_TEXCOORD0.xy).xyz;
    u_xlat16_1.xy = u_xlat16_0.xy * float2(2.0, 2.0) + float2(-1.0, -1.0);
    u_xlat16_5 = u_xlat16_0.z * i.vs_COLOR0.w;
    u_xlat16_1.xy = u_xlat16_1.xy * ((float2)(_ScreenDistortionScale));
    u_xlat0.xy = u_xlat16_1.xy * ((float2)(u_xlat16_5)) + i.vs_TEXCOORD2.xy;
    result.w = min(u_xlat16_5, 1.0);
    u_xlat0.xy = u_xlat0.xy / i.vs_TEXCOORD2.ww;
    u_xlat16_0.xyz = tex2D(_GrabTexture, u_xlat0.xy).xyz;
    result.xyz = u_xlat16_0.xyz;
    return result;

}

#endif
ENDCG
}}}
