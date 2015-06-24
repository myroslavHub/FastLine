using UnityEngine;

public class BackGroundManager : MonoBehaviour
{

	public GameObject _BackgroundLine;
	public float _StartPositionX = -10;
	public float _RestartPositionX = 12;
	public int _Count = 12;

	private int swipeCount = 0;

	void Start () 
	{
		for (int i = 0; i < _Count; i++)
		{
			var objUp = (GameObject)Instantiate(_BackgroundLine, new Vector3(_StartPositionX + 2 * i, 4, _BackgroundLine.transform.position.z), Quaternion.identity);
			(objUp.GetComponent<SpriteRenderer>()).color = ColorHelper.GetRandomBGColor();

			var objDown = (GameObject)Instantiate(_BackgroundLine, new Vector3(_StartPositionX + 2 * i, -4, _BackgroundLine.transform.position.z), Quaternion.identity);
			(objDown.GetComponent<SpriteRenderer>()).color = ColorHelper.GetRandomBGColor();
			objDown.transform.localScale = new Vector3(objDown.transform.localScale.x, -1, objDown.transform.localScale.z);
		}
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag == "BackLine")
		{
			other.gameObject.transform.position = new Vector3(_RestartPositionX, other.gameObject.transform.position.y,
				other.gameObject.transform.position.z);
			(other.gameObject.GetComponent<SpriteRenderer>()).color = ColorHelper.GetRandomBGColor();
			swipeCount++;
			if (swipeCount > 5)
			{
				ColorHelper.GoDark();
				swipeCount = 0;
			}
		}
	}
}