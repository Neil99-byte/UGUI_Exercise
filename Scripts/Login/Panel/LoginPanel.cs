using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoginPanel : BasePanel
{   //注册按钮 和 确定按钮
    public Button btnRegister;
    public Button btnSure;
    //用户账号 和 用户密码
    public InputField inputUN;
    public InputField inputPW;
    //勾选记住密码 和 自动登陆
    public Toggle togRem;
    public Toggle togAuto;

    public override void Init()
    {
        //注册按钮 监听事件
        btnRegister.onClick.AddListener(() =>{
            //显示注册面板
            UIManager.Instance.ShowMe<RegisterPanel>();
            //隐藏自己
            UIManager.Instance.HideMe<LoginPanel>();
        });

        //确定按钮 监听事件
        btnSure.onClick.AddListener(()=>{
            //判断用户名 密码是否正确
         if(   LoginManager.Instance.CheckUser(inputUN.text,inputPW.text))
            {
                //登录成功

                //记录登录数据
                LoginManager.Instance.LoginData.userName = inputUN.text;
                LoginManager.Instance.LoginData.passWord = inputPW.text;
                LoginManager.Instance.LoginData.rememberPw = togRem.isOn;
                LoginManager.Instance.LoginData.autoLogin = togAuto.isOn;
                LoginManager.Instance.SavaData();
                //隐藏自己
                UIManager.Instance.HideMe<LoginPanel>();
                //显示服务器面板
                //根据服务器信息 来进行判断 显示哪个面板
                if (LoginManager.Instance.LoginData.frontID <= 0)
                {
                    //如果从来没有选择过服务器 id为-1时  就应该直接打开 选服面板
                    UIManager.Instance.ShowMe<ChooseServerPanel>();
                }
                else
                {
                    //打开我们的服务器面板
                    UIManager.Instance.ShowMe<ServerPanel>();
                }
                
            }
         //登录失败
         else
            {
                UIManager.Instance.ShowMe<TipPanel>().ChangeInfo("用户名或者密码输入错误");
            }
        });

        //点击记住密码
        togRem.onValueChanged.AddListener(isOn =>
        {
            if (!isOn)
                togAuto.isOn = false;
        });

        //点击自动登录
        togAuto.onValueChanged.AddListener(isOn =>
        {if(isOn)
            togRem.isOn = true;
        });

    }

    public override void ShowMe()
    {
        base.ShowMe();
        //得到数据
        LoginData loginData = LoginManager.Instance.LoginData;

        togRem.isOn = loginData.rememberPw;
        togAuto.isOn = loginData.autoLogin;

        inputUN.text = loginData.userName;
        //根据是否勾选记住密码 决定更新密码输入框
        if(togRem.isOn)
        inputPW.text = loginData.passWord;

        //是否勾选自动登陆
        if(togAuto.isOn)
        {
            //自动去验证用户 密码
        }

    }


}
