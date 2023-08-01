using System;
using static System.Console;
namespace ToolLibrary
{
    public class ToolCollection
    {
        private Tool[,,] tools;
        public Tool[] borrowed;
        public ToolCollection()
        {
            tools = new Tool[9, 6, 15];//the length of the tool itself is 15, and 9, 6 do not really matter
            borrowed = new Tool[19];
        }
        public void AddTools(int category, int type, string toolName, int quantity)
        {
            for (int i = 0; i < 15; i++)
            {
                if (tools[category, type, i] == null)
                {
                    tools[category, type, i] = new Tool(toolName, quantity);
                    tools[category, type, i].Availability = tools[category, type, i].Quantity;
                    break;
                }
                if (tools[category, type, i].ToolName == toolName)
                {
                    tools[category, type, i].Quantity += quantity;
                    tools[category, type, i].Availability += quantity;
                    break;
                }
            }
        }
        public void RemoveTools()
        {
            //if (SearchThrough() != "null")
            //{
            //    if (SearchThrough() == toolName && tools[i, j, k].Quantity > 0)
            //    {

            //        if ((tools[i, j, k].Quantity - quantity) >= 0)
            //        {
            //            tools[i, j, k].Quantity -= quantity;//if after the reduction, the quantity is positive
            //        }
            //        else
            //        {
            //            WriteLine("Invalid quantity, please re-enter!");
            //            WriteLine("------------------------------------------------");
            //            RemoveTools();
            //        }
            //    }
            //}
            bool flag = false;
            Write("Enter the name of the tool to remove >> ");
            string toolName = ReadLine();
            Write("Enter the quantity you want to remove >> ");
            int quantity = Convert.ToInt32(ReadLine());
            WriteLine(" ");
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    for (int k = 0; k < 15; k++)
                    {
                        if (tools[i, j, k] != null)
                        {
                            if (tools[i, j, k].ToolName == toolName && tools[i, j, k].Availability >= 0)
                            {
                                flag = true;
                                if ((tools[i, j, k].Availability - quantity) >= 0)
                                {
                                    tools[i, j, k].Availability -= quantity;//if after the reduction, the quantity is positive
                                    tools[i, j, k].Quantity -= quantity;
                                }
                                else
                                {
                                    WriteLine("Insufficient quantity, operation fail!");
                                    WriteLine("------------------------------------------------");
                                    RemoveTools();
                                }
                            }
                        }
                    }
                }
            }
            if (flag == false)
            {
                WriteLine("The tool does not exist!! ");
                RemoveTools();
            }
            //for (int i = 0; i < 15; i++)
            //{
            //    if (tools[category, type, i].ToolName == toolName)
            //    {
            //        if (tools[category, type, i].Quantity > 0)
            //            tools[category, type, i].Quantity -= quantity;
            //        else
            //            WriteLine("The tool does not existed!");
            //        break;
            //    }
            //}
        }
        public void Print()
        {
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    for (int k = 0; k < 15; k++)
                    {
                        if (tools[i, j, k] != null)
                        {
                            WriteLine(tools[i, j, k]);
                        }
                    }
                }
            }
        }
        public void PrintAll()
        {
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    for (int k = 0; k < 15; k++)
                    {
                        if (tools[i, j, k] != null)
                        {
                            WriteLine(tools[i, j, k] + " Availability: " + tools[i, j, k].Availability);
                        }
                    }
                }
            }
        }
        public void Borrow(string name)
        {
            bool success = false;
            WriteLine("==========List of all tools==========");
            PrintAll();
            WriteLine("\n ** Each person can only hold 5 items **");
            WriteLine("====================================");
            if (5 - MemberCollection.currentLogged.count == 0)
                WriteLine("You have already borrowed 5 tools! ");
            else
            {
                WriteLine("You can still borrow {0} tools", 5 - MemberCollection.currentLogged.count);
                Write("Enter the tool name you wish to borrow >> ");
                string toolName = ReadLine();
                Write("How many do you wish to borrow? >> ");
                int number = Convert.ToInt32(ReadLine());
                for (int i = 0; i < 9; i++)
                {
                    for (int j = 0; j < 6; j++)
                    {
                        for (int k = 0; k < 15; k++)
                        {
                            
                            if (tools[i, j, k] != null && (number <= 5 && number > 0) && MemberCollection.currentLogged.count + number <= 5)
                            {
                                if (tools[i, j, k].ToolName == toolName && tools[i, j, k].Availability >= number)
                                {
                                    tools[i, j, k].Availability -= number;
                                    MemberCollection.currentLogged.BorrowTool(toolName, number);//this is to connect the currentuser with his/her tool bucket
                                    WriteLine("====Your current holding list====");
                                    MemberCollection.currentLogged.PrintBorrowing();
                                    WriteLine("=======================================\n");
                                    success = true;
                                    tools[i, j, k].BorrowedTimes += number;//setting the borrowed times for each tool in order to display top 3 frequent
                                    //WriteLine(tools[i, j, k].BorrowedTimes);
                                }
                            }
                        }
                    }
                }
                if (success == true)
                    WriteLine("\nTool borrowed successfully\n");
                else
                    WriteLine("Invalid input! \n");
            }
            PrintAll();
            ReturntoMemberMenu(name);
        }
        public void DisplayCurrentHolds(string name)
        {
            MemberCollection.currentLogged.PrintBorrowing();
            ReturntoMemberMenu(name);
        }
        public void ReturnTools(string name)
        {
            bool success = false;
            WriteLine("==========List of all tools==========");
            PrintAll();
            WriteLine("====================================");
            Write("You currently hold {0} tools\n", MemberCollection.currentLogged.count);
            MemberCollection.currentLogged.PrintBorrowing();
            WriteLine("====================================");
            if (MemberCollection.currentLogged.count <= 0)
                WriteLine("You have no tool to return! ");
            else
            {
                Write("Enter the tool name to return >> ");
                string toolName = ReadLine();
                Write("The number you wish to return >> ");
                int number = Convert.ToInt32(ReadLine());
                for (int i = 0; i < 9; i++)
                {
                    for (int j = 0; j < 6; j++)
                    {
                        for (int k = 0; k < 15; k++)
                        {
                            if (tools[i, j, k] != null && (number <= 5 && number > 0) && MemberCollection.currentLogged.count >= number)
                            {
                                if (tools[i, j, k].ToolName == toolName)
                                {
                                    tools[i, j, k].Availability += number;
                                    MemberCollection.currentLogged.ReturnTool(toolName, number);
                                    WriteLine("====Your current holding list====");
                                    MemberCollection.currentLogged.PrintBorrowing();
                                    WriteLine("=======================================\n\n");
                                    success = true;
                                }
                            }
                        }
                    }
                }
                if (success == true)
                    WriteLine("\nTool returned successfully!\n");
                else
                    WriteLine("Invalid input! \n");
            }
            PrintAll();
            ReturntoMemberMenu(name);
        }
        public void GetBorrowedTimes(string name)
        {   
            int x = 0;
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    for (int k = 0; k < 15; k++)
                    {
                        if (tools[i, j, k] != null)
                        {
                            if (tools[i, j, k].BorrowedTimes > 0)
                            {
                                borrowed[x] = new Tool(tools[i, j, k].ToolName, tools[i, j, k].BorrowedTimes);
                                //WriteLine(borrowed[x]);
                                x++;
                               // break;
                            }
                            //for (int x = 0; x < borrowed.Length; x++)
                            //{
                            //    if (borrowed[x] == null)
                            //    {
                            //        if (tools[i, j, k].BorrowedTimes >0)
                            //        {
                            //            borrowed[x] = new Tool(tools[i, j, k].ToolName, tools[i, j, k].BorrowedTimes);
                            //            WriteLine(borrowed[x]);
                            //            //x++;
                            //            break;
                            //        }
                            //        else if (tools[i, j, k].BorrowedTimes == 0)
                            //        {
                            //            borrowed[x] = new Tool("", 0);
                            //            //break; 
                            //        }
                            //    }

                            //}
                            //if (tools[i,j,k])
                        }
                    }
                }
            }for (int y = 0; y < borrowed.Length; y++)//to avoid the null in the array by filling out with "" and 0 
            {
                if (borrowed[y] == null)
                {
                    borrowed[y] = new Tool("", 0);
                }
            }
            TopThree(borrowed, name);
        }
        public void TopThree(Tool[] borrowed,string name)
        {
            WriteLine("===Top 3 frequent borrowed tools===\n");
            Tool[] top3;
            HeapSort(borrowed);
            if (borrowed.Length > 3)
                top3 = new Tool[3];
            else
                top3 = new Tool[borrowed.Length];
            for (int i = 0; i < top3.Length; i++)
                top3[i] = borrowed[i];
            PrintTop3(top3);
            ReturntoMemberMenu(name);
        }
        private void HeapSort(Tool[] borrowed)
        {
            int borrow = borrowed.Length;
            for (int i = borrow/2-1; i >= 0; i--)
                Heapify(borrowed, borrow, i);
            for (int i = borrow-1; i >= 0; i--)
            {
                Tool temp = borrowed[0];
                borrowed[0] = borrowed[i];
                borrowed[i] = temp;
                Heapify(borrowed, i, 0);
            }
        }
        private void Heapify(Tool[] borrowed, int heapSize, int root)
        {
            int smallest = root;
            int left = 2 * root + 1;
            int right = 2 * root + 2;
            for (int i = 0; i < borrowed.Length; i++)
            {
                if (borrowed[i] != null)
                {
                    if (left < heapSize && borrowed[left].Quantity < borrowed[smallest].Quantity)
                        smallest = left;
                    if (right < heapSize && borrowed[right].Quantity < borrowed[smallest].Quantity)
                        smallest = right;
                    if (smallest != root)
                    {
                        Tool change = borrowed[root];
                        borrowed[root] = borrowed[smallest];
                        borrowed[smallest] = change;
                        Heapify(borrowed, heapSize, smallest);
                    }
                }
            }
        }
        public void PrintTop3(Tool[] borrowed)
        {
            for (int i = 0; i < borrowed.Length; ++i)
            {
                if (borrowed[i].ToolName == "")
                {
                    WriteLine("{0,20}", "Empty");
                   // break;
                }
                else
                    WriteLine ("{0,8}. {1} Borrowed times: {2}",i+1,borrowed[i].ToolName,borrowed[i].Quantity);          
            }
            WriteLine("\n===================================");
        }
        public void DisplayCategory(int category, int type, string name)
        {
            bool flag = false;
            for (int i = 0; i < 15; i++)
            {
                if (tools[category, type, i] != null)
                {
                    WriteLine(tools[category, type, i]);
                    flag = true;
                }
            }
            if (flag == false)
            {
                WriteLine("There is no tool under the type! \n");
                Program.SelectFromCollection(name);
            }
            Program.SelectFromCollection(name);
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
        public void ReturntoMemberMenu(string name)
        {
            bool flag = true;
            while (flag)
            {
                WriteLine(" ");
                WriteLine("Enter 0 to return to previous menu");
                string back = ReadLine();
                if (back == "0")
                {
                    Clear();
                    Program.MemberMenu(name);
                    flag = false;
                }
                else if (back == "S")
                {
                    Clear();
                    Borrow(name);
                }
                else
                {
                    WriteLine("Invalid input, please re-enter 0 to return Member menu");
                }
            }
        }
        public override string ToString()
        {
            return base.ToString();
        }
    }
}
