using Microsoft.AspNetCore.SpaServices;
using VueCliMiddleware;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSpaStaticFiles(config =>
{
    config.RootPath = "ClientApp/dist"; //�˴�build ��Ӧvue��Ŀ�ķ����ļ�������
});

var app = builder.Build();

#region ��ӵ�ҳ��webӦ��  vue
app.UseStaticFiles();
app.UseSpaStaticFiles();
#endregion
app.UseRouting();
app.UseEndpoints(endpoints =>
{
    endpoints.MapToVueCliProxy(
                       "{*path}",
                       new SpaOptions { SourcePath = "ClientApp" },
                       npmScript: (System.Diagnostics.Debugger.IsAttached) ? "dev" : null,
                       regex: "Compiled successfully",
                       forceKill: true
                       );
});
app.Run();
