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
namespace FeiyapBoss
{
	/// <summary>
	/// 明镜止水
	/// 若自身持有的减益数量超过 5 个，解除自身所有<sprite=0>弱化减益和<sprite=1>痛苦减益。受到那些减益的剩余伤害量的痛苦伤害。
	/// 移除所有手牌的额外增益效果。
	/// </summary>
    public class S_Feiyap_Boss_2:Skill_Extended
    {
        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            base.SkillUseSingle(SkillD, Targets);

            new List<Skill>();
            List<Skill> list = new List<Skill>();
            list.AddRange(BattleSystem.instance.AllyTeam.Skills.FindAll(t => t.MySkill.KeyID != "S_Feiyap_Boss_2"));
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].Master.IsLucyNoC || list[i].Master != Targets[0])
                {
                    list.RemoveAt(i);
                    i--;
                }
            }

            BattleSystem.instance.EffectDelays.Enqueue(BattleSystem.I_OtherSkillSelect(list, new SkillButton.SkillClickDel(this.Del), ScriptLocalization.System_SkillSelect.King_1, false, true, true, false, true));
        }

        public void Del(SkillButton Mybutton)
        {
            BattleSystem.instance.AllyTeam.Skills.Remove(Mybutton.Myskill);
            BattleSystem.instance.StartCoroutine(BattleSystem.instance.ActWindow.Window.SkillInstantiate(BattleSystem.instance.AllyTeam, true));
        }
    }
}