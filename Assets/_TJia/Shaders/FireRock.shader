Shader "Lesson/SurfaceShader1" {
	Properties{
		_Color("Color", Color) = (1,1,1,1)
		_MainTex("Albedo (RGB)", 2D) = "white" {}
		_BumpMap("Bumpmap", 2D) = "bump" {}
		_FireTex("Fire", 2D) = "white" {}
		_Threshold("Threshold", Range(0,1)) = 1
		_FireValue("FireValue", Range(0.6,0.8)) = 0.7
		_Glossiness("Smoothness", Range(0,1)) = 0.5
		_Metallic("Metallic", Range(0,1)) = 0.0
	}
		SubShader{
		Tags{ "RenderType" = "Opaque" }
		LOD 200

		CGPROGRAM
			#pragma surface surf Standard fullforwardshadows
			#pragma target 3.0

			sampler2D _MainTex;
			sampler2D _BumpMap;
			sampler2D _FireTex;//熔岩贴图

		struct Input
		{
			float2 uv_MainTex;
			float2 uv_BumpMap;
			float2 uv_FireTex;
		};

		half _Glossiness;
		half _Metallic;
		fixed4 _Color;
		float _FireValue;
		fixed _Threshold;

		void surf(Input IN, inout SurfaceOutputStandard o) {
			fixed4 c = tex2D(_MainTex, IN.uv_MainTex) * _Color;
			fixed2 new_fire_uv = IN.uv_FireTex + _Time.x * 2;//烟雾流动效果

			fixed4 fire = (tex2D(_FireTex, IN.uv_FireTex) * ((_SinTime.z + 1) * 0.4 + 0.2)//熔岩明暗变化
				+ tex2D(_FireTex, new_fire_uv)) * 0.5 //烟雾流动
				* _Threshold;

			//熔岩颜色调整
			fire.b = 0;
			fire.r = fire.r / _FireValue / _FireValue;//加强红色通道
			fire.g = fire.g * _FireValue * _FireValue;//减弱绿色通道

			o.Albedo = c.rgb;
			o.Normal = UnpackNormal(tex2D(_BumpMap, IN.uv_BumpMap));

			o.Metallic = _Metallic;
			o.Smoothness = _Glossiness;
			o.Alpha = c.a;
			o.Emission = fire;
		}
		ENDCG
		}
			FallBack "Diffuse"
}