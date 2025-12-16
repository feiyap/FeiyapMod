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
	/// 刺痛流泪之心
	/// 每受到125伤害，生成 1 个“破碎的心”（优先抽1）。每回合最多触发 3 次。
	/// 触发 3 次后，这个增益的“攻击力+50%”会转变为“受到伤害量+20%”，持续到回合结束。
	/// 仅有一次，体力值不会低于999。触发时，转变为“爱与妖精之心”。
	/// </summary>
    public class B_Boss_Cirno_P_2:Buff, IP_DamageTake, IP_HPChange
    {
        public override void Init()
        {
            base.Init();
            this.HP = this.MAXHP;
        }
        
        public void Turn()
        {
            count = 0;
            this.HP = this.MAXHP;
        }

        public void DamageTake(BattleChar User, int Dmg, bool Cri, ref bool resist, bool NODEF = false, bool NOEFFECT = false, BattleChar Target = null)
        {
            if (count < 3)
            {
                this.HP -= Dmg;
            }
            while (this.HP <= 0)
            {
                this.HP = this.MAXHP + this.HP;
                if (count < 3)
                {
                    Skill tmpSkill = Skill.TempSkill("S_Boss_Cirno_Lucy_0", BattleSystem.instance.AllyTeam.LucyChar, BattleSystem.instance.AllyTeam);
                    BattleSystem.instance.AllyTeam.Add(tmpSkill, true);
                    count++;
                }
            }
        }

        public override void FixedUpdate()
        {
            base.FixedUpdate();
            BattleEvent_CirnoBlizzard.Boss.MasterBossSmallHPBar.gameObject.SetActive(true);
            BattleEvent_CirnoBlizzard.Boss.MasterBossSmallHPBar.MainBar.fillAmount = Misc.NumToPer((float)this.MAXHP, (float)this.HP) * 0.01f;
        }

        public override string DescExtended()
        {
            return base.DescExtended().Replace("&a", this.HP.ToString())
                                      .Replace("&c", ((int)(this.BChar.GetStat.maxhp * 0.5)).ToString()); ;
        }

        public void HPChange(BattleChar Char, bool Healed)
        {
            if (BattleEvent_CirnoBlizzard.MainP.Phase == 1 && this.BChar.HP <= this.BChar.GetStat.maxhp * 0.5)
            {
                this.BChar.Info.Hp = (int)(this.BChar.GetStat.maxhp * 0.5);
                BattleEvent_CirnoBlizzard.MainP.Phase = 3;
                BattleEvent_CirnoBlizzard.Boss.MasterBossSmallHPBar.gameObject.SetActive(false);

                this.SelfDestroy();
                this.BChar.BuffAdd("B_Boss_Cirno_P_3", this.BChar);
                this.BChar.BuffAdd("B_Boss_Cirno_P_3_1", this.BChar);

                (this.BChar as BattleEnemy).ChangeSprite(this.getSprite("CirnoBlizzard3"));
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

        public int HP;
        public int MAXHP = 125;
        public int count = 0;
    }
}