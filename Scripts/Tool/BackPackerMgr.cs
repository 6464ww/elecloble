using System.Collections;
using System.Collections.Generic;
using Tool;
using UnityEngine;

public class BackPackerMgr : BaseSingleMono<BackPackerMgr>
{
    // Start is called before the first frame update
    
   public int LimitNum=5;
   private int CurrentNum=0;
   public GameObject BackPackerPrefab;

   public void AddItemToBackpack(int id)
   {
       if (CurrentNum < LimitNum)
       {
           CurrentNum++;
           GameObject obj = GameObject.Instantiate(BackPackerPrefab, transform); 
           PackageItem packageItem = obj.GetComponent<PackageItem>();
           CmpLocalDataItem cmpLocalDataItem = CmpLocalDataMgr.GetInstance().AddCmpLocalDataItem(id);
           packageItem.Refresh(cmpLocalDataItem);
       }
   }
}
