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
        // 왼 오를 초과하는 인덱스 유효처리
        if(index > weapons.Length)
        {
            return;
        }

        // 아이템 착용
        weapons[index] = weapon;

        //착용하고 있던 아이템이 있다면
        if (weaponObjs[index] != null)
        {
            Destroy(weaponObjs[index]);
            weaponObjs[index] = null;
        }

        // 매개변수 weapon이 null이 아니라면
        // 무기 오브젝트 생성
        if(weapon != null)
        {
            weaponObjs[index] = Instantiate(weapon.equipPrefab, hands[index]);
        }
    }


}
