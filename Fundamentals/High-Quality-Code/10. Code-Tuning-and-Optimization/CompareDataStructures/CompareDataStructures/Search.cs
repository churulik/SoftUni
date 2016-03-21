using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace CompareDataStructures
{
    public class Search: IEnumerable<Person>
    {
        private readonly string _searchedName;
        private readonly IList<Person> _personList; 

        public Search(IList<Person> personList, string searchedName)
        {
            this._personList = personList;
            this._searchedName = searchedName;
        }


        public IEnumerator<Person> GetEnumerator()
        {
            var serchedName = this._personList.Where(p => p.Name == this._searchedName);
            foreach (var person in serchedName)
            {
                yield return person;
            }
            
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}