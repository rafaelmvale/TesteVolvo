using Microsoft.EntityFrameworkCore.Migrations;

namespace TesteVolvo.Infra.Data.Migrations
{
    public partial class seedTrucks : Migration
    {
        protected override void Up(MigrationBuilder mb)
        {
            mb.Sql("INSERT INTO Trucks(YearManufacture,YearModel,CategoryId)" +
               "VALUES('2022','2022',1)");

            mb.Sql("INSERT INTO Trucks(YearManufacture,YearModel,CategoryId)" +
               "VALUES('2022','2023',2)");

            mb.Sql("INSERT INTO Trucks(YearManufacture,YearModel,CategoryId)" +
               "VALUES('2022','2022',2)");

            mb.Sql("INSERT INTO Trucks(YearManufacture,YearModel,CategoryId)" +
               "VALUES('2022','2023',1)");
        }

        protected override void Down(MigrationBuilder mb)
        {

            mb.Sql("DELETE FROM Trucks");

        }
    }
}
