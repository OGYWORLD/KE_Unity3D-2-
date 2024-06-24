using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShaderTest : MonoBehaviour
{
    Renderer render;

    // # 어트리뷰트 찾아보기
    [Range(0, 1)] // 어트리뷰트 추가
    public float colorAmount;

    private void Awake()
    {
        render = GetComponent<Renderer>();
    }

    private void Update()
    {
        render.material.SetFloat("_colorAmount", colorAmount); // 스크립트에서 제어가능
        // colorAmount랑 _colorAmount랑 헷갈리지 말랬는데 몬가몬가임

        //render.material.SetColor("_MainTex", Color.white);

        // # 맞는 설명인지 모름..ㅋ.
        // 머트리얼이 컴포넌트로 붙으면 인스턴스화 돼서 모두 다른 값을 가질 수 있음..
        // 그래서 스크립트로 제어하면 런타임에 제어 가능 어쩌고
    }
}
