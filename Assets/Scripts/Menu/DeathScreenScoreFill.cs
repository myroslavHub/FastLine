using UnityEngine;
using UnityEngine.UI;

public class DeathScreenScoreFill : MonoBehaviour
{
    public Text _Score;
    public Text _RedBalls;
    public Text _GreenBalls;
    public Text _CyanBalls;

    private void OnEnable()
    {
        _Score.text = "Score : " + ScoreManager.Instance.CurrentScore;
        _RedBalls.text = " : " + ScoreManager.Instance.CurrentRedBall;
        _GreenBalls.text = " : " + ScoreManager.Instance.CurrentGreenBall;
        _CyanBalls.text = " : " + ScoreManager.Instance.CurrentCyanBall;
    }
}