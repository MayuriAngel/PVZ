
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using DG.Tweening;


public class Card : MonoBehaviour, IPointerClickHandler
{
    public GameObject objectPrefab;  // ��Ƭ��Ӧ������Ԥ�Ƽ�
    private GameObject curGameObject;  // ��¼��ǰ��������������
    private GameObject darkBg;
    private GameObject progressBar;
    public float waitTime;
    public int useSun;
    private float timer;
    public PlantInfoItem plantInfo;
    public bool hasUse = false;
    public bool hasLock = false;
    public bool isMoving = false;
    public bool hasStart = false;
    public Plant IsPlant;
    //public Shovel Shovel;
    // Start is called before the first frame update
    void Start()
    {
        // ��һ�ֻ�ȡ����ķ�ʽ����ȡ������
        darkBg = transform.Find("Dark").gameObject;
        progressBar = transform.Find("Progress").gameObject;

        darkBg.SetActive(false);
        progressBar.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameManager.instance.gameStart)
        {
            return;
        }
        if (!hasStart)
        {
            hasStart = true;
            darkBg.SetActive(true);
            progressBar.SetActive(true);
        }
        timer += Time.deltaTime;
        UpdateProgress();
        UpdateDarkBg();
    }

    void UpdateProgress()
    {
        float per = Mathf.Clamp(timer / waitTime, 0, 1);
        progressBar.GetComponent<Image>().fillAmount = 1 - per;
    }

    void UpdateDarkBg()
    {
        // ����ʱ����������̫�������㹻
        if (progressBar.GetComponent<Image>().fillAmount == 0 && GameManager.instance.SunNum >= useSun)
        {
            darkBg.SetActive(false);
        }
        else
        {
            darkBg.SetActive(true);
        }
    }



    // ��ק��ʼ�������µ�һ˲�䣩
    public void OnBeginDrag(BaseEventData data)
    {
        if (!hasStart)
        {
            return;
        }
        // �ж��Ƿ������ֲ, ѹ�ڴ������޷���ֲ
        if (darkBg.activeSelf)
        {
            return;
        }
        PointerEventData pointerEventData = data as PointerEventData;
        curGameObject = Instantiate(objectPrefab);
        curGameObject.transform.position = TranlateScreenToWorld(pointerEventData.position);
        // ���ŵ����Ƭ������
        SoundManager.instance.PlaySound(Globals.S_Seedlift);
    }

    // ��ק���̣���갴��û�ſ���
    public void OnDrag(BaseEventData data)
    {
        if (IsPlant.IsPlant == false)//&& Shovel.IsZombie == true
        {
            curGameObject.GetComponent<Plant>().SetPlantStart();
        }
        if (curGameObject == null)
        {
            return;
        }
        PointerEventData pointerEventData = data as PointerEventData;
        // ��������ƶ���λ�ö�Ӧ�ƶ�����
        curGameObject.transform.position = TranlateScreenToWorld(pointerEventData.position);

    }

    // ��ק���������ſ���һ˲�䣩
    public void OnEndDrag(BaseEventData data)
    {
        //Shovel.CanRun = true;
        if (curGameObject == null)
        {
            return;
        }
        PointerEventData pointerEventData = data as PointerEventData;
        // �õ��������λ�õ���ײ��
        Collider2D[] col = Physics2D.OverlapPointAll(TranlateScreenToWorld(pointerEventData.position));
        // ������ײ��
        foreach (Collider2D c in col)
        {
            // �ж�����Ϊ�����ء�������������û������ֲ��
            if (c.tag == "Land" && c.transform.childCount == 0&&IsPlant.IsPlant==true)
            {
                // �ѵ�ǰ�������Ϊ���ص�������
                curGameObject.transform.parent = c.transform;
                curGameObject.transform.localPosition = Vector3.zero;
                // ����ֲ��
                curGameObject.GetComponent<Plant>().SetPlantStart();
                // ������ֲ�������ϵ�����
                SoundManager.instance.PlaySound(Globals.S_Plant);
                // ����Ĭ��ֵ�����ɽ���
                curGameObject = null;
                GameManager.instance.ChangeSunNum(-useSun);
                timer = 0;
                break;
            }
        }
        // ���û�з������������أ���curGameObject�������ţ���ô������.
        if (curGameObject != null)
        {
            GameObject.Destroy(curGameObject);
            curGameObject = null;
        }
    }

    public static Vector3 TranlateScreenToWorld(Vector3 position)
    {
        Vector3 cameraTranslatePos = Camera.main.ScreenToWorldPoint(position);
        return new Vector3(cameraTranslatePos.x, cameraTranslatePos.y, 0);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (isMoving)
            return;
        if (hasLock)
            return;
        if (GameManager.instance.gameStart == false)
        {
            if (hasUse)
            {
                RemoveCard(gameObject);
            }
            else
            {
                AddCard(gameObject);
            }
        }
    }

    public void RemoveCard(GameObject removeCard)
    {
        ChooseCardPanel chooseCardPanel = UIManager.instance.chooseCardPanel;
        if (chooseCardPanel.ChooseCard.Contains(removeCard))
        {
            // �Ƴ�����
            removeCard.GetComponent<Card>().isMoving = true;
            chooseCardPanel.ChooseCard.Remove(removeCard);
            chooseCardPanel.UpdateCardPosition();
            // �ƶ��ص�ԭ����λ��
            Transform cardParent = UIManager.instance.allCardPanel.Bg.transform.Find("Card" + removeCard.GetComponent<Card>().plantInfo.plantId);
            Vector3 curPosition = removeCard.transform.position;
            removeCard.transform.SetParent(UIManager.instance.transform, false);
            removeCard.transform.position = curPosition;
            // DOMove
            removeCard.transform.DOMove(cardParent.position, 0.3f).OnComplete(
                () =>
                {
                    
                    cardParent.Find("BeforeCard").GetComponent<Card>().darkBg.SetActive(false);
                    cardParent.Find("BeforeCard").GetComponent<Card>().hasLock = false;
                    removeCard.GetComponent<Card>().isMoving = false;
                    Destroy(removeCard);
                }
            );
        }

    }

    public void AddCard(GameObject gameObject)
    {
        ChooseCardPanel chooseCardPanel = UIManager.instance.chooseCardPanel;
        int curIndex = chooseCardPanel.ChooseCard.Count;
        if (curIndex >= 8)
        {
            // Destroy(useCard);
            print("�Ѿ�ѡ�еĿ�Ƭ�����������");
            return;
        }
        GameObject useCard = Instantiate(plantInfo.cardPrefab);
        useCard.transform.SetParent(UIManager.instance.transform);
        useCard.transform.position = transform.position;
        useCard.name = "Card";
        useCard.GetComponent<Card>().plantInfo = plantInfo;
        hasLock = true;
        darkBg.SetActive(true);
        // �ƶ���Ŀ��λ��
        Transform targetObject = chooseCardPanel.cards.transform.Find("Card" + curIndex);
        useCard.GetComponent<Card>().isMoving = true;
        useCard.GetComponent<Card>().hasUse = true;
        chooseCardPanel.ChooseCard.Add(useCard);
        // DoMove�����ƶ�
        useCard.transform.DOMove(targetObject.position, 0.3f).OnComplete(
            () =>
            {
                useCard.transform.SetParent(targetObject, false);
                useCard.transform.localPosition = Vector3.zero;
                useCard.GetComponent<Card>().isMoving = false;
            }
        );
    }
}
