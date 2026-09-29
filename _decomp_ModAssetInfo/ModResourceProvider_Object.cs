using System;
using ChronoArkMod.ModData;
using UnityEngine.ResourceManagement.ResourceProviders;

namespace ChronoArkMod.Addressable;

public class ModResourceProvider_Object : ResourceProviderBase
{
	private string id;

	public override string ProviderId => base.ProviderId + id;

	private ModInfo info => ModManager.getModInfo(id);

	public ModResourceProvider_Object(string id)
	{
		this.id = id;
	}

	public override void Provide(ProvideHandle provideHandle)
	{
		if (provideHandle.Location.PrimaryKey == "null")
		{
			provideHandle.Complete<object>(null, status: true, null);
		}
		object obj = (provideHandle.Location.Data as ModAssetInfo.ModObjectInfo).Get();
		if (obj != null)
		{
			Type type = provideHandle.Type;
			if (obj.GetType().IsAssignableFrom(type))
			{
				provideHandle.Complete(obj, status: true, null);
			}
			else
			{
				provideHandle.Complete<object>(null, status: false, new Exception((provideHandle.Location.Data as ModAssetInfo.ModImageInfo).ToString() + "Type Error"));
			}
		}
		else
		{
			provideHandle.Complete<object>(null, status: false, new Exception((provideHandle.Location.Data as ModAssetInfo.ModImageInfo).ToString() + "Load Error"));
		}
	}
}
You are not using the latest version of the tool, please update.
Latest version is '11.1.0.9782' (yours is '9.1.0.7988')
