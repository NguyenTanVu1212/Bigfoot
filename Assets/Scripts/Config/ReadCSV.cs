using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System.Reflection;
using System;
using UnityEditor;

public class DataBase : ScriptableObject
{
    public virtual void CreateAssetFile(TextAsset file)
    {

    }
}
public class ReadCSV<T>: DataBase
{
    public static List<T> records = new List<T>();

    static public List<string> SpliptCsvLine(string line)
    {
        return (from System.Text.RegularExpressions.Match m in System.Text.RegularExpressions.Regex.Matches(line,
        @"(((?<x>(?=[,\r\n]+))|""(?<x>([^""]|"""")+)""|(?<x>[^,\r\n]+)),?)",
        System.Text.RegularExpressions.RegexOptions.ExplicitCapture)
                select m.Groups[1].Value).ToList();
    }

    public static List<List<string>> SpliptCsvGrid(string text)
    {
        List<string> lines = text.Split("\n"[0]).ToList();
        List<List<string>> grid = new List<List<string>>();
        foreach (var e in lines)
        {
            if (lines.IndexOf(e) != 0)
            {
                List<string> row = SpliptCsvLine(e);
                List<string> line = new List<string>();
                foreach (string y in row)
                {
                    line.Add(y.Replace("\"\"", "\""));
                }
                grid.Add(line);
            }
        }
        return grid;
    }
    public override void CreateAssetFile(TextAsset file)
    {
        List<List<string>> grid = SpliptCsvGrid(file.text);
        if (records != null) records.Clear();

        foreach (List<string> e in grid)
        {
            Type myType = typeof(T);
            FieldInfo[] fieldInfo;
            fieldInfo = myType.GetFields(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
            string json = string.Empty;
            json += "{";
            for (int i = 0; i < fieldInfo.Length; i++)
            {
                if (fieldInfo[i].FieldType == typeof(System.String))
                {
                    json += "\"" + fieldInfo[i].Name + "\":\"" + e[i] + "\"";
                }
                else
                {
                    json += "\"" + fieldInfo[i].Name + "\":" + e[i];
                }

                if (i < fieldInfo.Length - 1)
                {
                    json += ",";
                }
            }
            json += "}";
            Debug.Log(json);
            T data = JsonUtility.FromJson<T>(json);
            records.Add(data);
        }
    }
}
