using System.Collections;
using System.Collections.Generic;
using Tool;
using UnityEngine;

public class PassDataLocalMgr : BaseSingleMono<PassDataLocalMgr>
{
    public List<PassDataLocalItem> PassLocalDataItems = new List<PassDataLocalItem>();
    public PassDataLocalItem AddPassLocalDataItem(int id)
    {
        PassDataLocalItem PasslocalDataItem = new PassDataLocalItem();
        PassDataItem passDataItem= PassDataMgr.GetInstance().GetPassData(id);
        PasslocalDataItem.Uid = System.Guid.NewGuid().ToString();
        PasslocalDataItem.PassID = passDataItem.PassID;
        PasslocalDataItem.Colors.Add(ColorType.Red,passDataItem.Red);
        PasslocalDataItem.Colors.Add(ColorType.Blue,passDataItem.Blue);
        PasslocalDataItem.Colors.Add(ColorType.Yellow,passDataItem.Yellow);
        PassLocalDataItems.Add(PasslocalDataItem);
        return PasslocalDataItem;
    }
}
public class PassDataLocalItem
{
    public string Uid;
    public int PassID;
    public Dictionary<ColorType,int> Colors = new Dictionary<ColorType, int>();
    public int Health;
}
