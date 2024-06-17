using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InvenManager : MonoBehaviour
{
    public static InvenManager instance;

    public Transform PannelParent;

    const int ITEM_NUM = 4;

    public enum EITEMS
    {
        ARROW,
        AXE,
        BACK,
        COIN
    }

    public GameObject[] itemObj = new GameObject[ITEM_NUM];

    public struct Item
    {
        public readonly EITEMS m_name { get; }
        public readonly bool m_isWeapon { get; }
        public readonly bool m_isOnce { get; }
        public bool m_isOpen { get; set; }

        public Item(EITEMS _i, bool _w, bool _o, bool _p)
        {
            m_name = _i;
            m_isWeapon = _w;
            m_isOnce = _o;
            m_isOpen = _p;
        }
    }

    public List<Item> items;

    private void Awake()
    {
        // For Singleton
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }

        // Set List
        items = new List<Item>();

        //FOR DEBUG!
        items.Add(new Item(EITEMS.ARROW, true, true, false));
    }

    private void Update()
    {
        
    }

    public void ShowItems()
    {
        for(int i = 0; i < items.Count; i++)
        {
            if(!items[i].m_isOpen)
            {
                GameObject perItem = Instantiate(itemObj[(int)items[i].m_name]);

                perItem.transform.SetParent(PannelParent);

                items[i] = new Item(items[i].m_name, items[i].m_isWeapon, items[i].m_isOnce, true);
            }
        }
    }
}
