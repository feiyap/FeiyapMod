using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BossPhoenix
{
    /// <summary>
    /// 猜谜游戏
    /// 打开挡住下层的猜谜界面，用正则搜索技能并对照属性。
    /// </summary>
    public class S_BossPhoenix_0 : Skill_Extended
    {
        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            base.SkillUseSingle(SkillD, Targets);
            BattleSystem.DelayInput(this.Co_Riddle());
        }

        private IEnumerator Co_Riddle()
        {
            B_BossPhoenix_P state = B_BossPhoenix_P.Get(this.BChar);
            if (state == null)
            {
                yield break;
            }

            state.ResetRiddle();
            state.EnsureImagined();

            RiddleUI.Open(state, this.BChar);
            while (RiddleUI.IsOpen)
            {
                yield return null;
            }

            if (RiddleUI.LastResult == RiddleUI.Result.Won)
            {
                string rewardKey = state.RewardKeyForGuess();
                PhoenixSkillUtil.GiveSkillToOwner(rewardKey);
                yield return BattleText.InstBattleText_Co(this.BChar, PhoenixLoc.RiddleCorrect, true, 0, 0f);
                state.ResetRiddle();
                yield break;
            }

            if (state.LostRiddleCount < PhoenixSkillUtil.MaxRiddleLoss)
            {
                yield return BattleText.InstBattleText_Co(this.BChar, string.Format(PhoenixLoc.Loc("Riddle/RoundLost"), state.LostRiddleCount, PhoenixSkillUtil.MaxRiddleLoss), true, 0, 0f);
                state.ResetRiddle();
                yield break;
            }

            yield break;
        }
    }
}
