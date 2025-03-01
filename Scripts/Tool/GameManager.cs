using System;
using System.Collections;
using System.Collections.Generic;
using Tool;
using UnityEngine;

public class GameManager : BaseSingleMono<GameManager>
{
   public List<port> Listports = new List<port>();
   public Dictionary<ColorType,port> ports = new Dictionary<ColorType, port>();

 
   public void Buy(ColorType colorType,int cost)
   {
      if (ports.ContainsKey(colorType)&&ports[colorType].Grade >= cost)
      {
         ports[colorType].Grade -= cost;
      }
   }
   
   public void InitGameMgr()
   {
      Array enumcolors = Enum.GetValues(typeof(ColorType));
      int t = 0;
      foreach (ColorType colorType in enumcolors)
      {
         if (colorType != ColorType.Gray)
         {
            ports.Add(colorType, Listports[t]);
            t++;
         }
      }
      Debug.Log("Game Manager Init");
      PassDataLocalMgr.GetInstance().AddPassLocalDataItem(0);
      Dictionary<ColorType, int> colorTypes = PassDataLocalMgr.GetInstance().PassLocalDataItems[0].Colors;
      foreach (ColorType color in colorTypes.Keys)
      {
         ports[color].Grade=colorTypes[color];
      }
   }
   
}