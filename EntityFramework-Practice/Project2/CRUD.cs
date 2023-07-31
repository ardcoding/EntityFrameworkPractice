
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityFramework_Practice.Context;
using EntityFramework_Practice.Entities;
using Microsoft.EntityFrameworkCore;

namespace Project2 
{ 
    public class CRUD : ICRUD
    {
        BusinessDbContext context = new();

        public CRUD(BusinessDbContext context) {
            this.context = context;
        }

        public async Task Create()
        {
            Project proje1 = new()
            {
                ProjectName = "Proje1",
                ProjectCost = 500,
            };

            Project proje2 = new()
            {
                ProjectName = "Proje2",
                ProjectCost = 700,
            };

            Project proje3 = new()
            {
                ProjectName = "Proje3",
                ProjectCost = 600,
            };

            Employee employee1 = new()
            {
                EmployeeName = "Employee1",
                Salary = 100,
            };

            Employee employee2 = new()
            {
                EmployeeName = "Employee2",
                Salary = 300,
            };

            Employee employee3 = new()
            {
                EmployeeName = "Employee3",
                Salary = 200,
            };

            await context.AddRangeAsync(proje2, proje3);
            await context.SaveChangesAsync();
        }

        public async Task DeleteProject(int id)
        {
            Project project = context.Projects.SingleOrDefault(u => u.Id == id);
            context.Projects.Remove(project);
            context.SaveChangesAsync();
        }
        public async Task DeleteEmployee(int id)
        {
            Employee employee = context.Employees.SingleOrDefault(u => u.Id == id);
            context.Employees.Remove(employee);
            context.SaveChangesAsync();
        }
    }
    class Start 
    {
        public static async Task Main(string[] args)
        {
            BusinessDbContext context = new();
            ICRUD crud = new CRUD(context);

            #region Create
            // await crud.Create();
            #endregion

            #region Delete
            // await crud.DeleteProject(7);
            #endregion

            #region ToList
            //var projects = await context.Projects.ToListAsync();
            #endregion

            #region Where
            //var projects = context.Projects.Where(u => u.Id == 8);
            #endregion

            #region OrderBy
            //var projects = context.Projects.OrderBy(u => u.ProjectCost);
            #endregion

            #region ThenBy
            // var projects = context.Projects.OrderBy(u => u.ProjectCost).ThenBy(u => u.Id);
            #endregion

            #region Single
            // var employees = await context.Employees.SingleAsync(u => u.Id == 3);
            #endregion

            #region SingleOrDefault
            // var employees = await context.Employees.SingleOrDefaultAsync(u => u.Id == 99);
            #endregion

            #region First
            // var employees = await context.Employees.FirstAsync();
            #endregion

            #region FirstOrDefault
            // var employees = await context.Employees.FirstOrDefaultAsync(u => u.Id == 88);
            #endregion

            #region Last
            // var employees = await context.Employees.OrderBy(u=>u.Salary).LastAsync();
            #endregion

            #region LastOrDefault
            // var employees = await context.Employees.OrderBy(u=>u.Salary).LastOrDefaultAsync();
            #endregion

            #region Find
            // var employees = await context.Employees.FindAsync(1);
            #endregion

            #region Count
            //var project = await context.Projects.CountAsync();
            #endregion

            #region Any
            // var project = await context.Projects.AnyAsync();
            #endregion

            #region All
            // var project = await context.Projects.AllAsync(u=>u.Id==2);
            #endregion

            #region Max - Min
            //var project = await context.Projects.MaxAsync(u => u.Id);
            //var project2 = await context.Projects.MinAsync(u=>u.Id);
            #endregion

            #region Sum - Average
            // var project = await context.Projects.SumAsync(u => u.ProjectCost);
            // var project2 = await context.Projects.AverageAsync(u => u.ProjectCost);
            #endregion

            #region Contains - StartsWith - EndsWith
            // var project = await context.Projects.Where(u => u.ProjectName.Contains("Proje")).ToListAsync();
            // var project2 = await context.Projects.Where(u => u.ProjectName.StartsWith("P")).ToListAsync();
            // var project3 = await context.Projects.Where(u => u.ProjectName.EndsWith("1")).ToListAsync();
            #endregion

            #region ToDictionary ToArray
            // var project = await context.Projects.ToDictionaryAsync(u=> u.ProjectName, u => u.ProjectCost);
            // var project2 = await context.Projects.ToArrayAsync();
            #endregion

            #region Select - SelectMany
            /* var employee = context.Employees.Select(u => new Employee
            {
                Id = u.Id,
                EmployeeName = u.EmployeeName,
            });
            var project = await context.Projects.Include(u => u.Employees).SelectMany(u => u.Employees, (u,p) => new
            {
                u.ProjectName,
                u.ProjectCost,
                p.EmployeeName
            }).ToListAsync(); */
            #endregion

            #region GroupBy - ForEach Fonksiyonu
            /*
            //GroupBy
            var projects = await context.Projects.GroupBy(u => u.ProjectCost).Select(c => new
            {
                Count = c.Count(),
                ProjectCost = c.Key
            }).ToListAsync();

            //ForEach
            projects.ForEach(i =>
            {
                Console.WriteLine(i.ProjectCost);
            });*/
            #endregion

            #region ChangeTracker Property
            // await context.Projects.ToListAsync();
            //var entries = context.ChangeTracker.Entries();
            #endregion

            #region Entries Metodu
            //await context.Projects.ToListAsync();
            //context.ChangeTracker.Entries().ToList().ForEach(e =>
            //{
            //    if (e.State == EntityState.Unchanged)
            //    {
            //        Console.WriteLine("Değiştirilmedi");
            //    }
            //    else
            //    {
            //        Console.WriteLine("Değiştirildi");
            //    }
            //});
            #endregion

            #region HasChanges
            // var proje = await context.Projects.ToListAsync();
            // context.ChangeTracker.HasChanges();
            #endregion

            #region OriginalValue - GetDatabaseValue
            // var data = crud.Create();
            // context.Entry(data).OriginalValues.GetValue("");
            // await context.Entry(data).GetDatabaseValuesAsync();
            #endregion

            #region AsNoTracking
            /* var projects = await context.Projects.AsNoTracking().ToListAsync();
            foreach (var project in projects)
            {
                Console.WriteLine(project.ProjectName);
                project.ProjectName = $"yeni - {project.ProjectName}";
                context.Projects.Update(project);
            }
            await context.SaveChangesAsync(); */
            #endregion

            #region AsNoTrackingWithIdentityResolution
            // var projects = await context.Projects.Include(p => p.Employees).AsNoTrackingWithIdentityResolution().ToListAsync();
            #endregion

            #region İlişkisel tablolara veri ekleme
            /*Project project = new()
            {
                ProjectName = "Project A",
                Employees = new HashSet<ProjectEmployee>()
                {
                    new()
                    {
                        Employee = new(){ EmployeeName = "Employee A"}
                    },
                }
            };
            await context.AddAsync(project);
            await context.SaveChangesAsync();*/
            #endregion

            #region İlişkisel tablolarda güncelleme
            /*
            Project? project = await context.Projects.FindAsync(10);
            Employee? employee = await context.Employees.FindAsync(1);
            employee.Projects.Add(project);
            await context.SaveChangesAsync();
            */
            #endregion

            #region İlişkisel tablolarda silme
            /*
            Project? project = await context.Projects.FindAsync(10);
            Employee? employee = await context.Employees.FindAsync(1);
            employee.Projects.Remove(project);
            await context.SaveChangesAsync();
            */
            #endregion
            Console.WriteLine();
        }
    }
}
