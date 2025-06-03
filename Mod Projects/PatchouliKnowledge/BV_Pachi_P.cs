using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Debug = UnityEngine.Debug;

namespace PatchouliKnowledge
{
    class BV_Pachi_P
    {
        public List<int> elementLevel = new List<int> {0,0,0,0,0,0,0 };
        public List<int> sunUsed = new List<int> { 0,0,0,0,0,0,0 };
        public List<int> moonUsed = new List<int> { 0,0,0,0,0,0,0 };

        //设置元素等级，isInit控制是否为初始化（直接设定），value决定增加数值
        public void setElementLevel(int index, int value, bool isInit = false)
        {
            if (isInit)
            {
                elementLevel[index] = value;
            }
            else
            {
                elementLevel[index] += value;
            }

            foreach (IP_ElementLevelUp ip_elementLvUp in BattleSystem.instance.IReturn<IP_ElementLevelUp>())
            {
                if (ip_elementLvUp != null)
                {
                    ip_elementLvUp.ElementLevelUp(value);
                }
            }
        }

        //记录日元素使用过的次数
        public void setSunUsed(int index)
        {
            sunUsed[index] = 1;
            Debug.Log(sunUsed);
        }

        //记录月元素使用过的次数
        public void setMoonUsed(int index)
        {
            moonUsed[index] = 1;
            Debug.Log(moonUsed);
        }
    }

    public interface IP_ElementLevelUp
    {
        void ElementLevelUp(int count);
    }
}
