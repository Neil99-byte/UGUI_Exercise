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
            //��¼��ǰ������
            LoginManager.Instance.LoginData.frontID = nowServerInfo.id;
            //���� ѡ�������
            UIManager.Instance.HideMe<ChooseServerPanel>();
            //��ʾ ���������
            UIManager.Instance.ShowMe<ServerPanel>();
        });

    }
    public void InitInfo(ServerInfo info)
    {
        nowServerInfo = info;

        txtName.text = info.id + "�� " + info.name;

        imgIsNew.gameObject.SetActive(info.isNew);

        imgState.gameObject.SetActive(true);
        SpriteAtlas sa = Resources.Load<SpriteAtlas>("Login");
        switch(info.state)
        {
            case 0://��״̬
                break;
            case 1://����
                imgState.sprite = sa.GetSprite("ui_DL_liuchang_01");
                break;
            case 2://��æ
                imgState.sprite = sa.GetSprite("ui_DL_fanhua_01");
                break;
            case 3://��
                imgState.sprite = sa.GetSprite("ui_DL_huobao_01");
                break;
            case 4://ά��
                imgState.sprite = sa.GetSprite("ui_DL_weihu_01");
                break;
        }
    }
}
