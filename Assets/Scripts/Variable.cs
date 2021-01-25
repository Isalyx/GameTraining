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
        //SwitchTest();

        //Exo1();
        //Exo2();
        //Exo3();
        //Exo4();
        //Exo5();
        //Exo6();
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


    private void Exo1()
    {
        int mon_entier = 53;
        float mon_float = 12.3f;

        Debug.Log(mon_entier);
        Debug.Log(mon_float);
    }

    private void Exo2()
    {
        int mon_entier = 53;
        float mon_float = 12.3f;

        string avecVirgule = "Avec virgule : " + (mon_entier + mon_float);

        Debug.Log(avecVirgule);
        Debug.Log("Sans virgule : " + (mon_entier + (int)mon_float));
    }

    private void Exo3()
    {
        for (int i = 0; i <= 153; i++)
        {
            Debug.Log("For : " + i);
        }
        // Alternative :
        for(int j = 0; j < 154; j++)
        {
            Debug.Log("For ALTERNATIF : " + j);
        }
    }

    private void Exo4()
    {
        for(int i = -26; i >= -232; i--)
        {
            Debug.Log("For : " + i);
        }


        int j = -26;
        while(j >= -232)
        {
            Debug.Log("While " + j);
            j--;
        }
    }


    private void Exo5()
    {
        for (int i = -26; i >= -232; i--)
        {
            if(i == -50)
            {
                Debug.Log("For : Coucou");
            }
            else
            {
                Debug.Log("For : " + i);
            }
        }


        int j = -26;
        while (j >= -232)
        {
            if (j == -50)
            {
                Debug.Log("While : Coucou");
            }
            else
            {
                Debug.Log("While : " + j);
            }
            j--;
        }
    }

    private void Exo6()
    {
        for (int i = -26; i >= -232; i--)
        {
            if (i == -85)
            {
                Debug.Log("For : Coucou");
            }
            else if (i == -230)
            {
                Debug.Log("For : Presque FINI");
            }
            else
            {
                Debug.Log("For : " + i);
            }
        }


        int j = -26;
        while (j >= -232)
        {
            switch (j)
            {
                case -85:
                    Debug.Log("While : Coucou");
                    break;
                case -230:
                    Debug.Log("While : Presque FINI");
                    break;
                default:
                    //Debug.Log("While : " + j + System.Environment.NewLine + "TEST");

                    Debug.Log($"While : {j} {j} {System.Environment.NewLine}TEST");

                    //string p = $"While : {j} {j} {System.Environment.NewLine}TEST";
                    break;
            }
            j--;
        }
    }


}
