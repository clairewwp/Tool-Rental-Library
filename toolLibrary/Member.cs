using System;
using static System.Console;
namespace ToolLibrary
{
    public class Member
    {
        private string firstName;
        private string lastName;
        private string phoneNumber;
        private string password;
        public int count = 0;
        private Tool[] toolholds;
        public void BorrowTool(string tool, int num)
        {
            if (count < 5)//each member only hold max 5 of tools
            {
                for (int i = 0; i < toolholds.Length; i++)
                {
                    if (toolholds[i] == null)
                    {
                        toolholds[i] = new Tool(tool, num);
                        count += num;
                        break;
                    }
                    if (toolholds[i].ToolName == tool)
                    {
                        toolholds[i].Quantity += num;
                        count += num;
                        break;
                    }
                }
            }
        }
     

        public void ReturnTool(string tool, int num)
        {
        
            for (int i = 0; i < toolholds.Length; i++)
            {
                if (toolholds[i].ToolName != null)
                {
                    if (toolholds[i].ToolName == tool && toolholds[i].Quantity >= num)
                    {
                        toolholds[i].Quantity -= num;
                        if (toolholds[i].Quantity == 0)
                            toolholds[i] = null;
                        break;
                        
                    }
                }
                else
                    WriteLine("Invalid input! ");
            }
           
            //int count = 0;
            //int hold = 0;
            //if (num - counter > 0)
            //{
            //    WriteLine("Quantity exceeded! \n");
            //}
            //for (int i = 0; i < holdTools.Length; i++)
            //{
            //    if (holdTools[count] != tool)
            //        count++;
            //    if (holdTools[count] == tool)
            //    {
            //        hold++;
            //        count++;
            //    }
            //        if (hold < num)
            //    {
            //        WriteLine("Quantity exceeded!");
            //        break;
            //    }
            //    else if (num > 0 && holdTools[count] == tool)
            //    {
            //        holdTools[count] = null;
            //        num--;
            //        count++;
            //    }
            //}
        }
        public void PrintBorrowing()
        {
            bool flag = false;
            for (int i = 0; i < 5; i++)
            {
                if (toolholds[i] != null)
                {
                    WriteLine(toolholds[i]);
                    flag = true;
                }
            }
            if (flag == false)
            {
                WriteLine("You are currently not holding any tools. ");
            }
        }
        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }
        public string LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }
        public string PhoneNumber
        {
            get { return phoneNumber; }
            set { phoneNumber = value; }
        }
        public string Password
        {
            get { return password; }
            set { password = value; }
        }
        public Tool[] Toolholds
        {
            get { return toolholds; }
        }
        //public List<string> HoldTools
        //{
        //    get { return holdTools; }
        //    set { holdTools = value; }
        //}
        //public void addTools(string toolName)
        //{
        //    holdTools.Add(toolName);

        //}
        //public void deleteTools(string toolName)
        //{
        //    holdTools.Remove(toolName);
        //}
        //public void addTools(string title) { }
        //public void deleteFromTools(string title) { }
        public Member() { }
        public Member(string firstName, string lastName, string phone, string password)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.phoneNumber = phone;
            this.password = password;
            toolholds = new Tool[5];
            //holdTools = new List<string>();
        }
        public int CompareTo(Member InputMember)
        {
            if (this.firstName.CompareTo(InputMember.FirstName) < 0)
                return -1;
            else
                if (this.firstName.CompareTo(InputMember.FirstName) == 0)
                return this.lastName.CompareTo(InputMember.LastName);
            else
                if (this.lastName.CompareTo(InputMember.LastName) == 0)
                return this.password.CompareTo(InputMember.Password);
            else
                return 1;
        }
        public override string ToString()
        {
            return FirstName.ToString() + " " +
                LastName.ToString() + " " +
                phoneNumber.ToString() + " " +
                password.ToString();
        }
    }
}
