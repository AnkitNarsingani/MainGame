using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class HealthUI : MonoBehaviour
{
      
    public GameObject Player;
    public Canvas canvas;
    public Vector3 Offset;

    void Start()
    {
            Offset = transform.position - worldToUISpace(canvas, Player.transform.position);
    }

    
    void Update()
    {   
        this.transform.position = worldToUISpace(canvas, Player.transform.position) + Offset;
    }

    public Vector3 worldToUISpace(Canvas parentCanvas, Vector3 worldPos)
    {
        Vector3 screenPos = Camera.main.WorldToScreenPoint(worldPos);
        Vector2 movePos;
        
        RectTransformUtility.ScreenPointToLocalPointInRectangle(parentCanvas.transform as RectTransform, screenPos, parentCanvas.worldCamera, out movePos);
        return parentCanvas.transform.TransformPoint(movePos);
    }
}
