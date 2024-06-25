using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CLevelInfo : MonoBehaviour
{
    public Text level;

    private void Update()
    {
        level.text = "" + SkillManager.instance.level;
    }

    public void LevelUp()
    {
        SkillManager.instance.level++;

        print("Level Up!");
    }
}
