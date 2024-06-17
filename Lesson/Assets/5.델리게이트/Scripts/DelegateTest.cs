using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// global namesapace
// 다른 스크립트에서 참조 가능
public delegate float SomeDelegateMethod(float x, float y);
public delegate void OtherDelegateMethod(string s);

public class DelegateTest : MonoBehaviour
{
    public float x;
    public float y;

    public SomeDelegateMethod someDelegate;
    public OtherDelegateMethod otherDelegate;

    private void Start()
    {
        /*
        // # 두 개 뭐가 다른 거지
        // 정확한 초기화는 new 키워드를 사용하는 것인데
        // 그냥 아래처럼 저렇게 쓰면 암시적으로 들어가짐
        //someDelegate = new SomeDelegateMethod(Plus);
        someDelegate = Plus;
        someDelegate = Minus;
        someDelegate = Multiple;
        someDelegate = Divide;

        //otherDelegate = PrintMessage;

        // print의 매개변수는 object
        // 매개변수가 암시적 캐스팅이 가능한 경우에도 가능
        otherDelegate = print;
        

        // delegate도 클래스이다.
        // 위 아래는 같은 의미
        //otherDelegate("");
        //otherDelegate.Invoke("");
        // # 델레게이트를 클래스 꼴로 보는게 익숙하지 않음
        // # 내부에 구현된 메소드에는 무엇이 있는지 궁금

        // Null 조건부 연산자
        // # 물음표를 넣으면 null일 경우 참조하지 않음
        // # 정말 아무것도 안 집어 넣은 경우, -> 아무것도 안 뜸
        // # null을 집어 넣은 경우 -> 아무것도 안 뜸
        // # 정상적으로 delegate를 집어 넣은 경우 -> 구조대로 잘 뜸
        // # 의 출력은?
        */

        otherDelegate?.Invoke("");
    }

    public void CalcChange(int i)
    {
        switch(i)
        {
            case 0:
                someDelegate = Plus;
                break;
            case 1:
                someDelegate = Minus;
                break;
            case 2:
                someDelegate = Multiple;
                break;
            case 3:
                someDelegate = Divide;
                break;
        }
    }

    public void ButtonClick()
    {
        print(someDelegate?.Invoke(x, y));
    }

    public float Plus(float x, float y)
    {
        return x + y;
    }

    public float Minus(float x, float y)
    {
        return x - y;
    }

    public float Multiple(float x, float y)
    {
        return x * y;
    }

    public float Divide(float x, float y)
    {
        return x / y;
    }

    public void PrintMessage(string message)
    {
        print(message);
    }
}
