using HarmonyLib;
using GameDataEditor;

namespace DiffcultSystem
{
    /// <summary>
    /// 循循善诱：生成地图时将 Event_EnemyNum 设为原战斗格数量，并取消战斗格生成。
    /// </summary>
    public static class EndorphinGuidingMap
    {
        public static bool IsActive =>
            EndorphinSave.Instance.endorphinActiveList.Exists(a => a == "Endorphin_Guiding");

        public static void ApplyStageDataOverride(GDEStageData stageData)
        {
            if (stageData == null)
            {
                return;
            }

            int battleTileCount = stageData.EnemyNum;
            stageData.EnemyNum = 0;
            stageData.Event_EnemyNum = battleTileCount;
        }
    }

    [HarmonyPatch(typeof(HexGenerator), nameof(HexGenerator.GeneratorMap))]
    public static class HexGenerator_GeneratorMap_Guiding_Patch
    {
        [HarmonyPrefix]
        static void Prefix(GDEStageData StageData)
        {
            if (!EndorphinGuidingMap.IsActive ||
                StageData == null ||
                (PlayData.TSavedata != null && PlayData.TSavedata.IsLoaded))
            {
                return;
            }

            EndorphinGuidingMap.ApplyStageDataOverride(StageData);
        }
    }
}
