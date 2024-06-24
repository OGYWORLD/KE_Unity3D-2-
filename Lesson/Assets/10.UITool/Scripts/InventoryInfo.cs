using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InventoryInfo : MonoBehaviour
{
    public enum Item
    {
        Coin,
        Meat,
        Crystal
    }
    
    public ItemInfo[] itemInfoes = new ItemInfo[Enum.GetValues(typeof(Item)).Length];

    public TextMeshProUGUI itemName;
    public TextMeshProUGUI itemInfo;

    void SetItemInfoText(ItemInfo item)
    {
        itemName.text = item.itemName;
        itemInfo.text = item.itemInfo;
    }

    public void OnClickButton(int n)
    {
        SetItemInfoText(itemInfoes[n]);
    }
}
