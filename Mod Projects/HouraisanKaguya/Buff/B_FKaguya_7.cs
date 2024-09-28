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
namespace HouraisanKaguya
{
	/// <summary>
	/// 辉夜/月人
	/// 在濒死状态下受到伤害时，抵消这次伤害，恢复所有体力，之后获得1层[辉夜/蓬莱]。
	/// </summary>
    public class B_FKaguya_7:Buff, IP_DamageTake
    {
        public void DamageTake(BattleChar User, int Dmg, bool Cri, ref bool resist, bool NODEF = false, bool NOEFFECT = false, BattleChar Target = null)
        {
            bool flag = this.BChar.Info.Hp <= 0;
            if (flag)
            {
                resist = true;

                this.SelfDestroy();

                if (!this.BChar.BuffFind("B_FKaguya_7_0"))
                {
                    BattleSystem.DelayInputAfter(this.Del());
                }
                
                this.BChar.BuffAdd("B_FKaguya_7_0", this.BChar, false, 0, false, -1, false);
                this.BChar.Recovery = this.BChar.Info.get_stat.maxhp;
                this.BChar.HP = 1;
                this.BChar.Heal(this.BChar, (float)this.BChar.Info.get_stat.maxhp, false, true, null);
                for (int i = 0; i < this.BChar.Buffs.Count; i++)
                {
                    bool flag2 = this.BChar.Buffs[i].BuffData.Debuff && !this.BChar.Buffs[i].CantDisable;
                    if (flag2)
                    {
                        this.BChar.Buffs[i].SelfDestroy(false);
                    }
                }
            }
        }

        public IEnumerator Del()
        {
            yield return new WaitForFixedUpdate();
            yield return BattleText.InstBattleTextAlly_Co(this.BChar, ModManager.getModInfo("HouraisanKaguya").localizationInfo.SystemLocalizationUpdate("BattleDia/FKaguyaRevive/Text1"), false);
            yield return BattleText.InstBattleTextAlly_Co(this.BChar, ModManager.getModInfo("HouraisanKaguya").localizationInfo.SystemLocalizationUpdate("BattleDia/FKaguyaRevive/Text2"), false);
            yield break;
        }

        public override void Init()
        {
            base.Init();
            this.PlusStat.AggroPer = 66;
        }
    }
}