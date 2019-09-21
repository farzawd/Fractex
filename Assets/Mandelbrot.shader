Shader "Fractal/Mandelbrot"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _Area ("Area", vector) = (0, 0, 4, 4)
        _MaxIter ("Max Iterations", Float) = 512
    }
    SubShader
    {
        // No culling or depth
        Cull Off ZWrite Off ZTest Always

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                return o;
            }

            float4 _Area;
            float _MaxIter;
            sampler2D _MainTex;

            fixed4 frag (v2f i) : SV_Target
            {
                float2 c = _Area.xy + (i.uv - .5) * _Area.zw;
                float2 z;
                float iter;
                
                for (iter = 0; iter < _MaxIter; iter++) {
                    z = float2(z.x*z.x - z.y*z.y, 2*z.x*z.y) + c;
                    if (length(z) > 2) break;
                }
                
                float4 color = 0;
				if (iter < _MaxIter){
					color.r = (sin(0.05 * iter + .7853) + 1) / 2;
                    color.g = (sin(0.06 * iter + .5890) + 1) / 2;
                    color.b = (sin(0.07 * iter + .5) + 1) / 2;
				}

                return color;
            }
            ENDCG
        }
    }
}
