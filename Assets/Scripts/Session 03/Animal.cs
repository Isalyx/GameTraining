using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Animal
{
    #region Property
    private string m_name;
    public string Name
    {
        get
        {
            return m_name;
        }
        protected set
        {
            m_name = value;
        }
    }

    private int m_yearsOld;
    public int YearsOld
    {
        get { return m_yearsOld; }
        protected set { m_yearsOld = value; }
    }


    private string m_race;
    public string Race
    {
        get { return m_race; }
        protected set { m_race = value; }
    }


    private float m_weight;
    public float Weight
    {
        get { return m_weight; }
        protected set { m_weight = value; }
    }
    #endregion

    public Animal(string name, int yearsOld, string race, float weight)
    {
        Name = name;
        YearsOld = yearsOld;
        Race = race;
        Weight = weight;
    }


    public void ModifyYearsOld(int newValue)
    {
        if (newValue > 0)
        {
            YearsOld = newValue;
        }
    }

    public void ModifyWeight(float newValue)
    {
        if (newValue > 0)
        {
            Weight = newValue;
        }
    }

    public void ModifyWeight(float newValue, bool isNegative)
    {
        if (isNegative)
        {
            newValue *= -1;
        }

        ModifyWeight(newValue);
    }


    public override string ToString()
    {
        return $"Je m'appelle {Name}, j'ai {YearsOld} ans. Je suis de la race {Race} et je pèse {Weight} KG.";
    }

    public abstract void MyMethodAbstract();
}
