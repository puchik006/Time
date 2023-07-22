using System;

public interface IClockTimeInSeconds
{
    event Action<float> CurrentTimeUpdated;
}


