using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Windows;
using FitnesClubEF.Models;
namespace FitnesClubEF
{
    public class MyVisitor
    {
        public int id { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public DateTime Birthday { get; set; }
        public string bday => Birthday.ToString("dd.MM.yyyy");
        public string Phone { get; set; }
        public double Balance { get; set; }
        public bool Status { get; set; } = false;
    }
    class FitnesClubDB
    {
        public static List<MyVisitor> SelectMyVisitors()
        {
            List<MyVisitor> MyVisitors = new List<MyVisitor>();
            using (var ctx = new FitnesClubContext())
            {
                foreach (var item in ctx.Visitors)
                {
                    var v = new MyVisitor()
                    {
                        LastName = item.LastName,
                        FirstName = item.FirstName,
                        Balance = ((double)item.Balance),
                        Birthday = item.BirthDay,
                        id = item.Id,
                        Phone = item.Phone
                    };
                    if (item.Status == null)
                    {
                        v.Status = false;
                    }
                    else
                    {
                        v.Status = (bool)item.Status;
                    }
                    MyVisitors.Add(v);
                }
            }
            return MyVisitors;
        }
        public static void Insert(MyVisitor MyVisitor)
        {
            using (var ctx = new FitnesClubContext())
            {
                ctx.Visitors.Add(new Visitor()
                {
                    LastName = MyVisitor.LastName,
                    FirstName = MyVisitor.FirstName,
                    Balance = ((decimal)MyVisitor.Balance),
                    Id = MyVisitor.id,
                    BirthDay = MyVisitor.Birthday,
                    Phone = MyVisitor.Phone
                });
                ctx.SaveChanges();
            }
        }
        public static void Update(MyVisitor MyVisitor)
        {
            using (var ctx = new FitnesClubContext())
            {
                var vis = ctx.Visitors.First(o => o.Id == MyVisitor.id);
                vis.LastName = MyVisitor.LastName;
                vis.FirstName = MyVisitor.FirstName;
                vis.Balance = ((decimal)MyVisitor.Balance);
                vis.Id = MyVisitor.id;
                vis.BirthDay = MyVisitor.Birthday;
                vis.Phone = MyVisitor.Phone;
                ctx.Visitors.Update(vis);
                ctx.SaveChanges();
            }
        }
        public static void Delete(MyVisitor MyVisitor)
        {
            using (var ctx = new FitnesClubContext())
            {
                ctx.Visitors.Remove(ctx.Visitors.First(o => o.Id == MyVisitor.id));
                ctx.Npuxogs.Remove(ctx.Npuxogs.First(o => o.VisitorId == MyVisitor.id));
                try
                {
                    var pacxog = ctx.Pacxogs.First(o => o.VisitorId == MyVisitor.id);
                    if (pacxog != null)
                    {
                        ctx.Pacxogs.Remove(pacxog);
                    }
                }
                catch (Exception e)
                {

                }
                try
                {
                    var SectionVisitor = ctx.SectionVisitors.First(o => o.VisitorId == MyVisitor.id);
                    if (SectionVisitor != null)
                    {
                        ctx.SectionVisitors.Remove(SectionVisitor);
                    }
                    ctx.SectionVisitors.Remove(ctx.SectionVisitors.First(o => o.VisitorId == MyVisitor.id));
                }
                catch (Exception e)
                {
                    
                }                
                ctx.SaveChanges();
            }
        }
    }
}