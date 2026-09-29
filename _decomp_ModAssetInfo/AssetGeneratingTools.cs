using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.TextCore;
using UnityEngine.UI;

namespace ChronoArkMod.ModData;

public static class AssetGeneratingTools
{
	public static Color[] blacks = new Color[123200];

	public static GameObject Makeface(string ImageKey, Vector2 offsetMax, Vector2 offsetMin, Vector2 pivot)
	{
		GameObject gameObject = UnityEngine.Object.Instantiate(AddressableLoadManager.LoadAsyncCompletion<GameObject>("CharImagePrefebs/Face/Face_Johan", AddressableLoadManager.ManageType.None));
		Image component = gameObject.GetComponent<Image>();
		if (!ImageKey.IsNullOrEmpty())
		{
			component.sprite = AssetManager.ModSprite(ImageKey);
		}
		RectTransform component2 = gameObject.GetComponent<RectTransform>();
		component2.offsetMax = offsetMax;
		component2.offsetMin = offsetMin;
		component2.pivot = pivot;
		component2.localPosition = Vector3.zero;
		UnityEngine.Object.DontDestroyOnLoad(gameObject);
		return gameObject;
	}

	public static GameObject MakeSmallFace(string ImageKey, Vector2 offsetMax, Vector2 offsetMin, Vector2 pivot)
	{
		GameObject gameObject = UnityEngine.Object.Instantiate(AddressableLoadManager.LoadAsyncCompletion<GameObject>("CharImagePrefebs/FaceSmall/FaceSmall_Johan", AddressableLoadManager.ManageType.None));
		Image component = gameObject.GetComponent<Image>();
		if (!ImageKey.IsNullOrEmpty())
		{
			component.sprite = AssetManager.ModSprite(ImageKey);
		}
		RectTransform component2 = gameObject.GetComponent<RectTransform>();
		component2.offsetMax = offsetMax;
		component2.offsetMin = offsetMin;
		component2.pivot = pivot;
		component2.localPosition = Vector3.zero;
		UnityEngine.Object.DontDestroyOnLoad(gameObject);
		return gameObject;
	}

	public static GameObject MakeBattleChar(string ImageKey, Vector2 offsetMax, Vector2 offsetMin, Vector2 pivot)
	{
		GameObject gameObject = UnityEngine.Object.Instantiate(AddressableLoadManager.LoadAsyncCompletion<GameObject>("CharImagePrefebs/JohanBattle", AddressableLoadManager.ManageType.None));
		Image component = gameObject.GetComponent<Image>();
		if (!ImageKey.IsNullOrEmpty())
		{
			component.sprite = AssetManager.ModSprite(ImageKey);
		}
		RectTransform component2 = component.GetComponent<RectTransform>();
		component2.offsetMax = offsetMax;
		component2.offsetMin = offsetMin;
		component2.pivot = pivot;
		component2.localPosition = Vector3.zero;
		UnityEngine.Object.DontDestroyOnLoad(gameObject);
		return gameObject;
	}

	public static GameObject MakeEnemy(string ImageKey, Vector3 Head, Vector3 Center, Vector3 UI)
	{
		GameObject gameObject = UnityEngine.Object.Instantiate(AddressableLoadManager.LoadAsyncCompletion<GameObject>("BattleEnemy/HealBallon", AddressableLoadManager.ManageType.None));
		EnemyCustom component = gameObject.GetComponent<EnemyCustom>();
		if (!ImageKey.IsNullOrEmpty())
		{
			Texture2D texture2D = AddressableLoadManager.LoadAsyncCompletion<Texture2D>(ImageKey, AddressableLoadManager.ManageType.None);
			Sprite sprite = (component.MainSprite = Sprite.Create(texture2D, new Rect(0f, 0f, texture2D.width, texture2D.height), new Vector2(0.5f, 0f), 100f, 0u, SpriteMeshType.FullRect));
			gameObject.GetComponent<SpriteRenderer>().sprite = sprite;
		}
		component.Head.transform.localPosition = Head;
		component.Center.transform.localPosition = Center;
		component.UI.transform.localPosition = UI;
		UnityEngine.Object.DontDestroyOnLoad(gameObject);
		gameObject.transform.position = new Vector3(100f, 100f, 100f);
		return gameObject;
	}

