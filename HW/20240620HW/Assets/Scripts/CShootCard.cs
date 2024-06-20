using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CShootCard : MonoBehaviour
{
    public GameObject card;
    public Transform cardShootTrans;

    private const int TOTAL_CARD_NUM = 10;
    private GameObject[] cards = new GameObject[TOTAL_CARD_NUM];

    private int cardIdx = 0;

    private void Start()
    {
        // Instantiate
        for(int i = 0; i < cards.Length; i++)
        {
            cards[i] = Instantiate(card, cardShootTrans.position, Quaternion.identity);
            cards[i].SetActive(false);
        }
    }

    private void Update()
    {
        ShootCard();
    }

    void ShootCard()
    {
        if(!GameManager.instance.isTab && Input.GetMouseButtonDown(0))
        {
            CardFly();
        }
    }

    void CardFly()
    {
        cards[cardIdx].transform.position = cardShootTrans.position;
        cards[cardIdx].SetActive(true);
        cardIdx++;

        if (cardIdx >= TOTAL_CARD_NUM)
        {
            cardIdx = 0;
        }
    }
}
