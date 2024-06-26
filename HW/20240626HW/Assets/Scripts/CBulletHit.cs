using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CBulletHit : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        CMonster monster = other.GetComponent<CMonster>();
        if(monster != null)
        {
            monster.Hit();
            gameObject.SetActive(false);
        }
    }
}
