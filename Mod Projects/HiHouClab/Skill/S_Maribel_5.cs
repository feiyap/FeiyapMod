using BasicMethods;
using ChronoArkMod;
using ChronoArkMod.Plugin;
using ChronoArkMod.Template;
using DarkTonic.MasterAudio;
using GameDataEditor;
using I2.Loc;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;
using Debug = UnityEngine.Debug;
namespace HiHouClab
{
	/// <summary>
	/// 阿加尔塔之风
	/// 这个技能不会因为回合结束而被释放。
	/// 倒计时期间，目标受到的量子伤害降低为0。
	/// </summary>
    public class S_Maribel_5:Skill_Extended, IP_SkillCastingStart, IP_SkillCastingQuit, IP_DamageTakeChange_Quantum
    {
        public bool isFlag = false;
        public List<BattleChar> tempList;

        public override void Init()
        {
            base.Init();
            this.CountingExtedned = true;
            isFlag = false;
        }
        public int DamageTakeChange_Quantum(BattleChar Hit, BattleChar User, int Dmg, bool Cri, bool NODEF = false, bool NOEFFECT = false, bool Preview = false)
        {
            if (isFlag && tempList.Contains(Hit))
            {
                Dmg = 0;
            }
            return Dmg;
        }

        public void SkillCasting(CastingSkill ThisSkill)
        {
            isFlag = true;
            tempList = ThisSkill.TargetReturn();
            CustomMethods.CountingSkillNotUseTurnEnd(ThisSkill);
        }

        public void SkillCastingQuit(CastingSkill ThisSkill)
        {
            isFlag = false;
            tempList = null;
        }
    }
}