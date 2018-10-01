// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

Shader "Custom/EdgeLight" 
{
	Properties 
	{
		_MainTex ("Albedo (RGB)", 2D) = "white" {}
		_EdgeSize ("Edge Size", Range(0, 1)) = 0
		_EdgeColor ("Edge Color", Color ) = (1, 1, 1, 1)
		_BackgroundColor ("Background Color", Color) = (0, 0, 0, 1)
	}
	SubShader 
	{
		pass
		{
			Tags {"LightMode" = "ForwardBase"}
			Cull off
			CGPROGRAM
			#pragma vertex vert 
			#pragma fragment frag
			#include "UnityCG.cginc"

			sampler2D _MainTex;
			float4 _MainTex_ST;
			float4 _MainTex_TexelSize;
			float _EdgeSize;
			float4 _EdgeColor;
			float4 _BackgroundColor;

			struct v2f
			{
				float4 pos : SV_POSITION;
				float2 uv_MainTex : TEXCOORD0;
			};

			v2f vert(appdata_base IN)
			{
				v2f OUT;
				OUT.pos = UnityObjectToClipPos(IN.vertex);
				OUT.uv_MainTex = IN.texcoord * _MainTex_ST.xy;
				return OUT;
			}

			fixed4 frag(v2f IN) : SV_TARGET
			{
				fixed4 c;
				float3 luminance = float3(0.2125, 0.7154, 0.0721);
				float sobel00 = dot(tex2D(_MainTex, IN.uv_MainTex + fixed2(-1, -1) / _MainTex_TexelSize), luminance);
				float sobel01 = dot(tex2D(_MainTex, IN.uv_MainTex + fixed2(0, -1) / _MainTex_TexelSize), luminance);
				float sobel02 = dot(tex2D(_MainTex, IN.uv_MainTex + fixed2(1, -1) / _MainTex_TexelSize), luminance);
				float soble10 = dot(tex2D(_MainTex, IN.uv_MainTex + fixed2(-1, 0) / _MainTex_TexelSize), luminance);
				float sobel11 = dot(tex2D(_MainTex, IN.uv_MainTex), luminance);
				float sobel12 = dot(tex2D(_MainTex, IN.uv_MainTex + fixed2(1, 0) / _MainTex_TexelSize), luminance);
				float sobel20 = dot(tex2D(_MainTex, IN.uv_MainTex + fixed2(-1, 1) / _MainTex_TexelSize), luminance); 
				float sobel21 = dot(tex2D(_MainTex, IN.uv_MainTex + fixed2(0, 1) / _MainTex_TexelSize), luminance);
				float sobel22 = dot(tex2D(_MainTex, IN.uv_MainTex + fixed2(1, 1) / _MainTex_TexelSize), luminance);
				float Gx = -1 * sobel00 + 1 * sobel02 + -2 * soble10 + 2 * sobel12 + -1 * sobel20 + 1 * sobel22;
				float Gy = 1 * sobel00 + 2 * sobel01 + 1 * sobel02 + -1 * sobel20 + -2 * sobel21 + -1 * sobel22;
				float G = 1 - abs(Gx) - abs(Gy);
				fixed4 withEdge = lerp(_EdgeColor, tex2D(_MainTex, IN.uv_MainTex), G);
				fixed4 edgeOnly = lerp(_EdgeColor, _BackgroundColor, G);
				c = lerp(withEdge, edgeOnly, _EdgeSize);
				return c;
			}
			ENDCG
		}
	}
	FallBack "Diffuse"
}
