using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEquip : MonoBehaviour
{
    public Transform[] hands;
    private Weapon[] weapons = new Weapon[2];
    private GameObject[] weaponObjs = new GameObject[2];

    public void EquipWeapon(int index, Weapon weapon)
    {
        // �� ���� �ʰ��ϴ� �ε��� ��ȿó��
        if(index > weapons.Length)
        {
            return;
        }

        // ������ ����
        weapons[index] = weapon;

        //�����ϰ� �ִ� �������� �ִٸ�
        if (weaponObjs[index] != null)
        {
            Destroy(weaponObjs[index]);
            weaponObjs[index] = null;
        }

        // �Ű����� weapon�� null�� �ƴ϶��
        // ���� ������Ʈ ����
        if(weapon != null)
        {
            weaponObjs[index] = Instantiate(weapon.equipPrefab, hands[index]);
        }
    }


}
