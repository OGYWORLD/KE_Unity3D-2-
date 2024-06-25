using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillUpdate : MonoBehaviour
{
    public Image[] skillIcons;

    private void Update()
    {
        CheckCanOpen();
    }

    void CheckCanOpen()
    {
        for(int i = 0; i < SkillManager.instance.skillInfo.Count; i++)
        {
            // Paranet Check
            int conditionCnt = 0;
            for (int j = 0; j < SkillManager.instance.skillInfo[i].conditionSkills.Length; j++)
            {
                if (SkillManager.instance.skillInfo[SkillManager.instance.skillInfo[i].conditionSkills[j]].curSkillLevel >= SkillManager.instance.skillInfo[SkillManager.instance.skillInfo[i].conditionSkills[j]].skillLevel)
                {
                    conditionCnt++;
                }
            }

            // Check Can Open
            if (conditionCnt == SkillManager.instance.skillInfo[i].conditionSkills.Length)
            {
                Color color = skillIcons[i].color;
                color.a = 1f;
                skillIcons[i].color = color;
                SkillManager.instance.skillInfo[i].isOpen = true;
            }
        }
    }

}
