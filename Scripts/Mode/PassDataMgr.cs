using System;
using System.Collections;
using System.Collections.Generic;
using Tool;
using UnityEngine;

public class PassDataMgr : BaseSingleMono<PassDataMgr>
{
    public List<PassDataItem> PassDataItems = new List<PassDataItem>();


  

    public void LoadData()
    {
        PassDataItems=JsonMgr.Instance.LoadData<List<PassDataItem>>("PassData");
        Debug.Log(PassDataItems.Count);
    }
    public PassDataItem GetPassData(int id)
    {
        if (PassDataItems.Count <= id)
        {
            return null;
        }
        return PassDataItems[id];
    }
}

public class PassDataItem
{
    public int PassID;
    public int Red;
    public int Yellow;
    public int Blue;
    public int Health;
}
