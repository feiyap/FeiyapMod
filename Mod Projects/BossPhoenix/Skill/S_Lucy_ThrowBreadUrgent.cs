using System.Collections.Generic;
using DarkTonic.MasterAudio;
using GameDataEditor;

namespace BossPhoenix
{
    /// <summary>
    /// 扔面包（很急！）
    /// 消耗1个面包。
    /// </summary>
    public class S_Lucy_ThrowBreadUrgent : Skill_Extended
    {
        public override bool ButtonSelectTerms()
        {
            if (PartyInventory.InvenM.FindItem(GDEItemKeys.Item_Consume_Bread) <= 0)
            {
                return false;
            }
            return base.ButtonSelectTerms();
        }

        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            base.SkillUseSingle(SkillD, Targets);
            if (PartyInventory.InvenM.FindItem(GDEItemKeys.Item_Consume_Bread) > 0)
            {
                PartyInventory.InvenM.DelItem(GDEItemKeys.Item_Consume_Bread, 1);
                MasterAudio.PlaySound("Food Eat 02", 1f, null, 0f, null, null, false, false);
            }

            if (Targets == null || Targets.Count == 0)
            {
                return;
            }

            BattleChar target = Targets[0];
            if (target != null && target.Info.KeyData == ModItemKeys.Enemy_Boss_Phoenix)
            {
                B_BossPhoenix_P passive = B_BossPhoenix_P.Get(target);
                if (passive != null && !passive.Soothed)
                {
                    passive.SootheAndDefeat();
                }
            }
        }
    }
}
