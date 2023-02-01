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
            //�����Լ�
            UIManager.Instance.HideMe<ServerPanel>();
            //���ص�¼���
            UIManager.Instance.ShowMe<LoginPanel>();
        });

        btnChange.onClick.AddListener(() =>
        {
            //�����Լ�
            UIManager.Instance.HideMe<ServerPanel>();
            //��ת��ѡ����������
            UIManager.Instance.ShowMe<ChooseServerPanel>();
        });

        btnSure.onClick.AddListener(() =>
        {
            //��¼��Ϸ
            //�����Լ�
            UIManager.Instance.HideMe<ServerPanel>();
            //�л�����
            SceneManager.LoadScene("GameScene");
        });
    }

    public override void ShowMe()
    {
        base.ShowMe();
        //��ʾ�Լ���ʱ�� ���� ��ǰѡ��ķ���������
        //֮�� ���ǻ�ͨ�� ��¼����һ�ε�¼�ķ�����ID ����������
        int id = LoginManager.Instance.LoginData.frontID;
        if (id <= 0)
        {
            txtName.text = "��ѡ��";
        }
        else
        {
            ServerInfo info = LoginManager.Instance.ServerData[id - 1];
            txtName.text = info.id + "�� " + info.name;
        }

    }
}
