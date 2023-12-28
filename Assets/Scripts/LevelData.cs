using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
/*����ʹ���� CreateAssetMenu() �������Զ��� ScriptableObject �Ĳ˵�������Խ�������������

- fileName: ���Ǵ������� ScriptableObject ʵ����Ĭ���ļ�����Unity ����������ļ�������Ŀ�д�����Ӧ���ļ���
ͨ��������ʹ�� "NewCustomData" ��������ΪĬ���ļ��������� Unity ���Զ����һ�����ֺ�׺����ȷ���ļ�����Ψһ�ԡ�
- menuName: ������ Unity �༭���д����˵����·�����˵�������� "Assets/Create/Custom Data" 
�£����� "Custom Data" ��������滻Ϊ������ϲ�������ơ�
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



