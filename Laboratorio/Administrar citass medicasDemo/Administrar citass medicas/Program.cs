using System;
using System.Collections.Generic;

namespace CitasMedicas
{
    class Program
    {
        static List<Doctor> doctors = new List<Doctor>();
        static List<Patient> patients = new List<Patient>();
        static List<Appointment> appointments = new List<Appointment>();

        static void Main(string[] args)
        {
            bool exit = false;
            while (!exit)
            {
                DisplayMenu();

                Console.Write("Ingrese el numero de la opcion deseada: ");
                string option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        ShowDoctors();
                        break;
                    case "2":
                        ShowPatientsOfDoctor();
                        break;
                    case "3":
                        ShowAllAppointments();
                        break;
                    case "4":
                        AddNewDoctor();
                        break;
                    case "5":
                        AddNewPatient();
                        break;
                    case "6":
                        AddNewAppointment();
                        break;
                    case "7":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Opcion no valida. Intente de nuevo.");
                        break;
                }
            }
        }

        static void DisplayMenu()
        {
            Console.WriteLine("1. Mostrar listado de doctores");
            Console.WriteLine("2. Mostrar listado de pacientes de un doctor");
            Console.WriteLine("3. Mostrar listado de todas las citas");
            Console.WriteLine("4. Agregar nuevo doctor");
            Console.WriteLine("5. Agregar nuevo paciente");
            Console.WriteLine("6. Agregar nueva cita");
            Console.WriteLine("7. Salir");
        }

        static void ShowDoctors()
        {
            Console.WriteLine("Listado de Doctores:");
            foreach (var doctor in doctors)
            {
                Console.WriteLine($"{doctor.Id}. {doctor.Name} - {doctor.Specialty}");
            }
        }

        static void ShowPatientsOfDoctor()
        {
            ShowDoctors();
            Console.Write("Ingrese el ID del doctor: ");
            if (int.TryParse(Console.ReadLine(), out int doctorId))
            {
                var doctor = doctors.Find(d => d.Id == doctorId);
                if (doctor != null)
                {
                    Console.WriteLine($"Pacientes del Doctor {doctor.Name}:");
                    foreach (var patient in doctor.Patients)
                    {
                        Console.WriteLine($"{patient.Id}. {patient.Name}");
                    }
                }
                else
                {
                    Console.WriteLine("Doctor no encontrado.");
                }
            }
            else
            {
                Console.WriteLine("ID de doctor no valido.");
            }
        }

        static void ShowAllAppointments()
        {
            Console.WriteLine("Listado de Citas:");
            foreach (var appointment in appointments)
            {
                Console.WriteLine($"Doctor: {appointment.Doctor.Name}, Paciente: {appointment.Patient.Name}, Fecha: {appointment.Date}");
            }
        }

        static void AddNewDoctor()
        {
            Doctor doctor = new Doctor();
            doctor.Id = doctors.Count + 1;
            Console.Write("Ingrese el nombre del doctor: ");
            doctor.Name = Console.ReadLine();
            Console.Write("Ingrese la especialidad del doctor: ");
            doctor.Specialty = Console.ReadLine();
            doctors.Add(doctor);
            Console.WriteLine("Doctor agregado exitosamente.");
        }

        static void AddNewPatient()
        {
            Patient patient = new Patient();
            patient.Id = patients.Count + 1;
            Console.Write("Ingrese el nombre del paciente: ");
            patient.Name = Console.ReadLine();
            patients.Add(patient);
            Console.WriteLine("Paciente agregado exitosamente.");
        }

        static void AddNewAppointment()
        {
            ShowDoctors();
            Console.Write("Ingrese el ID del doctor: ");
            if (int.TryParse(Console.ReadLine(), out int doctorId))
            {
                var doctor = doctors.Find(d => d.Id == doctorId);
                if (doctor != null)
                {
                    ShowPatients();
                    Console.Write("Ingrese el ID del paciente: ");
                    if (int.TryParse(Console.ReadLine(), out int patientId))
                    {
                        var patient = patients.Find(p => p.Id == patientId);
                        if (patient != null)
                        {
                            Console.Write("Ingrese la fecha de la cita (DD/MM/AAAA): ");
                            if (DateTime.TryParse(Console.ReadLine(), out DateTime date))
                            {
                                Appointment appointment = new Appointment();
                                appointment.Doctor = doctor;
                                appointment.Patient = patient;
                                appointment.Date = date;
                                appointments.Add(appointment);
                                doctor.Patients.Add(patient);
                                Console.WriteLine("Cita agregada exitosamente.");
                            }
                            else
                            {
                                Console.WriteLine("Fecha no valida.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Paciente no encontrado.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("ID de paciente no valido.");
                    }
                }
                else
                {
                    Console.WriteLine("Doctor no encontrado.");
                }
            }
            else
            {
                Console.WriteLine("ID de doctor no valido.");
            }
        }

        static void ShowPatients()
        {
            Console.WriteLine("Listado de Pacientes:");
            foreach (var patient in patients)
            {
                Console.WriteLine($"{patient.Id}. {patient.Name}");
            }
        }
    }
}