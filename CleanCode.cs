
using System;

public class PriceCalculator
{
    public IBasePriceRepository BasePriceRepository { get; set; }

    public IDiscountService DiscountService { get; set; }

    public decimal CalculatePrice(DateTime checkIn, DateTime checkOut)
    {
        var perNightPrice = BasePriceRepository.GetPerNightPrice();

        if (checkOut < checkIn)
        {
            throw new ArgumentException("Invalid dates");
        }

        var durationOfStay = (int)(checkIn.Date - checkOut.Date).TotalDays;

        var totalPrice = perNightPrice * durationOfStay;

        if (durationOfStay > 15)
        {
            totalPrice = DiscountService.ApplyExtendedStayDiscount(totalPrice);
        }

        if (durationOfStay <= 5
            && checkIn.DayOfWeek >= DayOfWeek.Monday
            && checkOut.DayOfWeek <= DayOfWeek.Friday)
        {
            totalPrice = DiscountService.ApplyWeekdayDiscount(totalPrice);
        }

        if (checkIn.Month == 4 && checkIn.Day == 1) //April 1st
        {
            totalPrice = totalPrice * .9m; //give them a 10% discount
        }

        /**
         * Temporarily Disabled. Product may bring this back in the future.
         * if (checkIn.Month == 12 && checkIn.Day == 31)
          {
            totalPrice = totalPrice * 1.1m; // 10% increase on New Years Eve
          }
         */

        return totalPrice;
    }

    public decimal CalculateFamilyPrice(decimal totalPrice, int numberOfGuests)
    {
        if (numberOfGuests > 2)
        {
            return DiscountService.ApplyFamilyDiscount(totalPrice);
        }

        return totalPrice;
    }
}

public interface IDiscountService
{
    decimal ApplyFamilyDiscount(decimal price);
    decimal ApplyWeekdayDiscount(decimal price);
    decimal ApplyExtendedStayDiscount(decimal price);
}


public interface IBasePriceRepository
{
    decimal GetPerNightPrice();
}
