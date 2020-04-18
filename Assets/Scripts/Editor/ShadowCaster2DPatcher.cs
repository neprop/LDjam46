using System.IO;
using UnityEditor;
using UnityEngine;

[InitializeOnLoad]
public static class ShadowCaster2DPatcher
{
    static ShadowCaster2DPatcher()
    {
        var path = Application.dataPath.Replace('\\', '/');
        path = path.Substring(0, path.Length - "Assets".Length);
        path += "Library/PackageCache/com.unity.render-pipelines.universal@7.3.1/Runtime/2D/ShadowCaster2D.cs";

        if (File.Exists(path))
        {
            var text1 = File.ReadAllText(Application.dataPath + "/Scripts/Editor/ShadowCaster2D.cs.txt");
            var text2 = File.ReadAllText(path);
            if (text1 != text2)
            {
                File.WriteAllText(path, text1);
                AssetDatabase.Refresh();
            }
        }
    }
}
