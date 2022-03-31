using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace EMS
{
    internal class Program
    {
        // Data structures
        static int MAX_RECORDS = 20;
        static string[] usernameA = new string[MAX_RECORDS];
        static string[] passwordsA = new string[MAX_RECORDS];
        static string[] initialPassA = new string[MAX_RECORDS];
        static string[] rolesA = new string[MAX_RECORDS];
        static string[] emp_nameA = new string[MAX_RECORDS];
        static string[] task_1A = new string[MAX_RECORDS];
        static string[] task_2A = new string[MAX_RECORDS];
        static string[] task_3A = new string[MAX_RECORDS];
        static string[] task_4A = new string[MAX_RECORDS];
        static float[] emp_payA = new float[MAX_RECORDS];
        static float[] emp_rewardA = new float[MAX_RECORDS];
        static float[] emp_attendanceA = new float[MAX_RECORDS];
        static float[] emp_absenceA = new float[MAX_RECORDS];
        static float[] emp_deductA = new float[MAX_RECORDS];
        static int[] emp_rankA = new int[MAX_RECORDS];
        static int[] emp_perA = new int[MAX_RECORDS];
        static int[] task1_timeA = new int[MAX_RECORDS];
        static int[] task2_timeA = new int[MAX_RECORDS];
        static int[] task3_timeA = new int[MAX_RECORDS];
        static int[] task4_timeA = new int[MAX_RECORDS];
        static int[] emp_comp_taskA = new int[MAX_RECORDS];
        static bool[] payA = new bool[MAX_RECORDS];

        // end of arrays
        // initializing scalar variables
        static int userCount = 0;
        static int emp_count = 0;
        static string loginusername = " ";
        static int a = 0;
        static string st = " ";
        static string path = "user.txt";

        // end of scalar variables
        static void Main(string[] args)
        {
            removeJunk();
            storeArray();
            string i = " ", j = " ";
            string admin = " ";
            string user = " ";
            string pass = " ";
            string role = " ";
            while (true) // STARTING FIRST WHILE LOOP
            {
                Console.Clear();
                head();          // ADDING HEADER
                i = loginMenu(); // SAVING VALUE OF FUNCTION IN A string
                if (i == "ADMIN")
                {
                    while (true)
                    {
                        clearscreen();
                        head();
                        j = adInterface();
                        clearscreen();
                        head();
                        if (j == "1") // STARTING MOST NESTED IF
                        {
                            Console.WriteLine("Main Menu > Add User");
                            Console.WriteLine("-----------------------------------------");
                            Console.WriteLine("Enter username of User : ");
                            user = Console.ReadLine();
                            while (true)
                            {
                                
                                Console.Write("Enter password of User : ");
                                pass = Console.ReadLine();
                                if (pass.Length >= 8)
                                {
                                    break;
                                }
                                else
                                {
                                    Console.WriteLine("password must be 8 digit or long.");
                                    Console.Write("Enter any key to continue : ");
                                    Console.Read();
                                    Console.Clear();
                                }
                            }
                            Console.Write("Enter role of User : ");
                            role=Console.ReadLine();
                            addUser(ref user,ref  pass,ref  role);
                        }                  // END OF MOST NESTED IF
                        else if (j == "2") // STARTING MOST NESTED ELSE IF
                        {
                            addEmployRank();
                        }                  // END MOST NESTED ELSE IF
                        else if (j == "3") // STARTING MOST NESTED ELSE IF
                        {
                            releasePay();
                        }                  // END MOST NESTED ELSE IF
                        else if (j == "4") // STARTING MOST NESTED ELSE IF
                        {
                            empReward();
                        }                  // END MOST NESTED ELSE IF
                        else if (j == "5") // STARTING MOST NESTED ELSE IF
                        {
                            empAttendance();
                        }                  // END MOST NESTED ELSE IF
                        else if (j == "6") // STARTING MOST NESTED ELSE IF
                        {
                            empDeductions();
                        }                  // END MOST NESTED ELSE IF
                        else if (j == "7") // STARTING MOST NESTED ELSE IF
                        {
                            empRemove();
                        }
                        else if (j == "8") // STARTING MOST NESTED ELSE IF
                        {
                            Console.WriteLine("Main Menu > Employ List");
                            Console.WriteLine("-----------------------------------------");
                            Console.WriteLine("Srno\t Name\t Rank");
                            displayEmploy();
                        }                  // END MOST NESTED ELSE IF
                        else if (j == "9") // STARTING MOST NESTED ELSE IF
                        {
                            Console.WriteLine("Main Menu > Assighn Tasks / Duties");
                            Console.WriteLine("-----------------------------------------");
                            empTasks();
                        }                   // END MOST NESTED ELSE IF
                        else if (j == "10") // STARTING MOST NESTED ELSE IF
                        {
                            Console.WriteLine("Main Menu > Changes by Employ.");
                            Console.WriteLine("----------------------------");
                            empChanges();
                        }                   // END MOST NESTED ELSE IF
                        else if (j == "11") // STARTING MOST NESTED ELSE IF
                        {
                            Console.WriteLine("Main Menu > Employ Performance.");
                            Console.WriteLine("----------------------------");
                            empCompletedTasks();
                        }                   // END MOST NESTED ELSE IF
                        else if (j == "12") // STARTING MOST NESTED ELSE IF
                        {
                            Console.WriteLine("Main Menu > Change Password of employ.");
                            Console.WriteLine("----------------------------");
                            changeEmpPass();
                        }                   // END MOST NESTED ELSE IF
                        else if (j == "13") // STARTING MOST NESTED ELSE IF
                        {
                            Console.WriteLine("Main Menu > Give Promotion.");
                            Console.WriteLine("----------------------------");
                            empPromotion();
                        } // END MOST NESTED ELSE IF
                        else if (j == "14")
                        {
                            break;
                        }
                        else // STARTING MOST NESTED ELSE
                        {
                            Console.Write("Enter valid value");
                        }               // END MOST NESTED ELSE
                    }                   // end of nested while
                }                       // END if
                else if (i == "EMPLOY") // START OF ELSE IF
                {
                    while (true) // START OF NESTED WHILE
                    {
                        clearscreen();
                        head();
                        j = empInterface();
                        clearscreen();
                        head();
                        if (j == "1") // STARTING MOST NESTED ELSE IF
                        {
                            Console.WriteLine("Main Menu > Change Password");
                            Console.WriteLine("----------------------------------");
                            changePass();
                        }                  // END MOST NESTED IF
                        else if (j == "2") // STARTING MOST NESTED ELSE IF
                        {
                            Console.WriteLine("Main Menu > View salary");
                            Console.WriteLine("----------------------------------");
                            viewSalary();
                        }                  // END MOST NESTED ELSE IF
                        else if (j == "3") // STARTING MOST NESTED Console.WriteLine(
                        {
                            Console.WriteLine("Main Menu > View Grant / Reward or Bonus.");
                            Console.WriteLine("--------------------------------------------");
                            viewReward();
                        }                  // END MOST NESTED ELSE IF
                        else if (j == "4") // STARTING MOST NESTED ELSE IF
                        {
                            Console.WriteLine("Main Menu > View Attendance.");
                            Console.WriteLine("--------------------------------");
                            viewAttendance();
                        }                  // END MOST NESTED ELSE IF
                        else if (j == "5") // STARTING MOST NESTED ELSE IF
                        {
                            Console.WriteLine("Main Menu > View Deductions.");
                            Console.WriteLine("--------------------------------");
                            viewDeduct();
                        }                  // END MOST NESTED ELSE IF
                        else if (j == "6") // STARTING MOST NESTED ELSE IF
                        {
                            Console.WriteLine("Main menu > View assighned Tasks / Duties.");
                            Console.WriteLine("----------------------------------------------");
                            Console.WriteLine("No. task\t\ttime");
                            viewTask();
                        }                  // END MOST NESTED ELSE IF
                        else if (j == "7") // STARTING MOST NESTED ELSE IF
                        {
                            Console.WriteLine("Main menu > Completed Tasks / Duties.");
                            Console.WriteLine("-----------------------------------------");
                            enterCompTask();
                        }                  // END MOST NESTED ELSE IF
                        else if (j == "8") // STARTING MOST NESTED ELSE IF
                        {
                            Console.WriteLine("Main menu > View your Balance.");
                            Console.WriteLine("-----------------------------------------");
                            viewBalance();
                        }                  // END MOST NESTED ELSE IF
                        else if (j == "9") // STARTING MOST NESTED ELSE IF
                        {
                            Console.WriteLine("Main menu > See your Status.");
                            Console.WriteLine("-----------------------------------------");
                            viewStatus();
                        }                   // END MOST NESTED ELSE IF
                        else if (j == "10") // STARTING MOST NESTED ELSE IF
                        {
                            break;
                        }    // END MOST NESTED ELSE IF
                        else // STARTING MOST NESTED ELSE
                        {
                            Console.Write("Enter valid value.");
                        } // END MOST NESTED ELSE
                    }     // END OF NESTED WHILE
                }         // END OF ELSE IF
                else if (i == "EXIT")
                {
                    storeFile();
                    Console.WriteLine("Thank You For Using!");
                    break;
                }
                else
                {
                    Console.WriteLine("Enter correct user name or password.");
                    Console.Write("Press any key to continue : ");
                    Console.Read();
                    Console.Clear();
                }
            }
        }
        static void head() // HEADER FILE
        {
            Console.WriteLine("*******************************************************");
            Console.WriteLine("*              EMPLOY MANAGEMENT SYSTEM               *");
            Console.WriteLine("*******************************************************");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
        }
        static void clearscreen() // TO CLEAR SCREEN
        {
            Console.Write("Enter any key to continue : ");
            Console.Read();
            Console.Read();
            Console.Read();
            Console.Clear();
        }
        static string loginMenu()
        { //________Get user credentials and check whether user is present in
            char s;
            string tempName = " ";
            string e = "EXIT";
            Console.WriteLine("LOGIN MENU.");
            Console.WriteLine("----------------------");
            Console.WriteLine("1. Login.");
            Console.WriteLine("2. Exit.");
            Console.Write("Enter one option : ");
            s = (char)Console.Read();
            Console.Read();
            Console.Read();

            Console.Clear();
            if (s == '1')
            {
                head();
                Console.WriteLine("Enter user name : ");
                tempName = Console.ReadLine();
                Console.WriteLine("Enter Password : ");
                string tempRoll = Console.ReadLine();
                for (int x = 0; x < MAX_RECORDS; x++)
                {
                    if (usernameA[x] == tempName && passwordsA[x] == tempRoll)
                    {
                        loginusername = tempName;
                        return rolesA[x];
                    }
                }
            }
            else if (s == '2')
            {
                return e;
            }
            return "no";
        }
        static string adInterface() // ADMIN MAIN MENU
        {
            string admin_employ = " ";
            Console.WriteLine("Main Menu.");
            Console.WriteLine("--------------");
            Console.WriteLine("Select one of the following.");
            Console.WriteLine("1.  Add User.");
            Console.WriteLine("2.  Add Employ rank.");
            Console.WriteLine("3.  Release Pay.");
            Console.WriteLine("4.  Grant / Reward or Bonus.");
            Console.WriteLine("5.  Attendance.");
            Console.WriteLine("6.  Deductions.");
            Console.WriteLine("7.  Remove Employ.");
            Console.WriteLine("8.  Employ List.");
            Console.WriteLine("9.  Assighn Tasks / Duties.");
            Console.WriteLine("10. Changes by Employ.");
            Console.WriteLine("11. Employ Performance.");
            Console.WriteLine("12. Change Password of employ.");
            Console.WriteLine("13. Give promotion.");
            Console.WriteLine("14. LogOut.");
            Console.Write("Select one option : ");
            admin_employ = Console.ReadLine();
            return admin_employ;
        }
        static string empInterface() // EMPLOY MAIN MENU
        {
            string admin_employ = " ";
            Console.WriteLine("Main Menu.");
            Console.WriteLine("--------------");
            Console.WriteLine("Select one of the following.");
            Console.WriteLine("1.  Change password.");
            Console.WriteLine("2.  View salary.");
            Console.WriteLine("3.  View Grant / Reward or Bonus.");
            Console.WriteLine("4.  View Attendance.");
            Console.WriteLine("5.  View Deductions.");
            Console.WriteLine("6.  View Assigned Tasks / Duties.");
            Console.WriteLine("7.  Completed Tasks / Duties.");
            Console.WriteLine("8.  View your Balance.");
            Console.WriteLine("9.  View your Full Status.");
            Console.WriteLine("10. LogOut.");
            Console.Write("Select one option : ");
            admin_employ = Console.ReadLine();
            return admin_employ;
        }
        static void addEmployRank() // adding employ rank
        {
            string user;
            Console.WriteLine("Main Menu > Add Employ rank.");
            Console.WriteLine("-----------------------------");
            Console.Write("Enter Employ username : ");
            user = Console.ReadLine();
            for (int i = 0; i < emp_count; i++)
            {
                if (emp_nameA[i] == user) // checking position of employ in array
                {
                    Console.Write("Enter Employ rank : ");
                    st = Console.ReadLine();
                    if (isNumber(st))
                    {
                        emp_rankA[i] = int.Parse(st); // entering rank
                    }
                    else
                    {
                        Console.WriteLine("Invalid Input.");
                    }
                }
            }
        }
        static void addUser(ref string user,ref string pass,ref string role) // adding user
        {
            if (userCount < MAX_RECORDS)
            {
                usernameA[userCount] = user;
                passwordsA[userCount] = pass;
                rolesA[userCount] = role;
                if (rolesA[userCount] == "EMPLOY") // if admin want to add employ
                {
                    emp_nameA[emp_count] = user;
                    initialPassA[emp_count] = pass;
                    emp_count++;
                }
                userCount++;
            }
            else
            {
                Console.WriteLine("No more space to add user.");
            }
        }
        static void releasePay() // releasing pay of employ
        {
            string username = " ";
            Console.WriteLine("Main Menu > Release Pay");
            Console.WriteLine("-----------------------------------------");
            Console.Write("Enter username of employ : ");
            username = Console.ReadLine();
            for (int y = 0; y < emp_count; y++)
            {
                payA[y] = false;
                if (username == emp_nameA[y]) // checking position of employ
                {
                    Console.Write("Enter pay of Employ : ");
                    st = Console.ReadLine();
                    if (isNumber(st))
                    {
                       emp_payA[y] = int.Parse(st);
                        payA[y] = true;
                    }
                    else
                    {
                        Console.WriteLine("Invalid Input.");
                    }
                }
            }
        }
        static void empReward() // giving reward to employ
        {
            string username = " ";
            Console.WriteLine("Main Menu > Grant / Reward or Bonus.");
            Console.WriteLine("-----------------------------------------");
            Console.Write("Enter username of employ : ");
            username = Console.ReadLine();
            for (int y = 0; y < emp_count; y++)
            {
                if (username == emp_nameA[y])
                {
                    Console.Write("Enter Reward of Employ " + y + 1 + " : ");
                    st = Console.ReadLine();
                    if (isNumber(st))
                    {
                        emp_rewardA[y] = int.Parse(st);
                    }
                    else
                    {
                        Console.WriteLine("Invalid Input.");
                    }
                }
            }
        }
        static void empAttendance() // attendance of employ
        {
            string username = " ";
            Console.WriteLine("Main Menu > Attendance");
            Console.WriteLine("-----------------------------------------");
            Console.Write("Enter username of employ : ");
            username = Console.ReadLine();
            for (int y = 0; y < emp_count; y++)
            {
                if (username == emp_nameA[y])
                {
                    Console.Write("Enter how many days out 0f 30 employ 1 present : ");
                    st = Console.ReadLine();
                    if (isNumber(st))
                    {
                        emp_attendanceA[y] = int.Parse(st);
                        emp_absenceA[y] = 30 - emp_attendanceA[y]; // calculating absent days out of 30
                        Console.WriteLine("employ is absent {0} day(s)." , emp_absenceA[y]);
                    }
                    else
                    {
                        Console.WriteLine("Invalid Input.");
                    }
                }
            }
        }
        static void empDeductions() // deductions in employ pay
        {
            string username = " ";
            Console.WriteLine("Main Menu > Deductions");
            Console.WriteLine("-----------------------------------------");
            Console.Write("Enter username of employ : ");
            username = Console.ReadLine();
            for (int y = 0; y < emp_count; y++)
            {
                emp_deductA[y] = emp_absenceA[y] * 100; // calculating fine due to absence
                if (username == emp_nameA[y])
                {
                    Console.WriteLine("employ is absent {0} day(s)." , emp_absenceA[y]);
                    Console.WriteLine("Employ deductions : {0}" , emp_deductA[y]);
                }
            }
        }
        static void empRemove() // removing employ
        {
            string username = " ";
            char i = ' ';
            Console.WriteLine("Main Menu > Remove Employ.");
            Console.WriteLine("----------------------------");
            Console.Write("Enter username of employ : ");
            username = Console.ReadLine();
            Console.Write("Do you wanna remove employ(y or n) : ");
            i = (char)Console.Read();

            if (i == 'y') // STARTING IF
            {
                for (int y = 0; y < emp_count; y++)
                {
                    if (username == emp_nameA[y])
                    {
                        for (int x = 0; x < emp_count - 1; x++)
                        {
                            emp_nameA[x] = emp_nameA[x + 1];
                            emp_payA[x] = emp_payA[x + 1];
                            emp_rewardA[x] = emp_rewardA[x + 1];
                            emp_rankA[x] = emp_rankA[x + 1];
                            emp_attendanceA[x] = emp_attendanceA[x + 1];
                            emp_deductA[x] = emp_deductA[x + 1];
                            emp_absenceA[x] = emp_absenceA[x + 1];
                        }
                        emp_count = emp_count - 1;
                        Console.WriteLine("Employ removed.");
                        break;
                    }
                }
                for (int y = 0; y < userCount; y++)
                {
                    if (username == usernameA[y] && rolesA[y] == "EMPLOY") // checking position of employ in array
                    {
                        for (int x = y; x < userCount - 1; x++)
                        {

                            passwordsA[x] = passwordsA[x + 1];
                            initialPassA[x] = initialPassA[x + 1];
                            rolesA[x] = rolesA[x + 1]; // removing from array
                        }
                        userCount--;
                    }
                }
            }
        }
        static void displayEmploy() // display employ with respect to their rank
        {
            int temp = 0;
            string temp1;
            float temp3;
            for (int x = 0; x < emp_count; x++) // sorting w.r.t employ rank
            {
                for (int y = 0; y < emp_count - 1; y++)
                {
                    if (emp_rankA[y] < emp_rankA[y + 1]) // Descending order
                    {
                        temp = emp_rankA[y];
                        emp_rankA[y] = emp_rankA[y + 1];
                        emp_rankA[y + 1] = temp;

                        temp1 = emp_nameA[y];
                        emp_nameA[y] = emp_nameA[y + 1];
                        emp_nameA[y + 1] = temp1;

                        temp1 = task_1A[y];
                        task_1A[y] = task_1A[y + 1];
                        task_1A[y + 1] = temp1;

                        temp1 = task_2A[y];
                        task_2A[y] = task_2A[y + 1];
                        task_2A[y + 1] = temp1;

                        temp1 = task_3A[y];
                        task_3A[y] = task_3A[y + 1];
                        task_3A[y + 1] = temp1;

                        temp1 = task_4A[y];
                        task_4A[y] = task_4A[y + 1];
                        task_4A[y + 1] = temp1;

                        temp3 = emp_payA[y];
                        emp_payA[y] = emp_payA[y + 1];
                        emp_payA[y + 1] = temp3;

                        temp3 = emp_rewardA[y];
                        emp_rewardA[y] = emp_rewardA[y + 1];
                        emp_rewardA[y + 1] = temp3;

                        temp3 = emp_attendanceA[y];
                        emp_attendanceA[y] = emp_attendanceA[y + 1];
                        emp_attendanceA[y + 1] = temp3;

                        temp3 = emp_absenceA[y];
                        emp_absenceA[y] = emp_absenceA[y + 1];
                        emp_absenceA[y + 1] = temp3;

                        temp3 = emp_deductA[y];
                        emp_deductA[y] = emp_deductA[y + 1];
                        emp_deductA[y + 1] = temp3;

                        temp = task1_timeA[y];
                        task1_timeA[y] = task1_timeA[y + 1];
                        task1_timeA[y + 1] = temp;

                        temp = task2_timeA[y];
                        task2_timeA[y] = task2_timeA[y + 1];
                        task2_timeA[y + 1] = temp;

                        temp = task3_timeA[y];
                        task3_timeA[y] = task3_timeA[y + 1];
                        task3_timeA[y + 1] = temp;

                        temp = task4_timeA[y];
                        task4_timeA[y] = task4_timeA[y + 1];
                        task4_timeA[y + 1] = temp;

                        temp = emp_comp_taskA[y];
                        emp_comp_taskA[y] = emp_comp_taskA[y + 1];
                        emp_comp_taskA[y + 1] = temp;
                    }
                }
            }
            for (int x = 0; x < emp_count; x++)
            {
                Console.WriteLine(x + 1 + ".  \t"+emp_nameA[x]+ "\t" + emp_rankA[x]);
            }
        }
        static void empTasks() // assign tasks to employ
        {
            string task_1, task_2, task_3, task_4;
            int task1_time, task2_time, task3_time, task4_time;
            string username = " ";
            Console.Write("Enter username of employ : ");
            username = Console.ReadLine();

            Console.Write("Enter task 1 : ");
            task_1 = Console.ReadLine();
            Console.Write("Enter Task 1 time : ");
            task1_time = int.Parse(Console.ReadLine());
            Console.Write("Enter task 2 : ");
            task_2 = Console.ReadLine();
            Console.Write("Enter Task 2 time : ");
            task2_time = int.Parse(Console.ReadLine());
            Console.Write("Enter task 3 : ");
            task_3 = Console.ReadLine();
            Console.Write("Enter Task 3 time : ");
            task3_time = int.Parse(Console.ReadLine());
            Console.Write("Enter task 4 : ");
            task_4 = Console.ReadLine();
            Console.Write("Enter Task 4 time : ");
            task4_time = int.Parse(Console.ReadLine());
            for (int y = 0; y < emp_count; y++)
            {
                if (username == emp_nameA[y])
                {
                    task_1A[y] = task_1;
                    task_2A[y] = task_2;
                    task_3A[y] = task_3;
                    task_4A[y] = task_4;
                    task1_timeA[y] = task1_time;
                    task2_timeA[y] = task2_time;
                    task3_timeA[y] = task3_time;
                    task4_timeA[y] = task4_time;
                }
            }
        }
        static void empChanges() // see changes by employ
        {
            string username = " ";
            int c = 0;

            Console.Write("Enter username of required employ : ");
            username = Console.ReadLine();
            for (int x = 0; x < userCount; x++)
            {
                if (usernameA[x] == username && initialPassA[x] != passwordsA[x])
                {
                    Console.WriteLine("Employ changed his password to : {0}" , passwordsA[x]);
                    initialPassA[x] = passwordsA[x];
                    c++;
                    break;
                }
            }
            if (c == 0)
            {
                Console.WriteLine("No changes by employ.");
            }
        }
        static void empCompletedTasks() // Completed tasks by employ
        {
            string username = " ";
            Console.Write("Enter user name of employ : ");
            username = Console.ReadLine();
            Console.Write("No of task completed by employ : ");
            for (int x = 0; x < emp_count; x++)
            {
                if (emp_nameA[x] == username)
                {

                    if (emp_comp_taskA[x] != 0)
                    {
                        Console.WriteLine(emp_comp_taskA[x]);
                    }
                    else
                    {
                        Console.WriteLine("Nil");
                    }
                    break;
                }
            }
        }
        static void changeEmpPass() // Changing password of employ
        {
            string pass;
            string username = " ";
            char x = ' ';
            Console.Write("Enter user name of employ : ");
            username = Console.ReadLine();
            Console.Write("Do you wanna change password of employ (y or n) : ");
            x = (char)Console.Read();
            for (int i = 0; i < userCount; i++)
            {
                if (x == 'y' && usernameA[i] == username && rolesA[i] == "EMPLOY")
                {
                    while (true)
                    {
                        Console.Write("Enter password of User : ");
                        pass = Console.ReadLine();
                        if (pass.Length >= 8)
                        {
                            passwordsA[i] = pass;
                            initialPassA[i] = passwordsA[i];
                            Console.WriteLine("Password updated!");
                            break;
                        }
                        else
                        {
                            Console.WriteLine("password must be 8 digit or long.");
                            Console.Write("Enter any key to continue : ");
                            Console.Read();
                            Console.Clear();
                        }
                    }
                    break;
                }
            }
        }
        static void empPromotion() // promotion of employ
        {
            string username = " ";
            Console.Write("Enter user name : ");
            username = Console.ReadLine();
            for (int i = 0; i < emp_count; i++)
            {
                if (emp_nameA[i] == username)
                {
                    Console.Write("Enter new employ rank : ");
                    st = Console.ReadLine();
                    if (isNumber(st))
                    {
                        emp_rankA[i] = int.Parse(st);
                    }
                    else
                    {
                        Console.WriteLine("Invalid Input.");
                    }
                    break;
                }
            }
        }
        static void changePass() // Employ can change his password by this function
        {
            string pass;
            string previous_pass = " ";
            int c = 0;
            Console.Write("Enter Previous Password : ");
            previous_pass=Console.ReadLine();
            for (int z = 0; z < userCount; z++)
            {
                if (previous_pass == passwordsA[z] && usernameA[z] == loginusername) // STARTING IF
                {
                    while (true)
                    {
                        Console.Write("Enter password of User : ");
                        pass = Console.ReadLine();
                        if (pass.Length >= 8)
                        {
                            passwordsA[z] = pass;
                            break;
                        }
                        else
                        {
                            Console.WriteLine("password must be 8 digit or long.");
                            Console.Write("Enter any key to continue : ");
                            Console.Read();
                            Console.Clear();
                        }
                    }

                    Console.WriteLine("Password updated.");
                    c++;
                    break;
                } // END IF
            }
            if (c == 0)
            {
                Console.WriteLine("You entered wrong password.");
            }
        }
        static void viewSalary() // employ view his salary
        {
            a = 0;
            for (int x = 0; x < emp_count; x++)
            {
                if (loginusername == emp_nameA[x] && payA[x] == true)
                {
                    Console.WriteLine("Your salary status : {0}",emp_payA[x]);
                    a++;
                }
            }
            if (a == 0)
            {
                Console.WriteLine("NO data entered yet");
            }
        }
        static void viewReward() // employ can view his reward
        {
            a = 0;
            for (int x = 0; x < emp_count; x++)
            {
                if (loginusername == emp_nameA[x])
                {
                    Console.WriteLine("Your Grant / Reward or bonus : {0}",emp_rewardA[x]);
                    a++;
                }
            }
            if (a == 0)
            {
                Console.WriteLine("NO data entered yet");
            }
        }
        static void viewAttendance() // employ can view his attendance
        {
            a = 0;
            for (int x = 0; x < emp_count; x++)
            {
                if (loginusername == emp_nameA[x])
                {
                    Console.WriteLine("Your attendance : {0}",emp_attendanceA[x]);
                    Console.WriteLine("Your absence out of 30 : {0}",emp_absenceA[x]);
                    a++;
                }
            }
            if (a == 0)
            {
                Console.WriteLine("NO data entered yet");
            }
        }
        static void viewDeduct() // employ can view his attendance
        {
            a = 0;
            for (int x = 0; x < emp_count; x++)
            {
                if (loginusername == emp_nameA[x])
                {
                    Console.WriteLine("Your deduction in salary : {0}",emp_deductA[x]);
                    a++;
                }
            }
            if (a == 0)
            {
                Console.WriteLine("NO data entered yet");
            }
        }
        static void viewTask() // employ can view assigned tasks by admin
        {
            a = 0;
            for (int x = 0; x < emp_count; x++)
            {
                if (loginusername == emp_nameA[x])
                {
                    Console.WriteLine("1. {0} \t\t {1}" , task_1A[x] , task1_timeA[x]);
                    Console.WriteLine("2. {0} \t\t {1}" , task_2A[x] , task2_timeA[x]);
                    Console.WriteLine("3. {0} \t\t {1}" , task_3A[x] , task3_timeA[x]);
                    Console.WriteLine("4. {0} \t\t {1}" , task_4A[x] , task4_timeA[x]);
                    a++;
                }
            }
            if (a == 0)
            {
                Console.WriteLine("NO data entered yet");
            }
        }
        static void enterCompTask() // Number of completed tasks
        {
            a = 0;
            for (int x = 0; x < emp_count; x++)
            {
                if (loginusername == emp_nameA[x])
                {
                    Console.Write("Enter no of completed tasks : ");
                    st = Console.ReadLine();
                    if (isNumber(st))
                    {
                        emp_comp_taskA[x] = int.Parse(st);
                        a++;
                    }
                    else
                    {
                        Console.WriteLine("Invalid Input.");
                    }
                }
            }
            if (a == 0)
            {
                Console.WriteLine("NO data entered yet");
            }
        }
        static void viewBalance() // Employ can see his Balance
        {
            a = 0;
            for (int x = 0; x < emp_count; x++)
            {
                if (loginusername == emp_nameA[x])
                {
                    float balance = emp_payA[x] + emp_rewardA[x] - emp_deductA[x];
                    Console.WriteLine("Your balance : {0}",balance);
                    a++;
                }
            }
            if (a == 0)
            {
                Console.WriteLine("NO data entered yet");
            }
        }
        static void viewStatus() // employ can view his full status
        {
            a = 0;
            for (int x = 0; x < emp_count; x++)
            {
                if (loginusername == emp_nameA[x])
                {
                    Console.WriteLine("Your Salary : {0}",emp_payA[x]);
                    Console.WriteLine("Your rank : {0}",emp_rankA[x]);
                    Console.WriteLine("Your bonus : {0}",emp_rewardA[x]);
                    Console.WriteLine("your deductions : {0}",emp_deductA[x]);
                    float balance = emp_payA[x] + emp_rewardA[x] - emp_deductA[x];
                    Console.WriteLine("Your balance : {0}", balance);
                    a++;
                }
            }
            if (a == 0)
            {
                Console.WriteLine("NO data entered yet");
            }
        }
        static string getParse(string abc, int num) // to seperate data read from file
        {
            int commaCount = 0;
            string item = "";
            for (int y = 0; y < abc.Length; y++)
            {
                if (abc[y] == ',')
                {
                    commaCount = commaCount + 1;
                }
                else if (commaCount == num)
                {
                    item = item + abc[y];
                }
            }
            return item;
        }
        static void storeArray() // to store data from file t array
        {
            string us, pass, rol;
            int rnk;
            float emp_pay, emp_reward, emp_attendance, emp_absence, emp_deduct;
            int task1_time;
            int task2_time, task3_time, task4_time, emp_comp_task;
            bool payannounce;
            StreamReader fp = new StreamReader(path);
            string line = " ";
            while ((line = fp.ReadLine()) != null)
            {
                us = getParse(line, 0);
                pass = getParse(line, 1);
                rol = getParse(line, 2);
                if (rol == "EMPLOY")
                {
                    rnk = int.Parse(getParse(line, 3));
                    emp_pay = int.Parse(getParse(line, 4));
                    emp_reward = int.Parse(getParse(line, 5));
                    emp_attendance = int.Parse(getParse(line, 6));
                    emp_absence = int.Parse(getParse(line, 7));
                    emp_deduct = int.Parse(getParse(line, 8));
                    task1_time = int.Parse(getParse(line, 9));
                    task2_time = int.Parse(getParse(line, 10));
                    task3_time = int.Parse(getParse(line, 11));
                    task4_time = int.Parse(getParse(line, 12));
                    emp_comp_task = int.Parse(getParse(line, 13));
                    emp_nameA[emp_count] = us;
                    emp_payA[emp_count] = emp_pay;
                    emp_rankA[emp_count] = rnk;
                    emp_rewardA[emp_count] = emp_reward;
                    emp_attendanceA[emp_count] = emp_attendance;
                    emp_absenceA[emp_count] = emp_absence;
                    emp_deductA[emp_count] = emp_deduct;
                    task1_timeA[emp_count] = task1_time;
                    task2_timeA[emp_count] = task2_time;
                    task3_timeA[emp_count] = task3_time;
                    task4_timeA[emp_count] = task4_time;
                    emp_comp_taskA[emp_count] = emp_comp_task;
                    task_1A[emp_count] = getParse(line, 14);
                    task_2A[emp_count] = getParse(line, 15);
                    task_3A[emp_count] = getParse(line, 16);
                    task_4A[emp_count] = getParse(line, 17);
                    payannounce = Convert.ToBoolean(getParse(line, 18));
                    payA[emp_count] = payannounce;
                    initialPassA[userCount] = getParse(line, 19);
                }
                addUser(ref us,ref  pass,ref rol);
            }
            fp.Close();
        }
        static void storeFile() // to store data in file
        {
            StreamWriter newfile = new StreamWriter(path);
            for (int z = 0; z < userCount; z++)
            {
                newfile.Write(usernameA[z] + "," + passwordsA[z] + "," + rolesA[z]);
                if (rolesA[z] == "EMPLOY")
                {
                    for (int y = 0; y < emp_count; y++)
                    {
                        if (usernameA[z] == emp_nameA[y])
                        {
                            newfile.Write("," + emp_rankA[y] + "," + emp_payA[y] + "," + emp_rewardA[y] + "," + emp_attendanceA[y]);
                            newfile.Write("," + emp_absenceA[y] + "," + emp_deductA[y] + "," + task1_timeA[y] + "," + task2_timeA[y] + "," + task3_timeA[y]);
                            newfile.Write("," + task4_timeA[y] + "," + emp_comp_taskA[y] + "," + task_1A[y] + "," + task_2A[y] + "," + task_3A[y] + "," + task_4A[y] + "," + payA[y]);
                            newfile.Write("," + initialPassA[y]);
                        }
                    }
                }
                if (z < userCount - 1)
                {
                    newfile.WriteLine();
                }
            }
            newfile.Flush();
            newfile.Close();
        }
        static void removeJunk() // remove garbage value of arrays
        {
            for (int i = 0; i < MAX_RECORDS; i++)
            {
                usernameA[i] = "0";
                passwordsA[i] = "0";
                initialPassA[i] = "0";
                rolesA[i] = "0";
                emp_nameA[i] = "0";
                task_1A[i] = "0";
                task_2A[i] = "0";
                task_3A[i] = "0";
                task_4A[i] = "0";
                emp_payA[i] = 0;
                emp_rewardA[i] = 0;
                emp_attendanceA[i] = 0;
                emp_absenceA[i] = 0;
                emp_deductA[i] = 0;
                emp_rankA[i] = 0;
                emp_perA[i] = 0;
                task1_timeA[i] = 0;
                task2_timeA[i] = 0;
                task3_timeA[i] = 0;
                task4_timeA[i] = 0;
                emp_comp_taskA[i] = 0;
                payA[i] = false;
            }
        }
        static bool isNumber(string line)
        {
            bool flag = true;

            for (int i = 0; i < line.Length; i++)
            {
                if (!(line[i] >= 48 && line[i] <= 57))
                {
                    flag = false;
                    break;
                }
            }
            return flag;
        }
    }
}
