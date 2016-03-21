using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using _02.Customer.Models.Enums;

namespace _02.Customer.Models
{
    public class Customer : ICloneable, IComparable<Customer>
    {
        private const int IdLenght = 10;
        private const int MobilePhoneLength = 10;

        private string firstName;
        private string middleName;
        private string lastName;
        private string id;
        private string permanentAddress;
        private string mobilePhone;
        private string email;

        public Customer(string firstName, string middleName, string lastName, string id,
            string permanentAddress, string mobilePhone, string email, CustomerType customerType)
        {
            this.FirstName = firstName;
            this.MiddleName = middleName;
            this.LastName = lastName;
            this.Id = id;
            this.PermanentAddress = permanentAddress;
            this.MobilePhone = mobilePhone;
            this.Email = email;
            this.CustomerType = customerType;
            this.Payments = new List<Payment>();

        }


        public string FirstName
        {
            get { return this.firstName; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(nameof(this.firstName), "Enter valid first name.");
                }
                this.firstName = value;
            }
        }

        public string MiddleName
        {
            get { return this.middleName; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(nameof(this.middleName), "Enter valid middle name.");
                }
                this.middleName = value;
            }
        }

        public string LastName
        {
            get { return this.lastName; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(nameof(this.lastName), "Enter valid last name.");
                }
                this.lastName = value;
            }
        }

        //EGN - accepts only numbers
        public string Id
        {
            get { return this.id; }
            set
            {
                if (!IsAllDigits(value) || value.Length != IdLenght)
                {
                    throw new FormatException("Enter valid id.");
                }

                this.id = value;
            }
        }

        public string PermanentAddress
        {
            get { return this.permanentAddress; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(nameof(this.permanentAddress), "Enter valid permanent address.");
                }
                this.permanentAddress = value;
            }
        }

        public string MobilePhone
        {
            get { return this.mobilePhone; }
            set
            {
                if (!IsAllDigits(value) || value.Length < 10)
                {
                    throw new FormatException("Enter valid mobile phone.");
                }
                this.mobilePhone = value;
            }
        }

        public string Email
        {
            get { return this.email; }
            set
            {
                if (!IsValidEmail(value) || value.Length < MobilePhoneLength)
                {
                    throw new FormatException("Enter valid email.");
                }
                this.email = value;
            }
        }

        public ICollection<Payment> Payments { get; set; }

        public CustomerType CustomerType { get; set; }

        
        object ICloneable.Clone()
        {
            return this.Clone();
        }

        public Customer Clone()
        {

            var result = new Customer(this.FirstName, this.MiddleName, this.LastName,
                this.id, this.PermanentAddress, this.MobilePhone, this.Email, this.CustomerType);

            foreach (var payment in this.Payments)
            {
                result.Payments.Add(payment);
            }

            return result;

        }

        public int CompareTo(Customer other)
        {
            var thisFullName = $"{this.FirstName} {this.MiddleName} {this.LastName}";
            var otherFullName = $"{other.FirstName} {other.MiddleName} {other.LastName}";

            if (thisFullName != otherFullName)
            {
                return string.Compare(thisFullName, otherFullName, StringComparison.Ordinal);
            }
            if (this.Id != other.Id)
            {
                return string.Compare(this.Id, other.Id, StringComparison.Ordinal);
            }

            return 0;
        }

        public override bool Equals(object obj)
        {
            var customer = obj as Customer;
            
            if (customer == null
                || !Equals(this.FirstName, customer.FirstName)
                || !Equals(this.MiddleName, customer.MiddleName)
                || !Equals(this.LastName, customer.LastName)
                || !Equals(this.Id, customer.Id)
                || !Equals(this.MobilePhone, customer.MobilePhone)
                || !Equals(this.Email, customer.Email)
                || !Equals(this.CustomerType, customer.CustomerType))
            {
                return false;
            }

            var payments = this.Payments.SequenceEqual(customer.Payments);
            if (!payments)
            {
                return false;
            }

            return true;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = (FirstName != null ? FirstName.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (MiddleName != null ? MiddleName.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (LastName != null ? LastName.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Id != null ? Id.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (PermanentAddress != null ? PermanentAddress.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (MobilePhone != null ? MobilePhone.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Email != null ? Email.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (int)CustomerType;
                return hashCode;
            }
        }

        public static bool operator ==(Customer customerA, Customer customerB)
        {
            return Equals(customerA, customerB);
        }

        public static bool operator !=(Customer customerA, Customer customerB)
        {
            return !Equals(customerA, customerB);
        }

        public override string ToString()
        {
            var output = $"Name: {this.FirstName} {this.MiddleName} {this.LastName}\n" +
                         $"Id: {this.Id}\n" +
                         $"Address: {this.PermanentAddress}\n" +
                         $"Mobile phone: {this.MobilePhone}\n" +
                         $"E-mail: {this.Email}\n" +
                         $"Customer type: {this.CustomerType}\n" +
                         "Payments: ";

            if (this.Payments.Any())
            {
                foreach (var payment in this.Payments)
                {
                    output += $"\n    Product: {payment.ProducName}\n" +
                              $"    Price: {payment.Price} lv.\n";
                }
            }
            else
            {
                output += "N/A\n";
            }

            return output;
        }

        private static bool IsValidEmail(string emailaddress)
        {
            try
            {
                var m = new MailAddress(emailaddress);

                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }

        private static bool IsAllDigits(string digits)
        {
            var output = digits.All(char.IsDigit);
            return output;
        }
    }


}