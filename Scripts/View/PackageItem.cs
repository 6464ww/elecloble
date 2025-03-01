using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PackageItem : MonoBehaviour
{
  public TextMeshProUGUI UItextchip_name;
  private Button button;
  private CmpLocalDataItem cmpLocalDataItem;
  private CmpDataItem cmpDataItem;
  
  void Awake()
  {
    
  }

  private void Init()
  {
    button = GetComponent<Button>();
    //button.onClick.AddListener();
  }

 
  public void Refresh(CmpLocalDataItem _cmpLocalDataItem)
  {
    cmpLocalDataItem = _cmpLocalDataItem;
    cmpDataItem = CmpDataMgr.GetInstance().GetCmpData(cmpLocalDataItem.Id);
    UItextchip_name.text = cmpLocalDataItem.chip_name;
  }

  public void AddCmp()
  {
    GameObject obj = Instantiate(Resources.Load<GameObject>("Prefabs/CmpItem"));
  }
}
