using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    
    public static UIManager instance;
    public Text sunNumText;
    public ProgressPanel progressPanel;
    public AllCardPanel allCardPanel;
    public ChooseCardPanel chooseCardPanel;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {

    }

    void Update()
    {

    }

    public void InitUI()
    {
        sunNumText.text = GameManager.instance.SunNum.ToString();
        //progressPanel.gameObject.SetActive(false);
        // �������õ��������ɿ�ѡ�Ŀ�Ƭ
        allCardPanel.InitCards();
    }

    public void UpdateUI()
    {
        sunNumText.text = GameManager.instance.SunNum.ToString();
    }

    public void InitProgressPanel()
    {
        LevelInfoItem levelInfo = GameManager.instance.levelInfo.LevelInfoList[GameManager.instance.curLevelId];
        for (int i = 0; i < levelInfo.progressPercent.Length; i++)
        {
            // �õ����õ����ݣ�������ָ��λ����������
            float percent = levelInfo.progressPercent[i];
            if (percent == 1)
            {
                continue;
            }
            progressPanel.SetFlagPercent(percent);
        }
        // ��ʼ������Ϊ0
        progressPanel.SetPercent(0);
        progressPanel.gameObject.SetActive(true);
    }

    public void UpdateProgressPanel()
    {
        // todo: �õ���ǰ���εĽ�ʬ����
        int progressNum = 0;
        for (int i = 0; i < GameManager.instance.levelData.LevelDataList.Count; i++)
        {
            LevelItem levelItem = GameManager.instance.levelData.LevelDataList[i];
            if (levelItem.levelId == GameManager.instance.curLevelId && levelItem.progressId == GameManager.instance.curProgressId)
            {
                progressNum += 1;
                
            }
        }

        // ��ǰ����ʣ��Ľ�ʬ����
        int remainNum = GameManager.instance.curProgressZombie.Count;
        // ��ǰ���ν��е����ٰٷֱ�
        float percent = (float)(progressNum - remainNum) / progressNum;
        // ��ǰ���α�����ǰһ���α���
        LevelInfoItem levelInfoItem = GameManager.instance.levelInfo.LevelInfoList[GameManager.instance.curLevelId];
        float progressPercent = levelInfoItem.progressPercent[GameManager.instance.curProgressId - 1];
        float lastProgressPercent = 0;
        if (GameManager.instance.curProgressId > 1)
        {
            lastProgressPercent = levelInfoItem.progressPercent[GameManager.instance.curProgressId - 2];
        }
        // ���ձ��� = ��ǰ���ΰٷֱ� + ǰһ���ΰٷֱ�
        float finalPercent = percent * (progressPercent - lastProgressPercent) + lastProgressPercent;
        progressPanel.SetPercent(finalPercent);
    }

}

