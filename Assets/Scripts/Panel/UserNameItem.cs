using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UserNameItem : MonoBehaviour
{
    private GameObject select;
    private Text txt;
    //�û�����
    private UserData userData;
    private Button btn;
    private UserPanel parent;

    
    //nameΪ�û�����  newΪ�������û�
    public string ItemType = "name";
    private void Awake()
    {
        txt = transform.Find("Name").GetComponent<Text>();
        select = transform.Find("Select").gameObject;
        select.SetActive(false);
        btn = GetComponent<Button>();
        //button��Ӧ
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
        txt.text = "�������û�";
    }

    void OnBtnNameItem()
    {
        if (ItemType == "name")
        {
            //�޸��б��ѡ��״̬
            parent.CurName = userData.name;
        }
        else
        {
            //�����û�����
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
