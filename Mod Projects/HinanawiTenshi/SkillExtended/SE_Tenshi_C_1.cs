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
namespace HinanawiTenshi
{
	/// <summary>
	/// 抽取到手中时，根据技能的费用，自身和比那名居天子获得相同数量的随机<color=#B22222>天</color><color=#00BFFF>气</color><color=#00FF7F>增</color><color=#FFD700>益</color>。
	/// </summary>
    public class SE_Tenshi_C_1: SkillBase_Tenshi
    {
        public override IEnumerator DrawAction()
        {
            BattleSystem.DelayInput(this.Del());
            return base.DrawAction();
        }

        public IEnumerator Del()
        {
            BattleAlly tenshi = new BattleAlly();
            bool isTenshi = false;
            foreach (BattleAlly battleAlly in BattleSystem.instance.AllyList)
            {
                if (battleAlly.Info.KeyData == "HinanawiTenshi")
                {
                    tenshi = battleAlly;
                    isTenshi = true;
                }
            }

            if (isTenshi)
            {
                AddTenki(tenshi, this.MySkill._AP);
            }

            AddTenki(this.BChar, this.MySkill._AP);

            yield break;
        }
    }
}