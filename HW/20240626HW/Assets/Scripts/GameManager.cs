using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance { get; private set; }

    // player Info
    public PlayerInfo playerInfo;

    public bool isOpenTab = false;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}

[Serializable]
public class PlayerInfo
{
    public int curHP = 20;
    public int maxHP = 20;
    public int exp = 0;
    public int level = 1;

    //0: small, 1: middle, 2: Large
    public int curBulletPrefab = 0;
    public int maxBullet = 5;
    public int curBullet = 5;
    public int bulletDamage = 5;
}