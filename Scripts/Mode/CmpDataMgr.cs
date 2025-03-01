using System;
using System.Collections;
using System.Collections.Generic;
using Tool;
using UnityEngine;
using Unity.VisualScripting;
public class CmpDataMgr : BaseSingleMono<CmpDataMgr>
{
    // Start is called before the first frame update
    public List<CmpDataItem> CmpDataItems = new List<CmpDataItem>();
    public Action Initaction;

    public void LoadData()
    {
        
        CmpDataItems=JsonMgr.Instance.LoadData<List<CmpDataItem>>("CmpData");
      
    }
    public CmpDataItem GetCmpData(int id)
    {
        return CmpDataItems[id];
    }
}



public class CmpDataItem
{
    public int ID;
    public string chip_name;
    public string PortColor;
    public int OutPortLimit;
    public int BaseNum;
    public string conditiondsb;
    public string Triggercondition;
    public string effectdsb;
    public string Effect;
    public string time;
    public string level;
    public string StoryDescribe;
    public int Price;
    public string ColorType;
}
