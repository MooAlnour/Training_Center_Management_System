using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TC_DataAccess;

namespace TC_Bussines
{
    public class PaymentBL
    {
            public enum enMode { AddNew = 0, Update = 1 };
            public enMode Mode = enMode.AddNew;
            public int PaymentID { set; get; }
            public int EnrollmentID { set; get; }

            public EnrollmentBL EnrollmentInfo;
            public decimal Amount { set; get; }
            public DateTime PaymentDate { set; get; }
            public string Method { set; get; }
            public string Notes { set; get; }

            public PaymentBL()
            {
                this.PaymentID = -1;
                this.EnrollmentID = -1;
                this.Amount = 0;
                this.PaymentDate = DateTime.Now;
                this.Method = "";
                this.Notes = "";

                Mode = enMode.AddNew;
            }

            private PaymentBL(int paymentID, int enrollmentID, decimal amount,
                DateTime paymentDate, string method, string notes)
            {
                this.PaymentID = paymentID;
                this.EnrollmentID = enrollmentID;
                EnrollmentInfo = EnrollmentBL.FindByEnrollmentID(EnrollmentID);
                this.Amount = amount;
                this.PaymentDate = paymentDate;
                this.Method = method;
                this.Notes = notes;

                Mode = enMode.Update;
            }

            public static PaymentBL FindByPaymentID(int paymentID)
            {

                int enrollmentID = -1;
                decimal amount = 0;
                DateTime paymentDate = DateTime.Now;
                string method = "", notes = "";

                bool IsFound = PaymentDL.GetPaymentInfoByPaymentID(
                    paymentID,
                    ref enrollmentID,
                    ref amount,
                    ref paymentDate,
                    ref method,
                    ref notes);

                if (IsFound)
                    return new PaymentBL(paymentID, enrollmentID, amount,
                        paymentDate, method, notes);
                else
                    return null;

            }

            public static PaymentBL FindByEnrollmentID(int EnrollmentID)
            {

                int paymentID = -1;
                decimal amount = 0;
                DateTime paymentDate = DateTime.Now;
                string method = "", notes = "";

                bool IsFound = PaymentDL.GetPaymentInfoByEnrollmentID(
                    EnrollmentID,
                    ref paymentID,
                    ref amount,
                    ref paymentDate,
                    ref method,
                    ref notes);

                if (IsFound)
                    return new PaymentBL(paymentID, EnrollmentID, amount,
                        paymentDate, method, notes);
                else
                    return null;

            }

        // Validation Mothed For Add new Payment

      
            private bool _ValidatePaymentData(ref string ErrorMessage)
            {
                if (Amount <= 0)
                {
                    ErrorMessage = " Amount must be greater than 0 ";
                    return false;
                }

                if (PaymentDate>DateTime.Now)
                {
                    ErrorMessage = "Payment Date is grad then date time now ";
                    return false;
                }
                if (!EnrollmentBL.IsEnrollmentExist(EnrollmentID))
                {
                    ErrorMessage = "there are not enrollment ";
                    return false;
                }

                if (EnrollmentBL.IsEnrollmentCancelled(EnrollmentID))
                {
                    ErrorMessage = "The  Enrollment was Cancelled ";
                    return false;
                }
                return true;
            }

            private bool _AddNewPayment()
            {

                this.PaymentID = PaymentDL.AddNewPayment(
                    this.EnrollmentID,
                    this.Amount,
                    this.PaymentDate,
                    this.Method,
                    this.Notes);

                return (this.PaymentID != -1);

            }

            private bool _UpdatePayment()
            {

                return PaymentDL.UpdatePayment(
                    this.PaymentID,
                    this.EnrollmentID,
                    this.Amount,
                    this.PaymentDate,
                    this.Method,
                    this.Notes);

            }

            public bool Save()
            {

                switch (Mode)
                {

                    case enMode.AddNew:

                        if (_AddNewPayment())
                        {

                            Mode = enMode.Update;
                            return true;

                        }
                        else
                        {
                            return false;
                        }

                    case enMode.Update:

                        return _UpdatePayment();

                }

                return false;

            }

            public static DataTable GetAllPayments()
            {
                return PaymentDL.GetAllPayments();
            }

        // Validation Mothed For delete Payment
        private static bool CanDeletePayment(int paymentID, ref string ErrorMessage)
        {
            PaymentBL payment = PaymentBL.FindByPaymentID(paymentID);

            if (payment == null)
            {
                ErrorMessage = "Payment not found.";
                return false;
            }

            if (!EnrollmentBL.IsEnrollmentExist(payment.EnrollmentID))
            {
                ErrorMessage = "Enrollment not found.";
                return false;
            }

            if (EnrollmentBL.IsEnrollmentCancelled(payment.EnrollmentID))
            {
                ErrorMessage = "Cannot delete payment because enrollment is cancelled.";
                return false;
            }

            return true;
        }

        public static bool DeletePayment(int paymentID, ref string ErrorMessage)
        {
            if (!CanDeletePayment(paymentID, ref ErrorMessage))
                return false;
            return PaymentDL.DeletePayment(paymentID);
        }

        public static bool IsPaymentExist(int ID)
            {
                return PaymentDL.IsPaymentExist(ID);
            }

       
    }
    
}
