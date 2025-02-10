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
namespace Yuyuko
{
	/// <summary>
	/// 西行寺幽幽子
	/// Passive:
	/// <b>操纵死亡程度的能力</b> - 西行寺幽幽子模糊了生与死的界限，部分技能会增加或减少<color=#FFB6C1>返魂值</color>。
	/// <b><color=#FF1493>华胥</color></b> - 当<color=#FFB6C1>返魂值</color>的进度超过50时，西行寺幽幽子进入<color=#FF1493>华胥</color>状态，获得10%的攻击力和防御力加成，同时技能会获得加强。
	/// <b><color=#8B008B>永眠</color></b> - 当<color=#FFB6C1>返魂值</color>的进度超过100时，西行寺幽幽子进入<color=#8B008B>永眠</color>状态：无法行动，直到<color=#FFB6C1>返魂值</color>降低为0；<color=#8B008B>永眠</color>状态下，使用技能时失去20<color=#FFB6C1>返魂值</color>。
	/// <b>幽雅地绽放吧，墨染之樱</b> - 每个回合开始时，西行寺幽幽子失去20<color=#FFB6C1>返魂值</color>。
	/// </summary>
    public class P_YuyukoF:Passive_Char, IP_DamageChange, IP_PlayerTurn, IP_FanhunChange, IP_ButterflyChange, IP_BattleStart_Ones, IP_BattleEnd, IP_OnSkillExcept
    {
        public enum YuyuState
        {
            State_Normal = 0,
            State_Huaxu = 1,
            State_Yongmian = 2,
        }

        private static YuyuState yuyu;

        public static YuyuState Yuyu
        {
            get
            {
                return yuyu;
            }

            set
            {
                yuyu = value;
            }
        }

        private Skill originbasicskill = new Skill();

        //OP领域大神
        public override void Init()
        {
            base.Init();
            this.OnePassive = true;
        }

        //战斗开始时，切入普通状态
        public void BattleStart(BattleSystem Ins)
        {
            Yuyu = YuyuState.State_Normal;
            this.BChar.BuffAdd("B_YuyukoF_P_1", this.BChar);
            this.BChar.BuffAdd("B_YuyukoF_Ghost", this.BChar);
            originbasicskill = (this.BChar as BattleAlly).MyBasicSkill.buttonData;
        }

        //战斗结束时，切入普通状态
        public void BattleEnd()
        {
            Yuyu = YuyuState.State_Normal;
        }

        //每个回合开始时，西行寺幽幽子减少20返魂值。
        public void Turn()
        {
            if (BattleSystem.instance.GetBattleValue<BV_YuyukoF_P>() == null)
            {
                BattleSystem.instance.BattleValues.Add(new BV_YuyukoF_P());
            }

            BattleSystem.instance.GetBattleValue<BV_YuyukoF_P>().setFanhun(20);
        }

        //西行寺幽幽子的攻击不再造成伤害，而是降低目标等量的最大体力值。
        public int DamageChange(Skill SkillD, BattleChar Target, int Damage, ref bool Cri, bool View)
        {
            if (!View && Damage > 0)
            {
                if (BattleSystem.instance.GetBattleValue<BV_YuyukoF_P>() == null)
                {
                    BattleSystem.instance.BattleValues.Add(new BV_YuyukoF_P());
                }

                BattleSystem.instance.GetBattleValue<BV_YuyukoF_P>().setDieList(Target, Damage, this.BChar);
            }

            return 0;
        }

        //当返魂值的进度超过50时，西行寺幽幽子进入华胥状态。
        //当返魂值的进度超过100时，西行寺幽幽子进入永眠状态。
        //在永眠状态下、当返魂值的进度等于0时，西行寺幽幽子进入正常状态。
        public void FanhunChange(int count)
        {
            if (count >= 100)
            {
                SetYuyukoState(YuyuState.State_Yongmian);
            }
            else if (Yuyu == YuyuState.State_Yongmian && count <= 0)
            {
                SetYuyukoState(YuyuState.State_Normal);
            }
            else if (Yuyu != YuyuState.State_Yongmian && count >= 50)
            {
                SetYuyukoState(YuyuState.State_Huaxu);
            }
            else if (Yuyu == YuyuState.State_Huaxu && count < 50)
            {
                SetYuyukoState(YuyuState.State_Normal);
            }
        }

