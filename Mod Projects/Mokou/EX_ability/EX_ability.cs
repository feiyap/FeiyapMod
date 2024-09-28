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
namespace Mokou
{
    public class EX_ability : Skill_Extended
    {
        public static bool CheckEXburn(int burn, BattleChar user)
        {
            if (user.BuffFind("B_Mokou_T_1", false) == true)
            {
                if (user.BuffReturn("B_Mokou_T_1", false).StackNum >= burn)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        public static void UseEXburn(int burn, BattleChar user)
        {
            for (int i = 0; i < burn; i++)
            {
                if (user.BuffFind("B_Mokou_T_1", false) == true)
                {
                    user.BuffReturn("B_Mokou_T_1", false).SelfStackDestroy();
                    user.Damage(user, 3 * (int)Misc.PerToNum((float)user.GetStat.atk, 15f), false, true, true, 0, false, false, false);
                }
            }
        }
        public static void MokouRebirth(BattleChar user ,bool SoundOn = true)
        {
            if (SoundOn)
            {
                string text = "MokouRebirth";
                text += UnityEngine.Random.Range(1, 6).ToString();
                MasterAudio.PlaySound(text, 1f, null, 0f, null, null, false, false);
            }
            user.BuffAdd("B_Mokou_0", user, false, 0, false, -1, false);
            user.Recovery = user.Info.get_stat.maxhp;
            user.HP = 1;
            user.Heal(user, (float)user.Info.get_stat.maxhp, true, true, null);
            for (int i = 0; i < user.Buffs.Count; i++)
            {
                if (user.Buffs[i].BuffData.Debuff && !user.Buffs[i].CantDisable)
                {
                    user.Buffs[i].SelfDestroy(false);
                }
            }
        }
        public static bool ChackConundrum(BattleChar user)
        {
            int Kaguya_Achieve = 0;
            int Kaguya_Fail = 0;
            if (user.BuffFind("B_Kaguya_Achieve"))
            {
                Kaguya_Achieve = user.BuffReturn("B_Kaguya_Achieve", false).StackNum;
            }
            else
            {
                Kaguya_Achieve = 0;
            }
            if (user.BuffFind("B_Kaguya_Fail"))
            {
                Kaguya_Fail = user.BuffReturn("B_Kaguya_Fail", false).StackNum;
            }
            else
            {
                Kaguya_Fail = 0;
            }
            if (Kaguya_Achieve > Kaguya_Fail)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}