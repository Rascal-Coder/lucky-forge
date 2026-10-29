// Direct stage-body port of shipped GLES variants; preserved material-driven render states.
Shader "Cartoon FX/Remaster/Particle Ubershader"{
Properties {

[Enum(UnityEngine.Rendering.BlendMode)] _SrcBlend ("Blend Source", Float) = 5.0

[Enum(UnityEngine.Rendering.BlendMode)] _DstBlend ("Blend Destination", Float) = 10.0

[KeywordEnumNoPrefix(Alpha Blending, _ALPHABLEND_ON, Alpha Blending Premultiplied, _ALPHAPREMULTIPLY_ON, Multiplicative, _ALPHAMODULATE_ON, Additive, _CFXR_ADDITIVE)] _BlendingType ("Blending Type", Float) = 0.0

[ToggleNoKeyword] _ZWrite ("Depth Write", Float) = 0.0

[Toggle(_ALPHATEST_ON)] _UseAlphaClip ("Alpha Clipping (Cutout)", Float) = 0.0

_Cutoff ("Cutoff Threshold", Range(0.001, 1)) = 0.10000000149011612

[Toggle(_FADING_ON)] _UseSP ("Soft Particles", Float) = 0.0

_SoftParticlesFadeDistanceNear ("Near Fade", Float) = 0.0

_SoftParticlesFadeDistanceFar ("Far Fade", Float) = 1.0

[Toggle(_CFXR_EDGE_FADING)] _UseEF ("Edge Fade", Float) = 0.0

_EdgeFadePow ("Edge Fade Power", Float) = 1.0

[Toggle(_CFXR_DISSOLVE)] _UseDissolve ("Enable Dissolve", Float) = 0.0

_DissolveTex ("Dissolve Texture", 2D) = "gray" { }

_DissolveSmooth ("Dissolve Smoothing", Range(0.0001, 0.5)) = 0.10000000149011612

[ToggleNoKeyword] _InvertDissolveTex ("Invert Dissolve Texture", Float) = 0.0

[ToggleNoKeyword] _DoubleDissolve ("Double Dissolve", Float) = 0.0

[Toggle] _UseDissolveOffsetUV ("Dissolve offset along X", Float) = 0.0

_DissolveScroll ("UV Scrolling", Vector) = (0,0,0,0)

[Toggle(_CFXR_UV_DISTORTION)] _UseUVDistortion ("Enable UV Distortion", Float) = 0.0

_DistortTex ("Distortion Texture", 2D) = "gray" { }

_DistortScrolling ("Scroll (XY) Tile (ZW)", Vector) = (0,0,1,1)

[Toggle] _UseUV2Distortion ("Use UV2", Float) = 0.0

_Distort ("Distortion Strength", Range(0, 2)) = 0.10000000149011612

[ToggleNoKeyword] _FadeAlongU ("Fade along Y", Float) = 0.0

[Toggle] _UVDistortionAdd ("Add to base UV", Float) = 0.0

_MainTex ("Texture", 2D) = "white" { }

[Toggle] _SingleChannel ("Single Channel Texture", Float) = 0.0

[KeywordEnum(Off,1x,2x)] _CFXR_OVERLAYTEX ("Enable Overlay Texture", Float) = 0.0

[Enum(RGBA,0,RGB,1,A,2)] _CFXR_OVERLAYBLEND ("Overlay Blend Channels", Float) = 0.0

_OverlayTex ("Overlay Texture", 2D) = "white" { }

_OverlayTex_Scroll ("Overlay Scrolling / Scale", Vector) = (0.1,0.1,1,1)

[Toggle(_FLIPBOOK_BLENDING)] _UseFB ("Flipbook Blending", Float) = 0.0

[Toggle(_CFXR_SECONDCOLOR_LERP)] _UseSecondColor ("Secondary Vertex Color (TEXCOORD2)", Float) = 0.0

_SecondColorTex ("Second Color Map", 2D) = "black" { }

_SecondColorSmooth ("Second Color Smoothing", Range(0.0001, 0.5)) = 0.20000000298023224

[Toggle(_CFXR_FONT_COLORS)] _UseFontColor ("Use Font Colors", Float) = 0.0

_HdrMultiply ("HDR Multiplier", Float) = 1.0

[KeywordEnumNoPrefix(Off, _, Direct, _CFXR_LIGHTING_DIRECT, Indirect, _CFXR_LIGHTING_INDIRECT, Both, _CFXR_LIGHTING_ALL)] _UseLighting ("Mode", Float) = 0.0

_DirectLightingRamp ("Direct Lighting Ramp", Range(0, 1)) = 1.0

[Toggle(_NORMALMAP)] _UseNormalMap ("Enable Normal Map", Float) = 0.0

_BumpMap ("Normal Map", 2D) = "bump" { }

_BumpScale ("Normal Scale", Range(-1, 1)) = 1.0

[Toggle(_EMISSION)] _UseEmission ("Enable Emission (TEXCOORD2)", Float) = 0.0

[Toggle(_CFXR_LIGHTING_WPOS_OFFSET)] _UseLightingWorldPosOffset ("Enable World Pos. Offset", Float) = 0.0

_LightingWorldPosStrength ("Offset Strength", Range(0, 1)) = 0.20000000298023224

[Toggle(_CFXR_LIGHTING_BACK)] _UseBackLighting ("Enable Backlighting", Float) = 0.0

_DirLightScreenAtten ("Dir. Light Screen Attenuation", Range(0, 5)) = 1.0

_BacklightTransmittance ("Backlight Transmittance", Range(0, 2)) = 1.0

_IndirectLightingMix ("Indirect Lighting Mix", Range(0, 1)) = 0.5

_ShadowColor ("Shadow Color", Color) = (0,0,0,1)

[KeywordEnum(Off,On,CustomTexture)] _CFXR_DITHERED_SHADOWS ("Dithered Shadows", Float) = 0.0

_ShadowStrength ("Shadows Strength Max", Range(0, 1)) = 1.0

_DitherCustom ("Dithering 3D Texture", 3D) = "black" { }

}

SubShader{Tags{"IGNOREPROJECTOR"="true" "PreviewType"="Plane" "QUEUE"="Transparent" "RenderType"="Transparent"}
Blend [_SrcBlend] [_DstBlend], One One
ZWrite [_ZWrite]
Cull Off
ZTest LEqual
Pass{Name "BASE" Tags{"LightMode"="ForwardBase"}
CGPROGRAM
#pragma target 3.0
#pragma vertex vert
#pragma fragment frag
#pragma multi_compile_particles
#pragma shader_feature_local _ _ALPHABLEND_ON _ALPHAPREMULTIPLY_ON _ALPHAMODULATE_ON _CFXR_ADDITIVE
#pragma shader_feature_local _ _CFXR_LIGHTING_ALL
#pragma shader_feature_local _ _CFXR_OVERLAYTEX_1X
#pragma shader_feature_local _ _ALPHATEST_ON
#pragma shader_feature_local _ _CFXR_DISSOLVE
#pragma shader_feature_local _ _CFXR_EDGE_FADING
#pragma shader_feature_local _ _CFXR_FONT_COLORS
#pragma shader_feature_local _ _CFXR_LIGHTING_BACK
#pragma shader_feature_local _ _CFXR_LIGHTING_WPOS_OFFSET
#pragma shader_feature_local _ _CFXR_SECONDCOLOR_LERP
#pragma shader_feature_local _ _CFXR_UV_DISTORTION
#pragma shader_feature_local _ _EMISSION
#pragma shader_feature_local _ _FADING_ON
#pragma shader_feature_local _ _FLIPBOOK_BLENDING
#pragma shader_feature_local _ _NORMALMAP
#include "UnityCG.cginc"
#include "Lighting.cginc"
#define lessThan(a,b) ((a)<(b))
#define greaterThan(a,b) ((a)>(b))
#define lessThanEqual(a,b) ((a)<=(b))
#define greaterThanEqual(a,b) ((a)>=(b))
#define equal(a,b) ((a)==(b))
#define notEqual(a,b) ((a)!=(b))
#if defined(SOFTPARTICLES_ON) && defined(_ALPHABLEND_ON) && !defined(_ALPHAMODULATE_ON) && !defined(_ALPHAPREMULTIPLY_ON) && !defined(_ALPHATEST_ON) && !defined(_CFXR_ADDITIVE) && defined(_CFXR_DISSOLVE) && !defined(_CFXR_EDGE_FADING) && !defined(_CFXR_FONT_COLORS) && defined(_CFXR_LIGHTING_ALL) && defined(_CFXR_LIGHTING_BACK) && defined(_CFXR_LIGHTING_WPOS_OFFSET) && !defined(_CFXR_OVERLAYTEX_1X) && !defined(_CFXR_SECONDCOLOR_LERP) && !defined(_CFXR_UV_DISTORTION) && !defined(_EMISSION) && defined(_FADING_ON) && !defined(_FLIPBOOK_BLENDING) && defined(_NORMALMAP)
// Original GLES program 81; SOFTPARTICLES_ON,_CFXR_DISSOLVE,_CFXR_LIGHTING_ALL,_CFXR_LIGHTING_WPOS_OFFSET,_CFXR_LIGHTING_BACK,_NORMALMAP,_FADING_ON,_ALPHABLEND_ON
float4 _GameObjectWorldPosition;
float _SingleChannel;
float _UseDissolveOffsetUV;
float _BumpScale;
float _LightingWorldPosStrength;
float _IndirectLightingMix;
float4 _ShadowColor;
float _DirectLightingRamp;
float _DirLightScreenAtten;
float _BacklightTransmittance;
float _InvertDissolveTex;
float _DoubleDissolve;
float2 _DissolveScroll;
float _DissolveSmooth;
float _HdrMultiply;
float _SoftParticlesFadeDistanceNear;
float _SoftParticlesFadeDistanceFar;
float4 _DissolveTex_ST;
sampler2D _MainTex;
sampler2D _BumpMap;
sampler2D _DissolveTex;
sampler2D _CameraDepthTexture;
struct A{float4 in_POSITION0:POSITION0;float4 in_COLOR0:COLOR0;float4 in_TEXCOORD0:TEXCOORD0;float4 in_TEXCOORD1:TEXCOORD1;float3 in_NORMAL0:NORMAL0;float4 in_TANGENT0:TANGENT0;};
struct V{float4 vertex:SV_POSITION;float4 vs_COLOR0:TEXCOORD0;float4 vs_TEXCOORD0:TEXCOORD1;float4 vs_TEXCOORD1:TEXCOORD2;float4 vs_TEXCOORD3:TEXCOORD3;float3 vs_TEXCOORD4:TEXCOORD4;float3 vs_TEXCOORD6:TEXCOORD5;float3 vs_TEXCOORD7:TEXCOORD6;float3 vs_NORMAL0:TEXCOORD7;float4 vs_TANGENT0:TEXCOORD8;};
V vert(A i){V o=(V)0;
float4 u_xlat0;
float4 u_xlat1;
float u_xlat2;
float u_xlat6;

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
    o.vs_TEXCOORD1 = i.in_TEXCOORD1;
    u_xlat2 = u_xlat0.y * transpose(unity_MatrixV)[1].z;
    u_xlat0.x = transpose(unity_MatrixV)[0].z * u_xlat0.x + u_xlat2;
    u_xlat0.x = transpose(unity_MatrixV)[2].z * u_xlat0.z + u_xlat0.x;
    u_xlat0.x = transpose(unity_MatrixV)[3].z * u_xlat0.w + u_xlat0.x;
    o.vs_TEXCOORD3.z = (-u_xlat0.x);
    u_xlat0.x = u_xlat1.y * _ProjectionParams.x;
    u_xlat0.w = u_xlat0.x * 0.5;
    u_xlat0.xz = u_xlat1.xw * float2(0.5, 0.5);
    o.vs_TEXCOORD3.w = u_xlat1.w;
    o.vs_TEXCOORD3.xy = u_xlat0.zz + u_xlat0.xw;
    o.vs_TEXCOORD4.xyz = i.in_POSITION0.xyz;
    u_xlat0.xyz = (-i.in_POSITION0.xyz) + _WorldSpaceCameraPos.xyz;
    u_xlat6 = dot(u_xlat0.xyz, u_xlat0.xyz);
    u_xlat6 = rsqrt(u_xlat6);
    o.vs_TEXCOORD6.xyz = ((float3)(u_xlat6)) * u_xlat0.xyz;
    o.vs_TEXCOORD7.xyz = (-i.in_POSITION0.xyz) + _GameObjectWorldPosition.xyz;
    o.vs_NORMAL0.xyz = i.in_NORMAL0.xyz;
    o.vs_TANGENT0 = i.in_TANGENT0;
    return o;

}
float4 frag(V i):SV_Target{float4 result=0;
float4 u_xlat0;
float u_xlat16_0;
bool u_xlatb0;
float4 u_xlat1;
float4 u_xlat16_1;
float4 u_xlat2;
float4 u_xlat16_2;
float4 u_xlat3;
float4 u_xlat16_3;
float4 u_xlat4;
float3 u_xlat16_4;
float3 u_xlat16_5;
float4 u_xlat6;
bool2 u_xlatb6;
float4 u_xlat7;
float3 u_xlat16_8;
float3 u_xlat16_9;
float u_xlat10;
float u_xlat16_15;
float2 u_xlat20;
bool u_xlatb20;
float u_xlat16_25;
float u_xlat31;
bool u_xlatb31;
float u_xlat16_35;

    u_xlat0.x = i.vs_TANGENT0.x;
    u_xlat0.z = i.vs_NORMAL0.x;
    u_xlat1.xyz = i.vs_NORMAL0.zxy * i.vs_TANGENT0.yzx;
    u_xlat1.xyz = i.vs_NORMAL0.yzx * i.vs_TANGENT0.zxy + (-u_xlat1.xyz);
    u_xlat1.xyz = u_xlat1.xzy * i.vs_TANGENT0.www;
    u_xlat0.y = u_xlat1.x;
    u_xlat16_2.xyz = tex2D(_BumpMap, i.vs_TEXCOORD0.xy).xyz;
    u_xlat16_3.xyz = u_xlat16_2.xyz * float3(2.0, 2.0, 2.0) + float3(-1.0, -1.0, -1.0);
    u_xlat16_3.xy = u_xlat16_3.xy * ((float2)(float2(_BumpScale, _BumpScale)));
    u_xlat16_4.x = dot(u_xlat16_3.xyz, u_xlat0.xyz);
    u_xlat0.y = u_xlat1.z;
    u_xlat0.x = i.vs_TANGENT0.y;
    u_xlat0.z = i.vs_NORMAL0.y;
    u_xlat16_4.y = dot(u_xlat16_3.xyz, u_xlat0.xyz);
    u_xlat1.x = i.vs_TANGENT0.z;
    u_xlat1.z = i.vs_NORMAL0.z;
    u_xlat16_4.z = dot(u_xlat16_3.xyz, u_xlat1.xyz);
    u_xlat0 = (-i.vs_TEXCOORD7.xyzz) * ((float4)(_LightingWorldPosStrength)) + u_xlat16_4.xyzz;
    u_xlat1.x = dot(u_xlat0.xyw, u_xlat0.xyw);
    u_xlat1.x = rsqrt(u_xlat1.x);
    u_xlat0 = u_xlat0.xywz * u_xlat1.xxxx;
    u_xlat1 = (-i.vs_TEXCOORD4.yyyy) + unity_4LightPosY0;
    u_xlat2 = u_xlat0.yyyy * u_xlat1;
    u_xlat3 = (-i.vs_TEXCOORD4.xxxx) + unity_4LightPosX0;
    u_xlat2 = u_xlat3 * u_xlat0.xxxx + u_xlat2;
    u_xlat4 = (-i.vs_TEXCOORD4.zzzz) + unity_4LightPosZ0;
    u_xlat2 = u_xlat4 * u_xlat0.zzzz + u_xlat2;
    u_xlat2 = u_xlat2 * float4(0.5, 0.5, 0.5, 0.5) + float4(0.5, 0.5, 0.5, 0.5);
    u_xlat16_5.x = (-_DirectLightingRamp) * 0.5 + 0.5;
    u_xlat2 = u_xlat2 + (-u_xlat16_5.xxxx);
    u_xlat16_15 = _DirectLightingRamp * 0.5 + 0.5;
    u_xlat6.x = (-u_xlat16_5.x) + u_xlat16_15;
    u_xlat16_15 = (-u_xlat16_5.x) + u_xlat16_15;
    u_xlat16_15 = float(1.0) / u_xlat16_15;
    u_xlat6.x = float(1.0) / u_xlat6.x;
    u_xlat2 = u_xlat2 * u_xlat6.xxxx;
    u_xlat2 = clamp(u_xlat2, 0.0, 1.0);
    u_xlat7 = u_xlat2 * float4(-2.0, -2.0, -2.0, -2.0) + float4(3.0, 3.0, 3.0, 3.0);
    u_xlat2 = u_xlat2 * u_xlat2;
    u_xlat2 = u_xlat2 * u_xlat7;
    u_xlat7 = u_xlat1 * u_xlat1;
    u_xlat1 = (-u_xlat0.yyyy) * u_xlat1;
    u_xlat1 = u_xlat3 * (-u_xlat0.xxxx) + u_xlat1;
    u_xlat3 = u_xlat3 * u_xlat3 + u_xlat7;
    u_xlat3 = u_xlat4 * u_xlat4 + u_xlat3;
    u_xlat1 = u_xlat4 * (-u_xlat0.zzzz) + u_xlat1;
    u_xlat1 = u_xlat1 * float4(0.5, 0.5, 0.5, 0.5) + (-u_xlat16_5.xxxx);
    u_xlat1 = u_xlat1 + float4(0.5, 0.5, 0.5, 0.5);
    u_xlat1 = u_xlat6.xxxx * u_xlat1;
    u_xlat1 = clamp(u_xlat1, 0.0, 1.0);
    u_xlat3 = max(u_xlat3, float4(9.99999997e-07, 9.99999997e-07, 9.99999997e-07, 9.99999997e-07));
    u_xlat4 = rsqrt(u_xlat3);
    u_xlat3 = u_xlat3 * unity_4LightAtten0 + float4(1.0, 1.0, 1.0, 1.0);
    u_xlat3 = float4(1.0, 1.0, 1.0, 1.0) / u_xlat3;
    u_xlat2 = u_xlat2 * u_xlat4;
    u_xlat2 = u_xlat3 * u_xlat2;
    u_xlat6.xyz = u_xlat2.yyy * unity_LightColor[1].xyz;
    u_xlat6.xyz = unity_LightColor[0].xyz * u_xlat2.xxx + u_xlat6.xyz;
    u_xlat2.xyz = unity_LightColor[2].xyz * u_xlat2.zzz + u_xlat6.xyz;
    u_xlat2.xyz = unity_LightColor[3].xyz * u_xlat2.www + u_xlat2.xyz;
    u_xlat6 = u_xlat1 * float4(-2.0, -2.0, -2.0, -2.0) + float4(3.0, 3.0, 3.0, 3.0);
    u_xlat1 = u_xlat1 * u_xlat1;
    u_xlat1 = u_xlat1 * u_xlat6;
    u_xlat1 = u_xlat4 * u_xlat1;
    u_xlat1 = u_xlat3 * u_xlat1;
    u_xlat6.xyz = u_xlat1.yyy * unity_LightColor[1].xyz;
    u_xlat6.xyz = unity_LightColor[0].xyz * u_xlat1.xxx + u_xlat6.xyz;
    u_xlat1.xyz = unity_LightColor[2].xyz * u_xlat1.zzz + u_xlat6.xyz;
    u_xlat1.xyz = unity_LightColor[3].xyz * u_xlat1.www + u_xlat1.xyz;
    u_xlat1.xyz = u_xlat1.xyz * ((float3)(float3(_BacklightTransmittance, _BacklightTransmittance, _BacklightTransmittance))) + u_xlat2.xyz;
    u_xlat31 = log2(_HdrMultiply);
    u_xlat31 = u_xlat31 * 0.416666657;
    u_xlat31 = exp2(u_xlat31);
    u_xlat31 = u_xlat31 * 1.05499995 + -0.0549999997;
    u_xlat31 = max(u_xlat31, 0.0);
    u_xlat16_2 = tex2D(_MainTex, i.vs_TEXCOORD0.xy);
    u_xlatb6.xy = lessThan(float4(0.0, 0.0, 0.0, 0.0), float4(_SingleChannel, _UseDissolveOffsetUV, _SingleChannel, _SingleChannel)).xy;
    u_xlat16_3.xyz = (u_xlatb6.x) ? float3(1.0, 1.0, 1.0) : u_xlat16_2.xyz;
    u_xlat16_3.w = (u_xlatb6.x) ? u_xlat16_2.x : u_xlat16_2.w;
    u_xlat16_2 = u_xlat16_3 * i.vs_COLOR0;
    u_xlat16_8.xyz = ((float3)(u_xlat31)) * u_xlat16_2.xyz;
    u_xlatb31 = 0.0<_HdrMultiply;
    u_xlat16_8.xyz = (bool(u_xlatb31)) ? u_xlat16_8.xyz : u_xlat16_2.xyz;
    u_xlat31 = dot(u_xlat0.xyz, _WorldSpaceLightPos0.xyz);
    u_xlat16_25 = u_xlat31 * 0.5 + 0.5;
    u_xlat16_5.x = (-u_xlat16_5.x) + u_xlat16_25;
    u_xlat16_5.x = u_xlat16_15 * u_xlat16_5.x;
    u_xlat16_5.x = clamp(u_xlat16_5.x, 0.0, 1.0);
    u_xlat16_15 = u_xlat16_5.x * -2.0 + 3.0;
    u_xlat6.xzw = i.vs_TEXCOORD6.xyz + _WorldSpaceLightPos0.xyz;
    u_xlat31 = dot(u_xlat6.xzw, u_xlat6.xzw);
    u_xlat31 = sqrt(u_xlat31);
    u_xlat16_25 = float(1.0) / _DirLightScreenAtten;
    u_xlat16_5.z = u_xlat31 * u_xlat16_25;
    u_xlat16_5.z = clamp(u_xlat16_5.z, 0.0, 1.0);
    u_xlat16_35 = u_xlat16_5.z * -2.0 + 3.0;
    u_xlat16_5.xz = u_xlat16_5.xz * u_xlat16_5.xz;
    u_xlat16_25 = (-u_xlat16_35) * u_xlat16_5.z + 1.0;
    u_xlat16_25 = u_xlat16_25 * u_xlat16_25;
    u_xlat16_25 = u_xlat16_25 * _BacklightTransmittance;
    u_xlat16_5.x = u_xlat16_15 * u_xlat16_5.x + u_xlat16_25;
    u_xlat6.xzw = _LightColor0.xyz + (-_ShadowColor.xyz);
    u_xlat6.xzw = u_xlat16_5.xxx * u_xlat6.xzw + _ShadowColor.xyz;
    u_xlat16_5.xyz = u_xlat16_8.xyz * u_xlat6.xzw + u_xlat1.xyz;
    u_xlat16_35 = u_xlat0.y * u_xlat0.y;
    u_xlat16_35 = u_xlat0.x * u_xlat0.x + (-u_xlat16_35);
    u_xlat16_1 = u_xlat0.yzwx * u_xlat0.xywz;
    u_xlat16_8.x = dot(unity_SHBr, u_xlat16_1);
    u_xlat16_8.y = dot(unity_SHBg, u_xlat16_1);
    u_xlat16_8.z = dot(unity_SHBb, u_xlat16_1);
    u_xlat16_8.xyz = unity_SHC.xyz * ((float3)(u_xlat16_35)) + u_xlat16_8.xyz;
    u_xlat0.w = 1.0;
    u_xlat16_9.x = dot(unity_SHAr, u_xlat0);
    u_xlat16_9.y = dot(unity_SHAg, u_xlat0);
    u_xlat16_9.z = dot(unity_SHAb, u_xlat0);
    u_xlat16_8.xyz = u_xlat16_8.xyz + u_xlat16_9.xyz;
    u_xlat16_8.xyz = max(u_xlat16_8.xyz, float3(0.0, 0.0, 0.0));
    u_xlat0.xyz = log2(u_xlat16_8.xyz);
    u_xlat0.xyz = u_xlat0.xyz * float3(0.416666657, 0.416666657, 0.416666657);
    u_xlat0.xyz = exp2(u_xlat0.xyz);
    u_xlat0.xyz = u_xlat0.xyz * float3(1.05499995, 1.05499995, 1.05499995) + float3(-0.0549999997, -0.0549999997, -0.0549999997);
    u_xlat0.xyz = max(u_xlat0.xyz, float3(0.0, 0.0, 0.0));
    result.xyz = u_xlat0.xyz * ((float3)(float3(_IndirectLightingMix, _IndirectLightingMix, _IndirectLightingMix))) + u_xlat16_5.xyz;
    u_xlat0.xy = _Time.yy * float2(_DissolveScroll.x, _DissolveScroll.y);
    u_xlat0.xy = frac(u_xlat0.xy);
    u_xlat20.xy = i.vs_TEXCOORD0.xy * _DissolveTex_ST.xy + _DissolveTex_ST.zw;
    u_xlat0.xy = u_xlat0.xy + u_xlat20.xy;
    u_xlat0.xy = (u_xlatb6.y) ? u_xlat0.xy : i.vs_TEXCOORD0.xy;
    u_xlat16_0 = tex2D(_DissolveTex, u_xlat0.xy).x;
    u_xlat16_5.x = u_xlat16_0 * 2.0 + -1.0;
    u_xlat10 = u_xlat16_5.x * i.vs_TEXCOORD1.z + i.vs_TEXCOORD0.x;
    u_xlat16_5.x = (u_xlatb6.y) ? u_xlat10 : u_xlat16_0;
    u_xlat16_15 = (-u_xlat16_5.x) + 1.0;
    u_xlatb0 = 0.0>=_InvertDissolveTex;
    u_xlat16_5.x = (u_xlatb0) ? u_xlat16_15 : u_xlat16_5.x;
    u_xlat16_15 = u_xlat16_5.x + _DissolveSmooth;
    u_xlat16_5.x = u_xlat16_5.x + (-_DissolveSmooth);
    u_xlat16_15 = (-u_xlat16_5.x) + u_xlat16_15;
    u_xlat16_15 = float(1.0) / u_xlat16_15;
    u_xlat16_25 = _DissolveSmooth * 2.0 + 1.0;
    u_xlat16_25 = i.vs_TEXCOORD1.x * u_xlat16_25 + (-_DissolveSmooth);
    u_xlat16_35 = (-u_xlat16_5.x) + u_xlat16_25;
    u_xlat16_35 = u_xlat16_15 * u_xlat16_35;
    u_xlat16_35 = clamp(u_xlat16_35, 0.0, 1.0);
    u_xlat16_8.x = u_xlat16_35 * -2.0 + 3.0;
    u_xlat16_35 = u_xlat16_35 * u_xlat16_35;
    u_xlat16_35 = u_xlat16_35 * u_xlat16_8.x;
    u_xlat16_35 = u_xlat16_2.w * u_xlat16_35;
    u_xlatb0 = 0.0<_DoubleDissolve;
    u_xlat16_8.x = (u_xlatb0) ? i.vs_TEXCOORD1.y : 0.0;
    u_xlat16_25 = u_xlat16_25 + (-u_xlat16_8.x);
    u_xlatb0 = 0.0<u_xlat16_8.x;
    u_xlat16_5.x = (-u_xlat16_5.x) + u_xlat16_25;
    u_xlat16_5.x = u_xlat16_15 * u_xlat16_5.x;
    u_xlat16_5.x = clamp(u_xlat16_5.x, 0.0, 1.0);
    u_xlat16_15 = u_xlat16_5.x * -2.0 + 3.0;
    u_xlat16_5.x = u_xlat16_5.x * u_xlat16_5.x;
    u_xlat16_5.x = (-u_xlat16_15) * u_xlat16_5.x + u_xlat16_35;
    u_xlat16_5.x = clamp(u_xlat16_5.x, 0.0, 1.0);
    u_xlat16_5.x = (u_xlatb0) ? u_xlat16_5.x : u_xlat16_35;
    u_xlat0.xy = i.vs_TEXCOORD3.xy / i.vs_TEXCOORD3.ww;
    u_xlat0.x = tex2D(_CameraDepthTexture, u_xlat0.xy).x;
    u_xlat10 = _ZBufferParams.z * u_xlat0.x + _ZBufferParams.w;
    u_xlat0.x = u_xlat0.x * _ProjectionParams.z + _ProjectionParams.y;
    u_xlat10 = float(1.0) / u_xlat10;
    u_xlatb20 = unity_OrthoParams.w==1.0;
    u_xlat0.x = (u_xlatb20) ? u_xlat0.x : u_xlat10;
    u_xlat0.x = u_xlat0.x + (-_SoftParticlesFadeDistanceNear);
    u_xlat0.x = u_xlat0.x + (-i.vs_TEXCOORD3.z);
    u_xlat0.x = u_xlat0.x * _SoftParticlesFadeDistanceFar;
    u_xlat0.x = clamp(u_xlat0.x, 0.0, 1.0);
    u_xlat0.x = u_xlat0.x * u_xlat16_5.x;
    result.w = min(u_xlat0.x, 1.0);
    return result;

}

#elif !defined(SOFTPARTICLES_ON) && defined(_ALPHABLEND_ON) && !defined(_ALPHAMODULATE_ON) && !defined(_ALPHAPREMULTIPLY_ON) && !defined(_ALPHATEST_ON) && !defined(_CFXR_ADDITIVE) && defined(_CFXR_DISSOLVE) && !defined(_CFXR_EDGE_FADING) && !defined(_CFXR_FONT_COLORS) && defined(_CFXR_LIGHTING_ALL) && defined(_CFXR_LIGHTING_BACK) && defined(_CFXR_LIGHTING_WPOS_OFFSET) && !defined(_CFXR_OVERLAYTEX_1X) && !defined(_CFXR_SECONDCOLOR_LERP) && !defined(_CFXR_UV_DISTORTION) && !defined(_EMISSION) && defined(_FADING_ON) && !defined(_FLIPBOOK_BLENDING) && defined(_NORMALMAP)
// Original GLES program 45; _CFXR_DISSOLVE,_CFXR_LIGHTING_ALL,_CFXR_LIGHTING_WPOS_OFFSET,_CFXR_LIGHTING_BACK,_NORMALMAP,_FADING_ON,_ALPHABLEND_ON
float4 _GameObjectWorldPosition;
float _SingleChannel;
float _UseDissolveOffsetUV;
float _BumpScale;
float _LightingWorldPosStrength;
float _IndirectLightingMix;
float4 _ShadowColor;
float _DirectLightingRamp;
float _DirLightScreenAtten;
float _BacklightTransmittance;
float _InvertDissolveTex;
float _DoubleDissolve;
float2 _DissolveScroll;
float _DissolveSmooth;
float _HdrMultiply;
float4 _DissolveTex_ST;
sampler2D _MainTex;
sampler2D _BumpMap;
sampler2D _DissolveTex;
struct A{float4 in_POSITION0:POSITION0;float4 in_COLOR0:COLOR0;float4 in_TEXCOORD0:TEXCOORD0;float4 in_TEXCOORD1:TEXCOORD1;float3 in_NORMAL0:NORMAL0;float4 in_TANGENT0:TANGENT0;};
struct V{float4 vertex:SV_POSITION;float4 vs_COLOR0:TEXCOORD0;float4 vs_TEXCOORD0:TEXCOORD1;float4 vs_TEXCOORD1:TEXCOORD2;float3 vs_TEXCOORD4:TEXCOORD3;float3 vs_TEXCOORD6:TEXCOORD4;float3 vs_TEXCOORD7:TEXCOORD5;float3 vs_NORMAL0:TEXCOORD6;float4 vs_TANGENT0:TEXCOORD7;};
V vert(A i){V o=(V)0;
float4 u_xlat0;
float4 u_xlat1;
float u_xlat6;

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
    o.vs_TEXCOORD1 = i.in_TEXCOORD1;
    o.vs_TEXCOORD4.xyz = i.in_POSITION0.xyz;
    u_xlat0.xyz = (-i.in_POSITION0.xyz) + _WorldSpaceCameraPos.xyz;
    u_xlat6 = dot(u_xlat0.xyz, u_xlat0.xyz);
    u_xlat6 = rsqrt(u_xlat6);
    o.vs_TEXCOORD6.xyz = ((float3)(u_xlat6)) * u_xlat0.xyz;
    o.vs_TEXCOORD7.xyz = (-i.in_POSITION0.xyz) + _GameObjectWorldPosition.xyz;
    o.vs_NORMAL0.xyz = i.in_NORMAL0.xyz;
    o.vs_TANGENT0 = i.in_TANGENT0;
    return o;

}
float4 frag(V i):SV_Target{float4 result=0;
float4 u_xlat0;
float u_xlat16_0;
bool u_xlatb0;
float4 u_xlat1;
float4 u_xlat16_1;
float4 u_xlat2;
float4 u_xlat16_2;
float4 u_xlat3;
float4 u_xlat16_3;
float4 u_xlat4;
float3 u_xlat16_4;
float3 u_xlat16_5;
float4 u_xlat6;
bool2 u_xlatb6;
float4 u_xlat7;
float3 u_xlat16_8;
float3 u_xlat16_9;
float u_xlat10;
float u_xlat16_15;
float2 u_xlat20;
float u_xlat16_25;
float u_xlat31;
bool u_xlatb31;
float u_xlat16_35;

    u_xlat0.x = i.vs_TANGENT0.x;
    u_xlat0.z = i.vs_NORMAL0.x;
    u_xlat1.xyz = i.vs_NORMAL0.zxy * i.vs_TANGENT0.yzx;
    u_xlat1.xyz = i.vs_NORMAL0.yzx * i.vs_TANGENT0.zxy + (-u_xlat1.xyz);
    u_xlat1.xyz = u_xlat1.xzy * i.vs_TANGENT0.www;
    u_xlat0.y = u_xlat1.x;
    u_xlat16_2.xyz = tex2D(_BumpMap, i.vs_TEXCOORD0.xy).xyz;
    u_xlat16_3.xyz = u_xlat16_2.xyz * float3(2.0, 2.0, 2.0) + float3(-1.0, -1.0, -1.0);
    u_xlat16_3.xy = u_xlat16_3.xy * ((float2)(float2(_BumpScale, _BumpScale)));
    u_xlat16_4.x = dot(u_xlat16_3.xyz, u_xlat0.xyz);
    u_xlat0.y = u_xlat1.z;
    u_xlat0.x = i.vs_TANGENT0.y;
    u_xlat0.z = i.vs_NORMAL0.y;
    u_xlat16_4.y = dot(u_xlat16_3.xyz, u_xlat0.xyz);
    u_xlat1.x = i.vs_TANGENT0.z;
    u_xlat1.z = i.vs_NORMAL0.z;
    u_xlat16_4.z = dot(u_xlat16_3.xyz, u_xlat1.xyz);
    u_xlat0 = (-i.vs_TEXCOORD7.xyzz) * ((float4)(_LightingWorldPosStrength)) + u_xlat16_4.xyzz;
    u_xlat1.x = dot(u_xlat0.xyw, u_xlat0.xyw);
    u_xlat1.x = rsqrt(u_xlat1.x);
    u_xlat0 = u_xlat0.xywz * u_xlat1.xxxx;
    u_xlat1 = (-i.vs_TEXCOORD4.yyyy) + unity_4LightPosY0;
    u_xlat2 = u_xlat0.yyyy * u_xlat1;
    u_xlat3 = (-i.vs_TEXCOORD4.xxxx) + unity_4LightPosX0;
    u_xlat2 = u_xlat3 * u_xlat0.xxxx + u_xlat2;
    u_xlat4 = (-i.vs_TEXCOORD4.zzzz) + unity_4LightPosZ0;
    u_xlat2 = u_xlat4 * u_xlat0.zzzz + u_xlat2;
    u_xlat2 = u_xlat2 * float4(0.5, 0.5, 0.5, 0.5) + float4(0.5, 0.5, 0.5, 0.5);
    u_xlat16_5.x = (-_DirectLightingRamp) * 0.5 + 0.5;
    u_xlat2 = u_xlat2 + (-u_xlat16_5.xxxx);
    u_xlat16_15 = _DirectLightingRamp * 0.5 + 0.5;
    u_xlat6.x = (-u_xlat16_5.x) + u_xlat16_15;
    u_xlat16_15 = (-u_xlat16_5.x) + u_xlat16_15;
    u_xlat16_15 = float(1.0) / u_xlat16_15;
    u_xlat6.x = float(1.0) / u_xlat6.x;
    u_xlat2 = u_xlat2 * u_xlat6.xxxx;
    u_xlat2 = clamp(u_xlat2, 0.0, 1.0);
    u_xlat7 = u_xlat2 * float4(-2.0, -2.0, -2.0, -2.0) + float4(3.0, 3.0, 3.0, 3.0);
    u_xlat2 = u_xlat2 * u_xlat2;
    u_xlat2 = u_xlat2 * u_xlat7;
    u_xlat7 = u_xlat1 * u_xlat1;
    u_xlat1 = (-u_xlat0.yyyy) * u_xlat1;
    u_xlat1 = u_xlat3 * (-u_xlat0.xxxx) + u_xlat1;
    u_xlat3 = u_xlat3 * u_xlat3 + u_xlat7;
    u_xlat3 = u_xlat4 * u_xlat4 + u_xlat3;
    u_xlat1 = u_xlat4 * (-u_xlat0.zzzz) + u_xlat1;
    u_xlat1 = u_xlat1 * float4(0.5, 0.5, 0.5, 0.5) + (-u_xlat16_5.xxxx);
    u_xlat1 = u_xlat1 + float4(0.5, 0.5, 0.5, 0.5);
    u_xlat1 = u_xlat6.xxxx * u_xlat1;
    u_xlat1 = clamp(u_xlat1, 0.0, 1.0);
    u_xlat3 = max(u_xlat3, float4(9.99999997e-07, 9.99999997e-07, 9.99999997e-07, 9.99999997e-07));
    u_xlat4 = rsqrt(u_xlat3);
    u_xlat3 = u_xlat3 * unity_4LightAtten0 + float4(1.0, 1.0, 1.0, 1.0);
    u_xlat3 = float4(1.0, 1.0, 1.0, 1.0) / u_xlat3;
    u_xlat2 = u_xlat2 * u_xlat4;
    u_xlat2 = u_xlat3 * u_xlat2;
    u_xlat6.xyz = u_xlat2.yyy * unity_LightColor[1].xyz;
    u_xlat6.xyz = unity_LightColor[0].xyz * u_xlat2.xxx + u_xlat6.xyz;
    u_xlat2.xyz = unity_LightColor[2].xyz * u_xlat2.zzz + u_xlat6.xyz;
    u_xlat2.xyz = unity_LightColor[3].xyz * u_xlat2.www + u_xlat2.xyz;
    u_xlat6 = u_xlat1 * float4(-2.0, -2.0, -2.0, -2.0) + float4(3.0, 3.0, 3.0, 3.0);
    u_xlat1 = u_xlat1 * u_xlat1;
    u_xlat1 = u_xlat1 * u_xlat6;
    u_xlat1 = u_xlat4 * u_xlat1;
    u_xlat1 = u_xlat3 * u_xlat1;
    u_xlat6.xyz = u_xlat1.yyy * unity_LightColor[1].xyz;
    u_xlat6.xyz = unity_LightColor[0].xyz * u_xlat1.xxx + u_xlat6.xyz;
    u_xlat1.xyz = unity_LightColor[2].xyz * u_xlat1.zzz + u_xlat6.xyz;
    u_xlat1.xyz = unity_LightColor[3].xyz * u_xlat1.www + u_xlat1.xyz;
    u_xlat1.xyz = u_xlat1.xyz * ((float3)(float3(_BacklightTransmittance, _BacklightTransmittance, _BacklightTransmittance))) + u_xlat2.xyz;
    u_xlat31 = log2(_HdrMultiply);
    u_xlat31 = u_xlat31 * 0.416666657;
    u_xlat31 = exp2(u_xlat31);
    u_xlat31 = u_xlat31 * 1.05499995 + -0.0549999997;
    u_xlat31 = max(u_xlat31, 0.0);
    u_xlat16_2 = tex2D(_MainTex, i.vs_TEXCOORD0.xy);
    u_xlatb6.xy = lessThan(float4(0.0, 0.0, 0.0, 0.0), float4(_SingleChannel, _UseDissolveOffsetUV, _SingleChannel, _SingleChannel)).xy;
    u_xlat16_3.xyz = (u_xlatb6.x) ? float3(1.0, 1.0, 1.0) : u_xlat16_2.xyz;
    u_xlat16_3.w = (u_xlatb6.x) ? u_xlat16_2.x : u_xlat16_2.w;
    u_xlat16_2 = u_xlat16_3 * i.vs_COLOR0;
    u_xlat16_8.xyz = ((float3)(u_xlat31)) * u_xlat16_2.xyz;
    u_xlatb31 = 0.0<_HdrMultiply;
    u_xlat16_8.xyz = (bool(u_xlatb31)) ? u_xlat16_8.xyz : u_xlat16_2.xyz;
    u_xlat31 = dot(u_xlat0.xyz, _WorldSpaceLightPos0.xyz);
    u_xlat16_25 = u_xlat31 * 0.5 + 0.5;
    u_xlat16_5.x = (-u_xlat16_5.x) + u_xlat16_25;
    u_xlat16_5.x = u_xlat16_15 * u_xlat16_5.x;
    u_xlat16_5.x = clamp(u_xlat16_5.x, 0.0, 1.0);
    u_xlat16_15 = u_xlat16_5.x * -2.0 + 3.0;
    u_xlat6.xzw = i.vs_TEXCOORD6.xyz + _WorldSpaceLightPos0.xyz;
    u_xlat31 = dot(u_xlat6.xzw, u_xlat6.xzw);
    u_xlat31 = sqrt(u_xlat31);
    u_xlat16_25 = float(1.0) / _DirLightScreenAtten;
    u_xlat16_5.z = u_xlat31 * u_xlat16_25;
    u_xlat16_5.z = clamp(u_xlat16_5.z, 0.0, 1.0);
    u_xlat16_35 = u_xlat16_5.z * -2.0 + 3.0;
    u_xlat16_5.xz = u_xlat16_5.xz * u_xlat16_5.xz;
    u_xlat16_25 = (-u_xlat16_35) * u_xlat16_5.z + 1.0;
    u_xlat16_25 = u_xlat16_25 * u_xlat16_25;
    u_xlat16_25 = u_xlat16_25 * _BacklightTransmittance;
    u_xlat16_5.x = u_xlat16_15 * u_xlat16_5.x + u_xlat16_25;
    u_xlat6.xzw = _LightColor0.xyz + (-_ShadowColor.xyz);
    u_xlat6.xzw = u_xlat16_5.xxx * u_xlat6.xzw + _ShadowColor.xyz;
    u_xlat16_5.xyz = u_xlat16_8.xyz * u_xlat6.xzw + u_xlat1.xyz;
    u_xlat16_35 = u_xlat0.y * u_xlat0.y;
    u_xlat16_35 = u_xlat0.x * u_xlat0.x + (-u_xlat16_35);
    u_xlat16_1 = u_xlat0.yzwx * u_xlat0.xywz;
    u_xlat16_8.x = dot(unity_SHBr, u_xlat16_1);
    u_xlat16_8.y = dot(unity_SHBg, u_xlat16_1);
    u_xlat16_8.z = dot(unity_SHBb, u_xlat16_1);
    u_xlat16_8.xyz = unity_SHC.xyz * ((float3)(u_xlat16_35)) + u_xlat16_8.xyz;
    u_xlat0.w = 1.0;
    u_xlat16_9.x = dot(unity_SHAr, u_xlat0);
    u_xlat16_9.y = dot(unity_SHAg, u_xlat0);
    u_xlat16_9.z = dot(unity_SHAb, u_xlat0);
    u_xlat16_8.xyz = u_xlat16_8.xyz + u_xlat16_9.xyz;
    u_xlat16_8.xyz = max(u_xlat16_8.xyz, float3(0.0, 0.0, 0.0));
    u_xlat0.xyz = log2(u_xlat16_8.xyz);
    u_xlat0.xyz = u_xlat0.xyz * float3(0.416666657, 0.416666657, 0.416666657);
    u_xlat0.xyz = exp2(u_xlat0.xyz);
    u_xlat0.xyz = u_xlat0.xyz * float3(1.05499995, 1.05499995, 1.05499995) + float3(-0.0549999997, -0.0549999997, -0.0549999997);
    u_xlat0.xyz = max(u_xlat0.xyz, float3(0.0, 0.0, 0.0));
    result.xyz = u_xlat0.xyz * ((float3)(float3(_IndirectLightingMix, _IndirectLightingMix, _IndirectLightingMix))) + u_xlat16_5.xyz;
    u_xlat0.xy = _Time.yy * float2(_DissolveScroll.x, _DissolveScroll.y);
    u_xlat0.xy = frac(u_xlat0.xy);
    u_xlat20.xy = i.vs_TEXCOORD0.xy * _DissolveTex_ST.xy + _DissolveTex_ST.zw;
    u_xlat0.xy = u_xlat0.xy + u_xlat20.xy;
    u_xlat0.xy = (u_xlatb6.y) ? u_xlat0.xy : i.vs_TEXCOORD0.xy;
    u_xlat16_0 = tex2D(_DissolveTex, u_xlat0.xy).x;
    u_xlat16_5.x = u_xlat16_0 * 2.0 + -1.0;
    u_xlat10 = u_xlat16_5.x * i.vs_TEXCOORD1.z + i.vs_TEXCOORD0.x;
    u_xlat16_5.x = (u_xlatb6.y) ? u_xlat10 : u_xlat16_0;
    u_xlat16_15 = (-u_xlat16_5.x) + 1.0;
    u_xlatb0 = 0.0>=_InvertDissolveTex;
    u_xlat16_5.x = (u_xlatb0) ? u_xlat16_15 : u_xlat16_5.x;
    u_xlat16_15 = u_xlat16_5.x + _DissolveSmooth;
    u_xlat16_5.x = u_xlat16_5.x + (-_DissolveSmooth);
    u_xlat16_15 = (-u_xlat16_5.x) + u_xlat16_15;
    u_xlat16_15 = float(1.0) / u_xlat16_15;
    u_xlat16_25 = _DissolveSmooth * 2.0 + 1.0;
    u_xlat16_25 = i.vs_TEXCOORD1.x * u_xlat16_25 + (-_DissolveSmooth);
    u_xlat16_35 = (-u_xlat16_5.x) + u_xlat16_25;
    u_xlat16_35 = u_xlat16_15 * u_xlat16_35;
    u_xlat16_35 = clamp(u_xlat16_35, 0.0, 1.0);
    u_xlat16_8.x = u_xlat16_35 * -2.0 + 3.0;
    u_xlat16_35 = u_xlat16_35 * u_xlat16_35;
    u_xlat16_35 = u_xlat16_35 * u_xlat16_8.x;
    u_xlat16_35 = u_xlat16_2.w * u_xlat16_35;
    u_xlatb0 = 0.0<_DoubleDissolve;
    u_xlat16_8.x = (u_xlatb0) ? i.vs_TEXCOORD1.y : 0.0;
    u_xlat16_25 = u_xlat16_25 + (-u_xlat16_8.x);
    u_xlatb0 = 0.0<u_xlat16_8.x;
    u_xlat16_5.x = (-u_xlat16_5.x) + u_xlat16_25;
    u_xlat16_5.x = u_xlat16_15 * u_xlat16_5.x;
    u_xlat16_5.x = clamp(u_xlat16_5.x, 0.0, 1.0);
    u_xlat16_15 = u_xlat16_5.x * -2.0 + 3.0;
    u_xlat16_5.x = u_xlat16_5.x * u_xlat16_5.x;
    u_xlat16_5.x = (-u_xlat16_15) * u_xlat16_5.x + u_xlat16_35;
    u_xlat16_5.x = clamp(u_xlat16_5.x, 0.0, 1.0);
    u_xlat16_5.x = (u_xlatb0) ? u_xlat16_5.x : u_xlat16_35;
    result.w = min(u_xlat16_5.x, 1.0);
    return result;

}

#elif defined(SOFTPARTICLES_ON) && defined(_ALPHABLEND_ON) && !defined(_ALPHAMODULATE_ON) && !defined(_ALPHAPREMULTIPLY_ON) && !defined(_ALPHATEST_ON) && !defined(_CFXR_ADDITIVE) && defined(_CFXR_DISSOLVE) && !defined(_CFXR_EDGE_FADING) && !defined(_CFXR_FONT_COLORS) && defined(_CFXR_LIGHTING_ALL) && defined(_CFXR_LIGHTING_BACK) && defined(_CFXR_LIGHTING_WPOS_OFFSET) && !defined(_CFXR_OVERLAYTEX_1X) && !defined(_CFXR_SECONDCOLOR_LERP) && !defined(_CFXR_UV_DISTORTION) && !defined(_EMISSION) && defined(_FADING_ON) && !defined(_FLIPBOOK_BLENDING) && !defined(_NORMALMAP)
// Original GLES program 80; SOFTPARTICLES_ON,_CFXR_DISSOLVE,_CFXR_LIGHTING_ALL,_CFXR_LIGHTING_WPOS_OFFSET,_CFXR_LIGHTING_BACK,_FADING_ON,_ALPHABLEND_ON
float4 _GameObjectWorldPosition;
float _SingleChannel;
float _UseDissolveOffsetUV;
float _LightingWorldPosStrength;
float _IndirectLightingMix;
float4 _ShadowColor;
float _DirectLightingRamp;
float _DirLightScreenAtten;
float _BacklightTransmittance;
float _InvertDissolveTex;
float _DoubleDissolve;
float2 _DissolveScroll;
float _DissolveSmooth;
float _HdrMultiply;
float _SoftParticlesFadeDistanceNear;
float _SoftParticlesFadeDistanceFar;
float4 _DissolveTex_ST;
sampler2D _MainTex;
sampler2D _DissolveTex;
sampler2D _CameraDepthTexture;
struct A{float4 in_POSITION0:POSITION0;float4 in_COLOR0:COLOR0;float4 in_TEXCOORD0:TEXCOORD0;float4 in_TEXCOORD1:TEXCOORD1;float3 in_NORMAL0:NORMAL0;};
struct V{float4 vertex:SV_POSITION;float4 vs_COLOR0:TEXCOORD0;float4 vs_TEXCOORD0:TEXCOORD1;float4 vs_TEXCOORD1:TEXCOORD2;float4 vs_TEXCOORD3:TEXCOORD3;float3 vs_TEXCOORD4:TEXCOORD4;float3 vs_TEXCOORD5:TEXCOORD5;float3 vs_TEXCOORD6:TEXCOORD6;float3 vs_TEXCOORD7:TEXCOORD7;float3 vs_NORMAL0:TEXCOORD8;};
V vert(A i){V o=(V)0;
float4 u_xlat0;
float4 u_xlat16_0;
float4 u_xlat1;
float3 u_xlat16_2;
float3 u_xlat16_3;
float u_xlat4;
float u_xlat13;

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
    o.vs_TEXCOORD1 = i.in_TEXCOORD1;
    u_xlat4 = u_xlat0.y * transpose(unity_MatrixV)[1].z;
    u_xlat0.x = transpose(unity_MatrixV)[0].z * u_xlat0.x + u_xlat4;
    u_xlat0.x = transpose(unity_MatrixV)[2].z * u_xlat0.z + u_xlat0.x;
    u_xlat0.x = transpose(unity_MatrixV)[3].z * u_xlat0.w + u_xlat0.x;
    o.vs_TEXCOORD3.z = (-u_xlat0.x);
    u_xlat0.x = u_xlat1.y * _ProjectionParams.x;
    u_xlat0.w = u_xlat0.x * 0.5;
    u_xlat0.xz = u_xlat1.xw * float2(0.5, 0.5);
    o.vs_TEXCOORD3.w = u_xlat1.w;
    o.vs_TEXCOORD3.xy = u_xlat0.zz + u_xlat0.xw;
    o.vs_TEXCOORD4.xyz = i.in_POSITION0.xyz;
    u_xlat16_2.x = i.in_NORMAL0.y * i.in_NORMAL0.y;
    u_xlat16_2.x = i.in_NORMAL0.x * i.in_NORMAL0.x + (-u_xlat16_2.x);
    u_xlat16_0 = i.in_NORMAL0.yzzx * i.in_NORMAL0.xyzz;
    u_xlat16_3.x = dot(unity_SHBr, u_xlat16_0);
    u_xlat16_3.y = dot(unity_SHBg, u_xlat16_0);
    u_xlat16_3.z = dot(unity_SHBb, u_xlat16_0);
    u_xlat16_2.xyz = unity_SHC.xyz * u_xlat16_2.xxx + u_xlat16_3.xyz;
    u_xlat0.xyz = i.in_NORMAL0.xyz;
    u_xlat0.w = 1.0;
    u_xlat16_3.x = dot(unity_SHAr, u_xlat0);
    u_xlat16_3.y = dot(unity_SHAg, u_xlat0);
    u_xlat16_3.z = dot(unity_SHAb, u_xlat0);
    u_xlat16_2.xyz = u_xlat16_2.xyz + u_xlat16_3.xyz;
    u_xlat16_2.xyz = max(u_xlat16_2.xyz, float3(0.0, 0.0, 0.0));
    u_xlat1.xyz = log2(u_xlat16_2.xyz);
    u_xlat1.xyz = u_xlat1.xyz * float3(0.416666657, 0.416666657, 0.416666657);
    u_xlat1.xyz = exp2(u_xlat1.xyz);
    u_xlat1.xyz = u_xlat1.xyz * float3(1.05499995, 1.05499995, 1.05499995) + float3(-0.0549999997, -0.0549999997, -0.0549999997);
    o.vs_TEXCOORD5.xyz = max(u_xlat1.xyz, float3(0.0, 0.0, 0.0));
    u_xlat1.xyz = (-i.in_POSITION0.xyz) + _WorldSpaceCameraPos.xyz;
    u_xlat13 = dot(u_xlat1.xyz, u_xlat1.xyz);
    u_xlat13 = rsqrt(u_xlat13);
    o.vs_TEXCOORD6.xyz = ((float3)(u_xlat13)) * u_xlat1.xyz;
    o.vs_TEXCOORD7.xyz = (-i.in_POSITION0.xyz) + _GameObjectWorldPosition.xyz;
    o.vs_NORMAL0.xyz = i.in_NORMAL0.xyz;
    return o;

}
float4 frag(V i):SV_Target{float4 result=0;
float4 u_xlat0;
float u_xlat16_0;
bool u_xlatb0;
float4 u_xlat1;
float4 u_xlat16_1;
float4 u_xlat2;
bool2 u_xlatb2;
float4 u_xlat3;
float4 u_xlat16_3;
float4 u_xlat4;
float3 u_xlat16_5;
float4 u_xlat6;
float u_xlat16_7;
float u_xlat8;
float3 u_xlat16_13;
float u_xlat16_15;
float2 u_xlat16;
bool u_xlatb16;
float u_xlat16_21;
float u_xlat16_23;
float u_xlat24;
bool u_xlatb24;
float u_xlat16_29;

    u_xlat0.xyz = (-i.vs_TEXCOORD7.xyz) * ((float3)(_LightingWorldPosStrength)) + i.vs_NORMAL0.xyz;
    u_xlat24 = dot(u_xlat0.xyz, u_xlat0.xyz);
    u_xlat24 = rsqrt(u_xlat24);
    u_xlat0.xyz = ((float3)(u_xlat24)) * u_xlat0.xyz;
    u_xlat1 = (-i.vs_TEXCOORD4.yyyy) + unity_4LightPosY0;
    u_xlat2 = u_xlat0.yyyy * u_xlat1;
    u_xlat3 = (-i.vs_TEXCOORD4.xxxx) + unity_4LightPosX0;
    u_xlat2 = u_xlat3 * u_xlat0.xxxx + u_xlat2;
    u_xlat4 = (-i.vs_TEXCOORD4.zzzz) + unity_4LightPosZ0;
    u_xlat2 = u_xlat4 * u_xlat0.zzzz + u_xlat2;
    u_xlat2 = u_xlat2 * float4(0.5, 0.5, 0.5, 0.5) + float4(0.5, 0.5, 0.5, 0.5);
    u_xlat16_5.x = (-_DirectLightingRamp) * 0.5 + 0.5;
    u_xlat2 = u_xlat2 + (-u_xlat16_5.xxxx);
    u_xlat16_13.x = _DirectLightingRamp * 0.5 + 0.5;
    u_xlat24 = (-u_xlat16_5.x) + u_xlat16_13.x;
    u_xlat16_13.x = (-u_xlat16_5.x) + u_xlat16_13.x;
    u_xlat16_13.x = float(1.0) / u_xlat16_13.x;
    u_xlat24 = float(1.0) / u_xlat24;
    u_xlat2 = ((float4)(u_xlat24)) * u_xlat2;
    u_xlat2 = clamp(u_xlat2, 0.0, 1.0);
    u_xlat6 = u_xlat2 * float4(-2.0, -2.0, -2.0, -2.0) + float4(3.0, 3.0, 3.0, 3.0);
    u_xlat2 = u_xlat2 * u_xlat2;
    u_xlat2 = u_xlat2 * u_xlat6;
    u_xlat6 = u_xlat1 * u_xlat1;
    u_xlat1 = (-u_xlat0.yyyy) * u_xlat1;
    u_xlat1 = u_xlat3 * (-u_xlat0.xxxx) + u_xlat1;
    u_xlat3 = u_xlat3 * u_xlat3 + u_xlat6;
    u_xlat3 = u_xlat4 * u_xlat4 + u_xlat3;
    u_xlat1 = u_xlat4 * (-u_xlat0.zzzz) + u_xlat1;
    u_xlat0.x = dot(u_xlat0.xyz, _WorldSpaceLightPos0.xyz);
    u_xlat16_21 = u_xlat0.x * 0.5 + 0.5;
    u_xlat16_21 = (-u_xlat16_5.x) + u_xlat16_21;
    u_xlat1 = u_xlat1 * float4(0.5, 0.5, 0.5, 0.5) + (-u_xlat16_5.xxxx);
    u_xlat1 = u_xlat1 + float4(0.5, 0.5, 0.5, 0.5);
    u_xlat0 = ((float4)(u_xlat24)) * u_xlat1;
    u_xlat0 = clamp(u_xlat0, 0.0, 1.0);
    u_xlat16_5.x = u_xlat16_13.x * u_xlat16_21;
    u_xlat16_5.x = clamp(u_xlat16_5.x, 0.0, 1.0);
    u_xlat1 = max(u_xlat3, float4(9.99999997e-07, 9.99999997e-07, 9.99999997e-07, 9.99999997e-07));
    u_xlat3 = rsqrt(u_xlat1);
    u_xlat1 = u_xlat1 * unity_4LightAtten0 + float4(1.0, 1.0, 1.0, 1.0);
    u_xlat1 = float4(1.0, 1.0, 1.0, 1.0) / u_xlat1;
    u_xlat2 = u_xlat2 * u_xlat3;
    u_xlat2 = u_xlat1 * u_xlat2;
    u_xlat4.xyz = u_xlat2.yyy * unity_LightColor[1].xyz;
    u_xlat4.xyz = unity_LightColor[0].xyz * u_xlat2.xxx + u_xlat4.xyz;
    u_xlat2.xyz = unity_LightColor[2].xyz * u_xlat2.zzz + u_xlat4.xyz;
    u_xlat2.xyz = unity_LightColor[3].xyz * u_xlat2.www + u_xlat2.xyz;
    u_xlat4 = u_xlat0 * float4(-2.0, -2.0, -2.0, -2.0) + float4(3.0, 3.0, 3.0, 3.0);
    u_xlat0 = u_xlat0 * u_xlat0;
    u_xlat0 = u_xlat0 * u_xlat4;
    u_xlat0 = u_xlat3 * u_xlat0;
    u_xlat0 = u_xlat1 * u_xlat0;
    u_xlat1.xyz = u_xlat0.yyy * unity_LightColor[1].xyz;
    u_xlat1.xyz = unity_LightColor[0].xyz * u_xlat0.xxx + u_xlat1.xyz;
    u_xlat0.xyz = unity_LightColor[2].xyz * u_xlat0.zzz + u_xlat1.xyz;
    u_xlat0.xyz = unity_LightColor[3].xyz * u_xlat0.www + u_xlat0.xyz;
    u_xlat0.xyz = u_xlat0.xyz * ((float3)(float3(_BacklightTransmittance, _BacklightTransmittance, _BacklightTransmittance))) + u_xlat2.xyz;
    u_xlat24 = log2(_HdrMultiply);
    u_xlat24 = u_xlat24 * 0.416666657;
    u_xlat24 = exp2(u_xlat24);
    u_xlat24 = u_xlat24 * 1.05499995 + -0.0549999997;
    u_xlat24 = max(u_xlat24, 0.0);
    u_xlat16_1 = tex2D(_MainTex, i.vs_TEXCOORD0.xy);
    u_xlatb2.xy = lessThan(float4(0.0, 0.0, 0.0, 0.0), float4(_SingleChannel, _UseDissolveOffsetUV, _SingleChannel, _SingleChannel)).xy;
    u_xlat16_3.xyz = (u_xlatb2.x) ? float3(1.0, 1.0, 1.0) : u_xlat16_1.xyz;
    u_xlat16_3.w = (u_xlatb2.x) ? u_xlat16_1.x : u_xlat16_1.w;
    u_xlat16_1 = u_xlat16_3 * i.vs_COLOR0;
    u_xlat16_13.xyz = ((float3)(u_xlat24)) * u_xlat16_1.xyz;
    u_xlatb24 = 0.0<_HdrMultiply;
    u_xlat16_13.xyz = (bool(u_xlatb24)) ? u_xlat16_13.xyz : u_xlat16_1.xyz;
    u_xlat16_7 = u_xlat16_5.x * -2.0 + 3.0;
    u_xlat16_5.x = u_xlat16_5.x * u_xlat16_5.x;
    u_xlat2.xzw = i.vs_TEXCOORD6.xyz + _WorldSpaceLightPos0.xyz;
    u_xlat24 = dot(u_xlat2.xzw, u_xlat2.xzw);
    u_xlat24 = sqrt(u_xlat24);
    u_xlat16_15 = float(1.0) / _DirLightScreenAtten;
    u_xlat16_15 = u_xlat24 * u_xlat16_15;
    u_xlat16_15 = clamp(u_xlat16_15, 0.0, 1.0);
    u_xlat16_23 = u_xlat16_15 * -2.0 + 3.0;
    u_xlat16_15 = u_xlat16_15 * u_xlat16_15;
    u_xlat16_15 = (-u_xlat16_23) * u_xlat16_15 + 1.0;
    u_xlat16_15 = u_xlat16_15 * u_xlat16_15;
    u_xlat16_15 = u_xlat16_15 * _BacklightTransmittance;
    u_xlat16_5.x = u_xlat16_7 * u_xlat16_5.x + u_xlat16_15;
    u_xlat2.xzw = _LightColor0.xyz + (-_ShadowColor.xyz);
    u_xlat2.xzw = u_xlat16_5.xxx * u_xlat2.xzw + _ShadowColor.xyz;
    u_xlat16_5.xyz = u_xlat16_13.xyz * u_xlat2.xzw + u_xlat0.xyz;
    u_xlat0.xyz = i.vs_TEXCOORD5.xyz * ((float3)(float3(_IndirectLightingMix, _IndirectLightingMix, _IndirectLightingMix))) + u_xlat16_5.xyz;
    result.xyz = u_xlat0.xyz;
    u_xlat0.xy = _Time.yy * float2(_DissolveScroll.x, _DissolveScroll.y);
    u_xlat0.xy = frac(u_xlat0.xy);
    u_xlat16.xy = i.vs_TEXCOORD0.xy * _DissolveTex_ST.xy + _DissolveTex_ST.zw;
    u_xlat0.xy = u_xlat0.xy + u_xlat16.xy;
    u_xlat0.xy = (u_xlatb2.y) ? u_xlat0.xy : i.vs_TEXCOORD0.xy;
    u_xlat16_0 = tex2D(_DissolveTex, u_xlat0.xy).x;
    u_xlat16_5.x = u_xlat16_0 * 2.0 + -1.0;
    u_xlat8 = u_xlat16_5.x * i.vs_TEXCOORD1.z + i.vs_TEXCOORD0.x;
    u_xlat16_5.x = (u_xlatb2.y) ? u_xlat8 : u_xlat16_0;
    u_xlat16_13.x = (-u_xlat16_5.x) + 1.0;
    u_xlatb0 = 0.0>=_InvertDissolveTex;
    u_xlat16_5.x = (u_xlatb0) ? u_xlat16_13.x : u_xlat16_5.x;
    u_xlat16_13.x = u_xlat16_5.x + _DissolveSmooth;
    u_xlat16_5.x = u_xlat16_5.x + (-_DissolveSmooth);
    u_xlat16_13.x = (-u_xlat16_5.x) + u_xlat16_13.x;
    u_xlat16_13.x = float(1.0) / u_xlat16_13.x;
    u_xlat16_21 = _DissolveSmooth * 2.0 + 1.0;
    u_xlat16_21 = i.vs_TEXCOORD1.x * u_xlat16_21 + (-_DissolveSmooth);
    u_xlat16_29 = (-u_xlat16_5.x) + u_xlat16_21;
    u_xlat16_29 = u_xlat16_13.x * u_xlat16_29;
    u_xlat16_29 = clamp(u_xlat16_29, 0.0, 1.0);
    u_xlat16_7 = u_xlat16_29 * -2.0 + 3.0;
    u_xlat16_29 = u_xlat16_29 * u_xlat16_29;
    u_xlat16_29 = u_xlat16_29 * u_xlat16_7;
    u_xlat16_29 = u_xlat16_1.w * u_xlat16_29;
    u_xlatb0 = 0.0<_DoubleDissolve;
    u_xlat16_7 = (u_xlatb0) ? i.vs_TEXCOORD1.y : 0.0;
    u_xlat16_21 = u_xlat16_21 + (-u_xlat16_7);
    u_xlatb0 = 0.0<u_xlat16_7;
    u_xlat16_5.x = (-u_xlat16_5.x) + u_xlat16_21;
    u_xlat16_5.x = u_xlat16_13.x * u_xlat16_5.x;
    u_xlat16_5.x = clamp(u_xlat16_5.x, 0.0, 1.0);
    u_xlat16_13.x = u_xlat16_5.x * -2.0 + 3.0;
    u_xlat16_5.x = u_xlat16_5.x * u_xlat16_5.x;
    u_xlat16_5.x = (-u_xlat16_13.x) * u_xlat16_5.x + u_xlat16_29;
    u_xlat16_5.x = clamp(u_xlat16_5.x, 0.0, 1.0);
    u_xlat16_5.x = (u_xlatb0) ? u_xlat16_5.x : u_xlat16_29;
    u_xlat0.xy = i.vs_TEXCOORD3.xy / i.vs_TEXCOORD3.ww;
    u_xlat0.x = tex2D(_CameraDepthTexture, u_xlat0.xy).x;
    u_xlat8 = _ZBufferParams.z * u_xlat0.x + _ZBufferParams.w;
    u_xlat0.x = u_xlat0.x * _ProjectionParams.z + _ProjectionParams.y;
    u_xlat8 = float(1.0) / u_xlat8;
    u_xlatb16 = unity_OrthoParams.w==1.0;
    u_xlat0.x = (u_xlatb16) ? u_xlat0.x : u_xlat8;
    u_xlat0.x = u_xlat0.x + (-_SoftParticlesFadeDistanceNear);
    u_xlat0.x = u_xlat0.x + (-i.vs_TEXCOORD3.z);
    u_xlat0.x = u_xlat0.x * _SoftParticlesFadeDistanceFar;
    u_xlat0.x = clamp(u_xlat0.x, 0.0, 1.0);
    u_xlat0.x = u_xlat0.x * u_xlat16_5.x;
    result.w = min(u_xlat0.x, 1.0);
    return result;

}

#elif defined(SOFTPARTICLES_ON) && defined(_ALPHABLEND_ON) && !defined(_ALPHAMODULATE_ON) && !defined(_ALPHAPREMULTIPLY_ON) && defined(_ALPHATEST_ON) && !defined(_CFXR_ADDITIVE) && !defined(_CFXR_DISSOLVE) && !defined(_CFXR_EDGE_FADING) && !defined(_CFXR_FONT_COLORS) && defined(_CFXR_LIGHTING_ALL) && defined(_CFXR_LIGHTING_BACK) && !defined(_CFXR_LIGHTING_WPOS_OFFSET) && !defined(_CFXR_OVERLAYTEX_1X) && !defined(_CFXR_SECONDCOLOR_LERP) && !defined(_CFXR_UV_DISTORTION) && !defined(_EMISSION) && defined(_FADING_ON) && !defined(_FLIPBOOK_BLENDING) && defined(_NORMALMAP)
// Original GLES program 92; SOFTPARTICLES_ON,_CFXR_LIGHTING_ALL,_CFXR_LIGHTING_BACK,_NORMALMAP,_FADING_ON,_ALPHATEST_ON,_ALPHABLEND_ON
float _SingleChannel;
float _BumpScale;
float _IndirectLightingMix;
float4 _ShadowColor;
float _DirectLightingRamp;
float _DirLightScreenAtten;
float _BacklightTransmittance;
float _HdrMultiply;
float _Cutoff;
float _SoftParticlesFadeDistanceNear;
float _SoftParticlesFadeDistanceFar;
sampler2D _MainTex;
sampler2D _BumpMap;
sampler2D _CameraDepthTexture;
struct A{float4 in_POSITION0:POSITION0;float4 in_COLOR0:COLOR0;float4 in_TEXCOORD0:TEXCOORD0;float4 in_TEXCOORD1:TEXCOORD1;float3 in_NORMAL0:NORMAL0;float4 in_TANGENT0:TANGENT0;};
struct V{float4 vertex:SV_POSITION;float4 vs_COLOR0:TEXCOORD0;float4 vs_TEXCOORD0:TEXCOORD1;float4 vs_TEXCOORD3:TEXCOORD2;float3 vs_TEXCOORD4:TEXCOORD3;float3 vs_TEXCOORD6:TEXCOORD4;float3 vs_NORMAL0:TEXCOORD5;float4 vs_TANGENT0:TEXCOORD6;};
V vert(A i){V o=(V)0;
float4 vs_TEXCOORD1;
float4 u_xlat0;
float4 u_xlat1;
float u_xlat2;
float u_xlat6;

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
    o.vs_TEXCOORD3.z = (-u_xlat0.x);
    u_xlat0.x = u_xlat1.y * _ProjectionParams.x;
    u_xlat0.w = u_xlat0.x * 0.5;
    u_xlat0.xz = u_xlat1.xw * float2(0.5, 0.5);
    o.vs_TEXCOORD3.w = u_xlat1.w;
    o.vs_TEXCOORD3.xy = u_xlat0.zz + u_xlat0.xw;
    o.vs_TEXCOORD4.xyz = i.in_POSITION0.xyz;
    u_xlat0.xyz = (-i.in_POSITION0.xyz) + _WorldSpaceCameraPos.xyz;
    u_xlat6 = dot(u_xlat0.xyz, u_xlat0.xyz);
    u_xlat6 = rsqrt(u_xlat6);
    o.vs_TEXCOORD6.xyz = ((float3)(u_xlat6)) * u_xlat0.xyz;
    o.vs_NORMAL0.xyz = i.in_NORMAL0.xyz;
    o.vs_TANGENT0 = i.in_TANGENT0;
    return o;

}
float4 frag(V i):SV_Target{float4 result=0;
float4 u_xlat16_0;
float3 u_xlat1;
float4 u_xlat16_1;
bool u_xlatb1;
float4 u_xlat16_2;
float4 u_xlat3;
float4 u_xlat16_3;
float4 u_xlat4;
float3 u_xlat16_4;
float4 u_xlat5;
float3 u_xlat16_5;
float4 u_xlat6;
float3 u_xlat16_7;
float4 u_xlat8;
float4 u_xlat9;
float3 u_xlat16_10;
float u_xlat15;
float u_xlat16_18;
bool u_xlatb26;
float u_xlat16_29;
float u_xlat16_35;
float u_xlat36;

    u_xlat16_0 = tex2D(_MainTex, i.vs_TEXCOORD0.xy);
    u_xlatb1 = 0.0<_SingleChannel;
    u_xlat16_2.w = (u_xlatb1) ? u_xlat16_0.x : u_xlat16_0.w;
    u_xlat16_2.xyz = (bool(u_xlatb1)) ? float3(1.0, 1.0, 1.0) : u_xlat16_0.xyz;
    u_xlat16_0 = u_xlat16_2 * i.vs_COLOR0;
    u_xlat16_2.x = u_xlat16_2.w * i.vs_COLOR0.w + (-_Cutoff);
    u_xlatb1 = u_xlat16_2.x<0.0;
    if(u_xlatb1){discard;}
    u_xlat1.x = log2(_HdrMultiply);
    u_xlat1.x = u_xlat1.x * 0.416666657;
    u_xlat1.x = exp2(u_xlat1.x);
    u_xlat1.x = u_xlat1.x * 1.05499995 + -0.0549999997;
    u_xlat1.x = max(u_xlat1.x, 0.0);
    u_xlat16_2.xyz = u_xlat16_0.xyz * u_xlat1.xxx;
    u_xlatb1 = 0.0<_HdrMultiply;
    u_xlat16_2.xyz = (bool(u_xlatb1)) ? u_xlat16_2.xyz : u_xlat16_0.xyz;
    u_xlat1.x = i.vs_TANGENT0.z;
    u_xlat1.z = i.vs_NORMAL0.z;
    u_xlat3.xyz = i.vs_NORMAL0.zxy * i.vs_TANGENT0.yzx;
    u_xlat3.xyz = i.vs_NORMAL0.yzx * i.vs_TANGENT0.zxy + (-u_xlat3.xyz);
    u_xlat3.xyz = u_xlat3.xyz * i.vs_TANGENT0.www;
    u_xlat1.y = u_xlat3.z;
    u_xlat16_4.xyz = tex2D(_BumpMap, i.vs_TEXCOORD0.xy).xyz;
    u_xlat16_5.xyz = u_xlat16_4.xyz * float3(2.0, 2.0, 2.0) + float3(-1.0, -1.0, -1.0);
    u_xlat16_5.xy = u_xlat16_5.xy * ((float2)(float2(_BumpScale, _BumpScale)));
    u_xlat16_1.z = dot(u_xlat16_5.xyz, u_xlat1.xyz);
    u_xlat4.y = u_xlat3.x;
    u_xlat4.x = i.vs_TANGENT0.x;
    u_xlat4.z = i.vs_NORMAL0.x;
    u_xlat16_1.x = dot(u_xlat16_5.xyz, u_xlat4.xyz);
    u_xlat3.x = i.vs_TANGENT0.y;
    u_xlat3.z = i.vs_NORMAL0.y;
    u_xlat16_1.y = dot(u_xlat16_5.xyz, u_xlat3.xyz);
    u_xlat3 = (-i.vs_TEXCOORD4.yyyy) + unity_4LightPosY0;
    u_xlat4 = u_xlat16_1.yyyy * u_xlat3;
    u_xlat5 = (-i.vs_TEXCOORD4.xxxx) + unity_4LightPosX0;
    u_xlat4 = u_xlat5 * u_xlat16_1.xxxx + u_xlat4;
    u_xlat6 = (-i.vs_TEXCOORD4.zzzz) + unity_4LightPosZ0;
    u_xlat4 = u_xlat6 * u_xlat16_1.zzzz + u_xlat4;
    u_xlat4 = u_xlat4 * float4(0.5, 0.5, 0.5, 0.5) + float4(0.5, 0.5, 0.5, 0.5);
    u_xlat16_35 = (-_DirectLightingRamp) * 0.5 + 0.5;
    u_xlat4 = (-((float4)(u_xlat16_35))) + u_xlat4;
    u_xlat16_7.x = _DirectLightingRamp * 0.5 + 0.5;
    u_xlat8.x = (-u_xlat16_35) + u_xlat16_7.x;
    u_xlat16_7.x = (-u_xlat16_35) + u_xlat16_7.x;
    u_xlat16_7.x = float(1.0) / u_xlat16_7.x;
    u_xlat8.x = float(1.0) / u_xlat8.x;
    u_xlat4 = u_xlat4 * u_xlat8.xxxx;
    u_xlat4 = clamp(u_xlat4, 0.0, 1.0);
    u_xlat9 = u_xlat4 * float4(-2.0, -2.0, -2.0, -2.0) + float4(3.0, 3.0, 3.0, 3.0);
    u_xlat4 = u_xlat4 * u_xlat4;
    u_xlat4 = u_xlat4 * u_xlat9;
    u_xlat9 = u_xlat3 * u_xlat3;
    u_xlat3 = (-u_xlat16_1.yyyy) * u_xlat3;
    u_xlat3 = u_xlat5 * (-u_xlat16_1.xxxx) + u_xlat3;
    u_xlat5 = u_xlat5 * u_xlat5 + u_xlat9;
    u_xlat5 = u_xlat6 * u_xlat6 + u_xlat5;
    u_xlat3 = u_xlat6 * (-u_xlat16_1.zzzz) + u_xlat3;
    u_xlat3 = u_xlat3 * float4(0.5, 0.5, 0.5, 0.5) + (-((float4)(u_xlat16_35)));
    u_xlat3 = u_xlat3 + float4(0.5, 0.5, 0.5, 0.5);
    u_xlat3 = u_xlat8.xxxx * u_xlat3;
    u_xlat3 = clamp(u_xlat3, 0.0, 1.0);
    u_xlat5 = max(u_xlat5, float4(9.99999997e-07, 9.99999997e-07, 9.99999997e-07, 9.99999997e-07));
    u_xlat6 = rsqrt(u_xlat5);
    u_xlat5 = u_xlat5 * unity_4LightAtten0 + float4(1.0, 1.0, 1.0, 1.0);
    u_xlat5 = float4(1.0, 1.0, 1.0, 1.0) / u_xlat5;
    u_xlat4 = u_xlat4 * u_xlat6;
    u_xlat4 = u_xlat5 * u_xlat4;
    u_xlat8.xyz = u_xlat4.yyy * unity_LightColor[1].xyz;
    u_xlat8.xyz = unity_LightColor[0].xyz * u_xlat4.xxx + u_xlat8.xyz;
    u_xlat4.xyz = unity_LightColor[2].xyz * u_xlat4.zzz + u_xlat8.xyz;
    u_xlat4.xyz = unity_LightColor[3].xyz * u_xlat4.www + u_xlat4.xyz;
    u_xlat8 = u_xlat3 * float4(-2.0, -2.0, -2.0, -2.0) + float4(3.0, 3.0, 3.0, 3.0);
    u_xlat3 = u_xlat3 * u_xlat3;
    u_xlat3 = u_xlat3 * u_xlat8;
    u_xlat3 = u_xlat6 * u_xlat3;
    u_xlat3 = u_xlat5 * u_xlat3;
    u_xlat6.xyz = u_xlat3.yyy * unity_LightColor[1].xyz;
    u_xlat6.xyz = unity_LightColor[0].xyz * u_xlat3.xxx + u_xlat6.xyz;
    u_xlat3.xyz = unity_LightColor[2].xyz * u_xlat3.zzz + u_xlat6.xyz;
    u_xlat3.xyz = unity_LightColor[3].xyz * u_xlat3.www + u_xlat3.xyz;
    u_xlat3.xyz = u_xlat3.xyz * ((float3)(float3(_BacklightTransmittance, _BacklightTransmittance, _BacklightTransmittance))) + u_xlat4.xyz;
    u_xlat4.xyz = i.vs_TEXCOORD6.xyz + _WorldSpaceLightPos0.xyz;
    u_xlat36 = dot(u_xlat4.xyz, u_xlat4.xyz);
    u_xlat36 = sqrt(u_xlat36);
    u_xlat16_18 = float(1.0) / _DirLightScreenAtten;
    u_xlat16_18 = u_xlat36 * u_xlat16_18;
    u_xlat16_18 = clamp(u_xlat16_18, 0.0, 1.0);
    u_xlat16_29 = u_xlat16_18 * -2.0 + 3.0;
    u_xlat16_18 = u_xlat16_18 * u_xlat16_18;
    u_xlat16_18 = (-u_xlat16_29) * u_xlat16_18 + 1.0;
    u_xlat16_18 = u_xlat16_18 * u_xlat16_18;
    u_xlat16_18 = u_xlat16_18 * _BacklightTransmittance;
    u_xlat36 = dot(u_xlat16_1.xyz, _WorldSpaceLightPos0.xyz);
    u_xlat16_29 = u_xlat36 * 0.5 + 0.5;
    u_xlat16_35 = (-u_xlat16_35) + u_xlat16_29;
    u_xlat16_35 = u_xlat16_7.x * u_xlat16_35;
    u_xlat16_35 = clamp(u_xlat16_35, 0.0, 1.0);
    u_xlat16_7.x = u_xlat16_35 * -2.0 + 3.0;
    u_xlat16_35 = u_xlat16_35 * u_xlat16_35;
    u_xlat16_35 = u_xlat16_7.x * u_xlat16_35 + u_xlat16_18;
    u_xlat4.xyz = _LightColor0.xyz + (-_ShadowColor.xyz);
    u_xlat4.xyz = ((float3)(u_xlat16_35)) * u_xlat4.xyz + _ShadowColor.xyz;
    u_xlat16_2.xyz = u_xlat16_2.xyz * u_xlat4.xyz + u_xlat3.xyz;
    u_xlat16_35 = u_xlat16_1.y * u_xlat16_1.y;
    u_xlat16_35 = u_xlat16_1.x * u_xlat16_1.x + (-u_xlat16_35);
    u_xlat16_3 = u_xlat16_1.yzzx * u_xlat16_1.xyzz;
    u_xlat16_7.x = dot(unity_SHBr, u_xlat16_3);
    u_xlat16_7.y = dot(unity_SHBg, u_xlat16_3);
    u_xlat16_7.z = dot(unity_SHBb, u_xlat16_3);
    u_xlat16_7.xyz = unity_SHC.xyz * ((float3)(u_xlat16_35)) + u_xlat16_7.xyz;
    u_xlat16_1.w = 1.0;
    u_xlat16_10.x = dot(unity_SHAr, u_xlat16_1);
    u_xlat16_10.y = dot(unity_SHAg, u_xlat16_1);
    u_xlat16_10.z = dot(unity_SHAb, u_xlat16_1);
    u_xlat16_7.xyz = u_xlat16_7.xyz + u_xlat16_10.xyz;
    u_xlat16_7.xyz = max(u_xlat16_7.xyz, float3(0.0, 0.0, 0.0));
    u_xlat4.xyz = log2(u_xlat16_7.xyz);
    u_xlat4.xyz = u_xlat4.xyz * float3(0.416666657, 0.416666657, 0.416666657);
    u_xlat4.xyz = exp2(u_xlat4.xyz);
    u_xlat4.xyz = u_xlat4.xyz * float3(1.05499995, 1.05499995, 1.05499995) + float3(-0.0549999997, -0.0549999997, -0.0549999997);
    u_xlat4.xyz = max(u_xlat4.xyz, float3(0.0, 0.0, 0.0));
    result.xyz = u_xlat4.xyz * ((float3)(float3(_IndirectLightingMix, _IndirectLightingMix, _IndirectLightingMix))) + u_xlat16_2.xyz;
    u_xlat4.xy = i.vs_TEXCOORD3.xy / i.vs_TEXCOORD3.ww;
    u_xlat4.x = tex2D(_CameraDepthTexture, u_xlat4.xy).x;
    u_xlat15 = _ZBufferParams.z * u_xlat4.x + _ZBufferParams.w;
    u_xlat4.x = u_xlat4.x * _ProjectionParams.z + _ProjectionParams.y;
    u_xlat15 = float(1.0) / u_xlat15;
    u_xlatb26 = unity_OrthoParams.w==1.0;
    u_xlat4.x = (u_xlatb26) ? u_xlat4.x : u_xlat15;
    u_xlat4.x = u_xlat4.x + (-_SoftParticlesFadeDistanceNear);
    u_xlat4.x = u_xlat4.x + (-i.vs_TEXCOORD3.z);
    u_xlat4.x = u_xlat4.x * _SoftParticlesFadeDistanceFar;
    u_xlat4.x = clamp(u_xlat4.x, 0.0, 1.0);
    u_xlat4.x = u_xlat16_0.w * u_xlat4.x;
    result.w = min(u_xlat4.x, 1.0);
    return result;

}

#elif !defined(SOFTPARTICLES_ON) && defined(_ALPHABLEND_ON) && !defined(_ALPHAMODULATE_ON) && !defined(_ALPHAPREMULTIPLY_ON) && !defined(_ALPHATEST_ON) && !defined(_CFXR_ADDITIVE) && defined(_CFXR_DISSOLVE) && !defined(_CFXR_EDGE_FADING) && !defined(_CFXR_FONT_COLORS) && defined(_CFXR_LIGHTING_ALL) && defined(_CFXR_LIGHTING_BACK) && defined(_CFXR_LIGHTING_WPOS_OFFSET) && !defined(_CFXR_OVERLAYTEX_1X) && !defined(_CFXR_SECONDCOLOR_LERP) && !defined(_CFXR_UV_DISTORTION) && !defined(_EMISSION) && defined(_FADING_ON) && !defined(_FLIPBOOK_BLENDING) && !defined(_NORMALMAP)
// Original GLES program 44; _CFXR_DISSOLVE,_CFXR_LIGHTING_ALL,_CFXR_LIGHTING_WPOS_OFFSET,_CFXR_LIGHTING_BACK,_FADING_ON,_ALPHABLEND_ON
float4 _GameObjectWorldPosition;
float _SingleChannel;
float _UseDissolveOffsetUV;
float _LightingWorldPosStrength;
float _IndirectLightingMix;
float4 _ShadowColor;
float _DirectLightingRamp;
float _DirLightScreenAtten;
float _BacklightTransmittance;
float _InvertDissolveTex;
float _DoubleDissolve;
float2 _DissolveScroll;
float _DissolveSmooth;
float _HdrMultiply;
float4 _DissolveTex_ST;
sampler2D _MainTex;
sampler2D _DissolveTex;
struct A{float4 in_POSITION0:POSITION0;float4 in_COLOR0:COLOR0;float4 in_TEXCOORD0:TEXCOORD0;float4 in_TEXCOORD1:TEXCOORD1;float3 in_NORMAL0:NORMAL0;};
struct V{float4 vertex:SV_POSITION;float4 vs_COLOR0:TEXCOORD0;float4 vs_TEXCOORD0:TEXCOORD1;float4 vs_TEXCOORD1:TEXCOORD2;float3 vs_TEXCOORD4:TEXCOORD3;float3 vs_TEXCOORD5:TEXCOORD4;float3 vs_TEXCOORD6:TEXCOORD5;float3 vs_TEXCOORD7:TEXCOORD6;float3 vs_NORMAL0:TEXCOORD7;};
V vert(A i){V o=(V)0;
float4 u_xlat0;
float4 u_xlat16_0;
float4 u_xlat1;
float3 u_xlat16_2;
float3 u_xlat16_3;
float u_xlat13;

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
    o.vs_TEXCOORD1 = i.in_TEXCOORD1;
    o.vs_TEXCOORD4.xyz = i.in_POSITION0.xyz;
    u_xlat16_2.x = i.in_NORMAL0.y * i.in_NORMAL0.y;
    u_xlat16_2.x = i.in_NORMAL0.x * i.in_NORMAL0.x + (-u_xlat16_2.x);
    u_xlat16_0 = i.in_NORMAL0.yzzx * i.in_NORMAL0.xyzz;
    u_xlat16_3.x = dot(unity_SHBr, u_xlat16_0);
    u_xlat16_3.y = dot(unity_SHBg, u_xlat16_0);
    u_xlat16_3.z = dot(unity_SHBb, u_xlat16_0);
    u_xlat16_2.xyz = unity_SHC.xyz * u_xlat16_2.xxx + u_xlat16_3.xyz;
    u_xlat0.xyz = i.in_NORMAL0.xyz;
    u_xlat0.w = 1.0;
    u_xlat16_3.x = dot(unity_SHAr, u_xlat0);
    u_xlat16_3.y = dot(unity_SHAg, u_xlat0);
    u_xlat16_3.z = dot(unity_SHAb, u_xlat0);
    u_xlat16_2.xyz = u_xlat16_2.xyz + u_xlat16_3.xyz;
    u_xlat16_2.xyz = max(u_xlat16_2.xyz, float3(0.0, 0.0, 0.0));
    u_xlat1.xyz = log2(u_xlat16_2.xyz);
    u_xlat1.xyz = u_xlat1.xyz * float3(0.416666657, 0.416666657, 0.416666657);
    u_xlat1.xyz = exp2(u_xlat1.xyz);
    u_xlat1.xyz = u_xlat1.xyz * float3(1.05499995, 1.05499995, 1.05499995) + float3(-0.0549999997, -0.0549999997, -0.0549999997);
    o.vs_TEXCOORD5.xyz = max(u_xlat1.xyz, float3(0.0, 0.0, 0.0));
    u_xlat1.xyz = (-i.in_POSITION0.xyz) + _WorldSpaceCameraPos.xyz;
    u_xlat13 = dot(u_xlat1.xyz, u_xlat1.xyz);
    u_xlat13 = rsqrt(u_xlat13);
    o.vs_TEXCOORD6.xyz = ((float3)(u_xlat13)) * u_xlat1.xyz;
    o.vs_TEXCOORD7.xyz = (-i.in_POSITION0.xyz) + _GameObjectWorldPosition.xyz;
    o.vs_NORMAL0.xyz = i.in_NORMAL0.xyz;
    return o;

}
float4 frag(V i):SV_Target{float4 result=0;
float4 u_xlat0;
float u_xlat16_0;
bool u_xlatb0;
float4 u_xlat1;
float4 u_xlat16_1;
float4 u_xlat2;
bool2 u_xlatb2;
float4 u_xlat3;
float4 u_xlat16_3;
float4 u_xlat4;
float3 u_xlat16_5;
float4 u_xlat6;
float u_xlat16_7;
float u_xlat8;
float3 u_xlat16_13;
float u_xlat16_15;
float2 u_xlat16;
float u_xlat16_21;
float u_xlat16_23;
float u_xlat24;
bool u_xlatb24;
float u_xlat16_29;

    u_xlat0.xyz = (-i.vs_TEXCOORD7.xyz) * ((float3)(_LightingWorldPosStrength)) + i.vs_NORMAL0.xyz;
    u_xlat24 = dot(u_xlat0.xyz, u_xlat0.xyz);
    u_xlat24 = rsqrt(u_xlat24);
    u_xlat0.xyz = ((float3)(u_xlat24)) * u_xlat0.xyz;
    u_xlat1 = (-i.vs_TEXCOORD4.yyyy) + unity_4LightPosY0;
    u_xlat2 = u_xlat0.yyyy * u_xlat1;
    u_xlat3 = (-i.vs_TEXCOORD4.xxxx) + unity_4LightPosX0;
    u_xlat2 = u_xlat3 * u_xlat0.xxxx + u_xlat2;
    u_xlat4 = (-i.vs_TEXCOORD4.zzzz) + unity_4LightPosZ0;
    u_xlat2 = u_xlat4 * u_xlat0.zzzz + u_xlat2;
    u_xlat2 = u_xlat2 * float4(0.5, 0.5, 0.5, 0.5) + float4(0.5, 0.5, 0.5, 0.5);
    u_xlat16_5.x = (-_DirectLightingRamp) * 0.5 + 0.5;
    u_xlat2 = u_xlat2 + (-u_xlat16_5.xxxx);
    u_xlat16_13.x = _DirectLightingRamp * 0.5 + 0.5;
    u_xlat24 = (-u_xlat16_5.x) + u_xlat16_13.x;
    u_xlat16_13.x = (-u_xlat16_5.x) + u_xlat16_13.x;
    u_xlat16_13.x = float(1.0) / u_xlat16_13.x;
    u_xlat24 = float(1.0) / u_xlat24;
    u_xlat2 = ((float4)(u_xlat24)) * u_xlat2;
    u_xlat2 = clamp(u_xlat2, 0.0, 1.0);
    u_xlat6 = u_xlat2 * float4(-2.0, -2.0, -2.0, -2.0) + float4(3.0, 3.0, 3.0, 3.0);
    u_xlat2 = u_xlat2 * u_xlat2;
    u_xlat2 = u_xlat2 * u_xlat6;
    u_xlat6 = u_xlat1 * u_xlat1;
    u_xlat1 = (-u_xlat0.yyyy) * u_xlat1;
    u_xlat1 = u_xlat3 * (-u_xlat0.xxxx) + u_xlat1;
    u_xlat3 = u_xlat3 * u_xlat3 + u_xlat6;
    u_xlat3 = u_xlat4 * u_xlat4 + u_xlat3;
    u_xlat1 = u_xlat4 * (-u_xlat0.zzzz) + u_xlat1;
    u_xlat0.x = dot(u_xlat0.xyz, _WorldSpaceLightPos0.xyz);
    u_xlat16_21 = u_xlat0.x * 0.5 + 0.5;
    u_xlat16_21 = (-u_xlat16_5.x) + u_xlat16_21;
    u_xlat1 = u_xlat1 * float4(0.5, 0.5, 0.5, 0.5) + (-u_xlat16_5.xxxx);
    u_xlat1 = u_xlat1 + float4(0.5, 0.5, 0.5, 0.5);
    u_xlat0 = ((float4)(u_xlat24)) * u_xlat1;
    u_xlat0 = clamp(u_xlat0, 0.0, 1.0);
    u_xlat16_5.x = u_xlat16_13.x * u_xlat16_21;
    u_xlat16_5.x = clamp(u_xlat16_5.x, 0.0, 1.0);
    u_xlat1 = max(u_xlat3, float4(9.99999997e-07, 9.99999997e-07, 9.99999997e-07, 9.99999997e-07));
    u_xlat3 = rsqrt(u_xlat1);
    u_xlat1 = u_xlat1 * unity_4LightAtten0 + float4(1.0, 1.0, 1.0, 1.0);
    u_xlat1 = float4(1.0, 1.0, 1.0, 1.0) / u_xlat1;
    u_xlat2 = u_xlat2 * u_xlat3;
    u_xlat2 = u_xlat1 * u_xlat2;
    u_xlat4.xyz = u_xlat2.yyy * unity_LightColor[1].xyz;
    u_xlat4.xyz = unity_LightColor[0].xyz * u_xlat2.xxx + u_xlat4.xyz;
    u_xlat2.xyz = unity_LightColor[2].xyz * u_xlat2.zzz + u_xlat4.xyz;
    u_xlat2.xyz = unity_LightColor[3].xyz * u_xlat2.www + u_xlat2.xyz;
    u_xlat4 = u_xlat0 * float4(-2.0, -2.0, -2.0, -2.0) + float4(3.0, 3.0, 3.0, 3.0);
    u_xlat0 = u_xlat0 * u_xlat0;
    u_xlat0 = u_xlat0 * u_xlat4;
    u_xlat0 = u_xlat3 * u_xlat0;
    u_xlat0 = u_xlat1 * u_xlat0;
    u_xlat1.xyz = u_xlat0.yyy * unity_LightColor[1].xyz;
    u_xlat1.xyz = unity_LightColor[0].xyz * u_xlat0.xxx + u_xlat1.xyz;
    u_xlat0.xyz = unity_LightColor[2].xyz * u_xlat0.zzz + u_xlat1.xyz;
    u_xlat0.xyz = unity_LightColor[3].xyz * u_xlat0.www + u_xlat0.xyz;
    u_xlat0.xyz = u_xlat0.xyz * ((float3)(float3(_BacklightTransmittance, _BacklightTransmittance, _BacklightTransmittance))) + u_xlat2.xyz;
    u_xlat24 = log2(_HdrMultiply);
    u_xlat24 = u_xlat24 * 0.416666657;
    u_xlat24 = exp2(u_xlat24);
    u_xlat24 = u_xlat24 * 1.05499995 + -0.0549999997;
    u_xlat24 = max(u_xlat24, 0.0);
    u_xlat16_1 = tex2D(_MainTex, i.vs_TEXCOORD0.xy);
    u_xlatb2.xy = lessThan(float4(0.0, 0.0, 0.0, 0.0), float4(_SingleChannel, _UseDissolveOffsetUV, _SingleChannel, _SingleChannel)).xy;
    u_xlat16_3.xyz = (u_xlatb2.x) ? float3(1.0, 1.0, 1.0) : u_xlat16_1.xyz;
    u_xlat16_3.w = (u_xlatb2.x) ? u_xlat16_1.x : u_xlat16_1.w;
    u_xlat16_1 = u_xlat16_3 * i.vs_COLOR0;
    u_xlat16_13.xyz = ((float3)(u_xlat24)) * u_xlat16_1.xyz;
    u_xlatb24 = 0.0<_HdrMultiply;
    u_xlat16_13.xyz = (bool(u_xlatb24)) ? u_xlat16_13.xyz : u_xlat16_1.xyz;
    u_xlat16_7 = u_xlat16_5.x * -2.0 + 3.0;
    u_xlat16_5.x = u_xlat16_5.x * u_xlat16_5.x;
    u_xlat2.xzw = i.vs_TEXCOORD6.xyz + _WorldSpaceLightPos0.xyz;
    u_xlat24 = dot(u_xlat2.xzw, u_xlat2.xzw);
    u_xlat24 = sqrt(u_xlat24);
    u_xlat16_15 = float(1.0) / _DirLightScreenAtten;
    u_xlat16_15 = u_xlat24 * u_xlat16_15;
    u_xlat16_15 = clamp(u_xlat16_15, 0.0, 1.0);
    u_xlat16_23 = u_xlat16_15 * -2.0 + 3.0;
    u_xlat16_15 = u_xlat16_15 * u_xlat16_15;
    u_xlat16_15 = (-u_xlat16_23) * u_xlat16_15 + 1.0;
    u_xlat16_15 = u_xlat16_15 * u_xlat16_15;
    u_xlat16_15 = u_xlat16_15 * _BacklightTransmittance;
    u_xlat16_5.x = u_xlat16_7 * u_xlat16_5.x + u_xlat16_15;
    u_xlat2.xzw = _LightColor0.xyz + (-_ShadowColor.xyz);
    u_xlat2.xzw = u_xlat16_5.xxx * u_xlat2.xzw + _ShadowColor.xyz;
    u_xlat16_5.xyz = u_xlat16_13.xyz * u_xlat2.xzw + u_xlat0.xyz;
    u_xlat0.xyz = i.vs_TEXCOORD5.xyz * ((float3)(float3(_IndirectLightingMix, _IndirectLightingMix, _IndirectLightingMix))) + u_xlat16_5.xyz;
    result.xyz = u_xlat0.xyz;
    u_xlat0.xy = _Time.yy * float2(_DissolveScroll.x, _DissolveScroll.y);
    u_xlat0.xy = frac(u_xlat0.xy);
    u_xlat16.xy = i.vs_TEXCOORD0.xy * _DissolveTex_ST.xy + _DissolveTex_ST.zw;
    u_xlat0.xy = u_xlat0.xy + u_xlat16.xy;
    u_xlat0.xy = (u_xlatb2.y) ? u_xlat0.xy : i.vs_TEXCOORD0.xy;
    u_xlat16_0 = tex2D(_DissolveTex, u_xlat0.xy).x;
    u_xlat16_5.x = u_xlat16_0 * 2.0 + -1.0;
    u_xlat8 = u_xlat16_5.x * i.vs_TEXCOORD1.z + i.vs_TEXCOORD0.x;
    u_xlat16_5.x = (u_xlatb2.y) ? u_xlat8 : u_xlat16_0;
    u_xlat16_13.x = (-u_xlat16_5.x) + 1.0;
    u_xlatb0 = 0.0>=_InvertDissolveTex;
    u_xlat16_5.x = (u_xlatb0) ? u_xlat16_13.x : u_xlat16_5.x;
    u_xlat16_13.x = u_xlat16_5.x + _DissolveSmooth;
    u_xlat16_5.x = u_xlat16_5.x + (-_DissolveSmooth);
    u_xlat16_13.x = (-u_xlat16_5.x) + u_xlat16_13.x;
    u_xlat16_13.x = float(1.0) / u_xlat16_13.x;
    u_xlat16_21 = _DissolveSmooth * 2.0 + 1.0;
    u_xlat16_21 = i.vs_TEXCOORD1.x * u_xlat16_21 + (-_DissolveSmooth);
    u_xlat16_29 = (-u_xlat16_5.x) + u_xlat16_21;
    u_xlat16_29 = u_xlat16_13.x * u_xlat16_29;
    u_xlat16_29 = clamp(u_xlat16_29, 0.0, 1.0);
    u_xlat16_7 = u_xlat16_29 * -2.0 + 3.0;
    u_xlat16_29 = u_xlat16_29 * u_xlat16_29;
    u_xlat16_29 = u_xlat16_29 * u_xlat16_7;
    u_xlat16_29 = u_xlat16_1.w * u_xlat16_29;
    u_xlatb0 = 0.0<_DoubleDissolve;
    u_xlat16_7 = (u_xlatb0) ? i.vs_TEXCOORD1.y : 0.0;
    u_xlat16_21 = u_xlat16_21 + (-u_xlat16_7);
    u_xlatb0 = 0.0<u_xlat16_7;
    u_xlat16_5.x = (-u_xlat16_5.x) + u_xlat16_21;
    u_xlat16_5.x = u_xlat16_13.x * u_xlat16_5.x;
    u_xlat16_5.x = clamp(u_xlat16_5.x, 0.0, 1.0);
    u_xlat16_13.x = u_xlat16_5.x * -2.0 + 3.0;
    u_xlat16_5.x = u_xlat16_5.x * u_xlat16_5.x;
    u_xlat16_5.x = (-u_xlat16_13.x) * u_xlat16_5.x + u_xlat16_29;
    u_xlat16_5.x = clamp(u_xlat16_5.x, 0.0, 1.0);
    u_xlat16_5.x = (u_xlatb0) ? u_xlat16_5.x : u_xlat16_29;
    result.w = min(u_xlat16_5.x, 1.0);
    return result;

}

#elif !defined(SOFTPARTICLES_ON) && defined(_ALPHABLEND_ON) && !defined(_ALPHAMODULATE_ON) && !defined(_ALPHAPREMULTIPLY_ON) && defined(_ALPHATEST_ON) && !defined(_CFXR_ADDITIVE) && !defined(_CFXR_DISSOLVE) && !defined(_CFXR_EDGE_FADING) && !defined(_CFXR_FONT_COLORS) && defined(_CFXR_LIGHTING_ALL) && defined(_CFXR_LIGHTING_BACK) && !defined(_CFXR_LIGHTING_WPOS_OFFSET) && !defined(_CFXR_OVERLAYTEX_1X) && !defined(_CFXR_SECONDCOLOR_LERP) && !defined(_CFXR_UV_DISTORTION) && !defined(_EMISSION) && defined(_FADING_ON) && !defined(_FLIPBOOK_BLENDING) && defined(_NORMALMAP)
// Original GLES program 56; _CFXR_LIGHTING_ALL,_CFXR_LIGHTING_BACK,_NORMALMAP,_FADING_ON,_ALPHATEST_ON,_ALPHABLEND_ON
float _SingleChannel;
float _BumpScale;
float _IndirectLightingMix;
float4 _ShadowColor;
float _DirectLightingRamp;
float _DirLightScreenAtten;
float _BacklightTransmittance;
float _HdrMultiply;
float _Cutoff;
sampler2D _MainTex;
sampler2D _BumpMap;
struct A{float4 in_POSITION0:POSITION0;float4 in_COLOR0:COLOR0;float4 in_TEXCOORD0:TEXCOORD0;float4 in_TEXCOORD1:TEXCOORD1;float3 in_NORMAL0:NORMAL0;float4 in_TANGENT0:TANGENT0;};
struct V{float4 vertex:SV_POSITION;float4 vs_COLOR0:TEXCOORD0;float4 vs_TEXCOORD0:TEXCOORD1;float3 vs_TEXCOORD4:TEXCOORD2;float3 vs_TEXCOORD6:TEXCOORD3;float3 vs_NORMAL0:TEXCOORD4;float4 vs_TANGENT0:TEXCOORD5;};
V vert(A i){V o=(V)0;
float4 vs_TEXCOORD1;
float4 u_xlat0;
float4 u_xlat1;
float u_xlat6;

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
    o.vs_TEXCOORD4.xyz = i.in_POSITION0.xyz;
    u_xlat0.xyz = (-i.in_POSITION0.xyz) + _WorldSpaceCameraPos.xyz;
    u_xlat6 = dot(u_xlat0.xyz, u_xlat0.xyz);
    u_xlat6 = rsqrt(u_xlat6);
    o.vs_TEXCOORD6.xyz = ((float3)(u_xlat6)) * u_xlat0.xyz;
    o.vs_NORMAL0.xyz = i.in_NORMAL0.xyz;
    o.vs_TANGENT0 = i.in_TANGENT0;
    return o;

}
float4 frag(V i):SV_Target{float4 result=0;
float4 u_xlat16_0;
float4 u_xlat1;
float4 u_xlat16_1;
bool u_xlatb1;
float4 u_xlat16_2;
float4 u_xlat3;
float4 u_xlat4;
float3 u_xlat16_4;
float4 u_xlat5;
float3 u_xlat16_5;
float3 u_xlat16_6;
float4 u_xlat7;
float4 u_xlat8;
float3 u_xlat16_9;
float u_xlat16_16;
float u_xlat16_26;
float u_xlat31;
float u_xlat16_32;

    u_xlat16_0 = tex2D(_MainTex, i.vs_TEXCOORD0.xy);
    u_xlatb1 = 0.0<_SingleChannel;
    u_xlat16_2.w = (u_xlatb1) ? u_xlat16_0.x : u_xlat16_0.w;
    u_xlat16_2.xyz = (bool(u_xlatb1)) ? float3(1.0, 1.0, 1.0) : u_xlat16_0.xyz;
    u_xlat16_0 = u_xlat16_2 * i.vs_COLOR0;
    u_xlat16_2.x = u_xlat16_2.w * i.vs_COLOR0.w + (-_Cutoff);
    u_xlatb1 = u_xlat16_2.x<0.0;
    if(u_xlatb1){discard;}
    u_xlat1.x = log2(_HdrMultiply);
    u_xlat1.x = u_xlat1.x * 0.416666657;
    u_xlat1.x = exp2(u_xlat1.x);
    u_xlat1.x = u_xlat1.x * 1.05499995 + -0.0549999997;
    u_xlat1.x = max(u_xlat1.x, 0.0);
    u_xlat16_2.xyz = u_xlat16_0.xyz * u_xlat1.xxx;
    u_xlatb1 = 0.0<_HdrMultiply;
    u_xlat16_2.xyz = (bool(u_xlatb1)) ? u_xlat16_2.xyz : u_xlat16_0.xyz;
    result.w = min(u_xlat16_0.w, 1.0);
    u_xlat1.x = i.vs_TANGENT0.z;
    u_xlat1.z = i.vs_NORMAL0.z;
    u_xlat3.xyz = i.vs_NORMAL0.zxy * i.vs_TANGENT0.yzx;
    u_xlat3.xyz = i.vs_NORMAL0.yzx * i.vs_TANGENT0.zxy + (-u_xlat3.xyz);
    u_xlat3.xyz = u_xlat3.xyz * i.vs_TANGENT0.www;
    u_xlat1.y = u_xlat3.z;
    u_xlat16_4.xyz = tex2D(_BumpMap, i.vs_TEXCOORD0.xy).xyz;
    u_xlat16_5.xyz = u_xlat16_4.xyz * float3(2.0, 2.0, 2.0) + float3(-1.0, -1.0, -1.0);
    u_xlat16_5.xy = u_xlat16_5.xy * ((float2)(float2(_BumpScale, _BumpScale)));
    u_xlat16_0.z = dot(u_xlat16_5.xyz, u_xlat1.xyz);
    u_xlat1.y = u_xlat3.x;
    u_xlat1.x = i.vs_TANGENT0.x;
    u_xlat1.z = i.vs_NORMAL0.x;
    u_xlat16_0.x = dot(u_xlat16_5.xyz, u_xlat1.xyz);
    u_xlat3.x = i.vs_TANGENT0.y;
    u_xlat3.z = i.vs_NORMAL0.y;
    u_xlat16_0.y = dot(u_xlat16_5.xyz, u_xlat3.xyz);
    u_xlat1 = (-i.vs_TEXCOORD4.yyyy) + unity_4LightPosY0;
    u_xlat3 = u_xlat16_0.yyyy * u_xlat1;
    u_xlat4 = (-i.vs_TEXCOORD4.xxxx) + unity_4LightPosX0;
    u_xlat3 = u_xlat4 * u_xlat16_0.xxxx + u_xlat3;
    u_xlat5 = (-i.vs_TEXCOORD4.zzzz) + unity_4LightPosZ0;
    u_xlat3 = u_xlat5 * u_xlat16_0.zzzz + u_xlat3;
    u_xlat3 = u_xlat3 * float4(0.5, 0.5, 0.5, 0.5) + float4(0.5, 0.5, 0.5, 0.5);
    u_xlat16_32 = (-_DirectLightingRamp) * 0.5 + 0.5;
    u_xlat3 = (-((float4)(u_xlat16_32))) + u_xlat3;
    u_xlat16_6.x = _DirectLightingRamp * 0.5 + 0.5;
    u_xlat7.x = (-u_xlat16_32) + u_xlat16_6.x;
    u_xlat16_6.x = (-u_xlat16_32) + u_xlat16_6.x;
    u_xlat16_6.x = float(1.0) / u_xlat16_6.x;
    u_xlat7.x = float(1.0) / u_xlat7.x;
    u_xlat3 = u_xlat3 * u_xlat7.xxxx;
    u_xlat3 = clamp(u_xlat3, 0.0, 1.0);
    u_xlat8 = u_xlat3 * float4(-2.0, -2.0, -2.0, -2.0) + float4(3.0, 3.0, 3.0, 3.0);
    u_xlat3 = u_xlat3 * u_xlat3;
    u_xlat3 = u_xlat3 * u_xlat8;
    u_xlat8 = u_xlat1 * u_xlat1;
    u_xlat1 = (-u_xlat16_0.yyyy) * u_xlat1;
    u_xlat1 = u_xlat4 * (-u_xlat16_0.xxxx) + u_xlat1;
    u_xlat4 = u_xlat4 * u_xlat4 + u_xlat8;
    u_xlat4 = u_xlat5 * u_xlat5 + u_xlat4;
    u_xlat1 = u_xlat5 * (-u_xlat16_0.zzzz) + u_xlat1;
    u_xlat1 = u_xlat1 * float4(0.5, 0.5, 0.5, 0.5) + (-((float4)(u_xlat16_32)));
    u_xlat1 = u_xlat1 + float4(0.5, 0.5, 0.5, 0.5);
    u_xlat1 = u_xlat7.xxxx * u_xlat1;
    u_xlat1 = clamp(u_xlat1, 0.0, 1.0);
    u_xlat4 = max(u_xlat4, float4(9.99999997e-07, 9.99999997e-07, 9.99999997e-07, 9.99999997e-07));
    u_xlat5 = rsqrt(u_xlat4);
    u_xlat4 = u_xlat4 * unity_4LightAtten0 + float4(1.0, 1.0, 1.0, 1.0);
    u_xlat4 = float4(1.0, 1.0, 1.0, 1.0) / u_xlat4;
    u_xlat3 = u_xlat3 * u_xlat5;
    u_xlat3 = u_xlat4 * u_xlat3;
    u_xlat7.xyz = u_xlat3.yyy * unity_LightColor[1].xyz;
    u_xlat7.xyz = unity_LightColor[0].xyz * u_xlat3.xxx + u_xlat7.xyz;
    u_xlat3.xyz = unity_LightColor[2].xyz * u_xlat3.zzz + u_xlat7.xyz;
    u_xlat3.xyz = unity_LightColor[3].xyz * u_xlat3.www + u_xlat3.xyz;
    u_xlat7 = u_xlat1 * float4(-2.0, -2.0, -2.0, -2.0) + float4(3.0, 3.0, 3.0, 3.0);
    u_xlat1 = u_xlat1 * u_xlat1;
    u_xlat1 = u_xlat1 * u_xlat7;
    u_xlat1 = u_xlat5 * u_xlat1;
    u_xlat1 = u_xlat4 * u_xlat1;
    u_xlat4.xyz = u_xlat1.yyy * unity_LightColor[1].xyz;
    u_xlat4.xyz = unity_LightColor[0].xyz * u_xlat1.xxx + u_xlat4.xyz;
    u_xlat1.xyz = unity_LightColor[2].xyz * u_xlat1.zzz + u_xlat4.xyz;
    u_xlat1.xyz = unity_LightColor[3].xyz * u_xlat1.www + u_xlat1.xyz;
    u_xlat1.xyz = u_xlat1.xyz * ((float3)(float3(_BacklightTransmittance, _BacklightTransmittance, _BacklightTransmittance))) + u_xlat3.xyz;
    u_xlat3.xyz = i.vs_TEXCOORD6.xyz + _WorldSpaceLightPos0.xyz;
    u_xlat31 = dot(u_xlat3.xyz, u_xlat3.xyz);
    u_xlat31 = sqrt(u_xlat31);
    u_xlat16_16 = float(1.0) / _DirLightScreenAtten;
    u_xlat16_16 = u_xlat31 * u_xlat16_16;
    u_xlat16_16 = clamp(u_xlat16_16, 0.0, 1.0);
    u_xlat16_26 = u_xlat16_16 * -2.0 + 3.0;
    u_xlat16_16 = u_xlat16_16 * u_xlat16_16;
    u_xlat16_16 = (-u_xlat16_26) * u_xlat16_16 + 1.0;
    u_xlat16_16 = u_xlat16_16 * u_xlat16_16;
    u_xlat16_16 = u_xlat16_16 * _BacklightTransmittance;
    u_xlat31 = dot(u_xlat16_0.xyz, _WorldSpaceLightPos0.xyz);
    u_xlat16_26 = u_xlat31 * 0.5 + 0.5;
    u_xlat16_32 = (-u_xlat16_32) + u_xlat16_26;
    u_xlat16_32 = u_xlat16_6.x * u_xlat16_32;
    u_xlat16_32 = clamp(u_xlat16_32, 0.0, 1.0);
    u_xlat16_6.x = u_xlat16_32 * -2.0 + 3.0;
    u_xlat16_32 = u_xlat16_32 * u_xlat16_32;
    u_xlat16_32 = u_xlat16_6.x * u_xlat16_32 + u_xlat16_16;
    u_xlat3.xyz = _LightColor0.xyz + (-_ShadowColor.xyz);
    u_xlat3.xyz = ((float3)(u_xlat16_32)) * u_xlat3.xyz + _ShadowColor.xyz;
    u_xlat16_2.xyz = u_xlat16_2.xyz * u_xlat3.xyz + u_xlat1.xyz;
    u_xlat16_32 = u_xlat16_0.y * u_xlat16_0.y;
    u_xlat16_32 = u_xlat16_0.x * u_xlat16_0.x + (-u_xlat16_32);
    u_xlat16_1 = u_xlat16_0.yzzx * u_xlat16_0.xyzz;
    u_xlat16_6.x = dot(unity_SHBr, u_xlat16_1);
    u_xlat16_6.y = dot(unity_SHBg, u_xlat16_1);
    u_xlat16_6.z = dot(unity_SHBb, u_xlat16_1);
    u_xlat16_6.xyz = unity_SHC.xyz * ((float3)(u_xlat16_32)) + u_xlat16_6.xyz;
    u_xlat16_0.w = 1.0;
    u_xlat16_9.x = dot(unity_SHAr, u_xlat16_0);
    u_xlat16_9.y = dot(unity_SHAg, u_xlat16_0);
    u_xlat16_9.z = dot(unity_SHAb, u_xlat16_0);
    u_xlat16_6.xyz = u_xlat16_6.xyz + u_xlat16_9.xyz;
    u_xlat16_6.xyz = max(u_xlat16_6.xyz, float3(0.0, 0.0, 0.0));
    u_xlat3.xyz = log2(u_xlat16_6.xyz);
    u_xlat3.xyz = u_xlat3.xyz * float3(0.416666657, 0.416666657, 0.416666657);
    u_xlat3.xyz = exp2(u_xlat3.xyz);
    u_xlat3.xyz = u_xlat3.xyz * float3(1.05499995, 1.05499995, 1.05499995) + float3(-0.0549999997, -0.0549999997, -0.0549999997);
    u_xlat3.xyz = max(u_xlat3.xyz, float3(0.0, 0.0, 0.0));
    result.xyz = u_xlat3.xyz * ((float3)(float3(_IndirectLightingMix, _IndirectLightingMix, _IndirectLightingMix))) + u_xlat16_2.xyz;
    return result;

}

#elif defined(SOFTPARTICLES_ON) && defined(_ALPHABLEND_ON) && !defined(_ALPHAMODULATE_ON) && !defined(_ALPHAPREMULTIPLY_ON) && !defined(_ALPHATEST_ON) && !defined(_CFXR_ADDITIVE) && defined(_CFXR_DISSOLVE) && !defined(_CFXR_EDGE_FADING) && !defined(_CFXR_FONT_COLORS) && defined(_CFXR_LIGHTING_ALL) && defined(_CFXR_LIGHTING_BACK) && !defined(_CFXR_LIGHTING_WPOS_OFFSET) && !defined(_CFXR_OVERLAYTEX_1X) && !defined(_CFXR_SECONDCOLOR_LERP) && !defined(_CFXR_UV_DISTORTION) && !defined(_EMISSION) && defined(_FADING_ON) && !defined(_FLIPBOOK_BLENDING) && !defined(_NORMALMAP)
// Original GLES program 79; SOFTPARTICLES_ON,_CFXR_DISSOLVE,_CFXR_LIGHTING_ALL,_CFXR_LIGHTING_BACK,_FADING_ON,_ALPHABLEND_ON
float _SingleChannel;
float _UseDissolveOffsetUV;
float _IndirectLightingMix;
float4 _ShadowColor;
float _DirectLightingRamp;
float _DirLightScreenAtten;
float _BacklightTransmittance;
float _InvertDissolveTex;
float _DoubleDissolve;
float2 _DissolveScroll;
float _DissolveSmooth;
float _HdrMultiply;
float _SoftParticlesFadeDistanceNear;
float _SoftParticlesFadeDistanceFar;
float4 _DissolveTex_ST;
sampler2D _MainTex;
sampler2D _DissolveTex;
sampler2D _CameraDepthTexture;
struct A{float4 in_POSITION0:POSITION0;float4 in_COLOR0:COLOR0;float4 in_TEXCOORD0:TEXCOORD0;float4 in_TEXCOORD1:TEXCOORD1;float3 in_NORMAL0:NORMAL0;};
struct V{float4 vertex:SV_POSITION;float4 vs_COLOR0:TEXCOORD0;float4 vs_TEXCOORD0:TEXCOORD1;float4 vs_TEXCOORD1:TEXCOORD2;float4 vs_TEXCOORD3:TEXCOORD3;float3 vs_TEXCOORD4:TEXCOORD4;float3 vs_TEXCOORD5:TEXCOORD5;float3 vs_TEXCOORD6:TEXCOORD6;float3 vs_NORMAL0:TEXCOORD7;};
V vert(A i){V o=(V)0;
float4 u_xlat0;
float4 u_xlat16_0;
float4 u_xlat1;
float3 u_xlat16_2;
float3 u_xlat16_3;
float u_xlat4;
float u_xlat13;

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
    o.vs_TEXCOORD1 = i.in_TEXCOORD1;
    u_xlat4 = u_xlat0.y * transpose(unity_MatrixV)[1].z;
    u_xlat0.x = transpose(unity_MatrixV)[0].z * u_xlat0.x + u_xlat4;
    u_xlat0.x = transpose(unity_MatrixV)[2].z * u_xlat0.z + u_xlat0.x;
    u_xlat0.x = transpose(unity_MatrixV)[3].z * u_xlat0.w + u_xlat0.x;
    o.vs_TEXCOORD3.z = (-u_xlat0.x);
    u_xlat0.x = u_xlat1.y * _ProjectionParams.x;
    u_xlat0.w = u_xlat0.x * 0.5;
    u_xlat0.xz = u_xlat1.xw * float2(0.5, 0.5);
    o.vs_TEXCOORD3.w = u_xlat1.w;
    o.vs_TEXCOORD3.xy = u_xlat0.zz + u_xlat0.xw;
    o.vs_TEXCOORD4.xyz = i.in_POSITION0.xyz;
    u_xlat16_2.x = i.in_NORMAL0.y * i.in_NORMAL0.y;
    u_xlat16_2.x = i.in_NORMAL0.x * i.in_NORMAL0.x + (-u_xlat16_2.x);
    u_xlat16_0 = i.in_NORMAL0.yzzx * i.in_NORMAL0.xyzz;
    u_xlat16_3.x = dot(unity_SHBr, u_xlat16_0);
    u_xlat16_3.y = dot(unity_SHBg, u_xlat16_0);
    u_xlat16_3.z = dot(unity_SHBb, u_xlat16_0);
    u_xlat16_2.xyz = unity_SHC.xyz * u_xlat16_2.xxx + u_xlat16_3.xyz;
    u_xlat0.xyz = i.in_NORMAL0.xyz;
    u_xlat0.w = 1.0;
    u_xlat16_3.x = dot(unity_SHAr, u_xlat0);
    u_xlat16_3.y = dot(unity_SHAg, u_xlat0);
    u_xlat16_3.z = dot(unity_SHAb, u_xlat0);
    u_xlat16_2.xyz = u_xlat16_2.xyz + u_xlat16_3.xyz;
    u_xlat16_2.xyz = max(u_xlat16_2.xyz, float3(0.0, 0.0, 0.0));
    u_xlat1.xyz = log2(u_xlat16_2.xyz);
    u_xlat1.xyz = u_xlat1.xyz * float3(0.416666657, 0.416666657, 0.416666657);
    u_xlat1.xyz = exp2(u_xlat1.xyz);
    u_xlat1.xyz = u_xlat1.xyz * float3(1.05499995, 1.05499995, 1.05499995) + float3(-0.0549999997, -0.0549999997, -0.0549999997);
    o.vs_TEXCOORD5.xyz = max(u_xlat1.xyz, float3(0.0, 0.0, 0.0));
    u_xlat1.xyz = (-i.in_POSITION0.xyz) + _WorldSpaceCameraPos.xyz;
    u_xlat13 = dot(u_xlat1.xyz, u_xlat1.xyz);
    u_xlat13 = rsqrt(u_xlat13);
    o.vs_TEXCOORD6.xyz = ((float3)(u_xlat13)) * u_xlat1.xyz;
    o.vs_NORMAL0.xyz = i.in_NORMAL0.xyz;
    return o;

}
float4 frag(V i):SV_Target{float4 result=0;
float4 u_xlat0;
float u_xlat16_0;
bool u_xlatb0;
float4 u_xlat1;
float4 u_xlat2;
float4 u_xlat16_2;
float4 u_xlat3;
bool2 u_xlatb3;
float4 u_xlat16_4;
float4 u_xlat5;
float4 u_xlat6;
float u_xlat16_7;
float u_xlat8;
float u_xlat16_12;
float2 u_xlat16;
bool u_xlatb16;
float u_xlat16_20;
float u_xlat24;
bool u_xlatb24;
float u_xlat16_28;

    u_xlat0 = (-i.vs_TEXCOORD4.yyyy) + unity_4LightPosY0;
    u_xlat1 = u_xlat0 * i.vs_NORMAL0.yyyy;
    u_xlat2 = (-i.vs_TEXCOORD4.xxxx) + unity_4LightPosX0;
    u_xlat1 = u_xlat2 * i.vs_NORMAL0.xxxx + u_xlat1;
    u_xlat3 = (-i.vs_TEXCOORD4.zzzz) + unity_4LightPosZ0;
    u_xlat1 = u_xlat3 * i.vs_NORMAL0.zzzz + u_xlat1;
    u_xlat1 = u_xlat1 * float4(0.5, 0.5, 0.5, 0.5) + float4(0.5, 0.5, 0.5, 0.5);
    u_xlat16_4.x = (-_DirectLightingRamp) * 0.5 + 0.5;
    u_xlat1 = u_xlat1 + (-u_xlat16_4.xxxx);
    u_xlat16_12 = _DirectLightingRamp * 0.5 + 0.5;
    u_xlat5.x = (-u_xlat16_4.x) + u_xlat16_12;
    u_xlat16_12 = (-u_xlat16_4.x) + u_xlat16_12;
    u_xlat16_12 = float(1.0) / u_xlat16_12;
    u_xlat5.x = float(1.0) / u_xlat5.x;
    u_xlat1 = u_xlat1 * u_xlat5.xxxx;
    u_xlat1 = clamp(u_xlat1, 0.0, 1.0);
    u_xlat6 = u_xlat1 * float4(-2.0, -2.0, -2.0, -2.0) + float4(3.0, 3.0, 3.0, 3.0);
    u_xlat1 = u_xlat1 * u_xlat1;
    u_xlat1 = u_xlat1 * u_xlat6;
    u_xlat6 = u_xlat0 * u_xlat0;
    u_xlat0 = u_xlat0 * (-i.vs_NORMAL0.yyyy);
    u_xlat0 = u_xlat2 * (-i.vs_NORMAL0.xxxx) + u_xlat0;
    u_xlat2 = u_xlat2 * u_xlat2 + u_xlat6;
    u_xlat2 = u_xlat3 * u_xlat3 + u_xlat2;
    u_xlat0 = u_xlat3 * (-i.vs_NORMAL0.zzzz) + u_xlat0;
    u_xlat0 = u_xlat0 * float4(0.5, 0.5, 0.5, 0.5) + (-u_xlat16_4.xxxx);
    u_xlat0 = u_xlat0 + float4(0.5, 0.5, 0.5, 0.5);
    u_xlat0 = u_xlat5.xxxx * u_xlat0;
    u_xlat0 = clamp(u_xlat0, 0.0, 1.0);
    u_xlat2 = max(u_xlat2, float4(9.99999997e-07, 9.99999997e-07, 9.99999997e-07, 9.99999997e-07));
    u_xlat3 = rsqrt(u_xlat2);
    u_xlat2 = u_xlat2 * unity_4LightAtten0 + float4(1.0, 1.0, 1.0, 1.0);
    u_xlat2 = float4(1.0, 1.0, 1.0, 1.0) / u_xlat2;
    u_xlat1 = u_xlat1 * u_xlat3;
    u_xlat1 = u_xlat2 * u_xlat1;
    u_xlat5.xyz = u_xlat1.yyy * unity_LightColor[1].xyz;
    u_xlat5.xyz = unity_LightColor[0].xyz * u_xlat1.xxx + u_xlat5.xyz;
    u_xlat1.xyz = unity_LightColor[2].xyz * u_xlat1.zzz + u_xlat5.xyz;
    u_xlat1.xyz = unity_LightColor[3].xyz * u_xlat1.www + u_xlat1.xyz;
    u_xlat5 = u_xlat0 * float4(-2.0, -2.0, -2.0, -2.0) + float4(3.0, 3.0, 3.0, 3.0);
    u_xlat0 = u_xlat0 * u_xlat0;
    u_xlat0 = u_xlat0 * u_xlat5;
    u_xlat0 = u_xlat3 * u_xlat0;
    u_xlat0 = u_xlat2 * u_xlat0;
    u_xlat2.xyz = u_xlat0.yyy * unity_LightColor[1].xyz;
    u_xlat2.xyz = unity_LightColor[0].xyz * u_xlat0.xxx + u_xlat2.xyz;
    u_xlat0.xyz = unity_LightColor[2].xyz * u_xlat0.zzz + u_xlat2.xyz;
    u_xlat0.xyz = unity_LightColor[3].xyz * u_xlat0.www + u_xlat0.xyz;
    u_xlat0.xyz = u_xlat0.xyz * ((float3)(float3(_BacklightTransmittance, _BacklightTransmittance, _BacklightTransmittance))) + u_xlat1.xyz;
    u_xlat24 = dot(i.vs_NORMAL0.xyz, _WorldSpaceLightPos0.xyz);
    u_xlat16_20 = u_xlat24 * 0.5 + 0.5;
    u_xlat16_4.x = (-u_xlat16_4.x) + u_xlat16_20;
    u_xlat16_4.x = u_xlat16_12 * u_xlat16_4.x;
    u_xlat16_4.x = clamp(u_xlat16_4.x, 0.0, 1.0);
    u_xlat16_12 = u_xlat16_4.x * -2.0 + 3.0;
    u_xlat1.xyz = i.vs_TEXCOORD6.xyz + _WorldSpaceLightPos0.xyz;
    u_xlat24 = dot(u_xlat1.xyz, u_xlat1.xyz);
    u_xlat24 = sqrt(u_xlat24);
    u_xlat16_20 = float(1.0) / _DirLightScreenAtten;
    u_xlat16_4.z = u_xlat24 * u_xlat16_20;
    u_xlat16_4.z = clamp(u_xlat16_4.z, 0.0, 1.0);
    u_xlat16_28 = u_xlat16_4.z * -2.0 + 3.0;
    u_xlat16_4.xz = u_xlat16_4.xz * u_xlat16_4.xz;
    u_xlat16_20 = (-u_xlat16_28) * u_xlat16_4.z + 1.0;
    u_xlat16_20 = u_xlat16_20 * u_xlat16_20;
    u_xlat16_20 = u_xlat16_20 * _BacklightTransmittance;
    u_xlat16_4.x = u_xlat16_12 * u_xlat16_4.x + u_xlat16_20;
    u_xlat1.xyz = _LightColor0.xyz + (-_ShadowColor.xyz);
    u_xlat1.xyz = u_xlat16_4.xxx * u_xlat1.xyz + _ShadowColor.xyz;
    u_xlat24 = log2(_HdrMultiply);
    u_xlat24 = u_xlat24 * 0.416666657;
    u_xlat24 = exp2(u_xlat24);
    u_xlat24 = u_xlat24 * 1.05499995 + -0.0549999997;
    u_xlat24 = max(u_xlat24, 0.0);
    u_xlat16_2 = tex2D(_MainTex, i.vs_TEXCOORD0.xy);
    u_xlatb3.xy = lessThan(float4(0.0, 0.0, 0.0, 0.0), float4(_SingleChannel, _UseDissolveOffsetUV, _SingleChannel, _SingleChannel)).xy;
    u_xlat16_4.xyz = (u_xlatb3.x) ? float3(1.0, 1.0, 1.0) : u_xlat16_2.xyz;
    u_xlat16_4.w = (u_xlatb3.x) ? u_xlat16_2.x : u_xlat16_2.w;
    u_xlat16_2 = u_xlat16_4 * i.vs_COLOR0;
    u_xlat16_4.xyz = ((float3)(u_xlat24)) * u_xlat16_2.xyz;
    u_xlatb24 = 0.0<_HdrMultiply;
    u_xlat16_4.xyz = (bool(u_xlatb24)) ? u_xlat16_4.xyz : u_xlat16_2.xyz;
    u_xlat16_4.xyz = u_xlat16_4.xyz * u_xlat1.xyz + u_xlat0.xyz;
    u_xlat0.xyz = i.vs_TEXCOORD5.xyz * ((float3)(float3(_IndirectLightingMix, _IndirectLightingMix, _IndirectLightingMix))) + u_xlat16_4.xyz;
    result.xyz = u_xlat0.xyz;
    u_xlat0.xy = _Time.yy * float2(_DissolveScroll.x, _DissolveScroll.y);
    u_xlat0.xy = frac(u_xlat0.xy);
    u_xlat16.xy = i.vs_TEXCOORD0.xy * _DissolveTex_ST.xy + _DissolveTex_ST.zw;
    u_xlat0.xy = u_xlat0.xy + u_xlat16.xy;
    u_xlat0.xy = (u_xlatb3.y) ? u_xlat0.xy : i.vs_TEXCOORD0.xy;
    u_xlat16_0 = tex2D(_DissolveTex, u_xlat0.xy).x;
    u_xlat16_4.x = u_xlat16_0 * 2.0 + -1.0;
    u_xlat8 = u_xlat16_4.x * i.vs_TEXCOORD1.z + i.vs_TEXCOORD0.x;
    u_xlat16_4.x = (u_xlatb3.y) ? u_xlat8 : u_xlat16_0;
    u_xlat16_12 = (-u_xlat16_4.x) + 1.0;
    u_xlatb0 = 0.0>=_InvertDissolveTex;
    u_xlat16_4.x = (u_xlatb0) ? u_xlat16_12 : u_xlat16_4.x;
    u_xlat16_12 = u_xlat16_4.x + _DissolveSmooth;
    u_xlat16_4.x = u_xlat16_4.x + (-_DissolveSmooth);
    u_xlat16_12 = (-u_xlat16_4.x) + u_xlat16_12;
    u_xlat16_12 = float(1.0) / u_xlat16_12;
    u_xlat16_20 = _DissolveSmooth * 2.0 + 1.0;
    u_xlat16_20 = i.vs_TEXCOORD1.x * u_xlat16_20 + (-_DissolveSmooth);
    u_xlat16_28 = (-u_xlat16_4.x) + u_xlat16_20;
    u_xlat16_28 = u_xlat16_12 * u_xlat16_28;
    u_xlat16_28 = clamp(u_xlat16_28, 0.0, 1.0);
    u_xlat16_7 = u_xlat16_28 * -2.0 + 3.0;
    u_xlat16_28 = u_xlat16_28 * u_xlat16_28;
    u_xlat16_28 = u_xlat16_28 * u_xlat16_7;
    u_xlat16_28 = u_xlat16_2.w * u_xlat16_28;
    u_xlatb0 = 0.0<_DoubleDissolve;
    u_xlat16_7 = (u_xlatb0) ? i.vs_TEXCOORD1.y : 0.0;
    u_xlat16_20 = u_xlat16_20 + (-u_xlat16_7);
    u_xlatb0 = 0.0<u_xlat16_7;
    u_xlat16_4.x = (-u_xlat16_4.x) + u_xlat16_20;
    u_xlat16_4.x = u_xlat16_12 * u_xlat16_4.x;
    u_xlat16_4.x = clamp(u_xlat16_4.x, 0.0, 1.0);
    u_xlat16_12 = u_xlat16_4.x * -2.0 + 3.0;
    u_xlat16_4.x = u_xlat16_4.x * u_xlat16_4.x;
    u_xlat16_4.x = (-u_xlat16_12) * u_xlat16_4.x + u_xlat16_28;
    u_xlat16_4.x = clamp(u_xlat16_4.x, 0.0, 1.0);
    u_xlat16_4.x = (u_xlatb0) ? u_xlat16_4.x : u_xlat16_28;
    u_xlat0.xy = i.vs_TEXCOORD3.xy / i.vs_TEXCOORD3.ww;
    u_xlat0.x = tex2D(_CameraDepthTexture, u_xlat0.xy).x;
    u_xlat8 = _ZBufferParams.z * u_xlat0.x + _ZBufferParams.w;
    u_xlat0.x = u_xlat0.x * _ProjectionParams.z + _ProjectionParams.y;
    u_xlat8 = float(1.0) / u_xlat8;
    u_xlatb16 = unity_OrthoParams.w==1.0;
    u_xlat0.x = (u_xlatb16) ? u_xlat0.x : u_xlat8;
    u_xlat0.x = u_xlat0.x + (-_SoftParticlesFadeDistanceNear);
    u_xlat0.x = u_xlat0.x + (-i.vs_TEXCOORD3.z);
    u_xlat0.x = u_xlat0.x * _SoftParticlesFadeDistanceFar;
    u_xlat0.x = clamp(u_xlat0.x, 0.0, 1.0);
    u_xlat0.x = u_xlat0.x * u_xlat16_4.x;
    result.w = min(u_xlat0.x, 1.0);
    return result;

}

#elif defined(SOFTPARTICLES_ON) && defined(_ALPHABLEND_ON) && !defined(_ALPHAMODULATE_ON) && !defined(_ALPHAPREMULTIPLY_ON) && defined(_ALPHATEST_ON) && !defined(_CFXR_ADDITIVE) && !defined(_CFXR_DISSOLVE) && !defined(_CFXR_EDGE_FADING) && !defined(_CFXR_FONT_COLORS) && defined(_CFXR_LIGHTING_ALL) && !defined(_CFXR_LIGHTING_BACK) && !defined(_CFXR_LIGHTING_WPOS_OFFSET) && !defined(_CFXR_OVERLAYTEX_1X) && !defined(_CFXR_SECONDCOLOR_LERP) && !defined(_CFXR_UV_DISTORTION) && defined(_EMISSION) && !defined(_FADING_ON) && !defined(_FLIPBOOK_BLENDING) && defined(_NORMALMAP)
// Original GLES program 90; SOFTPARTICLES_ON,_CFXR_LIGHTING_ALL,_NORMALMAP,_EMISSION,_ALPHATEST_ON,_ALPHABLEND_ON
float _SingleChannel;
float _BumpScale;
float _IndirectLightingMix;
float4 _ShadowColor;
float _DirectLightingRamp;
float _HdrMultiply;
float _Cutoff;
sampler2D _MainTex;
sampler2D _BumpMap;
struct A{float4 in_POSITION0:POSITION0;float4 in_COLOR0:COLOR0;float4 in_TEXCOORD0:TEXCOORD0;float4 in_TEXCOORD1:TEXCOORD1;float4 in_TEXCOORD2:TEXCOORD2;float3 in_NORMAL0:NORMAL0;float4 in_TANGENT0:TANGENT0;};
struct V{float4 vertex:SV_POSITION;float4 vs_COLOR0:TEXCOORD0;float4 vs_TEXCOORD0:TEXCOORD1;float4 vs_TEXCOORD2:TEXCOORD2;float3 vs_TEXCOORD4:TEXCOORD3;float3 vs_NORMAL0:TEXCOORD4;float4 vs_TANGENT0:TEXCOORD5;};
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
    o.vs_TEXCOORD2 = i.in_TEXCOORD2;
    o.vs_TEXCOORD4.xyz = i.in_POSITION0.xyz;
    o.vs_NORMAL0.xyz = i.in_NORMAL0.xyz;
    o.vs_TANGENT0 = i.in_TANGENT0;
    return o;

}
float4 frag(V i):SV_Target{float4 result=0;
float4 u_xlat0;
float4 u_xlat16_0;
float4 u_xlat1;
float4 u_xlat16_1;
bool u_xlatb1;
float4 u_xlat16_2;
float4 u_xlat3;
float4 u_xlat16_3;
float4 u_xlat4;
float3 u_xlat16_4;
float4 u_xlat5;
float3 u_xlat16_5;
float u_xlat16_6;
float3 u_xlat7;
float3 u_xlat8;
float u_xlat16_15;
float u_xlat16_29;
float u_xlat31;
bool u_xlatb31;

    u_xlat16_0 = tex2D(_MainTex, i.vs_TEXCOORD0.xy);
    u_xlatb1 = 0.0<_SingleChannel;
    u_xlat16_2.w = (u_xlatb1) ? u_xlat16_0.x : u_xlat16_0.w;
    u_xlat16_2.xyz = (bool(u_xlatb1)) ? float3(1.0, 1.0, 1.0) : u_xlat16_0.xyz;
    u_xlat16_0 = u_xlat16_2 * i.vs_COLOR0;
    u_xlat16_2.x = u_xlat16_2.w * i.vs_COLOR0.w + (-_Cutoff);
    u_xlatb1 = u_xlat16_2.x<0.0;
    if(u_xlatb1){discard;}
    u_xlat1.x = i.vs_TANGENT0.y;
    u_xlat1.z = i.vs_NORMAL0.y;
    u_xlat3.xyz = i.vs_NORMAL0.zxy * i.vs_TANGENT0.yzx;
    u_xlat3.xyz = i.vs_NORMAL0.yzx * i.vs_TANGENT0.zxy + (-u_xlat3.xyz);
    u_xlat3.xyz = u_xlat3.xzy * i.vs_TANGENT0.www;
    u_xlat1.y = u_xlat3.z;
    u_xlat16_4.xyz = tex2D(_BumpMap, i.vs_TEXCOORD0.xy).xyz;
    u_xlat16_2.xyz = u_xlat16_4.xyz * float3(2.0, 2.0, 2.0) + float3(-1.0, -1.0, -1.0);
    u_xlat16_2.xy = u_xlat16_2.xy * ((float2)(float2(_BumpScale, _BumpScale)));
    u_xlat16_1.y = dot(u_xlat16_2.xyz, u_xlat1.xyz);
    u_xlat16_29 = u_xlat16_1.y * u_xlat16_1.y;
    u_xlat4.y = u_xlat3.x;
    u_xlat4.x = i.vs_TANGENT0.x;
    u_xlat4.z = i.vs_NORMAL0.x;
    u_xlat16_1.x = dot(u_xlat16_2.xyz, u_xlat4.xyz);
    u_xlat16_29 = u_xlat16_1.x * u_xlat16_1.x + (-u_xlat16_29);
    u_xlat3.x = i.vs_TANGENT0.z;
    u_xlat3.z = i.vs_NORMAL0.z;
    u_xlat16_1.z = dot(u_xlat16_2.xyz, u_xlat3.xyz);
    u_xlat16_3 = u_xlat16_1.yzzx * u_xlat16_1.xyzz;
    u_xlat16_2.x = dot(unity_SHBr, u_xlat16_3);
    u_xlat16_2.y = dot(unity_SHBg, u_xlat16_3);
    u_xlat16_2.z = dot(unity_SHBb, u_xlat16_3);
    u_xlat16_2.xyz = unity_SHC.xyz * ((float3)(u_xlat16_29)) + u_xlat16_2.xyz;
    u_xlat16_1.w = 1.0;
    u_xlat16_5.x = dot(unity_SHAr, u_xlat16_1);
    u_xlat16_5.y = dot(unity_SHAg, u_xlat16_1);
    u_xlat16_5.z = dot(unity_SHAb, u_xlat16_1);
    u_xlat16_2.xyz = u_xlat16_2.xyz + u_xlat16_5.xyz;
    u_xlat16_2.xyz = max(u_xlat16_2.xyz, float3(0.0, 0.0, 0.0));
    u_xlat4.xyz = log2(u_xlat16_2.xyz);
    u_xlat4.xyz = u_xlat4.xyz * float3(0.416666657, 0.416666657, 0.416666657);
    u_xlat4.xyz = exp2(u_xlat4.xyz);
    u_xlat4.xyz = u_xlat4.xyz * float3(1.05499995, 1.05499995, 1.05499995) + float3(-0.0549999997, -0.0549999997, -0.0549999997);
    u_xlat31 = log2(_HdrMultiply);
    u_xlat31 = u_xlat31 * 0.416666657;
    u_xlat31 = exp2(u_xlat31);
    u_xlat4.w = u_xlat31 * 1.05499995 + -0.0549999997;
    u_xlat4 = max(u_xlat4, float4(0.0, 0.0, 0.0, 0.0));
    u_xlat16_2.xyz = u_xlat16_0.xyz * u_xlat4.www;
    u_xlatb31 = 0.0<_HdrMultiply;
    u_xlat16_2.xyz = (bool(u_xlatb31)) ? u_xlat16_2.xyz : u_xlat16_0.xyz;
    result.w = min(u_xlat16_0.w, 1.0);
    u_xlat0 = (-i.vs_TEXCOORD4.yyyy) + unity_4LightPosY0;
    u_xlat3 = u_xlat16_1.yyyy * u_xlat0;
    u_xlat31 = dot(u_xlat16_1.xyz, _WorldSpaceLightPos0.xyz);
    u_xlat16_29 = u_xlat31 * 0.5 + 0.5;
    u_xlat0 = u_xlat0 * u_xlat0;
    u_xlat5 = (-i.vs_TEXCOORD4.xxxx) + unity_4LightPosX0;
    u_xlat3 = u_xlat5 * u_xlat16_1.xxxx + u_xlat3;
    u_xlat0 = u_xlat5 * u_xlat5 + u_xlat0;
    u_xlat5 = (-i.vs_TEXCOORD4.zzzz) + unity_4LightPosZ0;
    u_xlat1 = u_xlat5 * u_xlat16_1.zzzz + u_xlat3;
    u_xlat0 = u_xlat5 * u_xlat5 + u_xlat0;
    u_xlat0 = max(u_xlat0, float4(9.99999997e-07, 9.99999997e-07, 9.99999997e-07, 9.99999997e-07));
    u_xlat1 = u_xlat1 * float4(0.5, 0.5, 0.5, 0.5) + float4(0.5, 0.5, 0.5, 0.5);
    u_xlat16_6 = (-_DirectLightingRamp) * 0.5 + 0.5;
    u_xlat1 = u_xlat1 + (-((float4)(u_xlat16_6)));
    u_xlat16_15 = _DirectLightingRamp * 0.5 + 0.5;
    u_xlat31 = (-u_xlat16_6) + u_xlat16_15;
    u_xlat16_15 = (-u_xlat16_6) + u_xlat16_15;
    u_xlat16_29 = u_xlat16_29 + (-u_xlat16_6);
    u_xlat16_6 = float(1.0) / u_xlat16_15;
    u_xlat16_29 = u_xlat16_29 * u_xlat16_6;
    u_xlat16_29 = clamp(u_xlat16_29, 0.0, 1.0);
    u_xlat31 = float(1.0) / u_xlat31;
    u_xlat1 = u_xlat1 * ((float4)(u_xlat31));
    u_xlat1 = clamp(u_xlat1, 0.0, 1.0);
    u_xlat3 = u_xlat1 * float4(-2.0, -2.0, -2.0, -2.0) + float4(3.0, 3.0, 3.0, 3.0);
    u_xlat1 = u_xlat1 * u_xlat1;
    u_xlat1 = u_xlat1 * u_xlat3;
    u_xlat3 = rsqrt(u_xlat0);
    u_xlat0 = u_xlat0 * unity_4LightAtten0 + float4(1.0, 1.0, 1.0, 1.0);
    u_xlat0 = float4(1.0, 1.0, 1.0, 1.0) / u_xlat0;
    u_xlat1 = u_xlat1 * u_xlat3;
    u_xlat0 = u_xlat0 * u_xlat1;
    u_xlat7.xyz = u_xlat0.yyy * unity_LightColor[1].xyz;
    u_xlat7.xyz = unity_LightColor[0].xyz * u_xlat0.xxx + u_xlat7.xyz;
    u_xlat7.xyz = unity_LightColor[2].xyz * u_xlat0.zzz + u_xlat7.xyz;
    u_xlat7.xyz = unity_LightColor[3].xyz * u_xlat0.www + u_xlat7.xyz;
    u_xlat16_6 = u_xlat16_29 * -2.0 + 3.0;
    u_xlat16_29 = u_xlat16_29 * u_xlat16_29;
    u_xlat16_29 = u_xlat16_29 * u_xlat16_6;
    u_xlat8.xyz = _LightColor0.xyz + (-_ShadowColor.xyz);
    u_xlat8.xyz = ((float3)(u_xlat16_29)) * u_xlat8.xyz + _ShadowColor.xyz;
    u_xlat16_2.xyz = u_xlat16_2.xyz * u_xlat8.xyz + u_xlat7.xyz;
    u_xlat16_2.xyz = u_xlat4.xyz * ((float3)(float3(_IndirectLightingMix, _IndirectLightingMix, _IndirectLightingMix))) + u_xlat16_2.xyz;
    u_xlat4.xyz = u_xlat16_2.xyz + i.vs_TEXCOORD2.xyz;
    result.xyz = u_xlat4.xyz;
    return result;

}

#elif defined(SOFTPARTICLES_ON) && defined(_ALPHABLEND_ON) && !defined(_ALPHAMODULATE_ON) && !defined(_ALPHAPREMULTIPLY_ON) && defined(_ALPHATEST_ON) && !defined(_CFXR_ADDITIVE) && !defined(_CFXR_DISSOLVE) && defined(_CFXR_EDGE_FADING) && !defined(_CFXR_FONT_COLORS) && !defined(_CFXR_LIGHTING_ALL) && !defined(_CFXR_LIGHTING_BACK) && !defined(_CFXR_LIGHTING_WPOS_OFFSET) && !defined(_CFXR_OVERLAYTEX_1X) && !defined(_CFXR_SECONDCOLOR_LERP) && defined(_CFXR_UV_DISTORTION) && !defined(_EMISSION) && defined(_FADING_ON) && !defined(_FLIPBOOK_BLENDING) && !defined(_NORMALMAP)
// Original GLES program 95; SOFTPARTICLES_ON,_CFXR_EDGE_FADING,_FADING_ON,_CFXR_UV_DISTORTION,_ALPHATEST_ON,_ALPHABLEND_ON
float _EdgeFadePow;
float _SingleChannel;
float _UseUV2Distortion;
float _UVDistortionAdd;
float4 _DistortScrolling;
float _Distort;
float _FadeAlongU;
float _HdrMultiply;
float _Cutoff;
float _SoftParticlesFadeDistanceNear;
float _SoftParticlesFadeDistanceFar;
sampler2D _DistortTex;
sampler2D _MainTex;
sampler2D _CameraDepthTexture;
struct A{float4 in_POSITION0:POSITION0;float4 in_COLOR0:COLOR0;float4 in_TEXCOORD0:TEXCOORD0;float4 in_TEXCOORD1:TEXCOORD1;float3 in_NORMAL0:NORMAL0;};
struct V{float4 vertex:SV_POSITION;float4 vs_COLOR0:TEXCOORD0;float4 vs_TEXCOORD0:TEXCOORD1;float4 vs_TEXCOORD1:TEXCOORD2;float4 vs_TEXCOORD3:TEXCOORD3;};
V vert(A i){V o=(V)0;
float4 u_xlat0;
float4 u_xlat1;
float3 u_xlat2;
float u_xlat3;
float u_xlat7;

    u_xlat0 = i.in_POSITION0.yyyy * transpose(unity_ObjectToWorld)[1];
    u_xlat0 = transpose(unity_ObjectToWorld)[0] * i.in_POSITION0.xxxx + u_xlat0;
    u_xlat0 = transpose(unity_ObjectToWorld)[2] * i.in_POSITION0.zzzz + u_xlat0;
    u_xlat0 = u_xlat0 + transpose(unity_ObjectToWorld)[3];
    u_xlat1 = u_xlat0.yyyy * transpose(unity_MatrixVP)[1];
    u_xlat1 = transpose(unity_MatrixVP)[0] * u_xlat0.xxxx + u_xlat1;
    u_xlat1 = transpose(unity_MatrixVP)[2] * u_xlat0.zzzz + u_xlat1;
    u_xlat1 = transpose(unity_MatrixVP)[3] * u_xlat0.wwww + u_xlat1;
    o.vertex = u_xlat1;
    u_xlat2.xyz = (-i.in_POSITION0.xyz) + _WorldSpaceCameraPos.xyz;
    u_xlat7 = dot(u_xlat2.xyz, u_xlat2.xyz);
    u_xlat7 = rsqrt(u_xlat7);
    u_xlat2.xyz = ((float3)(u_xlat7)) * u_xlat2.xyz;
    u_xlat7 = dot(u_xlat2.xyz, i.in_NORMAL0.xyz);
    u_xlat7 = log2(abs(u_xlat7));
    u_xlat7 = u_xlat7 * _EdgeFadePow;
    u_xlat7 = exp2(u_xlat7);
    u_xlat7 = min(u_xlat7, 1.0);
    u_xlat7 = u_xlat7 * i.in_COLOR0.w;
    o.vs_COLOR0.w = u_xlat7;
    o.vs_COLOR0.xyz = i.in_COLOR0.xyz;
    o.vs_TEXCOORD0 = i.in_TEXCOORD0.xyxy;
    o.vs_TEXCOORD1 = i.in_TEXCOORD1;
    u_xlat3 = u_xlat0.y * transpose(unity_MatrixV)[1].z;
    u_xlat0.x = transpose(unity_MatrixV)[0].z * u_xlat0.x + u_xlat3;
    u_xlat0.x = transpose(unity_MatrixV)[2].z * u_xlat0.z + u_xlat0.x;
    u_xlat0.x = transpose(unity_MatrixV)[3].z * u_xlat0.w + u_xlat0.x;
    o.vs_TEXCOORD3.z = (-u_xlat0.x);
    u_xlat0.x = u_xlat1.y * _ProjectionParams.x;
    u_xlat0.w = u_xlat0.x * 0.5;
    u_xlat0.xz = u_xlat1.xw * float2(0.5, 0.5);
    o.vs_TEXCOORD3.w = u_xlat1.w;
    o.vs_TEXCOORD3.xy = u_xlat0.zz + u_xlat0.xw;
    return o;

}
float4 frag(V i):SV_Target{float4 result=0;
float2 u_xlat0;
float4 u_xlat16_0;
float2 u_xlat1;
bool3 u_xlatb1;
float4 u_xlat16_2;
float u_xlat4;
float2 u_xlat6;
bool u_xlatb7;

    u_xlat0.xy = _Time.yy * _DistortScrolling.xy;
    u_xlat0.xy = frac(u_xlat0.xy);
    u_xlatb1.xyz = lessThan(float4(0.0, 0.0, 0.0, 0.0), float4(_UseUV2Distortion, _UVDistortionAdd, _SingleChannel, _UseUV2Distortion)).xyz;
    u_xlat6.xy = (u_xlatb1.x) ? i.vs_TEXCOORD1.xy : i.vs_TEXCOORD0.xy;
    u_xlat6.xy = u_xlat6.xy * _DistortScrolling.zw + i.vs_TEXCOORD0.zw;
    u_xlat0.xy = u_xlat0.xy + u_xlat6.xy;
    u_xlat16_0.xy = tex2D(_DistortTex, u_xlat0.xy).xy;
    u_xlat6.xy = u_xlat16_0.xy * float2(2.0, 2.0) + float2(-1.0, -1.0);
    u_xlat0.xy = u_xlat16_0.xy + (-i.vs_TEXCOORD0.xy);
    u_xlat0.xy = ((float2)(_Distort)) * u_xlat0.xy + i.vs_TEXCOORD0.xy;
    u_xlat6.xy = u_xlat6.xy * ((float2)(_Distort)) + i.vs_TEXCOORD0.xy;
    u_xlat0.xy = (u_xlatb1.y) ? u_xlat6.xy : u_xlat0.xy;
    u_xlat6.xy = u_xlat0.xy + (-i.vs_TEXCOORD0.xy);
    u_xlat1.x = i.vs_TEXCOORD0.y * 0.5;
    u_xlat6.xy = u_xlat1.xx * u_xlat6.xy + i.vs_TEXCOORD0.xy;
    u_xlatb1.xy = lessThan(float4(0.0, 0.0, 0.0, 0.0), float4(_FadeAlongU, _HdrMultiply, _FadeAlongU, _FadeAlongU)).xy;
    u_xlat0.xy = (u_xlatb1.x) ? u_xlat6.xy : u_xlat0.xy;
    u_xlat16_0 = tex2D(_MainTex, u_xlat0.xy);
    u_xlat16_2.w = (u_xlatb1.z) ? u_xlat16_0.x : u_xlat16_0.w;
    u_xlat16_2.xyz = (u_xlatb1.z) ? float3(1.0, 1.0, 1.0) : u_xlat16_0.xyz;
    u_xlat16_0 = u_xlat16_2 * i.vs_COLOR0;
    u_xlat16_2.x = u_xlat16_2.w * i.vs_COLOR0.w + (-_Cutoff);
    u_xlatb1.x = u_xlat16_2.x<0.0;
    if(u_xlatb1.x){discard;}
    u_xlat1.x = log2(_HdrMultiply);
    u_xlat1.x = u_xlat1.x * 0.416666657;
    u_xlat1.x = exp2(u_xlat1.x);
    u_xlat1.x = u_xlat1.x * 1.05499995 + -0.0549999997;
    u_xlat1.x = max(u_xlat1.x, 0.0);
    u_xlat16_2.xyz = u_xlat16_0.xyz * u_xlat1.xxx;
    result.xyz = (u_xlatb1.y) ? u_xlat16_2.xyz : u_xlat16_0.xyz;
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

#elif defined(SOFTPARTICLES_ON) && !defined(_ALPHABLEND_ON) && !defined(_ALPHAMODULATE_ON) && !defined(_ALPHAPREMULTIPLY_ON) && defined(_ALPHATEST_ON) && defined(_CFXR_ADDITIVE) && !defined(_CFXR_DISSOLVE) && defined(_CFXR_EDGE_FADING) && !defined(_CFXR_FONT_COLORS) && !defined(_CFXR_LIGHTING_ALL) && !defined(_CFXR_LIGHTING_BACK) && !defined(_CFXR_LIGHTING_WPOS_OFFSET) && !defined(_CFXR_OVERLAYTEX_1X) && !defined(_CFXR_SECONDCOLOR_LERP) && defined(_CFXR_UV_DISTORTION) && !defined(_EMISSION) && defined(_FADING_ON) && !defined(_FLIPBOOK_BLENDING) && !defined(_NORMALMAP)
// Original GLES program 105; SOFTPARTICLES_ON,_CFXR_EDGE_FADING,_FADING_ON,_CFXR_UV_DISTORTION,_ALPHATEST_ON,_CFXR_ADDITIVE
float _EdgeFadePow;
float _SingleChannel;
float _UseUV2Distortion;
float _UVDistortionAdd;
float4 _DistortScrolling;
float _Distort;
float _FadeAlongU;
float _HdrMultiply;
float _Cutoff;
float _SoftParticlesFadeDistanceNear;
float _SoftParticlesFadeDistanceFar;
sampler2D _DistortTex;
sampler2D _MainTex;
sampler2D _CameraDepthTexture;
struct A{float4 in_POSITION0:POSITION0;float4 in_COLOR0:COLOR0;float4 in_TEXCOORD0:TEXCOORD0;float4 in_TEXCOORD1:TEXCOORD1;float3 in_NORMAL0:NORMAL0;};
struct V{float4 vertex:SV_POSITION;float4 vs_COLOR0:TEXCOORD0;float4 vs_TEXCOORD0:TEXCOORD1;float4 vs_TEXCOORD1:TEXCOORD2;float4 vs_TEXCOORD3:TEXCOORD3;};
V vert(A i){V o=(V)0;
float4 u_xlat0;
float4 u_xlat1;
float3 u_xlat2;
float u_xlat3;
float u_xlat7;

    u_xlat0 = i.in_POSITION0.yyyy * transpose(unity_ObjectToWorld)[1];
    u_xlat0 = transpose(unity_ObjectToWorld)[0] * i.in_POSITION0.xxxx + u_xlat0;
    u_xlat0 = transpose(unity_ObjectToWorld)[2] * i.in_POSITION0.zzzz + u_xlat0;
    u_xlat0 = u_xlat0 + transpose(unity_ObjectToWorld)[3];
    u_xlat1 = u_xlat0.yyyy * transpose(unity_MatrixVP)[1];
    u_xlat1 = transpose(unity_MatrixVP)[0] * u_xlat0.xxxx + u_xlat1;
    u_xlat1 = transpose(unity_MatrixVP)[2] * u_xlat0.zzzz + u_xlat1;
    u_xlat1 = transpose(unity_MatrixVP)[3] * u_xlat0.wwww + u_xlat1;
    o.vertex = u_xlat1;
    u_xlat2.xyz = (-i.in_POSITION0.xyz) + _WorldSpaceCameraPos.xyz;
    u_xlat7 = dot(u_xlat2.xyz, u_xlat2.xyz);
    u_xlat7 = rsqrt(u_xlat7);
    u_xlat2.xyz = ((float3)(u_xlat7)) * u_xlat2.xyz;
    u_xlat7 = dot(u_xlat2.xyz, i.in_NORMAL0.xyz);
    u_xlat7 = log2(abs(u_xlat7));
    u_xlat7 = u_xlat7 * _EdgeFadePow;
    u_xlat7 = exp2(u_xlat7);
    u_xlat7 = min(u_xlat7, 1.0);
    u_xlat7 = u_xlat7 * i.in_COLOR0.w;
    o.vs_COLOR0.w = u_xlat7;
    o.vs_COLOR0.xyz = i.in_COLOR0.xyz;
    o.vs_TEXCOORD0 = i.in_TEXCOORD0.xyxy;
    o.vs_TEXCOORD1 = i.in_TEXCOORD1;
    u_xlat3 = u_xlat0.y * transpose(unity_MatrixV)[1].z;
    u_xlat0.x = transpose(unity_MatrixV)[0].z * u_xlat0.x + u_xlat3;
    u_xlat0.x = transpose(unity_MatrixV)[2].z * u_xlat0.z + u_xlat0.x;
    u_xlat0.x = transpose(unity_MatrixV)[3].z * u_xlat0.w + u_xlat0.x;
    o.vs_TEXCOORD3.z = (-u_xlat0.x);
    u_xlat0.x = u_xlat1.y * _ProjectionParams.x;
    u_xlat0.w = u_xlat0.x * 0.5;
    u_xlat0.xz = u_xlat1.xw * float2(0.5, 0.5);
    o.vs_TEXCOORD3.w = u_xlat1.w;
    o.vs_TEXCOORD3.xy = u_xlat0.zz + u_xlat0.xw;
    return o;

}
float4 frag(V i):SV_Target{float4 result=0;
float2 u_xlat0;
float4 u_xlat16_0;
float2 u_xlat1;
bool3 u_xlatb1;
float4 u_xlat16_2;
float u_xlat4;
float2 u_xlat6;
bool u_xlatb7;

    u_xlat0.xy = _Time.yy * _DistortScrolling.xy;
    u_xlat0.xy = frac(u_xlat0.xy);
    u_xlatb1.xyz = lessThan(float4(0.0, 0.0, 0.0, 0.0), float4(_UseUV2Distortion, _UVDistortionAdd, _SingleChannel, _UseUV2Distortion)).xyz;
    u_xlat6.xy = (u_xlatb1.x) ? i.vs_TEXCOORD1.xy : i.vs_TEXCOORD0.xy;
    u_xlat6.xy = u_xlat6.xy * _DistortScrolling.zw + i.vs_TEXCOORD0.zw;
    u_xlat0.xy = u_xlat0.xy + u_xlat6.xy;
    u_xlat16_0.xy = tex2D(_DistortTex, u_xlat0.xy).xy;
    u_xlat6.xy = u_xlat16_0.xy * float2(2.0, 2.0) + float2(-1.0, -1.0);
    u_xlat0.xy = u_xlat16_0.xy + (-i.vs_TEXCOORD0.xy);
    u_xlat0.xy = ((float2)(_Distort)) * u_xlat0.xy + i.vs_TEXCOORD0.xy;
    u_xlat6.xy = u_xlat6.xy * ((float2)(_Distort)) + i.vs_TEXCOORD0.xy;
    u_xlat0.xy = (u_xlatb1.y) ? u_xlat6.xy : u_xlat0.xy;
    u_xlat6.xy = u_xlat0.xy + (-i.vs_TEXCOORD0.xy);
    u_xlat1.x = i.vs_TEXCOORD0.y * 0.5;
    u_xlat6.xy = u_xlat1.xx * u_xlat6.xy + i.vs_TEXCOORD0.xy;
    u_xlatb1.xy = lessThan(float4(0.0, 0.0, 0.0, 0.0), float4(_FadeAlongU, _HdrMultiply, _FadeAlongU, _FadeAlongU)).xy;
    u_xlat0.xy = (u_xlatb1.x) ? u_xlat6.xy : u_xlat0.xy;
    u_xlat16_0 = tex2D(_MainTex, u_xlat0.xy);
    u_xlat16_2.w = (u_xlatb1.z) ? u_xlat16_0.x : u_xlat16_0.w;
    u_xlat16_2.xyz = (u_xlatb1.z) ? float3(1.0, 1.0, 1.0) : u_xlat16_0.xyz;
    u_xlat16_0 = u_xlat16_2 * i.vs_COLOR0;
    u_xlat16_2.x = u_xlat16_2.w * i.vs_COLOR0.w + (-_Cutoff);
    u_xlatb1.x = u_xlat16_2.x<0.0;
    if(u_xlatb1.x){discard;}
    u_xlat1.x = log2(_HdrMultiply);
    u_xlat1.x = u_xlat1.x * 0.416666657;
    u_xlat1.x = exp2(u_xlat1.x);
    u_xlat1.x = u_xlat1.x * 1.05499995 + -0.0549999997;
    u_xlat1.x = max(u_xlat1.x, 0.0);
    u_xlat16_2.xyz = u_xlat16_0.xyz * u_xlat1.xxx;
    result.xyz = (u_xlatb1.y) ? u_xlat16_2.xyz : u_xlat16_0.xyz;
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

#elif !defined(SOFTPARTICLES_ON) && defined(_ALPHABLEND_ON) && !defined(_ALPHAMODULATE_ON) && !defined(_ALPHAPREMULTIPLY_ON) && !defined(_ALPHATEST_ON) && !defined(_CFXR_ADDITIVE) && defined(_CFXR_DISSOLVE) && !defined(_CFXR_EDGE_FADING) && !defined(_CFXR_FONT_COLORS) && defined(_CFXR_LIGHTING_ALL) && defined(_CFXR_LIGHTING_BACK) && !defined(_CFXR_LIGHTING_WPOS_OFFSET) && !defined(_CFXR_OVERLAYTEX_1X) && !defined(_CFXR_SECONDCOLOR_LERP) && !defined(_CFXR_UV_DISTORTION) && !defined(_EMISSION) && defined(_FADING_ON) && !defined(_FLIPBOOK_BLENDING) && !defined(_NORMALMAP)
// Original GLES program 43; _CFXR_DISSOLVE,_CFXR_LIGHTING_ALL,_CFXR_LIGHTING_BACK,_FADING_ON,_ALPHABLEND_ON
float _SingleChannel;
float _UseDissolveOffsetUV;
float _IndirectLightingMix;
float4 _ShadowColor;
float _DirectLightingRamp;
float _DirLightScreenAtten;
float _BacklightTransmittance;
float _InvertDissolveTex;
float _DoubleDissolve;
float2 _DissolveScroll;
float _DissolveSmooth;
float _HdrMultiply;
float4 _DissolveTex_ST;
sampler2D _MainTex;
sampler2D _DissolveTex;
struct A{float4 in_POSITION0:POSITION0;float4 in_COLOR0:COLOR0;float4 in_TEXCOORD0:TEXCOORD0;float4 in_TEXCOORD1:TEXCOORD1;float3 in_NORMAL0:NORMAL0;};
struct V{float4 vertex:SV_POSITION;float4 vs_COLOR0:TEXCOORD0;float4 vs_TEXCOORD0:TEXCOORD1;float4 vs_TEXCOORD1:TEXCOORD2;float3 vs_TEXCOORD4:TEXCOORD3;float3 vs_TEXCOORD5:TEXCOORD4;float3 vs_TEXCOORD6:TEXCOORD5;float3 vs_NORMAL0:TEXCOORD6;};
V vert(A i){V o=(V)0;
float4 u_xlat0;
float4 u_xlat16_0;
float4 u_xlat1;
float3 u_xlat16_2;
float3 u_xlat16_3;
float u_xlat13;

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
    o.vs_TEXCOORD1 = i.in_TEXCOORD1;
    o.vs_TEXCOORD4.xyz = i.in_POSITION0.xyz;
    u_xlat16_2.x = i.in_NORMAL0.y * i.in_NORMAL0.y;
    u_xlat16_2.x = i.in_NORMAL0.x * i.in_NORMAL0.x + (-u_xlat16_2.x);
    u_xlat16_0 = i.in_NORMAL0.yzzx * i.in_NORMAL0.xyzz;
    u_xlat16_3.x = dot(unity_SHBr, u_xlat16_0);
    u_xlat16_3.y = dot(unity_SHBg, u_xlat16_0);
    u_xlat16_3.z = dot(unity_SHBb, u_xlat16_0);
    u_xlat16_2.xyz = unity_SHC.xyz * u_xlat16_2.xxx + u_xlat16_3.xyz;
    u_xlat0.xyz = i.in_NORMAL0.xyz;
    u_xlat0.w = 1.0;
    u_xlat16_3.x = dot(unity_SHAr, u_xlat0);
    u_xlat16_3.y = dot(unity_SHAg, u_xlat0);
    u_xlat16_3.z = dot(unity_SHAb, u_xlat0);
    u_xlat16_2.xyz = u_xlat16_2.xyz + u_xlat16_3.xyz;
    u_xlat16_2.xyz = max(u_xlat16_2.xyz, float3(0.0, 0.0, 0.0));
    u_xlat1.xyz = log2(u_xlat16_2.xyz);
    u_xlat1.xyz = u_xlat1.xyz * float3(0.416666657, 0.416666657, 0.416666657);
    u_xlat1.xyz = exp2(u_xlat1.xyz);
    u_xlat1.xyz = u_xlat1.xyz * float3(1.05499995, 1.05499995, 1.05499995) + float3(-0.0549999997, -0.0549999997, -0.0549999997);
    o.vs_TEXCOORD5.xyz = max(u_xlat1.xyz, float3(0.0, 0.0, 0.0));
    u_xlat1.xyz = (-i.in_POSITION0.xyz) + _WorldSpaceCameraPos.xyz;
    u_xlat13 = dot(u_xlat1.xyz, u_xlat1.xyz);
    u_xlat13 = rsqrt(u_xlat13);
    o.vs_TEXCOORD6.xyz = ((float3)(u_xlat13)) * u_xlat1.xyz;
    o.vs_NORMAL0.xyz = i.in_NORMAL0.xyz;
    return o;

}
float4 frag(V i):SV_Target{float4 result=0;
float4 u_xlat0;
float u_xlat16_0;
bool u_xlatb0;
float4 u_xlat1;
float4 u_xlat2;
float4 u_xlat16_2;
float4 u_xlat3;
bool2 u_xlatb3;
float4 u_xlat16_4;
float4 u_xlat5;
float4 u_xlat6;
float u_xlat16_7;
float u_xlat8;
float u_xlat16_12;
float2 u_xlat16;
float u_xlat16_20;
float u_xlat24;
bool u_xlatb24;
float u_xlat16_28;

    u_xlat0 = (-i.vs_TEXCOORD4.yyyy) + unity_4LightPosY0;
    u_xlat1 = u_xlat0 * i.vs_NORMAL0.yyyy;
    u_xlat2 = (-i.vs_TEXCOORD4.xxxx) + unity_4LightPosX0;
    u_xlat1 = u_xlat2 * i.vs_NORMAL0.xxxx + u_xlat1;
    u_xlat3 = (-i.vs_TEXCOORD4.zzzz) + unity_4LightPosZ0;
    u_xlat1 = u_xlat3 * i.vs_NORMAL0.zzzz + u_xlat1;
    u_xlat1 = u_xlat1 * float4(0.5, 0.5, 0.5, 0.5) + float4(0.5, 0.5, 0.5, 0.5);
    u_xlat16_4.x = (-_DirectLightingRamp) * 0.5 + 0.5;
    u_xlat1 = u_xlat1 + (-u_xlat16_4.xxxx);
    u_xlat16_12 = _DirectLightingRamp * 0.5 + 0.5;
    u_xlat5.x = (-u_xlat16_4.x) + u_xlat16_12;
    u_xlat16_12 = (-u_xlat16_4.x) + u_xlat16_12;
    u_xlat16_12 = float(1.0) / u_xlat16_12;
    u_xlat5.x = float(1.0) / u_xlat5.x;
    u_xlat1 = u_xlat1 * u_xlat5.xxxx;
    u_xlat1 = clamp(u_xlat1, 0.0, 1.0);
    u_xlat6 = u_xlat1 * float4(-2.0, -2.0, -2.0, -2.0) + float4(3.0, 3.0, 3.0, 3.0);
    u_xlat1 = u_xlat1 * u_xlat1;
    u_xlat1 = u_xlat1 * u_xlat6;
    u_xlat6 = u_xlat0 * u_xlat0;
    u_xlat0 = u_xlat0 * (-i.vs_NORMAL0.yyyy);
    u_xlat0 = u_xlat2 * (-i.vs_NORMAL0.xxxx) + u_xlat0;
    u_xlat2 = u_xlat2 * u_xlat2 + u_xlat6;
    u_xlat2 = u_xlat3 * u_xlat3 + u_xlat2;
    u_xlat0 = u_xlat3 * (-i.vs_NORMAL0.zzzz) + u_xlat0;
    u_xlat0 = u_xlat0 * float4(0.5, 0.5, 0.5, 0.5) + (-u_xlat16_4.xxxx);
    u_xlat0 = u_xlat0 + float4(0.5, 0.5, 0.5, 0.5);
    u_xlat0 = u_xlat5.xxxx * u_xlat0;
    u_xlat0 = clamp(u_xlat0, 0.0, 1.0);
    u_xlat2 = max(u_xlat2, float4(9.99999997e-07, 9.99999997e-07, 9.99999997e-07, 9.99999997e-07));
    u_xlat3 = rsqrt(u_xlat2);
    u_xlat2 = u_xlat2 * unity_4LightAtten0 + float4(1.0, 1.0, 1.0, 1.0);
    u_xlat2 = float4(1.0, 1.0, 1.0, 1.0) / u_xlat2;
    u_xlat1 = u_xlat1 * u_xlat3;
    u_xlat1 = u_xlat2 * u_xlat1;
    u_xlat5.xyz = u_xlat1.yyy * unity_LightColor[1].xyz;
    u_xlat5.xyz = unity_LightColor[0].xyz * u_xlat1.xxx + u_xlat5.xyz;
    u_xlat1.xyz = unity_LightColor[2].xyz * u_xlat1.zzz + u_xlat5.xyz;
    u_xlat1.xyz = unity_LightColor[3].xyz * u_xlat1.www + u_xlat1.xyz;
    u_xlat5 = u_xlat0 * float4(-2.0, -2.0, -2.0, -2.0) + float4(3.0, 3.0, 3.0, 3.0);
    u_xlat0 = u_xlat0 * u_xlat0;
    u_xlat0 = u_xlat0 * u_xlat5;
    u_xlat0 = u_xlat3 * u_xlat0;
    u_xlat0 = u_xlat2 * u_xlat0;
    u_xlat2.xyz = u_xlat0.yyy * unity_LightColor[1].xyz;
    u_xlat2.xyz = unity_LightColor[0].xyz * u_xlat0.xxx + u_xlat2.xyz;
    u_xlat0.xyz = unity_LightColor[2].xyz * u_xlat0.zzz + u_xlat2.xyz;
    u_xlat0.xyz = unity_LightColor[3].xyz * u_xlat0.www + u_xlat0.xyz;
    u_xlat0.xyz = u_xlat0.xyz * ((float3)(float3(_BacklightTransmittance, _BacklightTransmittance, _BacklightTransmittance))) + u_xlat1.xyz;
    u_xlat24 = dot(i.vs_NORMAL0.xyz, _WorldSpaceLightPos0.xyz);
    u_xlat16_20 = u_xlat24 * 0.5 + 0.5;
    u_xlat16_4.x = (-u_xlat16_4.x) + u_xlat16_20;
    u_xlat16_4.x = u_xlat16_12 * u_xlat16_4.x;
    u_xlat16_4.x = clamp(u_xlat16_4.x, 0.0, 1.0);
    u_xlat16_12 = u_xlat16_4.x * -2.0 + 3.0;
    u_xlat1.xyz = i.vs_TEXCOORD6.xyz + _WorldSpaceLightPos0.xyz;
    u_xlat24 = dot(u_xlat1.xyz, u_xlat1.xyz);
    u_xlat24 = sqrt(u_xlat24);
    u_xlat16_20 = float(1.0) / _DirLightScreenAtten;
    u_xlat16_4.z = u_xlat24 * u_xlat16_20;
    u_xlat16_4.z = clamp(u_xlat16_4.z, 0.0, 1.0);
    u_xlat16_28 = u_xlat16_4.z * -2.0 + 3.0;
    u_xlat16_4.xz = u_xlat16_4.xz * u_xlat16_4.xz;
    u_xlat16_20 = (-u_xlat16_28) * u_xlat16_4.z + 1.0;
    u_xlat16_20 = u_xlat16_20 * u_xlat16_20;
    u_xlat16_20 = u_xlat16_20 * _BacklightTransmittance;
    u_xlat16_4.x = u_xlat16_12 * u_xlat16_4.x + u_xlat16_20;
    u_xlat1.xyz = _LightColor0.xyz + (-_ShadowColor.xyz);
    u_xlat1.xyz = u_xlat16_4.xxx * u_xlat1.xyz + _ShadowColor.xyz;
    u_xlat24 = log2(_HdrMultiply);
    u_xlat24 = u_xlat24 * 0.416666657;
    u_xlat24 = exp2(u_xlat24);
    u_xlat24 = u_xlat24 * 1.05499995 + -0.0549999997;
    u_xlat24 = max(u_xlat24, 0.0);
    u_xlat16_2 = tex2D(_MainTex, i.vs_TEXCOORD0.xy);
    u_xlatb3.xy = lessThan(float4(0.0, 0.0, 0.0, 0.0), float4(_SingleChannel, _UseDissolveOffsetUV, _SingleChannel, _SingleChannel)).xy;
    u_xlat16_4.xyz = (u_xlatb3.x) ? float3(1.0, 1.0, 1.0) : u_xlat16_2.xyz;
    u_xlat16_4.w = (u_xlatb3.x) ? u_xlat16_2.x : u_xlat16_2.w;
    u_xlat16_2 = u_xlat16_4 * i.vs_COLOR0;
    u_xlat16_4.xyz = ((float3)(u_xlat24)) * u_xlat16_2.xyz;
    u_xlatb24 = 0.0<_HdrMultiply;
    u_xlat16_4.xyz = (bool(u_xlatb24)) ? u_xlat16_4.xyz : u_xlat16_2.xyz;
    u_xlat16_4.xyz = u_xlat16_4.xyz * u_xlat1.xyz + u_xlat0.xyz;
    u_xlat0.xyz = i.vs_TEXCOORD5.xyz * ((float3)(float3(_IndirectLightingMix, _IndirectLightingMix, _IndirectLightingMix))) + u_xlat16_4.xyz;
    result.xyz = u_xlat0.xyz;
    u_xlat0.xy = _Time.yy * float2(_DissolveScroll.x, _DissolveScroll.y);
    u_xlat0.xy = frac(u_xlat0.xy);
    u_xlat16.xy = i.vs_TEXCOORD0.xy * _DissolveTex_ST.xy + _DissolveTex_ST.zw;
    u_xlat0.xy = u_xlat0.xy + u_xlat16.xy;
    u_xlat0.xy = (u_xlatb3.y) ? u_xlat0.xy : i.vs_TEXCOORD0.xy;
    u_xlat16_0 = tex2D(_DissolveTex, u_xlat0.xy).x;
    u_xlat16_4.x = u_xlat16_0 * 2.0 + -1.0;
    u_xlat8 = u_xlat16_4.x * i.vs_TEXCOORD1.z + i.vs_TEXCOORD0.x;
    u_xlat16_4.x = (u_xlatb3.y) ? u_xlat8 : u_xlat16_0;
    u_xlat16_12 = (-u_xlat16_4.x) + 1.0;
    u_xlatb0 = 0.0>=_InvertDissolveTex;
    u_xlat16_4.x = (u_xlatb0) ? u_xlat16_12 : u_xlat16_4.x;
    u_xlat16_12 = u_xlat16_4.x + _DissolveSmooth;
    u_xlat16_4.x = u_xlat16_4.x + (-_DissolveSmooth);
    u_xlat16_12 = (-u_xlat16_4.x) + u_xlat16_12;
    u_xlat16_12 = float(1.0) / u_xlat16_12;
    u_xlat16_20 = _DissolveSmooth * 2.0 + 1.0;
    u_xlat16_20 = i.vs_TEXCOORD1.x * u_xlat16_20 + (-_DissolveSmooth);
    u_xlat16_28 = (-u_xlat16_4.x) + u_xlat16_20;
    u_xlat16_28 = u_xlat16_12 * u_xlat16_28;
    u_xlat16_28 = clamp(u_xlat16_28, 0.0, 1.0);
    u_xlat16_7 = u_xlat16_28 * -2.0 + 3.0;
    u_xlat16_28 = u_xlat16_28 * u_xlat16_28;
    u_xlat16_28 = u_xlat16_28 * u_xlat16_7;
    u_xlat16_28 = u_xlat16_2.w * u_xlat16_28;
    u_xlatb0 = 0.0<_DoubleDissolve;
    u_xlat16_7 = (u_xlatb0) ? i.vs_TEXCOORD1.y : 0.0;
    u_xlat16_20 = u_xlat16_20 + (-u_xlat16_7);
    u_xlatb0 = 0.0<u_xlat16_7;
    u_xlat16_4.x = (-u_xlat16_4.x) + u_xlat16_20;
    u_xlat16_4.x = u_xlat16_12 * u_xlat16_4.x;
    u_xlat16_4.x = clamp(u_xlat16_4.x, 0.0, 1.0);
    u_xlat16_12 = u_xlat16_4.x * -2.0 + 3.0;
    u_xlat16_4.x = u_xlat16_4.x * u_xlat16_4.x;
    u_xlat16_4.x = (-u_xlat16_12) * u_xlat16_4.x + u_xlat16_28;
    u_xlat16_4.x = clamp(u_xlat16_4.x, 0.0, 1.0);
    u_xlat16_4.x = (u_xlatb0) ? u_xlat16_4.x : u_xlat16_28;
    result.w = min(u_xlat16_4.x, 1.0);
    return result;

}

#elif !defined(SOFTPARTICLES_ON) && defined(_ALPHABLEND_ON) && !defined(_ALPHAMODULATE_ON) && !defined(_ALPHAPREMULTIPLY_ON) && defined(_ALPHATEST_ON) && !defined(_CFXR_ADDITIVE) && !defined(_CFXR_DISSOLVE) && !defined(_CFXR_EDGE_FADING) && !defined(_CFXR_FONT_COLORS) && defined(_CFXR_LIGHTING_ALL) && !defined(_CFXR_LIGHTING_BACK) && !defined(_CFXR_LIGHTING_WPOS_OFFSET) && !defined(_CFXR_OVERLAYTEX_1X) && !defined(_CFXR_SECONDCOLOR_LERP) && !defined(_CFXR_UV_DISTORTION) && defined(_EMISSION) && !defined(_FADING_ON) && !defined(_FLIPBOOK_BLENDING) && defined(_NORMALMAP)
// Original GLES program 54; _CFXR_LIGHTING_ALL,_NORMALMAP,_EMISSION,_ALPHATEST_ON,_ALPHABLEND_ON
float _SingleChannel;
float _BumpScale;
float _IndirectLightingMix;
float4 _ShadowColor;
float _DirectLightingRamp;
float _HdrMultiply;
float _Cutoff;
sampler2D _MainTex;
sampler2D _BumpMap;
struct A{float4 in_POSITION0:POSITION0;float4 in_COLOR0:COLOR0;float4 in_TEXCOORD0:TEXCOORD0;float4 in_TEXCOORD1:TEXCOORD1;float4 in_TEXCOORD2:TEXCOORD2;float3 in_NORMAL0:NORMAL0;float4 in_TANGENT0:TANGENT0;};
struct V{float4 vertex:SV_POSITION;float4 vs_COLOR0:TEXCOORD0;float4 vs_TEXCOORD0:TEXCOORD1;float4 vs_TEXCOORD2:TEXCOORD2;float3 vs_TEXCOORD4:TEXCOORD3;float3 vs_NORMAL0:TEXCOORD4;float4 vs_TANGENT0:TEXCOORD5;};
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
    o.vs_TEXCOORD2 = i.in_TEXCOORD2;
    o.vs_TEXCOORD4.xyz = i.in_POSITION0.xyz;
    o.vs_NORMAL0.xyz = i.in_NORMAL0.xyz;
    o.vs_TANGENT0 = i.in_TANGENT0;
    return o;

}
float4 frag(V i):SV_Target{float4 result=0;
float4 u_xlat0;
float4 u_xlat16_0;
float4 u_xlat1;
float4 u_xlat16_1;
bool u_xlatb1;
float4 u_xlat16_2;
float4 u_xlat3;
float4 u_xlat16_3;
float4 u_xlat4;
float3 u_xlat16_4;
float4 u_xlat5;
float3 u_xlat16_5;
float u_xlat16_6;
float3 u_xlat7;
float3 u_xlat8;
float u_xlat16_15;
float u_xlat16_29;
float u_xlat31;
bool u_xlatb31;

    u_xlat16_0 = tex2D(_MainTex, i.vs_TEXCOORD0.xy);
    u_xlatb1 = 0.0<_SingleChannel;
    u_xlat16_2.w = (u_xlatb1) ? u_xlat16_0.x : u_xlat16_0.w;
    u_xlat16_2.xyz = (bool(u_xlatb1)) ? float3(1.0, 1.0, 1.0) : u_xlat16_0.xyz;
    u_xlat16_0 = u_xlat16_2 * i.vs_COLOR0;
    u_xlat16_2.x = u_xlat16_2.w * i.vs_COLOR0.w + (-_Cutoff);
    u_xlatb1 = u_xlat16_2.x<0.0;
    if(u_xlatb1){discard;}
    u_xlat1.x = i.vs_TANGENT0.y;
    u_xlat1.z = i.vs_NORMAL0.y;
    u_xlat3.xyz = i.vs_NORMAL0.zxy * i.vs_TANGENT0.yzx;
    u_xlat3.xyz = i.vs_NORMAL0.yzx * i.vs_TANGENT0.zxy + (-u_xlat3.xyz);
    u_xlat3.xyz = u_xlat3.xzy * i.vs_TANGENT0.www;
    u_xlat1.y = u_xlat3.z;
    u_xlat16_4.xyz = tex2D(_BumpMap, i.vs_TEXCOORD0.xy).xyz;
    u_xlat16_2.xyz = u_xlat16_4.xyz * float3(2.0, 2.0, 2.0) + float3(-1.0, -1.0, -1.0);
    u_xlat16_2.xy = u_xlat16_2.xy * ((float2)(float2(_BumpScale, _BumpScale)));
    u_xlat16_1.y = dot(u_xlat16_2.xyz, u_xlat1.xyz);
    u_xlat16_29 = u_xlat16_1.y * u_xlat16_1.y;
    u_xlat4.y = u_xlat3.x;
    u_xlat4.x = i.vs_TANGENT0.x;
    u_xlat4.z = i.vs_NORMAL0.x;
    u_xlat16_1.x = dot(u_xlat16_2.xyz, u_xlat4.xyz);
    u_xlat16_29 = u_xlat16_1.x * u_xlat16_1.x + (-u_xlat16_29);
    u_xlat3.x = i.vs_TANGENT0.z;
    u_xlat3.z = i.vs_NORMAL0.z;
    u_xlat16_1.z = dot(u_xlat16_2.xyz, u_xlat3.xyz);
    u_xlat16_3 = u_xlat16_1.yzzx * u_xlat16_1.xyzz;
    u_xlat16_2.x = dot(unity_SHBr, u_xlat16_3);
    u_xlat16_2.y = dot(unity_SHBg, u_xlat16_3);
    u_xlat16_2.z = dot(unity_SHBb, u_xlat16_3);
    u_xlat16_2.xyz = unity_SHC.xyz * ((float3)(u_xlat16_29)) + u_xlat16_2.xyz;
    u_xlat16_1.w = 1.0;
    u_xlat16_5.x = dot(unity_SHAr, u_xlat16_1);
    u_xlat16_5.y = dot(unity_SHAg, u_xlat16_1);
    u_xlat16_5.z = dot(unity_SHAb, u_xlat16_1);
    u_xlat16_2.xyz = u_xlat16_2.xyz + u_xlat16_5.xyz;
    u_xlat16_2.xyz = max(u_xlat16_2.xyz, float3(0.0, 0.0, 0.0));
    u_xlat4.xyz = log2(u_xlat16_2.xyz);
    u_xlat4.xyz = u_xlat4.xyz * float3(0.416666657, 0.416666657, 0.416666657);
    u_xlat4.xyz = exp2(u_xlat4.xyz);
    u_xlat4.xyz = u_xlat4.xyz * float3(1.05499995, 1.05499995, 1.05499995) + float3(-0.0549999997, -0.0549999997, -0.0549999997);
    u_xlat31 = log2(_HdrMultiply);
    u_xlat31 = u_xlat31 * 0.416666657;
    u_xlat31 = exp2(u_xlat31);
    u_xlat4.w = u_xlat31 * 1.05499995 + -0.0549999997;
    u_xlat4 = max(u_xlat4, float4(0.0, 0.0, 0.0, 0.0));
    u_xlat16_2.xyz = u_xlat16_0.xyz * u_xlat4.www;
    u_xlatb31 = 0.0<_HdrMultiply;
    u_xlat16_2.xyz = (bool(u_xlatb31)) ? u_xlat16_2.xyz : u_xlat16_0.xyz;
    result.w = min(u_xlat16_0.w, 1.0);
    u_xlat0 = (-i.vs_TEXCOORD4.yyyy) + unity_4LightPosY0;
    u_xlat3 = u_xlat16_1.yyyy * u_xlat0;
    u_xlat31 = dot(u_xlat16_1.xyz, _WorldSpaceLightPos0.xyz);
    u_xlat16_29 = u_xlat31 * 0.5 + 0.5;
    u_xlat0 = u_xlat0 * u_xlat0;
    u_xlat5 = (-i.vs_TEXCOORD4.xxxx) + unity_4LightPosX0;
    u_xlat3 = u_xlat5 * u_xlat16_1.xxxx + u_xlat3;
    u_xlat0 = u_xlat5 * u_xlat5 + u_xlat0;
    u_xlat5 = (-i.vs_TEXCOORD4.zzzz) + unity_4LightPosZ0;
    u_xlat1 = u_xlat5 * u_xlat16_1.zzzz + u_xlat3;
    u_xlat0 = u_xlat5 * u_xlat5 + u_xlat0;
    u_xlat0 = max(u_xlat0, float4(9.99999997e-07, 9.99999997e-07, 9.99999997e-07, 9.99999997e-07));
    u_xlat1 = u_xlat1 * float4(0.5, 0.5, 0.5, 0.5) + float4(0.5, 0.5, 0.5, 0.5);
    u_xlat16_6 = (-_DirectLightingRamp) * 0.5 + 0.5;
    u_xlat1 = u_xlat1 + (-((float4)(u_xlat16_6)));
    u_xlat16_15 = _DirectLightingRamp * 0.5 + 0.5;
    u_xlat31 = (-u_xlat16_6) + u_xlat16_15;
    u_xlat16_15 = (-u_xlat16_6) + u_xlat16_15;
    u_xlat16_29 = u_xlat16_29 + (-u_xlat16_6);
    u_xlat16_6 = float(1.0) / u_xlat16_15;
    u_xlat16_29 = u_xlat16_29 * u_xlat16_6;
    u_xlat16_29 = clamp(u_xlat16_29, 0.0, 1.0);
    u_xlat31 = float(1.0) / u_xlat31;
    u_xlat1 = u_xlat1 * ((float4)(u_xlat31));
    u_xlat1 = clamp(u_xlat1, 0.0, 1.0);
    u_xlat3 = u_xlat1 * float4(-2.0, -2.0, -2.0, -2.0) + float4(3.0, 3.0, 3.0, 3.0);
    u_xlat1 = u_xlat1 * u_xlat1;
    u_xlat1 = u_xlat1 * u_xlat3;
    u_xlat3 = rsqrt(u_xlat0);
    u_xlat0 = u_xlat0 * unity_4LightAtten0 + float4(1.0, 1.0, 1.0, 1.0);
    u_xlat0 = float4(1.0, 1.0, 1.0, 1.0) / u_xlat0;
    u_xlat1 = u_xlat1 * u_xlat3;
    u_xlat0 = u_xlat0 * u_xlat1;
    u_xlat7.xyz = u_xlat0.yyy * unity_LightColor[1].xyz;
    u_xlat7.xyz = unity_LightColor[0].xyz * u_xlat0.xxx + u_xlat7.xyz;
    u_xlat7.xyz = unity_LightColor[2].xyz * u_xlat0.zzz + u_xlat7.xyz;
    u_xlat7.xyz = unity_LightColor[3].xyz * u_xlat0.www + u_xlat7.xyz;
    u_xlat16_6 = u_xlat16_29 * -2.0 + 3.0;
    u_xlat16_29 = u_xlat16_29 * u_xlat16_29;
    u_xlat16_29 = u_xlat16_29 * u_xlat16_6;
    u_xlat8.xyz = _LightColor0.xyz + (-_ShadowColor.xyz);
    u_xlat8.xyz = ((float3)(u_xlat16_29)) * u_xlat8.xyz + _ShadowColor.xyz;
    u_xlat16_2.xyz = u_xlat16_2.xyz * u_xlat8.xyz + u_xlat7.xyz;
    u_xlat16_2.xyz = u_xlat4.xyz * ((float3)(float3(_IndirectLightingMix, _IndirectLightingMix, _IndirectLightingMix))) + u_xlat16_2.xyz;
    u_xlat4.xyz = u_xlat16_2.xyz + i.vs_TEXCOORD2.xyz;
    result.xyz = u_xlat4.xyz;
    return result;

}

#elif !defined(SOFTPARTICLES_ON) && defined(_ALPHABLEND_ON) && !defined(_ALPHAMODULATE_ON) && !defined(_ALPHAPREMULTIPLY_ON) && defined(_ALPHATEST_ON) && !defined(_CFXR_ADDITIVE) && !defined(_CFXR_DISSOLVE) && defined(_CFXR_EDGE_FADING) && !defined(_CFXR_FONT_COLORS) && !defined(_CFXR_LIGHTING_ALL) && !defined(_CFXR_LIGHTING_BACK) && !defined(_CFXR_LIGHTING_WPOS_OFFSET) && !defined(_CFXR_OVERLAYTEX_1X) && !defined(_CFXR_SECONDCOLOR_LERP) && defined(_CFXR_UV_DISTORTION) && !defined(_EMISSION) && defined(_FADING_ON) && !defined(_FLIPBOOK_BLENDING) && !defined(_NORMALMAP)
// Original GLES program 59; _CFXR_EDGE_FADING,_FADING_ON,_CFXR_UV_DISTORTION,_ALPHATEST_ON,_ALPHABLEND_ON
float _EdgeFadePow;
float _SingleChannel;
float _UseUV2Distortion;
float _UVDistortionAdd;
float4 _DistortScrolling;
float _Distort;
float _FadeAlongU;
float _HdrMultiply;
float _Cutoff;
sampler2D _DistortTex;
sampler2D _MainTex;
struct A{float4 in_POSITION0:POSITION0;float4 in_COLOR0:COLOR0;float4 in_TEXCOORD0:TEXCOORD0;float4 in_TEXCOORD1:TEXCOORD1;float3 in_NORMAL0:NORMAL0;};
struct V{float4 vertex:SV_POSITION;float4 vs_COLOR0:TEXCOORD0;float4 vs_TEXCOORD0:TEXCOORD1;float4 vs_TEXCOORD1:TEXCOORD2;};
V vert(A i){V o=(V)0;
float4 u_xlat0;
float4 u_xlat1;
float u_xlat6;

    u_xlat0 = i.in_POSITION0.yyyy * transpose(unity_ObjectToWorld)[1];
    u_xlat0 = transpose(unity_ObjectToWorld)[0] * i.in_POSITION0.xxxx + u_xlat0;
    u_xlat0 = transpose(unity_ObjectToWorld)[2] * i.in_POSITION0.zzzz + u_xlat0;
    u_xlat0 = u_xlat0 + transpose(unity_ObjectToWorld)[3];
    u_xlat1 = u_xlat0.yyyy * transpose(unity_MatrixVP)[1];
    u_xlat1 = transpose(unity_MatrixVP)[0] * u_xlat0.xxxx + u_xlat1;
    u_xlat1 = transpose(unity_MatrixVP)[2] * u_xlat0.zzzz + u_xlat1;
    o.vertex = transpose(unity_MatrixVP)[3] * u_xlat0.wwww + u_xlat1;
    u_xlat0.xyz = (-i.in_POSITION0.xyz) + _WorldSpaceCameraPos.xyz;
    u_xlat6 = dot(u_xlat0.xyz, u_xlat0.xyz);
    u_xlat6 = rsqrt(u_xlat6);
    u_xlat0.xyz = ((float3)(u_xlat6)) * u_xlat0.xyz;
    u_xlat0.x = dot(u_xlat0.xyz, i.in_NORMAL0.xyz);
    u_xlat0.x = log2(abs(u_xlat0.x));
    u_xlat0.x = u_xlat0.x * _EdgeFadePow;
    u_xlat0.x = exp2(u_xlat0.x);
    u_xlat0.x = min(u_xlat0.x, 1.0);
    u_xlat0.x = u_xlat0.x * i.in_COLOR0.w;
    o.vs_COLOR0.w = u_xlat0.x;
    o.vs_COLOR0.xyz = i.in_COLOR0.xyz;
    o.vs_TEXCOORD0 = i.in_TEXCOORD0.xyxy;
    o.vs_TEXCOORD1 = i.in_TEXCOORD1;
    return o;

}
float4 frag(V i):SV_Target{float4 result=0;
float2 u_xlat0;
float4 u_xlat16_0;
float u_xlat1;
bool3 u_xlatb1;
float4 u_xlat16_2;
float2 u_xlat6;

    u_xlat0.xy = _Time.yy * _DistortScrolling.xy;
    u_xlat0.xy = frac(u_xlat0.xy);
    u_xlatb1.xyz = lessThan(float4(0.0, 0.0, 0.0, 0.0), float4(_UseUV2Distortion, _UVDistortionAdd, _SingleChannel, _UseUV2Distortion)).xyz;
    u_xlat6.xy = (u_xlatb1.x) ? i.vs_TEXCOORD1.xy : i.vs_TEXCOORD0.xy;
    u_xlat6.xy = u_xlat6.xy * _DistortScrolling.zw + i.vs_TEXCOORD0.zw;
    u_xlat0.xy = u_xlat0.xy + u_xlat6.xy;
    u_xlat16_0.xy = tex2D(_DistortTex, u_xlat0.xy).xy;
    u_xlat6.xy = u_xlat16_0.xy * float2(2.0, 2.0) + float2(-1.0, -1.0);
    u_xlat0.xy = u_xlat16_0.xy + (-i.vs_TEXCOORD0.xy);
    u_xlat0.xy = ((float2)(_Distort)) * u_xlat0.xy + i.vs_TEXCOORD0.xy;
    u_xlat6.xy = u_xlat6.xy * ((float2)(_Distort)) + i.vs_TEXCOORD0.xy;
    u_xlat0.xy = (u_xlatb1.y) ? u_xlat6.xy : u_xlat0.xy;
    u_xlat6.xy = u_xlat0.xy + (-i.vs_TEXCOORD0.xy);
    u_xlat1 = i.vs_TEXCOORD0.y * 0.5;
    u_xlat6.xy = ((float2)(u_xlat1)) * u_xlat6.xy + i.vs_TEXCOORD0.xy;
    u_xlatb1.xy = lessThan(float4(0.0, 0.0, 0.0, 0.0), float4(_FadeAlongU, _HdrMultiply, _FadeAlongU, _FadeAlongU)).xy;
    u_xlat0.xy = (u_xlatb1.x) ? u_xlat6.xy : u_xlat0.xy;
    u_xlat16_0 = tex2D(_MainTex, u_xlat0.xy);
    u_xlat16_2.w = (u_xlatb1.z) ? u_xlat16_0.x : u_xlat16_0.w;
    u_xlat16_2.xyz = (u_xlatb1.z) ? float3(1.0, 1.0, 1.0) : u_xlat16_0.xyz;
    u_xlat16_0 = u_xlat16_2 * i.vs_COLOR0;
    u_xlat16_2.x = u_xlat16_2.w * i.vs_COLOR0.w + (-_Cutoff);
    u_xlatb1.x = u_xlat16_2.x<0.0;
    if(u_xlatb1.x){discard;}
    u_xlat1 = log2(_HdrMultiply);
    u_xlat1 = u_xlat1 * 0.416666657;
    u_xlat1 = exp2(u_xlat1);
    u_xlat1 = u_xlat1 * 1.05499995 + -0.0549999997;
    u_xlat1 = max(u_xlat1, 0.0);
    u_xlat16_2.xyz = u_xlat16_0.xyz * ((float3)(u_xlat1));
    result.xyz = (u_xlatb1.y) ? u_xlat16_2.xyz : u_xlat16_0.xyz;
    result.w = min(u_xlat16_0.w, 1.0);
    return result;

}

#elif !defined(SOFTPARTICLES_ON) && !defined(_ALPHABLEND_ON) && !defined(_ALPHAMODULATE_ON) && !defined(_ALPHAPREMULTIPLY_ON) && defined(_ALPHATEST_ON) && defined(_CFXR_ADDITIVE) && !defined(_CFXR_DISSOLVE) && defined(_CFXR_EDGE_FADING) && !defined(_CFXR_FONT_COLORS) && !defined(_CFXR_LIGHTING_ALL) && !defined(_CFXR_LIGHTING_BACK) && !defined(_CFXR_LIGHTING_WPOS_OFFSET) && !defined(_CFXR_OVERLAYTEX_1X) && !defined(_CFXR_SECONDCOLOR_LERP) && defined(_CFXR_UV_DISTORTION) && !defined(_EMISSION) && defined(_FADING_ON) && !defined(_FLIPBOOK_BLENDING) && !defined(_NORMALMAP)
// Original GLES program 69; _CFXR_EDGE_FADING,_FADING_ON,_CFXR_UV_DISTORTION,_ALPHATEST_ON,_CFXR_ADDITIVE
float _EdgeFadePow;
float _SingleChannel;
float _UseUV2Distortion;
float _UVDistortionAdd;
float4 _DistortScrolling;
float _Distort;
float _FadeAlongU;
float _HdrMultiply;
float _Cutoff;
sampler2D _DistortTex;
sampler2D _MainTex;
struct A{float4 in_POSITION0:POSITION0;float4 in_COLOR0:COLOR0;float4 in_TEXCOORD0:TEXCOORD0;float4 in_TEXCOORD1:TEXCOORD1;float3 in_NORMAL0:NORMAL0;};
struct V{float4 vertex:SV_POSITION;float4 vs_COLOR0:TEXCOORD0;float4 vs_TEXCOORD0:TEXCOORD1;float4 vs_TEXCOORD1:TEXCOORD2;};
V vert(A i){V o=(V)0;
float4 u_xlat0;
float4 u_xlat1;
float u_xlat6;

    u_xlat0 = i.in_POSITION0.yyyy * transpose(unity_ObjectToWorld)[1];
    u_xlat0 = transpose(unity_ObjectToWorld)[0] * i.in_POSITION0.xxxx + u_xlat0;
    u_xlat0 = transpose(unity_ObjectToWorld)[2] * i.in_POSITION0.zzzz + u_xlat0;
    u_xlat0 = u_xlat0 + transpose(unity_ObjectToWorld)[3];
    u_xlat1 = u_xlat0.yyyy * transpose(unity_MatrixVP)[1];
    u_xlat1 = transpose(unity_MatrixVP)[0] * u_xlat0.xxxx + u_xlat1;
    u_xlat1 = transpose(unity_MatrixVP)[2] * u_xlat0.zzzz + u_xlat1;
    o.vertex = transpose(unity_MatrixVP)[3] * u_xlat0.wwww + u_xlat1;
    u_xlat0.xyz = (-i.in_POSITION0.xyz) + _WorldSpaceCameraPos.xyz;
    u_xlat6 = dot(u_xlat0.xyz, u_xlat0.xyz);
    u_xlat6 = rsqrt(u_xlat6);
    u_xlat0.xyz = ((float3)(u_xlat6)) * u_xlat0.xyz;
    u_xlat0.x = dot(u_xlat0.xyz, i.in_NORMAL0.xyz);
    u_xlat0.x = log2(abs(u_xlat0.x));
    u_xlat0.x = u_xlat0.x * _EdgeFadePow;
    u_xlat0.x = exp2(u_xlat0.x);
    u_xlat0.x = min(u_xlat0.x, 1.0);
    u_xlat0.x = u_xlat0.x * i.in_COLOR0.w;
    o.vs_COLOR0.w = u_xlat0.x;
    o.vs_COLOR0.xyz = i.in_COLOR0.xyz;
    o.vs_TEXCOORD0 = i.in_TEXCOORD0.xyxy;
    o.vs_TEXCOORD1 = i.in_TEXCOORD1;
    return o;

}
float4 frag(V i):SV_Target{float4 result=0;
float2 u_xlat0;
float4 u_xlat16_0;
float u_xlat1;
bool3 u_xlatb1;
float4 u_xlat16_2;
float2 u_xlat6;

    u_xlat0.xy = _Time.yy * _DistortScrolling.xy;
    u_xlat0.xy = frac(u_xlat0.xy);
    u_xlatb1.xyz = lessThan(float4(0.0, 0.0, 0.0, 0.0), float4(_UseUV2Distortion, _UVDistortionAdd, _SingleChannel, _UseUV2Distortion)).xyz;
    u_xlat6.xy = (u_xlatb1.x) ? i.vs_TEXCOORD1.xy : i.vs_TEXCOORD0.xy;
    u_xlat6.xy = u_xlat6.xy * _DistortScrolling.zw + i.vs_TEXCOORD0.zw;
    u_xlat0.xy = u_xlat0.xy + u_xlat6.xy;
    u_xlat16_0.xy = tex2D(_DistortTex, u_xlat0.xy).xy;
    u_xlat6.xy = u_xlat16_0.xy * float2(2.0, 2.0) + float2(-1.0, -1.0);
    u_xlat0.xy = u_xlat16_0.xy + (-i.vs_TEXCOORD0.xy);
    u_xlat0.xy = ((float2)(_Distort)) * u_xlat0.xy + i.vs_TEXCOORD0.xy;
    u_xlat6.xy = u_xlat6.xy * ((float2)(_Distort)) + i.vs_TEXCOORD0.xy;
    u_xlat0.xy = (u_xlatb1.y) ? u_xlat6.xy : u_xlat0.xy;
    u_xlat6.xy = u_xlat0.xy + (-i.vs_TEXCOORD0.xy);
    u_xlat1 = i.vs_TEXCOORD0.y * 0.5;
    u_xlat6.xy = ((float2)(u_xlat1)) * u_xlat6.xy + i.vs_TEXCOORD0.xy;
    u_xlatb1.xy = lessThan(float4(0.0, 0.0, 0.0, 0.0), float4(_FadeAlongU, _HdrMultiply, _FadeAlongU, _FadeAlongU)).xy;
    u_xlat0.xy = (u_xlatb1.x) ? u_xlat6.xy : u_xlat0.xy;
    u_xlat16_0 = tex2D(_MainTex, u_xlat0.xy);
    u_xlat16_2.w = (u_xlatb1.z) ? u_xlat16_0.x : u_xlat16_0.w;
    u_xlat16_2.xyz = (u_xlatb1.z) ? float3(1.0, 1.0, 1.0) : u_xlat16_0.xyz;
    u_xlat16_0 = u_xlat16_2 * i.vs_COLOR0;
    u_xlat16_2.x = u_xlat16_2.w * i.vs_COLOR0.w + (-_Cutoff);
    u_xlatb1.x = u_xlat16_2.x<0.0;
    if(u_xlatb1.x){discard;}
    u_xlat1 = log2(_HdrMultiply);
    u_xlat1 = u_xlat1 * 0.416666657;
    u_xlat1 = exp2(u_xlat1);
    u_xlat1 = u_xlat1 * 1.05499995 + -0.0549999997;
    u_xlat1 = max(u_xlat1, 0.0);
    u_xlat16_2.xyz = u_xlat16_0.xyz * ((float3)(u_xlat1));
    result.xyz = (u_xlatb1.y) ? u_xlat16_2.xyz : u_xlat16_0.xyz;
    result.w = min(u_xlat16_0.w, 1.0);
    return result;

}

#elif defined(SOFTPARTICLES_ON) && defined(_ALPHABLEND_ON) && !defined(_ALPHAMODULATE_ON) && !defined(_ALPHAPREMULTIPLY_ON) && !defined(_ALPHATEST_ON) && !defined(_CFXR_ADDITIVE) && defined(_CFXR_DISSOLVE) && !defined(_CFXR_EDGE_FADING) && !defined(_CFXR_FONT_COLORS) && !defined(_CFXR_LIGHTING_ALL) && !defined(_CFXR_LIGHTING_BACK) && !defined(_CFXR_LIGHTING_WPOS_OFFSET) && !defined(_CFXR_OVERLAYTEX_1X) && defined(_CFXR_SECONDCOLOR_LERP) && !defined(_CFXR_UV_DISTORTION) && !defined(_EMISSION) && defined(_FADING_ON) && !defined(_FLIPBOOK_BLENDING) && !defined(_NORMALMAP)
// Original GLES program 76; SOFTPARTICLES_ON,_CFXR_DISSOLVE,_CFXR_SECONDCOLOR_LERP,_FADING_ON,_ALPHABLEND_ON
float _SingleChannel;
float _UseDissolveOffsetUV;
float _InvertDissolveTex;
float _DoubleDissolve;
float2 _DissolveScroll;
float _DissolveSmooth;
float _SecondColorSmooth;
float _HdrMultiply;
float _SoftParticlesFadeDistanceNear;
float _SoftParticlesFadeDistanceFar;
float4 _DissolveTex_ST;
sampler2D _MainTex;
sampler2D _SecondColorTex;
sampler2D _DissolveTex;
sampler2D _CameraDepthTexture;
struct A{float4 in_POSITION0:POSITION0;float4 in_COLOR0:COLOR0;float4 in_TEXCOORD0:TEXCOORD0;float4 in_TEXCOORD1:TEXCOORD1;float4 in_TEXCOORD2:TEXCOORD2;};
struct V{float4 vertex:SV_POSITION;float4 vs_COLOR0:TEXCOORD0;float4 vs_TEXCOORD0:TEXCOORD1;float4 vs_TEXCOORD1:TEXCOORD2;float4 vs_TEXCOORD2:TEXCOORD3;float4 vs_TEXCOORD3:TEXCOORD4;};
V vert(A i){V o=(V)0;
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
    o.vs_TEXCOORD1 = i.in_TEXCOORD1;
    o.vs_TEXCOORD2 = i.in_TEXCOORD2;
    u_xlat2 = u_xlat0.y * transpose(unity_MatrixV)[1].z;
    u_xlat0.x = transpose(unity_MatrixV)[0].z * u_xlat0.x + u_xlat2;
    u_xlat0.x = transpose(unity_MatrixV)[2].z * u_xlat0.z + u_xlat0.x;
    u_xlat0.x = transpose(unity_MatrixV)[3].z * u_xlat0.w + u_xlat0.x;
    o.vs_TEXCOORD3.z = (-u_xlat0.x);
    u_xlat0.x = u_xlat1.y * _ProjectionParams.x;
    u_xlat0.w = u_xlat0.x * 0.5;
    u_xlat0.xz = u_xlat1.xw * float2(0.5, 0.5);
    o.vs_TEXCOORD3.w = u_xlat1.w;
    o.vs_TEXCOORD3.xy = u_xlat0.zz + u_xlat0.xw;
    return o;

}
float4 frag(V i):SV_Target{float4 result=0;
float2 u_xlat0;
float4 u_xlat16_0;
bool u_xlatb0;
float3 u_xlat16_1;
float4 u_xlat16_2;
float4 u_xlat16_3;
float3 u_xlat4;
float u_xlat16_4;
bool u_xlatb4;
float u_xlat5;
float u_xlat16_6;
float u_xlat9;
float2 u_xlat10;
bool2 u_xlatb10;
float u_xlat16_11;
bool u_xlatb14;
float u_xlat16_16;
float u_xlat19;
bool u_xlatb19;

    u_xlat0.xy = _Time.yy * float2(_DissolveScroll.x, _DissolveScroll.y);
    u_xlat0.xy = frac(u_xlat0.xy);
    u_xlat10.xy = i.vs_TEXCOORD0.xy * _DissolveTex_ST.xy + _DissolveTex_ST.zw;
    u_xlat0.xy = u_xlat0.xy + u_xlat10.xy;
    u_xlatb10.xy = lessThan(float4(0.0, 0.0, 0.0, 0.0), float4(_SingleChannel, _UseDissolveOffsetUV, _SingleChannel, _UseDissolveOffsetUV)).xy;
    u_xlat0.xy = (u_xlatb10.y) ? u_xlat0.xy : i.vs_TEXCOORD0.xy;
    u_xlat16_0.x = tex2D(_DissolveTex, u_xlat0.xy).x;
    u_xlat16_1.x = u_xlat16_0.x * 2.0 + -1.0;
    u_xlat5 = u_xlat16_1.x * i.vs_TEXCOORD1.z + i.vs_TEXCOORD0.x;
    u_xlat16_1.x = (u_xlatb10.y) ? u_xlat5 : u_xlat16_0.x;
    u_xlat16_6 = (-u_xlat16_1.x) + 1.0;
    u_xlatb0 = 0.0>=_InvertDissolveTex;
    u_xlat16_1.x = (u_xlatb0) ? u_xlat16_6 : u_xlat16_1.x;
    u_xlat16_6 = u_xlat16_1.x + _DissolveSmooth;
    u_xlat16_1.x = u_xlat16_1.x + (-_DissolveSmooth);
    u_xlat16_6 = (-u_xlat16_1.x) + u_xlat16_6;
    u_xlat16_6 = float(1.0) / u_xlat16_6;
    u_xlat16_11 = _DissolveSmooth * 2.0 + 1.0;
    u_xlat16_11 = i.vs_TEXCOORD1.x * u_xlat16_11 + (-_DissolveSmooth);
    u_xlat16_16 = (-u_xlat16_1.x) + u_xlat16_11;
    u_xlat16_16 = u_xlat16_6 * u_xlat16_16;
    u_xlat16_16 = clamp(u_xlat16_16, 0.0, 1.0);
    u_xlat16_2.x = u_xlat16_16 * -2.0 + 3.0;
    u_xlat16_16 = u_xlat16_16 * u_xlat16_16;
    u_xlat16_16 = u_xlat16_16 * u_xlat16_2.x;
    u_xlat16_2 = tex2D(_MainTex, i.vs_TEXCOORD0.xy);
    u_xlat16_3.xyz = (u_xlatb10.x) ? float3(1.0, 1.0, 1.0) : u_xlat16_2.xyz;
    u_xlat16_3.w = (u_xlatb10.x) ? u_xlat16_2.x : u_xlat16_2.w;
    u_xlat16_0 = u_xlat16_3 * i.vs_COLOR0;
    u_xlat16_16 = u_xlat16_16 * u_xlat16_0.w;
    u_xlatb4 = 0.0<_DoubleDissolve;
    u_xlat16_3.x = (u_xlatb4) ? i.vs_TEXCOORD1.y : 0.0;
    u_xlat16_11 = u_xlat16_11 + (-u_xlat16_3.x);
    u_xlatb4 = 0.0<u_xlat16_3.x;
    u_xlat16_1.x = (-u_xlat16_1.x) + u_xlat16_11;
    u_xlat16_1.x = u_xlat16_6 * u_xlat16_1.x;
    u_xlat16_1.x = clamp(u_xlat16_1.x, 0.0, 1.0);
    u_xlat16_6 = u_xlat16_1.x * -2.0 + 3.0;
    u_xlat16_1.x = u_xlat16_1.x * u_xlat16_1.x;
    u_xlat16_1.x = (-u_xlat16_6) * u_xlat16_1.x + u_xlat16_16;
    u_xlat16_1.x = clamp(u_xlat16_1.x, 0.0, 1.0);
    u_xlat16_1.x = (u_xlatb4) ? u_xlat16_1.x : u_xlat16_16;
    u_xlat4.xy = i.vs_TEXCOORD3.xy / i.vs_TEXCOORD3.ww;
    u_xlat4.x = tex2D(_CameraDepthTexture, u_xlat4.xy).x;
    u_xlat9 = _ZBufferParams.z * u_xlat4.x + _ZBufferParams.w;
    u_xlat4.x = u_xlat4.x * _ProjectionParams.z + _ProjectionParams.y;
    u_xlat9 = float(1.0) / u_xlat9;
    u_xlatb14 = unity_OrthoParams.w==1.0;
    u_xlat4.x = (u_xlatb14) ? u_xlat4.x : u_xlat9;
    u_xlat4.x = u_xlat4.x + (-_SoftParticlesFadeDistanceNear);
    u_xlat4.x = u_xlat4.x + (-i.vs_TEXCOORD3.z);
    u_xlat4.x = u_xlat4.x * _SoftParticlesFadeDistanceFar;
    u_xlat4.x = clamp(u_xlat4.x, 0.0, 1.0);
    u_xlat4.x = u_xlat16_1.x * u_xlat4.x;
    result.w = min(u_xlat4.x, 1.0);
    u_xlat16_4 = tex2D(_SecondColorTex, i.vs_TEXCOORD0.xy).x;
    u_xlat16_1.x = u_xlat16_4 + _SecondColorSmooth;
    u_xlat16_6 = u_xlat16_4 + (-_SecondColorSmooth);
    u_xlat4.x = (-u_xlat16_6) + u_xlat16_1.x;
    u_xlat4.x = float(1.0) / u_xlat4.x;
    u_xlat9 = _SecondColorSmooth * 2.0 + 1.0;
    u_xlat9 = i.vs_TEXCOORD2.w * u_xlat9 + (-_SecondColorSmooth);
    u_xlat9 = (-u_xlat16_6) + u_xlat9;
    u_xlat4.x = u_xlat4.x * u_xlat9;
    u_xlat4.x = clamp(u_xlat4.x, 0.0, 1.0);
    u_xlat9 = u_xlat4.x * -2.0 + 3.0;
    u_xlat4.x = u_xlat4.x * u_xlat4.x;
    u_xlat4.x = u_xlat4.x * u_xlat9;
    u_xlat4.xyz = i.vs_TEXCOORD2.xyz * u_xlat4.xxx + u_xlat16_0.xyz;
    u_xlat19 = log2(_HdrMultiply);
    u_xlat19 = u_xlat19 * 0.416666657;
    u_xlat19 = exp2(u_xlat19);
    u_xlat19 = u_xlat19 * 1.05499995 + -0.0549999997;
    u_xlat19 = max(u_xlat19, 0.0);
    u_xlat16_1.xyz = ((float3)(u_xlat19)) * u_xlat4.xyz;
    u_xlatb19 = 0.0<_HdrMultiply;
    result.xyz = (bool(u_xlatb19)) ? u_xlat16_1.xyz : u_xlat4.xyz;
    return result;

}

#elif defined(SOFTPARTICLES_ON) && defined(_ALPHABLEND_ON) && !defined(_ALPHAMODULATE_ON) && !defined(_ALPHAPREMULTIPLY_ON) && !defined(_ALPHATEST_ON) && !defined(_CFXR_ADDITIVE) && defined(_CFXR_DISSOLVE) && !defined(_CFXR_EDGE_FADING) && !defined(_CFXR_FONT_COLORS) && !defined(_CFXR_LIGHTING_ALL) && !defined(_CFXR_LIGHTING_BACK) && !defined(_CFXR_LIGHTING_WPOS_OFFSET) && !defined(_CFXR_OVERLAYTEX_1X) && !defined(_CFXR_SECONDCOLOR_LERP) && defined(_CFXR_UV_DISTORTION) && !defined(_EMISSION) && defined(_FADING_ON) && !defined(_FLIPBOOK_BLENDING) && !defined(_NORMALMAP)
// Original GLES program 82; SOFTPARTICLES_ON,_CFXR_DISSOLVE,_FADING_ON,_CFXR_UV_DISTORTION,_ALPHABLEND_ON
float _SingleChannel;
float _UseDissolveOffsetUV;
float _UseUV2Distortion;
float _UVDistortionAdd;
float _InvertDissolveTex;
float _DoubleDissolve;
float2 _DissolveScroll;
float _DissolveSmooth;
float4 _DistortScrolling;
float _Distort;
float _FadeAlongU;
float _HdrMultiply;
float _SoftParticlesFadeDistanceNear;
float _SoftParticlesFadeDistanceFar;
float4 _DissolveTex_ST;
sampler2D _DistortTex;
sampler2D _MainTex;
sampler2D _DissolveTex;
sampler2D _CameraDepthTexture;
struct A{float4 in_POSITION0:POSITION0;float4 in_COLOR0:COLOR0;float4 in_TEXCOORD0:TEXCOORD0;float4 in_TEXCOORD1:TEXCOORD1;};
struct V{float4 vertex:SV_POSITION;float4 vs_COLOR0:TEXCOORD0;float4 vs_TEXCOORD0:TEXCOORD1;float4 vs_TEXCOORD1:TEXCOORD2;float4 vs_TEXCOORD3:TEXCOORD3;};
V vert(A i){V o=(V)0;
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
    o.vs_TEXCOORD1 = i.in_TEXCOORD1;
    u_xlat2 = u_xlat0.y * transpose(unity_MatrixV)[1].z;
    u_xlat0.x = transpose(unity_MatrixV)[0].z * u_xlat0.x + u_xlat2;
    u_xlat0.x = transpose(unity_MatrixV)[2].z * u_xlat0.z + u_xlat0.x;
    u_xlat0.x = transpose(unity_MatrixV)[3].z * u_xlat0.w + u_xlat0.x;
    o.vs_TEXCOORD3.z = (-u_xlat0.x);
    u_xlat0.x = u_xlat1.y * _ProjectionParams.x;
    u_xlat0.w = u_xlat0.x * 0.5;
    u_xlat0.xz = u_xlat1.xw * float2(0.5, 0.5);
    o.vs_TEXCOORD3.w = u_xlat1.w;
    o.vs_TEXCOORD3.xy = u_xlat0.zz + u_xlat0.xw;
    return o;

}
float4 frag(V i):SV_Target{float4 result=0;
float2 u_xlat0;
float4 u_xlat16_0;
float3 u_xlat1;
float u_xlat16_1;
bool4 u_xlatb1;
float4 u_xlat16_2;
float2 u_xlat3;
float u_xlat16_4;
float u_xlat16_7;
float2 u_xlat10;
float u_xlat11;
float u_xlat16_12;
bool u_xlatb16;
float u_xlat16_17;

    u_xlat0.xy = _Time.yy * _DistortScrolling.xy;
    u_xlat0.xy = frac(u_xlat0.xy);
    u_xlatb1 = lessThan(float4(0.0, 0.0, 0.0, 0.0), float4(_UseUV2Distortion, _UVDistortionAdd, _SingleChannel, _UseDissolveOffsetUV));
    u_xlat10.xy = (u_xlatb1.x) ? i.vs_TEXCOORD1.xy : i.vs_TEXCOORD0.xy;
    u_xlat10.xy = u_xlat10.xy * _DistortScrolling.zw + i.vs_TEXCOORD0.zw;
    u_xlat0.xy = u_xlat0.xy + u_xlat10.xy;
    u_xlat16_0.xy = tex2D(_DistortTex, u_xlat0.xy).xy;
    u_xlat10.xy = u_xlat16_0.xy * float2(2.0, 2.0) + float2(-1.0, -1.0);
    u_xlat0.xy = u_xlat16_0.xy + (-i.vs_TEXCOORD0.xy);
    u_xlat0.xy = ((float2)(_Distort)) * u_xlat0.xy + i.vs_TEXCOORD0.xy;
    u_xlat10.xy = u_xlat10.xy * ((float2)(_Distort)) + i.vs_TEXCOORD0.xy;
    u_xlat0.xy = (u_xlatb1.y) ? u_xlat10.xy : u_xlat0.xy;
    u_xlat10.xy = u_xlat0.xy + (-i.vs_TEXCOORD0.xy);
    u_xlat1.x = i.vs_TEXCOORD0.y * 0.5;
    u_xlat10.xy = u_xlat1.xx * u_xlat10.xy + i.vs_TEXCOORD0.xy;
    u_xlatb1.xy = lessThan(float4(0.0, 0.0, 0.0, 0.0), float4(_FadeAlongU, _HdrMultiply, _FadeAlongU, _FadeAlongU)).xy;
    u_xlat0.xy = (u_xlatb1.x) ? u_xlat10.xy : u_xlat0.xy;
    u_xlat16_0 = tex2D(_MainTex, u_xlat0.xy);
    u_xlat16_2.xyz = (u_xlatb1.z) ? float3(1.0, 1.0, 1.0) : u_xlat16_0.xyz;
    u_xlat16_2.w = (u_xlatb1.z) ? u_xlat16_0.x : u_xlat16_0.w;
    u_xlat16_0 = u_xlat16_2 * i.vs_COLOR0;
    u_xlat1.xz = _Time.yy * float2(_DissolveScroll.x, _DissolveScroll.y);
    u_xlat1.xz = frac(u_xlat1.xz);
    u_xlat3.xy = i.vs_TEXCOORD0.xy * _DissolveTex_ST.xy + _DissolveTex_ST.zw;
    u_xlat1.xz = u_xlat1.xz + u_xlat3.xy;
    u_xlat1.xz = (u_xlatb1.w) ? u_xlat1.xz : i.vs_TEXCOORD0.xy;
    u_xlat16_1 = tex2D(_DissolveTex, u_xlat1.xz).x;
    u_xlat16_2.x = u_xlat16_1 * 2.0 + -1.0;
    u_xlat11 = u_xlat16_2.x * i.vs_TEXCOORD1.z + i.vs_TEXCOORD0.x;
    u_xlat16_2.x = (u_xlatb1.w) ? u_xlat11 : u_xlat16_1;
    u_xlat16_7 = (-u_xlat16_2.x) + 1.0;
    u_xlatb1.x = 0.0>=_InvertDissolveTex;
    u_xlat16_2.x = (u_xlatb1.x) ? u_xlat16_7 : u_xlat16_2.x;
    u_xlat16_7 = u_xlat16_2.x + _DissolveSmooth;
    u_xlat16_2.x = u_xlat16_2.x + (-_DissolveSmooth);
    u_xlat16_7 = (-u_xlat16_2.x) + u_xlat16_7;
    u_xlat16_7 = float(1.0) / u_xlat16_7;
    u_xlat16_12 = _DissolveSmooth * 2.0 + 1.0;
    u_xlat16_12 = i.vs_TEXCOORD1.x * u_xlat16_12 + (-_DissolveSmooth);
    u_xlat16_17 = (-u_xlat16_2.x) + u_xlat16_12;
    u_xlat16_17 = u_xlat16_7 * u_xlat16_17;
    u_xlat16_17 = clamp(u_xlat16_17, 0.0, 1.0);
    u_xlat16_4 = u_xlat16_17 * -2.0 + 3.0;
    u_xlat16_17 = u_xlat16_17 * u_xlat16_17;
    u_xlat16_17 = u_xlat16_17 * u_xlat16_4;
    u_xlat16_17 = u_xlat16_0.w * u_xlat16_17;
    u_xlatb1.x = 0.0<_DoubleDissolve;
    u_xlat16_4 = (u_xlatb1.x) ? i.vs_TEXCOORD1.y : 0.0;
    u_xlat16_12 = u_xlat16_12 + (-u_xlat16_4);
    u_xlatb1.x = 0.0<u_xlat16_4;
    u_xlat16_2.x = (-u_xlat16_2.x) + u_xlat16_12;
    u_xlat16_2.x = u_xlat16_7 * u_xlat16_2.x;
    u_xlat16_2.x = clamp(u_xlat16_2.x, 0.0, 1.0);
    u_xlat16_7 = u_xlat16_2.x * -2.0 + 3.0;
    u_xlat16_2.x = u_xlat16_2.x * u_xlat16_2.x;
    u_xlat16_2.x = (-u_xlat16_7) * u_xlat16_2.x + u_xlat16_17;
    u_xlat16_2.x = clamp(u_xlat16_2.x, 0.0, 1.0);
    u_xlat16_2.x = (u_xlatb1.x) ? u_xlat16_2.x : u_xlat16_17;
    u_xlat1.xz = i.vs_TEXCOORD3.xy / i.vs_TEXCOORD3.ww;
    u_xlat1.x = tex2D(_CameraDepthTexture, u_xlat1.xz).x;
    u_xlat11 = _ZBufferParams.z * u_xlat1.x + _ZBufferParams.w;
    u_xlat1.x = u_xlat1.x * _ProjectionParams.z + _ProjectionParams.y;
    u_xlat11 = float(1.0) / u_xlat11;
    u_xlatb16 = unity_OrthoParams.w==1.0;
    u_xlat1.x = (u_xlatb16) ? u_xlat1.x : u_xlat11;
    u_xlat1.x = u_xlat1.x + (-_SoftParticlesFadeDistanceNear);
    u_xlat1.x = u_xlat1.x + (-i.vs_TEXCOORD3.z);
    u_xlat1.x = u_xlat1.x * _SoftParticlesFadeDistanceFar;
    u_xlat1.x = clamp(u_xlat1.x, 0.0, 1.0);
    u_xlat1.x = u_xlat1.x * u_xlat16_2.x;
    result.w = min(u_xlat1.x, 1.0);
    u_xlat1.x = log2(_HdrMultiply);
    u_xlat1.x = u_xlat1.x * 0.416666657;
    u_xlat1.x = exp2(u_xlat1.x);
    u_xlat1.x = u_xlat1.x * 1.05499995 + -0.0549999997;
    u_xlat1.x = max(u_xlat1.x, 0.0);
    u_xlat16_2.xyz = u_xlat16_0.xyz * u_xlat1.xxx;
    result.xyz = (u_xlatb1.y) ? u_xlat16_2.xyz : u_xlat16_0.xyz;
    return result;

}

#elif defined(SOFTPARTICLES_ON) && defined(_ALPHABLEND_ON) && !defined(_ALPHAMODULATE_ON) && !defined(_ALPHAPREMULTIPLY_ON) && !defined(_ALPHATEST_ON) && !defined(_CFXR_ADDITIVE) && !defined(_CFXR_DISSOLVE) && defined(_CFXR_EDGE_FADING) && !defined(_CFXR_FONT_COLORS) && !defined(_CFXR_LIGHTING_ALL) && !defined(_CFXR_LIGHTING_BACK) && !defined(_CFXR_LIGHTING_WPOS_OFFSET) && !defined(_CFXR_OVERLAYTEX_1X) && !defined(_CFXR_SECONDCOLOR_LERP) && defined(_CFXR_UV_DISTORTION) && !defined(_EMISSION) && defined(_FADING_ON) && !defined(_FLIPBOOK_BLENDING) && !defined(_NORMALMAP)
// Original GLES program 83; SOFTPARTICLES_ON,_CFXR_EDGE_FADING,_FADING_ON,_CFXR_UV_DISTORTION,_ALPHABLEND_ON
float _EdgeFadePow;
float _SingleChannel;
float _UseUV2Distortion;
float _UVDistortionAdd;
float4 _DistortScrolling;
float _Distort;
float _FadeAlongU;
float _HdrMultiply;
float _SoftParticlesFadeDistanceNear;
float _SoftParticlesFadeDistanceFar;
sampler2D _DistortTex;
sampler2D _MainTex;
sampler2D _CameraDepthTexture;
struct A{float4 in_POSITION0:POSITION0;float4 in_COLOR0:COLOR0;float4 in_TEXCOORD0:TEXCOORD0;float4 in_TEXCOORD1:TEXCOORD1;float3 in_NORMAL0:NORMAL0;};
struct V{float4 vertex:SV_POSITION;float4 vs_COLOR0:TEXCOORD0;float4 vs_TEXCOORD0:TEXCOORD1;float4 vs_TEXCOORD1:TEXCOORD2;float4 vs_TEXCOORD3:TEXCOORD3;};
V vert(A i){V o=(V)0;
float4 u_xlat0;
float4 u_xlat1;
float3 u_xlat2;
float u_xlat3;
float u_xlat7;

    u_xlat0 = i.in_POSITION0.yyyy * transpose(unity_ObjectToWorld)[1];
    u_xlat0 = transpose(unity_ObjectToWorld)[0] * i.in_POSITION0.xxxx + u_xlat0;
    u_xlat0 = transpose(unity_ObjectToWorld)[2] * i.in_POSITION0.zzzz + u_xlat0;
    u_xlat0 = u_xlat0 + transpose(unity_ObjectToWorld)[3];
    u_xlat1 = u_xlat0.yyyy * transpose(unity_MatrixVP)[1];
    u_xlat1 = transpose(unity_MatrixVP)[0] * u_xlat0.xxxx + u_xlat1;
    u_xlat1 = transpose(unity_MatrixVP)[2] * u_xlat0.zzzz + u_xlat1;
    u_xlat1 = transpose(unity_MatrixVP)[3] * u_xlat0.wwww + u_xlat1;
    o.vertex = u_xlat1;
    u_xlat2.xyz = (-i.in_POSITION0.xyz) + _WorldSpaceCameraPos.xyz;
    u_xlat7 = dot(u_xlat2.xyz, u_xlat2.xyz);
    u_xlat7 = rsqrt(u_xlat7);
    u_xlat2.xyz = ((float3)(u_xlat7)) * u_xlat2.xyz;
    u_xlat7 = dot(u_xlat2.xyz, i.in_NORMAL0.xyz);
    u_xlat7 = log2(abs(u_xlat7));
    u_xlat7 = u_xlat7 * _EdgeFadePow;
    u_xlat7 = exp2(u_xlat7);
    u_xlat7 = min(u_xlat7, 1.0);
    u_xlat7 = u_xlat7 * i.in_COLOR0.w;
    o.vs_COLOR0.w = u_xlat7;
    o.vs_COLOR0.xyz = i.in_COLOR0.xyz;
    o.vs_TEXCOORD0 = i.in_TEXCOORD0.xyxy;
    o.vs_TEXCOORD1 = i.in_TEXCOORD1;
    u_xlat3 = u_xlat0.y * transpose(unity_MatrixV)[1].z;
    u_xlat0.x = transpose(unity_MatrixV)[0].z * u_xlat0.x + u_xlat3;
    u_xlat0.x = transpose(unity_MatrixV)[2].z * u_xlat0.z + u_xlat0.x;
    u_xlat0.x = transpose(unity_MatrixV)[3].z * u_xlat0.w + u_xlat0.x;
    o.vs_TEXCOORD3.z = (-u_xlat0.x);
    u_xlat0.x = u_xlat1.y * _ProjectionParams.x;
    u_xlat0.w = u_xlat0.x * 0.5;
    u_xlat0.xz = u_xlat1.xw * float2(0.5, 0.5);
    o.vs_TEXCOORD3.w = u_xlat1.w;
    o.vs_TEXCOORD3.xy = u_xlat0.zz + u_xlat0.xw;
    return o;

}
float4 frag(V i):SV_Target{float4 result=0;
float2 u_xlat0;
float4 u_xlat1;
float4 u_xlat16_1;
bool3 u_xlatb1;
bool2 u_xlatb2;
float4 u_xlat16_3;
float4 u_xlat16_4;
float2 u_xlat5;
float2 u_xlat16_5;
bool u_xlatb10;
float u_xlat15;

    u_xlat0.x = log2(_HdrMultiply);
    u_xlat0.x = u_xlat0.x * 0.416666657;
    u_xlat0.x = exp2(u_xlat0.x);
    u_xlat0.x = u_xlat0.x * 1.05499995 + -0.0549999997;
    u_xlat0.x = max(u_xlat0.x, 0.0);
    u_xlat5.xy = _Time.yy * _DistortScrolling.xy;
    u_xlat5.xy = frac(u_xlat5.xy);
    u_xlatb1.xyz = lessThan(float4(0.0, 0.0, 0.0, 0.0), float4(_UseUV2Distortion, _UVDistortionAdd, _SingleChannel, _UseUV2Distortion)).xyz;
    u_xlat1.xw = (u_xlatb1.x) ? i.vs_TEXCOORD1.xy : i.vs_TEXCOORD0.xy;
    u_xlat1.xw = u_xlat1.xw * _DistortScrolling.zw + i.vs_TEXCOORD0.zw;
    u_xlat5.xy = u_xlat5.xy + u_xlat1.xw;
    u_xlat16_5.xy = tex2D(_DistortTex, u_xlat5.xy).xy;
    u_xlat1.xw = u_xlat16_5.xy * float2(2.0, 2.0) + float2(-1.0, -1.0);
    u_xlat5.xy = u_xlat16_5.xy + (-i.vs_TEXCOORD0.xy);
    u_xlat5.xy = ((float2)(_Distort)) * u_xlat5.xy + i.vs_TEXCOORD0.xy;
    u_xlat1.xw = u_xlat1.xw * ((float2)(_Distort)) + i.vs_TEXCOORD0.xy;
    u_xlat5.xy = (u_xlatb1.y) ? u_xlat1.xw : u_xlat5.xy;
    u_xlat1.xy = u_xlat5.xy + (-i.vs_TEXCOORD0.xy);
    u_xlat15 = i.vs_TEXCOORD0.y * 0.5;
    u_xlat1.xy = ((float2)(u_xlat15)) * u_xlat1.xy + i.vs_TEXCOORD0.xy;
    u_xlatb2.xy = lessThan(float4(0.0, 0.0, 0.0, 0.0), float4(_FadeAlongU, _HdrMultiply, _FadeAlongU, _FadeAlongU)).xy;
    u_xlat5.xy = (u_xlatb2.x) ? u_xlat1.xy : u_xlat5.xy;
    u_xlat16_3 = tex2D(_MainTex, u_xlat5.xy);
    u_xlat16_4.xyz = (u_xlatb1.z) ? float3(1.0, 1.0, 1.0) : u_xlat16_3.xyz;
    u_xlat16_4.w = (u_xlatb1.z) ? u_xlat16_3.x : u_xlat16_3.w;
    u_xlat16_1 = u_xlat16_4 * i.vs_COLOR0;
    u_xlat16_4.xyz = u_xlat0.xxx * u_xlat16_1.xyz;
    result.xyz = (u_xlatb2.y) ? u_xlat16_4.xyz : u_xlat16_1.xyz;
    u_xlat0.xy = i.vs_TEXCOORD3.xy / i.vs_TEXCOORD3.ww;
    u_xlat0.x = tex2D(_CameraDepthTexture, u_xlat0.xy).x;
    u_xlat5.x = _ZBufferParams.z * u_xlat0.x + _ZBufferParams.w;
    u_xlat0.x = u_xlat0.x * _ProjectionParams.z + _ProjectionParams.y;
    u_xlat5.x = float(1.0) / u_xlat5.x;
    u_xlatb10 = unity_OrthoParams.w==1.0;
    u_xlat0.x = (u_xlatb10) ? u_xlat0.x : u_xlat5.x;
    u_xlat0.x = u_xlat0.x + (-_SoftParticlesFadeDistanceNear);
    u_xlat0.x = u_xlat0.x + (-i.vs_TEXCOORD3.z);
    u_xlat0.x = u_xlat0.x * _SoftParticlesFadeDistanceFar;
    u_xlat0.x = clamp(u_xlat0.x, 0.0, 1.0);
    u_xlat0.x = u_xlat0.x * u_xlat16_1.w;
    result.w = min(u_xlat0.x, 1.0);
    return result;

}

#elif defined(SOFTPARTICLES_ON) && defined(_ALPHABLEND_ON) && !defined(_ALPHAMODULATE_ON) && !defined(_ALPHAPREMULTIPLY_ON) && defined(_ALPHATEST_ON) && !defined(_CFXR_ADDITIVE) && !defined(_CFXR_DISSOLVE) && !defined(_CFXR_EDGE_FADING) && !defined(_CFXR_FONT_COLORS) && defined(_CFXR_LIGHTING_ALL) && !defined(_CFXR_LIGHTING_BACK) && !defined(_CFXR_LIGHTING_WPOS_OFFSET) && !defined(_CFXR_OVERLAYTEX_1X) && !defined(_CFXR_SECONDCOLOR_LERP) && !defined(_CFXR_UV_DISTORTION) && !defined(_EMISSION) && !defined(_FADING_ON) && !defined(_FLIPBOOK_BLENDING) && defined(_NORMALMAP)
// Original GLES program 89; SOFTPARTICLES_ON,_CFXR_LIGHTING_ALL,_NORMALMAP,_ALPHATEST_ON,_ALPHABLEND_ON
float _SingleChannel;
float _BumpScale;
float _IndirectLightingMix;
float4 _ShadowColor;
float _DirectLightingRamp;
float _HdrMultiply;
float _Cutoff;
sampler2D _MainTex;
sampler2D _BumpMap;
struct A{float4 in_POSITION0:POSITION0;float4 in_COLOR0:COLOR0;float4 in_TEXCOORD0:TEXCOORD0;float4 in_TEXCOORD1:TEXCOORD1;float3 in_NORMAL0:NORMAL0;float4 in_TANGENT0:TANGENT0;};
struct V{float4 vertex:SV_POSITION;float4 vs_COLOR0:TEXCOORD0;float4 vs_TEXCOORD0:TEXCOORD1;float3 vs_TEXCOORD4:TEXCOORD2;float3 vs_NORMAL0:TEXCOORD3;float4 vs_TANGENT0:TEXCOORD4;};
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
    o.vs_TEXCOORD4.xyz = i.in_POSITION0.xyz;
    o.vs_NORMAL0.xyz = i.in_NORMAL0.xyz;
    o.vs_TANGENT0 = i.in_TANGENT0;
    return o;

}
float4 frag(V i):SV_Target{float4 result=0;
float4 u_xlat0;
float4 u_xlat16_0;
float4 u_xlat1;
float4 u_xlat16_1;
bool u_xlatb1;
float4 u_xlat16_2;
float4 u_xlat3;
float4 u_xlat16_3;
float4 u_xlat4;
float3 u_xlat16_4;
float4 u_xlat5;
float3 u_xlat16_5;
float u_xlat16_6;
float3 u_xlat7;
float3 u_xlat8;
float u_xlat16_15;
float u_xlat16_29;
float u_xlat31;
bool u_xlatb31;

    u_xlat16_0 = tex2D(_MainTex, i.vs_TEXCOORD0.xy);
    u_xlatb1 = 0.0<_SingleChannel;
    u_xlat16_2.w = (u_xlatb1) ? u_xlat16_0.x : u_xlat16_0.w;
    u_xlat16_2.xyz = (bool(u_xlatb1)) ? float3(1.0, 1.0, 1.0) : u_xlat16_0.xyz;
    u_xlat16_0 = u_xlat16_2 * i.vs_COLOR0;
    u_xlat16_2.x = u_xlat16_2.w * i.vs_COLOR0.w + (-_Cutoff);
    u_xlatb1 = u_xlat16_2.x<0.0;
    if(u_xlatb1){discard;}
    u_xlat1.x = i.vs_TANGENT0.y;
    u_xlat1.z = i.vs_NORMAL0.y;
    u_xlat3.xyz = i.vs_NORMAL0.zxy * i.vs_TANGENT0.yzx;
    u_xlat3.xyz = i.vs_NORMAL0.yzx * i.vs_TANGENT0.zxy + (-u_xlat3.xyz);
    u_xlat3.xyz = u_xlat3.xzy * i.vs_TANGENT0.www;
    u_xlat1.y = u_xlat3.z;
    u_xlat16_4.xyz = tex2D(_BumpMap, i.vs_TEXCOORD0.xy).xyz;
    u_xlat16_2.xyz = u_xlat16_4.xyz * float3(2.0, 2.0, 2.0) + float3(-1.0, -1.0, -1.0);
    u_xlat16_2.xy = u_xlat16_2.xy * ((float2)(float2(_BumpScale, _BumpScale)));
    u_xlat16_1.y = dot(u_xlat16_2.xyz, u_xlat1.xyz);
    u_xlat16_29 = u_xlat16_1.y * u_xlat16_1.y;
    u_xlat4.y = u_xlat3.x;
    u_xlat4.x = i.vs_TANGENT0.x;
    u_xlat4.z = i.vs_NORMAL0.x;
    u_xlat16_1.x = dot(u_xlat16_2.xyz, u_xlat4.xyz);
    u_xlat16_29 = u_xlat16_1.x * u_xlat16_1.x + (-u_xlat16_29);
    u_xlat3.x = i.vs_TANGENT0.z;
    u_xlat3.z = i.vs_NORMAL0.z;
    u_xlat16_1.z = dot(u_xlat16_2.xyz, u_xlat3.xyz);
    u_xlat16_3 = u_xlat16_1.yzzx * u_xlat16_1.xyzz;
    u_xlat16_2.x = dot(unity_SHBr, u_xlat16_3);
    u_xlat16_2.y = dot(unity_SHBg, u_xlat16_3);
    u_xlat16_2.z = dot(unity_SHBb, u_xlat16_3);
    u_xlat16_2.xyz = unity_SHC.xyz * ((float3)(u_xlat16_29)) + u_xlat16_2.xyz;
    u_xlat16_1.w = 1.0;
    u_xlat16_5.x = dot(unity_SHAr, u_xlat16_1);
    u_xlat16_5.y = dot(unity_SHAg, u_xlat16_1);
    u_xlat16_5.z = dot(unity_SHAb, u_xlat16_1);
    u_xlat16_2.xyz = u_xlat16_2.xyz + u_xlat16_5.xyz;
    u_xlat16_2.xyz = max(u_xlat16_2.xyz, float3(0.0, 0.0, 0.0));
    u_xlat4.xyz = log2(u_xlat16_2.xyz);
    u_xlat4.xyz = u_xlat4.xyz * float3(0.416666657, 0.416666657, 0.416666657);
    u_xlat4.xyz = exp2(u_xlat4.xyz);
    u_xlat4.xyz = u_xlat4.xyz * float3(1.05499995, 1.05499995, 1.05499995) + float3(-0.0549999997, -0.0549999997, -0.0549999997);
    u_xlat31 = log2(_HdrMultiply);
    u_xlat31 = u_xlat31 * 0.416666657;
    u_xlat31 = exp2(u_xlat31);
    u_xlat4.w = u_xlat31 * 1.05499995 + -0.0549999997;
    u_xlat4 = max(u_xlat4, float4(0.0, 0.0, 0.0, 0.0));
    u_xlat16_2.xyz = u_xlat16_0.xyz * u_xlat4.www;
    u_xlatb31 = 0.0<_HdrMultiply;
    u_xlat16_2.xyz = (bool(u_xlatb31)) ? u_xlat16_2.xyz : u_xlat16_0.xyz;
    result.w = min(u_xlat16_0.w, 1.0);
    u_xlat0 = (-i.vs_TEXCOORD4.yyyy) + unity_4LightPosY0;
    u_xlat3 = u_xlat16_1.yyyy * u_xlat0;
    u_xlat31 = dot(u_xlat16_1.xyz, _WorldSpaceLightPos0.xyz);
    u_xlat16_29 = u_xlat31 * 0.5 + 0.5;
    u_xlat0 = u_xlat0 * u_xlat0;
    u_xlat5 = (-i.vs_TEXCOORD4.xxxx) + unity_4LightPosX0;
    u_xlat3 = u_xlat5 * u_xlat16_1.xxxx + u_xlat3;
    u_xlat0 = u_xlat5 * u_xlat5 + u_xlat0;
    u_xlat5 = (-i.vs_TEXCOORD4.zzzz) + unity_4LightPosZ0;
    u_xlat1 = u_xlat5 * u_xlat16_1.zzzz + u_xlat3;
    u_xlat0 = u_xlat5 * u_xlat5 + u_xlat0;
    u_xlat0 = max(u_xlat0, float4(9.99999997e-07, 9.99999997e-07, 9.99999997e-07, 9.99999997e-07));
    u_xlat1 = u_xlat1 * float4(0.5, 0.5, 0.5, 0.5) + float4(0.5, 0.5, 0.5, 0.5);
    u_xlat16_6 = (-_DirectLightingRamp) * 0.5 + 0.5;
    u_xlat1 = u_xlat1 + (-((float4)(u_xlat16_6)));
    u_xlat16_15 = _DirectLightingRamp * 0.5 + 0.5;
    u_xlat31 = (-u_xlat16_6) + u_xlat16_15;
    u_xlat16_15 = (-u_xlat16_6) + u_xlat16_15;
    u_xlat16_29 = u_xlat16_29 + (-u_xlat16_6);
    u_xlat16_6 = float(1.0) / u_xlat16_15;
    u_xlat16_29 = u_xlat16_29 * u_xlat16_6;
    u_xlat16_29 = clamp(u_xlat16_29, 0.0, 1.0);
    u_xlat31 = float(1.0) / u_xlat31;
    u_xlat1 = u_xlat1 * ((float4)(u_xlat31));
    u_xlat1 = clamp(u_xlat1, 0.0, 1.0);
    u_xlat3 = u_xlat1 * float4(-2.0, -2.0, -2.0, -2.0) + float4(3.0, 3.0, 3.0, 3.0);
    u_xlat1 = u_xlat1 * u_xlat1;
    u_xlat1 = u_xlat1 * u_xlat3;
    u_xlat3 = rsqrt(u_xlat0);
    u_xlat0 = u_xlat0 * unity_4LightAtten0 + float4(1.0, 1.0, 1.0, 1.0);
    u_xlat0 = float4(1.0, 1.0, 1.0, 1.0) / u_xlat0;
    u_xlat1 = u_xlat1 * u_xlat3;
    u_xlat0 = u_xlat0 * u_xlat1;
    u_xlat7.xyz = u_xlat0.yyy * unity_LightColor[1].xyz;
    u_xlat7.xyz = unity_LightColor[0].xyz * u_xlat0.xxx + u_xlat7.xyz;
    u_xlat7.xyz = unity_LightColor[2].xyz * u_xlat0.zzz + u_xlat7.xyz;
    u_xlat7.xyz = unity_LightColor[3].xyz * u_xlat0.www + u_xlat7.xyz;
    u_xlat16_6 = u_xlat16_29 * -2.0 + 3.0;
    u_xlat16_29 = u_xlat16_29 * u_xlat16_29;
    u_xlat16_29 = u_xlat16_29 * u_xlat16_6;
    u_xlat8.xyz = _LightColor0.xyz + (-_ShadowColor.xyz);
    u_xlat8.xyz = ((float3)(u_xlat16_29)) * u_xlat8.xyz + _ShadowColor.xyz;
    u_xlat16_2.xyz = u_xlat16_2.xyz * u_xlat8.xyz + u_xlat7.xyz;
    result.xyz = u_xlat4.xyz * ((float3)(float3(_IndirectLightingMix, _IndirectLightingMix, _IndirectLightingMix))) + u_xlat16_2.xyz;
    return result;

}

#elif defined(SOFTPARTICLES_ON) && defined(_ALPHABLEND_ON) && !defined(_ALPHAMODULATE_ON) && !defined(_ALPHAPREMULTIPLY_ON) && defined(_ALPHATEST_ON) && !defined(_CFXR_ADDITIVE) && !defined(_CFXR_DISSOLVE) && defined(_CFXR_EDGE_FADING) && !defined(_CFXR_FONT_COLORS) && !defined(_CFXR_LIGHTING_ALL) && !defined(_CFXR_LIGHTING_BACK) && !defined(_CFXR_LIGHTING_WPOS_OFFSET) && !defined(_CFXR_OVERLAYTEX_1X) && !defined(_CFXR_SECONDCOLOR_LERP) && defined(_CFXR_UV_DISTORTION) && !defined(_EMISSION) && !defined(_FADING_ON) && !defined(_FLIPBOOK_BLENDING) && !defined(_NORMALMAP)
// Original GLES program 93; SOFTPARTICLES_ON,_CFXR_EDGE_FADING,_CFXR_UV_DISTORTION,_ALPHATEST_ON,_ALPHABLEND_ON
float _EdgeFadePow;
float _SingleChannel;
float _UseUV2Distortion;
float _UVDistortionAdd;
float4 _DistortScrolling;
float _Distort;
float _FadeAlongU;
float _HdrMultiply;
float _Cutoff;
sampler2D _DistortTex;
sampler2D _MainTex;
struct A{float4 in_POSITION0:POSITION0;float4 in_COLOR0:COLOR0;float4 in_TEXCOORD0:TEXCOORD0;float4 in_TEXCOORD1:TEXCOORD1;float3 in_NORMAL0:NORMAL0;};
struct V{float4 vertex:SV_POSITION;float4 vs_COLOR0:TEXCOORD0;float4 vs_TEXCOORD0:TEXCOORD1;float4 vs_TEXCOORD1:TEXCOORD2;};
V vert(A i){V o=(V)0;
float4 u_xlat0;
float4 u_xlat1;
float u_xlat6;

    u_xlat0 = i.in_POSITION0.yyyy * transpose(unity_ObjectToWorld)[1];
    u_xlat0 = transpose(unity_ObjectToWorld)[0] * i.in_POSITION0.xxxx + u_xlat0;
    u_xlat0 = transpose(unity_ObjectToWorld)[2] * i.in_POSITION0.zzzz + u_xlat0;
    u_xlat0 = u_xlat0 + transpose(unity_ObjectToWorld)[3];
    u_xlat1 = u_xlat0.yyyy * transpose(unity_MatrixVP)[1];
    u_xlat1 = transpose(unity_MatrixVP)[0] * u_xlat0.xxxx + u_xlat1;
    u_xlat1 = transpose(unity_MatrixVP)[2] * u_xlat0.zzzz + u_xlat1;
    o.vertex = transpose(unity_MatrixVP)[3] * u_xlat0.wwww + u_xlat1;
    u_xlat0.xyz = (-i.in_POSITION0.xyz) + _WorldSpaceCameraPos.xyz;
    u_xlat6 = dot(u_xlat0.xyz, u_xlat0.xyz);
    u_xlat6 = rsqrt(u_xlat6);
    u_xlat0.xyz = ((float3)(u_xlat6)) * u_xlat0.xyz;
    u_xlat0.x = dot(u_xlat0.xyz, i.in_NORMAL0.xyz);
    u_xlat0.x = log2(abs(u_xlat0.x));
    u_xlat0.x = u_xlat0.x * _EdgeFadePow;
    u_xlat0.x = exp2(u_xlat0.x);
    u_xlat0.x = min(u_xlat0.x, 1.0);
    u_xlat0.x = u_xlat0.x * i.in_COLOR0.w;
    o.vs_COLOR0.w = u_xlat0.x;
    o.vs_COLOR0.xyz = i.in_COLOR0.xyz;
    o.vs_TEXCOORD0 = i.in_TEXCOORD0.xyxy;
    o.vs_TEXCOORD1 = i.in_TEXCOORD1;
    return o;

}
float4 frag(V i):SV_Target{float4 result=0;
float2 u_xlat0;
float4 u_xlat16_0;
float u_xlat1;
bool3 u_xlatb1;
float4 u_xlat16_2;
float2 u_xlat6;

    u_xlat0.xy = _Time.yy * _DistortScrolling.xy;
    u_xlat0.xy = frac(u_xlat0.xy);
    u_xlatb1.xyz = lessThan(float4(0.0, 0.0, 0.0, 0.0), float4(_UseUV2Distortion, _UVDistortionAdd, _SingleChannel, _UseUV2Distortion)).xyz;
    u_xlat6.xy = (u_xlatb1.x) ? i.vs_TEXCOORD1.xy : i.vs_TEXCOORD0.xy;
    u_xlat6.xy = u_xlat6.xy * _DistortScrolling.zw + i.vs_TEXCOORD0.zw;
    u_xlat0.xy = u_xlat0.xy + u_xlat6.xy;
    u_xlat16_0.xy = tex2D(_DistortTex, u_xlat0.xy).xy;
    u_xlat6.xy = u_xlat16_0.xy * float2(2.0, 2.0) + float2(-1.0, -1.0);
    u_xlat0.xy = u_xlat16_0.xy + (-i.vs_TEXCOORD0.xy);
    u_xlat0.xy = ((float2)(_Distort)) * u_xlat0.xy + i.vs_TEXCOORD0.xy;
    u_xlat6.xy = u_xlat6.xy * ((float2)(_Distort)) + i.vs_TEXCOORD0.xy;
    u_xlat0.xy = (u_xlatb1.y) ? u_xlat6.xy : u_xlat0.xy;
    u_xlat6.xy = u_xlat0.xy + (-i.vs_TEXCOORD0.xy);
    u_xlat1 = i.vs_TEXCOORD0.y * 0.5;
    u_xlat6.xy = ((float2)(u_xlat1)) * u_xlat6.xy + i.vs_TEXCOORD0.xy;
    u_xlatb1.xy = lessThan(float4(0.0, 0.0, 0.0, 0.0), float4(_FadeAlongU, _HdrMultiply, _FadeAlongU, _FadeAlongU)).xy;
    u_xlat0.xy = (u_xlatb1.x) ? u_xlat6.xy : u_xlat0.xy;
    u_xlat16_0 = tex2D(_MainTex, u_xlat0.xy);
    u_xlat16_2.w = (u_xlatb1.z) ? u_xlat16_0.x : u_xlat16_0.w;
    u_xlat16_2.xyz = (u_xlatb1.z) ? float3(1.0, 1.0, 1.0) : u_xlat16_0.xyz;
    u_xlat16_0 = u_xlat16_2 * i.vs_COLOR0;
    u_xlat16_2.x = u_xlat16_2.w * i.vs_COLOR0.w + (-_Cutoff);
    u_xlatb1.x = u_xlat16_2.x<0.0;
    if(u_xlatb1.x){discard;}
    u_xlat1 = log2(_HdrMultiply);
    u_xlat1 = u_xlat1 * 0.416666657;
    u_xlat1 = exp2(u_xlat1);
    u_xlat1 = u_xlat1 * 1.05499995 + -0.0549999997;
    u_xlat1 = max(u_xlat1, 0.0);
    u_xlat16_2.xyz = u_xlat16_0.xyz * ((float3)(u_xlat1));
    result.xyz = (u_xlatb1.y) ? u_xlat16_2.xyz : u_xlat16_0.xyz;
    result.w = min(u_xlat16_0.w, 1.0);
    return result;

}

#elif defined(SOFTPARTICLES_ON) && defined(_ALPHABLEND_ON) && !defined(_ALPHAMODULATE_ON) && !defined(_ALPHAPREMULTIPLY_ON) && defined(_ALPHATEST_ON) && !defined(_CFXR_ADDITIVE) && !defined(_CFXR_DISSOLVE) && !defined(_CFXR_EDGE_FADING) && !defined(_CFXR_FONT_COLORS) && !defined(_CFXR_LIGHTING_ALL) && !defined(_CFXR_LIGHTING_BACK) && !defined(_CFXR_LIGHTING_WPOS_OFFSET) && !defined(_CFXR_OVERLAYTEX_1X) && !defined(_CFXR_SECONDCOLOR_LERP) && defined(_CFXR_UV_DISTORTION) && !defined(_EMISSION) && defined(_FADING_ON) && !defined(_FLIPBOOK_BLENDING) && !defined(_NORMALMAP)
// Original GLES program 94; SOFTPARTICLES_ON,_FADING_ON,_CFXR_UV_DISTORTION,_ALPHATEST_ON,_ALPHABLEND_ON
float _SingleChannel;
float _UseUV2Distortion;
float _UVDistortionAdd;
float4 _DistortScrolling;
float _Distort;
float _FadeAlongU;
float _HdrMultiply;
float _Cutoff;
float _SoftParticlesFadeDistanceNear;
float _SoftParticlesFadeDistanceFar;
sampler2D _DistortTex;
sampler2D _MainTex;
sampler2D _CameraDepthTexture;
struct A{float4 in_POSITION0:POSITION0;float4 in_COLOR0:COLOR0;float4 in_TEXCOORD0:TEXCOORD0;float4 in_TEXCOORD1:TEXCOORD1;};
struct V{float4 vertex:SV_POSITION;float4 vs_COLOR0:TEXCOORD0;float4 vs_TEXCOORD0:TEXCOORD1;float4 vs_TEXCOORD1:TEXCOORD2;float4 vs_TEXCOORD3:TEXCOORD3;};
V vert(A i){V o=(V)0;
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
    o.vs_TEXCOORD1 = i.in_TEXCOORD1;
    u_xlat2 = u_xlat0.y * transpose(unity_MatrixV)[1].z;
    u_xlat0.x = transpose(unity_MatrixV)[0].z * u_xlat0.x + u_xlat2;
    u_xlat0.x = transpose(unity_MatrixV)[2].z * u_xlat0.z + u_xlat0.x;
    u_xlat0.x = transpose(unity_MatrixV)[3].z * u_xlat0.w + u_xlat0.x;
    o.vs_TEXCOORD3.z = (-u_xlat0.x);
    u_xlat0.x = u_xlat1.y * _ProjectionParams.x;
    u_xlat0.w = u_xlat0.x * 0.5;
    u_xlat0.xz = u_xlat1.xw * float2(0.5, 0.5);
    o.vs_TEXCOORD3.w = u_xlat1.w;
    o.vs_TEXCOORD3.xy = u_xlat0.zz + u_xlat0.xw;
    return o;

}
float4 frag(V i):SV_Target{float4 result=0;
float2 u_xlat0;
float4 u_xlat16_0;
float2 u_xlat1;
bool3 u_xlatb1;
float4 u_xlat16_2;
float u_xlat4;
float2 u_xlat6;
bool u_xlatb7;

    u_xlat0.xy = _Time.yy * _DistortScrolling.xy;
    u_xlat0.xy = frac(u_xlat0.xy);
    u_xlatb1.xyz = lessThan(float4(0.0, 0.0, 0.0, 0.0), float4(_UseUV2Distortion, _UVDistortionAdd, _SingleChannel, _UseUV2Distortion)).xyz;
    u_xlat6.xy = (u_xlatb1.x) ? i.vs_TEXCOORD1.xy : i.vs_TEXCOORD0.xy;
    u_xlat6.xy = u_xlat6.xy * _DistortScrolling.zw + i.vs_TEXCOORD0.zw;
    u_xlat0.xy = u_xlat0.xy + u_xlat6.xy;
    u_xlat16_0.xy = tex2D(_DistortTex, u_xlat0.xy).xy;
    u_xlat6.xy = u_xlat16_0.xy * float2(2.0, 2.0) + float2(-1.0, -1.0);
    u_xlat0.xy = u_xlat16_0.xy + (-i.vs_TEXCOORD0.xy);
    u_xlat0.xy = ((float2)(_Distort)) * u_xlat0.xy + i.vs_TEXCOORD0.xy;
    u_xlat6.xy = u_xlat6.xy * ((float2)(_Distort)) + i.vs_TEXCOORD0.xy;
    u_xlat0.xy = (u_xlatb1.y) ? u_xlat6.xy : u_xlat0.xy;
    u_xlat6.xy = u_xlat0.xy + (-i.vs_TEXCOORD0.xy);
    u_xlat1.x = i.vs_TEXCOORD0.y * 0.5;
    u_xlat6.xy = u_xlat1.xx * u_xlat6.xy + i.vs_TEXCOORD0.xy;
    u_xlatb1.xy = lessThan(float4(0.0, 0.0, 0.0, 0.0), float4(_FadeAlongU, _HdrMultiply, _FadeAlongU, _FadeAlongU)).xy;
    u_xlat0.xy = (u_xlatb1.x) ? u_xlat6.xy : u_xlat0.xy;
    u_xlat16_0 = tex2D(_MainTex, u_xlat0.xy);
    u_xlat16_2.w = (u_xlatb1.z) ? u_xlat16_0.x : u_xlat16_0.w;
    u_xlat16_2.xyz = (u_xlatb1.z) ? float3(1.0, 1.0, 1.0) : u_xlat16_0.xyz;
    u_xlat16_0 = u_xlat16_2 * i.vs_COLOR0;
    u_xlat16_2.x = u_xlat16_2.w * i.vs_COLOR0.w + (-_Cutoff);
    u_xlatb1.x = u_xlat16_2.x<0.0;
    if(u_xlatb1.x){discard;}
    u_xlat1.x = log2(_HdrMultiply);
    u_xlat1.x = u_xlat1.x * 0.416666657;
    u_xlat1.x = exp2(u_xlat1.x);
    u_xlat1.x = u_xlat1.x * 1.05499995 + -0.0549999997;
    u_xlat1.x = max(u_xlat1.x, 0.0);
    u_xlat16_2.xyz = u_xlat16_0.xyz * u_xlat1.xxx;
    result.xyz = (u_xlatb1.y) ? u_xlat16_2.xyz : u_xlat16_0.xyz;
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

#elif defined(SOFTPARTICLES_ON) && !defined(_ALPHABLEND_ON) && !defined(_ALPHAMODULATE_ON) && !defined(_ALPHAPREMULTIPLY_ON) && !defined(_ALPHATEST_ON) && defined(_CFXR_ADDITIVE) && defined(_CFXR_DISSOLVE) && !defined(_CFXR_EDGE_FADING) && !defined(_CFXR_FONT_COLORS) && !defined(_CFXR_LIGHTING_ALL) && !defined(_CFXR_LIGHTING_BACK) && !defined(_CFXR_LIGHTING_WPOS_OFFSET) && defined(_CFXR_OVERLAYTEX_1X) && !defined(_CFXR_SECONDCOLOR_LERP) && !defined(_CFXR_UV_DISTORTION) && !defined(_EMISSION) && defined(_FADING_ON) && !defined(_FLIPBOOK_BLENDING) && !defined(_NORMALMAP)
// Original GLES program 102; SOFTPARTICLES_ON,_CFXR_DISSOLVE,_FADING_ON,_CFXR_OVERLAYTEX_1X,_CFXR_ADDITIVE
float4 _OverlayTex_Scroll;
float _SingleChannel;
float _UseDissolveOffsetUV;
float _CFXR_OVERLAYBLEND;
float _InvertDissolveTex;
float _DoubleDissolve;
float2 _DissolveScroll;
float _DissolveSmooth;
float _HdrMultiply;
float _SoftParticlesFadeDistanceNear;
float _SoftParticlesFadeDistanceFar;
float4 _DissolveTex_ST;
sampler2D _MainTex;
sampler2D _OverlayTex;
sampler2D _DissolveTex;
sampler2D _CameraDepthTexture;
struct A{float4 in_POSITION0:POSITION0;float4 in_COLOR0:COLOR0;float4 in_TEXCOORD0:TEXCOORD0;float4 in_TEXCOORD1:TEXCOORD1;};
struct V{float4 vertex:SV_POSITION;float4 vs_COLOR0:TEXCOORD0;float4 vs_TEXCOORD0:TEXCOORD1;float4 vs_TEXCOORD1:TEXCOORD2;float4 vs_TEXCOORD3:TEXCOORD3;};
V vert(A i){V o=(V)0;
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
    o.vs_TEXCOORD1 = i.in_TEXCOORD1;
    u_xlat2 = u_xlat0.y * transpose(unity_MatrixV)[1].z;
    u_xlat0.x = transpose(unity_MatrixV)[0].z * u_xlat0.x + u_xlat2;
    u_xlat0.x = transpose(unity_MatrixV)[2].z * u_xlat0.z + u_xlat0.x;
    u_xlat0.x = transpose(unity_MatrixV)[3].z * u_xlat0.w + u_xlat0.x;
    o.vs_TEXCOORD3.z = (-u_xlat0.x);
    u_xlat0.x = u_xlat1.y * _ProjectionParams.x;
    u_xlat0.w = u_xlat0.x * 0.5;
    u_xlat0.xz = u_xlat1.xw * float2(0.5, 0.5);
    o.vs_TEXCOORD3.w = u_xlat1.w;
    o.vs_TEXCOORD3.xy = u_xlat0.zz + u_xlat0.xw;
    return o;

}
float4 frag(V i):SV_Target{float4 result=0;
float2 u_xlat0;
float4 u_xlat16_0;
bool u_xlatb0;
float3 u_xlat16_1;
float4 u_xlat16_2;
float2 u_xlat3;
float4 u_xlat16_3;
float2 u_xlat4;
bool2 u_xlatb4;
float u_xlat16_5;
float u_xlat6;
float u_xlat16_7;
float u_xlat10;
float2 u_xlat12;
bool2 u_xlatb12;
float u_xlat16_13;
bool u_xlatb16;
float u_xlat16_19;

    u_xlat0.xy = _Time.yy * float2(_DissolveScroll.x, _DissolveScroll.y);
    u_xlat0.xy = frac(u_xlat0.xy);
    u_xlat12.xy = i.vs_TEXCOORD0.xy * _DissolveTex_ST.xy + _DissolveTex_ST.zw;
    u_xlat0.xy = u_xlat0.xy + u_xlat12.xy;
    u_xlatb12.xy = lessThan(float4(0.0, 0.0, 0.0, 0.0), float4(_SingleChannel, _UseDissolveOffsetUV, _SingleChannel, _UseDissolveOffsetUV)).xy;
    u_xlat0.xy = (u_xlatb12.y) ? u_xlat0.xy : i.vs_TEXCOORD0.xy;
    u_xlat16_0.x = tex2D(_DissolveTex, u_xlat0.xy).x;
    u_xlat16_1.x = u_xlat16_0.x * 2.0 + -1.0;
    u_xlat6 = u_xlat16_1.x * i.vs_TEXCOORD1.z + i.vs_TEXCOORD0.x;
    u_xlat16_1.x = (u_xlatb12.y) ? u_xlat6 : u_xlat16_0.x;
    u_xlat16_7 = (-u_xlat16_1.x) + 1.0;
    u_xlatb0 = 0.0>=_InvertDissolveTex;
    u_xlat16_1.x = (u_xlatb0) ? u_xlat16_7 : u_xlat16_1.x;
    u_xlat16_7 = u_xlat16_1.x + _DissolveSmooth;
    u_xlat16_1.x = u_xlat16_1.x + (-_DissolveSmooth);
    u_xlat16_7 = (-u_xlat16_1.x) + u_xlat16_7;
    u_xlat16_7 = float(1.0) / u_xlat16_7;
    u_xlat16_13 = _DissolveSmooth * 2.0 + 1.0;
    u_xlat16_13 = i.vs_TEXCOORD1.x * u_xlat16_13 + (-_DissolveSmooth);
    u_xlat16_19 = (-u_xlat16_1.x) + u_xlat16_13;
    u_xlat16_19 = u_xlat16_7 * u_xlat16_19;
    u_xlat16_19 = clamp(u_xlat16_19, 0.0, 1.0);
    u_xlat16_2.x = u_xlat16_19 * -2.0 + 3.0;
    u_xlat16_19 = u_xlat16_19 * u_xlat16_19;
    u_xlat16_19 = u_xlat16_19 * u_xlat16_2.x;
    u_xlat0.xy = _Time.yy * _OverlayTex_Scroll.xy;
    u_xlat0.xy = frac(u_xlat0.xy);
    u_xlat3.xy = i.vs_TEXCOORD0.zw + i.vs_TEXCOORD0.xy;
    u_xlat0.xy = u_xlat3.xy * _OverlayTex_Scroll.zz + u_xlat0.xy;
    u_xlat16_0.x = tex2D(_OverlayTex, u_xlat0.xy).x;
    u_xlat16_2 = tex2D(_MainTex, i.vs_TEXCOORD0.xy);
    u_xlat16_3.xyz = (u_xlatb12.x) ? float3(1.0, 1.0, 1.0) : u_xlat16_2.xyz;
    u_xlat16_3.w = (u_xlatb12.x) ? u_xlat16_2.x : u_xlat16_2.w;
    u_xlat16_0 = u_xlat16_0.xxxx * u_xlat16_3;
    u_xlat16_2.xyz = u_xlat16_3.xyz;
    u_xlat16_3.xyz = u_xlat16_0.xyz;
    u_xlatb4.xy = equal(((float4)(_CFXR_OVERLAYBLEND)), float4(2.0, 1.0, 0.0, 0.0)).xy;
    u_xlat16_3 = (u_xlatb4.y) ? u_xlat16_3 : u_xlat16_0;
    u_xlat16_2.w = u_xlat16_0.w;
    u_xlat16_0 = (u_xlatb4.x) ? u_xlat16_2 : u_xlat16_3;
    u_xlat16_0 = u_xlat16_0 * i.vs_COLOR0;
    u_xlat16_19 = u_xlat16_19 * u_xlat16_0.w;
    u_xlatb4.x = 0.0<_DoubleDissolve;
    u_xlat16_5 = (u_xlatb4.x) ? i.vs_TEXCOORD1.y : 0.0;
    u_xlat16_13 = u_xlat16_13 + (-u_xlat16_5);
    u_xlatb4.x = 0.0<u_xlat16_5;
    u_xlat16_1.x = (-u_xlat16_1.x) + u_xlat16_13;
    u_xlat16_1.x = u_xlat16_7 * u_xlat16_1.x;
    u_xlat16_1.x = clamp(u_xlat16_1.x, 0.0, 1.0);
    u_xlat16_7 = u_xlat16_1.x * -2.0 + 3.0;
    u_xlat16_1.x = u_xlat16_1.x * u_xlat16_1.x;
    u_xlat16_1.x = (-u_xlat16_7) * u_xlat16_1.x + u_xlat16_19;
    u_xlat16_1.x = clamp(u_xlat16_1.x, 0.0, 1.0);
    u_xlat16_1.x = (u_xlatb4.x) ? u_xlat16_1.x : u_xlat16_19;
    u_xlat4.xy = i.vs_TEXCOORD3.xy / i.vs_TEXCOORD3.ww;
    u_xlat4.x = tex2D(_CameraDepthTexture, u_xlat4.xy).x;
    u_xlat10 = _ZBufferParams.z * u_xlat4.x + _ZBufferParams.w;
    u_xlat4.x = u_xlat4.x * _ProjectionParams.z + _ProjectionParams.y;
    u_xlat10 = float(1.0) / u_xlat10;
    u_xlatb16 = unity_OrthoParams.w==1.0;
    u_xlat4.x = (u_xlatb16) ? u_xlat4.x : u_xlat10;
    u_xlat4.x = u_xlat4.x + (-_SoftParticlesFadeDistanceNear);
    u_xlat4.x = u_xlat4.x + (-i.vs_TEXCOORD3.z);
    u_xlat4.x = u_xlat4.x * _SoftParticlesFadeDistanceFar;
    u_xlat4.x = clamp(u_xlat4.x, 0.0, 1.0);
    u_xlat4.x = u_xlat16_1.x * u_xlat4.x;
    result.w = min(u_xlat4.x, 1.0);
    u_xlat4.x = log2(_HdrMultiply);
    u_xlat4.x = u_xlat4.x * 0.416666657;
    u_xlat4.x = exp2(u_xlat4.x);
    u_xlat4.x = u_xlat4.x * 1.05499995 + -0.0549999997;
    u_xlat4.x = max(u_xlat4.x, 0.0);
    u_xlat16_1.xyz = u_xlat16_0.xyz * u_xlat4.xxx;
    u_xlatb4.x = 0.0<_HdrMultiply;
    result.xyz = (u_xlatb4.x) ? u_xlat16_1.xyz : u_xlat16_0.xyz;
    return result;

}

#elif defined(SOFTPARTICLES_ON) && !defined(_ALPHABLEND_ON) && !defined(_ALPHAMODULATE_ON) && !defined(_ALPHAPREMULTIPLY_ON) && !defined(_ALPHATEST_ON) && defined(_CFXR_ADDITIVE) && !defined(_CFXR_DISSOLVE) && !defined(_CFXR_EDGE_FADING) && !defined(_CFXR_FONT_COLORS) && !defined(_CFXR_LIGHTING_ALL) && !defined(_CFXR_LIGHTING_BACK) && !defined(_CFXR_LIGHTING_WPOS_OFFSET) && defined(_CFXR_OVERLAYTEX_1X) && !defined(_CFXR_SECONDCOLOR_LERP) && defined(_CFXR_UV_DISTORTION) && !defined(_EMISSION) && defined(_FADING_ON) && !defined(_FLIPBOOK_BLENDING) && !defined(_NORMALMAP)
// Original GLES program 103; SOFTPARTICLES_ON,_FADING_ON,_CFXR_UV_DISTORTION,_CFXR_OVERLAYTEX_1X,_CFXR_ADDITIVE
float4 _OverlayTex_Scroll;
float _SingleChannel;
float _UseUV2Distortion;
float _UVDistortionAdd;
float _CFXR_OVERLAYBLEND;
float4 _DistortScrolling;
float _Distort;
float _FadeAlongU;
float _HdrMultiply;
float _SoftParticlesFadeDistanceNear;
float _SoftParticlesFadeDistanceFar;
sampler2D _DistortTex;
sampler2D _MainTex;
sampler2D _OverlayTex;
sampler2D _CameraDepthTexture;
struct A{float4 in_POSITION0:POSITION0;float4 in_COLOR0:COLOR0;float4 in_TEXCOORD0:TEXCOORD0;float4 in_TEXCOORD1:TEXCOORD1;};
struct V{float4 vertex:SV_POSITION;float4 vs_COLOR0:TEXCOORD0;float4 vs_TEXCOORD0:TEXCOORD1;float4 vs_TEXCOORD1:TEXCOORD2;float4 vs_TEXCOORD3:TEXCOORD3;};
V vert(A i){V o=(V)0;
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
    o.vs_TEXCOORD1 = i.in_TEXCOORD1;
    u_xlat2 = u_xlat0.y * transpose(unity_MatrixV)[1].z;
    u_xlat0.x = transpose(unity_MatrixV)[0].z * u_xlat0.x + u_xlat2;
    u_xlat0.x = transpose(unity_MatrixV)[2].z * u_xlat0.z + u_xlat0.x;
    u_xlat0.x = transpose(unity_MatrixV)[3].z * u_xlat0.w + u_xlat0.x;
    o.vs_TEXCOORD3.z = (-u_xlat0.x);
    u_xlat0.x = u_xlat1.y * _ProjectionParams.x;
    u_xlat0.w = u_xlat0.x * 0.5;
    u_xlat0.xz = u_xlat1.xw * float2(0.5, 0.5);
    o.vs_TEXCOORD3.w = u_xlat1.w;
    o.vs_TEXCOORD3.xy = u_xlat0.zz + u_xlat0.xw;
    return o;

}
float4 frag(V i):SV_Target{float4 result=0;
float2 u_xlat0;
float4 u_xlat16_0;
float4 u_xlat1;
float4 u_xlat16_1;
bool3 u_xlatb1;
float2 u_xlat2;
bool3 u_xlatb2;
float4 u_xlat16_3;
float4 u_xlat16_4;
float2 u_xlat5;
float2 u_xlat16_5;
float u_xlat7;
float2 u_xlat10;
bool u_xlatb12;
float u_xlat15;

    u_xlat0.xy = _Time.yy * _OverlayTex_Scroll.xy;
    u_xlat0.xy = frac(u_xlat0.xy);
    u_xlat10.xy = i.vs_TEXCOORD0.zw + i.vs_TEXCOORD0.xy;
    u_xlat0.xy = u_xlat10.xy * _OverlayTex_Scroll.zz + u_xlat0.xy;
    u_xlat16_0.x = tex2D(_OverlayTex, u_xlat0.xy).x;
    u_xlat5.xy = _Time.yy * _DistortScrolling.xy;
    u_xlat5.xy = frac(u_xlat5.xy);
    u_xlatb1.xyz = lessThan(float4(0.0, 0.0, 0.0, 0.0), float4(_UseUV2Distortion, _UVDistortionAdd, _SingleChannel, _UseUV2Distortion)).xyz;
    u_xlat1.xw = (u_xlatb1.x) ? i.vs_TEXCOORD1.xy : i.vs_TEXCOORD0.xy;
    u_xlat1.xw = u_xlat1.xw * _DistortScrolling.zw + i.vs_TEXCOORD0.zw;
    u_xlat5.xy = u_xlat5.xy + u_xlat1.xw;
    u_xlat16_5.xy = tex2D(_DistortTex, u_xlat5.xy).xy;
    u_xlat1.xw = u_xlat16_5.xy * float2(2.0, 2.0) + float2(-1.0, -1.0);
    u_xlat5.xy = u_xlat16_5.xy + (-i.vs_TEXCOORD0.xy);
    u_xlat5.xy = ((float2)(_Distort)) * u_xlat5.xy + i.vs_TEXCOORD0.xy;
    u_xlat1.xw = u_xlat1.xw * ((float2)(_Distort)) + i.vs_TEXCOORD0.xy;
    u_xlat5.xy = (u_xlatb1.y) ? u_xlat1.xw : u_xlat5.xy;
    u_xlat1.xy = u_xlat5.xy + (-i.vs_TEXCOORD0.xy);
    u_xlat15 = i.vs_TEXCOORD0.y * 0.5;
    u_xlat1.xy = ((float2)(u_xlat15)) * u_xlat1.xy + i.vs_TEXCOORD0.xy;
    u_xlatb2.xy = lessThan(float4(0.0, 0.0, 0.0, 0.0), float4(_FadeAlongU, _HdrMultiply, _FadeAlongU, _FadeAlongU)).xy;
    u_xlat5.xy = (u_xlatb2.x) ? u_xlat1.xy : u_xlat5.xy;
    u_xlat16_3 = tex2D(_MainTex, u_xlat5.xy);
    u_xlat16_4.xyz = (u_xlatb1.z) ? float3(1.0, 1.0, 1.0) : u_xlat16_3.xyz;
    u_xlat16_4.w = (u_xlatb1.z) ? u_xlat16_3.x : u_xlat16_3.w;
    u_xlat16_0 = u_xlat16_0.xxxx * u_xlat16_4;
    u_xlat16_1.xyz = u_xlat16_4.xyz;
    u_xlat16_4.xyz = u_xlat16_0.xyz;
    u_xlatb2.xz = equal(((float4)(_CFXR_OVERLAYBLEND)), float4(2.0, 0.0, 1.0, 0.0)).xz;
    u_xlat16_3 = (u_xlatb2.z) ? u_xlat16_4 : u_xlat16_0;
    u_xlat16_1.w = u_xlat16_0.w;
    u_xlat16_0 = (u_xlatb2.x) ? u_xlat16_1 : u_xlat16_3;
    u_xlat16_0 = u_xlat16_0 * i.vs_COLOR0;
    u_xlat2.x = log2(_HdrMultiply);
    u_xlat2.x = u_xlat2.x * 0.416666657;
    u_xlat2.x = exp2(u_xlat2.x);
    u_xlat2.x = u_xlat2.x * 1.05499995 + -0.0549999997;
    u_xlat2.x = max(u_xlat2.x, 0.0);
    u_xlat16_4.xyz = u_xlat16_0.xyz * u_xlat2.xxx;
    result.xyz = (u_xlatb2.y) ? u_xlat16_4.xyz : u_xlat16_0.xyz;
    u_xlat2.xy = i.vs_TEXCOORD3.xy / i.vs_TEXCOORD3.ww;
    u_xlat2.x = tex2D(_CameraDepthTexture, u_xlat2.xy).x;
    u_xlat7 = _ZBufferParams.z * u_xlat2.x + _ZBufferParams.w;
    u_xlat2.x = u_xlat2.x * _ProjectionParams.z + _ProjectionParams.y;
    u_xlat7 = float(1.0) / u_xlat7;
    u_xlatb12 = unity_OrthoParams.w==1.0;
    u_xlat2.x = (u_xlatb12) ? u_xlat2.x : u_xlat7;
    u_xlat2.x = u_xlat2.x + (-_SoftParticlesFadeDistanceNear);
    u_xlat2.x = u_xlat2.x + (-i.vs_TEXCOORD3.z);
    u_xlat2.x = u_xlat2.x * _SoftParticlesFadeDistanceFar;
    u_xlat2.x = clamp(u_xlat2.x, 0.0, 1.0);
    u_xlat2.x = u_xlat16_0.w * u_xlat2.x;
    result.w = min(u_xlat2.x, 1.0);
    return result;

}

#elif !defined(SOFTPARTICLES_ON) && defined(_ALPHABLEND_ON) && !defined(_ALPHAMODULATE_ON) && !defined(_ALPHAPREMULTIPLY_ON) && !defined(_ALPHATEST_ON) && !defined(_CFXR_ADDITIVE) && defined(_CFXR_DISSOLVE) && !defined(_CFXR_EDGE_FADING) && !defined(_CFXR_FONT_COLORS) && !defined(_CFXR_LIGHTING_ALL) && !defined(_CFXR_LIGHTING_BACK) && !defined(_CFXR_LIGHTING_WPOS_OFFSET) && !defined(_CFXR_OVERLAYTEX_1X) && defined(_CFXR_SECONDCOLOR_LERP) && !defined(_CFXR_UV_DISTORTION) && !defined(_EMISSION) && defined(_FADING_ON) && !defined(_FLIPBOOK_BLENDING) && !defined(_NORMALMAP)
// Original GLES program 40; _CFXR_DISSOLVE,_CFXR_SECONDCOLOR_LERP,_FADING_ON,_ALPHABLEND_ON
float _SingleChannel;
float _UseDissolveOffsetUV;
float _InvertDissolveTex;
float _DoubleDissolve;
float2 _DissolveScroll;
float _DissolveSmooth;
float _SecondColorSmooth;
float _HdrMultiply;
float4 _DissolveTex_ST;
sampler2D _MainTex;
sampler2D _SecondColorTex;
sampler2D _DissolveTex;
struct A{float4 in_POSITION0:POSITION0;float4 in_COLOR0:COLOR0;float4 in_TEXCOORD0:TEXCOORD0;float4 in_TEXCOORD1:TEXCOORD1;float4 in_TEXCOORD2:TEXCOORD2;};
struct V{float4 vertex:SV_POSITION;float4 vs_COLOR0:TEXCOORD0;float4 vs_TEXCOORD0:TEXCOORD1;float4 vs_TEXCOORD1:TEXCOORD2;float4 vs_TEXCOORD2:TEXCOORD3;};
V vert(A i){V o=(V)0;
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
    o.vs_TEXCOORD1 = i.in_TEXCOORD1;
    o.vs_TEXCOORD2 = i.in_TEXCOORD2;
    return o;

}
float4 frag(V i):SV_Target{float4 result=0;
float2 u_xlat0;
float4 u_xlat16_0;
bool u_xlatb0;
float3 u_xlat16_1;
float4 u_xlat16_2;
float4 u_xlat16_3;
float3 u_xlat4;
float u_xlat16_4;
bool u_xlatb4;
float u_xlat5;
float u_xlat16_6;
float u_xlat9;
float2 u_xlat10;
bool2 u_xlatb10;
float u_xlat16_11;
float u_xlat16_16;
float u_xlat19;
bool u_xlatb19;

    u_xlat0.xy = _Time.yy * float2(_DissolveScroll.x, _DissolveScroll.y);
    u_xlat0.xy = frac(u_xlat0.xy);
    u_xlat10.xy = i.vs_TEXCOORD0.xy * _DissolveTex_ST.xy + _DissolveTex_ST.zw;
    u_xlat0.xy = u_xlat0.xy + u_xlat10.xy;
    u_xlatb10.xy = lessThan(float4(0.0, 0.0, 0.0, 0.0), float4(_SingleChannel, _UseDissolveOffsetUV, _SingleChannel, _UseDissolveOffsetUV)).xy;
    u_xlat0.xy = (u_xlatb10.y) ? u_xlat0.xy : i.vs_TEXCOORD0.xy;
    u_xlat16_0.x = tex2D(_DissolveTex, u_xlat0.xy).x;
    u_xlat16_1.x = u_xlat16_0.x * 2.0 + -1.0;
    u_xlat5 = u_xlat16_1.x * i.vs_TEXCOORD1.z + i.vs_TEXCOORD0.x;
    u_xlat16_1.x = (u_xlatb10.y) ? u_xlat5 : u_xlat16_0.x;
    u_xlat16_6 = (-u_xlat16_1.x) + 1.0;
    u_xlatb0 = 0.0>=_InvertDissolveTex;
    u_xlat16_1.x = (u_xlatb0) ? u_xlat16_6 : u_xlat16_1.x;
    u_xlat16_6 = u_xlat16_1.x + _DissolveSmooth;
    u_xlat16_1.x = u_xlat16_1.x + (-_DissolveSmooth);
    u_xlat16_6 = (-u_xlat16_1.x) + u_xlat16_6;
    u_xlat16_6 = float(1.0) / u_xlat16_6;
    u_xlat16_11 = _DissolveSmooth * 2.0 + 1.0;
    u_xlat16_11 = i.vs_TEXCOORD1.x * u_xlat16_11 + (-_DissolveSmooth);
    u_xlat16_16 = (-u_xlat16_1.x) + u_xlat16_11;
    u_xlat16_16 = u_xlat16_6 * u_xlat16_16;
    u_xlat16_16 = clamp(u_xlat16_16, 0.0, 1.0);
    u_xlat16_2.x = u_xlat16_16 * -2.0 + 3.0;
    u_xlat16_16 = u_xlat16_16 * u_xlat16_16;
    u_xlat16_16 = u_xlat16_16 * u_xlat16_2.x;
    u_xlat16_2 = tex2D(_MainTex, i.vs_TEXCOORD0.xy);
    u_xlat16_3.xyz = (u_xlatb10.x) ? float3(1.0, 1.0, 1.0) : u_xlat16_2.xyz;
    u_xlat16_3.w = (u_xlatb10.x) ? u_xlat16_2.x : u_xlat16_2.w;
    u_xlat16_0 = u_xlat16_3 * i.vs_COLOR0;
    u_xlat16_16 = u_xlat16_16 * u_xlat16_0.w;
    u_xlatb4 = 0.0<_DoubleDissolve;
    u_xlat16_3.x = (u_xlatb4) ? i.vs_TEXCOORD1.y : 0.0;
    u_xlat16_11 = u_xlat16_11 + (-u_xlat16_3.x);
    u_xlatb4 = 0.0<u_xlat16_3.x;
    u_xlat16_1.x = (-u_xlat16_1.x) + u_xlat16_11;
    u_xlat16_1.x = u_xlat16_6 * u_xlat16_1.x;
    u_xlat16_1.x = clamp(u_xlat16_1.x, 0.0, 1.0);
    u_xlat16_6 = u_xlat16_1.x * -2.0 + 3.0;
    u_xlat16_1.x = u_xlat16_1.x * u_xlat16_1.x;
    u_xlat16_1.x = (-u_xlat16_6) * u_xlat16_1.x + u_xlat16_16;
    u_xlat16_1.x = clamp(u_xlat16_1.x, 0.0, 1.0);
    u_xlat16_1.x = (u_xlatb4) ? u_xlat16_1.x : u_xlat16_16;
    result.w = min(u_xlat16_1.x, 1.0);
    u_xlat16_4 = tex2D(_SecondColorTex, i.vs_TEXCOORD0.xy).x;
    u_xlat16_1.x = u_xlat16_4 + _SecondColorSmooth;
    u_xlat16_6 = u_xlat16_4 + (-_SecondColorSmooth);
    u_xlat4.x = (-u_xlat16_6) + u_xlat16_1.x;
    u_xlat4.x = float(1.0) / u_xlat4.x;
    u_xlat9 = _SecondColorSmooth * 2.0 + 1.0;
    u_xlat9 = i.vs_TEXCOORD2.w * u_xlat9 + (-_SecondColorSmooth);
    u_xlat9 = (-u_xlat16_6) + u_xlat9;
    u_xlat4.x = u_xlat4.x * u_xlat9;
    u_xlat4.x = clamp(u_xlat4.x, 0.0, 1.0);
    u_xlat9 = u_xlat4.x * -2.0 + 3.0;
    u_xlat4.x = u_xlat4.x * u_xlat4.x;
    u_xlat4.x = u_xlat4.x * u_xlat9;
    u_xlat4.xyz = i.vs_TEXCOORD2.xyz * u_xlat4.xxx + u_xlat16_0.xyz;
    u_xlat19 = log2(_HdrMultiply);
    u_xlat19 = u_xlat19 * 0.416666657;
    u_xlat19 = exp2(u_xlat19);
    u_xlat19 = u_xlat19 * 1.05499995 + -0.0549999997;
    u_xlat19 = max(u_xlat19, 0.0);
    u_xlat16_1.xyz = ((float3)(u_xlat19)) * u_xlat4.xyz;
    u_xlatb19 = 0.0<_HdrMultiply;
    result.xyz = (bool(u_xlatb19)) ? u_xlat16_1.xyz : u_xlat4.xyz;
    return result;

}

#elif !defined(SOFTPARTICLES_ON) && defined(_ALPHABLEND_ON) && !defined(_ALPHAMODULATE_ON) && !defined(_ALPHAPREMULTIPLY_ON) && !defined(_ALPHATEST_ON) && !defined(_CFXR_ADDITIVE) && defined(_CFXR_DISSOLVE) && !defined(_CFXR_EDGE_FADING) && !defined(_CFXR_FONT_COLORS) && !defined(_CFXR_LIGHTING_ALL) && !defined(_CFXR_LIGHTING_BACK) && !defined(_CFXR_LIGHTING_WPOS_OFFSET) && !defined(_CFXR_OVERLAYTEX_1X) && !defined(_CFXR_SECONDCOLOR_LERP) && defined(_CFXR_UV_DISTORTION) && !defined(_EMISSION) && defined(_FADING_ON) && !defined(_FLIPBOOK_BLENDING) && !defined(_NORMALMAP)
// Original GLES program 46; _CFXR_DISSOLVE,_FADING_ON,_CFXR_UV_DISTORTION,_ALPHABLEND_ON
float _SingleChannel;
float _UseDissolveOffsetUV;
float _UseUV2Distortion;
float _UVDistortionAdd;
float _InvertDissolveTex;
float _DoubleDissolve;
float2 _DissolveScroll;
float _DissolveSmooth;
float4 _DistortScrolling;
float _Distort;
float _FadeAlongU;
float _HdrMultiply;
float4 _DissolveTex_ST;
sampler2D _DistortTex;
sampler2D _MainTex;
sampler2D _DissolveTex;
struct A{float4 in_POSITION0:POSITION0;float4 in_COLOR0:COLOR0;float4 in_TEXCOORD0:TEXCOORD0;float4 in_TEXCOORD1:TEXCOORD1;};
struct V{float4 vertex:SV_POSITION;float4 vs_COLOR0:TEXCOORD0;float4 vs_TEXCOORD0:TEXCOORD1;float4 vs_TEXCOORD1:TEXCOORD2;};
V vert(A i){V o=(V)0;
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
    o.vs_TEXCOORD1 = i.in_TEXCOORD1;
    return o;

}
float4 frag(V i):SV_Target{float4 result=0;
float2 u_xlat0;
float4 u_xlat16_0;
float3 u_xlat1;
float u_xlat16_1;
bool4 u_xlatb1;
float4 u_xlat16_2;
float2 u_xlat3;
float u_xlat16_4;
float u_xlat16_7;
float2 u_xlat10;
float u_xlat11;
float u_xlat16_12;
float u_xlat16_17;

    u_xlat0.xy = _Time.yy * _DistortScrolling.xy;
    u_xlat0.xy = frac(u_xlat0.xy);
    u_xlatb1 = lessThan(float4(0.0, 0.0, 0.0, 0.0), float4(_UseUV2Distortion, _UVDistortionAdd, _SingleChannel, _UseDissolveOffsetUV));
    u_xlat10.xy = (u_xlatb1.x) ? i.vs_TEXCOORD1.xy : i.vs_TEXCOORD0.xy;
    u_xlat10.xy = u_xlat10.xy * _DistortScrolling.zw + i.vs_TEXCOORD0.zw;
    u_xlat0.xy = u_xlat0.xy + u_xlat10.xy;
    u_xlat16_0.xy = tex2D(_DistortTex, u_xlat0.xy).xy;
    u_xlat10.xy = u_xlat16_0.xy * float2(2.0, 2.0) + float2(-1.0, -1.0);
    u_xlat0.xy = u_xlat16_0.xy + (-i.vs_TEXCOORD0.xy);
    u_xlat0.xy = ((float2)(_Distort)) * u_xlat0.xy + i.vs_TEXCOORD0.xy;
    u_xlat10.xy = u_xlat10.xy * ((float2)(_Distort)) + i.vs_TEXCOORD0.xy;
    u_xlat0.xy = (u_xlatb1.y) ? u_xlat10.xy : u_xlat0.xy;
    u_xlat10.xy = u_xlat0.xy + (-i.vs_TEXCOORD0.xy);
    u_xlat1.x = i.vs_TEXCOORD0.y * 0.5;
    u_xlat10.xy = u_xlat1.xx * u_xlat10.xy + i.vs_TEXCOORD0.xy;
    u_xlatb1.xy = lessThan(float4(0.0, 0.0, 0.0, 0.0), float4(_FadeAlongU, _HdrMultiply, _FadeAlongU, _FadeAlongU)).xy;
    u_xlat0.xy = (u_xlatb1.x) ? u_xlat10.xy : u_xlat0.xy;
    u_xlat16_0 = tex2D(_MainTex, u_xlat0.xy);
    u_xlat16_2.xyz = (u_xlatb1.z) ? float3(1.0, 1.0, 1.0) : u_xlat16_0.xyz;
    u_xlat16_2.w = (u_xlatb1.z) ? u_xlat16_0.x : u_xlat16_0.w;
    u_xlat16_0 = u_xlat16_2 * i.vs_COLOR0;
    u_xlat1.xz = _Time.yy * float2(_DissolveScroll.x, _DissolveScroll.y);
    u_xlat1.xz = frac(u_xlat1.xz);
    u_xlat3.xy = i.vs_TEXCOORD0.xy * _DissolveTex_ST.xy + _DissolveTex_ST.zw;
    u_xlat1.xz = u_xlat1.xz + u_xlat3.xy;
    u_xlat1.xz = (u_xlatb1.w) ? u_xlat1.xz : i.vs_TEXCOORD0.xy;
    u_xlat16_1 = tex2D(_DissolveTex, u_xlat1.xz).x;
    u_xlat16_2.x = u_xlat16_1 * 2.0 + -1.0;
    u_xlat11 = u_xlat16_2.x * i.vs_TEXCOORD1.z + i.vs_TEXCOORD0.x;
    u_xlat16_2.x = (u_xlatb1.w) ? u_xlat11 : u_xlat16_1;
    u_xlat16_7 = (-u_xlat16_2.x) + 1.0;
    u_xlatb1.x = 0.0>=_InvertDissolveTex;
    u_xlat16_2.x = (u_xlatb1.x) ? u_xlat16_7 : u_xlat16_2.x;
    u_xlat16_7 = u_xlat16_2.x + _DissolveSmooth;
    u_xlat16_2.x = u_xlat16_2.x + (-_DissolveSmooth);
    u_xlat16_7 = (-u_xlat16_2.x) + u_xlat16_7;
    u_xlat16_7 = float(1.0) / u_xlat16_7;
    u_xlat16_12 = _DissolveSmooth * 2.0 + 1.0;
    u_xlat16_12 = i.vs_TEXCOORD1.x * u_xlat16_12 + (-_DissolveSmooth);
    u_xlat16_17 = (-u_xlat16_2.x) + u_xlat16_12;
    u_xlat16_17 = u_xlat16_7 * u_xlat16_17;
    u_xlat16_17 = clamp(u_xlat16_17, 0.0, 1.0);
    u_xlat16_4 = u_xlat16_17 * -2.0 + 3.0;
    u_xlat16_17 = u_xlat16_17 * u_xlat16_17;
    u_xlat16_17 = u_xlat16_17 * u_xlat16_4;
    u_xlat16_17 = u_xlat16_0.w * u_xlat16_17;
    u_xlatb1.x = 0.0<_DoubleDissolve;
    u_xlat16_4 = (u_xlatb1.x) ? i.vs_TEXCOORD1.y : 0.0;
    u_xlat16_12 = u_xlat16_12 + (-u_xlat16_4);
    u_xlatb1.x = 0.0<u_xlat16_4;
    u_xlat16_2.x = (-u_xlat16_2.x) + u_xlat16_12;
    u_xlat16_2.x = u_xlat16_7 * u_xlat16_2.x;
    u_xlat16_2.x = clamp(u_xlat16_2.x, 0.0, 1.0);
    u_xlat16_7 = u_xlat16_2.x * -2.0 + 3.0;
    u_xlat16_2.x = u_xlat16_2.x * u_xlat16_2.x;
    u_xlat16_2.x = (-u_xlat16_7) * u_xlat16_2.x + u_xlat16_17;
    u_xlat16_2.x = clamp(u_xlat16_2.x, 0.0, 1.0);
    u_xlat16_2.x = (u_xlatb1.x) ? u_xlat16_2.x : u_xlat16_17;
    result.w = min(u_xlat16_2.x, 1.0);
    u_xlat1.x = log2(_HdrMultiply);
    u_xlat1.x = u_xlat1.x * 0.416666657;
    u_xlat1.x = exp2(u_xlat1.x);
    u_xlat1.x = u_xlat1.x * 1.05499995 + -0.0549999997;
    u_xlat1.x = max(u_xlat1.x, 0.0);
    u_xlat16_2.xyz = u_xlat16_0.xyz * u_xlat1.xxx;
    result.xyz = (u_xlatb1.y) ? u_xlat16_2.xyz : u_xlat16_0.xyz;
    return result;

}

#elif !defined(SOFTPARTICLES_ON) && defined(_ALPHABLEND_ON) && !defined(_ALPHAMODULATE_ON) && !defined(_ALPHAPREMULTIPLY_ON) && !defined(_ALPHATEST_ON) && !defined(_CFXR_ADDITIVE) && !defined(_CFXR_DISSOLVE) && defined(_CFXR_EDGE_FADING) && !defined(_CFXR_FONT_COLORS) && !defined(_CFXR_LIGHTING_ALL) && !defined(_CFXR_LIGHTING_BACK) && !defined(_CFXR_LIGHTING_WPOS_OFFSET) && !defined(_CFXR_OVERLAYTEX_1X) && !defined(_CFXR_SECONDCOLOR_LERP) && defined(_CFXR_UV_DISTORTION) && !defined(_EMISSION) && defined(_FADING_ON) && !defined(_FLIPBOOK_BLENDING) && !defined(_NORMALMAP)
// Original GLES program 47; _CFXR_EDGE_FADING,_FADING_ON,_CFXR_UV_DISTORTION,_ALPHABLEND_ON
float _EdgeFadePow;
float _SingleChannel;
float _UseUV2Distortion;
float _UVDistortionAdd;
float4 _DistortScrolling;
float _Distort;
float _FadeAlongU;
float _HdrMultiply;
sampler2D _DistortTex;
sampler2D _MainTex;
struct A{float4 in_POSITION0:POSITION0;float4 in_COLOR0:COLOR0;float4 in_TEXCOORD0:TEXCOORD0;float4 in_TEXCOORD1:TEXCOORD1;float3 in_NORMAL0:NORMAL0;};
struct V{float4 vertex:SV_POSITION;float4 vs_COLOR0:TEXCOORD0;float4 vs_TEXCOORD0:TEXCOORD1;float4 vs_TEXCOORD1:TEXCOORD2;};
V vert(A i){V o=(V)0;
float4 u_xlat0;
float4 u_xlat1;
float u_xlat6;

    u_xlat0 = i.in_POSITION0.yyyy * transpose(unity_ObjectToWorld)[1];
    u_xlat0 = transpose(unity_ObjectToWorld)[0] * i.in_POSITION0.xxxx + u_xlat0;
    u_xlat0 = transpose(unity_ObjectToWorld)[2] * i.in_POSITION0.zzzz + u_xlat0;
    u_xlat0 = u_xlat0 + transpose(unity_ObjectToWorld)[3];
    u_xlat1 = u_xlat0.yyyy * transpose(unity_MatrixVP)[1];
    u_xlat1 = transpose(unity_MatrixVP)[0] * u_xlat0.xxxx + u_xlat1;
    u_xlat1 = transpose(unity_MatrixVP)[2] * u_xlat0.zzzz + u_xlat1;
    o.vertex = transpose(unity_MatrixVP)[3] * u_xlat0.wwww + u_xlat1;
    u_xlat0.xyz = (-i.in_POSITION0.xyz) + _WorldSpaceCameraPos.xyz;
    u_xlat6 = dot(u_xlat0.xyz, u_xlat0.xyz);
    u_xlat6 = rsqrt(u_xlat6);
    u_xlat0.xyz = ((float3)(u_xlat6)) * u_xlat0.xyz;
    u_xlat0.x = dot(u_xlat0.xyz, i.in_NORMAL0.xyz);
    u_xlat0.x = log2(abs(u_xlat0.x));
    u_xlat0.x = u_xlat0.x * _EdgeFadePow;
    u_xlat0.x = exp2(u_xlat0.x);
    u_xlat0.x = min(u_xlat0.x, 1.0);
    u_xlat0.x = u_xlat0.x * i.in_COLOR0.w;
    o.vs_COLOR0.w = u_xlat0.x;
    o.vs_COLOR0.xyz = i.in_COLOR0.xyz;
    o.vs_TEXCOORD0 = i.in_TEXCOORD0.xyxy;
    o.vs_TEXCOORD1 = i.in_TEXCOORD1;
    return o;

}
float4 frag(V i):SV_Target{float4 result=0;
float u_xlat0;
float4 u_xlat1;
float4 u_xlat16_1;
bool3 u_xlatb1;
bool2 u_xlatb2;
float4 u_xlat16_3;
float4 u_xlat16_4;
float2 u_xlat5;
float2 u_xlat16_5;
float u_xlat15;

    u_xlat0 = log2(_HdrMultiply);
    u_xlat0 = u_xlat0 * 0.416666657;
    u_xlat0 = exp2(u_xlat0);
    u_xlat0 = u_xlat0 * 1.05499995 + -0.0549999997;
    u_xlat0 = max(u_xlat0, 0.0);
    u_xlat5.xy = _Time.yy * _DistortScrolling.xy;
    u_xlat5.xy = frac(u_xlat5.xy);
    u_xlatb1.xyz = lessThan(float4(0.0, 0.0, 0.0, 0.0), float4(_UseUV2Distortion, _UVDistortionAdd, _SingleChannel, _UseUV2Distortion)).xyz;
    u_xlat1.xw = (u_xlatb1.x) ? i.vs_TEXCOORD1.xy : i.vs_TEXCOORD0.xy;
    u_xlat1.xw = u_xlat1.xw * _DistortScrolling.zw + i.vs_TEXCOORD0.zw;
    u_xlat5.xy = u_xlat5.xy + u_xlat1.xw;
    u_xlat16_5.xy = tex2D(_DistortTex, u_xlat5.xy).xy;
    u_xlat1.xw = u_xlat16_5.xy * float2(2.0, 2.0) + float2(-1.0, -1.0);
    u_xlat5.xy = u_xlat16_5.xy + (-i.vs_TEXCOORD0.xy);
    u_xlat5.xy = ((float2)(_Distort)) * u_xlat5.xy + i.vs_TEXCOORD0.xy;
    u_xlat1.xw = u_xlat1.xw * ((float2)(_Distort)) + i.vs_TEXCOORD0.xy;
    u_xlat5.xy = (u_xlatb1.y) ? u_xlat1.xw : u_xlat5.xy;
    u_xlat1.xy = u_xlat5.xy + (-i.vs_TEXCOORD0.xy);
    u_xlat15 = i.vs_TEXCOORD0.y * 0.5;
    u_xlat1.xy = ((float2)(u_xlat15)) * u_xlat1.xy + i.vs_TEXCOORD0.xy;
    u_xlatb2.xy = lessThan(float4(0.0, 0.0, 0.0, 0.0), float4(_FadeAlongU, _HdrMultiply, _FadeAlongU, _FadeAlongU)).xy;
    u_xlat5.xy = (u_xlatb2.x) ? u_xlat1.xy : u_xlat5.xy;
    u_xlat16_3 = tex2D(_MainTex, u_xlat5.xy);
    u_xlat16_4.xyz = (u_xlatb1.z) ? float3(1.0, 1.0, 1.0) : u_xlat16_3.xyz;
    u_xlat16_4.w = (u_xlatb1.z) ? u_xlat16_3.x : u_xlat16_3.w;
    u_xlat16_1 = u_xlat16_4 * i.vs_COLOR0;
    u_xlat16_4.xyz = ((float3)(u_xlat0)) * u_xlat16_1.xyz;
    result.xyz = (u_xlatb2.y) ? u_xlat16_4.xyz : u_xlat16_1.xyz;
    result.w = min(u_xlat16_1.w, 1.0);
    return result;

}

#elif !defined(SOFTPARTICLES_ON) && defined(_ALPHABLEND_ON) && !defined(_ALPHAMODULATE_ON) && !defined(_ALPHAPREMULTIPLY_ON) && defined(_ALPHATEST_ON) && !defined(_CFXR_ADDITIVE) && !defined(_CFXR_DISSOLVE) && !defined(_CFXR_EDGE_FADING) && !defined(_CFXR_FONT_COLORS) && defined(_CFXR_LIGHTING_ALL) && !defined(_CFXR_LIGHTING_BACK) && !defined(_CFXR_LIGHTING_WPOS_OFFSET) && !defined(_CFXR_OVERLAYTEX_1X) && !defined(_CFXR_SECONDCOLOR_LERP) && !defined(_CFXR_UV_DISTORTION) && !defined(_EMISSION) && !defined(_FADING_ON) && !defined(_FLIPBOOK_BLENDING) && defined(_NORMALMAP)
// Original GLES program 53; _CFXR_LIGHTING_ALL,_NORMALMAP,_ALPHATEST_ON,_ALPHABLEND_ON
float _SingleChannel;
float _BumpScale;
float _IndirectLightingMix;
float4 _ShadowColor;
float _DirectLightingRamp;
float _HdrMultiply;
float _Cutoff;
sampler2D _MainTex;
sampler2D _BumpMap;
struct A{float4 in_POSITION0:POSITION0;float4 in_COLOR0:COLOR0;float4 in_TEXCOORD0:TEXCOORD0;float4 in_TEXCOORD1:TEXCOORD1;float3 in_NORMAL0:NORMAL0;float4 in_TANGENT0:TANGENT0;};
struct V{float4 vertex:SV_POSITION;float4 vs_COLOR0:TEXCOORD0;float4 vs_TEXCOORD0:TEXCOORD1;float3 vs_TEXCOORD4:TEXCOORD2;float3 vs_NORMAL0:TEXCOORD3;float4 vs_TANGENT0:TEXCOORD4;};
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
    o.vs_TEXCOORD4.xyz = i.in_POSITION0.xyz;
    o.vs_NORMAL0.xyz = i.in_NORMAL0.xyz;
    o.vs_TANGENT0 = i.in_TANGENT0;
    return o;

}
float4 frag(V i):SV_Target{float4 result=0;
float4 u_xlat0;
float4 u_xlat16_0;
float4 u_xlat1;
float4 u_xlat16_1;
bool u_xlatb1;
float4 u_xlat16_2;
float4 u_xlat3;
float4 u_xlat16_3;
float4 u_xlat4;
float3 u_xlat16_4;
float4 u_xlat5;
float3 u_xlat16_5;
float u_xlat16_6;
float3 u_xlat7;
float3 u_xlat8;
float u_xlat16_15;
float u_xlat16_29;
float u_xlat31;
bool u_xlatb31;

    u_xlat16_0 = tex2D(_MainTex, i.vs_TEXCOORD0.xy);
    u_xlatb1 = 0.0<_SingleChannel;
    u_xlat16_2.w = (u_xlatb1) ? u_xlat16_0.x : u_xlat16_0.w;
    u_xlat16_2.xyz = (bool(u_xlatb1)) ? float3(1.0, 1.0, 1.0) : u_xlat16_0.xyz;
    u_xlat16_0 = u_xlat16_2 * i.vs_COLOR0;
    u_xlat16_2.x = u_xlat16_2.w * i.vs_COLOR0.w + (-_Cutoff);
    u_xlatb1 = u_xlat16_2.x<0.0;
    if(u_xlatb1){discard;}
    u_xlat1.x = i.vs_TANGENT0.y;
    u_xlat1.z = i.vs_NORMAL0.y;
    u_xlat3.xyz = i.vs_NORMAL0.zxy * i.vs_TANGENT0.yzx;
    u_xlat3.xyz = i.vs_NORMAL0.yzx * i.vs_TANGENT0.zxy + (-u_xlat3.xyz);
    u_xlat3.xyz = u_xlat3.xzy * i.vs_TANGENT0.www;
    u_xlat1.y = u_xlat3.z;
    u_xlat16_4.xyz = tex2D(_BumpMap, i.vs_TEXCOORD0.xy).xyz;
    u_xlat16_2.xyz = u_xlat16_4.xyz * float3(2.0, 2.0, 2.0) + float3(-1.0, -1.0, -1.0);
    u_xlat16_2.xy = u_xlat16_2.xy * ((float2)(float2(_BumpScale, _BumpScale)));
    u_xlat16_1.y = dot(u_xlat16_2.xyz, u_xlat1.xyz);
    u_xlat16_29 = u_xlat16_1.y * u_xlat16_1.y;
    u_xlat4.y = u_xlat3.x;
    u_xlat4.x = i.vs_TANGENT0.x;
    u_xlat4.z = i.vs_NORMAL0.x;
    u_xlat16_1.x = dot(u_xlat16_2.xyz, u_xlat4.xyz);
    u_xlat16_29 = u_xlat16_1.x * u_xlat16_1.x + (-u_xlat16_29);
    u_xlat3.x = i.vs_TANGENT0.z;
    u_xlat3.z = i.vs_NORMAL0.z;
    u_xlat16_1.z = dot(u_xlat16_2.xyz, u_xlat3.xyz);
    u_xlat16_3 = u_xlat16_1.yzzx * u_xlat16_1.xyzz;
    u_xlat16_2.x = dot(unity_SHBr, u_xlat16_3);
    u_xlat16_2.y = dot(unity_SHBg, u_xlat16_3);
    u_xlat16_2.z = dot(unity_SHBb, u_xlat16_3);
    u_xlat16_2.xyz = unity_SHC.xyz * ((float3)(u_xlat16_29)) + u_xlat16_2.xyz;
    u_xlat16_1.w = 1.0;
    u_xlat16_5.x = dot(unity_SHAr, u_xlat16_1);
    u_xlat16_5.y = dot(unity_SHAg, u_xlat16_1);
    u_xlat16_5.z = dot(unity_SHAb, u_xlat16_1);
    u_xlat16_2.xyz = u_xlat16_2.xyz + u_xlat16_5.xyz;
    u_xlat16_2.xyz = max(u_xlat16_2.xyz, float3(0.0, 0.0, 0.0));
    u_xlat4.xyz = log2(u_xlat16_2.xyz);
    u_xlat4.xyz = u_xlat4.xyz * float3(0.416666657, 0.416666657, 0.416666657);
    u_xlat4.xyz = exp2(u_xlat4.xyz);
    u_xlat4.xyz = u_xlat4.xyz * float3(1.05499995, 1.05499995, 1.05499995) + float3(-0.0549999997, -0.0549999997, -0.0549999997);
    u_xlat31 = log2(_HdrMultiply);
    u_xlat31 = u_xlat31 * 0.416666657;
    u_xlat31 = exp2(u_xlat31);
    u_xlat4.w = u_xlat31 * 1.05499995 + -0.0549999997;
    u_xlat4 = max(u_xlat4, float4(0.0, 0.0, 0.0, 0.0));
    u_xlat16_2.xyz = u_xlat16_0.xyz * u_xlat4.www;
    u_xlatb31 = 0.0<_HdrMultiply;
    u_xlat16_2.xyz = (bool(u_xlatb31)) ? u_xlat16_2.xyz : u_xlat16_0.xyz;
    result.w = min(u_xlat16_0.w, 1.0);
    u_xlat0 = (-i.vs_TEXCOORD4.yyyy) + unity_4LightPosY0;
    u_xlat3 = u_xlat16_1.yyyy * u_xlat0;
    u_xlat31 = dot(u_xlat16_1.xyz, _WorldSpaceLightPos0.xyz);
    u_xlat16_29 = u_xlat31 * 0.5 + 0.5;
    u_xlat0 = u_xlat0 * u_xlat0;
    u_xlat5 = (-i.vs_TEXCOORD4.xxxx) + unity_4LightPosX0;
    u_xlat3 = u_xlat5 * u_xlat16_1.xxxx + u_xlat3;
    u_xlat0 = u_xlat5 * u_xlat5 + u_xlat0;
    u_xlat5 = (-i.vs_TEXCOORD4.zzzz) + unity_4LightPosZ0;
    u_xlat1 = u_xlat5 * u_xlat16_1.zzzz + u_xlat3;
    u_xlat0 = u_xlat5 * u_xlat5 + u_xlat0;
    u_xlat0 = max(u_xlat0, float4(9.99999997e-07, 9.99999997e-07, 9.99999997e-07, 9.99999997e-07));
    u_xlat1 = u_xlat1 * float4(0.5, 0.5, 0.5, 0.5) + float4(0.5, 0.5, 0.5, 0.5);
    u_xlat16_6 = (-_DirectLightingRamp) * 0.5 + 0.5;
    u_xlat1 = u_xlat1 + (-((float4)(u_xlat16_6)));
    u_xlat16_15 = _DirectLightingRamp * 0.5 + 0.5;
    u_xlat31 = (-u_xlat16_6) + u_xlat16_15;
    u_xlat16_15 = (-u_xlat16_6) + u_xlat16_15;
    u_xlat16_29 = u_xlat16_29 + (-u_xlat16_6);
    u_xlat16_6 = float(1.0) / u_xlat16_15;
    u_xlat16_29 = u_xlat16_29 * u_xlat16_6;
    u_xlat16_29 = clamp(u_xlat16_29, 0.0, 1.0);
    u_xlat31 = float(1.0) / u_xlat31;
    u_xlat1 = u_xlat1 * ((float4)(u_xlat31));
    u_xlat1 = clamp(u_xlat1, 0.0, 1.0);
    u_xlat3 = u_xlat1 * float4(-2.0, -2.0, -2.0, -2.0) + float4(3.0, 3.0, 3.0, 3.0);
    u_xlat1 = u_xlat1 * u_xlat1;
    u_xlat1 = u_xlat1 * u_xlat3;
    u_xlat3 = rsqrt(u_xlat0);
    u_xlat0 = u_xlat0 * unity_4LightAtten0 + float4(1.0, 1.0, 1.0, 1.0);
    u_xlat0 = float4(1.0, 1.0, 1.0, 1.0) / u_xlat0;
    u_xlat1 = u_xlat1 * u_xlat3;
    u_xlat0 = u_xlat0 * u_xlat1;
    u_xlat7.xyz = u_xlat0.yyy * unity_LightColor[1].xyz;
    u_xlat7.xyz = unity_LightColor[0].xyz * u_xlat0.xxx + u_xlat7.xyz;
    u_xlat7.xyz = unity_LightColor[2].xyz * u_xlat0.zzz + u_xlat7.xyz;
    u_xlat7.xyz = unity_LightColor[3].xyz * u_xlat0.www + u_xlat7.xyz;
    u_xlat16_6 = u_xlat16_29 * -2.0 + 3.0;
    u_xlat16_29 = u_xlat16_29 * u_xlat16_29;
    u_xlat16_29 = u_xlat16_29 * u_xlat16_6;
    u_xlat8.xyz = _LightColor0.xyz + (-_ShadowColor.xyz);
    u_xlat8.xyz = ((float3)(u_xlat16_29)) * u_xlat8.xyz + _ShadowColor.xyz;
    u_xlat16_2.xyz = u_xlat16_2.xyz * u_xlat8.xyz + u_xlat7.xyz;
    result.xyz = u_xlat4.xyz * ((float3)(float3(_IndirectLightingMix, _IndirectLightingMix, _IndirectLightingMix))) + u_xlat16_2.xyz;
    return result;

}

#elif !defined(SOFTPARTICLES_ON) && defined(_ALPHABLEND_ON) && !defined(_ALPHAMODULATE_ON) && !defined(_ALPHAPREMULTIPLY_ON) && defined(_ALPHATEST_ON) && !defined(_CFXR_ADDITIVE) && !defined(_CFXR_DISSOLVE) && defined(_CFXR_EDGE_FADING) && !defined(_CFXR_FONT_COLORS) && !defined(_CFXR_LIGHTING_ALL) && !defined(_CFXR_LIGHTING_BACK) && !defined(_CFXR_LIGHTING_WPOS_OFFSET) && !defined(_CFXR_OVERLAYTEX_1X) && !defined(_CFXR_SECONDCOLOR_LERP) && defined(_CFXR_UV_DISTORTION) && !defined(_EMISSION) && !defined(_FADING_ON) && !defined(_FLIPBOOK_BLENDING) && !defined(_NORMALMAP)
// Original GLES program 57; _CFXR_EDGE_FADING,_CFXR_UV_DISTORTION,_ALPHATEST_ON,_ALPHABLEND_ON
float _EdgeFadePow;
float _SingleChannel;
float _UseUV2Distortion;
float _UVDistortionAdd;
float4 _DistortScrolling;
float _Distort;
float _FadeAlongU;
float _HdrMultiply;
float _Cutoff;
sampler2D _DistortTex;
sampler2D _MainTex;
struct A{float4 in_POSITION0:POSITION0;float4 in_COLOR0:COLOR0;float4 in_TEXCOORD0:TEXCOORD0;float4 in_TEXCOORD1:TEXCOORD1;float3 in_NORMAL0:NORMAL0;};
struct V{float4 vertex:SV_POSITION;float4 vs_COLOR0:TEXCOORD0;float4 vs_TEXCOORD0:TEXCOORD1;float4 vs_TEXCOORD1:TEXCOORD2;};
V vert(A i){V o=(V)0;
float4 u_xlat0;
float4 u_xlat1;
float u_xlat6;

    u_xlat0 = i.in_POSITION0.yyyy * transpose(unity_ObjectToWorld)[1];
    u_xlat0 = transpose(unity_ObjectToWorld)[0] * i.in_POSITION0.xxxx + u_xlat0;
    u_xlat0 = transpose(unity_ObjectToWorld)[2] * i.in_POSITION0.zzzz + u_xlat0;
    u_xlat0 = u_xlat0 + transpose(unity_ObjectToWorld)[3];
    u_xlat1 = u_xlat0.yyyy * transpose(unity_MatrixVP)[1];
    u_xlat1 = transpose(unity_MatrixVP)[0] * u_xlat0.xxxx + u_xlat1;
    u_xlat1 = transpose(unity_MatrixVP)[2] * u_xlat0.zzzz + u_xlat1;
    o.vertex = transpose(unity_MatrixVP)[3] * u_xlat0.wwww + u_xlat1;
    u_xlat0.xyz = (-i.in_POSITION0.xyz) + _WorldSpaceCameraPos.xyz;
    u_xlat6 = dot(u_xlat0.xyz, u_xlat0.xyz);
    u_xlat6 = rsqrt(u_xlat6);
    u_xlat0.xyz = ((float3)(u_xlat6)) * u_xlat0.xyz;
    u_xlat0.x = dot(u_xlat0.xyz, i.in_NORMAL0.xyz);
    u_xlat0.x = log2(abs(u_xlat0.x));
    u_xlat0.x = u_xlat0.x * _EdgeFadePow;
    u_xlat0.x = exp2(u_xlat0.x);
    u_xlat0.x = min(u_xlat0.x, 1.0);
    u_xlat0.x = u_xlat0.x * i.in_COLOR0.w;
    o.vs_COLOR0.w = u_xlat0.x;
    o.vs_COLOR0.xyz = i.in_COLOR0.xyz;
    o.vs_TEXCOORD0 = i.in_TEXCOORD0.xyxy;
    o.vs_TEXCOORD1 = i.in_TEXCOORD1;
    return o;

}
float4 frag(V i):SV_Target{float4 result=0;
float2 u_xlat0;
float4 u_xlat16_0;
float u_xlat1;
bool3 u_xlatb1;
float4 u_xlat16_2;
float2 u_xlat6;

    u_xlat0.xy = _Time.yy * _DistortScrolling.xy;
    u_xlat0.xy = frac(u_xlat0.xy);
    u_xlatb1.xyz = lessThan(float4(0.0, 0.0, 0.0, 0.0), float4(_UseUV2Distortion, _UVDistortionAdd, _SingleChannel, _UseUV2Distortion)).xyz;
    u_xlat6.xy = (u_xlatb1.x) ? i.vs_TEXCOORD1.xy : i.vs_TEXCOORD0.xy;
    u_xlat6.xy = u_xlat6.xy * _DistortScrolling.zw + i.vs_TEXCOORD0.zw;
    u_xlat0.xy = u_xlat0.xy + u_xlat6.xy;
    u_xlat16_0.xy = tex2D(_DistortTex, u_xlat0.xy).xy;
    u_xlat6.xy = u_xlat16_0.xy * float2(2.0, 2.0) + float2(-1.0, -1.0);
    u_xlat0.xy = u_xlat16_0.xy + (-i.vs_TEXCOORD0.xy);
    u_xlat0.xy = ((float2)(_Distort)) * u_xlat0.xy + i.vs_TEXCOORD0.xy;
    u_xlat6.xy = u_xlat6.xy * ((float2)(_Distort)) + i.vs_TEXCOORD0.xy;
    u_xlat0.xy = (u_xlatb1.y) ? u_xlat6.xy : u_xlat0.xy;
    u_xlat6.xy = u_xlat0.xy + (-i.vs_TEXCOORD0.xy);
    u_xlat1 = i.vs_TEXCOORD0.y * 0.5;
    u_xlat6.xy = ((float2)(u_xlat1)) * u_xlat6.xy + i.vs_TEXCOORD0.xy;
    u_xlatb1.xy = lessThan(float4(0.0, 0.0, 0.0, 0.0), float4(_FadeAlongU, _HdrMultiply, _FadeAlongU, _FadeAlongU)).xy;
    u_xlat0.xy = (u_xlatb1.x) ? u_xlat6.xy : u_xlat0.xy;
    u_xlat16_0 = tex2D(_MainTex, u_xlat0.xy);
    u_xlat16_2.w = (u_xlatb1.z) ? u_xlat16_0.x : u_xlat16_0.w;
    u_xlat16_2.xyz = (u_xlatb1.z) ? float3(1.0, 1.0, 1.0) : u_xlat16_0.xyz;
    u_xlat16_0 = u_xlat16_2 * i.vs_COLOR0;
    u_xlat16_2.x = u_xlat16_2.w * i.vs_COLOR0.w + (-_Cutoff);
    u_xlatb1.x = u_xlat16_2.x<0.0;
    if(u_xlatb1.x){discard;}
    u_xlat1 = log2(_HdrMultiply);
    u_xlat1 = u_xlat1 * 0.416666657;
    u_xlat1 = exp2(u_xlat1);
    u_xlat1 = u_xlat1 * 1.05499995 + -0.0549999997;
    u_xlat1 = max(u_xlat1, 0.0);
    u_xlat16_2.xyz = u_xlat16_0.xyz * ((float3)(u_xlat1));
    result.xyz = (u_xlatb1.y) ? u_xlat16_2.xyz : u_xlat16_0.xyz;
    result.w = min(u_xlat16_0.w, 1.0);
    return result;

}

#elif !defined(SOFTPARTICLES_ON) && defined(_ALPHABLEND_ON) && !defined(_ALPHAMODULATE_ON) && !defined(_ALPHAPREMULTIPLY_ON) && defined(_ALPHATEST_ON) && !defined(_CFXR_ADDITIVE) && !defined(_CFXR_DISSOLVE) && !defined(_CFXR_EDGE_FADING) && !defined(_CFXR_FONT_COLORS) && !defined(_CFXR_LIGHTING_ALL) && !defined(_CFXR_LIGHTING_BACK) && !defined(_CFXR_LIGHTING_WPOS_OFFSET) && !defined(_CFXR_OVERLAYTEX_1X) && !defined(_CFXR_SECONDCOLOR_LERP) && defined(_CFXR_UV_DISTORTION) && !defined(_EMISSION) && defined(_FADING_ON) && !defined(_FLIPBOOK_BLENDING) && !defined(_NORMALMAP)
// Original GLES program 58; _FADING_ON,_CFXR_UV_DISTORTION,_ALPHATEST_ON,_ALPHABLEND_ON
float _SingleChannel;
float _UseUV2Distortion;
float _UVDistortionAdd;
float4 _DistortScrolling;
float _Distort;
float _FadeAlongU;
float _HdrMultiply;
float _Cutoff;
sampler2D _DistortTex;
sampler2D _MainTex;
struct A{float4 in_POSITION0:POSITION0;float4 in_COLOR0:COLOR0;float4 in_TEXCOORD0:TEXCOORD0;float4 in_TEXCOORD1:TEXCOORD1;};
struct V{float4 vertex:SV_POSITION;float4 vs_COLOR0:TEXCOORD0;float4 vs_TEXCOORD0:TEXCOORD1;float4 vs_TEXCOORD1:TEXCOORD2;};
V vert(A i){V o=(V)0;
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
    o.vs_TEXCOORD1 = i.in_TEXCOORD1;
    return o;

}
float4 frag(V i):SV_Target{float4 result=0;
float2 u_xlat0;
float4 u_xlat16_0;
float u_xlat1;
bool3 u_xlatb1;
float4 u_xlat16_2;
float2 u_xlat6;

    u_xlat0.xy = _Time.yy * _DistortScrolling.xy;
    u_xlat0.xy = frac(u_xlat0.xy);
    u_xlatb1.xyz = lessThan(float4(0.0, 0.0, 0.0, 0.0), float4(_UseUV2Distortion, _UVDistortionAdd, _SingleChannel, _UseUV2Distortion)).xyz;
    u_xlat6.xy = (u_xlatb1.x) ? i.vs_TEXCOORD1.xy : i.vs_TEXCOORD0.xy;
    u_xlat6.xy = u_xlat6.xy * _DistortScrolling.zw + i.vs_TEXCOORD0.zw;
    u_xlat0.xy = u_xlat0.xy + u_xlat6.xy;
    u_xlat16_0.xy = tex2D(_DistortTex, u_xlat0.xy).xy;
    u_xlat6.xy = u_xlat16_0.xy * float2(2.0, 2.0) + float2(-1.0, -1.0);
    u_xlat0.xy = u_xlat16_0.xy + (-i.vs_TEXCOORD0.xy);
    u_xlat0.xy = ((float2)(_Distort)) * u_xlat0.xy + i.vs_TEXCOORD0.xy;
    u_xlat6.xy = u_xlat6.xy * ((float2)(_Distort)) + i.vs_TEXCOORD0.xy;
    u_xlat0.xy = (u_xlatb1.y) ? u_xlat6.xy : u_xlat0.xy;
    u_xlat6.xy = u_xlat0.xy + (-i.vs_TEXCOORD0.xy);
    u_xlat1 = i.vs_TEXCOORD0.y * 0.5;
    u_xlat6.xy = ((float2)(u_xlat1)) * u_xlat6.xy + i.vs_TEXCOORD0.xy;
    u_xlatb1.xy = lessThan(float4(0.0, 0.0, 0.0, 0.0), float4(_FadeAlongU, _HdrMultiply, _FadeAlongU, _FadeAlongU)).xy;
    u_xlat0.xy = (u_xlatb1.x) ? u_xlat6.xy : u_xlat0.xy;
    u_xlat16_0 = tex2D(_MainTex, u_xlat0.xy);
    u_xlat16_2.w = (u_xlatb1.z) ? u_xlat16_0.x : u_xlat16_0.w;
    u_xlat16_2.xyz = (u_xlatb1.z) ? float3(1.0, 1.0, 1.0) : u_xlat16_0.xyz;
    u_xlat16_0 = u_xlat16_2 * i.vs_COLOR0;
    u_xlat16_2.x = u_xlat16_2.w * i.vs_COLOR0.w + (-_Cutoff);
    u_xlatb1.x = u_xlat16_2.x<0.0;
    if(u_xlatb1.x){discard;}
    u_xlat1 = log2(_HdrMultiply);
    u_xlat1 = u_xlat1 * 0.416666657;
    u_xlat1 = exp2(u_xlat1);
    u_xlat1 = u_xlat1 * 1.05499995 + -0.0549999997;
    u_xlat1 = max(u_xlat1, 0.0);
    u_xlat16_2.xyz = u_xlat16_0.xyz * ((float3)(u_xlat1));
    result.xyz = (u_xlatb1.y) ? u_xlat16_2.xyz : u_xlat16_0.xyz;
    result.w = min(u_xlat16_0.w, 1.0);
    return result;

}

#elif !defined(SOFTPARTICLES_ON) && !defined(_ALPHABLEND_ON) && !defined(_ALPHAMODULATE_ON) && !defined(_ALPHAPREMULTIPLY_ON) && !defined(_ALPHATEST_ON) && defined(_CFXR_ADDITIVE) && defined(_CFXR_DISSOLVE) && !defined(_CFXR_EDGE_FADING) && !defined(_CFXR_FONT_COLORS) && !defined(_CFXR_LIGHTING_ALL) && !defined(_CFXR_LIGHTING_BACK) && !defined(_CFXR_LIGHTING_WPOS_OFFSET) && defined(_CFXR_OVERLAYTEX_1X) && !defined(_CFXR_SECONDCOLOR_LERP) && !defined(_CFXR_UV_DISTORTION) && !defined(_EMISSION) && defined(_FADING_ON) && !defined(_FLIPBOOK_BLENDING) && !defined(_NORMALMAP)
// Original GLES program 66; _CFXR_DISSOLVE,_FADING_ON,_CFXR_OVERLAYTEX_1X,_CFXR_ADDITIVE
float4 _OverlayTex_Scroll;
float _SingleChannel;
float _UseDissolveOffsetUV;
float _CFXR_OVERLAYBLEND;
float _InvertDissolveTex;
float _DoubleDissolve;
float2 _DissolveScroll;
float _DissolveSmooth;
float _HdrMultiply;
float4 _DissolveTex_ST;
sampler2D _MainTex;
sampler2D _OverlayTex;
sampler2D _DissolveTex;
struct A{float4 in_POSITION0:POSITION0;float4 in_COLOR0:COLOR0;float4 in_TEXCOORD0:TEXCOORD0;float4 in_TEXCOORD1:TEXCOORD1;};
struct V{float4 vertex:SV_POSITION;float4 vs_COLOR0:TEXCOORD0;float4 vs_TEXCOORD0:TEXCOORD1;float4 vs_TEXCOORD1:TEXCOORD2;};
V vert(A i){V o=(V)0;
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
    o.vs_TEXCOORD1 = i.in_TEXCOORD1;
    return o;

}
float4 frag(V i):SV_Target{float4 result=0;
float2 u_xlat0;
float4 u_xlat16_0;
bool u_xlatb0;
float3 u_xlat16_1;
float4 u_xlat16_2;
float2 u_xlat3;
float4 u_xlat16_3;
float u_xlat4;
bool2 u_xlatb4;
float u_xlat16_5;
float u_xlat6;
float u_xlat16_7;
float2 u_xlat12;
bool2 u_xlatb12;
float u_xlat16_13;
float u_xlat16_19;

    u_xlat0.xy = _Time.yy * float2(_DissolveScroll.x, _DissolveScroll.y);
    u_xlat0.xy = frac(u_xlat0.xy);
    u_xlat12.xy = i.vs_TEXCOORD0.xy * _DissolveTex_ST.xy + _DissolveTex_ST.zw;
    u_xlat0.xy = u_xlat0.xy + u_xlat12.xy;
    u_xlatb12.xy = lessThan(float4(0.0, 0.0, 0.0, 0.0), float4(_SingleChannel, _UseDissolveOffsetUV, _SingleChannel, _UseDissolveOffsetUV)).xy;
    u_xlat0.xy = (u_xlatb12.y) ? u_xlat0.xy : i.vs_TEXCOORD0.xy;
    u_xlat16_0.x = tex2D(_DissolveTex, u_xlat0.xy).x;
    u_xlat16_1.x = u_xlat16_0.x * 2.0 + -1.0;
    u_xlat6 = u_xlat16_1.x * i.vs_TEXCOORD1.z + i.vs_TEXCOORD0.x;
    u_xlat16_1.x = (u_xlatb12.y) ? u_xlat6 : u_xlat16_0.x;
    u_xlat16_7 = (-u_xlat16_1.x) + 1.0;
    u_xlatb0 = 0.0>=_InvertDissolveTex;
    u_xlat16_1.x = (u_xlatb0) ? u_xlat16_7 : u_xlat16_1.x;
    u_xlat16_7 = u_xlat16_1.x + _DissolveSmooth;
    u_xlat16_1.x = u_xlat16_1.x + (-_DissolveSmooth);
    u_xlat16_7 = (-u_xlat16_1.x) + u_xlat16_7;
    u_xlat16_7 = float(1.0) / u_xlat16_7;
    u_xlat16_13 = _DissolveSmooth * 2.0 + 1.0;
    u_xlat16_13 = i.vs_TEXCOORD1.x * u_xlat16_13 + (-_DissolveSmooth);
    u_xlat16_19 = (-u_xlat16_1.x) + u_xlat16_13;
    u_xlat16_19 = u_xlat16_7 * u_xlat16_19;
    u_xlat16_19 = clamp(u_xlat16_19, 0.0, 1.0);
    u_xlat16_2.x = u_xlat16_19 * -2.0 + 3.0;
    u_xlat16_19 = u_xlat16_19 * u_xlat16_19;
    u_xlat16_19 = u_xlat16_19 * u_xlat16_2.x;
    u_xlat0.xy = _Time.yy * _OverlayTex_Scroll.xy;
    u_xlat0.xy = frac(u_xlat0.xy);
    u_xlat3.xy = i.vs_TEXCOORD0.zw + i.vs_TEXCOORD0.xy;
    u_xlat0.xy = u_xlat3.xy * _OverlayTex_Scroll.zz + u_xlat0.xy;
    u_xlat16_0.x = tex2D(_OverlayTex, u_xlat0.xy).x;
    u_xlat16_2 = tex2D(_MainTex, i.vs_TEXCOORD0.xy);
    u_xlat16_3.xyz = (u_xlatb12.x) ? float3(1.0, 1.0, 1.0) : u_xlat16_2.xyz;
    u_xlat16_3.w = (u_xlatb12.x) ? u_xlat16_2.x : u_xlat16_2.w;
    u_xlat16_0 = u_xlat16_0.xxxx * u_xlat16_3;
    u_xlat16_2.xyz = u_xlat16_3.xyz;
    u_xlat16_3.xyz = u_xlat16_0.xyz;
    u_xlatb4.xy = equal(((float4)(_CFXR_OVERLAYBLEND)), float4(2.0, 1.0, 0.0, 0.0)).xy;
    u_xlat16_3 = (u_xlatb4.y) ? u_xlat16_3 : u_xlat16_0;
    u_xlat16_2.w = u_xlat16_0.w;
    u_xlat16_0 = (u_xlatb4.x) ? u_xlat16_2 : u_xlat16_3;
    u_xlat16_0 = u_xlat16_0 * i.vs_COLOR0;
    u_xlat16_19 = u_xlat16_19 * u_xlat16_0.w;
    u_xlatb4.x = 0.0<_DoubleDissolve;
    u_xlat16_5 = (u_xlatb4.x) ? i.vs_TEXCOORD1.y : 0.0;
    u_xlat16_13 = u_xlat16_13 + (-u_xlat16_5);
    u_xlatb4.x = 0.0<u_xlat16_5;
    u_xlat16_1.x = (-u_xlat16_1.x) + u_xlat16_13;
    u_xlat16_1.x = u_xlat16_7 * u_xlat16_1.x;
    u_xlat16_1.x = clamp(u_xlat16_1.x, 0.0, 1.0);
    u_xlat16_7 = u_xlat16_1.x * -2.0 + 3.0;
    u_xlat16_1.x = u_xlat16_1.x * u_xlat16_1.x;
    u_xlat16_1.x = (-u_xlat16_7) * u_xlat16_1.x + u_xlat16_19;
    u_xlat16_1.x = clamp(u_xlat16_1.x, 0.0, 1.0);
    u_xlat16_1.x = (u_xlatb4.x) ? u_xlat16_1.x : u_xlat16_19;
    result.w = min(u_xlat16_1.x, 1.0);
    u_xlat4 = log2(_HdrMultiply);
    u_xlat4 = u_xlat4 * 0.416666657;
    u_xlat4 = exp2(u_xlat4);
    u_xlat4 = u_xlat4 * 1.05499995 + -0.0549999997;
    u_xlat4 = max(u_xlat4, 0.0);
    u_xlat16_1.xyz = u_xlat16_0.xyz * ((float3)(u_xlat4));
    u_xlatb4.x = 0.0<_HdrMultiply;
    result.xyz = (u_xlatb4.x) ? u_xlat16_1.xyz : u_xlat16_0.xyz;
    return result;

}

#elif !defined(SOFTPARTICLES_ON) && !defined(_ALPHABLEND_ON) && !defined(_ALPHAMODULATE_ON) && !defined(_ALPHAPREMULTIPLY_ON) && !defined(_ALPHATEST_ON) && defined(_CFXR_ADDITIVE) && !defined(_CFXR_DISSOLVE) && !defined(_CFXR_EDGE_FADING) && !defined(_CFXR_FONT_COLORS) && !defined(_CFXR_LIGHTING_ALL) && !defined(_CFXR_LIGHTING_BACK) && !defined(_CFXR_LIGHTING_WPOS_OFFSET) && defined(_CFXR_OVERLAYTEX_1X) && !defined(_CFXR_SECONDCOLOR_LERP) && defined(_CFXR_UV_DISTORTION) && !defined(_EMISSION) && defined(_FADING_ON) && !defined(_FLIPBOOK_BLENDING) && !defined(_NORMALMAP)
// Original GLES program 67; _FADING_ON,_CFXR_UV_DISTORTION,_CFXR_OVERLAYTEX_1X,_CFXR_ADDITIVE
float4 _OverlayTex_Scroll;
float _SingleChannel;
float _UseUV2Distortion;
float _UVDistortionAdd;
float _CFXR_OVERLAYBLEND;
float4 _DistortScrolling;
float _Distort;
float _FadeAlongU;
float _HdrMultiply;
sampler2D _DistortTex;
sampler2D _MainTex;
sampler2D _OverlayTex;
struct A{float4 in_POSITION0:POSITION0;float4 in_COLOR0:COLOR0;float4 in_TEXCOORD0:TEXCOORD0;float4 in_TEXCOORD1:TEXCOORD1;};
struct V{float4 vertex:SV_POSITION;float4 vs_COLOR0:TEXCOORD0;float4 vs_TEXCOORD0:TEXCOORD1;float4 vs_TEXCOORD1:TEXCOORD2;};
V vert(A i){V o=(V)0;
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
    o.vs_TEXCOORD1 = i.in_TEXCOORD1;
    return o;

}
float4 frag(V i):SV_Target{float4 result=0;
float2 u_xlat0;
float4 u_xlat16_0;
float4 u_xlat1;
float4 u_xlat16_1;
bool3 u_xlatb1;
float u_xlat2;
bool3 u_xlatb2;
float4 u_xlat16_3;
float4 u_xlat16_4;
float2 u_xlat5;
float2 u_xlat16_5;
float2 u_xlat10;
float u_xlat15;

    u_xlat0.xy = _Time.yy * _OverlayTex_Scroll.xy;
    u_xlat0.xy = frac(u_xlat0.xy);
    u_xlat10.xy = i.vs_TEXCOORD0.zw + i.vs_TEXCOORD0.xy;
    u_xlat0.xy = u_xlat10.xy * _OverlayTex_Scroll.zz + u_xlat0.xy;
    u_xlat16_0.x = tex2D(_OverlayTex, u_xlat0.xy).x;
    u_xlat5.xy = _Time.yy * _DistortScrolling.xy;
    u_xlat5.xy = frac(u_xlat5.xy);
    u_xlatb1.xyz = lessThan(float4(0.0, 0.0, 0.0, 0.0), float4(_UseUV2Distortion, _UVDistortionAdd, _SingleChannel, _UseUV2Distortion)).xyz;
    u_xlat1.xw = (u_xlatb1.x) ? i.vs_TEXCOORD1.xy : i.vs_TEXCOORD0.xy;
    u_xlat1.xw = u_xlat1.xw * _DistortScrolling.zw + i.vs_TEXCOORD0.zw;
    u_xlat5.xy = u_xlat5.xy + u_xlat1.xw;
    u_xlat16_5.xy = tex2D(_DistortTex, u_xlat5.xy).xy;
    u_xlat1.xw = u_xlat16_5.xy * float2(2.0, 2.0) + float2(-1.0, -1.0);
    u_xlat5.xy = u_xlat16_5.xy + (-i.vs_TEXCOORD0.xy);
    u_xlat5.xy = ((float2)(_Distort)) * u_xlat5.xy + i.vs_TEXCOORD0.xy;
    u_xlat1.xw = u_xlat1.xw * ((float2)(_Distort)) + i.vs_TEXCOORD0.xy;
    u_xlat5.xy = (u_xlatb1.y) ? u_xlat1.xw : u_xlat5.xy;
    u_xlat1.xy = u_xlat5.xy + (-i.vs_TEXCOORD0.xy);
    u_xlat15 = i.vs_TEXCOORD0.y * 0.5;
    u_xlat1.xy = ((float2)(u_xlat15)) * u_xlat1.xy + i.vs_TEXCOORD0.xy;
    u_xlatb2.xy = lessThan(float4(0.0, 0.0, 0.0, 0.0), float4(_FadeAlongU, _HdrMultiply, _FadeAlongU, _FadeAlongU)).xy;
    u_xlat5.xy = (u_xlatb2.x) ? u_xlat1.xy : u_xlat5.xy;
    u_xlat16_3 = tex2D(_MainTex, u_xlat5.xy);
    u_xlat16_4.xyz = (u_xlatb1.z) ? float3(1.0, 1.0, 1.0) : u_xlat16_3.xyz;
    u_xlat16_4.w = (u_xlatb1.z) ? u_xlat16_3.x : u_xlat16_3.w;
    u_xlat16_0 = u_xlat16_0.xxxx * u_xlat16_4;
    u_xlat16_1.xyz = u_xlat16_4.xyz;
    u_xlat16_4.xyz = u_xlat16_0.xyz;
    u_xlatb2.xz = equal(((float4)(_CFXR_OVERLAYBLEND)), float4(2.0, 0.0, 1.0, 0.0)).xz;
    u_xlat16_3 = (u_xlatb2.z) ? u_xlat16_4 : u_xlat16_0;
    u_xlat16_1.w = u_xlat16_0.w;
    u_xlat16_0 = (u_xlatb2.x) ? u_xlat16_1 : u_xlat16_3;
    u_xlat16_0 = u_xlat16_0 * i.vs_COLOR0;
    u_xlat2 = log2(_HdrMultiply);
    u_xlat2 = u_xlat2 * 0.416666657;
    u_xlat2 = exp2(u_xlat2);
    u_xlat2 = u_xlat2 * 1.05499995 + -0.0549999997;
    u_xlat2 = max(u_xlat2, 0.0);
    u_xlat16_4.xyz = u_xlat16_0.xyz * ((float3)(u_xlat2));
    result.xyz = (u_xlatb2.y) ? u_xlat16_4.xyz : u_xlat16_0.xyz;
    result.w = min(u_xlat16_0.w, 1.0);
    return result;

}

#elif defined(SOFTPARTICLES_ON) && defined(_ALPHABLEND_ON) && !defined(_ALPHAMODULATE_ON) && !defined(_ALPHAPREMULTIPLY_ON) && !defined(_ALPHATEST_ON) && !defined(_CFXR_ADDITIVE) && defined(_CFXR_DISSOLVE) && !defined(_CFXR_EDGE_FADING) && !defined(_CFXR_FONT_COLORS) && !defined(_CFXR_LIGHTING_ALL) && !defined(_CFXR_LIGHTING_BACK) && !defined(_CFXR_LIGHTING_WPOS_OFFSET) && !defined(_CFXR_OVERLAYTEX_1X) && !defined(_CFXR_SECONDCOLOR_LERP) && !defined(_CFXR_UV_DISTORTION) && !defined(_EMISSION) && defined(_FADING_ON) && !defined(_FLIPBOOK_BLENDING) && !defined(_NORMALMAP)
// Original GLES program 74; SOFTPARTICLES_ON,_CFXR_DISSOLVE,_FADING_ON,_ALPHABLEND_ON
float _SingleChannel;
float _UseDissolveOffsetUV;
float _InvertDissolveTex;
float _DoubleDissolve;
float2 _DissolveScroll;
float _DissolveSmooth;
float _HdrMultiply;
float _SoftParticlesFadeDistanceNear;
float _SoftParticlesFadeDistanceFar;
float4 _DissolveTex_ST;
sampler2D _MainTex;
sampler2D _DissolveTex;
sampler2D _CameraDepthTexture;
struct A{float4 in_POSITION0:POSITION0;float4 in_COLOR0:COLOR0;float4 in_TEXCOORD0:TEXCOORD0;float4 in_TEXCOORD1:TEXCOORD1;};
struct V{float4 vertex:SV_POSITION;float4 vs_COLOR0:TEXCOORD0;float4 vs_TEXCOORD0:TEXCOORD1;float4 vs_TEXCOORD1:TEXCOORD2;float4 vs_TEXCOORD3:TEXCOORD3;};
V vert(A i){V o=(V)0;
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
    o.vs_TEXCOORD1 = i.in_TEXCOORD1;
    u_xlat2 = u_xlat0.y * transpose(unity_MatrixV)[1].z;
    u_xlat0.x = transpose(unity_MatrixV)[0].z * u_xlat0.x + u_xlat2;
    u_xlat0.x = transpose(unity_MatrixV)[2].z * u_xlat0.z + u_xlat0.x;
    u_xlat0.x = transpose(unity_MatrixV)[3].z * u_xlat0.w + u_xlat0.x;
    o.vs_TEXCOORD3.z = (-u_xlat0.x);
    u_xlat0.x = u_xlat1.y * _ProjectionParams.x;
    u_xlat0.w = u_xlat0.x * 0.5;
    u_xlat0.xz = u_xlat1.xw * float2(0.5, 0.5);
    o.vs_TEXCOORD3.w = u_xlat1.w;
    o.vs_TEXCOORD3.xy = u_xlat0.zz + u_xlat0.xw;
    return o;

}
float4 frag(V i):SV_Target{float4 result=0;
float2 u_xlat0;
float4 u_xlat16_0;
bool u_xlatb0;
float3 u_xlat16_1;
float4 u_xlat16_2;
float4 u_xlat16_3;
float2 u_xlat4;
bool u_xlatb4;
float u_xlat5;
float u_xlat16_6;
float u_xlat9;
float2 u_xlat10;
bool2 u_xlatb10;
float u_xlat16_11;
bool u_xlatb14;
float u_xlat16_16;

    u_xlat0.xy = _Time.yy * float2(_DissolveScroll.x, _DissolveScroll.y);
    u_xlat0.xy = frac(u_xlat0.xy);
    u_xlat10.xy = i.vs_TEXCOORD0.xy * _DissolveTex_ST.xy + _DissolveTex_ST.zw;
    u_xlat0.xy = u_xlat0.xy + u_xlat10.xy;
    u_xlatb10.xy = lessThan(float4(0.0, 0.0, 0.0, 0.0), float4(_SingleChannel, _UseDissolveOffsetUV, _SingleChannel, _UseDissolveOffsetUV)).xy;
    u_xlat0.xy = (u_xlatb10.y) ? u_xlat0.xy : i.vs_TEXCOORD0.xy;
    u_xlat16_0.x = tex2D(_DissolveTex, u_xlat0.xy).x;
    u_xlat16_1.x = u_xlat16_0.x * 2.0 + -1.0;
    u_xlat5 = u_xlat16_1.x * i.vs_TEXCOORD1.z + i.vs_TEXCOORD0.x;
    u_xlat16_1.x = (u_xlatb10.y) ? u_xlat5 : u_xlat16_0.x;
    u_xlat16_6 = (-u_xlat16_1.x) + 1.0;
    u_xlatb0 = 0.0>=_InvertDissolveTex;
    u_xlat16_1.x = (u_xlatb0) ? u_xlat16_6 : u_xlat16_1.x;
    u_xlat16_6 = u_xlat16_1.x + _DissolveSmooth;
    u_xlat16_1.x = u_xlat16_1.x + (-_DissolveSmooth);
    u_xlat16_6 = (-u_xlat16_1.x) + u_xlat16_6;
    u_xlat16_6 = float(1.0) / u_xlat16_6;
    u_xlat16_11 = _DissolveSmooth * 2.0 + 1.0;
    u_xlat16_11 = i.vs_TEXCOORD1.x * u_xlat16_11 + (-_DissolveSmooth);
    u_xlat16_16 = (-u_xlat16_1.x) + u_xlat16_11;
    u_xlat16_16 = u_xlat16_6 * u_xlat16_16;
    u_xlat16_16 = clamp(u_xlat16_16, 0.0, 1.0);
    u_xlat16_2.x = u_xlat16_16 * -2.0 + 3.0;
    u_xlat16_16 = u_xlat16_16 * u_xlat16_16;
    u_xlat16_16 = u_xlat16_16 * u_xlat16_2.x;
    u_xlat16_2 = tex2D(_MainTex, i.vs_TEXCOORD0.xy);
    u_xlat16_3.xyz = (u_xlatb10.x) ? float3(1.0, 1.0, 1.0) : u_xlat16_2.xyz;
    u_xlat16_3.w = (u_xlatb10.x) ? u_xlat16_2.x : u_xlat16_2.w;
    u_xlat16_0 = u_xlat16_3 * i.vs_COLOR0;
    u_xlat16_16 = u_xlat16_16 * u_xlat16_0.w;
    u_xlatb4 = 0.0<_DoubleDissolve;
    u_xlat16_3.x = (u_xlatb4) ? i.vs_TEXCOORD1.y : 0.0;
    u_xlat16_11 = u_xlat16_11 + (-u_xlat16_3.x);
    u_xlatb4 = 0.0<u_xlat16_3.x;
    u_xlat16_1.x = (-u_xlat16_1.x) + u_xlat16_11;
    u_xlat16_1.x = u_xlat16_6 * u_xlat16_1.x;
    u_xlat16_1.x = clamp(u_xlat16_1.x, 0.0, 1.0);
    u_xlat16_6 = u_xlat16_1.x * -2.0 + 3.0;
    u_xlat16_1.x = u_xlat16_1.x * u_xlat16_1.x;
    u_xlat16_1.x = (-u_xlat16_6) * u_xlat16_1.x + u_xlat16_16;
    u_xlat16_1.x = clamp(u_xlat16_1.x, 0.0, 1.0);
    u_xlat16_1.x = (u_xlatb4) ? u_xlat16_1.x : u_xlat16_16;
    u_xlat4.xy = i.vs_TEXCOORD3.xy / i.vs_TEXCOORD3.ww;
    u_xlat4.x = tex2D(_CameraDepthTexture, u_xlat4.xy).x;
    u_xlat9 = _ZBufferParams.z * u_xlat4.x + _ZBufferParams.w;
    u_xlat4.x = u_xlat4.x * _ProjectionParams.z + _ProjectionParams.y;
    u_xlat9 = float(1.0) / u_xlat9;
    u_xlatb14 = unity_OrthoParams.w==1.0;
    u_xlat4.x = (u_xlatb14) ? u_xlat4.x : u_xlat9;
    u_xlat4.x = u_xlat4.x + (-_SoftParticlesFadeDistanceNear);
    u_xlat4.x = u_xlat4.x + (-i.vs_TEXCOORD3.z);
    u_xlat4.x = u_xlat4.x * _SoftParticlesFadeDistanceFar;
    u_xlat4.x = clamp(u_xlat4.x, 0.0, 1.0);
    u_xlat4.x = u_xlat16_1.x * u_xlat4.x;
    result.w = min(u_xlat4.x, 1.0);
    u_xlat4.x = log2(_HdrMultiply);
    u_xlat4.x = u_xlat4.x * 0.416666657;
    u_xlat4.x = exp2(u_xlat4.x);
    u_xlat4.x = u_xlat4.x * 1.05499995 + -0.0549999997;
    u_xlat4.x = max(u_xlat4.x, 0.0);
    u_xlat16_1.xyz = u_xlat16_0.xyz * u_xlat4.xxx;
    u_xlatb4 = 0.0<_HdrMultiply;
    result.xyz = (bool(u_xlatb4)) ? u_xlat16_1.xyz : u_xlat16_0.xyz;
    return result;

}

#elif defined(SOFTPARTICLES_ON) && defined(_ALPHABLEND_ON) && !defined(_ALPHAMODULATE_ON) && !defined(_ALPHAPREMULTIPLY_ON) && !defined(_ALPHATEST_ON) && !defined(_CFXR_ADDITIVE) && !defined(_CFXR_DISSOLVE) && !defined(_CFXR_EDGE_FADING) && !defined(_CFXR_FONT_COLORS) && !defined(_CFXR_LIGHTING_ALL) && !defined(_CFXR_LIGHTING_BACK) && !defined(_CFXR_LIGHTING_WPOS_OFFSET) && !defined(_CFXR_OVERLAYTEX_1X) && defined(_CFXR_SECONDCOLOR_LERP) && !defined(_CFXR_UV_DISTORTION) && !defined(_EMISSION) && defined(_FADING_ON) && !defined(_FLIPBOOK_BLENDING) && !defined(_NORMALMAP)
// Original GLES program 75; SOFTPARTICLES_ON,_CFXR_SECONDCOLOR_LERP,_FADING_ON,_ALPHABLEND_ON
float _SingleChannel;
float _SecondColorSmooth;
float _HdrMultiply;
float _SoftParticlesFadeDistanceNear;
float _SoftParticlesFadeDistanceFar;
sampler2D _MainTex;
sampler2D _SecondColorTex;
sampler2D _CameraDepthTexture;
struct A{float4 in_POSITION0:POSITION0;float4 in_COLOR0:COLOR0;float4 in_TEXCOORD0:TEXCOORD0;float4 in_TEXCOORD1:TEXCOORD1;float4 in_TEXCOORD2:TEXCOORD2;};
struct V{float4 vertex:SV_POSITION;float4 vs_COLOR0:TEXCOORD0;float4 vs_TEXCOORD0:TEXCOORD1;float4 vs_TEXCOORD2:TEXCOORD2;float4 vs_TEXCOORD3:TEXCOORD3;};
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
    o.vs_TEXCOORD2 = i.in_TEXCOORD2;
    u_xlat2 = u_xlat0.y * transpose(unity_MatrixV)[1].z;
    u_xlat0.x = transpose(unity_MatrixV)[0].z * u_xlat0.x + u_xlat2;
    u_xlat0.x = transpose(unity_MatrixV)[2].z * u_xlat0.z + u_xlat0.x;
    u_xlat0.x = transpose(unity_MatrixV)[3].z * u_xlat0.w + u_xlat0.x;
    o.vs_TEXCOORD3.z = (-u_xlat0.x);
    u_xlat0.x = u_xlat1.y * _ProjectionParams.x;
    u_xlat0.w = u_xlat0.x * 0.5;
    u_xlat0.xz = u_xlat1.xw * float2(0.5, 0.5);
    o.vs_TEXCOORD3.w = u_xlat1.w;
    o.vs_TEXCOORD3.xy = u_xlat0.zz + u_xlat0.xw;
    return o;

}
float4 frag(V i):SV_Target{float4 result=0;
float3 u_xlat0;
float u_xlat16_0;
float4 u_xlat16_1;
float4 u_xlat16_2;
float u_xlat3;
bool u_xlatb3;
float u_xlat16_4;
bool u_xlatb6;
float u_xlat9;
bool u_xlatb9;

    u_xlat16_0 = tex2D(_SecondColorTex, i.vs_TEXCOORD0.xy).x;
    u_xlat16_1.x = u_xlat16_0 + _SecondColorSmooth;
    u_xlat16_4 = u_xlat16_0 + (-_SecondColorSmooth);
    u_xlat0.x = (-u_xlat16_4) + u_xlat16_1.x;
    u_xlat0.x = float(1.0) / u_xlat0.x;
    u_xlat3 = _SecondColorSmooth * 2.0 + 1.0;
    u_xlat3 = i.vs_TEXCOORD2.w * u_xlat3 + (-_SecondColorSmooth);
    u_xlat3 = (-u_xlat16_4) + u_xlat3;
    u_xlat0.x = u_xlat0.x * u_xlat3;
    u_xlat0.x = clamp(u_xlat0.x, 0.0, 1.0);
    u_xlat3 = u_xlat0.x * -2.0 + 3.0;
    u_xlat0.x = u_xlat0.x * u_xlat0.x;
    u_xlat0.x = u_xlat0.x * u_xlat3;
    u_xlat16_1 = tex2D(_MainTex, i.vs_TEXCOORD0.xy);
    u_xlatb3 = 0.0<_SingleChannel;
    u_xlat16_2.xyz = (bool(u_xlatb3)) ? float3(1.0, 1.0, 1.0) : u_xlat16_1.xyz;
    u_xlat16_2.w = (u_xlatb3) ? u_xlat16_1.x : u_xlat16_1.w;
    u_xlat16_1 = u_xlat16_2 * i.vs_COLOR0;
    u_xlat0.xyz = i.vs_TEXCOORD2.xyz * u_xlat0.xxx + u_xlat16_1.xyz;
    u_xlat9 = log2(_HdrMultiply);
    u_xlat9 = u_xlat9 * 0.416666657;
    u_xlat9 = exp2(u_xlat9);
    u_xlat9 = u_xlat9 * 1.05499995 + -0.0549999997;
    u_xlat9 = max(u_xlat9, 0.0);
    u_xlat16_2.xyz = ((float3)(u_xlat9)) * u_xlat0.xyz;
    u_xlatb9 = 0.0<_HdrMultiply;
    result.xyz = (bool(u_xlatb9)) ? u_xlat16_2.xyz : u_xlat0.xyz;
    u_xlat0.xy = i.vs_TEXCOORD3.xy / i.vs_TEXCOORD3.ww;
    u_xlat0.x = tex2D(_CameraDepthTexture, u_xlat0.xy).x;
    u_xlat3 = _ZBufferParams.z * u_xlat0.x + _ZBufferParams.w;
    u_xlat0.x = u_xlat0.x * _ProjectionParams.z + _ProjectionParams.y;
    u_xlat3 = float(1.0) / u_xlat3;
    u_xlatb6 = unity_OrthoParams.w==1.0;
    u_xlat0.x = (u_xlatb6) ? u_xlat0.x : u_xlat3;
    u_xlat0.x = u_xlat0.x + (-_SoftParticlesFadeDistanceNear);
    u_xlat0.x = u_xlat0.x + (-i.vs_TEXCOORD3.z);
    u_xlat0.x = u_xlat0.x * _SoftParticlesFadeDistanceFar;
    u_xlat0.x = clamp(u_xlat0.x, 0.0, 1.0);
    u_xlat0.x = u_xlat0.x * u_xlat16_1.w;
    result.w = min(u_xlat0.x, 1.0);
    return result;

}

#elif defined(SOFTPARTICLES_ON) && defined(_ALPHABLEND_ON) && !defined(_ALPHAMODULATE_ON) && !defined(_ALPHAPREMULTIPLY_ON) && !defined(_ALPHATEST_ON) && !defined(_CFXR_ADDITIVE) && !defined(_CFXR_DISSOLVE) && !defined(_CFXR_EDGE_FADING) && defined(_CFXR_FONT_COLORS) && !defined(_CFXR_LIGHTING_ALL) && !defined(_CFXR_LIGHTING_BACK) && !defined(_CFXR_LIGHTING_WPOS_OFFSET) && !defined(_CFXR_OVERLAYTEX_1X) && !defined(_CFXR_SECONDCOLOR_LERP) && !defined(_CFXR_UV_DISTORTION) && !defined(_EMISSION) && defined(_FADING_ON) && !defined(_FLIPBOOK_BLENDING) && !defined(_NORMALMAP)
// Original GLES program 77; SOFTPARTICLES_ON,_CFXR_FONT_COLORS,_FADING_ON,_ALPHABLEND_ON
float _SingleChannel;
float _HdrMultiply;
float _SoftParticlesFadeDistanceNear;
float _SoftParticlesFadeDistanceFar;
sampler2D _MainTex;
sampler2D _CameraDepthTexture;
struct A{float4 in_POSITION0:POSITION0;float4 in_COLOR0:COLOR0;float4 in_TEXCOORD0:TEXCOORD0;float4 in_TEXCOORD1:TEXCOORD1;float4 in_TEXCOORD2:TEXCOORD2;};
struct V{float4 vertex:SV_POSITION;float4 vs_COLOR0:TEXCOORD0;float4 vs_TEXCOORD0:TEXCOORD1;float4 vs_TEXCOORD1:TEXCOORD2;float4 vs_TEXCOORD2:TEXCOORD3;float4 vs_TEXCOORD3:TEXCOORD4;};
V vert(A i){V o=(V)0;
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
    o.vs_TEXCOORD1 = i.in_TEXCOORD1;
    o.vs_TEXCOORD2 = i.in_TEXCOORD2;
    u_xlat2 = u_xlat0.y * transpose(unity_MatrixV)[1].z;
    u_xlat0.x = transpose(unity_MatrixV)[0].z * u_xlat0.x + u_xlat2;
    u_xlat0.x = transpose(unity_MatrixV)[2].z * u_xlat0.z + u_xlat0.x;
    u_xlat0.x = transpose(unity_MatrixV)[3].z * u_xlat0.w + u_xlat0.x;
    o.vs_TEXCOORD3.z = (-u_xlat0.x);
    u_xlat0.x = u_xlat1.y * _ProjectionParams.x;
    u_xlat0.w = u_xlat0.x * 0.5;
    u_xlat0.xz = u_xlat1.xw * float2(0.5, 0.5);
    o.vs_TEXCOORD3.w = u_xlat1.w;
    o.vs_TEXCOORD3.xy = u_xlat0.zz + u_xlat0.xw;
    return o;

}
float4 frag(V i):SV_Target{float4 result=0;
float2 u_xlat0;
bool u_xlatb0;
float4 u_xlat16_1;
float4 u_xlat16_2;
float3 u_xlat3;
bool u_xlatb3;
bool u_xlatb6;

    u_xlat0.x = log2(_HdrMultiply);
    u_xlat0.x = u_xlat0.x * 0.416666657;
    u_xlat0.x = exp2(u_xlat0.x);
    u_xlat0.x = u_xlat0.x * 1.05499995 + -0.0549999997;
    u_xlat0.x = max(u_xlat0.x, 0.0);
    u_xlat16_1 = tex2D(_MainTex, i.vs_TEXCOORD0.xy);
    u_xlatb3 = 0.0<_SingleChannel;
    u_xlat16_2.w = (u_xlatb3) ? u_xlat16_1.x : u_xlat16_1.w;
    u_xlat16_2.xyz = (bool(u_xlatb3)) ? float3(1.0, 1.0, 1.0) : u_xlat16_1.xyz;
    u_xlat16_1 = u_xlat16_2.zzzw * i.vs_COLOR0;
    u_xlat3.xyz = u_xlat16_2.yyy * i.vs_TEXCOORD1.xyz + u_xlat16_1.xyz;
    u_xlat3.xyz = u_xlat16_2.xxx * i.vs_TEXCOORD2.xyz + u_xlat3.xyz;
    u_xlat16_2.xyz = u_xlat0.xxx * u_xlat3.xyz;
    u_xlatb0 = 0.0<_HdrMultiply;
    result.xyz = (bool(u_xlatb0)) ? u_xlat16_2.xyz : u_xlat3.xyz;
    u_xlat0.xy = i.vs_TEXCOORD3.xy / i.vs_TEXCOORD3.ww;
    u_xlat0.x = tex2D(_CameraDepthTexture, u_xlat0.xy).x;
    u_xlat3.x = _ZBufferParams.z * u_xlat0.x + _ZBufferParams.w;
    u_xlat0.x = u_xlat0.x * _ProjectionParams.z + _ProjectionParams.y;
    u_xlat3.x = float(1.0) / u_xlat3.x;
    u_xlatb6 = unity_OrthoParams.w==1.0;
    u_xlat0.x = (u_xlatb6) ? u_xlat0.x : u_xlat3.x;
    u_xlat0.x = u_xlat0.x + (-_SoftParticlesFadeDistanceNear);
    u_xlat0.x = u_xlat0.x + (-i.vs_TEXCOORD3.z);
    u_xlat0.x = u_xlat0.x * _SoftParticlesFadeDistanceFar;
    u_xlat0.x = clamp(u_xlat0.x, 0.0, 1.0);
    u_xlat0.x = u_xlat0.x * u_xlat16_1.w;
    result.w = min(u_xlat0.x, 1.0);
    return result;

}

#elif defined(SOFTPARTICLES_ON) && defined(_ALPHABLEND_ON) && !defined(_ALPHAMODULATE_ON) && !defined(_ALPHAPREMULTIPLY_ON) && !defined(_ALPHATEST_ON) && !defined(_CFXR_ADDITIVE) && !defined(_CFXR_DISSOLVE) && defined(_CFXR_EDGE_FADING) && !defined(_CFXR_FONT_COLORS) && !defined(_CFXR_LIGHTING_ALL) && !defined(_CFXR_LIGHTING_BACK) && !defined(_CFXR_LIGHTING_WPOS_OFFSET) && !defined(_CFXR_OVERLAYTEX_1X) && !defined(_CFXR_SECONDCOLOR_LERP) && !defined(_CFXR_UV_DISTORTION) && !defined(_EMISSION) && defined(_FADING_ON) && !defined(_FLIPBOOK_BLENDING) && !defined(_NORMALMAP)
// Original GLES program 78; SOFTPARTICLES_ON,_CFXR_EDGE_FADING,_FADING_ON,_ALPHABLEND_ON
float _EdgeFadePow;
float _SingleChannel;
float _HdrMultiply;
float _SoftParticlesFadeDistanceNear;
float _SoftParticlesFadeDistanceFar;
sampler2D _MainTex;
sampler2D _CameraDepthTexture;
struct A{float4 in_POSITION0:POSITION0;float4 in_COLOR0:COLOR0;float4 in_TEXCOORD0:TEXCOORD0;float4 in_TEXCOORD1:TEXCOORD1;float3 in_NORMAL0:NORMAL0;};
struct V{float4 vertex:SV_POSITION;float4 vs_COLOR0:TEXCOORD0;float4 vs_TEXCOORD0:TEXCOORD1;float4 vs_TEXCOORD3:TEXCOORD2;};
V vert(A i){V o=(V)0;
float4 vs_TEXCOORD1;
float4 u_xlat0;
float4 u_xlat1;
float3 u_xlat2;
float u_xlat3;
float u_xlat7;

    u_xlat0 = i.in_POSITION0.yyyy * transpose(unity_ObjectToWorld)[1];
    u_xlat0 = transpose(unity_ObjectToWorld)[0] * i.in_POSITION0.xxxx + u_xlat0;
    u_xlat0 = transpose(unity_ObjectToWorld)[2] * i.in_POSITION0.zzzz + u_xlat0;
    u_xlat0 = u_xlat0 + transpose(unity_ObjectToWorld)[3];
    u_xlat1 = u_xlat0.yyyy * transpose(unity_MatrixVP)[1];
    u_xlat1 = transpose(unity_MatrixVP)[0] * u_xlat0.xxxx + u_xlat1;
    u_xlat1 = transpose(unity_MatrixVP)[2] * u_xlat0.zzzz + u_xlat1;
    u_xlat1 = transpose(unity_MatrixVP)[3] * u_xlat0.wwww + u_xlat1;
    o.vertex = u_xlat1;
    u_xlat2.xyz = (-i.in_POSITION0.xyz) + _WorldSpaceCameraPos.xyz;
    u_xlat7 = dot(u_xlat2.xyz, u_xlat2.xyz);
    u_xlat7 = rsqrt(u_xlat7);
    u_xlat2.xyz = ((float3)(u_xlat7)) * u_xlat2.xyz;
    u_xlat7 = dot(u_xlat2.xyz, i.in_NORMAL0.xyz);
    u_xlat7 = log2(abs(u_xlat7));
    u_xlat7 = u_xlat7 * _EdgeFadePow;
    u_xlat7 = exp2(u_xlat7);
    u_xlat7 = min(u_xlat7, 1.0);
    u_xlat7 = u_xlat7 * i.in_COLOR0.w;
    o.vs_COLOR0.w = u_xlat7;
    o.vs_COLOR0.xyz = i.in_COLOR0.xyz;
    o.vs_TEXCOORD0 = i.in_TEXCOORD0.xyxy;
    vs_TEXCOORD1 = i.in_TEXCOORD1;
    u_xlat3 = u_xlat0.y * transpose(unity_MatrixV)[1].z;
    u_xlat0.x = transpose(unity_MatrixV)[0].z * u_xlat0.x + u_xlat3;
    u_xlat0.x = transpose(unity_MatrixV)[2].z * u_xlat0.z + u_xlat0.x;
    u_xlat0.x = transpose(unity_MatrixV)[3].z * u_xlat0.w + u_xlat0.x;
    o.vs_TEXCOORD3.z = (-u_xlat0.x);
    u_xlat0.x = u_xlat1.y * _ProjectionParams.x;
    u_xlat0.w = u_xlat0.x * 0.5;
    u_xlat0.xz = u_xlat1.xw * float2(0.5, 0.5);
    o.vs_TEXCOORD3.w = u_xlat1.w;
    o.vs_TEXCOORD3.xy = u_xlat0.zz + u_xlat0.xw;
    return o;

}
float4 frag(V i):SV_Target{float4 result=0;
float2 u_xlat0;
bool u_xlatb0;
float4 u_xlat16_1;
float4 u_xlat16_2;
float u_xlat3;
bool u_xlatb3;
bool u_xlatb6;

    u_xlat0.x = log2(_HdrMultiply);
    u_xlat0.x = u_xlat0.x * 0.416666657;
    u_xlat0.x = exp2(u_xlat0.x);
    u_xlat0.x = u_xlat0.x * 1.05499995 + -0.0549999997;
    u_xlat0.x = max(u_xlat0.x, 0.0);
    u_xlat16_1 = tex2D(_MainTex, i.vs_TEXCOORD0.xy);
    u_xlatb3 = 0.0<_SingleChannel;
    u_xlat16_2.xyz = (bool(u_xlatb3)) ? float3(1.0, 1.0, 1.0) : u_xlat16_1.xyz;
    u_xlat16_2.w = (u_xlatb3) ? u_xlat16_1.x : u_xlat16_1.w;
    u_xlat16_1 = u_xlat16_2 * i.vs_COLOR0;
    u_xlat16_2.xyz = u_xlat0.xxx * u_xlat16_1.xyz;
    u_xlatb0 = 0.0<_HdrMultiply;
    result.xyz = (bool(u_xlatb0)) ? u_xlat16_2.xyz : u_xlat16_1.xyz;
    u_xlat0.xy = i.vs_TEXCOORD3.xy / i.vs_TEXCOORD3.ww;
    u_xlat0.x = tex2D(_CameraDepthTexture, u_xlat0.xy).x;
    u_xlat3 = _ZBufferParams.z * u_xlat0.x + _ZBufferParams.w;
    u_xlat0.x = u_xlat0.x * _ProjectionParams.z + _ProjectionParams.y;
    u_xlat3 = float(1.0) / u_xlat3;
    u_xlatb6 = unity_OrthoParams.w==1.0;
    u_xlat0.x = (u_xlatb6) ? u_xlat0.x : u_xlat3;
    u_xlat0.x = u_xlat0.x + (-_SoftParticlesFadeDistanceNear);
    u_xlat0.x = u_xlat0.x + (-i.vs_TEXCOORD3.z);
    u_xlat0.x = u_xlat0.x * _SoftParticlesFadeDistanceFar;
    u_xlat0.x = clamp(u_xlat0.x, 0.0, 1.0);
    u_xlat0.x = u_xlat0.x * u_xlat16_1.w;
    result.w = min(u_xlat0.x, 1.0);
    return result;

}

#elif defined(SOFTPARTICLES_ON) && defined(_ALPHABLEND_ON) && !defined(_ALPHAMODULATE_ON) && !defined(_ALPHAPREMULTIPLY_ON) && !defined(_ALPHATEST_ON) && !defined(_CFXR_ADDITIVE) && defined(_CFXR_DISSOLVE) && !defined(_CFXR_EDGE_FADING) && !defined(_CFXR_FONT_COLORS) && !defined(_CFXR_LIGHTING_ALL) && !defined(_CFXR_LIGHTING_BACK) && !defined(_CFXR_LIGHTING_WPOS_OFFSET) && defined(_CFXR_OVERLAYTEX_1X) && !defined(_CFXR_SECONDCOLOR_LERP) && !defined(_CFXR_UV_DISTORTION) && !defined(_EMISSION) && !defined(_FADING_ON) && !defined(_FLIPBOOK_BLENDING) && !defined(_NORMALMAP)
// Original GLES program 84; SOFTPARTICLES_ON,_CFXR_DISSOLVE,_CFXR_OVERLAYTEX_1X,_ALPHABLEND_ON
float4 _OverlayTex_Scroll;
float _SingleChannel;
float _UseDissolveOffsetUV;
float _CFXR_OVERLAYBLEND;
float _InvertDissolveTex;
float _DoubleDissolve;
float2 _DissolveScroll;
float _DissolveSmooth;
float _HdrMultiply;
float4 _DissolveTex_ST;
sampler2D _MainTex;
sampler2D _OverlayTex;
sampler2D _DissolveTex;
struct A{float4 in_POSITION0:POSITION0;float4 in_COLOR0:COLOR0;float4 in_TEXCOORD0:TEXCOORD0;float4 in_TEXCOORD1:TEXCOORD1;};
struct V{float4 vertex:SV_POSITION;float4 vs_COLOR0:TEXCOORD0;float4 vs_TEXCOORD0:TEXCOORD1;float4 vs_TEXCOORD1:TEXCOORD2;};
V vert(A i){V o=(V)0;
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
    o.vs_TEXCOORD1 = i.in_TEXCOORD1;
    return o;

}
float4 frag(V i):SV_Target{float4 result=0;
float2 u_xlat0;
float4 u_xlat16_0;
bool u_xlatb0;
float3 u_xlat16_1;
float4 u_xlat16_2;
float2 u_xlat3;
float4 u_xlat16_3;
float u_xlat4;
bool2 u_xlatb4;
float u_xlat16_5;
float u_xlat6;
float u_xlat16_7;
float2 u_xlat12;
bool2 u_xlatb12;
float u_xlat16_13;
float u_xlat16_19;

    u_xlat0.xy = _Time.yy * float2(_DissolveScroll.x, _DissolveScroll.y);
    u_xlat0.xy = frac(u_xlat0.xy);
    u_xlat12.xy = i.vs_TEXCOORD0.xy * _DissolveTex_ST.xy + _DissolveTex_ST.zw;
    u_xlat0.xy = u_xlat0.xy + u_xlat12.xy;
    u_xlatb12.xy = lessThan(float4(0.0, 0.0, 0.0, 0.0), float4(_SingleChannel, _UseDissolveOffsetUV, _SingleChannel, _UseDissolveOffsetUV)).xy;
    u_xlat0.xy = (u_xlatb12.y) ? u_xlat0.xy : i.vs_TEXCOORD0.xy;
    u_xlat16_0.x = tex2D(_DissolveTex, u_xlat0.xy).x;
    u_xlat16_1.x = u_xlat16_0.x * 2.0 + -1.0;
    u_xlat6 = u_xlat16_1.x * i.vs_TEXCOORD1.z + i.vs_TEXCOORD0.x;
    u_xlat16_1.x = (u_xlatb12.y) ? u_xlat6 : u_xlat16_0.x;
    u_xlat16_7 = (-u_xlat16_1.x) + 1.0;
    u_xlatb0 = 0.0>=_InvertDissolveTex;
    u_xlat16_1.x = (u_xlatb0) ? u_xlat16_7 : u_xlat16_1.x;
    u_xlat16_7 = u_xlat16_1.x + _DissolveSmooth;
    u_xlat16_1.x = u_xlat16_1.x + (-_DissolveSmooth);
    u_xlat16_7 = (-u_xlat16_1.x) + u_xlat16_7;
    u_xlat16_7 = float(1.0) / u_xlat16_7;
    u_xlat16_13 = _DissolveSmooth * 2.0 + 1.0;
    u_xlat16_13 = i.vs_TEXCOORD1.x * u_xlat16_13 + (-_DissolveSmooth);
    u_xlat16_19 = (-u_xlat16_1.x) + u_xlat16_13;
    u_xlat16_19 = u_xlat16_7 * u_xlat16_19;
    u_xlat16_19 = clamp(u_xlat16_19, 0.0, 1.0);
    u_xlat16_2.x = u_xlat16_19 * -2.0 + 3.0;
    u_xlat16_19 = u_xlat16_19 * u_xlat16_19;
    u_xlat16_19 = u_xlat16_19 * u_xlat16_2.x;
    u_xlat0.xy = _Time.yy * _OverlayTex_Scroll.xy;
    u_xlat0.xy = frac(u_xlat0.xy);
    u_xlat3.xy = i.vs_TEXCOORD0.zw + i.vs_TEXCOORD0.xy;
    u_xlat0.xy = u_xlat3.xy * _OverlayTex_Scroll.zz + u_xlat0.xy;
    u_xlat16_0.x = tex2D(_OverlayTex, u_xlat0.xy).x;
    u_xlat16_2 = tex2D(_MainTex, i.vs_TEXCOORD0.xy);
    u_xlat16_3.xyz = (u_xlatb12.x) ? float3(1.0, 1.0, 1.0) : u_xlat16_2.xyz;
    u_xlat16_3.w = (u_xlatb12.x) ? u_xlat16_2.x : u_xlat16_2.w;
    u_xlat16_0 = u_xlat16_0.xxxx * u_xlat16_3;
    u_xlat16_2.xyz = u_xlat16_3.xyz;
    u_xlat16_3.xyz = u_xlat16_0.xyz;
    u_xlatb4.xy = equal(((float4)(_CFXR_OVERLAYBLEND)), float4(2.0, 1.0, 0.0, 0.0)).xy;
    u_xlat16_3 = (u_xlatb4.y) ? u_xlat16_3 : u_xlat16_0;
    u_xlat16_2.w = u_xlat16_0.w;
    u_xlat16_0 = (u_xlatb4.x) ? u_xlat16_2 : u_xlat16_3;
    u_xlat16_0 = u_xlat16_0 * i.vs_COLOR0;
    u_xlat16_19 = u_xlat16_19 * u_xlat16_0.w;
    u_xlatb4.x = 0.0<_DoubleDissolve;
    u_xlat16_5 = (u_xlatb4.x) ? i.vs_TEXCOORD1.y : 0.0;
    u_xlat16_13 = u_xlat16_13 + (-u_xlat16_5);
    u_xlatb4.x = 0.0<u_xlat16_5;
    u_xlat16_1.x = (-u_xlat16_1.x) + u_xlat16_13;
    u_xlat16_1.x = u_xlat16_7 * u_xlat16_1.x;
    u_xlat16_1.x = clamp(u_xlat16_1.x, 0.0, 1.0);
    u_xlat16_7 = u_xlat16_1.x * -2.0 + 3.0;
    u_xlat16_1.x = u_xlat16_1.x * u_xlat16_1.x;
    u_xlat16_1.x = (-u_xlat16_7) * u_xlat16_1.x + u_xlat16_19;
    u_xlat16_1.x = clamp(u_xlat16_1.x, 0.0, 1.0);
    u_xlat16_1.x = (u_xlatb4.x) ? u_xlat16_1.x : u_xlat16_19;
    result.w = min(u_xlat16_1.x, 1.0);
    u_xlat4 = log2(_HdrMultiply);
    u_xlat4 = u_xlat4 * 0.416666657;
    u_xlat4 = exp2(u_xlat4);
    u_xlat4 = u_xlat4 * 1.05499995 + -0.0549999997;
    u_xlat4 = max(u_xlat4, 0.0);
    u_xlat16_1.xyz = u_xlat16_0.xyz * ((float3)(u_xlat4));
    u_xlatb4.x = 0.0<_HdrMultiply;
    result.xyz = (u_xlatb4.x) ? u_xlat16_1.xyz : u_xlat16_0.xyz;
    return result;

}

#elif defined(SOFTPARTICLES_ON) && defined(_ALPHABLEND_ON) && !defined(_ALPHAMODULATE_ON) && !defined(_ALPHAPREMULTIPLY_ON) && !defined(_ALPHATEST_ON) && !defined(_CFXR_ADDITIVE) && !defined(_CFXR_DISSOLVE) && !defined(_CFXR_EDGE_FADING) && !defined(_CFXR_FONT_COLORS) && !defined(_CFXR_LIGHTING_ALL) && !defined(_CFXR_LIGHTING_BACK) && !defined(_CFXR_LIGHTING_WPOS_OFFSET) && !defined(_CFXR_OVERLAYTEX_1X) && !defined(_CFXR_SECONDCOLOR_LERP) && !defined(_CFXR_UV_DISTORTION) && !defined(_EMISSION) && defined(_FADING_ON) && defined(_FLIPBOOK_BLENDING) && !defined(_NORMALMAP)
// Original GLES program 86; SOFTPARTICLES_ON,_FADING_ON,_FLIPBOOK_BLENDING,_ALPHABLEND_ON
float _SingleChannel;
float _HdrMultiply;
float _SoftParticlesFadeDistanceNear;
float _SoftParticlesFadeDistanceFar;
sampler2D _MainTex;
sampler2D _CameraDepthTexture;
struct A{float4 in_POSITION0:POSITION0;float4 in_COLOR0:COLOR0;float4 in_TEXCOORD0:TEXCOORD0;float4 in_TEXCOORD1:TEXCOORD1;};
struct V{float4 vertex:SV_POSITION;float4 vs_COLOR0:TEXCOORD0;float4 vs_TEXCOORD0:TEXCOORD1;float4 vs_TEXCOORD1:TEXCOORD2;float4 vs_TEXCOORD3:TEXCOORD3;};
V vert(A i){V o=(V)0;
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
    o.vs_TEXCOORD1 = i.in_TEXCOORD1;
    u_xlat2 = u_xlat0.y * transpose(unity_MatrixV)[1].z;
    u_xlat0.x = transpose(unity_MatrixV)[0].z * u_xlat0.x + u_xlat2;
    u_xlat0.x = transpose(unity_MatrixV)[2].z * u_xlat0.z + u_xlat0.x;
    u_xlat0.x = transpose(unity_MatrixV)[3].z * u_xlat0.w + u_xlat0.x;
    o.vs_TEXCOORD3.z = (-u_xlat0.x);
    u_xlat0.x = u_xlat1.y * _ProjectionParams.x;
    u_xlat0.w = u_xlat0.x * 0.5;
    u_xlat0.xz = u_xlat1.xw * float2(0.5, 0.5);
    o.vs_TEXCOORD3.w = u_xlat1.w;
    o.vs_TEXCOORD3.xy = u_xlat0.zz + u_xlat0.xw;
    return o;

}
float4 frag(V i):SV_Target{float4 result=0;
float2 u_xlat0;
bool u_xlatb0;
float4 u_xlat1;
float4 u_xlat16_1;
float4 u_xlat2;
float3 u_xlat16_2;
float4 u_xlat16_3;
float4 u_xlat16_4;
float u_xlat5;
bool u_xlatb5;
bool u_xlatb10;

    u_xlat0.x = log2(_HdrMultiply);
    u_xlat0.x = u_xlat0.x * 0.416666657;
    u_xlat0.x = exp2(u_xlat0.x);
    u_xlat0.x = u_xlat0.x * 1.05499995 + -0.0549999997;
    u_xlat0.x = max(u_xlat0.x, 0.0);
    u_xlat16_1 = tex2D(_MainTex, i.vs_TEXCOORD0.zw);
    u_xlatb5 = 0.0<_SingleChannel;
    u_xlat16_2.xyz = (bool(u_xlatb5)) ? u_xlat16_1.xxx : u_xlat16_1.yzw;
    u_xlat16_3 = tex2D(_MainTex, i.vs_TEXCOORD0.xy);
    u_xlat16_4.w = (u_xlatb5) ? u_xlat16_3.x : u_xlat16_3.w;
    u_xlat16_4.xyz = (bool(u_xlatb5)) ? float3(1.0, 1.0, 1.0) : u_xlat16_3.xyz;
    u_xlat2.yzw = u_xlat16_2.xyz + (-u_xlat16_4.yzw);
    u_xlat2.x = u_xlat16_1.x + (-u_xlat16_4.x);
    u_xlat1 = i.vs_TEXCOORD1.yyyy * u_xlat2 + u_xlat16_4;
    u_xlat16_1 = u_xlat1 * i.vs_COLOR0;
    u_xlat16_4.xyz = u_xlat0.xxx * u_xlat16_1.xyz;
    u_xlatb0 = 0.0<_HdrMultiply;
    result.xyz = (bool(u_xlatb0)) ? u_xlat16_4.xyz : u_xlat16_1.xyz;
    u_xlat0.xy = i.vs_TEXCOORD3.xy / i.vs_TEXCOORD3.ww;
    u_xlat0.x = tex2D(_CameraDepthTexture, u_xlat0.xy).x;
    u_xlat5 = _ZBufferParams.z * u_xlat0.x + _ZBufferParams.w;
    u_xlat0.x = u_xlat0.x * _ProjectionParams.z + _ProjectionParams.y;
    u_xlat5 = float(1.0) / u_xlat5;
    u_xlatb10 = unity_OrthoParams.w==1.0;
    u_xlat0.x = (u_xlatb10) ? u_xlat0.x : u_xlat5;
    u_xlat0.x = u_xlat0.x + (-_SoftParticlesFadeDistanceNear);
    u_xlat0.x = u_xlat0.x + (-i.vs_TEXCOORD3.z);
    u_xlat0.x = u_xlat0.x * _SoftParticlesFadeDistanceFar;
    u_xlat0.x = clamp(u_xlat0.x, 0.0, 1.0);
    u_xlat0.x = u_xlat0.x * u_xlat16_1.w;
    result.w = min(u_xlat0.x, 1.0);
    return result;

}

#elif defined(SOFTPARTICLES_ON) && defined(_ALPHABLEND_ON) && !defined(_ALPHAMODULATE_ON) && !defined(_ALPHAPREMULTIPLY_ON) && defined(_ALPHATEST_ON) && !defined(_CFXR_ADDITIVE) && !defined(_CFXR_DISSOLVE) && defined(_CFXR_EDGE_FADING) && !defined(_CFXR_FONT_COLORS) && !defined(_CFXR_LIGHTING_ALL) && !defined(_CFXR_LIGHTING_BACK) && !defined(_CFXR_LIGHTING_WPOS_OFFSET) && !defined(_CFXR_OVERLAYTEX_1X) && !defined(_CFXR_SECONDCOLOR_LERP) && !defined(_CFXR_UV_DISTORTION) && !defined(_EMISSION) && !defined(_FADING_ON) && !defined(_FLIPBOOK_BLENDING) && !defined(_NORMALMAP)
// Original GLES program 88; SOFTPARTICLES_ON,_CFXR_EDGE_FADING,_ALPHATEST_ON,_ALPHABLEND_ON
float _EdgeFadePow;
float _SingleChannel;
float _HdrMultiply;
float _Cutoff;
sampler2D _MainTex;
struct A{float4 in_POSITION0:POSITION0;float4 in_COLOR0:COLOR0;float4 in_TEXCOORD0:TEXCOORD0;float4 in_TEXCOORD1:TEXCOORD1;float3 in_NORMAL0:NORMAL0;};
struct V{float4 vertex:SV_POSITION;float4 vs_COLOR0:TEXCOORD0;float4 vs_TEXCOORD0:TEXCOORD1;};
V vert(A i){V o=(V)0;
float4 vs_TEXCOORD1;
float4 u_xlat0;
float4 u_xlat1;
float u_xlat6;

    u_xlat0 = i.in_POSITION0.yyyy * transpose(unity_ObjectToWorld)[1];
    u_xlat0 = transpose(unity_ObjectToWorld)[0] * i.in_POSITION0.xxxx + u_xlat0;
    u_xlat0 = transpose(unity_ObjectToWorld)[2] * i.in_POSITION0.zzzz + u_xlat0;
    u_xlat0 = u_xlat0 + transpose(unity_ObjectToWorld)[3];
    u_xlat1 = u_xlat0.yyyy * transpose(unity_MatrixVP)[1];
    u_xlat1 = transpose(unity_MatrixVP)[0] * u_xlat0.xxxx + u_xlat1;
    u_xlat1 = transpose(unity_MatrixVP)[2] * u_xlat0.zzzz + u_xlat1;
    o.vertex = transpose(unity_MatrixVP)[3] * u_xlat0.wwww + u_xlat1;
    u_xlat0.xyz = (-i.in_POSITION0.xyz) + _WorldSpaceCameraPos.xyz;
    u_xlat6 = dot(u_xlat0.xyz, u_xlat0.xyz);
    u_xlat6 = rsqrt(u_xlat6);
    u_xlat0.xyz = ((float3)(u_xlat6)) * u_xlat0.xyz;
    u_xlat0.x = dot(u_xlat0.xyz, i.in_NORMAL0.xyz);
    u_xlat0.x = log2(abs(u_xlat0.x));
    u_xlat0.x = u_xlat0.x * _EdgeFadePow;
    u_xlat0.x = exp2(u_xlat0.x);
    u_xlat0.x = min(u_xlat0.x, 1.0);
    u_xlat0.x = u_xlat0.x * i.in_COLOR0.w;
    o.vs_COLOR0.w = u_xlat0.x;
    o.vs_COLOR0.xyz = i.in_COLOR0.xyz;
    o.vs_TEXCOORD0 = i.in_TEXCOORD0.xyxy;
    vs_TEXCOORD1 = i.in_TEXCOORD1;
    return o;

}
float4 frag(V i):SV_Target{float4 result=0;
float4 u_xlat16_0;
float u_xlat1;
bool u_xlatb1;
float4 u_xlat16_2;

    u_xlat16_0 = tex2D(_MainTex, i.vs_TEXCOORD0.xy);
    u_xlatb1 = 0.0<_SingleChannel;
    u_xlat16_2.w = (u_xlatb1) ? u_xlat16_0.x : u_xlat16_0.w;
    u_xlat16_2.xyz = (bool(u_xlatb1)) ? float3(1.0, 1.0, 1.0) : u_xlat16_0.xyz;
    u_xlat16_0 = u_xlat16_2 * i.vs_COLOR0;
    u_xlat16_2.x = u_xlat16_2.w * i.vs_COLOR0.w + (-_Cutoff);
    u_xlatb1 = u_xlat16_2.x<0.0;
    if(u_xlatb1){discard;}
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

#elif defined(SOFTPARTICLES_ON) && defined(_ALPHABLEND_ON) && !defined(_ALPHAMODULATE_ON) && !defined(_ALPHAPREMULTIPLY_ON) && defined(_ALPHATEST_ON) && !defined(_CFXR_ADDITIVE) && !defined(_CFXR_DISSOLVE) && !defined(_CFXR_EDGE_FADING) && !defined(_CFXR_FONT_COLORS) && !defined(_CFXR_LIGHTING_ALL) && !defined(_CFXR_LIGHTING_BACK) && !defined(_CFXR_LIGHTING_WPOS_OFFSET) && !defined(_CFXR_OVERLAYTEX_1X) && !defined(_CFXR_SECONDCOLOR_LERP) && !defined(_CFXR_UV_DISTORTION) && !defined(_EMISSION) && defined(_FADING_ON) && !defined(_FLIPBOOK_BLENDING) && !defined(_NORMALMAP)
// Original GLES program 91; SOFTPARTICLES_ON,_FADING_ON,_ALPHATEST_ON,_ALPHABLEND_ON
float _SingleChannel;
float _HdrMultiply;
float _Cutoff;
float _SoftParticlesFadeDistanceNear;
float _SoftParticlesFadeDistanceFar;
sampler2D _MainTex;
sampler2D _CameraDepthTexture;
struct A{float4 in_POSITION0:POSITION0;float4 in_COLOR0:COLOR0;float4 in_TEXCOORD0:TEXCOORD0;float4 in_TEXCOORD1:TEXCOORD1;};
struct V{float4 vertex:SV_POSITION;float4 vs_COLOR0:TEXCOORD0;float4 vs_TEXCOORD0:TEXCOORD1;float4 vs_TEXCOORD3:TEXCOORD2;};
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
    o.vs_TEXCOORD3.z = (-u_xlat0.x);
    u_xlat0.x = u_xlat1.y * _ProjectionParams.x;
    u_xlat0.w = u_xlat0.x * 0.5;
    u_xlat0.xz = u_xlat1.xw * float2(0.5, 0.5);
    o.vs_TEXCOORD3.w = u_xlat1.w;
    o.vs_TEXCOORD3.xy = u_xlat0.zz + u_xlat0.xw;
    return o;

}
float4 frag(V i):SV_Target{float4 result=0;
float4 u_xlat16_0;
float2 u_xlat1;
bool u_xlatb1;
float4 u_xlat16_2;
float u_xlat4;
bool u_xlatb7;

    u_xlat16_0 = tex2D(_MainTex, i.vs_TEXCOORD0.xy);
    u_xlatb1 = 0.0<_SingleChannel;
    u_xlat16_2.w = (u_xlatb1) ? u_xlat16_0.x : u_xlat16_0.w;
    u_xlat16_2.xyz = (bool(u_xlatb1)) ? float3(1.0, 1.0, 1.0) : u_xlat16_0.xyz;
    u_xlat16_0 = u_xlat16_2 * i.vs_COLOR0;
    u_xlat16_2.x = u_xlat16_2.w * i.vs_COLOR0.w + (-_Cutoff);
    u_xlatb1 = u_xlat16_2.x<0.0;
    if(u_xlatb1){discard;}
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

#elif defined(SOFTPARTICLES_ON) && !defined(_ALPHABLEND_ON) && defined(_ALPHAMODULATE_ON) && !defined(_ALPHAPREMULTIPLY_ON) && !defined(_ALPHATEST_ON) && !defined(_CFXR_ADDITIVE) && defined(_CFXR_DISSOLVE) && !defined(_CFXR_EDGE_FADING) && !defined(_CFXR_FONT_COLORS) && !defined(_CFXR_LIGHTING_ALL) && !defined(_CFXR_LIGHTING_BACK) && !defined(_CFXR_LIGHTING_WPOS_OFFSET) && !defined(_CFXR_OVERLAYTEX_1X) && !defined(_CFXR_SECONDCOLOR_LERP) && !defined(_CFXR_UV_DISTORTION) && !defined(_EMISSION) && defined(_FADING_ON) && !defined(_FLIPBOOK_BLENDING) && !defined(_NORMALMAP)
// Original GLES program 97; SOFTPARTICLES_ON,_CFXR_DISSOLVE,_FADING_ON,_ALPHAMODULATE_ON
float _SingleChannel;
float _UseDissolveOffsetUV;
float _InvertDissolveTex;
float _DoubleDissolve;
float2 _DissolveScroll;
float _DissolveSmooth;
float _HdrMultiply;
float _SoftParticlesFadeDistanceNear;
float _SoftParticlesFadeDistanceFar;
float4 _DissolveTex_ST;
sampler2D _MainTex;
sampler2D _DissolveTex;
sampler2D _CameraDepthTexture;
struct A{float4 in_POSITION0:POSITION0;float4 in_COLOR0:COLOR0;float4 in_TEXCOORD0:TEXCOORD0;float4 in_TEXCOORD1:TEXCOORD1;};
struct V{float4 vertex:SV_POSITION;float4 vs_COLOR0:TEXCOORD0;float4 vs_TEXCOORD0:TEXCOORD1;float4 vs_TEXCOORD1:TEXCOORD2;float4 vs_TEXCOORD3:TEXCOORD3;};
V vert(A i){V o=(V)0;
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
    o.vs_TEXCOORD1 = i.in_TEXCOORD1;
    u_xlat2 = u_xlat0.y * transpose(unity_MatrixV)[1].z;
    u_xlat0.x = transpose(unity_MatrixV)[0].z * u_xlat0.x + u_xlat2;
    u_xlat0.x = transpose(unity_MatrixV)[2].z * u_xlat0.z + u_xlat0.x;
    u_xlat0.x = transpose(unity_MatrixV)[3].z * u_xlat0.w + u_xlat0.x;
    o.vs_TEXCOORD3.z = (-u_xlat0.x);
    u_xlat0.x = u_xlat1.y * _ProjectionParams.x;
    u_xlat0.w = u_xlat0.x * 0.5;
    u_xlat0.xz = u_xlat1.xw * float2(0.5, 0.5);
    o.vs_TEXCOORD3.w = u_xlat1.w;
    o.vs_TEXCOORD3.xy = u_xlat0.zz + u_xlat0.xw;
    return o;

}
float4 frag(V i):SV_Target{float4 result=0;
float2 u_xlat0;
float4 u_xlat16_0;
bool u_xlatb0;
float u_xlat16_1;
float4 u_xlat16_2;
float4 u_xlat16_3;
float3 u_xlat4;
bool u_xlatb4;
float u_xlat5;
float3 u_xlat16_6;
float u_xlat9;
float2 u_xlat10;
bool2 u_xlatb10;
float u_xlat16_11;
bool u_xlatb14;
float u_xlat16_16;

    u_xlat0.xy = _Time.yy * float2(_DissolveScroll.x, _DissolveScroll.y);
    u_xlat0.xy = frac(u_xlat0.xy);
    u_xlat10.xy = i.vs_TEXCOORD0.xy * _DissolveTex_ST.xy + _DissolveTex_ST.zw;
    u_xlat0.xy = u_xlat0.xy + u_xlat10.xy;
    u_xlatb10.xy = lessThan(float4(0.0, 0.0, 0.0, 0.0), float4(_SingleChannel, _UseDissolveOffsetUV, _SingleChannel, _UseDissolveOffsetUV)).xy;
    u_xlat0.xy = (u_xlatb10.y) ? u_xlat0.xy : i.vs_TEXCOORD0.xy;
    u_xlat16_0.x = tex2D(_DissolveTex, u_xlat0.xy).x;
    u_xlat16_1 = u_xlat16_0.x * 2.0 + -1.0;
    u_xlat5 = u_xlat16_1 * i.vs_TEXCOORD1.z + i.vs_TEXCOORD0.x;
    u_xlat16_1 = (u_xlatb10.y) ? u_xlat5 : u_xlat16_0.x;
    u_xlat16_6.x = (-u_xlat16_1) + 1.0;
    u_xlatb0 = 0.0>=_InvertDissolveTex;
    u_xlat16_1 = (u_xlatb0) ? u_xlat16_6.x : u_xlat16_1;
    u_xlat16_6.x = u_xlat16_1 + _DissolveSmooth;
    u_xlat16_1 = u_xlat16_1 + (-_DissolveSmooth);
    u_xlat16_6.x = (-u_xlat16_1) + u_xlat16_6.x;
    u_xlat16_6.x = float(1.0) / u_xlat16_6.x;
    u_xlat16_11 = _DissolveSmooth * 2.0 + 1.0;
    u_xlat16_11 = i.vs_TEXCOORD1.x * u_xlat16_11 + (-_DissolveSmooth);
    u_xlat16_16 = (-u_xlat16_1) + u_xlat16_11;
    u_xlat16_16 = u_xlat16_6.x * u_xlat16_16;
    u_xlat16_16 = clamp(u_xlat16_16, 0.0, 1.0);
    u_xlat16_2.x = u_xlat16_16 * -2.0 + 3.0;
    u_xlat16_16 = u_xlat16_16 * u_xlat16_16;
    u_xlat16_16 = u_xlat16_16 * u_xlat16_2.x;
    u_xlat16_2 = tex2D(_MainTex, i.vs_TEXCOORD0.xy);
    u_xlat16_3.xyz = (u_xlatb10.x) ? float3(1.0, 1.0, 1.0) : u_xlat16_2.xyz;
    u_xlat16_3.w = (u_xlatb10.x) ? u_xlat16_2.x : u_xlat16_2.w;
    u_xlat16_0 = u_xlat16_3 * i.vs_COLOR0;
    u_xlat16_16 = u_xlat16_16 * u_xlat16_0.w;
    u_xlatb4 = 0.0<_DoubleDissolve;
    u_xlat16_3.x = (u_xlatb4) ? i.vs_TEXCOORD1.y : 0.0;
    u_xlat16_11 = u_xlat16_11 + (-u_xlat16_3.x);
    u_xlatb4 = 0.0<u_xlat16_3.x;
    u_xlat16_1 = (-u_xlat16_1) + u_xlat16_11;
    u_xlat16_1 = u_xlat16_6.x * u_xlat16_1;
    u_xlat16_1 = clamp(u_xlat16_1, 0.0, 1.0);
    u_xlat16_6.x = u_xlat16_1 * -2.0 + 3.0;
    u_xlat16_1 = u_xlat16_1 * u_xlat16_1;
    u_xlat16_1 = (-u_xlat16_6.x) * u_xlat16_1 + u_xlat16_16;
    u_xlat16_1 = clamp(u_xlat16_1, 0.0, 1.0);
    u_xlat16_1 = (u_xlatb4) ? u_xlat16_1 : u_xlat16_16;
    u_xlat4.x = log2(_HdrMultiply);
    u_xlat4.x = u_xlat4.x * 0.416666657;
    u_xlat4.x = exp2(u_xlat4.x);
    u_xlat4.x = u_xlat4.x * 1.05499995 + -0.0549999997;
    u_xlat4.x = max(u_xlat4.x, 0.0);
    u_xlat16_6.xyz = u_xlat16_0.xyz * u_xlat4.xxx;
    u_xlatb4 = 0.0<_HdrMultiply;
    u_xlat16_6.xyz = (bool(u_xlatb4)) ? u_xlat16_6.xyz : u_xlat16_0.xyz;
    u_xlat4.xyz = u_xlat16_6.xyz + float3(-1.0, -1.0, -1.0);
    u_xlat4.xyz = ((float3)(u_xlat16_1)) * u_xlat4.xyz + float3(1.0, 1.0, 1.0);
    result.xyz = u_xlat4.xyz;
    u_xlat4.xy = i.vs_TEXCOORD3.xy / i.vs_TEXCOORD3.ww;
    u_xlat4.x = tex2D(_CameraDepthTexture, u_xlat4.xy).x;
    u_xlat9 = _ZBufferParams.z * u_xlat4.x + _ZBufferParams.w;
    u_xlat4.x = u_xlat4.x * _ProjectionParams.z + _ProjectionParams.y;
    u_xlat9 = float(1.0) / u_xlat9;
    u_xlatb14 = unity_OrthoParams.w==1.0;
    u_xlat4.x = (u_xlatb14) ? u_xlat4.x : u_xlat9;
    u_xlat4.x = u_xlat4.x + (-_SoftParticlesFadeDistanceNear);
    u_xlat4.x = u_xlat4.x + (-i.vs_TEXCOORD3.z);
    u_xlat4.x = u_xlat4.x * _SoftParticlesFadeDistanceFar;
    u_xlat4.x = clamp(u_xlat4.x, 0.0, 1.0);
    u_xlat4.x = u_xlat16_1 * u_xlat4.x;
    result.w = min(u_xlat4.x, 1.0);
    return result;

}

#elif defined(SOFTPARTICLES_ON) && !defined(_ALPHABLEND_ON) && defined(_ALPHAMODULATE_ON) && !defined(_ALPHAPREMULTIPLY_ON) && !defined(_ALPHATEST_ON) && !defined(_CFXR_ADDITIVE) && !defined(_CFXR_DISSOLVE) && defined(_CFXR_EDGE_FADING) && !defined(_CFXR_FONT_COLORS) && !defined(_CFXR_LIGHTING_ALL) && !defined(_CFXR_LIGHTING_BACK) && !defined(_CFXR_LIGHTING_WPOS_OFFSET) && !defined(_CFXR_OVERLAYTEX_1X) && !defined(_CFXR_SECONDCOLOR_LERP) && defined(_CFXR_UV_DISTORTION) && !defined(_EMISSION) && !defined(_FADING_ON) && !defined(_FLIPBOOK_BLENDING) && !defined(_NORMALMAP)
// Original GLES program 98; SOFTPARTICLES_ON,_CFXR_EDGE_FADING,_CFXR_UV_DISTORTION,_ALPHAMODULATE_ON
float _EdgeFadePow;
float _SingleChannel;
float _UseUV2Distortion;
float _UVDistortionAdd;
float4 _DistortScrolling;
float _Distort;
float _FadeAlongU;
float _HdrMultiply;
sampler2D _DistortTex;
sampler2D _MainTex;
struct A{float4 in_POSITION0:POSITION0;float4 in_COLOR0:COLOR0;float4 in_TEXCOORD0:TEXCOORD0;float4 in_TEXCOORD1:TEXCOORD1;float3 in_NORMAL0:NORMAL0;};
struct V{float4 vertex:SV_POSITION;float4 vs_COLOR0:TEXCOORD0;float4 vs_TEXCOORD0:TEXCOORD1;float4 vs_TEXCOORD1:TEXCOORD2;};
V vert(A i){V o=(V)0;
float4 u_xlat0;
float4 u_xlat1;
float u_xlat6;

    u_xlat0 = i.in_POSITION0.yyyy * transpose(unity_ObjectToWorld)[1];
    u_xlat0 = transpose(unity_ObjectToWorld)[0] * i.in_POSITION0.xxxx + u_xlat0;
    u_xlat0 = transpose(unity_ObjectToWorld)[2] * i.in_POSITION0.zzzz + u_xlat0;
    u_xlat0 = u_xlat0 + transpose(unity_ObjectToWorld)[3];
    u_xlat1 = u_xlat0.yyyy * transpose(unity_MatrixVP)[1];
    u_xlat1 = transpose(unity_MatrixVP)[0] * u_xlat0.xxxx + u_xlat1;
    u_xlat1 = transpose(unity_MatrixVP)[2] * u_xlat0.zzzz + u_xlat1;
    o.vertex = transpose(unity_MatrixVP)[3] * u_xlat0.wwww + u_xlat1;
    u_xlat0.xyz = (-i.in_POSITION0.xyz) + _WorldSpaceCameraPos.xyz;
    u_xlat6 = dot(u_xlat0.xyz, u_xlat0.xyz);
    u_xlat6 = rsqrt(u_xlat6);
    u_xlat0.xyz = ((float3)(u_xlat6)) * u_xlat0.xyz;
    u_xlat0.x = dot(u_xlat0.xyz, i.in_NORMAL0.xyz);
    u_xlat0.x = log2(abs(u_xlat0.x));
    u_xlat0.x = u_xlat0.x * _EdgeFadePow;
    u_xlat0.x = exp2(u_xlat0.x);
    u_xlat0.x = min(u_xlat0.x, 1.0);
    u_xlat0.x = u_xlat0.x * i.in_COLOR0.w;
    o.vs_COLOR0.w = u_xlat0.x;
    o.vs_COLOR0.xyz = i.in_COLOR0.xyz;
    o.vs_TEXCOORD0 = i.in_TEXCOORD0.xyxy;
    o.vs_TEXCOORD1 = i.in_TEXCOORD1;
    return o;

}
float4 frag(V i):SV_Target{float4 result=0;
float3 u_xlat0;
float4 u_xlat1;
float4 u_xlat16_1;
bool3 u_xlatb1;
bool2 u_xlatb2;
float4 u_xlat16_3;
float4 u_xlat16_4;
float2 u_xlat5;
float2 u_xlat16_5;
float u_xlat15;

    u_xlat0.x = log2(_HdrMultiply);
    u_xlat0.x = u_xlat0.x * 0.416666657;
    u_xlat0.x = exp2(u_xlat0.x);
    u_xlat0.x = u_xlat0.x * 1.05499995 + -0.0549999997;
    u_xlat0.x = max(u_xlat0.x, 0.0);
    u_xlat5.xy = _Time.yy * _DistortScrolling.xy;
    u_xlat5.xy = frac(u_xlat5.xy);
    u_xlatb1.xyz = lessThan(float4(0.0, 0.0, 0.0, 0.0), float4(_UseUV2Distortion, _UVDistortionAdd, _SingleChannel, _UseUV2Distortion)).xyz;
    u_xlat1.xw = (u_xlatb1.x) ? i.vs_TEXCOORD1.xy : i.vs_TEXCOORD0.xy;
    u_xlat1.xw = u_xlat1.xw * _DistortScrolling.zw + i.vs_TEXCOORD0.zw;
    u_xlat5.xy = u_xlat5.xy + u_xlat1.xw;
    u_xlat16_5.xy = tex2D(_DistortTex, u_xlat5.xy).xy;
    u_xlat1.xw = u_xlat16_5.xy * float2(2.0, 2.0) + float2(-1.0, -1.0);
    u_xlat5.xy = u_xlat16_5.xy + (-i.vs_TEXCOORD0.xy);
    u_xlat5.xy = ((float2)(_Distort)) * u_xlat5.xy + i.vs_TEXCOORD0.xy;
    u_xlat1.xw = u_xlat1.xw * ((float2)(_Distort)) + i.vs_TEXCOORD0.xy;
    u_xlat5.xy = (u_xlatb1.y) ? u_xlat1.xw : u_xlat5.xy;
    u_xlat1.xy = u_xlat5.xy + (-i.vs_TEXCOORD0.xy);
    u_xlat15 = i.vs_TEXCOORD0.y * 0.5;
    u_xlat1.xy = ((float2)(u_xlat15)) * u_xlat1.xy + i.vs_TEXCOORD0.xy;
    u_xlatb2.xy = lessThan(float4(0.0, 0.0, 0.0, 0.0), float4(_FadeAlongU, _HdrMultiply, _FadeAlongU, _FadeAlongU)).xy;
    u_xlat5.xy = (u_xlatb2.x) ? u_xlat1.xy : u_xlat5.xy;
    u_xlat16_3 = tex2D(_MainTex, u_xlat5.xy);
    u_xlat16_4.xyz = (u_xlatb1.z) ? float3(1.0, 1.0, 1.0) : u_xlat16_3.xyz;
    u_xlat16_4.w = (u_xlatb1.z) ? u_xlat16_3.x : u_xlat16_3.w;
    u_xlat16_1 = u_xlat16_4 * i.vs_COLOR0;
    u_xlat16_4.xyz = u_xlat0.xxx * u_xlat16_1.xyz;
    u_xlat16_4.xyz = (u_xlatb2.y) ? u_xlat16_4.xyz : u_xlat16_1.xyz;
    u_xlat0.xyz = u_xlat16_4.xyz + float3(-1.0, -1.0, -1.0);
    u_xlat0.xyz = u_xlat16_1.www * u_xlat0.xyz + float3(1.0, 1.0, 1.0);
    result.w = min(u_xlat16_1.w, 1.0);
    result.xyz = u_xlat0.xyz;
    return result;

}

#elif defined(SOFTPARTICLES_ON) && !defined(_ALPHABLEND_ON) && !defined(_ALPHAMODULATE_ON) && !defined(_ALPHAPREMULTIPLY_ON) && !defined(_ALPHATEST_ON) && defined(_CFXR_ADDITIVE) && defined(_CFXR_DISSOLVE) && !defined(_CFXR_EDGE_FADING) && !defined(_CFXR_FONT_COLORS) && !defined(_CFXR_LIGHTING_ALL) && !defined(_CFXR_LIGHTING_BACK) && !defined(_CFXR_LIGHTING_WPOS_OFFSET) && !defined(_CFXR_OVERLAYTEX_1X) && !defined(_CFXR_SECONDCOLOR_LERP) && !defined(_CFXR_UV_DISTORTION) && !defined(_EMISSION) && defined(_FADING_ON) && !defined(_FLIPBOOK_BLENDING) && !defined(_NORMALMAP)
// Original GLES program 101; SOFTPARTICLES_ON,_CFXR_DISSOLVE,_FADING_ON,_CFXR_ADDITIVE
float _SingleChannel;
float _UseDissolveOffsetUV;
float _InvertDissolveTex;
float _DoubleDissolve;
float2 _DissolveScroll;
float _DissolveSmooth;
float _HdrMultiply;
float _SoftParticlesFadeDistanceNear;
float _SoftParticlesFadeDistanceFar;
float4 _DissolveTex_ST;
sampler2D _MainTex;
sampler2D _DissolveTex;
sampler2D _CameraDepthTexture;
struct A{float4 in_POSITION0:POSITION0;float4 in_COLOR0:COLOR0;float4 in_TEXCOORD0:TEXCOORD0;float4 in_TEXCOORD1:TEXCOORD1;};
struct V{float4 vertex:SV_POSITION;float4 vs_COLOR0:TEXCOORD0;float4 vs_TEXCOORD0:TEXCOORD1;float4 vs_TEXCOORD1:TEXCOORD2;float4 vs_TEXCOORD3:TEXCOORD3;};
V vert(A i){V o=(V)0;
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
    o.vs_TEXCOORD1 = i.in_TEXCOORD1;
    u_xlat2 = u_xlat0.y * transpose(unity_MatrixV)[1].z;
    u_xlat0.x = transpose(unity_MatrixV)[0].z * u_xlat0.x + u_xlat2;
    u_xlat0.x = transpose(unity_MatrixV)[2].z * u_xlat0.z + u_xlat0.x;
    u_xlat0.x = transpose(unity_MatrixV)[3].z * u_xlat0.w + u_xlat0.x;
    o.vs_TEXCOORD3.z = (-u_xlat0.x);
    u_xlat0.x = u_xlat1.y * _ProjectionParams.x;
    u_xlat0.w = u_xlat0.x * 0.5;
    u_xlat0.xz = u_xlat1.xw * float2(0.5, 0.5);
    o.vs_TEXCOORD3.w = u_xlat1.w;
    o.vs_TEXCOORD3.xy = u_xlat0.zz + u_xlat0.xw;
    return o;

}
float4 frag(V i):SV_Target{float4 result=0;
float2 u_xlat0;
float4 u_xlat16_0;
bool u_xlatb0;
float3 u_xlat16_1;
float4 u_xlat16_2;
float4 u_xlat16_3;
float2 u_xlat4;
bool u_xlatb4;
float u_xlat5;
float u_xlat16_6;
float u_xlat9;
float2 u_xlat10;
bool2 u_xlatb10;
float u_xlat16_11;
bool u_xlatb14;
float u_xlat16_16;

    u_xlat0.xy = _Time.yy * float2(_DissolveScroll.x, _DissolveScroll.y);
    u_xlat0.xy = frac(u_xlat0.xy);
    u_xlat10.xy = i.vs_TEXCOORD0.xy * _DissolveTex_ST.xy + _DissolveTex_ST.zw;
    u_xlat0.xy = u_xlat0.xy + u_xlat10.xy;
    u_xlatb10.xy = lessThan(float4(0.0, 0.0, 0.0, 0.0), float4(_SingleChannel, _UseDissolveOffsetUV, _SingleChannel, _UseDissolveOffsetUV)).xy;
    u_xlat0.xy = (u_xlatb10.y) ? u_xlat0.xy : i.vs_TEXCOORD0.xy;
    u_xlat16_0.x = tex2D(_DissolveTex, u_xlat0.xy).x;
    u_xlat16_1.x = u_xlat16_0.x * 2.0 + -1.0;
    u_xlat5 = u_xlat16_1.x * i.vs_TEXCOORD1.z + i.vs_TEXCOORD0.x;
    u_xlat16_1.x = (u_xlatb10.y) ? u_xlat5 : u_xlat16_0.x;
    u_xlat16_6 = (-u_xlat16_1.x) + 1.0;
    u_xlatb0 = 0.0>=_InvertDissolveTex;
    u_xlat16_1.x = (u_xlatb0) ? u_xlat16_6 : u_xlat16_1.x;
    u_xlat16_6 = u_xlat16_1.x + _DissolveSmooth;
    u_xlat16_1.x = u_xlat16_1.x + (-_DissolveSmooth);
    u_xlat16_6 = (-u_xlat16_1.x) + u_xlat16_6;
    u_xlat16_6 = float(1.0) / u_xlat16_6;
    u_xlat16_11 = _DissolveSmooth * 2.0 + 1.0;
    u_xlat16_11 = i.vs_TEXCOORD1.x * u_xlat16_11 + (-_DissolveSmooth);
    u_xlat16_16 = (-u_xlat16_1.x) + u_xlat16_11;
    u_xlat16_16 = u_xlat16_6 * u_xlat16_16;
    u_xlat16_16 = clamp(u_xlat16_16, 0.0, 1.0);
    u_xlat16_2.x = u_xlat16_16 * -2.0 + 3.0;
    u_xlat16_16 = u_xlat16_16 * u_xlat16_16;
    u_xlat16_16 = u_xlat16_16 * u_xlat16_2.x;
    u_xlat16_2 = tex2D(_MainTex, i.vs_TEXCOORD0.xy);
    u_xlat16_3.xyz = (u_xlatb10.x) ? float3(1.0, 1.0, 1.0) : u_xlat16_2.xyz;
    u_xlat16_3.w = (u_xlatb10.x) ? u_xlat16_2.x : u_xlat16_2.w;
    u_xlat16_0 = u_xlat16_3 * i.vs_COLOR0;
    u_xlat16_16 = u_xlat16_16 * u_xlat16_0.w;
    u_xlatb4 = 0.0<_DoubleDissolve;
    u_xlat16_3.x = (u_xlatb4) ? i.vs_TEXCOORD1.y : 0.0;
    u_xlat16_11 = u_xlat16_11 + (-u_xlat16_3.x);
    u_xlatb4 = 0.0<u_xlat16_3.x;
    u_xlat16_1.x = (-u_xlat16_1.x) + u_xlat16_11;
    u_xlat16_1.x = u_xlat16_6 * u_xlat16_1.x;
    u_xlat16_1.x = clamp(u_xlat16_1.x, 0.0, 1.0);
    u_xlat16_6 = u_xlat16_1.x * -2.0 + 3.0;
    u_xlat16_1.x = u_xlat16_1.x * u_xlat16_1.x;
    u_xlat16_1.x = (-u_xlat16_6) * u_xlat16_1.x + u_xlat16_16;
    u_xlat16_1.x = clamp(u_xlat16_1.x, 0.0, 1.0);
    u_xlat16_1.x = (u_xlatb4) ? u_xlat16_1.x : u_xlat16_16;
    u_xlat4.xy = i.vs_TEXCOORD3.xy / i.vs_TEXCOORD3.ww;
    u_xlat4.x = tex2D(_CameraDepthTexture, u_xlat4.xy).x;
    u_xlat9 = _ZBufferParams.z * u_xlat4.x + _ZBufferParams.w;
    u_xlat4.x = u_xlat4.x * _ProjectionParams.z + _ProjectionParams.y;
    u_xlat9 = float(1.0) / u_xlat9;
    u_xlatb14 = unity_OrthoParams.w==1.0;
    u_xlat4.x = (u_xlatb14) ? u_xlat4.x : u_xlat9;
    u_xlat4.x = u_xlat4.x + (-_SoftParticlesFadeDistanceNear);
    u_xlat4.x = u_xlat4.x + (-i.vs_TEXCOORD3.z);
    u_xlat4.x = u_xlat4.x * _SoftParticlesFadeDistanceFar;
    u_xlat4.x = clamp(u_xlat4.x, 0.0, 1.0);
    u_xlat4.x = u_xlat16_1.x * u_xlat4.x;
    result.w = min(u_xlat4.x, 1.0);
    u_xlat4.x = log2(_HdrMultiply);
    u_xlat4.x = u_xlat4.x * 0.416666657;
    u_xlat4.x = exp2(u_xlat4.x);
    u_xlat4.x = u_xlat4.x * 1.05499995 + -0.0549999997;
    u_xlat4.x = max(u_xlat4.x, 0.0);
    u_xlat16_1.xyz = u_xlat16_0.xyz * u_xlat4.xxx;
    u_xlatb4 = 0.0<_HdrMultiply;
    result.xyz = (bool(u_xlatb4)) ? u_xlat16_1.xyz : u_xlat16_0.xyz;
    return result;

}

#elif defined(SOFTPARTICLES_ON) && !defined(_ALPHABLEND_ON) && !defined(_ALPHAMODULATE_ON) && !defined(_ALPHAPREMULTIPLY_ON) && defined(_ALPHATEST_ON) && defined(_CFXR_ADDITIVE) && !defined(_CFXR_DISSOLVE) && !defined(_CFXR_EDGE_FADING) && !defined(_CFXR_FONT_COLORS) && !defined(_CFXR_LIGHTING_ALL) && !defined(_CFXR_LIGHTING_BACK) && !defined(_CFXR_LIGHTING_WPOS_OFFSET) && !defined(_CFXR_OVERLAYTEX_1X) && !defined(_CFXR_SECONDCOLOR_LERP) && !defined(_CFXR_UV_DISTORTION) && !defined(_EMISSION) && defined(_FADING_ON) && !defined(_FLIPBOOK_BLENDING) && !defined(_NORMALMAP)
// Original GLES program 104; SOFTPARTICLES_ON,_FADING_ON,_ALPHATEST_ON,_CFXR_ADDITIVE
float _SingleChannel;
float _HdrMultiply;
float _Cutoff;
float _SoftParticlesFadeDistanceNear;
float _SoftParticlesFadeDistanceFar;
sampler2D _MainTex;
sampler2D _CameraDepthTexture;
struct A{float4 in_POSITION0:POSITION0;float4 in_COLOR0:COLOR0;float4 in_TEXCOORD0:TEXCOORD0;float4 in_TEXCOORD1:TEXCOORD1;};
struct V{float4 vertex:SV_POSITION;float4 vs_COLOR0:TEXCOORD0;float4 vs_TEXCOORD0:TEXCOORD1;float4 vs_TEXCOORD3:TEXCOORD2;};
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
    o.vs_TEXCOORD3.z = (-u_xlat0.x);
    u_xlat0.x = u_xlat1.y * _ProjectionParams.x;
    u_xlat0.w = u_xlat0.x * 0.5;
    u_xlat0.xz = u_xlat1.xw * float2(0.5, 0.5);
    o.vs_TEXCOORD3.w = u_xlat1.w;
    o.vs_TEXCOORD3.xy = u_xlat0.zz + u_xlat0.xw;
    return o;

}
float4 frag(V i):SV_Target{float4 result=0;
float4 u_xlat16_0;
float2 u_xlat1;
bool u_xlatb1;
float4 u_xlat16_2;
float u_xlat4;
bool u_xlatb7;

    u_xlat16_0 = tex2D(_MainTex, i.vs_TEXCOORD0.xy);
    u_xlatb1 = 0.0<_SingleChannel;
    u_xlat16_2.w = (u_xlatb1) ? u_xlat16_0.x : u_xlat16_0.w;
    u_xlat16_2.xyz = (bool(u_xlatb1)) ? float3(1.0, 1.0, 1.0) : u_xlat16_0.xyz;
    u_xlat16_0 = u_xlat16_2 * i.vs_COLOR0;
    u_xlat16_2.x = u_xlat16_2.w * i.vs_COLOR0.w + (-_Cutoff);
    u_xlatb1 = u_xlat16_2.x<0.0;
    if(u_xlatb1){discard;}
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

#elif !defined(SOFTPARTICLES_ON) && defined(_ALPHABLEND_ON) && !defined(_ALPHAMODULATE_ON) && !defined(_ALPHAPREMULTIPLY_ON) && !defined(_ALPHATEST_ON) && !defined(_CFXR_ADDITIVE) && defined(_CFXR_DISSOLVE) && !defined(_CFXR_EDGE_FADING) && !defined(_CFXR_FONT_COLORS) && !defined(_CFXR_LIGHTING_ALL) && !defined(_CFXR_LIGHTING_BACK) && !defined(_CFXR_LIGHTING_WPOS_OFFSET) && !defined(_CFXR_OVERLAYTEX_1X) && !defined(_CFXR_SECONDCOLOR_LERP) && !defined(_CFXR_UV_DISTORTION) && !defined(_EMISSION) && defined(_FADING_ON) && !defined(_FLIPBOOK_BLENDING) && !defined(_NORMALMAP)
// Original GLES program 38; _CFXR_DISSOLVE,_FADING_ON,_ALPHABLEND_ON
float _SingleChannel;
float _UseDissolveOffsetUV;
float _InvertDissolveTex;
float _DoubleDissolve;
float2 _DissolveScroll;
float _DissolveSmooth;
float _HdrMultiply;
float4 _DissolveTex_ST;
sampler2D _MainTex;
sampler2D _DissolveTex;
struct A{float4 in_POSITION0:POSITION0;float4 in_COLOR0:COLOR0;float4 in_TEXCOORD0:TEXCOORD0;float4 in_TEXCOORD1:TEXCOORD1;};
struct V{float4 vertex:SV_POSITION;float4 vs_COLOR0:TEXCOORD0;float4 vs_TEXCOORD0:TEXCOORD1;float4 vs_TEXCOORD1:TEXCOORD2;};
V vert(A i){V o=(V)0;
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
    o.vs_TEXCOORD1 = i.in_TEXCOORD1;
    return o;

}
float4 frag(V i):SV_Target{float4 result=0;
float2 u_xlat0;
float4 u_xlat16_0;
bool u_xlatb0;
float3 u_xlat16_1;
float4 u_xlat16_2;
float4 u_xlat16_3;
float u_xlat4;
bool u_xlatb4;
float u_xlat5;
float u_xlat16_6;
float2 u_xlat10;
bool2 u_xlatb10;
float u_xlat16_11;
float u_xlat16_16;

    u_xlat0.xy = _Time.yy * float2(_DissolveScroll.x, _DissolveScroll.y);
    u_xlat0.xy = frac(u_xlat0.xy);
    u_xlat10.xy = i.vs_TEXCOORD0.xy * _DissolveTex_ST.xy + _DissolveTex_ST.zw;
    u_xlat0.xy = u_xlat0.xy + u_xlat10.xy;
    u_xlatb10.xy = lessThan(float4(0.0, 0.0, 0.0, 0.0), float4(_SingleChannel, _UseDissolveOffsetUV, _SingleChannel, _UseDissolveOffsetUV)).xy;
    u_xlat0.xy = (u_xlatb10.y) ? u_xlat0.xy : i.vs_TEXCOORD0.xy;
    u_xlat16_0.x = tex2D(_DissolveTex, u_xlat0.xy).x;
    u_xlat16_1.x = u_xlat16_0.x * 2.0 + -1.0;
    u_xlat5 = u_xlat16_1.x * i.vs_TEXCOORD1.z + i.vs_TEXCOORD0.x;
    u_xlat16_1.x = (u_xlatb10.y) ? u_xlat5 : u_xlat16_0.x;
    u_xlat16_6 = (-u_xlat16_1.x) + 1.0;
    u_xlatb0 = 0.0>=_InvertDissolveTex;
    u_xlat16_1.x = (u_xlatb0) ? u_xlat16_6 : u_xlat16_1.x;
    u_xlat16_6 = u_xlat16_1.x + _DissolveSmooth;
    u_xlat16_1.x = u_xlat16_1.x + (-_DissolveSmooth);
    u_xlat16_6 = (-u_xlat16_1.x) + u_xlat16_6;
    u_xlat16_6 = float(1.0) / u_xlat16_6;
    u_xlat16_11 = _DissolveSmooth * 2.0 + 1.0;
    u_xlat16_11 = i.vs_TEXCOORD1.x * u_xlat16_11 + (-_DissolveSmooth);
    u_xlat16_16 = (-u_xlat16_1.x) + u_xlat16_11;
    u_xlat16_16 = u_xlat16_6 * u_xlat16_16;
    u_xlat16_16 = clamp(u_xlat16_16, 0.0, 1.0);
    u_xlat16_2.x = u_xlat16_16 * -2.0 + 3.0;
    u_xlat16_16 = u_xlat16_16 * u_xlat16_16;
    u_xlat16_16 = u_xlat16_16 * u_xlat16_2.x;
    u_xlat16_2 = tex2D(_MainTex, i.vs_TEXCOORD0.xy);
    u_xlat16_3.xyz = (u_xlatb10.x) ? float3(1.0, 1.0, 1.0) : u_xlat16_2.xyz;
    u_xlat16_3.w = (u_xlatb10.x) ? u_xlat16_2.x : u_xlat16_2.w;
    u_xlat16_0 = u_xlat16_3 * i.vs_COLOR0;
    u_xlat16_16 = u_xlat16_16 * u_xlat16_0.w;
    u_xlatb4 = 0.0<_DoubleDissolve;
    u_xlat16_3.x = (u_xlatb4) ? i.vs_TEXCOORD1.y : 0.0;
    u_xlat16_11 = u_xlat16_11 + (-u_xlat16_3.x);
    u_xlatb4 = 0.0<u_xlat16_3.x;
    u_xlat16_1.x = (-u_xlat16_1.x) + u_xlat16_11;
    u_xlat16_1.x = u_xlat16_6 * u_xlat16_1.x;
    u_xlat16_1.x = clamp(u_xlat16_1.x, 0.0, 1.0);
    u_xlat16_6 = u_xlat16_1.x * -2.0 + 3.0;
    u_xlat16_1.x = u_xlat16_1.x * u_xlat16_1.x;
    u_xlat16_1.x = (-u_xlat16_6) * u_xlat16_1.x + u_xlat16_16;
    u_xlat16_1.x = clamp(u_xlat16_1.x, 0.0, 1.0);
    u_xlat16_1.x = (u_xlatb4) ? u_xlat16_1.x : u_xlat16_16;
    result.w = min(u_xlat16_1.x, 1.0);
    u_xlat4 = log2(_HdrMultiply);
    u_xlat4 = u_xlat4 * 0.416666657;
    u_xlat4 = exp2(u_xlat4);
    u_xlat4 = u_xlat4 * 1.05499995 + -0.0549999997;
    u_xlat4 = max(u_xlat4, 0.0);
    u_xlat16_1.xyz = u_xlat16_0.xyz * ((float3)(u_xlat4));
    u_xlatb4 = 0.0<_HdrMultiply;
    result.xyz = (bool(u_xlatb4)) ? u_xlat16_1.xyz : u_xlat16_0.xyz;
    return result;

}

#elif !defined(SOFTPARTICLES_ON) && defined(_ALPHABLEND_ON) && !defined(_ALPHAMODULATE_ON) && !defined(_ALPHAPREMULTIPLY_ON) && !defined(_ALPHATEST_ON) && !defined(_CFXR_ADDITIVE) && !defined(_CFXR_DISSOLVE) && !defined(_CFXR_EDGE_FADING) && !defined(_CFXR_FONT_COLORS) && !defined(_CFXR_LIGHTING_ALL) && !defined(_CFXR_LIGHTING_BACK) && !defined(_CFXR_LIGHTING_WPOS_OFFSET) && !defined(_CFXR_OVERLAYTEX_1X) && defined(_CFXR_SECONDCOLOR_LERP) && !defined(_CFXR_UV_DISTORTION) && !defined(_EMISSION) && defined(_FADING_ON) && !defined(_FLIPBOOK_BLENDING) && !defined(_NORMALMAP)
// Original GLES program 39; _CFXR_SECONDCOLOR_LERP,_FADING_ON,_ALPHABLEND_ON
float _SingleChannel;
float _SecondColorSmooth;
float _HdrMultiply;
sampler2D _MainTex;
sampler2D _SecondColorTex;
struct A{float4 in_POSITION0:POSITION0;float4 in_COLOR0:COLOR0;float4 in_TEXCOORD0:TEXCOORD0;float4 in_TEXCOORD1:TEXCOORD1;float4 in_TEXCOORD2:TEXCOORD2;};
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
    o.vertex = transpose(unity_MatrixVP)[3] * u_xlat0.wwww + u_xlat1;
    o.vs_COLOR0 = i.in_COLOR0;
    o.vs_TEXCOORD0 = i.in_TEXCOORD0.xyxy;
    vs_TEXCOORD1 = i.in_TEXCOORD1;
    o.vs_TEXCOORD2 = i.in_TEXCOORD2;
    return o;

}
float4 frag(V i):SV_Target{float4 result=0;
float3 u_xlat0;
float u_xlat16_0;
float4 u_xlat16_1;
float4 u_xlat16_2;
float u_xlat3;
bool u_xlatb3;
float u_xlat16_4;
float u_xlat9;
bool u_xlatb9;

    u_xlat16_0 = tex2D(_SecondColorTex, i.vs_TEXCOORD0.xy).x;
    u_xlat16_1.x = u_xlat16_0 + _SecondColorSmooth;
    u_xlat16_4 = u_xlat16_0 + (-_SecondColorSmooth);
    u_xlat0.x = (-u_xlat16_4) + u_xlat16_1.x;
    u_xlat0.x = float(1.0) / u_xlat0.x;
    u_xlat3 = _SecondColorSmooth * 2.0 + 1.0;
    u_xlat3 = i.vs_TEXCOORD2.w * u_xlat3 + (-_SecondColorSmooth);
    u_xlat3 = (-u_xlat16_4) + u_xlat3;
    u_xlat0.x = u_xlat0.x * u_xlat3;
    u_xlat0.x = clamp(u_xlat0.x, 0.0, 1.0);
    u_xlat3 = u_xlat0.x * -2.0 + 3.0;
    u_xlat0.x = u_xlat0.x * u_xlat0.x;
    u_xlat0.x = u_xlat0.x * u_xlat3;
    u_xlat16_1 = tex2D(_MainTex, i.vs_TEXCOORD0.xy);
    u_xlatb3 = 0.0<_SingleChannel;
    u_xlat16_2.xyz = (bool(u_xlatb3)) ? float3(1.0, 1.0, 1.0) : u_xlat16_1.xyz;
    u_xlat16_2.w = (u_xlatb3) ? u_xlat16_1.x : u_xlat16_1.w;
    u_xlat16_1 = u_xlat16_2 * i.vs_COLOR0;
    u_xlat0.xyz = i.vs_TEXCOORD2.xyz * u_xlat0.xxx + u_xlat16_1.xyz;
    result.w = min(u_xlat16_1.w, 1.0);
    u_xlat9 = log2(_HdrMultiply);
    u_xlat9 = u_xlat9 * 0.416666657;
    u_xlat9 = exp2(u_xlat9);
    u_xlat9 = u_xlat9 * 1.05499995 + -0.0549999997;
    u_xlat9 = max(u_xlat9, 0.0);
    u_xlat16_2.xyz = ((float3)(u_xlat9)) * u_xlat0.xyz;
    u_xlatb9 = 0.0<_HdrMultiply;
    result.xyz = (bool(u_xlatb9)) ? u_xlat16_2.xyz : u_xlat0.xyz;
    return result;

}

#elif !defined(SOFTPARTICLES_ON) && defined(_ALPHABLEND_ON) && !defined(_ALPHAMODULATE_ON) && !defined(_ALPHAPREMULTIPLY_ON) && !defined(_ALPHATEST_ON) && !defined(_CFXR_ADDITIVE) && !defined(_CFXR_DISSOLVE) && !defined(_CFXR_EDGE_FADING) && defined(_CFXR_FONT_COLORS) && !defined(_CFXR_LIGHTING_ALL) && !defined(_CFXR_LIGHTING_BACK) && !defined(_CFXR_LIGHTING_WPOS_OFFSET) && !defined(_CFXR_OVERLAYTEX_1X) && !defined(_CFXR_SECONDCOLOR_LERP) && !defined(_CFXR_UV_DISTORTION) && !defined(_EMISSION) && defined(_FADING_ON) && !defined(_FLIPBOOK_BLENDING) && !defined(_NORMALMAP)
// Original GLES program 41; _CFXR_FONT_COLORS,_FADING_ON,_ALPHABLEND_ON
float _SingleChannel;
float _HdrMultiply;
sampler2D _MainTex;
struct A{float4 in_POSITION0:POSITION0;float4 in_COLOR0:COLOR0;float4 in_TEXCOORD0:TEXCOORD0;float4 in_TEXCOORD1:TEXCOORD1;float4 in_TEXCOORD2:TEXCOORD2;};
struct V{float4 vertex:SV_POSITION;float4 vs_COLOR0:TEXCOORD0;float4 vs_TEXCOORD0:TEXCOORD1;float4 vs_TEXCOORD1:TEXCOORD2;float4 vs_TEXCOORD2:TEXCOORD3;};
V vert(A i){V o=(V)0;
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
    o.vs_TEXCOORD1 = i.in_TEXCOORD1;
    o.vs_TEXCOORD2 = i.in_TEXCOORD2;
    return o;

}
float4 frag(V i):SV_Target{float4 result=0;
float u_xlat0;
bool u_xlatb0;
float4 u_xlat16_1;
float4 u_xlat16_2;
float3 u_xlat3;
bool u_xlatb3;

    u_xlat0 = log2(_HdrMultiply);
    u_xlat0 = u_xlat0 * 0.416666657;
    u_xlat0 = exp2(u_xlat0);
    u_xlat0 = u_xlat0 * 1.05499995 + -0.0549999997;
    u_xlat0 = max(u_xlat0, 0.0);
    u_xlat16_1 = tex2D(_MainTex, i.vs_TEXCOORD0.xy);
    u_xlatb3 = 0.0<_SingleChannel;
    u_xlat16_2.w = (u_xlatb3) ? u_xlat16_1.x : u_xlat16_1.w;
    u_xlat16_2.xyz = (bool(u_xlatb3)) ? float3(1.0, 1.0, 1.0) : u_xlat16_1.xyz;
    u_xlat16_1 = u_xlat16_2.zzzw * i.vs_COLOR0;
    u_xlat3.xyz = u_xlat16_2.yyy * i.vs_TEXCOORD1.xyz + u_xlat16_1.xyz;
    result.w = min(u_xlat16_1.w, 1.0);
    u_xlat3.xyz = u_xlat16_2.xxx * i.vs_TEXCOORD2.xyz + u_xlat3.xyz;
    u_xlat16_2.xyz = ((float3)(u_xlat0)) * u_xlat3.xyz;
    u_xlatb0 = 0.0<_HdrMultiply;
    result.xyz = (bool(u_xlatb0)) ? u_xlat16_2.xyz : u_xlat3.xyz;
    return result;

}

#elif !defined(SOFTPARTICLES_ON) && defined(_ALPHABLEND_ON) && !defined(_ALPHAMODULATE_ON) && !defined(_ALPHAPREMULTIPLY_ON) && !defined(_ALPHATEST_ON) && !defined(_CFXR_ADDITIVE) && !defined(_CFXR_DISSOLVE) && defined(_CFXR_EDGE_FADING) && !defined(_CFXR_FONT_COLORS) && !defined(_CFXR_LIGHTING_ALL) && !defined(_CFXR_LIGHTING_BACK) && !defined(_CFXR_LIGHTING_WPOS_OFFSET) && !defined(_CFXR_OVERLAYTEX_1X) && !defined(_CFXR_SECONDCOLOR_LERP) && !defined(_CFXR_UV_DISTORTION) && !defined(_EMISSION) && defined(_FADING_ON) && !defined(_FLIPBOOK_BLENDING) && !defined(_NORMALMAP)
// Original GLES program 42; _CFXR_EDGE_FADING,_FADING_ON,_ALPHABLEND_ON
float _EdgeFadePow;
float _SingleChannel;
float _HdrMultiply;
sampler2D _MainTex;
struct A{float4 in_POSITION0:POSITION0;float4 in_COLOR0:COLOR0;float4 in_TEXCOORD0:TEXCOORD0;float4 in_TEXCOORD1:TEXCOORD1;float3 in_NORMAL0:NORMAL0;};
struct V{float4 vertex:SV_POSITION;float4 vs_COLOR0:TEXCOORD0;float4 vs_TEXCOORD0:TEXCOORD1;};
V vert(A i){V o=(V)0;
float4 vs_TEXCOORD1;
float4 u_xlat0;
float4 u_xlat1;
float u_xlat6;

    u_xlat0 = i.in_POSITION0.yyyy * transpose(unity_ObjectToWorld)[1];
    u_xlat0 = transpose(unity_ObjectToWorld)[0] * i.in_POSITION0.xxxx + u_xlat0;
    u_xlat0 = transpose(unity_ObjectToWorld)[2] * i.in_POSITION0.zzzz + u_xlat0;
    u_xlat0 = u_xlat0 + transpose(unity_ObjectToWorld)[3];
    u_xlat1 = u_xlat0.yyyy * transpose(unity_MatrixVP)[1];
    u_xlat1 = transpose(unity_MatrixVP)[0] * u_xlat0.xxxx + u_xlat1;
    u_xlat1 = transpose(unity_MatrixVP)[2] * u_xlat0.zzzz + u_xlat1;
    o.vertex = transpose(unity_MatrixVP)[3] * u_xlat0.wwww + u_xlat1;
    u_xlat0.xyz = (-i.in_POSITION0.xyz) + _WorldSpaceCameraPos.xyz;
    u_xlat6 = dot(u_xlat0.xyz, u_xlat0.xyz);
    u_xlat6 = rsqrt(u_xlat6);
    u_xlat0.xyz = ((float3)(u_xlat6)) * u_xlat0.xyz;
    u_xlat0.x = dot(u_xlat0.xyz, i.in_NORMAL0.xyz);
    u_xlat0.x = log2(abs(u_xlat0.x));
    u_xlat0.x = u_xlat0.x * _EdgeFadePow;
    u_xlat0.x = exp2(u_xlat0.x);
    u_xlat0.x = min(u_xlat0.x, 1.0);
    u_xlat0.x = u_xlat0.x * i.in_COLOR0.w;
    o.vs_COLOR0.w = u_xlat0.x;
    o.vs_COLOR0.xyz = i.in_COLOR0.xyz;
    o.vs_TEXCOORD0 = i.in_TEXCOORD0.xyxy;
    vs_TEXCOORD1 = i.in_TEXCOORD1;
    return o;

}
float4 frag(V i):SV_Target{float4 result=0;
float u_xlat0;
bool u_xlatb0;
float4 u_xlat16_1;
float4 u_xlat16_2;
bool u_xlatb3;

    u_xlat0 = log2(_HdrMultiply);
    u_xlat0 = u_xlat0 * 0.416666657;
    u_xlat0 = exp2(u_xlat0);
    u_xlat0 = u_xlat0 * 1.05499995 + -0.0549999997;
    u_xlat0 = max(u_xlat0, 0.0);
    u_xlat16_1 = tex2D(_MainTex, i.vs_TEXCOORD0.xy);
    u_xlatb3 = 0.0<_SingleChannel;
    u_xlat16_2.xyz = (bool(u_xlatb3)) ? float3(1.0, 1.0, 1.0) : u_xlat16_1.xyz;
    u_xlat16_2.w = (u_xlatb3) ? u_xlat16_1.x : u_xlat16_1.w;
    u_xlat16_1 = u_xlat16_2 * i.vs_COLOR0;
    u_xlat16_2.xyz = ((float3)(u_xlat0)) * u_xlat16_1.xyz;
    u_xlatb0 = 0.0<_HdrMultiply;
    result.xyz = (bool(u_xlatb0)) ? u_xlat16_2.xyz : u_xlat16_1.xyz;
    result.w = min(u_xlat16_1.w, 1.0);
    return result;

}

#elif !defined(SOFTPARTICLES_ON) && defined(_ALPHABLEND_ON) && !defined(_ALPHAMODULATE_ON) && !defined(_ALPHAPREMULTIPLY_ON) && !defined(_ALPHATEST_ON) && !defined(_CFXR_ADDITIVE) && defined(_CFXR_DISSOLVE) && !defined(_CFXR_EDGE_FADING) && !defined(_CFXR_FONT_COLORS) && !defined(_CFXR_LIGHTING_ALL) && !defined(_CFXR_LIGHTING_BACK) && !defined(_CFXR_LIGHTING_WPOS_OFFSET) && defined(_CFXR_OVERLAYTEX_1X) && !defined(_CFXR_SECONDCOLOR_LERP) && !defined(_CFXR_UV_DISTORTION) && !defined(_EMISSION) && !defined(_FADING_ON) && !defined(_FLIPBOOK_BLENDING) && !defined(_NORMALMAP)
// Original GLES program 48; _CFXR_DISSOLVE,_CFXR_OVERLAYTEX_1X,_ALPHABLEND_ON
float4 _OverlayTex_Scroll;
float _SingleChannel;
float _UseDissolveOffsetUV;
float _CFXR_OVERLAYBLEND;
float _InvertDissolveTex;
float _DoubleDissolve;
float2 _DissolveScroll;
float _DissolveSmooth;
float _HdrMultiply;
float4 _DissolveTex_ST;
sampler2D _MainTex;
sampler2D _OverlayTex;
sampler2D _DissolveTex;
struct A{float4 in_POSITION0:POSITION0;float4 in_COLOR0:COLOR0;float4 in_TEXCOORD0:TEXCOORD0;float4 in_TEXCOORD1:TEXCOORD1;};
struct V{float4 vertex:SV_POSITION;float4 vs_COLOR0:TEXCOORD0;float4 vs_TEXCOORD0:TEXCOORD1;float4 vs_TEXCOORD1:TEXCOORD2;};
V vert(A i){V o=(V)0;
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
    o.vs_TEXCOORD1 = i.in_TEXCOORD1;
    return o;

}
float4 frag(V i):SV_Target{float4 result=0;
float2 u_xlat0;
float4 u_xlat16_0;
bool u_xlatb0;
float3 u_xlat16_1;
float4 u_xlat16_2;
float2 u_xlat3;
float4 u_xlat16_3;
float u_xlat4;
bool2 u_xlatb4;
float u_xlat16_5;
float u_xlat6;
float u_xlat16_7;
float2 u_xlat12;
bool2 u_xlatb12;
float u_xlat16_13;
float u_xlat16_19;

    u_xlat0.xy = _Time.yy * float2(_DissolveScroll.x, _DissolveScroll.y);
    u_xlat0.xy = frac(u_xlat0.xy);
    u_xlat12.xy = i.vs_TEXCOORD0.xy * _DissolveTex_ST.xy + _DissolveTex_ST.zw;
    u_xlat0.xy = u_xlat0.xy + u_xlat12.xy;
    u_xlatb12.xy = lessThan(float4(0.0, 0.0, 0.0, 0.0), float4(_SingleChannel, _UseDissolveOffsetUV, _SingleChannel, _UseDissolveOffsetUV)).xy;
    u_xlat0.xy = (u_xlatb12.y) ? u_xlat0.xy : i.vs_TEXCOORD0.xy;
    u_xlat16_0.x = tex2D(_DissolveTex, u_xlat0.xy).x;
    u_xlat16_1.x = u_xlat16_0.x * 2.0 + -1.0;
    u_xlat6 = u_xlat16_1.x * i.vs_TEXCOORD1.z + i.vs_TEXCOORD0.x;
    u_xlat16_1.x = (u_xlatb12.y) ? u_xlat6 : u_xlat16_0.x;
    u_xlat16_7 = (-u_xlat16_1.x) + 1.0;
    u_xlatb0 = 0.0>=_InvertDissolveTex;
    u_xlat16_1.x = (u_xlatb0) ? u_xlat16_7 : u_xlat16_1.x;
    u_xlat16_7 = u_xlat16_1.x + _DissolveSmooth;
    u_xlat16_1.x = u_xlat16_1.x + (-_DissolveSmooth);
    u_xlat16_7 = (-u_xlat16_1.x) + u_xlat16_7;
    u_xlat16_7 = float(1.0) / u_xlat16_7;
    u_xlat16_13 = _DissolveSmooth * 2.0 + 1.0;
    u_xlat16_13 = i.vs_TEXCOORD1.x * u_xlat16_13 + (-_DissolveSmooth);
    u_xlat16_19 = (-u_xlat16_1.x) + u_xlat16_13;
    u_xlat16_19 = u_xlat16_7 * u_xlat16_19;
    u_xlat16_19 = clamp(u_xlat16_19, 0.0, 1.0);
    u_xlat16_2.x = u_xlat16_19 * -2.0 + 3.0;
    u_xlat16_19 = u_xlat16_19 * u_xlat16_19;
    u_xlat16_19 = u_xlat16_19 * u_xlat16_2.x;
    u_xlat0.xy = _Time.yy * _OverlayTex_Scroll.xy;
    u_xlat0.xy = frac(u_xlat0.xy);
    u_xlat3.xy = i.vs_TEXCOORD0.zw + i.vs_TEXCOORD0.xy;
    u_xlat0.xy = u_xlat3.xy * _OverlayTex_Scroll.zz + u_xlat0.xy;
    u_xlat16_0.x = tex2D(_OverlayTex, u_xlat0.xy).x;
    u_xlat16_2 = tex2D(_MainTex, i.vs_TEXCOORD0.xy);
    u_xlat16_3.xyz = (u_xlatb12.x) ? float3(1.0, 1.0, 1.0) : u_xlat16_2.xyz;
    u_xlat16_3.w = (u_xlatb12.x) ? u_xlat16_2.x : u_xlat16_2.w;
    u_xlat16_0 = u_xlat16_0.xxxx * u_xlat16_3;
    u_xlat16_2.xyz = u_xlat16_3.xyz;
    u_xlat16_3.xyz = u_xlat16_0.xyz;
    u_xlatb4.xy = equal(((float4)(_CFXR_OVERLAYBLEND)), float4(2.0, 1.0, 0.0, 0.0)).xy;
    u_xlat16_3 = (u_xlatb4.y) ? u_xlat16_3 : u_xlat16_0;
    u_xlat16_2.w = u_xlat16_0.w;
    u_xlat16_0 = (u_xlatb4.x) ? u_xlat16_2 : u_xlat16_3;
    u_xlat16_0 = u_xlat16_0 * i.vs_COLOR0;
    u_xlat16_19 = u_xlat16_19 * u_xlat16_0.w;
    u_xlatb4.x = 0.0<_DoubleDissolve;
    u_xlat16_5 = (u_xlatb4.x) ? i.vs_TEXCOORD1.y : 0.0;
    u_xlat16_13 = u_xlat16_13 + (-u_xlat16_5);
    u_xlatb4.x = 0.0<u_xlat16_5;
    u_xlat16_1.x = (-u_xlat16_1.x) + u_xlat16_13;
    u_xlat16_1.x = u_xlat16_7 * u_xlat16_1.x;
    u_xlat16_1.x = clamp(u_xlat16_1.x, 0.0, 1.0);
    u_xlat16_7 = u_xlat16_1.x * -2.0 + 3.0;
    u_xlat16_1.x = u_xlat16_1.x * u_xlat16_1.x;
    u_xlat16_1.x = (-u_xlat16_7) * u_xlat16_1.x + u_xlat16_19;
    u_xlat16_1.x = clamp(u_xlat16_1.x, 0.0, 1.0);
    u_xlat16_1.x = (u_xlatb4.x) ? u_xlat16_1.x : u_xlat16_19;
    result.w = min(u_xlat16_1.x, 1.0);
    u_xlat4 = log2(_HdrMultiply);
    u_xlat4 = u_xlat4 * 0.416666657;
    u_xlat4 = exp2(u_xlat4);
    u_xlat4 = u_xlat4 * 1.05499995 + -0.0549999997;
    u_xlat4 = max(u_xlat4, 0.0);
    u_xlat16_1.xyz = u_xlat16_0.xyz * ((float3)(u_xlat4));
    u_xlatb4.x = 0.0<_HdrMultiply;
    result.xyz = (u_xlatb4.x) ? u_xlat16_1.xyz : u_xlat16_0.xyz;
    return result;

}

#elif !defined(SOFTPARTICLES_ON) && defined(_ALPHABLEND_ON) && !defined(_ALPHAMODULATE_ON) && !defined(_ALPHAPREMULTIPLY_ON) && !defined(_ALPHATEST_ON) && !defined(_CFXR_ADDITIVE) && !defined(_CFXR_DISSOLVE) && !defined(_CFXR_EDGE_FADING) && !defined(_CFXR_FONT_COLORS) && !defined(_CFXR_LIGHTING_ALL) && !defined(_CFXR_LIGHTING_BACK) && !defined(_CFXR_LIGHTING_WPOS_OFFSET) && !defined(_CFXR_OVERLAYTEX_1X) && !defined(_CFXR_SECONDCOLOR_LERP) && !defined(_CFXR_UV_DISTORTION) && !defined(_EMISSION) && defined(_FADING_ON) && defined(_FLIPBOOK_BLENDING) && !defined(_NORMALMAP)
// Original GLES program 50; _FADING_ON,_FLIPBOOK_BLENDING,_ALPHABLEND_ON
float _SingleChannel;
float _HdrMultiply;
sampler2D _MainTex;
struct A{float4 in_POSITION0:POSITION0;float4 in_COLOR0:COLOR0;float4 in_TEXCOORD0:TEXCOORD0;float4 in_TEXCOORD1:TEXCOORD1;};
struct V{float4 vertex:SV_POSITION;float4 vs_COLOR0:TEXCOORD0;float4 vs_TEXCOORD0:TEXCOORD1;float4 vs_TEXCOORD1:TEXCOORD2;};
V vert(A i){V o=(V)0;
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
    o.vs_TEXCOORD1 = i.in_TEXCOORD1;
    return o;

}
float4 frag(V i):SV_Target{float4 result=0;
float u_xlat0;
bool u_xlatb0;
float4 u_xlat1;
float4 u_xlat16_1;
float4 u_xlat2;
float3 u_xlat16_2;
float4 u_xlat16_3;
float4 u_xlat16_4;
bool u_xlatb5;

    u_xlat0 = log2(_HdrMultiply);
    u_xlat0 = u_xlat0 * 0.416666657;
    u_xlat0 = exp2(u_xlat0);
    u_xlat0 = u_xlat0 * 1.05499995 + -0.0549999997;
    u_xlat0 = max(u_xlat0, 0.0);
    u_xlat16_1 = tex2D(_MainTex, i.vs_TEXCOORD0.zw);
    u_xlatb5 = 0.0<_SingleChannel;
    u_xlat16_2.xyz = (bool(u_xlatb5)) ? u_xlat16_1.xxx : u_xlat16_1.yzw;
    u_xlat16_3 = tex2D(_MainTex, i.vs_TEXCOORD0.xy);
    u_xlat16_4.w = (u_xlatb5) ? u_xlat16_3.x : u_xlat16_3.w;
    u_xlat16_4.xyz = (bool(u_xlatb5)) ? float3(1.0, 1.0, 1.0) : u_xlat16_3.xyz;
    u_xlat2.yzw = u_xlat16_2.xyz + (-u_xlat16_4.yzw);
    u_xlat2.x = u_xlat16_1.x + (-u_xlat16_4.x);
    u_xlat1 = i.vs_TEXCOORD1.yyyy * u_xlat2 + u_xlat16_4;
    u_xlat16_1 = u_xlat1 * i.vs_COLOR0;
    u_xlat16_4.xyz = ((float3)(u_xlat0)) * u_xlat16_1.xyz;
    u_xlatb0 = 0.0<_HdrMultiply;
    result.xyz = (bool(u_xlatb0)) ? u_xlat16_4.xyz : u_xlat16_1.xyz;
    result.w = min(u_xlat16_1.w, 1.0);
    return result;

}

#elif !defined(SOFTPARTICLES_ON) && defined(_ALPHABLEND_ON) && !defined(_ALPHAMODULATE_ON) && !defined(_ALPHAPREMULTIPLY_ON) && defined(_ALPHATEST_ON) && !defined(_CFXR_ADDITIVE) && !defined(_CFXR_DISSOLVE) && defined(_CFXR_EDGE_FADING) && !defined(_CFXR_FONT_COLORS) && !defined(_CFXR_LIGHTING_ALL) && !defined(_CFXR_LIGHTING_BACK) && !defined(_CFXR_LIGHTING_WPOS_OFFSET) && !defined(_CFXR_OVERLAYTEX_1X) && !defined(_CFXR_SECONDCOLOR_LERP) && !defined(_CFXR_UV_DISTORTION) && !defined(_EMISSION) && !defined(_FADING_ON) && !defined(_FLIPBOOK_BLENDING) && !defined(_NORMALMAP)
// Original GLES program 52; _CFXR_EDGE_FADING,_ALPHATEST_ON,_ALPHABLEND_ON
float _EdgeFadePow;
float _SingleChannel;
float _HdrMultiply;
float _Cutoff;
sampler2D _MainTex;
struct A{float4 in_POSITION0:POSITION0;float4 in_COLOR0:COLOR0;float4 in_TEXCOORD0:TEXCOORD0;float4 in_TEXCOORD1:TEXCOORD1;float3 in_NORMAL0:NORMAL0;};
struct V{float4 vertex:SV_POSITION;float4 vs_COLOR0:TEXCOORD0;float4 vs_TEXCOORD0:TEXCOORD1;};
V vert(A i){V o=(V)0;
float4 vs_TEXCOORD1;
float4 u_xlat0;
float4 u_xlat1;
float u_xlat6;

    u_xlat0 = i.in_POSITION0.yyyy * transpose(unity_ObjectToWorld)[1];
    u_xlat0 = transpose(unity_ObjectToWorld)[0] * i.in_POSITION0.xxxx + u_xlat0;
    u_xlat0 = transpose(unity_ObjectToWorld)[2] * i.in_POSITION0.zzzz + u_xlat0;
    u_xlat0 = u_xlat0 + transpose(unity_ObjectToWorld)[3];
    u_xlat1 = u_xlat0.yyyy * transpose(unity_MatrixVP)[1];
    u_xlat1 = transpose(unity_MatrixVP)[0] * u_xlat0.xxxx + u_xlat1;
    u_xlat1 = transpose(unity_MatrixVP)[2] * u_xlat0.zzzz + u_xlat1;
    o.vertex = transpose(unity_MatrixVP)[3] * u_xlat0.wwww + u_xlat1;
    u_xlat0.xyz = (-i.in_POSITION0.xyz) + _WorldSpaceCameraPos.xyz;
    u_xlat6 = dot(u_xlat0.xyz, u_xlat0.xyz);
    u_xlat6 = rsqrt(u_xlat6);
    u_xlat0.xyz = ((float3)(u_xlat6)) * u_xlat0.xyz;
    u_xlat0.x = dot(u_xlat0.xyz, i.in_NORMAL0.xyz);
    u_xlat0.x = log2(abs(u_xlat0.x));
    u_xlat0.x = u_xlat0.x * _EdgeFadePow;
    u_xlat0.x = exp2(u_xlat0.x);
    u_xlat0.x = min(u_xlat0.x, 1.0);
    u_xlat0.x = u_xlat0.x * i.in_COLOR0.w;
    o.vs_COLOR0.w = u_xlat0.x;
    o.vs_COLOR0.xyz = i.in_COLOR0.xyz;
    o.vs_TEXCOORD0 = i.in_TEXCOORD0.xyxy;
    vs_TEXCOORD1 = i.in_TEXCOORD1;
    return o;

}
float4 frag(V i):SV_Target{float4 result=0;
float4 u_xlat16_0;
float u_xlat1;
bool u_xlatb1;
float4 u_xlat16_2;

    u_xlat16_0 = tex2D(_MainTex, i.vs_TEXCOORD0.xy);
    u_xlatb1 = 0.0<_SingleChannel;
    u_xlat16_2.w = (u_xlatb1) ? u_xlat16_0.x : u_xlat16_0.w;
    u_xlat16_2.xyz = (bool(u_xlatb1)) ? float3(1.0, 1.0, 1.0) : u_xlat16_0.xyz;
    u_xlat16_0 = u_xlat16_2 * i.vs_COLOR0;
    u_xlat16_2.x = u_xlat16_2.w * i.vs_COLOR0.w + (-_Cutoff);
    u_xlatb1 = u_xlat16_2.x<0.0;
    if(u_xlatb1){discard;}
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

#elif !defined(SOFTPARTICLES_ON) && defined(_ALPHABLEND_ON) && !defined(_ALPHAMODULATE_ON) && !defined(_ALPHAPREMULTIPLY_ON) && defined(_ALPHATEST_ON) && !defined(_CFXR_ADDITIVE) && !defined(_CFXR_DISSOLVE) && !defined(_CFXR_EDGE_FADING) && !defined(_CFXR_FONT_COLORS) && !defined(_CFXR_LIGHTING_ALL) && !defined(_CFXR_LIGHTING_BACK) && !defined(_CFXR_LIGHTING_WPOS_OFFSET) && !defined(_CFXR_OVERLAYTEX_1X) && !defined(_CFXR_SECONDCOLOR_LERP) && !defined(_CFXR_UV_DISTORTION) && !defined(_EMISSION) && defined(_FADING_ON) && !defined(_FLIPBOOK_BLENDING) && !defined(_NORMALMAP)
// Original GLES program 55; _FADING_ON,_ALPHATEST_ON,_ALPHABLEND_ON
float _SingleChannel;
float _HdrMultiply;
float _Cutoff;
sampler2D _MainTex;
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
float4 u_xlat16_0;
float u_xlat1;
bool u_xlatb1;
float4 u_xlat16_2;

    u_xlat16_0 = tex2D(_MainTex, i.vs_TEXCOORD0.xy);
    u_xlatb1 = 0.0<_SingleChannel;
    u_xlat16_2.w = (u_xlatb1) ? u_xlat16_0.x : u_xlat16_0.w;
    u_xlat16_2.xyz = (bool(u_xlatb1)) ? float3(1.0, 1.0, 1.0) : u_xlat16_0.xyz;
    u_xlat16_0 = u_xlat16_2 * i.vs_COLOR0;
    u_xlat16_2.x = u_xlat16_2.w * i.vs_COLOR0.w + (-_Cutoff);
    u_xlatb1 = u_xlat16_2.x<0.0;
    if(u_xlatb1){discard;}
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

#elif !defined(SOFTPARTICLES_ON) && !defined(_ALPHABLEND_ON) && defined(_ALPHAMODULATE_ON) && !defined(_ALPHAPREMULTIPLY_ON) && !defined(_ALPHATEST_ON) && !defined(_CFXR_ADDITIVE) && defined(_CFXR_DISSOLVE) && !defined(_CFXR_EDGE_FADING) && !defined(_CFXR_FONT_COLORS) && !defined(_CFXR_LIGHTING_ALL) && !defined(_CFXR_LIGHTING_BACK) && !defined(_CFXR_LIGHTING_WPOS_OFFSET) && !defined(_CFXR_OVERLAYTEX_1X) && !defined(_CFXR_SECONDCOLOR_LERP) && !defined(_CFXR_UV_DISTORTION) && !defined(_EMISSION) && defined(_FADING_ON) && !defined(_FLIPBOOK_BLENDING) && !defined(_NORMALMAP)
// Original GLES program 61; _CFXR_DISSOLVE,_FADING_ON,_ALPHAMODULATE_ON
float _SingleChannel;
float _UseDissolveOffsetUV;
float _InvertDissolveTex;
float _DoubleDissolve;
float2 _DissolveScroll;
float _DissolveSmooth;
float _HdrMultiply;
float4 _DissolveTex_ST;
sampler2D _MainTex;
sampler2D _DissolveTex;
struct A{float4 in_POSITION0:POSITION0;float4 in_COLOR0:COLOR0;float4 in_TEXCOORD0:TEXCOORD0;float4 in_TEXCOORD1:TEXCOORD1;};
struct V{float4 vertex:SV_POSITION;float4 vs_COLOR0:TEXCOORD0;float4 vs_TEXCOORD0:TEXCOORD1;float4 vs_TEXCOORD1:TEXCOORD2;};
V vert(A i){V o=(V)0;
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
    o.vs_TEXCOORD1 = i.in_TEXCOORD1;
    return o;

}
float4 frag(V i):SV_Target{float4 result=0;
float2 u_xlat0;
float4 u_xlat16_0;
bool u_xlatb0;
float u_xlat16_1;
float4 u_xlat16_2;
float4 u_xlat16_3;
float3 u_xlat4;
bool u_xlatb4;
float u_xlat5;
float3 u_xlat16_6;
float2 u_xlat10;
bool2 u_xlatb10;
float u_xlat16_11;
float u_xlat16_16;

    u_xlat0.xy = _Time.yy * float2(_DissolveScroll.x, _DissolveScroll.y);
    u_xlat0.xy = frac(u_xlat0.xy);
    u_xlat10.xy = i.vs_TEXCOORD0.xy * _DissolveTex_ST.xy + _DissolveTex_ST.zw;
    u_xlat0.xy = u_xlat0.xy + u_xlat10.xy;
    u_xlatb10.xy = lessThan(float4(0.0, 0.0, 0.0, 0.0), float4(_SingleChannel, _UseDissolveOffsetUV, _SingleChannel, _UseDissolveOffsetUV)).xy;
    u_xlat0.xy = (u_xlatb10.y) ? u_xlat0.xy : i.vs_TEXCOORD0.xy;
    u_xlat16_0.x = tex2D(_DissolveTex, u_xlat0.xy).x;
    u_xlat16_1 = u_xlat16_0.x * 2.0 + -1.0;
    u_xlat5 = u_xlat16_1 * i.vs_TEXCOORD1.z + i.vs_TEXCOORD0.x;
    u_xlat16_1 = (u_xlatb10.y) ? u_xlat5 : u_xlat16_0.x;
    u_xlat16_6.x = (-u_xlat16_1) + 1.0;
    u_xlatb0 = 0.0>=_InvertDissolveTex;
    u_xlat16_1 = (u_xlatb0) ? u_xlat16_6.x : u_xlat16_1;
    u_xlat16_6.x = u_xlat16_1 + _DissolveSmooth;
    u_xlat16_1 = u_xlat16_1 + (-_DissolveSmooth);
    u_xlat16_6.x = (-u_xlat16_1) + u_xlat16_6.x;
    u_xlat16_6.x = float(1.0) / u_xlat16_6.x;
    u_xlat16_11 = _DissolveSmooth * 2.0 + 1.0;
    u_xlat16_11 = i.vs_TEXCOORD1.x * u_xlat16_11 + (-_DissolveSmooth);
    u_xlat16_16 = (-u_xlat16_1) + u_xlat16_11;
    u_xlat16_16 = u_xlat16_6.x * u_xlat16_16;
    u_xlat16_16 = clamp(u_xlat16_16, 0.0, 1.0);
    u_xlat16_2.x = u_xlat16_16 * -2.0 + 3.0;
    u_xlat16_16 = u_xlat16_16 * u_xlat16_16;
    u_xlat16_16 = u_xlat16_16 * u_xlat16_2.x;
    u_xlat16_2 = tex2D(_MainTex, i.vs_TEXCOORD0.xy);
    u_xlat16_3.xyz = (u_xlatb10.x) ? float3(1.0, 1.0, 1.0) : u_xlat16_2.xyz;
    u_xlat16_3.w = (u_xlatb10.x) ? u_xlat16_2.x : u_xlat16_2.w;
    u_xlat16_0 = u_xlat16_3 * i.vs_COLOR0;
    u_xlat16_16 = u_xlat16_16 * u_xlat16_0.w;
    u_xlatb4 = 0.0<_DoubleDissolve;
    u_xlat16_3.x = (u_xlatb4) ? i.vs_TEXCOORD1.y : 0.0;
    u_xlat16_11 = u_xlat16_11 + (-u_xlat16_3.x);
    u_xlatb4 = 0.0<u_xlat16_3.x;
    u_xlat16_1 = (-u_xlat16_1) + u_xlat16_11;
    u_xlat16_1 = u_xlat16_6.x * u_xlat16_1;
    u_xlat16_1 = clamp(u_xlat16_1, 0.0, 1.0);
    u_xlat16_6.x = u_xlat16_1 * -2.0 + 3.0;
    u_xlat16_1 = u_xlat16_1 * u_xlat16_1;
    u_xlat16_1 = (-u_xlat16_6.x) * u_xlat16_1 + u_xlat16_16;
    u_xlat16_1 = clamp(u_xlat16_1, 0.0, 1.0);
    u_xlat16_1 = (u_xlatb4) ? u_xlat16_1 : u_xlat16_16;
    u_xlat4.x = log2(_HdrMultiply);
    u_xlat4.x = u_xlat4.x * 0.416666657;
    u_xlat4.x = exp2(u_xlat4.x);
    u_xlat4.x = u_xlat4.x * 1.05499995 + -0.0549999997;
    u_xlat4.x = max(u_xlat4.x, 0.0);
    u_xlat16_6.xyz = u_xlat16_0.xyz * u_xlat4.xxx;
    u_xlatb4 = 0.0<_HdrMultiply;
    u_xlat16_6.xyz = (bool(u_xlatb4)) ? u_xlat16_6.xyz : u_xlat16_0.xyz;
    u_xlat4.xyz = u_xlat16_6.xyz + float3(-1.0, -1.0, -1.0);
    u_xlat4.xyz = ((float3)(u_xlat16_1)) * u_xlat4.xyz + float3(1.0, 1.0, 1.0);
    result.w = min(u_xlat16_1, 1.0);
    result.xyz = u_xlat4.xyz;
    return result;

}

#elif !defined(SOFTPARTICLES_ON) && !defined(_ALPHABLEND_ON) && defined(_ALPHAMODULATE_ON) && !defined(_ALPHAPREMULTIPLY_ON) && !defined(_ALPHATEST_ON) && !defined(_CFXR_ADDITIVE) && !defined(_CFXR_DISSOLVE) && defined(_CFXR_EDGE_FADING) && !defined(_CFXR_FONT_COLORS) && !defined(_CFXR_LIGHTING_ALL) && !defined(_CFXR_LIGHTING_BACK) && !defined(_CFXR_LIGHTING_WPOS_OFFSET) && !defined(_CFXR_OVERLAYTEX_1X) && !defined(_CFXR_SECONDCOLOR_LERP) && defined(_CFXR_UV_DISTORTION) && !defined(_EMISSION) && !defined(_FADING_ON) && !defined(_FLIPBOOK_BLENDING) && !defined(_NORMALMAP)
// Original GLES program 62; _CFXR_EDGE_FADING,_CFXR_UV_DISTORTION,_ALPHAMODULATE_ON
float _EdgeFadePow;
float _SingleChannel;
float _UseUV2Distortion;
float _UVDistortionAdd;
float4 _DistortScrolling;
float _Distort;
float _FadeAlongU;
float _HdrMultiply;
sampler2D _DistortTex;
sampler2D _MainTex;
struct A{float4 in_POSITION0:POSITION0;float4 in_COLOR0:COLOR0;float4 in_TEXCOORD0:TEXCOORD0;float4 in_TEXCOORD1:TEXCOORD1;float3 in_NORMAL0:NORMAL0;};
struct V{float4 vertex:SV_POSITION;float4 vs_COLOR0:TEXCOORD0;float4 vs_TEXCOORD0:TEXCOORD1;float4 vs_TEXCOORD1:TEXCOORD2;};
V vert(A i){V o=(V)0;
float4 u_xlat0;
float4 u_xlat1;
float u_xlat6;

    u_xlat0 = i.in_POSITION0.yyyy * transpose(unity_ObjectToWorld)[1];
    u_xlat0 = transpose(unity_ObjectToWorld)[0] * i.in_POSITION0.xxxx + u_xlat0;
    u_xlat0 = transpose(unity_ObjectToWorld)[2] * i.in_POSITION0.zzzz + u_xlat0;
    u_xlat0 = u_xlat0 + transpose(unity_ObjectToWorld)[3];
    u_xlat1 = u_xlat0.yyyy * transpose(unity_MatrixVP)[1];
    u_xlat1 = transpose(unity_MatrixVP)[0] * u_xlat0.xxxx + u_xlat1;
    u_xlat1 = transpose(unity_MatrixVP)[2] * u_xlat0.zzzz + u_xlat1;
    o.vertex = transpose(unity_MatrixVP)[3] * u_xlat0.wwww + u_xlat1;
    u_xlat0.xyz = (-i.in_POSITION0.xyz) + _WorldSpaceCameraPos.xyz;
    u_xlat6 = dot(u_xlat0.xyz, u_xlat0.xyz);
    u_xlat6 = rsqrt(u_xlat6);
    u_xlat0.xyz = ((float3)(u_xlat6)) * u_xlat0.xyz;
    u_xlat0.x = dot(u_xlat0.xyz, i.in_NORMAL0.xyz);
    u_xlat0.x = log2(abs(u_xlat0.x));
    u_xlat0.x = u_xlat0.x * _EdgeFadePow;
    u_xlat0.x = exp2(u_xlat0.x);
    u_xlat0.x = min(u_xlat0.x, 1.0);
    u_xlat0.x = u_xlat0.x * i.in_COLOR0.w;
    o.vs_COLOR0.w = u_xlat0.x;
    o.vs_COLOR0.xyz = i.in_COLOR0.xyz;
    o.vs_TEXCOORD0 = i.in_TEXCOORD0.xyxy;
    o.vs_TEXCOORD1 = i.in_TEXCOORD1;
    return o;

}
float4 frag(V i):SV_Target{float4 result=0;
float3 u_xlat0;
float4 u_xlat1;
float4 u_xlat16_1;
bool3 u_xlatb1;
bool2 u_xlatb2;
float4 u_xlat16_3;
float4 u_xlat16_4;
float2 u_xlat5;
float2 u_xlat16_5;
float u_xlat15;

    u_xlat0.x = log2(_HdrMultiply);
    u_xlat0.x = u_xlat0.x * 0.416666657;
    u_xlat0.x = exp2(u_xlat0.x);
    u_xlat0.x = u_xlat0.x * 1.05499995 + -0.0549999997;
    u_xlat0.x = max(u_xlat0.x, 0.0);
    u_xlat5.xy = _Time.yy * _DistortScrolling.xy;
    u_xlat5.xy = frac(u_xlat5.xy);
    u_xlatb1.xyz = lessThan(float4(0.0, 0.0, 0.0, 0.0), float4(_UseUV2Distortion, _UVDistortionAdd, _SingleChannel, _UseUV2Distortion)).xyz;
    u_xlat1.xw = (u_xlatb1.x) ? i.vs_TEXCOORD1.xy : i.vs_TEXCOORD0.xy;
    u_xlat1.xw = u_xlat1.xw * _DistortScrolling.zw + i.vs_TEXCOORD0.zw;
    u_xlat5.xy = u_xlat5.xy + u_xlat1.xw;
    u_xlat16_5.xy = tex2D(_DistortTex, u_xlat5.xy).xy;
    u_xlat1.xw = u_xlat16_5.xy * float2(2.0, 2.0) + float2(-1.0, -1.0);
    u_xlat5.xy = u_xlat16_5.xy + (-i.vs_TEXCOORD0.xy);
    u_xlat5.xy = ((float2)(_Distort)) * u_xlat5.xy + i.vs_TEXCOORD0.xy;
    u_xlat1.xw = u_xlat1.xw * ((float2)(_Distort)) + i.vs_TEXCOORD0.xy;
    u_xlat5.xy = (u_xlatb1.y) ? u_xlat1.xw : u_xlat5.xy;
    u_xlat1.xy = u_xlat5.xy + (-i.vs_TEXCOORD0.xy);
    u_xlat15 = i.vs_TEXCOORD0.y * 0.5;
    u_xlat1.xy = ((float2)(u_xlat15)) * u_xlat1.xy + i.vs_TEXCOORD0.xy;
    u_xlatb2.xy = lessThan(float4(0.0, 0.0, 0.0, 0.0), float4(_FadeAlongU, _HdrMultiply, _FadeAlongU, _FadeAlongU)).xy;
    u_xlat5.xy = (u_xlatb2.x) ? u_xlat1.xy : u_xlat5.xy;
    u_xlat16_3 = tex2D(_MainTex, u_xlat5.xy);
    u_xlat16_4.xyz = (u_xlatb1.z) ? float3(1.0, 1.0, 1.0) : u_xlat16_3.xyz;
    u_xlat16_4.w = (u_xlatb1.z) ? u_xlat16_3.x : u_xlat16_3.w;
    u_xlat16_1 = u_xlat16_4 * i.vs_COLOR0;
    u_xlat16_4.xyz = u_xlat0.xxx * u_xlat16_1.xyz;
    u_xlat16_4.xyz = (u_xlatb2.y) ? u_xlat16_4.xyz : u_xlat16_1.xyz;
    u_xlat0.xyz = u_xlat16_4.xyz + float3(-1.0, -1.0, -1.0);
    u_xlat0.xyz = u_xlat16_1.www * u_xlat0.xyz + float3(1.0, 1.0, 1.0);
    result.w = min(u_xlat16_1.w, 1.0);
    result.xyz = u_xlat0.xyz;
    return result;

}

#elif !defined(SOFTPARTICLES_ON) && !defined(_ALPHABLEND_ON) && !defined(_ALPHAMODULATE_ON) && !defined(_ALPHAPREMULTIPLY_ON) && !defined(_ALPHATEST_ON) && defined(_CFXR_ADDITIVE) && defined(_CFXR_DISSOLVE) && !defined(_CFXR_EDGE_FADING) && !defined(_CFXR_FONT_COLORS) && !defined(_CFXR_LIGHTING_ALL) && !defined(_CFXR_LIGHTING_BACK) && !defined(_CFXR_LIGHTING_WPOS_OFFSET) && !defined(_CFXR_OVERLAYTEX_1X) && !defined(_CFXR_SECONDCOLOR_LERP) && !defined(_CFXR_UV_DISTORTION) && !defined(_EMISSION) && defined(_FADING_ON) && !defined(_FLIPBOOK_BLENDING) && !defined(_NORMALMAP)
// Original GLES program 65; _CFXR_DISSOLVE,_FADING_ON,_CFXR_ADDITIVE
float _SingleChannel;
float _UseDissolveOffsetUV;
float _InvertDissolveTex;
float _DoubleDissolve;
float2 _DissolveScroll;
float _DissolveSmooth;
float _HdrMultiply;
float4 _DissolveTex_ST;
sampler2D _MainTex;
sampler2D _DissolveTex;
struct A{float4 in_POSITION0:POSITION0;float4 in_COLOR0:COLOR0;float4 in_TEXCOORD0:TEXCOORD0;float4 in_TEXCOORD1:TEXCOORD1;};
struct V{float4 vertex:SV_POSITION;float4 vs_COLOR0:TEXCOORD0;float4 vs_TEXCOORD0:TEXCOORD1;float4 vs_TEXCOORD1:TEXCOORD2;};
V vert(A i){V o=(V)0;
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
    o.vs_TEXCOORD1 = i.in_TEXCOORD1;
    return o;

}
float4 frag(V i):SV_Target{float4 result=0;
float2 u_xlat0;
float4 u_xlat16_0;
bool u_xlatb0;
float3 u_xlat16_1;
float4 u_xlat16_2;
float4 u_xlat16_3;
float u_xlat4;
bool u_xlatb4;
float u_xlat5;
float u_xlat16_6;
float2 u_xlat10;
bool2 u_xlatb10;
float u_xlat16_11;
float u_xlat16_16;

    u_xlat0.xy = _Time.yy * float2(_DissolveScroll.x, _DissolveScroll.y);
    u_xlat0.xy = frac(u_xlat0.xy);
    u_xlat10.xy = i.vs_TEXCOORD0.xy * _DissolveTex_ST.xy + _DissolveTex_ST.zw;
    u_xlat0.xy = u_xlat0.xy + u_xlat10.xy;
    u_xlatb10.xy = lessThan(float4(0.0, 0.0, 0.0, 0.0), float4(_SingleChannel, _UseDissolveOffsetUV, _SingleChannel, _UseDissolveOffsetUV)).xy;
    u_xlat0.xy = (u_xlatb10.y) ? u_xlat0.xy : i.vs_TEXCOORD0.xy;
    u_xlat16_0.x = tex2D(_DissolveTex, u_xlat0.xy).x;
    u_xlat16_1.x = u_xlat16_0.x * 2.0 + -1.0;
    u_xlat5 = u_xlat16_1.x * i.vs_TEXCOORD1.z + i.vs_TEXCOORD0.x;
    u_xlat16_1.x = (u_xlatb10.y) ? u_xlat5 : u_xlat16_0.x;
    u_xlat16_6 = (-u_xlat16_1.x) + 1.0;
    u_xlatb0 = 0.0>=_InvertDissolveTex;
    u_xlat16_1.x = (u_xlatb0) ? u_xlat16_6 : u_xlat16_1.x;
    u_xlat16_6 = u_xlat16_1.x + _DissolveSmooth;
    u_xlat16_1.x = u_xlat16_1.x + (-_DissolveSmooth);
    u_xlat16_6 = (-u_xlat16_1.x) + u_xlat16_6;
    u_xlat16_6 = float(1.0) / u_xlat16_6;
    u_xlat16_11 = _DissolveSmooth * 2.0 + 1.0;
    u_xlat16_11 = i.vs_TEXCOORD1.x * u_xlat16_11 + (-_DissolveSmooth);
    u_xlat16_16 = (-u_xlat16_1.x) + u_xlat16_11;
    u_xlat16_16 = u_xlat16_6 * u_xlat16_16;
    u_xlat16_16 = clamp(u_xlat16_16, 0.0, 1.0);
    u_xlat16_2.x = u_xlat16_16 * -2.0 + 3.0;
    u_xlat16_16 = u_xlat16_16 * u_xlat16_16;
    u_xlat16_16 = u_xlat16_16 * u_xlat16_2.x;
    u_xlat16_2 = tex2D(_MainTex, i.vs_TEXCOORD0.xy);
    u_xlat16_3.xyz = (u_xlatb10.x) ? float3(1.0, 1.0, 1.0) : u_xlat16_2.xyz;
    u_xlat16_3.w = (u_xlatb10.x) ? u_xlat16_2.x : u_xlat16_2.w;
    u_xlat16_0 = u_xlat16_3 * i.vs_COLOR0;
    u_xlat16_16 = u_xlat16_16 * u_xlat16_0.w;
    u_xlatb4 = 0.0<_DoubleDissolve;
    u_xlat16_3.x = (u_xlatb4) ? i.vs_TEXCOORD1.y : 0.0;
    u_xlat16_11 = u_xlat16_11 + (-u_xlat16_3.x);
    u_xlatb4 = 0.0<u_xlat16_3.x;
    u_xlat16_1.x = (-u_xlat16_1.x) + u_xlat16_11;
    u_xlat16_1.x = u_xlat16_6 * u_xlat16_1.x;
    u_xlat16_1.x = clamp(u_xlat16_1.x, 0.0, 1.0);
    u_xlat16_6 = u_xlat16_1.x * -2.0 + 3.0;
    u_xlat16_1.x = u_xlat16_1.x * u_xlat16_1.x;
    u_xlat16_1.x = (-u_xlat16_6) * u_xlat16_1.x + u_xlat16_16;
    u_xlat16_1.x = clamp(u_xlat16_1.x, 0.0, 1.0);
    u_xlat16_1.x = (u_xlatb4) ? u_xlat16_1.x : u_xlat16_16;
    result.w = min(u_xlat16_1.x, 1.0);
    u_xlat4 = log2(_HdrMultiply);
    u_xlat4 = u_xlat4 * 0.416666657;
    u_xlat4 = exp2(u_xlat4);
    u_xlat4 = u_xlat4 * 1.05499995 + -0.0549999997;
    u_xlat4 = max(u_xlat4, 0.0);
    u_xlat16_1.xyz = u_xlat16_0.xyz * ((float3)(u_xlat4));
    u_xlatb4 = 0.0<_HdrMultiply;
    result.xyz = (bool(u_xlatb4)) ? u_xlat16_1.xyz : u_xlat16_0.xyz;
    return result;

}

#elif !defined(SOFTPARTICLES_ON) && !defined(_ALPHABLEND_ON) && !defined(_ALPHAMODULATE_ON) && !defined(_ALPHAPREMULTIPLY_ON) && defined(_ALPHATEST_ON) && defined(_CFXR_ADDITIVE) && !defined(_CFXR_DISSOLVE) && !defined(_CFXR_EDGE_FADING) && !defined(_CFXR_FONT_COLORS) && !defined(_CFXR_LIGHTING_ALL) && !defined(_CFXR_LIGHTING_BACK) && !defined(_CFXR_LIGHTING_WPOS_OFFSET) && !defined(_CFXR_OVERLAYTEX_1X) && !defined(_CFXR_SECONDCOLOR_LERP) && !defined(_CFXR_UV_DISTORTION) && !defined(_EMISSION) && defined(_FADING_ON) && !defined(_FLIPBOOK_BLENDING) && !defined(_NORMALMAP)
// Original GLES program 68; _FADING_ON,_ALPHATEST_ON,_CFXR_ADDITIVE
float _SingleChannel;
float _HdrMultiply;
float _Cutoff;
sampler2D _MainTex;
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
float4 u_xlat16_0;
float u_xlat1;
bool u_xlatb1;
float4 u_xlat16_2;

    u_xlat16_0 = tex2D(_MainTex, i.vs_TEXCOORD0.xy);
    u_xlatb1 = 0.0<_SingleChannel;
    u_xlat16_2.w = (u_xlatb1) ? u_xlat16_0.x : u_xlat16_0.w;
    u_xlat16_2.xyz = (bool(u_xlatb1)) ? float3(1.0, 1.0, 1.0) : u_xlat16_0.xyz;
    u_xlat16_0 = u_xlat16_2 * i.vs_COLOR0;
    u_xlat16_2.x = u_xlat16_2.w * i.vs_COLOR0.w + (-_Cutoff);
    u_xlatb1 = u_xlat16_2.x<0.0;
    if(u_xlatb1){discard;}
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

#elif defined(SOFTPARTICLES_ON) && defined(_ALPHABLEND_ON) && !defined(_ALPHAMODULATE_ON) && !defined(_ALPHAPREMULTIPLY_ON) && !defined(_ALPHATEST_ON) && !defined(_CFXR_ADDITIVE) && defined(_CFXR_DISSOLVE) && !defined(_CFXR_EDGE_FADING) && !defined(_CFXR_FONT_COLORS) && !defined(_CFXR_LIGHTING_ALL) && !defined(_CFXR_LIGHTING_BACK) && !defined(_CFXR_LIGHTING_WPOS_OFFSET) && !defined(_CFXR_OVERLAYTEX_1X) && !defined(_CFXR_SECONDCOLOR_LERP) && !defined(_CFXR_UV_DISTORTION) && !defined(_EMISSION) && !defined(_FADING_ON) && !defined(_FLIPBOOK_BLENDING) && !defined(_NORMALMAP)
// Original GLES program 72; SOFTPARTICLES_ON,_CFXR_DISSOLVE,_ALPHABLEND_ON
float _SingleChannel;
float _UseDissolveOffsetUV;
float _InvertDissolveTex;
float _DoubleDissolve;
float2 _DissolveScroll;
float _DissolveSmooth;
float _HdrMultiply;
float4 _DissolveTex_ST;
sampler2D _MainTex;
sampler2D _DissolveTex;
struct A{float4 in_POSITION0:POSITION0;float4 in_COLOR0:COLOR0;float4 in_TEXCOORD0:TEXCOORD0;float4 in_TEXCOORD1:TEXCOORD1;};
struct V{float4 vertex:SV_POSITION;float4 vs_COLOR0:TEXCOORD0;float4 vs_TEXCOORD0:TEXCOORD1;float4 vs_TEXCOORD1:TEXCOORD2;};
V vert(A i){V o=(V)0;
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
    o.vs_TEXCOORD1 = i.in_TEXCOORD1;
    return o;

}
float4 frag(V i):SV_Target{float4 result=0;
float2 u_xlat0;
float4 u_xlat16_0;
bool u_xlatb0;
float3 u_xlat16_1;
float4 u_xlat16_2;
float4 u_xlat16_3;
float u_xlat4;
bool u_xlatb4;
float u_xlat5;
float u_xlat16_6;
float2 u_xlat10;
bool2 u_xlatb10;
float u_xlat16_11;
float u_xlat16_16;

    u_xlat0.xy = _Time.yy * float2(_DissolveScroll.x, _DissolveScroll.y);
    u_xlat0.xy = frac(u_xlat0.xy);
    u_xlat10.xy = i.vs_TEXCOORD0.xy * _DissolveTex_ST.xy + _DissolveTex_ST.zw;
    u_xlat0.xy = u_xlat0.xy + u_xlat10.xy;
    u_xlatb10.xy = lessThan(float4(0.0, 0.0, 0.0, 0.0), float4(_SingleChannel, _UseDissolveOffsetUV, _SingleChannel, _UseDissolveOffsetUV)).xy;
    u_xlat0.xy = (u_xlatb10.y) ? u_xlat0.xy : i.vs_TEXCOORD0.xy;
    u_xlat16_0.x = tex2D(_DissolveTex, u_xlat0.xy).x;
    u_xlat16_1.x = u_xlat16_0.x * 2.0 + -1.0;
    u_xlat5 = u_xlat16_1.x * i.vs_TEXCOORD1.z + i.vs_TEXCOORD0.x;
    u_xlat16_1.x = (u_xlatb10.y) ? u_xlat5 : u_xlat16_0.x;
    u_xlat16_6 = (-u_xlat16_1.x) + 1.0;
    u_xlatb0 = 0.0>=_InvertDissolveTex;
    u_xlat16_1.x = (u_xlatb0) ? u_xlat16_6 : u_xlat16_1.x;
    u_xlat16_6 = u_xlat16_1.x + _DissolveSmooth;
    u_xlat16_1.x = u_xlat16_1.x + (-_DissolveSmooth);
    u_xlat16_6 = (-u_xlat16_1.x) + u_xlat16_6;
    u_xlat16_6 = float(1.0) / u_xlat16_6;
    u_xlat16_11 = _DissolveSmooth * 2.0 + 1.0;
    u_xlat16_11 = i.vs_TEXCOORD1.x * u_xlat16_11 + (-_DissolveSmooth);
    u_xlat16_16 = (-u_xlat16_1.x) + u_xlat16_11;
    u_xlat16_16 = u_xlat16_6 * u_xlat16_16;
    u_xlat16_16 = clamp(u_xlat16_16, 0.0, 1.0);
    u_xlat16_2.x = u_xlat16_16 * -2.0 + 3.0;
    u_xlat16_16 = u_xlat16_16 * u_xlat16_16;
    u_xlat16_16 = u_xlat16_16 * u_xlat16_2.x;
    u_xlat16_2 = tex2D(_MainTex, i.vs_TEXCOORD0.xy);
    u_xlat16_3.xyz = (u_xlatb10.x) ? float3(1.0, 1.0, 1.0) : u_xlat16_2.xyz;
    u_xlat16_3.w = (u_xlatb10.x) ? u_xlat16_2.x : u_xlat16_2.w;
    u_xlat16_0 = u_xlat16_3 * i.vs_COLOR0;
    u_xlat16_16 = u_xlat16_16 * u_xlat16_0.w;
    u_xlatb4 = 0.0<_DoubleDissolve;
    u_xlat16_3.x = (u_xlatb4) ? i.vs_TEXCOORD1.y : 0.0;
    u_xlat16_11 = u_xlat16_11 + (-u_xlat16_3.x);
    u_xlatb4 = 0.0<u_xlat16_3.x;
    u_xlat16_1.x = (-u_xlat16_1.x) + u_xlat16_11;
    u_xlat16_1.x = u_xlat16_6 * u_xlat16_1.x;
    u_xlat16_1.x = clamp(u_xlat16_1.x, 0.0, 1.0);
    u_xlat16_6 = u_xlat16_1.x * -2.0 + 3.0;
    u_xlat16_1.x = u_xlat16_1.x * u_xlat16_1.x;
    u_xlat16_1.x = (-u_xlat16_6) * u_xlat16_1.x + u_xlat16_16;
    u_xlat16_1.x = clamp(u_xlat16_1.x, 0.0, 1.0);
    u_xlat16_1.x = (u_xlatb4) ? u_xlat16_1.x : u_xlat16_16;
    result.w = min(u_xlat16_1.x, 1.0);
    u_xlat4 = log2(_HdrMultiply);
    u_xlat4 = u_xlat4 * 0.416666657;
    u_xlat4 = exp2(u_xlat4);
    u_xlat4 = u_xlat4 * 1.05499995 + -0.0549999997;
    u_xlat4 = max(u_xlat4, 0.0);
    u_xlat16_1.xyz = u_xlat16_0.xyz * ((float3)(u_xlat4));
    u_xlatb4 = 0.0<_HdrMultiply;
    result.xyz = (bool(u_xlatb4)) ? u_xlat16_1.xyz : u_xlat16_0.xyz;
    return result;

}

#elif defined(SOFTPARTICLES_ON) && defined(_ALPHABLEND_ON) && !defined(_ALPHAMODULATE_ON) && !defined(_ALPHAPREMULTIPLY_ON) && !defined(_ALPHATEST_ON) && !defined(_CFXR_ADDITIVE) && !defined(_CFXR_DISSOLVE) && !defined(_CFXR_EDGE_FADING) && !defined(_CFXR_FONT_COLORS) && !defined(_CFXR_LIGHTING_ALL) && !defined(_CFXR_LIGHTING_BACK) && !defined(_CFXR_LIGHTING_WPOS_OFFSET) && !defined(_CFXR_OVERLAYTEX_1X) && !defined(_CFXR_SECONDCOLOR_LERP) && !defined(_CFXR_UV_DISTORTION) && !defined(_EMISSION) && defined(_FADING_ON) && !defined(_FLIPBOOK_BLENDING) && !defined(_NORMALMAP)
// Original GLES program 73; SOFTPARTICLES_ON,_FADING_ON,_ALPHABLEND_ON
float _SingleChannel;
float _HdrMultiply;
float _SoftParticlesFadeDistanceNear;
float _SoftParticlesFadeDistanceFar;
sampler2D _MainTex;
sampler2D _CameraDepthTexture;
struct A{float4 in_POSITION0:POSITION0;float4 in_COLOR0:COLOR0;float4 in_TEXCOORD0:TEXCOORD0;float4 in_TEXCOORD1:TEXCOORD1;};
struct V{float4 vertex:SV_POSITION;float4 vs_COLOR0:TEXCOORD0;float4 vs_TEXCOORD0:TEXCOORD1;float4 vs_TEXCOORD3:TEXCOORD2;};
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
    o.vs_TEXCOORD3.z = (-u_xlat0.x);
    u_xlat0.x = u_xlat1.y * _ProjectionParams.x;
    u_xlat0.w = u_xlat0.x * 0.5;
    u_xlat0.xz = u_xlat1.xw * float2(0.5, 0.5);
    o.vs_TEXCOORD3.w = u_xlat1.w;
    o.vs_TEXCOORD3.xy = u_xlat0.zz + u_xlat0.xw;
    return o;

}
float4 frag(V i):SV_Target{float4 result=0;
float2 u_xlat0;
bool u_xlatb0;
float4 u_xlat16_1;
float4 u_xlat16_2;
float u_xlat3;
bool u_xlatb3;
bool u_xlatb6;

    u_xlat0.x = log2(_HdrMultiply);
    u_xlat0.x = u_xlat0.x * 0.416666657;
    u_xlat0.x = exp2(u_xlat0.x);
    u_xlat0.x = u_xlat0.x * 1.05499995 + -0.0549999997;
    u_xlat0.x = max(u_xlat0.x, 0.0);
    u_xlat16_1 = tex2D(_MainTex, i.vs_TEXCOORD0.xy);
    u_xlatb3 = 0.0<_SingleChannel;
    u_xlat16_2.xyz = (bool(u_xlatb3)) ? float3(1.0, 1.0, 1.0) : u_xlat16_1.xyz;
    u_xlat16_2.w = (u_xlatb3) ? u_xlat16_1.x : u_xlat16_1.w;
    u_xlat16_1 = u_xlat16_2 * i.vs_COLOR0;
    u_xlat16_2.xyz = u_xlat0.xxx * u_xlat16_1.xyz;
    u_xlatb0 = 0.0<_HdrMultiply;
    result.xyz = (bool(u_xlatb0)) ? u_xlat16_2.xyz : u_xlat16_1.xyz;
    u_xlat0.xy = i.vs_TEXCOORD3.xy / i.vs_TEXCOORD3.ww;
    u_xlat0.x = tex2D(_CameraDepthTexture, u_xlat0.xy).x;
    u_xlat3 = _ZBufferParams.z * u_xlat0.x + _ZBufferParams.w;
    u_xlat0.x = u_xlat0.x * _ProjectionParams.z + _ProjectionParams.y;
    u_xlat3 = float(1.0) / u_xlat3;
    u_xlatb6 = unity_OrthoParams.w==1.0;
    u_xlat0.x = (u_xlatb6) ? u_xlat0.x : u_xlat3;
    u_xlat0.x = u_xlat0.x + (-_SoftParticlesFadeDistanceNear);
    u_xlat0.x = u_xlat0.x + (-i.vs_TEXCOORD3.z);
    u_xlat0.x = u_xlat0.x * _SoftParticlesFadeDistanceFar;
    u_xlat0.x = clamp(u_xlat0.x, 0.0, 1.0);
    u_xlat0.x = u_xlat0.x * u_xlat16_1.w;
    result.w = min(u_xlat0.x, 1.0);
    return result;

}

#elif defined(SOFTPARTICLES_ON) && defined(_ALPHABLEND_ON) && !defined(_ALPHAMODULATE_ON) && !defined(_ALPHAPREMULTIPLY_ON) && !defined(_ALPHATEST_ON) && !defined(_CFXR_ADDITIVE) && !defined(_CFXR_DISSOLVE) && !defined(_CFXR_EDGE_FADING) && !defined(_CFXR_FONT_COLORS) && !defined(_CFXR_LIGHTING_ALL) && !defined(_CFXR_LIGHTING_BACK) && !defined(_CFXR_LIGHTING_WPOS_OFFSET) && !defined(_CFXR_OVERLAYTEX_1X) && !defined(_CFXR_SECONDCOLOR_LERP) && !defined(_CFXR_UV_DISTORTION) && !defined(_EMISSION) && !defined(_FADING_ON) && defined(_FLIPBOOK_BLENDING) && !defined(_NORMALMAP)
// Original GLES program 85; SOFTPARTICLES_ON,_FLIPBOOK_BLENDING,_ALPHABLEND_ON
float _SingleChannel;
float _HdrMultiply;
sampler2D _MainTex;
struct A{float4 in_POSITION0:POSITION0;float4 in_COLOR0:COLOR0;float4 in_TEXCOORD0:TEXCOORD0;float4 in_TEXCOORD1:TEXCOORD1;};
struct V{float4 vertex:SV_POSITION;float4 vs_COLOR0:TEXCOORD0;float4 vs_TEXCOORD0:TEXCOORD1;float4 vs_TEXCOORD1:TEXCOORD2;};
V vert(A i){V o=(V)0;
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
    o.vs_TEXCOORD1 = i.in_TEXCOORD1;
    return o;

}
float4 frag(V i):SV_Target{float4 result=0;
float u_xlat0;
bool u_xlatb0;
float4 u_xlat1;
float4 u_xlat16_1;
float4 u_xlat2;
float3 u_xlat16_2;
float4 u_xlat16_3;
float4 u_xlat16_4;
bool u_xlatb5;

    u_xlat0 = log2(_HdrMultiply);
    u_xlat0 = u_xlat0 * 0.416666657;
    u_xlat0 = exp2(u_xlat0);
    u_xlat0 = u_xlat0 * 1.05499995 + -0.0549999997;
    u_xlat0 = max(u_xlat0, 0.0);
    u_xlat16_1 = tex2D(_MainTex, i.vs_TEXCOORD0.zw);
    u_xlatb5 = 0.0<_SingleChannel;
    u_xlat16_2.xyz = (bool(u_xlatb5)) ? u_xlat16_1.xxx : u_xlat16_1.yzw;
    u_xlat16_3 = tex2D(_MainTex, i.vs_TEXCOORD0.xy);
    u_xlat16_4.w = (u_xlatb5) ? u_xlat16_3.x : u_xlat16_3.w;
    u_xlat16_4.xyz = (bool(u_xlatb5)) ? float3(1.0, 1.0, 1.0) : u_xlat16_3.xyz;
    u_xlat2.yzw = u_xlat16_2.xyz + (-u_xlat16_4.yzw);
    u_xlat2.x = u_xlat16_1.x + (-u_xlat16_4.x);
    u_xlat1 = i.vs_TEXCOORD1.yyyy * u_xlat2 + u_xlat16_4;
    u_xlat16_1 = u_xlat1 * i.vs_COLOR0;
    u_xlat16_4.xyz = ((float3)(u_xlat0)) * u_xlat16_1.xyz;
    u_xlatb0 = 0.0<_HdrMultiply;
    result.xyz = (bool(u_xlatb0)) ? u_xlat16_4.xyz : u_xlat16_1.xyz;
    result.w = min(u_xlat16_1.w, 1.0);
    return result;

}

#elif defined(SOFTPARTICLES_ON) && defined(_ALPHABLEND_ON) && !defined(_ALPHAMODULATE_ON) && !defined(_ALPHAPREMULTIPLY_ON) && defined(_ALPHATEST_ON) && !defined(_CFXR_ADDITIVE) && !defined(_CFXR_DISSOLVE) && !defined(_CFXR_EDGE_FADING) && !defined(_CFXR_FONT_COLORS) && !defined(_CFXR_LIGHTING_ALL) && !defined(_CFXR_LIGHTING_BACK) && !defined(_CFXR_LIGHTING_WPOS_OFFSET) && !defined(_CFXR_OVERLAYTEX_1X) && !defined(_CFXR_SECONDCOLOR_LERP) && !defined(_CFXR_UV_DISTORTION) && !defined(_EMISSION) && !defined(_FADING_ON) && !defined(_FLIPBOOK_BLENDING) && !defined(_NORMALMAP)
// Original GLES program 87; SOFTPARTICLES_ON,_ALPHATEST_ON,_ALPHABLEND_ON
float _SingleChannel;
float _HdrMultiply;
float _Cutoff;
sampler2D _MainTex;
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
float4 u_xlat16_0;
float u_xlat1;
bool u_xlatb1;
float4 u_xlat16_2;

    u_xlat16_0 = tex2D(_MainTex, i.vs_TEXCOORD0.xy);
    u_xlatb1 = 0.0<_SingleChannel;
    u_xlat16_2.w = (u_xlatb1) ? u_xlat16_0.x : u_xlat16_0.w;
    u_xlat16_2.xyz = (bool(u_xlatb1)) ? float3(1.0, 1.0, 1.0) : u_xlat16_0.xyz;
    u_xlat16_0 = u_xlat16_2 * i.vs_COLOR0;
    u_xlat16_2.x = u_xlat16_2.w * i.vs_COLOR0.w + (-_Cutoff);
    u_xlatb1 = u_xlat16_2.x<0.0;
    if(u_xlatb1){discard;}
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

#elif defined(SOFTPARTICLES_ON) && !defined(_ALPHABLEND_ON) && !defined(_ALPHAMODULATE_ON) && defined(_ALPHAPREMULTIPLY_ON) && !defined(_ALPHATEST_ON) && !defined(_CFXR_ADDITIVE) && !defined(_CFXR_DISSOLVE) && !defined(_CFXR_EDGE_FADING) && !defined(_CFXR_FONT_COLORS) && !defined(_CFXR_LIGHTING_ALL) && !defined(_CFXR_LIGHTING_BACK) && !defined(_CFXR_LIGHTING_WPOS_OFFSET) && !defined(_CFXR_OVERLAYTEX_1X) && !defined(_CFXR_SECONDCOLOR_LERP) && !defined(_CFXR_UV_DISTORTION) && !defined(_EMISSION) && defined(_FADING_ON) && !defined(_FLIPBOOK_BLENDING) && !defined(_NORMALMAP)
// Original GLES program 96; SOFTPARTICLES_ON,_FADING_ON,_ALPHAPREMULTIPLY_ON
float _SingleChannel;
float _HdrMultiply;
float _SoftParticlesFadeDistanceNear;
float _SoftParticlesFadeDistanceFar;
sampler2D _MainTex;
sampler2D _CameraDepthTexture;
struct A{float4 in_POSITION0:POSITION0;float4 in_COLOR0:COLOR0;float4 in_TEXCOORD0:TEXCOORD0;float4 in_TEXCOORD1:TEXCOORD1;};
struct V{float4 vertex:SV_POSITION;float4 vs_COLOR0:TEXCOORD0;float4 vs_TEXCOORD0:TEXCOORD1;float4 vs_TEXCOORD3:TEXCOORD2;};
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
    o.vs_TEXCOORD3.z = (-u_xlat0.x);
    u_xlat0.x = u_xlat1.y * _ProjectionParams.x;
    u_xlat0.w = u_xlat0.x * 0.5;
    u_xlat0.xz = u_xlat1.xw * float2(0.5, 0.5);
    o.vs_TEXCOORD3.w = u_xlat1.w;
    o.vs_TEXCOORD3.xy = u_xlat0.zz + u_xlat0.xw;
    return o;

}
float4 frag(V i):SV_Target{float4 result=0;
float2 u_xlat0;
bool u_xlatb0;
float4 u_xlat16_1;
float4 u_xlat16_2;
float u_xlat3;
bool u_xlatb3;
bool u_xlatb6;

    u_xlat0.x = log2(_HdrMultiply);
    u_xlat0.x = u_xlat0.x * 0.416666657;
    u_xlat0.x = exp2(u_xlat0.x);
    u_xlat0.x = u_xlat0.x * 1.05499995 + -0.0549999997;
    u_xlat0.x = max(u_xlat0.x, 0.0);
    u_xlat16_1 = tex2D(_MainTex, i.vs_TEXCOORD0.xy);
    u_xlatb3 = 0.0<_SingleChannel;
    u_xlat16_2.xyz = (bool(u_xlatb3)) ? float3(1.0, 1.0, 1.0) : u_xlat16_1.xyz;
    u_xlat16_2.w = (u_xlatb3) ? u_xlat16_1.x : u_xlat16_1.w;
    u_xlat16_1 = u_xlat16_2 * i.vs_COLOR0;
    u_xlat16_2.xyz = u_xlat0.xxx * u_xlat16_1.xyz;
    u_xlatb0 = 0.0<_HdrMultiply;
    u_xlat16_2.xyz = (bool(u_xlatb0)) ? u_xlat16_2.xyz : u_xlat16_1.xyz;
    result.xyz = u_xlat16_1.www * u_xlat16_2.xyz;
    u_xlat0.xy = i.vs_TEXCOORD3.xy / i.vs_TEXCOORD3.ww;
    u_xlat0.x = tex2D(_CameraDepthTexture, u_xlat0.xy).x;
    u_xlat3 = _ZBufferParams.z * u_xlat0.x + _ZBufferParams.w;
    u_xlat0.x = u_xlat0.x * _ProjectionParams.z + _ProjectionParams.y;
    u_xlat3 = float(1.0) / u_xlat3;
    u_xlatb6 = unity_OrthoParams.w==1.0;
    u_xlat0.x = (u_xlatb6) ? u_xlat0.x : u_xlat3;
    u_xlat0.x = u_xlat0.x + (-_SoftParticlesFadeDistanceNear);
    u_xlat0.x = u_xlat0.x + (-i.vs_TEXCOORD3.z);
    u_xlat0.x = u_xlat0.x * _SoftParticlesFadeDistanceFar;
    u_xlat0.x = clamp(u_xlat0.x, 0.0, 1.0);
    u_xlat0.x = u_xlat0.x * u_xlat16_1.w;
    result.w = min(u_xlat0.x, 1.0);
    return result;

}

#elif defined(SOFTPARTICLES_ON) && !defined(_ALPHABLEND_ON) && !defined(_ALPHAMODULATE_ON) && !defined(_ALPHAPREMULTIPLY_ON) && !defined(_ALPHATEST_ON) && defined(_CFXR_ADDITIVE) && defined(_CFXR_DISSOLVE) && !defined(_CFXR_EDGE_FADING) && !defined(_CFXR_FONT_COLORS) && !defined(_CFXR_LIGHTING_ALL) && !defined(_CFXR_LIGHTING_BACK) && !defined(_CFXR_LIGHTING_WPOS_OFFSET) && !defined(_CFXR_OVERLAYTEX_1X) && !defined(_CFXR_SECONDCOLOR_LERP) && !defined(_CFXR_UV_DISTORTION) && !defined(_EMISSION) && !defined(_FADING_ON) && !defined(_FLIPBOOK_BLENDING) && !defined(_NORMALMAP)
// Original GLES program 99; SOFTPARTICLES_ON,_CFXR_DISSOLVE,_CFXR_ADDITIVE
float _SingleChannel;
float _UseDissolveOffsetUV;
float _InvertDissolveTex;
float _DoubleDissolve;
float2 _DissolveScroll;
float _DissolveSmooth;
float _HdrMultiply;
float4 _DissolveTex_ST;
sampler2D _MainTex;
sampler2D _DissolveTex;
struct A{float4 in_POSITION0:POSITION0;float4 in_COLOR0:COLOR0;float4 in_TEXCOORD0:TEXCOORD0;float4 in_TEXCOORD1:TEXCOORD1;};
struct V{float4 vertex:SV_POSITION;float4 vs_COLOR0:TEXCOORD0;float4 vs_TEXCOORD0:TEXCOORD1;float4 vs_TEXCOORD1:TEXCOORD2;};
V vert(A i){V o=(V)0;
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
    o.vs_TEXCOORD1 = i.in_TEXCOORD1;
    return o;

}
float4 frag(V i):SV_Target{float4 result=0;
float2 u_xlat0;
float4 u_xlat16_0;
bool u_xlatb0;
float3 u_xlat16_1;
float4 u_xlat16_2;
float4 u_xlat16_3;
float u_xlat4;
bool u_xlatb4;
float u_xlat5;
float u_xlat16_6;
float2 u_xlat10;
bool2 u_xlatb10;
float u_xlat16_11;
float u_xlat16_16;

    u_xlat0.xy = _Time.yy * float2(_DissolveScroll.x, _DissolveScroll.y);
    u_xlat0.xy = frac(u_xlat0.xy);
    u_xlat10.xy = i.vs_TEXCOORD0.xy * _DissolveTex_ST.xy + _DissolveTex_ST.zw;
    u_xlat0.xy = u_xlat0.xy + u_xlat10.xy;
    u_xlatb10.xy = lessThan(float4(0.0, 0.0, 0.0, 0.0), float4(_SingleChannel, _UseDissolveOffsetUV, _SingleChannel, _UseDissolveOffsetUV)).xy;
    u_xlat0.xy = (u_xlatb10.y) ? u_xlat0.xy : i.vs_TEXCOORD0.xy;
    u_xlat16_0.x = tex2D(_DissolveTex, u_xlat0.xy).x;
    u_xlat16_1.x = u_xlat16_0.x * 2.0 + -1.0;
    u_xlat5 = u_xlat16_1.x * i.vs_TEXCOORD1.z + i.vs_TEXCOORD0.x;
    u_xlat16_1.x = (u_xlatb10.y) ? u_xlat5 : u_xlat16_0.x;
    u_xlat16_6 = (-u_xlat16_1.x) + 1.0;
    u_xlatb0 = 0.0>=_InvertDissolveTex;
    u_xlat16_1.x = (u_xlatb0) ? u_xlat16_6 : u_xlat16_1.x;
    u_xlat16_6 = u_xlat16_1.x + _DissolveSmooth;
    u_xlat16_1.x = u_xlat16_1.x + (-_DissolveSmooth);
    u_xlat16_6 = (-u_xlat16_1.x) + u_xlat16_6;
    u_xlat16_6 = float(1.0) / u_xlat16_6;
    u_xlat16_11 = _DissolveSmooth * 2.0 + 1.0;
    u_xlat16_11 = i.vs_TEXCOORD1.x * u_xlat16_11 + (-_DissolveSmooth);
    u_xlat16_16 = (-u_xlat16_1.x) + u_xlat16_11;
    u_xlat16_16 = u_xlat16_6 * u_xlat16_16;
    u_xlat16_16 = clamp(u_xlat16_16, 0.0, 1.0);
    u_xlat16_2.x = u_xlat16_16 * -2.0 + 3.0;
    u_xlat16_16 = u_xlat16_16 * u_xlat16_16;
    u_xlat16_16 = u_xlat16_16 * u_xlat16_2.x;
    u_xlat16_2 = tex2D(_MainTex, i.vs_TEXCOORD0.xy);
    u_xlat16_3.xyz = (u_xlatb10.x) ? float3(1.0, 1.0, 1.0) : u_xlat16_2.xyz;
    u_xlat16_3.w = (u_xlatb10.x) ? u_xlat16_2.x : u_xlat16_2.w;
    u_xlat16_0 = u_xlat16_3 * i.vs_COLOR0;
    u_xlat16_16 = u_xlat16_16 * u_xlat16_0.w;
    u_xlatb4 = 0.0<_DoubleDissolve;
    u_xlat16_3.x = (u_xlatb4) ? i.vs_TEXCOORD1.y : 0.0;
    u_xlat16_11 = u_xlat16_11 + (-u_xlat16_3.x);
    u_xlatb4 = 0.0<u_xlat16_3.x;
    u_xlat16_1.x = (-u_xlat16_1.x) + u_xlat16_11;
    u_xlat16_1.x = u_xlat16_6 * u_xlat16_1.x;
    u_xlat16_1.x = clamp(u_xlat16_1.x, 0.0, 1.0);
    u_xlat16_6 = u_xlat16_1.x * -2.0 + 3.0;
    u_xlat16_1.x = u_xlat16_1.x * u_xlat16_1.x;
    u_xlat16_1.x = (-u_xlat16_6) * u_xlat16_1.x + u_xlat16_16;
    u_xlat16_1.x = clamp(u_xlat16_1.x, 0.0, 1.0);
    u_xlat16_1.x = (u_xlatb4) ? u_xlat16_1.x : u_xlat16_16;
    result.w = min(u_xlat16_1.x, 1.0);
    u_xlat4 = log2(_HdrMultiply);
    u_xlat4 = u_xlat4 * 0.416666657;
    u_xlat4 = exp2(u_xlat4);
    u_xlat4 = u_xlat4 * 1.05499995 + -0.0549999997;
    u_xlat4 = max(u_xlat4, 0.0);
    u_xlat16_1.xyz = u_xlat16_0.xyz * ((float3)(u_xlat4));
    u_xlatb4 = 0.0<_HdrMultiply;
    result.xyz = (bool(u_xlatb4)) ? u_xlat16_1.xyz : u_xlat16_0.xyz;
    return result;

}

#elif defined(SOFTPARTICLES_ON) && !defined(_ALPHABLEND_ON) && !defined(_ALPHAMODULATE_ON) && !defined(_ALPHAPREMULTIPLY_ON) && !defined(_ALPHATEST_ON) && defined(_CFXR_ADDITIVE) && !defined(_CFXR_DISSOLVE) && !defined(_CFXR_EDGE_FADING) && !defined(_CFXR_FONT_COLORS) && !defined(_CFXR_LIGHTING_ALL) && !defined(_CFXR_LIGHTING_BACK) && !defined(_CFXR_LIGHTING_WPOS_OFFSET) && !defined(_CFXR_OVERLAYTEX_1X) && !defined(_CFXR_SECONDCOLOR_LERP) && !defined(_CFXR_UV_DISTORTION) && !defined(_EMISSION) && defined(_FADING_ON) && !defined(_FLIPBOOK_BLENDING) && !defined(_NORMALMAP)
// Original GLES program 100; SOFTPARTICLES_ON,_FADING_ON,_CFXR_ADDITIVE
float _SingleChannel;
float _HdrMultiply;
float _SoftParticlesFadeDistanceNear;
float _SoftParticlesFadeDistanceFar;
sampler2D _MainTex;
sampler2D _CameraDepthTexture;
struct A{float4 in_POSITION0:POSITION0;float4 in_COLOR0:COLOR0;float4 in_TEXCOORD0:TEXCOORD0;float4 in_TEXCOORD1:TEXCOORD1;};
struct V{float4 vertex:SV_POSITION;float4 vs_COLOR0:TEXCOORD0;float4 vs_TEXCOORD0:TEXCOORD1;float4 vs_TEXCOORD3:TEXCOORD2;};
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
    o.vs_TEXCOORD3.z = (-u_xlat0.x);
    u_xlat0.x = u_xlat1.y * _ProjectionParams.x;
    u_xlat0.w = u_xlat0.x * 0.5;
    u_xlat0.xz = u_xlat1.xw * float2(0.5, 0.5);
    o.vs_TEXCOORD3.w = u_xlat1.w;
    o.vs_TEXCOORD3.xy = u_xlat0.zz + u_xlat0.xw;
    return o;

}
float4 frag(V i):SV_Target{float4 result=0;
float2 u_xlat0;
bool u_xlatb0;
float4 u_xlat16_1;
float4 u_xlat16_2;
float u_xlat3;
bool u_xlatb3;
bool u_xlatb6;

    u_xlat0.x = log2(_HdrMultiply);
    u_xlat0.x = u_xlat0.x * 0.416666657;
    u_xlat0.x = exp2(u_xlat0.x);
    u_xlat0.x = u_xlat0.x * 1.05499995 + -0.0549999997;
    u_xlat0.x = max(u_xlat0.x, 0.0);
    u_xlat16_1 = tex2D(_MainTex, i.vs_TEXCOORD0.xy);
    u_xlatb3 = 0.0<_SingleChannel;
    u_xlat16_2.xyz = (bool(u_xlatb3)) ? float3(1.0, 1.0, 1.0) : u_xlat16_1.xyz;
    u_xlat16_2.w = (u_xlatb3) ? u_xlat16_1.x : u_xlat16_1.w;
    u_xlat16_1 = u_xlat16_2 * i.vs_COLOR0;
    u_xlat16_2.xyz = u_xlat0.xxx * u_xlat16_1.xyz;
    u_xlatb0 = 0.0<_HdrMultiply;
    result.xyz = (bool(u_xlatb0)) ? u_xlat16_2.xyz : u_xlat16_1.xyz;
    u_xlat0.xy = i.vs_TEXCOORD3.xy / i.vs_TEXCOORD3.ww;
    u_xlat0.x = tex2D(_CameraDepthTexture, u_xlat0.xy).x;
    u_xlat3 = _ZBufferParams.z * u_xlat0.x + _ZBufferParams.w;
    u_xlat0.x = u_xlat0.x * _ProjectionParams.z + _ProjectionParams.y;
    u_xlat3 = float(1.0) / u_xlat3;
    u_xlatb6 = unity_OrthoParams.w==1.0;
    u_xlat0.x = (u_xlatb6) ? u_xlat0.x : u_xlat3;
    u_xlat0.x = u_xlat0.x + (-_SoftParticlesFadeDistanceNear);
    u_xlat0.x = u_xlat0.x + (-i.vs_TEXCOORD3.z);
    u_xlat0.x = u_xlat0.x * _SoftParticlesFadeDistanceFar;
    u_xlat0.x = clamp(u_xlat0.x, 0.0, 1.0);
    u_xlat0.x = u_xlat0.x * u_xlat16_1.w;
    result.w = min(u_xlat0.x, 1.0);
    return result;

}

#elif !defined(SOFTPARTICLES_ON) && defined(_ALPHABLEND_ON) && !defined(_ALPHAMODULATE_ON) && !defined(_ALPHAPREMULTIPLY_ON) && !defined(_ALPHATEST_ON) && !defined(_CFXR_ADDITIVE) && defined(_CFXR_DISSOLVE) && !defined(_CFXR_EDGE_FADING) && !defined(_CFXR_FONT_COLORS) && !defined(_CFXR_LIGHTING_ALL) && !defined(_CFXR_LIGHTING_BACK) && !defined(_CFXR_LIGHTING_WPOS_OFFSET) && !defined(_CFXR_OVERLAYTEX_1X) && !defined(_CFXR_SECONDCOLOR_LERP) && !defined(_CFXR_UV_DISTORTION) && !defined(_EMISSION) && !defined(_FADING_ON) && !defined(_FLIPBOOK_BLENDING) && !defined(_NORMALMAP)
// Original GLES program 36; _CFXR_DISSOLVE,_ALPHABLEND_ON
float _SingleChannel;
float _UseDissolveOffsetUV;
float _InvertDissolveTex;
float _DoubleDissolve;
float2 _DissolveScroll;
float _DissolveSmooth;
float _HdrMultiply;
float4 _DissolveTex_ST;
sampler2D _MainTex;
sampler2D _DissolveTex;
struct A{float4 in_POSITION0:POSITION0;float4 in_COLOR0:COLOR0;float4 in_TEXCOORD0:TEXCOORD0;float4 in_TEXCOORD1:TEXCOORD1;};
struct V{float4 vertex:SV_POSITION;float4 vs_COLOR0:TEXCOORD0;float4 vs_TEXCOORD0:TEXCOORD1;float4 vs_TEXCOORD1:TEXCOORD2;};
V vert(A i){V o=(V)0;
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
    o.vs_TEXCOORD1 = i.in_TEXCOORD1;
    return o;

}
float4 frag(V i):SV_Target{float4 result=0;
float2 u_xlat0;
float4 u_xlat16_0;
bool u_xlatb0;
float3 u_xlat16_1;
float4 u_xlat16_2;
float4 u_xlat16_3;
float u_xlat4;
bool u_xlatb4;
float u_xlat5;
float u_xlat16_6;
float2 u_xlat10;
bool2 u_xlatb10;
float u_xlat16_11;
float u_xlat16_16;

    u_xlat0.xy = _Time.yy * float2(_DissolveScroll.x, _DissolveScroll.y);
    u_xlat0.xy = frac(u_xlat0.xy);
    u_xlat10.xy = i.vs_TEXCOORD0.xy * _DissolveTex_ST.xy + _DissolveTex_ST.zw;
    u_xlat0.xy = u_xlat0.xy + u_xlat10.xy;
    u_xlatb10.xy = lessThan(float4(0.0, 0.0, 0.0, 0.0), float4(_SingleChannel, _UseDissolveOffsetUV, _SingleChannel, _UseDissolveOffsetUV)).xy;
    u_xlat0.xy = (u_xlatb10.y) ? u_xlat0.xy : i.vs_TEXCOORD0.xy;
    u_xlat16_0.x = tex2D(_DissolveTex, u_xlat0.xy).x;
    u_xlat16_1.x = u_xlat16_0.x * 2.0 + -1.0;
    u_xlat5 = u_xlat16_1.x * i.vs_TEXCOORD1.z + i.vs_TEXCOORD0.x;
    u_xlat16_1.x = (u_xlatb10.y) ? u_xlat5 : u_xlat16_0.x;
    u_xlat16_6 = (-u_xlat16_1.x) + 1.0;
    u_xlatb0 = 0.0>=_InvertDissolveTex;
    u_xlat16_1.x = (u_xlatb0) ? u_xlat16_6 : u_xlat16_1.x;
    u_xlat16_6 = u_xlat16_1.x + _DissolveSmooth;
    u_xlat16_1.x = u_xlat16_1.x + (-_DissolveSmooth);
    u_xlat16_6 = (-u_xlat16_1.x) + u_xlat16_6;
    u_xlat16_6 = float(1.0) / u_xlat16_6;
    u_xlat16_11 = _DissolveSmooth * 2.0 + 1.0;
    u_xlat16_11 = i.vs_TEXCOORD1.x * u_xlat16_11 + (-_DissolveSmooth);
    u_xlat16_16 = (-u_xlat16_1.x) + u_xlat16_11;
    u_xlat16_16 = u_xlat16_6 * u_xlat16_16;
    u_xlat16_16 = clamp(u_xlat16_16, 0.0, 1.0);
    u_xlat16_2.x = u_xlat16_16 * -2.0 + 3.0;
    u_xlat16_16 = u_xlat16_16 * u_xlat16_16;
    u_xlat16_16 = u_xlat16_16 * u_xlat16_2.x;
    u_xlat16_2 = tex2D(_MainTex, i.vs_TEXCOORD0.xy);
    u_xlat16_3.xyz = (u_xlatb10.x) ? float3(1.0, 1.0, 1.0) : u_xlat16_2.xyz;
    u_xlat16_3.w = (u_xlatb10.x) ? u_xlat16_2.x : u_xlat16_2.w;
    u_xlat16_0 = u_xlat16_3 * i.vs_COLOR0;
    u_xlat16_16 = u_xlat16_16 * u_xlat16_0.w;
    u_xlatb4 = 0.0<_DoubleDissolve;
    u_xlat16_3.x = (u_xlatb4) ? i.vs_TEXCOORD1.y : 0.0;
    u_xlat16_11 = u_xlat16_11 + (-u_xlat16_3.x);
    u_xlatb4 = 0.0<u_xlat16_3.x;
    u_xlat16_1.x = (-u_xlat16_1.x) + u_xlat16_11;
    u_xlat16_1.x = u_xlat16_6 * u_xlat16_1.x;
    u_xlat16_1.x = clamp(u_xlat16_1.x, 0.0, 1.0);
    u_xlat16_6 = u_xlat16_1.x * -2.0 + 3.0;
    u_xlat16_1.x = u_xlat16_1.x * u_xlat16_1.x;
    u_xlat16_1.x = (-u_xlat16_6) * u_xlat16_1.x + u_xlat16_16;
    u_xlat16_1.x = clamp(u_xlat16_1.x, 0.0, 1.0);
    u_xlat16_1.x = (u_xlatb4) ? u_xlat16_1.x : u_xlat16_16;
    result.w = min(u_xlat16_1.x, 1.0);
    u_xlat4 = log2(_HdrMultiply);
    u_xlat4 = u_xlat4 * 0.416666657;
    u_xlat4 = exp2(u_xlat4);
    u_xlat4 = u_xlat4 * 1.05499995 + -0.0549999997;
    u_xlat4 = max(u_xlat4, 0.0);
    u_xlat16_1.xyz = u_xlat16_0.xyz * ((float3)(u_xlat4));
    u_xlatb4 = 0.0<_HdrMultiply;
    result.xyz = (bool(u_xlatb4)) ? u_xlat16_1.xyz : u_xlat16_0.xyz;
    return result;

}

#elif !defined(SOFTPARTICLES_ON) && defined(_ALPHABLEND_ON) && !defined(_ALPHAMODULATE_ON) && !defined(_ALPHAPREMULTIPLY_ON) && !defined(_ALPHATEST_ON) && !defined(_CFXR_ADDITIVE) && !defined(_CFXR_DISSOLVE) && !defined(_CFXR_EDGE_FADING) && !defined(_CFXR_FONT_COLORS) && !defined(_CFXR_LIGHTING_ALL) && !defined(_CFXR_LIGHTING_BACK) && !defined(_CFXR_LIGHTING_WPOS_OFFSET) && !defined(_CFXR_OVERLAYTEX_1X) && !defined(_CFXR_SECONDCOLOR_LERP) && !defined(_CFXR_UV_DISTORTION) && !defined(_EMISSION) && defined(_FADING_ON) && !defined(_FLIPBOOK_BLENDING) && !defined(_NORMALMAP)
// Original GLES program 37; _FADING_ON,_ALPHABLEND_ON
float _SingleChannel;
float _HdrMultiply;
sampler2D _MainTex;
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
float u_xlat0;
bool u_xlatb0;
float4 u_xlat16_1;
float4 u_xlat16_2;
bool u_xlatb3;

    u_xlat0 = log2(_HdrMultiply);
    u_xlat0 = u_xlat0 * 0.416666657;
    u_xlat0 = exp2(u_xlat0);
    u_xlat0 = u_xlat0 * 1.05499995 + -0.0549999997;
    u_xlat0 = max(u_xlat0, 0.0);
    u_xlat16_1 = tex2D(_MainTex, i.vs_TEXCOORD0.xy);
    u_xlatb3 = 0.0<_SingleChannel;
    u_xlat16_2.xyz = (bool(u_xlatb3)) ? float3(1.0, 1.0, 1.0) : u_xlat16_1.xyz;
    u_xlat16_2.w = (u_xlatb3) ? u_xlat16_1.x : u_xlat16_1.w;
    u_xlat16_1 = u_xlat16_2 * i.vs_COLOR0;
    u_xlat16_2.xyz = ((float3)(u_xlat0)) * u_xlat16_1.xyz;
    u_xlatb0 = 0.0<_HdrMultiply;
    result.xyz = (bool(u_xlatb0)) ? u_xlat16_2.xyz : u_xlat16_1.xyz;
    result.w = min(u_xlat16_1.w, 1.0);
    return result;

}

#elif !defined(SOFTPARTICLES_ON) && defined(_ALPHABLEND_ON) && !defined(_ALPHAMODULATE_ON) && !defined(_ALPHAPREMULTIPLY_ON) && !defined(_ALPHATEST_ON) && !defined(_CFXR_ADDITIVE) && !defined(_CFXR_DISSOLVE) && !defined(_CFXR_EDGE_FADING) && !defined(_CFXR_FONT_COLORS) && !defined(_CFXR_LIGHTING_ALL) && !defined(_CFXR_LIGHTING_BACK) && !defined(_CFXR_LIGHTING_WPOS_OFFSET) && !defined(_CFXR_OVERLAYTEX_1X) && !defined(_CFXR_SECONDCOLOR_LERP) && !defined(_CFXR_UV_DISTORTION) && !defined(_EMISSION) && !defined(_FADING_ON) && defined(_FLIPBOOK_BLENDING) && !defined(_NORMALMAP)
// Original GLES program 49; _FLIPBOOK_BLENDING,_ALPHABLEND_ON
float _SingleChannel;
float _HdrMultiply;
sampler2D _MainTex;
struct A{float4 in_POSITION0:POSITION0;float4 in_COLOR0:COLOR0;float4 in_TEXCOORD0:TEXCOORD0;float4 in_TEXCOORD1:TEXCOORD1;};
struct V{float4 vertex:SV_POSITION;float4 vs_COLOR0:TEXCOORD0;float4 vs_TEXCOORD0:TEXCOORD1;float4 vs_TEXCOORD1:TEXCOORD2;};
V vert(A i){V o=(V)0;
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
    o.vs_TEXCOORD1 = i.in_TEXCOORD1;
    return o;

}
float4 frag(V i):SV_Target{float4 result=0;
float u_xlat0;
bool u_xlatb0;
float4 u_xlat1;
float4 u_xlat16_1;
float4 u_xlat2;
float3 u_xlat16_2;
float4 u_xlat16_3;
float4 u_xlat16_4;
bool u_xlatb5;

    u_xlat0 = log2(_HdrMultiply);
    u_xlat0 = u_xlat0 * 0.416666657;
    u_xlat0 = exp2(u_xlat0);
    u_xlat0 = u_xlat0 * 1.05499995 + -0.0549999997;
    u_xlat0 = max(u_xlat0, 0.0);
    u_xlat16_1 = tex2D(_MainTex, i.vs_TEXCOORD0.zw);
    u_xlatb5 = 0.0<_SingleChannel;
    u_xlat16_2.xyz = (bool(u_xlatb5)) ? u_xlat16_1.xxx : u_xlat16_1.yzw;
    u_xlat16_3 = tex2D(_MainTex, i.vs_TEXCOORD0.xy);
    u_xlat16_4.w = (u_xlatb5) ? u_xlat16_3.x : u_xlat16_3.w;
    u_xlat16_4.xyz = (bool(u_xlatb5)) ? float3(1.0, 1.0, 1.0) : u_xlat16_3.xyz;
    u_xlat2.yzw = u_xlat16_2.xyz + (-u_xlat16_4.yzw);
    u_xlat2.x = u_xlat16_1.x + (-u_xlat16_4.x);
    u_xlat1 = i.vs_TEXCOORD1.yyyy * u_xlat2 + u_xlat16_4;
    u_xlat16_1 = u_xlat1 * i.vs_COLOR0;
    u_xlat16_4.xyz = ((float3)(u_xlat0)) * u_xlat16_1.xyz;
    u_xlatb0 = 0.0<_HdrMultiply;
    result.xyz = (bool(u_xlatb0)) ? u_xlat16_4.xyz : u_xlat16_1.xyz;
    result.w = min(u_xlat16_1.w, 1.0);
    return result;

}

#elif !defined(SOFTPARTICLES_ON) && defined(_ALPHABLEND_ON) && !defined(_ALPHAMODULATE_ON) && !defined(_ALPHAPREMULTIPLY_ON) && defined(_ALPHATEST_ON) && !defined(_CFXR_ADDITIVE) && !defined(_CFXR_DISSOLVE) && !defined(_CFXR_EDGE_FADING) && !defined(_CFXR_FONT_COLORS) && !defined(_CFXR_LIGHTING_ALL) && !defined(_CFXR_LIGHTING_BACK) && !defined(_CFXR_LIGHTING_WPOS_OFFSET) && !defined(_CFXR_OVERLAYTEX_1X) && !defined(_CFXR_SECONDCOLOR_LERP) && !defined(_CFXR_UV_DISTORTION) && !defined(_EMISSION) && !defined(_FADING_ON) && !defined(_FLIPBOOK_BLENDING) && !defined(_NORMALMAP)
// Original GLES program 51; _ALPHATEST_ON,_ALPHABLEND_ON
float _SingleChannel;
float _HdrMultiply;
float _Cutoff;
sampler2D _MainTex;
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
float4 u_xlat16_0;
float u_xlat1;
bool u_xlatb1;
float4 u_xlat16_2;

    u_xlat16_0 = tex2D(_MainTex, i.vs_TEXCOORD0.xy);
    u_xlatb1 = 0.0<_SingleChannel;
    u_xlat16_2.w = (u_xlatb1) ? u_xlat16_0.x : u_xlat16_0.w;
    u_xlat16_2.xyz = (bool(u_xlatb1)) ? float3(1.0, 1.0, 1.0) : u_xlat16_0.xyz;
    u_xlat16_0 = u_xlat16_2 * i.vs_COLOR0;
    u_xlat16_2.x = u_xlat16_2.w * i.vs_COLOR0.w + (-_Cutoff);
    u_xlatb1 = u_xlat16_2.x<0.0;
    if(u_xlatb1){discard;}
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

#elif !defined(SOFTPARTICLES_ON) && !defined(_ALPHABLEND_ON) && !defined(_ALPHAMODULATE_ON) && defined(_ALPHAPREMULTIPLY_ON) && !defined(_ALPHATEST_ON) && !defined(_CFXR_ADDITIVE) && !defined(_CFXR_DISSOLVE) && !defined(_CFXR_EDGE_FADING) && !defined(_CFXR_FONT_COLORS) && !defined(_CFXR_LIGHTING_ALL) && !defined(_CFXR_LIGHTING_BACK) && !defined(_CFXR_LIGHTING_WPOS_OFFSET) && !defined(_CFXR_OVERLAYTEX_1X) && !defined(_CFXR_SECONDCOLOR_LERP) && !defined(_CFXR_UV_DISTORTION) && !defined(_EMISSION) && defined(_FADING_ON) && !defined(_FLIPBOOK_BLENDING) && !defined(_NORMALMAP)
// Original GLES program 60; _FADING_ON,_ALPHAPREMULTIPLY_ON
float _SingleChannel;
float _HdrMultiply;
sampler2D _MainTex;
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
float u_xlat0;
bool u_xlatb0;
float4 u_xlat16_1;
float4 u_xlat16_2;
bool u_xlatb3;

    u_xlat0 = log2(_HdrMultiply);
    u_xlat0 = u_xlat0 * 0.416666657;
    u_xlat0 = exp2(u_xlat0);
    u_xlat0 = u_xlat0 * 1.05499995 + -0.0549999997;
    u_xlat0 = max(u_xlat0, 0.0);
    u_xlat16_1 = tex2D(_MainTex, i.vs_TEXCOORD0.xy);
    u_xlatb3 = 0.0<_SingleChannel;
    u_xlat16_2.xyz = (bool(u_xlatb3)) ? float3(1.0, 1.0, 1.0) : u_xlat16_1.xyz;
    u_xlat16_2.w = (u_xlatb3) ? u_xlat16_1.x : u_xlat16_1.w;
    u_xlat16_1 = u_xlat16_2 * i.vs_COLOR0;
    u_xlat16_2.xyz = ((float3)(u_xlat0)) * u_xlat16_1.xyz;
    u_xlatb0 = 0.0<_HdrMultiply;
    u_xlat16_2.xyz = (bool(u_xlatb0)) ? u_xlat16_2.xyz : u_xlat16_1.xyz;
    result.xyz = u_xlat16_1.www * u_xlat16_2.xyz;
    result.w = min(u_xlat16_1.w, 1.0);
    return result;

}

#elif !defined(SOFTPARTICLES_ON) && !defined(_ALPHABLEND_ON) && !defined(_ALPHAMODULATE_ON) && !defined(_ALPHAPREMULTIPLY_ON) && !defined(_ALPHATEST_ON) && defined(_CFXR_ADDITIVE) && defined(_CFXR_DISSOLVE) && !defined(_CFXR_EDGE_FADING) && !defined(_CFXR_FONT_COLORS) && !defined(_CFXR_LIGHTING_ALL) && !defined(_CFXR_LIGHTING_BACK) && !defined(_CFXR_LIGHTING_WPOS_OFFSET) && !defined(_CFXR_OVERLAYTEX_1X) && !defined(_CFXR_SECONDCOLOR_LERP) && !defined(_CFXR_UV_DISTORTION) && !defined(_EMISSION) && !defined(_FADING_ON) && !defined(_FLIPBOOK_BLENDING) && !defined(_NORMALMAP)
// Original GLES program 63; _CFXR_DISSOLVE,_CFXR_ADDITIVE
float _SingleChannel;
float _UseDissolveOffsetUV;
float _InvertDissolveTex;
float _DoubleDissolve;
float2 _DissolveScroll;
float _DissolveSmooth;
float _HdrMultiply;
float4 _DissolveTex_ST;
sampler2D _MainTex;
sampler2D _DissolveTex;
struct A{float4 in_POSITION0:POSITION0;float4 in_COLOR0:COLOR0;float4 in_TEXCOORD0:TEXCOORD0;float4 in_TEXCOORD1:TEXCOORD1;};
struct V{float4 vertex:SV_POSITION;float4 vs_COLOR0:TEXCOORD0;float4 vs_TEXCOORD0:TEXCOORD1;float4 vs_TEXCOORD1:TEXCOORD2;};
V vert(A i){V o=(V)0;
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
    o.vs_TEXCOORD1 = i.in_TEXCOORD1;
    return o;

}
float4 frag(V i):SV_Target{float4 result=0;
float2 u_xlat0;
float4 u_xlat16_0;
bool u_xlatb0;
float3 u_xlat16_1;
float4 u_xlat16_2;
float4 u_xlat16_3;
float u_xlat4;
bool u_xlatb4;
float u_xlat5;
float u_xlat16_6;
float2 u_xlat10;
bool2 u_xlatb10;
float u_xlat16_11;
float u_xlat16_16;

    u_xlat0.xy = _Time.yy * float2(_DissolveScroll.x, _DissolveScroll.y);
    u_xlat0.xy = frac(u_xlat0.xy);
    u_xlat10.xy = i.vs_TEXCOORD0.xy * _DissolveTex_ST.xy + _DissolveTex_ST.zw;
    u_xlat0.xy = u_xlat0.xy + u_xlat10.xy;
    u_xlatb10.xy = lessThan(float4(0.0, 0.0, 0.0, 0.0), float4(_SingleChannel, _UseDissolveOffsetUV, _SingleChannel, _UseDissolveOffsetUV)).xy;
    u_xlat0.xy = (u_xlatb10.y) ? u_xlat0.xy : i.vs_TEXCOORD0.xy;
    u_xlat16_0.x = tex2D(_DissolveTex, u_xlat0.xy).x;
    u_xlat16_1.x = u_xlat16_0.x * 2.0 + -1.0;
    u_xlat5 = u_xlat16_1.x * i.vs_TEXCOORD1.z + i.vs_TEXCOORD0.x;
    u_xlat16_1.x = (u_xlatb10.y) ? u_xlat5 : u_xlat16_0.x;
    u_xlat16_6 = (-u_xlat16_1.x) + 1.0;
    u_xlatb0 = 0.0>=_InvertDissolveTex;
    u_xlat16_1.x = (u_xlatb0) ? u_xlat16_6 : u_xlat16_1.x;
    u_xlat16_6 = u_xlat16_1.x + _DissolveSmooth;
    u_xlat16_1.x = u_xlat16_1.x + (-_DissolveSmooth);
    u_xlat16_6 = (-u_xlat16_1.x) + u_xlat16_6;
    u_xlat16_6 = float(1.0) / u_xlat16_6;
    u_xlat16_11 = _DissolveSmooth * 2.0 + 1.0;
    u_xlat16_11 = i.vs_TEXCOORD1.x * u_xlat16_11 + (-_DissolveSmooth);
    u_xlat16_16 = (-u_xlat16_1.x) + u_xlat16_11;
    u_xlat16_16 = u_xlat16_6 * u_xlat16_16;
    u_xlat16_16 = clamp(u_xlat16_16, 0.0, 1.0);
    u_xlat16_2.x = u_xlat16_16 * -2.0 + 3.0;
    u_xlat16_16 = u_xlat16_16 * u_xlat16_16;
    u_xlat16_16 = u_xlat16_16 * u_xlat16_2.x;
    u_xlat16_2 = tex2D(_MainTex, i.vs_TEXCOORD0.xy);
    u_xlat16_3.xyz = (u_xlatb10.x) ? float3(1.0, 1.0, 1.0) : u_xlat16_2.xyz;
    u_xlat16_3.w = (u_xlatb10.x) ? u_xlat16_2.x : u_xlat16_2.w;
    u_xlat16_0 = u_xlat16_3 * i.vs_COLOR0;
    u_xlat16_16 = u_xlat16_16 * u_xlat16_0.w;
    u_xlatb4 = 0.0<_DoubleDissolve;
    u_xlat16_3.x = (u_xlatb4) ? i.vs_TEXCOORD1.y : 0.0;
    u_xlat16_11 = u_xlat16_11 + (-u_xlat16_3.x);
    u_xlatb4 = 0.0<u_xlat16_3.x;
    u_xlat16_1.x = (-u_xlat16_1.x) + u_xlat16_11;
    u_xlat16_1.x = u_xlat16_6 * u_xlat16_1.x;
    u_xlat16_1.x = clamp(u_xlat16_1.x, 0.0, 1.0);
    u_xlat16_6 = u_xlat16_1.x * -2.0 + 3.0;
    u_xlat16_1.x = u_xlat16_1.x * u_xlat16_1.x;
    u_xlat16_1.x = (-u_xlat16_6) * u_xlat16_1.x + u_xlat16_16;
    u_xlat16_1.x = clamp(u_xlat16_1.x, 0.0, 1.0);
    u_xlat16_1.x = (u_xlatb4) ? u_xlat16_1.x : u_xlat16_16;
    result.w = min(u_xlat16_1.x, 1.0);
    u_xlat4 = log2(_HdrMultiply);
    u_xlat4 = u_xlat4 * 0.416666657;
    u_xlat4 = exp2(u_xlat4);
    u_xlat4 = u_xlat4 * 1.05499995 + -0.0549999997;
    u_xlat4 = max(u_xlat4, 0.0);
    u_xlat16_1.xyz = u_xlat16_0.xyz * ((float3)(u_xlat4));
    u_xlatb4 = 0.0<_HdrMultiply;
    result.xyz = (bool(u_xlatb4)) ? u_xlat16_1.xyz : u_xlat16_0.xyz;
    return result;

}

#elif !defined(SOFTPARTICLES_ON) && !defined(_ALPHABLEND_ON) && !defined(_ALPHAMODULATE_ON) && !defined(_ALPHAPREMULTIPLY_ON) && !defined(_ALPHATEST_ON) && defined(_CFXR_ADDITIVE) && !defined(_CFXR_DISSOLVE) && !defined(_CFXR_EDGE_FADING) && !defined(_CFXR_FONT_COLORS) && !defined(_CFXR_LIGHTING_ALL) && !defined(_CFXR_LIGHTING_BACK) && !defined(_CFXR_LIGHTING_WPOS_OFFSET) && !defined(_CFXR_OVERLAYTEX_1X) && !defined(_CFXR_SECONDCOLOR_LERP) && !defined(_CFXR_UV_DISTORTION) && !defined(_EMISSION) && defined(_FADING_ON) && !defined(_FLIPBOOK_BLENDING) && !defined(_NORMALMAP)
// Original GLES program 64; _FADING_ON,_CFXR_ADDITIVE
float _SingleChannel;
float _HdrMultiply;
sampler2D _MainTex;
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
float u_xlat0;
bool u_xlatb0;
float4 u_xlat16_1;
float4 u_xlat16_2;
bool u_xlatb3;

    u_xlat0 = log2(_HdrMultiply);
    u_xlat0 = u_xlat0 * 0.416666657;
    u_xlat0 = exp2(u_xlat0);
    u_xlat0 = u_xlat0 * 1.05499995 + -0.0549999997;
    u_xlat0 = max(u_xlat0, 0.0);
    u_xlat16_1 = tex2D(_MainTex, i.vs_TEXCOORD0.xy);
    u_xlatb3 = 0.0<_SingleChannel;
    u_xlat16_2.xyz = (bool(u_xlatb3)) ? float3(1.0, 1.0, 1.0) : u_xlat16_1.xyz;
    u_xlat16_2.w = (u_xlatb3) ? u_xlat16_1.x : u_xlat16_1.w;
    u_xlat16_1 = u_xlat16_2 * i.vs_COLOR0;
    u_xlat16_2.xyz = ((float3)(u_xlat0)) * u_xlat16_1.xyz;
    u_xlatb0 = 0.0<_HdrMultiply;
    result.xyz = (bool(u_xlatb0)) ? u_xlat16_2.xyz : u_xlat16_1.xyz;
    result.w = min(u_xlat16_1.w, 1.0);
    return result;

}

#elif defined(SOFTPARTICLES_ON) && defined(_ALPHABLEND_ON) && !defined(_ALPHAMODULATE_ON) && !defined(_ALPHAPREMULTIPLY_ON) && !defined(_ALPHATEST_ON) && !defined(_CFXR_ADDITIVE) && !defined(_CFXR_DISSOLVE) && !defined(_CFXR_EDGE_FADING) && !defined(_CFXR_FONT_COLORS) && !defined(_CFXR_LIGHTING_ALL) && !defined(_CFXR_LIGHTING_BACK) && !defined(_CFXR_LIGHTING_WPOS_OFFSET) && !defined(_CFXR_OVERLAYTEX_1X) && !defined(_CFXR_SECONDCOLOR_LERP) && !defined(_CFXR_UV_DISTORTION) && !defined(_EMISSION) && !defined(_FADING_ON) && !defined(_FLIPBOOK_BLENDING) && !defined(_NORMALMAP)
// Original GLES program 71; SOFTPARTICLES_ON,_ALPHABLEND_ON
float _SingleChannel;
float _HdrMultiply;
sampler2D _MainTex;
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
float u_xlat0;
bool u_xlatb0;
float4 u_xlat16_1;
float4 u_xlat16_2;
bool u_xlatb3;

    u_xlat0 = log2(_HdrMultiply);
    u_xlat0 = u_xlat0 * 0.416666657;
    u_xlat0 = exp2(u_xlat0);
    u_xlat0 = u_xlat0 * 1.05499995 + -0.0549999997;
    u_xlat0 = max(u_xlat0, 0.0);
    u_xlat16_1 = tex2D(_MainTex, i.vs_TEXCOORD0.xy);
    u_xlatb3 = 0.0<_SingleChannel;
    u_xlat16_2.xyz = (bool(u_xlatb3)) ? float3(1.0, 1.0, 1.0) : u_xlat16_1.xyz;
    u_xlat16_2.w = (u_xlatb3) ? u_xlat16_1.x : u_xlat16_1.w;
    u_xlat16_1 = u_xlat16_2 * i.vs_COLOR0;
    u_xlat16_2.xyz = ((float3)(u_xlat0)) * u_xlat16_1.xyz;
    u_xlatb0 = 0.0<_HdrMultiply;
    result.xyz = (bool(u_xlatb0)) ? u_xlat16_2.xyz : u_xlat16_1.xyz;
    result.w = min(u_xlat16_1.w, 1.0);
    return result;

}

#elif !defined(SOFTPARTICLES_ON) && defined(_ALPHABLEND_ON) && !defined(_ALPHAMODULATE_ON) && !defined(_ALPHAPREMULTIPLY_ON) && !defined(_ALPHATEST_ON) && !defined(_CFXR_ADDITIVE) && !defined(_CFXR_DISSOLVE) && !defined(_CFXR_EDGE_FADING) && !defined(_CFXR_FONT_COLORS) && !defined(_CFXR_LIGHTING_ALL) && !defined(_CFXR_LIGHTING_BACK) && !defined(_CFXR_LIGHTING_WPOS_OFFSET) && !defined(_CFXR_OVERLAYTEX_1X) && !defined(_CFXR_SECONDCOLOR_LERP) && !defined(_CFXR_UV_DISTORTION) && !defined(_EMISSION) && !defined(_FADING_ON) && !defined(_FLIPBOOK_BLENDING) && !defined(_NORMALMAP)
// Original GLES program 35; _ALPHABLEND_ON
float _SingleChannel;
float _HdrMultiply;
sampler2D _MainTex;
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
float u_xlat0;
bool u_xlatb0;
float4 u_xlat16_1;
float4 u_xlat16_2;
bool u_xlatb3;

    u_xlat0 = log2(_HdrMultiply);
    u_xlat0 = u_xlat0 * 0.416666657;
    u_xlat0 = exp2(u_xlat0);
    u_xlat0 = u_xlat0 * 1.05499995 + -0.0549999997;
    u_xlat0 = max(u_xlat0, 0.0);
    u_xlat16_1 = tex2D(_MainTex, i.vs_TEXCOORD0.xy);
    u_xlatb3 = 0.0<_SingleChannel;
    u_xlat16_2.xyz = (bool(u_xlatb3)) ? float3(1.0, 1.0, 1.0) : u_xlat16_1.xyz;
    u_xlat16_2.w = (u_xlatb3) ? u_xlat16_1.x : u_xlat16_1.w;
    u_xlat16_1 = u_xlat16_2 * i.vs_COLOR0;
    u_xlat16_2.xyz = ((float3)(u_xlat0)) * u_xlat16_1.xyz;
    u_xlatb0 = 0.0<_HdrMultiply;
    result.xyz = (bool(u_xlatb0)) ? u_xlat16_2.xyz : u_xlat16_1.xyz;
    result.w = min(u_xlat16_1.w, 1.0);
    return result;

}

#elif defined(SOFTPARTICLES_ON) && !defined(_ALPHABLEND_ON) && !defined(_ALPHAMODULATE_ON) && !defined(_ALPHAPREMULTIPLY_ON) && !defined(_ALPHATEST_ON) && !defined(_CFXR_ADDITIVE) && !defined(_CFXR_DISSOLVE) && !defined(_CFXR_EDGE_FADING) && !defined(_CFXR_FONT_COLORS) && !defined(_CFXR_LIGHTING_ALL) && !defined(_CFXR_LIGHTING_BACK) && !defined(_CFXR_LIGHTING_WPOS_OFFSET) && !defined(_CFXR_OVERLAYTEX_1X) && !defined(_CFXR_SECONDCOLOR_LERP) && !defined(_CFXR_UV_DISTORTION) && !defined(_EMISSION) && !defined(_FADING_ON) && !defined(_FLIPBOOK_BLENDING) && !defined(_NORMALMAP)
// Original GLES program 70; SOFTPARTICLES_ON
float _SingleChannel;
float _HdrMultiply;
sampler2D _MainTex;
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
float u_xlat0;
bool u_xlatb0;
float4 u_xlat16_1;
float4 u_xlat16_2;
bool u_xlatb3;

    u_xlat0 = log2(_HdrMultiply);
    u_xlat0 = u_xlat0 * 0.416666657;
    u_xlat0 = exp2(u_xlat0);
    u_xlat0 = u_xlat0 * 1.05499995 + -0.0549999997;
    u_xlat0 = max(u_xlat0, 0.0);
    u_xlat16_1 = tex2D(_MainTex, i.vs_TEXCOORD0.xy);
    u_xlatb3 = 0.0<_SingleChannel;
    u_xlat16_2.xyz = (bool(u_xlatb3)) ? float3(1.0, 1.0, 1.0) : u_xlat16_1.xyz;
    u_xlat16_2.w = (u_xlatb3) ? u_xlat16_1.x : u_xlat16_1.w;
    u_xlat16_1 = u_xlat16_2 * i.vs_COLOR0;
    u_xlat16_2.xyz = ((float3)(u_xlat0)) * u_xlat16_1.xyz;
    u_xlatb0 = 0.0<_HdrMultiply;
    result.xyz = (bool(u_xlatb0)) ? u_xlat16_2.xyz : u_xlat16_1.xyz;
    result.w = min(u_xlat16_1.w, 1.0);
    return result;

}

#elif !defined(SOFTPARTICLES_ON) && !defined(_ALPHABLEND_ON) && !defined(_ALPHAMODULATE_ON) && !defined(_ALPHAPREMULTIPLY_ON) && !defined(_ALPHATEST_ON) && !defined(_CFXR_ADDITIVE) && !defined(_CFXR_DISSOLVE) && !defined(_CFXR_EDGE_FADING) && !defined(_CFXR_FONT_COLORS) && !defined(_CFXR_LIGHTING_ALL) && !defined(_CFXR_LIGHTING_BACK) && !defined(_CFXR_LIGHTING_WPOS_OFFSET) && !defined(_CFXR_OVERLAYTEX_1X) && !defined(_CFXR_SECONDCOLOR_LERP) && !defined(_CFXR_UV_DISTORTION) && !defined(_EMISSION) && !defined(_FADING_ON) && !defined(_FLIPBOOK_BLENDING) && !defined(_NORMALMAP)
// Original GLES program 34; 
float _SingleChannel;
float _HdrMultiply;
sampler2D _MainTex;
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
float u_xlat0;
bool u_xlatb0;
float4 u_xlat16_1;
float4 u_xlat16_2;
bool u_xlatb3;

    u_xlat0 = log2(_HdrMultiply);
    u_xlat0 = u_xlat0 * 0.416666657;
    u_xlat0 = exp2(u_xlat0);
    u_xlat0 = u_xlat0 * 1.05499995 + -0.0549999997;
    u_xlat0 = max(u_xlat0, 0.0);
    u_xlat16_1 = tex2D(_MainTex, i.vs_TEXCOORD0.xy);
    u_xlatb3 = 0.0<_SingleChannel;
    u_xlat16_2.xyz = (bool(u_xlatb3)) ? float3(1.0, 1.0, 1.0) : u_xlat16_1.xyz;
    u_xlat16_2.w = (u_xlatb3) ? u_xlat16_1.x : u_xlat16_1.w;
    u_xlat16_1 = u_xlat16_2 * i.vs_COLOR0;
    u_xlat16_2.xyz = ((float3)(u_xlat0)) * u_xlat16_1.xyz;
    u_xlatb0 = 0.0<_HdrMultiply;
    result.xyz = (bool(u_xlatb0)) ? u_xlat16_2.xyz : u_xlat16_1.xyz;
    result.w = min(u_xlat16_1.w, 1.0);
    return result;

}

#else
// Combination absent from original shipped forward variants.
float _SingleChannel;
float _HdrMultiply;
sampler2D _MainTex;
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
float u_xlat0;
bool u_xlatb0;
float4 u_xlat16_1;
float4 u_xlat16_2;
bool u_xlatb3;

    u_xlat0 = log2(_HdrMultiply);
    u_xlat0 = u_xlat0 * 0.416666657;
    u_xlat0 = exp2(u_xlat0);
    u_xlat0 = u_xlat0 * 1.05499995 + -0.0549999997;
    u_xlat0 = max(u_xlat0, 0.0);
    u_xlat16_1 = tex2D(_MainTex, i.vs_TEXCOORD0.xy);
    u_xlatb3 = 0.0<_SingleChannel;
    u_xlat16_2.xyz = (bool(u_xlatb3)) ? float3(1.0, 1.0, 1.0) : u_xlat16_1.xyz;
    u_xlat16_2.w = (u_xlatb3) ? u_xlat16_1.x : u_xlat16_1.w;
    u_xlat16_1 = u_xlat16_2 * i.vs_COLOR0;
    u_xlat16_2.xyz = ((float3)(u_xlat0)) * u_xlat16_1.xyz;
    u_xlatb0 = 0.0<_HdrMultiply;
    result.xyz = (bool(u_xlatb0)) ? u_xlat16_2.xyz : u_xlat16_1.xyz;
    result.w = min(u_xlat16_1.w, 1.0);
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
#pragma shader_feature_local _ _ALPHABLEND_ON _ALPHAPREMULTIPLY_ON _ALPHAMODULATE_ON _CFXR_ADDITIVE
#pragma shader_feature_local _ _CFXR_OVERLAYTEX_1X
#pragma shader_feature_local _ _CFXR_DITHERED_SHADOWS_ON
#pragma shader_feature_local _ _ALPHATEST_ON
#pragma shader_feature_local _ _CFXR_DISSOLVE
#pragma shader_feature_local _ _CFXR_UV_DISTORTION
#pragma shader_feature_local _ _FLIPBOOK_BLENDING
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
#if defined(SHADOWS_CUBE) && !defined(SHADOWS_DEPTH) && defined(_ALPHABLEND_ON) && !defined(_ALPHAMODULATE_ON) && !defined(_ALPHAPREMULTIPLY_ON) && !defined(_ALPHATEST_ON) && !defined(_CFXR_ADDITIVE) && defined(_CFXR_DISSOLVE) && defined(_CFXR_DITHERED_SHADOWS_ON) && !defined(_CFXR_OVERLAYTEX_1X) && defined(_CFXR_UV_DISTORTION) && !defined(_FLIPBOOK_BLENDING)
// Original shadow GLES program 141
float _SingleChannel;
float _UseDissolveOffsetUV;
float _UseUV2Distortion;
float _UVDistortionAdd;
float _InvertDissolveTex;
float _DoubleDissolve;
float2 _DissolveScroll;
float _DissolveSmooth;
float4 _DistortScrolling;
float _Distort;
float _FadeAlongU;
float4 _DissolveTex_ST;
float _ShadowStrength;
sampler2D _DistortTex;
sampler2D _MainTex;
sampler2D _DissolveTex;
sampler3D _DitherMaskLOD;
struct A{float4 in_POSITION0:POSITION0;float4 in_COLOR0:COLOR0;float4 in_TEXCOORD0:TEXCOORD0;float4 in_TEXCOORD1:TEXCOORD1;float3 in_NORMAL0:NORMAL0;};
struct V{float4 vertex:SV_POSITION;float4 vs_COLOR0:TEXCOORD0;float4 vs_TEXCOORD1:TEXCOORD1;float4 vs_TEXCOORD2:TEXCOORD2;};
V vert(A i){V o=(V)0;
float4 u_xlat0;
float4 u_xlat1;
float4 u_xlat2;
float u_xlat9;
bool u_xlatb9;

    o.vs_COLOR0 = i.in_COLOR0;
    o.vs_TEXCOORD1 = i.in_TEXCOORD0.xyxy;
    o.vs_TEXCOORD2 = i.in_TEXCOORD1;
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
bool4 u_xlatb1;
float3 u_xlat2;
float u_xlat16_2;
float u_xlat16_3;
float u_xlat4;
float u_xlat16_6;
float u_xlat16_7;
float2 u_xlat8;
float u_xlat16_10;
float u_xlat16_14;

float4 hlslcc_FragCoord = float4(i.vertex.xyz, 1.0/i.vertex.w);
    u_xlat0.xy = _Time.yy * _DistortScrolling.xy;
    u_xlat0.xy = frac(u_xlat0.xy);
    u_xlatb1 = lessThan(float4(0.0, 0.0, 0.0, 0.0), float4(_UseUV2Distortion, _UVDistortionAdd, _SingleChannel, _UseDissolveOffsetUV));
    u_xlat8.xy = (u_xlatb1.x) ? i.vs_TEXCOORD2.xy : i.vs_TEXCOORD1.xy;
    u_xlat8.xy = u_xlat8.xy * _DistortScrolling.zw + i.vs_TEXCOORD1.zw;
    u_xlat0.xy = u_xlat0.xy + u_xlat8.xy;
    u_xlat16_0.xy = tex2D(_DistortTex, u_xlat0.xy).xy;
    u_xlat8.xy = u_xlat16_0.xy * float2(2.0, 2.0) + float2(-1.0, -1.0);
    u_xlat0.xy = u_xlat16_0.xy + (-i.vs_TEXCOORD1.xy);
    u_xlat0.xy = ((float2)(_Distort)) * u_xlat0.xy + i.vs_TEXCOORD1.xy;
    u_xlat8.xy = u_xlat8.xy * ((float2)(_Distort)) + i.vs_TEXCOORD1.xy;
    u_xlat0.xy = (u_xlatb1.y) ? u_xlat8.xy : u_xlat0.xy;
    u_xlat8.xy = u_xlat0.xy + (-i.vs_TEXCOORD1.xy);
    u_xlat1 = i.vs_TEXCOORD1.y * 0.5;
    u_xlat8.xy = ((float2)(u_xlat1)) * u_xlat8.xy + i.vs_TEXCOORD1.xy;
    u_xlatb1.x = 0.0<_FadeAlongU;
    u_xlat0.xy = (u_xlatb1.x) ? u_xlat8.xy : u_xlat0.xy;
    u_xlat16_0.xy = tex2D(_MainTex, u_xlat0.xy).xw;
    u_xlat16_2 = (u_xlatb1.z) ? u_xlat16_0.x : u_xlat16_0.y;
    u_xlat16_2 = u_xlat16_2 * i.vs_COLOR0.w;
    u_xlat0.xy = _Time.yy * float2(_DissolveScroll.x, _DissolveScroll.y);
    u_xlat0.xy = frac(u_xlat0.xy);
    u_xlat8.xy = i.vs_TEXCOORD1.xy * _DissolveTex_ST.xy + _DissolveTex_ST.zw;
    u_xlat0.xy = u_xlat0.xy + u_xlat8.xy;
    u_xlat0.xy = (u_xlatb1.w) ? u_xlat0.xy : i.vs_TEXCOORD1.xy;
    u_xlat16_0.x = tex2D(_DissolveTex, u_xlat0.xy).x;
    u_xlat16_6 = u_xlat16_0.x * 2.0 + -1.0;
    u_xlat4 = u_xlat16_6 * i.vs_TEXCOORD2.z + i.vs_TEXCOORD1.x;
    u_xlat16_6 = (u_xlatb1.w) ? u_xlat4 : u_xlat16_0.x;
    u_xlat16_10 = (-u_xlat16_6) + 1.0;
    u_xlatb0 = 0.0>=_InvertDissolveTex;
    u_xlat16_6 = (u_xlatb0) ? u_xlat16_10 : u_xlat16_6;
    u_xlat16_10 = u_xlat16_6 + _DissolveSmooth;
    u_xlat16_6 = u_xlat16_6 + (-_DissolveSmooth);
    u_xlat16_10 = (-u_xlat16_6) + u_xlat16_10;
    u_xlat16_10 = float(1.0) / u_xlat16_10;
    u_xlat16_14 = _DissolveSmooth * 2.0 + 1.0;
    u_xlat16_14 = i.vs_TEXCOORD2.x * u_xlat16_14 + (-_DissolveSmooth);
    u_xlat16_3 = (-u_xlat16_6) + u_xlat16_14;
    u_xlat16_3 = u_xlat16_10 * u_xlat16_3;
    u_xlat16_3 = clamp(u_xlat16_3, 0.0, 1.0);
    u_xlat16_7 = u_xlat16_3 * -2.0 + 3.0;
    u_xlat16_3 = u_xlat16_3 * u_xlat16_3;
    u_xlat16_3 = u_xlat16_3 * u_xlat16_7;
    u_xlat16_2 = u_xlat16_2 * u_xlat16_3;
    u_xlatb0 = 0.0<_DoubleDissolve;
    u_xlat16_3 = (u_xlatb0) ? i.vs_TEXCOORD2.y : 0.0;
    u_xlat16_14 = u_xlat16_14 + (-u_xlat16_3);
    u_xlatb0 = 0.0<u_xlat16_3;
    u_xlat16_6 = (-u_xlat16_6) + u_xlat16_14;
    u_xlat16_6 = u_xlat16_10 * u_xlat16_6;
    u_xlat16_6 = clamp(u_xlat16_6, 0.0, 1.0);
    u_xlat16_10 = u_xlat16_6 * -2.0 + 3.0;
    u_xlat16_6 = u_xlat16_6 * u_xlat16_6;
    u_xlat16_6 = (-u_xlat16_10) * u_xlat16_6 + u_xlat16_2;
    u_xlat16_6 = clamp(u_xlat16_6, 0.0, 1.0);
    u_xlat16_2 = (u_xlatb0) ? u_xlat16_6 : u_xlat16_2;
    u_xlat16_2 = min(u_xlat16_2, 1.0);
    u_xlat0.x = min(u_xlat16_2, _ShadowStrength);
    u_xlat16_10 = u_xlat0.x * 0.9375;
    u_xlat2.z = u_xlat16_10;
    u_xlat2.xy = hlslcc_FragCoord.xy * float2(0.25, 0.25);
    u_xlat16_0.x = tex3D(_DitherMaskLOD, u_xlat2.xyz).w;
    u_xlat16_3 = u_xlat16_0.x + -0.00999999978;
    u_xlatb0 = u_xlat16_3<0.0;
    if(u_xlatb0){discard;}
    result = float4(0.0, 0.0, 0.0, 0.0);
    return result;

}

#elif defined(SHADOWS_CUBE) && !defined(SHADOWS_DEPTH) && !defined(_ALPHABLEND_ON) && !defined(_ALPHAMODULATE_ON) && !defined(_ALPHAPREMULTIPLY_ON) && !defined(_ALPHATEST_ON) && defined(_CFXR_ADDITIVE) && defined(_CFXR_DISSOLVE) && defined(_CFXR_DITHERED_SHADOWS_ON) && defined(_CFXR_OVERLAYTEX_1X) && !defined(_CFXR_UV_DISTORTION) && !defined(_FLIPBOOK_BLENDING)
// Original shadow GLES program 145
float4 _OverlayTex_Scroll;
float _SingleChannel;
float _UseDissolveOffsetUV;
float _CFXR_OVERLAYBLEND;
float _InvertDissolveTex;
float _DoubleDissolve;
float2 _DissolveScroll;
float _DissolveSmooth;
float _HdrMultiply;
float4 _DissolveTex_ST;
float _ShadowStrength;
sampler2D _MainTex;
sampler2D _OverlayTex;
sampler2D _DissolveTex;
sampler3D _DitherMaskLOD;
struct A{float4 in_POSITION0:POSITION0;float4 in_COLOR0:COLOR0;float4 in_TEXCOORD0:TEXCOORD0;float4 in_TEXCOORD1:TEXCOORD1;float3 in_NORMAL0:NORMAL0;};
struct V{float4 vertex:SV_POSITION;float4 vs_COLOR0:TEXCOORD0;float4 vs_TEXCOORD1:TEXCOORD1;float4 vs_TEXCOORD2:TEXCOORD2;};
V vert(A i){V o=(V)0;
float4 u_xlat0;
float4 u_xlat1;
float4 u_xlat2;
float u_xlat9;
bool u_xlatb9;

    o.vs_COLOR0 = i.in_COLOR0;
    o.vs_TEXCOORD1 = i.in_TEXCOORD0.xyxy;
    o.vs_TEXCOORD2 = i.in_TEXCOORD1;
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
float4 u_xlat16_0;
bool u_xlatb0;
float3 u_xlat1;
float u_xlat16_1;
float4 u_xlat16_2;
float2 u_xlat3;
float4 u_xlat16_3;
float u_xlat4;
float u_xlat16_4;
bool2 u_xlatb4;
float u_xlat16_5;
float u_xlat6;
float3 u_xlat16_7;
float2 u_xlat12;
bool2 u_xlatb12;
float u_xlat16_13;
float u_xlat16_19;

float4 hlslcc_FragCoord = float4(i.vertex.xyz, 1.0/i.vertex.w);
    u_xlat0.xy = _Time.yy * float2(_DissolveScroll.x, _DissolveScroll.y);
    u_xlat0.xy = frac(u_xlat0.xy);
    u_xlat12.xy = i.vs_TEXCOORD1.xy * _DissolveTex_ST.xy + _DissolveTex_ST.zw;
    u_xlat0.xy = u_xlat0.xy + u_xlat12.xy;
    u_xlatb12.xy = lessThan(float4(0.0, 0.0, 0.0, 0.0), float4(_SingleChannel, _UseDissolveOffsetUV, _SingleChannel, _UseDissolveOffsetUV)).xy;
    u_xlat0.xy = (u_xlatb12.y) ? u_xlat0.xy : i.vs_TEXCOORD1.xy;
    u_xlat16_0.x = tex2D(_DissolveTex, u_xlat0.xy).x;
    u_xlat16_1 = u_xlat16_0.x * 2.0 + -1.0;
    u_xlat6 = u_xlat16_1 * i.vs_TEXCOORD2.z + i.vs_TEXCOORD1.x;
    u_xlat16_1 = (u_xlatb12.y) ? u_xlat6 : u_xlat16_0.x;
    u_xlat16_7.x = (-u_xlat16_1) + 1.0;
    u_xlatb0 = 0.0>=_InvertDissolveTex;
    u_xlat16_1 = (u_xlatb0) ? u_xlat16_7.x : u_xlat16_1;
    u_xlat16_7.x = u_xlat16_1 + _DissolveSmooth;
    u_xlat16_1 = u_xlat16_1 + (-_DissolveSmooth);
    u_xlat16_7.x = (-u_xlat16_1) + u_xlat16_7.x;
    u_xlat16_7.x = float(1.0) / u_xlat16_7.x;
    u_xlat16_13 = _DissolveSmooth * 2.0 + 1.0;
    u_xlat16_13 = i.vs_TEXCOORD2.x * u_xlat16_13 + (-_DissolveSmooth);
    u_xlat16_19 = (-u_xlat16_1) + u_xlat16_13;
    u_xlat16_19 = u_xlat16_7.x * u_xlat16_19;
    u_xlat16_19 = clamp(u_xlat16_19, 0.0, 1.0);
    u_xlat16_2.x = u_xlat16_19 * -2.0 + 3.0;
    u_xlat16_19 = u_xlat16_19 * u_xlat16_19;
    u_xlat16_19 = u_xlat16_19 * u_xlat16_2.x;
    u_xlat0.xy = _Time.yy * _OverlayTex_Scroll.xy;
    u_xlat0.xy = frac(u_xlat0.xy);
    u_xlat3.xy = i.vs_TEXCOORD1.zw + i.vs_TEXCOORD1.xy;
    u_xlat0.xy = u_xlat3.xy * _OverlayTex_Scroll.zz + u_xlat0.xy;
    u_xlat16_0.x = tex2D(_OverlayTex, u_xlat0.xy).x;
    u_xlat16_2 = tex2D(_MainTex, i.vs_TEXCOORD1.xy);
    u_xlat16_3.xyz = (u_xlatb12.x) ? float3(1.0, 1.0, 1.0) : u_xlat16_2.xyz;
    u_xlat16_3.w = (u_xlatb12.x) ? u_xlat16_2.x : u_xlat16_2.w;
    u_xlat16_0 = u_xlat16_0.xxxx * u_xlat16_3;
    u_xlat16_2.xyz = u_xlat16_3.xyz;
    u_xlat16_3.xyz = u_xlat16_0.xyz;
    u_xlatb4.xy = equal(((float4)(_CFXR_OVERLAYBLEND)), float4(2.0, 1.0, 0.0, 0.0)).xy;
    u_xlat16_3 = (u_xlatb4.y) ? u_xlat16_3 : u_xlat16_0;
    u_xlat16_2.w = u_xlat16_0.w;
    u_xlat16_0 = (u_xlatb4.x) ? u_xlat16_2 : u_xlat16_3;
    u_xlat16_0 = u_xlat16_0 * i.vs_COLOR0;
    u_xlat16_19 = u_xlat16_19 * u_xlat16_0.w;
    u_xlatb4.x = 0.0<_DoubleDissolve;
    u_xlat16_5 = (u_xlatb4.x) ? i.vs_TEXCOORD2.y : 0.0;
    u_xlat16_13 = u_xlat16_13 + (-u_xlat16_5);
    u_xlatb4.x = 0.0<u_xlat16_5;
    u_xlat16_1 = (-u_xlat16_1) + u_xlat16_13;
    u_xlat16_1 = u_xlat16_7.x * u_xlat16_1;
    u_xlat16_1 = clamp(u_xlat16_1, 0.0, 1.0);
    u_xlat16_7.x = u_xlat16_1 * -2.0 + 3.0;
    u_xlat16_1 = u_xlat16_1 * u_xlat16_1;
    u_xlat16_1 = (-u_xlat16_7.x) * u_xlat16_1 + u_xlat16_19;
    u_xlat16_1 = clamp(u_xlat16_1, 0.0, 1.0);
    u_xlat16_1 = (u_xlatb4.x) ? u_xlat16_1 : u_xlat16_19;
    u_xlat16_1 = min(u_xlat16_1, 1.0);
    u_xlat4 = log2(_HdrMultiply);
    u_xlat4 = u_xlat4 * 0.416666657;
    u_xlat4 = exp2(u_xlat4);
    u_xlat4 = u_xlat4 * 1.05499995 + -0.0549999997;
    u_xlat4 = max(u_xlat4, 0.0);
    u_xlat16_7.xyz = u_xlat16_0.xyz * ((float3)(u_xlat4));
    u_xlatb4.x = 0.0<_HdrMultiply;
    u_xlat16_7.xyz = (u_xlatb4.x) ? u_xlat16_7.xyz : u_xlat16_0.xyz;
    u_xlat16_13 = max(u_xlat16_7.z, u_xlat16_7.y);
    u_xlat16_7.x = max(u_xlat16_13, u_xlat16_7.x);
    u_xlat16_1 = u_xlat16_1 * u_xlat16_7.x;
    u_xlat4 = min(u_xlat16_1, _ShadowStrength);
    u_xlat16_13 = u_xlat4 * 0.9375;
    u_xlat1.z = u_xlat16_13;
    u_xlat1.xy = hlslcc_FragCoord.xy * float2(0.25, 0.25);
    u_xlat16_4 = tex3D(_DitherMaskLOD, u_xlat1.xyz).w;
    u_xlat16_5 = u_xlat16_4 + -0.00999999978;
    u_xlatb4.x = u_xlat16_5<0.0;
    if(u_xlatb4.x){discard;}
    result = float4(0.0, 0.0, 0.0, 0.0);
    return result;

}

#elif !defined(SHADOWS_CUBE) && defined(SHADOWS_DEPTH) && defined(_ALPHABLEND_ON) && !defined(_ALPHAMODULATE_ON) && !defined(_ALPHAPREMULTIPLY_ON) && !defined(_ALPHATEST_ON) && !defined(_CFXR_ADDITIVE) && defined(_CFXR_DISSOLVE) && defined(_CFXR_DITHERED_SHADOWS_ON) && !defined(_CFXR_OVERLAYTEX_1X) && defined(_CFXR_UV_DISTORTION) && !defined(_FLIPBOOK_BLENDING)
// Original shadow GLES program 164
float _SingleChannel;
float _UseDissolveOffsetUV;
float _UseUV2Distortion;
float _UVDistortionAdd;
float _InvertDissolveTex;
float _DoubleDissolve;
float2 _DissolveScroll;
float _DissolveSmooth;
float4 _DistortScrolling;
float _Distort;
float _FadeAlongU;
float4 _DissolveTex_ST;
float _ShadowStrength;
sampler2D _DistortTex;
sampler2D _MainTex;
sampler2D _DissolveTex;
sampler3D _DitherMaskLOD;
struct A{float4 in_POSITION0:POSITION0;float4 in_COLOR0:COLOR0;float4 in_TEXCOORD0:TEXCOORD0;float4 in_TEXCOORD1:TEXCOORD1;float3 in_NORMAL0:NORMAL0;};
struct V{float4 vertex:SV_POSITION;float4 vs_COLOR0:TEXCOORD0;float4 vs_TEXCOORD1:TEXCOORD1;float4 vs_TEXCOORD2:TEXCOORD2;};
V vert(A i){V o=(V)0;
float4 u_xlat0;
float4 u_xlat1;
float4 u_xlat2;
float u_xlat6;
float u_xlat9;
bool u_xlatb9;

    o.vs_COLOR0 = i.in_COLOR0;
    o.vs_TEXCOORD1 = i.in_TEXCOORD0.xyxy;
    o.vs_TEXCOORD2 = i.in_TEXCOORD1;
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
bool4 u_xlatb1;
float3 u_xlat2;
float u_xlat16_2;
float u_xlat16_3;
float u_xlat4;
float u_xlat16_6;
float u_xlat16_7;
float2 u_xlat8;
float u_xlat16_10;
float u_xlat16_14;

float4 hlslcc_FragCoord = float4(i.vertex.xyz, 1.0/i.vertex.w);
    u_xlat0.xy = _Time.yy * _DistortScrolling.xy;
    u_xlat0.xy = frac(u_xlat0.xy);
    u_xlatb1 = lessThan(float4(0.0, 0.0, 0.0, 0.0), float4(_UseUV2Distortion, _UVDistortionAdd, _SingleChannel, _UseDissolveOffsetUV));
    u_xlat8.xy = (u_xlatb1.x) ? i.vs_TEXCOORD2.xy : i.vs_TEXCOORD1.xy;
    u_xlat8.xy = u_xlat8.xy * _DistortScrolling.zw + i.vs_TEXCOORD1.zw;
    u_xlat0.xy = u_xlat0.xy + u_xlat8.xy;
    u_xlat16_0.xy = tex2D(_DistortTex, u_xlat0.xy).xy;
    u_xlat8.xy = u_xlat16_0.xy * float2(2.0, 2.0) + float2(-1.0, -1.0);
    u_xlat0.xy = u_xlat16_0.xy + (-i.vs_TEXCOORD1.xy);
    u_xlat0.xy = ((float2)(_Distort)) * u_xlat0.xy + i.vs_TEXCOORD1.xy;
    u_xlat8.xy = u_xlat8.xy * ((float2)(_Distort)) + i.vs_TEXCOORD1.xy;
    u_xlat0.xy = (u_xlatb1.y) ? u_xlat8.xy : u_xlat0.xy;
    u_xlat8.xy = u_xlat0.xy + (-i.vs_TEXCOORD1.xy);
    u_xlat1 = i.vs_TEXCOORD1.y * 0.5;
    u_xlat8.xy = ((float2)(u_xlat1)) * u_xlat8.xy + i.vs_TEXCOORD1.xy;
    u_xlatb1.x = 0.0<_FadeAlongU;
    u_xlat0.xy = (u_xlatb1.x) ? u_xlat8.xy : u_xlat0.xy;
    u_xlat16_0.xy = tex2D(_MainTex, u_xlat0.xy).xw;
    u_xlat16_2 = (u_xlatb1.z) ? u_xlat16_0.x : u_xlat16_0.y;
    u_xlat16_2 = u_xlat16_2 * i.vs_COLOR0.w;
    u_xlat0.xy = _Time.yy * float2(_DissolveScroll.x, _DissolveScroll.y);
    u_xlat0.xy = frac(u_xlat0.xy);
    u_xlat8.xy = i.vs_TEXCOORD1.xy * _DissolveTex_ST.xy + _DissolveTex_ST.zw;
    u_xlat0.xy = u_xlat0.xy + u_xlat8.xy;
    u_xlat0.xy = (u_xlatb1.w) ? u_xlat0.xy : i.vs_TEXCOORD1.xy;
    u_xlat16_0.x = tex2D(_DissolveTex, u_xlat0.xy).x;
    u_xlat16_6 = u_xlat16_0.x * 2.0 + -1.0;
    u_xlat4 = u_xlat16_6 * i.vs_TEXCOORD2.z + i.vs_TEXCOORD1.x;
    u_xlat16_6 = (u_xlatb1.w) ? u_xlat4 : u_xlat16_0.x;
    u_xlat16_10 = (-u_xlat16_6) + 1.0;
    u_xlatb0 = 0.0>=_InvertDissolveTex;
    u_xlat16_6 = (u_xlatb0) ? u_xlat16_10 : u_xlat16_6;
    u_xlat16_10 = u_xlat16_6 + _DissolveSmooth;
    u_xlat16_6 = u_xlat16_6 + (-_DissolveSmooth);
    u_xlat16_10 = (-u_xlat16_6) + u_xlat16_10;
    u_xlat16_10 = float(1.0) / u_xlat16_10;
    u_xlat16_14 = _DissolveSmooth * 2.0 + 1.0;
    u_xlat16_14 = i.vs_TEXCOORD2.x * u_xlat16_14 + (-_DissolveSmooth);
    u_xlat16_3 = (-u_xlat16_6) + u_xlat16_14;
    u_xlat16_3 = u_xlat16_10 * u_xlat16_3;
    u_xlat16_3 = clamp(u_xlat16_3, 0.0, 1.0);
    u_xlat16_7 = u_xlat16_3 * -2.0 + 3.0;
    u_xlat16_3 = u_xlat16_3 * u_xlat16_3;
    u_xlat16_3 = u_xlat16_3 * u_xlat16_7;
    u_xlat16_2 = u_xlat16_2 * u_xlat16_3;
    u_xlatb0 = 0.0<_DoubleDissolve;
    u_xlat16_3 = (u_xlatb0) ? i.vs_TEXCOORD2.y : 0.0;
    u_xlat16_14 = u_xlat16_14 + (-u_xlat16_3);
    u_xlatb0 = 0.0<u_xlat16_3;
    u_xlat16_6 = (-u_xlat16_6) + u_xlat16_14;
    u_xlat16_6 = u_xlat16_10 * u_xlat16_6;
    u_xlat16_6 = clamp(u_xlat16_6, 0.0, 1.0);
    u_xlat16_10 = u_xlat16_6 * -2.0 + 3.0;
    u_xlat16_6 = u_xlat16_6 * u_xlat16_6;
    u_xlat16_6 = (-u_xlat16_10) * u_xlat16_6 + u_xlat16_2;
    u_xlat16_6 = clamp(u_xlat16_6, 0.0, 1.0);
    u_xlat16_2 = (u_xlatb0) ? u_xlat16_6 : u_xlat16_2;
    u_xlat16_2 = min(u_xlat16_2, 1.0);
    u_xlat0.x = min(u_xlat16_2, _ShadowStrength);
    u_xlat16_10 = u_xlat0.x * 0.9375;
    u_xlat2.z = u_xlat16_10;
    u_xlat2.xy = hlslcc_FragCoord.xy * float2(0.25, 0.25);
    u_xlat16_0.x = tex3D(_DitherMaskLOD, u_xlat2.xyz).w;
    u_xlat16_3 = u_xlat16_0.x + -0.00999999978;
    u_xlatb0 = u_xlat16_3<0.0;
    if(u_xlatb0){discard;}
    result = float4(0.0, 0.0, 0.0, 0.0);
    return result;

}

#elif !defined(SHADOWS_CUBE) && defined(SHADOWS_DEPTH) && !defined(_ALPHABLEND_ON) && !defined(_ALPHAMODULATE_ON) && !defined(_ALPHAPREMULTIPLY_ON) && !defined(_ALPHATEST_ON) && defined(_CFXR_ADDITIVE) && defined(_CFXR_DISSOLVE) && defined(_CFXR_DITHERED_SHADOWS_ON) && defined(_CFXR_OVERLAYTEX_1X) && !defined(_CFXR_UV_DISTORTION) && !defined(_FLIPBOOK_BLENDING)
// Original shadow GLES program 168
float4 _OverlayTex_Scroll;
float _SingleChannel;
float _UseDissolveOffsetUV;
float _CFXR_OVERLAYBLEND;
float _InvertDissolveTex;
float _DoubleDissolve;
float2 _DissolveScroll;
float _DissolveSmooth;
float _HdrMultiply;
float4 _DissolveTex_ST;
float _ShadowStrength;
sampler2D _MainTex;
sampler2D _OverlayTex;
sampler2D _DissolveTex;
sampler3D _DitherMaskLOD;
struct A{float4 in_POSITION0:POSITION0;float4 in_COLOR0:COLOR0;float4 in_TEXCOORD0:TEXCOORD0;float4 in_TEXCOORD1:TEXCOORD1;float3 in_NORMAL0:NORMAL0;};
struct V{float4 vertex:SV_POSITION;float4 vs_COLOR0:TEXCOORD0;float4 vs_TEXCOORD1:TEXCOORD1;float4 vs_TEXCOORD2:TEXCOORD2;};
V vert(A i){V o=(V)0;
float4 u_xlat0;
float4 u_xlat1;
float4 u_xlat2;
float u_xlat6;
float u_xlat9;
bool u_xlatb9;

    o.vs_COLOR0 = i.in_COLOR0;
    o.vs_TEXCOORD1 = i.in_TEXCOORD0.xyxy;
    o.vs_TEXCOORD2 = i.in_TEXCOORD1;
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
float4 u_xlat16_0;
bool u_xlatb0;
float3 u_xlat1;
float u_xlat16_1;
float4 u_xlat16_2;
float2 u_xlat3;
float4 u_xlat16_3;
float u_xlat4;
float u_xlat16_4;
bool2 u_xlatb4;
float u_xlat16_5;
float u_xlat6;
float3 u_xlat16_7;
float2 u_xlat12;
bool2 u_xlatb12;
float u_xlat16_13;
float u_xlat16_19;

float4 hlslcc_FragCoord = float4(i.vertex.xyz, 1.0/i.vertex.w);
    u_xlat0.xy = _Time.yy * float2(_DissolveScroll.x, _DissolveScroll.y);
    u_xlat0.xy = frac(u_xlat0.xy);
    u_xlat12.xy = i.vs_TEXCOORD1.xy * _DissolveTex_ST.xy + _DissolveTex_ST.zw;
    u_xlat0.xy = u_xlat0.xy + u_xlat12.xy;
    u_xlatb12.xy = lessThan(float4(0.0, 0.0, 0.0, 0.0), float4(_SingleChannel, _UseDissolveOffsetUV, _SingleChannel, _UseDissolveOffsetUV)).xy;
    u_xlat0.xy = (u_xlatb12.y) ? u_xlat0.xy : i.vs_TEXCOORD1.xy;
    u_xlat16_0.x = tex2D(_DissolveTex, u_xlat0.xy).x;
    u_xlat16_1 = u_xlat16_0.x * 2.0 + -1.0;
    u_xlat6 = u_xlat16_1 * i.vs_TEXCOORD2.z + i.vs_TEXCOORD1.x;
    u_xlat16_1 = (u_xlatb12.y) ? u_xlat6 : u_xlat16_0.x;
    u_xlat16_7.x = (-u_xlat16_1) + 1.0;
    u_xlatb0 = 0.0>=_InvertDissolveTex;
    u_xlat16_1 = (u_xlatb0) ? u_xlat16_7.x : u_xlat16_1;
    u_xlat16_7.x = u_xlat16_1 + _DissolveSmooth;
    u_xlat16_1 = u_xlat16_1 + (-_DissolveSmooth);
    u_xlat16_7.x = (-u_xlat16_1) + u_xlat16_7.x;
    u_xlat16_7.x = float(1.0) / u_xlat16_7.x;
    u_xlat16_13 = _DissolveSmooth * 2.0 + 1.0;
    u_xlat16_13 = i.vs_TEXCOORD2.x * u_xlat16_13 + (-_DissolveSmooth);
    u_xlat16_19 = (-u_xlat16_1) + u_xlat16_13;
    u_xlat16_19 = u_xlat16_7.x * u_xlat16_19;
    u_xlat16_19 = clamp(u_xlat16_19, 0.0, 1.0);
    u_xlat16_2.x = u_xlat16_19 * -2.0 + 3.0;
    u_xlat16_19 = u_xlat16_19 * u_xlat16_19;
    u_xlat16_19 = u_xlat16_19 * u_xlat16_2.x;
    u_xlat0.xy = _Time.yy * _OverlayTex_Scroll.xy;
    u_xlat0.xy = frac(u_xlat0.xy);
    u_xlat3.xy = i.vs_TEXCOORD1.zw + i.vs_TEXCOORD1.xy;
    u_xlat0.xy = u_xlat3.xy * _OverlayTex_Scroll.zz + u_xlat0.xy;
    u_xlat16_0.x = tex2D(_OverlayTex, u_xlat0.xy).x;
    u_xlat16_2 = tex2D(_MainTex, i.vs_TEXCOORD1.xy);
    u_xlat16_3.xyz = (u_xlatb12.x) ? float3(1.0, 1.0, 1.0) : u_xlat16_2.xyz;
    u_xlat16_3.w = (u_xlatb12.x) ? u_xlat16_2.x : u_xlat16_2.w;
    u_xlat16_0 = u_xlat16_0.xxxx * u_xlat16_3;
    u_xlat16_2.xyz = u_xlat16_3.xyz;
    u_xlat16_3.xyz = u_xlat16_0.xyz;
    u_xlatb4.xy = equal(((float4)(_CFXR_OVERLAYBLEND)), float4(2.0, 1.0, 0.0, 0.0)).xy;
    u_xlat16_3 = (u_xlatb4.y) ? u_xlat16_3 : u_xlat16_0;
    u_xlat16_2.w = u_xlat16_0.w;
    u_xlat16_0 = (u_xlatb4.x) ? u_xlat16_2 : u_xlat16_3;
    u_xlat16_0 = u_xlat16_0 * i.vs_COLOR0;
    u_xlat16_19 = u_xlat16_19 * u_xlat16_0.w;
    u_xlatb4.x = 0.0<_DoubleDissolve;
    u_xlat16_5 = (u_xlatb4.x) ? i.vs_TEXCOORD2.y : 0.0;
    u_xlat16_13 = u_xlat16_13 + (-u_xlat16_5);
    u_xlatb4.x = 0.0<u_xlat16_5;
    u_xlat16_1 = (-u_xlat16_1) + u_xlat16_13;
    u_xlat16_1 = u_xlat16_7.x * u_xlat16_1;
    u_xlat16_1 = clamp(u_xlat16_1, 0.0, 1.0);
    u_xlat16_7.x = u_xlat16_1 * -2.0 + 3.0;
    u_xlat16_1 = u_xlat16_1 * u_xlat16_1;
    u_xlat16_1 = (-u_xlat16_7.x) * u_xlat16_1 + u_xlat16_19;
    u_xlat16_1 = clamp(u_xlat16_1, 0.0, 1.0);
    u_xlat16_1 = (u_xlatb4.x) ? u_xlat16_1 : u_xlat16_19;
    u_xlat16_1 = min(u_xlat16_1, 1.0);
    u_xlat4 = log2(_HdrMultiply);
    u_xlat4 = u_xlat4 * 0.416666657;
    u_xlat4 = exp2(u_xlat4);
    u_xlat4 = u_xlat4 * 1.05499995 + -0.0549999997;
    u_xlat4 = max(u_xlat4, 0.0);
    u_xlat16_7.xyz = u_xlat16_0.xyz * ((float3)(u_xlat4));
    u_xlatb4.x = 0.0<_HdrMultiply;
    u_xlat16_7.xyz = (u_xlatb4.x) ? u_xlat16_7.xyz : u_xlat16_0.xyz;
    u_xlat16_13 = max(u_xlat16_7.z, u_xlat16_7.y);
    u_xlat16_7.x = max(u_xlat16_13, u_xlat16_7.x);
    u_xlat16_1 = u_xlat16_1 * u_xlat16_7.x;
    u_xlat4 = min(u_xlat16_1, _ShadowStrength);
    u_xlat16_13 = u_xlat4 * 0.9375;
    u_xlat1.z = u_xlat16_13;
    u_xlat1.xy = hlslcc_FragCoord.xy * float2(0.25, 0.25);
    u_xlat16_4 = tex3D(_DitherMaskLOD, u_xlat1.xyz).w;
    u_xlat16_5 = u_xlat16_4 + -0.00999999978;
    u_xlatb4.x = u_xlat16_5<0.0;
    if(u_xlatb4.x){discard;}
    result = float4(0.0, 0.0, 0.0, 0.0);
    return result;

}

#elif defined(SHADOWS_CUBE) && !defined(SHADOWS_DEPTH) && defined(_ALPHABLEND_ON) && !defined(_ALPHAMODULATE_ON) && !defined(_ALPHAPREMULTIPLY_ON) && !defined(_ALPHATEST_ON) && !defined(_CFXR_ADDITIVE) && defined(_CFXR_DISSOLVE) && !defined(_CFXR_DITHERED_SHADOWS_ON) && !defined(_CFXR_OVERLAYTEX_1X) && defined(_CFXR_UV_DISTORTION) && !defined(_FLIPBOOK_BLENDING)
// Original shadow GLES program 127
float _SingleChannel;
float _UseDissolveOffsetUV;
float _UseUV2Distortion;
float _UVDistortionAdd;
float _InvertDissolveTex;
float _DoubleDissolve;
float2 _DissolveScroll;
float _DissolveSmooth;
float4 _DistortScrolling;
float _Distort;
float _FadeAlongU;
float4 _DissolveTex_ST;
sampler2D _DistortTex;
sampler2D _MainTex;
sampler2D _DissolveTex;
struct A{float4 in_POSITION0:POSITION0;float4 in_COLOR0:COLOR0;float4 in_TEXCOORD0:TEXCOORD0;float4 in_TEXCOORD1:TEXCOORD1;float3 in_NORMAL0:NORMAL0;};
struct V{float4 vertex:SV_POSITION;float4 vs_COLOR0:TEXCOORD0;float4 vs_TEXCOORD1:TEXCOORD1;float4 vs_TEXCOORD2:TEXCOORD2;};
V vert(A i){V o=(V)0;
float4 u_xlat0;
float4 u_xlat1;
float4 u_xlat2;
float u_xlat9;
bool u_xlatb9;

    o.vs_COLOR0 = i.in_COLOR0;
    o.vs_TEXCOORD1 = i.in_TEXCOORD0.xyxy;
    o.vs_TEXCOORD2 = i.in_TEXCOORD1;
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
bool4 u_xlatb1;
float u_xlat16_2;
float u_xlat16_3;
float u_xlat4;
float u_xlat16_6;
float u_xlat16_7;
float2 u_xlat8;
float u_xlat16_10;
float u_xlat16_14;

    u_xlat0.xy = _Time.yy * _DistortScrolling.xy;
    u_xlat0.xy = frac(u_xlat0.xy);
    u_xlatb1 = lessThan(float4(0.0, 0.0, 0.0, 0.0), float4(_UseUV2Distortion, _UVDistortionAdd, _SingleChannel, _UseDissolveOffsetUV));
    u_xlat8.xy = (u_xlatb1.x) ? i.vs_TEXCOORD2.xy : i.vs_TEXCOORD1.xy;
    u_xlat8.xy = u_xlat8.xy * _DistortScrolling.zw + i.vs_TEXCOORD1.zw;
    u_xlat0.xy = u_xlat0.xy + u_xlat8.xy;
    u_xlat16_0.xy = tex2D(_DistortTex, u_xlat0.xy).xy;
    u_xlat8.xy = u_xlat16_0.xy * float2(2.0, 2.0) + float2(-1.0, -1.0);
    u_xlat0.xy = u_xlat16_0.xy + (-i.vs_TEXCOORD1.xy);
    u_xlat0.xy = ((float2)(_Distort)) * u_xlat0.xy + i.vs_TEXCOORD1.xy;
    u_xlat8.xy = u_xlat8.xy * ((float2)(_Distort)) + i.vs_TEXCOORD1.xy;
    u_xlat0.xy = (u_xlatb1.y) ? u_xlat8.xy : u_xlat0.xy;
    u_xlat8.xy = u_xlat0.xy + (-i.vs_TEXCOORD1.xy);
    u_xlat1 = i.vs_TEXCOORD1.y * 0.5;
    u_xlat8.xy = ((float2)(u_xlat1)) * u_xlat8.xy + i.vs_TEXCOORD1.xy;
    u_xlatb1.x = 0.0<_FadeAlongU;
    u_xlat0.xy = (u_xlatb1.x) ? u_xlat8.xy : u_xlat0.xy;
    u_xlat16_0.xy = tex2D(_MainTex, u_xlat0.xy).xw;
    u_xlat16_2 = (u_xlatb1.z) ? u_xlat16_0.x : u_xlat16_0.y;
    u_xlat16_2 = u_xlat16_2 * i.vs_COLOR0.w;
    u_xlat0.xy = _Time.yy * float2(_DissolveScroll.x, _DissolveScroll.y);
    u_xlat0.xy = frac(u_xlat0.xy);
    u_xlat8.xy = i.vs_TEXCOORD1.xy * _DissolveTex_ST.xy + _DissolveTex_ST.zw;
    u_xlat0.xy = u_xlat0.xy + u_xlat8.xy;
    u_xlat0.xy = (u_xlatb1.w) ? u_xlat0.xy : i.vs_TEXCOORD1.xy;
    u_xlat16_0.x = tex2D(_DissolveTex, u_xlat0.xy).x;
    u_xlat16_6 = u_xlat16_0.x * 2.0 + -1.0;
    u_xlat4 = u_xlat16_6 * i.vs_TEXCOORD2.z + i.vs_TEXCOORD1.x;
    u_xlat16_6 = (u_xlatb1.w) ? u_xlat4 : u_xlat16_0.x;
    u_xlat16_10 = (-u_xlat16_6) + 1.0;
    u_xlatb0 = 0.0>=_InvertDissolveTex;
    u_xlat16_6 = (u_xlatb0) ? u_xlat16_10 : u_xlat16_6;
    u_xlat16_10 = u_xlat16_6 + _DissolveSmooth;
    u_xlat16_6 = u_xlat16_6 + (-_DissolveSmooth);
    u_xlat16_10 = (-u_xlat16_6) + u_xlat16_10;
    u_xlat16_10 = float(1.0) / u_xlat16_10;
    u_xlat16_14 = _DissolveSmooth * 2.0 + 1.0;
    u_xlat16_14 = i.vs_TEXCOORD2.x * u_xlat16_14 + (-_DissolveSmooth);
    u_xlat16_3 = (-u_xlat16_6) + u_xlat16_14;
    u_xlat16_3 = u_xlat16_10 * u_xlat16_3;
    u_xlat16_3 = clamp(u_xlat16_3, 0.0, 1.0);
    u_xlat16_7 = u_xlat16_3 * -2.0 + 3.0;
    u_xlat16_3 = u_xlat16_3 * u_xlat16_3;
    u_xlat16_3 = u_xlat16_3 * u_xlat16_7;
    u_xlat16_2 = u_xlat16_2 * u_xlat16_3;
    u_xlatb0 = 0.0<_DoubleDissolve;
    u_xlat16_3 = (u_xlatb0) ? i.vs_TEXCOORD2.y : 0.0;
    u_xlat16_14 = u_xlat16_14 + (-u_xlat16_3);
    u_xlatb0 = 0.0<u_xlat16_3;
    u_xlat16_6 = (-u_xlat16_6) + u_xlat16_14;
    u_xlat16_6 = u_xlat16_10 * u_xlat16_6;
    u_xlat16_6 = clamp(u_xlat16_6, 0.0, 1.0);
    u_xlat16_10 = u_xlat16_6 * -2.0 + 3.0;
    u_xlat16_6 = u_xlat16_6 * u_xlat16_6;
    u_xlat16_6 = (-u_xlat16_10) * u_xlat16_6 + u_xlat16_2;
    u_xlat16_6 = clamp(u_xlat16_6, 0.0, 1.0);
    u_xlat16_2 = (u_xlatb0) ? u_xlat16_6 : u_xlat16_2;
    u_xlat16_2 = min(u_xlat16_2, 1.0);
    u_xlat16_2 = u_xlat16_2 + -0.00999999978;
    u_xlatb0 = u_xlat16_2<0.0;
    if(u_xlatb0){discard;}
    result = float4(0.0, 0.0, 0.0, 0.0);
    return result;

}

#elif defined(SHADOWS_CUBE) && !defined(SHADOWS_DEPTH) && defined(_ALPHABLEND_ON) && !defined(_ALPHAMODULATE_ON) && !defined(_ALPHAPREMULTIPLY_ON) && !defined(_ALPHATEST_ON) && !defined(_CFXR_ADDITIVE) && defined(_CFXR_DISSOLVE) && !defined(_CFXR_DITHERED_SHADOWS_ON) && defined(_CFXR_OVERLAYTEX_1X) && !defined(_CFXR_UV_DISTORTION) && !defined(_FLIPBOOK_BLENDING)
// Original shadow GLES program 128
float4 _OverlayTex_Scroll;
float _SingleChannel;
float _UseDissolveOffsetUV;
float _CFXR_OVERLAYBLEND;
float _InvertDissolveTex;
float _DoubleDissolve;
float2 _DissolveScroll;
float _DissolveSmooth;
float4 _DissolveTex_ST;
sampler2D _MainTex;
sampler2D _OverlayTex;
sampler2D _DissolveTex;
struct A{float4 in_POSITION0:POSITION0;float4 in_COLOR0:COLOR0;float4 in_TEXCOORD0:TEXCOORD0;float4 in_TEXCOORD1:TEXCOORD1;float3 in_NORMAL0:NORMAL0;};
struct V{float4 vertex:SV_POSITION;float4 vs_COLOR0:TEXCOORD0;float4 vs_TEXCOORD1:TEXCOORD1;float4 vs_TEXCOORD2:TEXCOORD2;};
V vert(A i){V o=(V)0;
float4 u_xlat0;
float4 u_xlat1;
float4 u_xlat2;
float u_xlat9;
bool u_xlatb9;

    o.vs_COLOR0 = i.in_COLOR0;
    o.vs_TEXCOORD1 = i.in_TEXCOORD0.xyxy;
    o.vs_TEXCOORD2 = i.in_TEXCOORD1;
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
float u_xlat16_0;
bool2 u_xlatb0;
float u_xlat16_1;
float u_xlat16_2;
float2 u_xlat3;
float u_xlat4;
float3 u_xlat16_4;
float u_xlat16_5;
float u_xlat16_6;
float2 u_xlat8;
bool2 u_xlatb8;
float u_xlat16_9;
float u_xlat16_13;

    u_xlat0.xy = _Time.yy * float2(_DissolveScroll.x, _DissolveScroll.y);
    u_xlat0.xy = frac(u_xlat0.xy);
    u_xlat8.xy = i.vs_TEXCOORD1.xy * _DissolveTex_ST.xy + _DissolveTex_ST.zw;
    u_xlat0.xy = u_xlat0.xy + u_xlat8.xy;
    u_xlatb8.xy = lessThan(float4(0.0, 0.0, 0.0, 0.0), float4(_SingleChannel, _UseDissolveOffsetUV, _SingleChannel, _UseDissolveOffsetUV)).xy;
    u_xlat0.xy = (u_xlatb8.y) ? u_xlat0.xy : i.vs_TEXCOORD1.xy;
    u_xlat16_0 = tex2D(_DissolveTex, u_xlat0.xy).x;
    u_xlat16_1 = u_xlat16_0 * 2.0 + -1.0;
    u_xlat4 = u_xlat16_1 * i.vs_TEXCOORD2.z + i.vs_TEXCOORD1.x;
    u_xlat16_1 = (u_xlatb8.y) ? u_xlat4 : u_xlat16_0;
    u_xlat16_5 = (-u_xlat16_1) + 1.0;
    u_xlatb0.x = 0.0>=_InvertDissolveTex;
    u_xlat16_1 = (u_xlatb0.x) ? u_xlat16_5 : u_xlat16_1;
    u_xlat16_5 = u_xlat16_1 + _DissolveSmooth;
    u_xlat16_1 = u_xlat16_1 + (-_DissolveSmooth);
    u_xlat16_5 = (-u_xlat16_1) + u_xlat16_5;
    u_xlat16_5 = float(1.0) / u_xlat16_5;
    u_xlat16_9 = _DissolveSmooth * 2.0 + 1.0;
    u_xlat16_9 = i.vs_TEXCOORD2.x * u_xlat16_9 + (-_DissolveSmooth);
    u_xlat16_13 = (-u_xlat16_1) + u_xlat16_9;
    u_xlat16_13 = u_xlat16_5 * u_xlat16_13;
    u_xlat16_13 = clamp(u_xlat16_13, 0.0, 1.0);
    u_xlat16_2 = u_xlat16_13 * -2.0 + 3.0;
    u_xlat16_13 = u_xlat16_13 * u_xlat16_13;
    u_xlat16_13 = u_xlat16_13 * u_xlat16_2;
    u_xlat0.xy = _Time.yy * _OverlayTex_Scroll.xy;
    u_xlat0.xy = frac(u_xlat0.xy);
    u_xlat3.xy = i.vs_TEXCOORD1.zw + i.vs_TEXCOORD1.xy;
    u_xlat0.xy = u_xlat3.xy * _OverlayTex_Scroll.zz + u_xlat0.xy;
    u_xlat16_0 = tex2D(_OverlayTex, u_xlat0.xy).x;
    u_xlat16_4.xz = tex2D(_MainTex, i.vs_TEXCOORD1.xy).xw;
    u_xlat16_2 = (u_xlatb8.x) ? u_xlat16_4.x : u_xlat16_4.z;
    u_xlat16_6 = u_xlat16_0 * u_xlat16_2;
    u_xlatb0.xy = equal(((float4)(_CFXR_OVERLAYBLEND)), float4(2.0, 1.0, 0.0, 0.0)).xy;
    u_xlat16_2 = (u_xlatb0.y) ? u_xlat16_2 : u_xlat16_6;
    u_xlat16_2 = (u_xlatb0.x) ? u_xlat16_6 : u_xlat16_2;
    u_xlat16_2 = u_xlat16_2 * i.vs_COLOR0.w;
    u_xlat16_13 = u_xlat16_13 * u_xlat16_2;
    u_xlatb0.x = 0.0<_DoubleDissolve;
    u_xlat16_2 = (u_xlatb0.x) ? i.vs_TEXCOORD2.y : 0.0;
    u_xlat16_9 = u_xlat16_9 + (-u_xlat16_2);
    u_xlatb0.x = 0.0<u_xlat16_2;
    u_xlat16_1 = (-u_xlat16_1) + u_xlat16_9;
    u_xlat16_1 = u_xlat16_5 * u_xlat16_1;
    u_xlat16_1 = clamp(u_xlat16_1, 0.0, 1.0);
    u_xlat16_5 = u_xlat16_1 * -2.0 + 3.0;
    u_xlat16_1 = u_xlat16_1 * u_xlat16_1;
    u_xlat16_1 = (-u_xlat16_5) * u_xlat16_1 + u_xlat16_13;
    u_xlat16_1 = clamp(u_xlat16_1, 0.0, 1.0);
    u_xlat16_1 = (u_xlatb0.x) ? u_xlat16_1 : u_xlat16_13;
    u_xlat16_1 = min(u_xlat16_1, 1.0);
    u_xlat16_1 = u_xlat16_1 + -0.00999999978;
    u_xlatb0.x = u_xlat16_1<0.0;
    if(u_xlatb0.x){discard;}
    result = float4(0.0, 0.0, 0.0, 0.0);
    return result;

}

#elif defined(SHADOWS_CUBE) && !defined(SHADOWS_DEPTH) && defined(_ALPHABLEND_ON) && !defined(_ALPHAMODULATE_ON) && !defined(_ALPHAPREMULTIPLY_ON) && defined(_ALPHATEST_ON) && !defined(_CFXR_ADDITIVE) && !defined(_CFXR_DISSOLVE) && !defined(_CFXR_DITHERED_SHADOWS_ON) && !defined(_CFXR_OVERLAYTEX_1X) && defined(_CFXR_UV_DISTORTION) && !defined(_FLIPBOOK_BLENDING)
// Original shadow GLES program 131
float _SingleChannel;
float _UseUV2Distortion;
float _UVDistortionAdd;
float4 _DistortScrolling;
float _Distort;
float _FadeAlongU;
float _Cutoff;
sampler2D _DistortTex;
sampler2D _MainTex;
struct A{float4 in_POSITION0:POSITION0;float4 in_COLOR0:COLOR0;float4 in_TEXCOORD0:TEXCOORD0;float4 in_TEXCOORD1:TEXCOORD1;float3 in_NORMAL0:NORMAL0;};
struct V{float4 vertex:SV_POSITION;float4 vs_COLOR0:TEXCOORD0;float4 vs_TEXCOORD1:TEXCOORD1;float4 vs_TEXCOORD2:TEXCOORD2;};
V vert(A i){V o=(V)0;
float4 u_xlat0;
float4 u_xlat1;
float4 u_xlat2;
float u_xlat9;
bool u_xlatb9;

    o.vs_COLOR0 = i.in_COLOR0;
    o.vs_TEXCOORD1 = i.in_TEXCOORD0.xyxy;
    o.vs_TEXCOORD2 = i.in_TEXCOORD1;
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
bool3 u_xlatb1;
float u_xlat16_2;
float u_xlat16_5;
float2 u_xlat6;

    u_xlat0.xy = _Time.yy * _DistortScrolling.xy;
    u_xlat0.xy = frac(u_xlat0.xy);
    u_xlatb1.xyz = lessThan(float4(0.0, 0.0, 0.0, 0.0), float4(_UseUV2Distortion, _UVDistortionAdd, _SingleChannel, _UseUV2Distortion)).xyz;
    u_xlat6.xy = (u_xlatb1.x) ? i.vs_TEXCOORD2.xy : i.vs_TEXCOORD1.xy;
    u_xlat6.xy = u_xlat6.xy * _DistortScrolling.zw + i.vs_TEXCOORD1.zw;
    u_xlat0.xy = u_xlat0.xy + u_xlat6.xy;
    u_xlat16_0.xy = tex2D(_DistortTex, u_xlat0.xy).xy;
    u_xlat6.xy = u_xlat16_0.xy * float2(2.0, 2.0) + float2(-1.0, -1.0);
    u_xlat0.xy = u_xlat16_0.xy + (-i.vs_TEXCOORD1.xy);
    u_xlat0.xy = ((float2)(_Distort)) * u_xlat0.xy + i.vs_TEXCOORD1.xy;
    u_xlat6.xy = u_xlat6.xy * ((float2)(_Distort)) + i.vs_TEXCOORD1.xy;
    u_xlat0.xy = (u_xlatb1.y) ? u_xlat6.xy : u_xlat0.xy;
    u_xlat6.xy = u_xlat0.xy + (-i.vs_TEXCOORD1.xy);
    u_xlat1 = i.vs_TEXCOORD1.y * 0.5;
    u_xlat6.xy = ((float2)(u_xlat1)) * u_xlat6.xy + i.vs_TEXCOORD1.xy;
    u_xlatb1.x = 0.0<_FadeAlongU;
    u_xlat0.xy = (u_xlatb1.x) ? u_xlat6.xy : u_xlat0.xy;
    u_xlat16_0.xy = tex2D(_MainTex, u_xlat0.xy).xw;
    u_xlat16_2 = (u_xlatb1.z) ? u_xlat16_0.x : u_xlat16_0.y;
    u_xlat16_5 = u_xlat16_2 * i.vs_COLOR0.w + (-_Cutoff);
    u_xlat16_2 = u_xlat16_2 * i.vs_COLOR0.w;
    u_xlat16_2 = min(u_xlat16_2, 1.0);
    u_xlat16_2 = u_xlat16_2 + -0.00999999978;
    u_xlatb0 = u_xlat16_2<0.0;
    if(u_xlatb0){discard;}
    u_xlatb0 = u_xlat16_5<0.0;
    if(u_xlatb0){discard;}
    result = float4(0.0, 0.0, 0.0, 0.0);
    return result;

}

#elif defined(SHADOWS_CUBE) && !defined(SHADOWS_DEPTH) && !defined(_ALPHABLEND_ON) && !defined(_ALPHAMODULATE_ON) && !defined(_ALPHAPREMULTIPLY_ON) && !defined(_ALPHATEST_ON) && defined(_CFXR_ADDITIVE) && !defined(_CFXR_DISSOLVE) && !defined(_CFXR_DITHERED_SHADOWS_ON) && defined(_CFXR_OVERLAYTEX_1X) && defined(_CFXR_UV_DISTORTION) && !defined(_FLIPBOOK_BLENDING)
// Original shadow GLES program 136
float4 _OverlayTex_Scroll;
float _SingleChannel;
float _UseUV2Distortion;
float _UVDistortionAdd;
float _CFXR_OVERLAYBLEND;
float4 _DistortScrolling;
float _Distort;
float _FadeAlongU;
float _HdrMultiply;
sampler2D _DistortTex;
sampler2D _MainTex;
sampler2D _OverlayTex;
struct A{float4 in_POSITION0:POSITION0;float4 in_COLOR0:COLOR0;float4 in_TEXCOORD0:TEXCOORD0;float4 in_TEXCOORD1:TEXCOORD1;float3 in_NORMAL0:NORMAL0;};
struct V{float4 vertex:SV_POSITION;float4 vs_COLOR0:TEXCOORD0;float4 vs_TEXCOORD1:TEXCOORD1;float4 vs_TEXCOORD2:TEXCOORD2;};
V vert(A i){V o=(V)0;
float4 u_xlat0;
float4 u_xlat1;
float4 u_xlat2;
float u_xlat9;
bool u_xlatb9;

    o.vs_COLOR0 = i.in_COLOR0;
    o.vs_TEXCOORD1 = i.in_TEXCOORD0.xyxy;
    o.vs_TEXCOORD2 = i.in_TEXCOORD1;
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
float4 u_xlat16_0;
float4 u_xlat1;
float4 u_xlat16_1;
bool3 u_xlatb1;
float u_xlat2;
bool3 u_xlatb2;
float4 u_xlat16_3;
float4 u_xlat16_4;
float2 u_xlat5;
float2 u_xlat16_5;
float u_xlat16_9;
float2 u_xlat10;
float u_xlat15;
float u_xlat16_19;

    u_xlat0.xy = _Time.yy * _OverlayTex_Scroll.xy;
    u_xlat0.xy = frac(u_xlat0.xy);
    u_xlat10.xy = i.vs_TEXCOORD1.zw + i.vs_TEXCOORD1.xy;
    u_xlat0.xy = u_xlat10.xy * _OverlayTex_Scroll.zz + u_xlat0.xy;
    u_xlat16_0.x = tex2D(_OverlayTex, u_xlat0.xy).x;
    u_xlat5.xy = _Time.yy * _DistortScrolling.xy;
    u_xlat5.xy = frac(u_xlat5.xy);
    u_xlatb1.xyz = lessThan(float4(0.0, 0.0, 0.0, 0.0), float4(_UseUV2Distortion, _UVDistortionAdd, _SingleChannel, _UseUV2Distortion)).xyz;
    u_xlat1.xw = (u_xlatb1.x) ? i.vs_TEXCOORD2.xy : i.vs_TEXCOORD1.xy;
    u_xlat1.xw = u_xlat1.xw * _DistortScrolling.zw + i.vs_TEXCOORD1.zw;
    u_xlat5.xy = u_xlat5.xy + u_xlat1.xw;
    u_xlat16_5.xy = tex2D(_DistortTex, u_xlat5.xy).xy;
    u_xlat1.xw = u_xlat16_5.xy * float2(2.0, 2.0) + float2(-1.0, -1.0);
    u_xlat5.xy = u_xlat16_5.xy + (-i.vs_TEXCOORD1.xy);
    u_xlat5.xy = ((float2)(_Distort)) * u_xlat5.xy + i.vs_TEXCOORD1.xy;
    u_xlat1.xw = u_xlat1.xw * ((float2)(_Distort)) + i.vs_TEXCOORD1.xy;
    u_xlat5.xy = (u_xlatb1.y) ? u_xlat1.xw : u_xlat5.xy;
    u_xlat1.xy = u_xlat5.xy + (-i.vs_TEXCOORD1.xy);
    u_xlat15 = i.vs_TEXCOORD1.y * 0.5;
    u_xlat1.xy = ((float2)(u_xlat15)) * u_xlat1.xy + i.vs_TEXCOORD1.xy;
    u_xlatb2.xy = lessThan(float4(0.0, 0.0, 0.0, 0.0), float4(_FadeAlongU, _HdrMultiply, _FadeAlongU, _FadeAlongU)).xy;
    u_xlat5.xy = (u_xlatb2.x) ? u_xlat1.xy : u_xlat5.xy;
    u_xlat16_3 = tex2D(_MainTex, u_xlat5.xy);
    u_xlat16_4.xyz = (u_xlatb1.z) ? float3(1.0, 1.0, 1.0) : u_xlat16_3.xyz;
    u_xlat16_4.w = (u_xlatb1.z) ? u_xlat16_3.x : u_xlat16_3.w;
    u_xlat16_0 = u_xlat16_0.xxxx * u_xlat16_4;
    u_xlat16_1.xyz = u_xlat16_4.xyz;
    u_xlat16_4.xyz = u_xlat16_0.xyz;
    u_xlatb2.xz = equal(((float4)(_CFXR_OVERLAYBLEND)), float4(2.0, 0.0, 1.0, 0.0)).xz;
    u_xlat16_3 = (u_xlatb2.z) ? u_xlat16_4 : u_xlat16_0;
    u_xlat16_1.w = u_xlat16_0.w;
    u_xlat16_0 = (u_xlatb2.x) ? u_xlat16_1 : u_xlat16_3;
    u_xlat16_0 = u_xlat16_0 * i.vs_COLOR0;
    u_xlat2 = log2(_HdrMultiply);
    u_xlat2 = u_xlat2 * 0.416666657;
    u_xlat2 = exp2(u_xlat2);
    u_xlat2 = u_xlat2 * 1.05499995 + -0.0549999997;
    u_xlat2 = max(u_xlat2, 0.0);
    u_xlat16_4.xyz = u_xlat16_0.xyz * ((float3)(u_xlat2));
    u_xlat16_4.xyz = (u_xlatb2.y) ? u_xlat16_4.xyz : u_xlat16_0.xyz;
    u_xlat16_19 = min(u_xlat16_0.w, 1.0);
    u_xlat16_9 = max(u_xlat16_4.z, u_xlat16_4.y);
    u_xlat16_4.x = max(u_xlat16_9, u_xlat16_4.x);
    u_xlat16_4.x = u_xlat16_4.x * u_xlat16_19 + -0.00999999978;
    u_xlatb2.x = u_xlat16_4.x<0.0;
    if(u_xlatb2.x){discard;}
    result = float4(0.0, 0.0, 0.0, 0.0);
    return result;

}

#elif defined(SHADOWS_CUBE) && !defined(SHADOWS_DEPTH) && !defined(_ALPHABLEND_ON) && !defined(_ALPHAMODULATE_ON) && !defined(_ALPHAPREMULTIPLY_ON) && defined(_ALPHATEST_ON) && defined(_CFXR_ADDITIVE) && !defined(_CFXR_DISSOLVE) && !defined(_CFXR_DITHERED_SHADOWS_ON) && !defined(_CFXR_OVERLAYTEX_1X) && defined(_CFXR_UV_DISTORTION) && !defined(_FLIPBOOK_BLENDING)
// Original shadow GLES program 138
float _SingleChannel;
float _UseUV2Distortion;
float _UVDistortionAdd;
float4 _DistortScrolling;
float _Distort;
float _FadeAlongU;
float _HdrMultiply;
float _Cutoff;
sampler2D _DistortTex;
sampler2D _MainTex;
struct A{float4 in_POSITION0:POSITION0;float4 in_COLOR0:COLOR0;float4 in_TEXCOORD0:TEXCOORD0;float4 in_TEXCOORD1:TEXCOORD1;float3 in_NORMAL0:NORMAL0;};
struct V{float4 vertex:SV_POSITION;float4 vs_COLOR0:TEXCOORD0;float4 vs_TEXCOORD1:TEXCOORD1;float4 vs_TEXCOORD2:TEXCOORD2;};
V vert(A i){V o=(V)0;
float4 u_xlat0;
float4 u_xlat1;
float4 u_xlat2;
float u_xlat9;
bool u_xlatb9;

    o.vs_COLOR0 = i.in_COLOR0;
    o.vs_TEXCOORD1 = i.in_TEXCOORD0.xyxy;
    o.vs_TEXCOORD2 = i.in_TEXCOORD1;
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
float4 u_xlat16_0;
float u_xlat1;
bool3 u_xlatb1;
float4 u_xlat16_2;
float u_xlat16_5;
float2 u_xlat6;
float u_xlat16_11;

    u_xlat0.xy = _Time.yy * _DistortScrolling.xy;
    u_xlat0.xy = frac(u_xlat0.xy);
    u_xlatb1.xyz = lessThan(float4(0.0, 0.0, 0.0, 0.0), float4(_UseUV2Distortion, _UVDistortionAdd, _SingleChannel, _UseUV2Distortion)).xyz;
    u_xlat6.xy = (u_xlatb1.x) ? i.vs_TEXCOORD2.xy : i.vs_TEXCOORD1.xy;
    u_xlat6.xy = u_xlat6.xy * _DistortScrolling.zw + i.vs_TEXCOORD1.zw;
    u_xlat0.xy = u_xlat0.xy + u_xlat6.xy;
    u_xlat16_0.xy = tex2D(_DistortTex, u_xlat0.xy).xy;
    u_xlat6.xy = u_xlat16_0.xy * float2(2.0, 2.0) + float2(-1.0, -1.0);
    u_xlat0.xy = u_xlat16_0.xy + (-i.vs_TEXCOORD1.xy);
    u_xlat0.xy = ((float2)(_Distort)) * u_xlat0.xy + i.vs_TEXCOORD1.xy;
    u_xlat6.xy = u_xlat6.xy * ((float2)(_Distort)) + i.vs_TEXCOORD1.xy;
    u_xlat0.xy = (u_xlatb1.y) ? u_xlat6.xy : u_xlat0.xy;
    u_xlat6.xy = u_xlat0.xy + (-i.vs_TEXCOORD1.xy);
    u_xlat1 = i.vs_TEXCOORD1.y * 0.5;
    u_xlat6.xy = ((float2)(u_xlat1)) * u_xlat6.xy + i.vs_TEXCOORD1.xy;
    u_xlatb1.xy = lessThan(float4(0.0, 0.0, 0.0, 0.0), float4(_FadeAlongU, _HdrMultiply, _FadeAlongU, _FadeAlongU)).xy;
    u_xlat0.xy = (u_xlatb1.x) ? u_xlat6.xy : u_xlat0.xy;
    u_xlat16_0 = tex2D(_MainTex, u_xlat0.xy);
    u_xlat16_2.w = (u_xlatb1.z) ? u_xlat16_0.x : u_xlat16_0.w;
    u_xlat16_2.xyz = (u_xlatb1.z) ? float3(1.0, 1.0, 1.0) : u_xlat16_0.xyz;
    u_xlat16_0 = u_xlat16_2 * i.vs_COLOR0;
    u_xlat16_2.x = u_xlat16_2.w * i.vs_COLOR0.w + (-_Cutoff);
    u_xlatb1.x = u_xlat16_2.x<0.0;
    if(u_xlatb1.x){discard;}
    u_xlat1 = log2(_HdrMultiply);
    u_xlat1 = u_xlat1 * 0.416666657;
    u_xlat1 = exp2(u_xlat1);
    u_xlat1 = u_xlat1 * 1.05499995 + -0.0549999997;
    u_xlat1 = max(u_xlat1, 0.0);
    u_xlat16_2.xyz = u_xlat16_0.xyz * ((float3)(u_xlat1));
    u_xlat16_2.xyz = (u_xlatb1.y) ? u_xlat16_2.xyz : u_xlat16_0.xyz;
    u_xlat16_11 = min(u_xlat16_0.w, 1.0);
    u_xlat16_5 = max(u_xlat16_2.z, u_xlat16_2.y);
    u_xlat16_2.x = max(u_xlat16_5, u_xlat16_2.x);
    u_xlat16_2.x = u_xlat16_2.x * u_xlat16_11 + -0.00999999978;
    u_xlatb1.x = u_xlat16_2.x<0.0;
    if(u_xlatb1.x){discard;}
    result = float4(0.0, 0.0, 0.0, 0.0);
    return result;

}

#elif defined(SHADOWS_CUBE) && !defined(SHADOWS_DEPTH) && defined(_ALPHABLEND_ON) && !defined(_ALPHAMODULATE_ON) && !defined(_ALPHAPREMULTIPLY_ON) && !defined(_ALPHATEST_ON) && !defined(_CFXR_ADDITIVE) && defined(_CFXR_DISSOLVE) && defined(_CFXR_DITHERED_SHADOWS_ON) && !defined(_CFXR_OVERLAYTEX_1X) && !defined(_CFXR_UV_DISTORTION) && !defined(_FLIPBOOK_BLENDING)
// Original shadow GLES program 140
float _SingleChannel;
float _UseDissolveOffsetUV;
float _InvertDissolveTex;
float _DoubleDissolve;
float2 _DissolveScroll;
float _DissolveSmooth;
float4 _DissolveTex_ST;
float _ShadowStrength;
sampler2D _MainTex;
sampler2D _DissolveTex;
sampler3D _DitherMaskLOD;
struct A{float4 in_POSITION0:POSITION0;float4 in_COLOR0:COLOR0;float4 in_TEXCOORD0:TEXCOORD0;float4 in_TEXCOORD1:TEXCOORD1;float3 in_NORMAL0:NORMAL0;};
struct V{float4 vertex:SV_POSITION;float4 vs_COLOR0:TEXCOORD0;float4 vs_TEXCOORD1:TEXCOORD1;float4 vs_TEXCOORD2:TEXCOORD2;};
V vert(A i){V o=(V)0;
float4 u_xlat0;
float4 u_xlat1;
float4 u_xlat2;
float u_xlat9;
bool u_xlatb9;

    o.vs_COLOR0 = i.in_COLOR0;
    o.vs_TEXCOORD1 = i.in_TEXCOORD0.xyxy;
    o.vs_TEXCOORD2 = i.in_TEXCOORD1;
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
float3 u_xlat1;
float u_xlat16_1;
float u_xlat16_2;
float u_xlat3;
float u_xlat16_4;
float2 u_xlat6;
bool2 u_xlatb6;
float u_xlat16_7;
float u_xlat16_10;

float4 hlslcc_FragCoord = float4(i.vertex.xyz, 1.0/i.vertex.w);
    u_xlat0.xy = _Time.yy * float2(_DissolveScroll.x, _DissolveScroll.y);
    u_xlat0.xy = frac(u_xlat0.xy);
    u_xlat6.xy = i.vs_TEXCOORD1.xy * _DissolveTex_ST.xy + _DissolveTex_ST.zw;
    u_xlat0.xy = u_xlat0.xy + u_xlat6.xy;
    u_xlatb6.xy = lessThan(float4(0.0, 0.0, 0.0, 0.0), float4(_SingleChannel, _UseDissolveOffsetUV, _SingleChannel, _UseDissolveOffsetUV)).xy;
    u_xlat0.xy = (u_xlatb6.y) ? u_xlat0.xy : i.vs_TEXCOORD1.xy;
    u_xlat16_0.x = tex2D(_DissolveTex, u_xlat0.xy).x;
    u_xlat16_1 = u_xlat16_0.x * 2.0 + -1.0;
    u_xlat3 = u_xlat16_1 * i.vs_TEXCOORD2.z + i.vs_TEXCOORD1.x;
    u_xlat16_1 = (u_xlatb6.y) ? u_xlat3 : u_xlat16_0.x;
    u_xlat16_4 = (-u_xlat16_1) + 1.0;
    u_xlatb0 = 0.0>=_InvertDissolveTex;
    u_xlat16_1 = (u_xlatb0) ? u_xlat16_4 : u_xlat16_1;
    u_xlat16_4 = u_xlat16_1 + _DissolveSmooth;
    u_xlat16_1 = u_xlat16_1 + (-_DissolveSmooth);
    u_xlat16_4 = (-u_xlat16_1) + u_xlat16_4;
    u_xlat16_4 = float(1.0) / u_xlat16_4;
    u_xlat16_7 = _DissolveSmooth * 2.0 + 1.0;
    u_xlat16_7 = i.vs_TEXCOORD2.x * u_xlat16_7 + (-_DissolveSmooth);
    u_xlat16_10 = (-u_xlat16_1) + u_xlat16_7;
    u_xlat16_10 = u_xlat16_4 * u_xlat16_10;
    u_xlat16_10 = clamp(u_xlat16_10, 0.0, 1.0);
    u_xlat16_2 = u_xlat16_10 * -2.0 + 3.0;
    u_xlat16_10 = u_xlat16_10 * u_xlat16_10;
    u_xlat16_10 = u_xlat16_10 * u_xlat16_2;
    u_xlat16_0.xy = tex2D(_MainTex, i.vs_TEXCOORD1.xy).xw;
    u_xlat16_2 = (u_xlatb6.x) ? u_xlat16_0.x : u_xlat16_0.y;
    u_xlat16_2 = u_xlat16_2 * i.vs_COLOR0.w;
    u_xlat16_10 = u_xlat16_10 * u_xlat16_2;
    u_xlatb0 = 0.0<_DoubleDissolve;
    u_xlat16_2 = (u_xlatb0) ? i.vs_TEXCOORD2.y : 0.0;
    u_xlat16_7 = u_xlat16_7 + (-u_xlat16_2);
    u_xlatb0 = 0.0<u_xlat16_2;
    u_xlat16_1 = (-u_xlat16_1) + u_xlat16_7;
    u_xlat16_1 = u_xlat16_4 * u_xlat16_1;
    u_xlat16_1 = clamp(u_xlat16_1, 0.0, 1.0);
    u_xlat16_4 = u_xlat16_1 * -2.0 + 3.0;
    u_xlat16_1 = u_xlat16_1 * u_xlat16_1;
    u_xlat16_1 = (-u_xlat16_4) * u_xlat16_1 + u_xlat16_10;
    u_xlat16_1 = clamp(u_xlat16_1, 0.0, 1.0);
    u_xlat16_1 = (u_xlatb0) ? u_xlat16_1 : u_xlat16_10;
    u_xlat16_1 = min(u_xlat16_1, 1.0);
    u_xlat0.x = min(u_xlat16_1, _ShadowStrength);
    u_xlat16_7 = u_xlat0.x * 0.9375;
    u_xlat1.z = u_xlat16_7;
    u_xlat1.xy = hlslcc_FragCoord.xy * float2(0.25, 0.25);
    u_xlat16_0.x = tex3D(_DitherMaskLOD, u_xlat1.xyz).w;
    u_xlat16_2 = u_xlat16_0.x + -0.00999999978;
    u_xlatb0 = u_xlat16_2<0.0;
    if(u_xlatb0){discard;}
    result = float4(0.0, 0.0, 0.0, 0.0);
    return result;

}

#elif defined(SHADOWS_CUBE) && !defined(SHADOWS_DEPTH) && defined(_ALPHABLEND_ON) && !defined(_ALPHAMODULATE_ON) && !defined(_ALPHAPREMULTIPLY_ON) && !defined(_ALPHATEST_ON) && !defined(_CFXR_ADDITIVE) && !defined(_CFXR_DISSOLVE) && defined(_CFXR_DITHERED_SHADOWS_ON) && !defined(_CFXR_OVERLAYTEX_1X) && !defined(_CFXR_UV_DISTORTION) && defined(_FLIPBOOK_BLENDING)
// Original shadow GLES program 142
float _SingleChannel;
float _ShadowStrength;
sampler2D _MainTex;
sampler3D _DitherMaskLOD;
struct A{float4 in_POSITION0:POSITION0;float4 in_COLOR0:COLOR0;float4 in_TEXCOORD0:TEXCOORD0;float4 in_TEXCOORD1:TEXCOORD1;float3 in_NORMAL0:NORMAL0;};
struct V{float4 vertex:SV_POSITION;float4 vs_COLOR0:TEXCOORD0;float4 vs_TEXCOORD1:TEXCOORD1;float4 vs_TEXCOORD2:TEXCOORD2;};
V vert(A i){V o=(V)0;
float4 u_xlat0;
float4 u_xlat1;
float4 u_xlat2;
float u_xlat9;
bool u_xlatb9;

    o.vs_COLOR0 = i.in_COLOR0;
    o.vs_TEXCOORD1 = i.in_TEXCOORD0.xyxy;
    o.vs_TEXCOORD2 = i.in_TEXCOORD1;
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
float2 u_xlat16_0;
bool u_xlatb0;
float3 u_xlat1;
float u_xlat16_1;
float u_xlat16_2;
float u_xlat16_4;
bool u_xlatb6;
float u_xlat16_7;

float4 hlslcc_FragCoord = float4(i.vertex.xyz, 1.0/i.vertex.w);
    u_xlat16_0.xy = tex2D(_MainTex, i.vs_TEXCOORD1.zw).xw;
    u_xlatb6 = 0.0<_SingleChannel;
    u_xlat16_1 = (u_xlatb6) ? u_xlat16_0.x : u_xlat16_0.y;
    u_xlat16_0.xy = tex2D(_MainTex, i.vs_TEXCOORD1.xy).xw;
    u_xlat16_4 = (u_xlatb6) ? u_xlat16_0.x : u_xlat16_0.y;
    u_xlat0 = (-u_xlat16_4) + u_xlat16_1;
    u_xlat0 = i.vs_TEXCOORD2.y * u_xlat0 + u_xlat16_4;
    u_xlat16_1 = u_xlat0 * i.vs_COLOR0.w;
    u_xlat16_1 = min(u_xlat16_1, 1.0);
    u_xlat0 = min(u_xlat16_1, _ShadowStrength);
    u_xlat16_7 = u_xlat0 * 0.9375;
    u_xlat1.z = u_xlat16_7;
    u_xlat1.xy = hlslcc_FragCoord.xy * float2(0.25, 0.25);
    u_xlat16_0.x = tex3D(_DitherMaskLOD, u_xlat1.xyz).w;
    u_xlat16_2 = u_xlat16_0.x + -0.00999999978;
    u_xlatb0 = u_xlat16_2<0.0;
    if(u_xlatb0){discard;}
    result = float4(0.0, 0.0, 0.0, 0.0);
    return result;

}

#elif defined(SHADOWS_CUBE) && !defined(SHADOWS_DEPTH) && defined(_ALPHABLEND_ON) && !defined(_ALPHAMODULATE_ON) && !defined(_ALPHAPREMULTIPLY_ON) && defined(_ALPHATEST_ON) && !defined(_CFXR_ADDITIVE) && !defined(_CFXR_DISSOLVE) && defined(_CFXR_DITHERED_SHADOWS_ON) && !defined(_CFXR_OVERLAYTEX_1X) && !defined(_CFXR_UV_DISTORTION) && !defined(_FLIPBOOK_BLENDING)
// Original shadow GLES program 143
float _SingleChannel;
float _Cutoff;
float _ShadowStrength;
sampler2D _MainTex;
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
float u_xlat0;
float2 u_xlat16_0;
bool u_xlatb0;
float u_xlat16_1;
float3 u_xlat2;
float u_xlat16_4;
bool u_xlatb6;
float u_xlat16_8;

float4 hlslcc_FragCoord = float4(i.vertex.xyz, 1.0/i.vertex.w);
    u_xlat16_0.xy = tex2D(_MainTex, i.vs_TEXCOORD1.xy).xw;
    u_xlatb6 = 0.0<_SingleChannel;
    u_xlat16_1 = (u_xlatb6) ? u_xlat16_0.x : u_xlat16_0.y;
    u_xlat16_4 = u_xlat16_1 * i.vs_COLOR0.w + (-_Cutoff);
    u_xlat16_1 = u_xlat16_1 * i.vs_COLOR0.w;
    u_xlat16_1 = min(u_xlat16_1, 1.0);
    u_xlat0 = min(u_xlat16_1, _ShadowStrength);
    u_xlat16_8 = u_xlat0 * 0.9375;
    u_xlat2.z = u_xlat16_8;
    u_xlatb0 = u_xlat16_4<0.0;
    if(u_xlatb0){discard;}
    u_xlat2.xy = hlslcc_FragCoord.xy * float2(0.25, 0.25);
    u_xlat16_0.x = tex3D(_DitherMaskLOD, u_xlat2.xyz).w;
    u_xlat16_1 = u_xlat16_0.x + -0.00999999978;
    u_xlatb0 = u_xlat16_1<0.0;
    if(u_xlatb0){discard;}
    result = float4(0.0, 0.0, 0.0, 0.0);
    return result;

}

#elif defined(SHADOWS_CUBE) && !defined(SHADOWS_DEPTH) && !defined(_ALPHABLEND_ON) && defined(_ALPHAMODULATE_ON) && !defined(_ALPHAPREMULTIPLY_ON) && !defined(_ALPHATEST_ON) && !defined(_CFXR_ADDITIVE) && defined(_CFXR_DISSOLVE) && defined(_CFXR_DITHERED_SHADOWS_ON) && !defined(_CFXR_OVERLAYTEX_1X) && !defined(_CFXR_UV_DISTORTION) && !defined(_FLIPBOOK_BLENDING)
// Original shadow GLES program 144
float _SingleChannel;
float _UseDissolveOffsetUV;
float _InvertDissolveTex;
float _DoubleDissolve;
float2 _DissolveScroll;
float _DissolveSmooth;
float4 _DissolveTex_ST;
float _ShadowStrength;
sampler2D _MainTex;
sampler2D _DissolveTex;
sampler3D _DitherMaskLOD;
struct A{float4 in_POSITION0:POSITION0;float4 in_COLOR0:COLOR0;float4 in_TEXCOORD0:TEXCOORD0;float4 in_TEXCOORD1:TEXCOORD1;float3 in_NORMAL0:NORMAL0;};
struct V{float4 vertex:SV_POSITION;float4 vs_COLOR0:TEXCOORD0;float4 vs_TEXCOORD1:TEXCOORD1;float4 vs_TEXCOORD2:TEXCOORD2;};
V vert(A i){V o=(V)0;
float4 u_xlat0;
float4 u_xlat1;
float4 u_xlat2;
float u_xlat9;
bool u_xlatb9;

    o.vs_COLOR0 = i.in_COLOR0;
    o.vs_TEXCOORD1 = i.in_TEXCOORD0.xyxy;
    o.vs_TEXCOORD2 = i.in_TEXCOORD1;
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
float3 u_xlat1;
float u_xlat16_1;
float u_xlat16_2;
float u_xlat3;
float u_xlat16_4;
float2 u_xlat6;
bool2 u_xlatb6;
float u_xlat16_7;
float u_xlat16_10;

float4 hlslcc_FragCoord = float4(i.vertex.xyz, 1.0/i.vertex.w);
    u_xlat0.xy = _Time.yy * float2(_DissolveScroll.x, _DissolveScroll.y);
    u_xlat0.xy = frac(u_xlat0.xy);
    u_xlat6.xy = i.vs_TEXCOORD1.xy * _DissolveTex_ST.xy + _DissolveTex_ST.zw;
    u_xlat0.xy = u_xlat0.xy + u_xlat6.xy;
    u_xlatb6.xy = lessThan(float4(0.0, 0.0, 0.0, 0.0), float4(_SingleChannel, _UseDissolveOffsetUV, _SingleChannel, _UseDissolveOffsetUV)).xy;
    u_xlat0.xy = (u_xlatb6.y) ? u_xlat0.xy : i.vs_TEXCOORD1.xy;
    u_xlat16_0.x = tex2D(_DissolveTex, u_xlat0.xy).x;
    u_xlat16_1 = u_xlat16_0.x * 2.0 + -1.0;
    u_xlat3 = u_xlat16_1 * i.vs_TEXCOORD2.z + i.vs_TEXCOORD1.x;
    u_xlat16_1 = (u_xlatb6.y) ? u_xlat3 : u_xlat16_0.x;
    u_xlat16_4 = (-u_xlat16_1) + 1.0;
    u_xlatb0 = 0.0>=_InvertDissolveTex;
    u_xlat16_1 = (u_xlatb0) ? u_xlat16_4 : u_xlat16_1;
    u_xlat16_4 = u_xlat16_1 + _DissolveSmooth;
    u_xlat16_1 = u_xlat16_1 + (-_DissolveSmooth);
    u_xlat16_4 = (-u_xlat16_1) + u_xlat16_4;
    u_xlat16_4 = float(1.0) / u_xlat16_4;
    u_xlat16_7 = _DissolveSmooth * 2.0 + 1.0;
    u_xlat16_7 = i.vs_TEXCOORD2.x * u_xlat16_7 + (-_DissolveSmooth);
    u_xlat16_10 = (-u_xlat16_1) + u_xlat16_7;
    u_xlat16_10 = u_xlat16_4 * u_xlat16_10;
    u_xlat16_10 = clamp(u_xlat16_10, 0.0, 1.0);
    u_xlat16_2 = u_xlat16_10 * -2.0 + 3.0;
    u_xlat16_10 = u_xlat16_10 * u_xlat16_10;
    u_xlat16_10 = u_xlat16_10 * u_xlat16_2;
    u_xlat16_0.xy = tex2D(_MainTex, i.vs_TEXCOORD1.xy).xw;
    u_xlat16_2 = (u_xlatb6.x) ? u_xlat16_0.x : u_xlat16_0.y;
    u_xlat16_2 = u_xlat16_2 * i.vs_COLOR0.w;
    u_xlat16_10 = u_xlat16_10 * u_xlat16_2;
    u_xlatb0 = 0.0<_DoubleDissolve;
    u_xlat16_2 = (u_xlatb0) ? i.vs_TEXCOORD2.y : 0.0;
    u_xlat16_7 = u_xlat16_7 + (-u_xlat16_2);
    u_xlatb0 = 0.0<u_xlat16_2;
    u_xlat16_1 = (-u_xlat16_1) + u_xlat16_7;
    u_xlat16_1 = u_xlat16_4 * u_xlat16_1;
    u_xlat16_1 = clamp(u_xlat16_1, 0.0, 1.0);
    u_xlat16_4 = u_xlat16_1 * -2.0 + 3.0;
    u_xlat16_1 = u_xlat16_1 * u_xlat16_1;
    u_xlat16_1 = (-u_xlat16_4) * u_xlat16_1 + u_xlat16_10;
    u_xlat16_1 = clamp(u_xlat16_1, 0.0, 1.0);
    u_xlat16_1 = (u_xlatb0) ? u_xlat16_1 : u_xlat16_10;
    u_xlat16_1 = min(u_xlat16_1, 1.0);
    u_xlat0.x = min(u_xlat16_1, _ShadowStrength);
    u_xlat16_7 = u_xlat0.x * 0.9375;
    u_xlat1.z = u_xlat16_7;
    u_xlat1.xy = hlslcc_FragCoord.xy * float2(0.25, 0.25);
    u_xlat16_0.x = tex3D(_DitherMaskLOD, u_xlat1.xyz).w;
    u_xlat16_2 = u_xlat16_0.x + -0.00999999978;
    u_xlatb0 = u_xlat16_2<0.0;
    if(u_xlatb0){discard;}
    result = float4(0.0, 0.0, 0.0, 0.0);
    return result;

}

#elif !defined(SHADOWS_CUBE) && defined(SHADOWS_DEPTH) && defined(_ALPHABLEND_ON) && !defined(_ALPHAMODULATE_ON) && !defined(_ALPHAPREMULTIPLY_ON) && !defined(_ALPHATEST_ON) && !defined(_CFXR_ADDITIVE) && defined(_CFXR_DISSOLVE) && !defined(_CFXR_DITHERED_SHADOWS_ON) && !defined(_CFXR_OVERLAYTEX_1X) && defined(_CFXR_UV_DISTORTION) && !defined(_FLIPBOOK_BLENDING)
// Original shadow GLES program 150
float _SingleChannel;
float _UseDissolveOffsetUV;
float _UseUV2Distortion;
float _UVDistortionAdd;
float _InvertDissolveTex;
float _DoubleDissolve;
float2 _DissolveScroll;
float _DissolveSmooth;
float4 _DistortScrolling;
float _Distort;
float _FadeAlongU;
float4 _DissolveTex_ST;
sampler2D _DistortTex;
sampler2D _MainTex;
sampler2D _DissolveTex;
struct A{float4 in_POSITION0:POSITION0;float4 in_COLOR0:COLOR0;float4 in_TEXCOORD0:TEXCOORD0;float4 in_TEXCOORD1:TEXCOORD1;float3 in_NORMAL0:NORMAL0;};
struct V{float4 vertex:SV_POSITION;float4 vs_COLOR0:TEXCOORD0;float4 vs_TEXCOORD1:TEXCOORD1;float4 vs_TEXCOORD2:TEXCOORD2;};
V vert(A i){V o=(V)0;
float4 u_xlat0;
float4 u_xlat1;
float4 u_xlat2;
float u_xlat6;
float u_xlat9;
bool u_xlatb9;

    o.vs_COLOR0 = i.in_COLOR0;
    o.vs_TEXCOORD1 = i.in_TEXCOORD0.xyxy;
    o.vs_TEXCOORD2 = i.in_TEXCOORD1;
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
bool4 u_xlatb1;
float u_xlat16_2;
float u_xlat16_3;
float u_xlat4;
float u_xlat16_6;
float u_xlat16_7;
float2 u_xlat8;
float u_xlat16_10;
float u_xlat16_14;

    u_xlat0.xy = _Time.yy * _DistortScrolling.xy;
    u_xlat0.xy = frac(u_xlat0.xy);
    u_xlatb1 = lessThan(float4(0.0, 0.0, 0.0, 0.0), float4(_UseUV2Distortion, _UVDistortionAdd, _SingleChannel, _UseDissolveOffsetUV));
    u_xlat8.xy = (u_xlatb1.x) ? i.vs_TEXCOORD2.xy : i.vs_TEXCOORD1.xy;
    u_xlat8.xy = u_xlat8.xy * _DistortScrolling.zw + i.vs_TEXCOORD1.zw;
    u_xlat0.xy = u_xlat0.xy + u_xlat8.xy;
    u_xlat16_0.xy = tex2D(_DistortTex, u_xlat0.xy).xy;
    u_xlat8.xy = u_xlat16_0.xy * float2(2.0, 2.0) + float2(-1.0, -1.0);
    u_xlat0.xy = u_xlat16_0.xy + (-i.vs_TEXCOORD1.xy);
    u_xlat0.xy = ((float2)(_Distort)) * u_xlat0.xy + i.vs_TEXCOORD1.xy;
    u_xlat8.xy = u_xlat8.xy * ((float2)(_Distort)) + i.vs_TEXCOORD1.xy;
    u_xlat0.xy = (u_xlatb1.y) ? u_xlat8.xy : u_xlat0.xy;
    u_xlat8.xy = u_xlat0.xy + (-i.vs_TEXCOORD1.xy);
    u_xlat1 = i.vs_TEXCOORD1.y * 0.5;
    u_xlat8.xy = ((float2)(u_xlat1)) * u_xlat8.xy + i.vs_TEXCOORD1.xy;
    u_xlatb1.x = 0.0<_FadeAlongU;
    u_xlat0.xy = (u_xlatb1.x) ? u_xlat8.xy : u_xlat0.xy;
    u_xlat16_0.xy = tex2D(_MainTex, u_xlat0.xy).xw;
    u_xlat16_2 = (u_xlatb1.z) ? u_xlat16_0.x : u_xlat16_0.y;
    u_xlat16_2 = u_xlat16_2 * i.vs_COLOR0.w;
    u_xlat0.xy = _Time.yy * float2(_DissolveScroll.x, _DissolveScroll.y);
    u_xlat0.xy = frac(u_xlat0.xy);
    u_xlat8.xy = i.vs_TEXCOORD1.xy * _DissolveTex_ST.xy + _DissolveTex_ST.zw;
    u_xlat0.xy = u_xlat0.xy + u_xlat8.xy;
    u_xlat0.xy = (u_xlatb1.w) ? u_xlat0.xy : i.vs_TEXCOORD1.xy;
    u_xlat16_0.x = tex2D(_DissolveTex, u_xlat0.xy).x;
    u_xlat16_6 = u_xlat16_0.x * 2.0 + -1.0;
    u_xlat4 = u_xlat16_6 * i.vs_TEXCOORD2.z + i.vs_TEXCOORD1.x;
    u_xlat16_6 = (u_xlatb1.w) ? u_xlat4 : u_xlat16_0.x;
    u_xlat16_10 = (-u_xlat16_6) + 1.0;
    u_xlatb0 = 0.0>=_InvertDissolveTex;
    u_xlat16_6 = (u_xlatb0) ? u_xlat16_10 : u_xlat16_6;
    u_xlat16_10 = u_xlat16_6 + _DissolveSmooth;
    u_xlat16_6 = u_xlat16_6 + (-_DissolveSmooth);
    u_xlat16_10 = (-u_xlat16_6) + u_xlat16_10;
    u_xlat16_10 = float(1.0) / u_xlat16_10;
    u_xlat16_14 = _DissolveSmooth * 2.0 + 1.0;
    u_xlat16_14 = i.vs_TEXCOORD2.x * u_xlat16_14 + (-_DissolveSmooth);
    u_xlat16_3 = (-u_xlat16_6) + u_xlat16_14;
    u_xlat16_3 = u_xlat16_10 * u_xlat16_3;
    u_xlat16_3 = clamp(u_xlat16_3, 0.0, 1.0);
    u_xlat16_7 = u_xlat16_3 * -2.0 + 3.0;
    u_xlat16_3 = u_xlat16_3 * u_xlat16_3;
    u_xlat16_3 = u_xlat16_3 * u_xlat16_7;
    u_xlat16_2 = u_xlat16_2 * u_xlat16_3;
    u_xlatb0 = 0.0<_DoubleDissolve;
    u_xlat16_3 = (u_xlatb0) ? i.vs_TEXCOORD2.y : 0.0;
    u_xlat16_14 = u_xlat16_14 + (-u_xlat16_3);
    u_xlatb0 = 0.0<u_xlat16_3;
    u_xlat16_6 = (-u_xlat16_6) + u_xlat16_14;
    u_xlat16_6 = u_xlat16_10 * u_xlat16_6;
    u_xlat16_6 = clamp(u_xlat16_6, 0.0, 1.0);
    u_xlat16_10 = u_xlat16_6 * -2.0 + 3.0;
    u_xlat16_6 = u_xlat16_6 * u_xlat16_6;
    u_xlat16_6 = (-u_xlat16_10) * u_xlat16_6 + u_xlat16_2;
    u_xlat16_6 = clamp(u_xlat16_6, 0.0, 1.0);
    u_xlat16_2 = (u_xlatb0) ? u_xlat16_6 : u_xlat16_2;
    u_xlat16_2 = min(u_xlat16_2, 1.0);
    u_xlat16_2 = u_xlat16_2 + -0.00999999978;
    u_xlatb0 = u_xlat16_2<0.0;
    if(u_xlatb0){discard;}
    result = float4(0.0, 0.0, 0.0, 0.0);
    return result;

}

#elif !defined(SHADOWS_CUBE) && defined(SHADOWS_DEPTH) && defined(_ALPHABLEND_ON) && !defined(_ALPHAMODULATE_ON) && !defined(_ALPHAPREMULTIPLY_ON) && !defined(_ALPHATEST_ON) && !defined(_CFXR_ADDITIVE) && defined(_CFXR_DISSOLVE) && !defined(_CFXR_DITHERED_SHADOWS_ON) && defined(_CFXR_OVERLAYTEX_1X) && !defined(_CFXR_UV_DISTORTION) && !defined(_FLIPBOOK_BLENDING)
// Original shadow GLES program 151
float4 _OverlayTex_Scroll;
float _SingleChannel;
float _UseDissolveOffsetUV;
float _CFXR_OVERLAYBLEND;
float _InvertDissolveTex;
float _DoubleDissolve;
float2 _DissolveScroll;
float _DissolveSmooth;
float4 _DissolveTex_ST;
sampler2D _MainTex;
sampler2D _OverlayTex;
sampler2D _DissolveTex;
struct A{float4 in_POSITION0:POSITION0;float4 in_COLOR0:COLOR0;float4 in_TEXCOORD0:TEXCOORD0;float4 in_TEXCOORD1:TEXCOORD1;float3 in_NORMAL0:NORMAL0;};
struct V{float4 vertex:SV_POSITION;float4 vs_COLOR0:TEXCOORD0;float4 vs_TEXCOORD1:TEXCOORD1;float4 vs_TEXCOORD2:TEXCOORD2;};
V vert(A i){V o=(V)0;
float4 u_xlat0;
float4 u_xlat1;
float4 u_xlat2;
float u_xlat6;
float u_xlat9;
bool u_xlatb9;

    o.vs_COLOR0 = i.in_COLOR0;
    o.vs_TEXCOORD1 = i.in_TEXCOORD0.xyxy;
    o.vs_TEXCOORD2 = i.in_TEXCOORD1;
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
float u_xlat16_0;
bool2 u_xlatb0;
float u_xlat16_1;
float u_xlat16_2;
float2 u_xlat3;
float u_xlat4;
float3 u_xlat16_4;
float u_xlat16_5;
float u_xlat16_6;
float2 u_xlat8;
bool2 u_xlatb8;
float u_xlat16_9;
float u_xlat16_13;

    u_xlat0.xy = _Time.yy * float2(_DissolveScroll.x, _DissolveScroll.y);
    u_xlat0.xy = frac(u_xlat0.xy);
    u_xlat8.xy = i.vs_TEXCOORD1.xy * _DissolveTex_ST.xy + _DissolveTex_ST.zw;
    u_xlat0.xy = u_xlat0.xy + u_xlat8.xy;
    u_xlatb8.xy = lessThan(float4(0.0, 0.0, 0.0, 0.0), float4(_SingleChannel, _UseDissolveOffsetUV, _SingleChannel, _UseDissolveOffsetUV)).xy;
    u_xlat0.xy = (u_xlatb8.y) ? u_xlat0.xy : i.vs_TEXCOORD1.xy;
    u_xlat16_0 = tex2D(_DissolveTex, u_xlat0.xy).x;
    u_xlat16_1 = u_xlat16_0 * 2.0 + -1.0;
    u_xlat4 = u_xlat16_1 * i.vs_TEXCOORD2.z + i.vs_TEXCOORD1.x;
    u_xlat16_1 = (u_xlatb8.y) ? u_xlat4 : u_xlat16_0;
    u_xlat16_5 = (-u_xlat16_1) + 1.0;
    u_xlatb0.x = 0.0>=_InvertDissolveTex;
    u_xlat16_1 = (u_xlatb0.x) ? u_xlat16_5 : u_xlat16_1;
    u_xlat16_5 = u_xlat16_1 + _DissolveSmooth;
    u_xlat16_1 = u_xlat16_1 + (-_DissolveSmooth);
    u_xlat16_5 = (-u_xlat16_1) + u_xlat16_5;
    u_xlat16_5 = float(1.0) / u_xlat16_5;
    u_xlat16_9 = _DissolveSmooth * 2.0 + 1.0;
    u_xlat16_9 = i.vs_TEXCOORD2.x * u_xlat16_9 + (-_DissolveSmooth);
    u_xlat16_13 = (-u_xlat16_1) + u_xlat16_9;
    u_xlat16_13 = u_xlat16_5 * u_xlat16_13;
    u_xlat16_13 = clamp(u_xlat16_13, 0.0, 1.0);
    u_xlat16_2 = u_xlat16_13 * -2.0 + 3.0;
    u_xlat16_13 = u_xlat16_13 * u_xlat16_13;
    u_xlat16_13 = u_xlat16_13 * u_xlat16_2;
    u_xlat0.xy = _Time.yy * _OverlayTex_Scroll.xy;
    u_xlat0.xy = frac(u_xlat0.xy);
    u_xlat3.xy = i.vs_TEXCOORD1.zw + i.vs_TEXCOORD1.xy;
    u_xlat0.xy = u_xlat3.xy * _OverlayTex_Scroll.zz + u_xlat0.xy;
    u_xlat16_0 = tex2D(_OverlayTex, u_xlat0.xy).x;
    u_xlat16_4.xz = tex2D(_MainTex, i.vs_TEXCOORD1.xy).xw;
    u_xlat16_2 = (u_xlatb8.x) ? u_xlat16_4.x : u_xlat16_4.z;
    u_xlat16_6 = u_xlat16_0 * u_xlat16_2;
    u_xlatb0.xy = equal(((float4)(_CFXR_OVERLAYBLEND)), float4(2.0, 1.0, 0.0, 0.0)).xy;
    u_xlat16_2 = (u_xlatb0.y) ? u_xlat16_2 : u_xlat16_6;
    u_xlat16_2 = (u_xlatb0.x) ? u_xlat16_6 : u_xlat16_2;
    u_xlat16_2 = u_xlat16_2 * i.vs_COLOR0.w;
    u_xlat16_13 = u_xlat16_13 * u_xlat16_2;
    u_xlatb0.x = 0.0<_DoubleDissolve;
    u_xlat16_2 = (u_xlatb0.x) ? i.vs_TEXCOORD2.y : 0.0;
    u_xlat16_9 = u_xlat16_9 + (-u_xlat16_2);
    u_xlatb0.x = 0.0<u_xlat16_2;
    u_xlat16_1 = (-u_xlat16_1) + u_xlat16_9;
    u_xlat16_1 = u_xlat16_5 * u_xlat16_1;
    u_xlat16_1 = clamp(u_xlat16_1, 0.0, 1.0);
    u_xlat16_5 = u_xlat16_1 * -2.0 + 3.0;
    u_xlat16_1 = u_xlat16_1 * u_xlat16_1;
    u_xlat16_1 = (-u_xlat16_5) * u_xlat16_1 + u_xlat16_13;
    u_xlat16_1 = clamp(u_xlat16_1, 0.0, 1.0);
    u_xlat16_1 = (u_xlatb0.x) ? u_xlat16_1 : u_xlat16_13;
    u_xlat16_1 = min(u_xlat16_1, 1.0);
    u_xlat16_1 = u_xlat16_1 + -0.00999999978;
    u_xlatb0.x = u_xlat16_1<0.0;
    if(u_xlatb0.x){discard;}
    result = float4(0.0, 0.0, 0.0, 0.0);
    return result;

}

#elif !defined(SHADOWS_CUBE) && defined(SHADOWS_DEPTH) && defined(_ALPHABLEND_ON) && !defined(_ALPHAMODULATE_ON) && !defined(_ALPHAPREMULTIPLY_ON) && defined(_ALPHATEST_ON) && !defined(_CFXR_ADDITIVE) && !defined(_CFXR_DISSOLVE) && !defined(_CFXR_DITHERED_SHADOWS_ON) && !defined(_CFXR_OVERLAYTEX_1X) && defined(_CFXR_UV_DISTORTION) && !defined(_FLIPBOOK_BLENDING)
// Original shadow GLES program 154
float _SingleChannel;
float _UseUV2Distortion;
float _UVDistortionAdd;
float4 _DistortScrolling;
float _Distort;
float _FadeAlongU;
float _Cutoff;
sampler2D _DistortTex;
sampler2D _MainTex;
struct A{float4 in_POSITION0:POSITION0;float4 in_COLOR0:COLOR0;float4 in_TEXCOORD0:TEXCOORD0;float4 in_TEXCOORD1:TEXCOORD1;float3 in_NORMAL0:NORMAL0;};
struct V{float4 vertex:SV_POSITION;float4 vs_COLOR0:TEXCOORD0;float4 vs_TEXCOORD1:TEXCOORD1;float4 vs_TEXCOORD2:TEXCOORD2;};
V vert(A i){V o=(V)0;
float4 u_xlat0;
float4 u_xlat1;
float4 u_xlat2;
float u_xlat6;
float u_xlat9;
bool u_xlatb9;

    o.vs_COLOR0 = i.in_COLOR0;
    o.vs_TEXCOORD1 = i.in_TEXCOORD0.xyxy;
    o.vs_TEXCOORD2 = i.in_TEXCOORD1;
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
bool3 u_xlatb1;
float u_xlat16_2;
float u_xlat16_5;
float2 u_xlat6;

    u_xlat0.xy = _Time.yy * _DistortScrolling.xy;
    u_xlat0.xy = frac(u_xlat0.xy);
    u_xlatb1.xyz = lessThan(float4(0.0, 0.0, 0.0, 0.0), float4(_UseUV2Distortion, _UVDistortionAdd, _SingleChannel, _UseUV2Distortion)).xyz;
    u_xlat6.xy = (u_xlatb1.x) ? i.vs_TEXCOORD2.xy : i.vs_TEXCOORD1.xy;
    u_xlat6.xy = u_xlat6.xy * _DistortScrolling.zw + i.vs_TEXCOORD1.zw;
    u_xlat0.xy = u_xlat0.xy + u_xlat6.xy;
    u_xlat16_0.xy = tex2D(_DistortTex, u_xlat0.xy).xy;
    u_xlat6.xy = u_xlat16_0.xy * float2(2.0, 2.0) + float2(-1.0, -1.0);
    u_xlat0.xy = u_xlat16_0.xy + (-i.vs_TEXCOORD1.xy);
    u_xlat0.xy = ((float2)(_Distort)) * u_xlat0.xy + i.vs_TEXCOORD1.xy;
    u_xlat6.xy = u_xlat6.xy * ((float2)(_Distort)) + i.vs_TEXCOORD1.xy;
    u_xlat0.xy = (u_xlatb1.y) ? u_xlat6.xy : u_xlat0.xy;
    u_xlat6.xy = u_xlat0.xy + (-i.vs_TEXCOORD1.xy);
    u_xlat1 = i.vs_TEXCOORD1.y * 0.5;
    u_xlat6.xy = ((float2)(u_xlat1)) * u_xlat6.xy + i.vs_TEXCOORD1.xy;
    u_xlatb1.x = 0.0<_FadeAlongU;
    u_xlat0.xy = (u_xlatb1.x) ? u_xlat6.xy : u_xlat0.xy;
    u_xlat16_0.xy = tex2D(_MainTex, u_xlat0.xy).xw;
    u_xlat16_2 = (u_xlatb1.z) ? u_xlat16_0.x : u_xlat16_0.y;
    u_xlat16_5 = u_xlat16_2 * i.vs_COLOR0.w + (-_Cutoff);
    u_xlat16_2 = u_xlat16_2 * i.vs_COLOR0.w;
    u_xlat16_2 = min(u_xlat16_2, 1.0);
    u_xlat16_2 = u_xlat16_2 + -0.00999999978;
    u_xlatb0 = u_xlat16_2<0.0;
    if(u_xlatb0){discard;}
    u_xlatb0 = u_xlat16_5<0.0;
    if(u_xlatb0){discard;}
    result = float4(0.0, 0.0, 0.0, 0.0);
    return result;

}

#elif !defined(SHADOWS_CUBE) && defined(SHADOWS_DEPTH) && !defined(_ALPHABLEND_ON) && !defined(_ALPHAMODULATE_ON) && !defined(_ALPHAPREMULTIPLY_ON) && !defined(_ALPHATEST_ON) && defined(_CFXR_ADDITIVE) && !defined(_CFXR_DISSOLVE) && !defined(_CFXR_DITHERED_SHADOWS_ON) && defined(_CFXR_OVERLAYTEX_1X) && defined(_CFXR_UV_DISTORTION) && !defined(_FLIPBOOK_BLENDING)
// Original shadow GLES program 159
float4 _OverlayTex_Scroll;
float _SingleChannel;
float _UseUV2Distortion;
float _UVDistortionAdd;
float _CFXR_OVERLAYBLEND;
float4 _DistortScrolling;
float _Distort;
float _FadeAlongU;
float _HdrMultiply;
sampler2D _DistortTex;
sampler2D _MainTex;
sampler2D _OverlayTex;
struct A{float4 in_POSITION0:POSITION0;float4 in_COLOR0:COLOR0;float4 in_TEXCOORD0:TEXCOORD0;float4 in_TEXCOORD1:TEXCOORD1;float3 in_NORMAL0:NORMAL0;};
struct V{float4 vertex:SV_POSITION;float4 vs_COLOR0:TEXCOORD0;float4 vs_TEXCOORD1:TEXCOORD1;float4 vs_TEXCOORD2:TEXCOORD2;};
V vert(A i){V o=(V)0;
float4 u_xlat0;
float4 u_xlat1;
float4 u_xlat2;
float u_xlat6;
float u_xlat9;
bool u_xlatb9;

    o.vs_COLOR0 = i.in_COLOR0;
    o.vs_TEXCOORD1 = i.in_TEXCOORD0.xyxy;
    o.vs_TEXCOORD2 = i.in_TEXCOORD1;
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
float4 u_xlat16_0;
float4 u_xlat1;
float4 u_xlat16_1;
bool3 u_xlatb1;
float u_xlat2;
bool3 u_xlatb2;
float4 u_xlat16_3;
float4 u_xlat16_4;
float2 u_xlat5;
float2 u_xlat16_5;
float u_xlat16_9;
float2 u_xlat10;
float u_xlat15;
float u_xlat16_19;

    u_xlat0.xy = _Time.yy * _OverlayTex_Scroll.xy;
    u_xlat0.xy = frac(u_xlat0.xy);
    u_xlat10.xy = i.vs_TEXCOORD1.zw + i.vs_TEXCOORD1.xy;
    u_xlat0.xy = u_xlat10.xy * _OverlayTex_Scroll.zz + u_xlat0.xy;
    u_xlat16_0.x = tex2D(_OverlayTex, u_xlat0.xy).x;
    u_xlat5.xy = _Time.yy * _DistortScrolling.xy;
    u_xlat5.xy = frac(u_xlat5.xy);
    u_xlatb1.xyz = lessThan(float4(0.0, 0.0, 0.0, 0.0), float4(_UseUV2Distortion, _UVDistortionAdd, _SingleChannel, _UseUV2Distortion)).xyz;
    u_xlat1.xw = (u_xlatb1.x) ? i.vs_TEXCOORD2.xy : i.vs_TEXCOORD1.xy;
    u_xlat1.xw = u_xlat1.xw * _DistortScrolling.zw + i.vs_TEXCOORD1.zw;
    u_xlat5.xy = u_xlat5.xy + u_xlat1.xw;
    u_xlat16_5.xy = tex2D(_DistortTex, u_xlat5.xy).xy;
    u_xlat1.xw = u_xlat16_5.xy * float2(2.0, 2.0) + float2(-1.0, -1.0);
    u_xlat5.xy = u_xlat16_5.xy + (-i.vs_TEXCOORD1.xy);
    u_xlat5.xy = ((float2)(_Distort)) * u_xlat5.xy + i.vs_TEXCOORD1.xy;
    u_xlat1.xw = u_xlat1.xw * ((float2)(_Distort)) + i.vs_TEXCOORD1.xy;
    u_xlat5.xy = (u_xlatb1.y) ? u_xlat1.xw : u_xlat5.xy;
    u_xlat1.xy = u_xlat5.xy + (-i.vs_TEXCOORD1.xy);
    u_xlat15 = i.vs_TEXCOORD1.y * 0.5;
    u_xlat1.xy = ((float2)(u_xlat15)) * u_xlat1.xy + i.vs_TEXCOORD1.xy;
    u_xlatb2.xy = lessThan(float4(0.0, 0.0, 0.0, 0.0), float4(_FadeAlongU, _HdrMultiply, _FadeAlongU, _FadeAlongU)).xy;
    u_xlat5.xy = (u_xlatb2.x) ? u_xlat1.xy : u_xlat5.xy;
    u_xlat16_3 = tex2D(_MainTex, u_xlat5.xy);
    u_xlat16_4.xyz = (u_xlatb1.z) ? float3(1.0, 1.0, 1.0) : u_xlat16_3.xyz;
    u_xlat16_4.w = (u_xlatb1.z) ? u_xlat16_3.x : u_xlat16_3.w;
    u_xlat16_0 = u_xlat16_0.xxxx * u_xlat16_4;
    u_xlat16_1.xyz = u_xlat16_4.xyz;
    u_xlat16_4.xyz = u_xlat16_0.xyz;
    u_xlatb2.xz = equal(((float4)(_CFXR_OVERLAYBLEND)), float4(2.0, 0.0, 1.0, 0.0)).xz;
    u_xlat16_3 = (u_xlatb2.z) ? u_xlat16_4 : u_xlat16_0;
    u_xlat16_1.w = u_xlat16_0.w;
    u_xlat16_0 = (u_xlatb2.x) ? u_xlat16_1 : u_xlat16_3;
    u_xlat16_0 = u_xlat16_0 * i.vs_COLOR0;
    u_xlat2 = log2(_HdrMultiply);
    u_xlat2 = u_xlat2 * 0.416666657;
    u_xlat2 = exp2(u_xlat2);
    u_xlat2 = u_xlat2 * 1.05499995 + -0.0549999997;
    u_xlat2 = max(u_xlat2, 0.0);
    u_xlat16_4.xyz = u_xlat16_0.xyz * ((float3)(u_xlat2));
    u_xlat16_4.xyz = (u_xlatb2.y) ? u_xlat16_4.xyz : u_xlat16_0.xyz;
    u_xlat16_19 = min(u_xlat16_0.w, 1.0);
    u_xlat16_9 = max(u_xlat16_4.z, u_xlat16_4.y);
    u_xlat16_4.x = max(u_xlat16_9, u_xlat16_4.x);
    u_xlat16_4.x = u_xlat16_4.x * u_xlat16_19 + -0.00999999978;
    u_xlatb2.x = u_xlat16_4.x<0.0;
    if(u_xlatb2.x){discard;}
    result = float4(0.0, 0.0, 0.0, 0.0);
    return result;

}

#elif !defined(SHADOWS_CUBE) && defined(SHADOWS_DEPTH) && !defined(_ALPHABLEND_ON) && !defined(_ALPHAMODULATE_ON) && !defined(_ALPHAPREMULTIPLY_ON) && defined(_ALPHATEST_ON) && defined(_CFXR_ADDITIVE) && !defined(_CFXR_DISSOLVE) && !defined(_CFXR_DITHERED_SHADOWS_ON) && !defined(_CFXR_OVERLAYTEX_1X) && defined(_CFXR_UV_DISTORTION) && !defined(_FLIPBOOK_BLENDING)
// Original shadow GLES program 161
float _SingleChannel;
float _UseUV2Distortion;
float _UVDistortionAdd;
float4 _DistortScrolling;
float _Distort;
float _FadeAlongU;
float _HdrMultiply;
float _Cutoff;
sampler2D _DistortTex;
sampler2D _MainTex;
struct A{float4 in_POSITION0:POSITION0;float4 in_COLOR0:COLOR0;float4 in_TEXCOORD0:TEXCOORD0;float4 in_TEXCOORD1:TEXCOORD1;float3 in_NORMAL0:NORMAL0;};
struct V{float4 vertex:SV_POSITION;float4 vs_COLOR0:TEXCOORD0;float4 vs_TEXCOORD1:TEXCOORD1;float4 vs_TEXCOORD2:TEXCOORD2;};
V vert(A i){V o=(V)0;
float4 u_xlat0;
float4 u_xlat1;
float4 u_xlat2;
float u_xlat6;
float u_xlat9;
bool u_xlatb9;

    o.vs_COLOR0 = i.in_COLOR0;
    o.vs_TEXCOORD1 = i.in_TEXCOORD0.xyxy;
    o.vs_TEXCOORD2 = i.in_TEXCOORD1;
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
float4 u_xlat16_0;
float u_xlat1;
bool3 u_xlatb1;
float4 u_xlat16_2;
float u_xlat16_5;
float2 u_xlat6;
float u_xlat16_11;

    u_xlat0.xy = _Time.yy * _DistortScrolling.xy;
    u_xlat0.xy = frac(u_xlat0.xy);
    u_xlatb1.xyz = lessThan(float4(0.0, 0.0, 0.0, 0.0), float4(_UseUV2Distortion, _UVDistortionAdd, _SingleChannel, _UseUV2Distortion)).xyz;
    u_xlat6.xy = (u_xlatb1.x) ? i.vs_TEXCOORD2.xy : i.vs_TEXCOORD1.xy;
    u_xlat6.xy = u_xlat6.xy * _DistortScrolling.zw + i.vs_TEXCOORD1.zw;
    u_xlat0.xy = u_xlat0.xy + u_xlat6.xy;
    u_xlat16_0.xy = tex2D(_DistortTex, u_xlat0.xy).xy;
    u_xlat6.xy = u_xlat16_0.xy * float2(2.0, 2.0) + float2(-1.0, -1.0);
    u_xlat0.xy = u_xlat16_0.xy + (-i.vs_TEXCOORD1.xy);
    u_xlat0.xy = ((float2)(_Distort)) * u_xlat0.xy + i.vs_TEXCOORD1.xy;
    u_xlat6.xy = u_xlat6.xy * ((float2)(_Distort)) + i.vs_TEXCOORD1.xy;
    u_xlat0.xy = (u_xlatb1.y) ? u_xlat6.xy : u_xlat0.xy;
    u_xlat6.xy = u_xlat0.xy + (-i.vs_TEXCOORD1.xy);
    u_xlat1 = i.vs_TEXCOORD1.y * 0.5;
    u_xlat6.xy = ((float2)(u_xlat1)) * u_xlat6.xy + i.vs_TEXCOORD1.xy;
    u_xlatb1.xy = lessThan(float4(0.0, 0.0, 0.0, 0.0), float4(_FadeAlongU, _HdrMultiply, _FadeAlongU, _FadeAlongU)).xy;
    u_xlat0.xy = (u_xlatb1.x) ? u_xlat6.xy : u_xlat0.xy;
    u_xlat16_0 = tex2D(_MainTex, u_xlat0.xy);
    u_xlat16_2.w = (u_xlatb1.z) ? u_xlat16_0.x : u_xlat16_0.w;
    u_xlat16_2.xyz = (u_xlatb1.z) ? float3(1.0, 1.0, 1.0) : u_xlat16_0.xyz;
    u_xlat16_0 = u_xlat16_2 * i.vs_COLOR0;
    u_xlat16_2.x = u_xlat16_2.w * i.vs_COLOR0.w + (-_Cutoff);
    u_xlatb1.x = u_xlat16_2.x<0.0;
    if(u_xlatb1.x){discard;}
    u_xlat1 = log2(_HdrMultiply);
    u_xlat1 = u_xlat1 * 0.416666657;
    u_xlat1 = exp2(u_xlat1);
    u_xlat1 = u_xlat1 * 1.05499995 + -0.0549999997;
    u_xlat1 = max(u_xlat1, 0.0);
    u_xlat16_2.xyz = u_xlat16_0.xyz * ((float3)(u_xlat1));
    u_xlat16_2.xyz = (u_xlatb1.y) ? u_xlat16_2.xyz : u_xlat16_0.xyz;
    u_xlat16_11 = min(u_xlat16_0.w, 1.0);
    u_xlat16_5 = max(u_xlat16_2.z, u_xlat16_2.y);
    u_xlat16_2.x = max(u_xlat16_5, u_xlat16_2.x);
    u_xlat16_2.x = u_xlat16_2.x * u_xlat16_11 + -0.00999999978;
    u_xlatb1.x = u_xlat16_2.x<0.0;
    if(u_xlatb1.x){discard;}
    result = float4(0.0, 0.0, 0.0, 0.0);
    return result;

}

#elif !defined(SHADOWS_CUBE) && defined(SHADOWS_DEPTH) && defined(_ALPHABLEND_ON) && !defined(_ALPHAMODULATE_ON) && !defined(_ALPHAPREMULTIPLY_ON) && !defined(_ALPHATEST_ON) && !defined(_CFXR_ADDITIVE) && defined(_CFXR_DISSOLVE) && defined(_CFXR_DITHERED_SHADOWS_ON) && !defined(_CFXR_OVERLAYTEX_1X) && !defined(_CFXR_UV_DISTORTION) && !defined(_FLIPBOOK_BLENDING)
// Original shadow GLES program 163
float _SingleChannel;
float _UseDissolveOffsetUV;
float _InvertDissolveTex;
float _DoubleDissolve;
float2 _DissolveScroll;
float _DissolveSmooth;
float4 _DissolveTex_ST;
float _ShadowStrength;
sampler2D _MainTex;
sampler2D _DissolveTex;
sampler3D _DitherMaskLOD;
struct A{float4 in_POSITION0:POSITION0;float4 in_COLOR0:COLOR0;float4 in_TEXCOORD0:TEXCOORD0;float4 in_TEXCOORD1:TEXCOORD1;float3 in_NORMAL0:NORMAL0;};
struct V{float4 vertex:SV_POSITION;float4 vs_COLOR0:TEXCOORD0;float4 vs_TEXCOORD1:TEXCOORD1;float4 vs_TEXCOORD2:TEXCOORD2;};
V vert(A i){V o=(V)0;
float4 u_xlat0;
float4 u_xlat1;
float4 u_xlat2;
float u_xlat6;
float u_xlat9;
bool u_xlatb9;

    o.vs_COLOR0 = i.in_COLOR0;
    o.vs_TEXCOORD1 = i.in_TEXCOORD0.xyxy;
    o.vs_TEXCOORD2 = i.in_TEXCOORD1;
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
float3 u_xlat1;
float u_xlat16_1;
float u_xlat16_2;
float u_xlat3;
float u_xlat16_4;
float2 u_xlat6;
bool2 u_xlatb6;
float u_xlat16_7;
float u_xlat16_10;

float4 hlslcc_FragCoord = float4(i.vertex.xyz, 1.0/i.vertex.w);
    u_xlat0.xy = _Time.yy * float2(_DissolveScroll.x, _DissolveScroll.y);
    u_xlat0.xy = frac(u_xlat0.xy);
    u_xlat6.xy = i.vs_TEXCOORD1.xy * _DissolveTex_ST.xy + _DissolveTex_ST.zw;
    u_xlat0.xy = u_xlat0.xy + u_xlat6.xy;
    u_xlatb6.xy = lessThan(float4(0.0, 0.0, 0.0, 0.0), float4(_SingleChannel, _UseDissolveOffsetUV, _SingleChannel, _UseDissolveOffsetUV)).xy;
    u_xlat0.xy = (u_xlatb6.y) ? u_xlat0.xy : i.vs_TEXCOORD1.xy;
    u_xlat16_0.x = tex2D(_DissolveTex, u_xlat0.xy).x;
    u_xlat16_1 = u_xlat16_0.x * 2.0 + -1.0;
    u_xlat3 = u_xlat16_1 * i.vs_TEXCOORD2.z + i.vs_TEXCOORD1.x;
    u_xlat16_1 = (u_xlatb6.y) ? u_xlat3 : u_xlat16_0.x;
    u_xlat16_4 = (-u_xlat16_1) + 1.0;
    u_xlatb0 = 0.0>=_InvertDissolveTex;
    u_xlat16_1 = (u_xlatb0) ? u_xlat16_4 : u_xlat16_1;
    u_xlat16_4 = u_xlat16_1 + _DissolveSmooth;
    u_xlat16_1 = u_xlat16_1 + (-_DissolveSmooth);
    u_xlat16_4 = (-u_xlat16_1) + u_xlat16_4;
    u_xlat16_4 = float(1.0) / u_xlat16_4;
    u_xlat16_7 = _DissolveSmooth * 2.0 + 1.0;
    u_xlat16_7 = i.vs_TEXCOORD2.x * u_xlat16_7 + (-_DissolveSmooth);
    u_xlat16_10 = (-u_xlat16_1) + u_xlat16_7;
    u_xlat16_10 = u_xlat16_4 * u_xlat16_10;
    u_xlat16_10 = clamp(u_xlat16_10, 0.0, 1.0);
    u_xlat16_2 = u_xlat16_10 * -2.0 + 3.0;
    u_xlat16_10 = u_xlat16_10 * u_xlat16_10;
    u_xlat16_10 = u_xlat16_10 * u_xlat16_2;
    u_xlat16_0.xy = tex2D(_MainTex, i.vs_TEXCOORD1.xy).xw;
    u_xlat16_2 = (u_xlatb6.x) ? u_xlat16_0.x : u_xlat16_0.y;
    u_xlat16_2 = u_xlat16_2 * i.vs_COLOR0.w;
    u_xlat16_10 = u_xlat16_10 * u_xlat16_2;
    u_xlatb0 = 0.0<_DoubleDissolve;
    u_xlat16_2 = (u_xlatb0) ? i.vs_TEXCOORD2.y : 0.0;
    u_xlat16_7 = u_xlat16_7 + (-u_xlat16_2);
    u_xlatb0 = 0.0<u_xlat16_2;
    u_xlat16_1 = (-u_xlat16_1) + u_xlat16_7;
    u_xlat16_1 = u_xlat16_4 * u_xlat16_1;
    u_xlat16_1 = clamp(u_xlat16_1, 0.0, 1.0);
    u_xlat16_4 = u_xlat16_1 * -2.0 + 3.0;
    u_xlat16_1 = u_xlat16_1 * u_xlat16_1;
    u_xlat16_1 = (-u_xlat16_4) * u_xlat16_1 + u_xlat16_10;
    u_xlat16_1 = clamp(u_xlat16_1, 0.0, 1.0);
    u_xlat16_1 = (u_xlatb0) ? u_xlat16_1 : u_xlat16_10;
    u_xlat16_1 = min(u_xlat16_1, 1.0);
    u_xlat0.x = min(u_xlat16_1, _ShadowStrength);
    u_xlat16_7 = u_xlat0.x * 0.9375;
    u_xlat1.z = u_xlat16_7;
    u_xlat1.xy = hlslcc_FragCoord.xy * float2(0.25, 0.25);
    u_xlat16_0.x = tex3D(_DitherMaskLOD, u_xlat1.xyz).w;
    u_xlat16_2 = u_xlat16_0.x + -0.00999999978;
    u_xlatb0 = u_xlat16_2<0.0;
    if(u_xlatb0){discard;}
    result = float4(0.0, 0.0, 0.0, 0.0);
    return result;

}

#elif !defined(SHADOWS_CUBE) && defined(SHADOWS_DEPTH) && defined(_ALPHABLEND_ON) && !defined(_ALPHAMODULATE_ON) && !defined(_ALPHAPREMULTIPLY_ON) && !defined(_ALPHATEST_ON) && !defined(_CFXR_ADDITIVE) && !defined(_CFXR_DISSOLVE) && defined(_CFXR_DITHERED_SHADOWS_ON) && !defined(_CFXR_OVERLAYTEX_1X) && !defined(_CFXR_UV_DISTORTION) && defined(_FLIPBOOK_BLENDING)
// Original shadow GLES program 165
float _SingleChannel;
float _ShadowStrength;
sampler2D _MainTex;
sampler3D _DitherMaskLOD;
struct A{float4 in_POSITION0:POSITION0;float4 in_COLOR0:COLOR0;float4 in_TEXCOORD0:TEXCOORD0;float4 in_TEXCOORD1:TEXCOORD1;float3 in_NORMAL0:NORMAL0;};
struct V{float4 vertex:SV_POSITION;float4 vs_COLOR0:TEXCOORD0;float4 vs_TEXCOORD1:TEXCOORD1;float4 vs_TEXCOORD2:TEXCOORD2;};
V vert(A i){V o=(V)0;
float4 u_xlat0;
float4 u_xlat1;
float4 u_xlat2;
float u_xlat6;
float u_xlat9;
bool u_xlatb9;

    o.vs_COLOR0 = i.in_COLOR0;
    o.vs_TEXCOORD1 = i.in_TEXCOORD0.xyxy;
    o.vs_TEXCOORD2 = i.in_TEXCOORD1;
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
float2 u_xlat16_0;
bool u_xlatb0;
float3 u_xlat1;
float u_xlat16_1;
float u_xlat16_2;
float u_xlat16_4;
bool u_xlatb6;
float u_xlat16_7;

float4 hlslcc_FragCoord = float4(i.vertex.xyz, 1.0/i.vertex.w);
    u_xlat16_0.xy = tex2D(_MainTex, i.vs_TEXCOORD1.zw).xw;
    u_xlatb6 = 0.0<_SingleChannel;
    u_xlat16_1 = (u_xlatb6) ? u_xlat16_0.x : u_xlat16_0.y;
    u_xlat16_0.xy = tex2D(_MainTex, i.vs_TEXCOORD1.xy).xw;
    u_xlat16_4 = (u_xlatb6) ? u_xlat16_0.x : u_xlat16_0.y;
    u_xlat0 = (-u_xlat16_4) + u_xlat16_1;
    u_xlat0 = i.vs_TEXCOORD2.y * u_xlat0 + u_xlat16_4;
    u_xlat16_1 = u_xlat0 * i.vs_COLOR0.w;
    u_xlat16_1 = min(u_xlat16_1, 1.0);
    u_xlat0 = min(u_xlat16_1, _ShadowStrength);
    u_xlat16_7 = u_xlat0 * 0.9375;
    u_xlat1.z = u_xlat16_7;
    u_xlat1.xy = hlslcc_FragCoord.xy * float2(0.25, 0.25);
    u_xlat16_0.x = tex3D(_DitherMaskLOD, u_xlat1.xyz).w;
    u_xlat16_2 = u_xlat16_0.x + -0.00999999978;
    u_xlatb0 = u_xlat16_2<0.0;
    if(u_xlatb0){discard;}
    result = float4(0.0, 0.0, 0.0, 0.0);
    return result;

}

#elif !defined(SHADOWS_CUBE) && defined(SHADOWS_DEPTH) && defined(_ALPHABLEND_ON) && !defined(_ALPHAMODULATE_ON) && !defined(_ALPHAPREMULTIPLY_ON) && defined(_ALPHATEST_ON) && !defined(_CFXR_ADDITIVE) && !defined(_CFXR_DISSOLVE) && defined(_CFXR_DITHERED_SHADOWS_ON) && !defined(_CFXR_OVERLAYTEX_1X) && !defined(_CFXR_UV_DISTORTION) && !defined(_FLIPBOOK_BLENDING)
// Original shadow GLES program 166
float _SingleChannel;
float _Cutoff;
float _ShadowStrength;
sampler2D _MainTex;
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
float u_xlat0;
float2 u_xlat16_0;
bool u_xlatb0;
float u_xlat16_1;
float3 u_xlat2;
float u_xlat16_4;
bool u_xlatb6;
float u_xlat16_8;

float4 hlslcc_FragCoord = float4(i.vertex.xyz, 1.0/i.vertex.w);
    u_xlat16_0.xy = tex2D(_MainTex, i.vs_TEXCOORD1.xy).xw;
    u_xlatb6 = 0.0<_SingleChannel;
    u_xlat16_1 = (u_xlatb6) ? u_xlat16_0.x : u_xlat16_0.y;
    u_xlat16_4 = u_xlat16_1 * i.vs_COLOR0.w + (-_Cutoff);
    u_xlat16_1 = u_xlat16_1 * i.vs_COLOR0.w;
    u_xlat16_1 = min(u_xlat16_1, 1.0);
    u_xlat0 = min(u_xlat16_1, _ShadowStrength);
    u_xlat16_8 = u_xlat0 * 0.9375;
    u_xlat2.z = u_xlat16_8;
    u_xlatb0 = u_xlat16_4<0.0;
    if(u_xlatb0){discard;}
    u_xlat2.xy = hlslcc_FragCoord.xy * float2(0.25, 0.25);
    u_xlat16_0.x = tex3D(_DitherMaskLOD, u_xlat2.xyz).w;
    u_xlat16_1 = u_xlat16_0.x + -0.00999999978;
    u_xlatb0 = u_xlat16_1<0.0;
    if(u_xlatb0){discard;}
    result = float4(0.0, 0.0, 0.0, 0.0);
    return result;

}

#elif !defined(SHADOWS_CUBE) && defined(SHADOWS_DEPTH) && !defined(_ALPHABLEND_ON) && defined(_ALPHAMODULATE_ON) && !defined(_ALPHAPREMULTIPLY_ON) && !defined(_ALPHATEST_ON) && !defined(_CFXR_ADDITIVE) && defined(_CFXR_DISSOLVE) && defined(_CFXR_DITHERED_SHADOWS_ON) && !defined(_CFXR_OVERLAYTEX_1X) && !defined(_CFXR_UV_DISTORTION) && !defined(_FLIPBOOK_BLENDING)
// Original shadow GLES program 167
float _SingleChannel;
float _UseDissolveOffsetUV;
float _InvertDissolveTex;
float _DoubleDissolve;
float2 _DissolveScroll;
float _DissolveSmooth;
float4 _DissolveTex_ST;
float _ShadowStrength;
sampler2D _MainTex;
sampler2D _DissolveTex;
sampler3D _DitherMaskLOD;
struct A{float4 in_POSITION0:POSITION0;float4 in_COLOR0:COLOR0;float4 in_TEXCOORD0:TEXCOORD0;float4 in_TEXCOORD1:TEXCOORD1;float3 in_NORMAL0:NORMAL0;};
struct V{float4 vertex:SV_POSITION;float4 vs_COLOR0:TEXCOORD0;float4 vs_TEXCOORD1:TEXCOORD1;float4 vs_TEXCOORD2:TEXCOORD2;};
V vert(A i){V o=(V)0;
float4 u_xlat0;
float4 u_xlat1;
float4 u_xlat2;
float u_xlat6;
float u_xlat9;
bool u_xlatb9;

    o.vs_COLOR0 = i.in_COLOR0;
    o.vs_TEXCOORD1 = i.in_TEXCOORD0.xyxy;
    o.vs_TEXCOORD2 = i.in_TEXCOORD1;
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
float3 u_xlat1;
float u_xlat16_1;
float u_xlat16_2;
float u_xlat3;
float u_xlat16_4;
float2 u_xlat6;
bool2 u_xlatb6;
float u_xlat16_7;
float u_xlat16_10;

float4 hlslcc_FragCoord = float4(i.vertex.xyz, 1.0/i.vertex.w);
    u_xlat0.xy = _Time.yy * float2(_DissolveScroll.x, _DissolveScroll.y);
    u_xlat0.xy = frac(u_xlat0.xy);
    u_xlat6.xy = i.vs_TEXCOORD1.xy * _DissolveTex_ST.xy + _DissolveTex_ST.zw;
    u_xlat0.xy = u_xlat0.xy + u_xlat6.xy;
    u_xlatb6.xy = lessThan(float4(0.0, 0.0, 0.0, 0.0), float4(_SingleChannel, _UseDissolveOffsetUV, _SingleChannel, _UseDissolveOffsetUV)).xy;
    u_xlat0.xy = (u_xlatb6.y) ? u_xlat0.xy : i.vs_TEXCOORD1.xy;
    u_xlat16_0.x = tex2D(_DissolveTex, u_xlat0.xy).x;
    u_xlat16_1 = u_xlat16_0.x * 2.0 + -1.0;
    u_xlat3 = u_xlat16_1 * i.vs_TEXCOORD2.z + i.vs_TEXCOORD1.x;
    u_xlat16_1 = (u_xlatb6.y) ? u_xlat3 : u_xlat16_0.x;
    u_xlat16_4 = (-u_xlat16_1) + 1.0;
    u_xlatb0 = 0.0>=_InvertDissolveTex;
    u_xlat16_1 = (u_xlatb0) ? u_xlat16_4 : u_xlat16_1;
    u_xlat16_4 = u_xlat16_1 + _DissolveSmooth;
    u_xlat16_1 = u_xlat16_1 + (-_DissolveSmooth);
    u_xlat16_4 = (-u_xlat16_1) + u_xlat16_4;
    u_xlat16_4 = float(1.0) / u_xlat16_4;
    u_xlat16_7 = _DissolveSmooth * 2.0 + 1.0;
    u_xlat16_7 = i.vs_TEXCOORD2.x * u_xlat16_7 + (-_DissolveSmooth);
    u_xlat16_10 = (-u_xlat16_1) + u_xlat16_7;
    u_xlat16_10 = u_xlat16_4 * u_xlat16_10;
    u_xlat16_10 = clamp(u_xlat16_10, 0.0, 1.0);
    u_xlat16_2 = u_xlat16_10 * -2.0 + 3.0;
    u_xlat16_10 = u_xlat16_10 * u_xlat16_10;
    u_xlat16_10 = u_xlat16_10 * u_xlat16_2;
    u_xlat16_0.xy = tex2D(_MainTex, i.vs_TEXCOORD1.xy).xw;
    u_xlat16_2 = (u_xlatb6.x) ? u_xlat16_0.x : u_xlat16_0.y;
    u_xlat16_2 = u_xlat16_2 * i.vs_COLOR0.w;
    u_xlat16_10 = u_xlat16_10 * u_xlat16_2;
    u_xlatb0 = 0.0<_DoubleDissolve;
    u_xlat16_2 = (u_xlatb0) ? i.vs_TEXCOORD2.y : 0.0;
    u_xlat16_7 = u_xlat16_7 + (-u_xlat16_2);
    u_xlatb0 = 0.0<u_xlat16_2;
    u_xlat16_1 = (-u_xlat16_1) + u_xlat16_7;
    u_xlat16_1 = u_xlat16_4 * u_xlat16_1;
    u_xlat16_1 = clamp(u_xlat16_1, 0.0, 1.0);
    u_xlat16_4 = u_xlat16_1 * -2.0 + 3.0;
    u_xlat16_1 = u_xlat16_1 * u_xlat16_1;
    u_xlat16_1 = (-u_xlat16_4) * u_xlat16_1 + u_xlat16_10;
    u_xlat16_1 = clamp(u_xlat16_1, 0.0, 1.0);
    u_xlat16_1 = (u_xlatb0) ? u_xlat16_1 : u_xlat16_10;
    u_xlat16_1 = min(u_xlat16_1, 1.0);
    u_xlat0.x = min(u_xlat16_1, _ShadowStrength);
    u_xlat16_7 = u_xlat0.x * 0.9375;
    u_xlat1.z = u_xlat16_7;
    u_xlat1.xy = hlslcc_FragCoord.xy * float2(0.25, 0.25);
    u_xlat16_0.x = tex3D(_DitherMaskLOD, u_xlat1.xyz).w;
    u_xlat16_2 = u_xlat16_0.x + -0.00999999978;
    u_xlatb0 = u_xlat16_2<0.0;
    if(u_xlatb0){discard;}
    result = float4(0.0, 0.0, 0.0, 0.0);
    return result;

}

#elif defined(SHADOWS_CUBE) && !defined(SHADOWS_DEPTH) && defined(_ALPHABLEND_ON) && !defined(_ALPHAMODULATE_ON) && !defined(_ALPHAPREMULTIPLY_ON) && !defined(_ALPHATEST_ON) && !defined(_CFXR_ADDITIVE) && defined(_CFXR_DISSOLVE) && !defined(_CFXR_DITHERED_SHADOWS_ON) && !defined(_CFXR_OVERLAYTEX_1X) && !defined(_CFXR_UV_DISTORTION) && !defined(_FLIPBOOK_BLENDING)
// Original shadow GLES program 125
float _SingleChannel;
float _UseDissolveOffsetUV;
float _InvertDissolveTex;
float _DoubleDissolve;
float2 _DissolveScroll;
float _DissolveSmooth;
float4 _DissolveTex_ST;
sampler2D _MainTex;
sampler2D _DissolveTex;
struct A{float4 in_POSITION0:POSITION0;float4 in_COLOR0:COLOR0;float4 in_TEXCOORD0:TEXCOORD0;float4 in_TEXCOORD1:TEXCOORD1;float3 in_NORMAL0:NORMAL0;};
struct V{float4 vertex:SV_POSITION;float4 vs_COLOR0:TEXCOORD0;float4 vs_TEXCOORD1:TEXCOORD1;float4 vs_TEXCOORD2:TEXCOORD2;};
V vert(A i){V o=(V)0;
float4 u_xlat0;
float4 u_xlat1;
float4 u_xlat2;
float u_xlat9;
bool u_xlatb9;

    o.vs_COLOR0 = i.in_COLOR0;
    o.vs_TEXCOORD1 = i.in_TEXCOORD0.xyxy;
    o.vs_TEXCOORD2 = i.in_TEXCOORD1;
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
float u_xlat16_1;
float u_xlat16_2;
float u_xlat3;
float u_xlat16_4;
float2 u_xlat6;
bool2 u_xlatb6;
float u_xlat16_7;
float u_xlat16_10;

    u_xlat0.xy = _Time.yy * float2(_DissolveScroll.x, _DissolveScroll.y);
    u_xlat0.xy = frac(u_xlat0.xy);
    u_xlat6.xy = i.vs_TEXCOORD1.xy * _DissolveTex_ST.xy + _DissolveTex_ST.zw;
    u_xlat0.xy = u_xlat0.xy + u_xlat6.xy;
    u_xlatb6.xy = lessThan(float4(0.0, 0.0, 0.0, 0.0), float4(_SingleChannel, _UseDissolveOffsetUV, _SingleChannel, _UseDissolveOffsetUV)).xy;
    u_xlat0.xy = (u_xlatb6.y) ? u_xlat0.xy : i.vs_TEXCOORD1.xy;
    u_xlat16_0.x = tex2D(_DissolveTex, u_xlat0.xy).x;
    u_xlat16_1 = u_xlat16_0.x * 2.0 + -1.0;
    u_xlat3 = u_xlat16_1 * i.vs_TEXCOORD2.z + i.vs_TEXCOORD1.x;
    u_xlat16_1 = (u_xlatb6.y) ? u_xlat3 : u_xlat16_0.x;
    u_xlat16_4 = (-u_xlat16_1) + 1.0;
    u_xlatb0 = 0.0>=_InvertDissolveTex;
    u_xlat16_1 = (u_xlatb0) ? u_xlat16_4 : u_xlat16_1;
    u_xlat16_4 = u_xlat16_1 + _DissolveSmooth;
    u_xlat16_1 = u_xlat16_1 + (-_DissolveSmooth);
    u_xlat16_4 = (-u_xlat16_1) + u_xlat16_4;
    u_xlat16_4 = float(1.0) / u_xlat16_4;
    u_xlat16_7 = _DissolveSmooth * 2.0 + 1.0;
    u_xlat16_7 = i.vs_TEXCOORD2.x * u_xlat16_7 + (-_DissolveSmooth);
    u_xlat16_10 = (-u_xlat16_1) + u_xlat16_7;
    u_xlat16_10 = u_xlat16_4 * u_xlat16_10;
    u_xlat16_10 = clamp(u_xlat16_10, 0.0, 1.0);
    u_xlat16_2 = u_xlat16_10 * -2.0 + 3.0;
    u_xlat16_10 = u_xlat16_10 * u_xlat16_10;
    u_xlat16_10 = u_xlat16_10 * u_xlat16_2;
    u_xlat16_0.xy = tex2D(_MainTex, i.vs_TEXCOORD1.xy).xw;
    u_xlat16_2 = (u_xlatb6.x) ? u_xlat16_0.x : u_xlat16_0.y;
    u_xlat16_2 = u_xlat16_2 * i.vs_COLOR0.w;
    u_xlat16_10 = u_xlat16_10 * u_xlat16_2;
    u_xlatb0 = 0.0<_DoubleDissolve;
    u_xlat16_2 = (u_xlatb0) ? i.vs_TEXCOORD2.y : 0.0;
    u_xlat16_7 = u_xlat16_7 + (-u_xlat16_2);
    u_xlatb0 = 0.0<u_xlat16_2;
    u_xlat16_1 = (-u_xlat16_1) + u_xlat16_7;
    u_xlat16_1 = u_xlat16_4 * u_xlat16_1;
    u_xlat16_1 = clamp(u_xlat16_1, 0.0, 1.0);
    u_xlat16_4 = u_xlat16_1 * -2.0 + 3.0;
    u_xlat16_1 = u_xlat16_1 * u_xlat16_1;
    u_xlat16_1 = (-u_xlat16_4) * u_xlat16_1 + u_xlat16_10;
    u_xlat16_1 = clamp(u_xlat16_1, 0.0, 1.0);
    u_xlat16_1 = (u_xlatb0) ? u_xlat16_1 : u_xlat16_10;
    u_xlat16_1 = min(u_xlat16_1, 1.0);
    u_xlat16_1 = u_xlat16_1 + -0.00999999978;
    u_xlatb0 = u_xlat16_1<0.0;
    if(u_xlatb0){discard;}
    result = float4(0.0, 0.0, 0.0, 0.0);
    return result;

}

#elif defined(SHADOWS_CUBE) && !defined(SHADOWS_DEPTH) && defined(_ALPHABLEND_ON) && !defined(_ALPHAMODULATE_ON) && !defined(_ALPHAPREMULTIPLY_ON) && !defined(_ALPHATEST_ON) && !defined(_CFXR_ADDITIVE) && !defined(_CFXR_DISSOLVE) && !defined(_CFXR_DITHERED_SHADOWS_ON) && !defined(_CFXR_OVERLAYTEX_1X) && defined(_CFXR_UV_DISTORTION) && !defined(_FLIPBOOK_BLENDING)
// Original shadow GLES program 126
float _SingleChannel;
float _UseUV2Distortion;
float _UVDistortionAdd;
float4 _DistortScrolling;
float _Distort;
float _FadeAlongU;
sampler2D _DistortTex;
sampler2D _MainTex;
struct A{float4 in_POSITION0:POSITION0;float4 in_COLOR0:COLOR0;float4 in_TEXCOORD0:TEXCOORD0;float4 in_TEXCOORD1:TEXCOORD1;float3 in_NORMAL0:NORMAL0;};
struct V{float4 vertex:SV_POSITION;float4 vs_COLOR0:TEXCOORD0;float4 vs_TEXCOORD1:TEXCOORD1;float4 vs_TEXCOORD2:TEXCOORD2;};
V vert(A i){V o=(V)0;
float4 u_xlat0;
float4 u_xlat1;
float4 u_xlat2;
float u_xlat9;
bool u_xlatb9;

    o.vs_COLOR0 = i.in_COLOR0;
    o.vs_TEXCOORD1 = i.in_TEXCOORD0.xyxy;
    o.vs_TEXCOORD2 = i.in_TEXCOORD1;
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
bool3 u_xlatb1;
float u_xlat16_2;
float2 u_xlat6;

    u_xlat0.xy = _Time.yy * _DistortScrolling.xy;
    u_xlat0.xy = frac(u_xlat0.xy);
    u_xlatb1.xyz = lessThan(float4(0.0, 0.0, 0.0, 0.0), float4(_UseUV2Distortion, _UVDistortionAdd, _SingleChannel, _UseUV2Distortion)).xyz;
    u_xlat6.xy = (u_xlatb1.x) ? i.vs_TEXCOORD2.xy : i.vs_TEXCOORD1.xy;
    u_xlat6.xy = u_xlat6.xy * _DistortScrolling.zw + i.vs_TEXCOORD1.zw;
    u_xlat0.xy = u_xlat0.xy + u_xlat6.xy;
    u_xlat16_0.xy = tex2D(_DistortTex, u_xlat0.xy).xy;
    u_xlat6.xy = u_xlat16_0.xy * float2(2.0, 2.0) + float2(-1.0, -1.0);
    u_xlat0.xy = u_xlat16_0.xy + (-i.vs_TEXCOORD1.xy);
    u_xlat0.xy = ((float2)(_Distort)) * u_xlat0.xy + i.vs_TEXCOORD1.xy;
    u_xlat6.xy = u_xlat6.xy * ((float2)(_Distort)) + i.vs_TEXCOORD1.xy;
    u_xlat0.xy = (u_xlatb1.y) ? u_xlat6.xy : u_xlat0.xy;
    u_xlat6.xy = u_xlat0.xy + (-i.vs_TEXCOORD1.xy);
    u_xlat1 = i.vs_TEXCOORD1.y * 0.5;
    u_xlat6.xy = ((float2)(u_xlat1)) * u_xlat6.xy + i.vs_TEXCOORD1.xy;
    u_xlatb1.x = 0.0<_FadeAlongU;
    u_xlat0.xy = (u_xlatb1.x) ? u_xlat6.xy : u_xlat0.xy;
    u_xlat16_0.xy = tex2D(_MainTex, u_xlat0.xy).xw;
    u_xlat16_2 = (u_xlatb1.z) ? u_xlat16_0.x : u_xlat16_0.y;
    u_xlat16_2 = u_xlat16_2 * i.vs_COLOR0.w;
    u_xlat16_2 = min(u_xlat16_2, 1.0);
    u_xlat16_2 = u_xlat16_2 + -0.00999999978;
    u_xlatb0 = u_xlat16_2<0.0;
    if(u_xlatb0){discard;}
    result = float4(0.0, 0.0, 0.0, 0.0);
    return result;

}

#elif defined(SHADOWS_CUBE) && !defined(SHADOWS_DEPTH) && defined(_ALPHABLEND_ON) && !defined(_ALPHAMODULATE_ON) && !defined(_ALPHAPREMULTIPLY_ON) && !defined(_ALPHATEST_ON) && !defined(_CFXR_ADDITIVE) && !defined(_CFXR_DISSOLVE) && !defined(_CFXR_DITHERED_SHADOWS_ON) && !defined(_CFXR_OVERLAYTEX_1X) && !defined(_CFXR_UV_DISTORTION) && defined(_FLIPBOOK_BLENDING)
// Original shadow GLES program 129
float _SingleChannel;
sampler2D _MainTex;
struct A{float4 in_POSITION0:POSITION0;float4 in_COLOR0:COLOR0;float4 in_TEXCOORD0:TEXCOORD0;float4 in_TEXCOORD1:TEXCOORD1;float3 in_NORMAL0:NORMAL0;};
struct V{float4 vertex:SV_POSITION;float4 vs_COLOR0:TEXCOORD0;float4 vs_TEXCOORD1:TEXCOORD1;float4 vs_TEXCOORD2:TEXCOORD2;};
V vert(A i){V o=(V)0;
float4 u_xlat0;
float4 u_xlat1;
float4 u_xlat2;
float u_xlat9;
bool u_xlatb9;

    o.vs_COLOR0 = i.in_COLOR0;
    o.vs_TEXCOORD1 = i.in_TEXCOORD0.xyxy;
    o.vs_TEXCOORD2 = i.in_TEXCOORD1;
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
float2 u_xlat16_0;
bool u_xlatb0;
float u_xlat16_1;
float u_xlat16_3;
bool u_xlatb4;

    u_xlat16_0.xy = tex2D(_MainTex, i.vs_TEXCOORD1.zw).xw;
    u_xlatb4 = 0.0<_SingleChannel;
    u_xlat16_1 = (u_xlatb4) ? u_xlat16_0.x : u_xlat16_0.y;
    u_xlat16_0.xy = tex2D(_MainTex, i.vs_TEXCOORD1.xy).xw;
    u_xlat16_3 = (u_xlatb4) ? u_xlat16_0.x : u_xlat16_0.y;
    u_xlat0 = (-u_xlat16_3) + u_xlat16_1;
    u_xlat0 = i.vs_TEXCOORD2.y * u_xlat0 + u_xlat16_3;
    u_xlat16_1 = u_xlat0 * i.vs_COLOR0.w;
    u_xlat16_1 = min(u_xlat16_1, 1.0);
    u_xlat16_1 = u_xlat16_1 + -0.00999999978;
    u_xlatb0 = u_xlat16_1<0.0;
    if(u_xlatb0){discard;}
    result = float4(0.0, 0.0, 0.0, 0.0);
    return result;

}

#elif defined(SHADOWS_CUBE) && !defined(SHADOWS_DEPTH) && defined(_ALPHABLEND_ON) && !defined(_ALPHAMODULATE_ON) && !defined(_ALPHAPREMULTIPLY_ON) && defined(_ALPHATEST_ON) && !defined(_CFXR_ADDITIVE) && !defined(_CFXR_DISSOLVE) && !defined(_CFXR_DITHERED_SHADOWS_ON) && !defined(_CFXR_OVERLAYTEX_1X) && !defined(_CFXR_UV_DISTORTION) && !defined(_FLIPBOOK_BLENDING)
// Original shadow GLES program 130
float _SingleChannel;
float _Cutoff;
sampler2D _MainTex;
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
float2 u_xlat16_0;
bool u_xlatb0;
float u_xlat16_1;
float u_xlat16_3;
bool u_xlatb4;

    u_xlat16_0.xy = tex2D(_MainTex, i.vs_TEXCOORD1.xy).xw;
    u_xlatb4 = 0.0<_SingleChannel;
    u_xlat16_1 = (u_xlatb4) ? u_xlat16_0.x : u_xlat16_0.y;
    u_xlat16_3 = u_xlat16_1 * i.vs_COLOR0.w + (-_Cutoff);
    u_xlat16_1 = u_xlat16_1 * i.vs_COLOR0.w;
    u_xlat16_1 = min(u_xlat16_1, 1.0);
    u_xlat16_1 = u_xlat16_1 + -0.00999999978;
    u_xlatb0 = u_xlat16_1<0.0;
    if(u_xlatb0){discard;}
    u_xlatb0 = u_xlat16_3<0.0;
    if(u_xlatb0){discard;}
    result = float4(0.0, 0.0, 0.0, 0.0);
    return result;

}

#elif defined(SHADOWS_CUBE) && !defined(SHADOWS_DEPTH) && !defined(_ALPHABLEND_ON) && defined(_ALPHAMODULATE_ON) && !defined(_ALPHAPREMULTIPLY_ON) && !defined(_ALPHATEST_ON) && !defined(_CFXR_ADDITIVE) && !defined(_CFXR_DISSOLVE) && !defined(_CFXR_DITHERED_SHADOWS_ON) && !defined(_CFXR_OVERLAYTEX_1X) && defined(_CFXR_UV_DISTORTION) && !defined(_FLIPBOOK_BLENDING)
// Original shadow GLES program 133
float _SingleChannel;
float _UseUV2Distortion;
float _UVDistortionAdd;
float4 _DistortScrolling;
float _Distort;
float _FadeAlongU;
sampler2D _DistortTex;
sampler2D _MainTex;
struct A{float4 in_POSITION0:POSITION0;float4 in_COLOR0:COLOR0;float4 in_TEXCOORD0:TEXCOORD0;float4 in_TEXCOORD1:TEXCOORD1;float3 in_NORMAL0:NORMAL0;};
struct V{float4 vertex:SV_POSITION;float4 vs_COLOR0:TEXCOORD0;float4 vs_TEXCOORD1:TEXCOORD1;float4 vs_TEXCOORD2:TEXCOORD2;};
V vert(A i){V o=(V)0;
float4 u_xlat0;
float4 u_xlat1;
float4 u_xlat2;
float u_xlat9;
bool u_xlatb9;

    o.vs_COLOR0 = i.in_COLOR0;
    o.vs_TEXCOORD1 = i.in_TEXCOORD0.xyxy;
    o.vs_TEXCOORD2 = i.in_TEXCOORD1;
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
bool3 u_xlatb1;
float u_xlat16_2;
float2 u_xlat6;

    u_xlat0.xy = _Time.yy * _DistortScrolling.xy;
    u_xlat0.xy = frac(u_xlat0.xy);
    u_xlatb1.xyz = lessThan(float4(0.0, 0.0, 0.0, 0.0), float4(_UseUV2Distortion, _UVDistortionAdd, _SingleChannel, _UseUV2Distortion)).xyz;
    u_xlat6.xy = (u_xlatb1.x) ? i.vs_TEXCOORD2.xy : i.vs_TEXCOORD1.xy;
    u_xlat6.xy = u_xlat6.xy * _DistortScrolling.zw + i.vs_TEXCOORD1.zw;
    u_xlat0.xy = u_xlat0.xy + u_xlat6.xy;
    u_xlat16_0.xy = tex2D(_DistortTex, u_xlat0.xy).xy;
    u_xlat6.xy = u_xlat16_0.xy * float2(2.0, 2.0) + float2(-1.0, -1.0);
    u_xlat0.xy = u_xlat16_0.xy + (-i.vs_TEXCOORD1.xy);
    u_xlat0.xy = ((float2)(_Distort)) * u_xlat0.xy + i.vs_TEXCOORD1.xy;
    u_xlat6.xy = u_xlat6.xy * ((float2)(_Distort)) + i.vs_TEXCOORD1.xy;
    u_xlat0.xy = (u_xlatb1.y) ? u_xlat6.xy : u_xlat0.xy;
    u_xlat6.xy = u_xlat0.xy + (-i.vs_TEXCOORD1.xy);
    u_xlat1 = i.vs_TEXCOORD1.y * 0.5;
    u_xlat6.xy = ((float2)(u_xlat1)) * u_xlat6.xy + i.vs_TEXCOORD1.xy;
    u_xlatb1.x = 0.0<_FadeAlongU;
    u_xlat0.xy = (u_xlatb1.x) ? u_xlat6.xy : u_xlat0.xy;
    u_xlat16_0.xy = tex2D(_MainTex, u_xlat0.xy).xw;
    u_xlat16_2 = (u_xlatb1.z) ? u_xlat16_0.x : u_xlat16_0.y;
    u_xlat16_2 = u_xlat16_2 * i.vs_COLOR0.w;
    u_xlat16_2 = min(u_xlat16_2, 1.0);
    u_xlat16_2 = u_xlat16_2 + -0.00999999978;
    u_xlatb0 = u_xlat16_2<0.0;
    if(u_xlatb0){discard;}
    result = float4(0.0, 0.0, 0.0, 0.0);
    return result;

}

#elif defined(SHADOWS_CUBE) && !defined(SHADOWS_DEPTH) && !defined(_ALPHABLEND_ON) && !defined(_ALPHAMODULATE_ON) && !defined(_ALPHAPREMULTIPLY_ON) && !defined(_ALPHATEST_ON) && defined(_CFXR_ADDITIVE) && defined(_CFXR_DISSOLVE) && !defined(_CFXR_DITHERED_SHADOWS_ON) && !defined(_CFXR_OVERLAYTEX_1X) && !defined(_CFXR_UV_DISTORTION) && !defined(_FLIPBOOK_BLENDING)
// Original shadow GLES program 135
float _SingleChannel;
float _UseDissolveOffsetUV;
float _InvertDissolveTex;
float _DoubleDissolve;
float2 _DissolveScroll;
float _DissolveSmooth;
float _HdrMultiply;
float4 _DissolveTex_ST;
sampler2D _MainTex;
sampler2D _DissolveTex;
struct A{float4 in_POSITION0:POSITION0;float4 in_COLOR0:COLOR0;float4 in_TEXCOORD0:TEXCOORD0;float4 in_TEXCOORD1:TEXCOORD1;float3 in_NORMAL0:NORMAL0;};
struct V{float4 vertex:SV_POSITION;float4 vs_COLOR0:TEXCOORD0;float4 vs_TEXCOORD1:TEXCOORD1;float4 vs_TEXCOORD2:TEXCOORD2;};
V vert(A i){V o=(V)0;
float4 u_xlat0;
float4 u_xlat1;
float4 u_xlat2;
float u_xlat9;
bool u_xlatb9;

    o.vs_COLOR0 = i.in_COLOR0;
    o.vs_TEXCOORD1 = i.in_TEXCOORD0.xyxy;
    o.vs_TEXCOORD2 = i.in_TEXCOORD1;
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
float4 u_xlat16_0;
bool u_xlatb0;
float u_xlat16_1;
float4 u_xlat16_2;
float4 u_xlat16_3;
float u_xlat4;
bool u_xlatb4;
float u_xlat5;
float3 u_xlat16_6;
float2 u_xlat10;
bool2 u_xlatb10;
float u_xlat16_11;
float u_xlat16_16;

    u_xlat0.xy = _Time.yy * float2(_DissolveScroll.x, _DissolveScroll.y);
    u_xlat0.xy = frac(u_xlat0.xy);
    u_xlat10.xy = i.vs_TEXCOORD1.xy * _DissolveTex_ST.xy + _DissolveTex_ST.zw;
    u_xlat0.xy = u_xlat0.xy + u_xlat10.xy;
    u_xlatb10.xy = lessThan(float4(0.0, 0.0, 0.0, 0.0), float4(_SingleChannel, _UseDissolveOffsetUV, _SingleChannel, _UseDissolveOffsetUV)).xy;
    u_xlat0.xy = (u_xlatb10.y) ? u_xlat0.xy : i.vs_TEXCOORD1.xy;
    u_xlat16_0.x = tex2D(_DissolveTex, u_xlat0.xy).x;
    u_xlat16_1 = u_xlat16_0.x * 2.0 + -1.0;
    u_xlat5 = u_xlat16_1 * i.vs_TEXCOORD2.z + i.vs_TEXCOORD1.x;
    u_xlat16_1 = (u_xlatb10.y) ? u_xlat5 : u_xlat16_0.x;
    u_xlat16_6.x = (-u_xlat16_1) + 1.0;
    u_xlatb0 = 0.0>=_InvertDissolveTex;
    u_xlat16_1 = (u_xlatb0) ? u_xlat16_6.x : u_xlat16_1;
    u_xlat16_6.x = u_xlat16_1 + _DissolveSmooth;
    u_xlat16_1 = u_xlat16_1 + (-_DissolveSmooth);
    u_xlat16_6.x = (-u_xlat16_1) + u_xlat16_6.x;
    u_xlat16_6.x = float(1.0) / u_xlat16_6.x;
    u_xlat16_11 = _DissolveSmooth * 2.0 + 1.0;
    u_xlat16_11 = i.vs_TEXCOORD2.x * u_xlat16_11 + (-_DissolveSmooth);
    u_xlat16_16 = (-u_xlat16_1) + u_xlat16_11;
    u_xlat16_16 = u_xlat16_6.x * u_xlat16_16;
    u_xlat16_16 = clamp(u_xlat16_16, 0.0, 1.0);
    u_xlat16_2.x = u_xlat16_16 * -2.0 + 3.0;
    u_xlat16_16 = u_xlat16_16 * u_xlat16_16;
    u_xlat16_16 = u_xlat16_16 * u_xlat16_2.x;
    u_xlat16_2 = tex2D(_MainTex, i.vs_TEXCOORD1.xy);
    u_xlat16_3.xyz = (u_xlatb10.x) ? float3(1.0, 1.0, 1.0) : u_xlat16_2.xyz;
    u_xlat16_3.w = (u_xlatb10.x) ? u_xlat16_2.x : u_xlat16_2.w;
    u_xlat16_0 = u_xlat16_3 * i.vs_COLOR0;
    u_xlat16_16 = u_xlat16_16 * u_xlat16_0.w;
    u_xlatb4 = 0.0<_DoubleDissolve;
    u_xlat16_3.x = (u_xlatb4) ? i.vs_TEXCOORD2.y : 0.0;
    u_xlat16_11 = u_xlat16_11 + (-u_xlat16_3.x);
    u_xlatb4 = 0.0<u_xlat16_3.x;
    u_xlat16_1 = (-u_xlat16_1) + u_xlat16_11;
    u_xlat16_1 = u_xlat16_6.x * u_xlat16_1;
    u_xlat16_1 = clamp(u_xlat16_1, 0.0, 1.0);
    u_xlat16_6.x = u_xlat16_1 * -2.0 + 3.0;
    u_xlat16_1 = u_xlat16_1 * u_xlat16_1;
    u_xlat16_1 = (-u_xlat16_6.x) * u_xlat16_1 + u_xlat16_16;
    u_xlat16_1 = clamp(u_xlat16_1, 0.0, 1.0);
    u_xlat16_1 = (u_xlatb4) ? u_xlat16_1 : u_xlat16_16;
    u_xlat16_1 = min(u_xlat16_1, 1.0);
    u_xlat4 = log2(_HdrMultiply);
    u_xlat4 = u_xlat4 * 0.416666657;
    u_xlat4 = exp2(u_xlat4);
    u_xlat4 = u_xlat4 * 1.05499995 + -0.0549999997;
    u_xlat4 = max(u_xlat4, 0.0);
    u_xlat16_6.xyz = u_xlat16_0.xyz * ((float3)(u_xlat4));
    u_xlatb4 = 0.0<_HdrMultiply;
    u_xlat16_6.xyz = (bool(u_xlatb4)) ? u_xlat16_6.xyz : u_xlat16_0.xyz;
    u_xlat16_11 = max(u_xlat16_6.z, u_xlat16_6.y);
    u_xlat16_6.x = max(u_xlat16_11, u_xlat16_6.x);
    u_xlat16_1 = u_xlat16_6.x * u_xlat16_1 + -0.00999999978;
    u_xlatb4 = u_xlat16_1<0.0;
    if(u_xlatb4){discard;}
    result = float4(0.0, 0.0, 0.0, 0.0);
    return result;

}

#elif defined(SHADOWS_CUBE) && !defined(SHADOWS_DEPTH) && !defined(_ALPHABLEND_ON) && !defined(_ALPHAMODULATE_ON) && !defined(_ALPHAPREMULTIPLY_ON) && defined(_ALPHATEST_ON) && defined(_CFXR_ADDITIVE) && !defined(_CFXR_DISSOLVE) && !defined(_CFXR_DITHERED_SHADOWS_ON) && !defined(_CFXR_OVERLAYTEX_1X) && !defined(_CFXR_UV_DISTORTION) && !defined(_FLIPBOOK_BLENDING)
// Original shadow GLES program 137
float _SingleChannel;
float _HdrMultiply;
float _Cutoff;
sampler2D _MainTex;
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
float4 u_xlat16_0;
float u_xlat1;
bool u_xlatb1;
float4 u_xlat16_2;
float u_xlat16_5;
float u_xlat16_11;

    u_xlat16_0 = tex2D(_MainTex, i.vs_TEXCOORD1.xy);
    u_xlatb1 = 0.0<_SingleChannel;
    u_xlat16_2.w = (u_xlatb1) ? u_xlat16_0.x : u_xlat16_0.w;
    u_xlat16_2.xyz = (bool(u_xlatb1)) ? float3(1.0, 1.0, 1.0) : u_xlat16_0.xyz;
    u_xlat16_0 = u_xlat16_2 * i.vs_COLOR0;
    u_xlat16_2.x = u_xlat16_2.w * i.vs_COLOR0.w + (-_Cutoff);
    u_xlatb1 = u_xlat16_2.x<0.0;
    if(u_xlatb1){discard;}
    u_xlat1 = log2(_HdrMultiply);
    u_xlat1 = u_xlat1 * 0.416666657;
    u_xlat1 = exp2(u_xlat1);
    u_xlat1 = u_xlat1 * 1.05499995 + -0.0549999997;
    u_xlat1 = max(u_xlat1, 0.0);
    u_xlat16_2.xyz = u_xlat16_0.xyz * ((float3)(u_xlat1));
    u_xlatb1 = 0.0<_HdrMultiply;
    u_xlat16_2.xyz = (bool(u_xlatb1)) ? u_xlat16_2.xyz : u_xlat16_0.xyz;
    u_xlat16_11 = min(u_xlat16_0.w, 1.0);
    u_xlat16_5 = max(u_xlat16_2.z, u_xlat16_2.y);
    u_xlat16_2.x = max(u_xlat16_5, u_xlat16_2.x);
    u_xlat16_2.x = u_xlat16_2.x * u_xlat16_11 + -0.00999999978;
    u_xlatb1 = u_xlat16_2.x<0.0;
    if(u_xlatb1){discard;}
    result = float4(0.0, 0.0, 0.0, 0.0);
    return result;

}

#elif defined(SHADOWS_CUBE) && !defined(SHADOWS_DEPTH) && defined(_ALPHABLEND_ON) && !defined(_ALPHAMODULATE_ON) && !defined(_ALPHAPREMULTIPLY_ON) && !defined(_ALPHATEST_ON) && !defined(_CFXR_ADDITIVE) && !defined(_CFXR_DISSOLVE) && defined(_CFXR_DITHERED_SHADOWS_ON) && !defined(_CFXR_OVERLAYTEX_1X) && !defined(_CFXR_UV_DISTORTION) && !defined(_FLIPBOOK_BLENDING)
// Original shadow GLES program 139
float _SingleChannel;
float _ShadowStrength;
sampler2D _MainTex;
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
float u_xlat0;
float2 u_xlat16_0;
bool u_xlatb0;
float3 u_xlat1;
float u_xlat16_1;
float u_xlat16_2;
bool u_xlatb6;
float u_xlat16_7;

float4 hlslcc_FragCoord = float4(i.vertex.xyz, 1.0/i.vertex.w);
    u_xlat16_0.xy = tex2D(_MainTex, i.vs_TEXCOORD1.xy).xw;
    u_xlatb6 = 0.0<_SingleChannel;
    u_xlat16_1 = (u_xlatb6) ? u_xlat16_0.x : u_xlat16_0.y;
    u_xlat16_1 = u_xlat16_1 * i.vs_COLOR0.w;
    u_xlat16_1 = min(u_xlat16_1, 1.0);
    u_xlat0 = min(u_xlat16_1, _ShadowStrength);
    u_xlat16_7 = u_xlat0 * 0.9375;
    u_xlat1.z = u_xlat16_7;
    u_xlat1.xy = hlslcc_FragCoord.xy * float2(0.25, 0.25);
    u_xlat16_0.x = tex3D(_DitherMaskLOD, u_xlat1.xyz).w;
    u_xlat16_2 = u_xlat16_0.x + -0.00999999978;
    u_xlatb0 = u_xlat16_2<0.0;
    if(u_xlatb0){discard;}
    result = float4(0.0, 0.0, 0.0, 0.0);
    return result;

}

#elif !defined(SHADOWS_CUBE) && defined(SHADOWS_DEPTH) && defined(_ALPHABLEND_ON) && !defined(_ALPHAMODULATE_ON) && !defined(_ALPHAPREMULTIPLY_ON) && !defined(_ALPHATEST_ON) && !defined(_CFXR_ADDITIVE) && defined(_CFXR_DISSOLVE) && !defined(_CFXR_DITHERED_SHADOWS_ON) && !defined(_CFXR_OVERLAYTEX_1X) && !defined(_CFXR_UV_DISTORTION) && !defined(_FLIPBOOK_BLENDING)
// Original shadow GLES program 148
float _SingleChannel;
float _UseDissolveOffsetUV;
float _InvertDissolveTex;
float _DoubleDissolve;
float2 _DissolveScroll;
float _DissolveSmooth;
float4 _DissolveTex_ST;
sampler2D _MainTex;
sampler2D _DissolveTex;
struct A{float4 in_POSITION0:POSITION0;float4 in_COLOR0:COLOR0;float4 in_TEXCOORD0:TEXCOORD0;float4 in_TEXCOORD1:TEXCOORD1;float3 in_NORMAL0:NORMAL0;};
struct V{float4 vertex:SV_POSITION;float4 vs_COLOR0:TEXCOORD0;float4 vs_TEXCOORD1:TEXCOORD1;float4 vs_TEXCOORD2:TEXCOORD2;};
V vert(A i){V o=(V)0;
float4 u_xlat0;
float4 u_xlat1;
float4 u_xlat2;
float u_xlat6;
float u_xlat9;
bool u_xlatb9;

    o.vs_COLOR0 = i.in_COLOR0;
    o.vs_TEXCOORD1 = i.in_TEXCOORD0.xyxy;
    o.vs_TEXCOORD2 = i.in_TEXCOORD1;
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
float u_xlat16_1;
float u_xlat16_2;
float u_xlat3;
float u_xlat16_4;
float2 u_xlat6;
bool2 u_xlatb6;
float u_xlat16_7;
float u_xlat16_10;

    u_xlat0.xy = _Time.yy * float2(_DissolveScroll.x, _DissolveScroll.y);
    u_xlat0.xy = frac(u_xlat0.xy);
    u_xlat6.xy = i.vs_TEXCOORD1.xy * _DissolveTex_ST.xy + _DissolveTex_ST.zw;
    u_xlat0.xy = u_xlat0.xy + u_xlat6.xy;
    u_xlatb6.xy = lessThan(float4(0.0, 0.0, 0.0, 0.0), float4(_SingleChannel, _UseDissolveOffsetUV, _SingleChannel, _UseDissolveOffsetUV)).xy;
    u_xlat0.xy = (u_xlatb6.y) ? u_xlat0.xy : i.vs_TEXCOORD1.xy;
    u_xlat16_0.x = tex2D(_DissolveTex, u_xlat0.xy).x;
    u_xlat16_1 = u_xlat16_0.x * 2.0 + -1.0;
    u_xlat3 = u_xlat16_1 * i.vs_TEXCOORD2.z + i.vs_TEXCOORD1.x;
    u_xlat16_1 = (u_xlatb6.y) ? u_xlat3 : u_xlat16_0.x;
    u_xlat16_4 = (-u_xlat16_1) + 1.0;
    u_xlatb0 = 0.0>=_InvertDissolveTex;
    u_xlat16_1 = (u_xlatb0) ? u_xlat16_4 : u_xlat16_1;
    u_xlat16_4 = u_xlat16_1 + _DissolveSmooth;
    u_xlat16_1 = u_xlat16_1 + (-_DissolveSmooth);
    u_xlat16_4 = (-u_xlat16_1) + u_xlat16_4;
    u_xlat16_4 = float(1.0) / u_xlat16_4;
    u_xlat16_7 = _DissolveSmooth * 2.0 + 1.0;
    u_xlat16_7 = i.vs_TEXCOORD2.x * u_xlat16_7 + (-_DissolveSmooth);
    u_xlat16_10 = (-u_xlat16_1) + u_xlat16_7;
    u_xlat16_10 = u_xlat16_4 * u_xlat16_10;
    u_xlat16_10 = clamp(u_xlat16_10, 0.0, 1.0);
    u_xlat16_2 = u_xlat16_10 * -2.0 + 3.0;
    u_xlat16_10 = u_xlat16_10 * u_xlat16_10;
    u_xlat16_10 = u_xlat16_10 * u_xlat16_2;
    u_xlat16_0.xy = tex2D(_MainTex, i.vs_TEXCOORD1.xy).xw;
    u_xlat16_2 = (u_xlatb6.x) ? u_xlat16_0.x : u_xlat16_0.y;
    u_xlat16_2 = u_xlat16_2 * i.vs_COLOR0.w;
    u_xlat16_10 = u_xlat16_10 * u_xlat16_2;
    u_xlatb0 = 0.0<_DoubleDissolve;
    u_xlat16_2 = (u_xlatb0) ? i.vs_TEXCOORD2.y : 0.0;
    u_xlat16_7 = u_xlat16_7 + (-u_xlat16_2);
    u_xlatb0 = 0.0<u_xlat16_2;
    u_xlat16_1 = (-u_xlat16_1) + u_xlat16_7;
    u_xlat16_1 = u_xlat16_4 * u_xlat16_1;
    u_xlat16_1 = clamp(u_xlat16_1, 0.0, 1.0);
    u_xlat16_4 = u_xlat16_1 * -2.0 + 3.0;
    u_xlat16_1 = u_xlat16_1 * u_xlat16_1;
    u_xlat16_1 = (-u_xlat16_4) * u_xlat16_1 + u_xlat16_10;
    u_xlat16_1 = clamp(u_xlat16_1, 0.0, 1.0);
    u_xlat16_1 = (u_xlatb0) ? u_xlat16_1 : u_xlat16_10;
    u_xlat16_1 = min(u_xlat16_1, 1.0);
    u_xlat16_1 = u_xlat16_1 + -0.00999999978;
    u_xlatb0 = u_xlat16_1<0.0;
    if(u_xlatb0){discard;}
    result = float4(0.0, 0.0, 0.0, 0.0);
    return result;

}

#elif !defined(SHADOWS_CUBE) && defined(SHADOWS_DEPTH) && defined(_ALPHABLEND_ON) && !defined(_ALPHAMODULATE_ON) && !defined(_ALPHAPREMULTIPLY_ON) && !defined(_ALPHATEST_ON) && !defined(_CFXR_ADDITIVE) && !defined(_CFXR_DISSOLVE) && !defined(_CFXR_DITHERED_SHADOWS_ON) && !defined(_CFXR_OVERLAYTEX_1X) && defined(_CFXR_UV_DISTORTION) && !defined(_FLIPBOOK_BLENDING)
// Original shadow GLES program 149
float _SingleChannel;
float _UseUV2Distortion;
float _UVDistortionAdd;
float4 _DistortScrolling;
float _Distort;
float _FadeAlongU;
sampler2D _DistortTex;
sampler2D _MainTex;
struct A{float4 in_POSITION0:POSITION0;float4 in_COLOR0:COLOR0;float4 in_TEXCOORD0:TEXCOORD0;float4 in_TEXCOORD1:TEXCOORD1;float3 in_NORMAL0:NORMAL0;};
struct V{float4 vertex:SV_POSITION;float4 vs_COLOR0:TEXCOORD0;float4 vs_TEXCOORD1:TEXCOORD1;float4 vs_TEXCOORD2:TEXCOORD2;};
V vert(A i){V o=(V)0;
float4 u_xlat0;
float4 u_xlat1;
float4 u_xlat2;
float u_xlat6;
float u_xlat9;
bool u_xlatb9;

    o.vs_COLOR0 = i.in_COLOR0;
    o.vs_TEXCOORD1 = i.in_TEXCOORD0.xyxy;
    o.vs_TEXCOORD2 = i.in_TEXCOORD1;
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
bool3 u_xlatb1;
float u_xlat16_2;
float2 u_xlat6;

    u_xlat0.xy = _Time.yy * _DistortScrolling.xy;
    u_xlat0.xy = frac(u_xlat0.xy);
    u_xlatb1.xyz = lessThan(float4(0.0, 0.0, 0.0, 0.0), float4(_UseUV2Distortion, _UVDistortionAdd, _SingleChannel, _UseUV2Distortion)).xyz;
    u_xlat6.xy = (u_xlatb1.x) ? i.vs_TEXCOORD2.xy : i.vs_TEXCOORD1.xy;
    u_xlat6.xy = u_xlat6.xy * _DistortScrolling.zw + i.vs_TEXCOORD1.zw;
    u_xlat0.xy = u_xlat0.xy + u_xlat6.xy;
    u_xlat16_0.xy = tex2D(_DistortTex, u_xlat0.xy).xy;
    u_xlat6.xy = u_xlat16_0.xy * float2(2.0, 2.0) + float2(-1.0, -1.0);
    u_xlat0.xy = u_xlat16_0.xy + (-i.vs_TEXCOORD1.xy);
    u_xlat0.xy = ((float2)(_Distort)) * u_xlat0.xy + i.vs_TEXCOORD1.xy;
    u_xlat6.xy = u_xlat6.xy * ((float2)(_Distort)) + i.vs_TEXCOORD1.xy;
    u_xlat0.xy = (u_xlatb1.y) ? u_xlat6.xy : u_xlat0.xy;
    u_xlat6.xy = u_xlat0.xy + (-i.vs_TEXCOORD1.xy);
    u_xlat1 = i.vs_TEXCOORD1.y * 0.5;
    u_xlat6.xy = ((float2)(u_xlat1)) * u_xlat6.xy + i.vs_TEXCOORD1.xy;
    u_xlatb1.x = 0.0<_FadeAlongU;
    u_xlat0.xy = (u_xlatb1.x) ? u_xlat6.xy : u_xlat0.xy;
    u_xlat16_0.xy = tex2D(_MainTex, u_xlat0.xy).xw;
    u_xlat16_2 = (u_xlatb1.z) ? u_xlat16_0.x : u_xlat16_0.y;
    u_xlat16_2 = u_xlat16_2 * i.vs_COLOR0.w;
    u_xlat16_2 = min(u_xlat16_2, 1.0);
    u_xlat16_2 = u_xlat16_2 + -0.00999999978;
    u_xlatb0 = u_xlat16_2<0.0;
    if(u_xlatb0){discard;}
    result = float4(0.0, 0.0, 0.0, 0.0);
    return result;

}

#elif !defined(SHADOWS_CUBE) && defined(SHADOWS_DEPTH) && defined(_ALPHABLEND_ON) && !defined(_ALPHAMODULATE_ON) && !defined(_ALPHAPREMULTIPLY_ON) && !defined(_ALPHATEST_ON) && !defined(_CFXR_ADDITIVE) && !defined(_CFXR_DISSOLVE) && !defined(_CFXR_DITHERED_SHADOWS_ON) && !defined(_CFXR_OVERLAYTEX_1X) && !defined(_CFXR_UV_DISTORTION) && defined(_FLIPBOOK_BLENDING)
// Original shadow GLES program 152
float _SingleChannel;
sampler2D _MainTex;
struct A{float4 in_POSITION0:POSITION0;float4 in_COLOR0:COLOR0;float4 in_TEXCOORD0:TEXCOORD0;float4 in_TEXCOORD1:TEXCOORD1;float3 in_NORMAL0:NORMAL0;};
struct V{float4 vertex:SV_POSITION;float4 vs_COLOR0:TEXCOORD0;float4 vs_TEXCOORD1:TEXCOORD1;float4 vs_TEXCOORD2:TEXCOORD2;};
V vert(A i){V o=(V)0;
float4 u_xlat0;
float4 u_xlat1;
float4 u_xlat2;
float u_xlat6;
float u_xlat9;
bool u_xlatb9;

    o.vs_COLOR0 = i.in_COLOR0;
    o.vs_TEXCOORD1 = i.in_TEXCOORD0.xyxy;
    o.vs_TEXCOORD2 = i.in_TEXCOORD1;
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
float2 u_xlat16_0;
bool u_xlatb0;
float u_xlat16_1;
float u_xlat16_3;
bool u_xlatb4;

    u_xlat16_0.xy = tex2D(_MainTex, i.vs_TEXCOORD1.zw).xw;
    u_xlatb4 = 0.0<_SingleChannel;
    u_xlat16_1 = (u_xlatb4) ? u_xlat16_0.x : u_xlat16_0.y;
    u_xlat16_0.xy = tex2D(_MainTex, i.vs_TEXCOORD1.xy).xw;
    u_xlat16_3 = (u_xlatb4) ? u_xlat16_0.x : u_xlat16_0.y;
    u_xlat0 = (-u_xlat16_3) + u_xlat16_1;
    u_xlat0 = i.vs_TEXCOORD2.y * u_xlat0 + u_xlat16_3;
    u_xlat16_1 = u_xlat0 * i.vs_COLOR0.w;
    u_xlat16_1 = min(u_xlat16_1, 1.0);
    u_xlat16_1 = u_xlat16_1 + -0.00999999978;
    u_xlatb0 = u_xlat16_1<0.0;
    if(u_xlatb0){discard;}
    result = float4(0.0, 0.0, 0.0, 0.0);
    return result;

}

#elif !defined(SHADOWS_CUBE) && defined(SHADOWS_DEPTH) && defined(_ALPHABLEND_ON) && !defined(_ALPHAMODULATE_ON) && !defined(_ALPHAPREMULTIPLY_ON) && defined(_ALPHATEST_ON) && !defined(_CFXR_ADDITIVE) && !defined(_CFXR_DISSOLVE) && !defined(_CFXR_DITHERED_SHADOWS_ON) && !defined(_CFXR_OVERLAYTEX_1X) && !defined(_CFXR_UV_DISTORTION) && !defined(_FLIPBOOK_BLENDING)
// Original shadow GLES program 153
float _SingleChannel;
float _Cutoff;
sampler2D _MainTex;
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
float2 u_xlat16_0;
bool u_xlatb0;
float u_xlat16_1;
float u_xlat16_3;
bool u_xlatb4;

    u_xlat16_0.xy = tex2D(_MainTex, i.vs_TEXCOORD1.xy).xw;
    u_xlatb4 = 0.0<_SingleChannel;
    u_xlat16_1 = (u_xlatb4) ? u_xlat16_0.x : u_xlat16_0.y;
    u_xlat16_3 = u_xlat16_1 * i.vs_COLOR0.w + (-_Cutoff);
    u_xlat16_1 = u_xlat16_1 * i.vs_COLOR0.w;
    u_xlat16_1 = min(u_xlat16_1, 1.0);
    u_xlat16_1 = u_xlat16_1 + -0.00999999978;
    u_xlatb0 = u_xlat16_1<0.0;
    if(u_xlatb0){discard;}
    u_xlatb0 = u_xlat16_3<0.0;
    if(u_xlatb0){discard;}
    result = float4(0.0, 0.0, 0.0, 0.0);
    return result;

}

#elif !defined(SHADOWS_CUBE) && defined(SHADOWS_DEPTH) && !defined(_ALPHABLEND_ON) && defined(_ALPHAMODULATE_ON) && !defined(_ALPHAPREMULTIPLY_ON) && !defined(_ALPHATEST_ON) && !defined(_CFXR_ADDITIVE) && !defined(_CFXR_DISSOLVE) && !defined(_CFXR_DITHERED_SHADOWS_ON) && !defined(_CFXR_OVERLAYTEX_1X) && defined(_CFXR_UV_DISTORTION) && !defined(_FLIPBOOK_BLENDING)
// Original shadow GLES program 156
float _SingleChannel;
float _UseUV2Distortion;
float _UVDistortionAdd;
float4 _DistortScrolling;
float _Distort;
float _FadeAlongU;
sampler2D _DistortTex;
sampler2D _MainTex;
struct A{float4 in_POSITION0:POSITION0;float4 in_COLOR0:COLOR0;float4 in_TEXCOORD0:TEXCOORD0;float4 in_TEXCOORD1:TEXCOORD1;float3 in_NORMAL0:NORMAL0;};
struct V{float4 vertex:SV_POSITION;float4 vs_COLOR0:TEXCOORD0;float4 vs_TEXCOORD1:TEXCOORD1;float4 vs_TEXCOORD2:TEXCOORD2;};
V vert(A i){V o=(V)0;
float4 u_xlat0;
float4 u_xlat1;
float4 u_xlat2;
float u_xlat6;
float u_xlat9;
bool u_xlatb9;

    o.vs_COLOR0 = i.in_COLOR0;
    o.vs_TEXCOORD1 = i.in_TEXCOORD0.xyxy;
    o.vs_TEXCOORD2 = i.in_TEXCOORD1;
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
bool3 u_xlatb1;
float u_xlat16_2;
float2 u_xlat6;

    u_xlat0.xy = _Time.yy * _DistortScrolling.xy;
    u_xlat0.xy = frac(u_xlat0.xy);
    u_xlatb1.xyz = lessThan(float4(0.0, 0.0, 0.0, 0.0), float4(_UseUV2Distortion, _UVDistortionAdd, _SingleChannel, _UseUV2Distortion)).xyz;
    u_xlat6.xy = (u_xlatb1.x) ? i.vs_TEXCOORD2.xy : i.vs_TEXCOORD1.xy;
    u_xlat6.xy = u_xlat6.xy * _DistortScrolling.zw + i.vs_TEXCOORD1.zw;
    u_xlat0.xy = u_xlat0.xy + u_xlat6.xy;
    u_xlat16_0.xy = tex2D(_DistortTex, u_xlat0.xy).xy;
    u_xlat6.xy = u_xlat16_0.xy * float2(2.0, 2.0) + float2(-1.0, -1.0);
    u_xlat0.xy = u_xlat16_0.xy + (-i.vs_TEXCOORD1.xy);
    u_xlat0.xy = ((float2)(_Distort)) * u_xlat0.xy + i.vs_TEXCOORD1.xy;
    u_xlat6.xy = u_xlat6.xy * ((float2)(_Distort)) + i.vs_TEXCOORD1.xy;
    u_xlat0.xy = (u_xlatb1.y) ? u_xlat6.xy : u_xlat0.xy;
    u_xlat6.xy = u_xlat0.xy + (-i.vs_TEXCOORD1.xy);
    u_xlat1 = i.vs_TEXCOORD1.y * 0.5;
    u_xlat6.xy = ((float2)(u_xlat1)) * u_xlat6.xy + i.vs_TEXCOORD1.xy;
    u_xlatb1.x = 0.0<_FadeAlongU;
    u_xlat0.xy = (u_xlatb1.x) ? u_xlat6.xy : u_xlat0.xy;
    u_xlat16_0.xy = tex2D(_MainTex, u_xlat0.xy).xw;
    u_xlat16_2 = (u_xlatb1.z) ? u_xlat16_0.x : u_xlat16_0.y;
    u_xlat16_2 = u_xlat16_2 * i.vs_COLOR0.w;
    u_xlat16_2 = min(u_xlat16_2, 1.0);
    u_xlat16_2 = u_xlat16_2 + -0.00999999978;
    u_xlatb0 = u_xlat16_2<0.0;
    if(u_xlatb0){discard;}
    result = float4(0.0, 0.0, 0.0, 0.0);
    return result;

}

#elif !defined(SHADOWS_CUBE) && defined(SHADOWS_DEPTH) && !defined(_ALPHABLEND_ON) && !defined(_ALPHAMODULATE_ON) && !defined(_ALPHAPREMULTIPLY_ON) && !defined(_ALPHATEST_ON) && defined(_CFXR_ADDITIVE) && defined(_CFXR_DISSOLVE) && !defined(_CFXR_DITHERED_SHADOWS_ON) && !defined(_CFXR_OVERLAYTEX_1X) && !defined(_CFXR_UV_DISTORTION) && !defined(_FLIPBOOK_BLENDING)
// Original shadow GLES program 158
float _SingleChannel;
float _UseDissolveOffsetUV;
float _InvertDissolveTex;
float _DoubleDissolve;
float2 _DissolveScroll;
float _DissolveSmooth;
float _HdrMultiply;
float4 _DissolveTex_ST;
sampler2D _MainTex;
sampler2D _DissolveTex;
struct A{float4 in_POSITION0:POSITION0;float4 in_COLOR0:COLOR0;float4 in_TEXCOORD0:TEXCOORD0;float4 in_TEXCOORD1:TEXCOORD1;float3 in_NORMAL0:NORMAL0;};
struct V{float4 vertex:SV_POSITION;float4 vs_COLOR0:TEXCOORD0;float4 vs_TEXCOORD1:TEXCOORD1;float4 vs_TEXCOORD2:TEXCOORD2;};
V vert(A i){V o=(V)0;
float4 u_xlat0;
float4 u_xlat1;
float4 u_xlat2;
float u_xlat6;
float u_xlat9;
bool u_xlatb9;

    o.vs_COLOR0 = i.in_COLOR0;
    o.vs_TEXCOORD1 = i.in_TEXCOORD0.xyxy;
    o.vs_TEXCOORD2 = i.in_TEXCOORD1;
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
float4 u_xlat16_0;
bool u_xlatb0;
float u_xlat16_1;
float4 u_xlat16_2;
float4 u_xlat16_3;
float u_xlat4;
bool u_xlatb4;
float u_xlat5;
float3 u_xlat16_6;
float2 u_xlat10;
bool2 u_xlatb10;
float u_xlat16_11;
float u_xlat16_16;

    u_xlat0.xy = _Time.yy * float2(_DissolveScroll.x, _DissolveScroll.y);
    u_xlat0.xy = frac(u_xlat0.xy);
    u_xlat10.xy = i.vs_TEXCOORD1.xy * _DissolveTex_ST.xy + _DissolveTex_ST.zw;
    u_xlat0.xy = u_xlat0.xy + u_xlat10.xy;
    u_xlatb10.xy = lessThan(float4(0.0, 0.0, 0.0, 0.0), float4(_SingleChannel, _UseDissolveOffsetUV, _SingleChannel, _UseDissolveOffsetUV)).xy;
    u_xlat0.xy = (u_xlatb10.y) ? u_xlat0.xy : i.vs_TEXCOORD1.xy;
    u_xlat16_0.x = tex2D(_DissolveTex, u_xlat0.xy).x;
    u_xlat16_1 = u_xlat16_0.x * 2.0 + -1.0;
    u_xlat5 = u_xlat16_1 * i.vs_TEXCOORD2.z + i.vs_TEXCOORD1.x;
    u_xlat16_1 = (u_xlatb10.y) ? u_xlat5 : u_xlat16_0.x;
    u_xlat16_6.x = (-u_xlat16_1) + 1.0;
    u_xlatb0 = 0.0>=_InvertDissolveTex;
    u_xlat16_1 = (u_xlatb0) ? u_xlat16_6.x : u_xlat16_1;
    u_xlat16_6.x = u_xlat16_1 + _DissolveSmooth;
    u_xlat16_1 = u_xlat16_1 + (-_DissolveSmooth);
    u_xlat16_6.x = (-u_xlat16_1) + u_xlat16_6.x;
    u_xlat16_6.x = float(1.0) / u_xlat16_6.x;
    u_xlat16_11 = _DissolveSmooth * 2.0 + 1.0;
    u_xlat16_11 = i.vs_TEXCOORD2.x * u_xlat16_11 + (-_DissolveSmooth);
    u_xlat16_16 = (-u_xlat16_1) + u_xlat16_11;
    u_xlat16_16 = u_xlat16_6.x * u_xlat16_16;
    u_xlat16_16 = clamp(u_xlat16_16, 0.0, 1.0);
    u_xlat16_2.x = u_xlat16_16 * -2.0 + 3.0;
    u_xlat16_16 = u_xlat16_16 * u_xlat16_16;
    u_xlat16_16 = u_xlat16_16 * u_xlat16_2.x;
    u_xlat16_2 = tex2D(_MainTex, i.vs_TEXCOORD1.xy);
    u_xlat16_3.xyz = (u_xlatb10.x) ? float3(1.0, 1.0, 1.0) : u_xlat16_2.xyz;
    u_xlat16_3.w = (u_xlatb10.x) ? u_xlat16_2.x : u_xlat16_2.w;
    u_xlat16_0 = u_xlat16_3 * i.vs_COLOR0;
    u_xlat16_16 = u_xlat16_16 * u_xlat16_0.w;
    u_xlatb4 = 0.0<_DoubleDissolve;
    u_xlat16_3.x = (u_xlatb4) ? i.vs_TEXCOORD2.y : 0.0;
    u_xlat16_11 = u_xlat16_11 + (-u_xlat16_3.x);
    u_xlatb4 = 0.0<u_xlat16_3.x;
    u_xlat16_1 = (-u_xlat16_1) + u_xlat16_11;
    u_xlat16_1 = u_xlat16_6.x * u_xlat16_1;
    u_xlat16_1 = clamp(u_xlat16_1, 0.0, 1.0);
    u_xlat16_6.x = u_xlat16_1 * -2.0 + 3.0;
    u_xlat16_1 = u_xlat16_1 * u_xlat16_1;
    u_xlat16_1 = (-u_xlat16_6.x) * u_xlat16_1 + u_xlat16_16;
    u_xlat16_1 = clamp(u_xlat16_1, 0.0, 1.0);
    u_xlat16_1 = (u_xlatb4) ? u_xlat16_1 : u_xlat16_16;
    u_xlat16_1 = min(u_xlat16_1, 1.0);
    u_xlat4 = log2(_HdrMultiply);
    u_xlat4 = u_xlat4 * 0.416666657;
    u_xlat4 = exp2(u_xlat4);
    u_xlat4 = u_xlat4 * 1.05499995 + -0.0549999997;
    u_xlat4 = max(u_xlat4, 0.0);
    u_xlat16_6.xyz = u_xlat16_0.xyz * ((float3)(u_xlat4));
    u_xlatb4 = 0.0<_HdrMultiply;
    u_xlat16_6.xyz = (bool(u_xlatb4)) ? u_xlat16_6.xyz : u_xlat16_0.xyz;
    u_xlat16_11 = max(u_xlat16_6.z, u_xlat16_6.y);
    u_xlat16_6.x = max(u_xlat16_11, u_xlat16_6.x);
    u_xlat16_1 = u_xlat16_6.x * u_xlat16_1 + -0.00999999978;
    u_xlatb4 = u_xlat16_1<0.0;
    if(u_xlatb4){discard;}
    result = float4(0.0, 0.0, 0.0, 0.0);
    return result;

}

#elif !defined(SHADOWS_CUBE) && defined(SHADOWS_DEPTH) && !defined(_ALPHABLEND_ON) && !defined(_ALPHAMODULATE_ON) && !defined(_ALPHAPREMULTIPLY_ON) && defined(_ALPHATEST_ON) && defined(_CFXR_ADDITIVE) && !defined(_CFXR_DISSOLVE) && !defined(_CFXR_DITHERED_SHADOWS_ON) && !defined(_CFXR_OVERLAYTEX_1X) && !defined(_CFXR_UV_DISTORTION) && !defined(_FLIPBOOK_BLENDING)
// Original shadow GLES program 160
float _SingleChannel;
float _HdrMultiply;
float _Cutoff;
sampler2D _MainTex;
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
float4 u_xlat16_0;
float u_xlat1;
bool u_xlatb1;
float4 u_xlat16_2;
float u_xlat16_5;
float u_xlat16_11;

    u_xlat16_0 = tex2D(_MainTex, i.vs_TEXCOORD1.xy);
    u_xlatb1 = 0.0<_SingleChannel;
    u_xlat16_2.w = (u_xlatb1) ? u_xlat16_0.x : u_xlat16_0.w;
    u_xlat16_2.xyz = (bool(u_xlatb1)) ? float3(1.0, 1.0, 1.0) : u_xlat16_0.xyz;
    u_xlat16_0 = u_xlat16_2 * i.vs_COLOR0;
    u_xlat16_2.x = u_xlat16_2.w * i.vs_COLOR0.w + (-_Cutoff);
    u_xlatb1 = u_xlat16_2.x<0.0;
    if(u_xlatb1){discard;}
    u_xlat1 = log2(_HdrMultiply);
    u_xlat1 = u_xlat1 * 0.416666657;
    u_xlat1 = exp2(u_xlat1);
    u_xlat1 = u_xlat1 * 1.05499995 + -0.0549999997;
    u_xlat1 = max(u_xlat1, 0.0);
    u_xlat16_2.xyz = u_xlat16_0.xyz * ((float3)(u_xlat1));
    u_xlatb1 = 0.0<_HdrMultiply;
    u_xlat16_2.xyz = (bool(u_xlatb1)) ? u_xlat16_2.xyz : u_xlat16_0.xyz;
    u_xlat16_11 = min(u_xlat16_0.w, 1.0);
    u_xlat16_5 = max(u_xlat16_2.z, u_xlat16_2.y);
    u_xlat16_2.x = max(u_xlat16_5, u_xlat16_2.x);
    u_xlat16_2.x = u_xlat16_2.x * u_xlat16_11 + -0.00999999978;
    u_xlatb1 = u_xlat16_2.x<0.0;
    if(u_xlatb1){discard;}
    result = float4(0.0, 0.0, 0.0, 0.0);
    return result;

}

#elif !defined(SHADOWS_CUBE) && defined(SHADOWS_DEPTH) && defined(_ALPHABLEND_ON) && !defined(_ALPHAMODULATE_ON) && !defined(_ALPHAPREMULTIPLY_ON) && !defined(_ALPHATEST_ON) && !defined(_CFXR_ADDITIVE) && !defined(_CFXR_DISSOLVE) && defined(_CFXR_DITHERED_SHADOWS_ON) && !defined(_CFXR_OVERLAYTEX_1X) && !defined(_CFXR_UV_DISTORTION) && !defined(_FLIPBOOK_BLENDING)
// Original shadow GLES program 162
float _SingleChannel;
float _ShadowStrength;
sampler2D _MainTex;
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
float u_xlat0;
float2 u_xlat16_0;
bool u_xlatb0;
float3 u_xlat1;
float u_xlat16_1;
float u_xlat16_2;
bool u_xlatb6;
float u_xlat16_7;

float4 hlslcc_FragCoord = float4(i.vertex.xyz, 1.0/i.vertex.w);
    u_xlat16_0.xy = tex2D(_MainTex, i.vs_TEXCOORD1.xy).xw;
    u_xlatb6 = 0.0<_SingleChannel;
    u_xlat16_1 = (u_xlatb6) ? u_xlat16_0.x : u_xlat16_0.y;
    u_xlat16_1 = u_xlat16_1 * i.vs_COLOR0.w;
    u_xlat16_1 = min(u_xlat16_1, 1.0);
    u_xlat0 = min(u_xlat16_1, _ShadowStrength);
    u_xlat16_7 = u_xlat0 * 0.9375;
    u_xlat1.z = u_xlat16_7;
    u_xlat1.xy = hlslcc_FragCoord.xy * float2(0.25, 0.25);
    u_xlat16_0.x = tex3D(_DitherMaskLOD, u_xlat1.xyz).w;
    u_xlat16_2 = u_xlat16_0.x + -0.00999999978;
    u_xlatb0 = u_xlat16_2<0.0;
    if(u_xlatb0){discard;}
    result = float4(0.0, 0.0, 0.0, 0.0);
    return result;

}

#elif defined(SHADOWS_CUBE) && !defined(SHADOWS_DEPTH) && defined(_ALPHABLEND_ON) && !defined(_ALPHAMODULATE_ON) && !defined(_ALPHAPREMULTIPLY_ON) && !defined(_ALPHATEST_ON) && !defined(_CFXR_ADDITIVE) && !defined(_CFXR_DISSOLVE) && !defined(_CFXR_DITHERED_SHADOWS_ON) && !defined(_CFXR_OVERLAYTEX_1X) && !defined(_CFXR_UV_DISTORTION) && !defined(_FLIPBOOK_BLENDING)
// Original shadow GLES program 124
float _SingleChannel;
sampler2D _MainTex;
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
float2 u_xlat16_0;
bool u_xlatb0;
float u_xlat16_1;
bool u_xlatb4;

    u_xlat16_0.xy = tex2D(_MainTex, i.vs_TEXCOORD1.xy).xw;
    u_xlatb4 = 0.0<_SingleChannel;
    u_xlat16_1 = (u_xlatb4) ? u_xlat16_0.x : u_xlat16_0.y;
    u_xlat16_1 = u_xlat16_1 * i.vs_COLOR0.w;
    u_xlat16_1 = min(u_xlat16_1, 1.0);
    u_xlat16_1 = u_xlat16_1 + -0.00999999978;
    u_xlatb0 = u_xlat16_1<0.0;
    if(u_xlatb0){discard;}
    result = float4(0.0, 0.0, 0.0, 0.0);
    return result;

}

#elif defined(SHADOWS_CUBE) && !defined(SHADOWS_DEPTH) && !defined(_ALPHABLEND_ON) && !defined(_ALPHAMODULATE_ON) && defined(_ALPHAPREMULTIPLY_ON) && !defined(_ALPHATEST_ON) && !defined(_CFXR_ADDITIVE) && !defined(_CFXR_DISSOLVE) && !defined(_CFXR_DITHERED_SHADOWS_ON) && !defined(_CFXR_OVERLAYTEX_1X) && !defined(_CFXR_UV_DISTORTION) && !defined(_FLIPBOOK_BLENDING)
// Original shadow GLES program 132
float _SingleChannel;
sampler2D _MainTex;
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
float2 u_xlat16_0;
bool u_xlatb0;
float u_xlat16_1;
bool u_xlatb4;

    u_xlat16_0.xy = tex2D(_MainTex, i.vs_TEXCOORD1.xy).xw;
    u_xlatb4 = 0.0<_SingleChannel;
    u_xlat16_1 = (u_xlatb4) ? u_xlat16_0.x : u_xlat16_0.y;
    u_xlat16_1 = u_xlat16_1 * i.vs_COLOR0.w;
    u_xlat16_1 = min(u_xlat16_1, 1.0);
    u_xlat16_1 = u_xlat16_1 + -0.00999999978;
    u_xlatb0 = u_xlat16_1<0.0;
    if(u_xlatb0){discard;}
    result = float4(0.0, 0.0, 0.0, 0.0);
    return result;

}

#elif defined(SHADOWS_CUBE) && !defined(SHADOWS_DEPTH) && !defined(_ALPHABLEND_ON) && !defined(_ALPHAMODULATE_ON) && !defined(_ALPHAPREMULTIPLY_ON) && !defined(_ALPHATEST_ON) && defined(_CFXR_ADDITIVE) && !defined(_CFXR_DISSOLVE) && !defined(_CFXR_DITHERED_SHADOWS_ON) && !defined(_CFXR_OVERLAYTEX_1X) && !defined(_CFXR_UV_DISTORTION) && !defined(_FLIPBOOK_BLENDING)
// Original shadow GLES program 134
float _SingleChannel;
float _HdrMultiply;
sampler2D _MainTex;
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
float u_xlat0;
bool u_xlatb0;
float4 u_xlat16_1;
float4 u_xlat16_2;
bool u_xlatb3;
float u_xlat16_5;
float u_xlat16_11;

    u_xlat0 = log2(_HdrMultiply);
    u_xlat0 = u_xlat0 * 0.416666657;
    u_xlat0 = exp2(u_xlat0);
    u_xlat0 = u_xlat0 * 1.05499995 + -0.0549999997;
    u_xlat0 = max(u_xlat0, 0.0);
    u_xlat16_1 = tex2D(_MainTex, i.vs_TEXCOORD1.xy);
    u_xlatb3 = 0.0<_SingleChannel;
    u_xlat16_2.xyz = (bool(u_xlatb3)) ? float3(1.0, 1.0, 1.0) : u_xlat16_1.xyz;
    u_xlat16_2.w = (u_xlatb3) ? u_xlat16_1.x : u_xlat16_1.w;
    u_xlat16_1 = u_xlat16_2 * i.vs_COLOR0;
    u_xlat16_2.xyz = ((float3)(u_xlat0)) * u_xlat16_1.xyz;
    u_xlatb0 = 0.0<_HdrMultiply;
    u_xlat16_2.xyz = (bool(u_xlatb0)) ? u_xlat16_2.xyz : u_xlat16_1.xyz;
    u_xlat16_11 = min(u_xlat16_1.w, 1.0);
    u_xlat16_5 = max(u_xlat16_2.z, u_xlat16_2.y);
    u_xlat16_2.x = max(u_xlat16_5, u_xlat16_2.x);
    u_xlat16_2.x = u_xlat16_2.x * u_xlat16_11 + -0.00999999978;
    u_xlatb0 = u_xlat16_2.x<0.0;
    if(u_xlatb0){discard;}
    result = float4(0.0, 0.0, 0.0, 0.0);
    return result;

}

#elif !defined(SHADOWS_CUBE) && defined(SHADOWS_DEPTH) && defined(_ALPHABLEND_ON) && !defined(_ALPHAMODULATE_ON) && !defined(_ALPHAPREMULTIPLY_ON) && !defined(_ALPHATEST_ON) && !defined(_CFXR_ADDITIVE) && !defined(_CFXR_DISSOLVE) && !defined(_CFXR_DITHERED_SHADOWS_ON) && !defined(_CFXR_OVERLAYTEX_1X) && !defined(_CFXR_UV_DISTORTION) && !defined(_FLIPBOOK_BLENDING)
// Original shadow GLES program 147
float _SingleChannel;
sampler2D _MainTex;
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
float2 u_xlat16_0;
bool u_xlatb0;
float u_xlat16_1;
bool u_xlatb4;

    u_xlat16_0.xy = tex2D(_MainTex, i.vs_TEXCOORD1.xy).xw;
    u_xlatb4 = 0.0<_SingleChannel;
    u_xlat16_1 = (u_xlatb4) ? u_xlat16_0.x : u_xlat16_0.y;
    u_xlat16_1 = u_xlat16_1 * i.vs_COLOR0.w;
    u_xlat16_1 = min(u_xlat16_1, 1.0);
    u_xlat16_1 = u_xlat16_1 + -0.00999999978;
    u_xlatb0 = u_xlat16_1<0.0;
    if(u_xlatb0){discard;}
    result = float4(0.0, 0.0, 0.0, 0.0);
    return result;

}

#elif !defined(SHADOWS_CUBE) && defined(SHADOWS_DEPTH) && !defined(_ALPHABLEND_ON) && !defined(_ALPHAMODULATE_ON) && defined(_ALPHAPREMULTIPLY_ON) && !defined(_ALPHATEST_ON) && !defined(_CFXR_ADDITIVE) && !defined(_CFXR_DISSOLVE) && !defined(_CFXR_DITHERED_SHADOWS_ON) && !defined(_CFXR_OVERLAYTEX_1X) && !defined(_CFXR_UV_DISTORTION) && !defined(_FLIPBOOK_BLENDING)
// Original shadow GLES program 155
float _SingleChannel;
sampler2D _MainTex;
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
float2 u_xlat16_0;
bool u_xlatb0;
float u_xlat16_1;
bool u_xlatb4;

    u_xlat16_0.xy = tex2D(_MainTex, i.vs_TEXCOORD1.xy).xw;
    u_xlatb4 = 0.0<_SingleChannel;
    u_xlat16_1 = (u_xlatb4) ? u_xlat16_0.x : u_xlat16_0.y;
    u_xlat16_1 = u_xlat16_1 * i.vs_COLOR0.w;
    u_xlat16_1 = min(u_xlat16_1, 1.0);
    u_xlat16_1 = u_xlat16_1 + -0.00999999978;
    u_xlatb0 = u_xlat16_1<0.0;
    if(u_xlatb0){discard;}
    result = float4(0.0, 0.0, 0.0, 0.0);
    return result;

}

#elif !defined(SHADOWS_CUBE) && defined(SHADOWS_DEPTH) && !defined(_ALPHABLEND_ON) && !defined(_ALPHAMODULATE_ON) && !defined(_ALPHAPREMULTIPLY_ON) && !defined(_ALPHATEST_ON) && defined(_CFXR_ADDITIVE) && !defined(_CFXR_DISSOLVE) && !defined(_CFXR_DITHERED_SHADOWS_ON) && !defined(_CFXR_OVERLAYTEX_1X) && !defined(_CFXR_UV_DISTORTION) && !defined(_FLIPBOOK_BLENDING)
// Original shadow GLES program 157
float _SingleChannel;
float _HdrMultiply;
sampler2D _MainTex;
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
float u_xlat0;
bool u_xlatb0;
float4 u_xlat16_1;
float4 u_xlat16_2;
bool u_xlatb3;
float u_xlat16_5;
float u_xlat16_11;

    u_xlat0 = log2(_HdrMultiply);
    u_xlat0 = u_xlat0 * 0.416666657;
    u_xlat0 = exp2(u_xlat0);
    u_xlat0 = u_xlat0 * 1.05499995 + -0.0549999997;
    u_xlat0 = max(u_xlat0, 0.0);
    u_xlat16_1 = tex2D(_MainTex, i.vs_TEXCOORD1.xy);
    u_xlatb3 = 0.0<_SingleChannel;
    u_xlat16_2.xyz = (bool(u_xlatb3)) ? float3(1.0, 1.0, 1.0) : u_xlat16_1.xyz;
    u_xlat16_2.w = (u_xlatb3) ? u_xlat16_1.x : u_xlat16_1.w;
    u_xlat16_1 = u_xlat16_2 * i.vs_COLOR0;
    u_xlat16_2.xyz = ((float3)(u_xlat0)) * u_xlat16_1.xyz;
    u_xlatb0 = 0.0<_HdrMultiply;
    u_xlat16_2.xyz = (bool(u_xlatb0)) ? u_xlat16_2.xyz : u_xlat16_1.xyz;
    u_xlat16_11 = min(u_xlat16_1.w, 1.0);
    u_xlat16_5 = max(u_xlat16_2.z, u_xlat16_2.y);
    u_xlat16_2.x = max(u_xlat16_5, u_xlat16_2.x);
    u_xlat16_2.x = u_xlat16_2.x * u_xlat16_11 + -0.00999999978;
    u_xlatb0 = u_xlat16_2.x<0.0;
    if(u_xlatb0){discard;}
    result = float4(0.0, 0.0, 0.0, 0.0);
    return result;

}

#elif !defined(SHADOWS_CUBE) && defined(SHADOWS_DEPTH) && !defined(_ALPHABLEND_ON) && !defined(_ALPHAMODULATE_ON) && !defined(_ALPHAPREMULTIPLY_ON) && !defined(_ALPHATEST_ON) && !defined(_CFXR_ADDITIVE) && !defined(_CFXR_DISSOLVE) && !defined(_CFXR_DITHERED_SHADOWS_ON) && !defined(_CFXR_OVERLAYTEX_1X) && !defined(_CFXR_UV_DISTORTION) && !defined(_FLIPBOOK_BLENDING)
// Original shadow GLES program 123
float _SingleChannel;
sampler2D _MainTex;
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
float2 u_xlat16_0;
bool u_xlatb0;
float u_xlat16_1;
bool u_xlatb4;

    u_xlat16_0.xy = tex2D(_MainTex, i.vs_TEXCOORD1.xy).xw;
    u_xlatb4 = 0.0<_SingleChannel;
    u_xlat16_1 = (u_xlatb4) ? u_xlat16_0.x : u_xlat16_0.y;
    u_xlat16_1 = u_xlat16_1 * i.vs_COLOR0.w;
    u_xlat16_1 = min(u_xlat16_1, 1.0);
    u_xlat16_1 = u_xlat16_1 + -0.00999999978;
    u_xlatb0 = u_xlat16_1<0.0;
    if(u_xlatb0){discard;}
    result = float4(0.0, 0.0, 0.0, 0.0);
    return result;

}

#elif defined(SHADOWS_CUBE) && !defined(SHADOWS_DEPTH) && !defined(_ALPHABLEND_ON) && !defined(_ALPHAMODULATE_ON) && !defined(_ALPHAPREMULTIPLY_ON) && !defined(_ALPHATEST_ON) && !defined(_CFXR_ADDITIVE) && !defined(_CFXR_DISSOLVE) && !defined(_CFXR_DITHERED_SHADOWS_ON) && !defined(_CFXR_OVERLAYTEX_1X) && !defined(_CFXR_UV_DISTORTION) && !defined(_FLIPBOOK_BLENDING)
// Original shadow GLES program 146
float _SingleChannel;
sampler2D _MainTex;
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
float2 u_xlat16_0;
bool u_xlatb0;
float u_xlat16_1;
bool u_xlatb4;

    u_xlat16_0.xy = tex2D(_MainTex, i.vs_TEXCOORD1.xy).xw;
    u_xlatb4 = 0.0<_SingleChannel;
    u_xlat16_1 = (u_xlatb4) ? u_xlat16_0.x : u_xlat16_0.y;
    u_xlat16_1 = u_xlat16_1 * i.vs_COLOR0.w;
    u_xlat16_1 = min(u_xlat16_1, 1.0);
    u_xlat16_1 = u_xlat16_1 + -0.00999999978;
    u_xlatb0 = u_xlat16_1<0.0;
    if(u_xlatb0){discard;}
    result = float4(0.0, 0.0, 0.0, 0.0);
    return result;

}

#else
float _SingleChannel;
sampler2D _MainTex;
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
float2 u_xlat16_0;
bool u_xlatb0;
float u_xlat16_1;
bool u_xlatb4;

    u_xlat16_0.xy = tex2D(_MainTex, i.vs_TEXCOORD1.xy).xw;
    u_xlatb4 = 0.0<_SingleChannel;
    u_xlat16_1 = (u_xlatb4) ? u_xlat16_0.x : u_xlat16_0.y;
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
