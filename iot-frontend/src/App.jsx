import { useState, useEffect } from 'react';
import axios from 'axios';

function App() {
  const [readings, setReadings] = useState([]);
  const [loading, setLoading] = useState(true);

  // دالة لجلب البيانات من الخادم
  const fetchReadings = async () => {
    try {
      const response = await axios.get('https://localhost:7047/api/readings');
      setReadings(response.data);
      setLoading(false);
    } catch (error) {
      console.error("Error fetching data from API:", error);
    }
  };

  // جلب البيانات عند تحميل الصفحة وتحديثها كل 3 ثوانٍ تلقائياً
  useEffect(() => {
    fetchReadings();
    const interval = setInterval(fetchReadings, 3000);
    return () => clearInterval(interval);
  }, []);

  return (
    <div className="container mt-5">
      <div className="row text-center mb-4">
        <div className="col">
          <h2 className="text-primary fw-bold">IoT Device Monitoring Dashboard</h2>
          <p className="text-muted">Real-time data stream from simulated devices</p>
        </div>
      </div>

      {loading ? (
        <div className="text-center">
          <div className="spinner-border text-primary" role="status"></div>
        </div>
      ) : (
        <div className="card shadow-sm">
          <div className="card-header bg-dark text-white fw-bold">
            Live Device Readings
          </div>
          <div className="card-body p-0">
            <div className="table-responsive">
              <table className="table table-hover table-striped mb-0 text-center align-middle">
                <thead className="table-light">
                  <tr>
                    <th>ID</th>
                    <th>Device ID</th>
                    <th>Voltage (V)</th>
                    <th>Temperature (°C)</th>
                    <th>Timestamp</th>
                  </tr>
                </thead>
                <tbody>
                  {readings.length === 0 ? (
                    <tr>
                      <td colSpan="5" className="text-muted p-4">No data received yet. Ensure simulator is running.</td>
                    </tr>
                  ) : (
                    // عرض البيانات من الأحدث إلى الأقدم
                    [...readings].reverse().map((reading) => (
                      <tr key={reading.id}>
                        <td>{reading.id}</td>
                        <td><span className="badge bg-secondary">{reading.deviceId}</span></td>
                        <td className="fw-bold text-success">{reading.voltage.toFixed(2)} V</td>
                        <td className="fw-bold text-danger">{reading.temperature.toFixed(1)} °C</td>
                        <td className="text-muted">{new Date(reading.timestamp).toLocaleTimeString()}</td>
                      </tr>
                    ))
                  )}
                </tbody>
              </table>
            </div>
          </div>
        </div>
      )}
    </div>
  );
}

export default App;