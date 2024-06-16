using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoroutineTest : MonoBehaviour
{
    private void Start()
    {
        /*
        // 1. Enumerator란
        IEnumerator someEnum = SomeEnumerator();

        print(someEnum.Current);

        print(someEnum.MoveNext());

        print(someEnum.Current);

        while(someEnum.MoveNext())
        {
            print(someEnum.Current);
        }

        // 2. Generic Enumerator
        // 따라서 데이터가 박싱되어있지 않는다.
        int a = 1000;
        IEnumerator<int> someIntEnum = someIntEnumerator();
        while(someIntEnum.MoveNext())
        {
            a -= someIntEnum.Current;
            print(a);
        }

        foreach(Transform child in transform)
        {
            print(child.name);
        }

        // 3. 코루틴과 Enumerator
        IEnumerator thisIsCoroutine = ThisIsCoroutine();
        thisIsCoroutine.MoveNext(); // yield 하나 패스함
        print("코루틴 한 싸이클을 넘겼다.");

        StartCoroutine(thisIsCoroutine);

        // 4.
        StartCoroutine(SecondsCoroutine(10, 0.5f));

        // 5.
        StartCoroutine(RealTimeSecondsCoroutine(10, 0.5f));
        */

        // 6.
        StartCoroutine(UntileCoroutine());
    }

    private IEnumerator SomeEnumerator()
    {
        yield return "하이";

        yield return 1;

        yield return false;

        yield return new object();
    }

    private IEnumerator<int> someIntEnumerator()
    {
        yield return 6;

        yield return 2;

        yield return 923;

        yield return -323;
    }

    private IEnumerator ThisIsCoroutine()
    {
        print("코루틴 시작");

        yield return new WaitForSeconds(1f);
        print("1초 지남");

        yield return new WaitForSeconds(3f);
        print("3초 더 지남");

        yield return new WaitForSeconds(4f);
        print("4초 더 지남");
    }

    private IEnumerator SecondsCoroutine(int count, float interval)
    {
        float timeTemp = 0f;

        for(int i = 0; i < count; i++)
        {
            print($"{i} 번 호출, {timeTemp} 초 지남");
            timeTemp += interval;
            yield return new WaitForSeconds(interval);
        }
    }

    private IEnumerator RealTimeSecondsCoroutine(int count, float interval)
    {
        float timeTemp = 0f;

        for (int i = 0; i < count; i++)
        {
            print($"{i} 번 호출, {timeTemp} 초 지남");
            timeTemp += interval;
            yield return new WaitForSecondsRealtime(interval);
        }
    }

    public bool continueKey;

    private IEnumerator UntileCoroutine()
    {
        // WaitUntil
        // 매개변수로 넘어간 함수의 Return이 false일 때 대기, true일 때 넘어감
        yield return new WaitUntil(()=> { return continueKey; });
        print("컨티뉴 키가 True가 됨");

        // WaitWhile
        // 매개변수로 넘어간 함수의 Return이 true일 때 대기, false일 때 넘어감
        yield return new WaitWhile(() => { return continueKey; });
        print("컨티뉴 키가 false가 됨");
    }
}
