using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class Hold : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [HideInInspector]
    public bool shoot;
   
    private void Start()
    {

    }

    public void OnPointerDown(PointerEventData eventData)
    {
        shoot = true;
      

    }

    public void OnPointerUp(PointerEventData eventData)
    {
        shoot = false;

    }
}
