using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json.Serialization;
using P2N_Pet_API.Action;
using P2N_Pet_API.Action.Interface;
using P2N_Pet_API.Database;
using P2N_Pet_API.Models.UtilsProject;
using P2N_Pet_API.Module.AdminManager.Action;
using P2N_Pet_API.Module.AdminManager.Action.Interface;
using P2N_Pet_API.Module.AdminManager.Query;
using P2N_Pet_API.Module.AdminManager.Query.Interface;
using P2N_Pet_API.Module.AdminManager.Service;
using P2N_Pet_API.Module.AdminManager.Service.Interface;
using P2N_Pet_API.Query;
using P2N_Pet_API.Query.Interface;
using P2N_Pet_API.Service;
using P2N_Pet_API.Service.Interface;
using P2N_Pet_API.UtilsService;
using P2N_Pet_API.UtilsService.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace P2N_Pet_API
{
    public class Startup
    {
        //Write P2NPet shop localhost
        //Create: Scaffold-DbContext "server=127.0.0.1;port=3306;database=p2n_pet;user=root;password=1234567890" Pomelo.EntityFrameworkCore.MySql -OutputDir Database\PetShopModels -ContextDir Database -Context PetShopContext
        //Update: Scaffold-DbContext "server=127.0.0.1;port=3306;database=p2n_pet;user=root;password=1234567890" Pomelo.EntityFrameworkCore.MySql -OutputDir Database\PetShopModels -ContextDir Database -Context PetShopContext -Force

        //MySql Server Test
        //Create: Scaffold-DbContext "server=157.119.251.140;port=4785;database=p2n_pet;user=root;password=Y00t@()742C0mp@Ny" Pomelo.EntityFrameworkCore.MySql -OutputDir Database\PetShopModels -ContextDir Database -Context PetShopContext
        //Update: Scaffold-DbContext "server=157.119.251.140;port=4785;database=p2n_pet;user=root;password=Y00t@()742C0mp@Ny" Pomelo.EntityFrameworkCore.MySql -OutputDir Database\PetShopModels -ContextDir Database -Context PetShopContext -Force

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        [Obsolete]
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors();

            services.AddControllersWithViews().AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.PropertyNamingPolicy = null;
            });

            services.AddControllers().AddNewtonsoftJson(options =>
            {
                options.SerializerSettings.ContractResolver = new DefaultContractResolver();
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
            });

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            //Utils Service
            services.AddSingleton<IP2NPetDapper, P2NPetDapper>();
            services.AddScoped<IEmailService, EmailService>();
            services.AddScoped<ICloudMediaService, CloudMediaService>();
            services.AddScoped<IPaginationService, PaginationService>();
            services.AddScoped<IPaymentMomoService, PaymentMomoService>();
            services.AddScoped<IPaymentVNPayService, PaymentVNPayService>();

            //Service
            services.AddScoped<ILoginService, LoginService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<ICartService, CartService>();
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<IContactService, ContactService>();
            services.AddScoped<IPromotionService, PromotionService>();
            services.AddScoped<ICommentService, CommentService>();
            services.AddScoped<IChatService, ChatService>();
            services.AddScoped<INewsService, NewsService>();

            //Query
            services.AddScoped<ILoginQuery, LoginQuery>();
            services.AddScoped<IUserQuery, UserQuery>();
            services.AddScoped<ICategoryQuery, CategoryQuery>();
            services.AddScoped<IProductQuery, ProductQuery>();
            services.AddScoped<ICartQuery, CartQuery>();
            services.AddScoped<IOrderQuery, OrderQuery>();
            services.AddScoped<IPromotionQuery, PromotionQuery>();
            services.AddScoped<ICommentQuery, CommentQuery>();
            services.AddScoped<IChatQuery, ChatQuery>();
            services.AddScoped<INewsQuery, NewsQuery>();

            //Action
            services.AddScoped<IUserAction, UserAction>();
            services.AddScoped<ICartAction, CartAction>();
            services.AddScoped<IOrderAction, OrderAction>();
            services.AddScoped<IContactAction, ContactAction>();
            services.AddScoped<ICommentAction, CommentAction>();
            services.AddScoped<IChatAction, ChatAction>();

            //ADMIN
            //Service
            services.AddScoped<IAAgeService, AAgeService>();
            services.AddScoped<IAColorService, AColorService>();
            services.AddScoped<IASizeService, ASizeService>();
            services.AddScoped<IASupplierService, ASupplierService>();
            services.AddScoped<IAPromotionService, APromotionService>();
            services.AddScoped<IABreedService, ABreedService>();
            services.AddScoped<IAContactService, AContactService>();
            services.AddScoped<IACustomerService, ACustomerService>();
            services.AddScoped<IAProductService, AProductService>();
            services.AddScoped<IAProductDetailService, AProductDetailService>();
            services.AddScoped<IAOrderService, AOrderService>();
            services.AddScoped<IAdminService, AdminService>();
            services.AddScoped<IADataService, ADataService>();
            services.AddScoped<IAStatisticsService, AStatisticsService>();
            services.AddScoped<IABrandService, ABrandService>();
            services.AddScoped<IACategoryService, ACategoryService>();
            services.AddScoped<IAChatService, AChatService>();
            services.AddScoped<IANewsService, ANewsService>();

            //Action
            services.AddScoped<IAAgeAction, AAgeAction>();
            services.AddScoped<IAColorAction, AColorAction>();
            services.AddScoped<IASizeAction, ASizeAction>();
            services.AddScoped<IASupplierAction, ASupplierAction>();
            services.AddScoped<IAPromotionAction, APromotionAction>();
            services.AddScoped<IABreedAction, ABreedAction>();
            services.AddScoped<IAContactAction, AContactAction>();
            services.AddScoped<IACustomerAction, ACustomerAction>();
            services.AddScoped<IAProductAction, AProductAction>();
            services.AddScoped<IAProductDetailAction, AProductDetailAction>();
            services.AddScoped<IAOrderAction, AOrderAction>();
            services.AddScoped<IAdminAction, AdminAction>();
            services.AddScoped<IABrandAction, ABrandAction>();
            services.AddScoped<IACategoryAction, ACategoryAction>();
            services.AddScoped<IAChatAction, AChatAction>();
            services.AddScoped<IANewsAction, ANewsAction>();

            //Query
            services.AddScoped<IAAgeQuery, AAgeQuery>();
            services.AddScoped<IAColorQuery, AColorQuery>();
            services.AddScoped<IASizeQuery, ASizeQuery>();
            services.AddScoped<IASupplierQuery, ASupplierQuery>();
            services.AddScoped<IAPromotionQuery, APromotionQuery>();
            services.AddScoped<IABreedQuery, ABreedQuery>();
            services.AddScoped<IAContactQuery, AContactQuery>();
            services.AddScoped<IACustomerQuery, ACustomerQuery>();
            services.AddScoped<IAProductQuery, AProductQuery>();
            services.AddScoped<IAProductDetailQuery, AProductDetailQuery>();
            services.AddScoped<IAOrderQuery, AOrderQuery>();
            services.AddScoped<IAdminQuery, AdminQuery>();
            services.AddScoped<IADataQuery, ADataQuery>();
            services.AddScoped<IAStatisticsQuery, AStatisticsQuery>();
            services.AddScoped<IABrandQuery, ABrandQuery>();
            services.AddScoped<IACategoryQuery, ACategoryQuery>();
            services.AddScoped<IAChatQuery, AChatQuery>();
            services.AddScoped<IANewsQuery, ANewsQuery>();

            //DBContext
            services.AddDbContext<PetShopContext>(options =>
               options.UseMySql(Configuration.GetConnectionString("WP2NPetConnection"), ServerVersion.Parse("8.0.25-mysql")), ServiceLifetime.Scoped, ServiceLifetime.Scoped);

            //Swagger
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Pet Shop API", Version = "v1.0" });
                c.OperationFilter<SwaggerHeaderFilter>(); // UtilsProject
            });

            //Deploy
            services.Configure<FormOptions>(x =>
            {
                x.ValueLengthLimit = int.MaxValue;
                x.MultipartBodyLengthLimit = int.MaxValue;
                x.MultipartHeadersLengthLimit = int.MaxValue;
            });

            //services.Configure<KestrelServerOptions>(options =>
            //{
            //    options.Limits.MaxRequestBodySize = int.MaxValue;
            //});

            services.Configure<IISServerOptions>(options =>
            {
                options.AutomaticAuthentication = false;
                options.MaxRequestBodySize = int.MaxValue;
            });

            services.Configure<IISOptions>(options =>
            {
                options.ForwardClientCertificate = false;
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthorization();

            app.UseCors(x => x
                .AllowAnyMethod()
                .AllowAnyHeader()
                .SetIsOriginAllowed(origin => true) // allow any origin
                .AllowCredentials());

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
