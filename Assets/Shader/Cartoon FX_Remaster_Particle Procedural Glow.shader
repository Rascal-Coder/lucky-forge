// Direct stage-body port of shipped GLES variants; preserved material-driven render states.
Shader "Cartoon FX/Remaster/Particle Procedural Glow"{
Properties {

[Enum(UnityEngine.Rendering.BlendMode)] _SrcBlend ("Blend Source", Float) = 5.0

[Enum(UnityEngine.Rendering.BlendMode)] _DstBlend ("Blend Destination", Float) = 10.0

[Toggle(_CFXR_DISSOLVE)] _UseDissolve ("Enable Dissolve", Float) = 0.0

_DissolveTex ("Dissolve Texture", 2D) = "gray" { }

_DissolveSmooth ("Dissolve Smoothing", Range(0.0001, 0.5)) = 0.10000000149011612

[ToggleNoKeyword] _InvertDissolveTex ("Invert Dissolve Texture", Float) = 0.0

[KeywordEnum(P0, P2, P4, P8)] _CFXR_GLOW_POW ("Apply Power of", Float) = 0.0

_GlowMin ("Circle Min", Float) = 0.0

_GlowMax ("Circle Max", Float) = 1.0

_MaxValue ("Max Value", Float) = 10.0

_HdrMultiply ("HDR Multiplier", Float) = 2.0

[Toggle(_FADING_ON)] _UseSP ("Soft Particles", Float) = 0.0

_SoftParticlesFadeDistanceNear ("Near Fade", Float) = 0.0

_SoftParticlesFadeDistanceFar ("Far Fade", Float) = 1.0

[KeywordEnum(Off,On,CustomTexture)] _CFXR_DITHERED_SHADOWS ("Dithered Shadows", Float) = 0.0

_ShadowStrength ("Shadows Strength Max", Range(0, 1)) = 1.0

_DitherCustom ("Dithering 3D Texture", 3D) = "black" { }

}

SubShader{Tags{"IGNOREPROJECTOR"="true" "PreviewType"="Plane" "QUEUE"="Transparent" "RenderType"="Transparent"}
Blend [_SrcBlend] [_DstBlend], One One
ZWrite Off
Cull Off
ZTest LEqual
Pass{Name "BASE" Tags{"LightMode"="ForwardBase"}
CGPROGRAM
#pragma target 3.0
#pragma vertex vert
#pragma fragment frag
#pragma multi_compile_particles
#pragma shader_feature_local _ _CFXR_GLOW_POW_P4 _CFXR_GLOW_POW_P8
#pragma shader_feature_local _ _FADING_ON
#include "UnityCG.cginc"
#include "Lighting.cginc"
#define lessThan(a,b) ((a)<(b))
#define greaterThan(a,b) ((a)>(b))
#define lessThanEqual(a,b) ((a)<=(b))
#define greaterThanEqual(a,b) ((a)>=(b))
#define equal(a,b) ((a)==(b))
#define notEqual(a,b) ((a)!=(b))
#if defined(SOFTPARTICLES_ON) && defined(_CFXR_GLOW_POW_P4) && !defined(_CFXR_GLOW_POW_P8) && defined(_FADING_ON)
// Original GLES program 10; SOFTPARTICLES_ON,_CFXR_GLOW_POW_P4,_FADING_ON
float _GlowMin;
float _GlowMax;
float _MaxValue;
float _HdrMultiply;
float _SoftParticlesFadeDistanceNear;
float _SoftParticlesFadeDistanceFar;
sampler2D _CameraDepthTexture;
struct A{float4 in_POSITION0:POSITION0;float4 in_COLOR0:COLOR0;float4 in_TEXCOORD0:TEXCOORD0;float4 in_TEXCOORD1:TEXCOORD1;};
struct V{float4 vertex:SV_POSITION;float4 vs_COLOR0:TEXCOORD0;float4 vs_TEXCOORD0:TEXCOORD1;float4 vs_TEXCOORD2:TEXCOORD2;};
V vert(A i){V o=(V)0;
float4 vs_TEXCOORD1;
float4 u_xlat0;
float4 u_xlat1;
float u_xlat2;

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
    u_xlat2 = u_xlat0.y * transpose(unity_MatrixV)[1].z;
    u_xlat0.x = transpose(unity_MatrixV)[0].z * u_xlat0.x + u_xlat2;
    u_xlat0.x = transpose(unity_MatrixV)[2].z * u_xlat0.z + u_xlat0.x;
    u_xlat0.x = transpose(unity_MatrixV)[3].z * u_xlat0.w + u_xlat0.x;
    o.vs_TEXCOORD2.z = (-u_xlat0.x);
    u_xlat0.x = u_xlat1.y * _ProjectionParams.x;
    u_xlat0.w = u_xlat0.x * 0.5;
    u_xlat0.xz = u_xlat1.xw * float2(0.5, 0.5);
    o.vs_TEXCOORD2.w = u_xlat1.w;
    o.vs_TEXCOORD2.xy = u_xlat0.zz + u_xlat0.xw;
    return o;

}
float4 frag(V i):SV_Target{float4 result=0;
float2 u_xlat0;
float u_xlat16_1;
float u_xlat2;
bool u_xlatb2;
float u_xlat16_3;
bool u_xlatb4;

    u_xlat0.xy = i.vs_TEXCOORD0.xy + float2(-0.5, -0.5);
    u_xlat0.x = dot(u_xlat0.xy, u_xlat0.xy);
    u_xlat0.x = (-u_xlat0.x) * 4.0 + 1.0;
    u_xlat0.x = max(u_xlat0.x, 0.0);
    u_xlat16_1 = u_xlat0.x * u_xlat0.x;
    u_xlat16_1 = u_xlat16_1 * u_xlat16_1;
    u_xlat16_3 = (-_GlowMin) + _GlowMax;
    u_xlat16_3 = u_xlat16_1 * u_xlat16_3 + _GlowMin;
    u_xlat16_1 = u_xlat16_1 * 30.0;
    u_xlat16_1 = min(u_xlat16_1, 1.0);
    u_xlat16_3 = max(u_xlat16_3, 0.0);
    u_xlat16_3 = min(u_xlat16_3, _MaxValue);
    u_xlat16_1 = u_xlat16_1 * u_xlat16_3;
    u_xlat16_1 = u_xlat16_1 * i.vs_COLOR0.w;
    u_xlat0.xy = i.vs_TEXCOORD2.xy / i.vs_TEXCOORD2.ww;
    u_xlat0.x = tex2D(_CameraDepthTexture, u_xlat0.xy).x;
    u_xlat2 = _ZBufferParams.z * u_xlat0.x + _ZBufferParams.w;
    u_xlat0.x = u_xlat0.x * _ProjectionParams.z + _ProjectionParams.y;
    u_xlat2 = float(1.0) / u_xlat2;
    u_xlatb4 = unity_OrthoParams.w==1.0;
    u_xlat0.x = (u_xlatb4) ? u_xlat0.x : u_xlat2;
    u_xlat0.x = u_xlat0.x + (-_SoftParticlesFadeDistanceNear);
    u_xlat0.x = u_xlat0.x + (-i.vs_TEXCOORD2.z);
    u_xlat0.x = u_xlat0.x * _SoftParticlesFadeDistanceFar;
    u_xlat0.x = clamp(u_xlat0.x, 0.0, 1.0);
    u_xlat0.x = u_xlat0.x * u_xlat16_1;
    result.w = min(u_xlat0.x, 1.0);
    u_xlat0.x = log2(_HdrMultiply);
    u_xlat0.x = u_xlat0.x * 0.416666657;
    u_xlat0.x = exp2(u_xlat0.x);
    u_xlat0.x = u_xlat0.x * 1.05499995 + -0.0549999997;
    u_xlat0.x = max(u_xlat0.x, 0.0);
    u_xlatb2 = 0.0<_HdrMultiply;
    u_xlat16_1 = (u_xlatb2) ? u_xlat0.x : 1.0;
    result.xyz = ((float3)(u_xlat16_1)) * i.vs_COLOR0.xyz;
    return result;

}

#elif defined(SOFTPARTICLES_ON) && !defined(_CFXR_GLOW_POW_P4) && defined(_CFXR_GLOW_POW_P8) && defined(_FADING_ON)
// Original GLES program 11; SOFTPARTICLES_ON,_CFXR_GLOW_POW_P8,_FADING_ON
float _GlowMin;
float _GlowMax;
float _MaxValue;
float _HdrMultiply;
float _SoftParticlesFadeDistanceNear;
float _SoftParticlesFadeDistanceFar;
sampler2D _CameraDepthTexture;
struct A{float4 in_POSITION0:POSITION0;float4 in_COLOR0:COLOR0;float4 in_TEXCOORD0:TEXCOORD0;float4 in_TEXCOORD1:TEXCOORD1;};
struct V{float4 vertex:SV_POSITION;float4 vs_COLOR0:TEXCOORD0;float4 vs_TEXCOORD0:TEXCOORD1;float4 vs_TEXCOORD2:TEXCOORD2;};
V vert(A i){V o=(V)0;
float4 vs_TEXCOORD1;
float4 u_xlat0;
float4 u_xlat1;
float u_xlat2;

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
    u_xlat2 = u_xlat0.y * transpose(unity_MatrixV)[1].z;
    u_xlat0.x = transpose(unity_MatrixV)[0].z * u_xlat0.x + u_xlat2;
    u_xlat0.x = transpose(unity_MatrixV)[2].z * u_xlat0.z + u_xlat0.x;
    u_xlat0.x = transpose(unity_MatrixV)[3].z * u_xlat0.w + u_xlat0.x;
    o.vs_TEXCOORD2.z = (-u_xlat0.x);
    u_xlat0.x = u_xlat1.y * _ProjectionParams.x;
    u_xlat0.w = u_xlat0.x * 0.5;
    u_xlat0.xz = u_xlat1.xw * float2(0.5, 0.5);
    o.vs_TEXCOORD2.w = u_xlat1.w;
    o.vs_TEXCOORD2.xy = u_xlat0.zz + u_xlat0.xw;
    return o;

}
float4 frag(V i):SV_Target{float4 result=0;
float2 u_xlat0;
float u_xlat16_1;
float u_xlat2;
bool u_xlatb2;
float u_xlat16_3;
bool u_xlatb4;

    u_xlat0.xy = i.vs_TEXCOORD0.xy + float2(-0.5, -0.5);
    u_xlat0.x = dot(u_xlat0.xy, u_xlat0.xy);
    u_xlat0.x = (-u_xlat0.x) * 4.0 + 1.0;
    u_xlat0.x = max(u_xlat0.x, 0.0);
    u_xlat16_1 = u_xlat0.x * u_xlat0.x;
    u_xlat16_1 = u_xlat16_1 * u_xlat16_1;
    u_xlat16_1 = u_xlat16_1 * u_xlat16_1;
    u_xlat16_3 = (-_GlowMin) + _GlowMax;
    u_xlat16_3 = u_xlat16_1 * u_xlat16_3 + _GlowMin;
    u_xlat16_1 = u_xlat16_1 * 30.0;
    u_xlat16_1 = min(u_xlat16_1, 1.0);
    u_xlat16_3 = max(u_xlat16_3, 0.0);
    u_xlat16_3 = min(u_xlat16_3, _MaxValue);
    u_xlat16_1 = u_xlat16_1 * u_xlat16_3;
    u_xlat16_1 = u_xlat16_1 * i.vs_COLOR0.w;
    u_xlat0.xy = i.vs_TEXCOORD2.xy / i.vs_TEXCOORD2.ww;
    u_xlat0.x = tex2D(_CameraDepthTexture, u_xlat0.xy).x;
    u_xlat2 = _ZBufferParams.z * u_xlat0.x + _ZBufferParams.w;
    u_xlat0.x = u_xlat0.x * _ProjectionParams.z + _ProjectionParams.y;
    u_xlat2 = float(1.0) / u_xlat2;
    u_xlatb4 = unity_OrthoParams.w==1.0;
    u_xlat0.x = (u_xlatb4) ? u_xlat0.x : u_xlat2;
    u_xlat0.x = u_xlat0.x + (-_SoftParticlesFadeDistanceNear);
    u_xlat0.x = u_xlat0.x + (-i.vs_TEXCOORD2.z);
    u_xlat0.x = u_xlat0.x * _SoftParticlesFadeDistanceFar;
    u_xlat0.x = clamp(u_xlat0.x, 0.0, 1.0);
    u_xlat0.x = u_xlat0.x * u_xlat16_1;
    result.w = min(u_xlat0.x, 1.0);
    u_xlat0.x = log2(_HdrMultiply);
    u_xlat0.x = u_xlat0.x * 0.416666657;
    u_xlat0.x = exp2(u_xlat0.x);
    u_xlat0.x = u_xlat0.x * 1.05499995 + -0.0549999997;
    u_xlat0.x = max(u_xlat0.x, 0.0);
    u_xlatb2 = 0.0<_HdrMultiply;
    u_xlat16_1 = (u_xlatb2) ? u_xlat0.x : 1.0;
    result.xyz = ((float3)(u_xlat16_1)) * i.vs_COLOR0.xyz;
    return result;

}

#elif !defined(SOFTPARTICLES_ON) && defined(_CFXR_GLOW_POW_P4) && !defined(_CFXR_GLOW_POW_P8) && defined(_FADING_ON)
// Original GLES program 5; _CFXR_GLOW_POW_P4,_FADING_ON
float _GlowMin;
float _GlowMax;
float _MaxValue;
float _HdrMultiply;
struct A{float4 in_POSITION0:POSITION0;float4 in_COLOR0:COLOR0;float4 in_TEXCOORD0:TEXCOORD0;float4 in_TEXCOORD1:TEXCOORD1;};
struct V{float4 vertex:SV_POSITION;float4 vs_COLOR0:TEXCOORD0;float4 vs_TEXCOORD0:TEXCOORD1;};
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
    o.vertex = transpose(unity_MatrixVP)[3] * u_xlat0.wwww + u_xlat1;
    o.vs_COLOR0 = i.in_COLOR0;
    o.vs_TEXCOORD0 = i.in_TEXCOORD0.xyxy;
    vs_TEXCOORD1 = i.in_TEXCOORD1;
    return o;

}
float4 frag(V i):SV_Target{float4 result=0;
float2 u_xlat0;
float u_xlat16_1;
bool u_xlatb2;
float u_xlat16_3;

    u_xlat0.xy = i.vs_TEXCOORD0.xy + float2(-0.5, -0.5);
    u_xlat0.x = dot(u_xlat0.xy, u_xlat0.xy);
    u_xlat0.x = (-u_xlat0.x) * 4.0 + 1.0;
    u_xlat0.x = max(u_xlat0.x, 0.0);
    u_xlat16_1 = u_xlat0.x * u_xlat0.x;
    u_xlat16_1 = u_xlat16_1 * u_xlat16_1;
    u_xlat16_3 = (-_GlowMin) + _GlowMax;
    u_xlat16_3 = u_xlat16_1 * u_xlat16_3 + _GlowMin;
    u_xlat16_1 = u_xlat16_1 * 30.0;
    u_xlat16_1 = min(u_xlat16_1, 1.0);
    u_xlat16_3 = max(u_xlat16_3, 0.0);
    u_xlat16_3 = min(u_xlat16_3, _MaxValue);
    u_xlat16_1 = u_xlat16_1 * u_xlat16_3;
    u_xlat16_1 = u_xlat16_1 * i.vs_COLOR0.w;
    result.w = min(u_xlat16_1, 1.0);
    u_xlat0.x = log2(_HdrMultiply);
    u_xlat0.x = u_xlat0.x * 0.416666657;
    u_xlat0.x = exp2(u_xlat0.x);
    u_xlat0.x = u_xlat0.x * 1.05499995 + -0.0549999997;
    u_xlat0.x = max(u_xlat0.x, 0.0);
    u_xlatb2 = 0.0<_HdrMultiply;
    u_xlat16_1 = (u_xlatb2) ? u_xlat0.x : 1.0;
    result.xyz = ((float3)(u_xlat16_1)) * i.vs_COLOR0.xyz;
    return result;

}

#elif !defined(SOFTPARTICLES_ON) && !defined(_CFXR_GLOW_POW_P4) && defined(_CFXR_GLOW_POW_P8) && defined(_FADING_ON)
// Original GLES program 6; _CFXR_GLOW_POW_P8,_FADING_ON
float _GlowMin;
float _GlowMax;
float _MaxValue;
float _HdrMultiply;
struct A{float4 in_POSITION0:POSITION0;float4 in_COLOR0:COLOR0;float4 in_TEXCOORD0:TEXCOORD0;float4 in_TEXCOORD1:TEXCOORD1;};
struct V{float4 vertex:SV_POSITION;float4 vs_COLOR0:TEXCOORD0;float4 vs_TEXCOORD0:TEXCOORD1;};
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
    o.vertex = transpose(unity_MatrixVP)[3] * u_xlat0.wwww + u_xlat1;
    o.vs_COLOR0 = i.in_COLOR0;
    o.vs_TEXCOORD0 = i.in_TEXCOORD0.xyxy;
    vs_TEXCOORD1 = i.in_TEXCOORD1;
    return o;

}
float4 frag(V i):SV_Target{float4 result=0;
float2 u_xlat0;
float u_xlat16_1;
bool u_xlatb2;
float u_xlat16_3;

    u_xlat0.xy = i.vs_TEXCOORD0.xy + float2(-0.5, -0.5);
    u_xlat0.x = dot(u_xlat0.xy, u_xlat0.xy);
    u_xlat0.x = (-u_xlat0.x) * 4.0 + 1.0;
    u_xlat0.x = max(u_xlat0.x, 0.0);
    u_xlat16_1 = u_xlat0.x * u_xlat0.x;
    u_xlat16_1 = u_xlat16_1 * u_xlat16_1;
    u_xlat16_1 = u_xlat16_1 * u_xlat16_1;
    u_xlat16_3 = (-_GlowMin) + _GlowMax;
    u_xlat16_3 = u_xlat16_1 * u_xlat16_3 + _GlowMin;
    u_xlat16_1 = u_xlat16_1 * 30.0;
    u_xlat16_1 = min(u_xlat16_1, 1.0);
    u_xlat16_3 = max(u_xlat16_3, 0.0);
    u_xlat16_3 = min(u_xlat16_3, _MaxValue);
    u_xlat16_1 = u_xlat16_1 * u_xlat16_3;
    u_xlat16_1 = u_xlat16_1 * i.vs_COLOR0.w;
    result.w = min(u_xlat16_1, 1.0);
    u_xlat0.x = log2(_HdrMultiply);
    u_xlat0.x = u_xlat0.x * 0.416666657;
    u_xlat0.x = exp2(u_xlat0.x);
    u_xlat0.x = u_xlat0.x * 1.05499995 + -0.0549999997;
    u_xlat0.x = max(u_xlat0.x, 0.0);
    u_xlatb2 = 0.0<_HdrMultiply;
    u_xlat16_1 = (u_xlatb2) ? u_xlat0.x : 1.0;
    result.xyz = ((float3)(u_xlat16_1)) * i.vs_COLOR0.xyz;
    return result;

}

#elif defined(SOFTPARTICLES_ON) && defined(_CFXR_GLOW_POW_P4) && !defined(_CFXR_GLOW_POW_P8) && !defined(_FADING_ON)
// Original GLES program 8; SOFTPARTICLES_ON,_CFXR_GLOW_POW_P4
float _GlowMin;
float _GlowMax;
float _MaxValue;
float _HdrMultiply;
struct A{float4 in_POSITION0:POSITION0;float4 in_COLOR0:COLOR0;float4 in_TEXCOORD0:TEXCOORD0;float4 in_TEXCOORD1:TEXCOORD1;};
struct V{float4 vertex:SV_POSITION;float4 vs_COLOR0:TEXCOORD0;float4 vs_TEXCOORD0:TEXCOORD1;};
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
    o.vertex = transpose(unity_MatrixVP)[3] * u_xlat0.wwww + u_xlat1;
    o.vs_COLOR0 = i.in_COLOR0;
    o.vs_TEXCOORD0 = i.in_TEXCOORD0.xyxy;
    vs_TEXCOORD1 = i.in_TEXCOORD1;
    return o;

}
float4 frag(V i):SV_Target{float4 result=0;
float2 u_xlat0;
float u_xlat16_1;
bool u_xlatb2;
float u_xlat16_3;

    u_xlat0.xy = i.vs_TEXCOORD0.xy + float2(-0.5, -0.5);
    u_xlat0.x = dot(u_xlat0.xy, u_xlat0.xy);
    u_xlat0.x = (-u_xlat0.x) * 4.0 + 1.0;
    u_xlat0.x = max(u_xlat0.x, 0.0);
    u_xlat16_1 = u_xlat0.x * u_xlat0.x;
    u_xlat16_1 = u_xlat16_1 * u_xlat16_1;
    u_xlat16_3 = (-_GlowMin) + _GlowMax;
    u_xlat16_3 = u_xlat16_1 * u_xlat16_3 + _GlowMin;
    u_xlat16_1 = u_xlat16_1 * 30.0;
    u_xlat16_1 = min(u_xlat16_1, 1.0);
    u_xlat16_3 = max(u_xlat16_3, 0.0);
    u_xlat16_3 = min(u_xlat16_3, _MaxValue);
    u_xlat16_1 = u_xlat16_1 * u_xlat16_3;
    u_xlat16_1 = u_xlat16_1 * i.vs_COLOR0.w;
    result.w = min(u_xlat16_1, 1.0);
    u_xlat0.x = log2(_HdrMultiply);
    u_xlat0.x = u_xlat0.x * 0.416666657;
    u_xlat0.x = exp2(u_xlat0.x);
    u_xlat0.x = u_xlat0.x * 1.05499995 + -0.0549999997;
    u_xlat0.x = max(u_xlat0.x, 0.0);
    u_xlatb2 = 0.0<_HdrMultiply;
    u_xlat16_1 = (u_xlatb2) ? u_xlat0.x : 1.0;
    result.xyz = ((float3)(u_xlat16_1)) * i.vs_COLOR0.xyz;
    return result;

}

