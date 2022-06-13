﻿using Microsoft.EntityFrameworkCore;
using System;

namespace cwiczenia6_mp_s21461.Models
{
    public class MainDbContext : DbContext
    {

        protected MainDbContext()
        {


        }

        public MainDbContext(DbContextOptions options) : base(options)
        {


        }

        public DbSet<Patient> Patients { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Prescription> Prescriptions { get; set; }
        public DbSet<Prescription_Medicament> Prescription_Medicaments { get; set; }
        public DbSet<Medicament> Medicaments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Patient>(p =>
            {
                p.HasKey(e => e.IdPatient);
                p.Property(e => e.FirstName).IsRequired().HasMaxLength(100);
                p.Property(e => e.LastName).IsRequired().HasMaxLength(100);
                p.Property(e => e.Birthdate).IsRequired();

                p.HasData(
                    new Patient
                    {
                        IdPatient = 1,
                        FirstName = "Jan",
                        LastName = "Kowalski",
                        Birthdate = DateTime.Parse("1998-06-22")
                    },
                    new Patient
                    {
                        IdPatient = 2,
                        FirstName = "Ania",
                        LastName = "Kwiat",
                        Birthdate = DateTime.Parse("1996-03-02")
                    }
                    );
            });

            modelBuilder.Entity<Doctor>(d =>
            {
                d.HasKey(e => e.IdDoctor);
                d.Property(e => e.FirstName).IsRequired().HasMaxLength(100);
                d.Property(e => e.LastName).IsRequired().HasMaxLength(100);
                d.Property(e => e.Email).IsRequired().HasMaxLength(100);

                d.HasData(
                    new Doctor
                    {
                        IdDoctor = 1,
                        FirstName = "Mateusz",
                        LastName = "Rydzyk",
                        Email = "mr@pjatk.pl"
                    },
                    new Doctor
                    {
                        IdDoctor = 2,
                        FirstName = "Kamil",
                        LastName = "Ruski",
                        Email = "mr@pjatk.pl"
                    }
                    );
            });

            modelBuilder.Entity<Prescription>(p =>
            {
                p.HasKey(e => e.IdPrescription);
                p.Property(e => e.Date).IsRequired();
                p.Property(e => e.DueDate).IsRequired();

                p.HasOne(e => e.Patient).WithMany(e => e.Prescriptions).HasForeignKey(e => e.IdPatient);
                p.HasOne(e => e.Doctor).WithMany(e => e.Prescriptions).HasForeignKey(e => e.IdDoctor);

                p.HasData(
                    new Prescription
                    {
                        IdPrescription = 1,
                        Date = DateTime.Parse("2022-06-11"),
                        DueDate = DateTime.Parse("2022-07-11"),
                        IdPatient = 1,
                        IdDoctor = 2
                    },
                    new Prescription
                    {
                        IdPrescription = 2,
                        Date = DateTime.Parse("2022-01-22"),
                        DueDate = DateTime.Parse("2022-02-22"),
                        IdPatient = 2,
                        IdDoctor = 1
                    }
                    );
            });

            modelBuilder.Entity<Medicament>(m =>
            {
                m.HasKey(e => e.IdMedicament);
                m.Property(e => e.Name).IsRequired().HasMaxLength(100);
                m.Property(e => e.Description).IsRequired().HasMaxLength(100);
                m.Property(e => e.Type).IsRequired().HasMaxLength(100);

                m.HasData(
                    new Medicament
                    {
                        IdMedicament = 1,
                        Name = "syrop",
                        Description = "Opis leku",
                        Type = "typowy"
                    },
                    new Medicament
                    {
                        IdMedicament = 2,
                        Name = "tabletki",
                        Description = "niebieski lek",
                        Type = "nietypowy"
                    },
                    new Medicament
                    {
                        IdMedicament = 3,
                        Name = "maść",
                        Description = "na ból stawów",
                        Type = "klasyczny"
                    }
                    );
            });

            modelBuilder.Entity<Prescription_Medicament>(p =>
            {
                p.HasKey(e => e.IdPrescription);
                p.HasOne(e => e.Prescription).WithMany(e => e.Prescription_Medicaments).HasForeignKey(e => e.IdPrescription);
                p.HasKey(e => e.IdMedicament);
                p.HasOne(e => e.Medicament).WithMany(e => e.Prescription_Medicaments).HasForeignKey(e => e.IdMedicament);
                p.Property(e => e.Dose);
                p.Property(e => e.Details).IsRequired().HasMaxLength(100);

                p.HasData(
                    new Prescription_Medicament
                    {
                        IdMedicament = 1,
                        IdPrescription = 1,
                        Dose = 10,
                        Details = "mocne"
                    },
                    new Prescription_Medicament
                    {
                        IdMedicament = 2,
                        IdPrescription = 2,
                        Dose = 2,
                        Details = "słabe "
                    },
                    new Prescription_Medicament
                    {
                        IdMedicament = 3,
                        IdPrescription = 2,
                        Dose = 5,
                        Details = "umiarkowane"
                    }

                    );
            });
        }



    }
}
