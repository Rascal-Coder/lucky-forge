Shader "UI/Soft Additive"
{
 Properties
 {
  [PerRendererData] _MainTex ("Sprite Texture", 2D) = "white" {}
  _Color ("Tint", Color) = (1,1,1,1)
  _StencilComp ("Stencil Comparison", Float) = 8
  _Stencil ("Stencil ID", Float) = 0
  _StencilOp ("Stencil Operation", Float) = 0
  _StencilWriteMask ("Stencil Write Mask", Float) = 255
  _StencilReadMask ("Stencil Read Mask", Float) = 255
  _ColorMask ("Color Mask", Float) = 15
 }
 SubShader
 {
  Tags { "Queue"="Transparent" "RenderType"="Transparent" "CanUseSpriteAtlas"="True" "IgnoreProjector"="True" }
  Cull Off ZWrite Off ZTest [unity_GUIZTestMode]
  Blend OneMinusDstColor One
  ColorMask [_ColorMask]
  Stencil { Ref [_Stencil] Comp [_StencilComp] Pass [_StencilOp] ReadMask [_StencilReadMask] WriteMask [_StencilWriteMask] }
  Pass
  {
   CGPROGRAM
   #pragma vertex vert
   #pragma fragment frag
   #include "UnityCG.cginc"
   struct appdata { float4 vertex:POSITION; half4 color:COLOR; float2 uv:TEXCOORD0; };
   struct v2f { float4 vertex:SV_POSITION; half4 color:COLOR; float2 uv:TEXCOORD0; };
   sampler2D _MainTex; half4 _Color;
   v2f vert(appdata v) { v2f o; o.vertex=UnityObjectToClipPos(v.vertex); o.color=v.color*_Color; o.uv=v.uv; return o; }
   half4 frag(v2f i):SV_Target { half4 c=tex2D(_MainTex,i.uv)*i.color; clip(c.a-0.01); return half4(c.rgb*c.a,c.a); }
   ENDCG
  }
 }
}
