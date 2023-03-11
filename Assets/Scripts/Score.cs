using UnityEngine;

public class Score : MonoBehaviour
{
    private static readonly int ScoreIncrement = 1;

    private static int _scoreCount;
    public static int ScoreCount
    {
        get { return _scoreCount; }
        set { _scoreCount = value; }
    }

    public static int IncreaseScore()
    {
        return _scoreCount + ScoreIncrement;
    }
}
