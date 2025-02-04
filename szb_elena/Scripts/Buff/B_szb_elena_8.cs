using BasicMethods;

namespace szb_elena
{
    /// <summary>
    /// 洁净领域
    /// 当自己回复生命值时，如果该回复为自己本回合中的第1次，则会对随机敌人造成&a伤害(攻击力的100%)；
    /// 如果为第2次，则会将1个0费的“圣炎猛虎”加入手中；
    /// 如果为第3次，则会使随机1个队友无敌1回合。
    /// </summary>
    public class B_szb_elena_8 : Buff, IP_ElenaHealed
    {
        public override string DescExtended()
        {
            return base.DescExtended().Replace("&a", ((int)(base.Usestate_F.GetStat.atk * 1f)).ToString());
        }
        public override void Init()
        {
            base.Init();
            ////this.OnePassive = true;
            //if (BattleSystem.instance != null && HandSkillNumChange.ChangeNum > -base.StackNum)
            //{  for (int i = 0; i < 10; i++)
            //    {
            //        BasicMethods.HandSkillNumChange.ChangeNum -= 1;
            //        if (HandSkillNumChange.ChangeNum <= -base.StackNum)
            //        {
            //           return;
            //        }
            //    }
            //}
        }
        //public void BattleEnd()
        //{
        //    BasicMethods.HandSkillNumChange.ChangeNum = 0;

        //}

        //public void BuffUpdate(Buff MyBuff)
        //{
        //    if (BattleSystem.instance != null)
        //    {
        //        BasicMethods.HandSkillNumChange.ChangeNum = -base.StackNum;
        //    }
        //}
        //public override void SelfdestroyPlus()
        //{
        //    base.SelfdestroyPlus();
        //    BasicMethods.HandSkillNumChange.ChangeNum = 0;
        //}
            public void ElenaHealed()
        {
            if (P_szb_elena.TurnHealedNum == 1)
            {   for (int i = 0; i < base.StackNum; i++)
                {
                    BattleSystem.instance.EnemyTeam.AliveChars.Random(this.BChar.GetRandomClass().Main).Damage(this.BChar, (int)(this.BChar.GetStat.atk * 1), false, false, false, 0, false, false, false);
                }
            }
            else if (P_szb_elena.TurnHealedNum == 2)
            {
                for (int i = 0; i < base.StackNum; i++)
                {
                    Skill skill = Skill.TempSkill(ModItemKeys.Skill_S_szb_elena_8_0, this.BChar, this.BChar.MyTeam);
                    skill.NotCount = true;
                    skill.isExcept = true;
                    this.BChar.MyTeam.Add(skill.CloneSkill(false, null, null, false), true);
                }

            }
            else if (P_szb_elena.TurnHealedNum == 3)
            {
                for (int i = 0; i < base.StackNum; i++)
                {
                    BattleSystem.instance.AllyTeam.AliveChars.Random(this.BChar.GetRandomClass().Main).BuffAdd(ModItemKeys.Buff_B_szb_elena_8_0, this.BChar, false, 0, false, -1, false);
                }

            }

        }
    }
}