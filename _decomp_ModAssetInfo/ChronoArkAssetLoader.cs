using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace ChronoArkMod.InUnity;

public abstract class ChronoArkAssetLoader : MonoBehaviour
{
	public static List<AsyncOperationHandle> AllHandle = new List<AsyncOperationHandle>();

	[HideInInspector]
	internal List<GameObject> GameObjects = new List<GameObject>();

	public List<string> RelatedChronoArkGameObjects = new List<string>();

	public abstract void Load();

	public void PrePare()
	{
		if (GameObjects.Count == 0 || GameObjects.All((GameObject g) => g == null))
		{
			GameObjects.Clear();
			foreach (string relatedChronoArkGameObject in RelatedChronoArkGameObjects)
			{
				AsyncOperationHandle<GameObject> asyncOperationHandle = Addressables.LoadAssetAsync<GameObject>(relatedChronoArkGameObject);
				AllHandle.Add(asyncOperationHandle);
				GameObjects.Add(asyncOperationHandle.WaitForCompletion());
			}
		}
		Load();
	}

	public void Start()
	{
		PrePare();
	}

	public void Update()
	{
		PrePare();
	}
}
You are not using the latest version of the tool, please update.
Latest version is '11.1.0.9782' (yours is '9.1.0.7988')
