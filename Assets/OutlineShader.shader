Shader "Custom/Outline" {
    Properties {
        _Color ("Main Color", Color) = (1,1,1,1)
        _OutlineColor ("Outline Color", Color) = (0,0,0,1)
        _OutlineWidth ("Outline Width", Range(0.0, 0.1)) = 0.01
    }
 
    SubShader {
        Tags { "RenderType"="Opaque" }
        LOD 100
 
        Pass {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"
 
            struct appdata_t {
                float4 vertex : POSITION;
            };
 
            struct v2f {
                float4 pos : POSITION;
                float4 color : COLOR;
            };
 
            float _OutlineWidth;
 
            v2f vert (appdata_t v) {
                v2f o;
                o.pos = UnityObjectToClipPos(v.vertex);
                float4 outlinePos = o.pos;
                outlinePos.xy += normalize(v.vertex.xy - _WorldSpaceCameraPos.xy) * _OutlineWidth;
                o.color = _OutlineColor;
                return o;
            }
 
            half4 frag (v2f i) : SV_Target {
                return i.color;
            }
            ENDCG
        }
 
        Pass {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"
 
            struct appdata_t {
                float4 vertex : POSITION;
            };
 
            struct v2f {
                float4 pos : POSITION;
                float4 color : COLOR;
            };
 
            float _OutlineWidth;
 
            v2f vert (appdata_t v) {
                v2f o;
                o.pos = UnityObjectToClipPos(v.vertex);
                float4 outlinePos = o.pos;
                outlinePos.xy += normalize(v.vertex.xy - _WorldSpaceCameraPos.xy) * _OutlineWidth * 1.5; // 輪郭線を少し太くする
                o.color = _OutlineColor;
                return o;
            }
 
            half4 frag (v2f i) : SV_Target {
                return i.color;
            }
            ENDCG
        }
    }
}
