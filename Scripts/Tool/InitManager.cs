using System;
using System.Collections;
using System.Collections.Generic;
using Tool;
using Unity.VisualScripting;
using UnityEngine;

public class InitManager : BaseSingleMono<InitManager>
{
    public Action InitAction;
    private Action myDelegate;

    void Start()
    {
        InitAction += CmpDataMgr.GetInstance().LoadData;
        InitAction += PassDataMgr.GetInstance().LoadData;
        InitAction += ShopManager.GetInstance().InitShop;
        InitAction += GameManager.GetInstance().InitGameMgr;
      InitAction.Invoke();
    }



   
}
