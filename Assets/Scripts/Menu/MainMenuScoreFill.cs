using UnityEngine;
using UnityEngine.UI;

public class MainMenuScoreFill : MonoBehaviour
{
    public Text _BestScore;
    public Text _RedBalls;
    public Text _GreenBalls;
    public Text _CyanBalls;
	public Image _Character;

    private void OnEnable()
    {
        _BestScore.text = "Best Score : " + ScoreManager.Instance.BestScore;
        _RedBalls.text = " : " + ScoreManager.Instance.TotalRedBall;
        _GreenBalls.text = " : " + ScoreManager.Instance.TotalGreenBall;
        _CyanBalls.text = " : " + ScoreManager.Instance.TotalCyanBall;
	    _Character.sprite = Resources.Load<Sprite>("Character/" + CharacterManager.Instance.PlayerType);
    }
}