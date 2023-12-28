using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ChooseCardPanel : MonoBehaviour
{
    public GameObject cards;
    public GameObject beforeCardPrefab;
    public List<GameObject> ChooseCard;
    void Start()
    {
        ChooseCard = new List<GameObject>();
        for (int i = 0; i < 8; i++)
        {
            GameObject beforeCard = Instantiate(beforeCardPrefab);
            beforeCard.transform.SetParent(cards.transform, false);
            beforeCard.name = "Card" + i.ToString();
            beforeCard.transform.Find("Bg").gameObject.SetActive(false);
        }
    }

    public void UpdateCardPosition()
    {
        //if (GameManager.instance.gameStart == false)
        //{
            for (int i = 0; i < ChooseCard.Count; i++)
            {
                GameObject useCard = ChooseCard[i];
                Transform targetObject = cards.transform.Find("Card" + i.ToString());
                useCard.GetComponent<Card>().isMoving = true;
               
                // DOMove ½øÐÐÒÆ¶¯
                useCard.transform.DOMove(targetObject.position, 0.3f).OnComplete(
                    () =>
                    {
                        useCard.transform.SetParent(targetObject, false);
                        useCard.transform.localPosition = Vector3.zero;
                        useCard.GetComponent<Card>().isMoving = false;
                    }
                );
            }
       // }
    }

    void Update()
    {

    }
}
