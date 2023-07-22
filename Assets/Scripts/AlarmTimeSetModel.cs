using System;
using System.Collections;
using UnityEngine;

public abstract class AlarmTimeSetModel
{
    protected bool _isPressed = false;
    protected float _initialAngle;
    protected Vector3 _initialDirectionToMouse;
    protected int _totalRotations = 0;
    protected float _previousAngle = 0f;
    protected MonoBehaviour _context;
    protected Transform _timeRing;
    protected Transform _timeCircle;

    public event Action<string> AlarmTimeTextSetted;
    public event Action<float> AlarmRotationSetted;

    public void SetContext(MonoBehaviour context)
    {
        _context = context;
    }

    public void OnPointerDown(Transform timeRing, Transform timeCircle)
    {
        _isPressed = true;
        _timeRing = timeRing;
        _timeCircle = timeCircle;
        _initialAngle = _timeRing.eulerAngles.z;
        _initialDirectionToMouse = GetDirectionFromHourRingToMouse();

        _context.StartCoroutine(ContinuousUpdate());
    }

    public void OnPointerUp()
    {
        _isPressed = false;
    }

    private IEnumerator ContinuousUpdate()
    {
        while (_isPressed)
        {
            RotateHourRingTowardsMouse();
            KeepCircleVertical();
            yield return null;
        }
    }

    private Vector3 GetDirectionFromHourRingToMouse()
    {
        Vector3 mousePosition = Input.mousePosition;
        Vector3 buttonPosition = _timeRing.position;
        return mousePosition - buttonPosition;
    }

    private void KeepCircleVertical() => _timeCircle.rotation = Quaternion.identity;

    private void RotateHourRingTowardsMouse()
    {
        Vector3 currentDirectionToMouse = GetDirectionFromHourRingToMouse();
        float currentAngle = Mathf.Atan2(currentDirectionToMouse.y, currentDirectionToMouse.x) * Mathf.Rad2Deg;
        float deltaAngle = currentAngle - Mathf.Atan2(_initialDirectionToMouse.y, _initialDirectionToMouse.x) * Mathf.Rad2Deg;
        UpdateTime(_initialAngle + deltaAngle);

        AlarmRotationSetted?.Invoke(_initialAngle + deltaAngle);
    }

    protected void RaiseAlarmTimeSettedEvent(string timeText)
    {
        AlarmTimeTextSetted?.Invoke(timeText);
    }

    protected virtual void UpdateTime(float currentAngle) { }
}
