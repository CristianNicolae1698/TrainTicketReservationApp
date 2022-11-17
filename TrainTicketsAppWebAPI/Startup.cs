using DomainLibrary.Interfaces;
using EFDataAccessLibrary;
using EFDataAccessLibrary.Repositories;
using Microsoft.EntityFrameworkCore;
using TrainTicketsAppWebAPI.Managers;

namespace TrainTicketsAppWebAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddDbContext<BookingContext>(options =>
            options.UseSqlServer(
                Configuration.GetConnectionString("DefaultConnection"),
                b => b.MigrationsAssembly(typeof(BookingContext).Assembly.FullName)));

            #region Repositories
            services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddTransient<IRouteRepository, RouteRepository>();
            services.AddTransient<IStationRepository, StationRepository>();
            services.AddTransient<ITrainRepository, TrainRepository>();
            services.AddTransient<IBookingRepository, BookingRepository>();
            #endregion
            services.AddTransient<IBookingManager, BookingManager>();
            services.AddTransient<IClientManager, ClientManager>();
            services.AddTransient<IRouteManager, RouteManager>();
            services.AddTransient<ITrainManager, TrainManager>();
            services.AddTransient<IClientRepository, ClientRepository>();
            services.AddTransient<IRouteRepository, RouteRepository>();
            services.AddTransient<IBookingRepository, BookingRepository>();
            services.AddControllersWithViews().AddNewtonsoftJson(options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
            services.AddAutoMapper(typeof(Program).Assembly);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseDefaultFiles();
            app.UseStaticFiles();


            app.UseCors(policy=>policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });


            

        }




    }
}
