using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CInven : MonoBehaviour
{
    public enum Item
    {
        HealItem
    }

    // 0: HealItem
    public Sprite[] itemSprite;

    public List<int> getItems = new List<int>();

    public Image[] slotImage;

    private void Update()
    {
        SetImage();
    }

    void SetImage()
    {
        for(int i = 0; i < getItems.Count; i++)
        {
            slotImage[i].sprite = itemSprite[getItems[i]];
            slotImage[i].enabled = true;
        }
    }
}
