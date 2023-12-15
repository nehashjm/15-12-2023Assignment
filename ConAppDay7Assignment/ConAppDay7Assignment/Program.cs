using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ConAppDay7Assignment
{
    internal class Program
    {
        public static SqlConnection con;
        public static SqlCommand cmd;
        public static SqlDataAdapter sda;
        public static DataSet ds;
        public static string constr = "server=DESKTOP-0GDER0O;database=LibraryDB;trusted_connection=true;";
        static void Main(string[] args)
        {
            
            
                Console.WriteLine("choose the operation from the list");
                Console.WriteLine("1.retrive \n 2.insert \n 3.update\n 4delete \n 5search");
                int op = int.Parse(Console.ReadLine());
                switch (op)
                {
                    case 1:
                        {
                        retrive();
                            break;
                        }
                    case 2:
                        {
                           insert();
                            break;
                        }
                    case 3:
                        {
                        update();
                            break;
                        }
                    case 4:
                        {
                        delete();
                            break;
                        }
                    case 5:
                    {
                        search();
                        break;
                    }
                    default:
                        {
                            return;
                        }
                
                
            }
            
              
        }
        static void retrive()
        {
            try
            {
                con = new SqlConnection(constr);
                cmd = new SqlCommand("select * from books", con);
                sda = new SqlDataAdapter(cmd);
                ds = new DataSet();
                con.Open();
                sda.Fill(ds, "books");
                con.Close();
                Console.WriteLine("BookId Title Author genere quanity");
                foreach (DataRow row in ds.Tables["books"].Rows)
                {
                    Console.WriteLine(row[0] + "\t");
                    Console.WriteLine(row[1] + "\t");
                    Console.WriteLine(row[2] + "\t");
                    Console.WriteLine(row[3] + "\t");
                    Console.WriteLine(row[4] + "\t");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("error"+e.Message);
            }
            finally 
            {
                Console.ReadKey();
            }

        }
        static void insert()
        {
            try
            {
                con = new SqlConnection(constr);
                cmd = new SqlCommand("select * from books", con);
                sda = new SqlDataAdapter(cmd);
                ds = new DataSet();
                con.Open();
                sda.Fill(ds, "books");
                DataTable dt = ds.Tables["books"];
                DataRow dr = dt.NewRow();
                Console.WriteLine("Enter Book ID");
                dr["BookId"] = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter book Title");
                dr["Title"] = Console.ReadLine();
                Console.WriteLine("Enter book author");
                dr["Author"] = Console.ReadLine();
                Console.WriteLine("Enter genere");
                dr["Genere"] = Console.ReadLine();
                Console.WriteLine("Enter quantity");
                dr["Quantity"] =   int.Parse(Console.ReadLine());
                dt.Rows.Add(dr);
                SqlCommandBuilder builder = new SqlCommandBuilder(sda);
                sda.Update(ds, "books");
                Console.WriteLine("book record inserted");
                con.Close();

            }
            catch (Exception ex)
            {
                Console.WriteLine("error" + ex.Message);
            }
            finally
            {
                Console.ReadKey();
            }
        }
        static void update()
        {
            try
            {
                con = new SqlConnection(constr);
                cmd = new SqlCommand("select * from books", con);
                sda = new SqlDataAdapter(cmd);
                ds = new DataSet();
                con.Open();
                sda.Fill(ds, "books");
                Console.WriteLine("enter book id to update");
                int bid = int.Parse(Console.ReadLine());
                DataRow dr = null;
                foreach (DataRow row in ds.Tables["books"].Rows)
                {
                    if ((int)row["BookId"] == bid)
                    {
                        dr = row;
                        break;
                    }
                }
                if (dr == null)
                {
                    Console.WriteLine("no such id exists");
                }
                else
                {

                    Console.WriteLine("Enter book Title");
                    dr["Title"] = Console.ReadLine();
                    Console.WriteLine("Enter book author");
                    dr["Author"] = Console.ReadLine();
                    Console.WriteLine("Enter genere");
                    dr["Genere"] = Console.ReadLine();
                    Console.WriteLine("Enter quantity");
                    dr["Quantity"] = int.Parse(Console.ReadLine());
                    SqlCommandBuilder builder = new SqlCommandBuilder(sda);
                    sda.Update(ds, "books");
                    Console.WriteLine("record updated");
                }


            }
            catch (Exception e)
            {
                Console.WriteLine("Error" + e.Message);
            }
            finally
            {

                Console.ReadKey();
            }

        }
        static void delete()
        {
            try
            {
                con = new SqlConnection(constr);
                cmd = new SqlCommand("select * from books", con);
                sda = new SqlDataAdapter(cmd);
                ds = new DataSet();
                con.Open();
                sda.Fill(ds, "books");
                Console.WriteLine("enter book id to delete");
                int bid = int.Parse(Console.ReadLine());
                DataRow dr = null;
                foreach (DataRow row in ds.Tables["books"].Rows)
                {
                    if ((int)row["BookId"] == bid)
                    {
                        dr = row;
                        break;
                    }
                }
                if (dr == null)
                {
                    Console.WriteLine("no such id exists");
                }
                else
                {
                    dr.Delete();
                    SqlCommandBuilder builder = new SqlCommandBuilder(sda);
                    sda.Update(ds, "books");
                    Console.WriteLine("Record deleted");
                }

            }
            catch (Exception e)
            {
                Console.WriteLine("Error" + e.Message);
            }
            finally
            {

                Console.ReadKey();
            }
        }
        static void search()
        {
            try
            {
                con = new SqlConnection(constr);
                cmd = new SqlCommand("select * from books", con);
                sda = new SqlDataAdapter(cmd);
                ds = new DataSet();
                con.Open();
                sda.Fill(ds, "books");
                Console.WriteLine("enter book id to search");
                int bid = int.Parse(Console.ReadLine());
                DataRow dr = null;
                foreach (DataRow row in ds.Tables["books"].Rows)
                {
                    if ((int)row["BookId"] == bid)
                    {
                        dr = row;
                        Console.WriteLine("Record found details as follows");
                        Console.WriteLine("Book id" + row["BookId"]);
                        Console.WriteLine("Book name" + row["Title"]);
                        Console.WriteLine("author" + row["Author"]);
                        Console.WriteLine("genere" + row["Genere"]);
                        Console.WriteLine("quantity" + row["Quantity"]);
                    }
                }
                if (dr == null)
                {
                    Console.WriteLine("no such id exists");
                }


            }
            catch (Exception e)
            {
                Console.WriteLine("Error" + e.Message);
            }
            finally
            {

                Console.ReadKey();
            }
        }
    }
}
