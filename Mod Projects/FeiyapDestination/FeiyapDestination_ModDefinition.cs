using System;
using ChronoArkMod;
using ChronoArkMod.ModData;

namespace FeiyapDestination
{
    public class FeiyapDestination_ModDefinition : ModDefinition
    {
        public override Type ModItemKeysType
        {
            get
            {
                return typeof(ModItemKeys);
            }
        }
    }
}
