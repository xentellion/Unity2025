Shader "Unlit/Shader"
{
    Properties
    {
        _Color("Colorish", color) = (1,1,1,1)
        _MainTexture("MainTexture", 2D) = "white" {}
    }

    SubShader
    {
        Tags { "RenderType"="Transparent" }
        LOD 100
        
        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
          
            #include "UnityCG.cginc"
            
            fixed4 _Color;
            sampler2D _MainTexture;

            struct appdata
            {
                float4 vertex : POSITION;
                float4 uv : TEXCOORD0;
            };
            
            struct v2f
            {
                float4 vertex : SV_POSITION;
                float4 uv : TEXCOORD0;
            };

            v2f vert (appdata v)
            {
                v2f o; 
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                return o;
            }
            
            fixed4 frag (v2f i) : SV_Target
            {
                fixed4 textureColor = tex2D(_MainTexture, i.uv);
                return textureColor;
            }
            ENDCG
        }
    }
}
