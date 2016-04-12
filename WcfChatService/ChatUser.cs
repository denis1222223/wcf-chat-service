using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace WcfChatService
{
    [DataContract]
    public class ChatUser
    {
        [DataMember]
        public string Name { get; set; }

    }
}
