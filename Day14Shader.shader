Shader "Unlit/NewUnlitShader" //Shaders are wrteen in their own language. They all look like old C
								//Names our shader for Unity
{
	SubShader ///Shaders can have multiple subshaders, we'll deal with one
	{
		Pass //Most shaders have multiple passes
	{
		CGPROGRAM //Declare my language
#pragma vertex vert //My vertex shader will be called vert in code
#pragma fragment frag //Same with fragment shader

#include "UnityCG.cginc" //This includes Unity's default operations

		struct appdata //The data I want for my vertex shader
		{

			//GPU code has special structures
			//float - just one float value directly or name.x
			//float2 - two floats in one variable, name.x, name.y
			//float3 - two floats in one variable, name.x, name.y, name.z
			//float4 - two floats in one variable, name.x, name.y, name.z, name.w

			//type name [optional : specification]
			//POSITION means position
			//TEXCOORDX - a series of texture coordinates


			float4 vertex : POSITION;	//the location of the vertex
			float2 uv : TEXCOORD0;		//The UV of the vertex
		};

		struct v2f //The data the vertex buffer produces and the fragment shader consumes
					//the structure the vertex shader returns and the fragment shader takes as a parameter
		{
			float2 uv : TEXCOORD0;
			float4 vertex : SV_POSITION;
			float4 modelPosition : TEXCOORD1;

		};

		float4 _MainTex_ST;

		v2f vert(appdata v) //vertex shader
		{
			v2f o; //Declare return value

			float4 newPosition = v.vertex; //shaders are all pass by value
			newPosition.y = cos(sin(newPosition.x)) + pow(cos(newPosition.z),2);
			o.modelPosition = v.vertex;
			o.vertex = UnityObjectToClipPos(newPosition); //Unity's model->world space->camera->view matrix
			o.uv = TRANSFORM_TEX(v.uv, _MainTex); //Unity's UV transformation
			return o; //return...Culled...Rasterized...Z Buffer...Then fragment shader
		}

		fixed4 frag(v2f i) : SV_Target ///A fragment shader MUST return a float4 (of fixed4)
		{
			float newX = (sin(i.modelPosition.x * 25) + 1)/2;
			float newY = (cos(i.modelPosition.y * 25) + 1) / 2;
			//fixed4 col = float4(newX, newY, 0,1);
			fixed4 col = fixed4(i.modelPosition.x, i.modelPosition.y, i.modelPosition.z, 1);
			return col;
		}
		ENDCG
	}
	}
}
