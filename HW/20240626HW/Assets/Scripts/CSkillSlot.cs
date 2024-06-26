using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CSkillSlot : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler, IPointerEnterHandler, IPointerExitHandler
{
    public Image iconImage;
    public bool isSetSlot;
    public bool isCanUse = false;

    public Bullet curBullet { get; set; } = null;

    private void Start()
    {
        SetSkillIcon();
    }

    private void Update()
    {
        CheckCanUse();
    }

    void CheckCanUse()
    {
        if(GameManager.instance.playerInfo.level >= curBullet.bulletID + 1)
        {
            Color color = iconImage.color;
            color.a = 1f;
            iconImage.color = color;

            isCanUse = true;
        }
    }

    public void SetSkillIcon()
    {
        if(curBullet != null)
        {
            Color color = iconImage.color;
            color.a = 0.5f;
            iconImage.color = color;

            iconImage.sprite = curBullet.iconSprite;
            iconImage.enabled = true;
        }
        else
        {
            iconImage.enabled = false;
        }
    }

    public void OnBeginDrag(PointerEventData data)
    {
        if(!isCanUse) { return; }

        CSkillManager.instance.startSlot = this;

        iconImage.rectTransform.SetParent(CSkillManager.instance.skillPage);
    }

    public void OnDrag(PointerEventData data)
    {
        if (!isCanUse) { return; }

        iconImage.rectTransform.position = data.position;
    }

    public void OnEndDrag(PointerEventData data)
    {
        if (!isCanUse) { return; }

        // 이상한 곳에 드롭했을 때
        if (CSkillManager.instance.endSlot == null || this.curBullet == null || CSkillManager.instance.startSlot.isSetSlot)
        {
            iconImage.rectTransform.SetParent(transform);
            iconImage.rectTransform.anchoredPosition = Vector2.zero;

            return;
        }

        // 목적지가 장착 슬롯
        if (CSkillManager.instance.endSlot.isSetSlot)
        {
            GameManager.instance.playerInfo.curBulletPrefab = curBullet.bulletID;
            print(curBullet.bulletID);
            GameManager.instance.playerInfo.bulletDamage = curBullet.bulletDamage;
        }

        // 바꿔치기
        Bullet temp = CSkillManager.instance.startSlot.curBullet;
        this.curBullet = CSkillManager.instance.endSlot.curBullet;
        CSkillManager.instance.endSlot.curBullet = temp;

        // 바꿔친 내용으로 iconSprite 업데이트
        CSkillManager.instance.endSlot.SetSkillIcon();
        SetSkillIcon();

        iconImage.rectTransform.SetParent(transform);
        iconImage.rectTransform.anchoredPosition = Vector2.zero;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (!isCanUse) { return; }

        CSkillManager.instance.endSlot = this;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (!isCanUse) { return; }

        CSkillManager.instance.endSlot = null;
    }
}
