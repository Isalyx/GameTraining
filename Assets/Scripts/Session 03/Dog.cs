using UnityEngine;

public class Dog : Animal
{
    public Dog(string name, int yearsOld, string race, float weight) : base(name, yearsOld, race, weight)
    {

    }

    public override void MyMethodAbstract()
    {
        throw new System.NotImplementedException();
    }

    public void Bark()
    {
        Debug.Log("WOUF WOUF WOUF");
    }

    public override string ToString()
    {
        return $"Je suis un chien. {base.ToString()} WOUAF WOUAF";
    }
}
