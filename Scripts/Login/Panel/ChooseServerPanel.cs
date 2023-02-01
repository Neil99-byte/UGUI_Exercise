using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;
using UnityEngine.UI;

public class ChooseServerPanel :BasePanel
{
    //左右滚动视图
    public ScrollRect svLeft;
    public ScrollRect svRight;

    //上一次登录的服务器相关信息
    public Text txtName;
    public Image imgState;


    //当前选择的服务器相关范围
    public Text txtRange;

    private List<GameObject> itemList = new List<GameObject>();

    public override void Init()
    {
        //动态创建左侧的 区间按钮

        //获取到服务器列表的信息
        List<ServerInfo> infoList = LoginManager.Instance.ServerData;

        //得到一共要循环多少个区间按钮
        int num = infoList.Count / 5 + 1;

        for (int i = 0; i < num; i++)
        {
            //动态创建预设体对象
            GameObject item = Instantiate(Resources.Load<GameObject>("UI/ServerLeftItem"));
            item.transform.SetParent(svLeft.content, false);
            //初始化
            ServerLeftItem serverLeft = item.GetComponent<ServerLeftItem>();
            int startIndex = i * 5 + 1;
            int endIndex = 5 * (i + 1);

            if (endIndex > infoList.Count)
                endIndex = infoList.Count;

            serverLeft.InitInfo(startIndex, endIndex);
        }
    }
   
   public override void ShowMe()
    {
        base.ShowMe();

        //显示自己
        //应该初始化 上一次选择的服务器
        int id = LoginManager.Instance.LoginData.frontID;
        if(id<=0)
        {
            txtName.text = "无选择";
            imgState.gameObject.SetActive(false);
        }
        else
        {
            ServerInfo info = LoginManager.Instance.ServerData[id - 1];
            txtName.text = info.id + "区 " + info.name;

            imgState.gameObject.SetActive(true);

            SpriteAtlas sa = Resources.Load<SpriteAtlas>("Login");
            switch (info.state)
            {
                case 0://无状态
                    break;
                case 1://流畅
                    imgState.sprite = sa.GetSprite("ui_DL_liuchang_01");
                    break;
                case 2://繁忙
                    imgState.sprite = sa.GetSprite("ui_DL_fanhua_01");
                    break;
                case 3://火爆
                    imgState.sprite = sa.GetSprite("ui_DL_huobao_01");
                    break;
                case 4://维护
                    imgState.sprite = sa.GetSprite("ui_DL_weihu_01");
                    break;
            }
        }

        //更新当前的选择
        UpdatePanel(1, 5 > LoginManager.Instance.ServerData.Count ? LoginManager.Instance.ServerData.Count : 5);
    }

    public void UpdatePanel(int startIndex,int endIndex)
    {
        //更新服务器区间显示
        txtRange.text = "服务器" + startIndex + "-" + endIndex;
        //删除之前的按钮
        for (int i = 0; i < itemList.Count; i++)
        {
            Destroy(itemList[i]);
        }
        itemList.Clear();
        //创建新的按钮
        for (int i = startIndex; i <= endIndex; i++)
        {
            //获取服务器信息
            ServerInfo nowInfo = LoginManager.Instance.ServerData[i - 1];

            //动态创建预设体
            GameObject serverItem = Instantiate(Resources.Load<GameObject>("UI/ServerRightItem"));
            serverItem.transform.SetParent(svRight.content, false);

            ServerRightItem rightItem = serverItem.GetComponent<ServerRightItem>();
            rightItem.InitInfo(nowInfo);

            itemList.Add(serverItem);
        }
    }


}
