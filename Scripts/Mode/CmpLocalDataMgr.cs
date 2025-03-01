using System.Collections;
using System.Collections.Generic;
using Tool;
using UnityEngine;

public class CmpLocalDataMgr : BaseSingleMono<CmpLocalDataMgr>
{
   public Dictionary<string,CmpLocalDataItem> CmpLocalDataItems = new Dictionary<string,CmpLocalDataItem>();
    public CmpLocalDataItem AddCmpLocalDataItem(int id)
    {
        CmpLocalDataItem CmplocalDataItem = new CmpLocalDataItem();
        string colorstring= CmpDataMgr.GetInstance().GetCmpData(id).ColorType;
        CmplocalDataItem.Uid = System.Guid.NewGuid().ToString();
        CmplocalDataItem.Id = id;
        CmplocalDataItem.Price= CmpDataMgr.GetInstance().GetCmpData(id).Price;
        CmplocalDataItem.chip_name= CmpDataMgr.GetInstance().GetCmpData(id).chip_name;
        CmplocalDataItem.portColors = CmpDataMgr.GetInstance().GetCmpData(id).PortColor;
        if(!ColorType.TryParse(colorstring, true,out CmplocalDataItem.PriceColorType))
        {
            Debug.Log("Change color False");
        }
        CmpLocalDataItems.Add(CmplocalDataItem.Uid,CmplocalDataItem);
        return CmplocalDataItem;
    }

    public CmpLocalDataItem GetCmpLocalDataItemFromUid(string uid)
    {
        if (CmpLocalDataItems.ContainsKey(uid))
        {
            return CmpLocalDataItems[uid];
        }
        Debug.Log("Not found Uid");
        return null;
    }
}

public class CmpLocalDataItem
{
    public string Uid;
    public string chip_name;
    public string portColors;
    public int Id;
    public int Price;
    public ColorType PriceColorType;
}
