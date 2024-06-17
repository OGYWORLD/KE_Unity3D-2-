using System; // ! warning !
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DotnetDelegateTest : MonoBehaviour
{
    // delegate는 사용할 때 마다 선언을 해줘야함
    // 이게 좀 귀찮다

    // Action 델리게이트:
    // 기본적인 형태의 델리게이트를 .Net에서 기본적으로 정의하여 제공
    // 반환형이 없는 메소드
    Action action;

    // Action 델리게이트에 제네릭 타입은 파라미터 타입을 지정
    Action<int> actionWithIntParam;
    Action<float, float> actionWithTwoFloatParam; 

    // Func 델리게이트 :
    // 반환형이 있는 형태의 델리게이트를 .NET에서 기본적으로 정의하여 제공
    // 반환형이 있어야하기 때문에 제네릭을 안 쓰면 오류가 발생함
    Func<object> func;

    // Func 델리게이트는 제네릭 타입 중 맨 뒤은 반환형, 그 앞으로 파라미터 타입 지정
    Func<string, int> parseFunc;


    // Predicate 델리게이트 :
    // 반환형이 bool이고, 1개 이상의 파라미터가 있는 형태의 델리게이트
    Predicate<float> predicate;
    Predicate<int> predicateEven;

    private void Start()
    {
        action = SomeAction;
        actionWithIntParam = SomeActionWithParam;
        parseFunc = Parse;

        // Func<float, bool>과 똑같을텐데 왜 predicate는 존재하는가
        // Predicate 사용 이유
        // predicate의 경우, 일부 컬렉션 함수의 조건 판단을 위한 정의를
        // Bool을 리턴하는 함수 형태로 받기 위해 활용됨
        // # 그냥 반환형이 bool인 Func 쓰면 안돼?
        List<int> intList = new List<int>();

        intList.Add(5);
        intList.Add(6);
        intList.Add(8);
        intList.Add(9);
        intList.Add(10);

        // intList에서 짝수만 뽑아오고 싶다.
        predicateEven = IsEven;

        // predicate 사용
        List<int> evenList = intList.FindAll(predicateEven);

        foreach(int i in evenList)
        {
            print(i);
        }

        // 무명 메소드 사용
        List<int> evenAnoy = intList.FindAll(
            delegate(int param)
            {
                return param % 2 == 0;
            }
            );

    }

    private void SomeAction()
    {

    }

    private void SomeActionWithParam(int a)
    {
        // a로 무언가 했다고 침
    }

    private int Parse(string param)
    {
        return int.Parse(param);
    }

    private bool IsEven(int param)
    {
        if(param % 2 == 0)
        {
            return true;
        }

        return false;
    }
}
