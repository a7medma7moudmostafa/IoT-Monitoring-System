using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace DeviceSimulator
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Starting device simulator...");

            // إضافة السطرين دول لتخطي فحص شهادة الـ SSL المحلية
            HttpClientHandler handler = new HttpClientHandler();
            handler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => true;
            using HttpClient client = new HttpClient(handler);

            Random random = new Random();

            // الرابط الخاص بخادمك كما يظهر في المتصفح
            string apiUrl = "https://localhost:7047/api/readings";

            while (true)
            {
                // توليد بيانات عشوائية
                var reading = new
                {
                    deviceId = "ESP32_01",
                    voltage = 7.5 + (random.NextDouble() * 1.0),
                    temperature = 20.0 + (random.NextDouble() * 15.0)
                };

                try
                {
                    // إرسال البيانات إلى الخادم
                    HttpResponseMessage response = await client.PostAsJsonAsync(apiUrl, reading);

                    if (response.IsSuccessStatusCode)
                    {
                        Console.WriteLine($"Reading sent successfully: Voltage = {reading.voltage:F2}V, Temperature = {reading.temperature:F1}°C");
                    }
                    else
                    {
                        Console.WriteLine($"Error sending reading: {response.StatusCode}");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Connection failed: Ensure the API is running. Details: {ex.Message}");
                }

                // الانتظار لمدة 5 ثوانٍ قبل إرسال القراءة التالية
                await Task.Delay(5000);
            }
        }
    }
}