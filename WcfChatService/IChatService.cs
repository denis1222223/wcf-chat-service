using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfChatService
{
    [ServiceContract(CallbackContract = typeof(IChatCallbackService))]
    public interface IChatService
    {
        [OperationContract(IsOneWay = true)]
        void Connect(ChatUser chatUser);

        [OperationContract(IsOneWay = true)]
        void SendMessage(Message message);

        [OperationContract(IsOneWay = true)]
        void Disconnect(ChatUser chatUser);
    }
}
