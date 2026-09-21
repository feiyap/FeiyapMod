namespace BossPhoenix
{
    /// <summary>
    /// 凤凰猜对赠牌：费用变为 0，打出后放逐。
    /// </summary>
    public class SE_PhoenixGift : Skill_Extended
    {
        public override void Init()
        {
            base.Init();
            this.APChange = -99;
            if (this.MySkill != null)
            {
                this.MySkill.isExcept = true;
            }
        }
    }
}
