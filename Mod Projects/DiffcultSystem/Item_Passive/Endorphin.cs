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
using UnityEngine.Events;

namespace DiffcultSystem
{
	/// <summary>
	/// 内啡肽
	/// 已激活的内啡肽：
	/// &a
	/// </summary>
    public class Endorphin:PassiveItemBase, IP_TurnEnd, IP_PlayerTurn, IP_Draw, IP_SkillUse_Target, IP_HPChange, IP_DamageTake, IP_DrawNumChange, IP_BattleEndRewardChange, IP_BattleStart_Ones
    {
        public override string DescExtended(string desc)
        {
            string baseDesc = base.DescExtended(desc);

            if (EndorphinSave.Instance.endorphinActiveList == null || EndorphinSave.Instance.endorphinActiveList.Count == 0)
            {
                return baseDesc.Replace("&a", "");
            }
            else
            {
                string replacementText = string.Join("\n",
                    EndorphinSave.Instance.endorphinActiveList.Select(key =>
                    {
                        ItemBase item = ItemBase.GetItem(key, 1);
                        return item?.GetName ?? key;
                    })
                );
                return baseDesc.Replace("&a", replacementText);
            }
        }

        public override void Init()
        {
            base.Init();
        }

        public int fixCount = 0;
        public override void FixedUpdate()
        {
            base.FixedUpdate();
            fixCount++;
            if (fixCount >= 12)
            {
                fixCount = 0;
                //鬼祟玲珑：+露西技能法力值消耗-1。
                //鬼祟玲珑：+露西技能获得迅速。
                if (EndorphinSave.Instance.endorphinActiveList.Exists(a => a == "Endorphin_Sly"))
                {
                    foreach (Skill skill in BattleSystem.instance.AllyTeam.Skills)
                    {
                        if ((skill.Master == BattleSystem.instance.AllyTeam.LucyAlly) && skill.ExtendedFind_DataName("SE_Sly_0") == null)
                        {
                            skill.ExtendedAdd(Skill_Extended.DataToExtended("SE_Sly_0"));
                        }
                    }
                }
                //食髓知味：+速度+2。每回合抽取6个技能。
                if (EndorphinSave.Instance.endorphinActiveList.Exists(a => a == "Endorphin_Addicted"))
                {
                    this.PlusStat.PlusDraw = 4;
                    this.PlusStat.spd = 2;
                }
                else
                {
                    this.PlusStat.PlusDraw = 0;
                    this.PlusStat.spd = 0;
                }
                //同舟共济：+队员最大体力值+5。
                if (EndorphinSave.Instance.endorphinActiveList.Exists(a => a == "Endorphin_Unified"))
                {
                    this.PlusStat.maxhp = 5;
                }
                else
                {
                    this.PlusStat.maxhp = 0;
                }
                //坚韧不拔：+队伍受到伤害-10%
                if (EndorphinSave.Instance.endorphinActiveList.Exists(a => a == "Endorphin_Persistent"))
                {
                    this.PlusStat.DMGTaken = -10;
                }
                else
                {
                    this.PlusStat.DMGTaken = 0;
                }
            }
        }

        public void BattleStart(BattleSystem Ins)
        {
            //坚韧不拔：-敌人拥有30%濒死抵抗。
            if (!EndorphinSave.Instance.endorphinActiveList.Exists(a => a == "Endorphin_Persistent"))
            {
                return;
            }

            foreach (BattleEnemy enemy in Ins.EnemyList)
            {
                if (enemy != null && !enemy.IsDead)
                {
                    enemy.BuffAdd("B_Endorphin_PersistentResist", enemy, true);
                }
            }
        }

        public void Turn()
        {
            //坚韧不拔：+场上有3个及以上敌人时获得保护体力极限。
            if (EndorphinSave.Instance.endorphinActiveList.Exists(a => a == "Endorphin_Persistent"))
            {
                int aliveEnemyCount = BattleSystem.instance.EnemyList.Count(enemy => enemy != null && !enemy.IsDead);
                this.PlusStat.Strength = aliveEnemyCount >= 3;
            }
            else
            {
                this.PlusStat.Strength = false;
            }

            //疑神疑鬼：+战斗开始时，在抽牌堆中随机加入一张露西技能。
            if (EndorphinSave.Instance.endorphinActiveList.Exists(a => a == "Endorphin_Paranoid"))
            {
                if (BattleSystem.instance.TurnNum == 1 && PlayData.TSavedata.LucySkills != null && PlayData.TSavedata.LucySkills.Count > 0)
                {
                    string lucySkillKey = PlayData.TSavedata.LucySkills.Random(BattleSystem.instance.AllyTeam.LucyChar.GetRandomClass().Main);
                    Skill lucySkill = Skill.TempSkill(lucySkillKey, BattleSystem.instance.AllyTeam.LucyChar, BattleSystem.instance.AllyTeam);
                    BattleSystem.instance.AllyTeam.Skills_Deck.Add(lucySkill);
                }
            }
            //循循善诱：+每经过一个区域，战斗开始时获得1点法力值。
            if (EndorphinSave.Instance.endorphinActiveList.Exists(a => a == "Endorphin_Guiding"))
            {
                if (BattleSystem.instance.TurnNum == 1)
                {
                    BattleSystem.instance.AllyTeam.AP += PlayData.TSavedata.StageNum;
                    // 不能超过鬼祟玲珑的拮抗上限
                    if (BattleSystem.instance.AllyTeam.AP > BattleSystem.instance.AllyTeam.MAXAP)
                    {
                        BattleSystem.instance.AllyTeam.AP = BattleSystem.instance.AllyTeam.MAXAP;
                    }
                }
            }
        }

