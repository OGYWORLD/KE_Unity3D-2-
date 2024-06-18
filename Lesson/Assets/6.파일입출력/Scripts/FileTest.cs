using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;
using UnityEngine.UI;
using System.IO;
using Newtonsoft.Json; // 12. ���� �߰�

public class FileTest : MonoBehaviour
{
    // 4.
    // [System.Serializable]�� ���� ����ȭ�� �� ��� �ν�����â���� ���� ����
    // Ŭ���� ���� ���� ����
    // ����ȭ�� �ϸ� ȣȯ���� ���������� ���ȼ��� ��������.
    // �̰� ������ ���̴ּµ� ������ ���ظ� �� ����..
    public PlayerData playerData;

    // 5.
    // �ν����� â�� ���� �� ����
    public List<PlayerData> playerDatas;

    // 6.
    public List<PlayerData> readFromJson = new List<PlayerData>();

    public Text text;

    private void Start()
    {
        // 1. ������ġ ���
        StringBuilder sb = new StringBuilder();

        sb.Append("Data Path : ");
        sb.Append(Application.dataPath); // ���� ��ġ
        sb.Append("\nPers data Path : ");
        sb.Append(Application.persistentDataPath); // ���� ������ ��¼��
        sb.Append("\nStr data Path : ");
        sb.Append(Application.streamingAssetsPath); // streamngAsset ���� ��ġ

        text.text = sb.ToString();

        // 3. [Serializable] ���̰� �� ���̰� ����� �ٸ�
        // JsonUtility <- �������� �� ������� ����
        print(JsonUtility.ToJson(new PlayerData()));
        print(JsonUtility.ToJson(new SkillData()));

        // 5. �̾...(1)
        // �ν����� â�� �Է��� �� �ֿܼ� ���
        foreach(PlayerData data in playerDatas)
        {
            print(JsonUtility.ToJson(data));
        }

        /*
        // 5. �̾ ..(2) �̰� ���Ϸ� �����غ���
        foreach (PlayerData data in playerDatas)
        {
            // �ؽ�Ʈ ������ ����� ���(���ϸ�, Ȯ���� ����)
            string path = $"{Application.streamingAssetsPath}/{data.name}_Data.json";
            // PlayerData�� Json ���ڿ��� ��ȯ
            string json = JsonUtility.ToJson(data);
            // ���� ���(���, ����)
            File.WriteAllText(path, json);
        }

        // 6. �̾..
        // JSON file Load�غ���
        // �� �ν����� â���� ����� ���� ���� �� ����
        string[] names = {"����", "����", "����"};
        foreach (string name in names)
        {
            string path = $"{Application.streamingAssetsPath}/{name}_Data.json";
            
            // ��ȿ�� �˻�
            if(File.Exists(path))
            {
                // ���Ϸκ��� Json �������� ���ڿ��� ������
                string json = File.ReadAllText(path);
                // Json ������ �����͸� �Ľ��Ͽ� PlayerData �ν��Ͻ� ���� �� �� �Ҵ�.
                readFromJson.Add(JsonUtility.FromJson<PlayerData>(json));
            }
        }
        */

    }

    // 7.
    // ������ϱ� ���ϰ� �и�
    // Ư�� ���� �̸� <- ����Ƽ ��ť��Ʈ Ȯ��
    public void Save()
    {
        /*
        foreach (PlayerData data in playerDatas)
        {
            // �ؽ�Ʈ ������ ����� ���(���ϸ�, Ȯ���� ����)
            string path = $"{Application.streamingAssetsPath}/{data.name}_Data.json";
            // PlayerData�� Json ���ڿ��� ��ȯ
            string json = JsonUtility.ToJson(data);
            // ���� ���(���, ����)
            File.WriteAllText(path, json);
        }
        */

        //12. JsonUtility ��� JsonConvert(����) ���
        foreach (PlayerData data in playerDatas)
        {
            // �ؽ�Ʈ ������ ����� ���(���ϸ�, Ȯ���� ����)
            string path = $"{Application.streamingAssetsPath}/{data.name}_Data.json";
            // PlayerData�� Json ���ڿ��� ��ȯ
            string json = JsonConvert.SerializeObject(data);
            // ���� ���(���, ����)
            File.WriteAllText(path, json);
        }
    }

    public void Load()
    {
        // Load Clear
        readFromJson.Clear();

        string[] names = { "����", "����", "����" };

        /*
        // <���� �ð� ����>
        // StreamingAsset ���� �ȿ� �ִ� Json ������ ��� �о
        // readFromJson ����Ʈ�� Add �Ͻÿ�.
        // ��Ʈ:
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

        // 11. JsonUtility�� ����ü Dictionary �� ������ �����ʹ� ����ȭ���� ���Ѵ�.
        // ���� NetTone�� Json.NET�� ���
        // NuGet => npm ����.., VS�� ����Ǿ� �ִ�.
        // ������ unity�� �������ϱ� ������ VS�� �ƴ϶� Unity�� ��ġ�ؾ� ��
        // ���� Nuget for unity�� ���� ����

        //<�����ð� ����>
        /*
        foreach (string name in names)
        {
            string path = $"{Application.streamingAssetsPath}/{name}_Data.json";

            // ��ȿ�� �˻�
            if (File.Exists(path))
            {
                // ���Ϸκ��� Json �������� ���ڿ��� ������
                string json = File.ReadAllText(path);
                // Json ������ �����͸� �Ľ��Ͽ� PlayerData �ν��Ͻ� ���� �� �� �Ҵ�.
                readFromJson.Add(JsonUtility.FromJson<PlayerData>(json));
            }
        }
        */

        //12. �̾ �ٲ㺸��
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
// �ٸ� ���·� �����͸� ����ϱ� ���� ����ȭ ������ �ʿ���
[System.Serializable]
public class PlayerData // ������ ȣȯ���� �ʿ��� ������ ��ü�̱� ������ ����ȭ ��.
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