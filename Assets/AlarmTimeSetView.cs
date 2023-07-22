using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class AlarmTimeSetView : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private Transform _timeRing;
    [SerializeField] private TMP_Text _timeText;

    public event Action<Transform,Transform> PointerDown;
    public event Action PointerUp;

    public void OnPointerDown(PointerEventData eventData) => PointerDown?.Invoke(_timeRing,transform);

    public void OnPointerUp(PointerEventData eventData) => PointerUp?.Invoke();

    public void SetTimeText(string time) => _timeText.text = time;    

    public void SetTimeRingRotation(float angle)
    {
        _timeRing.rotation = Quaternion.Euler(0f, 0f, angle);
    }
}
