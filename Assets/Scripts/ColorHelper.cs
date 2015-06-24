using UnityEngine;

public class ColorHelper
{
	private static Color colorA = new Color(1, 0.736f, 0.579f);
	private static Color colorB = new Color(1, 0.969f, 0.953f);

	private static float _left = 0.8f;
	private static float _right = 1.0f;

	public static Color GetRandomBGColor()
	{
		return Color.Lerp(colorA, colorB, Random.Range(_left, _right));
	}
	public static Color GetRandomCubeColor()
	{
		return Color.black;
//		return Color.Lerp(Color.black, Color.red, Random.Range(0f, 0.6f));
	}
	public static void GoDark()
	{
		if (_left - 0.1f > 0)
		{
			_left -= 0.1f;
			_right -= 0.1f;
		}
	}
	public static void ResetBGInfo()
	{
		_left = 0.8f;
		_right = 1.0f;
	}
}