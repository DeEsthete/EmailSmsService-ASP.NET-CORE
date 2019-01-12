using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess
{
    public class MainContext : DbContext
    {
        public MainContext(DbContextOptions<MainContext> options)
            : base(options)
        { }

        public DbSet<SmsMessage> SmsMessages { get; set; }
        public DbSet<EmailMessage> EmailMessages { get; set; }
    }
}
