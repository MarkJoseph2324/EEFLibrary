using EntityLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess_Day4_EF_Exercise
{
    class InputOutput
    {
        private string _paramerterString = "";
        private int _parameterInt = 0;

        public DateTime GetDateToday()
        {
            return DateTime.Today;
        }

        public string GetUserInputSalesReasonName()
        {
            Console.Write("\nPlease insert Reason Name: ");
            _paramerterString = Console.ReadLine();
            if(_paramerterString != "")
            {
                return _paramerterString;
            }
            else
            {
                return "Invalid reason name input";
            }
        }

        public string GetUserInputSalesReasonType()
        {
            Console.Write("\nPlease insert Reason Type: ");
            _paramerterString = Console.ReadLine();
            if (_paramerterString != "")
            {
                return _paramerterString;
            }
            else
            {
                return "Invalid reason type input";
            }
        }

        public int GetUserInputID(string action)
        {
            Console.Write("\nPlease insert ID you want to " + action + ": ");
            Int32.TryParse(Console.ReadLine(), out _parameterInt);
            return _parameterInt;
        }

        public void PrintResultFromDB(List<SalesReason> list,int id)
        {
            int paddingName = 0;
            int paddingType = 0;

            if (id > 0 )
            {
                if (list.Count() != 0)
                {
                    Console.WriteLine("\n ID".PadRight(9) + "Reason Name".PadRight(30) + "Reason Type");
                    Console.WriteLine("───────────────────────────────────────────────────");
                    foreach (var item in list)
                    {
                        paddingName = 7 - item.SalesReasonID.ToString().Length;
                        paddingType = 30 - item.Name.Length;
                        Console.WriteLine(" " + item.SalesReasonID + "".PadRight(paddingName) + item.Name + "".PadRight(paddingType) + item.ReasonType);
                    }
                }
                else
                {
                    Console.WriteLine("\nNo results found.");
                }
            }
            else
            {
                Console.WriteLine("\nInvalid ID, cannot accept null value.");
            }
        }

        public void PrintResultFromDB1(List<ManagerEmployee> list, int id)
        {
            if (id > 0)
            {
                if (list.Count() != 0)
                {
                    int padding = 0;
                    Console.WriteLine("\nManagers Name".PadRight(31) + "Employee Name");
                    Console.WriteLine("─────────────────────".PadRight(30) + "───────────────────");
                    foreach (var item in list)
                    {
                        padding = 30 - (item.ManagerFName.Length + item.ManagerLName.Length + 1);
                        Console.WriteLine(item.ManagerFName + " " + item.ManagerLName + " ".PadRight(padding) + item.EmployeeFName + " " + item.EmployeeLName);
                        padding = 0;
                    }
                }
                else
                {
                    Console.WriteLine("\nNo results found.");
                }
            }
            else
            {
                Console.WriteLine("\nInvalid ID, cannot accept null value.");
            }
        }

        public void PrintMessage(string action, int status, string name, string type)
        {
            string message = "";
            string message2 = "";
            if(name == "Invalid reason name input" && type != "Invalid reason type input")
            {
                message2 = name+ ", cannot accept null value.";
            }
            else if(name == "Invalid reason name input" && type == "Invalid reason type input")
            {
                message2 = "Invalid reason name and reason type input, cannot accept null value.";
            }
            else if(name != "Invalid reason name input" && type == "Invalid reason type input")
            {
                message2 = type + ", cannot accept null value.";
            }
            else
            {
                message2 = "";
            }

            if (status == 1)
            {
                if (action == "Add")
                {
                    message = "\nSuccesfully added!";
                }
                else if (action == "Update")
                {
                    message = "\nUpdated successful!";
                }
                else
                {
                    message = "\nSuccessfully deleted!";
                }
            }
            else
            {
                if (action == "Add")
                {
                    message = "\nAdding failed! " + message2;
                }
                else if (action == "Update")
                {
                    message = "\nUpdating failed! " + message2;
                }
                else
                {
                    message = "\nDeleting failed! " + message2;
                }
            }
            Console.WriteLine(message);
        }

        public void PrintScalar(int scalar)
        {
            Console.WriteLine("There are {0} total logs in Sales Reason table.", scalar);
        }
    }
}
