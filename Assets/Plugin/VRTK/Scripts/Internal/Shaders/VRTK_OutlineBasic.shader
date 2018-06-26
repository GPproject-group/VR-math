Shader "VRTK/OutlineBasic"
{
    Properties
    {
        _OutlineColor("Outline Color", Color) = (1, 0, 0, 1)
        _Thickness("Thickness", float) = 1
		_MainTex("Main Tex", 2D) = "white" {}
		_AlphaScale("Alpha Scale", Range(0,1)) = 1
    }

    SubShader
    {
        Tags
        {
            "Queue" = "Transparent"
            "IgnoreProjector" = "True"
            "RenderType" = "Transparent"
        }

        // Fill the stencil buffer
        Pass
        {
            Stencil
            {
                Ref 1
                Comp Always
                Pass Replace
                ZFail Replace
            }

            ColorMask 0
        }

        // Draw the outline
        Pass
        {
            Blend SrcAlpha OneMinusSrcAlpha
            ZWrite Off // On (default) = Ignore lights etc. Should this be a property?
            Stencil
            {
                Ref 0
                Comp Equal
            }

            CGPROGRAM
                #pragma vertex vert
                #pragma geometry geom
                #pragma fragment frag

                #include "UnityCG.cginc"
                half4 _OutlineColor;
                float _Thickness;

                struct appdata
                {
                    float4 vertex : POSITION;
                };

                struct v2g
                {
                    float4 pos : SV_POSITION;
                };

                v2g vert(appdata IN)
                {
                    v2g OUT;
                    OUT.pos = UnityObjectToClipPos(IN.vertex);
                    return OUT;
                }

                void geom2(v2g start, v2g end, inout TriangleStream<v2g> triStream)
                {
                    float width = _Thickness / 100;
                    float4 parallel = (end.pos - start.pos) * width;
                    float4 perpendicular = normalize(float4(parallel.y, -parallel.x, 0, 0)) * width;
                    float4 v1 = start.pos - parallel;
                    float4 v2 = end.pos + parallel;
                    v2g OUT;
                    OUT.pos = v1 - perpendicular;
                    triStream.Append(OUT);
                    OUT.pos = v1 + perpendicular;
                    triStream.Append(OUT);
                    OUT.pos = v2 - perpendicular;
                    triStream.Append(OUT);
                    OUT.pos = v2 + perpendicular;
                    triStream.Append(OUT);
                }

                [maxvertexcount(12)]
                void geom(triangle v2g IN[3], inout TriangleStream<v2g> triStream)
                {
                    geom2(IN[0], IN[1], triStream);
                    geom2(IN[1], IN[2], triStream);
                    geom2(IN[2], IN[0], triStream);
                }

                half4 frag(v2g IN) : COLOR
                {
                    _OutlineColor.a = 1;
                    return _OutlineColor;
                }
            ENDCG
        }
		Pass
		{
			Tags{ "LightMode" = "ForwardBase" }
			ZWrite Off
			Blend SrcAlpha OneMinusSrcAlpha
			Cull Back
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			#include "UnityCG.cginc"
			sampler2D _MainTex;
			float4 _MainTex_ST;
			float _AlphaScale;
			struct a2v
			{
				float4 vertex : POSITION;
				float3 normal : NORMAL;
				// 将模型的第一组纹理坐标存储到该变量中
				float3 texcoord : TEXCOORD0;
			};
			struct v2f
			{
				float4 pos : SV_POSITION;
				float3 worldPos : TEXCOORD0;
				float3 worldNormal : TEXCOORD1;
				float2 uv : TEXCOORD2;
			};
			v2f vert(a2v v)
			{
				v2f o;
				o.pos = UnityObjectToClipPos(v.vertex);
				// 模型坐标顶点转换世界坐标顶点
				o.worldPos = mul(unity_ObjectToWorld, v.vertex);
				// 模型坐标法线转换世界坐标法线
				o.worldNormal = UnityObjectToWorldNormal(v.normal);
				// 对顶点纹理坐标进行变换，最终得到uv坐标。
				// 方法原理 o.uv = v.texcoord.xy * _MainTex_ST.xy + _MainTex_ST.zw;
				//_MainTex_ST 是纹理的属性值，写法是固定的为 纹理名+_ST
				o.uv = TRANSFORM_TEX(v.texcoord, _MainTex);
				return o;
			}
			fixed4 frag(v2f i) : SV_Target
			{

				// 对纹理进行采样，返回为计算得到的纹素值，与_Color的乘积作为反射率
				fixed3 albedo = tex2D(_MainTex, i.uv).rgb;
				return fixed4(albedo, _AlphaScale);
			}
			ENDCG
		}
			Pass
			{
				Tags{ "LightMode" = "ForwardBase" }
				ZWrite Off
				Blend SrcAlpha OneMinusSrcAlpha
				Cull Off
				CGPROGRAM
				#pragma vertex vert
				#pragma fragment frag
				#include "UnityCG.cginc"
				sampler2D _MainTex;
				float4 _MainTex_ST;
				float _AlphaScale;
				struct a2v
				{
					float4 vertex : POSITION;
					float3 normal : NORMAL;
					// 将模型的第一组纹理坐标存储到该变量中
					float3 texcoord : TEXCOORD0;
				};
				struct v2f
				{
					float4 pos : SV_POSITION;
					float3 worldPos : TEXCOORD0;
					float3 worldNormal : TEXCOORD1;
					float2 uv : TEXCOORD2;
				};
				v2f vert(a2v v)
				{
					v2f o;
					o.pos = UnityObjectToClipPos(v.vertex);
					// 模型坐标顶点转换世界坐标顶点
					o.worldPos = mul(unity_ObjectToWorld, v.vertex);
					// 模型坐标法线转换世界坐标法线
					o.worldNormal = UnityObjectToWorldNormal(v.normal);
					// 对顶点纹理坐标进行变换，最终得到uv坐标。
					// 方法原理 o.uv = v.texcoord.xy * _MainTex_ST.xy + _MainTex_ST.zw;
					//_MainTex_ST 是纹理的属性值，写法是固定的为 纹理名+_ST
					o.uv = TRANSFORM_TEX(v.texcoord, _MainTex);
					return o;
				}
				fixed4 frag(v2f i) : SV_Target
				{

					// 对纹理进行采样，返回为计算得到的纹素值，与_Color的乘积作为反射率
					fixed3 albedo = tex2D(_MainTex, i.uv).rgb;
				return fixed4(albedo, _AlphaScale);
				}
					ENDCG
				}
		}
    FallBack "Diffuse"
}