using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// global namesapace
// �ٸ� ��ũ��Ʈ���� ���� ����
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
        // # �� �� ���� �ٸ� ����
        // ��Ȯ�� �ʱ�ȭ�� new Ű���带 ����ϴ� ���ε�
        // �׳� �Ʒ�ó�� ������ ���� �Ͻ������� ����
        //someDelegate = new SomeDelegateMethod(Plus);
        someDelegate = Plus;
        someDelegate = Minus;
        someDelegate = Multiple;
        someDelegate = Divide;

        //otherDelegate = PrintMessage;

        // print�� �Ű������� object
        // �Ű������� �Ͻ��� ĳ������ ������ ��쿡�� ����
        otherDelegate = print;
        

        // delegate�� Ŭ�����̴�.
        // �� �Ʒ��� ���� �ǹ�
        //otherDelegate("");
        //otherDelegate.Invoke("");
        // # ��������Ʈ�� Ŭ���� �÷� ���°� �ͼ����� ����
        // # ���ο� ������ �޼ҵ忡�� ������ �ִ��� �ñ�

        // Null ���Ǻ� ������
        // # ����ǥ�� ������ null�� ��� �������� ����
        // # ���� �ƹ��͵� �� ���� ���� ���, -> �ƹ��͵� �� ��
        // # null�� ���� ���� ��� -> �ƹ��͵� �� ��
        // # ���������� delegate�� ���� ���� ��� -> ������� �� ��
        // # �� �����?
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
