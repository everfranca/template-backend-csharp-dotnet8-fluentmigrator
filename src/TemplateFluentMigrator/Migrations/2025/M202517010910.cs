using FluentMigrator;

namespace Migrations;

 [Migration(202517010910 , description: "Criação incial - Schema PAM")]
public class M202517010910 : Migration
{

    public override void Up()
    {
        Create.Schema("product");

        Create.Table("products").InSchema("product")
              .WithColumn("id").AsGuid().PrimaryKey()
              .WithColumn("name").AsAnsiString(100).NotNullable()
              .WithColumn("price").AsDecimal(18,2).NotNullable();

    }
    public override void Down()
    {
        Delete.Table("products").InSchema("product");
        
        Delete.Schema("product");
        
    }
}