using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TelePort : MonoBehaviour
{
    public SceneType From;
    public SceneType To;
    private SpriteRenderer spriteRenderer;
    private Color originalColor;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        originalColor = spriteRenderer.color;
    }

    public void TeleportToScene()
    {
        Debug.Log("TeleportToScene");
        TransMgr.GetInstance().Translate(From.ToString(),To.ToString());
    }

    public void OnMouseEnter()
    {
     spriteRenderer.color= new Color32(174,174,174,255);   
    }

    public void OnMouseExit()
    {
        spriteRenderer.color = originalColor;
    }

    public void OnMouseDown()
    {
        TeleportToScene();
    }
}