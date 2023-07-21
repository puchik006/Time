using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private AlarmSetterView _alarmSetterView;
    private AlarmSetterController _alarmSetterController;
    private AlarmSetterModel _alarmSetterModel;

    private void Awake()
    {
        _alarmSetterModel = new AlarmSetterModel();
        _alarmSetterController = new AlarmSetterController(_alarmSetterView,_alarmSetterModel);
    }
}
