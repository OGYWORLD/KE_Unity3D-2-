using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EquipSlot : InventorySlot
{
    public Image defaultIconImage; // 아이템을 장착하지 않았을 때 보여줄 아이콘
    public PlayerEquip playerEquip;
    public int handIndex;

    // Set item을 할 때
    // item Propterty에 값을 대입할 때의 로직을 수정

    public override Item Item {

        get => base.item;
      
        set
        {
            if(value is Weapon)
            {
                // 넣으려는 아이템이 무기면
                playerEquip.EquipWeapon(handIndex, value as Weapon);
                defaultIconImage.enabled = false;

                base.Item = value;
            }
            else if(value == null) // 무기를 해제하려 할 때 null을 대입
            {
                playerEquip.EquipWeapon(handIndex, null);
                defaultIconImage.enabled = true;
                base.Item = value;
            }
        }
            
    }

    public override bool TrySwap(Item item)
    {
        // 무기이거나 item이 null이면 true
        // 무기끼리 바뀌거나 빈공간일때만 옮겨질 수 있단 뜻
        if(item is Weapon || item == null)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

}
