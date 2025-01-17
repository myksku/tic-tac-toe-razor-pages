using System.Security.Cryptography.X509Certificates;
using TicTacToeWeb.Services;

namespace TicTacToeWeb
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.WebHost.ConfigureKestrel(opts =>
            {
                
                opts.ConfigureHttpsDefaults(cOpts =>
                {
                    string certificateName = "agurkufabrikas";
                    X509Store store = new X509Store(StoreName.My, StoreLocation.CurrentUser);
                    store.Open(OpenFlags.ReadOnly);
                    X509Certificate2 certificate = null;
                    foreach (var cert in store.Certificates)
                    {
                        if (cert.Subject.Contains(certificateName))
                            certificate = cert;
                    }
                    if (certificate == null)
                    {
                        throw new InvalidOperationException($"Server certificate: '{certificateName}' wasn't found");
                    }
                    cOpts.ServerCertificate = certificate;
                    store.Close();
                });
            });


            // Add services to the container.
            builder.Services.AddRazorPages();
            builder.Services.AddSingleton<IGameService,GameService>();
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            //app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapRazorPages();

            app.Run();
        }
    }
}