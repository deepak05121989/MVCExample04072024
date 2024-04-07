using MVCWeb.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCWeb.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        public ActionResult Index()
        {

            var list = GetStudent();


            return View(list);
        }

        // GET: Student/Details/5
        public ActionResult Details(int id)
        {
            Student student = new Student();
            try
            {
                var listS = GetStudent(id);
                foreach (Student s in listS)
                {
                    student.Name = s.Name;
                    student.Address = s.Address;
                    student.mobile = s.mobile;
                }

            }
            catch { }
            return View(student);
        }

        // GET: Student/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Student/Create
        [HttpPost]
        public ActionResult Create(Student student)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["TestDBConnection"].ConnectionString))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandText = "insert into student([Name], [Address], [mobile]) values(@Name, @Address, @mobile)";
                    cmd.Connection = con;
                    cmd.Parameters.AddWithValue("@Name", student.Name);
                    cmd.Parameters.AddWithValue("@Address", student.Address);
                    cmd.Parameters.AddWithValue("@mobile", student.mobile);
                    int result= cmd.ExecuteNonQuery();
                    if(result>0)
                    {
                        return RedirectToAction("Index");
                    }


                }

               
            }
            catch
            {
                return View();
            }
            return View();
        }

        // GET: Student/Edit/5
        public ActionResult Edit(int id)
        {
            Student student = new Student();
            try
            {
               var listS = GetStudent(id);
                foreach(Student s in listS)
                {
                    student.Name = s.Name;
                    student.Address = s.Address;
                    student.mobile = s.mobile;
                }

            }
            catch { }
            return View(student);
        }

        // POST: Student/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Student student)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["TestDBConnection"].ConnectionString))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandText = "update student set [Name]=@Name, [Address]=@Address, [mobile]=@mobile where roleno=@roleno";
                    cmd.Connection = con;
                    cmd.Parameters.AddWithValue("@Name", student.Name);
                    cmd.Parameters.AddWithValue("@Address", student.Address);
                    cmd.Parameters.AddWithValue("@mobile", student.mobile);
                    cmd.Parameters.AddWithValue("@roleno", id);
                    int result = cmd.ExecuteNonQuery();
                    if (result > 0)
                    {
                        return RedirectToAction("Index");
                    }


                }


            }
            catch
            {
                return View();
            }
            return View();
        }

        // GET: Student/Delete/5
        public ActionResult Delete(int id)
        {
            Student student = new Student();
            try
            {
                var listS = GetStudent(id);
                foreach (Student s in listS)
                {
                    student.Name = s.Name;
                    student.Address = s.Address;
                    student.mobile = s.mobile;
                }

            }
            catch { }
            return View(student);
        }

        // POST: Student/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Student student)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["TestDBConnection"].ConnectionString))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandText = "delete student where roleno=@roleno";
                    cmd.Connection = con;
                    cmd.Parameters.AddWithValue("@roleno", id);
                    int result = cmd.ExecuteNonQuery();
                    if (result > 0)
                    {
                        return RedirectToAction("Index");
                    }


                }


            }
            catch
            {
                return View();
            }
            return View();
        }


        private List<Student> GetStudent(int id=0)
        {

            List<Student> list = new List<Student>();
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["TestDBConnection"].ConnectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand();
                if (id > 0)
                {
                    cmd.CommandText = "select * from student where roleno='" + id + "'";
                }
                else
                {
                    cmd.CommandText = "select * from student";
                }
                cmd.Connection = con;
                SqlDataReader dataReader = cmd.ExecuteReader();
                while (dataReader.Read())
                {
                    Student student = new Student
                    {
                        Name = dataReader["name"].ToString(),
                        Address = dataReader["address"].ToString(),
                        mobile = dataReader["mobile"].ToString(),
                        RoleNo = dataReader["roleno"].ToString()

                    };
                    list.Add(student);

                }

                return list;
            }

        }
    }
}
