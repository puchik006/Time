public class HourSetterAlarmModel: AlarmTimeSetModel, IAlarmTime
{
    private int _hours;
    public int AlarmTime => _hours;

    protected override void UpdateTime(float currentAngle)
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
        _hours = (int)(hoursPassed + 12f) % 24;
        var timeText = _hours.ToString("00");

        RaiseAlarmTimeSettedEvent(timeText);

        _previousAngle = currentAngle;
    }
}
