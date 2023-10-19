using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ReservationManager : IReservationService
    {
        IReservationDal _reservationDal;

        public ReservationManager(IReservationDal reservationDal)
        {
            _reservationDal = reservationDal;
        }

        public IResult AddReservation(Reservation reservation)
        {
            _reservationDal.Add(reservation);
            return new SuccessResult();
        }

        public IResult DeleteReservation(Reservation reservation)
        {
            _reservationDal.Delete(reservation);
            return new SuccessResult();
        }

        public IDataResult<List<Reservation>> GetAll()
        {
            return new SuccessDataResult<List<Reservation>>(_reservationDal.GetAll());
        }

        public IResult UpdateReservation(Reservation reservation)
        {
            _reservationDal.Update(reservation);
            return new SuccessResult();
        }
    }
}
