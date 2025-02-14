using UnityEngine;

public class WaveSystem : MonoBehaviour
{
    public Day Day = Day.Morning;

    public void ChangeDayState(Day day)
    {
        Day = day;
    }
}
public enum Day
{
    Morning,
    Night
}