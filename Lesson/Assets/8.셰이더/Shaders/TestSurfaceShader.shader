Shader "Custom/TestSurfaceShader" // 셰이더의 경로
{
    Properties // 셰이더에서 사용할 변수 선언
    {
        // _변수명([인스펙터에서 표시될 이름], 자료형) = {초기값 할당}
        // ; 붙이지 않음, 대신 줄바꿈 수행
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
        // Transparent는 투명도가 적용되는 renderType임
        Tags { "RenderType"="Opaque" }
        LOD 200 // Level Of Detail (묘사단계), 수치가 아니라 ID다(?)
        // Diffuse Level: 200, 디퓨즈 머시기.. 유니티 도큐먼트 찾아보기

        CGPROGRAM
        // c for graphics 문법이 사용된 영역
        // Physically based Standard lighting model, and enable shadows on all light types
        //#pragma surface surf Standard fullforwardshadows
        #pragma surface surf Lambert

        // 렌더링 파이프라인에는 정점 셰이딩과 픽셀 셰이딩으로 나뉘는데
        // 유니티에서는 이를 한꺼번에 처리하나, 따로 처리하고 싶을 때 다음과 같이 작성할 수 있음
        //#pragma vertext vert // 정점 셰이딩 라이브러리 함수를 사용하겠다
        //#pragma frgament fag // 픽셀 셰이딩 라이브러리 함수를 사용하겠다

        // Use shader model 3.0 target, to get nicer looking lighting
        //#pragma target 3.0

        sampler2D _MainTex; // properties에 선언한 그대로 사용해야함
        sampler2D OverlabTex;
        float _colorAmount;

        struct Input
        {
            // uv mapping을 적용한 _MainTex 색 정보
            float2 uv_MainTex; // 여기도 properties에 선언한 그대로 사용해야함, 앞에 uv 추가
            float2 uvOverlabTex;
            
            // overlap 되는 텍스처를 maintex와 분리시키기
            // 카메라가 보는 화면을 중심으로 overlap이 됨
            float4 screenPos;
        };

       // half _Glossiness;
        //half _Metallic;
       // fixed4 _Color;

        //UNITY_INSTANCING_BUFFER_START(Props)

        //UNITY_INSTANCING_BUFFER_END(Props)

        // _Time : float4, 즉 4차원의 값으로 제공이 되는데
        // x: t/20, y: t, z: t*2, w:t*3

        //void surf (Input IN, inout SurfaceOutputStandard o)
        void surf (Input IN, inout SurfaceOutput o)
        {
            /*
            // 여기도 properties에 선언한 그대로 사용해야함
            // Albedo comes from a texture tinted by color
            fixed4 c = tex2D (_MainTex, IN.uv_MainTex) * _Color;
            o.Albedo = c.rgb;
            // Metallic and smoothness come from slider variables
            o.Metallic = _Metallic;
            o.Smoothness = _Glossiness;
            o.Alpha = c.a;
            */

            // 표면 셰이더에 텍스쳐 색을 적용
            o.Albedo = tex2D(_MainTex, IN.uv_MainTex).rgb * _colorAmount;
            //o.Albedo *= tex2D(OverlabTex, IN.uvOverlabTex).rgb;

            // 분리하기 이어서
            float2 screenUV = IN.screenPos.xy / IN.screenPos.w * float2(10, 5);

            // 오 이러면 무늬가 흐름.. 쉣 이걸 슈마알할 때 알았어야 하는데.
            o.Albedo *= tex2D(OverlabTex, screenUV  + _Time.y).rgb;
        }
        ENDCG
    }
    // 위의 SubShader에서 오류가 나면 다음 SubShader가 실행된다. / 그래픽카드 별 호환성을 고려할 때 여러 개 쓴다.
    
    //FallBack "Diffuse" // 에러가 발생하면 FallBack으로 떨어짐
    FallBack "Standard" // 에러가 발생하면 FallBack으로 떨어짐
    // Standard이면 shader가 standard로 변경된다는 뜻
}
