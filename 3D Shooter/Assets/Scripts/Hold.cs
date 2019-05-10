using UnityEngine;
using UnityEngine.EventSystems;


public class Hold : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [HideInInspector]
    public bool shoot;
  
    public void OnPointerDown(PointerEventData eventData)
    {
        shoot = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        shoot = false;
    }
}
