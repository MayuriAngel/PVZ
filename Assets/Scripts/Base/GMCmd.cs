using UnityEngine;
using UnityEditor;
public class GMCmd
{
    //��unity�˵������һ��CMCmd�˵�
    //Ϊ�����һ���˵���
    [MenuItem("CMCmd/SaveLocalConfig")]
    public static void SaveLocalConfig()
    {
        for (int i = 0; i < 5; i++)
            
        {
            UserData userData = new UserData();
            userData.name = "JXUFE" + i.ToString();
            userData.level = i;
            LocalConfig.SaveUserData(userData);
        }
        Debug.Log("Save End !!!!!!!!!!!!!!!!!!!!");
    }

    [MenuItem("CMCmd/LoadLocalConfig")]
    public static void LoadLocalConfig()
    {
        for (int i = 0; i < 5; i++)
        {
            string name = "JXUFE" + i.ToString();
            UserData userData = LocalConfig.LoadUserData(name);
            Debug.Log(userData.name);
            Debug.Log(userData.level);
        }
    }

    [MenuItem("CMCmd/OpenMainMenu")]
    public static void OpenMainMenu()
    {
        BaseUIManager.Instance.OpenPanel(UIConst.MainMenuPanel);
    }

}
