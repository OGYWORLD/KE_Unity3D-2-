using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CBuyItem : MonoBehaviour
{
    public void BuyArrow()
    {
        InvenManager.instance.items.Add(new InvenManager.Item(InvenManager.EITEMS.ARROW, true, true, false, InvenManager.instance.itemListIdx));
        InvenManager.instance.itemListIdx++;
    }

    public void BuyAxes()
    {
        InvenManager.instance.items.Add(new InvenManager.Item(InvenManager.EITEMS.AXE, true, false, false, InvenManager.instance.itemListIdx));
        InvenManager.instance.itemListIdx++;
    }

    public void BuyBack()
    {
        InvenManager.instance.items.Add(new InvenManager.Item(InvenManager.EITEMS.BACK, false, false, false, InvenManager.instance.itemListIdx));
        InvenManager.instance.itemListIdx++;
    }

    public void BuyCoin()
    {
        InvenManager.instance.items.Add(new InvenManager.Item(InvenManager.EITEMS.COIN, false, true, false, InvenManager.instance.itemListIdx));
        InvenManager.instance.itemListIdx++;
    }
}
