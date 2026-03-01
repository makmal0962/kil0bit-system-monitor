use nvml_wrapper::Nvml;

fn main() -> Result<(), Box<dyn std::error::Error>> {
    println!("Initializing NVML...");
    
    match Nvml::init() {
        Ok(nvml) => {
            let device_count = nvml.device_count()?;
            println!("Found {} NVIDIA GPU(s)", device_count);

            for i in 0..device_count {
                let device = nvml.device_by_index(i)?;
                let name = device.name()?;
                
                println!("--- {} ---", name);
                
                if let Ok(temp) = device.temperature(nvml_wrapper::enum_wrappers::device::TemperatureSensor::Gpu) {
                    println!("Temperature: {} °C", temp);
                }
                
                if let Ok(util) = device.utilization_rates() {
                    println!("GPU Usage: {}%", util.gpu);
                    println!("Memory Bandwidth Usage: {}%", util.memory);
                }
                
                if let Ok(mem) = device.memory_info() {
                    let used_mb = mem.used / 1024 / 1024;
                    let total_mb = mem.total / 1024 / 1024;
                    println!("VRAM: {} MB / {} MB", used_mb, total_mb);
                }
            }
        },
        Err(e) => {
            println!("NVML Initialization Failed! {:?}", e);
            println!("This system either does not have an NVIDIA GPU, or the driver is missing/corrupted.");
        }
    }

    Ok(())
}
