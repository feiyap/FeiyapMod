using System;
using System.Collections.Generic;
using System.Linq;
using DarkTonic.MasterAudio;
using GameDataEditor;
using HarmonyLib;
using UnityEngine;
using ChronoArkMod;
using ChronoArkMod.Plugin;
using ChronoArkMod.Template;
using ChronoArkMod.ModData;
using BasicMethods;

namespace MinamiRio
{
    public class FieldStorePatch : ModDefinition
    {
        [FieldStoreItem]
        public ItemBase FieldStorePatchBase(FieldStore store)
        {
            return ItemBase.GetItem(ModItemKeys.Item_Misc_ForgeTree_TreeOfLife);
        }
    }
}
