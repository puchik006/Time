using UnityEngine;

public class GameManager : MonoBehaviour
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

    private void Awake()
    {
        _hourSetterModel = new HourSetterAlarmModel();
        _hourSetterController = new AlarmTimeSetController(_hourSetterView,_hourSetterModel);

        _minutesSetterModel = new MinutesOrSecondsSetterAlarmModel();
        _hourSetterController = new AlarmTimeSetController(_minutesSetterView,_minutesSetterModel);

        _secondsSetterModel = new MinutesOrSecondsSetterAlarmModel();
        _secondsSetterController = new AlarmTimeSetController(_secondsSetterView,_secondsSetterModel);
    }
}
