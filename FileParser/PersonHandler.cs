using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using ObjectLibrary;
using System.Text;


namespace FileParser {
    
    //public class Person { }  // temp class delete this when Person is referenced from dll
    
    public class PersonHandler {
        public List<Person> People;
        /// <summary>
        /// Converts List of list of strings into Person objects for People attribute.
        /// </summary>
        /// <param name="people"></param>
        public PersonHandler(List<List<string>> people)
        {
            People = new List<Person>();
            int count = 1;
           while(count < people.Count)
            {
                Person p1 = new Person(int.Parse(people[count][0]), people[count][1].ToString(), people[count][2].ToString(), new DateTime(Convert.ToInt64(people[count][3])));
                People.Add(p1);
                count++;
            }
        }
        /// <summary>
        /// Gets oldest people
        /// </summary>
        /// <returns></returns>
        public List<Person> GetOldest() {
            DateTime oldest = DateTime.Now;
            int count = 0;
            List<Person> Oldest = new List<Person>();
            while(count < People.Count)
            {
                if (oldest > People[count].Dob)
                {
                    oldest = People[count].Dob;
                }
                count++;
            }
            count = 0;
            while (count < People.Count)
            {
                if (oldest == People[count].Dob)
                {
                    Oldest.Add(People[count]);
                }
                count++;
            }
            return Oldest; //-- return result here
        }

        /// <summary>
        /// Gets string (from ToString) of Person from given Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string GetString(int id) {
            int count = 0;
            bool FoundPerson = false;
            while (count < People.Count && FoundPerson == false)
            {
                if (id == People[count].Id)
                {
                    FoundPerson = true;
                }
                count++;
            }
                return People[count].ToString();  //-- return result here
        }

        public List<Person> GetOrderBySurname() {

            List<Person> SortedList = People.OrderBy(o => o.Surname).ToList();

            return SortedList;  //-- return result here
        }

        /// <summary>
        /// Returns number of people with surname starting with a given string.  Allows case-sensitive and case-insensitive searches
        /// </summary>
        /// <param name="searchTerm"></param>
        /// <param name="caseSensitive"></param>
        /// <returns></returns>
        public int GetNumSurnameBegins(string searchTerm, bool caseSensitive) {
            int SurnameMatches = 0;
            int count = 0;
            int SearchTermLength = searchTerm.Length;
            if(caseSensitive == false)
            {
                searchTerm = searchTerm.ToLower();
            }
            while(count < People.Count)
            {
                string Comparator = People[count].Surname.Substring(0, SearchTermLength);
                if (caseSensitive == false)
                {
                    Comparator = Comparator.ToLower();
                }
                if (Comparator == searchTerm)
                {
                    SurnameMatches++;
                }
                count++;
            }
            return SurnameMatches;  //-- return result here
        }
        
        /// <summary>
        /// Returns a string with date and number of people with that date of birth.  Two values seperated by a tab.  Results ordered by date.
        /// </summary>
        /// <returns></returns>
        public List<string> GetAmountBornOnEachDate() {
            List<string> result = new List<string>();
            List<Person> OrderedByDate = People.OrderBy(x => x.Dob).ToList();
            List<DateTime> DateTimeList = new List<DateTime>();
            List<int> NumBornOnEachDate = new List<int>();
            int count = 0;
            

            while (count < OrderedByDate.Count)
            {
                bool Indicator = false;
                int count2 =0;
                //adds first element of orderedlist to datetimelist when datetimelist has no elements
                if(count2 == 0 && count == 0)
                {
                    DateTimeList.Add(OrderedByDate[count].Dob);
                }
                //finds out if exists in datetimelist and if not adds it
                if (count2 != 0) {
                    
                    while (count2 < DateTimeList.Count) {
                        if (DateTimeList[count2] == OrderedByDate[count].Dob)
                        {
                            Indicator = true;
                        }
                        count2++;
                    }
                    if(Indicator == false)
                    {
                        DateTimeList.Add(OrderedByDate[count].Dob);
                    }
                }
                count++;
            }
            //creates list of numborn on each date from full datetimelist
            count = 0;
            while (count < DateTimeList.Count)
            {

                count++;
            }
            //adds results to results list
            int count3 = 0;
            while (count3 < DateTimeList.Count)
            {
                result.Add(DateTimeList[count3].Date.ToString().Substring(0, 10) + " " + NumBornOnEachDate[count3].ToString());
                count3++;
            }
            return result;  //-- return result here
        }
    }
}