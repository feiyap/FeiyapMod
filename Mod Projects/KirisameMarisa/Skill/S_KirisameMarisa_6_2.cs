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
namespace KirisameMarisa
{
	/// <summary>
	/// 星符「Eccentric Asteroid」
	/// <color=#00BFFF>危险等级2</color> - 额外施加一层[危险信号]。
	/// </summary>
    public class S_KirisameMarisa_6_2: SkillBase_KirisameMarisa
    {
        public override void SkillKill(SkillParticle SP)
        {
            base.SkillKill(SP);

            BattleSystem.DelayInput(this.Effect());
        }

        public IEnumerator Effect()
        {
            yield return new WaitForSeconds(0.15f);

            BattleSystem.instance.EnemyTeam.AliveChars.Random(this.BChar.GetRandomClass().Main).BuffAdd("B_KirisameMarisa_6", this.BChar);

            yield return new WaitForSeconds(0.1f);

            yield break;
        }
    }
}