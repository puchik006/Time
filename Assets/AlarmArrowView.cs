using UnityEngine;

[RequireComponent (typeof(RectTransform))]
public class AlarmArrowView: MonoBehaviour
{
    private int _alarmTime;
    public int AlarmTime => _alarmTime;

    public void SetAlarmArrow(int hours, int minutes, int seconds)
    {
        transform.rotation = Quaternion.identity;
        gameObject.SetActive(true);
        _alarmTime = hours * 3600 + minutes * 60 + seconds;
        float alarmRotation = (_alarmTime / 3600f) * 360f / 12f;
        transform.rotation = Quaternion.Euler(0f, 0f, -alarmRotation);
    }

    public void DisableAlarmArrow()
    {
        gameObject.SetActive(false);
    }
}
