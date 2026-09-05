using System.Collections.Generic;
using DarkTonic.MasterAudio;
using GameDataEditor;

namespace BossPhoenix
{
    /// <summary>
    /// 找面包（很急！）
    /// 获得1个面包。
    /// </summary>
    public class S_Lucy_FindBreadUrgent : Skill_Extended
    {
        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            base.SkillUseSingle(SkillD, Targets);
            InventoryManager.Reward(ItemBase.GetItem(GDEItemKeys.Item_Consume_Bread));
            MasterAudio.PlaySound("Food Eat 02", 1f, null, 0f, null, null, false, false);
        }
    }
}
