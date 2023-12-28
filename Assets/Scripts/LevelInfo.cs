using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "JXUFE/LevelInfo", fileName = "LevelInfo", order = 1)]
public class LevelInfo : ScriptableObject
{
    public List<LevelInfoItem> LevelInfoList = new List<LevelInfoItem>();
}
[System.Serializable]
public class LevelInfoItem
{

    public int levelId;
    public string levelName;
    public float[] progressPercent;

    override
    public string ToString()
    {
        return "[id]: " + levelId.ToString();
    }
}