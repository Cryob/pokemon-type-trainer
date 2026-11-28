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

        public String GetName()
        {
            return name;
        }

        public String GetAtkStrengthsNames()
        {
            if (atkStrengths == null)
            {
                return "None";
            }

            String types = "";

            for (int i = 0; i < atkStrengths.Length; i++)
            {
                types += atkStrengths[i].GetName();
                types += ",";
            }

            return types;
        }

        public String GetAtkWeaknessesNames()
        {
            if (atkWeaknesses == null)
            {
                return "None";
            }

            String types = "";

            for (int i = 0; i < atkWeaknesses.Length; i++)
            {
                types += atkWeaknesses[i].GetName();
                types += ",";
            }

            return types;
        }

        public String GetDefStrengthsNames()
        {
            if (defStrengths == null)
            {
                return "None";
            }

            String types = "";

            for (int i = 0; i < defStrengths.Length; i++)
            {
                types += defStrengths[i].GetName();
                types += ",";
            }

            return types;
        }

        public String GetDefWeaknessesNames()
        {
            if (defWeaknesses == null)
            {
                return "None";
            }

            String types = "";
            
            for (int i = 0; i < defWeaknesses.Length; i++)
            {
                types += defWeaknesses[i].GetName();
                types += ",";
            }

            return types;
        }

        public PokeType GetRandAtkStrength()
        {
            Random rand = new Random();

            //if (atkStrengths == null)
            //{
            //    Console.WriteLine("WAIT STOP");
            //    Console.WriteLine(name);
            //    return null;
            //}

            return atkStrengths[rand.Next(0, atkStrengths.Length)];
        }

        public PokeType GetRandAtkWeakness()
        {
            Random rand = new Random();

            return atkWeaknesses[rand.Next(0, atkWeaknesses.Length)];
        }

        public PokeType GetRandDefStrength()
        {
            Random rand = new Random();

            return defStrengths[rand.Next(0, defStrengths.Length)];
        }

        public PokeType GetRandDefWeakness()
        {
            Random rand = new Random();

            return defWeaknesses[rand.Next(0, defWeaknesses.Length)];
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

        public PokeType[] GetAtkStrengths()
        {
            return this.atkStrengths;
        }

        public PokeType[] GetAtkWeaknesses()
        {
            return this.atkWeaknesses;
        }

        public PokeType[] GetDefStrengths()
        {
            return this.defStrengths;
        }

        public PokeType[] GetDefWeaknesses()
        {
            return this.defWeaknesses;
        }

    }
}
