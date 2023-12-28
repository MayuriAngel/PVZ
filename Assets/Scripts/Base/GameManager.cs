using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public bool gameStart;
    //����Ϊһ�����������������ű�ʹ����
    public static GameManager instance;
    public int SunNum;

    public GameObject bornParent;
    public float createZombieTime;
    private int zOrderIndex = 0;
    [HideInInspector]
    public LevelData levelData;
    [HideInInspector]
    public LevelInfo levelInfo;
    [HideInInspector]
    public PlantInfo plantInfo;
    public List<GameObject> curProgressZombie;
    public int curLevelId = 1;
    public int curProgressId = 1;

    public GameObject All;

    //��Ϸ��ʤ
    public GameObject Win;
   
    //�Ƿ��˳���Ϸ
    public GameObject IsExit;


    //��ʾ
    public bool IsTwo = false;
    public bool IsEnd = false;
    public GameObject Two;
    public CanvasGroup canvasGroup1;
    public GameObject End;
    public CanvasGroup canvasGroup2;
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        ReadData();

    }

    private void GameStart()
    {
        UIManager.instance.InitUI();
    }

    public void GameReallyStart()
    {
        instance.gameStart = true;
        All.SetActive(false);

        CreateZombie();

        InvokeRepeating("CreateSunDown", 10, 20);
        // ����BGM
        SoundManager.instance.PlayBGM(Globals.BGM8);


    }

    void ReadData()
    {
        LoadTableNew();
    }

    public void LoadTableNew()
    {
        levelData = Resources.Load("TableData/Level") as LevelData;
        levelInfo = Resources.Load("TableData/LevelInfo") as LevelInfo;
        plantInfo = Resources.Load("TableData/plantInfo") as PlantInfo;

        GameStart();
    }
    private void Update()
    {
      
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            IsExit.SetActive(true);
            Time.timeScale = 0;
        }
    }


    public void ChangeSunNum(int changeNum)
    {
        SunNum += changeNum;
        if (SunNum <= 0)
        {
            SunNum = 0;
        }
        // �������������ı䣬֪ͨ��Ƭѹ�ڵ�...
        UIManager.instance.UpdateUI();

    }

    public void CreateZombie()
    {
        curProgressZombie = new List<GameObject>();
        TableCreateZombie();
        // ���ó�ʼ���������ĺ���
        UIManager.instance.InitProgressPanel();
    }

    // ��񴴽���ʬ
    private async void TableCreateZombie()
    {
       
        bool canCreate = false;
        for (int i = 0; i < levelData.LevelDataList.Count; i++)
        {
            LevelItem levelItem = levelData.LevelDataList[i];
            if (levelItem.levelId == curLevelId && levelItem.progressId == curProgressId)
            {

                StartCoroutine(ITableCreateZombie(levelItem));
                canCreate = true;
            }
        }
        if (!canCreate)
        {
            StopAllCoroutines();
            curProgressZombie = new List<GameObject>();
            gameStart = false;
            await Task.Delay(5000);
            GameWin();


        }
        else
        {
            SoundManager.instance.PlaySound(Globals.S_ZombieSound1);
        }
    }

    public void GameWin()
    {
        SoundManager.instance.StopBGM();
        SoundManager.instance.PlaySound(Globals.S_Winmusic);
        Win.SetActive(true);


       
    }
    //Эͬ����Coroutine�����Э�̣��ǰ������߳�һ�����еĳ���Ƭ�Σ���һ���ܹ���ִͣ�еĺ��������ڽ�����������⡣
    IEnumerator ITableCreateZombie(LevelItem levelItem)
    {
        yield return new WaitForSeconds(levelItem.createTime);
        //����Ԥ�Ƽ�
        GameObject zombiePrefab = Resources.Load("Prefab/Zombie" + levelItem.zombieType.ToString()) as GameObject;

        GameObject zombie = Instantiate(zombiePrefab);
        Transform zombieLine = bornParent.transform.Find("born" + levelItem.bornPos.ToString());
        zombie.transform.parent = zombieLine;
        zombie.transform.localPosition = Vector3.zero;
        zombie.GetComponent<SpriteRenderer>().sortingOrder = zOrderIndex;
        zOrderIndex += 1;
        curProgressZombie.Add(zombie);
    }

    public void ZombieDied(GameObject gameObject)
    {
        if (curProgressZombie.Contains(gameObject))
        {
            curProgressZombie.Remove(gameObject);
            UIManager.instance.UpdateProgressPanel();
        }
        if (curProgressZombie.Count == 0)
        {
            curProgressId += 1;

            TableCreateZombie();
            //���
            if (curProgressId == 2)
            {
                SoundManager.instance.PlaySound(Globals.S_Hugewave);
                Two.SetActive(true);
                canvasGroup1.DOFade(0, 4);

            }
            if (curProgressId == 3)
            {
                SoundManager.instance.PlaySound(Globals.S_Finalwave);
                End.SetActive(true);
                canvasGroup2.DOFade(0, 4);
            }
        }
    }

    public void CreateSunDown()
    {
        // ��ȡ���½ǡ����Ͻǵ���������
        Vector3 leftBottom = Camera.main.ViewportToWorldPoint(Vector2.zero);
        Vector3 rightTop = Camera.main.ViewportToWorldPoint(Vector2.one);
        // ����SunԤ�Ƽ�����һ�ְ취��
        GameObject sunPrefab = Resources.Load("Prefab/Sun") as GameObject;
        // ��ʼ��̫����λ��
        float x = Random.Range(leftBottom.x + 30, rightTop.x - 30);
        Vector3 bornPos = new Vector3(x, rightTop.y, 0);
        GameObject sun = Instantiate(sunPrefab, bornPos, Quaternion.identity);
        // ����Ŀ��λ��
        float y = Random.Range(leftBottom.y + 100, leftBottom.y + 30);
        sun.GetComponent<Sun>().SetTargetPos(new Vector3(bornPos.x, y, 0));
    }


    public int GetPlantLine(GameObject plant)
    {
        GameObject lineObject = plant.transform.parent.parent.gameObject;
        string lineStr = lineObject.name;
        int line = int.Parse(Split(lineStr, "Line")[1]);
        return line;
    }

    public List<GameObject> GetLineZombies(int line)
    {
        string lineName = "born" + line.ToString();
        Transform bornObject = bornParent.transform.Find(lineName);
        List<GameObject> zombies = new List<GameObject>();
        for (int i = 0; i < bornObject.childCount; i++)
        {
            zombies.Add(bornObject.GetChild(i).gameObject);
        }
        return zombies;
    }
    public static string[] Split(string source, string str)
    {
        var list = new List<string>();
        while (true)
        {
            var index = source.IndexOf(str);
            if (index < 0) { list.Add(source); break; }
            var rs = source.Substring(0, index);
            list.Add(rs);
            source = source.Substring(index + str.Length);
        }
        return list.ToArray();
    }
}
