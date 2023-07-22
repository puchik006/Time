using UnityEngine;

public partial class GameManager : MonoBehaviour
{
    [SerializeField] private AlarmTimeSetView _hourSetterView;
    private AlarmTimeSetController _hourSetterController;
    private HourSetterAlarmModel _hourSetterModel;

    [SerializeField] private AlarmTimeSetView _minutesSetterView;
    private AlarmTimeSetController _minutesSetterController;
    private MinutesOrSecondsSetterAlarmModel _minutesSetterModel;

    [SerializeField] private AlarmTimeSetView _secondsSetterView;
    private AlarmTimeSetController _secondsSetterController;
    private MinutesOrSecondsSetterAlarmModel _secondsSetterModel;

    [SerializeField] private AlarmButtonView _alarmButtonView;
    [SerializeField] private AlarmArrowView _alarmArrowView;
    private AlarmHandler _alarmHandler;

    private TimeAPIManager _timeApi;
    [SerializeField] ClockHandler _clock;
    private ExternalTimeUpdater _externalTimeUpdater;

    private void Awake()
    {
        _hourSetterModel = new HourSetterAlarmModel();
        _hourSetterController = new AlarmTimeSetController(_hourSetterView,_hourSetterModel);

        _minutesSetterModel = new MinutesOrSecondsSetterAlarmModel();
        _hourSetterController = new AlarmTimeSetController(_minutesSetterView,_minutesSetterModel);

        _secondsSetterModel = new MinutesOrSecondsSetterAlarmModel();
        _secondsSetterController = new AlarmTimeSetController(_secondsSetterView,_secondsSetterModel);

        _alarmHandler = new AlarmHandler(_hourSetterModel, _minutesSetterModel, _secondsSetterModel, _alarmButtonView, _alarmArrowView, _clock);

        _timeApi = new TimeAPIManager();
        _externalTimeUpdater = new ExternalTimeUpdater(_clock,_timeApi);
    }
}
