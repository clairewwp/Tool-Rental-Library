using System;
using static System.Console;
namespace ToolLibrary
{
    class Program
    {
        public static MemberCollection memberData = new MemberCollection(10);
        public static ToolCollection toolData = new ToolCollection();

        static void Main(string[] args)
        {

            //create some existing members initially
            memberData.Register("Claire", "Wang", "88888888", "123");
            memberData.Register("Irene", "Chen", "77777777", "456");
            memberData.Register("Jarry", "Tsai", "66666666", "789");
            memberData.Register("Lisa", "Tien", "55555555", "234");
            memberData.Register("Rita", "Chiang", "33333333", "567");
            MainMenu();

        }
        public static void MainMenu()
        {
            bool flag = true;
            while (flag)
            {
                WriteLine("Welcome to the Tool Library System \n");
                WriteLine("==============Main Menu==============");
                WriteLine("1.Staff  login");//V
                WriteLine("2.Member login");//V
                WriteLine("0.Exit");//V
                WriteLine("=====================================");
                Write("Select an option from the menu or enter 0 to exit >> ");
                switch (GetStringOption())
                {
                    case "0": //exit
                        Environment.Exit(0);
                        break;
                    case "1":
                        Clear();
                        StaffLogin();
                        break;
                    case "2":
                        Clear();
                        memberData.Memberlogin();
                        break;
                    default:
                        WriteLine("There is no such option, please re-select! ");
                        break;
                }
            }
        }
        public static string GetStringOption()
        {
            while (true)
            {
                try
                {
                    string v = ReadLine();
                    string opt = v;
                    return opt;
                }
                catch (Exception e)
                {
                    WriteLine("Please input a valid number, as the " + e.Message);
                }
            }
        }
        public static int GetIntOption()
        {
            while (true)
            {
                try
                {
                    int opt = Convert.ToInt32(ReadLine());
                    return opt;
                }
                catch (Exception e)
                {
                    WriteLine("Please input a valid number, as the " + e.Message);
                }
            }
        }
        public static void StaffLogin()
        {
            //StaffMenu();
            Write("Please enter your username >> ");
            string userName = ReadLine();
            Write("your password >>");
            string password = ReadLine();
            WriteLine("");
            //StaffMenu();
            if (userName == "staff" && password == "today123")
            {//staff info is hardcoded
                StaffMenu();
                // ReadKey();
            }
            else
            {
                WriteLine("Incorrect username or password, please re-enter ! \n");
                StaffLogin();
            }
        }

