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
	/// 切舍御免
	/// 受到伤害时，直到回合结束前，攻击力增加那个数值的值。
	/// </summary>
    public class B_Feiyap_Boss_P:Buff, IP_DamageTake, IP_TurnEnd, IP_HPChange, IP_BattleStart_Ones, IP_BattleStart_UIOnBefore
    {
        public int Phase = 1;

        //处理战斗事件
        public void BattleStartUIOnBefore(BattleSystem Ins)
        {
            BattleSystem.DelayInput(this.Start1());

            BattleSystem.instance.Reward.Add(ItemBase.GetItem("SkillBookCharacter_Rare"));
            BattleSystem.instance.Reward.Add(ItemBase.GetItem("Item_BurnFullDuck"));
        }

        //开场对话
        public IEnumerator Start1()
        {
            MasterAudio.StopBus("BGM");
            MasterAudio.StopBus("BattleBGM");
            MasterAudio.FadeBusToVolume("BGM", 1f, 1f, null, false, false);
            MasterAudio.FadeBusToVolume("BattleBGM", 0f, 0.5f, null, false, false);

            {
                yield return BattleText.InstBattleText_Co(this.BChar, ModManager.getModInfo("FeiyapBoss").localizationInfo.SystemLocalizationUpdate("BattleDia/Boss_Feiyap/Text1"), true, 0, 0f);
                yield return BattleText.InstBattleText_Co(this.BChar, ModManager.getModInfo("FeiyapBoss").localizationInfo.SystemLocalizationUpdate("BattleDia/Boss_Feiyap/Text2"), true, 0, 0f);
                yield return BattleText.InstBattleText_Co(this.BChar, ModManager.getModInfo("FeiyapBoss").localizationInfo.SystemLocalizationUpdate("BattleDia/Boss_Feiyap/Text3"), true, 0, 0f);
            }

            MasterAudio.PlaySound("Boss_Feiyap_BGM", 1f, null, 0f, null, null, false, false);

            yield break;
        }

        public override void Init()
        {
            base.Init();
            this.PlusStat.HIT_CC = 11f;
            this.PlusStat.HIT_DEBUFF = 11f;
            this.PlusStat.HIT_DOT = 11f;
        }

        public void BattleStart(BattleSystem Ins)
        {
            Ins.BattleExtended.Add(new BattleEvent_Feiyap());
            BattleEvent_Feiyap.Boss = this.BChar;
            BattleEvent_Feiyap.MainP = this;
            Phase = 1;
        }

        public void DamageTake(BattleChar User, int Dmg, bool Cri, ref bool resist, bool NODEF = false, bool NOEFFECT = false, BattleChar Target = null)
        {
            if (Target == this.BChar)
            {
                this.PlusStat.atk += Dmg;
            }
        }

        public void TurnEnd()
        {
            this.PlusStat.atk = 0;
        }

        public void HPChange(BattleChar Char, bool Healed)
        {
            if (Char == this.BChar)
            {
                if (this.BChar.HP <= this.BChar.GetStat.maxhp / 2 && Phase == 1)
                {
                    //进入惩罚阶段
                    BattleSystem.DelayInput(this.Phase2());

                    Phase = 2;
                    this.BChar.BuffAdd("B_Feiyap_Boss_P_2", this.BChar);
                    
                    int lastAct = 0;
                    foreach (CastingSkill cs in BattleSystem.instance.EnemyCastSkills)
                    {
                        if (cs.skill.Master == this.BChar && cs.CastSpeed > lastAct)
                        {
                            lastAct = cs.CastSpeed;
                        }
                    }

                    List<BattleChar> list = new List<BattleChar>();
                    Skill skill = Skill.TempSkill("S_Feiyap_Boss_5", this.BChar, this.BChar.MyTeam);
                    list.AddRange((this.BChar as BattleEnemy).Ai.TargetSelect(skill));
                    BattleSystem.instance.EnemyCastEnqueue(this.BChar as BattleEnemy, skill, list, lastAct + 2, false);

                    (this.BChar as BattleEnemy).ChangeSprite(this.getSprite("FeiyapStarFallen"));
                }
            }
        }

        public Sprite createSpriteWithPivot(Sprite Feiyap, Vector2 pivot)
        {
            return UnityEngine.Sprite.Create(Feiyap.texture, Feiyap.rect, pivot);
        }

        // Token: 0x060001C7 RID: 455 RVA: 0x0000C904 File Offset: 0x0000AB04
        public Sprite getSprite(string spriteName)
        {
            string text = spriteName + ".png";
            string text2 = ModManager.getModInfo("FeiyapBoss").assetInfo.ImageFromFile(text);
            Sprite sprite = AddressableLoadManager.LoadAsyncCompletion<Sprite>(text2, 0);
            Vector2 pivot = new Vector2(0.45f, -0.02f);
            return this.createSpriteWithPivot(sprite, pivot);
        }

        public IEnumerator Phase2()
        {
            MasterAudio.StopBus("BGM");
            MasterAudio.StopBus("BattleBGM");
            MasterAudio.FadeBusToVolume("BGM", 1f, 1f, null, false, false);
            MasterAudio.FadeBusToVolume("BattleBGM", 0f, 0.5f, null, false, false);

            {
                yield return BattleText.InstBattleText_Co(this.BChar, ModManager.getModInfo("FeiyapBoss").localizationInfo.SystemLocalizationUpdate("BattleDia/Boss_Feiyap/Text4"), true, 0, 0f);
                yield return BattleText.InstBattleText_Co(this.BChar, ModManager.getModInfo("FeiyapBoss").localizationInfo.SystemLocalizationUpdate("BattleDia/Boss_Feiyap/Text5"), true, 0, 0f);
                yield return BattleText.InstBattleText_Co(this.BChar, ModManager.getModInfo("FeiyapBoss").localizationInfo.SystemLocalizationUpdate("BattleDia/Boss_Feiyap/Text6"), true, 0, 0f);
            }

            MasterAudio.PlaySound("Boss_Feiyap_BGM_2", 1f, null, 0f, null, null, false, false);

            yield break;
        }
    }
}