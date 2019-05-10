using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class Hold : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [HideInInspector]
    public bool shoot;
    [HideInInspector]
    public  Button b;
    private void Start()
    {
        b = GetComponent<Button>();
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
