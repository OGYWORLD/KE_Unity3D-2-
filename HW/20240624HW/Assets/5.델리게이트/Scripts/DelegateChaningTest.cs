using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelegateChaningTest : MonoBehaviour
{
    private OtherDelegateMethod otherDelegate;

    private void Start()
    {
        // �߰��� = ������ ����ϸ� ������ �����յƴ� delegate�� �����
        // delegate instance�� ���� �����ؼ� ���ԵǴ� ��
        otherDelegate = new OtherDelegateMethod(MessageTrim);
        otherDelegate += new OtherDelegateMethod(MessageAllTrim);
        otherDelegate += new OtherDelegateMethod(MessageDuplicate);
        otherDelegate += new OtherDelegateMethod(MessageLower);

        otherDelegate?.Invoke("Hello World");

        otherDelegate -= new OtherDelegateMethod(MessageAllTrim);

        // delegate chain�� ������ stack���� ������
        // ���� �޼ҵ� �߿����� ���� ����� ���ŵȴ�.
        // # �ٵ� delegate �ν��Ͻ��� �Ҵ�Ǵ� ������ stack�� �ƴ��ݾ�
    }

    private void MessageTrim(string message)
    {
        // Trim: ���ڿ����� �� �� ������ �����Ͽ� ��ȯ�ϴ� �޼ҵ�
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
