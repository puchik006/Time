public class MinutesOrSecondsSetterAlarmModel: AlarmTimeSetModel, IAlarmable
{
    private int _time;
    public int AlarmTime => _time;

    protected override void UpdateTime(float currentAngle)
    {
        float minutesOrSecondsPassed = (360f - currentAngle) / 360f * 60f;
        _time = (int)minutesOrSecondsPassed % 60;
        var timeText = _time.ToString("00");

        RaiseAlarmTimeSettedEvent(timeText);
    }
}
