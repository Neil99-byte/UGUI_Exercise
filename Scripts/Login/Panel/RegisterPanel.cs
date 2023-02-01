using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RegisterPanel : BasePanel
{   //ȷ����ť �� ȡ����ť
    public Button btnSure;
    public Button btnCancel;
    //�˺����� �� ��������
    public InputField inputUN;
    public InputField inputPW;

    private LoginData loginData;
    public LoginData LoginData => loginData;

   
    public override void Init()
    {
      //ȷ����ť �����¼�
        btnSure.onClick.AddListener(() =>
        {if (inputUN.text != null && inputPW.text != null)
            {
                // ͨ��json�����ж��û��� �Ƿ����
              if(  LoginManager.Instance.RegisterUser(inputUN.text, inputPW.text))
                {
                    //ע��ɹ�
                    //�����Լ� ��ʾ��¼���
                    UIManager.Instance.HideMe<RegisterPanel>();
                  LoginPanel panel=  UIManager.Instance.ShowMe<LoginPanel>();
                    //�Զ����µ�¼�������ʾ����
                    panel.inputUN.text  = inputUN.text;
                    panel.inputPW.text = inputPW.text;
                }
              else
                {
                    UIManager.Instance.ShowMe<TipPanel>().ChangeInfo("�û��Ѿ�����");
                    inputUN.text = "";
                   inputPW.text = "";
                }

              
            }
        });

        //ȡ����ť �����¼�
        btnCancel.onClick.AddListener(() =>
        {
            //�����Լ�
            UIManager.Instance.HideMe<RegisterPanel>();
            //��ʾ��¼���
            UIManager.Instance.ShowMe<LoginPanel>();
        });

        
    }
}
