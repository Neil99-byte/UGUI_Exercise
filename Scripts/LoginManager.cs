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
    #region 登录数据
    private LoginManager()
    {
        //直接通过Json管理器 读取数据
      loginData=  JsonMgr.Instance.LoadData<LoginData>("LoginData");
        registerData = JsonMgr.Instance.LoadData<RegisterData>("RegisterData");
        serverData = JsonMgr.Instance.LoadData<List<ServerInfo>>("ServerInfo");
    }

    public void SavaData()
    {   //通过Json管理器 保存数据
        JsonMgr.Instance.SaveData(loginData, "LoginData");
        
    }
    #endregion

    #region 注册数据
    //保存数据方法
    public void SaveReData()
    { //保存用户名 密码到注册数据字典中
       
        JsonMgr.Instance.SaveData(registerData, "RegisterData");
    }

    //检查注册用户名是否存在
    public bool RegisterUser(string userName,string passWorld)
    {//判断是否存在用户名
        if(registerData.registerInfo.ContainsKey(userName))
        {
            return false;
        }
        //不存在就可以继续注册
        registerData.registerInfo.Add(userName, passWorld);
        SaveReData();
        return true;
    }

    //验证用户名和密码是否合法
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
