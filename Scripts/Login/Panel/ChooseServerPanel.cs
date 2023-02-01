using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;
using UnityEngine.UI;

public class ChooseServerPanel :BasePanel
{
    //���ҹ�����ͼ
    public ScrollRect svLeft;
    public ScrollRect svRight;

    //��һ�ε�¼�ķ����������Ϣ
    public Text txtName;
    public Image imgState;


    //��ǰѡ��ķ�������ط�Χ
    public Text txtRange;

    private List<GameObject> itemList = new List<GameObject>();

    public override void Init()
    {
        //��̬�������� ���䰴ť

        //��ȡ���������б����Ϣ
        List<ServerInfo> infoList = LoginManager.Instance.ServerData;

        //�õ�һ��Ҫѭ�����ٸ����䰴ť
        int num = infoList.Count / 5 + 1;

        for (int i = 0; i < num; i++)
        {
            //��̬����Ԥ�������
            GameObject item = Instantiate(Resources.Load<GameObject>("UI/ServerLeftItem"));
            item.transform.SetParent(svLeft.content, false);
            //��ʼ��
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

        //��ʾ�Լ�
        //Ӧ�ó�ʼ�� ��һ��ѡ��ķ�����
        int id = LoginManager.Instance.LoginData.frontID;
        if(id<=0)
        {
            txtName.text = "��ѡ��";
            imgState.gameObject.SetActive(false);
        }
        else
        {
            ServerInfo info = LoginManager.Instance.ServerData[id - 1];
            txtName.text = info.id + "�� " + info.name;

            imgState.gameObject.SetActive(true);

            SpriteAtlas sa = Resources.Load<SpriteAtlas>("Login");
            switch (info.state)
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

        //���µ�ǰ��ѡ��
        UpdatePanel(1, 5 > LoginManager.Instance.ServerData.Count ? LoginManager.Instance.ServerData.Count : 5);
    }

    public void UpdatePanel(int startIndex,int endIndex)
    {
        //���·�����������ʾ
        txtRange.text = "������" + startIndex + "-" + endIndex;
        //ɾ��֮ǰ�İ�ť
        for (int i = 0; i < itemList.Count; i++)
        {
            Destroy(itemList[i]);
        }
        itemList.Clear();
        //�����µİ�ť
        for (int i = startIndex; i <= endIndex; i++)
        {
            //��ȡ��������Ϣ
            ServerInfo nowInfo = LoginManager.Instance.ServerData[i - 1];

            //��̬����Ԥ����
            GameObject serverItem = Instantiate(Resources.Load<GameObject>("UI/ServerRightItem"));
            serverItem.transform.SetParent(svRight.content, false);

            ServerRightItem rightItem = serverItem.GetComponent<ServerRightItem>();
            rightItem.InitInfo(nowInfo);

            itemList.Add(serverItem);
        }
    }


}
