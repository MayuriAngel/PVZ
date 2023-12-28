using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;

public class UserPanel : BasePanel
{
    public Button btnOk;
    public Button btnCancel;
    public Button btnDelete;

    //滚动容器
    public ScrollRect scroll;
    //用户名的预制件
    public GameObject UserNamePrefab;


    //用字典来容纳所有的子节点
    private Dictionary<string, UserNameItem> menuNameItems;

    private string curUserName;
    public string CurName
        
    {
        get { return curUserName; }
        set
        {
            curUserName = value;
            RefreshSelectState();
        }
    }
    //更新所有子节点的选中状态
    public void RefreshSelectState()
    {
        foreach (UserNameItem item in menuNameItems.Values)
        {
            item.RefreSelect();
        }
    }

    protected override void Awake()
    {
        base.Awake();
        btnOk.onClick.AddListener(OnBtnOk);
        btnCancel.onClick.AddListener(OnBtnCancel);
        btnDelete.onClick.AddListener(OnBtnDelete);

        EventCenter.Instance.AddEventListener<UserData>(EventType.EventNewUserCreate, OnEventNewUserCreate);
        EventCenter.Instance.AddEventListener<UserData>(EventType.EventUserDelete, OnEventUserDelete);
        EventCenter.Instance.AddEventListener<string>(EventType.EventCurrentUserChange, OnEventCurrentUserChange);

    }
    private void Start()
    {
        RefreshMainPanel();
        CurName = BaseManager.Instance.currentUserName;
    }
    void OnEventNewUserCreate(UserData userData)
    {
        RefreshMainPanel();
    }
    void OnEventUserDelete(UserData userData)
    {
       
        RefreshMainPanel();
    }
    void OnEventCurrentUserChange(string curName)
    {
        RefreshSelectState();
    }

    void RefreshMainPanel()
    {
        foreach (Transform child in scroll.content)
        {
            Destroy(child.gameObject);
        }
        menuNameItems = new Dictionary<string, UserNameItem>();
        foreach (UserData userData in LocalConfig.LoadAllUseData())
        {
            Transform prefab = Instantiate(UserNamePrefab).transform;
            prefab.SetParent(scroll.content, false);
            prefab.localPosition = Vector3.zero;
            prefab.localScale = Vector3.one;
            prefab.localRotation = Quaternion.identity;
            prefab.GetComponent<UserNameItem>().InitItem(userData, this);
            menuNameItems.Add(userData.name, prefab.GetComponent<UserNameItem>());
        }
        Transform newPrefab = Instantiate(UserNamePrefab).transform;
        newPrefab.SetParent(scroll.content, false);
        newPrefab.localPosition = Vector3.zero;
        newPrefab.localScale = Vector3.one;
        newPrefab.localRotation = Quaternion.identity;
        newPrefab.GetComponent<UserNameItem>().InitNewUserItem();

    }
    private void OnBtnOk()
        
    {
        Debug.Log(">>>>>>>>> on btn ok");
        if (CurName != "")
        {
            BaseManager.Instance.SetCurrentUserName(CurName);
            ClosePanel();
        }
        else
        {
            print("空");
        }

    }

    private void OnBtnCancel()
    {
        Debug.Log(">>>>>>>>> on btn cancel");
        ClosePanel();
    }
    private void OnBtnDelete()
    {
        Debug.Log(">>>>>>>>> on btn delete");
        if (CurName == "")
        {
            return;
        }
        bool isSuccess = LocalConfig.ClearUserData(CurName);
        if (isSuccess && CurName == BaseManager.Instance.currentUserName)
        {
            List<UserData> users = LocalConfig.LoadAllUseData();
            if (users.Count > 0)
            {
                BaseManager.Instance.SetCurrentUserName(users[0].name);

               

            }
            else
            {
                BaseManager.Instance.SetCurrentUserName("");
                BaseUIManager.Instance.OpenPanel(UIConst.NewUserPanel);
            }
            
        }
    }
    public override void ClosePanel()
    {
        base.ClosePanel();
        EventCenter.Instance.RemoveEventListener<UserData>(EventType.EventNewUserCreate, OnEventNewUserCreate);
        EventCenter.Instance.RemoveEventListener<UserData>(EventType.EventUserDelete, OnEventUserDelete);
        EventCenter.Instance.RemoveEventListener<string>(EventType.EventCurrentUserChange, OnEventCurrentUserChange);
    }
}
