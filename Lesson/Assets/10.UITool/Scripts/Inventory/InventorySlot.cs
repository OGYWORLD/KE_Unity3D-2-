using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

// ����Ƽ �̺�Ʈ �ڵ鷯 �������̽�
// ȣ�� ��ü: EventSystem Ŭ���� (Canvas ȣ�� ��, �ڵ� ȣ��Ǵ�)

public class InventorySlot : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler, IPointerEnterHandler, IPointerExitHandler
{
    // 
    public Image iconImage;

    // internal
    // �ϳ��� ������Ʈ ���� �ִ� �ٸ� Ÿ�Ե��� ������ �� �� �ִ�.
    // ������, �ٸ� �����(������Ʈ)������ ������ �Ұ��ϴ�.
    // ����Ƽ������ Inspector���� ������ �� �ǰ�, ��� �ٸ� ��ũ��Ʈ������ ������ ����
    // ���������� �� ������� ����
    // ������Ÿ�� �� ���� ������ �ʿ��� �� HideInInspector �Ӽ��� ��ü�Ͽ� Ȱ��
    internal Item item = null;

    private void Start()
    {
        Item = item;
    }

    // item �ʵ尡 null�� ��� false, null�� �ƴ� ��� true ��ȯ
    public bool hasItem { get { return item != null; } }

    public virtual Item Item
    { 
        get 
        { 
            return item;
        }

        set
        {
            // item set�� ��
            item = value;
            if(item == null)
            {
                // null�̸� = �������� ������ 
                iconImage.enabled = false;
            }
            else
            {
                iconImage.enabled = true;
                iconImage.sprite = item.iconSprite;
            }
        }
    }

    public virtual bool TrySwap(Item item)
    {
        if(item is Weapon && hasItem)
        {
            if (this.item is Weapon)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        return true;
    }

    // IDragHandler
    public void OnDrag(PointerEventData data)
    {
        // item�� ������ �Լ� ��ȯ
        if (false == hasItem)
        {
            return;
        }

        // �ش� ������Ʈ�� data�� ���������� �ű��
        iconImage.rectTransform.position = data.position;

        // RectTransform.position: ��ũ�� �󿡼��� ��ġ
    }

    // IBeginDragHandler
    public void OnBeginDrag(PointerEventData data)
    {
        // ������������ !��� �̷��� ���⵵ ��
        if(false == hasItem) // item�� ������ �Լ� ��ȯ
        {
            return;
        }

        // SetParent(): ���̾��Ű �� �θ� ��������
        // �Ķ���ͷ� null�� �Ҵ��� ��� �θ� ���� �� ������� �̵���.
        iconImage.rectTransform.SetParent(InventoryManager.instance.equipPage);

        // �巡�װ� ������ �� Iventory Manager���� 1�� ����(�� �ڽ�)�� ���� �������� ����
        InventoryManager.instance.selectedSlot = this;
    }

    // IEndDragHandler
    public void OnEndDrag(PointerEventData data)
    {
        // item�� ������ �Լ� ��ȯ
        if (false == hasItem)
        {
            return;
        }

        // �巡�װ� ���� ���� ������ ���� �ٸ� ��: focused slot != this
        // �巡�װ� ���� ���� �κ��丮 ������ ��: focused slot != null
        // = ��ȿ�� �巡���� ��!
        if (InventoryManager.instance.focusedSlot != this && InventoryManager.instance.focusedSlot != null)
        {
            // ��� ���Կ� �������� ���� �� = �������� �ű���� �ߴ�.
            InventorySlot targetSlot = InventoryManager.instance.focusedSlot;

            if (targetSlot.TrySwap(item)) // �������� �ִ� �������� �����ͼ�
            {
                // temp�� ��ȯ
                Item tempItem = targetSlot.Item;

                targetSlot.Item = item;

                this.Item = tempItem;
            }
        }

        print(InventoryManager.instance.focusedSlot);


        InventoryManager.instance.selectedSlot = null; // ������ ���� null

        // AnchoredPosition: ��Ŀ�κ����� ����� ��ġ
        // �θ��� ��ġ�� �� ��ġ�� �ű��.
        iconImage.rectTransform.SetParent(transform);

        // ��Ŀ �߽����� �� �� �ֵ��� Vector2.zero ����
        iconImage.rectTransform.anchoredPosition = Vector2.zero;
    }

    // ���콺 Ŀ���� UI��ҳ� ���� ������Ʈ�� ��� ������ ���� �� ȣ��
    public void OnPointerEnter(PointerEventData eventData)
    {
        InventoryManager.instance.focusedSlot = this;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        InventoryManager.instance.focusedSlot = null;
    }
}
