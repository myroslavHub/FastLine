using UnityEngine;
using UnityEngine.UI;

public class ScoreBallListener: MonoBehaviour
{
    public Text _Text;
    public BallType _BallType;

	void OnDisable()
	{
		ScoreManager.Instance.CurrentBallChanged -= ScoreUpdate;
	}
    void OnEnable()
    {
        ScoreManager.Instance.CurrentBallChanged += ScoreUpdate;
    }
    private void ScoreUpdate(BallType type, int score)
    {
        if (_BallType == type)
        {
            _Text.text = " : " + score;
        }
    }
}