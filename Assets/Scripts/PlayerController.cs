using UnityEngine;

public class PlayerController : MonoBehaviour
{
	public float _JumpForce = 530;

	private GameManager _gameManager;
	private bool _isUp = true;
	private Rigidbody2D _rigidbody2D;

	private bool _grounded;
	public LayerMask _LayerMask;
	public Transform _GroundCheck;
	private float _circleRadius = 0.1f;

	public ParticleSystem _CircleDestroyEffect;

	void FixedUpdate()
	{
		_grounded = Physics2D.OverlapCircle(_GroundCheck.position, _circleRadius, _LayerMask);
	}
	void OnCollisionEnter2D(Collision2D coll)
	{
		if (coll.gameObject.tag == "Enemy")
		{
			_gameManager.EndGame();
			Destroy(gameObject);
		}
		if (coll.gameObject.tag == "Ball")
		{
			BallType type = coll.gameObject.GetComponent<BallScript>()._Type;
			ScoreManager.Instance.CurrentBallAdd(type, 1);
			ScoreManager.Instance.CurrentScoreAdd(type);

			instantiate(_CircleDestroyEffect, coll.gameObject);

			//Destroy(coll.gameObject);
		}
	}

	private ParticleSystem instantiate(ParticleSystem prefab, GameObject gameObject)
	{
		ParticleSystem newParticleSystem = Instantiate(
		  prefab,
		  gameObject.transform.position,
		  Quaternion.identity
		) as ParticleSystem;


		Destroy(
		  newParticleSystem.gameObject,
		  newParticleSystem.startLifetime
		);

		Destroy(
			gameObject.gameObject,
			newParticleSystem.startLifetime
			);

		return newParticleSystem;
	}

	void OnDisable()
	{
		TouchAndSwipeBehavior.OnSwipeDetected -= OnSwipe;
	}
	void OnEnable()
	{
		TouchAndSwipeBehavior.OnSwipeDetected += OnSwipe;
	}
	void Start()
	{
		var spriteRenderer = GetComponent<SpriteRenderer>();
		spriteRenderer.sprite = Resources.Load<Sprite>("Character/" + CharacterManager.Instance.PlayerType.ToString());
		_rigidbody2D = GetComponent<Rigidbody2D>();
		_gameManager = FindObjectOfType<GameManager>();
	}

	void OnSwipe(Swipe swipe)
	{
		if (_grounded)
		{
			if (swipe == Swipe.Up && _isUp)
				_rigidbody2D.AddForce(new Vector2(0, _JumpForce));
			else if (swipe == Swipe.Down && !_isUp)
				_rigidbody2D.AddForce(new Vector2(0, -_JumpForce));
			else
				Flip();
		}
		else
		{
			if (!_isUp && swipe == Swipe.Up)
				_rigidbody2D.AddForce(new Vector2(0, _JumpForce));
			if (_isUp && swipe == Swipe.Down)
				_rigidbody2D.AddForce(new Vector2(0, -_JumpForce));
		}
	}
	void Flip()
	{
		_isUp = !_isUp;
		_rigidbody2D.gravityScale *= -1;
		var pos = transform.position;
		pos.y *= -1;
		transform.position = pos;
		var scale = transform.localScale;
		scale.y *= -1;
		transform.localScale = scale;
	}
}