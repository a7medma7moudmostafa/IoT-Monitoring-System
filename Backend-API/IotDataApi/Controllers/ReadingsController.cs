using Microsoft.AspNetCore.Mvc;
using IotDataApi.Models;

namespace IotDataApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReadingsController : ControllerBase
    {
        // قائمة مؤقتة في الذاكرة لحفظ القراءات بشكل سريع
        private static List<DeviceReading> _readings = new List<DeviceReading>();

        // مسار لاستقبال البيانات وإضافتها
        // POST: api/readings
        [HttpPost]
        public IActionResult PostReading([FromBody] DeviceReading reading)
        {
            if (reading == null)
            {
                return BadRequest("البيانات المرسلة غير صحيحة");
            }

            // إعطاء رقم تلقائي وتحديد الوقت الحالي للوصول
            reading.Id = _readings.Count + 1;
            reading.Timestamp = DateTime.Now;

            _readings.Add(reading);

            return Ok(new { message = "تم استقبال القراءة بنجاح!", data = reading });
        }

        // مسار لعرض كل القراءات المستلمة للـ Front-End لاحقا
        // GET: api/readings
        [HttpGet]
        public IActionResult GetReadings()
        {
            return Ok(_readings);
        }
    }
}