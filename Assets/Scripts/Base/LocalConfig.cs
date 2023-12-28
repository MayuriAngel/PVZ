// �����ļ���д
using System.IO;
// ����json���л��ͷ����л�
using Newtonsoft.Json;
// Application.persistentDataPath����������
using UnityEngine;
// �޸�0��ʹ���ֵ������ռ�
using System.Collections.Generic;

public class LocalConfig
{

    // �޸�1������usersData��������
    public static Dictionary<string, UserData> usersData = new Dictionary<string, UserData>();

    public static ClientData clientData;
    // ����1��ѡ��һЩ�������������ַ���ע�Ᵽ�ܣ�
    public static char[] keyChars = { 'a', 'b', 'c', 'd', 'e' };

    // ����2�� ���ܷ���
    public static string Encrypt(string data)
    {
        char[] dataChars = data.ToCharArray();
        for (int i = 0; i < dataChars.Length; i++)
        {
            char dataChar = dataChars[i];
            char keyChar = keyChars[i % keyChars.Length];
            // �ص㣺 ͨ�����õ��µ��ַ�
            char newChar = (char)(dataChar ^ keyChar);
            dataChars[i] = newChar;
        }
        return new string(dataChars);
    }

    // ����3�� ���ܷ���
    public static string Decrypt(string data)
    {
        return Encrypt(data);
    }

    // �����û������ı�
    public static void SaveUserData(UserData userData)
    {
        // ��persistentDataPath�´���һ��/users�ļ��У��������
        if (!File.Exists(Application.persistentDataPath + "/users"))
        {
            System.IO.Directory.CreateDirectory(Application.persistentDataPath + "/users");
        }

        // �޸�2�����滺������
        usersData[userData.name] = userData;

        // ת���û�����ΪJSON�ַ���
        string jsonData = JsonConvert.SerializeObject(userData);
#if UNITY_EDITOR
        // ����4
        jsonData = Encrypt(jsonData);
#endif
        // ��JSON�ַ���д���ļ��У��ļ���ΪuserData.name��
        File.WriteAllText(Application.persistentDataPath + string.Format("/users/{0}.json", userData.name), jsonData);
    }

    // ��ȡ�û����ݵ��ڴ�
    public static UserData LoadUserData(string userName)
    {
        // �޸�3�� ���ȴӻ�����ȡ���ݣ������Ǵ��ı��ļ��ж�ȡ
        if (usersData.ContainsKey(userName))
        {
            return usersData[userName];
        }

        string path = Application.persistentDataPath + string.Format("/users/{0}.json", userName);
        // ����û������ļ��Ƿ����
        if (File.Exists(path))
        {
            // ���ı��ļ��м���JSON�ַ���
            string jsonData = File.ReadAllText(path);
#if UNITY_EDITOR
            // ����5
            jsonData = Decrypt(jsonData);
#endif
            // ��JSON�ַ���ת��Ϊ�û��ڴ�����
            UserData userData = JsonConvert.DeserializeObject<UserData>(jsonData);
            return userData;
        }
        else
        {
            return null;
        }
    }
    public static List<UserData> LoadAllUseData()
    {
        string floderPath = Application.persistentDataPath + "/users";
        DirectoryInfo folder = new DirectoryInfo(floderPath);
        List<UserData> users = new List<UserData>();
        FileInfo[] allFiles = folder.GetFiles("*.json");
        //�ȼ���ڴ�
        if (allFiles.Length == usersData.Count)
        {
            foreach (UserData userData in usersData.Values)
            {
                users.Add(userData);

            }
            return users;
        }
        //�ٴ�Ӳ���м���
        foreach (FileInfo file in allFiles)
        {

            UserData userData = LoadUserData(file.Name.Split('.')[0]);
            
            if (userData != null)
            {
                users.Add(userData);
            }

        }
        return users;
    }
    public static bool ClearUserData(string userName)
    {
        string path = Application.persistentDataPath + string.Format("/users/{0}.json", userName);
        if (File.Exists(path))
        {
            UserData oldUseData = LoadUserData(userName);
            File.Delete(path);
            if (usersData.ContainsKey(userName))
            {
                
                usersData.Remove(userName);
            }
            EventCenter.Instance.EventTrigger<UserData>(EventType.EventUserDelete, oldUseData);
            return true;
        }
        else
        {
            Debug.Log("ɾ��ʧ�ܣ�����");
            return false;
        }
    }

    //�����û������ı�
    public static void SaveClientData(ClientData data)
    {
        clientData = data;
        //ת���û�����ΪJSON�ַ���
        string jsonData = JsonConvert.SerializeObject(clientData);
        //����
        //jsonData = Encrypt(jsonData);
        //��JSON�ַ���д���ļ���
        File.WriteAllText(Application.persistentDataPath + "/clent_data.json", jsonData);
    }
    //��ȡ�û�����
    public static ClientData LoadClientData()
    {
        //�ȴӻ�����ȡ���ݣ������Ǵ��ı��ļ��ж�ȡ
        if (clientData != null)
        {
            return clientData;
        }
        string path = Application.persistentDataPath + "/client_data.json";
        //����û������ļ��Ƿ����
        if (File.Exists(path))
        {
            //���ı��ļ��м���JSON�ַ���
            string jsonData = File.ReadAllText(path);
            //����
            //jsonData = Encrypt(jsonData);
            //��JSON�ַ���ת��Ϊ�û�����
            ClientData clientData = JsonConvert.DeserializeObject<ClientData>(jsonData);
            return clientData;
        }
        else
        {
            clientData = new ClientData();
            string jsonData = JsonConvert.SerializeObject(clientData);
            File.WriteAllText(Application.persistentDataPath + "/client_data.json", jsonData);
            return clientData;
        }
    }
}




//�ٴ�
public class UserData
{
    public string name;
    public int level;
}
public class ClientData
{
    public string curUserName = "";
    public override string ToString()
    {
        return "curUserName" + curUserName;
    }
}