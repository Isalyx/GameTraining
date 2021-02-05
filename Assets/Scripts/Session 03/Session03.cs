using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Session03 : MonoBehaviour
{
    private List<Dog> m_dogsList;

    public List<Dog> DogsList
    {
        get { return m_dogsList; }
        private set { m_dogsList = value; }
    }


    private List<Cat> m_catsList;

    public List<Cat> CatsList
    {
        get { return m_catsList; }
        private set { m_catsList = value; }
    }


    private List<Animal> m_animalsList;
    public List<Animal> AnimalsList
    {
        get => m_animalsList;
        private set => m_animalsList = value;
    }



    // Start is called before the first frame update
    void Start()
    {
        DogsList = new List<Dog>();
        CatsList = new List<Cat>();
        AnimalsList = new List<Animal>();

        #region Creates animals

        #region Dogs
        AddDogsList(CreateDog("Medor", 3, "Malamute", 35.430f));
        AddDogsList(CreateDog("Stuart", 7, "Souris", 1.560f));
        AddDogsList(CreateDog("Mocheté", 1, "Chihuahua", 85.050f));
        #endregion


        #region Cats
        AddCatsList(CreateCat("Poupouce", 5, "Inconnue", 7.560f));
        AddCatsList(CreateCat("Little", 2, "Siamois", 9.250f));
        AddCatsList(CreateCat("Miaouss", 25, "Pokemon", 4.200f));
        #endregion


        #region Both
        AddAnimalsList(CreateDog("Medor", 3, "Malamute", 35.430f));
        AddAnimalsList(CreateDog("Stuart", 7, "Souris", 1.560f));
        AddAnimalsList(CreateDog("Mocheté", 1, "Chihuahua", 85.050f));
        AddAnimalsList(CreateCat("Poupouce", 5, "Inconnue", 7.560f));
        AddAnimalsList(CreateCat("Little", 2, "Siamois", 9.250f));
        AddAnimalsList(CreateCat("Miaouss", 25, "Pokemon", 4.200f));
        #endregion
        #endregion


        ModifyYearsOfDog(DogsList.First());
        CatsList[CatsList.Count - 1] = ModifyWeightOfCat(CatsList.Last());


        GetBiggestDog();
        GetSkinnyCat();


        GetOldestAnimals();


        GetBiggestNameOfDog();

        GetBiggestNameOfAnimals();        
    }


    private void Update()
    {
        Debug.Log(AnimalsList.First().ToString());
        Debug.Log(DogsList.First().ToString());
        Debug.Log(CatsList.First().ToString());
    }



    private Dog CreateDog(string name, int yearsOld, string race, float weight)
    {
        return new Dog(name, yearsOld, race, weight);
    }

    private Cat CreateCat(string name, int yearsOld, string race, float weight)
    {
        return new Cat(name, yearsOld, race, weight);
    }

    private void AddDogsList(Dog dog)
    {
        DogsList.Add(dog);
    }

    private void AddCatsList(Cat cat)
    {
        CatsList.Add(cat);
    }

    private void AddAnimalsList(Animal animal)
    {
        AnimalsList.Add(animal);
    }

    private void ModifyYearsOfDog(Dog dog)
    {
        dog.ModifyYearsOld(6);
    }

    private Cat ModifyWeightOfCat(Cat cat)
    {
        cat.ModifyWeight(8.390f);
        return cat;
    }


    private Dog GetBiggestDog()
    {

        #region Methode 1

        //Dog dog = DogsList.First();
        //for (int i = 1; i < DogsList.Count; i++)
        //{
        //    if(dog.Weight < DogsList[i].Weight)
        //    {
        //        dog = DogsList[i];
        //    }
        //}
        //return dog;

        #endregion

        #region Methode 2

        //Dog currentDog = null;
        //foreach(Dog dog in DogsList)
        //{
        //    if (currentDog is null)
        //        currentDog = dog;
        //    else
        //    {
        //        if(currentDog.Weight < dog.Weight)
        //        {
        //            currentDog = dog;
        //        }
        //    }
        //}

        //return currentDog;

        #endregion

        #region Methode 3



        #endregion

        return null;

    }

    private Cat GetSkinnyCat()
    {
        #region Methode 1

        //Cat cat = CatsList.First();
        //for (int i = 1; i < CatsList.Count; i++)
        //{
        //    if (cat.Weight > CatsList[i].Weight)
        //    {
        //        cat = CatsList[i];
        //    }
        //}
        //return cat;

        #endregion

        #region Methode 2

        Cat currentCat = null;
        foreach (Cat cat in CatsList)
        {
            if (currentCat is null)
                currentCat = cat;
            else
            {
                if (currentCat.Weight > cat.Weight)
                {
                    currentCat = cat;
                }
            }
        }

        return currentCat;

        #endregion

        #region Methode 3



        #endregion
    }


    private void GetOldestAnimals()
    {
        Dog dog = DogsList.First();
        Cat cat = CatsList.First();

        for (int i = 1; i < DogsList.Count; i++)
        {
            if(dog.YearsOld < DogsList[i].YearsOld)
            {
                dog = DogsList[i];
            }
        }

        for (int i = 1; i < CatsList.Count; i++)
        {
            if (cat.YearsOld < CatsList[i].YearsOld)
            {
                cat = CatsList[i];
            }
        }


        Debug.Log(cat.YearsOld > dog.YearsOld ? $"Le chat est le plus vieuw: { cat.Name}" : $"Le chien est le plus vieux : {dog.Name}");
        
        // La ligne ci-dessus fait la même chose que le contenu ci-dessous.

        //if(dog.YearsOld > cat.YearsOld)
        //{
        //    Debug.Log($"Le chien est le plus vieux : {dog.Name}");
        //}
        //else
        //{
        //    Debug.Log($"Le chat est le plus vieuw : {cat.Name}");
        //}

    }

    private void GetBiggestNameOfDog()
    {
        Dog dog = DogsList.First();

        for (int i = 1; i < DogsList.Count; i++)
        {
            if (dog.Name.Length < DogsList[i].Name.Length)
            {
                dog = DogsList[i];
            }
            else if(dog.Name.Length == DogsList[i].Name.Length)
            {
                if (dog.YearsOld < DogsList[i].YearsOld)
                    dog = DogsList[i];
            }
        }
    }


    private Animal GetBiggestNameOfAnimals()
    {
        Animal currentAnimal = null;
        foreach (Animal animal in AnimalsList)
        {
            if (currentAnimal is null) currentAnimal = animal;

            if (currentAnimal.Name.Length > animal.Name.Length)
            {
                currentAnimal = animal;
            }
            else if (currentAnimal.Name.Length == animal.Name.Length)
            {
                if (currentAnimal.YearsOld < animal.YearsOld)
                {
                    currentAnimal = animal;
                }
            }
        }

        return currentAnimal;
    }
}
