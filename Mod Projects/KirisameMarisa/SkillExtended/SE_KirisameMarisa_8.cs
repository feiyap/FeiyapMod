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
namespace KirisameMarisa
{
	/// <summary>
	/// 转变为指向所有敌人；且若目标只有一个，以暴击形式命中。
	/// </summary>
    public class SE_KirisameMarisa_8: BuffSkillExHand
    {
        public override void Init()
        {
            base.Init();
            this.OnePassive = true;
        }

        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            base.SkillUseSingle(SkillD, Targets);

            if (SkillD.Master.Info.Ally && SkillD.Master.Info.Ally != Targets[0].Info.Ally && !SkillD.FreeUse && !SkillD.PlusHit && !SkillD.ForceAction && !SkillD.BasicSkill)
            {
                foreach (BattleChar battleChar in BattleSystem.instance.EnemyTeam.AliveChars)
                {
                    if (battleChar != Targets[0])
                    {
                        Targets.Add(battleChar);
                    }
                }
            }

            if (Targets.Count == 1)
            {
                this.PlusSkillStat.cri = 100f;
            }

            this.MainBuff.SelfStackDestroy();
        }
    }
}