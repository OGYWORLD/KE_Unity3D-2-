using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartIsCoroutine : MonoBehaviour
{
    // Start �޽��� �Լ��� ��ȯ���� IEnumerator�� ��� �ڵ����� �ڷ�ƾ�� �ȴ�.
    IEnumerator Start()
    {
        print(@"""start"" started.");
        yield return new WaitForSeconds(5f);
        print(@"""start"" end.");
    }
}
