using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _03.StringDisperser
{
    public class StringDisperser : ICloneable, IComparable<StringDisperser>, IEnumerable<char>
    {
        private readonly IList<char> listOfChars = new List<char>();
        private readonly string paramsAsString;

        public StringDisperser(params string[] inputParams)
        {
            this.paramsAsString = string.Join("", inputParams);
            DisperseInputParams();
        }

        private void DisperseInputParams()
        {
            foreach (var charParam in this.paramsAsString)
            {
                this.listOfChars.Add(charParam);
            }
        }

        object ICloneable.Clone()
        {
            return this.Clone();
        }

        public StringDisperser Clone()
        {
            var stringDisperser = new StringDisperser(this.paramsAsString);
            return stringDisperser;
        }

        public int CompareTo(StringDisperser other)
        {
            return string.Compare(this.paramsAsString, other.paramsAsString, StringComparison.Ordinal);
        }

        public IEnumerator<char> GetEnumerator()
        {
            foreach (var charParam in this.listOfChars)
            {
                yield return charParam;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        public override bool Equals(object obj)
        {
            var other = obj as StringDisperser;

            if (other == null)
            {
                return false;
            }
            var areSequential = this.listOfChars.SequenceEqual(other.listOfChars);

            if (!areSequential)
            {
                return false;
            }

            return true;
        }

        public static bool operator ==(StringDisperser stringDisperserA, StringDisperser stringDisperserB)
        {
            return Equals(stringDisperserA, stringDisperserB);
        }

        public static bool operator !=(StringDisperser stringDisperserA, StringDisperser stringDisperserB)
        {
            return !Equals(stringDisperserA, stringDisperserB);
        }


        public override int GetHashCode()
        {
            return (listOfChars != null ? listOfChars.GetHashCode() : 0);
        }

        public override string ToString()
        {
            var output = "";
            foreach (var c in this.listOfChars)
            {
                output += c + " ";
            }
            return output;
        }
    }
}