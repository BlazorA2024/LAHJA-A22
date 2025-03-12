using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace LAHJA.Data.UI.Components.Templates_Subscriptions
{
    public class SubscriptionInfoTempla
    {
        public string SubscriptionLink { get; set; }
        public string SubscriptionTitle { get; set; }
        public string UserLink { get; set; }
        public string UserEmail { get; set; }
        public string UserPlan { get; set; }
        public string UserStatus { get; set; }
        public string SubscriptionId { get; set; }
        public string SubscrActions { get; set; }


    }
    
    public class SubscriptionDetails
    {
        public string StartDate { get; set; }
        public string NextInvoice { get; set; }
        public string TestModeDate { get; set; }
        public string Cancellation { get; set; }
        public string Invoice { get; set; }
        public string Started { get; set; }
    }
    
    public class SubscriptionItem
    {
        public string Label { get; set; }
        public string Value { get; set; }
        public string CustomerEmail { get; set; }
        public string CreatedDate { get; set; }
        public string CurrentPeriod { get; set; }
        public string Discounts { get; set; }
        public string BillingMethod { get; set; }
        public string PaymentMethod { get; set; }
        public string TaxCalculation { get; set; }
        public string UserLink { get; set; }


    }
    // نموذج البيانات
    public class PricingItem
    {
        public string ProductName { get; set; }
        public string Price { get; set; }
        public string SubscriptionId { get; set; }
        public int Quantity { get; set; }
        public string TotalPrice { get; set; }
        public string PricingtName { get; set; }
        public string Product { get; set; }
        public string SubscriptionItemId { get; set; }
        public int Qty { get; set; }
        public string Total { get; set; }
    }
   
    public class IDAddressInboxItem
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public bool HasIcon { get; set; } = false; // للتحكم في ظهور الأيقونة
    }
    public class Episode
    {
        public string Title { get; }
        public string Url { get; }
        public bool IsActive { get; }

        public Episode(string title, string url, bool isActive = false)
        {
            Title = title;
            Url = url;
            IsActive = isActive;
        }
    }

    public class Server
    {
        public string Name { get; }
        public string Url { get; }

        public Server(string name, string url)
        {
            Name = name;
            Url = url;
        }
    }

}
