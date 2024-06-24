using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Objects/Item Data", fileName = "ItemData", order = 0)]
public class ItemInfo : ScriptableObject
{
    public string itemName;
    public string itemInfo;
}
