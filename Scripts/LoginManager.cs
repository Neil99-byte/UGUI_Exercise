using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoginManager 
{
    private static LoginManager instance = new LoginManager();
    public static LoginManager Instance => instance;

    private LoginData loginData;
    public LoginData LoginData => loginData;

    public RegisterData registerData;

    private List<ServerInfo> serverData;
    public List<ServerInfo> ServerData => serverData;
    #region ��¼����
    private LoginManager()
    {
        //ֱ��ͨ��Json������ ��ȡ����
      loginData=  JsonMgr.Instance.LoadData<LoginData>("LoginData");
        registerData = JsonMgr.Instance.LoadData<RegisterData>("RegisterData");
        serverData = JsonMgr.Instance.LoadData<List<ServerInfo>>("ServerInfo");
    }

    public void SavaData()
    {   //ͨ��Json������ ��������
        JsonMgr.Instance.SaveData(loginData, "LoginData");
        
    }
    #endregion

    #region ע������
    //�������ݷ���
    public void SaveReData()
    { //�����û��� ���뵽ע�������ֵ���
       
        JsonMgr.Instance.SaveData(registerData, "RegisterData");
    }

    //���ע���û����Ƿ����
    public bool RegisterUser(string userName,string passWorld)
    {//�ж��Ƿ�����û���
        if(registerData.registerInfo.ContainsKey(userName))
        {
            return false;
        }
        //�����ھͿ��Լ���ע��
        registerData.registerInfo.Add(userName, passWorld);
        SaveReData();
        return true;
    }

    //��֤�û����������Ƿ�Ϸ�
    public bool CheckUser(string userName,string passWord)
    {
        if (registerData.registerInfo.ContainsKey(userName))
        {
            if (registerData.registerInfo[userName] == passWord)
                return true;
        }
        return false;
    }

    #endregion
}
