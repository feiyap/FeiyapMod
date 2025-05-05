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
namespace Parsee
{
	/// <summary>
	/// 剪舌麻雀「大葛笼与小葛笼」
	/// 选择：
	/// 对谦虚的富者之记恨 - 获得300金币，点燃3层妒火。
	/// 舌切雀的尖鸣 - 受到攻击时反击(50%攻击力)，持续3回合。抽取1个技能。受到相当于最大体力值50%的痛苦伤害。
	/// </summary>
    public class S_Parsee_5:Skill_Extended
    {
        public override void AttackEffectSingle(BattleChar hit, SkillParticle SP, int DMG, int Heal)
        {
            this.TargetTemp = hit;
            List<Skill> list = new List<Skill>();
            list.Add(Skill.TempSkill("S_Parsee_5_1", this.MySkill.Master, this.MySkill.Master.MyTeam));
            list.Add(Skill.TempSkill("S_Parsee_5_2", this.MySkill.Master, this.MySkill.Master.MyTeam));
            BattleSystem.instance.EffectDelays.Enqueue(BattleSystem.I_OtherSkillSelect(list, new SkillButton.SkillClickDel(this.Del), ScriptLocalization.System_SkillSelect.TargetEffectSelect, false, false, true, false, true));
        }
        
        public override string DescExtended(string desc)
        {
            return base.DescExtended(desc).Replace("&a", ((int)(this.BChar.GetStat.atk * 0.5f)).ToString());
        }
        
        public void Del(SkillButton Mybutton)
        {
            if (Mybutton.Myskill.MySkill.KeyID == "S_Parsee_5_1")
            {
                this.BChar.BuffAdd("B_Parsee_P", this.BChar);
                this.BChar.BuffAdd("B_Parsee_P", this.BChar);
                this.BChar.BuffAdd("B_Parsee_P", this.BChar);
                PlayData.Gold += 300;
            }
            if (Mybutton.Myskill.MySkill.KeyID == "S_Parsee_5_2")
            {
                this.BChar.BuffAdd("B_Parsee_5_0", this.BChar);
                BattleSystem.instance.AllyTeam.Draw();
                this.BChar.Damage(this.BChar, (int)(this.BChar.GetStat.maxhp * 0.5), false, true);
            }
        }
        
        private BattleChar TargetTemp;
    }
}