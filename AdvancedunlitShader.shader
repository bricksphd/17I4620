// Upgrade NOTE: replaced '_Object2World' with 'unity_ObjectToWorld'

Shader "Unlit/NewUnlitShader"
{
	Properties
	{
		_MainTex("Texture", 2D) = "white" {}
		_BumpTex("Texture", 2D) = "white" {}
	}
	SubShader
	{
		Tags { "RenderType"="Opaque" }
		LOD 100

		Pass
		{
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			// make fog work
			//#pragma multi_compile_fog
			
			#include "UnityCG.cginc"

			struct appdata
			{
				float4 vertex : POSITION;
				float2 uv : TEXCOORD0;
				float3 normal : NORMAL;
			};

			struct v2f
			{
				float2 uv : TEXCOORD0;
				float4 vertex : SV_POSITION;
				float3 normal : NORMAL;
			};

			sampler2D _MainTex;
			float4 _MainTex_ST;

			sampler2D _BumpTex;
			float4 _BumpTex_ST;
			
			v2f vert (appdata v)
			{
				v2f o;
				o.vertex = UnityObjectToClipPos(v.vertex);
				o.uv = TRANSFORM_TEX(v.uv, _MainTex);

				o.normal = mul((float3x3)unity_ObjectToWorld, v.normal);
				return o;
			}
			
			fixed4 frag (v2f i) : SV_Target
			{


				float3 directionToSun = float3(0, 1, 0);

				//Sample my texture at ht egiven UV coordinates and return the color
				fixed4 texCol = tex2D(_MainTex, i.uv);
				fixed4 bump = tex2D(_BumpTex, i.uv);
				float3 normalAdjust = normalize(bump);
				float3 newNormal = normalize(i.normal + normalAdjust * .2);

				float cosAngle = dot(newNormal, directionToSun);

				float4 ambient = float4(.1, .1, .1, 1);

				
				return cosAngle * texCol + ambient;
			}
			ENDCG
		}
	}
}
