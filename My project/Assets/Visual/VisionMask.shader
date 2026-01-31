Shader "UI/VisionMask"
{
    SubShader
    {
        Tags { "Queue"="Overlay" }
        Blend One OneMinusSrcAlpha

        Pass
        {
            Color (0,0,0,0.85)
        }
    }
}