using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoginPanel : BasePanel
{   //ע�ᰴť �� ȷ����ť
    public Button btnRegister;
    public Button btnSure;
    //�û��˺� �� �û�����
    public InputField inputUN;
    public InputField inputPW;
    //��ѡ��ס���� �� �Զ���½
    public Toggle togRem;
    public Toggle togAuto;

    public override void Init()
    {
        //ע�ᰴť �����¼�
        btnRegister.onClick.AddListener(() =>{
            //��ʾע�����
            UIManager.Instance.ShowMe<RegisterPanel>();
            //�����Լ�
            UIManager.Instance.HideMe<LoginPanel>();
        });

        //ȷ����ť �����¼�
        btnSure.onClick.AddListener(()=>{
            //�ж��û��� �����Ƿ���ȷ
         if(   LoginManager.Instance.CheckUser(inputUN.text,inputPW.text))
            {
                //��¼�ɹ�

                //��¼��¼����
                LoginManager.Instance.LoginData.userName = inputUN.text;
                LoginManager.Instance.LoginData.passWord = inputPW.text;
                LoginManager.Instance.LoginData.rememberPw = togRem.isOn;
                LoginManager.Instance.LoginData.autoLogin = togAuto.isOn;
                LoginManager.Instance.SavaData();
                //�����Լ�
                UIManager.Instance.HideMe<LoginPanel>();
                //��ʾ���������
                //���ݷ�������Ϣ �������ж� ��ʾ�ĸ����
                if (LoginManager.Instance.LoginData.frontID <= 0)
                {
                    //�������û��ѡ��������� idΪ-1ʱ  ��Ӧ��ֱ�Ӵ� ѡ�����
                    UIManager.Instance.ShowMe<ChooseServerPanel>();
                }
                else
                {
                    //�����ǵķ��������
                    UIManager.Instance.ShowMe<ServerPanel>();
                }
                
            }
         //��¼ʧ��
         else
            {
                UIManager.Instance.ShowMe<TipPanel>().ChangeInfo("�û������������������");
            }
        });

        //�����ס����
        togRem.onValueChanged.AddListener(isOn =>
        {
            if (!isOn)
                togAuto.isOn = false;
        });

        //����Զ���¼
        togAuto.onValueChanged.AddListener(isOn =>
        {if(isOn)
            togRem.isOn = true;
        });

    }

    public override void ShowMe()
    {
        base.ShowMe();
        //�õ�����
        LoginData loginData = LoginManager.Instance.LoginData;

        togRem.isOn = loginData.rememberPw;
        togAuto.isOn = loginData.autoLogin;

        inputUN.text = loginData.userName;
        //�����Ƿ�ѡ��ס���� �����������������
        if(togRem.isOn)
        inputPW.text = loginData.passWord;

        //�Ƿ�ѡ�Զ���½
        if(togAuto.isOn)
        {
            //�Զ�ȥ��֤�û� ����
        }

    }


}
