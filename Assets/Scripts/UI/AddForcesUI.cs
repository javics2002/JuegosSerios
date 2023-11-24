using System;
using UnityEngine;
using UnityEngine.Serialization;

public class AddForcesUI : MonoBehaviour
{
	public LevelData levelData;

	[FormerlySerializedAs("scalarPrefab")]
	[SerializeField]
	private GameObject ScalarPrefab;

	[FormerlySerializedAs("vectorialPrefab")]
	[SerializeField]
	private GameObject VectorPrefab;

	private void Awake()
	{
		if (levelData is null)
		{
			throw new ArgumentNullException(nameof(levelData));
		}
	}

	private void Start()
	{
		// Create prefabs
		foreach (var scalar in levelData.Scalars)
		{
			// Instantiate object as children of this (canvas)
			var newObj = Instantiate(ScalarPrefab, gameObject.transform);
			newObj.GetComponent<ScalarForce>().Force = (int)scalar;
		}

		foreach (var vector in levelData.Vectors)
		{
			// Instantiate object as children of this (canvas)
			var newObj = Instantiate(VectorPrefab, gameObject.transform);
			newObj.GetComponent<VectorForce>().Force = vector;
		}
	}
}