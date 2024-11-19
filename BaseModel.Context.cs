namespace WpfApp1
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class LogiClikeEntities : DbContext
    {
        private static LogiClikeEntities _context;

        public static LogiClikeEntities GetContext()
        {
            if (_context == null)
                _context = new LogiClikeEntities();
            return _context;
        }
        public LogiClikeEntities()
            : base("name=LogiClikeEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Account> Account { get; set; }
        public virtual DbSet<Childs> Childs { get; set; }
        public virtual DbSet<FaultTypes> FaultTypes { get; set; }
        public virtual DbSet<Requests> Requests { get; set; }
        public virtual DbSet<RequestStatus> RequestStatus { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<Subject> Subject { get; set; }
        public virtual DbSet<Teachers> Teachers { get; set; }
    }
}