        public static void StaffMenu()
        {
            Clear();
            WriteLine("==============Staff Menu==============");
            WriteLine("1.Add a tool");//V
            WriteLine("2.Remove a tool");//V
            WriteLine("3.Register a new member");//V
            WriteLine("4.Remove a member by the phone number");//V
            WriteLine("5.Display all members who are currently borrowing a tool");
            WriteLine("6.Find the phone number of a specific member");//V
            WriteLine("7.Test the time efficiency");
            WriteLine("0.Return to the main menu");//V
            WriteLine("E.Exit");//V
            WriteLine("=====================================");
            Write("Select an option from the menu or enter E to exit >> ");
            switch (GetStringOption().ToUpper())
            {
                case "0"://return to the main menu
                    Clear();
                    MainMenu();
                    break;
                case "1"://Add a tool
                    Clear();
                    toolData.AddTools(0, 0, "tool1", 1);
                    toolData.AddTools(0, 0, "tool1", 8);
                    toolData.AddTools(0, 0, "tool2", 3);
                    toolData.AddTools(0, 0, "tool2", 4);
                    toolData.AddTools(0, 1, "tool3", 2);
                    toolData.AddTools(0, 1, "tool4", 4);

                    toolData.AddTools(1, 0, "toolA", 2);
                    toolData.AddTools(1, 1, "toolB", 4);
                    toolData.AddTools(1, 2, "toolC", 5);
                    toolData.AddTools(1, 3, "toolD", 7);
                    toolData.AddTools(1, 4, "toolE", 8);
                    toolData.PrintAll();
                    toolData.Return();
                    break;
                case "2"://Remove a tool
                    Clear();
                    toolData.PrintAll();
                    toolData.RemoveTools();
                    WriteLine("==========After removing the tool(s)==========");
                    toolData.PrintAll();
                    toolData.Return();
                    break;
                case "3"://Register a new member
                    Clear();
                    memberData.SignUp();
                    memberData.Return();
                    break;
                case "4"://Remove a member
                    Clear();
                    memberData.Delete();
                    memberData.Return();
                    break;
                case "5"://Display all members who are currently borrowing a tool
                    Clear();
                    memberData.GetBorrowers();
                    memberData.Return();
                    break;
                case "6"://Find the phone number of a specific member
                    Clear();
                    memberData.FindAMember();
                    break;
                case "7"://Test the time efficiency
                    Clear();
                    TestEfficiency();
                    break;
                case "E"://Exit the whole system
                    Clear();
                    Environment.Exit(0);
                    break;
                default:
                    WriteLine("There is no such option, please re-select! ");
                    break;
            }
        }
        public static void MemberMenu(string name)
        {

            WriteLine("{0,11}Welcome - {1} -", " ", name);
            WriteLine("\n==============Member Menu==============");
            WriteLine("1.Display tools under a specific type");//V
            WriteLine("2.Borrow a tool");//V
            WriteLine("3.Return a tool");
            WriteLine("4.My current borrowing list");//V
            WriteLine("5.Display top three most frequently borrowed tools");
            WriteLine("0.Return to the main menu");//V
            WriteLine("E.Exit");//V
            WriteLine("=====================================");
            Write("Select an option from the menu or enter E to exit >> ");
            switch (GetStringOption().ToUpper())
            {
                case "0": //return to the main menu
                    Clear();
                    MainMenu();
                    break;
                case "1"://Display tools under a specific type
                    Clear();
                    SelectFromCollection(name);
                    break;
                case "2"://Borrow a tool
                    Clear();
                    toolData.Borrow(name);
                    break;
                case "3"://Return a tool
                    Clear();
                    toolData.ReturnTools(name);
                    break;
                case "4"://My current borrowing list
                    Clear();
                    toolData.DisplayCurrentHolds(name);
                    break;
                case "5"://Display top three most frequently borrowed tools
                    Clear();
                    toolData.GetBorrowedTimes(name);
                    //toolData.TopThree(name);
                    break;
                case "E"://exit the whole system
                    Clear();
                    Environment.Exit(0);
                    break;
                default:
                    WriteLine("There is no such option, please re-select! ");
                    break;
            }
        }
        public static void SelectFromCollection(string name)
        {
            WriteLine("==========Tool Category==========");
            WriteLine("1. Gardening Tools");
            WriteLine("2. Flooring Tools");
            WriteLine("3. Fencing Tools");
            WriteLine("4. Measuring Tools");
            WriteLine("5. Cleaning Tools");
            WriteLine("6. Painting Tools");
            WriteLine("7. Electronic Tools");
            WriteLine("8. Elecricity Tools");
            WriteLine("9. Automotive Tools");
            WriteLine("");
            WriteLine("0. Return to the main menu");
            WriteLine("========================================");
            Write("Select an option from the menu >> ");
            int category;
            int type;
            switch (GetIntOption())
            {
                case 0:
                    Clear();
                    MemberMenu(name);
                    break;
                case 1:
                    Clear();
                    WriteLine("==========Tool Types under " + "Gardening tools" + "==========");
                    WriteLine("1. Line Trimmers");
                    WriteLine("2. Lawn Mowers");
                    WriteLine("3. Hand Tools");
                    WriteLine("4. Wheelbarrows");
                    WriteLine("5. Garden Power Tools");
                    WriteLine("");
                    WriteLine("0. Return to previous menu");
                    WriteLine("========================================");
                    Write("Select an option from the menu >> ");
                    switch (GetIntOption())
                    {
                        case 0:
                            Clear();
                            SelectFromCollection(name);
                            break;
                        case 1:
                            Clear();
                            category = 0;
                            type = 0;
                            toolData.DisplayCategory(category, type, name);
                            // WriteLine("category: {0}, type: {1}", category, type);
                            break;
                        case 2:
                            Clear();
                            category = 0;
                            type = 1;
                            toolData.DisplayCategory(category, type, name);
                            break;
                        case 3:
                            Clear();
                            category = 0;
                            type = 2;
                            toolData.DisplayCategory(category, type, name);
                            break;
                        case 4:
                            Clear();
                            category = 0;
                            type = 3;
                            toolData.DisplayCategory(category, type, name);
                            break;
                        case 5:
                            Clear();
                            category = 0;
                            type = 4;
                            toolData.DisplayCategory(category, type, name);
                            break;
                        default:
                            WriteLine("There is no such option, please re-select! ");
                            break;
                    }
                    break;
                case 2:
                    Clear();
                    WriteLine("==========Tool Types under " + "Flooring tools" + "==========");
                    WriteLine("1. Scrapers");
                    WriteLine("2. Floor Lasers");
                    WriteLine("3. Floor Levelling Tools");
                    WriteLine("4. Floor Levelling Materials");
                    WriteLine("5. Floor Hand Tools");
                    WriteLine("6. Floor Hand Tools");
                    WriteLine("");
                    WriteLine("0. Return to previous menu");
                    WriteLine("========================================");
                    Write("Select an option from the menu >> ");
                    switch (GetIntOption())
                    {
                        case 0:
                            Clear();
                            SelectFromCollection(name);
                            break;
                        case 1:
                            Clear();
                            category = 1;
                            type = 0;
                            toolData.DisplayCategory(category, type, name);
                            break;
                        case 2:
                            Clear();
                            category = 1;
                            type = 1;
                            toolData.DisplayCategory(category, type, name);
                            break;
                        case 3:
                            Clear();
                            category = 1;
                            type = 2;
                            toolData.DisplayCategory(category, type, name);
                            break;
                        case 4:
                            Clear();
                            category = 1;
                            type = 3;
                            toolData.DisplayCategory(category, type, name);
                            break;
                        case 5:
                            Clear();
                            category = 1;
                            type = 4;
                            toolData.DisplayCategory(category, type, name);
                            break;
                        case 6:
                            Clear();
                            category = 1;
                            type = 5;
                            toolData.DisplayCategory(category, type, name);
                            break;
                        default:
                            WriteLine("There is no such option, please re-select! ");
                            break;
                    }
                    break;
                case 3:
                    Clear();
                    WriteLine("==========Tool Types under " + "Fencing tools" + "==========");
                    WriteLine("1. Hand Tools");
                    WriteLine("2. Electric Fencing");
                    WriteLine("3. Steel Fencing Tools");
                    WriteLine("4. Power Tools");
                    WriteLine("5. Fencing Accessories");
                    WriteLine("");
                    WriteLine("0. Return to previous menu");
                    WriteLine("========================================");
                    Write("Select an option from the menu >> ");
                    switch (GetIntOption())
                    {
                        case 0:
                            Clear();
                            SelectFromCollection(name);
                            break;
                        case 1:
                            Clear();
                            category = 2;
                            type = 0;
                            toolData.DisplayCategory(category, type, name);
                            break;
                        case 2:
                            Clear();
                            category = 2;
                            type = 1;
                            toolData.DisplayCategory(category, type, name);
                            break;
                        case 3:
                            Clear();
                            category = 2;
                            type = 2;
                            toolData.DisplayCategory(category, type, name);
                            break;
                        case 4:
                            Clear();
                            category = 2;
                            type = 3;
                            toolData.DisplayCategory(category, type, name);
                            break;
                        case 5:
                            Clear();
                            category = 2;
                            type = 4;
                            toolData.DisplayCategory(category, type, name);
                            break;
                        default:
                            WriteLine("There is no such option, please re-select! ");
                            break;
                    }
                    break;
                case 4:
                    Clear();
                    WriteLine("==========Tool Types under " + "Measuring tools" + "==========");
                    WriteLine("1. Distance Tools");
                    WriteLine("2. Laser Measurer");
                    WriteLine("3. Measuring Jugs");
                    WriteLine("4. Temperature & Humidity Tools");
                    WriteLine("5. Levelling Tools");
                    WriteLine("6. Markers");
                    WriteLine("");
                    WriteLine("0. Return to previous menu");
                    WriteLine("========================================");
                    Write("Select an option from the menu >> ");
                    switch (GetIntOption())
                    {
                        case 0:
                            Clear();
                            SelectFromCollection(name);
                            break;
                        case 1:
                            Clear();
                            category = 3;
                            type = 0;
                            toolData.DisplayCategory(category, type, name);
                            break;
                        case 2:
                            Clear();
                            category = 3;
                            type = 1;
                            toolData.DisplayCategory(category, type, name);
                            break;
                        case 3:
                            Clear();
                            category = 3;
                            type = 2;
                            toolData.DisplayCategory(category, type, name);
                            break;
                        case 4:
                            Clear();
                            category = 3;
                            type = 3;
                            toolData.DisplayCategory(category, type, name);
                            break;
                        case 5:
                            Clear();
                            category = 3;
                            type = 4;
                            toolData.DisplayCategory(category, type, name);
                            break;
                        case 6:
                            Clear();
                            category = 3;
                            type = 5;
                            toolData.DisplayCategory(category, type, name);
                            break;
                        default:
                            WriteLine("There is no such option, please re-select! ");
                            break;
                    }
                    break;
                case 5:
                    Clear();
                    WriteLine("==========Tool Types under " + "Cleaning tools" + "==========");
                    WriteLine("1. Draining");
                    WriteLine("2. Car Cleaning");
                    WriteLine("3. Vaccum");
                    WriteLine("4. Pressure Cleaners");
                    WriteLine("5. Pool Cleaning");
                    WriteLine("6. Floor Cleaning");
                    WriteLine("");
                    WriteLine("0. Return to previous menu");
                    WriteLine("========================================");
                    Write("Select an option from the menu >> ");
                    switch (GetIntOption())
                    {
                        case 0:
                            Clear();
                            SelectFromCollection(name);
                            break;
                        case 1:
                            Clear();
                            category = 4;
                            type = 0;
                            toolData.DisplayCategory(category, type, name);
                            break;
                        case 2:
                            Clear();
                            category = 4;
                            type = 1;
                            toolData.DisplayCategory(category, type, name);
                            break;
                        case 3:
                            Clear();
                            category = 4;
                            type = 2;
                            toolData.DisplayCategory(category, type, name);
                            break;
                        case 4:
                            Clear();
                            category = 4;
                            type = 3;
                            toolData.DisplayCategory(category, type, name);
                            break;
                        case 5:
                            Clear();
                            category = 4;
                            type = 4;
                            toolData.DisplayCategory(category, type, name);
                            break;
                        case 6:
                            Clear();
                            category = 4;
                            type = 5;
                            toolData.DisplayCategory(category, type, name);
                            break;
                        default:
                            WriteLine("There is no such option, please re-select! ");
                            break;
                    }
                    break;
                case 6:
                    Clear();
                    WriteLine("==========Tool Types under " + "Painting tools" + "==========");
                    WriteLine("1. Sanding Tools");
                    WriteLine("2. Brushes");
                    WriteLine("3. Rollers");
                    WriteLine("4. Paint Removal Tools");
                    WriteLine("5. Paint Scrapers");
                    WriteLine("6. Sprayers");
                    WriteLine("");
                    WriteLine("0. Return to previous menu");
                    WriteLine("========================================");
                    Write("Select an option from the menu >> ");
                    switch (GetIntOption())
                    {
                        case 0:
                            Clear();
                            SelectFromCollection(name);
                            break;
                        case 1:
                            Clear();
                            category = 5;
                            type = 0;
                            toolData.DisplayCategory(category, type, name);
                            break;
                        case 2:
                            Clear();
                            category = 5;
                            type = 1;
                            toolData.DisplayCategory(category, type, name);
                            break;
                        case 3:
                            Clear();
                            category = 5;
                            type = 2;
                            toolData.DisplayCategory(category, type, name);
                            break;
                        case 4:
                            Clear();
                            category = 5;
                            type = 3;
                            toolData.DisplayCategory(category, type, name);
                            break;
                        case 5:
                            Clear();
                            category = 5;
                            type = 4;
                            toolData.DisplayCategory(category, type, name);
                            break;
                        case 6:
                            Clear();
                            category = 5;
                            type = 5;
                            toolData.DisplayCategory(category, type, name);
                            break;
                        default:
                            WriteLine("There is no such option, please re-select! ");
                            break;
                    }
                    break;
                case 7:
                    Clear();
                    WriteLine("==========Tool Types under " + "Electronic tools" + "==========");
                    WriteLine("1. Voltage Tester");
                    WriteLine("2. Oscilloscopes");
                    WriteLine("3. Thermal Imaging");
                    WriteLine("4. Data Test Tool");
                    WriteLine("5. Insulation Testers");
                    WriteLine("");
                    WriteLine("0. Return to previous menu");
                    WriteLine("========================================");
                    Write("Select an option from the menu >> ");
                    switch (GetIntOption())
                    {
                        case 0:
                            Clear();
                            SelectFromCollection(name);
                            break;
                        case 1:
                            Clear();
                            category = 6;
                            type = 0;
                            toolData.DisplayCategory(category, type, name);
                            break;
                        case 2:
                            Clear();
                            category = 6;
                            type = 1;
                            toolData.DisplayCategory(category, type, name);
                            break;
                        case 3:
                            Clear();
                            category = 6;
                            type = 2;
                            toolData.DisplayCategory(category, type, name);
                            break;
                        case 4:
                            Clear();
                            category = 6;
                            type = 3;
                            toolData.DisplayCategory(category, type, name);
                            break;
                        case 5:
                            Clear();
                            category = 6;
                            type = 4;
                            toolData.DisplayCategory(category, type, name);
                            break;
                        default:
                            WriteLine("There is no such option, please re-select! ");
                            break;
                    }
                    break;
                case 8:
                    Clear();
                    WriteLine("==========Tool Types under " + "Electricity tools" + "==========");
                    WriteLine("1. Test Equipment");
                    WriteLine("2. Safety Equipment");
                    WriteLine("3. Basic Hand Tools");
                    WriteLine("4. Circuit Protection");
                    WriteLine("5. Cable Tools");
                    WriteLine("");
                    WriteLine("0. Return to previous menu");
                    WriteLine("========================================");
                    Write("Select an option from the menu >> ");
                    switch (GetIntOption())
                    {
                        case 0:
                            Clear();
                            SelectFromCollection(name);
                            break;
                        case 1:
                            Clear();
                            category = 7;
                            type = 0;
                            toolData.DisplayCategory(category, type, name);
                            break;
                        case 2:
                            Clear();
                            category = 7;
                            type = 1;
                            toolData.DisplayCategory(category, type, name);
                            break;
                        case 3:
                            Clear();
                            category = 7;
                            type = 2;
                            toolData.DisplayCategory(category, type, name);
                            break;
                        case 4:
                            Clear();
                            category = 7;
                            type = 3;
                            toolData.DisplayCategory(category, type, name);
                            break;
                        case 5:
                            Clear();
                            category = 7;
                            type = 4;
                            toolData.DisplayCategory(category, type, name);
                            break;
                        default:
                            WriteLine("There is no such option, please re-select! ");
                            break;
                    }
                    break;
                case 9:
                    Clear();
                    WriteLine("==========Tool Types under " + "Automotive tools" + "==========");
                    WriteLine("1. Jacks");
                    WriteLine("2. Air Compressors");
                    WriteLine("3. Battery Chargers");
                    WriteLine("4. Socket Tools");
                    WriteLine("5. Braking");
                    WriteLine("6. Drivetrain");
                    WriteLine("");
                    WriteLine("0. Return to previous menu");
                    WriteLine("========================================");
                    Write("Select an option from the menu >> ");
                    switch (GetIntOption())
                    {
                        case 0:
                            Clear();
                            SelectFromCollection(name);
                            break;
                        case 1:
                            Clear();
                            category = 8;
                            type = 0;
                            toolData.DisplayCategory(category, type, name);
                            break;
                        case 2:
                            Clear();
                            category = 8;
                            type = 1;
                            toolData.DisplayCategory(category, type, name);
                            break;
                        case 3:
                            Clear();
                            category = 8;
                            type = 2;
                            toolData.DisplayCategory(category, type, name);
                            break;
                        case 4:
                            Clear();
                            category = 8;
                            type = 3;
                            toolData.DisplayCategory(category, type, name);
                            break;
                        case 5:
                            Clear();
                            category = 8;
                            type = 4;
                            toolData.DisplayCategory(category, type, name);
                            break;
                        case 6:
                            Clear();
                            category = 8;
                            type = 5;
                            toolData.DisplayCategory(category, type, name);
                            break;
                        default:
                            WriteLine("There is no such option, please re-select! ");
                            break;
                    }
                    break;
                default:
                    WriteLine("There is no such option, please re-select! ");
                    break;
            }
        }
        private static void TestEfficiency()
        {
            DateTime endTime, startTime;
            ToolCollection testTool1 = new ToolCollection();
            ToolCollection testTool2 = new ToolCollection();
            ToolCollection testTool3 = new ToolCollection();
            ToolCollection testTool4 = new ToolCollection();
            ToolCollection testTool5 = new ToolCollection();
            WriteLine("\n===Test the efficiency of adding a tool===\n");
            startTime = DateTime.Now;
            for (int x = 0; x < 1000; x++)
                testTool1.AddTools(0, 0, "tool1", 1);
            endTime = DateTime.Now;
            startTime = DateTime.Now;
            testTool1.AddTools(0, 0, "tool1", 1);
            endTime = DateTime.Now;
            WriteLine(String.Format("--> Original input size: 1000\n--> Add one more tool1:"));
            Write("{0,4}", " ");
            testTool1.Print();
            WriteLine(String.Format("{0,4}run time : {1}", " ", (endTime - startTime).TotalMilliseconds));
            WriteLine("-------------------------------------------");
            startTime = DateTime.Now;
            for (int x = 0; x < 5000; x++)
                testTool2.AddTools(0, 0, "tool2", 1);
            endTime = DateTime.Now;
            startTime = DateTime.Now;
            testTool2.AddTools(0, 0, "tool2", 1);
            endTime = DateTime.Now;
            WriteLine(String.Format("--> Original input size: 5000\n--> Add one more tool2:"));
            Write("{0,4}", " ");
            testTool2.Print();
            WriteLine(String.Format("{0,4}run time : {1}", " ", (endTime - startTime).TotalMilliseconds));
            WriteLine("-------------------------------------------");
            for (int x = 0; x < 10000; x++)
                testTool3.AddTools(0, 0, "tool3", 1);
            startTime = DateTime.Now;
            testTool3.AddTools(0, 0, "tool3", 1);
            endTime = DateTime.Now;
            WriteLine(String.Format("--> Original input size: 10000\n--> Add one more tool3"));
            Write("{0,4}", " ");
            testTool3.Print();
            WriteLine(String.Format("{0,4}run time : {1}", " ", (endTime - startTime).TotalMilliseconds));
            WriteLine("-------------------------------------------");
            for (int x = 0; x < 15000; x++)
                testTool4.AddTools(0, 0, "tool4", 1);
            startTime = DateTime.Now;
            testTool4.AddTools(0, 0, "tool4", 1);
            endTime = DateTime.Now;
            WriteLine(String.Format("--> Original input size: 15000\n--> Add one more tool4:"));
            Write("{0,4}", " ");
            testTool4.Print();
            WriteLine(String.Format("{0,4}run time : {1}", " ", (endTime - startTime).TotalMilliseconds));
            WriteLine("-------------------------------------------");
            for (int x = 0; x < 20000; x++)
                testTool5.AddTools(0, 0, "tool5", 1);
            startTime = DateTime.Now;
            testTool5.AddTools(0, 0, "tool5", 1);
            endTime = DateTime.Now;
            WriteLine(String.Format("--> Original input size: 20000\n--> Add one more tool5:"));
            Write("{0,4}", " ");
            testTool5.Print();
            WriteLine(String.Format("{0,4}run time : {1}", " ", (endTime - startTime).TotalMilliseconds));
            WriteLine("-------------------------------------------");

            WriteLine("\n===Test the efficiency of the Top3 function===\n");
            startTime = DateTime.Now;
            for (int x = 0; x < 1000; x++)
                testTool1.AddTools(0, 0, "tool1", 1);
            endTime = DateTime.Now;
            startTime = DateTime.Now;
            testTool1.AddTools(0, 0, "tool1", 1);
            endTime = DateTime.Now;
            WriteLine(String.Format("--> Original input size: 1000\n--> Add one more tool1:"));
            Write("{0,4}", " ");
            testTool1.Print();
            WriteLine(String.Format("{0,4}run time : {1}", " ", (endTime - startTime).TotalMilliseconds));
            WriteLine("-------------------------------------------");
            memberData.Return();

        }
    }
}
