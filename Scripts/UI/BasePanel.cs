using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class BasePanel : MonoBehaviour
{
    public CanvasGroup canvasGroup;
    public float alphaSpeed = 10;
    private bool isShow = true;

   private UnityAction HideAction;
   
    /// <summary>
    /// 主要用于 子面板按钮监听事件
    /// </summary>
    public abstract void Init();

    private void Awake()
    {
        canvasGroup = this.GetComponent<CanvasGroup>();
        if (canvasGroup == null)
        {
            canvasGroup = this.gameObject.AddComponent<CanvasGroup>();
        }
    }
    // Start is called before the first frame update
    protected virtual void Start()
    {
        Init();
    }

    public virtual void ShowMe()
    {
        isShow = true;
        canvasGroup.alpha = 0;
    }

    public virtual void HideMe(UnityAction callBack)
    {
        isShow = false;
        canvasGroup.alpha = 1;
        HideAction = callBack;
    }
    // Update is called once per frame
    void Update()
    {
        //淡入
        if(isShow && canvasGroup.alpha!=1)
        {
            canvasGroup.alpha += alphaSpeed * Time.deltaTime;
            if (canvasGroup.alpha >= 1)
                canvasGroup.alpha = 1;
        }
        //淡出
        else if(!isShow)
        {
            canvasGroup.alpha -= alphaSpeed * Time.deltaTime;
            if (canvasGroup.alpha <= 0)
                canvasGroup.alpha = 0;
            //通过委托动态删除面板
            HideAction?.Invoke();
        }
        
    }
}
