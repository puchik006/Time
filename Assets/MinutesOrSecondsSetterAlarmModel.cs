public class MinutesOrSecondsSetterAlarmModel: AlarmTimeSetModel
{
    protected override void UpdateTime(float currentAngle)
    {
        float minutesOrSecondsPassed = (360f - currentAngle) / 360f * 60f;
        int minutesOrSeconds = (int)minutesOrSecondsPassed % 60;
        var timeText = minutesOrSeconds.ToString("00");

        RaiseAlarmTimeSettedEvent(timeText);
    }
}
