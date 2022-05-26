Shader "Unlit/teleportObj"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _PortalPos_WS("PortalPos World Space",Vector)=(0,0,0,0)
        _PortalPosBais("PortalPos Bais",Vector) = (0,0,0,0)
        _PortalForward_WS("PortalForward World Space",Vector)=(0,0,0,0)
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 100
    
        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            // make fog work
            #pragma multi_compile_fog

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                UNITY_FOG_COORDS(1)
                float4 vertex : SV_POSITION;
                float4 pos_ws:TEXCOORD1;
            };

            sampler2D _MainTex;
            float4 _MainTex_ST;

            float4 _PortalPos_WS;
            float4 _PortalForward_WS;
            float4 _PortalPosBais;

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                UNITY_TRANSFER_FOG(o,o.vertex);
                o.pos_ws=mul(unity_ObjectToWorld,v.vertex);
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                // sample the texture
                fixed4 col = tex2D(_MainTex, i.uv);
                // apply fog
                UNITY_APPLY_FOG(i.fogCoord, col);

                float3 PortalToObjDir=_PortalPos_WS-i.pos_ws;
                clip(dot(-_PortalForward_WS,PortalToObjDir));
                return col;
            }
            ENDCG
        }
    }
}
