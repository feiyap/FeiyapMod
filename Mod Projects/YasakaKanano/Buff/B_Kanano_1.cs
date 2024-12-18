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
namespace YasakaKanano
{
	/// <summary>
	/// 风雷之御柱
	/// 触发时，对随机敌人造成 &a 伤害<color=#FF7A33>(攻击力的60%/70%/80%/90%/100%)</color>。
	/// </summary>
    public class B_Kanano_1:Buff, IP_APChanged
    {
        public override void Init()
        {
            base.Init();
            this.OnePassive = true;
        }

        public void APChanged(int OldValue, int NewValue, bool NewTurnRecover)
        {
            if (!NewTurnRecover && NewValue > OldValue)
            {
                int num = NewValue - OldValue;
                for (int i = 0; i < num; i++)
                {
                    BattleSystem.DelayInput(this.Del());
                }
            }
        }

        private IEnumerator Del()
        {
            yield return new WaitForSeconds(0.1f);

            Skill skill = Skill.TempSkill("S_Kanano_1_1", this.BChar, this.BChar.MyTeam);
            skill.MySkill.Effect_Target.DMG_Per = 20 + BattleSystem.instance.GetBattleValue<BV_Kanano_P>().getYuzhuLevel(this.BChar) * 10;
            skill.isExcept = true;
            skill.FreeUse = true;
            skill.PlusHit = true;
            skill.NoAttackTimeWait = true;
            this.BChar.ParticleOut(skill, BattleSystem.instance.EnemyTeam.AliveChars.Random(this.BChar.GetRandomClass().Main));

            yield break;
        }

        static string str1 = "<color=#B22222>30%</color><color=#8B8989>/40%/50%/60%/70%</color>";
        static string str2 = "<color=#8B8989>30%/</color><color=#B22222>40%</color><color=#8B8989>/50%/60%/70%</color>";
        static string str3 = "<color=#8B8989>30%/40%/</color><color=#B22222>80%</color><color=#8B8989>/60%/70%</color>";
        static string str4 = "<color=#8B8989>30%/40%/50%/</color><color=#B22222>60%</color><color=#8B8989>/70%</color>";
        static string str5 = "<color=#8B8989>30%/40%/50%/60%/</color><color=#B22222>70%</color>";
        List<string> strList = new List<string> { str1, str2, str3, str4, str5 };

        public override string DescExtended()
        {
            int yuzhulv = 1;
            if (BattleSystem.instance != null && BattleSystem.instance.GetBattleValue<BV_Kanano_P>() != null)
            {
                yuzhulv = BattleSystem.instance.GetBattleValue<BV_Kanano_P>().getYuzhuLevel(this.BChar);
            }
            return base.DescExtended().Replace("&a", ((int)(this.BChar.GetStat.atk * (0.3 + yuzhulv * 0.1))).ToString())
                                      .Replace("&b", strList[yuzhulv - 1]);
        }
    }
}