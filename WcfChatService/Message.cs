using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace WcfChatService
{
    [DataContract]
    public class Message
    {
        [DataMember]
        public ChatUser Sender { get; set; }

        [DataMember]
        public ChatUser Receiver { get; set; }

        [DataMember]
        public string Text { get; set; }

        [DataMember]
        public DateTime Time { get; set; }
    }
}
