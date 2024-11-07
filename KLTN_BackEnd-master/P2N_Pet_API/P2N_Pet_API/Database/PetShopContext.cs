using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using P2N_Pet_API.Database.PetShopModels;

#nullable disable

namespace P2N_Pet_API.Database
{
    public partial class PetShopContext : DbContext
    {
        public PetShopContext()
        {
        }

        public PetShopContext(DbContextOptions<PetShopContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Age> Ages { get; set; }
        public virtual DbSet<Brand> Brands { get; set; }
        public virtual DbSet<Brandproduct> Brandproducts { get; set; }
        public virtual DbSet<Breed> Breeds { get; set; }
        public virtual DbSet<Cart> Carts { get; set; }
        public virtual DbSet<Cartitem> Cartitems { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Chatcontent> Chatcontents { get; set; }
        public virtual DbSet<Chatroom> Chatrooms { get; set; }
        public virtual DbSet<Chatroomuser> Chatroomusers { get; set; }
        public virtual DbSet<Color> Colors { get; set; }
        public virtual DbSet<Contact> Contacts { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<News> News { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Productcomment> Productcomments { get; set; }
        public virtual DbSet<Productdetail> Productdetails { get; set; }
        public virtual DbSet<Productimage> Productimages { get; set; }
        public virtual DbSet<Productimagefor> Productimagefors { get; set; }
        public virtual DbSet<Promotion> Promotions { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Sex> Sexes { get; set; }
        public virtual DbSet<Size> Sizes { get; set; }
        public virtual DbSet<Status> Statuses { get; set; }
        public virtual DbSet<Statusdetail> Statusdetails { get; set; }
        public virtual DbSet<Statusorder> Statusorders { get; set; }
        public virtual DbSet<Statuspayment> Statuspayments { get; set; }
        public virtual DbSet<Supplier> Suppliers { get; set; }
        public virtual DbSet<Typenews> Typenews { get; set; }
        public virtual DbSet<Typepayment> Typepayments { get; set; }
        public virtual DbSet<Typeproduct> Typeproducts { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseMySql("server=157.119.251.140;port=4785;database=p2n_pet;user=root;password=Y00t@()742C0mp@Ny", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.19-mysql"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_unicode_ci");

            modelBuilder.Entity<Age>(entity =>
            {
                entity.ToTable("age");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Createdate)
                    .HasColumnType("datetime")
                    .HasColumnName("createdate");

                entity.Property(e => e.Createuser).HasColumnName("createuser");

                entity.Property(e => e.Orderview).HasColumnName("orderview");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.Property(e => e.Title)
                    .HasMaxLength(255)
                    .HasColumnName("title")
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.Updatedate)
                    .HasColumnType("datetime")
                    .HasColumnName("updatedate");

                entity.Property(e => e.Updateuser).HasColumnName("updateuser");
            });

            modelBuilder.Entity<Brand>(entity =>
            {
                entity.ToTable("brand");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Address)
                    .HasColumnType("text")
                    .HasColumnName("address");

                entity.Property(e => e.Createdate)
                    .HasColumnType("datetime")
                    .HasColumnName("createdate");

                entity.Property(e => e.Createuser).HasColumnName("createuser");

                entity.Property(e => e.Email)
                    .HasMaxLength(255)
                    .HasColumnName("email");

                entity.Property(e => e.Phone)
                    .HasMaxLength(25)
                    .HasColumnName("phone");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.Property(e => e.Updatedate)
                    .HasColumnType("datetime")
                    .HasColumnName("updatedate");

                entity.Property(e => e.Updateuser).HasColumnName("updateuser");
            });

            modelBuilder.Entity<Brandproduct>(entity =>
            {
                entity.ToTable("brandproduct");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Brandid).HasColumnName("brandid");

                entity.Property(e => e.Createdate)
                    .HasColumnType("datetime")
                    .HasColumnName("createdate");

                entity.Property(e => e.Createuser).HasColumnName("createuser");

                entity.Property(e => e.Productdetailid).HasColumnName("productdetailid");

                entity.Property(e => e.Quantity).HasColumnName("quantity");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.Property(e => e.Updatedate)
                    .HasColumnType("datetime")
                    .HasColumnName("updatedate");

                entity.Property(e => e.Updateuser).HasColumnName("updateuser");
            });

            modelBuilder.Entity<Breed>(entity =>
            {
                entity.ToTable("breed");

                entity.HasIndex(e => e.Breedid, "breedid");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Breedid).HasColumnName("breedid");

                entity.Property(e => e.Createdate)
                    .HasColumnType("datetime")
                    .HasColumnName("createdate");

                entity.Property(e => e.Createuser).HasColumnName("createuser");

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .HasColumnName("name")
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.Property(e => e.Updatedate)
                    .HasColumnType("datetime")
                    .HasColumnName("updatedate");

                entity.Property(e => e.Updateuser).HasColumnName("updateuser");

                entity.HasOne(d => d.BreedNavigation)
                    .WithMany(p => p.InverseBreedNavigation)
                    .HasForeignKey(d => d.Breedid)
                    .HasConstraintName("breed_ibfk_1");
            });

            modelBuilder.Entity<Cart>(entity =>
            {
                entity.ToTable("cart");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Createdate)
                    .HasColumnType("datetime")
                    .HasColumnName("createdate");

                entity.Property(e => e.Createuser).HasColumnName("createuser");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.Property(e => e.Updatedate)
                    .HasColumnType("datetime")
                    .HasColumnName("updatedate");

                entity.Property(e => e.Updateuser).HasColumnName("updateuser");

                entity.Property(e => e.Userid).HasColumnName("userid");
            });

