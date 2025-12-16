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
namespace CirnoBlizzard
{
	/// <summary>
	/// 枯萎冻结之心
	/// 受到攻击时，进行一次 &a 伤害的反击(攻击力的25%)。
	/// 回合结束时，对所有单位造成 &b 痛苦伤害(攻击力的50%)。
	/// 仅有一次，体力值不会低于1799。触发时，转变为“刺痛流泪之心”。
	/// </summary>
    public class B_Boss_Cirno_P_1:Buff, IP_Hit, IP_Dodge, IP_TurnEnd, IP_HPChange
    {
        int PlusHit
        {
            get
            {
                return (int)(this.BChar.GetStat.atk * 0.25);
            }
        }

        int PlusHit2
        {
            get
            {
                return (int)(this.BChar.GetStat.atk * 0.5);
            }
        }

        public void Hit(SkillParticle SP, int Dmg, bool Cri)
        {
            this.Counter(SP);
        }

        public void Dodge(BattleChar Char, SkillParticle SP)
        {
            if (Char == this.BChar)
            {
                this.Counter(SP);
            }
        }

        public void Counter(SkillParticle SP)
        {
            if (!SP.SkillData.PlusHit && SP.SkillData.CounterEnable && !SP.UseStatus.NullCheck())
            {
                CastingSkill castingSkill = new CastingSkill();
                castingSkill.skill = Skill.TempSkill("S_Boss_Cirno_P1_3", this.BChar, this.BChar.MyTeam);
                castingSkill.Target = SP.UseStatus;
                castingSkill.Usestate = this.BChar;
                castingSkill.skill.PlusHit = true;
                BattleSystem.DelayInput(BattleSystem.instance.EnemyCounterAttack(castingSkill));
            }
        }
        
        public IEnumerator Wait()
        {
            yield return new WaitForSeconds(0.5f);
            yield break;
        }

        public void TurnEnd()
        {
            foreach (BattleAlly ba in BattleSystem.instance.AllyList)
            {
                ba.Damage(this.BChar, PlusHit2, false, true);
            }
        }

        public void HPChange(BattleChar Char, bool Healed)
        {
            if (BattleEvent_CirnoBlizzard.MainP.Phase == 1 && this.BChar.HP <= this.BChar.GetStat.maxhp * 0.9)
            {
                this.BChar.Info.Hp = (int)(this.BChar.GetStat.maxhp * 0.9);
                BattleEvent_CirnoBlizzard.MainP.Phase = 2;

                this.SelfDestroy();
                this.BChar.BuffAdd("B_Boss_Cirno_P_2", this.BChar);

                (this.BChar as BattleEnemy).ChangeSprite(this.getSprite("CirnoBlizzard2"));
            }
        }

        public Sprite createSpriteWithPivot(Sprite Feiyap, Vector2 pivot)
        {
            return UnityEngine.Sprite.Create(Feiyap.texture, Feiyap.rect, pivot);
        }
        
        public Sprite getSprite(string spriteName)
        {
            string text = spriteName + ".png";
            Debug.Log(text);
            string text2 = ModManager.getModInfo("CirnoBlizzard").assetInfo.ImageFromFile(text);
            Debug.Log(text2);
            Sprite sprite = AddressableLoadManager.LoadAsyncCompletion<Sprite>(text2, 0);
            Vector2 pivot = new Vector2(0.45f, -0.02f);
            return this.createSpriteWithPivot(sprite, pivot);
        }

        public override string DescExtended()
        {
            return base.DescExtended().Replace("&a", (PlusHit).ToString())
                                      .Replace("&b", (PlusHit2).ToString())
                                      .Replace("&c", ((int)(this.BChar.GetStat.maxhp * 0.9)).ToString());
        }
    }
}