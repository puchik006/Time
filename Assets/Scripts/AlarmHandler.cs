using System.Diagnostics;

public class AlarmHandler
{
    private IAlarmTime _hours;
    private IAlarmTime _minutes;
    private IAlarmTime _seconds;
    private IClockTimeInSeconds _clock;
    private AlarmButtonView _alarmButtonView;
    private AlarmArrowView _alarmArrowView;

    public AlarmHandler(IAlarmTime hours, IAlarmTime minutes, IAlarmTime seconds,
                        AlarmButtonView alarmButtonView, AlarmArrowView alarmArrowView,IClockTimeInSeconds clock)
    {
        _hours = hours;
        _minutes = minutes;
        _seconds = seconds;
        _clock = clock;
        _alarmButtonView = alarmButtonView;
        _alarmArrowView = alarmArrowView;

        _alarmButtonView.AlarmButtonClicked += SetAllarm;
        _clock.CurrentTimeUpdated += CheckAlarm;
    }

    private void SetAllarm()
    {
        int hours = _hours.AlarmTime;
        int minutes = _minutes.AlarmTime;
        int seconds = _seconds.AlarmTime;

        _alarmArrowView.SetAlarmArrow(hours, minutes, seconds);
    }

    private void CheckAlarm(float currentTime)
    {
        float catchRange = 0.5f;

        if (currentTime >= _alarmArrowView.AlarmTime - catchRange && currentTime <= _alarmArrowView.AlarmTime + catchRange)
        {
            _alarmArrowView.DisableAlarmArrow();
            //beep beep
        }
    }
}
