using System;
using System.Collections.Generic;
using System.Text;

namespace DomainModels.Enums
{
    public enum State
    {
        RequestFromUser = 1,
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
                case State.RequestFromUser:
                    message = "";
                    break;
                case State.SendToGateway:
                    message = "";
                    break;
                case State.RequestFailed:
                    message = "";
                    break;
                case State.RequestSucceed:
                    message = "";
                    break;
                case State.SendToUser:
                    message = "";
                    break;
                case State.Finished:
                    message = "";
                    break;
                default:
                    message = "";
                    break;
            }

            return message;
        }

    }

}
