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
namespace Reisen
{
	/// <summary>
	/// 国士无双
	/// 叠加4层后对自己和所有敌人造成100%最大体力值的伤害。
	/// </summary>
    public class B_Reisen_12Rare:Buff
    {
        public override void Init()
        {
            base.Init();
            this.PlusStat.atk = 2 * StackNum;
            this.PlusStat.def = 5 * StackNum;
            if (this.StackNum == 4)
            {
                AddressableLoadManager.Instantiate(new GDESkillData("S_Reisen_12Rare_0").Particle_Path, AddressableLoadManager.ManageType.Character).transform.position = this.BChar.GetTopPos();

                for (int i = 0; i < BattleSystem.instance.EnemyTeam.AliveChars.Count; i++)
                {
                    BattleSystem.instance.EnemyTeam.AliveChars[i].Damage(this.BChar, (int)(BattleSystem.instance.EnemyTeam.AliveChars[i].GetStat.maxhp * 1.0f), false);
                }
                this.BChar.Damage(this.BChar, (int)(this.BChar.GetStat.maxhp * 1.0f), false);

                this.SelfDestroy();
            }
        }
    }
}