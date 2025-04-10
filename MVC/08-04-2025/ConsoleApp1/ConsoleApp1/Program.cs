
using Newtonsoft.Json;

namespace ConsoleApp1
{

    internal class Program
    {
        static List<Student> students = new List<Student>();

        static void Main(string[] args)
        {
            // Program açılırken daha önceden kaydedilmiş verileri geri yükler
            LoadStudentsFromFile("students.txt");

            while (true)
            {
                Menu();
            }
        }

        /// <summary>
        /// students listesindeki öğrencileri console ekranına yazar.
        /// </summary>
        private static void ListAllStudents()
        {
            foreach (var student in students)
            {
                Console.WriteLine(student.ToString()); // ToString metodu override edildi.
            }
        }

        /// <summary>
        /// students listesindeki öğrencileri parametreden gelen dosyaya yazar.
        /// </summary>
        /// <param name="filePath">Üzerine veri yazılacak dosyanın yolu.</param>
        private static void SaveStudentsToFile(string filePath)
        {
            if (string.IsNullOrWhiteSpace(filePath) || string.IsNullOrEmpty(filePath))
            {
                throw new ArgumentException("Geçersiz dosya yolu.");
            }
            // JSON formatına çevirme
            string json = JsonConvert.SerializeObject(students, Newtonsoft.Json.Formatting.Indented);

            // dosyaya yaz
            File.WriteAllText(filePath, json);
        }

        /// <summary>
        /// Parametreden gelen listeyi dosyaya yazar.
        /// </summary>
        /// <param name="filePath">Üzerine veri yazılacak dosyanın yolu.</param>
        /// <param name="list">Dosyaya yazılacak liste verisi.</param>
        private static void SaveToFile(string filePath, List<Student> list)
        {
            if (string.IsNullOrWhiteSpace(filePath) || string.IsNullOrEmpty(filePath))
            {
                throw new ArgumentException("Geçersiz dosya yolu.");
            }
            // JSON formatına çevirme
            string json = JsonConvert.SerializeObject(list, Newtonsoft.Json.Formatting.Indented);

            // dosyaya yaz
            File.WriteAllText(filePath, json);
        }

