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
namespace Necromancer
{
	/// <summary>
	/// 忘却之灵
	/// 解锁固定能力。
	/// 使用固定能力后解除。
	/// 受到的痛苦伤害转为治疗，使生命值最高的队友受到同等伤害，并解除。
	/// </summary>
    public class B_Necromancer_1:Buff, IP_SkillUse_BasicSkill, IP_DamageTake
    {
        public override void BuffStat()
        {
            if (BChar.BuffFind("B_Necromancer_0"))
            {
                BChar.BuffRemove("B_Necromancer_0");
            }
        }

        public void DamageTake(BattleChar User, int Dmg, bool Cri, ref bool resist, bool NODEF = false, bool NOEFFECT = false, BattleChar Target = null)
        {
            if (Target == BChar && Dmg > 0 && NODEF == true && !View)
            {
                resist = true;
                BChar.Heal(BChar, (float)Dmg, false);
                /*
                int allayMaxHp = 0;
                BattleChar maxhpAllay = null;
                foreach (BattleChar battleChar in BattleSystem.instance.AllyTeam.AliveChars)
                {
                    if (battleChar.HP >  allayMaxHp)
                    {
                        allayMaxHp = battleChar.HP;
                        maxhpAllay = battleChar;
                    }
                }
                if (maxhpAllay != null && maxhpAllay != BChar)
                {
                    maxhpAllay.Damage(BChar, Dmg, false, true);
                }
                */
                DestoryMe();
            }
        }

        public override void Init()
        {
            base.Init();
            this.OnePassive = true;
        }

        public void SkillUseBasicSkill(Skill skill)
        {
            if (skill.Master == BChar)
            DestoryMe();
        }
        private void DestoryMe()
        {
            if (BChar.Info.KeyData == ModItemKeys.Character_Necromancer)
            {
                GDEImageDatasData temp = new GDEImageDatasData("NecromancerImage");
                AddressableLoadManager.LoadAsyncAction(temp.Sprites_Path[1], AddressableLoadManager.ManageType.Character, BChar.UI.CharImage.GetComponent<Image>());
            }
            Skill skill = Skill.TempSkill("S_P_Necromancer_2", BChar, BChar.MyTeam);
            (BChar as BattleAlly).MyBasicSkill.SkillInput(skill);
            (BChar as BattleAlly).MyBasicSkill.CoolDownNum = 0;
            BChar.BuffRemove("B_Necromancer_2");
            this.SelfDestroy();
        }
    }
}