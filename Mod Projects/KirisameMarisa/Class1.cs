using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using ChronoArkMod;
using ChronoArkMod.Plugin;
using ChronoArkMod.Template;
using HarmonyLib;

namespace KirisameMarisa
{
    //切换区域后重新施加区域BUFF
    [HarmonyPatch(typeof(FieldSystem))]
    [HarmonyPatch("NextStage")]
    public static class NextStage_Plugin
    {
        public static List<string> BuffIDList = new List<string>
        {
            "B_KirisameMarisa_DangerTrigger"
        };

        public static List<Buff> buffList = new List<Buff> { };

        [HarmonyPrefix]
        public static void NextStage_Prefix(FieldSystem __instance)
        {
            buffList.Clear();
            foreach (Character character in PlayData.TSavedata.Party)
            {
                foreach (Buff buff in character.Buffs_Field)
                {
                    if (BuffIDList.Exists(t => t == buff.BuffData.Key))
                    {
                        buffList.Add(buff);
                    }
                }
            }
        }

        [HarmonyPostfix]
        public static void NextStage_Postfix(FieldSystem __instance)
        {
            foreach (Character character in PlayData.TSavedata.Party)
            {
                foreach (Buff buff in buffList)
                {
                    character.Buff_FieldAdd(buff.BuffData.Key);
                }
            }
        }
    }
}
