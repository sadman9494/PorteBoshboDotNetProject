using DAL.EF;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class PaymentRepo : IRepo<Payment>, IPayment
    {
        private PorteBoshboEntities db = new PorteBoshboEntities();
        public bool Add(Payment obj)
        {
            db.Payments.Add(obj);
            return db.SaveChanges() > 0;
        }

        public Payment Get(int id)
        {
            return db.Payments.Find(id);
        }

        public List<Payment> ReceivedPayments(int teacherId)
        {
            var payments = (from p in db.Payments
                          where p.TeacherId==teacherId
                          select p).ToList();
            return payments;
        }


        public List<Payment> PaidPaytments(int stundetId)
        {
            var payments = (from p in db.Payments
                            where p.StudentId== stundetId
                            select p).ToList();
            return payments;
        }

        public List<Payment> GetAll()
        {
            return db.Payments.ToList();
        }

        public bool Remove(int id)
        {
            db.Payments.Remove(Get(id));
            return db.SaveChanges() > 0;
        }

        public bool Update(Payment obj)
        {
            db.Entry(Get(obj.PaymentId)).CurrentValues.SetValues(obj);
            return db.SaveChanges() > 0;
        }
    }
}