#elif defined(SOFTPARTICLES_ON) && !defined(_CFXR_GLOW_POW_P4) && !defined(_CFXR_GLOW_POW_P8) && defined(_FADING_ON)
// Original GLES program 9; SOFTPARTICLES_ON,_FADING_ON
float _GlowMin;
float _GlowMax;
float _MaxValue;
float _HdrMultiply;
float _SoftParticlesFadeDistanceNear;
float _SoftParticlesFadeDistanceFar;
sampler2D _CameraDepthTexture;
struct A{float4 in_POSITION0:POSITION0;float4 in_COLOR0:COLOR0;float4 in_TEXCOORD0:TEXCOORD0;float4 in_TEXCOORD1:TEXCOORD1;};
struct V{float4 vertex:SV_POSITION;float4 vs_COLOR0:TEXCOORD0;float4 vs_TEXCOORD0:TEXCOORD1;float4 vs_TEXCOORD2:TEXCOORD2;};
V vert(A i){V o=(V)0;
float4 vs_TEXCOORD1;
float4 u_xlat0;
float4 u_xlat1;
float u_xlat2;

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
    u_xlat2 = u_xlat0.y * transpose(unity_MatrixV)[1].z;
    u_xlat0.x = transpose(unity_MatrixV)[0].z * u_xlat0.x + u_xlat2;
    u_xlat0.x = transpose(unity_MatrixV)[2].z * u_xlat0.z + u_xlat0.x;
    u_xlat0.x = transpose(unity_MatrixV)[3].z * u_xlat0.w + u_xlat0.x;
    o.vs_TEXCOORD2.z = (-u_xlat0.x);
    u_xlat0.x = u_xlat1.y * _ProjectionParams.x;
    u_xlat0.w = u_xlat0.x * 0.5;
    u_xlat0.xz = u_xlat1.xw * float2(0.5, 0.5);
    o.vs_TEXCOORD2.w = u_xlat1.w;
    o.vs_TEXCOORD2.xy = u_xlat0.zz + u_xlat0.xw;
    return o;

}
float4 frag(V i):SV_Target{float4 result=0;
float2 u_xlat0;
float u_xlat16_1;
float u_xlat2;
bool u_xlatb2;
float u_xlat16_3;
bool u_xlatb4;

    u_xlat0.xy = i.vs_TEXCOORD0.xy + float2(-0.5, -0.5);
    u_xlat0.x = dot(u_xlat0.xy, u_xlat0.xy);
    u_xlat0.x = (-u_xlat0.x) * 4.0 + 1.0;
    u_xlat0.x = max(u_xlat0.x, 0.0);
    u_xlat16_1 = (-_GlowMin) + _GlowMax;
    u_xlat16_1 = u_xlat0.x * u_xlat16_1 + _GlowMin;
    u_xlat16_3 = u_xlat0.x * 30.0;
    u_xlat16_3 = min(u_xlat16_3, 1.0);
    u_xlat16_1 = max(u_xlat16_1, 0.0);
    u_xlat16_1 = min(u_xlat16_1, _MaxValue);
    u_xlat16_1 = u_xlat16_3 * u_xlat16_1;
    u_xlat16_1 = u_xlat16_1 * i.vs_COLOR0.w;
    u_xlat0.xy = i.vs_TEXCOORD2.xy / i.vs_TEXCOORD2.ww;
    u_xlat0.x = tex2D(_CameraDepthTexture, u_xlat0.xy).x;
    u_xlat2 = _ZBufferParams.z * u_xlat0.x + _ZBufferParams.w;
    u_xlat0.x = u_xlat0.x * _ProjectionParams.z + _ProjectionParams.y;
    u_xlat2 = float(1.0) / u_xlat2;
    u_xlatb4 = unity_OrthoParams.w==1.0;
    u_xlat0.x = (u_xlatb4) ? u_xlat0.x : u_xlat2;
    u_xlat0.x = u_xlat0.x + (-_SoftParticlesFadeDistanceNear);
    u_xlat0.x = u_xlat0.x + (-i.vs_TEXCOORD2.z);
    u_xlat0.x = u_xlat0.x * _SoftParticlesFadeDistanceFar;
    u_xlat0.x = clamp(u_xlat0.x, 0.0, 1.0);
    u_xlat0.x = u_xlat0.x * u_xlat16_1;
    result.w = min(u_xlat0.x, 1.0);
    u_xlat0.x = log2(_HdrMultiply);
    u_xlat0.x = u_xlat0.x * 0.416666657;
    u_xlat0.x = exp2(u_xlat0.x);
    u_xlat0.x = u_xlat0.x * 1.05499995 + -0.0549999997;
    u_xlat0.x = max(u_xlat0.x, 0.0);
    u_xlatb2 = 0.0<_HdrMultiply;
    u_xlat16_1 = (u_xlatb2) ? u_xlat0.x : 1.0;
    result.xyz = ((float3)(u_xlat16_1)) * i.vs_COLOR0.xyz;
    return result;

}

#elif !defined(SOFTPARTICLES_ON) && defined(_CFXR_GLOW_POW_P4) && !defined(_CFXR_GLOW_POW_P8) && !defined(_FADING_ON)
// Original GLES program 3; _CFXR_GLOW_POW_P4
float _GlowMin;
float _GlowMax;
float _MaxValue;
float _HdrMultiply;
struct A{float4 in_POSITION0:POSITION0;float4 in_COLOR0:COLOR0;float4 in_TEXCOORD0:TEXCOORD0;float4 in_TEXCOORD1:TEXCOORD1;};
struct V{float4 vertex:SV_POSITION;float4 vs_COLOR0:TEXCOORD0;float4 vs_TEXCOORD0:TEXCOORD1;};
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
    o.vertex = transpose(unity_MatrixVP)[3] * u_xlat0.wwww + u_xlat1;
    o.vs_COLOR0 = i.in_COLOR0;
    o.vs_TEXCOORD0 = i.in_TEXCOORD0.xyxy;
    vs_TEXCOORD1 = i.in_TEXCOORD1;
    return o;

}
float4 frag(V i):SV_Target{float4 result=0;
float2 u_xlat0;
float u_xlat16_1;
bool u_xlatb2;
float u_xlat16_3;

    u_xlat0.xy = i.vs_TEXCOORD0.xy + float2(-0.5, -0.5);
    u_xlat0.x = dot(u_xlat0.xy, u_xlat0.xy);
    u_xlat0.x = (-u_xlat0.x) * 4.0 + 1.0;
    u_xlat0.x = max(u_xlat0.x, 0.0);
    u_xlat16_1 = u_xlat0.x * u_xlat0.x;
    u_xlat16_1 = u_xlat16_1 * u_xlat16_1;
    u_xlat16_3 = (-_GlowMin) + _GlowMax;
    u_xlat16_3 = u_xlat16_1 * u_xlat16_3 + _GlowMin;
    u_xlat16_1 = u_xlat16_1 * 30.0;
    u_xlat16_1 = min(u_xlat16_1, 1.0);
    u_xlat16_3 = max(u_xlat16_3, 0.0);
    u_xlat16_3 = min(u_xlat16_3, _MaxValue);
    u_xlat16_1 = u_xlat16_1 * u_xlat16_3;
    u_xlat16_1 = u_xlat16_1 * i.vs_COLOR0.w;
    result.w = min(u_xlat16_1, 1.0);
    u_xlat0.x = log2(_HdrMultiply);
    u_xlat0.x = u_xlat0.x * 0.416666657;
    u_xlat0.x = exp2(u_xlat0.x);
    u_xlat0.x = u_xlat0.x * 1.05499995 + -0.0549999997;
    u_xlat0.x = max(u_xlat0.x, 0.0);
    u_xlatb2 = 0.0<_HdrMultiply;
    u_xlat16_1 = (u_xlatb2) ? u_xlat0.x : 1.0;
    result.xyz = ((float3)(u_xlat16_1)) * i.vs_COLOR0.xyz;
    return result;

}

