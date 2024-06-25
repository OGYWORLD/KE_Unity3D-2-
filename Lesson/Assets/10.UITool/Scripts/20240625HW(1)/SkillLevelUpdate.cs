using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillLevelUpdate : MonoBehaviour
{
    public Text[] skillLVText;

    private void Update()
    {
        SkillLVUpdate();
    }

    public void SkillLVUpdate()
    {
        for(int i = 0; i < skillLVText.Length; i++)
        {
            skillLVText[i].text = "" + SkillManager.instance.skillInfo[i].curSkillLevel;
        }
    }

    public void Upgrade(int n)
    {
        SkillManager.instance.skillInfo[n].curSkillLevel++;

        if(SkillManager.instance.skillInfo[n].curSkillLevel > 20)
        {
            SkillManager.instance.skillInfo[n].curSkillLevel = 20;
        }
    }
}
