using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization.Formatters;
using System.Text;

namespace CSToolsFinal
{
    public class Pokemon
    {
        String name;
        PokeType type1;
        PokeType type2;
        PokeType[] defStrengths;
        PokeType[] defWeaknesses;

        public Pokemon(String name, PokeType type1)
        {
            this.name = name;
            this.type1 = type1;
            this.type2 = null;

            defStrengths = type1.GetDefStrengths();
            defWeaknesses = type1.GetDefWeaknesses();
        }

        public Pokemon(String name, PokeType type1, PokeType type2)
        {
            this.name = name;
            this.type1 = type1;
            this.type2 = type2;

            CreateDefMatchups();
        }

        public void CreateDefMatchups()
        {
            PokeType[] resistsType1 = type1.GetDefStrengths();
            PokeType[] resistsType2 = type2.GetDefStrengths();
            PokeType[] weaknessesType1 = type1.GetDefWeaknesses();
            PokeType[] weaknessesType2 = type2.GetDefWeaknesses();

            List<PokeType> strengths = new List<PokeType>();
            List<PokeType> weaknesses = new List<PokeType>();
            
            // Add strength only if other type doesn't have that as a weakness
            for (int i = 0; i < resistsType1.Length; i++)
            {
                if (!type2.GetDefWeaknessesNames().Contains(resistsType1[i].GetName()))
                {
                    strengths.Add(resistsType1[i]);
                }
            }

            for (int i = 0; i < resistsType2.Length; i++)
            {
                if (!type1.GetDefWeaknessesNames().Contains(resistsType2[i].GetName()))
                {
                    if (!strengths.Contains(resistsType2[i]))
                    {
                        strengths.Add(resistsType2[i]);
                    }
                }
            }

            // Add weakness only if other type doesn't have that as a strength
            for (int i = 0; i < weaknessesType1.Length; i++)
            {
                if (!type2.GetDefStrengthsNames().Contains(weaknessesType1[i].GetName()))
                {
                    weaknesses.Add(weaknessesType1[i]);
                }
            }

            for (int i = 0; i < weaknessesType2.Length; i++)
            {
                if (!type1.GetDefStrengthsNames().Contains(weaknessesType2[i].GetName()))
                {
                    if (!weaknesses.Contains(weaknessesType2[i]))
                    {
                        weaknesses.Add(weaknessesType2[i]);
                    }
                }
            }

            defStrengths = new PokeType[strengths.Count];
            defWeaknesses = new PokeType[weaknesses.Count];

            for (int i = 0; i < defStrengths.Length; i++)
            {
                defStrengths[i] = strengths[i];
            }

            for (int i = 0; i < defWeaknesses.Length; i++)
            {
                defWeaknesses[i] = weaknesses[i];
            }
        }

        public PokeType[] GetDefStrengths()
        {
            return this.defStrengths;
        }

        public PokeType[] GetDefWeaknesses()
        {
            return this.defWeaknesses;
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

        public String GetName()
        {
            return this.name;
        }

    }
}
