using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopItem : MonoBehaviour
{
    // Start is called before the first frame update
    private Button clickButton;
    private CmpLocalDataItem cmpLocalDataItem;
    private CmpDataItem cmpDataItem;
    public TextMeshProUGUI UItextchipName;
    void Awake()
    {
      Init();
    }

    public void Refresh(CmpLocalDataItem _cmpLocalDataItem)
    {
        cmpLocalDataItem = _cmpLocalDataItem;
        cmpDataItem = CmpDataMgr.GetInstance().GetCmpData(cmpLocalDataItem.Id);
        UItextchipName.text = cmpLocalDataItem.chip_name;
        //渲染UI信息
    }
    private void Init()
    {
        clickButton = GetComponent<Button>();
        clickButton.onClick.AddListener(Onclick);
    }

    private void Onclick()
    {
        GameManager.GetInstance().Buy(cmpLocalDataItem.PriceColorType, cmpLocalDataItem.Price);
        BackPackerMgr.GetInstance().AddItemToBackpack(cmpLocalDataItem.Id);
        Destroy(this.gameObject);
    }
    
   
}
