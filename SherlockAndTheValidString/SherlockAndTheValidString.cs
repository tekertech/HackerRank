using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SherlockAndTheValidString
{
    public static class SherlockAndTheValidString
    {
        public static string isValid(string s)
        {
            List<char> characters = new List<char>();
            foreach (var item in s)
            {
                characters.Add(item);
            }

            var groupByCharacter = from character in characters
                                   group character by character into result
                                   select new
                                   {
                                       Character = result.Key,
                                       Count = result.Count()
                                   };
            int maxCount = groupByCharacter.Max(x => x.Count);
            int minCount = groupByCharacter.Min(x => x.Count);


            if (maxCount - minCount == 0)
            {
                return "YES";
            }
            else
            {
                int x = groupByCharacter.Where(a => a.Count == maxCount).Count();
                int y = groupByCharacter.Where(a => a.Count == minCount).Count();

                var newCharacterList = groupByCharacter.GroupBy(b => b.Count);

                if ((maxCount - minCount == 1) && (x == 1 || y == 1))
                {
                    return "YES";
                }
                else if ((newCharacterList.Count() == 2) && ((x == 1 && maxCount == 1) || (y == 1 && minCount == 1)))
                {
                    return "YES";
                }
                else
                {
                    return "NO";
                }
            }
        }
    }
}
