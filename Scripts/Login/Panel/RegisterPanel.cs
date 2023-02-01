using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RegisterPanel : BasePanel
{   //确定按钮 和 取消按钮
    public Button btnSure;
    public Button btnCancel;
    //账号输入 和 密码输入
    public InputField inputUN;
    public InputField inputPW;

    private LoginData loginData;
    public LoginData LoginData => loginData;

   
    public override void Init()
    {
      //确定按钮 监听事件
        btnSure.onClick.AddListener(() =>
        {if (inputUN.text != null && inputPW.text != null)
            {
                // 通过json管理判断用户名 是否存在
              if(  LoginManager.Instance.RegisterUser(inputUN.text, inputPW.text))
                {
                    //注册成功
                    //隐藏自己 显示登录面板
                    UIManager.Instance.HideMe<RegisterPanel>();
                  LoginPanel panel=  UIManager.Instance.ShowMe<LoginPanel>();
                    //自动更新登录面板上显示数据
                    panel.inputUN.text  = inputUN.text;
                    panel.inputPW.text = inputPW.text;
                }
              else
                {
                    UIManager.Instance.ShowMe<TipPanel>().ChangeInfo("用户已经存在");
                    inputUN.text = "";
                   inputPW.text = "";
                }

              
            }
        });

        //取消按钮 监听事件
        btnCancel.onClick.AddListener(() =>
        {
            //隐藏自己
            UIManager.Instance.HideMe<RegisterPanel>();
            //显示登录面板
            UIManager.Instance.ShowMe<LoginPanel>();
        });

        
    }
}
