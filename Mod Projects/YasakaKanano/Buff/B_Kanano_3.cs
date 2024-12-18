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
	/// 狂热之御柱
	/// 每触发 &a 次时，抽取1个技能<color=#FF7A33>(4/4/3/3/2)</color>。
	/// </summary>
    public class B_Kanano_3:Buff, IP_APChanged
    {
        public int count = 0;

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

            count++;
            if (count >= strList2[BattleSystem.instance.GetBattleValue<BV_Kanano_P>().getYuzhuLevel(this.BChar) - 1])
            {
                count = 0;
                BattleSystem.instance.AllyTeam.Draw();
            }

            yield break;
        }

        static string str1 = "<color=#B22222>4</color><color=#8B8989>/4/3/3/2</color>";
        static string str2 = "<color=#8B8989>4/</color><color=#B22222>4</color><color=#8B8989>/3/3/2</color>";
        static string str3 = "<color=#8B8989>4/4/</color><color=#B22222>3</color><color=#8B8989>/3/2</color>";
        static string str4 = "<color=#8B8989>4/4/3/</color><color=#B22222>3</color><color=#8B8989>/2</color>";
        static string str5 = "<color=#8B8989>4/4/3/3/</color><color=#B22222>2</color>";
        List<string> strList = new List<string> { str1, str2, str3, str4, str5 };
        List<int> strList2 = new List<int> { 4, 4, 3, 3, 2 };

        public override string DescExtended()
        {
            int yuzhulv = 1;
            if (BattleSystem.instance != null && BattleSystem.instance.GetBattleValue<BV_Kanano_P>() != null)
            {
                yuzhulv = BattleSystem.instance.GetBattleValue<BV_Kanano_P>().getYuzhuLevel(this.BChar);
            }
            return base.DescExtended().Replace("&a", strList2[yuzhulv - 1].ToString())
                                      .Replace("&b", strList[yuzhulv - 1])
                                      .Replace("&c", count.ToString());
        }
    }
}