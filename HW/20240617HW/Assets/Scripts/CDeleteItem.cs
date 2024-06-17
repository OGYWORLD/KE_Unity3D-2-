using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CDeleteItem : MonoBehaviour
{
    public void OnClickRemove()
    {
        InvenManager.instance.itemListIdx--;
        InvenManager.instance.items.RemoveAt(transform.GetSiblingIndex());
        Destroy(gameObject);
    }
}
