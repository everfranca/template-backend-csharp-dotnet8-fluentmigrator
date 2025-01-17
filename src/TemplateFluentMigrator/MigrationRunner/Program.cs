using Microsoft.Extensions.DependencyInjection;
using MigrationRunner.Configurations;
using MigrationRunner.Enums;
using MigrationRunner.Extensions;
using MigrationRunner.Operations.MigrationDown;
using MigrationRunner.Operations.MigrationUp;


IServiceProvider serviceProvider = StartServices();

IMigrationUp migrationUp;
IMigrationDown migrationDown;
long versionToDown = 0;

Console.WriteLine("PAM - Migration Runner v1.0.0");
Console.WriteLine("");
Console.WriteLine("Ambientes disponíveis");
Console.WriteLine("[1] local/dev");
Console.WriteLine("[2] homologação");
Console.WriteLine("[3] produção");
Console.WriteLine("");

// migrationUp = serviceProvider.GetService<IMigrationUp>()!;
// migrationDown = serviceProvider.GetService<IMigrationDown>()!;

Console.WriteLine("Qual o ambiente que deseja trabalhar?");
string? environmentResponse = Console.ReadLine();

if (!Enum.TryParse(environmentResponse, out ApplicationEnvironment env))
    Console.WriteLine("Ambiente informado é inválido.");

Console.WriteLine("Ambiente encontrado...");

Console.Clear();

Console.WriteLine("Operações disponíveis");
Console.WriteLine("");
Console.WriteLine("[1] Aplicar migrações");
Console.WriteLine("[2] Reverter migrações");
Console.WriteLine("[3] Listar migrações");
Console.WriteLine("");

Console.WriteLine("Qual o operação deseja aplicar?");
string? operationResponse = Console.ReadLine();
if (!Enum.TryParse(operationResponse, out MigrationOperation operation))
    Console.WriteLine("Operação informada é inválida.");

Console.WriteLine("Operação Encontrada ...");
Console.WriteLine("");

if (operation.Equals(MigrationOperation.MigrationDown))
{
    Console.WriteLine("Informe a versão para fazer o rollback");
    string? versionDownResponse = Console.ReadLine();

    while (!long.TryParse(versionDownResponse, out versionToDown))
    {
        Console.WriteLine("Versão inválida. Informe novamente.");
        versionDownResponse = Console.ReadLine();
    }
}

Console.Clear();

Console.WriteLine("Resumo das operações");
Console.WriteLine($"Ambiente: {env.Description()}");
Console.WriteLine($"Operação: {operation.Description()}");
if(operation.Equals(MigrationOperation.MigrationDown))
    Console.WriteLine($"Roolback para a versão: {versionToDown}");
Console.WriteLine("");
Console.WriteLine("Deseja continuar? [S/N]");

string? userResponse = Console.ReadLine();

if (!"s".Equals(userResponse) && !"S".Equals(userResponse))
{
    Console.WriteLine("Resposta inválida");
    return;
}

//TODO: Capturar ConnectionString pelo ambiente

switch (operation)
{
    case MigrationOperation.MigrationUp:
        migrationUp = serviceProvider.GetService<IMigrationUp>()!;
        migrationUp.Up();
        break;
    
    case MigrationOperation.MigrationDown:
        migrationDown = serviceProvider.GetService<IMigrationDown>()!;
        migrationDown.Down(versionToDown);
        break;
    
    case MigrationOperation.MigrationList:
        break;
}

Console.WriteLine("Operação finalizada.");
return;

IServiceProvider StartServices()
{
    IServiceCollection services = new ServiceCollection();

    services.AddFluentMigrator("Server=localhost;Port=5432;Database=mydatabase;User Id=postgres;Password=mypassword;");
    services.AddMigrationRunner();

    return services.BuildServiceProvider(validateScopes: false);
}