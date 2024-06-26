using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CPlayerInfoText : MonoBehaviour
{
    public Text curHP;
    public Text maxHP;
    public Text curEXP;
    public Text neededEXP;
    public Text curBullet;
    public Text maxBullet;

    private void Update()
    {
        PrintCharacInfoText();
    }

    void PrintCharacInfoText()
    {
        curHP.text = "" + GameManager.instance.playerInfo.curHP;
        maxHP.text = "" + GameManager.instance.playerInfo.maxHP;
        curEXP.text = "" + GameManager.instance.playerInfo.exp;
        neededEXP.text = "" + GameManager.instance.playerInfo.level * 5;
        curBullet.text = "" + GameManager.instance.playerInfo.curBullet;
        maxBullet.text = "" + GameManager.instance.playerInfo.maxBullet;
    }
}
