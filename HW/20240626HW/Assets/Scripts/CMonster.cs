using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CMonster : MonoBehaviour, IHitable
{
    public GameObject item;
    public int hp { get; set; } = 10;
    public int exp { get; set; } = 3;

    private void Start()
    {
        item.SetActive(false);
    }

    public void Hit()
    {
        hp -= GameManager.instance.playerInfo.bulletDamage;

        if(hp <= 0)
        {
            GameManager.instance.playerInfo.exp += exp;
            CheckDead();
        }
    }

    void CheckDead()
    {
        item.SetActive(true);
        gameObject.SetActive(false);
    }
}
