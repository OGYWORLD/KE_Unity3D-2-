using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CSkillManager : MonoBehaviour
{
    public static CSkillManager instance { get; private set; }

    public RectTransform skillPage;
    public RectTransform skillContents;

    public List<Bullet> bullets;

    public CSkillSlot startSlot;
    public CSkillSlot endSlot;

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

        
        for(int i = 0; i < bullets.Count; i++)
        {
            skillContents.GetChild(i).GetComponent<CSkillSlot>().curBullet = bullets[i];
        }
    }
}

[Serializable]
public class Bullet
{
    public Sprite iconSprite;
    public int bulletID;
    public int maxBullet;
    public int bulletDamage;
}