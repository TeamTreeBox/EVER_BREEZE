Shader "Custom/Buttrfly"
{  Properties
    {
        _Color("Color", Color) = (1,1,1,1)
        _MainTex("Albedo (RGB)", 2D) = "white" {}
        _Speed("Speed",Range(0,5)) = 1.0
        _EdgeLength("Edge length", Range(0,250)) = 5
        _XAmplitude("AmplitudeX",Range(0,5)) = 1
        _YAmplitude("AmplitudeY",Range(0,5)) = 1
        _YFrequency("YFrequency",Range(1,10)) = 1
        _Cutoff("Alpha cutoff", Range(0,1)) = 0.5
        [Toggle(USECUSTOMDATA)] _UseCustomData("Use Custom Data",Float) = 1
}
SubShader
        {
            Tags {  "RenderType" = "TransparentCutout" "Queue" = "AlphaTest" "IgnoreProjector" = "True" }
            Cull Off
            LOD 200
            CGPROGRAM
            #pragma surface surf Lambert addshadow alphatest:_Cutoff vertex:winganim tessellate:tessEdge

            #pragma shader_feature USECUSTOMDATA

            #pragma target 5.0
            #include "Tessellation.cginc"

            sampler2D _MainTex;
            float _EdgeLength;
            float _Speed;
            half _XAmplitude;
            half _YAmplitude;
            half _YFrequency;

            struct Input
            {
                float2 uv_MainTex;
                float4 color : COLOR;
            };

            fixed4 _Color;

            struct appdata {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float4 color : COLOR;
                float4 texcoord : TEXCOORD0;
                float3 customdata : TEXCOORD1; // custom data
            };

            float4 tessEdge(appdata v0, appdata  v1, appdata  v2)
            {
                return UnityEdgeLengthBasedTess(v0.vertex, v1.vertex, v2.vertex, _EdgeLength);
            }

            void winganim(inout appdata v)
            {
                float2 value = v.texcoord.xy;
                float dist = distance(value.x, 0.5);// 나비의 몸통부분과 현재 텍스쳐 좌표 사이의 거리는?

            #ifdef USECUSTOMDATA
                v.vertex.xyz +=
                    v.normal *
                    sin(dist + _Time.y * (_Speed + v.customdata.y) + v.customdata.x)
                    * dist * (_XAmplitude * v.customdata.z);
                // 커스텀 데이터를 사용할 경우 이 블럭의 코드가 실행된다.
            #else
                v.vertex.xyz +=
                    v.normal *
                    sin(dist + _Time.y * _Speed)
                    * dist * (_XAmplitude);
            #endif
                // 각 버텍스를 노멀방향으로 밀어내자. y = sin(abs(x-0.5) * time ) * abs(x-0.5);
                v.vertex.xyz +=
                    v.normal *
                    sin(value.y * _YFrequency + _Time.y * _Speed)
                    * dist * _YAmplitude;
                // 나비 날개의 팔랑거림을 더 주기위해 텍스쳐좌표 y축 기준에 대해서도 연산을 진행하자.
            }

            void surf(Input IN, inout SurfaceOutput o)
            {
                fixed4 c = tex2D(_MainTex, IN.uv_MainTex) * (IN.color + _Color);
                o.Albedo = c.rgb;
                o.Alpha = c.a;
            }

            ENDCG
        }
            FallBack "Diffuse"
}
