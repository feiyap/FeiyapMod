using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouraisanKaguya
{
    public class BattleEvent_FMokou : PassiveBase
    {
        public static int reviveTimes; //真正的复活次数，10层时进入虚人无
        public static int flameTimes; //不死鸟重生的层数，影响战斗结束概率
        public static int xufuCount; //触发徐福时空的计数
        public static bool onFire; //触发咒符「无差别放火之符」的对话
        public static bool battleend; //触发战斗结束的对话

        public override void Init()
        {
            base.Init();
            reviveTimes = 0;
            flameTimes = 0;
            xufuCount = 0;
            onFire = false;
            battleend = false;
        }

        public void BattleEnd()
        {
            reviveTimes = 0;
            flameTimes = 0;
            xufuCount = 0;
            onFire = false;
            battleend = false;
        }
    }
}
