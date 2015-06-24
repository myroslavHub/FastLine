using UnityEngine;
using UnityEngine.UI;

public class ScoreListener : MonoBehaviour
{
	public Text _Text;

	void OnDisable()
	{
		ScoreManager.Instance.CurrentScoreChanged -= ScoreUpdate;
	}
	void OnEnable()
	{
		ScoreManager.Instance.CurrentScoreChanged += ScoreUpdate;
	}

	private void ScoreUpdate(int score)
	{
		_Text.text = "Score : " + score;
	}
}