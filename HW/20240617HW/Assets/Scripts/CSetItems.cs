using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CSetItems : MonoBehaviour
{
    Predicate<InvenManager.Item> predicate;
    
    public Transform PannelParent;

    public void ShowWeapon()
    {
        predicate = isWeapon;
        List<InvenManager.Item> weaponList = InvenManager.instance.items.FindAll(predicate);

        predicate = isNotWeapon;
        List<InvenManager.Item> notWeaponList = InvenManager.instance.items.FindAll(predicate);

        for(int i = 0; i < weaponList.Count; i++)
        {
            Image itemButton = PannelParent.GetChild(weaponList[i].m_idx).GetComponent<Button>().image;
            Color whole = itemButton.color;
            whole.a = 0.5f;
            itemButton.color = whole;
        }
        for (int i = 0; i < notWeaponList.Count; i++)
        {
            Image itemButton = PannelParent.GetChild(notWeaponList[i].m_idx).GetComponent<Button>().image;
            Color whole = itemButton.color;
            whole.a = 1.0f;
            itemButton.color = whole;
        }
    }

    public void ShowOnce()
    {
        predicate = isOnce;
        List<InvenManager.Item> onceList = InvenManager.instance.items.FindAll(predicate);

        predicate = isNotOnce;
        List<InvenManager.Item> notOnceList = InvenManager.instance.items.FindAll(predicate);

        for (int i = 0; i < onceList.Count; i++)
        {
            Image itemButton = PannelParent.GetChild(onceList[i].m_idx).GetComponent<Button>().image;
            Color whole = itemButton.color;
            whole.a = 0.5f;
            itemButton.color = whole;
        }
        for (int i = 0; i < notOnceList.Count; i++)
        {
            Image itemButton = PannelParent.GetChild(notOnceList[i].m_idx).GetComponent<Button>().image;
            Color whole = itemButton.color;
            whole.a = 1.0f;
            itemButton.color = whole;
        }
    }

    public void ShowETC()
    {
        predicate = isNotWeapon;
        List<InvenManager.Item> weaponList = InvenManager.instance.items.FindAll(predicate);

        predicate = isWeapon;
        List<InvenManager.Item> notWeaponList = InvenManager.instance.items.FindAll(predicate);

        for (int i = 0; i < weaponList.Count; i++)
        {
            Image itemButton = PannelParent.GetChild(weaponList[i].m_idx).GetComponent<Button>().image;
            Color whole = itemButton.color;
            whole.a = 0.5f;
            itemButton.color = whole;
        }
        for (int i = 0; i < notWeaponList.Count; i++)
        {
            Image itemButton = PannelParent.GetChild(notWeaponList[i].m_idx).GetComponent<Button>().image;
            Color whole = itemButton.color;
            whole.a = 1.0f;
            itemButton.color = whole;
        }
    }

    public void ShowItem()
    {
        predicate = isNotOnce;
        List<InvenManager.Item> onceList = InvenManager.instance.items.FindAll(predicate);

        predicate = isOnce;
        List<InvenManager.Item> notOnceList = InvenManager.instance.items.FindAll(predicate);

        for (int i = 0; i < onceList.Count; i++)
        {
            Image itemButton = PannelParent.GetChild(onceList[i].m_idx).GetComponent<Button>().image;
            Color whole = itemButton.color;
            whole.a = 0.5f;
            itemButton.color = whole;
        }
        for (int i = 0; i < notOnceList.Count; i++)
        {
            Image itemButton = PannelParent.GetChild(notOnceList[i].m_idx).GetComponent<Button>().image;
            Color whole = itemButton.color;
            whole.a = 1.0f;
            itemButton.color = whole;
        }
    }


    bool isWeapon(InvenManager.Item item)
    {
        bool result = !item.m_isWeapon;
        return result;
    }

    bool isNotWeapon(InvenManager.Item item)
    {
        return item.m_isWeapon;
    }

    bool isOnce(InvenManager.Item item)
    {
        bool result = !item.m_isOnce;
        return result;
    }

    bool isNotOnce(InvenManager.Item item)
    {
        return item.m_isOnce;
    }
}
