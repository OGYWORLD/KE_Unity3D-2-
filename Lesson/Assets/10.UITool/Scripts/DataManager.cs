using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserData
{
    // Enum.GetValues : ������ Ÿ�� ���� ��� ���θ� �������� �Լ�
    private int[] currencyArray = new int[Enum.GetValues(typeof(CurrencyType)).Length];

    public int this[CurrencyType type]
    {
        get
        {
            return currencyArray[(int)type];
        }

        set
        {
            currencyArray[(int)type] = value;
        }
    }
}

public class DataManager : MonoBehaviour
{
    public List<CurrencyData> currencyDataList;
    public UICurrencyList currencyList;

    public static DataManager instance { get; private set; }

    public UserData userData = new UserData();

    // delegate
    public Action<CurrencyType, int> onCurrencyAmountChange;



    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }   
    }

    private void Start()
    {
        /*
        foreach(CurrencyData c in currencyDataList)
        {
            print(c.currencyName);
        }
        */

        currencyList.Initalize();

    }

    public void AddCurrency(int param)
    {
        CurrencyType type = (CurrencyType)param;

        userData[type]++;

        onCurrencyAmountChange?.Invoke(type, userData[type]);

        print($"{type} ��� : {userData[type]}");
    }
}
