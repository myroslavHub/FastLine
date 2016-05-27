using UnityEngine;

public class Move : MonoBehaviour
{
	public int Speed;

	private void Start()
	{
		//GetComponent<Rigidbody2D>().velocity = new Vector2(-Speed, 0);
	}

	void Update()
	{
		transform.position += Vector3.left * Speed * Time.deltaTime;
	}
}