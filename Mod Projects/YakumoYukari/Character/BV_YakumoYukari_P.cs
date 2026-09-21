using System;

namespace YakumoYukari
{
    /// <summary>
    /// 动作类型。
    /// </summary>
    public enum YukariActionType
    {
        Swift,
        Move,
        Standard,
        FullRound,
        Any
    }

    /// <summary>
    /// 动作槽消耗。
    /// </summary>
    public struct YukariActionCost
    {
        public int Swift;
        public int Move;
        public int Standard;

        public static YukariActionCost From(YukariActionType type, YukariActionType declared)
        {
            YukariActionType pay = type == YukariActionType.Any ? declared : type;
            switch (pay)
            {
                case YukariActionType.Swift:
                    return new YukariActionCost { Swift = 1 };
                case YukariActionType.Move:
                    return new YukariActionCost { Move = 1 };
                case YukariActionType.Standard:
                    return new YukariActionCost { Standard = 1 };
                case YukariActionType.FullRound:
                    return new YukariActionCost { Move = 1, Standard = 1 };
                default:
                    return new YukariActionCost { Swift = 1 };
            }
        }
    }

    /// <summary>
    /// 八云紫本场战斗值：动作等级、三槽、境界力。
    /// </summary>
    public class BV_YakumoYukari_P
    {
        public System.Collections.Generic.Dictionary<string, int> ActionLevels = new System.Collections.Generic.Dictionary<string, int>();
        public int Swift;
        public int Move;
        public int Standard;
        public int Boundary;
        public YukariActionType DeclaredType = YukariActionType.Swift;

        public static BV_YakumoYukari_P Get()
        {
            if (BattleSystem.instance == null)
            {
                return null;
            }
            BV_YakumoYukari_P bv = BattleSystem.instance.GetBattleValue<BV_YakumoYukari_P>();
            if (bv == null)
            {
                bv = new BV_YakumoYukari_P();
                BattleSystem.instance.BattleValues.Add(bv);
            }
            return bv;
        }

        public int MaxBoundary(BattleChar bc)
        {
            int lv = 1;
            if (bc != null && bc.Info != null)
            {
                lv = Math.Max(1, bc.Info.LV);
            }
            return lv * 10;
        }

        public void GrantTurnSlots()
        {
            this.Swift = 1;
            this.Move = 1;
            this.Standard = 1;
        }

        public void AddAction(string key, bool cannotLevel)
        {
            if (string.IsNullOrEmpty(key))
            {
                return;
            }
            if (cannotLevel)
            {
                this.ActionLevels[key] = 1;
                return;
            }
            if (this.ActionLevels.ContainsKey(key))
            {
                this.ActionLevels[key] = this.ActionLevels[key] + 1;
            }
            else
            {
                this.ActionLevels[key] = 1;
            }
        }

        public int GetActionLevel(string key)
        {
            int lv;
            if (this.ActionLevels.TryGetValue(key, out lv))
            {
                return lv;
            }
            return 0;
        }

        public void GainBoundary(int amount, BattleChar bc)
        {
            int max = this.MaxBoundary(bc);
            this.Boundary = Math.Min(max, Math.Max(0, this.Boundary + amount));
        }

        public bool TrySpendBoundary(int amount)
        {
            if (amount <= 0)
            {
                return true;
            }
            if (this.Boundary < amount)
            {
                return false;
            }
            this.Boundary -= amount;
            return true;
        }

        public void ClearBoundary()
        {
            this.Boundary = 0;
        }

        public bool CanPay(YukariActionCost cost)
        {
            int s = this.Swift;
            int m = this.Move;
            int st = this.Standard;
            return ApplyCost(ref s, ref m, ref st, cost);
        }

        public bool PreviewSpend(YukariActionCost cost, out int newSwift, out int newMove, out int newStandard)
        {
            newSwift = this.Swift;
            newMove = this.Move;
            newStandard = this.Standard;
            return ApplyCost(ref newSwift, ref newMove, ref newStandard, cost);
        }

        public bool TrySpend(YukariActionCost cost)
        {
            int s = this.Swift;
            int m = this.Move;
            int st = this.Standard;
            if (!ApplyCost(ref s, ref m, ref st, cost))
            {
                return false;
            }
            this.Swift = s;
            this.Move = m;
            this.Standard = st;
            return true;
        }

        public bool WouldTick(YukariActionCost cost, bool forceTick)
        {
            if (forceTick)
            {
                return true;
            }
            int ns, nm, nst;
            if (!this.PreviewSpend(cost, out ns, out nm, out nst))
            {
                return false;
            }
            return nm != this.Move || nst != this.Standard;
        }

        private static bool ApplyCost(ref int s, ref int m, ref int st, YukariActionCost cost)
        {
            if (st < cost.Standard)
            {
                return false;
            }
            st -= cost.Standard;

            int needMove = cost.Move;
            if (m >= needMove)
            {
                m -= needMove;
            }
            else
            {
                needMove -= m;
                m = 0;
                if (st < needMove)
                {
                    return false;
                }
                st -= needMove;
            }

            int needSwift = cost.Swift;
            if (s >= needSwift)
            {
                s -= needSwift;
            }
            else
            {
                needSwift -= s;
                s = 0;
                if (m >= needSwift)
                {
                    m -= needSwift;
                }
                else
                {
                    needSwift -= m;
                    m = 0;
                    if (st < needSwift)
                    {
                        return false;
                    }
                    st -= needSwift;
                }
            }
            return true;
        }

        public static bool MatchesButton(YukariActionType action, YukariActionType button)
        {
            if (action == YukariActionType.Any)
            {
                return true;
            }
            if (action == YukariActionType.FullRound)
            {
                return button == YukariActionType.Standard;
            }
            if (button == YukariActionType.Swift)
            {
                return action == YukariActionType.Swift;
            }
            if (button == YukariActionType.Move)
            {
                return action == YukariActionType.Move || action == YukariActionType.Swift;
            }
            if (button == YukariActionType.Standard)
            {
                return action == YukariActionType.Standard || action == YukariActionType.Move || action == YukariActionType.Swift;
            }
            return false;
        }
    }
}
