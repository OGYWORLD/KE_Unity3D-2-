using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class AnnoymousMethodTest : MonoBehaviour
{
    // ����޼ҵ��
    // Ŭ���� �ȿ��� �ƴ� �żҵ� �ȿ��� ���ǵǴ� �޼ҵ�
    // �޼ҵ忡 �̸��� ������, delegate�� �Ҵ��ϱ� ���ؼ���
    // �ش� Delegate�� �Ű������� ��ȯ���� Ÿ���� ��ġ�ؾ� ��.

// ����޼ҵ��� ����
// ��ȸ������ ���Ǵ� �Լ��� ���Ǹ� ���� �Լ� �ۿ��� �� �ʿ䰡 ����
// �������� ��������.
// ���� ���������� ���Ǵ� ��������Ʈ ������ �Ҵ��ϴ� ������ ���ɰ��
// �ش� ��Ŀ���� ����Ǹ� �޸� �Ҵ��� ���� �ϹǷ� ���ʿ��ϰ� �Լ���
// �޸𸮸� �����ϴ� ���� ������ �� ����.

// # ���������� Heap�� �Ҵ��Ѵ�?

// ����޼ҵ��� ����
// ��������Ʈ ü�̴��� ����� ��, �ش� �޼��常 �����ϴ� ���� �Ұ���.
/*
 * someAction2 = someAction = delegate ()
    {
        print("Anoymous Method Called");
    };

    someAction2 -= someAction;
�̷������� �� �� �ֱ�� ��
*/
// ����, �� �޼ҵ忡�� ���� ���� �޼ҵ� ���� �ÿ� ������ �������� ������ �� �ִ�.


// ���ٽ�
// ����޼ҵ��� ���� ǥ��
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

    // �Ű������� �������� ������ ���� �߻�
    autoCastPlus = delegate (int a, float b)
    {
        int result = a + (int)b;
        print(result);
    };

    // ���� �޼ҵ� �Ҵ翡�� �Ű����� ������ ���ʿ��� ���
    // ������ �����ϴ�.
    autoCastPlus += delegate 
    {
        print("Calc Finished!");
    };

    someFunc = delegate (int a)
    {
        // # string builder �� +�� ����
        StringBuilder sb = new StringBuilder();

        sb.Append("�Էµ� �Ķ���ʹ� ");
        sb.Append(a);
        sb.Append(" �Դϴ�.");

        return sb.ToString();
    };

    autoCastPlus?.Invoke(1, 2);

    // ���ٽ� ǥ�� ���
    someAction += () => { };

    // delegate Ű���� ��� => ��ȣ�� ���� ����޼ҵ� ���� ���.
    someFunc += (int a) => { return a + "is Integer"; };

    // �Ű������� �ڷ����� return Ű���� ���� ����
    someFunc += (a) => a + "is Integer";

    // �Ű������� �� ����� ��ȣ�� ���� ����
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
