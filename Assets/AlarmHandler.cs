public class AlarmHandler
{
    private IAlarmable _hours;
    private IAlarmable _minutes;
    private IAlarmable _seconds;

    private AlarmButtonView _alarmButtonView;
    private AlarmArrowView _alarmArrowView;

    public AlarmHandler(IAlarmable hours, IAlarmable minutes, IAlarmable seconds, AlarmButtonView alarmButtonView, AlarmArrowView alarmArrowView)
    {
        _hours = hours;
        _minutes = minutes;
        _seconds = seconds;

        _alarmButtonView = alarmButtonView;
        _alarmArrowView = alarmArrowView;

        _alarmButtonView.AlarmButtonClicked += SetAllarm;
    }

    private void SetAllarm()
    {
        int hours = _hours.AlarmTime;
        int minutes = _minutes.AlarmTime;
        int seconds = _seconds.AlarmTime;

        _alarmArrowView.SetAlarmArrow(hours, minutes, seconds);
    }
}