        //进入华胥状态、进入永眠状态、解除永眠状态时，可再次使用固定能力。
        public void SetYuyukoState(YuyuState state)
        {
            if (Yuyu == state)
            {
                return;
            }

            Yuyu = state;

            switch (state)
            {
                case YuyuState.State_Normal:
                    {
                        this.BChar.BuffReturn("B_YuyukoF_P_2")?.SelfDestroy();
                        this.BChar.BuffReturn("B_YuyukoF_P_3")?.SelfDestroy();
                        this.BChar.BuffAdd("B_YuyukoF_P_1", this.BChar);

                        Skill skill = originbasicskill;
                        if (skill != null)
                        {
                            (this.BChar as BattleAlly).MyBasicSkill.SkillInput(skill);
                        }
                    }
                    break;
                case YuyuState.State_Huaxu:
                    {
                        this.BChar.BuffReturn("B_YuyukoF_P_1")?.SelfDestroy();
                        this.BChar.BuffReturn("B_YuyukoF_P_3")?.SelfDestroy();
                        this.BChar.BuffAdd("B_YuyukoF_P_2", this.BChar);

                        Skill skill = Skill.TempSkill("S_YuyukoF_P_1", this.BChar, this.BChar.MyTeam);
                        (this.BChar as BattleAlly).MyBasicSkill.SkillInput(skill);

                        //进入华胥状态时，从放逐牌库将1个自己的技能放回牌库最上方
                        {
                            List<Skill> excDeck = Enumerable.ToList<Skill>(Enumerable.Where<Skill>(BV_ExceptDeck.TryGetExcptedSkills(), (Skill sk) => sk.MySkill.KeyID != "S_YuyukoF_P_1"));

                            if (excDeck.Count > 0)
                            {
                                BattleSystem.DelayInput(BattleSystem.I_OtherSkillSelect(excDeck, delegate (SkillButton skillbutton)
                                {
                                    BV_ExceptDeck.RemoveSkill(skillbutton.Myskill);
                                    BattleSystem.DelayInput(DelReturn(skillbutton.Myskill));
                                }, ModManager.getModInfo("YasakaKanano").localizationInfo.SystemLocalizationUpdate("exceptSkillSelect"), true, true, true, false, true));
                            }
                        }
                    }
                    break;
                case YuyuState.State_Yongmian:
                    {
                        this.BChar.BuffReturn("B_YuyukoF_P_1")?.SelfDestroy();
                        this.BChar.BuffReturn("B_YuyukoF_P_2")?.SelfDestroy();
                        this.BChar.BuffAdd("B_YuyukoF_P_3", this.BChar);

                        Skill skill = Skill.TempSkill("S_YuyukoF_P_3", this.BChar, this.BChar.MyTeam);
                        (this.BChar as BattleAlly).MyBasicSkill.SkillInput(skill);

                        //进入永眠状态时，使所有敌人失去10%最大体力值，并回引所有幽冥蝶和人魂蝶
                        {
                            foreach (BattleEnemy be in BattleSystem.instance.EnemyList)
                            {
                                BattleSystem.instance.GetBattleValue<BV_YuyukoF_P>().setDieList(be, be.Info.OriginStat.maxhp * 10 / 100, this.BChar);
                            }

                            ReturnAllButterfly();
                        }
                    }
                    break;
            }

            //this.BChar.MyTeam.BasicSkillRefill(this.BChar, this.BChar.BattleBasicskillRefill);
            (this.BChar as BattleAlly).MyBasicSkill.CoolDownNum = 0;
            if ((this.BChar as BattleAlly).MyBasicSkill.ThisSkillUse)
            {
                (this.BChar as BattleAlly).MyBasicSkill.InActive = false;
                (this.BChar as BattleAlly).MyBasicSkill.ThisSkillUse = false;
            }
            if ((this.BChar as BattleAlly).MyBasicSkill.InActive)
            {
                (this.BChar as BattleAlly).MyBasicSkill.InActive = false;
            }
        }

