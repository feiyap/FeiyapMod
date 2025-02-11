using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yuyuko
{
    class BV_YuyukoF_P
    {
        public int fanhun = 0; //返魂值
        public Dictionary<BattleChar, int> dieList = new Dictionary<BattleChar, int>(); //削减最大体力值上限的值
        public int ghost = 0; //亡魂点数
        public Skill str_S = new Skill(); //亡乡被放逐的技能存储
        public string str_M = ""; //幽冥蝶对应
        public string str_R = ""; //人魂蝶对应
        
        //设置返魂值，isInit控制是否为初始化（直接设定），number决定增加数值
        public void setFanhun(int number, bool isInit = false)
        {
            if (isInit)
            {
                fanhun = number;
            }
            else
            {
                fanhun += number;
            }

            if (fanhun >= 100)
            {
                fanhun = 100;
            }
            if (fanhun <= 0)
            {
                fanhun = 0;
            }

            foreach (IP_FanhunChange ip_fanhunChange in BattleSystem.instance.IReturn<IP_FanhunChange>())
            {
                if (ip_fanhunChange != null)
                {
                    ip_fanhunChange.FanhunChange(fanhun);
                }
            }
        }

        //设置最大体力值，isInit控制是否为初始化（直接设定），number决定增加数值，bc为目标对象，user为buff施加者
        public void setDieList(BattleChar bc, int number, BattleChar user, bool isInit = false)
        {
            if (dieList.ContainsKey(bc))
            {
                if (isInit)
                {
                    dieList[bc] = number;
                }
                else
                {
                    dieList[bc] += number;
                }
            }
            else
            {
                dieList.Add(bc, number);
            }

            if (!bc.BuffFind("B_YuyukoF_Die"))
            {
                bc.BuffAdd("B_YuyukoF_Die", user);
            }

            foreach (IP_DieListChange ip_dielistChange in BattleSystem.instance.IReturn<IP_DieListChange>())
            {
                if (ip_dielistChange != null)
                {
                    ip_dielistChange.DieListChange();
                }
            }
        }

        //设置幽冥蝶or人魂蝶，isM控制是否为幽冥蝶（否则为人魂蝶），str被放逐的技能
        public void setButterfly(bool isM)
        {
            if (isM)
            {
                str_M = str_S.MySkill.KeyID;
            }
            else
            {
                str_R = str_S.MySkill.KeyID;
            }

            foreach (IP_ButterflyChange ip_butterflyChange in BattleSystem.instance.IReturn<IP_ButterflyChange>())
            {
                if (ip_butterflyChange != null)
                {
                    ip_butterflyChange.ButterflyChange();
                }
            }
        }
    }

    public interface IP_FanhunChange
    {
        void FanhunChange(int count);
    }

    public interface IP_DieListChange
    {
        void DieListChange();
    }

    public interface IP_ButterflyChange
    {
        void ButterflyChange();
    }

    public interface IP_GhostChange
    {
        void GhostChange(int count);
    }

    public interface IP_ButterflyReturn
    {
        void ButterflyReturn();
    }
}
