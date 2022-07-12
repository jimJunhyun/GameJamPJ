using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomizeInitPos : MonoBehaviour
{
    public Vector2 randomRange;

	Vector3 offSet;

	private void Awake()
	{
		 offSet = new Vector2(Random.Range((int)-randomRange.x, (int)randomRange.x + 1), Random.Range((int)-randomRange.y, (int)randomRange.y + 1));
		transform.position += offSet;
	}
}
