public class Cat : Animal
{
    public Cat(string name, int yearsOld, string race, float weight) : base(name, yearsOld, race, weight)
    {

    }

    public override void MyMethodAbstract()
    {
        throw new System.NotImplementedException();
    }

    public override string ToString()
    {
        return $"Je suis un chat. {base.ToString()} MIAOUSS OUI LA GUERRE !";
    }
}
