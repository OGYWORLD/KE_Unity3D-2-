using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor; // �߰�

// 8. ������ ���� ����� �ۼ���
[CustomEditor(typeof(FileTest))]
public class FileTestEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        // 10. 
        FileTest fileTest = target as FileTest;

        // 9. ��ư ����
        if(GUILayout.Button("Save"))
        {
            // 10. �̾... fileTest�� Save �Լ� ȣ��
            fileTest.Save();
        }

        if (GUILayout.Button("Load"))
        {
            // 10. �̾... fileTest�� Load �Լ� ȣ��
            fileTest.Load();
        }
    }
}
