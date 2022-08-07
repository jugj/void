Shader "Custom/CameraShader"{
    Properties{
        _MainTex ("Albedo (RGB)", 2D) = "white" {}
        _fog ("Fog Mod", float) = 1
        _vigenette ("Vigenette Mod", float) = 1
    }
    SubShader {
        Pass {
            CGPROGRAM
            #pragma vertex vert_img
            #pragma fragment frag
            #include "UnityCG.cginc" // required for v2f_img

            // Properties
            sampler2D _MainTex;
            float _vigenette;
            float _fog;

            float4 frag(v2f_img input) : COLOR {
                // sample texture for color
                float distFromCenter = distance(input.uv.xy, float2(0.5, 0.5));

                float4 base = tex2D(_MainTex, input.uv);
                base += pow(distFromCenter, 1/_fog);
                base *= pow(1 - distFromCenter, _vigenette);

                return base;
            }
            ENDCG
        }
    }
}
