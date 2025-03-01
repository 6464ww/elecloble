using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Line : MonoBehaviour
{
    // Start is called before the first frame update
    public EdgeCollider2D edgeCollider;
    public LineRenderer lineRenderer;
    public port Inport;
    public port Outport;
    public int InPosIndex;
    public int OutPosIndex;
    public void UpdateLineCollider()
    {
        Vector3[] points3D = new Vector3[lineRenderer.positionCount];
        lineRenderer.GetPositions(points3D);

        // 转换为 Vector2 数组（仅保留 x 和 y）
        Vector2[] points2D = new Vector2[points3D.Length];
        for (int i = 0; i < points3D.Length; i++)
        {
            points2D[i] = new Vector2(points3D[i].x, points3D[i].y);
        }

        // 赋值给 EdgeCollider2D
        edgeCollider.points = points2D;
    }

    public void CreateLine(bool Is_in,RaycastHit2D hit,port hitPort=null)
    {
        if (hitPort == null)
        {
            hitPort = hit.collider.gameObject.GetComponent<port>();
        }
        else
        {
            Debug.Log("Set Point");
            lineRenderer.SetPosition(lineRenderer.positionCount-1, hit.point);
            lineRenderer.positionCount++;
        }
        if (Is_in)
        {
            Outport = hitPort;
            OutPosIndex = lineRenderer.positionCount - 1;
        }
        else
        {
            Inport = hitPort;
            InPosIndex = lineRenderer.positionCount - 1;
        }
        Debug.Log("Line"+hit.point);
        Debug.Log(Outport.transform.position);
        SetLine(Is_in);
        Inport.SetPortMsg(Outport);
        Inport.AddPortLine(this);
        Outport.AddPortLine(this);
    }

    public void SetLine(bool Is_in)
    {
        if (Is_in)
        {
            lineRenderer.SetPosition(lineRenderer.positionCount - 1, Outport.transform.position);
        }
        else
        {
            lineRenderer.SetPosition(lineRenderer.positionCount - 1, Inport.transform.position);
        }
        lineRenderer.startColor = ColorEnum.GetInstance().colorsList[(int)Outport.portColor];
        lineRenderer.endColor =  ColorEnum.GetInstance().colorsList[(int)Outport.portColor];
        UpdateLineCollider();
    }

    public void MoveLine(bool Isin)
    {
        if (Isin)
        {
            lineRenderer.SetPosition(InPosIndex, Inport.transform.position);
        }
        else
        {
            lineRenderer.SetPosition(OutPosIndex, Outport.transform.position);
        }
        UpdateLineCollider();
    }

    public void TransLatePortMsg(bool Isadd)
    {
        Debug.Log("TransLatePortMsg");
        if (Inport && Outport)
        {
            if(Isadd)
            {
                if (Outport.Grade != 0)
                {
                    if(Outport.Grade >=Inport.cost )
                    Outport.Grade -= Inport.cost;
                    Inport.Grade += Inport.cost;
                    Inport.baseCmp.BaseEffect();
                }
            }
            else
            {
                if (Inport.Grade != 0)
                {
                    Outport.Grade += Inport.cost;
                    Inport.Grade =0 ;
                   
                }
            }
        }
    }
    
    void Start()
    {
        edgeCollider = GetComponent<EdgeCollider2D>();
        UpdateLineCollider();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
