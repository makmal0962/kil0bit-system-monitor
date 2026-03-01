use systemstat::{System, Platform};

fn main() -> Result<(), Box<dyn std::error::Error>> {
    let sys = System::new();

    println!("Attempting CPU Temp via systemstat...");
    match sys.cpu_temp() {
        Ok(cpu_temp) => println!("CPU Temp: {} °C", cpu_temp),
        Err(e) => println!("Error getting CPU Temp: {:?}", e),
    }
    
    Ok(())
}
