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
namespace Suwako
{
	/// <summary>
	/// 风雨已至
	/// </summary>
    public class B_Suwako_Dot:Buff, IP_OnSkillAddToDeck, IP_SkillUseHand_Team
    {
        public int count;

        public override void Init()
        {
            base.Init();
            this.OnePassive = true;
        }

        public IEnumerator OnSkillAddToDeck(Dictionary<Skill, SkillLocation> AddToDeck_Skills)
        {
            yield return null;

            count++;
            this.PlusDamageTick = count * 2;

            if (Usestate_F.BuffFind("B_Suwako_Rare2"))
            {
                BattleSystem.DelayInput(this.Damage());
            }

            yield return null;
            yield break;
        }

        public void SKillUseHand_Team(Skill skill)
        {
            if ((!skill.NotCount && skill.AP <= 1) || skill.AP <= 0)
            {
                count++;
                this.PlusDamageTick = count * 2;

                if (Usestate_F.BuffFind("B_Suwako_Rare2"))
                {
                    BattleSystem.DelayInput(this.Damage());
                }
            }
        }

        public IEnumerator Damage()
        {
            yield return new WaitForSeconds(0.07f);
            AddressableLoadManager.Instantiate(new GDEGameobjectDatasData(GDEItemKeys.GameobjectDatas_StigmaExplosion).Gameobject_Path, AddressableLoadManager.ManageType.Character).transform.position = this.BChar.GetTopPos();
            this.BChar.Damage(base.Usestate_F, (int)((base.Usestate_F.GetStat.atk * 0.2 + count * 2) * this.StackNum / 2), false, true);
            yield break;
        }
    }
}