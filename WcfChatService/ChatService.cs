﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfChatService
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class ChatService : IChatService
    {
        Dictionary<ChatUser, IChatCallbackService> users = new Dictionary<ChatUser, IChatCallbackService>();
        IChatCallbackService callback = null;

        public ChatService() { }

        public void Connect(ChatUser chatUser)
        {
            try
            {
                if (!users.ContainsKey(chatUser))
                {
                    callback = OperationContext.Current.GetCallbackChannel<IChatCallbackService>();
                    users.Add(chatUser, callback);
                    AddUserToClientsUsersLists(chatUser);
                    SendAllUsersToConnectedUser(chatUser);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void SendAllUsersToConnectedUser(ChatUser chatUser)
        {
            try
            {
                users[chatUser].GetAllUsersToAddToClientUsersList(users.Keys.ToList());
            }
            catch (Exception ex)
            {
                throw ex;
            };
        }

        private void AddUserToClientsUsersLists(ChatUser chatUser)
        {
            try
            {
                foreach (var user in users)
                {
                    IChatCallbackService proxy = user.Value;
                    proxy.GetUserToAddToClientUsersList(chatUser);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
/*
        private void SendUsersToAll()
        {
            try
            {
                var chatUsers = users.Keys.ToList();
                foreach (var user in users)
                {
                    IChatCallbackService proxy = user.Value;
                    proxy.SendChatUsers(chatUsers);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
*/
        public void SendMessage(Message message)
        {
            try
            {
                if (users.ContainsKey(message.Receiver))
                {
                    callback = users[message.Receiver];
                    callback.ReceiveMessage(message);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Disconnect(ChatUser chatUser)
        {
            try
            {
                if (users.ContainsKey(chatUser))
                {
                    users.Remove(chatUser);
                    DeleteUserFromClientsUsersLists(chatUser);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void DeleteUserFromClientsUsersLists(ChatUser chatUser)
        {
            try
            {
                foreach (var user in users)
                {
                    IChatCallbackService proxy = user.Value;
                    proxy.GetUserToDeleteFromClientUsersList(chatUser);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
