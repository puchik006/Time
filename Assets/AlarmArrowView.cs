using UnityEngine;

[RequireComponent (typeof(RectTransform))]
public class AlarmArrowView: MonoBehaviour
{
    public void SetAlarmArrow(int hours, int minutes, int seconds)
    {
        transform.gameObject.SetActive(true);
        var alarmTime = hours * 3600f + minutes * 60f + seconds;
        float alarmRotation = (alarmTime / 3600f) * 360f / 12f;
        transform.rotation = Quaternion.Euler(0f, 0f, -alarmRotation);
    }
}
