using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class BaseCmp : MonoBehaviour
{
    // Start is called before the first frame update
    Vector3   cusorpos;
    public List<port> Inports = new List<port>();
    public List<port> Outports = new List<port>();
    private Vector3 offset;
    private CmpDataItem cmpData;
    private CmpLocalDataItem cmpLocalData;
    void Start()
    {
      BaseEffect();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void InitPort(string Uid)
    {
        string portColors = CmpLocalDataMgr.GetInstance().CmpLocalDataItems[Uid].portColors;
        int[] portColorsArray = portColors.Select(c => int.Parse(c.ToString())).ToArray();
        foreach (int portcolor in portColors)
        {
            port port = new port();
            port.portColor =(ColorType)portcolor;
        }
        
    }

    public void InitCmp(string Uid)
    {
        cmpLocalData=CmpLocalDataMgr.GetInstance().GetCmpLocalDataItemFromUid(Uid);
        cmpData = CmpDataMgr.GetInstance().GetCmpData(cmpLocalData.Id);
    }

    public void BaseEffect()
    {
        int Allcount = 0;
        int AllGrade = 0;
        int MinGrade = 100;
        bool IsColorEqual=true;
        ColorType colorType=Inports[0].portColor;
        if (Inports.Count >= 1 && Outports.Count == 1)
        {
            foreach (port p in Inports)
            {
                Allcount += (int)p.portColor;
                AllGrade += p.Grade;
                if (MinGrade > p.Grade)
                {
                    MinGrade = p.Grade;
                }

                if (p.portColor != colorType)
                {
                    IsColorEqual = false;
                }
            }

            if (!IsColorEqual)
            {
                Debug.Log(Allcount < Enum.GetValues(typeof(ColorType)).Length);
                if (Allcount < Enum.GetValues(typeof(ColorType)).Length) Outports[0].portColor = (ColorType)Allcount;
                else
                {
                    Outports[0].portColor = (ColorType)0;
                }
                Outports[0].Grade=MinGrade;
            }
            else
            {
                Outports[0].portColor =colorType ;
                Outports[0].Grade=AllGrade;
            }
        }

    
        
        
    }

    public void OnMouseDown()
    {
        offset = transform.position-Camera.main.ScreenToWorldPoint(Input.mousePosition) ;
    }

    public void OnMouseDrag()
    {
        cusorpos=Camera.main.ScreenToWorldPoint(Input.mousePosition)+offset;
        cusorpos.z=0;
        gameObject.transform.position = cusorpos;
        foreach (port p in Inports)
        {
            p.MoveLine();
        }

        foreach (port p in Outports)
        {
            p.MoveLine();
        }
    }
}
