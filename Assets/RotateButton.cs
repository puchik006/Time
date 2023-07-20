using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class RotateButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private Transform _hourRing;

    private bool isPressed = false;
    private float initialAngle;
    private Vector3 initialDirectionToMouse;

    public void OnPointerDown(PointerEventData eventData)
    {
        isPressed = true;
        initialAngle = _hourRing.eulerAngles.z;
        initialDirectionToMouse = GetDirectionFromHourRingToMouse();
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isPressed = false;
    }

    private void Update()
    {
        if (isPressed) RotateHourRingTowardsMouse();
    }

    private Vector3 GetDirectionFromHourRingToMouse()
    {
        Vector3 mousePosition = Input.mousePosition;
        Vector3 buttonPosition = _hourRing.position;
        return mousePosition - buttonPosition;
    }

    private void RotateHourRingTowardsMouse()
    {
        Vector3 currentDirectionToMouse = GetDirectionFromHourRingToMouse();
        float currentAngle = Mathf.Atan2(currentDirectionToMouse.y, currentDirectionToMouse.x) * Mathf.Rad2Deg;
        float deltaAngle = currentAngle - Mathf.Atan2(initialDirectionToMouse.y, initialDirectionToMouse.x) * Mathf.Rad2Deg;
        _hourRing.rotation = Quaternion.Euler(0f, 0f, initialAngle + deltaAngle);
    }
}