#elif !defined(SOFTPARTICLES_ON) && !defined(_CFXR_GLOW_POW_P4) && !defined(_CFXR_GLOW_POW_P8) && defined(_FADING_ON)
// Original GLES program 4; _FADING_ON
float _GlowMin;
float _GlowMax;
float _MaxValue;
float _HdrMultiply;
struct A{float4 in_POSITION0:POSITION0;float4 in_COLOR0:COLOR0;float4 in_TEXCOORD0:TEXCOORD0;float4 in_TEXCOORD1:TEXCOORD1;};
struct V{float4 vertex:SV_POSITION;float4 vs_COLOR0:TEXCOORD0;float4 vs_TEXCOORD0:TEXCOORD1;};
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
    o.vertex = transpose(unity_MatrixVP)[3] * u_xlat0.wwww + u_xlat1;
    o.vs_COLOR0 = i.in_COLOR0;
    o.vs_TEXCOORD0 = i.in_TEXCOORD0.xyxy;
    vs_TEXCOORD1 = i.in_TEXCOORD1;
    return o;

}
float4 frag(V i):SV_Target{float4 result=0;
float2 u_xlat0;
float u_xlat16_1;
bool u_xlatb2;
float u_xlat16_3;

    u_xlat0.xy = i.vs_TEXCOORD0.xy + float2(-0.5, -0.5);
    u_xlat0.x = dot(u_xlat0.xy, u_xlat0.xy);
    u_xlat0.x = (-u_xlat0.x) * 4.0 + 1.0;
    u_xlat0.x = max(u_xlat0.x, 0.0);
    u_xlat16_1 = (-_GlowMin) + _GlowMax;
    u_xlat16_1 = u_xlat0.x * u_xlat16_1 + _GlowMin;
    u_xlat16_3 = u_xlat0.x * 30.0;
    u_xlat16_3 = min(u_xlat16_3, 1.0);
    u_xlat16_1 = max(u_xlat16_1, 0.0);
    u_xlat16_1 = min(u_xlat16_1, _MaxValue);
    u_xlat16_1 = u_xlat16_3 * u_xlat16_1;
    u_xlat16_1 = u_xlat16_1 * i.vs_COLOR0.w;
    result.w = min(u_xlat16_1, 1.0);
    u_xlat0.x = log2(_HdrMultiply);
    u_xlat0.x = u_xlat0.x * 0.416666657;
    u_xlat0.x = exp2(u_xlat0.x);
    u_xlat0.x = u_xlat0.x * 1.05499995 + -0.0549999997;
    u_xlat0.x = max(u_xlat0.x, 0.0);
    u_xlatb2 = 0.0<_HdrMultiply;
    u_xlat16_1 = (u_xlatb2) ? u_xlat0.x : 1.0;
    result.xyz = ((float3)(u_xlat16_1)) * i.vs_COLOR0.xyz;
    return result;

}

#elif defined(SOFTPARTICLES_ON) && !defined(_CFXR_GLOW_POW_P4) && !defined(_CFXR_GLOW_POW_P8) && !defined(_FADING_ON)
// Original GLES program 7; SOFTPARTICLES_ON
float _GlowMin;
float _GlowMax;
float _MaxValue;
float _HdrMultiply;
struct A{float4 in_POSITION0:POSITION0;float4 in_COLOR0:COLOR0;float4 in_TEXCOORD0:TEXCOORD0;float4 in_TEXCOORD1:TEXCOORD1;};
struct V{float4 vertex:SV_POSITION;float4 vs_COLOR0:TEXCOORD0;float4 vs_TEXCOORD0:TEXCOORD1;};
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
    o.vertex = transpose(unity_MatrixVP)[3] * u_xlat0.wwww + u_xlat1;
    o.vs_COLOR0 = i.in_COLOR0;
    o.vs_TEXCOORD0 = i.in_TEXCOORD0.xyxy;
    vs_TEXCOORD1 = i.in_TEXCOORD1;
    return o;

}
float4 frag(V i):SV_Target{float4 result=0;
float2 u_xlat0;
float u_xlat16_1;
bool u_xlatb2;
float u_xlat16_3;

    u_xlat0.xy = i.vs_TEXCOORD0.xy + float2(-0.5, -0.5);
    u_xlat0.x = dot(u_xlat0.xy, u_xlat0.xy);
    u_xlat0.x = (-u_xlat0.x) * 4.0 + 1.0;
    u_xlat0.x = max(u_xlat0.x, 0.0);
    u_xlat16_1 = (-_GlowMin) + _GlowMax;
    u_xlat16_1 = u_xlat0.x * u_xlat16_1 + _GlowMin;
    u_xlat16_3 = u_xlat0.x * 30.0;
    u_xlat16_3 = min(u_xlat16_3, 1.0);
    u_xlat16_1 = max(u_xlat16_1, 0.0);
    u_xlat16_1 = min(u_xlat16_1, _MaxValue);
    u_xlat16_1 = u_xlat16_3 * u_xlat16_1;
    u_xlat16_1 = u_xlat16_1 * i.vs_COLOR0.w;
    result.w = min(u_xlat16_1, 1.0);
    u_xlat0.x = log2(_HdrMultiply);
    u_xlat0.x = u_xlat0.x * 0.416666657;
    u_xlat0.x = exp2(u_xlat0.x);
    u_xlat0.x = u_xlat0.x * 1.05499995 + -0.0549999997;
    u_xlat0.x = max(u_xlat0.x, 0.0);
    u_xlatb2 = 0.0<_HdrMultiply;
    u_xlat16_1 = (u_xlatb2) ? u_xlat0.x : 1.0;
    result.xyz = ((float3)(u_xlat16_1)) * i.vs_COLOR0.xyz;
    return result;

}

#elif !defined(SOFTPARTICLES_ON) && !defined(_CFXR_GLOW_POW_P4) && !defined(_CFXR_GLOW_POW_P8) && !defined(_FADING_ON)
// Original GLES program 2; 
float _GlowMin;
float _GlowMax;
float _MaxValue;
float _HdrMultiply;
struct A{float4 in_POSITION0:POSITION0;float4 in_COLOR0:COLOR0;float4 in_TEXCOORD0:TEXCOORD0;float4 in_TEXCOORD1:TEXCOORD1;};
struct V{float4 vertex:SV_POSITION;float4 vs_COLOR0:TEXCOORD0;float4 vs_TEXCOORD0:TEXCOORD1;};
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
    o.vertex = transpose(unity_MatrixVP)[3] * u_xlat0.wwww + u_xlat1;
    o.vs_COLOR0 = i.in_COLOR0;
    o.vs_TEXCOORD0 = i.in_TEXCOORD0.xyxy;
    vs_TEXCOORD1 = i.in_TEXCOORD1;
    return o;

}
float4 frag(V i):SV_Target{float4 result=0;
float2 u_xlat0;
float u_xlat16_1;
bool u_xlatb2;
float u_xlat16_3;

    u_xlat0.xy = i.vs_TEXCOORD0.xy + float2(-0.5, -0.5);
    u_xlat0.x = dot(u_xlat0.xy, u_xlat0.xy);
    u_xlat0.x = (-u_xlat0.x) * 4.0 + 1.0;
    u_xlat0.x = max(u_xlat0.x, 0.0);
    u_xlat16_1 = (-_GlowMin) + _GlowMax;
    u_xlat16_1 = u_xlat0.x * u_xlat16_1 + _GlowMin;
    u_xlat16_3 = u_xlat0.x * 30.0;
    u_xlat16_3 = min(u_xlat16_3, 1.0);
    u_xlat16_1 = max(u_xlat16_1, 0.0);
    u_xlat16_1 = min(u_xlat16_1, _MaxValue);
    u_xlat16_1 = u_xlat16_3 * u_xlat16_1;
    u_xlat16_1 = u_xlat16_1 * i.vs_COLOR0.w;
    result.w = min(u_xlat16_1, 1.0);
    u_xlat0.x = log2(_HdrMultiply);
    u_xlat0.x = u_xlat0.x * 0.416666657;
    u_xlat0.x = exp2(u_xlat0.x);
    u_xlat0.x = u_xlat0.x * 1.05499995 + -0.0549999997;
    u_xlat0.x = max(u_xlat0.x, 0.0);
    u_xlatb2 = 0.0<_HdrMultiply;
    u_xlat16_1 = (u_xlatb2) ? u_xlat0.x : 1.0;
    result.xyz = ((float3)(u_xlat16_1)) * i.vs_COLOR0.xyz;
    return result;

}

#else
// Combination absent from original shipped forward variants.
float _GlowMin;
float _GlowMax;
float _MaxValue;
float _HdrMultiply;
struct A{float4 in_POSITION0:POSITION0;float4 in_COLOR0:COLOR0;float4 in_TEXCOORD0:TEXCOORD0;float4 in_TEXCOORD1:TEXCOORD1;};
struct V{float4 vertex:SV_POSITION;float4 vs_COLOR0:TEXCOORD0;float4 vs_TEXCOORD0:TEXCOORD1;};
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
    o.vertex = transpose(unity_MatrixVP)[3] * u_xlat0.wwww + u_xlat1;
    o.vs_COLOR0 = i.in_COLOR0;
    o.vs_TEXCOORD0 = i.in_TEXCOORD0.xyxy;
    vs_TEXCOORD1 = i.in_TEXCOORD1;
    return o;

}
float4 frag(V i):SV_Target{float4 result=0;
float2 u_xlat0;
float u_xlat16_1;
bool u_xlatb2;
float u_xlat16_3;

    u_xlat0.xy = i.vs_TEXCOORD0.xy + float2(-0.5, -0.5);
    u_xlat0.x = dot(u_xlat0.xy, u_xlat0.xy);
    u_xlat0.x = (-u_xlat0.x) * 4.0 + 1.0;
    u_xlat0.x = max(u_xlat0.x, 0.0);
    u_xlat16_1 = (-_GlowMin) + _GlowMax;
    u_xlat16_1 = u_xlat0.x * u_xlat16_1 + _GlowMin;
    u_xlat16_3 = u_xlat0.x * 30.0;
    u_xlat16_3 = min(u_xlat16_3, 1.0);
    u_xlat16_1 = max(u_xlat16_1, 0.0);
    u_xlat16_1 = min(u_xlat16_1, _MaxValue);
    u_xlat16_1 = u_xlat16_3 * u_xlat16_1;
    u_xlat16_1 = u_xlat16_1 * i.vs_COLOR0.w;
    result.w = min(u_xlat16_1, 1.0);
    u_xlat0.x = log2(_HdrMultiply);
    u_xlat0.x = u_xlat0.x * 0.416666657;
    u_xlat0.x = exp2(u_xlat0.x);
    u_xlat0.x = u_xlat0.x * 1.05499995 + -0.0549999997;
    u_xlat0.x = max(u_xlat0.x, 0.0);
    u_xlatb2 = 0.0<_HdrMultiply;
    u_xlat16_1 = (u_xlatb2) ? u_xlat0.x : 1.0;
    result.xyz = ((float3)(u_xlat16_1)) * i.vs_COLOR0.xyz;
    return result;

}

