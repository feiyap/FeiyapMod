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
	/// 爱姬
	/// 本次战斗中，妒火层数固定为3。
	/// 每当帕露西使用非生成技能时，自身获得1层“神德”。指向友军时，改为对目标施加1层“润泽”。
	/// 每当露西在内的其他友军使用非生成技能，帕露西获得1层“爱”。
	/// 爱的层数重置后，接下来从手中释放的3个技能的伤害量、恢复量增加33%。
	/// 可以代替濒死友军成为攻击目标。
	/// </summary>
    public class B_Parsee_Rare_2:Buff, IP_SkillUse_Team_Target, IP_TargetedAlly
    {
        public override void FixedUpdate()
        {
            base.FixedUpdate();
            
            if ((this.BChar.BuffReturn("B_Parsee_P")?.StackNum ?? 0) > 3)
            {
                this.BChar.BuffReturn("B_Parsee_P").SelfDestroy();
            }
            if ((this.BChar.BuffReturn("B_Parsee_P")?.StackNum ?? 0) < 3)
            {
                this.BChar.BuffAdd("B_Parsee_P", this.BChar);
            }
        }

        public void SkillUseTeam_Target(Skill skill, List<BattleChar> Targets)
        {
            if (skill.Master != this.BChar && !skill.IsCreatedInBattle)
            {
                this.BChar.BuffAdd("B_Parsee_Rare_2_2", this.BChar);
            }

            if (skill.Master == this.BChar && !skill.IsCreatedInBattle)
            {
                if (Targets[0].Info.Ally)
                {
                    foreach (BattleChar bc in Targets)
                    {
                        bc.BuffAdd("B_Parsee_Rare_2_1", this.BChar);
                    }
                }
                else
                {
                    this.BChar.BuffAdd("B_Parsee_Rare_2_0", this.BChar);
                }
            }
        }

        public IEnumerator Targeted(BattleChar Attacker, List<BattleChar> SaveTargets, Skill skill)
        {
            bool flag = false;
            for (int i = 0; i < SaveTargets.Count; i++)
            {
                if (SaveTargets[i] == this.BChar)
                {
                    flag = true;
                    break;
                }
            }
            if (!flag && this.BChar.Info.KeyData != GDEItemKeys.Character_Phoenix)
            {
                List<Skill> list = new List<Skill>();
                foreach (BattleChar battleChar in SaveTargets)
                {
                    if (battleChar.HP <= 0)
                    {
                        list.Add(Skill.TempSkill(GDEItemKeys.Skill_S_Bodyguard, this.BChar, this.BChar.MyTeam));
                        Extended_BodyGuard extended_BodyGuard = list[list.Count - 1].ExtendedFind("Extended_BodyGuard", true) as Extended_BodyGuard;
                        extended_BodyGuard.Target = battleChar;
                        extended_BodyGuard.SaveTargets = SaveTargets;
                    }
                }
                if (list.Count != 0)
                {
                    list.Add(Skill.TempSkill(GDEItemKeys.Skill_S_Bodyguard_1, this.BChar, this.BChar.MyTeam));
                    BattleSystem.instance.EffectDelays.Enqueue(BattleSystem.I_OtherSkillSelect(list, new SkillButton.SkillClickDel(this.Del), ScriptLocalization.UI_Battle_Item.BodyGuardNeck_0, false, false, true, false, true));
                }
            }
            yield return null;
            yield break;
        }
        
        public void Del(SkillButton Mybutton)
        {
            if (Mybutton.Myskill.ExtendedFind("Extended_BodyGuard", true) != null)
            {
                Extended_BodyGuard extended_BodyGuard = Mybutton.Myskill.ExtendedFind("Extended_BodyGuard", true) as Extended_BodyGuard;
                for (int i = 0; i < extended_BodyGuard.SaveTargets.Count; i++)
                {
                    if (extended_BodyGuard.SaveTargets[i] == extended_BodyGuard.Target)
                    {
                        extended_BodyGuard.SaveTargets[i] = this.BChar;
                        return;
                    }
                }
            }
        }
    }
}