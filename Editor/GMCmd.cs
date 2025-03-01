using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class GMCmd : MonoBehaviour
{
   [MenuItem("Test/创建商店测试数据")]
   public static void InitShop()
   {
         CmpDataMgr obj = CmpDataMgr.GetInstance();
         obj.CmpDataItems=JsonMgr.Instance.LoadData<List<CmpDataItem>>("ShopTest");
         for (int i = 0; i < obj.CmpDataItems.Count; i++)
         {
             Debug.Log(obj.CmpDataItems[i].ID);
         }
   }
   [MenuItem("Test/创建关卡测试数据")]
   public static void PassData()
   {
       PassDataMgr obj =PassDataMgr.GetInstance();
       obj.PassDataItems=JsonMgr.Instance.LoadData<List<PassDataItem>>("PassData");
       for (int i = 0; i < obj.PassDataItems.Count; i++)
       {
           Debug.Log(obj.PassDataItems[i].PassID);
       }
       GameManager.GetInstance().InitGameMgr();
   }
}
