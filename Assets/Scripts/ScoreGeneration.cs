using UnityEngine;
using System.Collections;

public class ScoreGeneration : MonoBehaviour
{
	private void Start()
	{
		ScoreManager.Instance.CurrentReset();
		StartCoroutine(Spawn());
	}

	private IEnumerator Spawn()
	{
		while (true)
		{
			yield return new WaitForSeconds(0.4f);
			ScoreManager.Instance.CurrentScoreAdd(1);
		}
	}
}