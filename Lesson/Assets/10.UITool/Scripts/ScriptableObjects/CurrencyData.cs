using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CurrencyType
{
    Coin,
    Food,
    Wood,
    Metal,
    Crystal
}

// �Լ� �Ǵ� ������ ȣ�� �� [�Ķ���� �̸�] = [��] ���·� �Ķ���� ������ ������� ���� ����
[CreateAssetMenu(menuName = "Scriptable Objects/Currency Data", fileName = "CurrencyData", order = 0)]
public class CurrencyData : ScriptableObject
{
    // ��ȭ �����͸� ����ȭ �� Scriptable Object
    public string currencyName;
    public Sprite iconSprite;
    public CurrencyType currencyType;
    public int maxCount;
}
