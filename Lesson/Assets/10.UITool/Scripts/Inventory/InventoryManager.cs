using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager instance { get; private set; }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public RectTransform equipPage;
    public RectTransform inventoryContents;

    public int inventorySlotCount; // 생성할 슬롯 개수
    public InventorySlot inventorySlotPrefab; // 슬롯 프리팹
    private List<InventorySlot> inventorySlots = new(); // 슬롯 리스트


    // 확인용
    [Space(20)] // 인스펙터 상, 공백주기
    public InventorySlot focusedSlot; // 도착지점 슬롯
    public InventorySlot selectedSlot; // 선택한 슬롯

    public List<Weapon> tempWeapons;
    public List<Item> tempItems = new List<Item>();

    private void Start()
    {
        // tempItems 리스트에 tempWeapons 요소들을 0번 인덱스부터 삽입
        tempItems.InsertRange(0, tempWeapons);

        // 임시 아이템을 inventory content 내의 슬롯에 한 개씩 할당.
        for(int i = 0; i < tempItems.Count; i++)
        {
            inventoryContents.GetChild(i).GetComponent<InventorySlot>().Item = tempItems[i];
        }
    }
}

[Serializable]
public class Item
{
    public Sprite iconSprite; // 아이템 아이콘
    public string name; // 아이템 이름
    public string desc; // 아이템 설명
}

[Serializable]
public class Weapon : Item
{
    public float damage; // 데미지
    public GameObject equipPrefab; // 착용시 생성할 아이템 장비 프리팹
}
