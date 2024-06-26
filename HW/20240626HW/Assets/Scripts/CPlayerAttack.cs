using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CPlayerAttack : MonoBehaviour
{
    public GameObject[] bulletPrefab;
    public Transform shootTrans;
    public Image reloadIcon;

    private int curBulletIdx;

    private bool isStartRelaod = false;

    private List<GameObject> pool = new List<GameObject>();
    private int checkBullet = 0; // 0: 0 ~ 4, 1: 5 ~ 9

    private void Start()
    {
        curBulletIdx = 0;
        MakeBullet();
    }

    private void Update()
    {
        PlayerShoot();
        ChangeBullet();
    }

    void ChangeBullet()
    {
        if(curBulletIdx != GameManager.instance.playerInfo.curBulletPrefab)
        {
            curBulletIdx = GameManager.instance.playerInfo.curBulletPrefab;
            MakeBullet();
        }
    }

    void MakeBullet()
    {
        pool.Clear();

        for (int i = 0; i < GameManager.instance.playerInfo.maxBullet * 2; i++)
        {
            GameObject obj = Instantiate(bulletPrefab[GameManager.instance.playerInfo.curBulletPrefab], shootTrans.position, Quaternion.identity);
            obj.SetActive(false);
            pool.Add(obj);
        }
    }

    void PlayerShoot()
    {
        if(GameManager.instance.isOpenTab)
        {
            return;
        }

        // No Any Bullet
        if(!isStartRelaod && GameManager.instance.playerInfo.curBullet == 0)
        {
            isStartRelaod = true;
            reloadIcon.fillAmount = 0f;
            ChangeCheckBullet();
            ResetBullet();
            StartCoroutine(Reload());
        }
        else if(!isStartRelaod && Input.GetMouseButtonDown(0))
        {
            int curBulletIdx = GameManager.instance.playerInfo.maxBullet * (checkBullet + 1) - GameManager.instance.playerInfo.curBullet;
            pool[curBulletIdx].transform.position = shootTrans.position;
            pool[curBulletIdx].SetActive(true);
            GameManager.instance.playerInfo.curBullet--;
        }
    }

    void ResetBullet()
    {
        for (int i = GameManager.instance.playerInfo.maxBullet * checkBullet; i < GameManager.instance.playerInfo.maxBullet * (checkBullet + 1); i++)
        {
            pool[i].SetActive(false);
        }
    }

    void ChangeCheckBullet()
    {
        if(checkBullet == 0)
        {
            checkBullet = 1;
        }
        else
        {
            checkBullet = 0;
        }
    }

    IEnumerator Reload()
    {
        float sumTime = 0f;
        float reloadTime = 3f;

        while(sumTime <= reloadTime)
        {
            reloadIcon.fillAmount += sumTime / reloadTime * 0.04f;

            sumTime += Time.deltaTime;

            yield return null;
        }

        isStartRelaod = false;
        GameManager.instance.playerInfo.curBullet = GameManager.instance.playerInfo.maxBullet;
        yield break;
    }
}
