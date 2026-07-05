namespace IotDataApi.Models
{
    public class DeviceReading
    {
        public int Id { get; set; }
        public string DeviceId { get; set; }
        public double Voltage { get; set; }      // سنريدها مستقرة حول قيم معينة مثل 8.0V
        public double Temperature { get; set; }  // درجة الحرارة المحيطة
        public DateTime Timestamp { get; set; }  // وقت تسجيل القراءة
    }
}