using UnityEngine;
using UnityEngine.EventSystems;

public class Joystick : MonoBehaviour
{
    [SerializeField]private GameObject joystickInner;
    [SerializeField]private GameObject joystickOuter;
    private Vector2 joystickVector;
    private Vector2 joystickTouchPos;
    private Vector2 joysstickOrigPos;
    private Vector2 dragPos;
    private Vector3 pointerWorldPosition;
    private Vector3 mouseWorldPosition;
    private Vector3 mousePos;
    private float joystickRad;
    private float joystickDistance;
    private PointerEventData pointerEventData;

    void Start()
    {
        joysstickOrigPos = joystickOuter.transform.position;
        joystickRad = joystickOuter.GetComponent<RectTransform>().sizeDelta.y / 300;
    }

    public void PointerDown()
    {
        mousePos = Input.mousePosition;
        mousePos.z = Camera.main.nearClipPlane;
        mouseWorldPosition = Camera.main.ScreenToWorldPoint(mousePos);

        joystickInner.transform.position= mouseWorldPosition;
        joystickOuter.transform.position = mouseWorldPosition;
        joystickTouchPos = mouseWorldPosition;
    }

    public void Drag(BaseEventData baseEventData)
    {
        pointerEventData = baseEventData as PointerEventData;
        pointerWorldPosition = Camera.main.ScreenToWorldPoint(pointerEventData.position);

        dragPos.x = pointerWorldPosition.x;
        dragPos.y = pointerWorldPosition.y;

        joystickVector = (dragPos - joystickTouchPos).normalized;

        joystickDistance = Vector2.Distance(dragPos, joystickTouchPos);

        if(joystickDistance < joystickRad)
        {
            joystickInner.transform.position = joystickTouchPos + joystickVector * joystickDistance;
        }
        else
        {
            joystickInner.transform.position = joystickTouchPos + joystickVector * joystickRad;
        }
    }

    public void PointerUp()
    {
        joystickVector = Vector2.zero;
        joystickInner.transform.position = joysstickOrigPos;
        joystickOuter.transform.position = joysstickOrigPos;
    }
}
