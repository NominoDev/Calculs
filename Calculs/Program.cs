using System;

namespace Calculs
{
    /// <summary>
    /// Application Calculs : addition ou multiplication de 2 nombres
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            // variables 
            Random rand = new Random(); // outil de génération de nombre aléatoire
            int val1, val2; // mémorisation de nombres aléatoires
            int solution; // calcul de la solution

            //pour éviter de se répéter avec certains try catch j'ai fait directement une fonction ici qui retourne true et exécute un bloc de code donné si la saisie est correcte
            bool getInput(Action<int>fn)
            {
                try
                {
                    fn(int.Parse(Console.ReadLine()));
                }
                catch
                {
                    return false;
                }
                return true;
            }

            // boucle sur le menu
            while (true)
            {

                // affiche le menu et saisi le choix
                Console.WriteLine("Addition ....................... 1");
                Console.WriteLine("Multiplication ................. 2");
                Console.WriteLine("Quitter ........................ 0");
                Console.Write("Choix :                          ");
                int choix;
                try
                {
                    choix = int.Parse(Console.ReadLine());
                } catch
                {
                    Console.WriteLine("Eerreur de saisie.");
                    continue;
                }

                //choix de l'addition/multiplication
                val1 = rand.Next(1, 10);
                val2 = rand.Next(1, 10);
                // traitement des choix
                if (choix != 0)
                {
                    if (choix == 1)
                    {
                        
                        // saisie de la réponse
                        Console.Write(val1 + " + " + val2 + " = ");
                        // comparaison avec la bonne réponse
                        bool reponse_adition_valide = getInput((int reponse) =>
                        {
                            solution = val1 + val2;
                            if (reponse == solution)
                            {
                                Console.WriteLine("Bravo !");
                            }
                            else
                            {
                                Console.WriteLine("Faux : " + val1 + " + " + val2 + " = " + solution);
                            }
                        });
                        if (!reponse_adition_valide)
                        {
                            Console.WriteLine("Eerreur de saisie.");
                            continue;
                        }
                    }
                    else if (choix == 2) // il faut vérifier le choix
                    {
                        // saisie de la réponse
                        Console.Write(val1 + " x " + val2 + " = ");
                        // comparaison avec la bonne réponse
                        bool reponse_multiplication_valide = getInput((int reponse) => {
                            solution = val1 * val2;
                            if (reponse == solution)
                            {
                                Console.WriteLine("Bravo !");
                            }
                            else
                            {
                                Console.WriteLine("Faux : " + val1 + " x " + val2 + " = " + solution);
                            }
                        });
                    }
                    else
                    {
                        Console.WriteLine("Erreur de saisie.");
                        continue;
                    }
                }
                else
                {
                    break; // le choix était 0 donc on peut sortir de la boucle directement
                }
            }
        }
    }
}