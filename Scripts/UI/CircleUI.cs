using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class CircleUI : MonoBehaviour
{
    public Image circle;
    [SerializeField]
    private ColorType colorType;
    public TextMeshProUGUI circleText;
    public ColorType portColor
    {
        get { return colorType; }
        set
        {
            colorType = value;
            Debug.Log(colorType);
            circle.color = ColorEnum.GetInstance().colorsList[(int)colorType];
        }
    }
    
     [SerializeField]
    private int circleNum;

    public int CircleNum
    {
        get => circleNum;
        set
        {
            circleNum = value;
            Debug.Log(circleText);
            circleText.text = circleNum.ToString();
        }
    }

    void Start()
    {
        circle = GetComponent<Image>();
        portColor = colorType;
        CircleNum = circleNum;
    }
}
