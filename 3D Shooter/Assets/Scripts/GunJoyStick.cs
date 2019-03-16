using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class GunJoyStick : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler
{

    private Image jsContainer;
    [HideInInspector]
    public GameObject Lbutton;
    private Image joystick;

    public Vector3 InputDirection;

    void Start()
    {
        Lbutton = this.gameObject;
        jsContainer = GetComponent<Image>();
        joystick = transform.GetChild(0).GetComponent<Image>();
        InputDirection = Vector3.zero;
    }

    public void OnDrag(PointerEventData ped)
    {
        Vector2 position = Vector2.zero;


        RectTransformUtility.ScreenPointToLocalPointInRectangle
                (jsContainer.rectTransform,
                ped.position,
                ped.pressEventCamera,
                out position);

        position.x = (position.x / jsContainer.rectTransform.sizeDelta.x);
        position.y = (position.y / jsContainer.rectTransform.sizeDelta.y);

        float x = (jsContainer.rectTransform.pivot.x == 1f) ? position.x * 2 + 1 : position.x * 2 - 1;
        float y = (jsContainer.rectTransform.pivot.y == 1f) ? position.y * 2 + 1 : position.y * 2 - 1;
       

        InputDirection = new Vector3(x,y );
        InputDirection = (InputDirection.magnitude > 1) ? InputDirection.normalized : InputDirection;


        joystick.rectTransform.anchoredPosition = new Vector3(InputDirection.x * (jsContainer.rectTransform.sizeDelta.x /2),
                                                               InputDirection.y * (jsContainer.rectTransform.sizeDelta.y/2) );

    }

    public void OnPointerDown(PointerEventData ped)
    {

        OnDrag(ped);

    }

    public void OnPointerUp(PointerEventData ped)
    {

        InputDirection = Vector3.zero;
        joystick.rectTransform.anchoredPosition = Vector3.zero;
    }
    public float Horizontal()
    {
        if (InputDirection.x != 0)
            return InputDirection.x;
        else return Input.GetAxis("Horizontal");
    }

    public float Vertical()
    {
        if (InputDirection.y != 0)
            return InputDirection.y;
        else return Input.GetAxis("Vertical");
    }
}