	public static Texture2D LoadTexture(string path)
	{
		Texture2D texture2D = new Texture2D(4096, 4096, TextureFormat.ARGB32, mipChain: false);
		try
		{
			FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read);
			fileStream.Seek(0L, SeekOrigin.Begin);
			byte[] array = new byte[fileStream.Length];
			try
			{
				fileStream.Read(array, 0, array.Length);
			}
			catch (Exception message)
			{
				Debug.Log(message);
			}
			fileStream.Close();
			texture2D.LoadImage(array);
			texture2D.Apply();
		}
		catch (Exception exception)
		{
			Debug.LogException(exception);
		}
		return texture2D;
	}

	public static Texture2D SkillImageResizeTexture2D(Texture2D ori_tex)
	{
		int num = 440;
		int num2 = 280;
		int width = ori_tex.width;
		int height = ori_tex.height;
		int num3 = (num - width) / 2;
		int num4 = (num2 - height) / 2;
		if ((num3 > 0 && num4 > 0) || (num3 == 0 && num4 > 0) || (num3 > 0 && num4 == 0))
		{
			_ = ref blacks[0];
			Texture2D texture2D = new Texture2D(num, num2);
			Color[] pixels = ori_tex.GetPixels();
			texture2D.SetPixels(blacks);
			texture2D.SetPixels(num3, num4, width, height, pixels);
			texture2D.Apply();
			return texture2D;
		}
		return ori_tex;
	}

	public static Sprite SkillImageResizeGet(string path)
	{
		try
		{
			Texture2D texture2D = AssetManager.ModTexture2D(path);
			if (texture2D == null)
			{
				return null;
			}
			texture2D = SkillImageResizeTexture2D(texture2D);
			return Misc.CreatSprite(texture2D);
		}
		catch
		{
			return AssetManager.ModSprite(path);
		}
	}

	public static Sprite ChangePivot(string path, Vector2 pivot)
	{
		try
		{
			Texture2D texture2D = AssetManager.ModTexture2D(path);
			if (texture2D == null)
			{
				return null;
			}
			return Sprite.Create(texture2D, new Rect(0f, 0f, texture2D.width, texture2D.height), pivot, 100f, 0u, SpriteMeshType.FullRect);
		}
		catch
		{
			return AssetManager.ModSprite(path);
		}
	}

	public static TMP_SpriteAsset CreateTMPSpriteAsset(Sprite sprite)
	{
		TMP_SpriteAsset tMP_SpriteAsset = ScriptableObject.CreateInstance<TMP_SpriteAsset>();
		tMP_SpriteAsset.name = sprite.name;
		typeof(TMP_SpriteAsset).GetProperty("version").GetSetMethod(nonPublic: true).Invoke(tMP_SpriteAsset, new object[1] { "1.1.0" });
		tMP_SpriteAsset.hashCode = TMP_TextUtilities.GetSimpleHashCode(tMP_SpriteAsset.name);
		List<TMP_SpriteGlyph> spriteGlyphTable = new List<TMP_SpriteGlyph>();
		List<TMP_SpriteCharacter> spriteCharacterTable = new List<TMP_SpriteCharacter>();
		TMP_PopulateSpriteTables(sprite, ref spriteCharacterTable, ref spriteGlyphTable);
		typeof(TMP_SpriteAsset).GetProperty("spriteCharacterTable").GetSetMethod(nonPublic: true).Invoke(tMP_SpriteAsset, new object[1] { spriteCharacterTable });
		typeof(TMP_SpriteAsset).GetProperty("spriteGlyphTable").GetSetMethod(nonPublic: true).Invoke(tMP_SpriteAsset, new object[1] { spriteGlyphTable });
		TMP_AddDefaultMaterial(tMP_SpriteAsset);
		tMP_SpriteAsset.UpdateLookupTables();
		return tMP_SpriteAsset;
	}

	private static void TMP_PopulateSpriteTables(Sprite sprite, ref List<TMP_SpriteCharacter> spriteCharacterTable, ref List<TMP_SpriteGlyph> spriteGlyphTable)
	{
		TMP_SpriteGlyph tMP_SpriteGlyph = new TMP_SpriteGlyph();
		tMP_SpriteGlyph.index = 0u;
		tMP_SpriteGlyph.metrics = new GlyphMetrics(sprite.rect.width, sprite.rect.height, 0f - sprite.pivot.x, sprite.rect.height - sprite.pivot.y, sprite.rect.width);
		tMP_SpriteGlyph.glyphRect = new GlyphRect(sprite.rect);
		tMP_SpriteGlyph.scale = 1f;
		tMP_SpriteGlyph.sprite = sprite;
		spriteGlyphTable.Add(tMP_SpriteGlyph);
		TMP_SpriteCharacter tMP_SpriteCharacter = new TMP_SpriteCharacter(0u, tMP_SpriteGlyph);
		tMP_SpriteCharacter.name = sprite.name;
		tMP_SpriteCharacter.scale = 1f;
		spriteCharacterTable.Add(tMP_SpriteCharacter);
	}

	private static void TMP_AddDefaultMaterial(TMP_SpriteAsset spriteAsset)
	{
		Material material = new Material(Shader.Find("TextMeshPro/Sprite"));
		spriteAsset.spriteSheet = spriteAsset.spriteGlyphTable.FirstOrDefault()?.sprite?.texture;
		material.SetTexture(ShaderUtilities.ID_MainTex, spriteAsset.spriteSheet);
		spriteAsset.material = material;
		material.hideFlags = HideFlags.HideInHierarchy;
	}
}
You are not using the latest version of the tool, please update.
Latest version is '11.1.0.9782' (yours is '9.1.0.7988')
