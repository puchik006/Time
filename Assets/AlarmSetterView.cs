using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class AlarmSetterView : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private Transform _timeRing;
    [SerializeField] private TMP_Text _timeText;

    public event Action<Transform> PointerDown;
    public event Action PointerUp;

    public void OnPointerDown(PointerEventData eventData) => PointerDown?.Invoke(_timeRing);

    public void OnPointerUp(PointerEventData eventData) => PointerUp?.Invoke();

    public void SetTimeText(string time) => _timeText.text = time;    

    public void SetTimeRingRotation(float angle)
    {
        _timeRing.rotation = Quaternion.Euler(0f, 0f, angle);
        Debug.Log(angle.ToString());
    }
}
public class AlarmSetterController
{
    private AlarmSetterView _alarmSetterView;
    private AlarmSetterModel _alarmSetterModel;

    public AlarmSetterController(AlarmSetterView alarmSetterView, AlarmSetterModel alarmSetterModel)
    {
        _alarmSetterView = alarmSetterView;
        _alarmSetterModel = alarmSetterModel;

        _alarmSetterView.PointerDown += _alarmSetterModel.OnPointerDown;
        _alarmSetterView.PointerUp += _alarmSetterModel.OnPointerUp;

        _alarmSetterModel.SetContext(_alarmSetterView);
        _alarmSetterModel.AlarmTimeSetted += _alarmSetterView.SetTimeText;
        _alarmSetterModel.AlarmRotationSetted += _alarmSetterView.SetTimeRingRotation;
    }
}

public class AlarmSetterModel
{
    private bool _isPressed = false;
    private float _initialAngle;
    private Vector3 _initialDirectionToMouse;
    private int _totalRotations = 0;
    private float _previousAngle = 0f;
    private MonoBehaviour _context;
    private Transform _timeRing;

    public event Action<string> AlarmTimeSetted;
    public event Action<float> AlarmRotationSetted;

    public void SetContext(MonoBehaviour context)
    {
        _context = context;
    }

    public void OnPointerDown(Transform timeRing)
    {
        _isPressed = true;
        _timeRing = timeRing;
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
            yield return null;
        }
    }

    private Vector3 GetDirectionFromHourRingToMouse()
    {
        Vector3 mousePosition = Input.mousePosition;
        Vector3 buttonPosition = _timeRing.position;
        return mousePosition - buttonPosition;
    }

    private void RotateHourRingTowardsMouse()
    {
        Vector3 currentDirectionToMouse = GetDirectionFromHourRingToMouse();
        float currentAngle = Mathf.Atan2(currentDirectionToMouse.y, currentDirectionToMouse.x) * Mathf.Rad2Deg;
        float deltaAngle = currentAngle - Mathf.Atan2(_initialDirectionToMouse.y, _initialDirectionToMouse.x) * Mathf.Rad2Deg;
        UpdateTime(_initialAngle + deltaAngle);

        AlarmRotationSetted?.Invoke(_initialAngle + deltaAngle);
    }

    private void UpdateTime(float currentAngle)
    {
        float deltaAngle = currentAngle - _previousAngle;

        if (deltaAngle < -180f)
        {
            _totalRotations++;
        }
        else if (deltaAngle > 180f)
        {
            _totalRotations--;
        }

        float totalAngle = currentAngle + (_totalRotations * 360f);
        float hoursPassed = (360f - totalAngle) / 360f * 12f;
        int hours = (int)(hoursPassed + 12f) % 24;
        var timeText = hours.ToString("00");

        AlarmTimeSetted?.Invoke(timeText);

        _previousAngle = currentAngle;
    }
}
