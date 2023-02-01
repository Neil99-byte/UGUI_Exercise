using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;
using UnityEngine.UI;

public class ServerRightItem : MonoBehaviour
{
    public Button btnSelf;

    public Image imgState;

    public Image imgIsNew;

    public Text txtName;
    public ServerInfo nowServerInfo;

    // Start is called before the first frame update
    void Start()
    {
        btnSelf.onClick.AddListener(() =>
        {
            //记录当前服务器
            LoginManager.Instance.LoginData.frontID = nowServerInfo.id;
            //隐藏 选服器面板
            UIManager.Instance.HideMe<ChooseServerPanel>();
            //显示 服务器面板
            UIManager.Instance.ShowMe<ServerPanel>();
        });

    }
    public void InitInfo(ServerInfo info)
    {
        nowServerInfo = info;

        txtName.text = info.id + "区 " + info.name;

        imgIsNew.gameObject.SetActive(info.isNew);

        imgState.gameObject.SetActive(true);
        SpriteAtlas sa = Resources.Load<SpriteAtlas>("Login");
        switch(info.state)
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
}
