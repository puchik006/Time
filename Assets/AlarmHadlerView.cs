using System;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class AlarmHadlerView : MonoBehaviour
{
    public event Action ButtonClicked;

    [SerializeField] private Transform _alarmArrow;
    private Button _alarmButton;

    private void Awake()
    {
        _alarmButton = GetComponent<Button>();
        _alarmButton.Add(() => ButtonClicked?.Invoke());

        //SetAlarmArrow(13, 15, 45);
    }

    public void SetAlarmArrow(int hours, int minutes, int seconds)
    {
        _alarmArrow.gameObject.SetActive(true);
        var alarmTime = hours * 3600f + minutes * 60f + seconds;
        float alarmRotation = (alarmTime / 3600f) * 360f / 12f;
        _alarmArrow.rotation = Quaternion.Euler(0f, 0f, -alarmRotation);
    }
}
