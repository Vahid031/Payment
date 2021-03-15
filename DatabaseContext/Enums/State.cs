using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Enums
{
    public enum State
    {
        NewRequest = 1,
        SendToGateway = 2,
        RequestFailed = 3,
        RequestSucceed = 4,
        SendToUser = 5,
        Finished = 6
    }
    public static class Enums
    {
       
        public static string GetMessage(this State state)
        {
            string message;

            switch (state)
            {
                case State.NewRequest:
                    message = "درخواست ارسالی";
                    break;
                case State.SendToGateway:
                    message = "ارسال به درگاه";
                    break;
                case State.RequestFailed:
                    message = "ناموفق";
                    break;
                case State.RequestSucceed:
                    message = "موفق";
                    break;
                case State.SendToUser:
                    message = "ارسال جواب درخواست";
                    break;
                case State.Finished:
                    message = "اتمام عملیات";
                    break;
                default:
                    message = "نامعلوم";
                    break;
            }

            return message;
        }

    }

}
