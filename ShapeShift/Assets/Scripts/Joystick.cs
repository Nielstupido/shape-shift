using UnityEngine;
using UnityEngine.EventSystems;

public class Joystick : MonoBehaviour
{
    [SerializeField]private GameObject joystickInner;
    [SerializeField]private GameObject joystickOuter;
    private ShapeMovement shapeMovement;
    private Vector2 joystickVector;
    private Vector2 joystickTouchPos;
    private Vector2 joysstickOrigPos;
    private Vector2 dragPos;
    private Vector3 pointerWorldPosition;
    private Vector3 mouseWorldPosition;
    private Vector3 mousePos;
    private float joystickRad;
    private float joystickDistance;
    private float joystickMag;
    private PointerEventData pointerEventData;

    void Start()
    {
        shapeMovement = FindObjectOfType<ShapeMovement>();
        joystickVector = Vector2.zero;

        joysstickOrigPos = joystickOuter.transform.position;
        joystickRad = joystickOuter.GetComponent<RectTransform>().sizeDelta.y / 4 + 70;
    }

    void Update()
    {
        if(joystickOuter.transform.position.x != joysstickOrigPos.x && joystickOuter.transform.position.y != joysstickOrigPos.y)
        {
            shapeMovement.MoveShape(joystickVector, joystickMag);
        }
        else
        {
            shapeMovement.StopShape(joystickVector);
        }
    }

    public void PointerDown()
    {
        joystickInner.transform.position= Input.mousePosition;
        joystickOuter.transform.position = Input.mousePosition;
        joystickTouchPos = Input.mousePosition;
    }

    public void Drag(BaseEventData baseEventData)
    {
        pointerEventData = baseEventData as PointerEventData;
        dragPos = pointerEventData.position;

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

        joystickMag = Vector2.Distance(joystickOuter.transform.position, joystickInner.transform.position);
    }

    public void PointerUp()
    {
        joystickInner.transform.position = joysstickOrigPos;
        joystickOuter.transform.position = joysstickOrigPos;
    }
}
