using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Variable : MonoBehaviour
{
    int mon_integer = 10;
    float mon_float = 10.9f;
    double mon_double = 10.2;

    bool mon_bool = true;

    char mon_char = 'u';
    string mon_string = "uopoejfdiejf";


    private void Start()
    {
        // Pour appeler une méthode :
        SwitchTest();
    }


    private void SwitchTest()
    {
        switch (mon_integer)
        {
            case 10:
                Debug.Log(mon_integer);
                mon_integer = 25;
                break;
            case 25:
                Debug.Log(mon_integer);
                mon_integer = 50;
                break;
            default:
                Debug.Log(mon_integer);
                mon_integer = 10;
                break;
        }
    }

    private void IfElseTest()
    {
        if (mon_integer == 10)
        {
            Debug.Log(mon_integer);
            mon_integer = 25;
        }
        else
        {
            Debug.Log(mon_integer);
            mon_integer = 10;
        }
    }

    private void IfElseIfElseTest()
    {
        if (mon_integer == 10)
        {
            Debug.Log(mon_integer);
            mon_integer = 25;
        }
        else if (mon_integer == 25)
        {
            Debug.Log(mon_integer);
            mon_integer = 50;
        }
        else
        {
            Debug.Log(mon_integer);
            mon_integer = 10;
        }
    }

    private void ForTest()
    {
        //FOR
        for (int i = 0; i < 10; i++)
        //for(affectation compteur; conditions; incrément)
        {
            Debug.Log(i);

            // 0 ... 9
        }
    }

    private void WhileTest()
    {
        // WHILE
        int i = 0;
        while (mon_bool)
        //while(conditions)
        {
            Debug.Log(i);

            if (i >= 100)
            {
                mon_bool = false;
            }

            i++;
        }
        Debug.Log("While Terminé");
    }

    private void DoWhileTest()
    {
        // DO WHILE
            //do{ } while(conditions);
        mon_bool = false;
        int compteur = 0;
        do
        {
            Debug.Log("Coucou");
            Debug.Log(compteur);
            compteur++;
        } while (compteur <= 10);
    }
}
