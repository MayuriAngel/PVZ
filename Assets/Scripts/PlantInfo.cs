using System;
using UnityEngine;
using System.Collections.Generic;
[CreateAssetMenu(menuName = "JXUFE/PlantInfo", fileName = "PlantInfo", order = 1)]
public class PlantInfo : ScriptableObject
{
    public List<PlantInfoItem> plantInfoList = new List<PlantInfoItem>();
    // public Dictionary<int, LevelItem> LevelDataDict = new Dictionary<int, LevelItem>();
}

[System.Serializable]
public class PlantInfoItem
{
    public int plantId;
    public string plantName;
    public string description;
    public GameObject cardPrefab;
    // ��Щ��Ϣ�Ѿ��洢�ڿ�Ƭ��
    // public int useNum;
    // public int cdTime;
    // public GameObject prefab;


    override
    public string ToString()
    {
        return "[id]: " + plantId.ToString();
    }
}
