using System.Collections.Generic;
using ChronoArkMod.Plugin;
using GameDataEditor;
using HarmonyLib;

namespace Snake
{
    public class Snake_Plugin : ChronoArkPlugin
    {
        private Harmony harmony;

        public override void Dispose()
        {
            if (harmony != null)
            {
                harmony.UnpatchSelf();
            }
        }

        public override void Initialize()
        {
            harmony = new Harmony(GetGuid());
            harmony.PatchAll();
        }
    }

    /// <summary>
    /// 第一幕开局赠送 3 个贪吃蛇硬币。
    /// </summary>
    [HarmonyPatch(typeof(FieldSystem))]
    class FieldSystem_Patch
    {
        [HarmonyPostfix]
        [HarmonyPatch(nameof(FieldSystem.StageStart))]
        static void StageStartPostfix()
        {
            if (PlayData.TSavedata.NowStageMapKey == GDEItemKeys.Stage_Stage1_1)
            {
                List<ItemBase> list = new List<ItemBase>();
                list.Add(ItemBase.GetItem(ModItemKeys.Item_Consume_Item_Snake, 3));
                InventoryManager.Reward(list);
            }
        }
    }
}
