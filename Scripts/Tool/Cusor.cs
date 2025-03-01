using System.Collections;
using System.Collections.Generic;
using Tool;
using UnityEngine;

public class Cusor : BaseSingleMono<Cusor>
{
   
    private Collider2D GetCollider(string tag)
    {
        Vector2 mousepos= Camera.main.ScreenToWorldPoint(new Vector2(Input.mousePosition.x, Input.mousePosition.y));
        Ray2D ray = new Ray2D(mousepos, Vector2.zero);
        RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, 100f);
        if (hit.collider != null)
        {
            if (hit.collider.gameObject.CompareTag(tag))
            {
                return hit.collider;
            }
        }

        return null;
    }
    void Update()
    {
       
        if (Input.GetMouseButtonDown(1))
        {
            Collider2D hit = GetCollider("Line");
            if (hit)
            {
                Line l = hit.gameObject.GetComponent<Line>();
                l.TransLatePortMsg(false);
                WriteLineMgr.GetInstance().DeleteLine(l);
            }
        }
        else if (Input.GetMouseButtonDown(0))
        {
            Collider2D hit = GetCollider("Line");
            if (hit)
            {
                Line l = hit.gameObject.GetComponent<Line>();
               Vector3 pos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0));
               pos.z = 0;
                WriteLineMgr.GetInstance().Onclick(pos,false,l.Outport,true);
            }
        }
    }
    
}
