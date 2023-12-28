using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewUserPanel : BasePanel
{
    public Button BtnOk;
    public Button BtnCancel;
    public InputField inputField;
    private string inputString;
    protected override void Awake()
    {
        base.Awake();
        BtnOk.onClick.AddListener(OnBtnOk);
        BtnCancel.onClick.AddListener(OnBtnCancel);
        inputField.onValueChanged.AddListener(OnInputChange);
    }
    public void OnBtnOk()
    {
        if (inputString.Trim() == "")
        {
            return;
        }
        else if (LocalConfig.LoadUserData(inputString) != null)
        {
            return;
        }
        //�������û�
        UserData userData = new UserData();
        userData.name = inputString;
        userData.level = 1;
        LocalConfig.SaveUserData(userData);

        //
        EventCenter.Instance.EventTrigger<UserData>(EventType.EventNewUserCreate, userData);
        //�رս���
        ClosePanel();
    }
    public void OnInputChange(string value)
    {
        inputString = value;
    }
    public void OnBtnCancel()
    {
        if (BaseManager.Instance.currentUserName == "")
        {
            print("������Ҫһ���û���");
            return;
        }
        ClosePanel();
    }
    void Start()
    {

    }


    void Update()
    {

    }
}
