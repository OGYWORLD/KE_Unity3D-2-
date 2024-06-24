using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UICurrencyList : MonoBehaviour
{
    // currency element가 생성되어 content의 자식 객체로 만들어야 한다.
    public Transform content; //  Scroll view List 내부 Transform
    public UICurrencyElement currencyElementPrefab; // element UI 요소를 프리팹으로 참조하여 생성

    // 오브젝트가 비활성화되어도 호출되는 Awake
    private void Awake()
    {
    }

    public void Initalize()
    {
        foreach (CurrencyData data in DataManager.instance.currencyDataList)
        {
            // Currency Elements 생성
            Instantiate(currencyElementPrefab, content).SetData(data);
        }
    }
}
