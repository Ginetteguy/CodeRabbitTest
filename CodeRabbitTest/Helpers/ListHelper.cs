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

            if (liste1 == null || liste2 == null)
                return false;

            if (liste1.Count != liste2.Count) // Pas le même nombre d'éléments
                return false;

            if (liste1.Count == 0)  // Aucun élément dans les listes
                return true;

            // Même nombre d'éléments et au moins un élément dans chaque liste
            if (ignoreOrder)
            {
                var sortedList1 = new List<T>(liste1);
                var sortedList2 = new List<T>(liste2);
                sortedList1.Sort();
                sortedList2.Sort();

                return sortedList1.SequenceEqual(sortedList2);
            }
            else
            {
                return liste1.SequenceEqual(liste2);
            }
        }

        /// <summary>
        /// Diviser une liste en plusieurs listes de n éléments
        /// </summary>
        /// <typeparam name="T">Type de la liste</typeparam>
        /// <param name="liste">Liste à spliter</param>
        /// <param name="taille">Taille des sous listes désirée</param>
        /// <returns>Liste de liste de n éléments</returns>
        public static IEnumerable<IEnumerable<T>> Paginate<T>(IEnumerable<T> liste, int taille)
        {
            if (liste == null || !liste.Any())
                throw new ArgumentException("La liste est vide, c'est à l'appelant de gérer cela.");
            if (taille <= 0) 
                throw new ArgumentException("Le nombre d'éléments voulu dans les liste découpées doit être supérieur à 0.", nameof(taille));
            return PaginateIterator(liste, taille);

        }

        /// <summary>
        /// Itération pour diviser une liste en plusieurs listes de n éléments 
        /// </summary>
        /// <typeparam name="T">Type de la liste</typeparam>
        /// <param name="liste">Liste à spliter</param>
        /// <param name="taille">Taille des sous listes désirée</param>
        /// <returns>Liste de liste de n éléments</returns>
        private static IEnumerable<IEnumerable<T>> PaginateIterator<T>(IEnumerable<T> liste, int taille)
        {
            for (int i = 0; i < liste.Count(); i += taille)
            {
                yield return liste.Skip(i).Take(taille);
            }
        }
    }
}
