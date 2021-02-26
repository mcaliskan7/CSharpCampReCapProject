using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Constants
{
    public static class Messages
    {
        public static string CarAdded = "Car Added Successfully!";
        public static string CarUpdated = "Car Updated Successfully!";
        public static string CarDeleted = "Car Deleted Successfully!";
        public static string BrandIdInvalid = "Invalid Brand Id, Registration Failed.";
        public static string ColorIdInvalid = "Invalid Color Id, Registration Failed.";
        public static string ModelYearInvalid = "Invalid Model Year, Registration Failed.";
        public static string DailyPriceInvalid = "Invalid Daily Price, Registration Failed!";       

        public static string BrandAdded = "Brand Added Successfully!";
        public static string BrandDeleted = "Brand Deleted Successfully!";
        public static string BrandUpdated = "Brand Updated Successfully!";
        public static string BrandNameInvalid = "Invalid Brand Name, Registration Failed!";

        public static string ColorAdded = "Color Added Successfully!";
        public static string ColorDeleted = "Color Deleted Successfully!";
        public static string ColorUpdated = "Color Updated Successfully!";
        public static string ColorNameInvalid = "Invalid Color Name, Registration Failed.";

        public static string MaintenanceTime = "System Maintenance";

        public static string UserAdded = "User Added Successfully!";
        public static string UserDeleted = "User Deleted Successfully!";
        public static string UserUpdated = "User Updated Successfully!";
        public static string FirstNameInvalid = "Invalid First Name, Registration Failed.";
        public static string LastNameInvalid = "Invalid Last Name, Registration Failed.";
        public static string EmailInvalid = "Invalid Email, Registration Failed.";
        public static string PasswordInvalid = "Invalid Password, Registration Failed.";

        public static string CustomerAdded = "Customer Added Successfully!";
        public static string CustomerDeleted = "Customer Deleted Successfully!";
        public static string CustomerUpdated = "Customer Updated Successfully!";
        public static string UserIdInvalid = "Invalid User Id, Registration Failed.";
        public static string CompanyNameInvalid = "Invalid Company Name, Registration Failed.";

        public static string RentalAdded = "Car Rented Successfully!";
        public static string RentalAddFailed = "Car has not been delivered yet!";
        public static string RentalUpdated = "Rental Updated Successfully!";
        public static string RentalUpdateFailed = "Car has already been delivered!";  
        public static string RentalCarIdInvalid = "Invalid Car Id, Registration Failed.";
        public static string CustomerIdInvalid = "Invalid Customer Id, Registration Failed.";
        public static string RentDateInvalid = "Invalid Rent Date, Registration Failed.";

        public static string CarImageAdded = "Car Image Added Successfully!";
        public static string CarImageCarIdInvalid = "Invalid Car Id, Registration Failed.";
        public static string CarImageDeleted = "Car Image Deleted Successfully!";
        public static string CarImageUpdated = "Car Image Updated Successfully!";
        public static string CarImageLimitExceeded = "Car Image Limit Exceeded!";       
    }
}