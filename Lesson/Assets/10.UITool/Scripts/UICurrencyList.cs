using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UICurrencyList : MonoBehaviour
{
    // currency element�� �����Ǿ� content�� �ڽ� ��ü�� ������ �Ѵ�.
    public Transform content; //  Scroll view List ���� Transform
    public UICurrencyElement currencyElementPrefab; // element UI ��Ҹ� ���������� �����Ͽ� ����

    // ������Ʈ�� ��Ȱ��ȭ�Ǿ ȣ��Ǵ� Awake
    private void Awake()
    {
    }

    public void Initalize()
    {
        foreach (CurrencyData data in DataManager.instance.currencyDataList)
        {
            // Currency Elements ����
            Instantiate(currencyElementPrefab, content).SetData(data);
        }
    }
}
