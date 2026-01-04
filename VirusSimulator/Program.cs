using System;
using System.Drawing;        // Ekran renkleri ve fontlar için
using System.IO;
using System.Threading;      // İş parçacıkları için
using System.Windows.Forms;  // Pencere açmak için

namespace VirusSimulator
{
    class Program
    {
        // Programın başladığı yer
        static void Main(string[] args)
        {
            Console.Title = "Zararlı Yazılım Yükleyicisi";
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("--- VİRÜS SİMÜLASYONU BAŞLATILIYOR ---");
            System.Threading.Thread.Sleep(1000); // 1 saniye bekle

            // 1. ADIM: Virüslü Dosyayı Oluşturma
            // Bu dosya antivirüsün bulması gereken "imzayı" taşıyacak.
            string hedefKlasor = @"C:\TestKlasoru";
            string virusDosyasi = Path.Combine(hedefKlasor, "system_error_log.txt");
            string virusImzasi = "VIRUS_IMZASI_X99_BU_DOSYA_TEHLIKELI"; // Antivirüs bunu arayacak!

            try
            {
                if (!Directory.Exists(hedefKlasor)) Directory.CreateDirectory(hedefKlasor);

                // Dosyayı oluştur ve içine imzayı gizle
                File.WriteAllText(virusDosyasi, "Sistem günlükleri...\nKritik Hata.\n" + virusImzasi);
                Console.WriteLine($"[+] Zararlı dosya sisteme kopyalandı: {virusDosyasi}");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Dosya oluşturulurken hata: " + ex.Message);
            }

            Console.WriteLine("Payload (Zararlı yük) devreye giriyor...");
            System.Threading.Thread.Sleep(2000);

            // 2. ADIM: Sahte Kilit Ekranını Başlatma
            // Konsol donmasın diye ekranı ayrı bir işlemde (Thread) açıyoruz.
            Thread t = new Thread(() =>
            {
                Application.EnableVisualStyles();
                Application.Run(new SahteKilitEkrani()); // Aşağıdaki Formu çalıştır
            });

            // STA (Single Threaded Apartment) modu formlar için gereklidir
            t.SetApartmentState(ApartmentState.STA);
            t.Start();

            Console.WriteLine("Sistem kilitlendi! (Güvenlik için 100 saniye sonra açılacak)");
            Console.ReadLine(); // Konsol hemen kapanmasın
        }
    }

    // --- SAHTE KİLİT EKRANI TASARIMI ---
    // Bu sınıf, ekranı kaplayan kırmızı pencereyi oluşturur.
    public class SahteKilitEkrani : Form
    {
        public SahteKilitEkrani()
        {
            // Pencere ayarları (Tam ekran, çerçevesiz, en üstte)
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
            this.TopMost = true; // Görev yöneticisinin bile önüne geçmeye çalışır
            this.BackColor = Color.DarkRed; // Arka plan rengi
            this.ShowInTaskbar = false; // Alt tarafta görünmesin
            this.Cursor = Cursors.AppStarting; // Mouse imlecini değiştir

            // Ekrana yazı ekle
            Label lblMesaj = new Label();
            lblMesaj.Text = "SİSTEMİNİZ VİRÜS TARAFINDAN KİLİTLENDİ!\n\nLütfen bekleyiniz...";
            lblMesaj.Font = new Font("Consolas", 24, FontStyle.Bold);
            lblMesaj.ForeColor = Color.White;
            lblMesaj.AutoSize = true;

            // Yazıyı ekranın ortasına koymak için basit hesaplama
            lblMesaj.Location = new Point(Screen.PrimaryScreen.Bounds.Width / 3, Screen.PrimaryScreen.Bounds.Height / 2);

            this.Controls.Add(lblMesaj);

            // GÜVENLİK ZAMANLAYICISI
            // 100 Saniye sonra (100000 ms) ekran otomatik kapansın.
            // Bunu yapmazsak bilgisayarı resetlemen gerekebilir!
            System.Windows.Forms.Timer guvenlikZamanlayicisi = new System.Windows.Forms.Timer();
            guvenlikZamanlayicisi.Interval = 100000;
            guvenlikZamanlayicisi.Tick += (sender, e) => {
                this.Close(); // Formu kapat
                guvenlikZamanlayicisi.Stop();
            };
            guvenlikZamanlayicisi.Start();
        }

        // Kullanıcının Alt+F4 ile kapatmasını zorlaştırmak için (İsteğe bağlı)
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            // Kullanıcı kapatmaya çalışıyorsa (UserClosing),
            // Ve henüz 10 saniye dolmadıysa kapatmayı engellemek için e.Cancel = true diyebilirsin.
            // Ama şimdilik test aşamasında olduğumuz için açık bırakıyorum.
            base.OnFormClosing(e);
        }
    }
}