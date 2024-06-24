Shader "Custom/TestSurfaceShader" // ���̴��� ���
{
    Properties // ���̴����� ����� ���� ����
    {
        // _������([�ν����Ϳ��� ǥ�õ� �̸�], �ڷ���) = {�ʱⰪ �Ҵ�}
        // ; ������ ����, ��� �ٹٲ� ����
        /*
        _Color ("Color", Color) = (1,1,1,1)
        _MainTex ("Albedo (RGB)", 2D) = "white" {}
        _Glossiness ("Smoothness", Range(0,1)) = 0.5
        _Metallic ("Metallic", Range(0,1)) = 0.0
        */
        _MainTex("Main Texture", 2D) = "white" {}
        OverlabTex("Overlab Texture", 2D) = "gray" {}
        _colorAmount("Color Amount", Range(0, 1)) = 1
    }
    SubShader
    {
        // Transparent�� ������ ����Ǵ� renderType��
        Tags { "RenderType"="Opaque" }
        LOD 200 // Level Of Detail (����ܰ�), ��ġ�� �ƴ϶� ID��(?)
        // Diffuse Level: 200, ��ǻ�� �ӽñ�.. ����Ƽ ��ť��Ʈ ã�ƺ���

        CGPROGRAM
        // c for graphics ������ ���� ����
        // Physically based Standard lighting model, and enable shadows on all light types
        //#pragma surface surf Standard fullforwardshadows
        #pragma surface surf Lambert

        // ������ ���������ο��� ���� ���̵��� �ȼ� ���̵����� �����µ�
        // ����Ƽ������ �̸� �Ѳ����� ó���ϳ�, ���� ó���ϰ� ���� �� ������ ���� �ۼ��� �� ����
        //#pragma vertext vert // ���� ���̵� ���̺귯�� �Լ��� ����ϰڴ�
        //#pragma frgament fag // �ȼ� ���̵� ���̺귯�� �Լ��� ����ϰڴ�

        // Use shader model 3.0 target, to get nicer looking lighting
        //#pragma target 3.0

        sampler2D _MainTex; // properties�� ������ �״�� ����ؾ���
        sampler2D OverlabTex;
        float _colorAmount;

        struct Input
        {
            // uv mapping�� ������ _MainTex �� ����
            float2 uv_MainTex; // ���⵵ properties�� ������ �״�� ����ؾ���, �տ� uv �߰�
            float2 uvOverlabTex;
            
            // overlap �Ǵ� �ؽ�ó�� maintex�� �и���Ű��
            // ī�޶� ���� ȭ���� �߽����� overlap�� ��
            float4 screenPos;
        };

       // half _Glossiness;
        //half _Metallic;
       // fixed4 _Color;

        //UNITY_INSTANCING_BUFFER_START(Props)

        //UNITY_INSTANCING_BUFFER_END(Props)

        // _Time : float4, �� 4������ ������ ������ �Ǵµ�
        // x: t/20, y: t, z: t*2, w:t*3

        //void surf (Input IN, inout SurfaceOutputStandard o)
        void surf (Input IN, inout SurfaceOutput o)
        {
            /*
            // ���⵵ properties�� ������ �״�� ����ؾ���
            // Albedo comes from a texture tinted by color
            fixed4 c = tex2D (_MainTex, IN.uv_MainTex) * _Color;
            o.Albedo = c.rgb;
            // Metallic and smoothness come from slider variables
            o.Metallic = _Metallic;
            o.Smoothness = _Glossiness;
            o.Alpha = c.a;
            */

            // ǥ�� ���̴��� �ؽ��� ���� ����
            o.Albedo = tex2D(_MainTex, IN.uv_MainTex).rgb * _colorAmount;
            //o.Albedo *= tex2D(OverlabTex, IN.uvOverlabTex).rgb;

            // �и��ϱ� �̾
            float2 screenUV = IN.screenPos.xy / IN.screenPos.w * float2(10, 5);

            // �� �̷��� ���̰� �帧.. �x �̰� �������� �� �˾Ҿ�� �ϴµ�.
            o.Albedo *= tex2D(OverlabTex, screenUV  + _Time.y).rgb;
        }
        ENDCG
    }
    // ���� SubShader���� ������ ���� ���� SubShader�� ����ȴ�. / �׷���ī�� �� ȣȯ���� ����� �� ���� �� ����.
    
    //FallBack "Diffuse" // ������ �߻��ϸ� FallBack���� ������
    FallBack "Standard" // ������ �߻��ϸ� FallBack���� ������
    // Standard�̸� shader�� standard�� ����ȴٴ� ��
}
