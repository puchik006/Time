using System;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Toggle))]
public class AlarmButtonView : MonoBehaviour
{
    [SerializeField] private GameObject _clock;
    [SerializeField] private GameObject _alarm;
    private Toggle _alarmButton;

    public event Action AlarmButtonClicked;

    private void Awake()
    {
        _alarmButton = GetComponent<Toggle>();
        _alarmButton.onValueChanged.AddListener(ActivateAlarm);
    }

    private void ActivateAlarm(bool isOn)
    {
        _clock.SetActive(!isOn);
        _alarm.SetActive(isOn);

        if (!isOn)
        {
            AlarmButtonClicked?.Invoke();
        }
    }
}
