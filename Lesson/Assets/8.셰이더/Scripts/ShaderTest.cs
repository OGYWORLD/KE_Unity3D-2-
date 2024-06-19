using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShaderTest : MonoBehaviour
{
    Renderer render;

    // # ��Ʈ����Ʈ ã�ƺ���
    [Range(0, 1)] // ��Ʈ����Ʈ �߰�
    public float colorAmount;

    private void Awake()
    {
        render = GetComponent<Renderer>();
    }

    private void Update()
    {
        render.material.SetFloat("_colorAmount", colorAmount); // ��ũ��Ʈ���� �����
        // colorAmount�� _colorAmount�� �򰥸��� �����µ� �󰡸���

        //render.material.SetColor("_MainTex", Color.white);

        // # �´� �������� ��..��.
        // ��Ʈ������ ������Ʈ�� ������ �ν��Ͻ�ȭ �ż� ��� �ٸ� ���� ���� �� ����..
        // �׷��� ��ũ��Ʈ�� �����ϸ� ��Ÿ�ӿ� ���� ���� ��¼��
    }
}
