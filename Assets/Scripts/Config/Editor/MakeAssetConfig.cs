using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;
public static class MakeAssetFile
{
    [MenuItem("Assets/Create binary File form CSV", false, 1)]
    private static void CreateBinaryFile()
    {
        foreach (UnityEngine.Object obj in Selection.objects)
        {
            TextAsset csvFile = (TextAsset)obj;
            string tableName = Path.GetFileNameWithoutExtension(AssetDatabase.GetAssetPath(csvFile));
            ScriptableObject scriptableTable = ScriptableObject.CreateInstance(tableName);
            if (scriptableTable == null)
                return;

            AssetDatabase.CreateAsset(scriptableTable, "Assets/Resources/Config/" + tableName + ".asset");
            AssetDatabase.SaveAssets();
            AssetDatabase.Refresh();

            DataBase datas = (DataBase)scriptableTable;
            datas.CreateAssetFile(csvFile);
            EditorUtility.SetDirty(datas);
        }
    }
}