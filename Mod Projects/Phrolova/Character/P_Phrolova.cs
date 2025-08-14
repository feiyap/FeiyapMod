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
namespace Phrolova
{
    /// <summary>
    /// Passive:
    /// 每次释放自己的技能时，获得 1 层“乐声”。
    /// “乐声”叠加至 6 层后，固定能力会替换为“谱曲终末”。
    /// 受到来自队友的伤害提升100%。
    /// 队伍中每有 1 个角色阵亡，弗洛洛就会永久持有 1 层“乐声”。
    /// </summary>
    public class P_Phrolova : Passive_Char, IP_SkillUse_Team, IP_DamageTakeChange
    {
        public override void Init()
        {
            base.Init();
            this.OnePassive = true;
        }

        public override void FixedUpdate()
        {
            base.FixedUpdate();

            if (BattleSystem.instance != null)
            {
                int deadnum = BattleSystem.instance.AllyTeam.Chars.Count(c => c != null && c.IsDead);

                if (deadnum > 0 && deadnum > (this.BChar.BuffReturn("B_Phrolova_P")?.StackNum ?? 0))
                {
                    for (int i = 0; i < deadnum - (this.BChar.BuffReturn("B_Phrolova_P")?.StackNum ?? 0); i++)
                    {
                        this.BChar.BuffAdd("B_Phrolova_P", this.BChar);
                    }
                }
            }
        }

        public int DamageTakeChange(BattleChar Hit, BattleChar User, int Dmg, bool Cri, bool NODEF = false, bool NOEFFECT = false, bool Preview = false)
        {
            if (User.Info.Ally && User != this.BChar && Dmg > 0)
            {
                Dmg = Dmg * 2;
            }
            return Dmg;
        }

        public void SkillUseTeam(Skill skill)
        {
            this.BChar.BuffAdd("B_Phrolova_P", this.BChar);
        }
    }
}