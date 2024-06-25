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

    public int inventorySlotCount; // ������ ���� ����
    public InventorySlot inventorySlotPrefab; // ���� ������
    private List<InventorySlot> inventorySlots = new(); // ���� ����Ʈ


    // Ȯ�ο�
    [Space(20)] // �ν����� ��, �����ֱ�
    public InventorySlot focusedSlot; // �������� ����
    public InventorySlot selectedSlot; // ������ ����

    public List<Weapon> tempWeapons;
    public List<Item> tempItems = new List<Item>();

    private void Start()
    {
        // tempItems ����Ʈ�� tempWeapons ��ҵ��� 0�� �ε������� ����
        tempItems.InsertRange(0, tempWeapons);

        // �ӽ� �������� inventory content ���� ���Կ� �� ���� �Ҵ�.
        for(int i = 0; i < tempItems.Count; i++)
        {
            inventoryContents.GetChild(i).GetComponent<InventorySlot>().Item = tempItems[i];
        }
    }
}

[Serializable]
public class Item
{
    public Sprite iconSprite; // ������ ������
    public string name; // ������ �̸�
    public string desc; // ������ ����
}

[Serializable]
public class Weapon : Item
{
    public float damage; // ������
    public GameObject equipPrefab; // ����� ������ ������ ��� ������
}
