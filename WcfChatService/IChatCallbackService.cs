using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;

namespace WcfChatService
{
    public interface IChatCallbackService
    {
        [OperationContract(IsOneWay = true)]
        void ReceiveMessage(Message message);

        [OperationContract(IsOneWay = true)]
        void SendChatUsers(List<ChatUser> users);
    }
}