        public void TurnEnd()
        {
            //食髓知味：+回合结束时丢弃所有手牌。
            //食髓知味：-速度小于3时，回合结束时所有队员获得1层盐疫。
            if (EndorphinSave.Instance.endorphinActiveList.Exists(a => a == "Endorphin_Addicted"))
            {
                BattleSystem.DelayInput(this.Del());
                if (PlayData.PartySpeed < 3)
                {
                    foreach (BattleAlly ba in BattleSystem.instance.AllyList)
                    {
                        ba.BuffAdd("B_FishingVillageDebuff", ba);
                    }
                }
            }
        }

        //食髓知味：+回合结束时丢弃所有手牌。
        private IEnumerator Del()
        {
            yield return new WaitForFixedUpdate();

            for (int i = 0; i < BattleSystem.instance.AllyTeam.Skills.Count; i++)
            {
                BattleSystem.instance.AllyTeam.Skills[i].Delete(false);
            }
            yield return new WaitForFixedUpdate();

            yield break;
        }

        //鬼祟玲珑：-攻击时，随机获得法力值。（0~3）
        public void AttackEffect(BattleChar hit, SkillParticle SP, int DMG, bool Cri)
        {
            if (EndorphinSave.Instance.endorphinActiveList.Exists(a => a == "Endorphin_Sly"))
            {
                if (SP.LastHit && !SP.SkillData.PlusHit && SP.SkillData.IsDamage)
                {
                    BattleSystem.instance.AllyTeam.AP += UnityEngine.Random.Range(0, 4);
                }
            }
        }

        //鬼祟玲珑：-技能法力值随机重置。（重置区间0 ~3）
        public IEnumerator Draw(Skill Drawskill, bool NotDraw)
        {
            if (EndorphinSave.Instance.endorphinActiveList.Exists(a => a == "Endorphin_Sly"))
            {
                Drawskill.APChange = UnityEngine.Random.Range(0, 4);
            }
            yield break;
        }

        public void HPChange(BattleChar Char, bool Healed)
        {
            //同舟共济：-体力值最低的干员嘲讽值 + 77
            if (EndorphinSave.Instance.endorphinActiveList.Exists(a => a == "Endorphin_Unified"))
            {
                BattleAlly ba = BattleSystem.instance.AllyList.OrderBy(bab => bab.HP).FirstOrDefault();
                if (ba == null)
                {
                    return;
                }
                if (!ba.BuffFind("B_UnifiedDebuff"))
                {
                    foreach (BattleAlly ba2 in BattleSystem.instance.AllyList)
                    {
                        ba2.BuffRemove("B_UnifiedDebuff");
                    }
                    ba.BuffAdd("B_UnifiedDebuff", ba);
                }
            }
        }

        public void DamageTake(BattleChar User, int Dmg, bool Cri, ref bool resist, bool NODEF = false, bool NOEFFECT = false, BattleChar Target = null)
        {
            //同舟共济：+濒死状态队员每受到攻击时抽取1个技能。
            if (EndorphinSave.Instance.endorphinActiveList.Exists(a => a == "Endorphin_Unified"))
            {
                if (Target.Info.Ally && Target.HP <= 0)
                {
                    BattleSystem.instance.AllyTeam.Draw(1);
                }
            }
        }

        //标新立异：-战斗开始时，只会抽取1名随机队员的技能。（包括普通技能和稀有技能）
        public void DrawNumChange(int DrawNum, out int OutNum)
        {
            if (EndorphinSave.Instance.endorphinActiveList.Exists(a => a == "Endorphin_Innovative") && BattleSystem.instance.TurnNum == 0)
            {
                OutNum = 0;
                for (int i = 0 ; i < DrawNum ; i++)
                {
                    BattleChar battleChar = BattleSystem.instance.AllyList.Random(BattleRandom.PassiveItem);
                    BattleSystem.instance.AllyTeam.CharacterDraw(battleChar);
                }
            }
            else
            {
                OutNum = DrawNum;
            }
        }

        //内陆帝国：+战斗结束时获得4个额外的随机战利品。
        public void BattleEndRewardChange()
        {
            if (!EndorphinSave.Instance.endorphinActiveList.Exists(a => a == "Endorphin_InlandEmpire"))
            {
                return;
            }

            EndorphinInlandEmpireLoot.AddExtraBattleRewards(4);
        }
    }
}