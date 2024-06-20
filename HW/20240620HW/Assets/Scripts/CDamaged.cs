using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CDamaged : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        print("!");
        if(other.CompareTag("Card"))
        {
            other.gameObject.SetActive(false);

            if(gameObject.CompareTag("Amy"))
            {
                GameManager.instance.charas[0].m_love -= 10;
                if(GameManager.instance.charas[0].m_love < 0)
                {
                    GameManager.instance.charas[0].m_love = 0;
                }
            }
            else if(gameObject.CompareTag("Boss"))
            {
                GameManager.instance.charas[1].m_love -= 10;
                if (GameManager.instance.charas[1].m_love < 0)
                {
                    GameManager.instance.charas[1].m_love = 0;
                }
            }

        }
    }
}
