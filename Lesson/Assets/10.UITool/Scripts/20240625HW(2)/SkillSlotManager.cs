using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillSlotManager : MonoBehaviour
{
    public static SkillSlotManager instance { get; private set; }

    public RectTransform skillPage;
    public RectTransform skillContents;

    // skill info
    public List<SkillInfoInSlot> skillInfoInSlot;

    // skill slot info
    public SkillSlotInfo startSlot;
    public SkillSlotInfo endSlot;

    public GameObject leftSlotParent;
    public GameObject rightSlotParent;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }

        for (int i = 0; i < skillInfoInSlot.Count; i++)
        {
            skillContents.GetChild(i).GetComponent<SkillSlotInfo>().curInfo = skillInfoInSlot[i];
        }
    }

    private void Start()
    {

    }
}

[Serializable]
public class SkillInfoInSlot
{
    public Sprite iconSprite;
    public float coolTime;
    public bool isBeingCool;
}