using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public class CharaInfo
    {
        public string m_name { get; set; }
        public string m_info { get; set; }
        public int m_love { get; set; }

        public CharaInfo(string _n, string _i, int _l)
        {
            m_name = _n;
            m_info = _i;
            m_love = _l;
        }
    }

    public bool isTab = false;

    public List<CharaInfo> charas = new List<CharaInfo>();

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        charas.Add(new CharaInfo("", "", 0));
        charas.Add(new CharaInfo("", "", 0));
    }
}
