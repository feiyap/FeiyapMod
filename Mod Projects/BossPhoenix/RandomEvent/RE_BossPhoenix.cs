using System.Collections;
using GameDataEditor;
using UnityEngine;

namespace BossPhoenix
{
    /// <summary>
    /// 拦路的凤凰
    /// 进入战斗后视作替换关底 Boss，不再与原关底交战。
    /// </summary>
    public class RE_BossPhoenix : RandomEventBaseScript
    {
        public override void EventInit()
        {
            base.EventInit();
            this.CacheStageBoss();
        }

        public override void EventOpen()
        {
            base.EventOpen();
            this.CacheStageBoss();
            if (this.eventCleared)
            {
                base.ChangeDesc(this.MyUI.MainEventData.OrderStrings[0], true);
                return;
            }
            base.ChangeDesc(this.MyUI.MainEventData.EventDetails, false);
        }

        public override void UseButton1()
        {
            UIManager.inst.StartCoroutine(this.Co_OnlyEvent());
        }

        public override void UseButton2()
        {
            base.UseButton2();
        }

        private IEnumerator Co_OnlyEvent()
        {
            yield return new WaitForSeconds(1f);
            this.BattleStart();
            yield break;
        }

        private void BattleStart()
        {
            base.ChangeDesc(this.MyUI.MainEventData.OrderStrings[0], true);
            this.ReplaceStageBoss();
            FieldSystem.instance.BattleAfterDelegate = new FieldSystem.BattleAfterDel(this.AfterBattle);
            FieldSystem.instance.BattleStart(new GDEEnemyQueueData(ModItemKeys.EnemyQueue_Queue_BossPhoenix), GDEItemKeys.BattleMaps_BattleMap_Park, true, false, "", "", false);
            UIManager.inst.StartCoroutine(UIManager.inst.FadeBlack_In(0.5f));
        }

        private void AfterBattle()
        {
            this.eventCleared = true;
            this.ReplaceStageBoss();
            base.EventDisable();
            FieldSystem.DelayInput(this.Co_AfterBattle());
        }

        private IEnumerator Co_AfterBattle()
        {
            this.MyUI.Delete();
            while (GameObject.FindGameObjectWithTag("BattleStop"))
            {
                yield return null;
            }
            this.ReplaceStageBoss();
            yield return new WaitForSeconds(1f);
            yield break;
        }

        private void CacheStageBoss()
        {
            if (this.miniBoss == null)
            {
                this.miniBoss = UnityEngine.Object.FindObjectOfType<MiniBossObject>();
            }
            if (this.stage1 == null)
            {
                this.stage1 = UnityEngine.Object.FindObjectOfType<Stage1Events>();
            }
        }

        /// <summary>
        /// 标记原关底已清除，地图不再生成原关底战斗。
        /// </summary>
        private void ReplaceStageBoss()
        {
            this.CacheStageBoss();
            if (this.miniBoss != null)
            {
                this.miniBoss.BossClear = true;
                return;
            }
            if (this.stage1 != null)
            {
                this.stage1.BossClear = true;
            }
        }

        private MiniBossObject miniBoss;
        private Stage1Events stage1;
        private bool eventCleared;
    }
}
