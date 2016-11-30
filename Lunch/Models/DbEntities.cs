using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Lunch.Models
{
    public class DbEntities : DbContext
    {
        //base中的字符串为web.config中设置的数据库连接字符串名
        public DbEntities() : base("name=SQLConnString")
        {
            //表示创建数据库的方式
            Database.SetInitializer<DbEntities>(new CreateDatabaseIfNotExists<DbEntities>());
        }
        public DbSet<User> User { get; set; }
        public DbSet<Order> Order { get; set; }
    }
}