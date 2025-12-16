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
using BasicMethods;
namespace Jhin
{
    /// <summary>
    /// 绚葬之华
    /// <b>无法使用。</b>
    /// 握在手中时，每次敌人行动，对其施加“穿帮”减益，此技能的 X 回合后弃牌的回合计数将减少 1 。
    /// 这个技能被丢弃时，生成 1 个“万众倾倒”。
    /// </summary>
    public class S_Jhin_4 : Skill_Extended, IP_EnemyActionBefore
    {
        public override void Init()
        {
            base.Init();
            this.OnePassive = true;
        }

        public override bool Terms()
        {
            return false;
        }

        public override void DiscardSingle(bool Click)
        {
            Skill tmpSkill = Skill.TempSkill("S_Jhin_3", this.BChar, this.BChar.MyTeam);
            tmpSkill.Disposable = true;
            BattleSystem.instance.AllyTeam.Add(tmpSkill, true);
            base.DiscardSingle(Click);
        }

        public IEnumerator EnemyActionBefore(BattleEnemy ActionEnemy, Skill EnemyUseSkill, bool IsDelayWait)
        {
            ActionEnemy.BuffAdd("B_Jhin_4", this.BChar, false, 0, false, 5);

            if (this.MySkill.AutoDelete == 1)
            {
                BattleSystem.DelayInputAfter(this.Del(this.MySkill));
            }
            else
            {
                this.MySkill.AutoDelete--;
            }

            yield break;
        }

        private IEnumerator Del(Skill skill)
        {
            skill.Delete(false);
            yield break;
        }
    }
}