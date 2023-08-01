using System;
using static System.Console;
namespace ToolLibrary
{
    public class MemberCollection
    {
        private Member[] members;
        public static Member currentLogged { get; private set; }
        private int count;
        private int buckets;
        public MemberCollection(int buckets)
        {
            if (buckets > 0)
            {

                this.buckets = buckets;
                count = 0;
                members = new Member[buckets];
            }
            for (int i = 0; i < buckets; i++)
            {
                members[i] = new Member("null", "null", "null", "null");
            }
        }
        public int Count
        {
            get { return count; }
        }
        public int Hashing(string key)
        {
            int k = Math.Abs(key.GetHashCode());
            return (k % buckets);
        }
        private int Find_Insertion_Buckets(string key)
        {
            int bucket = Hashing(key);
            int offset = 0;
            int i = 0;
            while (i < buckets && members[(bucket + offset) % buckets].FirstName != "null" &&
                members[((bucket + offset) % buckets)].FirstName != "deleted")
            {
                i++;
                offset++;
            }
            return (offset + bucket) % buckets;
        }
        //public void Register(string fName, string lName, string phone, string password)
        //{
        //    Member m = new Member(fName, lName, phone, password);
        //    members[memberAmount] = m;
        //    memberAmount++;
        //}
        public void Register(string fName, string lName, string phone, string password)
        {
            int bucket = Find_Insertion_Buckets(fName);
            if (Count < members.Length)
            {
                members[bucket] = new Member(fName, lName, phone, password);
                count++;
            }
        }
        public void SignUp()
        {
            Write("Please enter the member's first name >> ");
            string fName = ReadLine();
            Write("member's last name >> ");
            string lName = ReadLine();
            Write("member's phone number >> ");
            string phone = ReadLine();
            Write("member's password >> ");
            string password = ReadLine();
            
                if (Count < members.Length && SearchMember(fName) == -1)
                {
                    //WriteLine(Count);
                    //WriteLine(members.Length);
                    int bucket = Find_Insertion_Buckets(fName);
                    //WriteLine(bucket);
                    members[bucket] = new Member(fName, lName, phone, password);
                    count++;
                    //currentLogged.FirstName = fName;
                    WriteLine("Registration Successful");
                    Print();
                }
                else { WriteLine("The key has already been in the hashtable or the hashtable is full"); }
           
            

        }
        public void Print()
        {
            WriteLine("==========Members list==========");
            for (int i = 0; i < buckets; i++)
            {
                if (members[i].FirstName == "null" || members[i].FirstName == "deleted")
                {
                    //members[i].FirstName = "___";
                    //members[i].LastName = "___";
                    //members[i].PhoneNumber = "___";
                    //members[i].Password = "___";
                    WriteLine((i + 1).ToString() + " " + members[i] + "\n");
                }
                else
                {
                    WriteLine((i + 1).ToString() + " " + members[i] + "\n");
                }
            }
            WriteLine("=======================================");
        }
        public void Return()
        {
            bool flag = true;
            while (flag)
            {
                WriteLine(" ");
                WriteLine("Enter 0 to return to previous menu");
                string back = ReadLine();
                if (back == "0")
                {
                    Program.StaffMenu();
                    flag = false;
                }
                else
                {
                    WriteLine("Invalid input, please re-enter 0 to return staff menu");
                }
            }
        }
        public void Delete()
        {
            Print();
            Write("Please enter the first name of the member for removing >> ");
            string fName = ReadLine();
            int bucket = SearchMember(fName);
            //WriteLine(bucket); WriteLine(fName);
            int counter=0;
            for (int i = 0; i < members.Length; i++)
            {
                if (members[i].FirstName == "deleted")
                    counter++;
                while (counter == members.Length-1)
                {
                    WriteLine("There is no member at the moment. ");
                    break;
                }
            }
            if (bucket != -1)
            {
                members[bucket] = new Member("deleted", "deleted", "deleted", "deleted");
                count--;
                WriteLine("The member has been deleted successfully!");
            } 
            else
            {
                WriteLine("The member does not exist");
            }
        }
        public int SearchMember(string key)
        {
            int bucket = Hashing(key);

            int i = 0;
            int offset = 0;
            while ((i < buckets) &&
                (members[(bucket + offset) % buckets].FirstName != key)
                )
            {
                i++;
                offset++;
            }
            if (members[(bucket + offset) % buckets].FirstName == key)
            {
                return (offset + bucket) % buckets;
            }
            else
                return -1;
        }
        public void GetBorrowers()
        {
            int count = 0;
            for (int i = 0; i < members.Length; i++)
            {
                if (members[i].Toolholds[0] != null)
                {
                    WriteLine("{0} is currently holding :", members[i].FirstName);
                    members[i].PrintBorrowing();
                    WriteLine("--------------------------------");
                }
                else
                {
                    count++;
                    if (count >= members.Length)
                    {
                        WriteLine(members[i].Toolholds[0]);
                        WriteLine("No member is currently holding any tools. ");
                        break;
                    }
                   
                }
            }
        }
        public void FindAMember()
        {
            Write("Please enter the first name of the member for the contact detail >> ");
            string fName = ReadLine();
            int bucket = SearchMember(fName);
            if (bucket != -1)
            {
                WriteLine(members[bucket].FirstName + " " + members[bucket].LastName + " " + members[bucket].PhoneNumber);
                Return();
            }
            else
            {
                WriteLine("The member does not exist \n");
                FindAMember();
            }

        }
        public void Memberlogin()
        {
            Write("Please enter your first name >> ");
            string fName = ReadLine();
            Write("your last name >> ");
            string lName = ReadLine();
            Write("your password >> ");
            string pWord = ReadLine();
            string phoneNumber = "";
            WriteLine(" ");
            Member aMember = new Member(fName, lName, phoneNumber, pWord);
            bool log = false;
            for (int i = 0; i < members.Length; i++)
            {
                if (members[i].CompareTo(aMember) == 0)
                {
                    while (members[i].Password.CompareTo(aMember.Password) == 0)
                    {
                        log = true;
                        WriteLine("Logged In successfully \n");
                        currentLogged = members[i];
                        Program.MemberMenu(aMember.FirstName);
                    }
                }
            }
            if (log == false)
            {
                WriteLine("The information is either incorrect or does not exist! ");
                Memberlogin();
            }


        }

    }

}
