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

namespace DiffcultSystem
{
    /// <summary>
    /// 坚韧不拔：敌人濒死抵抗。
    /// </summary>
    public class B_Endorphin_PersistentResist : Buff, IP_HPChange
    {
        private bool usedResist;

        public override void FixedUpdate()
        {
            base.FixedUpdate();
            // 1 点体力值时锁定 30% 闪避率
            this.PlusStat.dod = this.BChar.HP == 1 ? 30f : 0f;
        }

        public void HPChange(BattleChar Char, bool Healed)
        {
            if (Char != this.BChar || this.usedResist || Healed || Char.HP > 0)
            {
                return;
            }

            // 受到致命攻击时，30% 概率保留 1 点体力值（仅限 1 次）
            if (RandomManager.RandomPer(this.BChar.GetRandomClass().Main, 100, 30))
            {
                Char.HP = 1;
                Char.IsDead = false;
                this.usedResist = true;
                EffectView.SimpleTextout(Char.GetPos(), ScriptLocalization.UI_Battle.Endure, Localposition: true);
            }
        }
    }
}
