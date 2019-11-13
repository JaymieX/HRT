// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

Shader "Custom/SheildSurfaceShader"
{
    Properties
    {
        _Color ("Color", Color) = (1,1,1,1)
		_Transparency("Transparency", Range(0.0,1)) = 0.25
		_Glow("Intensity", Range(0, 3)) = 1
		[NoScaleOffset] _MainTex("Texture", 2D) = "white" {}
	}
		SubShader
	{
		Tags {"Queue" = "Transparent" "IgnoreProjector" = "True" "RenderType" = "Transparent"}
		LOD 100
		Cull Off
		Blend SrcAlpha OneMinusSrcAlpha
		ZWrite Off

		Pass
		{
			CGPROGRAM

			// Physically based Standard lighting model, and enable shadows on all light types
			//#pragma surface surf Standard fullforwardshadows alpha
			#pragma vertex vert
			#pragma fragment frag

			#include "UnityCG.cginc"

			// Simplex noise by random guy on internet
			float hash(float n)
			{
				return frac(sin(n)*43758.5453);
			}

			float noise(float3 x)
			{
				// The noise function returns a value in the range -1.0f -> 1.0f

				float3 p = floor(x);
				float3 f = frac(x);

				f = f * f*(3.0 - 2.0*f);
				float n = p.x + p.y*57.0 + 113.0*p.z;

				return lerp(lerp(lerp(hash(n + 0.0), hash(n + 1.0),f.x),
					lerp(hash(n + 57.0), hash(n + 58.0),f.x),f.y),
					lerp(lerp(hash(n + 113.0), hash(n + 114.0),f.x),
					lerp(hash(n + 170.0), hash(n + 171.0),f.x),f.y),f.z);
			}
			// Simplex noise by random guy on internet

			struct v2f
			{
				float4 vertex : SV_POSITION;
				fixed4 color : COLOR;
				half2 texcoord : TEXCOORD0;
			};

			struct appdata_t
			{
				float4 vertex : POSITION;
				fixed4 color : COLOR;
				float2 texcoord : TEXCOORD0;
			};

			fixed4 _Color;
			float _Transparency;

			sampler2D _MainTex;
			float4 _MainTex_ST;

			half _Glow;

			v2f vert(appdata_t v, uint vId : SV_VertexID)
			{
				v2f o;
				o.vertex = UnityObjectToClipPos(v.vertex);

				float val = (noise(_Time.z + vId) - -1) / (1 - -1) * (2 - 0) + 0;
				o.color = _Color * val;
				o.texcoord = TRANSFORM_TEX(v.texcoord, _MainTex);
				return o;
			}

			fixed4 frag(v2f i) : SV_Target
			{
				float4 col = i.color;
				col.a = _Transparency;
				col *= _Glow;

				return col;
			}

			ENDCG
		}
    }

    FallBack "Diffuse"
}
