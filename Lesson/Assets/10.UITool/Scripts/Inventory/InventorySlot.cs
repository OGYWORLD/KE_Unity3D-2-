using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

// 유니티 이벤트 핸들러 인터페이스
// 호출 주체: EventSystem 클래스 (Canvas 호출 시, 자동 호출되는)

public class InventorySlot : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler, IPointerEnterHandler, IPointerExitHandler
{
    // 
    public Image iconImage;

    // internal
    // 하나의 프로젝트 내에 있는 다른 타입들이 엑세스 할 수 있다.
    // 하지만, 다른 어셈블리(프로젝트)에서는 접근이 불가하다.
    // 유니티에서는 Inspector에서 참조가 안 되고, 대신 다른 스크립트에서는 접근이 가능
    // 현업에서는 잘 사용하지 않음
    // 프로토타입 등 빠른 구현이 필요할 때 HideInInspector 속성을 대체하여 활용
    internal Item item = null;

    private void Start()
    {
        Item = item;
    }

    // item 필드가 null일 경우 false, null이 아닐 경우 true 반환
    public bool hasItem { get { return item != null; } }

    public virtual Item Item
    { 
        get 
        { 
            return item;
        }

        set
        {
            // item set할 때
            item = value;
            if(item == null)
            {
                // null이면 = 아이템이 없으면 
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
        // item이 없으면 함수 반환
        if (false == hasItem)
        {
            return;
        }

        // 해당 오브젝트를 data의 포지션으로 옮기기
        iconImage.rectTransform.position = data.position;

        // RectTransform.position: 스크린 상에서의 위치
    }

    // IBeginDragHandler
    public void OnBeginDrag(PointerEventData data)
    {
        // 가독성때문에 !대신 이렇게 쓰기도 함
        if(false == hasItem) // item이 없으면 함수 반환
        {
            return;
        }

        // SetParent(): 하이어라키 상 부모를 지정해줌
        // 파라미터로 null을 할당할 경우 부모 없이 최 상단으로 이동함.
        iconImage.rectTransform.SetParent(InventoryManager.instance.equipPage);

        // 드래그가 시작할 때 Iventory Manager에게 1개 슬롯(나 자신)을 선택 슬롯으로 저장
        InventoryManager.instance.selectedSlot = this;
    }

    // IEndDragHandler
    public void OnEndDrag(PointerEventData data)
    {
        // item이 없으면 함수 반환
        if (false == hasItem)
        {
            return;
        }

        // 드래그가 끝난 곳이 시작한 곳과 다를 때: focused slot != this
        // 드래그가 끝난 곳이 인벤토리 슬롯일 때: focused slot != null
        // = 유효한 드래그일 때!
        if (InventoryManager.instance.focusedSlot != this && InventoryManager.instance.focusedSlot != null)
        {
            // 대상 슬롯에 아이템이 없을 때 = 아이템을 옮기려고 했다.
            InventorySlot targetSlot = InventoryManager.instance.focusedSlot;

            if (targetSlot.TrySwap(item)) // 도착지에 있는 아이템을 가져와서
            {
                // temp로 교환
                Item tempItem = targetSlot.Item;

                targetSlot.Item = item;

                this.Item = tempItem;
            }
        }

        print(InventoryManager.instance.focusedSlot);


        InventoryManager.instance.selectedSlot = null; // 선택한 슬롯 null

        // AnchoredPosition: 앵커로부터의 상대적 위치
        // 부모의 위치를 내 위치로 옮긴다.
        iconImage.rectTransform.SetParent(transform);

        // 앵커 중심으로 갈 수 있도록 Vector2.zero 대입
        iconImage.rectTransform.anchoredPosition = Vector2.zero;
    }

    // 마우스 커서가 UI요소나 게임 오브젝트의 경계 안으로 들어올 때 호출
    public void OnPointerEnter(PointerEventData eventData)
    {
        InventoryManager.instance.focusedSlot = this;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        InventoryManager.instance.focusedSlot = null;
    }
}
