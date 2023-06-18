Shader "Unlit/LanternEffectShader"
{
     Properties {
        _Color("Color", Color) = (1, 0, 0, 1)
    }
    SubShader {
        Tags { "RenderType"="Opaque" }
        LOD 100

        Pass {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            
            #include "UnityCG.cginc"

            struct appdata {
                float4 vertex : POSITION;
            };

            struct v2f {
                float4 vertex : SV_POSITION;
                float3 worldPos : TEXCOORD0;
            };

            v2f vert (appdata v) {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.worldPos = mul(unity_ObjectToWorld, v.vertex).xyz;
                return o;
            }

            fixed4 _Color;

            fixed4 frag (v2f i) : SV_Target {
                // Calculate distance from fragment to camera
                float distance = length(_WorldSpaceCameraPos - i.worldPos);
                
                // Use a smoothstep function to fade out the color over a certain distance
                float radius = 0.0;
                float fadeWidth = 10.0;
                float t = smoothstep(radius, radius + fadeWidth, distance);
                
                // Return the color multiplied by the fade factor
                return lerp(_Color,fixed4 (.3,.3,.3,.3), t);
            }
            ENDCG
        }
    }
}
