Shader "RnD/CompositeWallEffect"
{
	Properties
	{
		_MainTex("Texture", 2D) = "white" {}
	}
		SubShader
	{
		// No culling or depth
		Cull Off ZWrite Off ZTest Always

		Pass
	{
		CGPROGRAM
#pragma vertex vert
#pragma fragment frag

#include "UnityCG.cginc"

		struct appdata
	{
		float4 vertex : POSITION;
		float2 uv1 : TEXCOORD0;
		float2 uv2 : TEXCOORD1;
	};

	struct v2f
	{
		float2 uv1 : TEXCOORD0;
		float2 uv2 : TEXCOORD1;
		float4 vertex : SV_POSITION;
	};

	sampler2D _WallPassTex;
	sampler2D _PlayerPassTex;
	float _CharacterOverlayIntensity;
	fixed4 _CharacterOverlayColor;

	v2f vert(appdata v)
	{
		v2f o;
		o.vertex = UnityObjectToClipPos(v.vertex);
		o.uv1 = v.uv1;
		o.uv2 = v.uv2;
		return o;
	}

	sampler2D _MainTex;

	fixed4 frag(v2f i) : SV_Target
	{
		fixed4 col = tex2D(_MainTex, i.uv1);
		fixed4 wall = tex2D(_WallPassTex, i.uv2);
		fixed4 character = tex2D(_PlayerPassTex, i.uv2);
		
		// Only if both is white then the color will be replaced with glow color.
		fixed4 result = wall * character;

		if (result.r > 0)
			return  _CharacterOverlayColor  * _CharacterOverlayIntensity;
		
		return col;
	}
		ENDCG
	}
	}
}
