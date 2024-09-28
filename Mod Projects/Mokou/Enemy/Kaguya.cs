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
	/// <summary>
	/// 蓬莱山辉夜
	/// </summary>
    public class Kaguya:AI
    {
        public override Skill SkillSelect(int ActionCount)
        {
            if (this.BChar.BuffFind("B_Kaguya_P_1",false))
            {
                Phase = this.BChar.BuffReturn("B_Kaguya_P_1", false).StackNum;
            }
            if (this.BChar.BuffFind("B_Kaguya_Lunatic", false))
            {
                Lunatic = true;
            }
            switch (Phase)
            {
                case 1:
                    switch (ActionCount)
                    {
                        case 0:
                            if (Normal == 0)
                            {
                                Debug.Log("第1次行动:1符，从右扫到左");
                                return this.BChar.Skills[0];
                            }
                            else
                            {
                                Debug.Log("第1次行动:1符，从左扫到右");
                                return this.BChar.Skills[1];
                            }
                        case 1:
                            if (Lunatic)
                            {
                                if (Normal == 0)
                                {
                                    Debug.Log("第2次行动:1符，从左扫到右");
                                    Normal = 1;
                                    return this.BChar.Skills[1];
                                }
                                else
                                {
                                    Debug.Log("第2次行动:1符，从右扫到左");
                                    Normal = 0;
                                    return this.BChar.Skills[0];
                                }
                            }
                            else
                            {
                                Debug.Log("第2次行动:小玉弹（非L难度）");
                                Normal = 1;
                                return this.BChar.Skills[2];
                            }
                        case 2:
                            if (Lunatic)
                            {
                                Debug.Log("第3次行动:小玉弹（L难度）");
                                return this.BChar.Skills[2];
                            }
                            else
                            {
                                Debug.Log("第3次行动:无（非L难度）");
                                return null;
                            }
                        default:
                            Debug.Log("第4/5/6/7次行动:无（全难度）");
                            return null;
                    }
            }
            return null;
        }
        public B_Kaguya_P MainP
        {
            get
            {
                if (this._MainP == null)
                {
                    this._MainP = (this.BChar.BuffReturn("B_Kaguya_P", false) as B_Kaguya_P);
                }
                return this._MainP;
            }
        }
        private int Normal = 0;
        private int Phase = 1;
        private bool Lunatic = false;
        private B_Kaguya_P _MainP;
    }
}