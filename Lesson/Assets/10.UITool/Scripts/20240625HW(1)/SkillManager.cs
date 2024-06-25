using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillManager : MonoBehaviour
{
    public static SkillManager instance { get; private set; }
    public int level { get; set; } = 1;

    public List<SkillInfo> skillInfo = new List<SkillInfo>();

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(instance);
        }

    }
}

[Serializable]
public class SkillInfo
{
    public int curSkillLevel;
    public int skillLevel;
    public int[] conditionSkills;
    public bool isOpen;
}