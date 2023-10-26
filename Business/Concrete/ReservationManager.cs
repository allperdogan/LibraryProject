using Business.Abstract;
using Core.Utilities.Business;
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
            IResult result = BusinessRules.Run(CheckReturnDate(reservation.BookId));
            _reservationDal.Add(reservation);
            if (result != null)
            {
                return result;
            }
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

        public IDataResult<Reservation> GetById(int id)
        {
            return new SuccessDataResult<Reservation>(_reservationDal.Get(r=>r.Id==id));
        }

        public IResult UpdateReservation(Reservation reservation)
        {
            _reservationDal.Update(reservation);
            return new SuccessResult();
        }

        private IResult CheckReturnDate(int id)
        {
            var results = _reservationDal.GetAll(b=>b.BookId==id);
            foreach (var result in results)
            {
                if (result.ReturnDate > DateTime.Now)
                {
                    return new ErrorResult();
                }
            }
            return new SuccessResult();
        }
    }
}
