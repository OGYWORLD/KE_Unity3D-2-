using System; // ! warning !
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DotnetDelegateTest : MonoBehaviour
{
    // delegate�� ����� �� ���� ������ �������
    // �̰� �� ������

    // Action ��������Ʈ:
    // �⺻���� ������ ��������Ʈ�� .Net���� �⺻������ �����Ͽ� ����
    // ��ȯ���� ���� �޼ҵ�
    Action action;

    // Action ��������Ʈ�� ���׸� Ÿ���� �Ķ���� Ÿ���� ����
    Action<int> actionWithIntParam;
    Action<float, float> actionWithTwoFloatParam; 

    // Func ��������Ʈ :
    // ��ȯ���� �ִ� ������ ��������Ʈ�� .NET���� �⺻������ �����Ͽ� ����
    // ��ȯ���� �־���ϱ� ������ ���׸��� �� ���� ������ �߻���
    Func<object> func;

    // Func ��������Ʈ�� ���׸� Ÿ�� �� �� ���� ��ȯ��, �� ������ �Ķ���� Ÿ�� ����
    Func<string, int> parseFunc;


    // Predicate ��������Ʈ :
    // ��ȯ���� bool�̰�, 1�� �̻��� �Ķ���Ͱ� �ִ� ������ ��������Ʈ
    Predicate<float> predicate;
    Predicate<int> predicateEven;

    private void Start()
    {
        action = SomeAction;
        actionWithIntParam = SomeActionWithParam;
        parseFunc = Parse;

        // Func<float, bool>�� �Ȱ����ٵ� �� predicate�� �����ϴ°�
        // Predicate ��� ����
        // predicate�� ���, �Ϻ� �÷��� �Լ��� ���� �Ǵ��� ���� ���Ǹ�
        // Bool�� �����ϴ� �Լ� ���·� �ޱ� ���� Ȱ���
        // # �׳� ��ȯ���� bool�� Func ���� �ȵ�?
        List<int> intList = new List<int>();

        intList.Add(5);
        intList.Add(6);
        intList.Add(8);
        intList.Add(9);
        intList.Add(10);

        // intList���� ¦���� �̾ƿ��� �ʹ�.
        predicateEven = IsEven;

        // predicate ���
        List<int> evenList = intList.FindAll(predicateEven);

        foreach(int i in evenList)
        {
            print(i);
        }

        // ���� �޼ҵ� ���
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
        // a�� ���� �ߴٰ� ħ
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
