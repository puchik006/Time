using System;
using TMPro;
using UnityEngine;

public class ClockHandler : MonoBehaviour, IClockTimeInSeconds
{
    [SerializeField] private Transform _hourRing;
    [SerializeField] private Transform _minuteRing;
    [SerializeField] private Transform _secondRing;

    [SerializeField] private Transform _hourCircle;
    [SerializeField] private Transform _minuteCircle;
    [SerializeField] private Transform _secondCircle;

    [SerializeField] private TMP_Text _hours;
    [SerializeField] private TMP_Text _minutes;
    [SerializeField] private TMP_Text _second;

    private float _currentTime;
    public event Action<float> CurrentTimeUpdated;

    public void SetInitialTime(int hours, int minutes, int seconds)
    {
        _currentTime = hours * 3600f + minutes * 60f + seconds;
    }

    private void Start()
    {
        UpdateClock();
    }

    private void UpdateClock()
    {
        float deltaTime = 0.1f;

        _currentTime += deltaTime;
        CurrentTimeUpdated?.Invoke(_currentTime);

        float hourRotation = (_currentTime / 3600f) * 360f / 12f;
        float minuteRotation = (_currentTime / 60f) * 360f / 60f;
        float secondRotation = (_currentTime) * 360f / 60f;

        int hours = (int)((_currentTime / 3600f) % 24f);
        int minutes = (int)((_currentTime / 60f) % 60f);
        int seconds = (int)(_currentTime % 60f);

        _hours.text = hours.ToString("00");
        _minutes.text = minutes.ToString("00");
        _second.text = seconds.ToString("00");

        _hourRing.rotation = Quaternion.Euler(0f, 0f, -hourRotation);
        _minuteRing.rotation = Quaternion.Euler(0f, 0f, -minuteRotation);
        _secondRing.rotation = Quaternion.Euler(0f, 0f, -secondRotation);

        _hourCircle.rotation = Quaternion.identity;
        _minuteCircle.rotation = Quaternion.identity;
        _secondCircle.rotation = Quaternion.identity;

        Invoke(nameof(UpdateClock), deltaTime);
    }
}


