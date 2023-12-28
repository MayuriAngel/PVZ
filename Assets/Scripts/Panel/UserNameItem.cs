using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UserNameItem : MonoBehaviour
{
    private GameObject select;
    private Text txt;
    //用户数据
    private UserData userData;
    private Button btn;
    private UserPanel parent;

    
    //name为用户数据  new为创建新用户
    public string ItemType = "name";
    private void Awake()
    {
        txt = transform.Find("Name").GetComponent<Text>();
        select = transform.Find("Select").gameObject;
        select.SetActive(false);
        btn = GetComponent<Button>();
        //button响应
        btn.onClick.AddListener(OnBtnNameItem);
    }
    public void InitItem(UserData userData, UserPanel userPanel)
    {
        this.userData = userData;
        txt.text = userData.name;
        parent = userPanel;


    }
    
    public void InitNewUserItem()
    {
        ItemType = "new";
        txt.text = "创建新用户";
    }

    void OnBtnNameItem()
    {
        if (ItemType == "name")
        {
            //修改列表的选中状态
            parent.CurName = userData.name;
        }
        else
        {
            //打开新用户界面
            BaseUIManager.Instance.OpenPanel(UIConst.NewUserPanel);
        }
    }
    public void RefreSelect()
    {
        select.SetActive(userData.name == parent.CurName);
    }
    private void Start()
    {

    }
    private void Update()
    {

    }
}