            modelBuilder.Entity<Cartitem>(entity =>
            {
                entity.ToTable("cartitem");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Brandid).HasColumnName("brandid");

                entity.Property(e => e.Cartid).HasColumnName("cartid");

                entity.Property(e => e.Createdate)
                    .HasColumnType("datetime")
                    .HasColumnName("createdate");

                entity.Property(e => e.Createuser).HasColumnName("createuser");

                entity.Property(e => e.Orderid).HasColumnName("orderid");

                entity.Property(e => e.Pricediscount).HasColumnName("pricediscount");

                entity.Property(e => e.Productdetailid).HasColumnName("productdetailid");

                entity.Property(e => e.Quantity).HasColumnName("quantity");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.Property(e => e.Updatedate)
                    .HasColumnType("datetime")
                    .HasColumnName("updatedate");

                entity.Property(e => e.Updateuser).HasColumnName("updateuser");
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("category");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Categoryrootid).HasColumnName("categoryrootid");

                entity.Property(e => e.Createdate)
                    .HasColumnType("datetime")
                    .HasColumnName("createdate");

                entity.Property(e => e.Createuser).HasColumnName("createuser");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.Property(e => e.Title)
                    .HasMaxLength(255)
                    .HasColumnName("title")
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.Typeproductid).HasColumnName("typeproductid");

                entity.Property(e => e.Updatedate)
                    .HasColumnType("datetime")
                    .HasColumnName("updatedate");

