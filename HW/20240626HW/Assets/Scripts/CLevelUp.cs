using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CLevelUp : MonoBehaviour
{
    private void Update()
    {
        LevelUP();
    }

    void LevelUP()
    {
        if(GameManager.instance.playerInfo.exp >= GameManager.instance.playerInfo.level * 5)
        {
            GameManager.instance.playerInfo.exp = GameManager.instance.playerInfo.exp - GameManager.instance.playerInfo.level * 5;
            GameManager.instance.playerInfo.level++;

            GameManager.instance.playerInfo.maxHP += 10;
            GameManager.instance.playerInfo.curHP = GameManager.instance.playerInfo.maxHP;
        }
    }
}
