using System;
using System.Collections.Generic;
using System.Text;

namespace Satisfaction.Domain.Enumerations
{
    public class Enumeration
    {
        public enum SatisfactionRate
        {
            VeryDissatisfied = 1,//خیلی ناراضی
            Dissatisfied = 2,//ناراضی
            Neutral = 3,//متوسط
            Satisfied = 4,//راضی
            VerySatisfied = 5//خیلی راضی
        }
        //public enum SamplingMethod
        //{
        //    Selective = 1,//انتخابی
        //    AllEmbracing = 2,//تمام شمار
        //    FormulaBased = 3//بر اساس فرمول
        //}

        //public enum ImpactRate
        //{
        //    TenPercent = 10,
        //    TwentyPercent = 20,
        //    thirtyPercent = 30,
        //    FortyPercent = 40,
        //    FiftyPercent = 50,
        //    SixtyPercent = 60,
        //    SeventyPercent = 70,
        //    EightyPercent = 80,
        //    NinetyPercent = 90,
        //    HundredPercent = 100,
        //    Trimester = 3,//سه ماهه
        //    OneMonth = 1//یک ماهه 
        //}

        //public enum RoleType
        //{
        //    CRMSuperviser = 1,//CRM رئیس
        //    CRMManager = 2,//CRM مدیر
        //    Expert = 3,//کارشناس
        //    FranchiseManager = 4,//مدیر نمایندگی
        //    FranchiseExpert = 5//کارشناس نمایندگی
        //}
        //public enum CustomerState
        //{
        //    Respondent = 1,//پاسخگو به نظرسنجی
        //    Dissatisfied = 2,//ناراضی
        //    Rescheduled = 3,//دارای هشدار
        //    Pending=4//بلاتکلیف
        //}
        //public enum ContactType
        //{
        //    Email = 1,
        //    Mobile = 2,
        //}
        public enum SendType
        {
            Communication=1,//مخابرات
            Telegram = 2,
            WhatsApp =3,
            Email=4,
        }
    }
}
