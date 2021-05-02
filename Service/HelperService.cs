using System;
using System.Collections.Generic;
using Project;

namespace Project.Services
{
    public class HelperService
    {
        public List<Cafe> ReturnUniqueItems(List<List<Cafe>> testLists)
        {
            List<Cafe> Unique = new List<Cafe>();

            foreach (List<Cafe> list in testLists)
            {
                foreach (Cafe cafes in list)
                {
                    if (!Unique.Contains(cafes))
                        Unique.Add(cafes);
                }
            }

            return Unique;
        }
    }
}