        //进入华胥状态时，从放逐牌库将1个自己的技能放回牌库最上方
        private IEnumerator DelReturn(Skill skill)
        {
            yield return new WaitForFixedUpdate();

            yield return CustomMethods.I_SkillBackToDeck(skill, 0, true);

            yield return new WaitForFixedUpdate();
            yield return new WaitForSeconds(0.5f);
        }

        //回引所有幽冥蝶和人魂蝶
        public static void ReturnAllButterfly()
        {
            foreach (BattleEnemy be in BattleSystem.instance.EnemyList)
            {
                be.BuffReturn("B_YuyukoF_Butterfly_M")?.SelfDestroy();
                be.BuffReturn("B_YuyukoF_Butterfly_R")?.SelfDestroy();
            }

            BattleSystem.instance.GetBattleValue<BV_YuyukoF_P>().str_M = "";
            BattleSystem.instance.GetBattleValue<BV_YuyukoF_P>().str_R = "";
        }

        //场上同时存在幽冥蝶和人魂蝶时，固定技能被替换为亡乡「亡我乡 -自尽-」
        public void ButterflyChange()
        {
            if (BattleSystem.instance.GetBattleValue<BV_YuyukoF_P>().str_M != "" && BattleSystem.instance.GetBattleValue<BV_YuyukoF_P>().str_R != "")
            {
                Skill skill = Skill.TempSkill("S_YuyukoF_P_2", this.BChar, this.BChar.MyTeam);
                (this.BChar as BattleAlly).MyBasicSkill.SkillInput(skill);
            }
        }

        //每有1个技能被放逐，西行寺幽幽子获得1点亡魂。
        public bool OnSkillExcept(Dictionary<Skill, SkillLocation> exceptSkills)
        {
            if (BattleSystem.instance.GetBattleValue<BV_YuyukoF_P>() == null)
            {
                BattleSystem.instance.BattleValues.Add(new BV_YuyukoF_P());
            }

            BattleSystem.instance.GetBattleValue<BV_YuyukoF_P>().ghost += exceptSkills.Count;
            return true;
        }

        //判断亡魂点数是否大于X。若isPreview为true，则不消耗；否则消耗亡魂点数。
        public static bool CheckGhost(int count, bool isPreview = false)
        {
            if (BattleSystem.instance.GetBattleValue<BV_YuyukoF_P>() == null)
            {
                BattleSystem.instance.BattleValues.Add(new BV_YuyukoF_P());
            }

            if (BattleSystem.instance.GetBattleValue<BV_YuyukoF_P>().ghost >= count)
            {
                if (!isPreview)
                {
                    BattleSystem.instance.GetBattleValue<BV_YuyukoF_P>().ghost -= count;

                    foreach (IP_GhostChange ip_ghostChange in BattleSystem.instance.IReturn<IP_GhostChange>())
                    {
                        if (ip_ghostChange != null)
                        {
                            ip_ghostChange.GhostChange(count);
                        }
                    }
                }
                return true;
            }

            return false;
        }

        //亡者召还X：从放逐牌库中、费用不超过X的技能中，将随机1个费用最高的技能拿回手中（持有者不为自己的一次性技能除外）。
        public static void DeadRevive(BattleChar bc, int count)
        {
            List<Skill> excDeck = Enumerable.ToList<Skill>(Enumerable.Where<Skill>(BV_ExceptDeck.TryGetExcptedSkills(), 
                                                           (Skill skill) => !(skill.Master != bc && skill.Disposable) && skill._AP <= count));

            if (excDeck?.Count > 0)
            {
                var maxAp = excDeck.Max(skill => skill.AP);
                var maxApSkills = excDeck.Where(skill => skill.AP == maxAp).ToList();
                var random = new System.Random();
                var randomSkill = maxApSkills[random.Next(maxApSkills.Count)];

                BV_ExceptDeck.RemoveSkill(randomSkill);
                BattleSystem.instance.AllyTeam.Add(randomSkill, false);
            }
        }
    }
}