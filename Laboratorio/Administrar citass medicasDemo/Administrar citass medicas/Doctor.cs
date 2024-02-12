using System.Collections.Generic;

namespace CitasMedicas
{
    class Doctor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Specialty { get; set; }
        public List<Patient> Patients { get; set; } = new List<Patient>();
    }
}
