using UnityEngine;
using System.Collections;

public class ObjectSpawner : MonoBehaviour
{
	public GameObject _SpawnObject;
	public Vector2 _TimesSpan = new Vector2(1.5f, 2.4f);

	public bool IsCircle = false;
	public bool IsUp = false;


    private bool lev1 = false;
    private bool lev2 = false;
    private bool lev3 = false;

	public void Reset()
	{
		lev1 = false;
		lev2 = false;
		lev3 = false;
		_TimesSpan = new Vector2(1.5f, 2.4f);
	}

	void Start()
	{
		StartCoroutine(Spawn());
	}

	IEnumerator Spawn()
	{
		while (true)
		{
			yield return new WaitForSeconds(Random.Range(_TimesSpan.x, _TimesSpan.y));
			GameObject gameObject = (GameObject)Instantiate(_SpawnObject, this.transform.position, Quaternion.identity);
			if (!IsCircle)
			{
			    if (ScoreManager.Instance.CurrentScore > 70 && !lev1)
			    {
			        lev1 = true;
			        _TimesSpan = new Vector2(_TimesSpan.x - 0.3f, _TimesSpan.y - 0.3f);
			    }
			    if (ScoreManager.Instance.CurrentScore > 150 && !lev2)
			    {
			        _TimesSpan = new Vector2(_TimesSpan.x - 0.3f, _TimesSpan.y - 0.3f);
			        lev2 = true;
			    }
			    if (ScoreManager.Instance.CurrentScore > 220 && !lev3)
			    {
			        _TimesSpan = new Vector2(_TimesSpan.x - 0.3f, _TimesSpan.y - 0.3f);
			        lev3 = true;
			    }
			    gameObject.GetComponent<SpriteRenderer>().color = ColorHelper.GetRandomCubeColor();
			}
			gameObject.GetComponent<Rigidbody2D>().gravityScale *= IsUp ? 1 : -1;
		}
	}
}