using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SkillSlotInfo : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler, IPointerEnterHandler, IPointerExitHandler
{
    public Image iconImage;
    public bool isSetSlot;

    public SkillInfoInSlot curInfo { get; set; } = null;

    private void Start()
    {
        SetSkillIconInfo();
    }

    public void SetSkillIconInfo()
    {

        if (curInfo != null)
        {
            iconImage.sprite = curInfo.iconSprite;
            iconImage.enabled = true;
        }
        else
        {
            iconImage.enabled = false;
        }
    }

    public void OnBeginDrag(PointerEventData data)
    {
        SkillSlotManager.instance.startSlot = this;

        iconImage.rectTransform.SetParent(SkillSlotManager.instance.skillPage);
    }

    public void OnDrag(PointerEventData data)
    {
        iconImage.rectTransform.position = data.position;
    }

    public void OnEndDrag(PointerEventData data)
    {
        // �̻��� ���� ������� ��
        if(SkillSlotManager.instance.endSlot == null || this.curInfo == null)
        {
            iconImage.rectTransform.SetParent(transform);
            iconImage.rectTransform.anchoredPosition = Vector2.zero;

            return;
        }

        // �������� ���� ����
        if(!curInfo.isBeingCool && SkillSlotManager.instance.endSlot.isSetSlot)
        {
            SkillSlotManager.instance.endSlot.curInfo = this.curInfo;

            // ��Ÿ�� ����
            CoolTime();
        }
        else if(this.isSetSlot) // ��������
        {
            this.curInfo = null;
        }
        else if(!curInfo.isBeingCool && !this.isSetSlot && !SkillSlotManager.instance.endSlot.isSetSlot)
        {
            // �ٲ�ġ��
            SkillInfoInSlot temp = SkillSlotManager.instance.startSlot.curInfo;
            this.curInfo = SkillSlotManager.instance.endSlot.curInfo;
            SkillSlotManager.instance.endSlot.curInfo = temp;
        }

        // �ٲ�ģ �������� iconSprite ������Ʈ
        SkillSlotManager.instance.endSlot.SetSkillIconInfo();
        SetSkillIconInfo();

        iconImage.rectTransform.SetParent(transform);
        iconImage.rectTransform.anchoredPosition = Vector2.zero;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        SkillSlotManager.instance.endSlot = this;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        SkillSlotManager.instance.endSlot = null;
    }

    void CoolTime()
    {
        this.curInfo.isBeingCool = true;

        iconImage.fillAmount = 0f;
        StartCoroutine(SetCoolTime());
    }

    IEnumerator SetCoolTime()
    {
        float sumTime = 0;
        
        while(sumTime <= curInfo.coolTime)
        {
            iconImage.fillAmount += sumTime / curInfo.coolTime * 0.001f;

            sumTime += Time.deltaTime;
            print(sumTime);

            yield return null;
        }

        this.curInfo.isBeingCool = false;
        yield break;
    }
}
