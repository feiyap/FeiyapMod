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
namespace HouraisanKaguya
{
    /// <summary>
    /// 时效「月岩笠的诅咒」
    /// 1回合1次，妹红受到伤害时，会对自己和来源施加3层[烧伤]，并且本回合内自己和来源对互相造成的伤害-50%。
    /// </summary>
    public class B_FMokou_Stage_2:Buff, IP_Hit, IP_PlayerTurn
    {
        public int count;

        public void Hit(SkillParticle SP, int Dmg, bool Cri)
        {
            bool flag = Dmg > 0;
            if (flag && SP.SkillData.Master.Info.Ally && count == 0)
            {
                this.BChar.BuffAdd("B_Mokou_T_1", this.BChar, false, 0, false, -1, false);
                this.BChar.BuffAdd("B_Mokou_T_1", this.BChar, false, 0, false, -1, false);
                this.BChar.BuffAdd("B_Mokou_T_1", this.BChar, false, 0, false, -1, false);
                SP.SkillData.Master.BuffAdd("B_Mokou_T_1", this.BChar, false, 0, false, -1, false);
                SP.SkillData.Master.BuffAdd("B_Mokou_T_1", this.BChar, false, 0, false, -1, false);
                SP.SkillData.Master.BuffAdd("B_Mokou_T_1", this.BChar, false, 0, false, -1, false);
                SP.SkillData.Master.BuffAdd("B_FMokou_Stage_2_0", this.BChar, false, 0, false, -1, false);
                count++;
            }
        }

        public void Turn()
        {
            count = 0;
        }
    }
}