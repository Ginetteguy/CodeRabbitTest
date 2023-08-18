using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helpers
{
    public static class ListHelper
    {
        /// <summary>
        /// Test si les éléments de 2 listes sont identiques.
        /// Si les éléments sont de types simples, on test si ils ont les mêmes valeurs.
        /// </summary>
        /// <typeparam name="T">Le type des éléments contenus dans la liste (type simple)</typeparam>
        /// <param name="liste1">Liste à comparer</param>
        /// <param name="liste2">Liste à comparer</param>
        /// <param name="ignoreOrder">faut-il ignorer l'ordre ?</param>
        /// <returns>true si les 2 listes sont identiques (même instance ou mêmes éléments) </returns>
        public static bool IsListEqual<T>(IList<T> liste1, IList<T> liste2, bool ignoreOrder) where T : struct
        {
            if (liste1 == liste2)
                return true;
            else
            {
                if (liste1 == null || liste2 == null)
                    return false;
                else
                {
                    if (liste1.Count != liste2.Count) // Pas le même nombre d'éléments
                        return false;
                    else if (liste1.Count == 0)  // Aucun élément dans les listes
                        return true;
                    else
                    {
                        // Même nombre d'éléments et au moins un élément dans chaque liste
                        if (ignoreOrder)
                            return true;
                        else
                        {
                            // Vérification de l'ordre des éléments en parcourant tous les éléments si besoin
                            for (int i = 0; i < liste1.Count; i++)
                            {
                                if (liste2.IndexOf(liste1[i]) != i)
                                    return false;
                            }

                            return true;
                        }
                    }
                }
            }
        }
    }
}
