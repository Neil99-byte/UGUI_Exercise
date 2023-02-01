using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager
{
    private static UIManager instance = new UIManager();

    public static UIManager Instance => instance;

    private UIManager()
    {
        canvasTrans = GameObject.Find("Canvas").transform;
        GameObject.DontDestroyOnLoad(canvasTrans.gameObject);
    }

    public Dictionary<string, BasePanel> PanelDic = new Dictionary<string, BasePanel>();
    public Transform canvasTrans;
  
    public T ShowMe<T>() where T:BasePanel
    {
        string panelName = typeof(T).Name;
        if(PanelDic.ContainsKey(panelName))
        {
            return PanelDic[panelName] as T;
        }
      GameObject panelObj= GameObject.Instantiate(Resources.Load<GameObject>("UI/" + panelName));
        panelObj.transform.SetParent(canvasTrans, false);

        T panel = panelObj.GetComponent<T>();
        PanelDic.Add(panelName, panel);
        //��ʾ���
        panel.ShowMe();

        return panel;
    }
    public void HideMe<T>(bool isFade=true) where T:BasePanel
    {
        string panelName = typeof(T).Name;
        if(PanelDic.ContainsKey(panelName))
        {
            if (isFade)
            {
                PanelDic[panelName].HideMe(() =>
              {//ɾ�����
                  GameObject.Destroy(PanelDic[panelName].gameObject);
                  //ȥ���ֵ������
                  PanelDic.Remove(panelName);
              });
            }
        else
            {
                GameObject.Destroy(PanelDic[panelName].gameObject);
                PanelDic.Remove(panelName);
            }
        }
    }

    public T GetPanel<T>() where T:BasePanel
    { 
        string panelName = typeof(T).Name;
        if (PanelDic.ContainsKey(panelName))
            return PanelDic[panelName] as T;
        return null;
    }
}
