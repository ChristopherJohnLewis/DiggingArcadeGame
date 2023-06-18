// A very basic Shader that outputs a single color

Shader "Unlit/BasicColorShader"
{
    Properties
    {
        _Color ("Color", Color) = (1,1,1,1) // Defines a shader property named _Color, which is accessible in the Unity editor
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }  // Defines how the shader should behave in different rendering paths
        LOD 100

        Pass
        {
            CGPROGRAM  // Begins a section of CG code (CG is the language we're using here)

            #pragma vertex vert  // The vertex shader function will be named 'vert'
            #pragma fragment frag  // The fragment shader function will be named 'frag'

            #include "UnityCG.cginc"  // Include a file with helper functions

            struct appdata  // Input to the vertex shader
            {
                float4 vertex : POSITION;
            };

            struct v2f  // Output from the vertex shader and input to the fragment shader
            {
                float4 vertex : SV_POSITION;
            };

            uniform float4 _Color;  // A variable to hold the value of the _Color property

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);  // Convert the vertex position from object space to clip space
                return o;
            }

            fixed4 frag (v2f i) : SV_Target  // The fragment shader function
            {
                return _Color;  // Return the color property
            }

            ENDCG  // Ends a section of CG code
        }
    }
}
