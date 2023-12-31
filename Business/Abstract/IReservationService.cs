﻿using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IReservationService
    {
        IDataResult<List<Reservation>> GetAll();
        IDataResult<List<Reservation>> GetByUserId(int id);
        IDataResult<Reservation> GetById(int id);
        IResult AddReservation(Reservation reservation);
        IResult UpdateReservation(Reservation reservation);
        IResult DeleteReservation(Reservation reservation);
    }
}
