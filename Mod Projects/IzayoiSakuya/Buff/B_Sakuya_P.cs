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
namespace IzayoiSakuya
{
	/// <summary>
	/// 月时计
	/// 无法行动。
	/// </summary>
    public class B_Sakuya_P:Buff, IP_Discard
    {
        public override string DescExtended()
        {
            if (!this.View && this.BChar != null && this.BChar.Info.Ally)
            {
                return base.DescExtended() + "\n" + string.Format(ScriptLocalization.UI_Battle_Buff.RestBuffDesc, this.BChar.Info.Name);
            }
            return base.DescExtended();
        }

        // Token: 0x060013C1 RID: 5057 RVA: 0x00099CCA File Offset: 0x00097ECA
        public override void TurnUpdate()
        {
            if (!this.BChar.Info.Ally)
            {
                this.Destr();
                return;
            }
            if (!this.flag)
            {
                this.flag = true;
                return;
            }
            this.Destr();
        }

        // Token: 0x060013C2 RID: 5058 RVA: 0x00099CFC File Offset: 0x00097EFC
        public void Destr()
        {
            base.SelfDestroy(false);
            this.BChar.BuffAdd(GDEItemKeys.Buff_B_Common_CCRsis, this.BChar, false, 0, false, -1, false);
            this.BChar.BuffAdd(GDEItemKeys.Buff_B_Common_CCRsis, this.BChar, false, 0, false, -1, false);
            this.BChar.BuffAdd(GDEItemKeys.Buff_B_Common_CCRsis, this.BChar, false, 0, false, -1, false);
        }

        // Token: 0x060013C3 RID: 5059 RVA: 0x00099DB8 File Offset: 0x00097FB8
        public override void Init()
        {
            this.PlusStat.Stun = true;
            this.NoShowTimeNum_Tooltip = true;
        }

        // Token: 0x060013C4 RID: 5060 RVA: 0x00099DCD File Offset: 0x00097FCD
        public void Discard(bool Click, Skill skill, bool HandFullWaste)
        {
            if (skill.Master == this.BChar)
            {
                this.Destr();
            }
        }

        // Token: 0x04000DFA RID: 3578
        public bool flag;
    }
}