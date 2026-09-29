using System;

namespace FeiyapDestination
{
    public enum FeiyapVariant
    {
        None,
        Feiyap,
        FeiyapTank,
        FeiyapMage,
        Destination
    }

    public enum JobMode
    {
        Offense,
        Defense
    }

    public static class FeiyapKeys
    {
        public const string Destination = "FeiyapDestination";
        public const string Feiyap = "Feiyap";
        public const string FeiyapTank = "FeiyapTank";
        public const string FeiyapMage = "FeiyapMage";

        public static readonly string[] SiblingKeys = { Feiyap, FeiyapTank, FeiyapMage, Destination };

        public static bool IsFeiyapFamily(string charKey)
        {
            if (string.IsNullOrEmpty(charKey))
            {
                return false;
            }
            for (int i = 0; i < SiblingKeys.Length; i++)
            {
                if (SiblingKeys[i] == charKey)
                {
                    return true;
                }
            }
            return false;
        }

        public static bool IsOtherFeiyap(string charKey)
        {
            return charKey == Feiyap || charKey == FeiyapTank || charKey == FeiyapMage;
        }

        public static FeiyapVariant Classify(string charKey)
        {
            if (charKey == Feiyap)
            {
                return FeiyapVariant.Feiyap;
            }
            if (charKey == FeiyapTank)
            {
                return FeiyapVariant.FeiyapTank;
            }
            if (charKey == FeiyapMage)
            {
                return FeiyapVariant.FeiyapMage;
            }
            if (charKey == Destination)
            {
                return FeiyapVariant.Destination;
            }
            return FeiyapVariant.None;
        }

        public static string ChaseSkillKey(FeiyapVariant variant)
        {
            switch (variant)
            {
                case FeiyapVariant.FeiyapTank:
                    return ModItemKeys.Skill_S_FeiyapDestination_Chase_Tank;
                case FeiyapVariant.FeiyapMage:
                    return ModItemKeys.Skill_S_FeiyapDestination_Chase_Mage;
                default:
                    return ModItemKeys.Skill_S_FeiyapDestination_Chase_Feiyap;
            }
        }
    }
}
