using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class AnnoymousMethodTest : MonoBehaviour
{
    // 무명메소드란
    // 클래스 안에가 아닌 매소드 안에서 정의되는 메소드
    // 메소드에 이름이 없으며, delegate에 할당하기 위해서는
    // 해당 Delegate와 매개변수와 반환형의 타입이 일치해야 함.

// 무명메소드의 장점
// 일회성으로 사용되는 함수의 정의를 따로 함수 밖에서 할 필요가 없어
// 가독성이 좋아진다.
// 또한 지역적으로 사용되는 델리게이트 변수에 할당하는 식으로 상용될경우
// 해당 포커스가 종료되면 메모리 할당을 해제 하므로 불필요하게 함수가
// 메모리를 점유하는 것을 방지할 수 있음.

// # 전역변수는 Heap에 할당한다?

// 무명메소드의 단점
// 델리게이트 체이닝을 사용할 때, 해당 메서드만 제거하는 것이 불가능.
/*
 * someAction2 = someAction = delegate ()
    {
        print("Anoymous Method Called");
    };

    someAction2 -= someAction;
이런식으로 쓸 수 있기는 함
*/
// 또한, 한 메소드에서 많은 무명 메소드 정의 시에 오히려 가독성이 떨어질 수 있다.


// 람다식
// 무명메소드의 축약식 표현
    Action someAction;
    Action<int, float> autoCastPlus;
    Func<int, string> someFunc;
    Func<int, int, string> someFunc2;

private void Awake()
{
    someAction = delegate ()
    {
        print("Anoymous Method Called");
    };

    // 매개변수를 지켜주지 않으면 오류 발생
    autoCastPlus = delegate (int a, float b)
    {
        int result = a + (int)b;
        print(result);
    };

    // 무명 메소드 할당에서 매개변수 참조가 불필요할 경우
    // 생략이 가능하다.
    autoCastPlus += delegate 
    {
        print("Calc Finished!");
    };

    someFunc = delegate (int a)
    {
        // # string builder 와 +의 차이
        StringBuilder sb = new StringBuilder();

        sb.Append("입력된 파라미터는 ");
        sb.Append(a);
        sb.Append(" 입니다.");

        return sb.ToString();
    };

    autoCastPlus?.Invoke(1, 2);

    // 람다식 표현 방법
    someAction += () => { };

    // delegate 키워드 대신 => 기호를 통해 무명메소드 임을 명시.
    someFunc += (int a) => { return a + "is Integer"; };

    // 매개변수의 자료형과 return 키워드 생략 가능
    someFunc += (a) => a + "is Integer";

    // 매개변수가 한 개라면 괄호도 생략 가능
    someFunc += a => a + "is Integer";

    someFunc2 = (a, b) => $"{a} + {b} = {a + b}";
}

private void Start()
{
    someAction?.Invoke();
    someAction?.Invoke();

    print(someFunc?.Invoke(3));
}
}
