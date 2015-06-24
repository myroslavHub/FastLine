using System;
using UnityEngine;

public enum BallType
{
    btRed, btGreen, btCyan
}

public class ScoreManager: MonoBehaviour
{
    private const string BEST_SCORE = "Best score";
    private const string TOTAL_RED_BALL = "Total red balls";
    private const string TOTAL_GREEN_BALL = "Total green balls";
    private const string TOTAL_CYAN_BALL = "Total cyan balls";

    private int _BestScore;
    private int _TotalRedBall;
    private int _TotalGreenBall;
    private int _TotalCyanBall;

    public int BestScore
    {
        get { return _BestScore; }
        set
        {
            _BestScore = value;
            PlayerPrefs.SetInt(BEST_SCORE, _BestScore);
        }
    }
    public int TotalRedBall
    {
        get { return _TotalRedBall; }
        set
        {
            _TotalRedBall = value;
            PlayerPrefs.SetInt(TOTAL_RED_BALL, _TotalRedBall);
        }
    }
    public int TotalGreenBall
    {
        get { return _TotalGreenBall; }
        set
        {
            _TotalGreenBall = value;
            PlayerPrefs.SetInt(TOTAL_GREEN_BALL, _TotalGreenBall);
        }
    }
    public int TotalCyanBall
    {
        get { return _TotalCyanBall; }
        set
        {
            _TotalCyanBall = value;
            PlayerPrefs.SetInt(TOTAL_CYAN_BALL, _TotalCyanBall);
        }
    }

    #region CurrentScore

    private const int BALL_RED_SCORE = 2;
    private const int BALL_GREEN_SCORE = 5;
    private const int BALL_CYAN_SCORE = 7;

	private int _CurrentRedBall;
	private int _CurrentGreenBall;
	private int _CurrentCyanBall;

	private int _CurrentScore;

	public void CurrentReset()
	{
		_CurrentScore = 0;
        _CurrentRedBall = 0;
        _CurrentGreenBall = 0;
        _CurrentCyanBall = 0;
        CurrentScoreChanged(_CurrentScore);
        CurrentBallChanged(BallType.btRed, _CurrentRedBall);
        CurrentBallChanged(BallType.btGreen, _CurrentGreenBall);
        CurrentBallChanged(BallType.btCyan, _CurrentCyanBall);
	}
    public void CurrentSave()
    {
        if (_CurrentScore > BestScore)
            BestScore = _CurrentScore;
        TotalRedBall += _CurrentRedBall;
        TotalGreenBall += _CurrentGreenBall;
        TotalCyanBall += _CurrentCyanBall;
    }

	public void CurrentScoreAdd(int value)
	{
		_CurrentScore += value;
		if (CurrentScoreChanged != null)
			CurrentScoreChanged(_CurrentScore);
	}
    public void CurrentScoreAdd(BallType type)
    {
        switch (type)
        {
            case BallType.btRed:
                CurrentScoreAdd(BALL_RED_SCORE);
                break;
            case BallType.btGreen:
                CurrentScoreAdd(BALL_GREEN_SCORE);
                break;
            case BallType.btCyan:
                CurrentScoreAdd(BALL_CYAN_SCORE);
                break;
        }
    }
    public void CurrentBallAdd(BallType type, int value)
    {
        switch (type)
        {
            case BallType.btRed:
                _CurrentRedBall += value;
                if (CurrentBallChanged != null)
                    CurrentBallChanged(type, _CurrentRedBall);
                break;
            case BallType.btGreen:
                _CurrentGreenBall += value;
                if (CurrentBallChanged != null)
                    CurrentBallChanged(type, _CurrentGreenBall);
                break;
            case BallType.btCyan:
                _CurrentCyanBall += value;
                if (CurrentBallChanged != null)
                    CurrentBallChanged(type, _CurrentCyanBall);
                break;
        }
    }

    public int CurrentRedBall
    {
        get { return _CurrentRedBall; }
    }
    public int CurrentGreenBall
    {
        get { return _CurrentGreenBall; }
    }
    public int CurrentCyanBall
    {
        get { return _CurrentCyanBall; }
    }
    public int CurrentScore
    {
        get { return _CurrentScore; }
    }

    public event Action<BallType, int> CurrentBallChanged;
	public event Action<int> CurrentScoreChanged;
    #endregion

	#region Singleton
	private static readonly ScoreManager _Instance = new ScoreManager();

    private ScoreManager()
    {
        _BestScore = PlayerPrefs.GetInt(BEST_SCORE, 0);
        _TotalRedBall = PlayerPrefs.GetInt(TOTAL_RED_BALL, 0);
        _TotalGreenBall = PlayerPrefs.GetInt(TOTAL_GREEN_BALL, 0);
        _TotalCyanBall = PlayerPrefs.GetInt(TOTAL_CYAN_BALL, 0);
    }

	public static ScoreManager Instance
	{
		get { return _Instance; }
	}
	#endregion
}