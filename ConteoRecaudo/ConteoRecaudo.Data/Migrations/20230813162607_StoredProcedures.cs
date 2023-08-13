using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ConteoRecaudo.Data.Migrations
{
    public partial class StoredProcedures : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var createSpRecaudosAnio = @"CREATE OR ALTER PROCEDURE [dbo].[spObtenerRecaudosPorAnio]
	                                      @Estacion Varchar(50),
	                                      @Anio int
	                                    AS
	                                    BEGIN

	                                    SET NOCOUNT ON;
	                                    SET DATEFORMAT ymd;
		                                    BEGIN
		                                    SET LANGUAGE Spanish;
			                                     SELECT Estacion, YEAR(Fecha) Anio, DATENAME(MONTH, Fecha) Mes, SUM(Cantidad) Cantidad, SUM(ValorTabulado) Valor 
			                                     FROM Recaudo
			                                     WHERE YEAR(Fecha) = (CASE WHEN @Anio > 0 THEN @Anio ELSE YEAR(Fecha) END)
			                                     AND Estacion LIKE (CASE WHEN @Estacion != '' THEN '%'+@Estacion+'%' ELSE '%'+Estacion+'%' END)
			                                     GROUP BY YEAR(Fecha), MONTH(Fecha), DATENAME(MONTH, Fecha), Estacion
		                                    END
	                                    SET NOCOUNT OFF;
	                                    END";
            migrationBuilder.Sql(createSpRecaudosAnio);
            var createSpRecaudosFechas = @"CREATE OR ALTER PROCEDURE [dbo].[spObtenerRecaudosFecha]
											  @FechaInicial DATETIME,
											  @FechaFinal DATETIME
											AS
											BEGIN

											SET NOCOUNT ON;
											SET DATEFORMAT ymd;
												BEGIN
												SET LANGUAGE Spanish;
													SELECT Estacion, YEAR(Fecha) Anio, DATENAME(MONTH, Fecha) Mes, SUM(Cantidad) Cantidad, SUM(ValorTabulado) Valor 
													FROM Recaudo
													WHERE Fecha BETWEEN @FechaInicial AND @FechaFinal
													GROUP BY Estacion, YEAR(Fecha), DATENAME(MONTH, Fecha)
												END
											SET NOCOUNT OFF;
											END";
            migrationBuilder.Sql(createSpRecaudosFechas);
            var createSpRecaudosEstacion = @"CREATE OR ALTER PROCEDURE [dbo].[spObtenerRecaudosEstacionFecha]
											  @Estacion Varchar(50),
											  @FechaInicial DATETIME,
											  @FechaFinal DATETIME
											AS
											BEGIN

											SET NOCOUNT ON;
											SET DATEFORMAT ymd;
												BEGIN
												SET LANGUAGE Spanish;
													  SELECT Estacion, YEAR(Fecha) Anio, DATENAME(MONTH, Fecha) Mes, SUM(Cantidad) Cantidad, SUM(ValorTabulado) Valor 
													  FROM Recaudo 
													  WHERE Fecha BETWEEN @FechaInicial AND @FechaFinal
													  AND Estacion LIKE (CASE WHEN @Estacion != '' THEN '%'+@Estacion+'%' ELSE '%'+Estacion+'%' END)
													  GROUP BY Estacion, YEAR(Fecha), DATENAME(MONTH, Fecha)
												END
											SET NOCOUNT OFF;
											END";
            migrationBuilder.Sql(createSpRecaudosEstacion);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            var dropSpRecaudosAnio = @"DROP PROC spObtenerRecaudosPorAnio";
            migrationBuilder.Sql(dropSpRecaudosAnio);
            var dropSpRecaudosFechas = @"DROP PROC spObtenerRecaudosFecha";
            migrationBuilder.Sql(dropSpRecaudosFechas);
            var dropSpRecaudosEstacion = @"DROP PROC spObtenerRecaudosEstacionFecha";
            migrationBuilder.Sql(dropSpRecaudosEstacion);
        }
    }
}
