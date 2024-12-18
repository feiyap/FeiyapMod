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
	/// 丰收之御柱
	/// 触发时，获得 &a 防护墙<color=#00E5EE>(自身最大体力值的5%/10%/15%/20%/25%)</color>。
	/// </summary>
    public class B_Kanano_0:Buff, IP_APChanged
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

            BattleSystem.instance.AllyTeam.partybarrier.BarrierHP += (int)(this.BChar.GetStat.maxhp * 0.05 * BattleSystem.instance.GetBattleValue<BV_Kanano_P>().getYuzhuLevel(this.BChar));

            yield break;
        }

        static string str1 = "<color=#B22222>12%</color><color=#8B8989>/14%/16%/18%/20%</color>";
        static string str2 = "<color=#8B8989>12%/</color><color=#B22222>14%</color><color=#8B8989>/16%/18%/20%</color>";
        static string str3 = "<color=#8B8989>12%/14%/</color><color=#B22222>15%</color><color=#8B8989>/18%/20%</color>";
        static string str4 = "<color=#8B8989>12%/14%/16%/</color><color=#B22222>18%</color><color=#8B8989>/20%</color>";
        static string str5 = "<color=#8B8989>12%/14%/16%/18%/</color><color=#B22222>20%</color>";
        List<string> strList = new List<string> { str1, str2 ,str3 , str4 , str5};

        public override string DescExtended()
        {
            int yuzhulv = 1;
            if (BattleSystem.instance != null && BattleSystem.instance.GetBattleValue<BV_Kanano_P>() != null)
            {
                yuzhulv = BattleSystem.instance.GetBattleValue<BV_Kanano_P>().getYuzhuLevel(this.BChar);
            }

            return base.DescExtended().Replace("&a", ((int)(this.BChar.GetStat.maxhp * (0.1 + yuzhulv * 0.02))).ToString())
                                      .Replace("&b", strList[yuzhulv - 1]);
        }
    }
}