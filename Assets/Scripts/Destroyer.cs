using UnityEngine;

public class Destroyer : MonoBehaviour
{
	void OnCollisionEnter2D(Collision2D coll)
	{
		Destroy(coll.gameObject);
	}
}