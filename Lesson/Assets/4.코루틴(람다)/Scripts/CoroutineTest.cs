using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoroutineTest : MonoBehaviour
{
    private void Start()
    {
        /*
        // 1. Enumerator��
        IEnumerator someEnum = SomeEnumerator();

        print(someEnum.Current);

        print(someEnum.MoveNext());

        print(someEnum.Current);

        while(someEnum.MoveNext())
        {
            print(someEnum.Current);
        }

        // 2. Generic Enumerator
        // ���� �����Ͱ� �ڽ̵Ǿ����� �ʴ´�.
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

        // 3. �ڷ�ƾ�� Enumerator
        IEnumerator thisIsCoroutine = ThisIsCoroutine();
        thisIsCoroutine.MoveNext(); // yield �ϳ� �н���
        print("�ڷ�ƾ �� ����Ŭ�� �Ѱ��.");

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
        yield return "����";

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
        print("�ڷ�ƾ ����");

        yield return new WaitForSeconds(1f);
        print("1�� ����");

        yield return new WaitForSeconds(3f);
        print("3�� �� ����");

        yield return new WaitForSeconds(4f);
        print("4�� �� ����");
    }

    private IEnumerator SecondsCoroutine(int count, float interval)
    {
        float timeTemp = 0f;

        for(int i = 0; i < count; i++)
        {
            print($"{i} �� ȣ��, {timeTemp} �� ����");
            timeTemp += interval;
            yield return new WaitForSeconds(interval);
        }
    }

    private IEnumerator RealTimeSecondsCoroutine(int count, float interval)
    {
        float timeTemp = 0f;

        for (int i = 0; i < count; i++)
        {
            print($"{i} �� ȣ��, {timeTemp} �� ����");
            timeTemp += interval;
            yield return new WaitForSecondsRealtime(interval);
        }
    }

    public bool continueKey;

    private IEnumerator UntileCoroutine()
    {
        // WaitUntil
        // �Ű������� �Ѿ �Լ��� Return�� false�� �� ���, true�� �� �Ѿ
        yield return new WaitUntil(()=> { return continueKey; });
        print("��Ƽ�� Ű�� True�� ��");

        // WaitWhile
        // �Ű������� �Ѿ �Լ��� Return�� true�� �� ���, false�� �� �Ѿ
        yield return new WaitWhile(() => { return continueKey; });
        print("��Ƽ�� Ű�� false�� ��");
    }
}