        /// <summary>
        /// Dosyadaki verileri students listesine kaydeder.
        /// </summary>
        /// <param name="filePath">Verilerin alınacağı dosyanın yolu.</param>
        private static void LoadStudentsFromFile(string filePath)
        {
            if (File.Exists(filePath))
            {
                string json = File.ReadAllText(filePath);
                var deserializedStudent = JsonConvert.DeserializeObject<List<Student>>(json);
                if (deserializedStudent != null)
                {
                    students.AddRange(deserializedStudent);
                }
                else
                {
                    Console.WriteLine($"{filePath} dosyası boş veya hatalı.");
                }
            }
        }
        /// <summary>
        /// Parametredeki id değerine göre öğrenciyi sistemden siler.
        /// </summary>
        /// <param name="id">Öğrenci Id'si.</param>
        private static void DeleteStudent(int id)
        {
            try
            {
                var result = students.First(student => student.StudentId == id);
                if (result != null)
                {
                    students.Remove(result);
                    SaveStudentsToFile("students.txt");

                    Console.Clear();
                    Console.WriteLine("\nÖğrenci başarıyla sistemden silindi.\n");
                }
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine("Bu öğrenci sisteme kayıtlı değil.");
                Console.WriteLine("Hata Mesajı: " + ex.Message);
            }
            catch (ArgumentException ex)
            {
                // hatalı dosya adı
                Console.WriteLine("Hata Mesajı: " + ex.Message);
            }

            catch (JsonException ex)
            {
                // Json işlemi sırasında hata oluştu.
                Console.WriteLine("Hata mesajı: " + ex.Message);
            }
            catch (IOException ex)
            {
                // IO işlemleri sırasında hata oluştu
                Console.WriteLine("Hata mesajı: " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Bir hata oluştu: " + ex.Message);
            }


        }
        /// <summary>
        /// Soyadına göre students listesinden öğrenci arar ve listeler.
        /// </summary>
        /// <param name="lastName">Aranacak soyad değeri.</param>
        private static void SearchStudentByLastName(string lastName)
        {
            List<Student> results = students.FindAll(student => student.LastName.ToLower() == lastName.ToLower());
            Console.WriteLine("Bulunan Öğrenci / Öğrenciler");
            foreach (var student in results)
            {
                Console.WriteLine(student.ToString()); // override edilen ToString metodu
            }
        }

        /// <summary>
        /// Not ortalaması 50'nin altındaki öğrencileri ekrana yazar ve dosyaya kaydeder.
        /// </summary>
        private static void ListStudentFailFromCourse()
        {
            List<Student> results = new List<Student>();
            foreach (var student in students)
            {
                if (student.AverageGrade < 50)
                {
                    results.Add(student);
                }
            }

            foreach (var failedStudent in results)
            {
                Console.WriteLine(failedStudent.ToString());
            }
            try
            {
                SaveToFile("failedStudents.txt", results);

            }
            catch (ArgumentException ex)
            {
                Console.WriteLine("Hata mesajı: " + ex.Message);
            }
            catch (JsonException ex)
            {
                // Json işlemi sırasında hata oluştu.
                Console.WriteLine("Hata mesajı: " + ex.Message);
            }
            catch (IOException ex)
            {
                // IO işlemleri sırasında hata oluştu
                Console.WriteLine("Hata mesajı: " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Bir hata oluştu: " + ex.Message);
            }
        }
        private static void Menu()
        {
            Console.WriteLine("-----------------------------");
            Console.WriteLine("1: Tüm öğrencileri listele");
            Console.WriteLine("2: Yeni öğrenci ekle");
            Console.WriteLine("3: Öğrenci sil");
            Console.WriteLine("4: Soyadına göre öğrenci ara");
            Console.WriteLine("5: Not ortalaması 50'nin altındaki öğrencileri yazdır");
            Console.WriteLine("6: Çıkış yap");

            int secim = InputHelper.GetIntNumber("Lütfen yapmak istediğiniz işlemi seçiniz: ");
            Console.Clear();

            switch (secim)
            {
                case 1:
                    ListAllStudents();

                    break;
                case 2:
                    YeniOgrenciEkle();

                    break;
                case 3:
                    // Öğrencileri listele
                    ListAllStudents();

                    // Silinecek öğrenciyi seç
                    int studentNo = InputHelper.GetIntNumber("Öğrenci Id: ");

                    // Öğrenci numarası geçerli mi kontrol et.
                    while (!isValidStudentNo(studentNo, false))
                    {
                        studentNo = InputHelper.GetIntNumber("Öğrenci Id: ");
                    }

                    // Öğrenciyi sil
                    DeleteStudent(studentNo);

                    break;
                case 4:
                    string lastName = InputHelper.GetString("Öğrenci Soyadı: ");
                    SearchStudentByLastName(lastName);

                    break;
                case 5:
                    ListStudentFailFromCourse();

                    break;
                case 6:
                    CikisYap();

                    break;
                default:
                    break;
            }
        }



        private static void YeniOgrenciEkle()
        {

            // Sayısal giriş GetIntNumber fonksiyonu içinde kontrol ediliyor.
            int studentNo = InputHelper.GetIntNumber("Öğrenci Id: ");
            while (!isValidStudentNo(studentNo))
            {
                studentNo = InputHelper.GetIntNumber("Öğrenci Id: ");
            }

            string firstName = InputHelper.GetString("Öğrenci Adı: ");
            string lastName = InputHelper.GetString("Öğrenci Soyadı: ");
            int age = InputHelper.GetIntNumber("Öğrenci Yaşı: ");

            // Sayısal giriş GetDoubleNumber fonksiyonu içinde kontrol ediliyor.
            double grade = InputHelper.GetDoubleNumber("Öğrenci Not Ortalaması: ");
            while (!isValidGrade(grade))
            {
                grade = InputHelper.GetDoubleNumber("Öğrenci Not Ortalaması: ");
            }

            Student newStudent = new Student()
            {
                StudentId = studentNo,
                FirstName = firstName,
                LastName = lastName,
                Age = age,
                AverageGrade = grade
            };

            students.Add(newStudent);

            // dosyaya yaz
            try
            {
                SaveStudentsToFile("students.txt");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine("Hata mesajı: " + ex.Message);
            }
            catch (JsonException ex)
            {
                // Json işlemi sırasında hata oluştu.
                Console.WriteLine("Hata mesajı: " + ex.Message);
            }
            catch (IOException ex)
            {
                // IO işlemleri sırasında hata oluştu
                Console.WriteLine("Hata mesajı: " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Bir hata oluştu: " + ex.Message);
            }

            Console.WriteLine("\nÖğrenci başarıyla sisteme kaydedildi.\n");

        }

        /// <summary>
        /// Girilen not değerinin aralığını kontrol eder.
        /// </summary>
        /// <param name="grade">Not değeri.</param>
        /// <returns>Geçerli bir not girilip girilmediğini döndürür.</returns>
        private static bool isValidGrade(double grade)
        {
            if (grade < 0 || grade > 100)
            {
                Console.Write("Öğrenci not ortalaması 0 - 100 arasında olmalıdır.");
                return false;
            }
            return true;
        }

        /// <summary>
        /// Geçerli bir öğrenci numarası girilip girilmediğini kontrol eder.
        /// </summary>
        /// <param name="studentNo">Öğrenci numarası.</param>
        /// <param name="listSearchState">students listesinde arama yapılıp yapılmayacağı bilgisi</param>
        /// <returns>Öğrenci numarası geçerliyse true değilse false döner.</returns>
        private static bool isValidStudentNo(int studentNo, bool listSearchState = true)
        {
            // Ekeleme durumunda içeride var mı kontrol edecek.
            // Silme durumunda içeride var mı kontrol etmeyecek.
            if (listSearchState)
            {
                // Numara başka öğrenci tarafından kullanılıyor mu?
                foreach (var item in students)
                {
                    if (item.StudentId == studentNo)
                    {
                        Console.WriteLine("Bu öğrenci numarası başka bir öğrenci tarafından kullanılıyor.");
                        return false;
                    }
                }
            }


            // negatif kontrolü
            if (studentNo < 0)
            {
                Console.WriteLine("Öğrenci numarası 4 haneli pozitif bir sayı olmalı.");
                return false;
            }
            // 4 basamak kontrolü
            if (BasamakHesapla(studentNo) != 4)
            {
                Console.WriteLine("Öğrenci numarası 4 haneli bir sayı olmalı.");
                return false;
            }
            return true;

        }
        private static int BasamakHesapla(int sayi)
        {
            int counter = 0;
            do
            {
                sayi /= 10;
                counter++;
            }
            while (sayi != 0);
            return counter;
        }

        private static void CikisYap()
        {
            Environment.Exit(0);
        }
    }
}
