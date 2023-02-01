using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // UIManager.Instance.ShowMe<TipPanel>();
        //  UIManager.Instance.GetPanel<TipPanel>().ChangeInfo("≤‚ ‘ƒ⁄»›");
         UIManager.Instance.ShowMe<LoginPanel>();
      //  UIManager.Instance.ShowMe<RegisterPanel>();
    }

    // Update is called once per frame
   
}
