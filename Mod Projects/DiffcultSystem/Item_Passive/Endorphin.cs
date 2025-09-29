using UnityEngine;
using UnityEngine.UI;
using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using GameDataEditor;
using I2.Loc;
using DarkTonic.MasterAudio;
using ChronoArkMod;
using ChronoArkMod.Plugin;
using ChronoArkMod.Template;
using Debug = UnityEngine.Debug;
using UnityEngine.Events;

namespace DiffcultSystem
{
	/// <summary>
	/// 内啡肽
	/// 已激活的内啡肽：
	/// &a
	/// </summary>
    public class Endorphin:PassiveItemBase
    {
        public override string DescExtended(string desc)
        {
            string baseDesc = base.DescExtended(desc);

            if (EndorphinSave.Instance.endorphinActiveList == null || EndorphinSave.Instance.endorphinActiveList.Count == 0)
            {
                return baseDesc.Replace("&a", "");
            }
            else
            {
                string replacementText = string.Join("\n",
                    EndorphinSave.Instance.endorphinActiveList.Select(key =>
                    {
                        ItemBase item = ItemBase.GetItem(key, 1);
                        return item?.GetName ?? key;
                    })
                );
                return baseDesc.Replace("&a", replacementText);
            }
        }
    }
}