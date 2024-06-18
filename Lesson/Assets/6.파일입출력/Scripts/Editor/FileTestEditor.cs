using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor; // 추가

// 8. 에디터 폴더 만들고 작성함
[CustomEditor(typeof(FileTest))]
public class FileTestEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        // 10. 
        FileTest fileTest = target as FileTest;

        // 9. 버튼 생김
        if(GUILayout.Button("Save"))
        {
            // 10. 이어서... fileTest의 Save 함수 호출
            fileTest.Save();
        }

        if (GUILayout.Button("Load"))
        {
            // 10. 이어서... fileTest의 Load 함수 호출
            fileTest.Load();
        }
    }
}
