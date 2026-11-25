using System;
using System.Collections.Generic;
using System.Text;

namespace CSToolsFinal
{
    public class PokeType
    {
        String name;
        PokeType[] atkStrengths;
        PokeType[] atkWeaknesses;
        PokeType[] defStrengths;
        PokeType[] defWeaknesses;

        public PokeType(String name)
        {
            this.name = name;
            this.atkStrengths = null;
            this.atkWeaknesses = null;
            this.defStrengths = null;
            this.defWeaknesses = null;
        }

        public void SetAtkStrengths(PokeType[] strengths)
        {
            this.atkStrengths = strengths;
        }

        public void SetAtkWeaknesses(PokeType[] weaknesses)
        {
            this.atkWeaknesses = weaknesses;
        }

        public void SetDefStrengths(PokeType[] strengths)
        {
            this.defStrengths = strengths;
        }

        public void SetDefWeaknesses(PokeType[] weaknesses)
        {
            this.defWeaknesses = weaknesses;
        }

    }
}
