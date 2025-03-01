using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorEnum : BaseSingle<ColorEnum>
{
   public List<Color> colorsList = new List<Color>();
   
    public ColorEnum()
    {
        colorsList.Add(Color.gray);
        colorsList.Add(Color.red);
        colorsList.Add(Color.yellow);
        colorsList.Add(new Color32(229,156,62,255));
        colorsList.Add(Color.blue);
        colorsList.Add(Color.magenta);
        colorsList.Add(Color.green);
        colorsList.Add(Color.black);
    }
   
}
