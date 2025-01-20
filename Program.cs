using System;
using System.Diagnostics;
using System.Threading;

namespace WhatsAppMessageSender
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                // mesaj içeriği
                Console.Write("Mesajınızı yazın (çıkmak için 'exit' yazın): ");
                string mesaj = Console.ReadLine();

                // Kullanıcı çıkmak isterse uygulamayı kapat
                if (mesaj?.ToLower() == "exit")
                {
                    Console.WriteLine("Uygulama kapanıyor...");
                    break;
                }

                if (string.IsNullOrWhiteSpace(mesaj))
                {
                    Console.WriteLine("Lütfen bir mesaj içeriği girin!");
                    continue;
                }

                // WhatsApp URL'si  (telefon numarasını girmeden wp üzerindeki numaradan gönderilecek)
                string url = $"https://wa.me/?text={Uri.EscapeDataString(mesaj)}";

                // Mesaj gönderim hazırlığı
                Console.WriteLine("Mesaj gönderilmeye hazır. Devam etmek için ENTER'a basın.");
                Console.ReadLine();

                // WhatsApp linkini tarayıcı açılışı
                Console.WriteLine("WhatsApp açılıyor...");

                if (!OpenBrowser(url))
                {
                    Console.WriteLine("Tarayıcı açılamadı. Lütfen tarayıcınızı kontrol edin ve WhatsApp Web'e giriş yapmayı deneyin.");
                }
                else
                {
                    // Animasyon ve gecikme
                    Console.Write("Gönderiliyor: ");
                    for (int i = 0; i < 3; i++)
                    {
                        Console.Write(".");
                        Thread.Sleep(700);
                    }
                    Console.WriteLine("\nMesaj tarayıcıda açıldı. WhatsApp üzerinden gönderimi tamamlayabilirsiniz.");
                }

                Console.WriteLine();
            }
        }

        // Tarayıcıda URL açma fonksiyonu
        static bool OpenBrowser(string url)
        {
            try
            {
                Process.Start(new ProcessStartInfo
                {
                    FileName = url,
                    UseShellExecute = true // Tarayıcıda açmak için gerekli
                });
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Tarayıcı açılamadı: {ex.Message}");
                return false;
            }
        }
    }
}
