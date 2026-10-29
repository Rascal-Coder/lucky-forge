// Upgrade NOTE: replaced 'glstate_matrix_projection' with 'UNITY_MATRIX_P'

// Direct stage-body port of shipped GLES variants; preserved material-driven render states.
Shader "Cartoon FX/Remaster/Particle Procedural Ring"{
Properties {

[Enum(UnityEngine.Rendering.BlendMode)] _SrcBlend ("Blend Source", Float) = 5.0

[Enum(UnityEngine.Rendering.BlendMode)] _DstBlend ("Blend Destination", Float) = 10.0

[Toggle(_CFXR_DISSOLVE)] _UseDissolve ("Enable Dissolve", Float) = 0.0

_DissolveTex ("Dissolve Texture", 2D) = "gray" { }

_DissolveSmooth ("Dissolve Smoothing", Range(0.0001, 0.5)) = 0.10000000149011612

[ToggleNoKeyword] _InvertDissolveTex ("Invert Dissolve Texture", Float) = 0.0

_MainTex ("Texture", 2D) = "white" { }

[Toggle] _SingleChannel ("Single Channel Texture", Float) = 0.0

[Toggle(_CFXR_RADIAL_UV)] _UseRadialUV ("Enable Radial UVs", Float) = 0.0

_RingTopOffset ("Ring Offset", Float) = 0.05000000074505806

[Toggle(_CFXR_WORLD_SPACE_RING)] _WorldSpaceRing ("World Space", Float) = 0.0

_HdrMultiply ("HDR Multiplier", Float) = 2.0

[Toggle(_FADING_ON)] _UseSP ("Soft Particles", Float) = 0.0

_SoftParticlesFadeDistanceNear ("Near Fade", Float) = 0.0

_SoftParticlesFadeDistanceFar ("Far Fade", Float) = 1.0

[KeywordEnum(Off,On,CustomTexture)] _CFXR_DITHERED_SHADOWS ("Dithered Shadows", Float) = 0.0

_ShadowStrength ("Shadows Strength Max", Range(0, 1)) = 1.0

_DitherCustom ("Dithering 3D Texture", 3D) = "black" { }

}

SubShader{Tags{"IGNOREPROJECTOR"="true" "QUEUE"="Transparent" "RenderType"="Transparent"}
Blend [_SrcBlend] [_DstBlend], [_SrcBlend] [_DstBlend]
ZWrite Off
Cull Off
ZTest LEqual
Pass{Name "BASE" Tags{"LightMode"="ForwardBase"}
CGPROGRAM
#pragma target 3.0
#pragma vertex vert
#pragma fragment frag
#pragma multi_compile_particles
#pragma shader_feature_local _ _CFXR_DISSOLVE
#pragma shader_feature_local _ _CFXR_RADIAL_UV
#pragma shader_feature_local _ _CFXR_WORLD_SPACE_RING
#pragma shader_feature_local _ _FADING_ON
#include "UnityCG.cginc"
#include "Lighting.cginc"
#define lessThan(a,b) ((a)<(b))
#define greaterThan(a,b) ((a)>(b))
#define lessThanEqual(a,b) ((a)<=(b))
#define greaterThanEqual(a,b) ((a)>=(b))
#define equal(a,b) ((a)==(b))
#define notEqual(a,b) ((a)!=(b))
#if defined(SOFTPARTICLES_ON) && defined(_CFXR_DISSOLVE) && !defined(_CFXR_RADIAL_UV) && defined(_CFXR_WORLD_SPACE_RING) && !defined(_FADING_ON)
// Original GLES program 13; SOFTPARTICLES_ON,_CFXR_WORLD_SPACE_RING,_CFXR_DISSOLVE
float4 _MainTex_ST;
float _RingTopOffset;
float _SingleChannel;
float _InvertDissolveTex;
float _DissolveSmooth;
float _HdrMultiply;
sampler2D _MainTex;
sampler2D _DissolveTex;
struct A{float4 in_POSITION0:POSITION0;float4 in_COLOR0:COLOR0;float4 in_TEXCOORD0:TEXCOORD0;float4 in_TEXCOORD1:TEXCOORD1;float4 in_TEXCOORD2:TEXCOORD2;float3 in_NORMAL0:NORMAL0;};
struct V{float4 vertex:SV_POSITION;float4 vs_COLOR0:TEXCOORD0;float4 vs_TEXCOORD1:TEXCOORD1;float4 vs_TEXCOORD2:TEXCOORD2;float4 vs_TEXCOORD5:TEXCOORD3;};
V vert(A i){V o=(V)0;
float4 vs_TEXCOORD0;
float3 u_xlat0;
float4 u_xlat1;
float4 u_xlat2;
float u_xlat9;

    u_xlat0.xyz = i.in_TEXCOORD0.yyy * i.in_NORMAL0.xyz;
    u_xlat9 = min(i.in_TEXCOORD2.x, i.in_TEXCOORD2.w);
    u_xlat0.xyz = (-u_xlat0.xyz) * ((float3)(u_xlat9)) + i.in_POSITION0.xyz;
    u_xlat1 = u_xlat0.yyyy * transpose(unity_ObjectToWorld)[1];
    u_xlat1 = transpose(unity_ObjectToWorld)[0] * u_xlat0.xxxx + u_xlat1;
    u_xlat1 = transpose(unity_ObjectToWorld)[2] * u_xlat0.zzzz + u_xlat1;
    u_xlat1 = u_xlat1 + transpose(unity_ObjectToWorld)[3];
    u_xlat2 = u_xlat1.yyyy * transpose(unity_MatrixVP)[1];
    u_xlat2 = transpose(unity_MatrixVP)[0] * u_xlat1.xxxx + u_xlat2;
    u_xlat2 = transpose(unity_MatrixVP)[2] * u_xlat1.zzzz + u_xlat2;
    o.vertex = transpose(unity_MatrixVP)[3] * u_xlat1.wwww + u_xlat2;
    o.vs_COLOR0 = i.in_COLOR0;
    vs_TEXCOORD0 = i.in_TEXCOORD0;
    u_xlat0.x = u_xlat9 / i.in_TEXCOORD2.w;
    u_xlat0.x = (-u_xlat0.x) + 1.0;
    o.vs_TEXCOORD1.x = u_xlat0.x * u_xlat0.x;
    o.vs_TEXCOORD1.z = i.in_TEXCOORD2.y / i.in_TEXCOORD2.w;
    o.vs_TEXCOORD1.y = (-_RingTopOffset) + 1.0;
    o.vs_TEXCOORD1.w = i.in_TEXCOORD2.z;
    u_xlat0.xy = i.in_TEXCOORD0.yy * i.in_TEXCOORD0.zw;
    u_xlat0.xy = ((float2)(u_xlat9)) * u_xlat0.xy;
    u_xlat0.xy = u_xlat0.xy / i.in_TEXCOORD2.ww;
    o.vs_TEXCOORD2.zw = (-u_xlat0.xy) + i.in_TEXCOORD0.zw;
    u_xlat0.x = i.in_TEXCOORD2.z;
    u_xlat0.y = 0.0;
    u_xlat0.xy = u_xlat0.xy + i.in_TEXCOORD0.xy;
    u_xlat0.xy = u_xlat0.xy * _MainTex_ST.xy + _MainTex_ST.zw;
    o.vs_TEXCOORD2.xy = (-u_xlat0.xy) + float2(1.0, 1.0);
    o.vs_TEXCOORD5 = i.in_TEXCOORD1;
    return o;

}
float4 frag(V i):SV_Target{float4 result=0;
float4 u_xlat0;
float4 u_xlat16_0;
float u_xlat1;
float4 u_xlat16_1;
bool u_xlatb1;
float4 u_xlat16_2;
float u_xlat3;
bool u_xlatb3;
float u_xlat16_4;
float u_xlat16_5;
float u_xlat6;
float u_xlat16_8;

    u_xlat0.x = (-i.vs_TEXCOORD1.z) + i.vs_TEXCOORD1.y;
    u_xlat3 = (-u_xlat0.x) + i.vs_TEXCOORD1.y;
    u_xlat3 = float(1.0) / u_xlat3;
    u_xlat6 = dot(i.vs_TEXCOORD2.zw, i.vs_TEXCOORD2.zw);
    u_xlat0.x = (-u_xlat0.x) + u_xlat6;
    u_xlat6 = u_xlat6 + (-i.vs_TEXCOORD1.x);
    u_xlat0.x = u_xlat3 * u_xlat0.x;
    u_xlat0.x = clamp(u_xlat0.x, 0.0, 1.0);
    u_xlat3 = u_xlat0.x * -2.0 + 3.0;
    u_xlat0.x = u_xlat0.x * u_xlat0.x;
    u_xlat0.x = u_xlat0.x * u_xlat3;
    u_xlat3 = float(1.0) / i.vs_TEXCOORD1.z;
    u_xlat3 = u_xlat3 * u_xlat6;
    u_xlat3 = clamp(u_xlat3, 0.0, 1.0);
    u_xlat6 = u_xlat3 * -2.0 + 3.0;
    u_xlat3 = u_xlat3 * u_xlat3;
    u_xlat0.x = u_xlat6 * u_xlat3 + (-u_xlat0.x);
    u_xlat0.x = clamp(u_xlat0.x, 0.0, 1.0);
    u_xlat16_1 = tex2D(_MainTex, i.vs_TEXCOORD2.xy);
    u_xlatb3 = 0.0<_SingleChannel;
    u_xlat16_2.xyz = (bool(u_xlatb3)) ? float3(1.0, 1.0, 1.0) : u_xlat16_1.xyz;
    u_xlat16_2.w = (u_xlatb3) ? u_xlat16_1.x : u_xlat16_1.w;
    u_xlat0 = u_xlat0.xxxx * u_xlat16_2;
    u_xlat16_0 = u_xlat0 * i.vs_COLOR0;
    u_xlat1 = log2(_HdrMultiply);
    u_xlat1 = u_xlat1 * 0.416666657;
    u_xlat1 = exp2(u_xlat1);
    u_xlat1 = u_xlat1 * 1.05499995 + -0.0549999997;
    u_xlat1 = max(u_xlat1, 0.0);
    u_xlat16_2.xyz = u_xlat16_0.xyz * ((float3)(u_xlat1));
    u_xlatb1 = 0.0<_HdrMultiply;
    result.xyz = (bool(u_xlatb1)) ? u_xlat16_2.xyz : u_xlat16_0.xyz;
    u_xlatb1 = 0.0>=_InvertDissolveTex;
    u_xlat16_4 = tex2D(_DissolveTex, i.vs_TEXCOORD2.xy).x;
    u_xlat16_2.x = (-u_xlat16_4) + 1.0;
    u_xlat16_2.x = (u_xlatb1) ? u_xlat16_2.x : u_xlat16_4;
    u_xlat16_5 = u_xlat16_2.x + _DissolveSmooth;
    u_xlat16_2.x = u_xlat16_2.x + (-_DissolveSmooth);
    u_xlat16_5 = (-u_xlat16_2.x) + u_xlat16_5;
    u_xlat16_5 = float(1.0) / u_xlat16_5;
    u_xlat16_8 = _DissolveSmooth * 2.0 + 1.0;
    u_xlat16_8 = i.vs_TEXCOORD5.x * u_xlat16_8 + (-_DissolveSmooth);
    u_xlat16_2.x = (-u_xlat16_2.x) + u_xlat16_8;
    u_xlat16_2.x = u_xlat16_5 * u_xlat16_2.x;
    u_xlat16_2.x = clamp(u_xlat16_2.x, 0.0, 1.0);
    u_xlat16_5 = u_xlat16_2.x * -2.0 + 3.0;
    u_xlat16_2.x = u_xlat16_2.x * u_xlat16_2.x;
    u_xlat16_2.x = u_xlat16_2.x * u_xlat16_5;
    u_xlat16_2.x = u_xlat16_0.w * u_xlat16_2.x;
    result.w = min(u_xlat16_2.x, 1.0);
    return result;

}

#elif defined(SOFTPARTICLES_ON) && !defined(_CFXR_DISSOLVE) && defined(_CFXR_RADIAL_UV) && !defined(_CFXR_WORLD_SPACE_RING) && defined(_FADING_ON)
// Original GLES program 15; SOFTPARTICLES_ON,_CFXR_RADIAL_UV,_FADING_ON
float4 _MainTex_ST;
float _RingTopOffset;
float _SingleChannel;
float _HdrMultiply;
float _SoftParticlesFadeDistanceNear;
float _SoftParticlesFadeDistanceFar;
sampler2D _MainTex;
sampler2D _CameraDepthTexture;
struct A{float4 in_POSITION0:POSITION0;float4 in_COLOR0:COLOR0;float4 in_TEXCOORD0:TEXCOORD0;float4 in_TEXCOORD2:TEXCOORD2;};
struct V{float4 vertex:SV_POSITION;float4 vs_COLOR0:TEXCOORD0;float4 vs_TEXCOORD1:TEXCOORD1;float4 vs_TEXCOORD2:TEXCOORD2;float4 vs_TEXCOORD3:TEXCOORD3;};
V vert(A i){V o=(V)0;
float4 vs_TEXCOORD0;
float4 u_xlat0;
float4 u_xlat1;
float4 u_xlat2;
float u_xlat3;
float u_xlat6;

    u_xlat0.xy = i.in_TEXCOORD0.yy * (-i.in_TEXCOORD0.zw);
    u_xlat1 = i.in_POSITION0.yyyy * transpose(unity_MatrixV)[1];
    u_xlat1 = transpose(unity_MatrixV)[0] * i.in_POSITION0.xxxx + u_xlat1;
    u_xlat1 = transpose(unity_MatrixV)[2] * i.in_POSITION0.zzzz + u_xlat1;
    u_xlat1 = transpose(unity_MatrixV)[3] * i.in_POSITION0.wwww + u_xlat1;
    u_xlat6 = min(i.in_TEXCOORD2.x, i.in_TEXCOORD2.w);
    u_xlat0.xy = u_xlat0.xy * ((float2)(u_xlat6)) + u_xlat1.xy;
    u_xlat2 = u_xlat0.yyyy * transpose(UNITY_MATRIX_P)[1];
    u_xlat2 = transpose(UNITY_MATRIX_P)[0] * u_xlat0.xxxx + u_xlat2;
    u_xlat2 = transpose(UNITY_MATRIX_P)[2] * u_xlat1.zzzz + u_xlat2;
    u_xlat1 = transpose(UNITY_MATRIX_P)[3] * u_xlat1.wwww + u_xlat2;
    o.vertex = u_xlat1;
    o.vs_COLOR0 = i.in_COLOR0;
    vs_TEXCOORD0 = i.in_TEXCOORD0;
    u_xlat0.x = u_xlat6 / i.in_TEXCOORD2.w;
    u_xlat0.x = (-u_xlat0.x) + 1.0;
    o.vs_TEXCOORD1.x = u_xlat0.x * u_xlat0.x;
    o.vs_TEXCOORD1.z = i.in_TEXCOORD2.y / i.in_TEXCOORD2.w;
    o.vs_TEXCOORD1.y = (-_RingTopOffset) + 1.0;
    o.vs_TEXCOORD1.w = i.in_TEXCOORD2.z;
    u_xlat0.xy = i.in_TEXCOORD0.yy * i.in_TEXCOORD0.zw;
    u_xlat0.xy = ((float2)(u_xlat6)) * u_xlat0.xy;
    u_xlat0.xy = u_xlat0.xy / i.in_TEXCOORD2.ww;
    o.vs_TEXCOORD2.zw = (-u_xlat0.xy) + i.in_TEXCOORD0.zw;
    u_xlat0.x = i.in_TEXCOORD2.z;
    u_xlat0.y = 0.0;
    u_xlat0.xy = u_xlat0.xy + i.in_TEXCOORD0.xy;
    u_xlat0.xy = u_xlat0.xy * _MainTex_ST.xy + _MainTex_ST.zw;
    o.vs_TEXCOORD2.xy = (-u_xlat0.xy) + float2(1.0, 1.0);
    u_xlat0.x = u_xlat1.y * _ProjectionParams.x;
    u_xlat0.w = u_xlat0.x * 0.5;
    u_xlat0.xz = u_xlat1.xw * float2(0.5, 0.5);
    o.vs_TEXCOORD3.w = u_xlat1.w;
    o.vs_TEXCOORD3.xy = u_xlat0.zz + u_xlat0.xw;
    u_xlat0 = i.in_POSITION0.yyyy * transpose(unity_ObjectToWorld)[1];
    u_xlat0 = transpose(unity_ObjectToWorld)[0] * i.in_POSITION0.xxxx + u_xlat0;
    u_xlat0 = transpose(unity_ObjectToWorld)[2] * i.in_POSITION0.zzzz + u_xlat0;
    u_xlat0 = u_xlat0 + transpose(unity_ObjectToWorld)[3];
    u_xlat3 = u_xlat0.y * transpose(unity_MatrixV)[1].z;
    u_xlat0.x = transpose(unity_MatrixV)[0].z * u_xlat0.x + u_xlat3;
    u_xlat0.x = transpose(unity_MatrixV)[2].z * u_xlat0.z + u_xlat0.x;
    u_xlat0.x = transpose(unity_MatrixV)[3].z * u_xlat0.w + u_xlat0.x;
    o.vs_TEXCOORD3.z = (-u_xlat0.x);
    return o;

}
float4 frag(V i):SV_Target{float4 result=0;
float4 u_xlat0;
float4 u_xlat16_0;
bool u_xlatb0;
float2 u_xlat1;
bool u_xlatb1;
float4 u_xlat16_2;
float4 u_xlat16_3;
float u_xlat4;
bool u_xlatb4;
float u_xlat5;
float2 u_xlat8;
bool u_xlatb8;
bool u_xlatb9;
float u_xlat12;
bool u_xlatb12;

    u_xlat0.x = max(abs(i.vs_TEXCOORD2.w), abs(i.vs_TEXCOORD2.z));
    u_xlat0.x = float(1.0) / u_xlat0.x;
    u_xlat4 = min(abs(i.vs_TEXCOORD2.w), abs(i.vs_TEXCOORD2.z));
    u_xlat0.x = u_xlat0.x * u_xlat4;
    u_xlat4 = u_xlat0.x * u_xlat0.x;
    u_xlat8.x = u_xlat4 * 0.0208350997 + -0.0851330012;
    u_xlat8.x = u_xlat4 * u_xlat8.x + 0.180141002;
    u_xlat8.x = u_xlat4 * u_xlat8.x + -0.330299497;
    u_xlat4 = u_xlat4 * u_xlat8.x + 0.999866009;
    u_xlat8.x = u_xlat4 * u_xlat0.x;
    u_xlat8.x = u_xlat8.x * -2.0 + 1.57079637;
    u_xlatb12 = abs(i.vs_TEXCOORD2.w)<abs(i.vs_TEXCOORD2.z);
    u_xlat8.x = u_xlatb12 ? u_xlat8.x : float(0.0);
    u_xlat0.x = u_xlat0.x * u_xlat4 + u_xlat8.x;
    u_xlatb4 = i.vs_TEXCOORD2.w<(-i.vs_TEXCOORD2.w);
    u_xlat4 = u_xlatb4 ? -3.14159274 : float(0.0);
    u_xlat0.x = u_xlat4 + u_xlat0.x;
    u_xlat4 = min(i.vs_TEXCOORD2.w, i.vs_TEXCOORD2.z);
    u_xlatb4 = u_xlat4<(-u_xlat4);
    u_xlat8.x = max(i.vs_TEXCOORD2.w, i.vs_TEXCOORD2.z);
    u_xlatb8 = u_xlat8.x>=(-u_xlat8.x);
    u_xlatb4 = u_xlatb8 && u_xlatb4;
    u_xlat0.x = (u_xlatb4) ? (-u_xlat0.x) : u_xlat0.x;
    u_xlat0.x = u_xlat0.x * 0.159154937 + 0.730000019;
    u_xlat0.x = u_xlat0.x + (-i.vs_TEXCOORD1.w);
    u_xlat8.xy = (-i.vs_TEXCOORD1.zx) + i.vs_TEXCOORD1.yy;
    u_xlat1.x = float(1.0) / u_xlat8.y;
    u_xlat12 = i.vs_TEXCOORD1.x / u_xlat8.y;
    u_xlat5 = dot(i.vs_TEXCOORD2.zw, i.vs_TEXCOORD2.zw);
    u_xlat12 = u_xlat5 * u_xlat1.x + (-u_xlat12);
    u_xlat0.y = u_xlat12 * 0.899999976 + 0.0799999833;
    u_xlat0.xy = u_xlat0.xy * _MainTex_ST.xy + _MainTex_ST.zw;
    u_xlat12 = ddx(i.vs_TEXCOORD2.x);
    u_xlat16_2 = tex2Dgrad(_MainTex, u_xlat0.xy, ((float4)(((float4)(u_xlat12)))).xy, ((float4)(((float4)(u_xlat12)))).xy);
    u_xlatb0 = 0.0<_SingleChannel;
    u_xlat16_3.xyz = (bool(u_xlatb0)) ? float3(1.0, 1.0, 1.0) : u_xlat16_2.xyz;
    u_xlat16_3.w = (u_xlatb0) ? u_xlat16_2.x : u_xlat16_2.w;
    u_xlat0.x = (-u_xlat8.x) + u_xlat5;
    u_xlat4 = u_xlat5 + (-i.vs_TEXCOORD1.x);
    u_xlat8.x = (-u_xlat8.x) + i.vs_TEXCOORD1.y;
    u_xlat8.x = float(1.0) / u_xlat8.x;
    u_xlat0.x = u_xlat8.x * u_xlat0.x;
    u_xlat0.x = clamp(u_xlat0.x, 0.0, 1.0);
    u_xlat8.x = u_xlat0.x * -2.0 + 3.0;
    u_xlat0.x = u_xlat0.x * u_xlat0.x;
    u_xlat0.x = u_xlat0.x * u_xlat8.x;
    u_xlat8.x = float(1.0) / i.vs_TEXCOORD1.z;
    u_xlat4 = u_xlat8.x * u_xlat4;
    u_xlat4 = clamp(u_xlat4, 0.0, 1.0);
    u_xlat8.x = u_xlat4 * -2.0 + 3.0;
    u_xlat4 = u_xlat4 * u_xlat4;
    u_xlat0.x = u_xlat8.x * u_xlat4 + (-u_xlat0.x);
    u_xlat0.x = clamp(u_xlat0.x, 0.0, 1.0);
    u_xlat0 = u_xlat0.xxxx * u_xlat16_3;
    u_xlat16_0 = u_xlat0 * i.vs_COLOR0;
    u_xlat1.x = log2(_HdrMultiply);
    u_xlat1.x = u_xlat1.x * 0.416666657;
    u_xlat1.x = exp2(u_xlat1.x);
    u_xlat1.x = u_xlat1.x * 1.05499995 + -0.0549999997;
    u_xlat1.x = max(u_xlat1.x, 0.0);
    u_xlat16_3.xyz = u_xlat16_0.xyz * u_xlat1.xxx;
    u_xlatb1 = 0.0<_HdrMultiply;
    result.xyz = (bool(u_xlatb1)) ? u_xlat16_3.xyz : u_xlat16_0.xyz;
    u_xlat1.xy = i.vs_TEXCOORD3.xy / i.vs_TEXCOORD3.ww;
    u_xlat1.x = tex2D(_CameraDepthTexture, u_xlat1.xy).x;
    u_xlat5 = _ZBufferParams.z * u_xlat1.x + _ZBufferParams.w;
    u_xlat1.x = u_xlat1.x * _ProjectionParams.z + _ProjectionParams.y;
    u_xlat5 = float(1.0) / u_xlat5;
    u_xlatb9 = unity_OrthoParams.w==1.0;
    u_xlat1.x = (u_xlatb9) ? u_xlat1.x : u_xlat5;
    u_xlat1.x = u_xlat1.x + (-_SoftParticlesFadeDistanceNear);
    u_xlat1.x = u_xlat1.x + (-i.vs_TEXCOORD3.z);
    u_xlat1.x = u_xlat1.x * _SoftParticlesFadeDistanceFar;
    u_xlat1.x = clamp(u_xlat1.x, 0.0, 1.0);
    u_xlat1.x = u_xlat16_0.w * u_xlat1.x;
    result.w = min(u_xlat1.x, 1.0);
    return result;

}

#elif !defined(SOFTPARTICLES_ON) && defined(_CFXR_DISSOLVE) && !defined(_CFXR_RADIAL_UV) && defined(_CFXR_WORLD_SPACE_RING) && !defined(_FADING_ON)
// Original GLES program 8; _CFXR_WORLD_SPACE_RING,_CFXR_DISSOLVE
float4 _MainTex_ST;
float _RingTopOffset;
float _SingleChannel;
float _InvertDissolveTex;
float _DissolveSmooth;
float _HdrMultiply;
sampler2D _MainTex;
sampler2D _DissolveTex;
struct A{float4 in_POSITION0:POSITION0;float4 in_COLOR0:COLOR0;float4 in_TEXCOORD0:TEXCOORD0;float4 in_TEXCOORD1:TEXCOORD1;float4 in_TEXCOORD2:TEXCOORD2;float3 in_NORMAL0:NORMAL0;};
struct V{float4 vertex:SV_POSITION;float4 vs_COLOR0:TEXCOORD0;float4 vs_TEXCOORD1:TEXCOORD1;float4 vs_TEXCOORD2:TEXCOORD2;float4 vs_TEXCOORD5:TEXCOORD3;};
V vert(A i){V o=(V)0;
float4 vs_TEXCOORD0;
float3 u_xlat0;
float4 u_xlat1;
float4 u_xlat2;
float u_xlat9;

    u_xlat0.xyz = i.in_TEXCOORD0.yyy * i.in_NORMAL0.xyz;
    u_xlat9 = min(i.in_TEXCOORD2.x, i.in_TEXCOORD2.w);
    u_xlat0.xyz = (-u_xlat0.xyz) * ((float3)(u_xlat9)) + i.in_POSITION0.xyz;
    u_xlat1 = u_xlat0.yyyy * transpose(unity_ObjectToWorld)[1];
    u_xlat1 = transpose(unity_ObjectToWorld)[0] * u_xlat0.xxxx + u_xlat1;
    u_xlat1 = transpose(unity_ObjectToWorld)[2] * u_xlat0.zzzz + u_xlat1;
    u_xlat1 = u_xlat1 + transpose(unity_ObjectToWorld)[3];
    u_xlat2 = u_xlat1.yyyy * transpose(unity_MatrixVP)[1];
    u_xlat2 = transpose(unity_MatrixVP)[0] * u_xlat1.xxxx + u_xlat2;
    u_xlat2 = transpose(unity_MatrixVP)[2] * u_xlat1.zzzz + u_xlat2;
    o.vertex = transpose(unity_MatrixVP)[3] * u_xlat1.wwww + u_xlat2;
    o.vs_COLOR0 = i.in_COLOR0;
    vs_TEXCOORD0 = i.in_TEXCOORD0;
    u_xlat0.x = u_xlat9 / i.in_TEXCOORD2.w;
    u_xlat0.x = (-u_xlat0.x) + 1.0;
    o.vs_TEXCOORD1.x = u_xlat0.x * u_xlat0.x;
    o.vs_TEXCOORD1.z = i.in_TEXCOORD2.y / i.in_TEXCOORD2.w;
    o.vs_TEXCOORD1.y = (-_RingTopOffset) + 1.0;
    o.vs_TEXCOORD1.w = i.in_TEXCOORD2.z;
    u_xlat0.xy = i.in_TEXCOORD0.yy * i.in_TEXCOORD0.zw;
    u_xlat0.xy = ((float2)(u_xlat9)) * u_xlat0.xy;
    u_xlat0.xy = u_xlat0.xy / i.in_TEXCOORD2.ww;
    o.vs_TEXCOORD2.zw = (-u_xlat0.xy) + i.in_TEXCOORD0.zw;
    u_xlat0.x = i.in_TEXCOORD2.z;
    u_xlat0.y = 0.0;
    u_xlat0.xy = u_xlat0.xy + i.in_TEXCOORD0.xy;
    u_xlat0.xy = u_xlat0.xy * _MainTex_ST.xy + _MainTex_ST.zw;
    o.vs_TEXCOORD2.xy = (-u_xlat0.xy) + float2(1.0, 1.0);
    o.vs_TEXCOORD5 = i.in_TEXCOORD1;
    return o;

}
float4 frag(V i):SV_Target{float4 result=0;
float4 u_xlat0;
float4 u_xlat16_0;
float u_xlat1;
float4 u_xlat16_1;
bool u_xlatb1;
float4 u_xlat16_2;
float u_xlat3;
bool u_xlatb3;
float u_xlat16_4;
float u_xlat16_5;
float u_xlat6;
float u_xlat16_8;

    u_xlat0.x = (-i.vs_TEXCOORD1.z) + i.vs_TEXCOORD1.y;
    u_xlat3 = (-u_xlat0.x) + i.vs_TEXCOORD1.y;
    u_xlat3 = float(1.0) / u_xlat3;
    u_xlat6 = dot(i.vs_TEXCOORD2.zw, i.vs_TEXCOORD2.zw);
    u_xlat0.x = (-u_xlat0.x) + u_xlat6;
    u_xlat6 = u_xlat6 + (-i.vs_TEXCOORD1.x);
    u_xlat0.x = u_xlat3 * u_xlat0.x;
    u_xlat0.x = clamp(u_xlat0.x, 0.0, 1.0);
    u_xlat3 = u_xlat0.x * -2.0 + 3.0;
    u_xlat0.x = u_xlat0.x * u_xlat0.x;
    u_xlat0.x = u_xlat0.x * u_xlat3;
    u_xlat3 = float(1.0) / i.vs_TEXCOORD1.z;
    u_xlat3 = u_xlat3 * u_xlat6;
    u_xlat3 = clamp(u_xlat3, 0.0, 1.0);
    u_xlat6 = u_xlat3 * -2.0 + 3.0;
    u_xlat3 = u_xlat3 * u_xlat3;
    u_xlat0.x = u_xlat6 * u_xlat3 + (-u_xlat0.x);
    u_xlat0.x = clamp(u_xlat0.x, 0.0, 1.0);
    u_xlat16_1 = tex2D(_MainTex, i.vs_TEXCOORD2.xy);
    u_xlatb3 = 0.0<_SingleChannel;
    u_xlat16_2.xyz = (bool(u_xlatb3)) ? float3(1.0, 1.0, 1.0) : u_xlat16_1.xyz;
    u_xlat16_2.w = (u_xlatb3) ? u_xlat16_1.x : u_xlat16_1.w;
    u_xlat0 = u_xlat0.xxxx * u_xlat16_2;
    u_xlat16_0 = u_xlat0 * i.vs_COLOR0;
    u_xlat1 = log2(_HdrMultiply);
    u_xlat1 = u_xlat1 * 0.416666657;
    u_xlat1 = exp2(u_xlat1);
    u_xlat1 = u_xlat1 * 1.05499995 + -0.0549999997;
    u_xlat1 = max(u_xlat1, 0.0);
    u_xlat16_2.xyz = u_xlat16_0.xyz * ((float3)(u_xlat1));
    u_xlatb1 = 0.0<_HdrMultiply;
    result.xyz = (bool(u_xlatb1)) ? u_xlat16_2.xyz : u_xlat16_0.xyz;
    u_xlatb1 = 0.0>=_InvertDissolveTex;
    u_xlat16_4 = tex2D(_DissolveTex, i.vs_TEXCOORD2.xy).x;
    u_xlat16_2.x = (-u_xlat16_4) + 1.0;
    u_xlat16_2.x = (u_xlatb1) ? u_xlat16_2.x : u_xlat16_4;
    u_xlat16_5 = u_xlat16_2.x + _DissolveSmooth;
    u_xlat16_2.x = u_xlat16_2.x + (-_DissolveSmooth);
    u_xlat16_5 = (-u_xlat16_2.x) + u_xlat16_5;
    u_xlat16_5 = float(1.0) / u_xlat16_5;
    u_xlat16_8 = _DissolveSmooth * 2.0 + 1.0;
    u_xlat16_8 = i.vs_TEXCOORD5.x * u_xlat16_8 + (-_DissolveSmooth);
    u_xlat16_2.x = (-u_xlat16_2.x) + u_xlat16_8;
    u_xlat16_2.x = u_xlat16_5 * u_xlat16_2.x;
    u_xlat16_2.x = clamp(u_xlat16_2.x, 0.0, 1.0);
    u_xlat16_5 = u_xlat16_2.x * -2.0 + 3.0;
    u_xlat16_2.x = u_xlat16_2.x * u_xlat16_2.x;
    u_xlat16_2.x = u_xlat16_2.x * u_xlat16_5;
    u_xlat16_2.x = u_xlat16_0.w * u_xlat16_2.x;
    result.w = min(u_xlat16_2.x, 1.0);
    return result;

}

#elif !defined(SOFTPARTICLES_ON) && !defined(_CFXR_DISSOLVE) && defined(_CFXR_RADIAL_UV) && !defined(_CFXR_WORLD_SPACE_RING) && defined(_FADING_ON)
// Original GLES program 10; _CFXR_RADIAL_UV,_FADING_ON
float4 _MainTex_ST;
float _RingTopOffset;
float _SingleChannel;
float _HdrMultiply;
sampler2D _MainTex;
struct A{float4 in_POSITION0:POSITION0;float4 in_COLOR0:COLOR0;float4 in_TEXCOORD0:TEXCOORD0;float4 in_TEXCOORD2:TEXCOORD2;};
struct V{float4 vertex:SV_POSITION;float4 vs_COLOR0:TEXCOORD0;float4 vs_TEXCOORD1:TEXCOORD1;float4 vs_TEXCOORD2:TEXCOORD2;};
V vert(A i){V o=(V)0;
float4 vs_TEXCOORD0;
float2 u_xlat0;
float4 u_xlat1;
float4 u_xlat2;
float u_xlat6;

    u_xlat0.xy = i.in_TEXCOORD0.yy * (-i.in_TEXCOORD0.zw);
    u_xlat1 = i.in_POSITION0.yyyy * transpose(unity_MatrixV)[1];
    u_xlat1 = transpose(unity_MatrixV)[0] * i.in_POSITION0.xxxx + u_xlat1;
    u_xlat1 = transpose(unity_MatrixV)[2] * i.in_POSITION0.zzzz + u_xlat1;
    u_xlat1 = transpose(unity_MatrixV)[3] * i.in_POSITION0.wwww + u_xlat1;
    u_xlat6 = min(i.in_TEXCOORD2.x, i.in_TEXCOORD2.w);
    u_xlat0.xy = u_xlat0.xy * ((float2)(u_xlat6)) + u_xlat1.xy;
    u_xlat2 = u_xlat0.yyyy * transpose(UNITY_MATRIX_P)[1];
    u_xlat2 = transpose(UNITY_MATRIX_P)[0] * u_xlat0.xxxx + u_xlat2;
    u_xlat2 = transpose(UNITY_MATRIX_P)[2] * u_xlat1.zzzz + u_xlat2;
    o.vertex = transpose(UNITY_MATRIX_P)[3] * u_xlat1.wwww + u_xlat2;
    o.vs_COLOR0 = i.in_COLOR0;
    vs_TEXCOORD0 = i.in_TEXCOORD0;
    u_xlat0.x = u_xlat6 / i.in_TEXCOORD2.w;
    u_xlat0.x = (-u_xlat0.x) + 1.0;
    o.vs_TEXCOORD1.x = u_xlat0.x * u_xlat0.x;
    o.vs_TEXCOORD1.z = i.in_TEXCOORD2.y / i.in_TEXCOORD2.w;
    o.vs_TEXCOORD1.y = (-_RingTopOffset) + 1.0;
    o.vs_TEXCOORD1.w = i.in_TEXCOORD2.z;
    u_xlat0.xy = i.in_TEXCOORD0.yy * i.in_TEXCOORD0.zw;
    u_xlat0.xy = ((float2)(u_xlat6)) * u_xlat0.xy;
    u_xlat0.xy = u_xlat0.xy / i.in_TEXCOORD2.ww;
    o.vs_TEXCOORD2.zw = (-u_xlat0.xy) + i.in_TEXCOORD0.zw;
    u_xlat0.x = i.in_TEXCOORD2.z;
    u_xlat0.y = 0.0;
    u_xlat0.xy = u_xlat0.xy + i.in_TEXCOORD0.xy;
    u_xlat0.xy = u_xlat0.xy * _MainTex_ST.xy + _MainTex_ST.zw;
    o.vs_TEXCOORD2.xy = (-u_xlat0.xy) + float2(1.0, 1.0);
    return o;

}
float4 frag(V i):SV_Target{float4 result=0;
float4 u_xlat0;
float4 u_xlat16_0;
bool u_xlatb0;
float u_xlat1;
bool u_xlatb1;
float4 u_xlat16_2;
float4 u_xlat16_3;
float u_xlat4;
bool u_xlatb4;
float u_xlat5;
float2 u_xlat8;
bool u_xlatb8;
float u_xlat12;
bool u_xlatb12;

    u_xlat0.x = max(abs(i.vs_TEXCOORD2.w), abs(i.vs_TEXCOORD2.z));
    u_xlat0.x = float(1.0) / u_xlat0.x;
    u_xlat4 = min(abs(i.vs_TEXCOORD2.w), abs(i.vs_TEXCOORD2.z));
    u_xlat0.x = u_xlat0.x * u_xlat4;
    u_xlat4 = u_xlat0.x * u_xlat0.x;
    u_xlat8.x = u_xlat4 * 0.0208350997 + -0.0851330012;
    u_xlat8.x = u_xlat4 * u_xlat8.x + 0.180141002;
    u_xlat8.x = u_xlat4 * u_xlat8.x + -0.330299497;
    u_xlat4 = u_xlat4 * u_xlat8.x + 0.999866009;
    u_xlat8.x = u_xlat4 * u_xlat0.x;
    u_xlat8.x = u_xlat8.x * -2.0 + 1.57079637;
    u_xlatb12 = abs(i.vs_TEXCOORD2.w)<abs(i.vs_TEXCOORD2.z);
    u_xlat8.x = u_xlatb12 ? u_xlat8.x : float(0.0);
    u_xlat0.x = u_xlat0.x * u_xlat4 + u_xlat8.x;
    u_xlatb4 = i.vs_TEXCOORD2.w<(-i.vs_TEXCOORD2.w);
    u_xlat4 = u_xlatb4 ? -3.14159274 : float(0.0);
    u_xlat0.x = u_xlat4 + u_xlat0.x;
    u_xlat4 = min(i.vs_TEXCOORD2.w, i.vs_TEXCOORD2.z);
    u_xlatb4 = u_xlat4<(-u_xlat4);
    u_xlat8.x = max(i.vs_TEXCOORD2.w, i.vs_TEXCOORD2.z);
    u_xlatb8 = u_xlat8.x>=(-u_xlat8.x);
    u_xlatb4 = u_xlatb8 && u_xlatb4;
    u_xlat0.x = (u_xlatb4) ? (-u_xlat0.x) : u_xlat0.x;
    u_xlat0.x = u_xlat0.x * 0.159154937 + 0.730000019;
    u_xlat0.x = u_xlat0.x + (-i.vs_TEXCOORD1.w);
    u_xlat8.xy = (-i.vs_TEXCOORD1.zx) + i.vs_TEXCOORD1.yy;
    u_xlat1 = float(1.0) / u_xlat8.y;
    u_xlat12 = i.vs_TEXCOORD1.x / u_xlat8.y;
    u_xlat5 = dot(i.vs_TEXCOORD2.zw, i.vs_TEXCOORD2.zw);
    u_xlat12 = u_xlat5 * u_xlat1 + (-u_xlat12);
    u_xlat0.y = u_xlat12 * 0.899999976 + 0.0799999833;
    u_xlat0.xy = u_xlat0.xy * _MainTex_ST.xy + _MainTex_ST.zw;
    u_xlat12 = ddx(i.vs_TEXCOORD2.x);
    u_xlat16_2 = tex2Dgrad(_MainTex, u_xlat0.xy, ((float4)(((float4)(u_xlat12)))).xy, ((float4)(((float4)(u_xlat12)))).xy);
    u_xlatb0 = 0.0<_SingleChannel;
    u_xlat16_3.xyz = (bool(u_xlatb0)) ? float3(1.0, 1.0, 1.0) : u_xlat16_2.xyz;
    u_xlat16_3.w = (u_xlatb0) ? u_xlat16_2.x : u_xlat16_2.w;
    u_xlat0.x = (-u_xlat8.x) + u_xlat5;
    u_xlat4 = u_xlat5 + (-i.vs_TEXCOORD1.x);
    u_xlat8.x = (-u_xlat8.x) + i.vs_TEXCOORD1.y;
    u_xlat8.x = float(1.0) / u_xlat8.x;
    u_xlat0.x = u_xlat8.x * u_xlat0.x;
    u_xlat0.x = clamp(u_xlat0.x, 0.0, 1.0);
    u_xlat8.x = u_xlat0.x * -2.0 + 3.0;
    u_xlat0.x = u_xlat0.x * u_xlat0.x;
    u_xlat0.x = u_xlat0.x * u_xlat8.x;
    u_xlat8.x = float(1.0) / i.vs_TEXCOORD1.z;
    u_xlat4 = u_xlat8.x * u_xlat4;
    u_xlat4 = clamp(u_xlat4, 0.0, 1.0);
    u_xlat8.x = u_xlat4 * -2.0 + 3.0;
    u_xlat4 = u_xlat4 * u_xlat4;
    u_xlat0.x = u_xlat8.x * u_xlat4 + (-u_xlat0.x);
    u_xlat0.x = clamp(u_xlat0.x, 0.0, 1.0);
    u_xlat0 = u_xlat0.xxxx * u_xlat16_3;
    u_xlat16_0 = u_xlat0 * i.vs_COLOR0;
    u_xlat1 = log2(_HdrMultiply);
    u_xlat1 = u_xlat1 * 0.416666657;
    u_xlat1 = exp2(u_xlat1);
    u_xlat1 = u_xlat1 * 1.05499995 + -0.0549999997;
    u_xlat1 = max(u_xlat1, 0.0);
    u_xlat16_3.xyz = u_xlat16_0.xyz * ((float3)(u_xlat1));
    u_xlatb1 = 0.0<_HdrMultiply;
    result.xyz = (bool(u_xlatb1)) ? u_xlat16_3.xyz : u_xlat16_0.xyz;
    result.w = min(u_xlat16_0.w, 1.0);
    return result;

}

#elif defined(SOFTPARTICLES_ON) && !defined(_CFXR_DISSOLVE) && !defined(_CFXR_RADIAL_UV) && defined(_CFXR_WORLD_SPACE_RING) && !defined(_FADING_ON)
// Original GLES program 12; SOFTPARTICLES_ON,_CFXR_WORLD_SPACE_RING
float4 _MainTex_ST;
float _RingTopOffset;
float _SingleChannel;
float _HdrMultiply;
sampler2D _MainTex;
struct A{float4 in_POSITION0:POSITION0;float4 in_COLOR0:COLOR0;float4 in_TEXCOORD0:TEXCOORD0;float4 in_TEXCOORD2:TEXCOORD2;float3 in_NORMAL0:NORMAL0;};
struct V{float4 vertex:SV_POSITION;float4 vs_COLOR0:TEXCOORD0;float4 vs_TEXCOORD1:TEXCOORD1;float4 vs_TEXCOORD2:TEXCOORD2;};
V vert(A i){V o=(V)0;
float4 vs_TEXCOORD0;
float3 u_xlat0;
float4 u_xlat1;
float4 u_xlat2;
float u_xlat9;

    u_xlat0.xyz = i.in_TEXCOORD0.yyy * i.in_NORMAL0.xyz;
    u_xlat9 = min(i.in_TEXCOORD2.x, i.in_TEXCOORD2.w);
    u_xlat0.xyz = (-u_xlat0.xyz) * ((float3)(u_xlat9)) + i.in_POSITION0.xyz;
    u_xlat1 = u_xlat0.yyyy * transpose(unity_ObjectToWorld)[1];
    u_xlat1 = transpose(unity_ObjectToWorld)[0] * u_xlat0.xxxx + u_xlat1;
    u_xlat1 = transpose(unity_ObjectToWorld)[2] * u_xlat0.zzzz + u_xlat1;
    u_xlat1 = u_xlat1 + transpose(unity_ObjectToWorld)[3];
    u_xlat2 = u_xlat1.yyyy * transpose(unity_MatrixVP)[1];
    u_xlat2 = transpose(unity_MatrixVP)[0] * u_xlat1.xxxx + u_xlat2;
    u_xlat2 = transpose(unity_MatrixVP)[2] * u_xlat1.zzzz + u_xlat2;
    o.vertex = transpose(unity_MatrixVP)[3] * u_xlat1.wwww + u_xlat2;
    o.vs_COLOR0 = i.in_COLOR0;
    vs_TEXCOORD0 = i.in_TEXCOORD0;
    u_xlat0.x = u_xlat9 / i.in_TEXCOORD2.w;
    u_xlat0.x = (-u_xlat0.x) + 1.0;
    o.vs_TEXCOORD1.x = u_xlat0.x * u_xlat0.x;
    o.vs_TEXCOORD1.z = i.in_TEXCOORD2.y / i.in_TEXCOORD2.w;
    o.vs_TEXCOORD1.y = (-_RingTopOffset) + 1.0;
    o.vs_TEXCOORD1.w = i.in_TEXCOORD2.z;
    u_xlat0.xy = i.in_TEXCOORD0.yy * i.in_TEXCOORD0.zw;
    u_xlat0.xy = ((float2)(u_xlat9)) * u_xlat0.xy;
    u_xlat0.xy = u_xlat0.xy / i.in_TEXCOORD2.ww;
    o.vs_TEXCOORD2.zw = (-u_xlat0.xy) + i.in_TEXCOORD0.zw;
    u_xlat0.x = i.in_TEXCOORD2.z;
    u_xlat0.y = 0.0;
    u_xlat0.xy = u_xlat0.xy + i.in_TEXCOORD0.xy;
    u_xlat0.xy = u_xlat0.xy * _MainTex_ST.xy + _MainTex_ST.zw;
    o.vs_TEXCOORD2.xy = (-u_xlat0.xy) + float2(1.0, 1.0);
    return o;

}
float4 frag(V i):SV_Target{float4 result=0;
float4 u_xlat0;
float4 u_xlat16_0;
float u_xlat1;
float4 u_xlat16_1;
bool u_xlatb1;
float4 u_xlat16_2;
float u_xlat3;
bool u_xlatb3;
float u_xlat6;

    u_xlat0.x = (-i.vs_TEXCOORD1.z) + i.vs_TEXCOORD1.y;
    u_xlat3 = (-u_xlat0.x) + i.vs_TEXCOORD1.y;
    u_xlat3 = float(1.0) / u_xlat3;
    u_xlat6 = dot(i.vs_TEXCOORD2.zw, i.vs_TEXCOORD2.zw);
    u_xlat0.x = (-u_xlat0.x) + u_xlat6;
    u_xlat6 = u_xlat6 + (-i.vs_TEXCOORD1.x);
    u_xlat0.x = u_xlat3 * u_xlat0.x;
    u_xlat0.x = clamp(u_xlat0.x, 0.0, 1.0);
    u_xlat3 = u_xlat0.x * -2.0 + 3.0;
    u_xlat0.x = u_xlat0.x * u_xlat0.x;
    u_xlat0.x = u_xlat0.x * u_xlat3;
    u_xlat3 = float(1.0) / i.vs_TEXCOORD1.z;
    u_xlat3 = u_xlat3 * u_xlat6;
    u_xlat3 = clamp(u_xlat3, 0.0, 1.0);
    u_xlat6 = u_xlat3 * -2.0 + 3.0;
    u_xlat3 = u_xlat3 * u_xlat3;
    u_xlat0.x = u_xlat6 * u_xlat3 + (-u_xlat0.x);
    u_xlat0.x = clamp(u_xlat0.x, 0.0, 1.0);
    u_xlat16_1 = tex2D(_MainTex, i.vs_TEXCOORD2.xy);
    u_xlatb3 = 0.0<_SingleChannel;
    u_xlat16_2.xyz = (bool(u_xlatb3)) ? float3(1.0, 1.0, 1.0) : u_xlat16_1.xyz;
    u_xlat16_2.w = (u_xlatb3) ? u_xlat16_1.x : u_xlat16_1.w;
    u_xlat0 = u_xlat0.xxxx * u_xlat16_2;
    u_xlat16_0 = u_xlat0 * i.vs_COLOR0;
    u_xlat1 = log2(_HdrMultiply);
    u_xlat1 = u_xlat1 * 0.416666657;
    u_xlat1 = exp2(u_xlat1);
    u_xlat1 = u_xlat1 * 1.05499995 + -0.0549999997;
    u_xlat1 = max(u_xlat1, 0.0);
    u_xlat16_2.xyz = u_xlat16_0.xyz * ((float3)(u_xlat1));
    u_xlatb1 = 0.0<_HdrMultiply;
    result.xyz = (bool(u_xlatb1)) ? u_xlat16_2.xyz : u_xlat16_0.xyz;
    result.w = min(u_xlat16_0.w, 1.0);
    return result;

}

#elif defined(SOFTPARTICLES_ON) && !defined(_CFXR_DISSOLVE) && !defined(_CFXR_RADIAL_UV) && !defined(_CFXR_WORLD_SPACE_RING) && defined(_FADING_ON)
// Original GLES program 14; SOFTPARTICLES_ON,_FADING_ON
float4 _MainTex_ST;
float _RingTopOffset;
float _SingleChannel;
float _HdrMultiply;
float _SoftParticlesFadeDistanceNear;
float _SoftParticlesFadeDistanceFar;
sampler2D _MainTex;
sampler2D _CameraDepthTexture;
struct A{float4 in_POSITION0:POSITION0;float4 in_COLOR0:COLOR0;float4 in_TEXCOORD0:TEXCOORD0;float4 in_TEXCOORD2:TEXCOORD2;};
struct V{float4 vertex:SV_POSITION;float4 vs_COLOR0:TEXCOORD0;float4 vs_TEXCOORD1:TEXCOORD1;float4 vs_TEXCOORD2:TEXCOORD2;float4 vs_TEXCOORD3:TEXCOORD3;};
V vert(A i){V o=(V)0;
float4 vs_TEXCOORD0;
float4 u_xlat0;
float4 u_xlat1;
float4 u_xlat2;
float u_xlat3;
float u_xlat6;

    u_xlat0.xy = i.in_TEXCOORD0.yy * (-i.in_TEXCOORD0.zw);
    u_xlat1 = i.in_POSITION0.yyyy * transpose(unity_MatrixV)[1];
    u_xlat1 = transpose(unity_MatrixV)[0] * i.in_POSITION0.xxxx + u_xlat1;
    u_xlat1 = transpose(unity_MatrixV)[2] * i.in_POSITION0.zzzz + u_xlat1;
    u_xlat1 = transpose(unity_MatrixV)[3] * i.in_POSITION0.wwww + u_xlat1;
    u_xlat6 = min(i.in_TEXCOORD2.x, i.in_TEXCOORD2.w);
    u_xlat0.xy = u_xlat0.xy * ((float2)(u_xlat6)) + u_xlat1.xy;
    u_xlat2 = u_xlat0.yyyy * transpose(UNITY_MATRIX_P)[1];
    u_xlat2 = transpose(UNITY_MATRIX_P)[0] * u_xlat0.xxxx + u_xlat2;
    u_xlat2 = transpose(UNITY_MATRIX_P)[2] * u_xlat1.zzzz + u_xlat2;
    u_xlat1 = transpose(UNITY_MATRIX_P)[3] * u_xlat1.wwww + u_xlat2;
    o.vertex = u_xlat1;
    o.vs_COLOR0 = i.in_COLOR0;
    vs_TEXCOORD0 = i.in_TEXCOORD0;
    u_xlat0.x = u_xlat6 / i.in_TEXCOORD2.w;
    u_xlat0.x = (-u_xlat0.x) + 1.0;
    o.vs_TEXCOORD1.x = u_xlat0.x * u_xlat0.x;
    o.vs_TEXCOORD1.z = i.in_TEXCOORD2.y / i.in_TEXCOORD2.w;
    o.vs_TEXCOORD1.y = (-_RingTopOffset) + 1.0;
    o.vs_TEXCOORD1.w = i.in_TEXCOORD2.z;
    u_xlat0.xy = i.in_TEXCOORD0.yy * i.in_TEXCOORD0.zw;
    u_xlat0.xy = ((float2)(u_xlat6)) * u_xlat0.xy;
    u_xlat0.xy = u_xlat0.xy / i.in_TEXCOORD2.ww;
    o.vs_TEXCOORD2.zw = (-u_xlat0.xy) + i.in_TEXCOORD0.zw;
    u_xlat0.x = i.in_TEXCOORD2.z;
    u_xlat0.y = 0.0;
    u_xlat0.xy = u_xlat0.xy + i.in_TEXCOORD0.xy;
    u_xlat0.xy = u_xlat0.xy * _MainTex_ST.xy + _MainTex_ST.zw;
    o.vs_TEXCOORD2.xy = (-u_xlat0.xy) + float2(1.0, 1.0);
    u_xlat0.x = u_xlat1.y * _ProjectionParams.x;
    u_xlat0.w = u_xlat0.x * 0.5;
    u_xlat0.xz = u_xlat1.xw * float2(0.5, 0.5);
    o.vs_TEXCOORD3.w = u_xlat1.w;
    o.vs_TEXCOORD3.xy = u_xlat0.zz + u_xlat0.xw;
    u_xlat0 = i.in_POSITION0.yyyy * transpose(unity_ObjectToWorld)[1];
    u_xlat0 = transpose(unity_ObjectToWorld)[0] * i.in_POSITION0.xxxx + u_xlat0;
    u_xlat0 = transpose(unity_ObjectToWorld)[2] * i.in_POSITION0.zzzz + u_xlat0;
    u_xlat0 = u_xlat0 + transpose(unity_ObjectToWorld)[3];
    u_xlat3 = u_xlat0.y * transpose(unity_MatrixV)[1].z;
    u_xlat0.x = transpose(unity_MatrixV)[0].z * u_xlat0.x + u_xlat3;
    u_xlat0.x = transpose(unity_MatrixV)[2].z * u_xlat0.z + u_xlat0.x;
    u_xlat0.x = transpose(unity_MatrixV)[3].z * u_xlat0.w + u_xlat0.x;
    o.vs_TEXCOORD3.z = (-u_xlat0.x);
    return o;

}
float4 frag(V i):SV_Target{float4 result=0;
float4 u_xlat0;
float4 u_xlat16_0;
float2 u_xlat1;
float4 u_xlat16_1;
bool u_xlatb1;
float4 u_xlat16_2;
float u_xlat3;
bool u_xlatb3;
float u_xlat4;
float u_xlat6;
bool u_xlatb7;

    u_xlat0.x = (-i.vs_TEXCOORD1.z) + i.vs_TEXCOORD1.y;
    u_xlat3 = (-u_xlat0.x) + i.vs_TEXCOORD1.y;
    u_xlat3 = float(1.0) / u_xlat3;
    u_xlat6 = dot(i.vs_TEXCOORD2.zw, i.vs_TEXCOORD2.zw);
    u_xlat0.x = (-u_xlat0.x) + u_xlat6;
    u_xlat6 = u_xlat6 + (-i.vs_TEXCOORD1.x);
    u_xlat0.x = u_xlat3 * u_xlat0.x;
    u_xlat0.x = clamp(u_xlat0.x, 0.0, 1.0);
    u_xlat3 = u_xlat0.x * -2.0 + 3.0;
    u_xlat0.x = u_xlat0.x * u_xlat0.x;
    u_xlat0.x = u_xlat0.x * u_xlat3;
    u_xlat3 = float(1.0) / i.vs_TEXCOORD1.z;
    u_xlat3 = u_xlat3 * u_xlat6;
    u_xlat3 = clamp(u_xlat3, 0.0, 1.0);
    u_xlat6 = u_xlat3 * -2.0 + 3.0;
    u_xlat3 = u_xlat3 * u_xlat3;
    u_xlat0.x = u_xlat6 * u_xlat3 + (-u_xlat0.x);
    u_xlat0.x = clamp(u_xlat0.x, 0.0, 1.0);
    u_xlat16_1 = tex2D(_MainTex, i.vs_TEXCOORD2.xy);
    u_xlatb3 = 0.0<_SingleChannel;
    u_xlat16_2.xyz = (bool(u_xlatb3)) ? float3(1.0, 1.0, 1.0) : u_xlat16_1.xyz;
    u_xlat16_2.w = (u_xlatb3) ? u_xlat16_1.x : u_xlat16_1.w;
    u_xlat0 = u_xlat0.xxxx * u_xlat16_2;
    u_xlat16_0 = u_xlat0 * i.vs_COLOR0;
    u_xlat1.x = log2(_HdrMultiply);
    u_xlat1.x = u_xlat1.x * 0.416666657;
    u_xlat1.x = exp2(u_xlat1.x);
    u_xlat1.x = u_xlat1.x * 1.05499995 + -0.0549999997;
    u_xlat1.x = max(u_xlat1.x, 0.0);
    u_xlat16_2.xyz = u_xlat16_0.xyz * u_xlat1.xxx;
    u_xlatb1 = 0.0<_HdrMultiply;
    result.xyz = (bool(u_xlatb1)) ? u_xlat16_2.xyz : u_xlat16_0.xyz;
    u_xlat1.xy = i.vs_TEXCOORD3.xy / i.vs_TEXCOORD3.ww;
    u_xlat1.x = tex2D(_CameraDepthTexture, u_xlat1.xy).x;
    u_xlat4 = _ZBufferParams.z * u_xlat1.x + _ZBufferParams.w;
    u_xlat1.x = u_xlat1.x * _ProjectionParams.z + _ProjectionParams.y;
    u_xlat4 = float(1.0) / u_xlat4;
    u_xlatb7 = unity_OrthoParams.w==1.0;
    u_xlat1.x = (u_xlatb7) ? u_xlat1.x : u_xlat4;
    u_xlat1.x = u_xlat1.x + (-_SoftParticlesFadeDistanceNear);
    u_xlat1.x = u_xlat1.x + (-i.vs_TEXCOORD3.z);
    u_xlat1.x = u_xlat1.x * _SoftParticlesFadeDistanceFar;
    u_xlat1.x = clamp(u_xlat1.x, 0.0, 1.0);
    u_xlat1.x = u_xlat16_0.w * u_xlat1.x;
    result.w = min(u_xlat1.x, 1.0);
    return result;

}

#elif !defined(SOFTPARTICLES_ON) && !defined(_CFXR_DISSOLVE) && !defined(_CFXR_RADIAL_UV) && defined(_CFXR_WORLD_SPACE_RING) && !defined(_FADING_ON)
// Original GLES program 7; _CFXR_WORLD_SPACE_RING
float4 _MainTex_ST;
float _RingTopOffset;
float _SingleChannel;
float _HdrMultiply;
sampler2D _MainTex;
struct A{float4 in_POSITION0:POSITION0;float4 in_COLOR0:COLOR0;float4 in_TEXCOORD0:TEXCOORD0;float4 in_TEXCOORD2:TEXCOORD2;float3 in_NORMAL0:NORMAL0;};
struct V{float4 vertex:SV_POSITION;float4 vs_COLOR0:TEXCOORD0;float4 vs_TEXCOORD1:TEXCOORD1;float4 vs_TEXCOORD2:TEXCOORD2;};
V vert(A i){V o=(V)0;
float4 vs_TEXCOORD0;
float3 u_xlat0;
float4 u_xlat1;
float4 u_xlat2;
float u_xlat9;

    u_xlat0.xyz = i.in_TEXCOORD0.yyy * i.in_NORMAL0.xyz;
    u_xlat9 = min(i.in_TEXCOORD2.x, i.in_TEXCOORD2.w);
    u_xlat0.xyz = (-u_xlat0.xyz) * ((float3)(u_xlat9)) + i.in_POSITION0.xyz;
    u_xlat1 = u_xlat0.yyyy * transpose(unity_ObjectToWorld)[1];
    u_xlat1 = transpose(unity_ObjectToWorld)[0] * u_xlat0.xxxx + u_xlat1;
    u_xlat1 = transpose(unity_ObjectToWorld)[2] * u_xlat0.zzzz + u_xlat1;
    u_xlat1 = u_xlat1 + transpose(unity_ObjectToWorld)[3];
    u_xlat2 = u_xlat1.yyyy * transpose(unity_MatrixVP)[1];
    u_xlat2 = transpose(unity_MatrixVP)[0] * u_xlat1.xxxx + u_xlat2;
    u_xlat2 = transpose(unity_MatrixVP)[2] * u_xlat1.zzzz + u_xlat2;
    o.vertex = transpose(unity_MatrixVP)[3] * u_xlat1.wwww + u_xlat2;
    o.vs_COLOR0 = i.in_COLOR0;
    vs_TEXCOORD0 = i.in_TEXCOORD0;
    u_xlat0.x = u_xlat9 / i.in_TEXCOORD2.w;
    u_xlat0.x = (-u_xlat0.x) + 1.0;
    o.vs_TEXCOORD1.x = u_xlat0.x * u_xlat0.x;
    o.vs_TEXCOORD1.z = i.in_TEXCOORD2.y / i.in_TEXCOORD2.w;
    o.vs_TEXCOORD1.y = (-_RingTopOffset) + 1.0;
    o.vs_TEXCOORD1.w = i.in_TEXCOORD2.z;
    u_xlat0.xy = i.in_TEXCOORD0.yy * i.in_TEXCOORD0.zw;
    u_xlat0.xy = ((float2)(u_xlat9)) * u_xlat0.xy;
    u_xlat0.xy = u_xlat0.xy / i.in_TEXCOORD2.ww;
    o.vs_TEXCOORD2.zw = (-u_xlat0.xy) + i.in_TEXCOORD0.zw;
    u_xlat0.x = i.in_TEXCOORD2.z;
    u_xlat0.y = 0.0;
    u_xlat0.xy = u_xlat0.xy + i.in_TEXCOORD0.xy;
    u_xlat0.xy = u_xlat0.xy * _MainTex_ST.xy + _MainTex_ST.zw;
    o.vs_TEXCOORD2.xy = (-u_xlat0.xy) + float2(1.0, 1.0);
    return o;

}
float4 frag(V i):SV_Target{float4 result=0;
float4 u_xlat0;
float4 u_xlat16_0;
float u_xlat1;
float4 u_xlat16_1;
bool u_xlatb1;
float4 u_xlat16_2;
float u_xlat3;
bool u_xlatb3;
float u_xlat6;

    u_xlat0.x = (-i.vs_TEXCOORD1.z) + i.vs_TEXCOORD1.y;
    u_xlat3 = (-u_xlat0.x) + i.vs_TEXCOORD1.y;
    u_xlat3 = float(1.0) / u_xlat3;
    u_xlat6 = dot(i.vs_TEXCOORD2.zw, i.vs_TEXCOORD2.zw);
    u_xlat0.x = (-u_xlat0.x) + u_xlat6;
    u_xlat6 = u_xlat6 + (-i.vs_TEXCOORD1.x);
    u_xlat0.x = u_xlat3 * u_xlat0.x;
    u_xlat0.x = clamp(u_xlat0.x, 0.0, 1.0);
    u_xlat3 = u_xlat0.x * -2.0 + 3.0;
    u_xlat0.x = u_xlat0.x * u_xlat0.x;
    u_xlat0.x = u_xlat0.x * u_xlat3;
    u_xlat3 = float(1.0) / i.vs_TEXCOORD1.z;
    u_xlat3 = u_xlat3 * u_xlat6;
    u_xlat3 = clamp(u_xlat3, 0.0, 1.0);
    u_xlat6 = u_xlat3 * -2.0 + 3.0;
    u_xlat3 = u_xlat3 * u_xlat3;
    u_xlat0.x = u_xlat6 * u_xlat3 + (-u_xlat0.x);
    u_xlat0.x = clamp(u_xlat0.x, 0.0, 1.0);
    u_xlat16_1 = tex2D(_MainTex, i.vs_TEXCOORD2.xy);
    u_xlatb3 = 0.0<_SingleChannel;
    u_xlat16_2.xyz = (bool(u_xlatb3)) ? float3(1.0, 1.0, 1.0) : u_xlat16_1.xyz;
    u_xlat16_2.w = (u_xlatb3) ? u_xlat16_1.x : u_xlat16_1.w;
    u_xlat0 = u_xlat0.xxxx * u_xlat16_2;
    u_xlat16_0 = u_xlat0 * i.vs_COLOR0;
    u_xlat1 = log2(_HdrMultiply);
    u_xlat1 = u_xlat1 * 0.416666657;
    u_xlat1 = exp2(u_xlat1);
    u_xlat1 = u_xlat1 * 1.05499995 + -0.0549999997;
    u_xlat1 = max(u_xlat1, 0.0);
    u_xlat16_2.xyz = u_xlat16_0.xyz * ((float3)(u_xlat1));
    u_xlatb1 = 0.0<_HdrMultiply;
    result.xyz = (bool(u_xlatb1)) ? u_xlat16_2.xyz : u_xlat16_0.xyz;
    result.w = min(u_xlat16_0.w, 1.0);
    return result;

}

#elif !defined(SOFTPARTICLES_ON) && !defined(_CFXR_DISSOLVE) && !defined(_CFXR_RADIAL_UV) && !defined(_CFXR_WORLD_SPACE_RING) && defined(_FADING_ON)
// Original GLES program 9; _FADING_ON
float4 _MainTex_ST;
float _RingTopOffset;
float _SingleChannel;
float _HdrMultiply;
sampler2D _MainTex;
struct A{float4 in_POSITION0:POSITION0;float4 in_COLOR0:COLOR0;float4 in_TEXCOORD0:TEXCOORD0;float4 in_TEXCOORD2:TEXCOORD2;};
struct V{float4 vertex:SV_POSITION;float4 vs_COLOR0:TEXCOORD0;float4 vs_TEXCOORD1:TEXCOORD1;float4 vs_TEXCOORD2:TEXCOORD2;};
V vert(A i){V o=(V)0;
float4 vs_TEXCOORD0;
float2 u_xlat0;
float4 u_xlat1;
float4 u_xlat2;
float u_xlat6;

    u_xlat0.xy = i.in_TEXCOORD0.yy * (-i.in_TEXCOORD0.zw);
    u_xlat1 = i.in_POSITION0.yyyy * transpose(unity_MatrixV)[1];
    u_xlat1 = transpose(unity_MatrixV)[0] * i.in_POSITION0.xxxx + u_xlat1;
    u_xlat1 = transpose(unity_MatrixV)[2] * i.in_POSITION0.zzzz + u_xlat1;
    u_xlat1 = transpose(unity_MatrixV)[3] * i.in_POSITION0.wwww + u_xlat1;
    u_xlat6 = min(i.in_TEXCOORD2.x, i.in_TEXCOORD2.w);
    u_xlat0.xy = u_xlat0.xy * ((float2)(u_xlat6)) + u_xlat1.xy;
    u_xlat2 = u_xlat0.yyyy * transpose(UNITY_MATRIX_P)[1];
    u_xlat2 = transpose(UNITY_MATRIX_P)[0] * u_xlat0.xxxx + u_xlat2;
    u_xlat2 = transpose(UNITY_MATRIX_P)[2] * u_xlat1.zzzz + u_xlat2;
    o.vertex = transpose(UNITY_MATRIX_P)[3] * u_xlat1.wwww + u_xlat2;
    o.vs_COLOR0 = i.in_COLOR0;
    vs_TEXCOORD0 = i.in_TEXCOORD0;
    u_xlat0.x = u_xlat6 / i.in_TEXCOORD2.w;
    u_xlat0.x = (-u_xlat0.x) + 1.0;
    o.vs_TEXCOORD1.x = u_xlat0.x * u_xlat0.x;
    o.vs_TEXCOORD1.z = i.in_TEXCOORD2.y / i.in_TEXCOORD2.w;
    o.vs_TEXCOORD1.y = (-_RingTopOffset) + 1.0;
    o.vs_TEXCOORD1.w = i.in_TEXCOORD2.z;
    u_xlat0.xy = i.in_TEXCOORD0.yy * i.in_TEXCOORD0.zw;
    u_xlat0.xy = ((float2)(u_xlat6)) * u_xlat0.xy;
    u_xlat0.xy = u_xlat0.xy / i.in_TEXCOORD2.ww;
    o.vs_TEXCOORD2.zw = (-u_xlat0.xy) + i.in_TEXCOORD0.zw;
    u_xlat0.x = i.in_TEXCOORD2.z;
    u_xlat0.y = 0.0;
    u_xlat0.xy = u_xlat0.xy + i.in_TEXCOORD0.xy;
    u_xlat0.xy = u_xlat0.xy * _MainTex_ST.xy + _MainTex_ST.zw;
    o.vs_TEXCOORD2.xy = (-u_xlat0.xy) + float2(1.0, 1.0);
    return o;

}
float4 frag(V i):SV_Target{float4 result=0;
float4 u_xlat0;
float4 u_xlat16_0;
float u_xlat1;
float4 u_xlat16_1;
bool u_xlatb1;
float4 u_xlat16_2;
float u_xlat3;
bool u_xlatb3;
float u_xlat6;

    u_xlat0.x = (-i.vs_TEXCOORD1.z) + i.vs_TEXCOORD1.y;
    u_xlat3 = (-u_xlat0.x) + i.vs_TEXCOORD1.y;
    u_xlat3 = float(1.0) / u_xlat3;
    u_xlat6 = dot(i.vs_TEXCOORD2.zw, i.vs_TEXCOORD2.zw);
    u_xlat0.x = (-u_xlat0.x) + u_xlat6;
    u_xlat6 = u_xlat6 + (-i.vs_TEXCOORD1.x);
    u_xlat0.x = u_xlat3 * u_xlat0.x;
    u_xlat0.x = clamp(u_xlat0.x, 0.0, 1.0);
    u_xlat3 = u_xlat0.x * -2.0 + 3.0;
    u_xlat0.x = u_xlat0.x * u_xlat0.x;
    u_xlat0.x = u_xlat0.x * u_xlat3;
    u_xlat3 = float(1.0) / i.vs_TEXCOORD1.z;
    u_xlat3 = u_xlat3 * u_xlat6;
    u_xlat3 = clamp(u_xlat3, 0.0, 1.0);
    u_xlat6 = u_xlat3 * -2.0 + 3.0;
    u_xlat3 = u_xlat3 * u_xlat3;
    u_xlat0.x = u_xlat6 * u_xlat3 + (-u_xlat0.x);
    u_xlat0.x = clamp(u_xlat0.x, 0.0, 1.0);
    u_xlat16_1 = tex2D(_MainTex, i.vs_TEXCOORD2.xy);
    u_xlatb3 = 0.0<_SingleChannel;
    u_xlat16_2.xyz = (bool(u_xlatb3)) ? float3(1.0, 1.0, 1.0) : u_xlat16_1.xyz;
    u_xlat16_2.w = (u_xlatb3) ? u_xlat16_1.x : u_xlat16_1.w;
    u_xlat0 = u_xlat0.xxxx * u_xlat16_2;
    u_xlat16_0 = u_xlat0 * i.vs_COLOR0;
    u_xlat1 = log2(_HdrMultiply);
    u_xlat1 = u_xlat1 * 0.416666657;
    u_xlat1 = exp2(u_xlat1);
    u_xlat1 = u_xlat1 * 1.05499995 + -0.0549999997;
    u_xlat1 = max(u_xlat1, 0.0);
    u_xlat16_2.xyz = u_xlat16_0.xyz * ((float3)(u_xlat1));
    u_xlatb1 = 0.0<_HdrMultiply;
    result.xyz = (bool(u_xlatb1)) ? u_xlat16_2.xyz : u_xlat16_0.xyz;
    result.w = min(u_xlat16_0.w, 1.0);
    return result;

}

#elif defined(SOFTPARTICLES_ON) && !defined(_CFXR_DISSOLVE) && !defined(_CFXR_RADIAL_UV) && !defined(_CFXR_WORLD_SPACE_RING) && !defined(_FADING_ON)
// Original GLES program 11; SOFTPARTICLES_ON
float4 _MainTex_ST;
float _RingTopOffset;
float _SingleChannel;
float _HdrMultiply;
sampler2D _MainTex;
struct A{float4 in_POSITION0:POSITION0;float4 in_COLOR0:COLOR0;float4 in_TEXCOORD0:TEXCOORD0;float4 in_TEXCOORD2:TEXCOORD2;};
struct V{float4 vertex:SV_POSITION;float4 vs_COLOR0:TEXCOORD0;float4 vs_TEXCOORD1:TEXCOORD1;float4 vs_TEXCOORD2:TEXCOORD2;};
V vert(A i){V o=(V)0;
float4 vs_TEXCOORD0;
float2 u_xlat0;
float4 u_xlat1;
float4 u_xlat2;
float u_xlat6;

    u_xlat0.xy = i.in_TEXCOORD0.yy * (-i.in_TEXCOORD0.zw);
    u_xlat1 = i.in_POSITION0.yyyy * transpose(unity_MatrixV)[1];
    u_xlat1 = transpose(unity_MatrixV)[0] * i.in_POSITION0.xxxx + u_xlat1;
    u_xlat1 = transpose(unity_MatrixV)[2] * i.in_POSITION0.zzzz + u_xlat1;
    u_xlat1 = transpose(unity_MatrixV)[3] * i.in_POSITION0.wwww + u_xlat1;
    u_xlat6 = min(i.in_TEXCOORD2.x, i.in_TEXCOORD2.w);
    u_xlat0.xy = u_xlat0.xy * ((float2)(u_xlat6)) + u_xlat1.xy;
    u_xlat2 = u_xlat0.yyyy * transpose(UNITY_MATRIX_P)[1];
    u_xlat2 = transpose(UNITY_MATRIX_P)[0] * u_xlat0.xxxx + u_xlat2;
    u_xlat2 = transpose(UNITY_MATRIX_P)[2] * u_xlat1.zzzz + u_xlat2;
    o.vertex = transpose(UNITY_MATRIX_P)[3] * u_xlat1.wwww + u_xlat2;
    o.vs_COLOR0 = i.in_COLOR0;
    vs_TEXCOORD0 = i.in_TEXCOORD0;
    u_xlat0.x = u_xlat6 / i.in_TEXCOORD2.w;
    u_xlat0.x = (-u_xlat0.x) + 1.0;
    o.vs_TEXCOORD1.x = u_xlat0.x * u_xlat0.x;
    o.vs_TEXCOORD1.z = i.in_TEXCOORD2.y / i.in_TEXCOORD2.w;
    o.vs_TEXCOORD1.y = (-_RingTopOffset) + 1.0;
    o.vs_TEXCOORD1.w = i.in_TEXCOORD2.z;
    u_xlat0.xy = i.in_TEXCOORD0.yy * i.in_TEXCOORD0.zw;
    u_xlat0.xy = ((float2)(u_xlat6)) * u_xlat0.xy;
    u_xlat0.xy = u_xlat0.xy / i.in_TEXCOORD2.ww;
    o.vs_TEXCOORD2.zw = (-u_xlat0.xy) + i.in_TEXCOORD0.zw;
    u_xlat0.x = i.in_TEXCOORD2.z;
    u_xlat0.y = 0.0;
    u_xlat0.xy = u_xlat0.xy + i.in_TEXCOORD0.xy;
    u_xlat0.xy = u_xlat0.xy * _MainTex_ST.xy + _MainTex_ST.zw;
    o.vs_TEXCOORD2.xy = (-u_xlat0.xy) + float2(1.0, 1.0);
    return o;

}
float4 frag(V i):SV_Target{float4 result=0;
float4 u_xlat0;
float4 u_xlat16_0;
float u_xlat1;
float4 u_xlat16_1;
bool u_xlatb1;
float4 u_xlat16_2;
float u_xlat3;
bool u_xlatb3;
float u_xlat6;

    u_xlat0.x = (-i.vs_TEXCOORD1.z) + i.vs_TEXCOORD1.y;
    u_xlat3 = (-u_xlat0.x) + i.vs_TEXCOORD1.y;
    u_xlat3 = float(1.0) / u_xlat3;
    u_xlat6 = dot(i.vs_TEXCOORD2.zw, i.vs_TEXCOORD2.zw);
    u_xlat0.x = (-u_xlat0.x) + u_xlat6;
    u_xlat6 = u_xlat6 + (-i.vs_TEXCOORD1.x);
    u_xlat0.x = u_xlat3 * u_xlat0.x;
    u_xlat0.x = clamp(u_xlat0.x, 0.0, 1.0);
    u_xlat3 = u_xlat0.x * -2.0 + 3.0;
    u_xlat0.x = u_xlat0.x * u_xlat0.x;
    u_xlat0.x = u_xlat0.x * u_xlat3;
    u_xlat3 = float(1.0) / i.vs_TEXCOORD1.z;
    u_xlat3 = u_xlat3 * u_xlat6;
    u_xlat3 = clamp(u_xlat3, 0.0, 1.0);
    u_xlat6 = u_xlat3 * -2.0 + 3.0;
    u_xlat3 = u_xlat3 * u_xlat3;
    u_xlat0.x = u_xlat6 * u_xlat3 + (-u_xlat0.x);
    u_xlat0.x = clamp(u_xlat0.x, 0.0, 1.0);
    u_xlat16_1 = tex2D(_MainTex, i.vs_TEXCOORD2.xy);
    u_xlatb3 = 0.0<_SingleChannel;
    u_xlat16_2.xyz = (bool(u_xlatb3)) ? float3(1.0, 1.0, 1.0) : u_xlat16_1.xyz;
    u_xlat16_2.w = (u_xlatb3) ? u_xlat16_1.x : u_xlat16_1.w;
    u_xlat0 = u_xlat0.xxxx * u_xlat16_2;
    u_xlat16_0 = u_xlat0 * i.vs_COLOR0;
    u_xlat1 = log2(_HdrMultiply);
    u_xlat1 = u_xlat1 * 0.416666657;
    u_xlat1 = exp2(u_xlat1);
    u_xlat1 = u_xlat1 * 1.05499995 + -0.0549999997;
    u_xlat1 = max(u_xlat1, 0.0);
    u_xlat16_2.xyz = u_xlat16_0.xyz * ((float3)(u_xlat1));
    u_xlatb1 = 0.0<_HdrMultiply;
    result.xyz = (bool(u_xlatb1)) ? u_xlat16_2.xyz : u_xlat16_0.xyz;
    result.w = min(u_xlat16_0.w, 1.0);
    return result;

}

#elif !defined(SOFTPARTICLES_ON) && !defined(_CFXR_DISSOLVE) && !defined(_CFXR_RADIAL_UV) && !defined(_CFXR_WORLD_SPACE_RING) && !defined(_FADING_ON)
// Original GLES program 6; 
float4 _MainTex_ST;
float _RingTopOffset;
float _SingleChannel;
float _HdrMultiply;
sampler2D _MainTex;
struct A{float4 in_POSITION0:POSITION0;float4 in_COLOR0:COLOR0;float4 in_TEXCOORD0:TEXCOORD0;float4 in_TEXCOORD2:TEXCOORD2;};
struct V{float4 vertex:SV_POSITION;float4 vs_COLOR0:TEXCOORD0;float4 vs_TEXCOORD1:TEXCOORD1;float4 vs_TEXCOORD2:TEXCOORD2;};
V vert(A i){V o=(V)0;
float4 vs_TEXCOORD0;
float2 u_xlat0;
float4 u_xlat1;
float4 u_xlat2;
float u_xlat6;

    u_xlat0.xy = i.in_TEXCOORD0.yy * (-i.in_TEXCOORD0.zw);
    u_xlat1 = i.in_POSITION0.yyyy * transpose(unity_MatrixV)[1];
    u_xlat1 = transpose(unity_MatrixV)[0] * i.in_POSITION0.xxxx + u_xlat1;
    u_xlat1 = transpose(unity_MatrixV)[2] * i.in_POSITION0.zzzz + u_xlat1;
    u_xlat1 = transpose(unity_MatrixV)[3] * i.in_POSITION0.wwww + u_xlat1;
    u_xlat6 = min(i.in_TEXCOORD2.x, i.in_TEXCOORD2.w);
    u_xlat0.xy = u_xlat0.xy * ((float2)(u_xlat6)) + u_xlat1.xy;
    u_xlat2 = u_xlat0.yyyy * transpose(UNITY_MATRIX_P)[1];
    u_xlat2 = transpose(UNITY_MATRIX_P)[0] * u_xlat0.xxxx + u_xlat2;
    u_xlat2 = transpose(UNITY_MATRIX_P)[2] * u_xlat1.zzzz + u_xlat2;
    o.vertex = transpose(UNITY_MATRIX_P)[3] * u_xlat1.wwww + u_xlat2;
    o.vs_COLOR0 = i.in_COLOR0;
    vs_TEXCOORD0 = i.in_TEXCOORD0;
    u_xlat0.x = u_xlat6 / i.in_TEXCOORD2.w;
    u_xlat0.x = (-u_xlat0.x) + 1.0;
    o.vs_TEXCOORD1.x = u_xlat0.x * u_xlat0.x;
    o.vs_TEXCOORD1.z = i.in_TEXCOORD2.y / i.in_TEXCOORD2.w;
    o.vs_TEXCOORD1.y = (-_RingTopOffset) + 1.0;
    o.vs_TEXCOORD1.w = i.in_TEXCOORD2.z;
    u_xlat0.xy = i.in_TEXCOORD0.yy * i.in_TEXCOORD0.zw;
    u_xlat0.xy = ((float2)(u_xlat6)) * u_xlat0.xy;
    u_xlat0.xy = u_xlat0.xy / i.in_TEXCOORD2.ww;
    o.vs_TEXCOORD2.zw = (-u_xlat0.xy) + i.in_TEXCOORD0.zw;
    u_xlat0.x = i.in_TEXCOORD2.z;
    u_xlat0.y = 0.0;
    u_xlat0.xy = u_xlat0.xy + i.in_TEXCOORD0.xy;
    u_xlat0.xy = u_xlat0.xy * _MainTex_ST.xy + _MainTex_ST.zw;
    o.vs_TEXCOORD2.xy = (-u_xlat0.xy) + float2(1.0, 1.0);
    return o;

}
float4 frag(V i):SV_Target{float4 result=0;
float4 u_xlat0;
float4 u_xlat16_0;
float u_xlat1;
float4 u_xlat16_1;
bool u_xlatb1;
float4 u_xlat16_2;
float u_xlat3;
bool u_xlatb3;
float u_xlat6;

    u_xlat0.x = (-i.vs_TEXCOORD1.z) + i.vs_TEXCOORD1.y;
    u_xlat3 = (-u_xlat0.x) + i.vs_TEXCOORD1.y;
    u_xlat3 = float(1.0) / u_xlat3;
    u_xlat6 = dot(i.vs_TEXCOORD2.zw, i.vs_TEXCOORD2.zw);
    u_xlat0.x = (-u_xlat0.x) + u_xlat6;
    u_xlat6 = u_xlat6 + (-i.vs_TEXCOORD1.x);
    u_xlat0.x = u_xlat3 * u_xlat0.x;
    u_xlat0.x = clamp(u_xlat0.x, 0.0, 1.0);
    u_xlat3 = u_xlat0.x * -2.0 + 3.0;
    u_xlat0.x = u_xlat0.x * u_xlat0.x;
    u_xlat0.x = u_xlat0.x * u_xlat3;
    u_xlat3 = float(1.0) / i.vs_TEXCOORD1.z;
    u_xlat3 = u_xlat3 * u_xlat6;
    u_xlat3 = clamp(u_xlat3, 0.0, 1.0);
    u_xlat6 = u_xlat3 * -2.0 + 3.0;
    u_xlat3 = u_xlat3 * u_xlat3;
    u_xlat0.x = u_xlat6 * u_xlat3 + (-u_xlat0.x);
    u_xlat0.x = clamp(u_xlat0.x, 0.0, 1.0);
    u_xlat16_1 = tex2D(_MainTex, i.vs_TEXCOORD2.xy);
    u_xlatb3 = 0.0<_SingleChannel;
    u_xlat16_2.xyz = (bool(u_xlatb3)) ? float3(1.0, 1.0, 1.0) : u_xlat16_1.xyz;
    u_xlat16_2.w = (u_xlatb3) ? u_xlat16_1.x : u_xlat16_1.w;
    u_xlat0 = u_xlat0.xxxx * u_xlat16_2;
    u_xlat16_0 = u_xlat0 * i.vs_COLOR0;
    u_xlat1 = log2(_HdrMultiply);
    u_xlat1 = u_xlat1 * 0.416666657;
    u_xlat1 = exp2(u_xlat1);
    u_xlat1 = u_xlat1 * 1.05499995 + -0.0549999997;
    u_xlat1 = max(u_xlat1, 0.0);
    u_xlat16_2.xyz = u_xlat16_0.xyz * ((float3)(u_xlat1));
    u_xlatb1 = 0.0<_HdrMultiply;
    result.xyz = (bool(u_xlatb1)) ? u_xlat16_2.xyz : u_xlat16_0.xyz;
    result.w = min(u_xlat16_0.w, 1.0);
    return result;

}

#else
// Combination absent from original shipped forward variants.
float4 _MainTex_ST;
float _RingTopOffset;
float _SingleChannel;
float _HdrMultiply;
sampler2D _MainTex;
struct A{float4 in_POSITION0:POSITION0;float4 in_COLOR0:COLOR0;float4 in_TEXCOORD0:TEXCOORD0;float4 in_TEXCOORD2:TEXCOORD2;};
struct V{float4 vertex:SV_POSITION;float4 vs_COLOR0:TEXCOORD0;float4 vs_TEXCOORD1:TEXCOORD1;float4 vs_TEXCOORD2:TEXCOORD2;};
V vert(A i){V o=(V)0;
float4 vs_TEXCOORD0;
float2 u_xlat0;
float4 u_xlat1;
float4 u_xlat2;
float u_xlat6;

    u_xlat0.xy = i.in_TEXCOORD0.yy * (-i.in_TEXCOORD0.zw);
    u_xlat1 = i.in_POSITION0.yyyy * transpose(unity_MatrixV)[1];
    u_xlat1 = transpose(unity_MatrixV)[0] * i.in_POSITION0.xxxx + u_xlat1;
    u_xlat1 = transpose(unity_MatrixV)[2] * i.in_POSITION0.zzzz + u_xlat1;
    u_xlat1 = transpose(unity_MatrixV)[3] * i.in_POSITION0.wwww + u_xlat1;
    u_xlat6 = min(i.in_TEXCOORD2.x, i.in_TEXCOORD2.w);
    u_xlat0.xy = u_xlat0.xy * ((float2)(u_xlat6)) + u_xlat1.xy;
    u_xlat2 = u_xlat0.yyyy * transpose(UNITY_MATRIX_P)[1];
    u_xlat2 = transpose(UNITY_MATRIX_P)[0] * u_xlat0.xxxx + u_xlat2;
    u_xlat2 = transpose(UNITY_MATRIX_P)[2] * u_xlat1.zzzz + u_xlat2;
    o.vertex = transpose(UNITY_MATRIX_P)[3] * u_xlat1.wwww + u_xlat2;
    o.vs_COLOR0 = i.in_COLOR0;
    vs_TEXCOORD0 = i.in_TEXCOORD0;
    u_xlat0.x = u_xlat6 / i.in_TEXCOORD2.w;
    u_xlat0.x = (-u_xlat0.x) + 1.0;
    o.vs_TEXCOORD1.x = u_xlat0.x * u_xlat0.x;
    o.vs_TEXCOORD1.z = i.in_TEXCOORD2.y / i.in_TEXCOORD2.w;
    o.vs_TEXCOORD1.y = (-_RingTopOffset) + 1.0;
    o.vs_TEXCOORD1.w = i.in_TEXCOORD2.z;
    u_xlat0.xy = i.in_TEXCOORD0.yy * i.in_TEXCOORD0.zw;
    u_xlat0.xy = ((float2)(u_xlat6)) * u_xlat0.xy;
    u_xlat0.xy = u_xlat0.xy / i.in_TEXCOORD2.ww;
    o.vs_TEXCOORD2.zw = (-u_xlat0.xy) + i.in_TEXCOORD0.zw;
    u_xlat0.x = i.in_TEXCOORD2.z;
    u_xlat0.y = 0.0;
    u_xlat0.xy = u_xlat0.xy + i.in_TEXCOORD0.xy;
    u_xlat0.xy = u_xlat0.xy * _MainTex_ST.xy + _MainTex_ST.zw;
    o.vs_TEXCOORD2.xy = (-u_xlat0.xy) + float2(1.0, 1.0);
    return o;

}
float4 frag(V i):SV_Target{float4 result=0;
float4 u_xlat0;
float4 u_xlat16_0;
float u_xlat1;
float4 u_xlat16_1;
bool u_xlatb1;
float4 u_xlat16_2;
float u_xlat3;
bool u_xlatb3;
float u_xlat6;

    u_xlat0.x = (-i.vs_TEXCOORD1.z) + i.vs_TEXCOORD1.y;
    u_xlat3 = (-u_xlat0.x) + i.vs_TEXCOORD1.y;
    u_xlat3 = float(1.0) / u_xlat3;
    u_xlat6 = dot(i.vs_TEXCOORD2.zw, i.vs_TEXCOORD2.zw);
    u_xlat0.x = (-u_xlat0.x) + u_xlat6;
    u_xlat6 = u_xlat6 + (-i.vs_TEXCOORD1.x);
    u_xlat0.x = u_xlat3 * u_xlat0.x;
    u_xlat0.x = clamp(u_xlat0.x, 0.0, 1.0);
    u_xlat3 = u_xlat0.x * -2.0 + 3.0;
    u_xlat0.x = u_xlat0.x * u_xlat0.x;
    u_xlat0.x = u_xlat0.x * u_xlat3;
    u_xlat3 = float(1.0) / i.vs_TEXCOORD1.z;
    u_xlat3 = u_xlat3 * u_xlat6;
    u_xlat3 = clamp(u_xlat3, 0.0, 1.0);
    u_xlat6 = u_xlat3 * -2.0 + 3.0;
    u_xlat3 = u_xlat3 * u_xlat3;
    u_xlat0.x = u_xlat6 * u_xlat3 + (-u_xlat0.x);
    u_xlat0.x = clamp(u_xlat0.x, 0.0, 1.0);
    u_xlat16_1 = tex2D(_MainTex, i.vs_TEXCOORD2.xy);
    u_xlatb3 = 0.0<_SingleChannel;
    u_xlat16_2.xyz = (bool(u_xlatb3)) ? float3(1.0, 1.0, 1.0) : u_xlat16_1.xyz;
    u_xlat16_2.w = (u_xlatb3) ? u_xlat16_1.x : u_xlat16_1.w;
    u_xlat0 = u_xlat0.xxxx * u_xlat16_2;
    u_xlat16_0 = u_xlat0 * i.vs_COLOR0;
    u_xlat1 = log2(_HdrMultiply);
    u_xlat1 = u_xlat1 * 0.416666657;
    u_xlat1 = exp2(u_xlat1);
    u_xlat1 = u_xlat1 * 1.05499995 + -0.0549999997;
    u_xlat1 = max(u_xlat1, 0.0);
    u_xlat16_2.xyz = u_xlat16_0.xyz * ((float3)(u_xlat1));
    u_xlatb1 = 0.0<_HdrMultiply;
    result.xyz = (bool(u_xlatb1)) ? u_xlat16_2.xyz : u_xlat16_0.xyz;
    result.w = min(u_xlat16_0.w, 1.0);
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
#pragma shader_feature_local _ _CFXR_DISSOLVE
#pragma shader_feature_local _ _CFXR_RADIAL_UV
#pragma shader_feature_local _ _CFXR_WORLD_SPACE_RING
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
#if defined(SHADOWS_CUBE) && !defined(SHADOWS_DEPTH) && defined(_CFXR_DISSOLVE) && !defined(_CFXR_RADIAL_UV) && defined(_CFXR_WORLD_SPACE_RING)
// Original shadow GLES program 22
float4 _MainTex_ST;
float _RingTopOffset;
float _SingleChannel;
float _InvertDissolveTex;
float _DissolveSmooth;
sampler2D _MainTex;
sampler2D _DissolveTex;
struct A{float4 in_POSITION0:POSITION0;float4 in_COLOR0:COLOR0;float4 in_TEXCOORD0:TEXCOORD0;float4 in_TEXCOORD1:TEXCOORD1;float4 in_TEXCOORD2:TEXCOORD2;float3 in_NORMAL0:NORMAL0;};
struct V{float4 vertex:SV_POSITION;float4 vs_COLOR0:TEXCOORD0;float4 vs_TEXCOORD2:TEXCOORD1;float4 vs_TEXCOORD3:TEXCOORD2;float4 vs_TEXCOORD4:TEXCOORD3;};
V vert(A i){V o=(V)0;
float4 vs_TEXCOORD1;
float4 u_xlat0;
float4 u_xlat1;
float3 u_xlat2;
float3 u_xlat3;
float u_xlat10;
bool u_xlatb10;

    o.vs_COLOR0 = i.in_COLOR0;
    vs_TEXCOORD1 = i.in_TEXCOORD0;
    o.vs_TEXCOORD2.z = i.in_TEXCOORD2.y / i.in_TEXCOORD2.w;
    o.vs_TEXCOORD2.y = (-_RingTopOffset) + 1.0;
    o.vs_TEXCOORD2.w = i.in_TEXCOORD2.z;
    u_xlat0.x = min(i.in_TEXCOORD2.x, i.in_TEXCOORD2.w);
    u_xlat3.x = u_xlat0.x / i.in_TEXCOORD2.w;
    u_xlat3.x = (-u_xlat3.x) + 1.0;
    o.vs_TEXCOORD2.x = u_xlat3.x * u_xlat3.x;
    u_xlat1.x = i.in_TEXCOORD2.z;
    u_xlat1.y = 0.0;
    u_xlat3.xy = u_xlat1.xy + i.in_TEXCOORD0.xy;
    u_xlat3.xy = u_xlat3.xy * _MainTex_ST.xy + _MainTex_ST.zw;
    o.vs_TEXCOORD3.xy = (-u_xlat3.xy) + float2(1.0, 1.0);
    u_xlat3.xy = i.in_TEXCOORD0.yy * i.in_TEXCOORD0.zw;
    u_xlat3.xy = u_xlat0.xx * u_xlat3.xy;
    u_xlat3.xy = u_xlat3.xy / i.in_TEXCOORD2.ww;
    o.vs_TEXCOORD3.zw = (-u_xlat3.xy) + i.in_TEXCOORD0.zw;
    o.vs_TEXCOORD4 = i.in_TEXCOORD1;
    u_xlat3.xyz = i.in_TEXCOORD0.yyy * i.in_NORMAL0.xyz;
    u_xlat0.xyz = (-u_xlat3.xyz) * u_xlat0.xxx + i.in_POSITION0.xyz;
    u_xlat1 = u_xlat0.yyyy * transpose(unity_ObjectToWorld)[1];
    u_xlat1 = transpose(unity_ObjectToWorld)[0] * u_xlat0.xxxx + u_xlat1;
    u_xlat0 = transpose(unity_ObjectToWorld)[2] * u_xlat0.zzzz + u_xlat1;
    u_xlat0 = transpose(unity_ObjectToWorld)[3] * i.in_POSITION0.wwww + u_xlat0;
    u_xlat1.xyz = (-u_xlat0.xyz) * _WorldSpaceLightPos0.www + _WorldSpaceLightPos0.xyz;
    u_xlat10 = dot(u_xlat1.xyz, u_xlat1.xyz);
    u_xlat10 = rsqrt(u_xlat10);
    u_xlat1.xyz = ((float3)(u_xlat10)) * u_xlat1.xyz;
    u_xlat2.x = dot(i.in_NORMAL0.xyz, transpose(unity_WorldToObject)[0].xyz);
    u_xlat2.y = dot(i.in_NORMAL0.xyz, transpose(unity_WorldToObject)[1].xyz);
    u_xlat2.z = dot(i.in_NORMAL0.xyz, transpose(unity_WorldToObject)[2].xyz);
    u_xlat10 = dot(u_xlat2.xyz, u_xlat2.xyz);
    u_xlat10 = rsqrt(u_xlat10);
    u_xlat2.xyz = ((float3)(u_xlat10)) * u_xlat2.xyz;
    u_xlat1.x = dot(u_xlat2.xyz, u_xlat1.xyz);
    u_xlat1.x = (-u_xlat1.x) * u_xlat1.x + 1.0;
    u_xlat1.x = sqrt(u_xlat1.x);
    u_xlat1.x = u_xlat1.x * unity_LightShadowBias.z;
    u_xlat1.xyz = (-u_xlat2.xyz) * u_xlat1.xxx + u_xlat0.xyz;
    u_xlatb10 = unity_LightShadowBias.z!=0.0;
    u_xlat0.xyz = (bool(u_xlatb10)) ? u_xlat1.xyz : u_xlat0.xyz;
    u_xlat1 = u_xlat0.yyyy * transpose(unity_MatrixVP)[1];
    u_xlat1 = transpose(unity_MatrixVP)[0] * u_xlat0.xxxx + u_xlat1;
    u_xlat1 = transpose(unity_MatrixVP)[2] * u_xlat0.zzzz + u_xlat1;
    u_xlat0 = transpose(unity_MatrixVP)[3] * u_xlat0.wwww + u_xlat1;
    u_xlat1.x = LF_ShadowNearClamp(u_xlat0.z,u_xlat0.w);
    u_xlat1.x = (-u_xlat0.z) + u_xlat1.x;
    o.vertex.z = unity_LightShadowBias.y * u_xlat1.x + u_xlat0.z;
    o.vertex.xyw = u_xlat0.xyw;
    return o;

}
float4 frag(V i):SV_Target{float4 result=0;
float u_xlat0;
bool u_xlatb0;
float u_xlat16_1;
float u_xlat2;
float2 u_xlat16_2;
float u_xlat16_3;
float u_xlat4;
float u_xlat16_5;
bool u_xlatb6;
float u_xlat16_7;

    u_xlat0 = (-i.vs_TEXCOORD2.z) + i.vs_TEXCOORD2.y;
    u_xlat2 = (-u_xlat0) + i.vs_TEXCOORD2.y;
    u_xlat2 = float(1.0) / u_xlat2;
    u_xlat4 = dot(i.vs_TEXCOORD3.zw, i.vs_TEXCOORD3.zw);
    u_xlat0 = (-u_xlat0) + u_xlat4;
    u_xlat4 = u_xlat4 + (-i.vs_TEXCOORD2.x);
    u_xlat0 = u_xlat2 * u_xlat0;
    u_xlat0 = clamp(u_xlat0, 0.0, 1.0);
    u_xlat2 = u_xlat0 * -2.0 + 3.0;
    u_xlat0 = u_xlat0 * u_xlat0;
    u_xlat0 = u_xlat0 * u_xlat2;
    u_xlat2 = float(1.0) / i.vs_TEXCOORD2.z;
    u_xlat2 = u_xlat2 * u_xlat4;
    u_xlat2 = clamp(u_xlat2, 0.0, 1.0);
    u_xlat4 = u_xlat2 * -2.0 + 3.0;
    u_xlat2 = u_xlat2 * u_xlat2;
    u_xlat0 = u_xlat4 * u_xlat2 + (-u_xlat0);
    u_xlat0 = clamp(u_xlat0, 0.0, 1.0);
    u_xlat16_2.xy = tex2D(_MainTex, i.vs_TEXCOORD3.xy).xw;
    u_xlatb6 = 0.0<_SingleChannel;
    u_xlat16_1 = (u_xlatb6) ? u_xlat16_2.x : u_xlat16_2.y;
    u_xlat0 = u_xlat0 * u_xlat16_1;
    u_xlat16_1 = u_xlat0 * i.vs_COLOR0.w;
    u_xlatb0 = 0.0>=_InvertDissolveTex;
    u_xlat16_2.x = tex2D(_DissolveTex, i.vs_TEXCOORD3.xy).x;
    u_xlat16_3 = (-u_xlat16_2.x) + 1.0;
    u_xlat16_3 = (u_xlatb0) ? u_xlat16_3 : u_xlat16_2.x;
    u_xlat16_5 = u_xlat16_3 + _DissolveSmooth;
    u_xlat16_3 = u_xlat16_3 + (-_DissolveSmooth);
    u_xlat16_5 = (-u_xlat16_3) + u_xlat16_5;
    u_xlat16_5 = float(1.0) / u_xlat16_5;
    u_xlat16_7 = _DissolveSmooth * 2.0 + 1.0;
    u_xlat16_7 = i.vs_TEXCOORD4.x * u_xlat16_7 + (-_DissolveSmooth);
    u_xlat16_3 = (-u_xlat16_3) + u_xlat16_7;
    u_xlat16_3 = u_xlat16_5 * u_xlat16_3;
    u_xlat16_3 = clamp(u_xlat16_3, 0.0, 1.0);
    u_xlat16_5 = u_xlat16_3 * -2.0 + 3.0;
    u_xlat16_3 = u_xlat16_3 * u_xlat16_3;
    u_xlat16_3 = u_xlat16_3 * u_xlat16_5;
    u_xlat16_1 = u_xlat16_3 * u_xlat16_1;
    u_xlat16_1 = min(u_xlat16_1, 1.0);
    u_xlat16_1 = u_xlat16_1 + -0.00999999978;
    u_xlatb0 = u_xlat16_1<0.0;
    if(u_xlatb0){discard;}
    result = float4(0.0, 0.0, 0.0, 0.0);
    return result;

}

#elif !defined(SHADOWS_CUBE) && defined(SHADOWS_DEPTH) && defined(_CFXR_DISSOLVE) && !defined(_CFXR_RADIAL_UV) && defined(_CFXR_WORLD_SPACE_RING)
// Original shadow GLES program 26
float4 _MainTex_ST;
float _RingTopOffset;
float _SingleChannel;
float _InvertDissolveTex;
float _DissolveSmooth;
sampler2D _MainTex;
sampler2D _DissolveTex;
struct A{float4 in_POSITION0:POSITION0;float4 in_COLOR0:COLOR0;float4 in_TEXCOORD0:TEXCOORD0;float4 in_TEXCOORD1:TEXCOORD1;float4 in_TEXCOORD2:TEXCOORD2;float3 in_NORMAL0:NORMAL0;};
struct V{float4 vertex:SV_POSITION;float4 vs_COLOR0:TEXCOORD0;float4 vs_TEXCOORD2:TEXCOORD1;float4 vs_TEXCOORD3:TEXCOORD2;float4 vs_TEXCOORD4:TEXCOORD3;};
V vert(A i){V o=(V)0;
float4 vs_TEXCOORD1;
float4 u_xlat0;
float4 u_xlat1;
float3 u_xlat2;
float3 u_xlat3;
float u_xlat6;
float u_xlat10;
bool u_xlatb10;

    o.vs_COLOR0 = i.in_COLOR0;
    vs_TEXCOORD1 = i.in_TEXCOORD0;
    o.vs_TEXCOORD2.z = i.in_TEXCOORD2.y / i.in_TEXCOORD2.w;
    o.vs_TEXCOORD2.y = (-_RingTopOffset) + 1.0;
    o.vs_TEXCOORD2.w = i.in_TEXCOORD2.z;
    u_xlat0.x = min(i.in_TEXCOORD2.x, i.in_TEXCOORD2.w);
    u_xlat3.x = u_xlat0.x / i.in_TEXCOORD2.w;
    u_xlat3.x = (-u_xlat3.x) + 1.0;
    o.vs_TEXCOORD2.x = u_xlat3.x * u_xlat3.x;
    u_xlat1.x = i.in_TEXCOORD2.z;
    u_xlat1.y = 0.0;
    u_xlat3.xy = u_xlat1.xy + i.in_TEXCOORD0.xy;
    u_xlat3.xy = u_xlat3.xy * _MainTex_ST.xy + _MainTex_ST.zw;
    o.vs_TEXCOORD3.xy = (-u_xlat3.xy) + float2(1.0, 1.0);
    u_xlat3.xy = i.in_TEXCOORD0.yy * i.in_TEXCOORD0.zw;
    u_xlat3.xy = u_xlat0.xx * u_xlat3.xy;
    u_xlat3.xy = u_xlat3.xy / i.in_TEXCOORD2.ww;
    o.vs_TEXCOORD3.zw = (-u_xlat3.xy) + i.in_TEXCOORD0.zw;
    o.vs_TEXCOORD4 = i.in_TEXCOORD1;
    u_xlat3.xyz = i.in_TEXCOORD0.yyy * i.in_NORMAL0.xyz;
    u_xlat0.xyz = (-u_xlat3.xyz) * u_xlat0.xxx + i.in_POSITION0.xyz;
    u_xlat1 = u_xlat0.yyyy * transpose(unity_ObjectToWorld)[1];
    u_xlat1 = transpose(unity_ObjectToWorld)[0] * u_xlat0.xxxx + u_xlat1;
    u_xlat0 = transpose(unity_ObjectToWorld)[2] * u_xlat0.zzzz + u_xlat1;
    u_xlat0 = transpose(unity_ObjectToWorld)[3] * i.in_POSITION0.wwww + u_xlat0;
    u_xlat1.xyz = (-u_xlat0.xyz) * _WorldSpaceLightPos0.www + _WorldSpaceLightPos0.xyz;
    u_xlat10 = dot(u_xlat1.xyz, u_xlat1.xyz);
    u_xlat10 = rsqrt(u_xlat10);
    u_xlat1.xyz = ((float3)(u_xlat10)) * u_xlat1.xyz;
    u_xlat2.x = dot(i.in_NORMAL0.xyz, transpose(unity_WorldToObject)[0].xyz);
    u_xlat2.y = dot(i.in_NORMAL0.xyz, transpose(unity_WorldToObject)[1].xyz);
    u_xlat2.z = dot(i.in_NORMAL0.xyz, transpose(unity_WorldToObject)[2].xyz);
    u_xlat10 = dot(u_xlat2.xyz, u_xlat2.xyz);
    u_xlat10 = rsqrt(u_xlat10);
    u_xlat2.xyz = ((float3)(u_xlat10)) * u_xlat2.xyz;
    u_xlat1.x = dot(u_xlat2.xyz, u_xlat1.xyz);
    u_xlat1.x = (-u_xlat1.x) * u_xlat1.x + 1.0;
    u_xlat1.x = sqrt(u_xlat1.x);
    u_xlat1.x = u_xlat1.x * unity_LightShadowBias.z;
    u_xlat1.xyz = (-u_xlat2.xyz) * u_xlat1.xxx + u_xlat0.xyz;
    u_xlatb10 = unity_LightShadowBias.z!=0.0;
    u_xlat0.xyz = (bool(u_xlatb10)) ? u_xlat1.xyz : u_xlat0.xyz;
    u_xlat1 = u_xlat0.yyyy * transpose(unity_MatrixVP)[1];
    u_xlat1 = transpose(unity_MatrixVP)[0] * u_xlat0.xxxx + u_xlat1;
    u_xlat1 = transpose(unity_MatrixVP)[2] * u_xlat0.zzzz + u_xlat1;
    u_xlat0 = transpose(unity_MatrixVP)[3] * u_xlat0.wwww + u_xlat1;
    u_xlat1.x = LF_ShadowBiasDelta(unity_LightShadowBias.x / u_xlat0.w);
    u_xlat6 = u_xlat0.z + u_xlat1.x;
    u_xlat1.x = LF_ShadowNearClamp(u_xlat6,u_xlat0.w);
    o.vertex.xyw = u_xlat0.xyw;
    u_xlat0.x = (-u_xlat6) + u_xlat1.x;
    o.vertex.z = unity_LightShadowBias.y * u_xlat0.x + u_xlat6;
    return o;

}
float4 frag(V i):SV_Target{float4 result=0;
float u_xlat0;
bool u_xlatb0;
float u_xlat16_1;
float u_xlat2;
float2 u_xlat16_2;
float u_xlat16_3;
float u_xlat4;
float u_xlat16_5;
bool u_xlatb6;
float u_xlat16_7;

    u_xlat0 = (-i.vs_TEXCOORD2.z) + i.vs_TEXCOORD2.y;
    u_xlat2 = (-u_xlat0) + i.vs_TEXCOORD2.y;
    u_xlat2 = float(1.0) / u_xlat2;
    u_xlat4 = dot(i.vs_TEXCOORD3.zw, i.vs_TEXCOORD3.zw);
    u_xlat0 = (-u_xlat0) + u_xlat4;
    u_xlat4 = u_xlat4 + (-i.vs_TEXCOORD2.x);
    u_xlat0 = u_xlat2 * u_xlat0;
    u_xlat0 = clamp(u_xlat0, 0.0, 1.0);
    u_xlat2 = u_xlat0 * -2.0 + 3.0;
    u_xlat0 = u_xlat0 * u_xlat0;
    u_xlat0 = u_xlat0 * u_xlat2;
    u_xlat2 = float(1.0) / i.vs_TEXCOORD2.z;
    u_xlat2 = u_xlat2 * u_xlat4;
    u_xlat2 = clamp(u_xlat2, 0.0, 1.0);
    u_xlat4 = u_xlat2 * -2.0 + 3.0;
    u_xlat2 = u_xlat2 * u_xlat2;
    u_xlat0 = u_xlat4 * u_xlat2 + (-u_xlat0);
    u_xlat0 = clamp(u_xlat0, 0.0, 1.0);
    u_xlat16_2.xy = tex2D(_MainTex, i.vs_TEXCOORD3.xy).xw;
    u_xlatb6 = 0.0<_SingleChannel;
    u_xlat16_1 = (u_xlatb6) ? u_xlat16_2.x : u_xlat16_2.y;
    u_xlat0 = u_xlat0 * u_xlat16_1;
    u_xlat16_1 = u_xlat0 * i.vs_COLOR0.w;
    u_xlatb0 = 0.0>=_InvertDissolveTex;
    u_xlat16_2.x = tex2D(_DissolveTex, i.vs_TEXCOORD3.xy).x;
    u_xlat16_3 = (-u_xlat16_2.x) + 1.0;
    u_xlat16_3 = (u_xlatb0) ? u_xlat16_3 : u_xlat16_2.x;
    u_xlat16_5 = u_xlat16_3 + _DissolveSmooth;
    u_xlat16_3 = u_xlat16_3 + (-_DissolveSmooth);
    u_xlat16_5 = (-u_xlat16_3) + u_xlat16_5;
    u_xlat16_5 = float(1.0) / u_xlat16_5;
    u_xlat16_7 = _DissolveSmooth * 2.0 + 1.0;
    u_xlat16_7 = i.vs_TEXCOORD4.x * u_xlat16_7 + (-_DissolveSmooth);
    u_xlat16_3 = (-u_xlat16_3) + u_xlat16_7;
    u_xlat16_3 = u_xlat16_5 * u_xlat16_3;
    u_xlat16_3 = clamp(u_xlat16_3, 0.0, 1.0);
    u_xlat16_5 = u_xlat16_3 * -2.0 + 3.0;
    u_xlat16_3 = u_xlat16_3 * u_xlat16_3;
    u_xlat16_3 = u_xlat16_3 * u_xlat16_5;
    u_xlat16_1 = u_xlat16_3 * u_xlat16_1;
    u_xlat16_1 = min(u_xlat16_1, 1.0);
    u_xlat16_1 = u_xlat16_1 + -0.00999999978;
    u_xlatb0 = u_xlat16_1<0.0;
    if(u_xlatb0){discard;}
    result = float4(0.0, 0.0, 0.0, 0.0);
    return result;

}

#elif defined(SHADOWS_CUBE) && !defined(SHADOWS_DEPTH) && !defined(_CFXR_DISSOLVE) && defined(_CFXR_RADIAL_UV) && !defined(_CFXR_WORLD_SPACE_RING)
// Original shadow GLES program 20
float4 _MainTex_ST;
float _RingTopOffset;
float _SingleChannel;
sampler2D _MainTex;
struct A{float4 in_POSITION0:POSITION0;float4 in_COLOR0:COLOR0;float4 in_TEXCOORD0:TEXCOORD0;float4 in_TEXCOORD2:TEXCOORD2;float3 in_NORMAL0:NORMAL0;};
struct V{float4 vertex:SV_POSITION;float4 vs_COLOR0:TEXCOORD0;float4 vs_TEXCOORD2:TEXCOORD1;float4 vs_TEXCOORD3:TEXCOORD2;};
V vert(A i){V o=(V)0;
float4 vs_TEXCOORD1;
float4 u_xlat0;
float4 u_xlat1;
float4 u_xlat2;
float2 u_xlat3;
float u_xlat9;
bool u_xlatb9;

    o.vs_COLOR0 = i.in_COLOR0;
    vs_TEXCOORD1 = i.in_TEXCOORD0;
    u_xlat0.x = min(i.in_TEXCOORD2.x, i.in_TEXCOORD2.w);
    u_xlat3.x = u_xlat0.x / i.in_TEXCOORD2.w;
    u_xlat3.x = (-u_xlat3.x) + 1.0;
    o.vs_TEXCOORD2.x = u_xlat3.x * u_xlat3.x;
    o.vs_TEXCOORD2.z = i.in_TEXCOORD2.y / i.in_TEXCOORD2.w;
    o.vs_TEXCOORD2.y = (-_RingTopOffset) + 1.0;
    o.vs_TEXCOORD2.w = i.in_TEXCOORD2.z;
    u_xlat3.xy = i.in_TEXCOORD0.yy * i.in_TEXCOORD0.zw;
    u_xlat0.xy = u_xlat0.xx * u_xlat3.xy;
    u_xlat0.xy = u_xlat0.xy / i.in_TEXCOORD2.ww;
    o.vs_TEXCOORD3.zw = (-u_xlat0.xy) + i.in_TEXCOORD0.zw;
    u_xlat0.x = i.in_TEXCOORD2.z;
    u_xlat0.y = 0.0;
    u_xlat0.xy = u_xlat0.xy + i.in_TEXCOORD0.xy;
    u_xlat0.xy = u_xlat0.xy * _MainTex_ST.xy + _MainTex_ST.zw;
    o.vs_TEXCOORD3.xy = (-u_xlat0.xy) + float2(1.0, 1.0);
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
float2 u_xlat16_0;
bool u_xlatb0;
float u_xlat1;
float u_xlat16_2;
float u_xlat3;
bool u_xlatb3;
float u_xlat4;
float2 u_xlat6;
bool u_xlatb6;
float u_xlat9;
bool u_xlatb9;

    u_xlat0.x = max(abs(i.vs_TEXCOORD3.w), abs(i.vs_TEXCOORD3.z));
    u_xlat0.x = float(1.0) / u_xlat0.x;
    u_xlat3 = min(abs(i.vs_TEXCOORD3.w), abs(i.vs_TEXCOORD3.z));
    u_xlat0.x = u_xlat0.x * u_xlat3;
    u_xlat3 = u_xlat0.x * u_xlat0.x;
    u_xlat6.x = u_xlat3 * 0.0208350997 + -0.0851330012;
    u_xlat6.x = u_xlat3 * u_xlat6.x + 0.180141002;
    u_xlat6.x = u_xlat3 * u_xlat6.x + -0.330299497;
    u_xlat3 = u_xlat3 * u_xlat6.x + 0.999866009;
    u_xlat6.x = u_xlat3 * u_xlat0.x;
    u_xlat6.x = u_xlat6.x * -2.0 + 1.57079637;
    u_xlatb9 = abs(i.vs_TEXCOORD3.w)<abs(i.vs_TEXCOORD3.z);
    u_xlat6.x = u_xlatb9 ? u_xlat6.x : float(0.0);
    u_xlat0.x = u_xlat0.x * u_xlat3 + u_xlat6.x;
    u_xlatb3 = i.vs_TEXCOORD3.w<(-i.vs_TEXCOORD3.w);
    u_xlat3 = u_xlatb3 ? -3.14159274 : float(0.0);
    u_xlat0.x = u_xlat3 + u_xlat0.x;
    u_xlat3 = min(i.vs_TEXCOORD3.w, i.vs_TEXCOORD3.z);
    u_xlatb3 = u_xlat3<(-u_xlat3);
    u_xlat6.x = max(i.vs_TEXCOORD3.w, i.vs_TEXCOORD3.z);
    u_xlatb6 = u_xlat6.x>=(-u_xlat6.x);
    u_xlatb3 = u_xlatb6 && u_xlatb3;
    u_xlat0.x = (u_xlatb3) ? (-u_xlat0.x) : u_xlat0.x;
    u_xlat0.x = u_xlat0.x * 0.159154937 + 0.730000019;
    u_xlat0.x = u_xlat0.x + (-i.vs_TEXCOORD2.w);
    u_xlat6.xy = (-i.vs_TEXCOORD2.zx) + i.vs_TEXCOORD2.yy;
    u_xlat1 = float(1.0) / u_xlat6.y;
    u_xlat9 = i.vs_TEXCOORD2.x / u_xlat6.y;
    u_xlat4 = dot(i.vs_TEXCOORD3.zw, i.vs_TEXCOORD3.zw);
    u_xlat9 = u_xlat4 * u_xlat1 + (-u_xlat9);
    u_xlat0.y = u_xlat9 * 0.899999976 + 0.0799999833;
    u_xlat0.xy = u_xlat0.xy * _MainTex_ST.xy + _MainTex_ST.zw;
    u_xlat9 = ddx(i.vs_TEXCOORD3.x);
    u_xlat16_0.xy = tex2Dgrad(_MainTex, u_xlat0.xy, ((float4)(((float4)(u_xlat9)))).xy, ((float4)(((float4)(u_xlat9)))).xy).xw;
    u_xlatb9 = 0.0<_SingleChannel;
    u_xlat16_2 = (u_xlatb9) ? u_xlat16_0.x : u_xlat16_0.y;
    u_xlat0.x = (-u_xlat6.x) + u_xlat4;
    u_xlat3 = u_xlat4 + (-i.vs_TEXCOORD2.x);
    u_xlat6.x = (-u_xlat6.x) + i.vs_TEXCOORD2.y;
    u_xlat6.x = float(1.0) / u_xlat6.x;
    u_xlat0.x = u_xlat6.x * u_xlat0.x;
    u_xlat0.x = clamp(u_xlat0.x, 0.0, 1.0);
    u_xlat6.x = u_xlat0.x * -2.0 + 3.0;
    u_xlat0.x = u_xlat0.x * u_xlat0.x;
    u_xlat0.x = u_xlat0.x * u_xlat6.x;
    u_xlat6.x = float(1.0) / i.vs_TEXCOORD2.z;
    u_xlat3 = u_xlat6.x * u_xlat3;
    u_xlat3 = clamp(u_xlat3, 0.0, 1.0);
    u_xlat6.x = u_xlat3 * -2.0 + 3.0;
    u_xlat3 = u_xlat3 * u_xlat3;
    u_xlat0.x = u_xlat6.x * u_xlat3 + (-u_xlat0.x);
    u_xlat0.x = clamp(u_xlat0.x, 0.0, 1.0);
    u_xlat0.x = u_xlat0.x * u_xlat16_2;
    u_xlat16_2 = u_xlat0.x * i.vs_COLOR0.w;
    u_xlat16_2 = min(u_xlat16_2, 1.0);
    u_xlat16_2 = u_xlat16_2 + -0.00999999978;
    u_xlatb0 = u_xlat16_2<0.0;
    if(u_xlatb0){discard;}
    result = float4(0.0, 0.0, 0.0, 0.0);
    return result;

}

#elif defined(SHADOWS_CUBE) && !defined(SHADOWS_DEPTH) && !defined(_CFXR_DISSOLVE) && !defined(_CFXR_RADIAL_UV) && defined(_CFXR_WORLD_SPACE_RING)
// Original shadow GLES program 21
float4 _MainTex_ST;
float _RingTopOffset;
float _SingleChannel;
sampler2D _MainTex;
struct A{float4 in_POSITION0:POSITION0;float4 in_COLOR0:COLOR0;float4 in_TEXCOORD0:TEXCOORD0;float4 in_TEXCOORD2:TEXCOORD2;float3 in_NORMAL0:NORMAL0;};
struct V{float4 vertex:SV_POSITION;float4 vs_COLOR0:TEXCOORD0;float4 vs_TEXCOORD2:TEXCOORD1;float4 vs_TEXCOORD3:TEXCOORD2;};
V vert(A i){V o=(V)0;
float4 vs_TEXCOORD1;
float4 u_xlat0;
float4 u_xlat1;
float3 u_xlat2;
float3 u_xlat3;
float u_xlat10;
bool u_xlatb10;

    o.vs_COLOR0 = i.in_COLOR0;
    vs_TEXCOORD1 = i.in_TEXCOORD0;
    o.vs_TEXCOORD2.z = i.in_TEXCOORD2.y / i.in_TEXCOORD2.w;
    o.vs_TEXCOORD2.y = (-_RingTopOffset) + 1.0;
    o.vs_TEXCOORD2.w = i.in_TEXCOORD2.z;
    u_xlat0.x = min(i.in_TEXCOORD2.x, i.in_TEXCOORD2.w);
    u_xlat3.x = u_xlat0.x / i.in_TEXCOORD2.w;
    u_xlat3.x = (-u_xlat3.x) + 1.0;
    o.vs_TEXCOORD2.x = u_xlat3.x * u_xlat3.x;
    u_xlat1.x = i.in_TEXCOORD2.z;
    u_xlat1.y = 0.0;
    u_xlat3.xy = u_xlat1.xy + i.in_TEXCOORD0.xy;
    u_xlat3.xy = u_xlat3.xy * _MainTex_ST.xy + _MainTex_ST.zw;
    o.vs_TEXCOORD3.xy = (-u_xlat3.xy) + float2(1.0, 1.0);
    u_xlat3.xy = i.in_TEXCOORD0.yy * i.in_TEXCOORD0.zw;
    u_xlat3.xy = u_xlat0.xx * u_xlat3.xy;
    u_xlat3.xy = u_xlat3.xy / i.in_TEXCOORD2.ww;
    o.vs_TEXCOORD3.zw = (-u_xlat3.xy) + i.in_TEXCOORD0.zw;
    u_xlat3.xyz = i.in_TEXCOORD0.yyy * i.in_NORMAL0.xyz;
    u_xlat0.xyz = (-u_xlat3.xyz) * u_xlat0.xxx + i.in_POSITION0.xyz;
    u_xlat1 = u_xlat0.yyyy * transpose(unity_ObjectToWorld)[1];
    u_xlat1 = transpose(unity_ObjectToWorld)[0] * u_xlat0.xxxx + u_xlat1;
    u_xlat0 = transpose(unity_ObjectToWorld)[2] * u_xlat0.zzzz + u_xlat1;
    u_xlat0 = transpose(unity_ObjectToWorld)[3] * i.in_POSITION0.wwww + u_xlat0;
    u_xlat1.xyz = (-u_xlat0.xyz) * _WorldSpaceLightPos0.www + _WorldSpaceLightPos0.xyz;
    u_xlat10 = dot(u_xlat1.xyz, u_xlat1.xyz);
    u_xlat10 = rsqrt(u_xlat10);
    u_xlat1.xyz = ((float3)(u_xlat10)) * u_xlat1.xyz;
    u_xlat2.x = dot(i.in_NORMAL0.xyz, transpose(unity_WorldToObject)[0].xyz);
    u_xlat2.y = dot(i.in_NORMAL0.xyz, transpose(unity_WorldToObject)[1].xyz);
    u_xlat2.z = dot(i.in_NORMAL0.xyz, transpose(unity_WorldToObject)[2].xyz);
    u_xlat10 = dot(u_xlat2.xyz, u_xlat2.xyz);
    u_xlat10 = rsqrt(u_xlat10);
    u_xlat2.xyz = ((float3)(u_xlat10)) * u_xlat2.xyz;
    u_xlat1.x = dot(u_xlat2.xyz, u_xlat1.xyz);
    u_xlat1.x = (-u_xlat1.x) * u_xlat1.x + 1.0;
    u_xlat1.x = sqrt(u_xlat1.x);
    u_xlat1.x = u_xlat1.x * unity_LightShadowBias.z;
    u_xlat1.xyz = (-u_xlat2.xyz) * u_xlat1.xxx + u_xlat0.xyz;
    u_xlatb10 = unity_LightShadowBias.z!=0.0;
    u_xlat0.xyz = (bool(u_xlatb10)) ? u_xlat1.xyz : u_xlat0.xyz;
    u_xlat1 = u_xlat0.yyyy * transpose(unity_MatrixVP)[1];
    u_xlat1 = transpose(unity_MatrixVP)[0] * u_xlat0.xxxx + u_xlat1;
    u_xlat1 = transpose(unity_MatrixVP)[2] * u_xlat0.zzzz + u_xlat1;
    u_xlat0 = transpose(unity_MatrixVP)[3] * u_xlat0.wwww + u_xlat1;
    u_xlat1.x = LF_ShadowNearClamp(u_xlat0.z,u_xlat0.w);
    u_xlat1.x = (-u_xlat0.z) + u_xlat1.x;
    o.vertex.z = unity_LightShadowBias.y * u_xlat1.x + u_xlat0.z;
    o.vertex.xyw = u_xlat0.xyw;
    return o;

}
float4 frag(V i):SV_Target{float4 result=0;
float u_xlat0;
bool u_xlatb0;
float u_xlat16_1;
float u_xlat2;
float2 u_xlat16_2;
float u_xlat4;
bool u_xlatb6;

    u_xlat0 = (-i.vs_TEXCOORD2.z) + i.vs_TEXCOORD2.y;
    u_xlat2 = (-u_xlat0) + i.vs_TEXCOORD2.y;
    u_xlat2 = float(1.0) / u_xlat2;
    u_xlat4 = dot(i.vs_TEXCOORD3.zw, i.vs_TEXCOORD3.zw);
    u_xlat0 = (-u_xlat0) + u_xlat4;
    u_xlat4 = u_xlat4 + (-i.vs_TEXCOORD2.x);
    u_xlat0 = u_xlat2 * u_xlat0;
    u_xlat0 = clamp(u_xlat0, 0.0, 1.0);
    u_xlat2 = u_xlat0 * -2.0 + 3.0;
    u_xlat0 = u_xlat0 * u_xlat0;
    u_xlat0 = u_xlat0 * u_xlat2;
    u_xlat2 = float(1.0) / i.vs_TEXCOORD2.z;
    u_xlat2 = u_xlat2 * u_xlat4;
    u_xlat2 = clamp(u_xlat2, 0.0, 1.0);
    u_xlat4 = u_xlat2 * -2.0 + 3.0;
    u_xlat2 = u_xlat2 * u_xlat2;
    u_xlat0 = u_xlat4 * u_xlat2 + (-u_xlat0);
    u_xlat0 = clamp(u_xlat0, 0.0, 1.0);
    u_xlat16_2.xy = tex2D(_MainTex, i.vs_TEXCOORD3.xy).xw;
    u_xlatb6 = 0.0<_SingleChannel;
    u_xlat16_1 = (u_xlatb6) ? u_xlat16_2.x : u_xlat16_2.y;
    u_xlat0 = u_xlat0 * u_xlat16_1;
    u_xlat16_1 = u_xlat0 * i.vs_COLOR0.w;
    u_xlat16_1 = min(u_xlat16_1, 1.0);
    u_xlat16_1 = u_xlat16_1 + -0.00999999978;
    u_xlatb0 = u_xlat16_1<0.0;
    if(u_xlatb0){discard;}
    result = float4(0.0, 0.0, 0.0, 0.0);
    return result;

}

#elif !defined(SHADOWS_CUBE) && defined(SHADOWS_DEPTH) && !defined(_CFXR_DISSOLVE) && defined(_CFXR_RADIAL_UV) && !defined(_CFXR_WORLD_SPACE_RING)
// Original shadow GLES program 24
float4 _MainTex_ST;
float _RingTopOffset;
float _SingleChannel;
sampler2D _MainTex;
struct A{float4 in_POSITION0:POSITION0;float4 in_COLOR0:COLOR0;float4 in_TEXCOORD0:TEXCOORD0;float4 in_TEXCOORD2:TEXCOORD2;float3 in_NORMAL0:NORMAL0;};
struct V{float4 vertex:SV_POSITION;float4 vs_COLOR0:TEXCOORD0;float4 vs_TEXCOORD2:TEXCOORD1;float4 vs_TEXCOORD3:TEXCOORD2;};
V vert(A i){V o=(V)0;
float4 vs_TEXCOORD1;
float4 u_xlat0;
float4 u_xlat1;
float4 u_xlat2;
float2 u_xlat3;
float u_xlat6;
float u_xlat9;
bool u_xlatb9;

    o.vs_COLOR0 = i.in_COLOR0;
    vs_TEXCOORD1 = i.in_TEXCOORD0;
    u_xlat0.x = min(i.in_TEXCOORD2.x, i.in_TEXCOORD2.w);
    u_xlat3.x = u_xlat0.x / i.in_TEXCOORD2.w;
    u_xlat3.x = (-u_xlat3.x) + 1.0;
    o.vs_TEXCOORD2.x = u_xlat3.x * u_xlat3.x;
    o.vs_TEXCOORD2.z = i.in_TEXCOORD2.y / i.in_TEXCOORD2.w;
    o.vs_TEXCOORD2.y = (-_RingTopOffset) + 1.0;
    o.vs_TEXCOORD2.w = i.in_TEXCOORD2.z;
    u_xlat3.xy = i.in_TEXCOORD0.yy * i.in_TEXCOORD0.zw;
    u_xlat0.xy = u_xlat0.xx * u_xlat3.xy;
    u_xlat0.xy = u_xlat0.xy / i.in_TEXCOORD2.ww;
    o.vs_TEXCOORD3.zw = (-u_xlat0.xy) + i.in_TEXCOORD0.zw;
    u_xlat0.x = i.in_TEXCOORD2.z;
    u_xlat0.y = 0.0;
    u_xlat0.xy = u_xlat0.xy + i.in_TEXCOORD0.xy;
    u_xlat0.xy = u_xlat0.xy * _MainTex_ST.xy + _MainTex_ST.zw;
    o.vs_TEXCOORD3.xy = (-u_xlat0.xy) + float2(1.0, 1.0);
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
float2 u_xlat16_0;
bool u_xlatb0;
float u_xlat1;
float u_xlat16_2;
float u_xlat3;
bool u_xlatb3;
float u_xlat4;
float2 u_xlat6;
bool u_xlatb6;
float u_xlat9;
bool u_xlatb9;

    u_xlat0.x = max(abs(i.vs_TEXCOORD3.w), abs(i.vs_TEXCOORD3.z));
    u_xlat0.x = float(1.0) / u_xlat0.x;
    u_xlat3 = min(abs(i.vs_TEXCOORD3.w), abs(i.vs_TEXCOORD3.z));
    u_xlat0.x = u_xlat0.x * u_xlat3;
    u_xlat3 = u_xlat0.x * u_xlat0.x;
    u_xlat6.x = u_xlat3 * 0.0208350997 + -0.0851330012;
    u_xlat6.x = u_xlat3 * u_xlat6.x + 0.180141002;
    u_xlat6.x = u_xlat3 * u_xlat6.x + -0.330299497;
    u_xlat3 = u_xlat3 * u_xlat6.x + 0.999866009;
    u_xlat6.x = u_xlat3 * u_xlat0.x;
    u_xlat6.x = u_xlat6.x * -2.0 + 1.57079637;
    u_xlatb9 = abs(i.vs_TEXCOORD3.w)<abs(i.vs_TEXCOORD3.z);
    u_xlat6.x = u_xlatb9 ? u_xlat6.x : float(0.0);
    u_xlat0.x = u_xlat0.x * u_xlat3 + u_xlat6.x;
    u_xlatb3 = i.vs_TEXCOORD3.w<(-i.vs_TEXCOORD3.w);
    u_xlat3 = u_xlatb3 ? -3.14159274 : float(0.0);
    u_xlat0.x = u_xlat3 + u_xlat0.x;
    u_xlat3 = min(i.vs_TEXCOORD3.w, i.vs_TEXCOORD3.z);
    u_xlatb3 = u_xlat3<(-u_xlat3);
    u_xlat6.x = max(i.vs_TEXCOORD3.w, i.vs_TEXCOORD3.z);
    u_xlatb6 = u_xlat6.x>=(-u_xlat6.x);
    u_xlatb3 = u_xlatb6 && u_xlatb3;
    u_xlat0.x = (u_xlatb3) ? (-u_xlat0.x) : u_xlat0.x;
    u_xlat0.x = u_xlat0.x * 0.159154937 + 0.730000019;
    u_xlat0.x = u_xlat0.x + (-i.vs_TEXCOORD2.w);
    u_xlat6.xy = (-i.vs_TEXCOORD2.zx) + i.vs_TEXCOORD2.yy;
    u_xlat1 = float(1.0) / u_xlat6.y;
    u_xlat9 = i.vs_TEXCOORD2.x / u_xlat6.y;
    u_xlat4 = dot(i.vs_TEXCOORD3.zw, i.vs_TEXCOORD3.zw);
    u_xlat9 = u_xlat4 * u_xlat1 + (-u_xlat9);
    u_xlat0.y = u_xlat9 * 0.899999976 + 0.0799999833;
    u_xlat0.xy = u_xlat0.xy * _MainTex_ST.xy + _MainTex_ST.zw;
    u_xlat9 = ddx(i.vs_TEXCOORD3.x);
    u_xlat16_0.xy = tex2Dgrad(_MainTex, u_xlat0.xy, ((float4)(((float4)(u_xlat9)))).xy, ((float4)(((float4)(u_xlat9)))).xy).xw;
    u_xlatb9 = 0.0<_SingleChannel;
    u_xlat16_2 = (u_xlatb9) ? u_xlat16_0.x : u_xlat16_0.y;
    u_xlat0.x = (-u_xlat6.x) + u_xlat4;
    u_xlat3 = u_xlat4 + (-i.vs_TEXCOORD2.x);
    u_xlat6.x = (-u_xlat6.x) + i.vs_TEXCOORD2.y;
    u_xlat6.x = float(1.0) / u_xlat6.x;
    u_xlat0.x = u_xlat6.x * u_xlat0.x;
    u_xlat0.x = clamp(u_xlat0.x, 0.0, 1.0);
    u_xlat6.x = u_xlat0.x * -2.0 + 3.0;
    u_xlat0.x = u_xlat0.x * u_xlat0.x;
    u_xlat0.x = u_xlat0.x * u_xlat6.x;
    u_xlat6.x = float(1.0) / i.vs_TEXCOORD2.z;
    u_xlat3 = u_xlat6.x * u_xlat3;
    u_xlat3 = clamp(u_xlat3, 0.0, 1.0);
    u_xlat6.x = u_xlat3 * -2.0 + 3.0;
    u_xlat3 = u_xlat3 * u_xlat3;
    u_xlat0.x = u_xlat6.x * u_xlat3 + (-u_xlat0.x);
    u_xlat0.x = clamp(u_xlat0.x, 0.0, 1.0);
    u_xlat0.x = u_xlat0.x * u_xlat16_2;
    u_xlat16_2 = u_xlat0.x * i.vs_COLOR0.w;
    u_xlat16_2 = min(u_xlat16_2, 1.0);
    u_xlat16_2 = u_xlat16_2 + -0.00999999978;
    u_xlatb0 = u_xlat16_2<0.0;
    if(u_xlatb0){discard;}
    result = float4(0.0, 0.0, 0.0, 0.0);
    return result;

}

#elif !defined(SHADOWS_CUBE) && defined(SHADOWS_DEPTH) && !defined(_CFXR_DISSOLVE) && !defined(_CFXR_RADIAL_UV) && defined(_CFXR_WORLD_SPACE_RING)
// Original shadow GLES program 25
float4 _MainTex_ST;
float _RingTopOffset;
float _SingleChannel;
sampler2D _MainTex;
struct A{float4 in_POSITION0:POSITION0;float4 in_COLOR0:COLOR0;float4 in_TEXCOORD0:TEXCOORD0;float4 in_TEXCOORD2:TEXCOORD2;float3 in_NORMAL0:NORMAL0;};
struct V{float4 vertex:SV_POSITION;float4 vs_COLOR0:TEXCOORD0;float4 vs_TEXCOORD2:TEXCOORD1;float4 vs_TEXCOORD3:TEXCOORD2;};
V vert(A i){V o=(V)0;
float4 vs_TEXCOORD1;
float4 u_xlat0;
float4 u_xlat1;
float3 u_xlat2;
float3 u_xlat3;
float u_xlat6;
float u_xlat10;
bool u_xlatb10;

    o.vs_COLOR0 = i.in_COLOR0;
    vs_TEXCOORD1 = i.in_TEXCOORD0;
    o.vs_TEXCOORD2.z = i.in_TEXCOORD2.y / i.in_TEXCOORD2.w;
    o.vs_TEXCOORD2.y = (-_RingTopOffset) + 1.0;
    o.vs_TEXCOORD2.w = i.in_TEXCOORD2.z;
    u_xlat0.x = min(i.in_TEXCOORD2.x, i.in_TEXCOORD2.w);
    u_xlat3.x = u_xlat0.x / i.in_TEXCOORD2.w;
    u_xlat3.x = (-u_xlat3.x) + 1.0;
    o.vs_TEXCOORD2.x = u_xlat3.x * u_xlat3.x;
    u_xlat1.x = i.in_TEXCOORD2.z;
    u_xlat1.y = 0.0;
    u_xlat3.xy = u_xlat1.xy + i.in_TEXCOORD0.xy;
    u_xlat3.xy = u_xlat3.xy * _MainTex_ST.xy + _MainTex_ST.zw;
    o.vs_TEXCOORD3.xy = (-u_xlat3.xy) + float2(1.0, 1.0);
    u_xlat3.xy = i.in_TEXCOORD0.yy * i.in_TEXCOORD0.zw;
    u_xlat3.xy = u_xlat0.xx * u_xlat3.xy;
    u_xlat3.xy = u_xlat3.xy / i.in_TEXCOORD2.ww;
    o.vs_TEXCOORD3.zw = (-u_xlat3.xy) + i.in_TEXCOORD0.zw;
    u_xlat3.xyz = i.in_TEXCOORD0.yyy * i.in_NORMAL0.xyz;
    u_xlat0.xyz = (-u_xlat3.xyz) * u_xlat0.xxx + i.in_POSITION0.xyz;
    u_xlat1 = u_xlat0.yyyy * transpose(unity_ObjectToWorld)[1];
    u_xlat1 = transpose(unity_ObjectToWorld)[0] * u_xlat0.xxxx + u_xlat1;
    u_xlat0 = transpose(unity_ObjectToWorld)[2] * u_xlat0.zzzz + u_xlat1;
    u_xlat0 = transpose(unity_ObjectToWorld)[3] * i.in_POSITION0.wwww + u_xlat0;
    u_xlat1.xyz = (-u_xlat0.xyz) * _WorldSpaceLightPos0.www + _WorldSpaceLightPos0.xyz;
    u_xlat10 = dot(u_xlat1.xyz, u_xlat1.xyz);
    u_xlat10 = rsqrt(u_xlat10);
    u_xlat1.xyz = ((float3)(u_xlat10)) * u_xlat1.xyz;
    u_xlat2.x = dot(i.in_NORMAL0.xyz, transpose(unity_WorldToObject)[0].xyz);
    u_xlat2.y = dot(i.in_NORMAL0.xyz, transpose(unity_WorldToObject)[1].xyz);
    u_xlat2.z = dot(i.in_NORMAL0.xyz, transpose(unity_WorldToObject)[2].xyz);
    u_xlat10 = dot(u_xlat2.xyz, u_xlat2.xyz);
    u_xlat10 = rsqrt(u_xlat10);
    u_xlat2.xyz = ((float3)(u_xlat10)) * u_xlat2.xyz;
    u_xlat1.x = dot(u_xlat2.xyz, u_xlat1.xyz);
    u_xlat1.x = (-u_xlat1.x) * u_xlat1.x + 1.0;
    u_xlat1.x = sqrt(u_xlat1.x);
    u_xlat1.x = u_xlat1.x * unity_LightShadowBias.z;
    u_xlat1.xyz = (-u_xlat2.xyz) * u_xlat1.xxx + u_xlat0.xyz;
    u_xlatb10 = unity_LightShadowBias.z!=0.0;
    u_xlat0.xyz = (bool(u_xlatb10)) ? u_xlat1.xyz : u_xlat0.xyz;
    u_xlat1 = u_xlat0.yyyy * transpose(unity_MatrixVP)[1];
    u_xlat1 = transpose(unity_MatrixVP)[0] * u_xlat0.xxxx + u_xlat1;
    u_xlat1 = transpose(unity_MatrixVP)[2] * u_xlat0.zzzz + u_xlat1;
    u_xlat0 = transpose(unity_MatrixVP)[3] * u_xlat0.wwww + u_xlat1;
    u_xlat1.x = LF_ShadowBiasDelta(unity_LightShadowBias.x / u_xlat0.w);
    u_xlat6 = u_xlat0.z + u_xlat1.x;
    u_xlat1.x = LF_ShadowNearClamp(u_xlat6,u_xlat0.w);
    o.vertex.xyw = u_xlat0.xyw;
    u_xlat0.x = (-u_xlat6) + u_xlat1.x;
    o.vertex.z = unity_LightShadowBias.y * u_xlat0.x + u_xlat6;
    return o;

}
float4 frag(V i):SV_Target{float4 result=0;
float u_xlat0;
bool u_xlatb0;
float u_xlat16_1;
float u_xlat2;
float2 u_xlat16_2;
float u_xlat4;
bool u_xlatb6;

    u_xlat0 = (-i.vs_TEXCOORD2.z) + i.vs_TEXCOORD2.y;
    u_xlat2 = (-u_xlat0) + i.vs_TEXCOORD2.y;
    u_xlat2 = float(1.0) / u_xlat2;
    u_xlat4 = dot(i.vs_TEXCOORD3.zw, i.vs_TEXCOORD3.zw);
    u_xlat0 = (-u_xlat0) + u_xlat4;
    u_xlat4 = u_xlat4 + (-i.vs_TEXCOORD2.x);
    u_xlat0 = u_xlat2 * u_xlat0;
    u_xlat0 = clamp(u_xlat0, 0.0, 1.0);
    u_xlat2 = u_xlat0 * -2.0 + 3.0;
    u_xlat0 = u_xlat0 * u_xlat0;
    u_xlat0 = u_xlat0 * u_xlat2;
    u_xlat2 = float(1.0) / i.vs_TEXCOORD2.z;
    u_xlat2 = u_xlat2 * u_xlat4;
    u_xlat2 = clamp(u_xlat2, 0.0, 1.0);
    u_xlat4 = u_xlat2 * -2.0 + 3.0;
    u_xlat2 = u_xlat2 * u_xlat2;
    u_xlat0 = u_xlat4 * u_xlat2 + (-u_xlat0);
    u_xlat0 = clamp(u_xlat0, 0.0, 1.0);
    u_xlat16_2.xy = tex2D(_MainTex, i.vs_TEXCOORD3.xy).xw;
    u_xlatb6 = 0.0<_SingleChannel;
    u_xlat16_1 = (u_xlatb6) ? u_xlat16_2.x : u_xlat16_2.y;
    u_xlat0 = u_xlat0 * u_xlat16_1;
    u_xlat16_1 = u_xlat0 * i.vs_COLOR0.w;
    u_xlat16_1 = min(u_xlat16_1, 1.0);
    u_xlat16_1 = u_xlat16_1 + -0.00999999978;
    u_xlatb0 = u_xlat16_1<0.0;
    if(u_xlatb0){discard;}
    result = float4(0.0, 0.0, 0.0, 0.0);
    return result;

}

#elif !defined(SHADOWS_CUBE) && defined(SHADOWS_DEPTH) && !defined(_CFXR_DISSOLVE) && !defined(_CFXR_RADIAL_UV) && !defined(_CFXR_WORLD_SPACE_RING)
// Original shadow GLES program 19
float4 _MainTex_ST;
float _RingTopOffset;
float _SingleChannel;
sampler2D _MainTex;
struct A{float4 in_POSITION0:POSITION0;float4 in_COLOR0:COLOR0;float4 in_TEXCOORD0:TEXCOORD0;float4 in_TEXCOORD2:TEXCOORD2;float3 in_NORMAL0:NORMAL0;};
struct V{float4 vertex:SV_POSITION;float4 vs_COLOR0:TEXCOORD0;float4 vs_TEXCOORD2:TEXCOORD1;float4 vs_TEXCOORD3:TEXCOORD2;};
V vert(A i){V o=(V)0;
float4 vs_TEXCOORD1;
float4 u_xlat0;
float4 u_xlat1;
float4 u_xlat2;
float2 u_xlat3;
float u_xlat6;
float u_xlat9;
bool u_xlatb9;

    o.vs_COLOR0 = i.in_COLOR0;
    vs_TEXCOORD1 = i.in_TEXCOORD0;
    u_xlat0.x = min(i.in_TEXCOORD2.x, i.in_TEXCOORD2.w);
    u_xlat3.x = u_xlat0.x / i.in_TEXCOORD2.w;
    u_xlat3.x = (-u_xlat3.x) + 1.0;
    o.vs_TEXCOORD2.x = u_xlat3.x * u_xlat3.x;
    o.vs_TEXCOORD2.z = i.in_TEXCOORD2.y / i.in_TEXCOORD2.w;
    o.vs_TEXCOORD2.y = (-_RingTopOffset) + 1.0;
    o.vs_TEXCOORD2.w = i.in_TEXCOORD2.z;
    u_xlat3.xy = i.in_TEXCOORD0.yy * i.in_TEXCOORD0.zw;
    u_xlat0.xy = u_xlat0.xx * u_xlat3.xy;
    u_xlat0.xy = u_xlat0.xy / i.in_TEXCOORD2.ww;
    o.vs_TEXCOORD3.zw = (-u_xlat0.xy) + i.in_TEXCOORD0.zw;
    u_xlat0.x = i.in_TEXCOORD2.z;
    u_xlat0.y = 0.0;
    u_xlat0.xy = u_xlat0.xy + i.in_TEXCOORD0.xy;
    u_xlat0.xy = u_xlat0.xy * _MainTex_ST.xy + _MainTex_ST.zw;
    o.vs_TEXCOORD3.xy = (-u_xlat0.xy) + float2(1.0, 1.0);
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
float u_xlat0;
bool u_xlatb0;
float u_xlat16_1;
float u_xlat2;
float2 u_xlat16_2;
float u_xlat4;
bool u_xlatb6;

    u_xlat0 = (-i.vs_TEXCOORD2.z) + i.vs_TEXCOORD2.y;
    u_xlat2 = (-u_xlat0) + i.vs_TEXCOORD2.y;
    u_xlat2 = float(1.0) / u_xlat2;
    u_xlat4 = dot(i.vs_TEXCOORD3.zw, i.vs_TEXCOORD3.zw);
    u_xlat0 = (-u_xlat0) + u_xlat4;
    u_xlat4 = u_xlat4 + (-i.vs_TEXCOORD2.x);
    u_xlat0 = u_xlat2 * u_xlat0;
    u_xlat0 = clamp(u_xlat0, 0.0, 1.0);
    u_xlat2 = u_xlat0 * -2.0 + 3.0;
    u_xlat0 = u_xlat0 * u_xlat0;
    u_xlat0 = u_xlat0 * u_xlat2;
    u_xlat2 = float(1.0) / i.vs_TEXCOORD2.z;
    u_xlat2 = u_xlat2 * u_xlat4;
    u_xlat2 = clamp(u_xlat2, 0.0, 1.0);
    u_xlat4 = u_xlat2 * -2.0 + 3.0;
    u_xlat2 = u_xlat2 * u_xlat2;
    u_xlat0 = u_xlat4 * u_xlat2 + (-u_xlat0);
    u_xlat0 = clamp(u_xlat0, 0.0, 1.0);
    u_xlat16_2.xy = tex2D(_MainTex, i.vs_TEXCOORD3.xy).xw;
    u_xlatb6 = 0.0<_SingleChannel;
    u_xlat16_1 = (u_xlatb6) ? u_xlat16_2.x : u_xlat16_2.y;
    u_xlat0 = u_xlat0 * u_xlat16_1;
    u_xlat16_1 = u_xlat0 * i.vs_COLOR0.w;
    u_xlat16_1 = min(u_xlat16_1, 1.0);
    u_xlat16_1 = u_xlat16_1 + -0.00999999978;
    u_xlatb0 = u_xlat16_1<0.0;
    if(u_xlatb0){discard;}
    result = float4(0.0, 0.0, 0.0, 0.0);
    return result;

}

#elif defined(SHADOWS_CUBE) && !defined(SHADOWS_DEPTH) && !defined(_CFXR_DISSOLVE) && !defined(_CFXR_RADIAL_UV) && !defined(_CFXR_WORLD_SPACE_RING)
// Original shadow GLES program 23
float4 _MainTex_ST;
float _RingTopOffset;
float _SingleChannel;
sampler2D _MainTex;
struct A{float4 in_POSITION0:POSITION0;float4 in_COLOR0:COLOR0;float4 in_TEXCOORD0:TEXCOORD0;float4 in_TEXCOORD2:TEXCOORD2;float3 in_NORMAL0:NORMAL0;};
struct V{float4 vertex:SV_POSITION;float4 vs_COLOR0:TEXCOORD0;float4 vs_TEXCOORD2:TEXCOORD1;float4 vs_TEXCOORD3:TEXCOORD2;};
V vert(A i){V o=(V)0;
float4 vs_TEXCOORD1;
float4 u_xlat0;
float4 u_xlat1;
float4 u_xlat2;
float2 u_xlat3;
float u_xlat9;
bool u_xlatb9;

    o.vs_COLOR0 = i.in_COLOR0;
    vs_TEXCOORD1 = i.in_TEXCOORD0;
    u_xlat0.x = min(i.in_TEXCOORD2.x, i.in_TEXCOORD2.w);
    u_xlat3.x = u_xlat0.x / i.in_TEXCOORD2.w;
    u_xlat3.x = (-u_xlat3.x) + 1.0;
    o.vs_TEXCOORD2.x = u_xlat3.x * u_xlat3.x;
    o.vs_TEXCOORD2.z = i.in_TEXCOORD2.y / i.in_TEXCOORD2.w;
    o.vs_TEXCOORD2.y = (-_RingTopOffset) + 1.0;
    o.vs_TEXCOORD2.w = i.in_TEXCOORD2.z;
    u_xlat3.xy = i.in_TEXCOORD0.yy * i.in_TEXCOORD0.zw;
    u_xlat0.xy = u_xlat0.xx * u_xlat3.xy;
    u_xlat0.xy = u_xlat0.xy / i.in_TEXCOORD2.ww;
    o.vs_TEXCOORD3.zw = (-u_xlat0.xy) + i.in_TEXCOORD0.zw;
    u_xlat0.x = i.in_TEXCOORD2.z;
    u_xlat0.y = 0.0;
    u_xlat0.xy = u_xlat0.xy + i.in_TEXCOORD0.xy;
    u_xlat0.xy = u_xlat0.xy * _MainTex_ST.xy + _MainTex_ST.zw;
    o.vs_TEXCOORD3.xy = (-u_xlat0.xy) + float2(1.0, 1.0);
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
float u_xlat0;
bool u_xlatb0;
float u_xlat16_1;
float u_xlat2;
float2 u_xlat16_2;
float u_xlat4;
bool u_xlatb6;

    u_xlat0 = (-i.vs_TEXCOORD2.z) + i.vs_TEXCOORD2.y;
    u_xlat2 = (-u_xlat0) + i.vs_TEXCOORD2.y;
    u_xlat2 = float(1.0) / u_xlat2;
    u_xlat4 = dot(i.vs_TEXCOORD3.zw, i.vs_TEXCOORD3.zw);
    u_xlat0 = (-u_xlat0) + u_xlat4;
    u_xlat4 = u_xlat4 + (-i.vs_TEXCOORD2.x);
    u_xlat0 = u_xlat2 * u_xlat0;
    u_xlat0 = clamp(u_xlat0, 0.0, 1.0);
    u_xlat2 = u_xlat0 * -2.0 + 3.0;
    u_xlat0 = u_xlat0 * u_xlat0;
    u_xlat0 = u_xlat0 * u_xlat2;
    u_xlat2 = float(1.0) / i.vs_TEXCOORD2.z;
    u_xlat2 = u_xlat2 * u_xlat4;
    u_xlat2 = clamp(u_xlat2, 0.0, 1.0);
    u_xlat4 = u_xlat2 * -2.0 + 3.0;
    u_xlat2 = u_xlat2 * u_xlat2;
    u_xlat0 = u_xlat4 * u_xlat2 + (-u_xlat0);
    u_xlat0 = clamp(u_xlat0, 0.0, 1.0);
    u_xlat16_2.xy = tex2D(_MainTex, i.vs_TEXCOORD3.xy).xw;
    u_xlatb6 = 0.0<_SingleChannel;
    u_xlat16_1 = (u_xlatb6) ? u_xlat16_2.x : u_xlat16_2.y;
    u_xlat0 = u_xlat0 * u_xlat16_1;
    u_xlat16_1 = u_xlat0 * i.vs_COLOR0.w;
    u_xlat16_1 = min(u_xlat16_1, 1.0);
    u_xlat16_1 = u_xlat16_1 + -0.00999999978;
    u_xlatb0 = u_xlat16_1<0.0;
    if(u_xlatb0){discard;}
    result = float4(0.0, 0.0, 0.0, 0.0);
    return result;

}

#else
float4 _MainTex_ST;
float _RingTopOffset;
float _SingleChannel;
sampler2D _MainTex;
struct A{float4 in_POSITION0:POSITION0;float4 in_COLOR0:COLOR0;float4 in_TEXCOORD0:TEXCOORD0;float4 in_TEXCOORD2:TEXCOORD2;float3 in_NORMAL0:NORMAL0;};
struct V{float4 vertex:SV_POSITION;float4 vs_COLOR0:TEXCOORD0;float4 vs_TEXCOORD2:TEXCOORD1;float4 vs_TEXCOORD3:TEXCOORD2;};
V vert(A i){V o=(V)0;
float4 vs_TEXCOORD1;
float4 u_xlat0;
float4 u_xlat1;
float4 u_xlat2;
float2 u_xlat3;
float u_xlat6;
float u_xlat9;
bool u_xlatb9;

    o.vs_COLOR0 = i.in_COLOR0;
    vs_TEXCOORD1 = i.in_TEXCOORD0;
    u_xlat0.x = min(i.in_TEXCOORD2.x, i.in_TEXCOORD2.w);
    u_xlat3.x = u_xlat0.x / i.in_TEXCOORD2.w;
    u_xlat3.x = (-u_xlat3.x) + 1.0;
    o.vs_TEXCOORD2.x = u_xlat3.x * u_xlat3.x;
    o.vs_TEXCOORD2.z = i.in_TEXCOORD2.y / i.in_TEXCOORD2.w;
    o.vs_TEXCOORD2.y = (-_RingTopOffset) + 1.0;
    o.vs_TEXCOORD2.w = i.in_TEXCOORD2.z;
    u_xlat3.xy = i.in_TEXCOORD0.yy * i.in_TEXCOORD0.zw;
    u_xlat0.xy = u_xlat0.xx * u_xlat3.xy;
    u_xlat0.xy = u_xlat0.xy / i.in_TEXCOORD2.ww;
    o.vs_TEXCOORD3.zw = (-u_xlat0.xy) + i.in_TEXCOORD0.zw;
    u_xlat0.x = i.in_TEXCOORD2.z;
    u_xlat0.y = 0.0;
    u_xlat0.xy = u_xlat0.xy + i.in_TEXCOORD0.xy;
    u_xlat0.xy = u_xlat0.xy * _MainTex_ST.xy + _MainTex_ST.zw;
    o.vs_TEXCOORD3.xy = (-u_xlat0.xy) + float2(1.0, 1.0);
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
float u_xlat0;
bool u_xlatb0;
float u_xlat16_1;
float u_xlat2;
float2 u_xlat16_2;
float u_xlat4;
bool u_xlatb6;

    u_xlat0 = (-i.vs_TEXCOORD2.z) + i.vs_TEXCOORD2.y;
    u_xlat2 = (-u_xlat0) + i.vs_TEXCOORD2.y;
    u_xlat2 = float(1.0) / u_xlat2;
    u_xlat4 = dot(i.vs_TEXCOORD3.zw, i.vs_TEXCOORD3.zw);
    u_xlat0 = (-u_xlat0) + u_xlat4;
    u_xlat4 = u_xlat4 + (-i.vs_TEXCOORD2.x);
    u_xlat0 = u_xlat2 * u_xlat0;
    u_xlat0 = clamp(u_xlat0, 0.0, 1.0);
    u_xlat2 = u_xlat0 * -2.0 + 3.0;
    u_xlat0 = u_xlat0 * u_xlat0;
    u_xlat0 = u_xlat0 * u_xlat2;
    u_xlat2 = float(1.0) / i.vs_TEXCOORD2.z;
    u_xlat2 = u_xlat2 * u_xlat4;
    u_xlat2 = clamp(u_xlat2, 0.0, 1.0);
    u_xlat4 = u_xlat2 * -2.0 + 3.0;
    u_xlat2 = u_xlat2 * u_xlat2;
    u_xlat0 = u_xlat4 * u_xlat2 + (-u_xlat0);
    u_xlat0 = clamp(u_xlat0, 0.0, 1.0);
    u_xlat16_2.xy = tex2D(_MainTex, i.vs_TEXCOORD3.xy).xw;
    u_xlatb6 = 0.0<_SingleChannel;
    u_xlat16_1 = (u_xlatb6) ? u_xlat16_2.x : u_xlat16_2.y;
    u_xlat0 = u_xlat0 * u_xlat16_1;
    u_xlat16_1 = u_xlat0 * i.vs_COLOR0.w;
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
