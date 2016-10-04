using EntityLibrary;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class BusinessLogicClass
    {

        List<SalesReason> saleReasonList = new List<SalesReason>();

        public List<SalesReason> GetAllRecord()
        {
            try
            {
                using (var context = new AdventureWorks2008Entities())
                {
                    saleReasonList = (from SR in context.SalesReasons
                                              orderby SR.Name
                                              select SR).ToList();
                }
            }
            catch (Exception ex)
            {
            }
            return saleReasonList;
        }

        public SalesReason RetrieveSpecificRecordUsingLambda(int? salesReasonID)
        {
            var result = new SalesReason();
            try
            {
                using (var context = new AdventureWorks2008Entities())
                {
                    result = context.SalesReasons.Where(x => x.SalesReasonID == salesReasonID).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
            }

            return result;
        }

        public int CreateNewSalesReasonRecord(SalesReason salesReason)
        {
            int returnValue = 0;
                try
                {
                    using (var context = new AdventureWorks2008Entities())
                    {
                        DateTime dateNow = DateTime.Today;
                        salesReason.ModifiedDate = dateNow;
                        context.SalesReasons.Add(salesReason);
                        returnValue = context.SaveChanges();
                    }
                }
                catch (Exception ex)
                {
                }
                return returnValue;
        }

        public int UpdateSalesReasonRecord(SalesReason salesReason)
        {
            int returnValue = 0;

            if (salesReason.SalesReasonID > 0)
            {
                try
                {
                    using (var context = new AdventureWorks2008Entities())
                    {
                        salesReason.ModifiedDate = DateTime.Now;
                        context.Entry(salesReason).State = EntityState.Modified;
                        returnValue = context.SaveChanges();
                    }
                }
                catch (Exception ex)
                {
                }
                return returnValue;
            }
            else
            {
                return returnValue;
            }
        }

        public int DeleteSalesReasonRecord(int id)
        {
            int returnValue = 0;
            if (id > 0)
            {
                try
                {
                    using (var context = new AdventureWorks2008Entities())
                    {
                        SqlParameter[] parameters = new SqlParameter[]
                        {
                            new SqlParameter("@id", id)
                        };
                        returnValue = context.Database.ExecuteSqlCommand("DELETE FROM  Sales.SalesReason WHERE SalesReasonID = @id", parameters);
                    }
                }
                catch (Exception ex)
                {
                }
                return returnValue;
            }
            else
            {
                return returnValue;
            }
        }

        public int Scalar()
        {
            int returnValue = 0;
                try
                {
                    using (var context = new AdventureWorks2008Entities())
                    {
                        returnValue = context.Database.SqlQuery<int>("Select COUNT(SalesReasonID) FROM Sales.SalesReason").SingleOrDefault();
                    }
                }
                catch (Exception ex)
                {
                }
                return returnValue;
        }

        public List<ManagerEmployee> StoredProcedure(int id)
        {
            var managerEmployeeList = new List<ManagerEmployee>();
            if (id > 0)
            {
                try
                {
                    using (var context = new AdventureWorks2008Entities())
                    {
                        SqlParameter[] parameters = new SqlParameter[]
                        {
                            new SqlParameter("@id", id)
                        };
                        var results = context.Database.SqlQuery<uspGetManagerEmployees_Result>("uspGetManagerEmployees @id", parameters);

                        foreach (var item in results)
                        {
                            managerEmployeeList.Add(new ManagerEmployee() { ManagerFName = item.ManagerFirstName, ManagerLName = item.ManagerLastName, EmployeeFName = item.FirstName, EmployeeLName = item.LastName });
                        }
                    }
                }
                catch (Exception ex)
                {
                }
                return managerEmployeeList;
            }
            else
            {
                return managerEmployeeList;
            }
        }
    }
}
