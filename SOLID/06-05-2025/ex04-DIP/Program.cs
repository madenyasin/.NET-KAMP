// DIP - Dependency Inversion Principle
// - Constroctor Injection
// - Property Injection
// - Method Injection

using ex04_DIP.Dogru;

SqlDatabase sqlDatabase = new SqlDatabase();
OracleDatabase oracleDatabase = new OracleDatabase();

void EkranaYaz(IEnumerable<string> liste)
{
    foreach (var item in liste)
    {
        Console.WriteLine(item);
    }
}

var databaseManager1 = new DatabaseManager(oracleDatabase);

EkranaYaz(databaseManager1.VerileriListele());

var databaseManager2 = new DatabaseManager(sqlDatabase);
EkranaYaz(databaseManager2.VerileriListele());


var databaseManager3 = new DatabaseManager();
databaseManager3.MethodInjection(oracleDatabase);
EkranaYaz(databaseManager3.VerileriListele());

var databaseManager4 = new DatabaseManager();
databaseManager4.PropertyInjection = sqlDatabase;
EkranaYaz(databaseManager4.VerileriListele());