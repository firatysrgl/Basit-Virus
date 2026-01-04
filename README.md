🦠 Virus - Eğitim Amaçlı Zararlı Virus

Bu proje, C# kullanılarak yazılmış zararsız bir "Zararlı Yazılım (Malware)" simülasyonudur. Eğitim ve test amaçlı geliştirilmiştir. Sistemde gerçek bir hasar oluşturmaz; sadece tipik bir zararlı yazılımın davranış kalıplarını (dosya bırakma ve ekran kilitleme) taklit eder.



⚠️ ÖNEMLİ UYARI: Bu yazılım tamamen eğitim ve test amaçlıdır. Hiçbir dosyayı şifrelemez, silmez veya ağ üzerinden yayılmaz. Lütfen sadece kendinize ait sistemlerde veya sanal makinelerde (VM) çalıştırınız.



🚀 Özellikler

Bu simülasyon iki temel aşamadan oluşur:



İmza Dosyası Oluşturma (Payload Drop):



C:\\TestKlasoru dizini altında system\_error\_log.txt adında bir dosya oluşturur.



Bu dosya, Antivirüs yazılımlarının tespiti için kullanılabilecek sahte bir imza (VIRUS\_IMZASI\_X99...) içerir.



Sahte Kilit Ekranı (Fake Lock Screen):



Konsol uygulamasından ayrı bir Thread (iş parçacığı) başlatarak tam ekran bir Windows Formu açar.



Ekranı koyu kırmızıya boyar ve "Sistem Kilitlendi" uyarısı verir.



Güvenlik Mekanizması: Ekran, test sırasında bilgisayarın kilitli kalmaması için 100 saniye sonra otomatik olarak kapanır.



🛠️ Kurulum ve Çalıştırma

Bu proje bir Console App (.NET Framework veya .NET Core) olarak tasarlanmıştır ancak System.Windows.Forms ve System.Drawing kütüphanelerini kullanır.



Gereksinimler

Visual Studio (veya herhangi bir C# IDE)



.NET Framework 4.7.2 veya üzeri (önerilir)



Adım Adım Kurulum

Visual Studio'da yeni bir Console App (.NET Framework) projesi oluşturun.



Program.cs dosyasındaki kodları silin ve bu projedeki kodları yapıştırın.



Referansları Ekleyin:



Konsol uygulamaları varsayılan olarak Form kütüphanelerini içermez.



"Solution Explorer" (Çözüm Gezgini) -> References (Başvurular) -> Sağ Tık -> Add Reference (Başvuru Ekle).



Şu iki kütüphaneyi bulup işaretleyin:



System.Windows.Forms



System.Drawing



Projeyi derleyin ve çalıştırın (F5).



🔍 Teknik Detaylar

Kod içerisinde aşağıdaki C# konseptleri kullanılmıştır:



System.IO: Dosya ve klasör varlığı kontrolü, metin dosyası yazma.



System.Threading: Ana konsol akışını durdurmadan (non-blocking) arka planda Form penceresi açmak için çoklu iş parçacığı kullanımı.



Windows Forms (Code-only): Visual Studio Designer kullanmadan, saf kod ile dinamik form ve label (etiket) oluşturma.



STA Thread: Windows Formlarının çalışabilmesi için ApartmentState.STA ayarının yapılması.



🛡️ Güvenlik Notu

Simülasyonun kontrolden çıkmaması için SahteKilitEkrani sınıfında bir güvenlik zamanlayıcısı (Timer) bulunmaktadır.



Önemli Not :



* 100 Saniye sonra ekran otomatik kapanır
* guvenlikZamanlayicisi.Interval = 100000;
* Eğer ekranı daha erken kapatmak isterseniz Alt + Tab veya Görev Yöneticisini kullanmayı deneyebilirsiniz (kodda TopMost=true olduğu için pencere en üstte kalmaya çalışacaktır).





📷 Ara Yüz Ekranı



!\[Ara Yüz Ekranı](https://github.com/firatysrgl/Basit-Virus/blob/main/screenshot/ss.png)





👤 Geliştirici



Fırat Yunus Yaşaroğlu



📧 Email: firat9041@gmail.com



🔗 GitHub: https://github.com/firatysrgl



🔗 LinkedIn: https://www.linkedin.com/in/firat-yunus-yasaroglu/

