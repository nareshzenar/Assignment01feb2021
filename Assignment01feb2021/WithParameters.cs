using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Assignment01feb2021
{
    class Demo
    {
        SqlConnection con = null;
        SqlCommand cmd = null;
        SqlDataReader dr = null;
        public int ShowData()
        {
            try
            {
                Console.WriteLine("Data from the table after the DML command\n");
                Console.WriteLine("...........................................................");
                con = new SqlConnection(@"Data Source=DELL\SQLEXPRESS;Initial Catalog=WFA3DotNet;Integrated Security=True");
                cmd = new SqlCommand("select * from adoemp", con);
                con.Open();
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Console.WriteLine($"{dr["eid"]}\t{dr["ename"]}\t{dr["esal"]}\t{dr["depno"]}");
                }
                return 0;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return 1;
            }
            finally
            {
                dr.Close();
                con.Close();
            }
        }
    }
    class WithParameters
    {
        static void Main()
        {
            Demo d = new Demo();
            char a;
            SqlConnection con = null;
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            do
            {
                Console.WriteLine("Choose Your Operation:");
                Console.WriteLine("1.Insertion Operation");
                Console.WriteLine("2.Update Operation");
                Console.WriteLine("3.Delete Operation");
                int ch = Convert.ToInt32(Console.ReadLine());
                switch (ch)
                {
                    case 1:
                        try
                        {
                            Console.WriteLine("Enter Employee Name");
                            var ename = Console.ReadLine();
                            Console.WriteLine("Enter Employee Salary");
                            var esal = Convert.ToSingle(Console.ReadLine());
                            Console.WriteLine("Enter Dept Id");
                            var depno = Convert.ToInt32(Console.ReadLine());
                            con = new SqlConnection(@"Data Source=DELL\SQLEXPRESS;Initial Catalog=WFA3DotNet;Integrated Security=True");
                            cmd = new SqlCommand("insert into adoemp values(@ename,@esal,@depno)", con);
                            cmd.Parameters.Add("@ename", SqlDbType.VarChar, 20).Value = ename;
                            cmd.Parameters.Add("@esal", SqlDbType.Float).Value = esal;
                            cmd.Parameters.Add("@depno", SqlDbType.Int).Value = depno;
                            con.Open();
                            int i = cmd.ExecuteNonQuery();
                            d.ShowData();
                            // return i;

                        }

                        catch (Exception ex)
                        {
                            Console.WriteLine($"{ex.Message}");
                            //return 1;
                        }
                        finally
                        {
                            con.Close();
                        }

                        break;
                    case 2:
                        try
                        {
                            //Console.WriteLine("Enter employee Id");
                            //var eid = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Enter Emp Name");
                            var ename = Console.ReadLine();
                            Console.WriteLine("Enter Emp Salary");
                            var esal = Convert.ToSingle(Console.ReadLine());
                            Console.WriteLine("Enter Emp dept id");
                            var depno = Convert.ToInt32(Console.ReadLine());
                            con = new SqlConnection(@"Data Source=DELL\SQLEXPRESS;Initial Catalog=WFA3DotNet;Integrated Security=True");
                            //update Employeetab set EmpName=@ename,Salary=@esal,DeptNo=@did where EmpId=@empid
                            cmd = new SqlCommand("update adoemp set ename=@ename,esal=@esal where depno=@depno", con);
                            //cmd.Parameters.Add("@eId", SqlDbType.Int).Value = eid;
                            cmd.Parameters.Add("@ename", SqlDbType.VarChar, 20).Value = ename;
                            cmd.Parameters.Add("@esal", SqlDbType.Float).Value = esal;
                            cmd.Parameters.Add("@depno", SqlDbType.Int).Value = depno;
                            con.Open();

                            int i = cmd.ExecuteNonQuery();
                            Console.WriteLine("one row updated using parameters to the table");
                            d.ShowData();
                           // return i;


                        }
                        catch (Exception ex)
                        {

                            Console.WriteLine(ex.Message);
                           // return 1;
                        }
                        finally
                        {
                            con.Close();
                        }
                        break;
                    case 3:
                        try
                        {
                            Console.WriteLine("Enter employee Id");
                            var eid = Convert.ToInt32(Console.ReadLine());

                            con = new SqlConnection(@"Data Source=DELL\SQLEXPRESS;Initial Catalog=WFA3DotNet;Integrated Security=True");
                            cmd = new SqlCommand("delete from adoemp where eid=@eid", con);
                            cmd.Parameters.Add("@eid", SqlDbType.Int).Value = eid;

                            con.Open();
                            int i = cmd.ExecuteNonQuery();
                            Console.WriteLine("one row deleted using parameters to the table");
                            d.ShowData();
                           // return i;


                        }
                        catch (Exception ex)
                        {

                            Console.WriteLine(ex.Message);
                           // return 1;
                        }
                        finally
                        {
                            con.Close();
                        }
                        break;
                    default:
                        Console.WriteLine("wrong choice");
                        break;
                }
                Console.WriteLine("Do U want to continue(y/n)?");
                a = Convert.ToChar(Console.ReadLine());

            } while (a == 'y');

        }
    }
}
