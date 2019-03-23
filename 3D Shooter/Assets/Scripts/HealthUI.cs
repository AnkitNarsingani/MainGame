using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class HealthUI : MonoBehaviour
{
      
    public GameObject Player;
    public Canvas canvas;
    Vector3 Offset = Vector3.zero;

    void Start()
    {
            Offset = transform.position - worldToUISpace(canvas, Player.transform.position);
    }

    
    void Update()
    {   
        transform.position = worldToUISpace(canvas, Player.transform.position) + Offset;
    }

    public Vector3 worldToUISpace(Canvas parentCanvas, Vector3 worldPos)
    {
        Vector3 screenPos = Camera.main.WorldToScreenPoint(worldPos);
        Vector2 movePos;
        
        RectTransformUtility.ScreenPointToLocalPointInRectangle(parentCanvas.transform as RectTransform, screenPos, parentCanvas.worldCamera, out movePos);
        return parentCanvas.transform.TransformPoint(movePos);
    }
}
