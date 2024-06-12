using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orc : Moster
{
    public string orcPassive = "��ũ�� �������� 10% �� �޽��ϴ�.";

    private void Start()
    {
        maxHP = currentHP = 150;
    }

    public override void Hit(float damage)
    {
        damage *= .9f;

        base.Hit(damage);
    }
}
