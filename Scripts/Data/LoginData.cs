using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoginData 
{//用户登录账号
    public string userName;
    //用户登录密码
    public string passWord;
    //勾选记住密码
    public bool rememberPw;
    //自动登录
    public bool autoLogin;

    //-1代表没有选择过服务器
    public int frontID = 0;
}
