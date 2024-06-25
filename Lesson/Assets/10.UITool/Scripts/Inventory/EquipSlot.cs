using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EquipSlot : InventorySlot
{
    public Image defaultIconImage; // �������� �������� �ʾ��� �� ������ ������
    public PlayerEquip playerEquip;
    public int handIndex;

    // Set item�� �� ��
    // item Propterty�� ���� ������ ���� ������ ����

    public override Item Item {

        get => base.item;
      
        set
        {
            if(value is Weapon)
            {
                // �������� �������� �����
                playerEquip.EquipWeapon(handIndex, value as Weapon);
                defaultIconImage.enabled = false;

                base.Item = value;
            }
            else if(value == null) // ���⸦ �����Ϸ� �� �� null�� ����
            {
                playerEquip.EquipWeapon(handIndex, null);
                defaultIconImage.enabled = true;
                base.Item = value;
            }
        }
            
    }

    public override bool TrySwap(Item item)
    {
        // �����̰ų� item�� null�̸� true
        // ���Ⳣ�� �ٲ�ų� ������϶��� �Ű��� �� �ִ� ��
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
