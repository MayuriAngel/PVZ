using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
/*我们使用了 CreateAssetMenu() 属性来自定义 ScriptableObject 的菜单项。该属性接受两个参数：

- fileName: 这是创建的新 ScriptableObject 实例的默认文件名。Unity 将根据这个文件名在项目中创建对应的文件。
通常，我们使用 "NewCustomData" 或类名作为默认文件名，并且 Unity 将自动添加一个数字后缀，以确保文件名的唯一性。
- menuName: 这是在 Unity 编辑器中创建菜单项的路径。菜单项将出现在 "Assets/Create/Custom Data" 
下，其中 "Custom Data" 是你可以替换为其他你喜欢的名称。
*/
[CreateAssetMenu(menuName = "JXUFE/Level", fileName = "Level", order = 3)]
public class LevelData : ScriptableObject
{
    public List<LevelItem> LevelDataList = new List<LevelItem>();
}
[System.Serializable]
public class LevelItem
{
    public int id;
    public int levelId;
    public int progressId;
    public int createTime;
    public int zombieType;
    public int bornPos;

    override
    public string ToString()
    {
        return "[id]: " + id.ToString();
    }
}



