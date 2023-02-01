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
        {//点击按钮 显示右边面吧的区间服务器
         //通知选服面板 改变右侧的区间内容
            ChooseServerPanel panel = UIManager.Instance.GetPanel<ChooseServerPanel>();
            panel.UpdatePanel(startIndex, endIndex);
        });
    }

    public void InitInfo(int startIndex,int endIndex)
    {
        this.startIndex = startIndex;
        this.endIndex = endIndex;

        //把区间显示的内容 更新了
        txtInfo.text = startIndex + " - " + endIndex + "区";
    }

  
}
