﻿using DoctorAppointment.Persistence.EF;
using DoctorAppointment.Persistence.EF.Doctors;
using DoctorAppointment.Services.Doctors;
using DoctorAppointment.Services.Doctors.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DoctorAppointment.Persistence.EF;

namespace DoctorAppointment.Test.Tools.Infrastructure.Doctors
{
    public static class DoctorServiceFactory
    {
        public static DoctorService Create(EFDataContext context)
        {
            return new DoctorAppService(new EFDoctorRepository(context), new EFUnitOfWork(context));
        }
    }
}
