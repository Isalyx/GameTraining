using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Session2 : MonoBehaviour
{
    [SerializeField]
    MyClass m_myClass;

    [SerializeField]
    MyStruct m_myStruct;



    //Déclaration d'un ARRAY
    // type[] nomVariable;
    int[] myArrayInt = new int[3];

    [SerializeField]
    MyClass[] myArrayClass;

    [SerializeField]
    MyStruct[] myArrayStruct;


    List<int> myListInt;// = new List<int>();
    List<MyClass> myListClass = new List<MyClass>();



    // Start is called before the first frame update
    void Start()
    {
        FirstClassInit();
        FirstStructInit();

        //RefSample(m_myClass);
        //string s = "Mon string";
        //ValueSample(s);

        //myArrayClass = new MyClass[2];

        //myArrayInt = new int[3];

        //myArrayClass[0] = new MyClass();
        //myArrayClass[0].Name = "Coucou";

        //myArrayClass[1] = new MyClass();
        //myArrayClass[1].Name = "Malefoy";

        myListClass.Add(new MyClass());
        myListClass[0].Name = "Coucou";
        myListClass.Add(new MyClass());
        myListClass[1].Name = "Malefoy";


        //myArrayInt[0] = 10;
        //myArrayInt[1] = 24;
        //myArrayInt[2] = 50;

        //int p = 10;

        //ChangeP(p);

        //Debug.Log(myArrayInt[0]);
        //Debug.Log(myArrayInt[1]);

        //Debug.Log(p);

        //myListInt = new List<int>();

        //myListInt.Add(10);
        //myListInt.Add(20);
        //myListInt.Add(80);

        //myListInt[2] = 40;

        ForeachSample();
    }


    private void FirstClassInit()
    {
        m_myClass = new MyClass();

        m_myClass.Name = "Kuzko";
        m_myClass.YearOld = 15;

        //Debug.Log($"Name : {m_myClass.Name}");

    }
    private void FirstStructInit()
    {
        m_myStruct = new MyStruct();

        m_myStruct.Name = "Mike";
        m_myStruct.YearOld = 25;

        //Debug.Log($"Name : {m_myStruct.Name}");
    }

    private void RefSample(MyClass myParam)
    {
        /* REF TYPE :
         * OBJECT ( Class )
         * Array / List / Dictionnary / ....
         */


        myParam.Name = "JaiRenommé";
        Debug.Log($"myClass Name : {m_myClass.Name}");
        //return myClass;
    }

    private void ChangeP(int value)
    {
        value = 150;
    }

    private void ChangeArray(int[] arrayInt)
    {
        arrayInt[0] = 180;
        arrayInt[1] = 230;
    }

    private void ChangeArray(MyClass[] arrayClass)
    {
        arrayClass[0].Name = "Troll";
        arrayClass[1].Name = "Harry";
    }

    private void ValueSample(string value)
    {
        /* VALUE TYPE :
        INT
        BOOL
        STRUCT
        FLOAT
        CHAR
        STRING
        */

        //myParam.Name = "JaiRenommé";
        value = "JaiChangé";
        //Debug.Log($"{value}");
        //return myStruct;
    }

    private void ForeachSample()
    {
        ////foreach(type name in list/array)
        //foreach(int item in myArrayInt)
        //{
        //    Debug.Log(item);
        //}

        //for(int i = 0; i < myArrayInt.Length; i++)
        //{
        //    Debug.Log(myArrayInt[i]);
        //}

        //for(int i = 0; i < myArrayClass.Length; i++)
        //{
        //    Debug.Log($"{myArrayClass[i].Name}");
        //    myArrayClass[2] = null;
        //}

        foreach(MyClass item in myListClass)
        {
            Debug.Log($"{item.Name}");
            myListClass.Remove(item);
        }
    }


}
