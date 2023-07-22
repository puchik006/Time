public class AlarmTimeSetController
{
    private AlarmTimeSetView _alarmTimeSetView;
    private AlarmTimeSetModel _alarmTimeSetModel;

    public AlarmTimeSetController(AlarmTimeSetView alarmSetterView, AlarmTimeSetModel alarmSetterModel)
    {
        _alarmTimeSetView = alarmSetterView;
        _alarmTimeSetModel = alarmSetterModel;

        _alarmTimeSetView.PointerDown += _alarmTimeSetModel.OnPointerDown;
        _alarmTimeSetView.PointerUp += _alarmTimeSetModel.OnPointerUp;

        _alarmTimeSetModel.SetContext(_alarmTimeSetView);
        _alarmTimeSetModel.AlarmTimeTextSetted += _alarmTimeSetView.SetTimeText;
        _alarmTimeSetModel.AlarmRotationSetted += _alarmTimeSetView.SetTimeRingRotation;
    }
}
