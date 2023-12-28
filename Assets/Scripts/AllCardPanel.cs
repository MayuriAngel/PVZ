using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AllCardPanel : MonoBehaviour
{
    public GameObject Bg;
    public GameObject beforeCardPrefab;
    //public Button StartGame;
    
    // Start is called before the first frame update
    void Start()
    {

        // 生成选卡栏的24个格子
        for (int i = 0; i < 24; i++)
        {
            GameObject beforeCard = Instantiate(beforeCardPrefab);
            beforeCard.transform.SetParent(Bg.transform, false);
            beforeCard.name = "Card" + i.ToString();
        }
        
        
    }

    public void InitCards()
    {
        foreach (PlantInfoItem plantInfo in GameManager.instance.plantInfo.plantInfoList)
        {
            Transform cardParent = Bg.transform.Find("Card" + plantInfo.plantId);
            GameObject reallyCard = Instantiate(plantInfo.cardPrefab);
            reallyCard.GetComponent<Card>().plantInfo = plantInfo;
            reallyCard.transform.SetParent(cardParent, false);
            reallyCard.transform.localPosition = Vector2.zero;
            reallyCard.name = "BeforeCard";
        }
    }

    void Update()
    {

    }

    public void OnBtnStart()
    {
        
        GameManager.instance.GameReallyStart();
        SoundManager.instance.PlaySound(Globals.S_Relllsetplant);
       
    }
}
