using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ServerPanel : BasePanel
{
    public Button btnCancel;
    public Button btnChange;
    public Button btnSure;

    public Text txtName;
    public override void Init()
    {
        btnCancel.onClick.AddListener(() =>
        {
            //隐藏自己
            UIManager.Instance.HideMe<ServerPanel>();
            //返回登录面板
            UIManager.Instance.ShowMe<LoginPanel>();
        });

        btnChange.onClick.AddListener(() =>
        {
            //隐藏自己
            UIManager.Instance.HideMe<ServerPanel>();
            //跳转到选择服务器面板
            UIManager.Instance.ShowMe<ChooseServerPanel>();
        });

        btnSure.onClick.AddListener(() =>
        {
            //登录游戏
            //隐藏自己
            UIManager.Instance.HideMe<ServerPanel>();
            //切换场景
            SceneManager.LoadScene("GameScene");
        });
    }

    public override void ShowMe()
    {
        base.ShowMe();
        //显示自己的时候 更新 当前选择的服务器名字
        //之后 我们会通过 记录的上一次登录的服务器ID 来更新内容
        int id = LoginManager.Instance.LoginData.frontID;
        if (id <= 0)
        {
            txtName.text = "无选择";
        }
        else
        {
            ServerInfo info = LoginManager.Instance.ServerData[id - 1];
            txtName.text = info.id + "区 " + info.name;
        }

    }
}
