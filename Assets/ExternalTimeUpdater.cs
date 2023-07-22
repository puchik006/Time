public partial class GameManager
{
    public class ExternalTimeUpdater
    {
        private ClockHandler _clock;
        private TimeAPIManager _timeApi;
        private string apiUrl1 = "http://worldtimeapi.org/api/ip";
        private string apiUrl2 = "https://time.is/";

        public ExternalTimeUpdater(ClockHandler clock, TimeAPIManager timeAPI)
        {
            _clock = clock;
            _timeApi = timeAPI;
            _clock.StartCoroutine(_timeApi.GetTimeFromAPI(apiUrl1,_clock.SetInitialTime));
            _clock.StartCoroutine(_timeApi.GetTimeFromAPI(apiUrl2, _clock.SetInitialTime));
        }
    }
}
