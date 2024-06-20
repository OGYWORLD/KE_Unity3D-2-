using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CText : MonoBehaviour
{
    const int INFO_NUM = 2;

    public Text[] namE = new Text[INFO_NUM];
    public Text[] info = new Text[INFO_NUM];
    public Text[] love = new Text[INFO_NUM];

    private void Update()
    {
        PrintText();
    }

    void PrintText()
    {
        for(int i = 0; i < INFO_NUM; i++)
        {
            namE[i].text = GameManager.instance.charas[i].m_name;
            info[i].text = GameManager.instance.charas[i].m_info;
            love[i].text = "" + GameManager.instance.charas[i].m_love;
        }
    }
}
