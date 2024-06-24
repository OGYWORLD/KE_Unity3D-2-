using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;
using UnityEngine.UI;
using System.IO;
using Newtonsoft.Json; // 12. 뉴톤 추가

public class FileTest : MonoBehaviour
{
    // 4.
    // [System.Serializable]를 통해 직렬화를 한 경우 인스펙터창에서 수정 가능
    // 클래스 위에 쓰는 거임
    // 직렬화를 하면 호환성은 좋아지지만 보안성은 떨어진다.
    // 이거 설명을 해주셨는데 졸려서 이해를 잘 못함..
    public PlayerData playerData;

    // 5.
    // 인스펙터 창에 여러 개 만듦
    public List<PlayerData> playerDatas;

    // 6.
    public List<PlayerData> readFromJson = new List<PlayerData>();

    public Text text;

    private void Start()
    {
        // 1. 폴더위치 출력
        StringBuilder sb = new StringBuilder();

        sb.Append("Data Path : ");
        sb.Append(Application.dataPath); // 폴더 위치
        sb.Append("\nPers data Path : ");
        sb.Append(Application.persistentDataPath); // 무슨 프리팹 어쩌고
        sb.Append("\nStr data Path : ");
        sb.Append(Application.streamingAssetsPath); // streamngAsset 폴더 위치

        text.text = sb.ToString();

        // 3. [Serializable] 붙이고 안 붙이고 결과가 다름
        // JsonUtility <- 현업에서 잘 사용하진 않음
        print(JsonUtility.ToJson(new PlayerData()));
        print(JsonUtility.ToJson(new SkillData()));

        // 5. 이어서...(1)
        // 인스펙터 창에 입력한 걸 콘솔에 출력
        foreach(PlayerData data in playerDatas)
        {
            print(JsonUtility.ToJson(data));
        }

        /*
        // 5. 이어서 ..(2) 이걸 파일로 저장해보자
        foreach (PlayerData data in playerDatas)
        {
            // 텍스트 파일을 출력할 경로(파일명, 확장자 포함)
            string path = $"{Application.streamingAssetsPath}/{data.name}_Data.json";
            // PlayerData를 Json 문자열로 변환
            string json = JsonUtility.ToJson(data);
            // 파일 출력(경로, 내용)
            File.WriteAllText(path, json);
        }

        // 6. 이어서..
        // JSON file Load해보기
        // 오 인스펙터 창에서 디버그 모드로 돌릴 수 있음
        string[] names = {"법사", "병사", "힐러"};
        foreach (string name in names)
        {
            string path = $"{Application.streamingAssetsPath}/{name}_Data.json";
            
            // 유효성 검사
            if(File.Exists(path))
            {
                // 파일로부터 Json 포맷으로 문자열을 가져옴
                string json = File.ReadAllText(path);
                // Json 포맷의 데이터를 파싱하여 PlayerData 인스턴스 생성 후 값 할당.
                readFromJson.Add(JsonUtility.FromJson<PlayerData>(json));
            }
        }
        */

    }

    // 7.
    // 디버깅하기 편하게 분리
    // 특수 폴더 이름 <- 유니티 도큐먼트 확인
    public void Save()
    {
        /*
        foreach (PlayerData data in playerDatas)
        {
            // 텍스트 파일을 출력할 경로(파일명, 확장자 포함)
            string path = $"{Application.streamingAssetsPath}/{data.name}_Data.json";
            // PlayerData를 Json 문자열로 변환
            string json = JsonUtility.ToJson(data);
            // 파일 출력(경로, 내용)
            File.WriteAllText(path, json);
        }
        */

        //12. JsonUtility 대신 JsonConvert(뉴톤) 사용
        foreach (PlayerData data in playerDatas)
        {
            // 텍스트 파일을 출력할 경로(파일명, 확장자 포함)
            string path = $"{Application.streamingAssetsPath}/{data.name}_Data.json";
            // PlayerData를 Json 문자열로 변환
            string json = JsonConvert.SerializeObject(data);
            // 파일 출력(경로, 내용)
            File.WriteAllText(path, json);
        }
    }

    public void Load()
    {
        // Load Clear
        readFromJson.Clear();

        string[] names = { "법사", "병사", "힐러" };

        /*
        // <남은 시간 과제>
        // StreamingAsset 폴더 안에 있는 Json 파일을 모두 읽어서
        // readFromJson 리스트에 Add 하시오.
        // 힌트:
        DirectoryInfo di = new DirectoryInfo(Application.streamingAssetsPath);

        if(di.Exists)
        {
            var files = di.EnumerateFiles("*.json");
            foreach(var file in files)
            {
                string json = File.ReadAllText(file.ToString());
                readFromJson.Add(JsonUtility.FromJson<PlayerData>(json));
            }
        }
        */

        // 11. JsonUtility는 구조체 Dictionary 등 복잡한 데이터는 직렬화하지 못한다.
        // 따라서 NetTone의 Json.NET을 사용
        // NuGet => npm 같은.., VS에 내장되어 있다.
        // 하지만 unity가 컴파일하기 때문에 VS가 아니라 Unity에 설치해야 함
        // 따라서 Nuget for unity가 따로 있음

        //<수업시간 버전>
        /*
        foreach (string name in names)
        {
            string path = $"{Application.streamingAssetsPath}/{name}_Data.json";

            // 유효성 검사
            if (File.Exists(path))
            {
                // 파일로부터 Json 포맷으로 문자열을 가져옴
                string json = File.ReadAllText(path);
                // Json 포맷의 데이터를 파싱하여 PlayerData 인스턴스 생성 후 값 할당.
                readFromJson.Add(JsonUtility.FromJson<PlayerData>(json));
            }
        }
        */

        //12. 이어서 바꿔보기
        DirectoryInfo di = new DirectoryInfo(Application.streamingAssetsPath);

        if (di.Exists)
        {
            var files = di.EnumerateFiles("*.json");
            foreach (var file in files)
            {
                string json = File.ReadAllText(file.ToString());
                PlayerData data = JsonConvert.DeserializeObject<PlayerData>(json);
                readFromJson.Add(data);
            }
        }
    }
}
// 2. JSON
// 다른 형태로 데이터를 취급하기 위해 직렬화 과정이 필요함
[System.Serializable]
public class PlayerData // 데이터 호환성이 필요한 데이터 객체이기 때문에 직렬화 함.
{
    public string name;
    public int level;
    public float exp;
    public int hp;
    public int attack;
    public int[] items;
    public List<SkillData> skills;
}
[System.Serializable]
public class SkillData
{
    public int id;
    public int level;
    public EUpgradeType upgrade;

}

public enum EUpgradeType
{
    ATTACK,
    DEFENSE,
    SPEED,
    HP
}