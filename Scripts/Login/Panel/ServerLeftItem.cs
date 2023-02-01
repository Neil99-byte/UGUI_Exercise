using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ServerLeftItem : MonoBehaviour
{
    public Button btnSelf;
    public Text txtInfo;
    private int startIndex;
    private int endIndex;

    // Start is called before the first frame update
    void Start()
    {
        btnSelf.onClick.AddListener(() =>
        {//�����ť ��ʾ�ұ���ɵ����������
         //֪ͨѡ����� �ı��Ҳ����������
            ChooseServerPanel panel = UIManager.Instance.GetPanel<ChooseServerPanel>();
            panel.UpdatePanel(startIndex, endIndex);
        });
    }

    public void InitInfo(int startIndex,int endIndex)
    {
        this.startIndex = startIndex;
        this.endIndex = endIndex;

        //��������ʾ������ ������
        txtInfo.text = startIndex + " - " + endIndex + "��";
    }

  
}
