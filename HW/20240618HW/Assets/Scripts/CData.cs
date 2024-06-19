using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using NPOI.XSSF.UserModel;
using NPOI.SS.UserModel;

public class CData : MonoBehaviour
{
    [Serializable]
    public class EvidenceItem
    {
        public string m_name;
        public string m_info;

        public EvidenceItem(string _n, string _i)
        {
            m_name = _n;
            m_info = _i;
        }
    }

    public List<EvidenceItem> items = new List<EvidenceItem>();

    const int ITEM_NUM = 4;

    public InputField[] names = new InputField[ITEM_NUM];
    public InputField[] info = new InputField[ITEM_NUM];


    void Start()
    {
        // Init
        for(int i = 0; i < ITEM_NUM; i++)
        {
            //items.Add(new EvidenceItem(names[i].text, info[i].text));
            names[i].text = "";
            info[i].text = "";
        }

        SaveInfo();
    }

    public void SaveInfo()
    {
        IWorkbook workbook = new XSSFWorkbook();
        ISheet sheet = workbook.CreateSheet("Evidence");

        for (int i = 0; i < ITEM_NUM; i++)
        {
            IRow row = sheet.CreateRow(i);

            ICell cell = row.CreateCell(0);
            cell.SetCellValue(names[i].text);

            cell = row.CreateCell(1);
            cell.SetCellValue(info[i].text);
        }

        string path = Path.Combine(Application.streamingAssetsPath, "Evidence.xlsx");

        using (FileStream file = new FileStream(path, FileMode.Create, FileAccess.Write))
        {
            workbook.Write(file);
        }
    }

    public void LoadInfo()
    {
        string path = Path.Combine(Application.streamingAssetsPath, "Evidence.xlsx");

        using (FileStream file = new FileStream(path, FileMode.Open, FileAccess.Read))
        {
            IWorkbook workbook = new XSSFWorkbook(file);
            ISheet sheet = workbook.GetSheetAt(0);

            for (int i = 0; i < ITEM_NUM; i++)
            {
                IRow row = sheet.GetRow(i);

                ICell cell = row.GetCell(0);
                names[i].text = cell.ToString();

                cell = row.GetCell(1);
                info[i].text = cell.ToString();
            }
        }
    }
}