#endif
ENDCG
}
Pass{Name "ShadowCaster" Tags{"LightMode"="ShadowCaster" "ShadowSupport"="true"}
Blend One Zero, One Zero
ZWrite On
ZTest LEqual
Cull Off
CGPROGRAM
#pragma target 3.0
#pragma vertex vert
#pragma fragment frag
#pragma multi_compile_shadowcaster
#pragma shader_feature_local _ _CFXR_GLOW_POW_P4 _CFXR_GLOW_POW_P8
#pragma shader_feature_local _ _CFXR_DITHERED_SHADOWS_ON
#pragma shader_feature_local _ _FADING_ON
#include "UnityCG.cginc"
// Platform adapters equivalent to local UnityCG.UnityApplyLinearShadowBias.
float LF_ShadowBiasDelta(float ratio){
#if defined(UNITY_REVERSED_Z)
return max(-1,min(ratio,0));
#else
return saturate(ratio);
#endif
}
float LF_ShadowNearClamp(float z,float w){
#if defined(UNITY_REVERSED_Z)
return min(z,w*UNITY_NEAR_CLIP_VALUE);
#else
return max(z,w*UNITY_NEAR_CLIP_VALUE);
#endif
}
#define lessThan(a,b) ((a)<(b))
#define greaterThan(a,b) ((a)>(b))
#define lessThanEqual(a,b) ((a)<=(b))
#define greaterThanEqual(a,b) ((a)>=(b))
#define equal(a,b) ((a)==(b))
#define notEqual(a,b) ((a)!=(b))
#if defined(SHADOWS_CUBE) && !defined(SHADOWS_DEPTH) && !defined(_CFXR_DITHERED_SHADOWS_ON) && defined(_CFXR_GLOW_POW_P4) && !defined(_CFXR_GLOW_POW_P8) && defined(_FADING_ON)
// Original shadow GLES program 17
float _GlowMin;
float _GlowMax;
float _MaxValue;
struct A{float4 in_POSITION0:POSITION0;float4 in_COLOR0:COLOR0;float4 in_TEXCOORD0:TEXCOORD0;float4 in_TEXCOORD1:TEXCOORD1;float3 in_NORMAL0:NORMAL0;};
struct V{float4 vertex:SV_POSITION;float4 vs_COLOR0:TEXCOORD0;float4 vs_TEXCOORD1:TEXCOORD1;};
V vert(A i){V o=(V)0;
float4 vs_TEXCOORD2;
float4 u_xlat0;
float4 u_xlat1;
float4 u_xlat2;
float u_xlat9;
bool u_xlatb9;

    o.vs_COLOR0 = i.in_COLOR0;
    o.vs_TEXCOORD1 = i.in_TEXCOORD0.xyxy;
    vs_TEXCOORD2 = i.in_TEXCOORD1;
    u_xlat0.x = dot(i.in_NORMAL0.xyz, transpose(unity_WorldToObject)[0].xyz);
    u_xlat0.y = dot(i.in_NORMAL0.xyz, transpose(unity_WorldToObject)[1].xyz);
    u_xlat0.z = dot(i.in_NORMAL0.xyz, transpose(unity_WorldToObject)[2].xyz);
    u_xlat9 = dot(u_xlat0.xyz, u_xlat0.xyz);
    u_xlat9 = rsqrt(u_xlat9);
    u_xlat0.xyz = ((float3)(u_xlat9)) * u_xlat0.xyz;
    u_xlat1 = i.in_POSITION0.yyyy * transpose(unity_ObjectToWorld)[1];
    u_xlat1 = transpose(unity_ObjectToWorld)[0] * i.in_POSITION0.xxxx + u_xlat1;
    u_xlat1 = transpose(unity_ObjectToWorld)[2] * i.in_POSITION0.zzzz + u_xlat1;
    u_xlat1 = transpose(unity_ObjectToWorld)[3] * i.in_POSITION0.wwww + u_xlat1;
    u_xlat2.xyz = (-u_xlat1.xyz) * _WorldSpaceLightPos0.www + _WorldSpaceLightPos0.xyz;
    u_xlat9 = dot(u_xlat2.xyz, u_xlat2.xyz);
    u_xlat9 = rsqrt(u_xlat9);
    u_xlat2.xyz = ((float3)(u_xlat9)) * u_xlat2.xyz;
    u_xlat9 = dot(u_xlat0.xyz, u_xlat2.xyz);
    u_xlat9 = (-u_xlat9) * u_xlat9 + 1.0;
    u_xlat9 = sqrt(u_xlat9);
    u_xlat9 = u_xlat9 * unity_LightShadowBias.z;
    u_xlat0.xyz = (-u_xlat0.xyz) * ((float3)(u_xlat9)) + u_xlat1.xyz;
    u_xlatb9 = unity_LightShadowBias.z!=0.0;
    u_xlat0.xyz = (bool(u_xlatb9)) ? u_xlat0.xyz : u_xlat1.xyz;
    u_xlat2 = u_xlat0.yyyy * transpose(unity_MatrixVP)[1];
    u_xlat2 = transpose(unity_MatrixVP)[0] * u_xlat0.xxxx + u_xlat2;
    u_xlat0 = transpose(unity_MatrixVP)[2] * u_xlat0.zzzz + u_xlat2;
    u_xlat0 = transpose(unity_MatrixVP)[3] * u_xlat1.wwww + u_xlat0;
    u_xlat1.x = LF_ShadowNearClamp(u_xlat0.z,u_xlat0.w);
    u_xlat1.x = (-u_xlat0.z) + u_xlat1.x;
    o.vertex.z = unity_LightShadowBias.y * u_xlat1.x + u_xlat0.z;
    o.vertex.xyw = u_xlat0.xyw;
    return o;

}
float4 frag(V i):SV_Target{float4 result=0;
float2 u_xlat0;
bool u_xlatb0;
float u_xlat16_1;
float u_xlat16_3;

    u_xlat0.xy = i.vs_TEXCOORD1.xy + float2(-0.5, -0.5);
    u_xlat0.x = dot(u_xlat0.xy, u_xlat0.xy);
    u_xlat0.x = (-u_xlat0.x) * 4.0 + 1.0;
    u_xlat0.x = max(u_xlat0.x, 0.0);
    u_xlat16_1 = u_xlat0.x * u_xlat0.x;
    u_xlat16_1 = u_xlat16_1 * u_xlat16_1;
    u_xlat16_3 = (-_GlowMin) + _GlowMax;
    u_xlat16_3 = u_xlat16_1 * u_xlat16_3 + _GlowMin;
    u_xlat16_1 = u_xlat16_1 * 30.0;
    u_xlat16_1 = min(u_xlat16_1, 1.0);
    u_xlat16_3 = max(u_xlat16_3, 0.0);
    u_xlat16_3 = min(u_xlat16_3, _MaxValue);
    u_xlat16_1 = u_xlat16_1 * u_xlat16_3;
    u_xlat16_1 = u_xlat16_1 * i.vs_COLOR0.w;
    u_xlat16_1 = min(u_xlat16_1, 1.0);
    u_xlat16_1 = u_xlat16_1 + -0.00999999978;
    u_xlatb0 = u_xlat16_1<0.0;
    if(u_xlatb0){discard;}
    result = float4(0.0, 0.0, 0.0, 0.0);
    return result;

}

#elif defined(SHADOWS_CUBE) && !defined(SHADOWS_DEPTH) && !defined(_CFXR_DITHERED_SHADOWS_ON) && !defined(_CFXR_GLOW_POW_P4) && defined(_CFXR_GLOW_POW_P8) && defined(_FADING_ON)
// Original shadow GLES program 18
float _GlowMin;
float _GlowMax;
float _MaxValue;
struct A{float4 in_POSITION0:POSITION0;float4 in_COLOR0:COLOR0;float4 in_TEXCOORD0:TEXCOORD0;float4 in_TEXCOORD1:TEXCOORD1;float3 in_NORMAL0:NORMAL0;};
struct V{float4 vertex:SV_POSITION;float4 vs_COLOR0:TEXCOORD0;float4 vs_TEXCOORD1:TEXCOORD1;};
V vert(A i){V o=(V)0;
float4 vs_TEXCOORD2;
float4 u_xlat0;
float4 u_xlat1;
float4 u_xlat2;
float u_xlat9;
bool u_xlatb9;

    o.vs_COLOR0 = i.in_COLOR0;
    o.vs_TEXCOORD1 = i.in_TEXCOORD0.xyxy;
    vs_TEXCOORD2 = i.in_TEXCOORD1;
    u_xlat0.x = dot(i.in_NORMAL0.xyz, transpose(unity_WorldToObject)[0].xyz);
    u_xlat0.y = dot(i.in_NORMAL0.xyz, transpose(unity_WorldToObject)[1].xyz);
    u_xlat0.z = dot(i.in_NORMAL0.xyz, transpose(unity_WorldToObject)[2].xyz);
    u_xlat9 = dot(u_xlat0.xyz, u_xlat0.xyz);
    u_xlat9 = rsqrt(u_xlat9);
    u_xlat0.xyz = ((float3)(u_xlat9)) * u_xlat0.xyz;
    u_xlat1 = i.in_POSITION0.yyyy * transpose(unity_ObjectToWorld)[1];
    u_xlat1 = transpose(unity_ObjectToWorld)[0] * i.in_POSITION0.xxxx + u_xlat1;
    u_xlat1 = transpose(unity_ObjectToWorld)[2] * i.in_POSITION0.zzzz + u_xlat1;
    u_xlat1 = transpose(unity_ObjectToWorld)[3] * i.in_POSITION0.wwww + u_xlat1;
    u_xlat2.xyz = (-u_xlat1.xyz) * _WorldSpaceLightPos0.www + _WorldSpaceLightPos0.xyz;
    u_xlat9 = dot(u_xlat2.xyz, u_xlat2.xyz);
    u_xlat9 = rsqrt(u_xlat9);
    u_xlat2.xyz = ((float3)(u_xlat9)) * u_xlat2.xyz;
    u_xlat9 = dot(u_xlat0.xyz, u_xlat2.xyz);
    u_xlat9 = (-u_xlat9) * u_xlat9 + 1.0;
    u_xlat9 = sqrt(u_xlat9);
    u_xlat9 = u_xlat9 * unity_LightShadowBias.z;
    u_xlat0.xyz = (-u_xlat0.xyz) * ((float3)(u_xlat9)) + u_xlat1.xyz;
    u_xlatb9 = unity_LightShadowBias.z!=0.0;
    u_xlat0.xyz = (bool(u_xlatb9)) ? u_xlat0.xyz : u_xlat1.xyz;
    u_xlat2 = u_xlat0.yyyy * transpose(unity_MatrixVP)[1];
    u_xlat2 = transpose(unity_MatrixVP)[0] * u_xlat0.xxxx + u_xlat2;
    u_xlat0 = transpose(unity_MatrixVP)[2] * u_xlat0.zzzz + u_xlat2;
    u_xlat0 = transpose(unity_MatrixVP)[3] * u_xlat1.wwww + u_xlat0;
    u_xlat1.x = LF_ShadowNearClamp(u_xlat0.z,u_xlat0.w);
    u_xlat1.x = (-u_xlat0.z) + u_xlat1.x;
    o.vertex.z = unity_LightShadowBias.y * u_xlat1.x + u_xlat0.z;
    o.vertex.xyw = u_xlat0.xyw;
    return o;

}
float4 frag(V i):SV_Target{float4 result=0;
float2 u_xlat0;
bool u_xlatb0;
float u_xlat16_1;
float u_xlat16_3;

    u_xlat0.xy = i.vs_TEXCOORD1.xy + float2(-0.5, -0.5);
    u_xlat0.x = dot(u_xlat0.xy, u_xlat0.xy);
    u_xlat0.x = (-u_xlat0.x) * 4.0 + 1.0;
    u_xlat0.x = max(u_xlat0.x, 0.0);
    u_xlat16_1 = u_xlat0.x * u_xlat0.x;
    u_xlat16_1 = u_xlat16_1 * u_xlat16_1;
    u_xlat16_1 = u_xlat16_1 * u_xlat16_1;
    u_xlat16_3 = (-_GlowMin) + _GlowMax;
    u_xlat16_3 = u_xlat16_1 * u_xlat16_3 + _GlowMin;
    u_xlat16_1 = u_xlat16_1 * 30.0;
    u_xlat16_1 = min(u_xlat16_1, 1.0);
    u_xlat16_3 = max(u_xlat16_3, 0.0);
    u_xlat16_3 = min(u_xlat16_3, _MaxValue);
    u_xlat16_1 = u_xlat16_1 * u_xlat16_3;
    u_xlat16_1 = u_xlat16_1 * i.vs_COLOR0.w;
    u_xlat16_1 = min(u_xlat16_1, 1.0);
    u_xlat16_1 = u_xlat16_1 + -0.00999999978;
    u_xlatb0 = u_xlat16_1<0.0;
    if(u_xlatb0){discard;}
    result = float4(0.0, 0.0, 0.0, 0.0);
    return result;

}

#elif defined(SHADOWS_CUBE) && !defined(SHADOWS_DEPTH) && defined(_CFXR_DITHERED_SHADOWS_ON) && !defined(_CFXR_GLOW_POW_P4) && !defined(_CFXR_GLOW_POW_P8) && defined(_FADING_ON)
// Original shadow GLES program 19
float _GlowMin;
float _GlowMax;
float _MaxValue;
float _ShadowStrength;
sampler3D _DitherMaskLOD;
struct A{float4 in_POSITION0:POSITION0;float4 in_COLOR0:COLOR0;float4 in_TEXCOORD0:TEXCOORD0;float4 in_TEXCOORD1:TEXCOORD1;float3 in_NORMAL0:NORMAL0;};
struct V{float4 vertex:SV_POSITION;float4 vs_COLOR0:TEXCOORD0;float4 vs_TEXCOORD1:TEXCOORD1;};
V vert(A i){V o=(V)0;
float4 vs_TEXCOORD2;
float4 u_xlat0;
float4 u_xlat1;
float4 u_xlat2;
float u_xlat9;
bool u_xlatb9;

    o.vs_COLOR0 = i.in_COLOR0;
    o.vs_TEXCOORD1 = i.in_TEXCOORD0.xyxy;
    vs_TEXCOORD2 = i.in_TEXCOORD1;
    u_xlat0.x = dot(i.in_NORMAL0.xyz, transpose(unity_WorldToObject)[0].xyz);
    u_xlat0.y = dot(i.in_NORMAL0.xyz, transpose(unity_WorldToObject)[1].xyz);
    u_xlat0.z = dot(i.in_NORMAL0.xyz, transpose(unity_WorldToObject)[2].xyz);
    u_xlat9 = dot(u_xlat0.xyz, u_xlat0.xyz);
    u_xlat9 = rsqrt(u_xlat9);
    u_xlat0.xyz = ((float3)(u_xlat9)) * u_xlat0.xyz;
    u_xlat1 = i.in_POSITION0.yyyy * transpose(unity_ObjectToWorld)[1];
    u_xlat1 = transpose(unity_ObjectToWorld)[0] * i.in_POSITION0.xxxx + u_xlat1;
    u_xlat1 = transpose(unity_ObjectToWorld)[2] * i.in_POSITION0.zzzz + u_xlat1;
    u_xlat1 = transpose(unity_ObjectToWorld)[3] * i.in_POSITION0.wwww + u_xlat1;
    u_xlat2.xyz = (-u_xlat1.xyz) * _WorldSpaceLightPos0.www + _WorldSpaceLightPos0.xyz;
    u_xlat9 = dot(u_xlat2.xyz, u_xlat2.xyz);
    u_xlat9 = rsqrt(u_xlat9);
    u_xlat2.xyz = ((float3)(u_xlat9)) * u_xlat2.xyz;
    u_xlat9 = dot(u_xlat0.xyz, u_xlat2.xyz);
    u_xlat9 = (-u_xlat9) * u_xlat9 + 1.0;
    u_xlat9 = sqrt(u_xlat9);
    u_xlat9 = u_xlat9 * unity_LightShadowBias.z;
    u_xlat0.xyz = (-u_xlat0.xyz) * ((float3)(u_xlat9)) + u_xlat1.xyz;
    u_xlatb9 = unity_LightShadowBias.z!=0.0;
    u_xlat0.xyz = (bool(u_xlatb9)) ? u_xlat0.xyz : u_xlat1.xyz;
    u_xlat2 = u_xlat0.yyyy * transpose(unity_MatrixVP)[1];
    u_xlat2 = transpose(unity_MatrixVP)[0] * u_xlat0.xxxx + u_xlat2;
    u_xlat0 = transpose(unity_MatrixVP)[2] * u_xlat0.zzzz + u_xlat2;
    u_xlat0 = transpose(unity_MatrixVP)[3] * u_xlat1.wwww + u_xlat0;
    u_xlat1.x = LF_ShadowNearClamp(u_xlat0.z,u_xlat0.w);
    u_xlat1.x = (-u_xlat0.z) + u_xlat1.x;
    o.vertex.z = unity_LightShadowBias.y * u_xlat1.x + u_xlat0.z;
    o.vertex.xyw = u_xlat0.xyw;
    return o;

}
float4 frag(V i):SV_Target{float4 result=0;
float2 u_xlat0;
float u_xlat16_1;
float3 u_xlat2;
float u_xlat16_2;
float u_xlat3;
float u_xlat16_3;
bool u_xlatb3;
float u_xlat16_4;
float u_xlat16_7;
float u_xlat16_12;

float4 hlslcc_FragCoord = float4(i.vertex.xyz, 1.0/i.vertex.w);
    u_xlat0.xy = i.vs_TEXCOORD1.xy + float2(-0.5, -0.5);
    u_xlat0.x = dot(u_xlat0.xy, u_xlat0.xy);
    u_xlat0.x = (-u_xlat0.x) * 4.0 + 1.0;
    u_xlat0.x = max(u_xlat0.x, 0.0);
    u_xlat16_1 = (-_GlowMin) + _GlowMax;
    u_xlat16_2 = u_xlat0.x * u_xlat16_1 + _GlowMin;
    u_xlat16_7 = u_xlat0.x * 30.0;
    u_xlat16_7 = min(u_xlat16_7, 1.0);
    u_xlat16_2 = max(u_xlat16_2, 0.0);
    u_xlat16_2 = min(u_xlat16_2, _MaxValue);
    u_xlat16_2 = u_xlat16_7 * u_xlat16_2;
    u_xlat16_2 = u_xlat16_2 * i.vs_COLOR0.w;
    u_xlat16_2 = min(u_xlat16_2, 1.0);
    u_xlat3 = min(u_xlat16_2, _ShadowStrength);
    u_xlat16_12 = u_xlat3 * 0.9375;
    u_xlat2.z = u_xlat16_12;
    u_xlat2.xy = hlslcc_FragCoord.xy * float2(0.25, 0.25);
    u_xlat16_3 = tex3D(_DitherMaskLOD, u_xlat2.xyz).w;
    u_xlat16_4 = u_xlat16_3 + -0.00999999978;
    u_xlatb3 = u_xlat16_4<0.0;
    if(u_xlatb3){discard;}
    result = float4(0.0, 0.0, 0.0, 0.0);
    return result;

}

#elif !defined(SHADOWS_CUBE) && defined(SHADOWS_DEPTH) && !defined(_CFXR_DITHERED_SHADOWS_ON) && defined(_CFXR_GLOW_POW_P4) && !defined(_CFXR_GLOW_POW_P8) && defined(_FADING_ON)
// Original shadow GLES program 23
float _GlowMin;
float _GlowMax;
float _MaxValue;
struct A{float4 in_POSITION0:POSITION0;float4 in_COLOR0:COLOR0;float4 in_TEXCOORD0:TEXCOORD0;float4 in_TEXCOORD1:TEXCOORD1;float3 in_NORMAL0:NORMAL0;};
struct V{float4 vertex:SV_POSITION;float4 vs_COLOR0:TEXCOORD0;float4 vs_TEXCOORD1:TEXCOORD1;};
V vert(A i){V o=(V)0;
float4 vs_TEXCOORD2;
float4 u_xlat0;
float4 u_xlat1;
float4 u_xlat2;
float u_xlat6;
float u_xlat9;
bool u_xlatb9;

    o.vs_COLOR0 = i.in_COLOR0;
    o.vs_TEXCOORD1 = i.in_TEXCOORD0.xyxy;
    vs_TEXCOORD2 = i.in_TEXCOORD1;
    u_xlat0.x = dot(i.in_NORMAL0.xyz, transpose(unity_WorldToObject)[0].xyz);
    u_xlat0.y = dot(i.in_NORMAL0.xyz, transpose(unity_WorldToObject)[1].xyz);
    u_xlat0.z = dot(i.in_NORMAL0.xyz, transpose(unity_WorldToObject)[2].xyz);
    u_xlat9 = dot(u_xlat0.xyz, u_xlat0.xyz);
    u_xlat9 = rsqrt(u_xlat9);
    u_xlat0.xyz = ((float3)(u_xlat9)) * u_xlat0.xyz;
    u_xlat1 = i.in_POSITION0.yyyy * transpose(unity_ObjectToWorld)[1];
    u_xlat1 = transpose(unity_ObjectToWorld)[0] * i.in_POSITION0.xxxx + u_xlat1;
    u_xlat1 = transpose(unity_ObjectToWorld)[2] * i.in_POSITION0.zzzz + u_xlat1;
    u_xlat1 = transpose(unity_ObjectToWorld)[3] * i.in_POSITION0.wwww + u_xlat1;
    u_xlat2.xyz = (-u_xlat1.xyz) * _WorldSpaceLightPos0.www + _WorldSpaceLightPos0.xyz;
    u_xlat9 = dot(u_xlat2.xyz, u_xlat2.xyz);
    u_xlat9 = rsqrt(u_xlat9);
    u_xlat2.xyz = ((float3)(u_xlat9)) * u_xlat2.xyz;
    u_xlat9 = dot(u_xlat0.xyz, u_xlat2.xyz);
    u_xlat9 = (-u_xlat9) * u_xlat9 + 1.0;
    u_xlat9 = sqrt(u_xlat9);
    u_xlat9 = u_xlat9 * unity_LightShadowBias.z;
    u_xlat0.xyz = (-u_xlat0.xyz) * ((float3)(u_xlat9)) + u_xlat1.xyz;
    u_xlatb9 = unity_LightShadowBias.z!=0.0;
    u_xlat0.xyz = (bool(u_xlatb9)) ? u_xlat0.xyz : u_xlat1.xyz;
    u_xlat2 = u_xlat0.yyyy * transpose(unity_MatrixVP)[1];
    u_xlat2 = transpose(unity_MatrixVP)[0] * u_xlat0.xxxx + u_xlat2;
    u_xlat0 = transpose(unity_MatrixVP)[2] * u_xlat0.zzzz + u_xlat2;
    u_xlat0 = transpose(unity_MatrixVP)[3] * u_xlat1.wwww + u_xlat0;
    u_xlat1.x = LF_ShadowBiasDelta(unity_LightShadowBias.x / u_xlat0.w);
    u_xlat6 = u_xlat0.z + u_xlat1.x;
    u_xlat1.x = LF_ShadowNearClamp(u_xlat6,u_xlat0.w);
    o.vertex.xyw = u_xlat0.xyw;
    u_xlat0.x = (-u_xlat6) + u_xlat1.x;
    o.vertex.z = unity_LightShadowBias.y * u_xlat0.x + u_xlat6;
    return o;

}
float4 frag(V i):SV_Target{float4 result=0;
float2 u_xlat0;
bool u_xlatb0;
float u_xlat16_1;
float u_xlat16_3;

    u_xlat0.xy = i.vs_TEXCOORD1.xy + float2(-0.5, -0.5);
    u_xlat0.x = dot(u_xlat0.xy, u_xlat0.xy);
    u_xlat0.x = (-u_xlat0.x) * 4.0 + 1.0;
    u_xlat0.x = max(u_xlat0.x, 0.0);
    u_xlat16_1 = u_xlat0.x * u_xlat0.x;
    u_xlat16_1 = u_xlat16_1 * u_xlat16_1;
    u_xlat16_3 = (-_GlowMin) + _GlowMax;
    u_xlat16_3 = u_xlat16_1 * u_xlat16_3 + _GlowMin;
    u_xlat16_1 = u_xlat16_1 * 30.0;
    u_xlat16_1 = min(u_xlat16_1, 1.0);
    u_xlat16_3 = max(u_xlat16_3, 0.0);
    u_xlat16_3 = min(u_xlat16_3, _MaxValue);
    u_xlat16_1 = u_xlat16_1 * u_xlat16_3;
    u_xlat16_1 = u_xlat16_1 * i.vs_COLOR0.w;
    u_xlat16_1 = min(u_xlat16_1, 1.0);
    u_xlat16_1 = u_xlat16_1 + -0.00999999978;
    u_xlatb0 = u_xlat16_1<0.0;
    if(u_xlatb0){discard;}
    result = float4(0.0, 0.0, 0.0, 0.0);
    return result;

}

#elif !defined(SHADOWS_CUBE) && defined(SHADOWS_DEPTH) && !defined(_CFXR_DITHERED_SHADOWS_ON) && !defined(_CFXR_GLOW_POW_P4) && defined(_CFXR_GLOW_POW_P8) && defined(_FADING_ON)
// Original shadow GLES program 24
float _GlowMin;
float _GlowMax;
float _MaxValue;
struct A{float4 in_POSITION0:POSITION0;float4 in_COLOR0:COLOR0;float4 in_TEXCOORD0:TEXCOORD0;float4 in_TEXCOORD1:TEXCOORD1;float3 in_NORMAL0:NORMAL0;};
struct V{float4 vertex:SV_POSITION;float4 vs_COLOR0:TEXCOORD0;float4 vs_TEXCOORD1:TEXCOORD1;};
V vert(A i){V o=(V)0;
float4 vs_TEXCOORD2;
float4 u_xlat0;
float4 u_xlat1;
float4 u_xlat2;
float u_xlat6;
float u_xlat9;
bool u_xlatb9;

    o.vs_COLOR0 = i.in_COLOR0;
    o.vs_TEXCOORD1 = i.in_TEXCOORD0.xyxy;
    vs_TEXCOORD2 = i.in_TEXCOORD1;
    u_xlat0.x = dot(i.in_NORMAL0.xyz, transpose(unity_WorldToObject)[0].xyz);
    u_xlat0.y = dot(i.in_NORMAL0.xyz, transpose(unity_WorldToObject)[1].xyz);
    u_xlat0.z = dot(i.in_NORMAL0.xyz, transpose(unity_WorldToObject)[2].xyz);
    u_xlat9 = dot(u_xlat0.xyz, u_xlat0.xyz);
    u_xlat9 = rsqrt(u_xlat9);
    u_xlat0.xyz = ((float3)(u_xlat9)) * u_xlat0.xyz;
    u_xlat1 = i.in_POSITION0.yyyy * transpose(unity_ObjectToWorld)[1];
    u_xlat1 = transpose(unity_ObjectToWorld)[0] * i.in_POSITION0.xxxx + u_xlat1;
    u_xlat1 = transpose(unity_ObjectToWorld)[2] * i.in_POSITION0.zzzz + u_xlat1;
    u_xlat1 = transpose(unity_ObjectToWorld)[3] * i.in_POSITION0.wwww + u_xlat1;
    u_xlat2.xyz = (-u_xlat1.xyz) * _WorldSpaceLightPos0.www + _WorldSpaceLightPos0.xyz;
    u_xlat9 = dot(u_xlat2.xyz, u_xlat2.xyz);
    u_xlat9 = rsqrt(u_xlat9);
    u_xlat2.xyz = ((float3)(u_xlat9)) * u_xlat2.xyz;
    u_xlat9 = dot(u_xlat0.xyz, u_xlat2.xyz);
    u_xlat9 = (-u_xlat9) * u_xlat9 + 1.0;
    u_xlat9 = sqrt(u_xlat9);
    u_xlat9 = u_xlat9 * unity_LightShadowBias.z;
    u_xlat0.xyz = (-u_xlat0.xyz) * ((float3)(u_xlat9)) + u_xlat1.xyz;
    u_xlatb9 = unity_LightShadowBias.z!=0.0;
    u_xlat0.xyz = (bool(u_xlatb9)) ? u_xlat0.xyz : u_xlat1.xyz;
    u_xlat2 = u_xlat0.yyyy * transpose(unity_MatrixVP)[1];
    u_xlat2 = transpose(unity_MatrixVP)[0] * u_xlat0.xxxx + u_xlat2;
    u_xlat0 = transpose(unity_MatrixVP)[2] * u_xlat0.zzzz + u_xlat2;
    u_xlat0 = transpose(unity_MatrixVP)[3] * u_xlat1.wwww + u_xlat0;
    u_xlat1.x = LF_ShadowBiasDelta(unity_LightShadowBias.x / u_xlat0.w);
    u_xlat6 = u_xlat0.z + u_xlat1.x;
    u_xlat1.x = LF_ShadowNearClamp(u_xlat6,u_xlat0.w);
    o.vertex.xyw = u_xlat0.xyw;
    u_xlat0.x = (-u_xlat6) + u_xlat1.x;
    o.vertex.z = unity_LightShadowBias.y * u_xlat0.x + u_xlat6;
    return o;

}
float4 frag(V i):SV_Target{float4 result=0;
float2 u_xlat0;
bool u_xlatb0;
float u_xlat16_1;
float u_xlat16_3;

    u_xlat0.xy = i.vs_TEXCOORD1.xy + float2(-0.5, -0.5);
    u_xlat0.x = dot(u_xlat0.xy, u_xlat0.xy);
    u_xlat0.x = (-u_xlat0.x) * 4.0 + 1.0;
    u_xlat0.x = max(u_xlat0.x, 0.0);
    u_xlat16_1 = u_xlat0.x * u_xlat0.x;
    u_xlat16_1 = u_xlat16_1 * u_xlat16_1;
    u_xlat16_1 = u_xlat16_1 * u_xlat16_1;
    u_xlat16_3 = (-_GlowMin) + _GlowMax;
    u_xlat16_3 = u_xlat16_1 * u_xlat16_3 + _GlowMin;
    u_xlat16_1 = u_xlat16_1 * 30.0;
    u_xlat16_1 = min(u_xlat16_1, 1.0);
    u_xlat16_3 = max(u_xlat16_3, 0.0);
    u_xlat16_3 = min(u_xlat16_3, _MaxValue);
    u_xlat16_1 = u_xlat16_1 * u_xlat16_3;
    u_xlat16_1 = u_xlat16_1 * i.vs_COLOR0.w;
    u_xlat16_1 = min(u_xlat16_1, 1.0);
    u_xlat16_1 = u_xlat16_1 + -0.00999999978;
    u_xlatb0 = u_xlat16_1<0.0;
    if(u_xlatb0){discard;}
    result = float4(0.0, 0.0, 0.0, 0.0);
    return result;

}

#elif !defined(SHADOWS_CUBE) && defined(SHADOWS_DEPTH) && defined(_CFXR_DITHERED_SHADOWS_ON) && !defined(_CFXR_GLOW_POW_P4) && !defined(_CFXR_GLOW_POW_P8) && defined(_FADING_ON)
// Original shadow GLES program 25
float _GlowMin;
float _GlowMax;
float _MaxValue;
float _ShadowStrength;
sampler3D _DitherMaskLOD;
struct A{float4 in_POSITION0:POSITION0;float4 in_COLOR0:COLOR0;float4 in_TEXCOORD0:TEXCOORD0;float4 in_TEXCOORD1:TEXCOORD1;float3 in_NORMAL0:NORMAL0;};
struct V{float4 vertex:SV_POSITION;float4 vs_COLOR0:TEXCOORD0;float4 vs_TEXCOORD1:TEXCOORD1;};
V vert(A i){V o=(V)0;
float4 vs_TEXCOORD2;
float4 u_xlat0;
float4 u_xlat1;
float4 u_xlat2;
float u_xlat6;
float u_xlat9;
bool u_xlatb9;

    o.vs_COLOR0 = i.in_COLOR0;
    o.vs_TEXCOORD1 = i.in_TEXCOORD0.xyxy;
    vs_TEXCOORD2 = i.in_TEXCOORD1;
    u_xlat0.x = dot(i.in_NORMAL0.xyz, transpose(unity_WorldToObject)[0].xyz);
    u_xlat0.y = dot(i.in_NORMAL0.xyz, transpose(unity_WorldToObject)[1].xyz);
    u_xlat0.z = dot(i.in_NORMAL0.xyz, transpose(unity_WorldToObject)[2].xyz);
    u_xlat9 = dot(u_xlat0.xyz, u_xlat0.xyz);
    u_xlat9 = rsqrt(u_xlat9);
    u_xlat0.xyz = ((float3)(u_xlat9)) * u_xlat0.xyz;
    u_xlat1 = i.in_POSITION0.yyyy * transpose(unity_ObjectToWorld)[1];
    u_xlat1 = transpose(unity_ObjectToWorld)[0] * i.in_POSITION0.xxxx + u_xlat1;
    u_xlat1 = transpose(unity_ObjectToWorld)[2] * i.in_POSITION0.zzzz + u_xlat1;
    u_xlat1 = transpose(unity_ObjectToWorld)[3] * i.in_POSITION0.wwww + u_xlat1;
    u_xlat2.xyz = (-u_xlat1.xyz) * _WorldSpaceLightPos0.www + _WorldSpaceLightPos0.xyz;
    u_xlat9 = dot(u_xlat2.xyz, u_xlat2.xyz);
    u_xlat9 = rsqrt(u_xlat9);
    u_xlat2.xyz = ((float3)(u_xlat9)) * u_xlat2.xyz;
    u_xlat9 = dot(u_xlat0.xyz, u_xlat2.xyz);
    u_xlat9 = (-u_xlat9) * u_xlat9 + 1.0;
    u_xlat9 = sqrt(u_xlat9);
    u_xlat9 = u_xlat9 * unity_LightShadowBias.z;
    u_xlat0.xyz = (-u_xlat0.xyz) * ((float3)(u_xlat9)) + u_xlat1.xyz;
    u_xlatb9 = unity_LightShadowBias.z!=0.0;
    u_xlat0.xyz = (bool(u_xlatb9)) ? u_xlat0.xyz : u_xlat1.xyz;
    u_xlat2 = u_xlat0.yyyy * transpose(unity_MatrixVP)[1];
    u_xlat2 = transpose(unity_MatrixVP)[0] * u_xlat0.xxxx + u_xlat2;
    u_xlat0 = transpose(unity_MatrixVP)[2] * u_xlat0.zzzz + u_xlat2;
    u_xlat0 = transpose(unity_MatrixVP)[3] * u_xlat1.wwww + u_xlat0;
    u_xlat1.x = LF_ShadowBiasDelta(unity_LightShadowBias.x / u_xlat0.w);
    u_xlat6 = u_xlat0.z + u_xlat1.x;
    u_xlat1.x = LF_ShadowNearClamp(u_xlat6,u_xlat0.w);
    o.vertex.xyw = u_xlat0.xyw;
    u_xlat0.x = (-u_xlat6) + u_xlat1.x;
    o.vertex.z = unity_LightShadowBias.y * u_xlat0.x + u_xlat6;
    return o;

}
float4 frag(V i):SV_Target{float4 result=0;
float2 u_xlat0;
float u_xlat16_1;
float3 u_xlat2;
float u_xlat16_2;
float u_xlat3;
float u_xlat16_3;
bool u_xlatb3;
float u_xlat16_4;
float u_xlat16_7;
float u_xlat16_12;

float4 hlslcc_FragCoord = float4(i.vertex.xyz, 1.0/i.vertex.w);
    u_xlat0.xy = i.vs_TEXCOORD1.xy + float2(-0.5, -0.5);
    u_xlat0.x = dot(u_xlat0.xy, u_xlat0.xy);
    u_xlat0.x = (-u_xlat0.x) * 4.0 + 1.0;
    u_xlat0.x = max(u_xlat0.x, 0.0);
    u_xlat16_1 = (-_GlowMin) + _GlowMax;
    u_xlat16_2 = u_xlat0.x * u_xlat16_1 + _GlowMin;
    u_xlat16_7 = u_xlat0.x * 30.0;
    u_xlat16_7 = min(u_xlat16_7, 1.0);
    u_xlat16_2 = max(u_xlat16_2, 0.0);
    u_xlat16_2 = min(u_xlat16_2, _MaxValue);
    u_xlat16_2 = u_xlat16_7 * u_xlat16_2;
    u_xlat16_2 = u_xlat16_2 * i.vs_COLOR0.w;
    u_xlat16_2 = min(u_xlat16_2, 1.0);
    u_xlat3 = min(u_xlat16_2, _ShadowStrength);
    u_xlat16_12 = u_xlat3 * 0.9375;
    u_xlat2.z = u_xlat16_12;
    u_xlat2.xy = hlslcc_FragCoord.xy * float2(0.25, 0.25);
    u_xlat16_3 = tex3D(_DitherMaskLOD, u_xlat2.xyz).w;
    u_xlat16_4 = u_xlat16_3 + -0.00999999978;
    u_xlatb3 = u_xlat16_4<0.0;
    if(u_xlatb3){discard;}
    result = float4(0.0, 0.0, 0.0, 0.0);
    return result;

}

#elif defined(SHADOWS_CUBE) && !defined(SHADOWS_DEPTH) && !defined(_CFXR_DITHERED_SHADOWS_ON) && defined(_CFXR_GLOW_POW_P4) && !defined(_CFXR_GLOW_POW_P8) && !defined(_FADING_ON)
// Original shadow GLES program 15
float _GlowMin;
float _GlowMax;
float _MaxValue;
struct A{float4 in_POSITION0:POSITION0;float4 in_COLOR0:COLOR0;float4 in_TEXCOORD0:TEXCOORD0;float4 in_TEXCOORD1:TEXCOORD1;float3 in_NORMAL0:NORMAL0;};
struct V{float4 vertex:SV_POSITION;float4 vs_COLOR0:TEXCOORD0;float4 vs_TEXCOORD1:TEXCOORD1;};
V vert(A i){V o=(V)0;
float4 vs_TEXCOORD2;
float4 u_xlat0;
float4 u_xlat1;
float4 u_xlat2;
float u_xlat9;
bool u_xlatb9;

    o.vs_COLOR0 = i.in_COLOR0;
    o.vs_TEXCOORD1 = i.in_TEXCOORD0.xyxy;
    vs_TEXCOORD2 = i.in_TEXCOORD1;
    u_xlat0.x = dot(i.in_NORMAL0.xyz, transpose(unity_WorldToObject)[0].xyz);
    u_xlat0.y = dot(i.in_NORMAL0.xyz, transpose(unity_WorldToObject)[1].xyz);
    u_xlat0.z = dot(i.in_NORMAL0.xyz, transpose(unity_WorldToObject)[2].xyz);
    u_xlat9 = dot(u_xlat0.xyz, u_xlat0.xyz);
    u_xlat9 = rsqrt(u_xlat9);
    u_xlat0.xyz = ((float3)(u_xlat9)) * u_xlat0.xyz;
    u_xlat1 = i.in_POSITION0.yyyy * transpose(unity_ObjectToWorld)[1];
    u_xlat1 = transpose(unity_ObjectToWorld)[0] * i.in_POSITION0.xxxx + u_xlat1;
    u_xlat1 = transpose(unity_ObjectToWorld)[2] * i.in_POSITION0.zzzz + u_xlat1;
    u_xlat1 = transpose(unity_ObjectToWorld)[3] * i.in_POSITION0.wwww + u_xlat1;
    u_xlat2.xyz = (-u_xlat1.xyz) * _WorldSpaceLightPos0.www + _WorldSpaceLightPos0.xyz;
    u_xlat9 = dot(u_xlat2.xyz, u_xlat2.xyz);
    u_xlat9 = rsqrt(u_xlat9);
    u_xlat2.xyz = ((float3)(u_xlat9)) * u_xlat2.xyz;
    u_xlat9 = dot(u_xlat0.xyz, u_xlat2.xyz);
    u_xlat9 = (-u_xlat9) * u_xlat9 + 1.0;
    u_xlat9 = sqrt(u_xlat9);
    u_xlat9 = u_xlat9 * unity_LightShadowBias.z;
    u_xlat0.xyz = (-u_xlat0.xyz) * ((float3)(u_xlat9)) + u_xlat1.xyz;
    u_xlatb9 = unity_LightShadowBias.z!=0.0;
    u_xlat0.xyz = (bool(u_xlatb9)) ? u_xlat0.xyz : u_xlat1.xyz;
    u_xlat2 = u_xlat0.yyyy * transpose(unity_MatrixVP)[1];
    u_xlat2 = transpose(unity_MatrixVP)[0] * u_xlat0.xxxx + u_xlat2;
    u_xlat0 = transpose(unity_MatrixVP)[2] * u_xlat0.zzzz + u_xlat2;
    u_xlat0 = transpose(unity_MatrixVP)[3] * u_xlat1.wwww + u_xlat0;
    u_xlat1.x = LF_ShadowNearClamp(u_xlat0.z,u_xlat0.w);
    u_xlat1.x = (-u_xlat0.z) + u_xlat1.x;
    o.vertex.z = unity_LightShadowBias.y * u_xlat1.x + u_xlat0.z;
    o.vertex.xyw = u_xlat0.xyw;
    return o;

}
float4 frag(V i):SV_Target{float4 result=0;
float2 u_xlat0;
bool u_xlatb0;
float u_xlat16_1;
float u_xlat16_3;

    u_xlat0.xy = i.vs_TEXCOORD1.xy + float2(-0.5, -0.5);
    u_xlat0.x = dot(u_xlat0.xy, u_xlat0.xy);
    u_xlat0.x = (-u_xlat0.x) * 4.0 + 1.0;
    u_xlat0.x = max(u_xlat0.x, 0.0);
    u_xlat16_1 = u_xlat0.x * u_xlat0.x;
    u_xlat16_1 = u_xlat16_1 * u_xlat16_1;
    u_xlat16_3 = (-_GlowMin) + _GlowMax;
    u_xlat16_3 = u_xlat16_1 * u_xlat16_3 + _GlowMin;
    u_xlat16_1 = u_xlat16_1 * 30.0;
    u_xlat16_1 = min(u_xlat16_1, 1.0);
    u_xlat16_3 = max(u_xlat16_3, 0.0);
    u_xlat16_3 = min(u_xlat16_3, _MaxValue);
    u_xlat16_1 = u_xlat16_1 * u_xlat16_3;
    u_xlat16_1 = u_xlat16_1 * i.vs_COLOR0.w;
    u_xlat16_1 = min(u_xlat16_1, 1.0);
    u_xlat16_1 = u_xlat16_1 + -0.00999999978;
    u_xlatb0 = u_xlat16_1<0.0;
    if(u_xlatb0){discard;}
    result = float4(0.0, 0.0, 0.0, 0.0);
    return result;

}

#elif defined(SHADOWS_CUBE) && !defined(SHADOWS_DEPTH) && !defined(_CFXR_DITHERED_SHADOWS_ON) && !defined(_CFXR_GLOW_POW_P4) && !defined(_CFXR_GLOW_POW_P8) && defined(_FADING_ON)
// Original shadow GLES program 16
float _GlowMin;
float _GlowMax;
float _MaxValue;
struct A{float4 in_POSITION0:POSITION0;float4 in_COLOR0:COLOR0;float4 in_TEXCOORD0:TEXCOORD0;float4 in_TEXCOORD1:TEXCOORD1;float3 in_NORMAL0:NORMAL0;};
struct V{float4 vertex:SV_POSITION;float4 vs_COLOR0:TEXCOORD0;float4 vs_TEXCOORD1:TEXCOORD1;};
V vert(A i){V o=(V)0;
float4 vs_TEXCOORD2;
float4 u_xlat0;
float4 u_xlat1;
float4 u_xlat2;
float u_xlat9;
bool u_xlatb9;

    o.vs_COLOR0 = i.in_COLOR0;
    o.vs_TEXCOORD1 = i.in_TEXCOORD0.xyxy;
    vs_TEXCOORD2 = i.in_TEXCOORD1;
    u_xlat0.x = dot(i.in_NORMAL0.xyz, transpose(unity_WorldToObject)[0].xyz);
    u_xlat0.y = dot(i.in_NORMAL0.xyz, transpose(unity_WorldToObject)[1].xyz);
    u_xlat0.z = dot(i.in_NORMAL0.xyz, transpose(unity_WorldToObject)[2].xyz);
    u_xlat9 = dot(u_xlat0.xyz, u_xlat0.xyz);
    u_xlat9 = rsqrt(u_xlat9);
    u_xlat0.xyz = ((float3)(u_xlat9)) * u_xlat0.xyz;
    u_xlat1 = i.in_POSITION0.yyyy * transpose(unity_ObjectToWorld)[1];
    u_xlat1 = transpose(unity_ObjectToWorld)[0] * i.in_POSITION0.xxxx + u_xlat1;
    u_xlat1 = transpose(unity_ObjectToWorld)[2] * i.in_POSITION0.zzzz + u_xlat1;
    u_xlat1 = transpose(unity_ObjectToWorld)[3] * i.in_POSITION0.wwww + u_xlat1;
    u_xlat2.xyz = (-u_xlat1.xyz) * _WorldSpaceLightPos0.www + _WorldSpaceLightPos0.xyz;
    u_xlat9 = dot(u_xlat2.xyz, u_xlat2.xyz);
    u_xlat9 = rsqrt(u_xlat9);
    u_xlat2.xyz = ((float3)(u_xlat9)) * u_xlat2.xyz;
    u_xlat9 = dot(u_xlat0.xyz, u_xlat2.xyz);
    u_xlat9 = (-u_xlat9) * u_xlat9 + 1.0;
    u_xlat9 = sqrt(u_xlat9);
    u_xlat9 = u_xlat9 * unity_LightShadowBias.z;
    u_xlat0.xyz = (-u_xlat0.xyz) * ((float3)(u_xlat9)) + u_xlat1.xyz;
    u_xlatb9 = unity_LightShadowBias.z!=0.0;
    u_xlat0.xyz = (bool(u_xlatb9)) ? u_xlat0.xyz : u_xlat1.xyz;
    u_xlat2 = u_xlat0.yyyy * transpose(unity_MatrixVP)[1];
    u_xlat2 = transpose(unity_MatrixVP)[0] * u_xlat0.xxxx + u_xlat2;
    u_xlat0 = transpose(unity_MatrixVP)[2] * u_xlat0.zzzz + u_xlat2;
    u_xlat0 = transpose(unity_MatrixVP)[3] * u_xlat1.wwww + u_xlat0;
    u_xlat1.x = LF_ShadowNearClamp(u_xlat0.z,u_xlat0.w);
    u_xlat1.x = (-u_xlat0.z) + u_xlat1.x;
    o.vertex.z = unity_LightShadowBias.y * u_xlat1.x + u_xlat0.z;
    o.vertex.xyw = u_xlat0.xyw;
    return o;

}
float4 frag(V i):SV_Target{float4 result=0;
float2 u_xlat0;
bool u_xlatb0;
float u_xlat16_1;
float u_xlat16_3;

    u_xlat0.xy = i.vs_TEXCOORD1.xy + float2(-0.5, -0.5);
    u_xlat0.x = dot(u_xlat0.xy, u_xlat0.xy);
    u_xlat0.x = (-u_xlat0.x) * 4.0 + 1.0;
    u_xlat0.x = max(u_xlat0.x, 0.0);
    u_xlat16_1 = (-_GlowMin) + _GlowMax;
    u_xlat16_1 = u_xlat0.x * u_xlat16_1 + _GlowMin;
    u_xlat16_3 = u_xlat0.x * 30.0;
    u_xlat16_3 = min(u_xlat16_3, 1.0);
    u_xlat16_1 = max(u_xlat16_1, 0.0);
    u_xlat16_1 = min(u_xlat16_1, _MaxValue);
    u_xlat16_1 = u_xlat16_3 * u_xlat16_1;
    u_xlat16_1 = u_xlat16_1 * i.vs_COLOR0.w;
    u_xlat16_1 = min(u_xlat16_1, 1.0);
    u_xlat16_1 = u_xlat16_1 + -0.00999999978;
    u_xlatb0 = u_xlat16_1<0.0;
    if(u_xlatb0){discard;}
    result = float4(0.0, 0.0, 0.0, 0.0);
    return result;

}

#elif !defined(SHADOWS_CUBE) && defined(SHADOWS_DEPTH) && !defined(_CFXR_DITHERED_SHADOWS_ON) && defined(_CFXR_GLOW_POW_P4) && !defined(_CFXR_GLOW_POW_P8) && !defined(_FADING_ON)
// Original shadow GLES program 21
float _GlowMin;
float _GlowMax;
float _MaxValue;
struct A{float4 in_POSITION0:POSITION0;float4 in_COLOR0:COLOR0;float4 in_TEXCOORD0:TEXCOORD0;float4 in_TEXCOORD1:TEXCOORD1;float3 in_NORMAL0:NORMAL0;};
struct V{float4 vertex:SV_POSITION;float4 vs_COLOR0:TEXCOORD0;float4 vs_TEXCOORD1:TEXCOORD1;};
V vert(A i){V o=(V)0;
float4 vs_TEXCOORD2;
float4 u_xlat0;
float4 u_xlat1;
float4 u_xlat2;
float u_xlat6;
float u_xlat9;
bool u_xlatb9;

    o.vs_COLOR0 = i.in_COLOR0;
    o.vs_TEXCOORD1 = i.in_TEXCOORD0.xyxy;
    vs_TEXCOORD2 = i.in_TEXCOORD1;
    u_xlat0.x = dot(i.in_NORMAL0.xyz, transpose(unity_WorldToObject)[0].xyz);
    u_xlat0.y = dot(i.in_NORMAL0.xyz, transpose(unity_WorldToObject)[1].xyz);
    u_xlat0.z = dot(i.in_NORMAL0.xyz, transpose(unity_WorldToObject)[2].xyz);
    u_xlat9 = dot(u_xlat0.xyz, u_xlat0.xyz);
    u_xlat9 = rsqrt(u_xlat9);
    u_xlat0.xyz = ((float3)(u_xlat9)) * u_xlat0.xyz;
    u_xlat1 = i.in_POSITION0.yyyy * transpose(unity_ObjectToWorld)[1];
    u_xlat1 = transpose(unity_ObjectToWorld)[0] * i.in_POSITION0.xxxx + u_xlat1;
    u_xlat1 = transpose(unity_ObjectToWorld)[2] * i.in_POSITION0.zzzz + u_xlat1;
    u_xlat1 = transpose(unity_ObjectToWorld)[3] * i.in_POSITION0.wwww + u_xlat1;
    u_xlat2.xyz = (-u_xlat1.xyz) * _WorldSpaceLightPos0.www + _WorldSpaceLightPos0.xyz;
    u_xlat9 = dot(u_xlat2.xyz, u_xlat2.xyz);
    u_xlat9 = rsqrt(u_xlat9);
    u_xlat2.xyz = ((float3)(u_xlat9)) * u_xlat2.xyz;
    u_xlat9 = dot(u_xlat0.xyz, u_xlat2.xyz);
    u_xlat9 = (-u_xlat9) * u_xlat9 + 1.0;
    u_xlat9 = sqrt(u_xlat9);
    u_xlat9 = u_xlat9 * unity_LightShadowBias.z;
    u_xlat0.xyz = (-u_xlat0.xyz) * ((float3)(u_xlat9)) + u_xlat1.xyz;
    u_xlatb9 = unity_LightShadowBias.z!=0.0;
    u_xlat0.xyz = (bool(u_xlatb9)) ? u_xlat0.xyz : u_xlat1.xyz;
    u_xlat2 = u_xlat0.yyyy * transpose(unity_MatrixVP)[1];
    u_xlat2 = transpose(unity_MatrixVP)[0] * u_xlat0.xxxx + u_xlat2;
    u_xlat0 = transpose(unity_MatrixVP)[2] * u_xlat0.zzzz + u_xlat2;
    u_xlat0 = transpose(unity_MatrixVP)[3] * u_xlat1.wwww + u_xlat0;
    u_xlat1.x = LF_ShadowBiasDelta(unity_LightShadowBias.x / u_xlat0.w);
    u_xlat6 = u_xlat0.z + u_xlat1.x;
    u_xlat1.x = LF_ShadowNearClamp(u_xlat6,u_xlat0.w);
    o.vertex.xyw = u_xlat0.xyw;
    u_xlat0.x = (-u_xlat6) + u_xlat1.x;
    o.vertex.z = unity_LightShadowBias.y * u_xlat0.x + u_xlat6;
    return o;

}
float4 frag(V i):SV_Target{float4 result=0;
float2 u_xlat0;
bool u_xlatb0;
float u_xlat16_1;
float u_xlat16_3;

    u_xlat0.xy = i.vs_TEXCOORD1.xy + float2(-0.5, -0.5);
    u_xlat0.x = dot(u_xlat0.xy, u_xlat0.xy);
    u_xlat0.x = (-u_xlat0.x) * 4.0 + 1.0;
    u_xlat0.x = max(u_xlat0.x, 0.0);
    u_xlat16_1 = u_xlat0.x * u_xlat0.x;
    u_xlat16_1 = u_xlat16_1 * u_xlat16_1;
    u_xlat16_3 = (-_GlowMin) + _GlowMax;
    u_xlat16_3 = u_xlat16_1 * u_xlat16_3 + _GlowMin;
    u_xlat16_1 = u_xlat16_1 * 30.0;
    u_xlat16_1 = min(u_xlat16_1, 1.0);
    u_xlat16_3 = max(u_xlat16_3, 0.0);
    u_xlat16_3 = min(u_xlat16_3, _MaxValue);
    u_xlat16_1 = u_xlat16_1 * u_xlat16_3;
    u_xlat16_1 = u_xlat16_1 * i.vs_COLOR0.w;
    u_xlat16_1 = min(u_xlat16_1, 1.0);
    u_xlat16_1 = u_xlat16_1 + -0.00999999978;
    u_xlatb0 = u_xlat16_1<0.0;
    if(u_xlatb0){discard;}
    result = float4(0.0, 0.0, 0.0, 0.0);
    return result;

}

#elif !defined(SHADOWS_CUBE) && defined(SHADOWS_DEPTH) && !defined(_CFXR_DITHERED_SHADOWS_ON) && !defined(_CFXR_GLOW_POW_P4) && !defined(_CFXR_GLOW_POW_P8) && defined(_FADING_ON)
// Original shadow GLES program 22
float _GlowMin;
float _GlowMax;
float _MaxValue;
struct A{float4 in_POSITION0:POSITION0;float4 in_COLOR0:COLOR0;float4 in_TEXCOORD0:TEXCOORD0;float4 in_TEXCOORD1:TEXCOORD1;float3 in_NORMAL0:NORMAL0;};
struct V{float4 vertex:SV_POSITION;float4 vs_COLOR0:TEXCOORD0;float4 vs_TEXCOORD1:TEXCOORD1;};
V vert(A i){V o=(V)0;
float4 vs_TEXCOORD2;
float4 u_xlat0;
float4 u_xlat1;
float4 u_xlat2;
float u_xlat6;
float u_xlat9;
bool u_xlatb9;

    o.vs_COLOR0 = i.in_COLOR0;
    o.vs_TEXCOORD1 = i.in_TEXCOORD0.xyxy;
    vs_TEXCOORD2 = i.in_TEXCOORD1;
    u_xlat0.x = dot(i.in_NORMAL0.xyz, transpose(unity_WorldToObject)[0].xyz);
    u_xlat0.y = dot(i.in_NORMAL0.xyz, transpose(unity_WorldToObject)[1].xyz);
    u_xlat0.z = dot(i.in_NORMAL0.xyz, transpose(unity_WorldToObject)[2].xyz);
    u_xlat9 = dot(u_xlat0.xyz, u_xlat0.xyz);
    u_xlat9 = rsqrt(u_xlat9);
    u_xlat0.xyz = ((float3)(u_xlat9)) * u_xlat0.xyz;
    u_xlat1 = i.in_POSITION0.yyyy * transpose(unity_ObjectToWorld)[1];
    u_xlat1 = transpose(unity_ObjectToWorld)[0] * i.in_POSITION0.xxxx + u_xlat1;
    u_xlat1 = transpose(unity_ObjectToWorld)[2] * i.in_POSITION0.zzzz + u_xlat1;
    u_xlat1 = transpose(unity_ObjectToWorld)[3] * i.in_POSITION0.wwww + u_xlat1;
    u_xlat2.xyz = (-u_xlat1.xyz) * _WorldSpaceLightPos0.www + _WorldSpaceLightPos0.xyz;
    u_xlat9 = dot(u_xlat2.xyz, u_xlat2.xyz);
    u_xlat9 = rsqrt(u_xlat9);
    u_xlat2.xyz = ((float3)(u_xlat9)) * u_xlat2.xyz;
    u_xlat9 = dot(u_xlat0.xyz, u_xlat2.xyz);
    u_xlat9 = (-u_xlat9) * u_xlat9 + 1.0;
    u_xlat9 = sqrt(u_xlat9);
    u_xlat9 = u_xlat9 * unity_LightShadowBias.z;
    u_xlat0.xyz = (-u_xlat0.xyz) * ((float3)(u_xlat9)) + u_xlat1.xyz;
    u_xlatb9 = unity_LightShadowBias.z!=0.0;
    u_xlat0.xyz = (bool(u_xlatb9)) ? u_xlat0.xyz : u_xlat1.xyz;
    u_xlat2 = u_xlat0.yyyy * transpose(unity_MatrixVP)[1];
    u_xlat2 = transpose(unity_MatrixVP)[0] * u_xlat0.xxxx + u_xlat2;
    u_xlat0 = transpose(unity_MatrixVP)[2] * u_xlat0.zzzz + u_xlat2;
    u_xlat0 = transpose(unity_MatrixVP)[3] * u_xlat1.wwww + u_xlat0;
    u_xlat1.x = LF_ShadowBiasDelta(unity_LightShadowBias.x / u_xlat0.w);
    u_xlat6 = u_xlat0.z + u_xlat1.x;
    u_xlat1.x = LF_ShadowNearClamp(u_xlat6,u_xlat0.w);
    o.vertex.xyw = u_xlat0.xyw;
    u_xlat0.x = (-u_xlat6) + u_xlat1.x;
    o.vertex.z = unity_LightShadowBias.y * u_xlat0.x + u_xlat6;
    return o;

}
float4 frag(V i):SV_Target{float4 result=0;
float2 u_xlat0;
bool u_xlatb0;
float u_xlat16_1;
float u_xlat16_3;

    u_xlat0.xy = i.vs_TEXCOORD1.xy + float2(-0.5, -0.5);
    u_xlat0.x = dot(u_xlat0.xy, u_xlat0.xy);
    u_xlat0.x = (-u_xlat0.x) * 4.0 + 1.0;
    u_xlat0.x = max(u_xlat0.x, 0.0);
    u_xlat16_1 = (-_GlowMin) + _GlowMax;
    u_xlat16_1 = u_xlat0.x * u_xlat16_1 + _GlowMin;
    u_xlat16_3 = u_xlat0.x * 30.0;
    u_xlat16_3 = min(u_xlat16_3, 1.0);
    u_xlat16_1 = max(u_xlat16_1, 0.0);
    u_xlat16_1 = min(u_xlat16_1, _MaxValue);
    u_xlat16_1 = u_xlat16_3 * u_xlat16_1;
    u_xlat16_1 = u_xlat16_1 * i.vs_COLOR0.w;
    u_xlat16_1 = min(u_xlat16_1, 1.0);
    u_xlat16_1 = u_xlat16_1 + -0.00999999978;
    u_xlatb0 = u_xlat16_1<0.0;
    if(u_xlatb0){discard;}
    result = float4(0.0, 0.0, 0.0, 0.0);
    return result;

}

#elif !defined(SHADOWS_CUBE) && defined(SHADOWS_DEPTH) && !defined(_CFXR_DITHERED_SHADOWS_ON) && !defined(_CFXR_GLOW_POW_P4) && !defined(_CFXR_GLOW_POW_P8) && !defined(_FADING_ON)
// Original shadow GLES program 14
float _GlowMin;
float _GlowMax;
float _MaxValue;
struct A{float4 in_POSITION0:POSITION0;float4 in_COLOR0:COLOR0;float4 in_TEXCOORD0:TEXCOORD0;float4 in_TEXCOORD1:TEXCOORD1;float3 in_NORMAL0:NORMAL0;};
struct V{float4 vertex:SV_POSITION;float4 vs_COLOR0:TEXCOORD0;float4 vs_TEXCOORD1:TEXCOORD1;};
V vert(A i){V o=(V)0;
float4 vs_TEXCOORD2;
float4 u_xlat0;
float4 u_xlat1;
float4 u_xlat2;
float u_xlat6;
float u_xlat9;
bool u_xlatb9;

    o.vs_COLOR0 = i.in_COLOR0;
    o.vs_TEXCOORD1 = i.in_TEXCOORD0.xyxy;
    vs_TEXCOORD2 = i.in_TEXCOORD1;
    u_xlat0.x = dot(i.in_NORMAL0.xyz, transpose(unity_WorldToObject)[0].xyz);
    u_xlat0.y = dot(i.in_NORMAL0.xyz, transpose(unity_WorldToObject)[1].xyz);
    u_xlat0.z = dot(i.in_NORMAL0.xyz, transpose(unity_WorldToObject)[2].xyz);
    u_xlat9 = dot(u_xlat0.xyz, u_xlat0.xyz);
    u_xlat9 = rsqrt(u_xlat9);
    u_xlat0.xyz = ((float3)(u_xlat9)) * u_xlat0.xyz;
    u_xlat1 = i.in_POSITION0.yyyy * transpose(unity_ObjectToWorld)[1];
    u_xlat1 = transpose(unity_ObjectToWorld)[0] * i.in_POSITION0.xxxx + u_xlat1;
    u_xlat1 = transpose(unity_ObjectToWorld)[2] * i.in_POSITION0.zzzz + u_xlat1;
    u_xlat1 = transpose(unity_ObjectToWorld)[3] * i.in_POSITION0.wwww + u_xlat1;
    u_xlat2.xyz = (-u_xlat1.xyz) * _WorldSpaceLightPos0.www + _WorldSpaceLightPos0.xyz;
    u_xlat9 = dot(u_xlat2.xyz, u_xlat2.xyz);
    u_xlat9 = rsqrt(u_xlat9);
    u_xlat2.xyz = ((float3)(u_xlat9)) * u_xlat2.xyz;
    u_xlat9 = dot(u_xlat0.xyz, u_xlat2.xyz);
    u_xlat9 = (-u_xlat9) * u_xlat9 + 1.0;
    u_xlat9 = sqrt(u_xlat9);
    u_xlat9 = u_xlat9 * unity_LightShadowBias.z;
    u_xlat0.xyz = (-u_xlat0.xyz) * ((float3)(u_xlat9)) + u_xlat1.xyz;
    u_xlatb9 = unity_LightShadowBias.z!=0.0;
    u_xlat0.xyz = (bool(u_xlatb9)) ? u_xlat0.xyz : u_xlat1.xyz;
    u_xlat2 = u_xlat0.yyyy * transpose(unity_MatrixVP)[1];
    u_xlat2 = transpose(unity_MatrixVP)[0] * u_xlat0.xxxx + u_xlat2;
    u_xlat0 = transpose(unity_MatrixVP)[2] * u_xlat0.zzzz + u_xlat2;
    u_xlat0 = transpose(unity_MatrixVP)[3] * u_xlat1.wwww + u_xlat0;
    u_xlat1.x = LF_ShadowBiasDelta(unity_LightShadowBias.x / u_xlat0.w);
    u_xlat6 = u_xlat0.z + u_xlat1.x;
    u_xlat1.x = LF_ShadowNearClamp(u_xlat6,u_xlat0.w);
    o.vertex.xyw = u_xlat0.xyw;
    u_xlat0.x = (-u_xlat6) + u_xlat1.x;
    o.vertex.z = unity_LightShadowBias.y * u_xlat0.x + u_xlat6;
    return o;

}
float4 frag(V i):SV_Target{float4 result=0;
float2 u_xlat0;
bool u_xlatb0;
float u_xlat16_1;
float u_xlat16_3;

    u_xlat0.xy = i.vs_TEXCOORD1.xy + float2(-0.5, -0.5);
    u_xlat0.x = dot(u_xlat0.xy, u_xlat0.xy);
    u_xlat0.x = (-u_xlat0.x) * 4.0 + 1.0;
    u_xlat0.x = max(u_xlat0.x, 0.0);
    u_xlat16_1 = (-_GlowMin) + _GlowMax;
    u_xlat16_1 = u_xlat0.x * u_xlat16_1 + _GlowMin;
    u_xlat16_3 = u_xlat0.x * 30.0;
    u_xlat16_3 = min(u_xlat16_3, 1.0);
    u_xlat16_1 = max(u_xlat16_1, 0.0);
    u_xlat16_1 = min(u_xlat16_1, _MaxValue);
    u_xlat16_1 = u_xlat16_3 * u_xlat16_1;
    u_xlat16_1 = u_xlat16_1 * i.vs_COLOR0.w;
    u_xlat16_1 = min(u_xlat16_1, 1.0);
    u_xlat16_1 = u_xlat16_1 + -0.00999999978;
    u_xlatb0 = u_xlat16_1<0.0;
    if(u_xlatb0){discard;}
    result = float4(0.0, 0.0, 0.0, 0.0);
    return result;

}

#elif defined(SHADOWS_CUBE) && !defined(SHADOWS_DEPTH) && !defined(_CFXR_DITHERED_SHADOWS_ON) && !defined(_CFXR_GLOW_POW_P4) && !defined(_CFXR_GLOW_POW_P8) && !defined(_FADING_ON)
// Original shadow GLES program 20
float _GlowMin;
float _GlowMax;
float _MaxValue;
struct A{float4 in_POSITION0:POSITION0;float4 in_COLOR0:COLOR0;float4 in_TEXCOORD0:TEXCOORD0;float4 in_TEXCOORD1:TEXCOORD1;float3 in_NORMAL0:NORMAL0;};
struct V{float4 vertex:SV_POSITION;float4 vs_COLOR0:TEXCOORD0;float4 vs_TEXCOORD1:TEXCOORD1;};
V vert(A i){V o=(V)0;
float4 vs_TEXCOORD2;
float4 u_xlat0;
float4 u_xlat1;
float4 u_xlat2;
float u_xlat9;
bool u_xlatb9;

    o.vs_COLOR0 = i.in_COLOR0;
    o.vs_TEXCOORD1 = i.in_TEXCOORD0.xyxy;
    vs_TEXCOORD2 = i.in_TEXCOORD1;
    u_xlat0.x = dot(i.in_NORMAL0.xyz, transpose(unity_WorldToObject)[0].xyz);
    u_xlat0.y = dot(i.in_NORMAL0.xyz, transpose(unity_WorldToObject)[1].xyz);
    u_xlat0.z = dot(i.in_NORMAL0.xyz, transpose(unity_WorldToObject)[2].xyz);
    u_xlat9 = dot(u_xlat0.xyz, u_xlat0.xyz);
    u_xlat9 = rsqrt(u_xlat9);
    u_xlat0.xyz = ((float3)(u_xlat9)) * u_xlat0.xyz;
    u_xlat1 = i.in_POSITION0.yyyy * transpose(unity_ObjectToWorld)[1];
    u_xlat1 = transpose(unity_ObjectToWorld)[0] * i.in_POSITION0.xxxx + u_xlat1;
    u_xlat1 = transpose(unity_ObjectToWorld)[2] * i.in_POSITION0.zzzz + u_xlat1;
    u_xlat1 = transpose(unity_ObjectToWorld)[3] * i.in_POSITION0.wwww + u_xlat1;
    u_xlat2.xyz = (-u_xlat1.xyz) * _WorldSpaceLightPos0.www + _WorldSpaceLightPos0.xyz;
    u_xlat9 = dot(u_xlat2.xyz, u_xlat2.xyz);
    u_xlat9 = rsqrt(u_xlat9);
    u_xlat2.xyz = ((float3)(u_xlat9)) * u_xlat2.xyz;
    u_xlat9 = dot(u_xlat0.xyz, u_xlat2.xyz);
    u_xlat9 = (-u_xlat9) * u_xlat9 + 1.0;
    u_xlat9 = sqrt(u_xlat9);
    u_xlat9 = u_xlat9 * unity_LightShadowBias.z;
    u_xlat0.xyz = (-u_xlat0.xyz) * ((float3)(u_xlat9)) + u_xlat1.xyz;
    u_xlatb9 = unity_LightShadowBias.z!=0.0;
    u_xlat0.xyz = (bool(u_xlatb9)) ? u_xlat0.xyz : u_xlat1.xyz;
    u_xlat2 = u_xlat0.yyyy * transpose(unity_MatrixVP)[1];
    u_xlat2 = transpose(unity_MatrixVP)[0] * u_xlat0.xxxx + u_xlat2;
    u_xlat0 = transpose(unity_MatrixVP)[2] * u_xlat0.zzzz + u_xlat2;
    u_xlat0 = transpose(unity_MatrixVP)[3] * u_xlat1.wwww + u_xlat0;
    u_xlat1.x = LF_ShadowNearClamp(u_xlat0.z,u_xlat0.w);
    u_xlat1.x = (-u_xlat0.z) + u_xlat1.x;
    o.vertex.z = unity_LightShadowBias.y * u_xlat1.x + u_xlat0.z;
    o.vertex.xyw = u_xlat0.xyw;
    return o;

}
float4 frag(V i):SV_Target{float4 result=0;
float2 u_xlat0;
bool u_xlatb0;
float u_xlat16_1;
float u_xlat16_3;

    u_xlat0.xy = i.vs_TEXCOORD1.xy + float2(-0.5, -0.5);
    u_xlat0.x = dot(u_xlat0.xy, u_xlat0.xy);
    u_xlat0.x = (-u_xlat0.x) * 4.0 + 1.0;
    u_xlat0.x = max(u_xlat0.x, 0.0);
    u_xlat16_1 = (-_GlowMin) + _GlowMax;
    u_xlat16_1 = u_xlat0.x * u_xlat16_1 + _GlowMin;
    u_xlat16_3 = u_xlat0.x * 30.0;
    u_xlat16_3 = min(u_xlat16_3, 1.0);
    u_xlat16_1 = max(u_xlat16_1, 0.0);
    u_xlat16_1 = min(u_xlat16_1, _MaxValue);
    u_xlat16_1 = u_xlat16_3 * u_xlat16_1;
    u_xlat16_1 = u_xlat16_1 * i.vs_COLOR0.w;
    u_xlat16_1 = min(u_xlat16_1, 1.0);
    u_xlat16_1 = u_xlat16_1 + -0.00999999978;
    u_xlatb0 = u_xlat16_1<0.0;
    if(u_xlatb0){discard;}
    result = float4(0.0, 0.0, 0.0, 0.0);
    return result;

}

#else
float _GlowMin;
float _GlowMax;
float _MaxValue;
struct A{float4 in_POSITION0:POSITION0;float4 in_COLOR0:COLOR0;float4 in_TEXCOORD0:TEXCOORD0;float4 in_TEXCOORD1:TEXCOORD1;float3 in_NORMAL0:NORMAL0;};
struct V{float4 vertex:SV_POSITION;float4 vs_COLOR0:TEXCOORD0;float4 vs_TEXCOORD1:TEXCOORD1;};
V vert(A i){V o=(V)0;
float4 vs_TEXCOORD2;
float4 u_xlat0;
float4 u_xlat1;
float4 u_xlat2;
float u_xlat6;
float u_xlat9;
bool u_xlatb9;

    o.vs_COLOR0 = i.in_COLOR0;
    o.vs_TEXCOORD1 = i.in_TEXCOORD0.xyxy;
    vs_TEXCOORD2 = i.in_TEXCOORD1;
    u_xlat0.x = dot(i.in_NORMAL0.xyz, transpose(unity_WorldToObject)[0].xyz);
    u_xlat0.y = dot(i.in_NORMAL0.xyz, transpose(unity_WorldToObject)[1].xyz);
    u_xlat0.z = dot(i.in_NORMAL0.xyz, transpose(unity_WorldToObject)[2].xyz);
    u_xlat9 = dot(u_xlat0.xyz, u_xlat0.xyz);
    u_xlat9 = rsqrt(u_xlat9);
    u_xlat0.xyz = ((float3)(u_xlat9)) * u_xlat0.xyz;
    u_xlat1 = i.in_POSITION0.yyyy * transpose(unity_ObjectToWorld)[1];
    u_xlat1 = transpose(unity_ObjectToWorld)[0] * i.in_POSITION0.xxxx + u_xlat1;
    u_xlat1 = transpose(unity_ObjectToWorld)[2] * i.in_POSITION0.zzzz + u_xlat1;
    u_xlat1 = transpose(unity_ObjectToWorld)[3] * i.in_POSITION0.wwww + u_xlat1;
    u_xlat2.xyz = (-u_xlat1.xyz) * _WorldSpaceLightPos0.www + _WorldSpaceLightPos0.xyz;
    u_xlat9 = dot(u_xlat2.xyz, u_xlat2.xyz);
    u_xlat9 = rsqrt(u_xlat9);
    u_xlat2.xyz = ((float3)(u_xlat9)) * u_xlat2.xyz;
    u_xlat9 = dot(u_xlat0.xyz, u_xlat2.xyz);
    u_xlat9 = (-u_xlat9) * u_xlat9 + 1.0;
    u_xlat9 = sqrt(u_xlat9);
    u_xlat9 = u_xlat9 * unity_LightShadowBias.z;
    u_xlat0.xyz = (-u_xlat0.xyz) * ((float3)(u_xlat9)) + u_xlat1.xyz;
    u_xlatb9 = unity_LightShadowBias.z!=0.0;
    u_xlat0.xyz = (bool(u_xlatb9)) ? u_xlat0.xyz : u_xlat1.xyz;
    u_xlat2 = u_xlat0.yyyy * transpose(unity_MatrixVP)[1];
    u_xlat2 = transpose(unity_MatrixVP)[0] * u_xlat0.xxxx + u_xlat2;
    u_xlat0 = transpose(unity_MatrixVP)[2] * u_xlat0.zzzz + u_xlat2;
    u_xlat0 = transpose(unity_MatrixVP)[3] * u_xlat1.wwww + u_xlat0;
    u_xlat1.x = LF_ShadowBiasDelta(unity_LightShadowBias.x / u_xlat0.w);
    u_xlat6 = u_xlat0.z + u_xlat1.x;
    u_xlat1.x = LF_ShadowNearClamp(u_xlat6,u_xlat0.w);
    o.vertex.xyw = u_xlat0.xyw;
    u_xlat0.x = (-u_xlat6) + u_xlat1.x;
    o.vertex.z = unity_LightShadowBias.y * u_xlat0.x + u_xlat6;
    return o;

}
float4 frag(V i):SV_Target{float4 result=0;
float2 u_xlat0;
bool u_xlatb0;
float u_xlat16_1;
float u_xlat16_3;

    u_xlat0.xy = i.vs_TEXCOORD1.xy + float2(-0.5, -0.5);
    u_xlat0.x = dot(u_xlat0.xy, u_xlat0.xy);
    u_xlat0.x = (-u_xlat0.x) * 4.0 + 1.0;
    u_xlat0.x = max(u_xlat0.x, 0.0);
    u_xlat16_1 = (-_GlowMin) + _GlowMax;
    u_xlat16_1 = u_xlat0.x * u_xlat16_1 + _GlowMin;
    u_xlat16_3 = u_xlat0.x * 30.0;
    u_xlat16_3 = min(u_xlat16_3, 1.0);
    u_xlat16_1 = max(u_xlat16_1, 0.0);
    u_xlat16_1 = min(u_xlat16_1, _MaxValue);
    u_xlat16_1 = u_xlat16_3 * u_xlat16_1;
    u_xlat16_1 = u_xlat16_1 * i.vs_COLOR0.w;
    u_xlat16_1 = min(u_xlat16_1, 1.0);
    u_xlat16_1 = u_xlat16_1 + -0.00999999978;
    u_xlatb0 = u_xlat16_1<0.0;
    if(u_xlatb0){discard;}
    result = float4(0.0, 0.0, 0.0, 0.0);
    return result;

}

#endif
ENDCG
}
}}
