using System;
using System.Collections;
using System.Collections.Generic;
using Tool;
using UnityEngine;

public class WriteLineMgr : BaseSingleMono<WriteLineMgr>
{
    private Line newline;
    private GameObject line ;
    private Vector3 start;
    private Vector3 end;
    private bool IsSetLine=false;
    private bool IsFirstClick=true;
    private bool Is_in;
    private bool Is_line;
    private List<Line> lines = new List<Line>();

    new void  Awake()
    {
        line = Resources.Load<GameObject>("Game/Line");
    }

    private void Update()
    {
        UpdateLine();
    }

    public void Onclick(Vector3 TargetPos,bool IsIn,port _port=null,bool isline=false)
    {
        if (IsFirstClick)
        {
            start = TargetPos;
            start.z = 0;
            Is_in = IsIn;
            Is_line = isline;
            IsSetLine = true;
            IsFirstClick = false;
            AddLine(_port);
           
           
        }
    }

    private void AddLine(port _port)
    {        
            newline = Instantiate(line, transform).GetComponent<Line>();
            if (!Is_in)
            {
                newline.Outport=_port;
                newline.OutPosIndex = 0;
            }
            else
            {
                newline.Inport = _port;
                newline.InPosIndex = 0;
            }
            if (Is_line)
            {
                newline.lineRenderer.positionCount = 3;
                newline.lineRenderer.SetPosition(0, start);
                Debug.Log(start.ToString());
                newline.lineRenderer.SetPosition(1, start);
                
            }
            else
            {
                newline.lineRenderer.positionCount = 2;
                newline.lineRenderer.SetPosition(0, start);
            }

            
    }

    public void DeleteLine(Line Target_line)
    {
        if (lines.Contains(Target_line))
        {
            Target_line.Outport.RemovePortLine(Target_line);
            Target_line.Inport.RemovePortLine(Target_line);
            lines.Remove(Target_line);
            Destroy(Target_line.gameObject);
        }
        else
        {
            Debug.Log("No Found Line");
        }
    }
   private void UpdateLine()
    {
        if (IsSetLine)
        {
            end=Camera.main.ScreenToWorldPoint(Input.mousePosition);
            end.z = 0;
            if (Input.GetMouseButtonDown(0))
            {
                
                Vector2 mousepos= Camera.main.ScreenToWorldPoint(new Vector2(Input.mousePosition.x, Input.mousePosition.y));
                Ray2D ray = new Ray2D(mousepos, Vector2.zero);
                RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, 100f); 
                if (hit.collider!= null)
                {
                    if (hit.collider.gameObject.CompareTag("Port"))
                    {
                        port hitPort = hit.collider.gameObject.GetComponent<port>();
                        if (hitPort.Is_in != Is_in)
                        {
                            newline.CreateLine(Is_in, hit);
                            if (Is_line)
                            {
                                Debug.Log(hit.collider.gameObject.name);
                                newline.lineRenderer.SetPosition(0, newline.Outport.transform.position);
                            }
                            IsSetLine = false;
                            lines.Add(newline);
                            IsFirstClick = true;
                            newline.TransLatePortMsg(true);
                        }
                        return;
                    }
                    else if (hit.collider.gameObject.CompareTag("Line")&&!Is_line&&Is_in)
                    {
                        Line hitLine = hit.collider.gameObject.GetComponent<Line>();
                        port hitPort=default;
                        if (Is_in)
                        {
                             hitPort = hitLine.Outport;
                        }
                        else
                        {
                            hitPort = hitLine.Inport;
                        }
                        newline.CreateLine(Is_in, hit,hitPort);
                       
                        IsSetLine = false;
                        lines.Add(newline);
                        IsFirstClick = true;
                        newline.TransLatePortMsg(true);
                        return;
                    }
                }
                else
                {
                    Debug.Log("Set Point");
                    newline.lineRenderer.SetPosition(newline.lineRenderer.positionCount-1, end);
                    newline.lineRenderer.positionCount++;
                }
            }
            newline.lineRenderer.SetPosition(newline.lineRenderer.positionCount-1, end);
            if (Input.GetMouseButtonDown(1))
            {
                Destroy(newline.gameObject);
                IsSetLine = false;
                IsFirstClick = true;
            }
           
        }
    }

    
}
