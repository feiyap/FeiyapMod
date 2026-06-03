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
namespace FeiyapTank
{
	/// <summary>
	/// 追寻乐趣者的噩梦
	/// 眼前的景色飞速变换着，从森林，从大海，从宇宙，从沉眠者的梦——
	/// 吞噬掉目所能及的所有的一切的乐趣之后，仍旧不知满足。
	/// 于是，追寻乐趣者其自身成为了永恒的梦魇。
	/// 而你，将成为她的下一份养料。
	/// Button
	/// 与其一战！
	/// ButtonToolTip
	/// 迎战事件Boss“嬉笑魔女”。
	/// </summary>
    public class RE_FeiyapMage_0:RandomEventBaseScript
    {
        public override void EventInit()
        {
            base.EventInit();
            this.m = UnityEngine.Object.FindObjectOfType<MiniBossObject>();
            this.s = UnityEngine.Object.FindObjectOfType<Stage1Events>();
        }

        public override void EventOpen()
        {
            base.EventOpen();


            if (this.m == null)
            {
                this.m = UnityEngine.Object.FindObjectOfType<MiniBossObject>();
            }
            if (this.s == null)
            {
                this.s = UnityEngine.Object.FindObjectOfType<Stage1Events>();
            }
            if (this.m?.BossClear ?? false)
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
            FieldSystem.instance.BattleStart(new GDEEnemyQueueData("Queue_Boss_FeiyapMage"), StageSystem.instance.StageData.BattleMap.Key, true, false, "", "", false);
            UIManager.inst.StartCoroutine(UIManager.inst.FadeBlack_In(0.5f));
        }

        private void AfterBattle()
        {
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
            bool flag = this.m != null;
            if (flag)
            {
                this.m.BossClear = true;
            }
            else
            {
                bool flag2 = this.s != null;
                if (flag2)
                {
                    this.s.BossClear = true;
                }
            }
            yield return new WaitForSeconds(1f);
            yield break;
        }

        private MiniBossObject m;
        private Stage1Events s;
    }
}