using System.Collections;
using System.Collections.Generic;
using Tool;
using UnityEngine;

public class ShopManager : BaseSingleMono<ShopManager>
{
    // Start is called before the first frame update
   public List<ShopItem> shopItems = new List<ShopItem>();
   public GameObject shopItemPrefab;

   
   public void InitShop()
   {
       Debug.Log("InitShop");
       for (int i = 0; i < CmpDataMgr.GetInstance().CmpDataItems.Count; i++)
       {
           CmpLocalDataMgr.GetInstance().AddCmpLocalDataItem(i);
       }

       foreach (var cmpItem in CmpLocalDataMgr.GetInstance().CmpLocalDataItems)
       {
           GameObject obj = GameObject.Instantiate(shopItemPrefab, transform);
           ShopItem shopItem = obj.GetComponent<ShopItem>();
           shopItem.Refresh(CmpLocalDataMgr.GetInstance().CmpLocalDataItems[cmpItem.Key]);
           shopItems.Add(shopItem);
       }
     
   }
}
