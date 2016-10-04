using BusinessLogic;
using EntityLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess_Day4_EF_Exercise
{
    class Program
    {
        static void Main(string[] args)
        {
            Menu();
        }

        public static void Menu()
        {
            BusinessLogicClass businessLogic = new BusinessLogicClass();
            InputOutput IO = new InputOutput();
            int menu = 0, UserInputID = 0, scalar = 0, status = 0;
            bool flag = false;
            string UserInputReasonName = "", UserInputReasonType = "";
            List<SalesReason> salesReasonList = new List<SalesReason>();
            List<ManagerEmployee> managerEmployeesList = new List<ManagerEmployee>();


            while (flag == false)
            {
                Console.Clear();

                Console.WriteLine("\nPlease select from the menu:");
                Console.WriteLine("Press '1' Show all records orderby name.");
                Console.WriteLine("Press '2' Show specific record using lambda notation.");
                Console.WriteLine("Press '3' Add");
                Console.WriteLine("Press '4' Update");
                Console.WriteLine("Press '5' Delete");
                Console.WriteLine("Press '6' Scalar");
                Console.WriteLine("Press '7' Stored Procedure");
                Console.Write("\nNumber you press: ");

                Int32.TryParse(Console.ReadLine(), out menu);
                Console.WriteLine();
                switch (menu)
                {
                    case 1:
                        salesReasonList = businessLogic.GetAllRecord();
                        IO.PrintResultFromDB(salesReasonList, 1);
                        break;
                    case 2:
                        UserInputID = IO.GetUserInputID("view");

                        salesReasonList = businessLogic.RetrieveSpecificRecordUsingLambda(UserInputID);
                        IO.PrintResultFromDB(salesReasonList, UserInputID);
                        break;
                    case 3:
                        UserInputReasonName = IO.GetUserInputSalesReasonName();
                        UserInputReasonType = IO.GetUserInputSalesReasonType();

                        status = businessLogic.CreateNewSalesReasonRecord(UserInputReasonName, UserInputReasonType);
                        IO.PrintMessage("Add", status, UserInputReasonName, UserInputReasonType);
                        break;
                    case 4:
                        salesReasonList = businessLogic.GetAllRecord();
                        IO.PrintResultFromDB(salesReasonList, 1);

                        UserInputID = IO.GetUserInputID("update");
                        UserInputReasonName = IO.GetUserInputSalesReasonName();
                        UserInputReasonType = IO.GetUserInputSalesReasonType();

                        status = businessLogic.UpdateSalesReasonRecord(UserInputID, UserInputReasonName, UserInputReasonType);
                        IO.PrintMessage("Update", status, UserInputReasonName, UserInputReasonType);
                        break;
                    case 5:
                        salesReasonList = businessLogic.GetAllRecord();
                        IO.PrintResultFromDB(salesReasonList, 1);

                        UserInputID = IO.GetUserInputID("update");

                        status = businessLogic.DeleteSalesReasonRecord(UserInputID);
                        IO.PrintMessage("Delete", status, UserInputReasonName, UserInputReasonType);
                        break;
                    case 6:
                        scalar = businessLogic.Scalar();
                        IO.PrintScalar(scalar);
                        break;
                    case 7:
                        UserInputID = IO.GetUserInputID("view");

                        managerEmployeesList = businessLogic.StoredProcedure(UserInputID);
                        IO.PrintResultFromDB1(managerEmployeesList, UserInputID);
                        break;
                    default:
                        Console.WriteLine("Invalid input.");
                        break;
                }
                Console.Write("\nPress any key to continue...");
                Console.ReadKey();
            }
        }
    }
}
