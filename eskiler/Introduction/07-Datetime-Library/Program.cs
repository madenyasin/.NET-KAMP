// DateTime date = DateTime.Now;
/*
 * +		date	{21.02.2025 11:02:15}	System.DateTime
+		date.AddDays(1)	{22.02.2025 11:02:15}	System.DateTime
+		date.AddDays(0.5)	{21.02.2025 23:02:15}	System.DateTime
+		date.AddMonths(-3)	{21.11.2024 11:02:15}	System.DateTime
+		date.Date	{21.02.2025 00:00:00}	System.DateTime
		date.Day	21	int
		date.Month	2	int
		date.Year	2025	int
		date.ToLongDateString()	"21 Şubat 2025 Cuma"	string
		date.ToShortDateString()	"21.02.2025"	string
		date.ToLongTimeString()	"11:02:15"	string
		date.ToShortTimeString()	"11:02"	string
+		date.ToUniversalTime()	{21.02.2025 08:02:15}	System.DateTime

*/



DateTime birthDate = new DateTime(2001, 07, 07);

Console.WriteLine(birthDate.ToLongDateString());