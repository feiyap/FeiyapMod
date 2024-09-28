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
namespace saber
{
    public static class Ex_Saber_jiefang
    {

        public static void Usemoli(int num, BattleChar user)
        {
            for (int i = 0; i < num; i++)
            {
                bool flag = user.BuffFind("Saber_moli", false);
                if (flag)
                {
                    Buff buff = user.BuffReturn("Saber_moli", false);
                    if (buff != null)
                    {
                        buff.SelfStackDestroy();
                    }
                }
            }
        }
        public static bool Checkmoli(int num, BattleChar user)
        {
            bool flag = user.BuffFind("Saber_moli", false);
            bool result;
            if (flag)
            {
                bool flag2 = user.BuffReturn("Saber_moli", false).StackNum >= num;
                result = flag2;
            }
            else
            {
                result = false;
            }
            return result;
        }
        public static bool Checklingdao(int num, BattleChar user)
        {
            bool flag = user.BuffFind("Saber_lingdao_B", false);
            bool result;
            if (flag)
            {
                bool flag2 = user.BuffReturn("Saber_lingdao_B", false).StackNum >= num;
                result = flag2;
            }
            else
            {
                result = false;
            }
            return result;
        }
        public static void Uselingdao(int num, BattleChar user)
        {
            for (int i = 0; i < num; i++)
            {
                bool flag = user.BuffFind("Saber_lingdao_B", false);
                if (flag)
                {
                    Buff buff = user.BuffReturn("Saber_lingdao_B", false);
                    if (buff != null)
                    {
                        buff.SelfStackDestroy();
                    }
                }
            }
        }
        public static bool Checkjianshi(int num, BattleChar user)
        {
            bool flag = user.BuffFind("Saber_jianshi", false);
            bool result;
            if (flag)
            {
                bool flag2 = user.BuffReturn("Saber_jianshi", false).StackNum >= num;
                result = flag2;
            }
            else
            {
                result = false;
            }
            return result;
        }
        public static void Usejianshi(int num, BattleChar user)
        {
            for (int i = 0; i < num; i++)
            {
                bool flag = user.BuffFind("Saber_jianshi", false);
                if (flag)
                {
                    Buff buff = user.BuffReturn("Saber_jianshi", false);
                    if (buff != null)
                    {
                        buff.SelfStackDestroy();
                    }
                }
            }
        }
        public static bool Checkjiejie(int num, BattleChar user)
        {
            bool flag = user.BuffFind("Saber_jiejie_B", false);
            bool result;
            if (flag)
            {
                bool flag2 = user.BuffReturn("Saber_jiejie_B", false).StackNum >= num;
                result = flag2;
            }
            else
            {
                result = false;
            }
            return result;
        }
        public static bool Checkjiejie1(int num, BattleChar user)
        {
            bool flag = user.BuffFind("Saber_jiejie_A", false);
            bool result;
            if (flag)
            {
                bool flag2 = user.BuffReturn("Saber_jiejie_A", false).StackNum >= num;
                result = flag2;
            }
            else
            {
                result = false;
            }
            return result;
        }
        public static bool Checkfengshi(int num, BattleChar user)
        {
            bool flag = user.BuffFind("Saber_fengshi", false);
            bool result;
            if (flag)
            {
                bool flag2 = user.BuffReturn("Saber_fengshi", false).StackNum >= num;
                result = flag2;
            }
            else
            {
                result = false;
            }
            return result;
        }
        public static bool Checkzuocheng(int num, BattleChar user)
        {
            bool flag = user.BuffFind("Saber_yingxiong_B", false);
            bool result;
            if (flag)
            {
                bool flag2 = user.BuffReturn("Saber_yingxiong_B", false).StackNum >= num;
                result = flag2;
            }
            else
            {
                result = false;
            }
            return result;
        }
        public static bool CheckSaber(int num, BattleChar Target)
        {
            bool flag = Target.BuffFind("SaberBuff", false);
            bool result;
            if (flag)
            {
                bool flag2 = Target.BuffReturn("SaberBuff", false).StackNum >= num;
                result = flag2;
            }
            else
            {
                result = false;
            }
            return result;
        }
        public static bool Checkxunli(int num, BattleChar user)
        {
            bool flag = user.BuffFind("Saber_xunli", false);
            bool result;
            if (flag)
            {
                bool flag2 = user.BuffReturn("Saber_xunli", false).StackNum >= num;
                result = flag2;
            }
            else
            {
                result = false;
            }
            return result;
        }
        public static void Usexunli(int num, BattleChar user)
        {
            for (int i = 0; i < num; i++)
            {
                bool flag = user.BuffFind("Saber_xunli", false);
                if (flag)
                {
                    Buff buff = user.BuffReturn("Saber_xunli", false);
                    if (buff != null)
                    {
                        buff.SelfStackDestroy();
                    }
                }
            }
        }
        public static void Usezuocheng(int num, BattleChar user)
        {
            for (int i = 0; i < num; i++)
            {
                bool flag = user.BuffFind("Saber_yingxiong_B", false);
                if (flag)
                {
                    Buff buff = user.BuffReturn("Saber_yingxiong_B", false);
                    if (buff != null)
                    {
                        buff.SelfStackDestroy();
                    }
                }
            }
        }
        public static bool Checkmoli0(int num, BattleChar user)
        {
            bool flag = user.BuffFind("Saber_moli", false);
            bool result;
            if (flag)
            {               
                result = false;
            }
            else
            {
               result = true;
            }
            return result;
        }
        public static void Usejinsheng(int num, BattleChar user)
        {
            for (int i = 0; i < num; i++)
            {
                bool flag = user.BuffFind("Saber_jinsheng", false);
                if (flag)
                {
                    Buff buff = user.BuffReturn("Saber_jinsheng", false);
                    if (buff != null)
                    {
                        buff.SelfStackDestroy();
                    }
                }
            }
        }
        public static bool Checkjinsheng(int num, BattleChar user)
        {
            bool flag = user.BuffFind("Saber_jinsheng", false);
            bool result;
            if (flag)
            {
                bool flag2 = user.BuffReturn("Saber_jinsheng", false).StackNum >= num;
                result = flag2;
            }
            else
            {
                result = false;
            }
            return result;
        }
        public static List<T> GetAll_IP_InBattle<T>() where T : class
        {
            List<T> list = new List<T>();
            bool flag = BattleSystem.instance == null;
            List<T> result;
            if (flag)
            {
                result = list;
            }
            else
            {
                List<T> collection = BattleSystem.instance.IReturn<T>();
                List<Skill> list2 = new List<Skill>();
                List<Skill> list3 = list2;
                BattleTeam allyTeam = BattleSystem.instance.AllyTeam;
                list3.AddRange((allyTeam != null) ? allyTeam.Skills_Deck : null);
                List<Skill> list4 = list2;
                BattleTeam allyTeam2 = BattleSystem.instance.AllyTeam;
                list4.AddRange((allyTeam2 != null) ? allyTeam2.Skills_UsedDeck : null);
                for (int i = 0; i < list2.Count; i++)
                {
                    Skill skill = list2[i];
                    bool flag2 = skill == null || skill.AllExtendeds == null;
                    if (!flag2)
                    {
                        for (int j = 0; j < skill.AllExtendeds.Count; j++)
                        {
                            T t = skill.AllExtendeds[j] as T;
                            bool flag3 = t != null;
                            if (flag3)
                            {
                                list.Add(t);
                            }
                        }
                    }
                }
                list.AddRange(collection);
                result = list.Distinct<T>().ToList<T>();
            }
            return result;
        }
    }
    
}
  