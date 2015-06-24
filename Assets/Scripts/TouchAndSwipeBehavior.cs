using UnityEngine;

public enum Swipe { Left, Right, Up, Down };

public class TouchAndSwipeBehavior: MonoBehaviour
{
	public float minSwipeDistance = 0.05f;

	private float screenDiagonalSize;
	private float minimumSwipeDistanceInPixels;

	private bool touchStarted;
	private Vector2 touchStartPosition;
	
	private void Start()
	{
		screenDiagonalSize = Mathf.Sqrt(Screen.width * Screen.width + Screen.height * Screen.height);
		minimumSwipeDistanceInPixels = minSwipeDistance * screenDiagonalSize; 
	}
	private void Update()
	{
		if (Input.GetKeyUp(KeyCode.UpArrow))
		{
            OnSwipeDetectedRaise(Swipe.Up);
		}
		if (Input.GetKeyUp(KeyCode.DownArrow))
		{
            OnSwipeDetectedRaise(Swipe.Down);
		}

		if (Input.touchCount > 0)
		{
			var touch = Input.touches[0];
			
			switch (touch.phase)
			{
			case TouchPhase.Began:
				touchStarted = true;
				touchStartPosition = touch.position;
				break;
				
			case TouchPhase.Ended:
				if (touchStarted) {
					TestForTouchOrSwipeGesture(touch);
					touchStarted = false;
				}
				break;
				
			case TouchPhase.Canceled:
				touchStarted = false;
				break;
			}
		}
	}

    private void OnTouchDetectedRaise(Touch touch)
    {
        if (OnTouchDetected != null)
            OnTouchDetected(touch);
    }
    private void OnSwipeDetectedRaise(Swipe swipe)
    {
        if (OnSwipeDetected != null)
            OnSwipeDetected(swipe);
    }
	private void TestForTouchOrSwipeGesture(Touch touch)
	{
		Vector2 lastPosition = touch.position;
		float distance = Vector2.Distance(lastPosition, touchStartPosition);
		
		if (distance > minimumSwipeDistanceInPixels)
		{
			float dy = lastPosition.y - touchStartPosition.y;
			float dx = lastPosition.x - touchStartPosition.x;
			
			float angle = Mathf.Rad2Deg * Mathf.Atan2(dx, dy);
			
			angle = (360 + angle - 45) % 360;
			
			if (angle < 90)
                OnSwipeDetectedRaise(Swipe.Right);
			else if (angle < 180)
                OnSwipeDetectedRaise(Swipe.Down);
			else if (angle < 270)
                OnSwipeDetectedRaise(Swipe.Left);
			else
                OnSwipeDetectedRaise(Swipe.Up);
		}
		else
		{
            OnTouchDetectedRaise(touch);
		}
	}

	public static event System.Action<Touch> OnTouchDetected;
	public static event System.Action<Swipe> OnSwipeDetected;
}