using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuPanel : BasePanel
{
    public Button btnChangeUser;
    public Text userNameText;
    public Text samllLevelTex;
    public Button btnAdventure;
    public Button btnExit;
    public Button btnHelp;
    public Button btnOK;
    public GameObject Help;
    public GameObject IsExit;
    protected override void Awake()
    {
        
        base.Awake();
        btnAdventure.onClick.AddListener(OnBtnAdv);
        btnChangeUser.onClick.AddListener(OnBtnChangeUser);
        btnExit.onClick.AddListener(OnBtnExit);
        btnHelp.onClick.AddListener(OnBtnHelp);
        btnOK.onClick.AddListener(OnBtnOK);
        EventCenter.Instance.AddEventListener<UserData>(EventType.EventNewUserCreate, OnEventNewUserCreate);
        EventCenter.Instance.AddEventListener<string>(EventType.EventCurrentUserChange, OnEventCurrentUserChange);
    }
    private void Start()
    {
        if (BaseManager.Instance.currentUserName == "")
        {
            BaseUIManager.Instance.OpenPanel(UIConst.NewUserPanel);
            return;
        }
        userNameText.text = BaseManager.Instance.currentUserName;
        UserData userData = LocalConfig.LoadUserData(BaseManager.Instance.currentUserName);
        if (userData != null)
        {
            samllLevelTex.text = userData.level.ToString();
        }
    }
    public void OnBtnHelp()
    {
        
        Help.SetActive(true);
    }
    public void OnBtnOK()
    {
        
        Help.SetActive(false);
    }
    public void OnBtnExit()
    {
        
        IsExit.SetActive(true);
        
    }
    void OnBtnAdv()
    {
        
        SceneManager.LoadScene("Game");
    }
    void OnEventNewUserCreate(UserData userData)
    {
        
        userNameText.text = userData.name;
        samllLevelTex.text = userData.level.ToString();
    }
    void OnEventCurrentUserChange(string curName)
    {
        //SoundManager.instance.PlaySound(Globals.S_Button);
        userNameText.text = curName;
        if (LocalConfig.LoadUserData(curName) == null)
        {
            samllLevelTex.text = "1";
            return;
        }
        samllLevelTex.text = LocalConfig.LoadUserData(curName).level.ToString();
    }
    private void OnBtnChangeUser()
    {
        
        //打开用户列表界面
        BaseUIManager.Instance.OpenPanel(UIConst.UserPanel);
    }
    public override void ClosePanel()
    {
        base.ClosePanel();
        EventCenter.Instance.RemoveEventListener<UserData>(EventType.EventNewUserCreate, OnEventNewUserCreate);
        //EventCenter.Instance.RemoveEventListener<UserData>(EventType.EventUserDelete, OnEventUserDelete);
        EventCenter.Instance.RemoveEventListener<string>(EventType.EventCurrentUserChange, OnEventCurrentUserChange);
    }
}
