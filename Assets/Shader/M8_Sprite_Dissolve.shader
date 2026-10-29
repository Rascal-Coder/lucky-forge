// Restored from original serialized render states and GLES3 program(s), not DummyShaderTextExporter.
Shader "M8/Sprite/Dissolve"{
Properties {

_MainTex ("Sprite Texture", 2D) = "white" { }

_Color ("Tint", Color) = (1,1,1,1)

[MaterialToggle] PixelSnap ("Pixel snap", Float) = 0.0

_RendererColor ("RendererColor", Color) = (1,1,1,1)

_Flip ("Flip", Vector) = (1,1,1,1)

_AlphaTex ("External Alpha", 2D) = "white" { }

_EnableExternalAlpha ("Enable External Alpha", Float) = 0.0

_DissolveTex ("Dissolve Overlay", 2D) = "white" { }

_EmissionColor ("Emission Color", Color) = (1,0,0,1)

_EmissionThickness ("Emission Thickness", Range(0, 1)) = 0.10000000149011612

_DissolvePower ("Dissolve Power", Range(0, 1)) = 1.0

}

SubShader{Tags{"CanUseSpriteAtlas"="true" "IGNOREPROJECTOR"="true" "PreviewType"="Plane" "QUEUE"="Transparent" "RenderType"="Transparent"}
Cull Off
ZWrite Off
ZTest LEqual
Blend One OneMinusSrcAlpha, One OneMinusSrcAlpha
Pass{
CGPROGRAM
#pragma target 3.0
#pragma vertex SpriteVert
#pragma fragment frag
#pragma multi_compile _ PIXELSNAP_ON
#pragma multi_compile _ ETC1_EXTERNAL_ALPHA
#include "UnitySprites.cginc"
sampler2D _DissolveTex;float4 _DissolveTex_ST;float4 _EmissionColor;float _EmissionThickness,_DissolvePower;
float4 frag(v2f i):SV_Target{
 float4 color=SampleSpriteTexture(i.texcoord)*i.color;
 float threshold=tex2D(_DissolveTex,i.texcoord*_DissolveTex_ST.xy+_DissolveTex_ST.zw).r;
 float4 edge=threshold<_EmissionThickness+_DissolvePower?float4(_EmissionColor.rgb,color.a):float4(0,0,0,0);
 color=_DissolvePower>=threshold?color:edge;color.rgb*=color.a;return color;
}

ENDCG
}
}
}
