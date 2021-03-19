using FallstudieSem5.Models;
using FallstudieSem5.Models.Manager;
using FallstudieSem5.Models.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace FallstudieSem5
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
      services.AddDbContext<Context>(options => options.UseSqlServer(Configuration["ConnectionStrings:FallstudieSemDB"]));
      services.AddScoped<IDataRepository<Person>, PersonManager>();
      services.AddScoped<IDataRepository<Address>, AddressManager>();
      services.AddScoped<IDataRepository<City>, CityManager>();
      services.AddScoped<IDataRepository<Hazard>, HazardManager>();
      services.AddScoped<IDataRepository<HouseNumber>, HouseNumberManager>();
      services.AddScoped<IDataRepository<DangerLevel>, DangerLevelManager>();
      services.AddScoped<IDataRepository<Object>, ObjectManager>();
      services.AddScoped<IDataRepository<ObjectOwner>, ObjectOwnerManager>();
      services.AddScoped<IDataRepository<PropertyOwner>, PropertyOwnerManager>();
      services.AddScoped<IDataRepository<Staff>, StaffManager>();
      services.AddScoped<IDataRepository<Street>, StreetManager>();
      services.AddScoped<IDataRepository<Title>, TitleManager>();
      services.AddControllers();
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

      app.UseAuthorization();

      app.UseEndpoints(endpoints =>
      {
        endpoints.MapControllers();
      });
    }
  }
}
