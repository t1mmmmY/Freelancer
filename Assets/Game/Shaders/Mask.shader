Shader "Hole" 
{
    Properties 
    {
        _Color ("Main Color", Color) = (1,1,1,0)
    }
    SubShader {
        Tags { "Queue" = "Geometry-1" }  // Write to the stencil buffer before drawing any geometry to the screen
		ColorMask 0 // Don't write to any colour channels
		ZWrite Off // Don't write to the Depth buffer
        Stencil 
        {
            Ref 1
		    Comp Always
		    Pass Replace
        }

        CGPROGRAM
        #pragma surface surf Lambert
        float4 _Color;
        struct Input 
        {
            float4 color : COLOR;
        };
        void surf (Input IN, inout SurfaceOutput o) 
        {
            o.Albedo = _Color.rgb;
            o.Normal = half3(0,0,-1);
            o.Alpha = 1;
        }
        ENDCG
    } 
}