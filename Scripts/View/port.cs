using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class port : MonoBehaviour
{
    // Start is called before the first frame update
    private SpriteRenderer sprite;
    private List<Line> portLines=new List<Line>();
    public bool Is_in;
    [SerializeField]
    private ColorType colorType;
    public ColorType portColor
    {
        get { return colorType; }
        set
        {
            colorType = value;
            sprite.color = ColorEnum.GetInstance().colorsList[(int)colorType];
        }
    }
    public BaseCmp baseCmp=null;
    public int cost;
    public List<ColorType> ColorTypes=new List<ColorType>();
   [SerializeField]
    private int _Grade;
    public int Grade
    {
        get => _Grade;
        set
        {
            _Grade = value;
            gradeText.text = _Grade.ToString();
            if (portColor == ColorType.Black)
            {
                Debug.Log(colorType);
                gradeText.color = Color.white;
            }
            else
            {
                gradeText.color = Color.black;
            }
        }
    }
    public TextMeshPro gradeText;
    
    void Awake()
    {
        sprite = GetComponent<SpriteRenderer>();
        portColor=colorType;
        Grade = _Grade;
        gradeText.text = Grade.ToString();
    }
    private void OnMouseEnter()
    {
        sprite.color=Color.white;
    }

    private void OnMouseExit()
    {
        portColor=colorType;
    }

    private void OnMouseDown()
    {
        
      WriteLineMgr.GetInstance().Onclick(transform.position,Is_in,this);
    }

    public void MoveLine()
    {
        foreach (Line portLine in portLines)
        {
            portLine.MoveLine(Is_in);
        }
      
    }

    public void AddPortLine(Line portLine)
    {
        portLines.Add(portLine);
    }

    public void RemovePortLine(Line portLine)
    {
        portLines.Remove(portLine);
    }
    public void SetPortMsg(port targetport)
    {
        portColor = targetport.portColor;
        Grade = 0;
    }
   

}