                entity.Property(e => e.Updateuser).HasColumnName("updateuser");
            });

            modelBuilder.Entity<Chatcontent>(entity =>
            {
                entity.ToTable("chatcontent");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Chatroomid).HasColumnName("chatroomid");

                entity.Property(e => e.Content)
                    .HasColumnType("text")
                    .HasColumnName("content");

                entity.Property(e => e.Createdate)
                    .HasColumnType("datetime")
                    .HasColumnName("createdate");

                entity.Property(e => e.Createuser).HasColumnName("createuser");

                entity.Property(e => e.Isnew).HasColumnName("isnew");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.Property(e => e.Updatedate)
                    .HasColumnType("datetime")
                    .HasColumnName("updatedate");

                entity.Property(e => e.Updateuser).HasColumnName("updateuser");

                entity.Property(e => e.Userid).HasColumnName("userid");
            });

            modelBuilder.Entity<Chatroom>(entity =>
            {
                entity.ToTable("chatroom");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Createdate)
                    .HasColumnType("datetime")
                    .HasColumnName("createdate");

                entity.Property(e => e.Createuser).HasColumnName("createuser");

                entity.Property(e => e.Numchatnewcustomer).HasColumnName("numchatnewcustomer");

                entity.Property(e => e.Numchatnewmanager).HasColumnName("numchatnewmanager");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.Property(e => e.Updatedate)
                    .HasColumnType("datetime")
                    .HasColumnName("updatedate");

                entity.Property(e => e.Updateuser).HasColumnName("updateuser");
            });

            modelBuilder.Entity<Chatroomuser>(entity =>
            {
                entity.ToTable("chatroomuser");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Chatroomid).HasColumnName("chatroomid");

                entity.Property(e => e.Createdate)
                    .HasColumnType("datetime")
                    .HasColumnName("createdate");

                entity.Property(e => e.Createuser).HasColumnName("createuser");

                entity.Property(e => e.Deletedate)
                    .HasColumnType("datetime")
                    .HasColumnName("deletedate");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.Property(e => e.Updatedate)
                    .HasColumnType("datetime")
                    .HasColumnName("updatedate");

                entity.Property(e => e.Updateuser).HasColumnName("updateuser");

                entity.Property(e => e.Userid).HasColumnName("userid");
            });

            modelBuilder.Entity<Color>(entity =>
            {
                entity.ToTable("color");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Createdate)
                    .HasColumnType("datetime")
                    .HasColumnName("createdate");

                entity.Property(e => e.Createuser).HasColumnName("createuser");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.Property(e => e.Title)
                    .HasMaxLength(255)
                    .HasColumnName("title")
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.Updatedate)
                    .HasColumnType("datetime")
                    .HasColumnName("updatedate");

                entity.Property(e => e.Updateuser).HasColumnName("updateuser");
            });

            modelBuilder.Entity<Contact>(entity =>
            {
                entity.ToTable("contact");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Content)
                    .HasColumnType("text")
                    .HasColumnName("content");

                entity.Property(e => e.Createdate)
                    .HasColumnType("datetime")
                    .HasColumnName("createdate");

                entity.Property(e => e.Email)
                    .HasMaxLength(255)
                    .HasColumnName("email");

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .HasColumnName("name")
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.Phone)
                    .HasMaxLength(25)
                    .HasColumnName("phone");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.Property(e => e.Subject)
                    .HasMaxLength(255)
                    .HasColumnName("subject")
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.ToTable("customer");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Address)
                    .HasMaxLength(255)
                    .HasColumnName("address")
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.Birthday)
                    .HasColumnType("datetime")
                    .HasColumnName("birthday");

                entity.Property(e => e.Createdate)
                    .HasColumnType("datetime")
                    .HasColumnName("createdate");

                entity.Property(e => e.Createuser).HasColumnName("createuser");

                entity.Property(e => e.Email)
                    .HasMaxLength(255)
                    .HasColumnName("email");

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .HasColumnName("name")
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.Phone)
                    .HasMaxLength(25)
                    .HasColumnName("phone");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.Property(e => e.Updatedate)
                    .HasColumnType("datetime")
                    .HasColumnName("updatedate");

                entity.Property(e => e.Updateuser).HasColumnName("updateuser");

                entity.Property(e => e.Userid).HasColumnName("userid");
            });

            modelBuilder.Entity<News>(entity =>
            {
                entity.ToTable("news");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Content)
                    .HasColumnType("text")
                    .HasColumnName("content");

                entity.Property(e => e.Createdate)
                    .HasColumnType("datetime")
                    .HasColumnName("createdate");

                entity.Property(e => e.Createuser).HasColumnName("createuser");

                entity.Property(e => e.Htmlcontent)
                    .HasColumnType("text")
                    .HasColumnName("htmlcontent");

                entity.Property(e => e.Image)
                    .HasColumnType("text")
                    .HasColumnName("image");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.Property(e => e.Title)
                    .HasMaxLength(512)
                    .HasColumnName("title")
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.Typenewsid).HasColumnName("typenewsid");

                entity.Property(e => e.Updatedate)
                    .HasColumnType("datetime")
                    .HasColumnName("updatedate");

                entity.Property(e => e.Updateuser).HasColumnName("updateuser");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.ToTable("order");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Cartid).HasColumnName("cartid");

                entity.Property(e => e.Createdate)
                    .HasColumnType("datetime")
                    .HasColumnName("createdate");

                entity.Property(e => e.Createuser).HasColumnName("createuser");

                entity.Property(e => e.Customerid).HasColumnName("customerid");

                entity.Property(e => e.Note)
                    .HasColumnType("text")
                    .HasColumnName("note");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.Property(e => e.Statusorderid).HasColumnName("statusorderid");

                entity.Property(e => e.Statuspaymentid).HasColumnName("statuspaymentid");

                entity.Property(e => e.Totalmoney).HasColumnName("totalmoney");

                entity.Property(e => e.Typepaymentid).HasColumnName("typepaymentid");

                entity.Property(e => e.Updatedate)
                    .HasColumnType("datetime")
                    .HasColumnName("updatedate");

                entity.Property(e => e.Updateuser).HasColumnName("updateuser");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("product");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Breedid).HasColumnName("breedid");

                entity.Property(e => e.Categoryid).HasColumnName("categoryid");

                entity.Property(e => e.Content)
                    .HasColumnType("text")
                    .HasColumnName("content");

                entity.Property(e => e.Createdate)
                    .HasColumnType("datetime")
                    .HasColumnName("createdate");

                entity.Property(e => e.Createuser).HasColumnName("createuser");

                entity.Property(e => e.Productname)
                    .HasMaxLength(255)
                    .HasColumnName("productname")
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.Property(e => e.Supplierid).HasColumnName("supplierid");

                entity.Property(e => e.Updatedate)
                    .HasColumnType("datetime")
                    .HasColumnName("updatedate");

                entity.Property(e => e.Updateuser).HasColumnName("updateuser");
            });

            modelBuilder.Entity<Productcomment>(entity =>
            {
                entity.ToTable("productcomment");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Commentrootid).HasColumnName("commentrootid");

                entity.Property(e => e.Content)
                    .HasColumnType("text")
                    .HasColumnName("content");

                entity.Property(e => e.Createdate)
                    .HasColumnType("datetime")
                    .HasColumnName("createdate");

                entity.Property(e => e.Createuser).HasColumnName("createuser");

                entity.Property(e => e.Productdetailid).HasColumnName("productdetailid");

                entity.Property(e => e.Rating).HasColumnName("rating");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.Property(e => e.Updatedate)
                    .HasColumnType("datetime")
                    .HasColumnName("updatedate");

                entity.Property(e => e.Updateuser).HasColumnName("updateuser");

                entity.Property(e => e.Userid).HasColumnName("userid");
            });

            modelBuilder.Entity<Productdetail>(entity =>
            {
                entity.ToTable("productdetail");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Ageid).HasColumnName("ageid");

                entity.Property(e => e.Colorid).HasColumnName("colorid");

                entity.Property(e => e.Createdate)
                    .HasColumnType("datetime")
                    .HasColumnName("createdate");

                entity.Property(e => e.Createuser).HasColumnName("createuser");

                entity.Property(e => e.Discount).HasColumnName("discount");

                entity.Property(e => e.Price).HasColumnName("price");

                entity.Property(e => e.Productid).HasColumnName("productid");

                entity.Property(e => e.Quantity).HasColumnName("quantity");

                entity.Property(e => e.Sexid).HasColumnName("sexid");

                entity.Property(e => e.Sizeid).HasColumnName("sizeid");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.Property(e => e.Statusdetailid).HasColumnName("statusdetailid");

                entity.Property(e => e.Updatedate)
                    .HasColumnType("datetime")
                    .HasColumnName("updatedate");

                entity.Property(e => e.Updateuser).HasColumnName("updateuser");
            });

            modelBuilder.Entity<Productimage>(entity =>
            {
                entity.ToTable("productimage");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Createdate)
                    .HasColumnType("datetime")
                    .HasColumnName("createdate");

                entity.Property(e => e.Createuser).HasColumnName("createuser");

                entity.Property(e => e.Image)
                    .HasMaxLength(255)
                    .HasColumnName("image");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.Property(e => e.Updatedate)
                    .HasColumnType("datetime")
                    .HasColumnName("updatedate");

                entity.Property(e => e.Updateuser).HasColumnName("updateuser");
            });

            modelBuilder.Entity<Productimagefor>(entity =>
            {
                entity.HasKey(e => new { e.Id, e.Productimageid, e.Productdetailid })
                    .HasName("PRIMARY")
                    .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0, 0 });

                entity.ToTable("productimagefor");

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("id");

                entity.Property(e => e.Productimageid).HasColumnName("productimageid");

                entity.Property(e => e.Productdetailid).HasColumnName("productdetailid");

                entity.Property(e => e.Createdate)
                    .HasColumnType("datetime")
                    .HasColumnName("createdate");

                entity.Property(e => e.Createuser).HasColumnName("createuser");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.Property(e => e.Updatedate)
                    .HasColumnType("datetime")
                    .HasColumnName("updatedate");

                entity.Property(e => e.Updateuser).HasColumnName("updateuser");
            });

            modelBuilder.Entity<Promotion>(entity =>
            {
                entity.ToTable("promotion");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Createdate)
                    .HasColumnType("datetime")
                    .HasColumnName("createdate");

                entity.Property(e => e.Createuser).HasColumnName("createuser");

                entity.Property(e => e.Fromdate)
                    .HasColumnType("datetime")
                    .HasColumnName("fromdate");

                entity.Property(e => e.Image)
                    .HasMaxLength(255)
                    .HasColumnName("image");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.Property(e => e.Title)
                    .HasMaxLength(255)
                    .HasColumnName("title")
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.Todate)
                    .HasColumnType("datetime")
                    .HasColumnName("todate");

                entity.Property(e => e.Updatedate)
                    .HasColumnType("datetime")
                    .HasColumnName("updatedate");

                entity.Property(e => e.Updateuser).HasColumnName("updateuser");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("role");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.Property(e => e.Title)
                    .HasMaxLength(255)
                    .HasColumnName("title")
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");
            });

            modelBuilder.Entity<Sex>(entity =>
            {
                entity.ToTable("sex");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.Property(e => e.Title)
                    .HasMaxLength(255)
                    .HasColumnName("title")
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");
            });

            modelBuilder.Entity<Size>(entity =>
            {
                entity.ToTable("size");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Createdate)
                    .HasColumnType("datetime")
                    .HasColumnName("createdate");

                entity.Property(e => e.Createuser).HasColumnName("createuser");

                entity.Property(e => e.Orderview).HasColumnName("orderview");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.Property(e => e.Title)
                    .HasMaxLength(255)
                    .HasColumnName("title")
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.Typeproductid).HasColumnName("typeproductid");

                entity.Property(e => e.Updatedate)
                    .HasColumnType("datetime")
                    .HasColumnName("updatedate");

                entity.Property(e => e.Updateuser).HasColumnName("updateuser");
            });

            modelBuilder.Entity<Status>(entity =>
            {
                entity.ToTable("status");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Title)
                    .HasMaxLength(255)
                    .HasColumnName("title")
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");
            });

            modelBuilder.Entity<Statusdetail>(entity =>
            {
                entity.ToTable("statusdetail");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.Property(e => e.Title)
                    .HasMaxLength(255)
                    .HasColumnName("title")
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");
            });

            modelBuilder.Entity<Statusorder>(entity =>
            {
                entity.ToTable("statusorder");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.Property(e => e.Title)
                    .HasMaxLength(255)
                    .HasColumnName("title")
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");
            });

            modelBuilder.Entity<Statuspayment>(entity =>
            {
                entity.ToTable("statuspayment");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.Property(e => e.Title)
                    .HasMaxLength(255)
                    .HasColumnName("title")
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");
            });

            modelBuilder.Entity<Supplier>(entity =>
            {
                entity.ToTable("supplier");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Address)
                    .HasMaxLength(255)
                    .HasColumnName("address")
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.Createdate)
                    .HasColumnType("datetime")
                    .HasColumnName("createdate");

                entity.Property(e => e.Createuser).HasColumnName("createuser");

                entity.Property(e => e.Email)
                    .HasMaxLength(255)
                    .HasColumnName("email");

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .HasColumnName("name")
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.Phone)
                    .HasMaxLength(25)
                    .HasColumnName("phone");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.Property(e => e.Updatedate)
                    .HasColumnType("datetime")
                    .HasColumnName("updatedate");

                entity.Property(e => e.Updateuser).HasColumnName("updateuser");
            });

            modelBuilder.Entity<Typenews>(entity =>
            {
                entity.ToTable("typenews");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.Property(e => e.Title)
                    .HasMaxLength(255)
                    .HasColumnName("title")
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");
            });

            modelBuilder.Entity<Typepayment>(entity =>
            {
                entity.ToTable("typepayment");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.Property(e => e.Title)
                    .HasMaxLength(255)
                    .HasColumnName("title")
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");
            });

            modelBuilder.Entity<Typeproduct>(entity =>
            {
                entity.ToTable("typeproduct");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.Property(e => e.Title)
                    .HasMaxLength(255)
                    .HasColumnName("title")
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("users");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Address)
                    .HasMaxLength(255)
                    .HasColumnName("address")
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.Avatar)
                    .HasMaxLength(255)
                    .HasColumnName("avatar")
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.Createdate)
                    .HasColumnType("datetime")
                    .HasColumnName("createdate");

                entity.Property(e => e.Createuser).HasColumnName("createuser");

                entity.Property(e => e.Email)
                    .HasMaxLength(255)
                    .HasColumnName("email");

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .HasColumnName("name")
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.Password)
                    .HasMaxLength(255)
                    .HasColumnName("password");

                entity.Property(e => e.Phone)
                    .HasMaxLength(25)
                    .HasColumnName("phone");

                entity.Property(e => e.Role).HasColumnName("role");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.Property(e => e.Updatedate)
                    .HasColumnType("datetime")
                    .HasColumnName("updatedate");

                entity.Property(e => e.Updateuser).HasColumnName("updateuser");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
