using System.Collections;
using GameDataEditor;
using UnityEngine;

namespace BossPhoenix
{
    /// <summary>
    /// 拦路的凤凰
    /// </summary>
    public class RE_BossPhoenix : RandomEventBaseScript
    {
        public override void EventInit()
        {
            base.EventInit();
        }

        public override void EventOpen()
        {
            base.EventOpen();
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
            FieldSystem.instance.BattleAfterDelegate = new FieldSystem.BattleAfterDel(this.AfterBattle);
            FieldSystem.instance.BattleStart(new GDEEnemyQueueData(ModItemKeys.EnemyQueue_Queue_BossPhoenix), GDEItemKeys.BattleMaps_BattleMap_Park, true, false, "", "", false);
            UIManager.inst.StartCoroutine(UIManager.inst.FadeBlack_In(0.5f));
        }

        private void AfterBattle()
        {
            this.eventCleared = true;
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
            yield return new WaitForSeconds(1f);
            yield break;
        }

        private bool eventCleared;
    }
}
