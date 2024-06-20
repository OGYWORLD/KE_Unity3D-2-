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
    const int ITEM_NUM = 2;

    void Start()
    {
        LoadInfo();
    }

    public void SaveInfo()
    {
        IWorkbook workbook = new XSSFWorkbook();
        ISheet sheet = workbook.CreateSheet("Info");

        for (int i = 0; i < ITEM_NUM; i++)
        {
            IRow row = sheet.CreateRow(i);

            ICell cell = row.CreateCell(0);
            cell.SetCellValue(GameManager.instance.charas[i].m_name);

            cell = row.CreateCell(1);
            cell.SetCellValue(GameManager.instance.charas[i].m_info);

            cell = row.CreateCell(2);
            cell.SetCellValue(GameManager.instance.charas[i].m_love);
        }

        string path = Path.Combine(Application.streamingAssetsPath, "CharaInfo.xlsx");

        using (FileStream file = new FileStream(path, FileMode.Create, FileAccess.Write))
        {
            workbook.Write(file);
        }
    }

    public void LoadInfo()
    {
        string path = Path.Combine(Application.streamingAssetsPath, "CharaInfo.xlsx");

        using (FileStream file = new FileStream(path, FileMode.Open, FileAccess.Read))
        {
            IWorkbook workbook = new XSSFWorkbook(file);
            ISheet sheet = workbook.GetSheetAt(0);

            for (int i = 0; i < ITEM_NUM; i++)
            {
                IRow row = sheet.GetRow(i);

                ICell cell = row.GetCell(0);
                GameManager.instance.charas[i].m_name = cell.ToString();

                cell = row.GetCell(1);
                GameManager.instance.charas[i].m_info = cell.ToString();

                cell = row.GetCell(2);
                GameManager.instance.charas[i].m_love = int.Parse(cell.ToString());
            }
        }
    }
}
