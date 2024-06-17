using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelegateChaningTest : MonoBehaviour
{
    private OtherDelegateMethod otherDelegate;

    private void Start()
    {
        // 중간에 = 연산자 사용하면 이전에 누적합됐던 delegate가 사라짐
        // delegate instance가 새로 생성해서 대입되는 것
        otherDelegate = new OtherDelegateMethod(MessageTrim);
        otherDelegate += new OtherDelegateMethod(MessageAllTrim);
        otherDelegate += new OtherDelegateMethod(MessageDuplicate);
        otherDelegate += new OtherDelegateMethod(MessageLower);

        otherDelegate?.Invoke("Hello World");

        otherDelegate -= new OtherDelegateMethod(MessageAllTrim);

        // delegate chain은 일종의 stack구조 이지만
        // 같은 메소드 중에서만 선입 후출로 제거된다.
        // # 근데 delegate 인스턴스가 할당되는 공간은 stack이 아니잖아
    }

    private void MessageTrim(string message)
    {
        // Trim: 문자열에서 앞 뒤 공백을 제거하여 반환하는 메소드
        print(message.Trim());
    }

    private void MessageAllTrim(string message)
    {
        print(message.Replace(" ", ""));
    }

    private void MessageDuplicate(string message)
    {
        print(message + message);
    }

    private void MessageLower(string message)
    {
        print(message.ToLower());
    }


}
